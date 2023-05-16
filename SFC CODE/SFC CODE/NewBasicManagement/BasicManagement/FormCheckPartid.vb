Imports MainFrame.SysDataHandle

Public Class FormCheckPartid
    Public sql As String
    Dim sqlConn As New SysDataBaseClass
    Private Sub editName_KeyDown(sender As Object, e As KeyEventArgs) Handles Partid.KeyDown
        If e.KeyValue = 13 Then
            Dim sql As String = "SELECT TAvcPart,PAvcPart,CusID,Userid FROM m_PartContrast_t WHERE TAvcPart like '%" + Partid.Text.Trim() + "%'"
            Dim Data As DataTable = sqlConn.GetDataTable(sql)
            dgvData.DataSource = Data
        End If
    End Sub

    Private Sub dgvData_DoubleClick(sender As Object, e As EventArgs) Handles dgvData.DoubleClick, btnOK.Click
        If dgvData.Rows.Count > 0 AndAlso dgvData.CurrentRow IsNot Nothing Then
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub FormCheckPartid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Data As DataTable = sqlConn.GetDataTable(sql)
        dgvData.DataSource = Data
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.No
    End Sub
End Class