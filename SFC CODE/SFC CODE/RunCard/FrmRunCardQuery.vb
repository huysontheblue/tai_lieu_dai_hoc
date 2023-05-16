Imports System.Windows.Forms

#Region "Old"
'Public Class FrmRunCardQuery

'#Region "SqlWhere"
'    Private _sqlWhere As String
'    Public Property SqlWhere() As String
'        Get
'            Return _sqlWhere
'        End Get

'        Set(ByVal Value As String)
'            _sqlWhere = Value
'        End Set
'    End Property
'    Private _IsQueryOldVersion
'    Public Property IsQueryOldVersion() As String
'        Get
'            Return _IsQueryOldVersion
'        End Get

'        Set(ByVal Value As String)
'            _IsQueryOldVersion = Value
'        End Set
'    End Property
'#End Region

'#Region "TAB 处理"
'    Private Sub FrmRunCardQuery_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
'        If Asc(e.KeyChar) = 13 Then
'            SendKeys.Send("{TAB}")
'        End If
'    End Sub
'#End Region

'    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
'        Dim sql As String = ""
'        If Me.txtPartNumber.Text.Trim <> "" Then
'            sql = sql + " and PN.PartNumber like N'%" & Me.txtPartNumber.Text.Trim & "%' "
'        End If
'        If Me.ckDateBegin.Checked Then
'            sql = sql + " and RC.InTime >=convert(datetime,'" & Me.dateTimeFrom.Text & "',120 )"
'        End If
'        If Me.ckDateEnd.Checked Then
'            sql = sql + " and RC.InTime <=convert(datetime,'" & Me.dateTimeTo.Text & "',120 )"
'        End If
'        If Me.txtDrawingVer.Text.Trim <> "" Then
'            sql = sql + " and RC.DrawingVer like N'%" & Me.txtDrawingVer.Text.Trim & "%'"
'        End If
'        If Me.txtShape.Text.Trim <> "" Then
'            sql = sql + " and RC.Shape like N'%" & Me.txtShape.Text.Trim & "%'"
'        End If
'        If Me.cboStatus.SelectedIndex <> -1 Then
'            sql = sql + " and RC.Status = " & Me.cboStatus.SelectedItem.ToString().Substring(0, 1) & " "
'        End If
'        'If CheckBox1.Checked = True Then
'        '    If txtDrawingVer.Text.Trim = "" Then
'        '        MessageBox.Show("查询历史版本，请输入历史版本号")
'        '        Exit Sub
'        '    Else
'        '        sql += sql + " and RC.DrawingVer ='" & txtDrawingVer.Text.Trim & "'"
'        '    End If
'        'End If
'        Me.SqlWhere = sql
'        Me.IsQueryOldVersion = Me.CheckBox1.Checked
'        '退出
'        Me.DialogResult = Windows.Forms.DialogResult.OK
'        Me.Close()
'    End Sub

'    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
'        Me.Close()
'    End Sub

'    Private Sub FrmRunCardQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Me.dateTimeFrom.Value = Date.Now.AddDays(-1)
'    End Sub

'    Private Sub ckDateBegin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDateBegin.CheckedChanged
'        Select Case ckDateBegin.CheckState
'            Case CheckState.Checked
'                Me.dateTimeFrom.Enabled = True
'                Me.lblDateFrom.Enabled = True
'            Case CheckState.Unchecked
'                Me.dateTimeFrom.Enabled = False
'                Me.lblDateFrom.Enabled = False
'        End Select

'    End Sub

'    Private Sub ckDateEnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDateEnd.CheckedChanged
'        Select Case ckDateEnd.CheckState
'            Case CheckState.Checked
'                Me.dateTimeTo.Enabled = True
'                Me.lblDateTo.Enabled = True
'            Case CheckState.Unchecked
'                Me.dateTimeTo.Enabled = False
'                Me.lblDateTo.Enabled = False
'        End Select
'    End Sub
'End Class
#End Region

Public Class FrmRunCardQuery

#Region "SqlWhere"
    Private _sqlWhere As String
    Public Property SqlWhere() As String
        Get
            Return _sqlWhere
        End Get

        Set(ByVal Value As String)
            _sqlWhere = Value
        End Set
    End Property
    Private _IsQueryOldVersion
    Public Property IsQueryOldVersion() As String
        Get
            Return _IsQueryOldVersion
        End Get

        Set(ByVal Value As String)
            _IsQueryOldVersion = Value
        End Set
    End Property
#End Region

#Region "TAB 处理"
    Private Sub FrmRunCardQuery_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim sql As String = ""
        If Me.txtPartNumber.Text.Trim <> "" Then
            sql = sql + " and PN.PartNumber like N'%" & Me.txtPartNumber.Text.Trim & "%' "
        End If
        If Me.ckDateBegin.Checked Then
            sql = sql + " and RC.InTime >=convert(datetime,'" & Me.dateTimeFrom.Text & "',120 )"
        End If
        If Me.ckDateEnd.Checked Then
            sql = sql + " and RC.InTime <=convert(datetime,'" & Me.dateTimeTo.Text & "',120 )"
        End If
        If Me.txtDrawingVer.Text.Trim <> "" Then
            sql = sql + " and RC.DrawingVer like N'%" & Me.txtDrawingVer.Text.Trim & "%'"
        End If
        If Me.txtShape.Text.Trim <> "" Then
            sql = sql + " and RC.Shape like N'%" & Me.txtShape.Text.Trim & "%'"
        End If
        If Me.cboStatus.SelectedIndex <> -1 Then
            sql = sql + " and RC.Status = " & Me.cboStatus.SelectedItem.ToString().Substring(0, 1) & " "
        End If
        'If CheckBox1.Checked = True Then
        '    If txtDrawingVer.Text.Trim = "" Then
        '        MessageBox.Show("查询历史版本，请输入历史版本号")
        '        Exit Sub
        '    Else
        '        sql += sql + " and RC.DrawingVer ='" & txtDrawingVer.Text.Trim & "'"
        '    End If
        'End If
        Me.SqlWhere = sql
        Me.IsQueryOldVersion = Me.CheckBox1.Checked
        '退出
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRunCardQuery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dateTimeFrom.Value = Date.Now.AddDays(-1)
    End Sub

    Private Sub ckDateBegin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDateBegin.CheckedChanged
        Select Case ckDateBegin.CheckState
            Case CheckState.Checked
                Me.dateTimeFrom.Enabled = True
                Me.lblDateFrom.Enabled = True
            Case CheckState.Unchecked
                Me.dateTimeFrom.Enabled = False
                Me.lblDateFrom.Enabled = False
        End Select

    End Sub

    Private Sub ckDateEnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckDateEnd.CheckedChanged
        Select Case ckDateEnd.CheckState
            Case CheckState.Checked
                Me.dateTimeTo.Enabled = True
                Me.lblDateTo.Enabled = True
            Case CheckState.Unchecked
                Me.dateTimeTo.Enabled = False
                Me.lblDateTo.Enabled = False
        End Select
    End Sub
End Class