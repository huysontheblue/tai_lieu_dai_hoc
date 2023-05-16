Public Class FrmLocationSet

    Public locationId As String
    Public locationName As String
    Public OutId As String

    Private Sub FrmLocationSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridView.DataSource = GetMesData.GetLocation()
    End Sub

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Me.Close()
    End Sub

    Private Sub ButConfirm_Click(sender As Object, e As EventArgs) Handles ButConfirm.Click
        If gridView.Rows.Count = 0 Then Exit Sub

        locationId = gridView.Rows(gridView.SelectedCells(0).RowIndex).Cells(0).Value
        locationName = gridView.Rows(gridView.SelectedCells(0).RowIndex).Cells(1).Value
        OutId = txtOutwhid.Text

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub



End Class