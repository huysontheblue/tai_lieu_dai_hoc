

'--料号包装检查设置
'--Create by :　马锋
'--Create date :　2016/09/26
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
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region

Public Class FrmPackingCheckMaster

    Dim opFlag As Int16 = 0
    Dim DataType As String

#Region "窗体事件"

    Private Sub FrmPackingCheckMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dgvPackingCheckSetting.AutoGenerateColumns = False
        SetStatus(opFlag)
        GetPackingCheckSetting()
        Me.ActiveControl = Me.txtPartId
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolNew_Click(sender As Object, e As EventArgs) Handles ToolNew.Click
        DataType = "NEW"
        opFlag = 1
        SetStatus(opFlag)
    End Sub

    Private Sub ToolEdit_Click(sender As Object, e As EventArgs) Handles ToolEdit.Click
        If Me.dgvPackingCheckSetting.Rows.Count = 0 OrElse Me.dgvPackingCheckSetting.CurrentRow Is Nothing Then
            MessageBox.Show("请选择修改的料号")
            Exit Sub
        End If
        DataType = "EDIT"
        opFlag = 2
        SetStatus(opFlag)
    End Sub

    Private Sub ToolCommit_Click(sender As Object, e As EventArgs) Handles ToolCommit.Click

        Dim strSQL As StringBuilder = New StringBuilder
        Select Case (DataType)
            Case "NEW"
                If (String.IsNullOrEmpty(Me.txtPartId.Text.Trim)) Then
                    MessageBox.Show("料号不能为空")
                    Me.ActiveControl = Me.txtPartId
                    Exit Sub
                End If

                If (Not String.IsNullOrEmpty(Me.txtNumberDdivisions.Text.Trim)) Then
                    If (Not IsNumeric(Me.txtNumberDdivisions.Text.Trim)) Then
                        MessageBox.Show("重复数不是数字")
                        Exit Sub
                    End If

                    If (CInt(Me.txtNumberDdivisions.Text.Trim) <= 0) Then
                        MessageBox.Show("重复数必须大于0")
                        Exit Sub
                    End If
                End If

                Dim dtPartTemp As DataTable = DbOperateUtils.GetDataTable("SELECT TAvcPart FROM m_PartContrast_t WHERE TAvcPart = '" & Me.txtPartId.Text.Trim & "'")

                If (dtPartTemp Is Nothing Or dtPartTemp.Rows.Count <= 0) Then
                    MessageBox.Show("料号不存在存在")
                    Me.ActiveControl = Me.txtPartId
                    Exit Sub
                End If

                strSQL.AppendLine("SELECT PartId FROM m_PackingCheckSetting_t WHERE PartId = '" & Me.txtPartId.Text.Trim & "'")
                Dim dtTemp As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)

                If (dtTemp.Rows.Count > 0) Then
                    MessageBox.Show("料号包装检查设置已经存在")
                    Me.ActiveControl = Me.txtPartId
                    Exit Sub
                End If

                DbOperateUtils.ExecSQL("INSERT INTO m_PackingCheckSetting_t(PartId, AffiliatedBarCode, NumberDdivisions, CreateUserId, CreateTime)VALUES('" & Me.txtPartId.Text.Trim & "','" & Me.txtAffiliatedBarCode.Text.Trim & "','" & Me.txtNumberDdivisions.Text.Trim & "','" & VbCommClass.VbCommClass.UseId & "',GETDATE())")

            Case "EDIT"
                If (String.IsNullOrEmpty(Me.txtPartId.Text.Trim)) Then
                    MessageBox.Show("料号不能为空")
                    Me.ActiveControl = Me.txtPartId
                    Exit Sub
                End If

                If (Not String.IsNullOrEmpty(Me.txtNumberDdivisions.Text.Trim)) Then
                    If (Not IsNumeric(Me.txtNumberDdivisions.Text.Trim)) Then
                        MessageBox.Show("重复数不是数字")
                        Exit Sub
                    End If

                    If (CInt(Me.txtNumberDdivisions.Text.Trim) <= 0) Then
                        MessageBox.Show("重复数必须大于0")
                        Exit Sub
                    End If
                End If
                DbOperateUtils.ExecSQL("UPDATE m_PackingCheckSetting_t SET AffiliatedBarCode='" & Me.txtAffiliatedBarCode.Text.Trim & "', NumberDdivisions='" & Me.txtNumberDdivisions.Text.Trim & "', CreateUserId='" & VbCommClass.VbCommClass.UseId & "', CreateTime = GETDATE() WHERE  PartId = '" & Me.txtPartId.Text.Trim & "' ")

        End Select
        opFlag = 0
        SetStatus(opFlag)
        GetPackingCheckSetting()
    End Sub

    Private Sub ToolBack_Click(sender As Object, e As EventArgs) Handles ToolBack.Click
        opFlag = 0
        SetStatus(opFlag)
    End Sub

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        GetPackingCheckSetting()
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub


    Private Sub dgvPackingCheckSetting_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPackingCheckSetting.CellEnter
        If Me.dgvPackingCheckSetting.Rows.Count = 0 OrElse Me.dgvPackingCheckSetting.CurrentRow Is Nothing Then
            Me.txtPartId.Text = ""
            Me.txtAffiliatedBarCode.Text = ""
            Me.txtNumberDdivisions.Text = ""
            Exit Sub
        End If

        Me.txtPartId.Text = Me.dgvPackingCheckSetting.Rows(Me.dgvPackingCheckSetting.CurrentRow.Index).Cells("PartId").Value
        Me.txtAffiliatedBarCode.Text = Me.dgvPackingCheckSetting.Rows(Me.dgvPackingCheckSetting.CurrentRow.Index).Cells("AffiliatedBarCode").Value
        Me.txtNumberDdivisions.Text = Me.dgvPackingCheckSetting.Rows(Me.dgvPackingCheckSetting.CurrentRow.Index).Cells("NumberDdivisions").Value

    End Sub

#End Region

#Region "方法"

    Private Sub SetStatus(ByVal Flag As Int16)
        Select Case Flag
            Case 0     '初始
                Me.ToolNew.Enabled = True
                Me.ToolEdit.Enabled = True
                Me.ToolCommit.Enabled = False
                Me.ToolQuery.Enabled = True
                Me.ToolBack.Enabled = False

                Me.txtPartId.Enabled = True
                Me.txtAffiliatedBarCode.Enabled = False
                Me.txtNumberDdivisions.Enabled = False
                Me.dgvPackingCheckSetting.Enabled = True
            Case 1    '新增
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True

                Me.txtPartId.Text = ""
                Me.txtAffiliatedBarCode.Text = ""
                Me.txtNumberDdivisions.Text = ""

                Me.txtPartId.Enabled = True
                Me.txtAffiliatedBarCode.Enabled = True
                Me.txtNumberDdivisions.Enabled = True
                Me.dgvPackingCheckSetting.Enabled = False
            Case 2  '修改
                Me.ToolNew.Enabled = False
                Me.ToolEdit.Enabled = False
                Me.ToolCommit.Enabled = True
                Me.ToolQuery.Enabled = False
                Me.ToolBack.Enabled = True

                Me.txtPartId.Enabled = False
                Me.txtAffiliatedBarCode.Enabled = True
                Me.txtNumberDdivisions.Enabled = True
                Me.dgvPackingCheckSetting.Enabled = False
        End Select
    End Sub

    Private Sub GetPackingCheckSetting()
        Dim strSQL As StringBuilder = New StringBuilder
        strSQL.AppendLine("SELECT   PartId, AffiliatedBarCode, NumberDdivisions, CreateUserId, CreateTime FROM   m_PackingCheckSetting_t WHERE 1= 1 ")
        If (Not String.IsNullOrEmpty(Me.txtPartId.Text.Trim)) Then
            strSQL.AppendLine(" AND PartId LIKE '%" & Me.txtPartId.Text.Trim & "%'")
        End If
        Me.dgvPackingCheckSetting.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
    End Sub

#End Region

End Class