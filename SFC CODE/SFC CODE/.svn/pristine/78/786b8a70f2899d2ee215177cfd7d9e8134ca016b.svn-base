Imports MainFrame

Public Class Frminformation

    Private Sub Frminformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridViewX1.DataSource = DbOperateUtils.GetDataTable("select Numbers,Ppartid,PO,BoxName,PackingList,Mark,Qty,Remarks,type,Userid,time from m_Shipments WHERE state='N' ORDER BY type")
    End Sub

    Private Sub DataGridViewX1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellContentDoubleClick
        If DataGridViewX1.SelectedRows.Count > -1 And DataGridViewX1.SelectedRows.Count <= DataGridViewX1.RowCount Then
            VbCommClass.VbCommClass.PPartid = DataGridViewX1.Rows(DataGridViewX1.CurrentRow.Index).Cells(0).Value
            Me.Close()
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.Close()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If DataGridViewX1.SelectedRows.Count > -1 And DataGridViewX1.SelectedRows.Count <= DataGridViewX1.RowCount Then
            VbCommClass.VbCommClass.PPartid = DataGridViewX1.Rows(DataGridViewX1.CurrentRow.Index).Cells(0).Value
            Me.Close()
        End If
    End Sub
End Class