Imports System
Imports System.Collections.Generic
Imports System.Text
Imports NPOI.HSSF.UserModel
Imports NPOI.SS.UserModel
Imports System.Data
Imports System.IO
Imports System.Web
Imports System.Reflection
Imports System.Data.OleDb
Imports System.Windows.Forms

''' <summary>
'''  NPOI操作Excel类
''' Add Date 2018-07-19
''' add by 马跃平
''' </summary>
''' <remarks></remarks>
Public MustInherit Class NPOIExcle

    ''' <summary>
    ''' 导出Excel
    ''' add by 马跃平 2018-07-19
    ''' </summary>
    ''' <param name="dt">数据源</param>
    ''' <param name="list">表头标题集合</param>
    ''' <param name="FileName">xls文件名称</param>
    ''' <remarks></remarks>
    Public Shared Sub DataTableExportToExcle(ByVal dt As DataTable, ByVal list As List(Of String), ByVal FileName As String)
        Dim book = New HSSFWorkbook()
        Dim fn = FileName.Substring(0, FileName.LastIndexOf("."))
        Dim sheet = book.CreateSheet(fn)
        Dim row = sheet.CreateRow(0)
        Dim style = book.CreateCellStyle()
        style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center '水平剧中
        style.VerticalAlignment = VerticalAlignment.Center '垂直剧中
        For i As Integer = 0 To dt.Columns.Count - 1
            Dim cell = row.CreateCell(i)
            sheet.AutoSizeColumn(i)
            cell.CellStyle = style
            If Not list Is Nothing Then
                cell.SetCellValue(list(i))
            Else
                cell.SetCellValue(dt.Columns(i).ColumnName)
            End If
        Next

        For i As Integer = 0 To dt.Rows.Count - 1
            row = sheet.CreateRow(i + 1)
            For y As Integer = 0 To dt.Columns.Count - 1
                Dim cell = row.CreateCell(y)
                cell.CellStyle = style
                Dim obj = dt.Rows(i)(y).GetType()
                cell.SetCellValue(dt.Rows(i)(y).ToString())
            Next
        Next
        Dim ms = New MemoryStream()
        Dim ssf = New SaveFileDialog()
        ssf.Filter = "xls(*.xls)|*.xls"
        ssf.RestoreDirectory = True
        ssf.FileName = FileName
        If ssf.ShowDialog() = DialogResult.OK Then
            book.Write(ms)
            book = Nothing
            Using fs As FileStream = CType(ssf.OpenFile(), FileStream)
                Dim data = ms.ToArray()
                fs.Write(data, 0, data.Length)
                fs.Flush()
            End Using
            ms.Close()
            ms.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' ExcelXls汇成DataTable
    ''' add by 马跃平 2018-07-21
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExcelInputByNPOI(ByVal filePath As String) As DataTable
        Dim dt = New DataTable()
        Dim book = New HSSFWorkbook(File.Open(filePath, FileMode.Open))
        Dim sheet = CType(book.GetSheetAt(0), HSSFSheet)
        Dim rowCount = sheet.PhysicalNumberOfRows  '行数
        Dim colCount = sheet.GetRow(0).PhysicalNumberOfCells '列数
        Dim cellList = sheet.GetRow(0).Cells
        For Each ce As ICell In cellList
            dt.Columns.Add(ce.StringCellValue)
        Next

        For i As Integer = 1 To rowCount - 1
            Dim dr = dt.NewRow()

            If Not sheet.GetRow(i) Is Nothing Then

                For y As Integer = 0 To colCount - 1
                    dr(y) = sheet.GetRow(i).GetCell(y)
                Next
                dt.Rows.Add(dr)
            End If
        Next
        sheet = Nothing
        book = Nothing
        Return dt
    End Function
End Class
