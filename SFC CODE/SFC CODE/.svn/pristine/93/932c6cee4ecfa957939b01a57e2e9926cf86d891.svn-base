Imports System.Windows.Forms
Imports System.Text.RegularExpressions


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
    Private _IsQueryOldVersion As Boolean
    Public Property IsQueryOldVersion() As Boolean
        Get
            Return _IsQueryOldVersion
        End Get

        Set(ByVal Value As Boolean)
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
        Dim strUserID As String = ""
        If Me.txtPartNumber.Text.Trim <> "" Then
            sql = sql + " AND RC.PartID LIKE N'%" & Me.txtPartNumber.Text.Trim & "%' "
        End If
        If Me.ckDateBegin.Checked Then
            sql = sql + " AND  CONVERT(date,RC.InTime) >=CONVERT(date,'" & Me.dateTimeFrom.Text & "',120 )"
        End If
        If Me.ckDateEnd.Checked Then
            sql = sql + " AND CONVERT(date,RC.InTime) <=CONVERT(date,'" & Me.dateTimeTo.Text & "',120 )"
        End If
        If Me.txtDrawingVer.Text.Trim <> "" Then
            sql = sql + " AND RC.DrawingVer like N'%" & Me.txtDrawingVer.Text.Trim & "%'"
        End If
        If Me.txtShape.Text.Trim <> "" Then
            sql = sql + " AND RC.Shape like N'%" & Me.txtShape.Text.Trim & "%'"
        End If
        If Me.cboStatus.SelectedIndex <> -1 Then
            sql = sql + " AND RC.Status = " & Me.cboStatus.SelectedItem.ToString().Substring(0, 1) & " "
        End If

        If Me.txtUserID.Text.Trim <> "" Then
            If IsExistChinese(Me.txtUserID.Text.Trim) Then
                'get userid
                strUserID = RunCardBusiness.GetUserID(Me.txtUserID.Text.Trim)
                If Not String.IsNullOrEmpty(strUserID) Then
                    sql = sql + " AND RC.UserID LIKE N'%" & strUserID & "%'"
                End If
            Else
                sql = sql + " AND RC.UserID LIKE N'%" & Me.txtUserID.Text.Trim & "%'"
            End If
        End If

        '描述
        If Not String.IsNullOrEmpty(Me.txtDescription.Text.Trim) Then
            sql = sql + " AND Description LIKE N'%" & Me.txtDescription.Text.Trim & "%'"
        End If

        '规格
        If Not String.IsNullOrEmpty(Me.txtTypeDest.Text.Trim) Then
            sql = sql + " AND TypeDest LIKE N'%" & Me.txtTypeDest.Text.Trim & "%'"
        End If

        'Remark
        If Not String.IsNullOrEmpty(Me.txtRemark.Text.Trim) Then
            sql = sql + " AND RC.Remark LIKE N'%" & Me.txtRemark.Text.Trim & "%'"
        End If

        Me.SqlWhere = sql
        Me.IsQueryOldVersion = Me.CheckBox1.Checked
        '退出
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function IsExistChinese(ByVal strInputUserID As String) As Boolean
        Dim regX As New Regex("[\u4e00-\u9fa5]")
        If regX.IsMatch(strInputUserID) Then
            IsExistChinese = True
        Else
            IsExistChinese = False
        End If
        Return IsExistChinese
    End Function

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