
'--标签需求确认
'--Create by :　马锋
'--Create date :　2016/09/22
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
Imports BarCodePrint.SqlClassM
Imports BarCodePrint.SqlClassD
Imports MainFrame

#End Region

Public Class FrmPrintQCCheck


#Region "窗体事件"

    Private Sub FrmPrintQCCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.dgvPrintList.AutoGenerateColumns = False

            Me.dtpEndDate.Value = Now.AddDays(-1)
            Me.dtpStartDate.Value = Now.AddDays(1)

            Me.txtMOId.Focus()
        Catch ex As Exception
            SetMessage("加载异常", False)
        End Try
    End Sub

#End Region

#Region "菜单事件"

    Private Sub ToolQuery_Click(sender As Object, e As EventArgs) Handles ToolQuery.Click
        SetMessage("", False)
        Try
            If CheckQueryParameter(True) Then
                Return
            End If

            Me.txtDemandInfo.Text = ""
            Me.txtCheckDemandInfo.Text = ""
            Me.txtNote.Text = ""

            GetPrintList()
        Catch ex As Exception
            SetMessage("查询异常", False)
        End Try
    End Sub

    Private Sub ToolMove_Click(sender As Object, e As EventArgs) Handles ToolMove.Click
        SetMessage("", False)
        Try
            If Me.dgvPrintList.Rows.Count = 0 OrElse Me.dgvPrintList.CurrentRow Is Nothing Then
                SetMessage("请选择作废申请单", False)
                Exit Sub
            End If

            Dim strStatusFlag As String
            strStatusFlag = Me.dgvPrintList.Rows(Me.dgvPrintList.CurrentRow.Index).Cells("StatusFlag").Value
            If (strStatusFlag = "4") Then
                SetMessage("该单已经作废", False)
                Exit Sub
            End If

            If (strStatusFlag = "1") Then
                SetMessage("已经审核需求单，不允许作废!", False)
                Exit Sub
            End If

            Dim strMODemandId As String
            Dim strSQL As StringBuilder = New StringBuilder

            strMODemandId = Me.dgvPrintList.Rows(Me.dgvPrintList.CurrentRow.Index).Cells("MODemandId").Value
            strSQL.AppendLine("UPDATE m_MODemand_t SET StatusFlag = '4', InvalidUserId = '" & VbCommClass.VbCommClass.UseId & "', InvalidTime = GETDATE(), Note = N'" & Me.txtNote.Text.Trim.Replace("'", "''") & "' WHERE MODemandId = '" & strMODemandId & "'")

            DbOperateUtils.ExecSQL(strSQL.ToString)

            SetMessage("作废成功", True)
            GetPrintList()
        Catch ex As Exception
            SetMessage("加载异常", False)
        End Try
    End Sub

    Private Sub toolCheck_Click(sender As Object, e As EventArgs) Handles toolCheck.Click
        SetMessage("", False)
        Try
            If Me.dgvPrintList.Rows.Count = 0 OrElse Me.dgvPrintList.CurrentRow Is Nothing Then
                SetMessage("请选择审核申请单", False)
                Exit Sub
            End If

            If (String.IsNullOrEmpty(Me.txtCheckDemandInfo.Text.Trim)) Then
                SetMessage("请扫描确认条码内容", False)
                Me.ActiveControl = Me.txtCheckDemandInfo
                Exit Sub
            End If

            Dim strStatusFlag As String
            strStatusFlag = Me.dgvPrintList.Rows(Me.dgvPrintList.CurrentRow.Index).Cells("StatusFlag").Value
            If (strStatusFlag = "1") Then
                SetMessage("该单已经审核", False)
                Exit Sub
            End If

            If (strStatusFlag = "4") Then
                SetMessage("已经作废需求单，不允许审核!", False)
                Exit Sub
            End If

            Dim strMODemandId As String
            Dim strSQL As StringBuilder = New StringBuilder

            strMODemandId = Me.dgvPrintList.Rows(Me.dgvPrintList.CurrentRow.Index).Cells("MODemandId").Value
            strSQL.AppendLine("UPDATE m_MODemand_t SET StatusFlag = '1', CheckUserId = '" & VbCommClass.VbCommClass.UseId & "', CheckTime=GETDATE(), Note = N'" & Me.txtNote.Text.Trim.Replace("'", "''") & "', BarCodeNote = N'" & Me.txtCheckDemandInfo.Text.Trim.Replace("'", "''") & "'  WHERE MODemandId = '" & strMODemandId & "'")

            DbOperateUtils.ExecSQL(strSQL.ToString)

            GetPrintList()
        Catch ex As Exception
            SetMessage("加载异常", False)
        End Try
    End Sub

    Private Sub ToolExitFrom_Click(sender As Object, e As EventArgs) Handles ToolExitFrom.Click
        Me.Close()
    End Sub

#End Region

#Region "控件事件"

    Private Sub dgvPrintList_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrintList.CellEnter
        On Error Resume Next

        If Me.dgvPrintList.Rows.Count = 0 OrElse Me.dgvPrintList.CurrentRow Is Nothing Then
            Me.txtDemandInfo.Text = ""
            Me.txtCheckDemandInfo.Text = ""
            Me.txtNote.Text = ""
            Exit Sub
        End If

        Me.txtDemandInfo.Text = Me.dgvPrintList.Rows(Me.dgvPrintList.CurrentRow.Index).Cells("DemandNote").Value
        Me.txtCheckDemandInfo.Text = Me.dgvPrintList.Rows(Me.dgvPrintList.CurrentRow.Index).Cells("BarCodeNote").Value
        Me.txtNote.Text = Me.dgvPrintList.Rows(Me.dgvPrintList.CurrentRow.Index).Cells("Note").Value
    End Sub

#End Region

#Region "方法"

    Private Function CheckQueryParameter(ByVal MessageFlag As Boolean) As Boolean
        If (dtpStartDate.Value < dtpEndDate.Value) Then
            If (MessageFlag) Then
                MsgBox("查询结束时间不能大于开始时间！", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "系統提示")
            End If
            Return True
        End If

        Return False
    End Function

    Private Sub GetPrintList()
        Dim strSQL As StringBuilder = New StringBuilder()
        strSQL.AppendLine(" SELECT m_MODemand_t.MODemandId, m_MODemand_t.MOid, m_Mainmo_t.PartID, m_MODemand_t.DemandNote, m_MODemand_t.InvalidUserId, m_MODemand_t.InvalidTime,")
        strSQL.AppendLine(" m_MODemand_t.BarCodeNote, m_MODemand_t.StatusFlag, m_SettingParameter_t.PARAMETER_NAME AS StatusFlagText, m_MODemand_t.CheckTime, m_MODemand_t.CheckUserId, m_MODemand_t.CreateTime, m_MODemand_t.CreateUserId, m_MODemand_t.Note ")
        strSQL.AppendLine(" FROM m_MODemand_t INNER JOIN  m_Mainmo_t ON m_MODemand_t.MOid = m_Mainmo_t.Moid ")
        strSQL.AppendLine(" INNER JOIN m_SettingParameter_t ON m_SettingParameter_t.PARAMETER_VALUE = m_MODemand_t.StatusFlag AND m_SettingParameter_t.PARAMETER_MODE = 'SStatusFlagText' ")
        strSQL.AppendLine(" WHERE m_MODemand_t.CreateTime BETWEEN cast('" & Me.dtpEndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' as datetime) and cast('" & Me.dtpStartDate.Value.ToString("yyyy/MM/dd") + " 23:59:59" & "' as datetime) ")

        If (Not String.IsNullOrEmpty(Me.txtMOId.Text.Trim)) Then
            strSQL.AppendLine(" AND m_MODemand_t.MOid LIKE '%" & Me.txtMOId.Text.Trim & "%' ")
        End If
        strSQL.AppendLine(" ORDER BY m_MODemand_t.CreateTime DESC ")

        Me.dgvPrintList.DataSource = DbOperateUtils.GetDataTable(strSQL.ToString)
    End Sub

    Private Sub SetMessage(ByVal Message As String, ByVal bType As Boolean)
        If (bType) Then
            Me.lblMessage.ForeColor = Color.Green
        Else
            Me.lblMessage.ForeColor = Color.Red
        End If
        Me.lblMessage.Text = Message
    End Sub

#End Region


End Class