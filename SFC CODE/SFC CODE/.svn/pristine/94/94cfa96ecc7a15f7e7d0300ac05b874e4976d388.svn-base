Imports MainFrame

Public Class FrmRDList

    Public checkedLine As String = ""
    Public m_strDept As String = ""

    Private Sub FrmProductNGDayQuerySub_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetDeptPICUsersData()

    End Sub

    Private Sub SetDeptPICUsersData()
        Dim strDepts As String = txtSelectedDept.Text.Trim 'SampleCom.GetUserDept(VbCommClass.VbCommClass.UseId)  'txtSelectedDept.Text.Trim
        txtSelectedDept.Text = strDepts
        m_strDept = strDepts
        Dim strSQL As String = ""

        strSQL =
         " SELECT distinct b.UserName FROM m_SamplePic_t a" & _
         " LEFT JOIN  m_users_t  b  ON a.DutyUserID = b.UserID  " &
         " WHERE a.DutyDeptName =N'" & strDepts & "'"

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        checkListBoxLine.DataSource = dt
        checkListBoxLine.ValueMember = "UserName"
        checkListBoxLine.DisplayMember = "UserName"

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        For i As Integer = 0 To checkListBoxLine.Items.Count - 1
            If checkListBoxLine.GetItemChecked(i) = True Then
                checkedLine = checkedLine + "," + DirectCast(checkListBoxLine.Items(i), System.Data.DataRowView).Row.ItemArray(0)
            End If
        Next
        If checkedLine.Contains(",") Then
            checkedLine = checkedLine.Substring(1)
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class