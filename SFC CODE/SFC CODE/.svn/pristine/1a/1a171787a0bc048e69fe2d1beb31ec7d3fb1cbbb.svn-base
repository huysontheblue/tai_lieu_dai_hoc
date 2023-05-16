Public Class FrmQuoteQuery

    Private _sqlWhere As String
    Public Property sqlWhere() As String
        Get
            Return _sqlWhere
        End Get

        Set(ByVal Value As String)
            _sqlWhere = Value
        End Set
    End Property
    Private _ismultiline As Boolean = False
    Public Property IsMultiLine() As Boolean
        Get
            Return _ismultiline
        End Get

        Set(ByVal Value As Boolean)
            _ismultiline = Value
        End Set
    End Property
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim sql As String = ""
        Dim strUserID As String = ""
        If Me.txtPartNumber.Text.Trim <> "" Then
            If (Me.txtPartNumber.Text.Trim.Split(";").Length > 1) Then
                IsMultiLine = True
                Dim str As String = "and a.PartNumber in ("
                Dim strloop As String = ""
                For i = 0 To Me.txtPartNumber.Text.Trim.Split(";").Length - 1
                    strloop = strloop + ",'" + Me.txtPartNumber.Text.Trim.Split(";")(i) + "'"
                Next
                sql = str + strloop.Substring(1) + ")"
                'sql = sql + " AND a.PartNumber LIKE N'%" & Me.txtPartNumber.Text.Trim & "%' "
            Else
                sql = sql + " AND a.PartNumber LIKE N'%" & Me.txtPartNumber.Text.Trim & "%' "
            End If

        End If

        If Me.txtVer.Text.Trim <> "" Then
            sql = sql + " AND Ver like N'%" & Me.txtVer.Text.Trim & "%'"
        End If
        If Me.txtProductFrom.Text.Trim <> "" Then
            sql = sql + " AND ProductFrom like N'%" & Me.txtProductFrom.Text.Trim & "%'"
        End If


        'If Me.txtUserID.Text.Trim <> "" Then
        '    If IsExistChinese(Me.txtUserID.Text.Trim) Then
        '        'get userid
        '        strUserID = RunCardBusiness.GetUserID(Me.txtUserID.Text.Trim)
        '        If Not String.IsNullOrEmpty(strUserID) Then
        '            sql = sql + " AND Creater LIKE N'%" & strUserID & "%'"
        '        End If
        '    Else
        '        sql = sql + " AND Creater LIKE N'%" & Me.txtUserID.Text.Trim & "%'"
        '    End If
        'End If

        '创建人
        If Not String.IsNullOrEmpty(Me.txtUserID.Text.Trim) Then
            sql = sql + " AND a.CreaterName LIKE N'%" & Me.txtUserID.Text.Trim & "%'"
        End If

        '描述
        If Not String.IsNullOrEmpty(Me.txt_Remark.Text.Trim) Then
            sql = sql + " AND a.Remark LIKE N'%" & Me.txt_Remark.Text.Trim & "%'"
        End If

        '规格
        If Not String.IsNullOrEmpty(Me.txt_Efficiency.Text.Trim) Then
            sql = sql + " AND a.Remark LIKE N'%" & Me.txt_Efficiency.Text.Trim & "%'"
        End If

        If Me.ckDateBegin.Checked Then
            sql = sql + " AND convert(date,a.CreateTime) >=CONVERT(date,'" & Me.dateTimeFrom.Text & "',120 )"
        End If
        If Me.ckDateEnd.Checked Then
            sql = sql + " AND convert(date,a.CreateTime) <=CONVERT(date,'" & Me.dateTimeTo.Text & "',120 )"
        End If

        If Not String.IsNullOrEmpty(txtDevelopReference.Text.Trim) Then
            sql = sql + " and DevelopReference like '%" & txtDevelopReference.Text.Trim & "%'"
        End If

        Me.sqlWhere = sql
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub txtPartNumber_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtPartNumber.ButtonCustomClick
        Dim obj As New SysBasicClass.InputText(txtPartNumber)
        obj.ShowDialog()
    End Sub
End Class