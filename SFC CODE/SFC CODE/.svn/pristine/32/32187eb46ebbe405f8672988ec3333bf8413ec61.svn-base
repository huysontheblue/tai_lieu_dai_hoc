Public Class Frmslotdetails
    Public MouldID As String
    '查询模具绑定的线槽及机种
    Private Sub Frmslotdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable
        Dim strSQL As String
        strSQL = "SELECT MouldID,Slots,Parts,Storage,Line,Library FROM m_Slots_t  WHERE MouldID = '" & MouldID.ToString & "'"
        dt = MainFrame.DbOperateUtils.GetDataTable(strSQL)
        For Each dr As DataRow In dt.Rows
            dgvBasis.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), dr.Item(3), dr.Item(4), dr.Item(5))
        Next
    End Sub
End Class