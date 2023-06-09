Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame

'Imports Owc = Microsoft.Office.Interop.Excel


Public Class FrmShowDetail
    Public strSQL As String
    Public TabTitle As String = ""
    Public Sqlparam As SqlParameter()

#Region "重繪datagridview單元格,選中時去除焦點"

    Private Sub DgPartSet_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DgData.RowPrePaint

        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    End Sub

#End Region

    Private Sub ShowDetailData()
        Dim i As Integer
        Dim colNames As String() = TabTitle.Split("|")


        Dim DtCtScan1 As DataTable
        Try
            DtCtScan1 = DbOperateReportUtils.GetDataTable(strSQL, Sqlparam)
            ToolCount.Text = DtCtScan1.Rows.Count.ToString()
            DgData.DataSource = DtCtScan1
            If TabTitle <> "" Then
                For i = 0 To DgData.Columns.Count - 1
                    DgData.Columns(i).HeaderText = colNames(i)
                    DgData.Columns(i).Name = colNames(i)
                Next
            End If

            DgData.AutoResizeColumns()
            DgData.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            'DgData.ScrollBars = ScrollBars.Both
            DtCtScan1.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub FrmShowDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowDetailData()
    End Sub

    Private Sub ToolExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExcel.Click
        'ObjDB.InportInExcel(strSQL, "詳細記錄", Me.DgData, "")
        'ObjDB.LoadDataToExcel("詳細記錄", Me.DgData)
        'LoadDataToOpExcel("詳細記錄", Me.DgData, "")
        ' Call DcExcel(Me.DgData)
        LoadDataToExcel(Me.DgData, Me.Text)
    End Sub

    Private Sub ToolExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExit.Click
        Close()
    End Sub

    Public Sub DcExcel(ByVal DGV As DataGridView)
        ''把datagridview中的数据导出到excel
        'Dim wapp As New Owc.Application
        'Dim wsheet As Owc.Worksheet
        'Dim wbook As Owc.Workbook

        'On Error Resume Next

        'wapp.Visible = True
        'wbook = wapp.Workbooks.Add()
        'wsheet = wbook.ActiveSheet

        'Dim iX As Integer
        'Dim iY As Integer
        'Dim iC As Integer

        'For iC = 0 To DGV.Columns.Count - 1
        '    wsheet.Cells(1, iC + 1).Value = DGV.Columns(iC).HeaderText
        '    wsheet.Cells(1, iC + 1).Font.Bold = True
        'Next

        'wsheet.Rows(2).select()
        'For iX = 0 To DGV.Rows.Count - 1
        '    For iY = 0 To DGV.Columns.Count - 1
        '        wsheet.Cells(iX + 2, iY + 1).value = DGV(iY, iX).Value.ToString
        '    Next
        'Next
    End Sub

End Class