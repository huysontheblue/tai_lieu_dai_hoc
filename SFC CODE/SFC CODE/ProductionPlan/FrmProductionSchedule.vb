
'--生产时段维护
'--Create by :　田玉琳
'--Create date :　2017/08/22
'--Update date :  
'--Ver : V01

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame

#End Region

Public Class FrmProductionSchedule

#Region "窗体事件"

    Public opflag As Int16 = 0  '

    Private Sub FrmProductionTimeMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.gridView.AutoGenerateColumns = False

            ToolbtnState(0)

            PlanCommon.BindComboxClass(Me.cmbClass)

        Catch ex As Exception
            GetMesData.SetMessage(Me.LblMsg, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    '新增
    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles toolAdd.Click
        Try
            opflag = 1
            ToolbtnState(1)
            LblMsg.Text = "请新增数据"
        Catch ex As Exception
            GetMesData.SetMessage(Me.LblMsg, "新增异常", False)
        End Try
    End Sub

    '编辑
    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        Try
            If Me.gridView.Rows.Count = 0 OrElse Me.gridView.CurrentRow Is Nothing Then Exit Sub

            txtLine.Text = gridView.CurrentRow.Cells("LineId").Value
            txtDept.Text = gridView.CurrentRow.Cells("DeptID").Value
            cmbClass.Text = gridView.CurrentRow.Cells("ClassName").Value
            txtMans.Text = gridView.CurrentRow.Cells("ManpowerValue").Value
            txtRate.Text = gridView.CurrentRow.Cells("ProductiveValue").Value

            opflag = 2
            ToolbtnState(2)
            LblMsg.Text = "请修改数据"
        Catch ex As Exception
            GetMesData.SetMessage(Me.LblMsg, "修改异常", False)
        End Try
    End Sub

    '保存
    Private Sub toolSave_Click(sender As Object, e As EventArgs) Handles toolSave.Click
        Try
            Dim strSQL As String = ""
            If Checkdata() = False Then Exit Sub
            Dim msg As String = ""
            If opflag = 1 Then  '新增
                strSQL = strSQL + "INSERT INTO [m_APSPlanLine_t]([DeptID],[LineID],[ClassName] ,[ProductiveValue] ,[ManpowerValue] ,[UseY] ,[CreateUserId] ,CreateTime)) " &
                         "  VALUES (" &
                         " N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'Y',N'{5}',getdate()"
                strSQL = String.Format(strSQL, "", txtDept.Text.Trim, txtLine.Text.Trim, cmbClass.Text, txtRate.Text.Trim, txtMans.Text.Trim, VbCommClass.VbCommClass.UseId)
                msg = "新增"
            ElseIf opflag = 2 Then     '修改
                strSQL = "UPDATE m_APSPlanLine_t set ClassName =N'{0}',ProductiveValue='{1}',ManpowerValue='{2}' ,CreateTime = getdate() where LineID = '{3}'"
                strSQL = String.Format(strSQL, cmbClass.Text, txtRate.Text, txtMans.Text, txtLine.Text.Trim)
                msg = "修改"
            End If
            DbOperateUtils.ExecSQL(strSQL)
            LblMsg.Text = msg + "操作成功..."
            MessageUtils.ShowInformation(LblMsg.Text)
            GetProductionTime()
            opflag = 0
            ToolbtnState(0)
        Catch ex As Exception
            GetMesData.SetMessage(Me.LblMsg, "操作异常", False)
        End Try
    End Sub

    Private Function Checkdata()
        If IsNumeric(txtMans.Text.Trim) = False Then
            txtMans.Focus()
            LblMsg.Text = "人力请输入数字..."
            MessageUtils.ShowInformation(LblMsg.Text)
            Return False
        End If
        If IsNumeric(txtRate.Text.Trim) = False Then
            txtRate.Focus()
            LblMsg.Text = "生产效率请输入数字..."
            MessageUtils.ShowInformation(LblMsg.Text)
            Return False
        End If
        Return True
    End Function

    '作废
    Private Sub toolAbandon_Click(sender As Object, e As EventArgs) Handles toolAbandon.Click
        Try
            If Me.gridView.Rows.Count = 0 OrElse Me.gridView.CurrentRow Is Nothing Then
                GetMesData.SetMessage(LblMsg, "请选择要作废的数据", False)
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            Dim LINEID As String = Me.gridView.CurrentRow.Cells("LINEID").Value
            strSQL.AppendLine(" UPDATE m_APSPlanLine_t SET USEY = 'N'  WHERE  lINEID='" & LINEID & "'")
            DbOperateUtils.ExecSQL(strSQL.ToString)
            ToolbtnState(0)
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.LblMsg, "删除异常", False)
        End Try
    End Sub

    '导出
    Private Sub toolExport_Click(sender As Object, e As EventArgs) Handles toolExport.Click

    End Sub

    '导入
    Private Sub toolImport_Click(sender As Object, e As EventArgs) Handles toolImport.Click

    End Sub

    '班别维护
    Private Sub toolClass_Click(sender As Object, e As EventArgs) Handles toolClass.Click
        Dim frm As New FrmClassSet
        frm.ShowDialog()
    End Sub

    '返回
    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        Try
            ToolbtnState(0)
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.LblMsg, "返回异常", False)
        End Try
    End Sub

    '查询 
    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.LblMsg, "查询异常：" + ex.Message.ToString, False)
        End Try
    End Sub

    '退出
    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

    '线别
    Private Sub mtxtLine_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtLine.ButtonCustomClick
        Try

            Dim deptid As String = String.Empty

            Dim frmLineQuery As New FrmLineQuery(Me.txtLine.Text)

            If frmLineQuery.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                Me.txtLine.Text = frmLineQuery._txtLineIdContral
                Me.txtDept.Text = frmLineQuery._DialogDeptID
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.LblMsg, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "方法"

    Private Sub Clear()
        Me.txtLine.Text = ""
        Me.txtMans.Text = ""
        Me.txtRate.Text = ""
    End Sub

    Private Sub GetProductionTime()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            gridView.DataSource = Nothing
            strSQL.AppendLine("SELECT DeptID, LineID, ClassName, ProductiveValue, ManpowerValue, UseY, CreateUserId, CreateTime FROM [dbo].[m_APSPlanLine_t] WHERE 1=1 and UseY = 'Y' ")

            If Not String.IsNullOrEmpty(Me.txtLine.Text.Trim()) Then
                strSQL.AppendLine(" AND LineId LIKE '%" & Me.txtLine.Text.Trim & "%' ")
            End If
            If Not String.IsNullOrEmpty(Me.txtDept.Text.Trim()) Then
                strSQL.AppendLine(" AND deptid = '" & Me.txtDept.Text.Trim & "' ")
            End If
            Me.gridView.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.LblMsg, "查询异常", False)
        End Try
    End Sub

    '按钮控制
    Private Sub ToolbtnState(ByVal flag As Int16)
        Select Case flag
            Case 0 '
                Me.toolAdd.Enabled = True
                Me.toolEdit.Enabled = True
                Me.toolAbandon.Enabled = True
                Me.toolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.toolQuery.Enabled = True
            Case 1, 2
                Me.toolAdd.Enabled = False
                Me.toolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.toolBack.Enabled = True
                Me.toolSave.Enabled = True
                Me.toolQuery.Enabled = False
            Case 3
                Me.toolAdd.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.toolAbandon.Enabled = False
                Me.ToolBack.Enabled = False
                Me.toolSave.Enabled = False
                Me.ToolQuery.Enabled = True
        End Select
    End Sub


#End Region

End Class