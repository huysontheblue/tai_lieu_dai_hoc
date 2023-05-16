Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle

Public Class FrmShowDetail
    Public strSQL As String
    Public TabTitle As String
    Private ObjDB As New SysDataBaseClass()

    Private Sub ShowDetailData()
        Dim i As Integer
        Dim colNames As String() = TabTitle.Split("|")
        Dim DtCtScan As DataTable

        DtCtScan = ObjDB.GetDataTable(strSQL)
        ToolCount.Text = DtCtScan.Rows.Count.ToString()

        DgData.DataSource = DtCtScan
        For i = 0 To DgData.Columns.Count - 1
            DgData.Columns(i).HeaderText = colNames(i)
            DgData.Columns(i).Name = colNames(i)
        Next

        DgData.AutoResizeColumns()
        DgData.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DgData.ScrollBars = ScrollBars.Both
        DtCtScan.Dispose()
    End Sub

    Private Sub FrmShowDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowDetailData()
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        ObjDB.InportInExcel(strSQL, "¸Ô²Ó°O¿ý", Me.DgData, "")
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

End Class