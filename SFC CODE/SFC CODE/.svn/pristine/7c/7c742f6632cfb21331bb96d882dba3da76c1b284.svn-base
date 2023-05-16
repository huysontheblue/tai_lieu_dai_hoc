
'--生产时段维护
'--Create by :　马锋
'--Create date :　2017/01/12
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
Imports SysBasicClass
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
Imports DevComponents.DotNetBar.Controls
Imports MainFrame

#End Region

Public Class FrmProductionTimeMaster

#Region "窗体事件"

    Private Sub FrmProductionTimeMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvQuery.AutoGenerateColumns = False
            SetStatus(0)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        Try
            SetStatus(1)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "新增异常", False)
        End Try
    End Sub

    Private Sub ToolAgain_Click(sender As Object, e As EventArgs) Handles ToolAgain.Click
        Try
            'If (String.IsNullOrEmpty(Me.mtxtLine.Text.Trim())) Then
            '    GetMesData.SetMessage(Me.lblMessage, "重新下载工单不能为空", False)
            '    Me.ActiveControl = Me.mtxtLine
            '    Return
            'End If

            'Dim strSQL As StringBuilder = New StringBuilder

            'strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(128) ")
            'strSQL.AppendLine(" EXEC GetAgainTiptopMOPlan @RTVALUE OUTPUT, @RTMSG OUTPUT, '', '', '" & VbCommClass.VbCommClass.UseId & "', '" & Me.txtMOId.Text.Trim & "' ")
            'strSQL.AppendLine(" SELECT @RTVALUE, @RTMSG  ")

            'Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

            'If (Not dtTemp Is Nothing And dtTemp.Rows.Count > 0) Then

            '    If (dtTemp.Rows(0).Item(0).ToString = "1") Then
            '        GetMesData.SetMessage(Me.lblMessage, "重新下载工单成功", True)
            '    Else
            '        GetMesData.SetMessage(Me.lblMessage, dtTemp.Rows(0).Item(1).ToString, False)
            '    End If
            'End If

            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "下载异常", False)
        End Try
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        Try
            If Me.dgvQuery.Rows.Count = 0 OrElse Me.dgvQuery.CurrentRow Is Nothing Then
                GetMesData.SetMessage(lblMessage, "请选择要修改数据", False)
                Exit Sub
            End If

            Me.mtxtLine.Text = Me.dgvQuery.CurrentRow.Cells("LineId").Value
            Me.txtProductionTimeName.Text = Me.dgvQuery.CurrentRow.Cells("ProductionTimeName").Value
            Me.dtpStart.Text = Me.dgvQuery.CurrentRow.Cells("StartTime").Value
            Me.dtpEnd.Text = Me.dgvQuery.CurrentRow.Cells("EndTime").Value
            Me.txtProductionTimeValue.Text = Me.dgvQuery.CurrentRow.Cells("ProductionTimeValue").Value

            SetStatus(1)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "修改异常", False)
        End Try
    End Sub

    Private Sub ToolDelete_Click(sender As Object, e As EventArgs) Handles ToolDelete.Click
        Try

        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "删除异常", False)
        End Try
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click
        Try
            If (Not CheckSave()) Then
                Exit Sub
            End If

            Dim strSQL As New StringBuilder
            strSQL.AppendLine(" IF EXISTS(SELECT LineId FROM m_ProductionTime_t WHERE LineId = '" & Me.mtxtLine.Text.Trim & "' AND ProductionTimeName='" & Me.txtProductionTimeName.Text.Trim & "') BEGIN UPDATE m_ProductionTime_t SET ProductionTimeName = N'" & Me.txtProductionTimeName.Text.Trim & "', StartTime = '" & Me.dtpStart.Text.Trim & "', EndTime = '" & Me.dtpEnd.Text.Trim & "', ProductionTimeValue = '" & Me.txtProductionTimeValue.Text.Trim & "' WHERE LineId = '" & Me.mtxtLine.Text.Trim & "' End Else BEGIN ")
            strSQL.AppendLine(" INSERT INTO m_ProductionTime_t( LineId, ProductionTimeName, StartTime, EndTime, ProductionTimeValue, ProductivityType, CreateUserId, CreateTime)VALUES( '" & Me.mtxtLine.Text.Trim & "', N'" & Me.txtProductionTimeName.Text.Trim & "', '" & Me.dtpStart.Text.Trim & "', '" & Me.dtpEnd.Text.Trim & "', '" & Me.txtProductionTimeValue.Text.Trim & "', '1', '" & VbCommClass.VbCommClass.UseId & "', GETDATE() ) End ")

            DbOperateUtils.ExecSQL(strSQL.ToString)

            SetStatus(0)
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存异常", False)
        End Try
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        Try
            SetStatus(0)
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "返回异常", False)
        End Try
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        Try
            GetProductionTime()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "退出异常", False)
        End Try
    End Sub

    Private Sub mtxtLine_ButtonCustomClick(sender As Object, e As EventArgs) Handles mtxtLine.ButtonCustomClick
        Try



            Dim frmLineQuery As New FrmLineQuery(Me.mtxtLine.Text)
            'frmLineQuery.ShowDialog()
            'update by hgd 2017-03-31  返回部门代码
            If frmLineQuery.ShowDialog() = Windows.Forms.DialogResult.Yes Then


            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "选择异常", False)
        End Try
    End Sub

#End Region

#Region "方法"

    Private Sub SetStatus(ByVal statusFlag As Int16)
        Select Case (statusFlag)
            Case 0
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolAgain.Enabled = True
                Me.ToolCommit.Enabled = False
                Me.ToolBack.Enabled = False
                Me.ToolQuery.Enabled = True
                Me.ToolExitFrom.Enabled = True
            Case 1
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolAgain.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolBack.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolExitFrom.Enabled = False
        End Select
    End Sub

    Private Sub GetProductionTime()
        Try
            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine("SELECT ProductionTimeId, LineId, ProductionTimeName, StartTime, EndTime, ProductionTimeValue, ProductivityType, CreateUserId, CreateTime FROM m_ProductionTime_t WHERE 1=1 ")

            If Not String.IsNullOrEmpty(Me.mtxtLine.Text.Trim()) Then
                strSQL.AppendLine(" AND LineId LIKE '%" & Me.mtxtLine.Text.Trim & "%' ")
            End If

            Me.dgvQuery.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "查询异常", False)
        End Try
    End Sub

    Private Function CheckSave() As Boolean
        Try
            'If (String.IsNullOrEmpty(Me.mtxtLine.Text.Trim)) Then
            '    GetMesData.SetMessage(Me.lblMessage, "产线不能为空", False)
            '    Return False
            'End If

            If (String.IsNullOrEmpty(Me.txtProductionTimeName.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "时段名称不能为空", False)
                Return False
            End If

            If (String.IsNullOrEmpty(Me.dtpStart.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "开始时间不能为空", False)
                Return False
            End If

            If (String.IsNullOrEmpty(Me.dtpEnd.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "结束时间不能为空", False)
                Return False
            End If

            If (String.IsNullOrEmpty(Me.txtProductionTimeValue.Text.Trim)) Then
                GetMesData.SetMessage(Me.lblMessage, "时间值不能为空", False)
                Return False
            Else
                If Not IsNumeric(Me.txtProductionTimeValue.Text.Trim) Then
                    GetMesData.SetMessage(Me.lblMessage, "时间值必须为数字", False)
                    Return False
                Else
                    If (CDbl(Me.txtProductionTimeValue.Text.Trim) <= 0) Then
                        GetMesData.SetMessage(Me.lblMessage, "时间值必须大于0", False)
                        Return False
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "保存检查异常", False)
            Return False
        End Try
    End Function

#End Region


End Class