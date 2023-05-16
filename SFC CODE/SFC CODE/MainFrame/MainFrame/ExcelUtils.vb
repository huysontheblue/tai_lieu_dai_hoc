Imports Aspose.Cells
Imports System.IO
Imports System.Text
Imports MainFrame.SysCheckData
'Imports NPOI.HSSF.UserModel
Imports System.Windows.Forms

Public Class ExcelUtils

    ''' <summary>
    ''' DataGridView数据导出excel 公共方法
    ''' </summary>
    ''' <param name="DgMoData">DataGridView控件ID</param>
    ''' <param name="tbname">导出文件名称</param>
    ''' <remarks></remarks>
    Public Shared Sub LoadDataToExcel(ByVal DgMoData As DataGridView, ByVal tbname As String, Optional ByVal strDirectory As String = "")
        Try

            If DgMoData.RowCount = 0 Then
                MessageBox.Show("请确认需导出的数据资料！", "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = DgMoData.DataSource

            '导出CSV文件格式，以便用户查询，以,号区分

            If Not Directory.Exists("c:\MesExport") Then
                Directory.CreateDirectory("c:\MesExport")
            End If


            Dim Swriter As New IO.StreamWriter("c:\MesExport\" + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim nColqty As Integer = 0
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容

            '写入标题行
            For comIndex As Integer = 0 To DgMoData.ColumnCount - 1
                If bColName = False Then
                    If wColName = "" Then
                        wColName = DgMoData.Columns(comIndex).HeaderText
                    Else
                        wColName = wColName + "," + DgMoData.Columns(comIndex).HeaderText
                    End If
                End If
            Next

            For Each r As DataRow In getTable.Rows

                nColqty = 0

                For Each c As DataColumn In getTable.Columns
                    '写入每行的值
                    If nColqty = 0 Then
                        wValue = r.Item(c.ColumnName).ToString.Replace(",", "，")
                    Else
                        wValue = wValue + "," + r.Item(c.ColumnName).ToString.Replace(",", "，")
                    End If
                    nColqty = nColqty + 1
                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                Swriter.WriteLine(wValue)

            Next
            Swriter.Close()

            MessageBox.Show("文件导出成功,导出位置：c:\MesExport\" + tbname + ".csv !", "汇出数据", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "异常错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Table数据导出excel 公共方法
    ''' </summary>
    ''' <param name="dt">DataTable</param>
    ''' <param name="tbname">导出文件名称</param>
    ''' <remarks></remarks>
    Public Shared Sub LoadDataToExcelFromDT(ByVal dt As DataTable, ByVal tbname As String, Optional ByVal strDirectory As String = "")
        Try

            Dim getTable As New DataTable
            getTable.TableName = tbname

            getTable = dt.Copy

            If strDirectory = "" Then
                strDirectory = "c:\MesExport\"
            End If

            '导出CSV文件格式，以便用户查询，以,号区分
            If Not Directory.Exists(strDirectory) Then
                Directory.CreateDirectory(strDirectory)
            End If

            Dim Swriter As New IO.StreamWriter(strDirectory + tbname + ".csv", False, System.Text.Encoding.UTF8) '覆盖或新建

            Dim wValue As String = ""                   '保存每行的徝
            Dim bColName As Boolean = False             '是否写了标题行
            Dim wColName As String = ""                 '标题行的内容
            Dim sbDataItems As StringBuilder = New StringBuilder

            For Each r As DataRow In getTable.Rows

                For Each c As DataColumn In getTable.Columns
                    '写入标题行
                    If bColName = False Then
                        If wColName = "" Then
                            wColName = c.ColumnName.Replace(",", "，")
                        Else
                            wColName = wColName + "," + c.ColumnName.Replace(",", "，")
                        End If
                    End If

                    '写入每行的值
                    sbDataItems.AppendFormat("{0}{1}", r(c.ColumnName).ToString.Trim.Replace(",", "，"), ",")
                Next

                If wColName <> "" And bColName = False Then
                    Swriter.WriteLine(wColName)
                    bColName = True
                End If

                sbDataItems.Remove(sbDataItems.Length - 1, 1)
                Swriter.WriteLine(sbDataItems.ToString)

                sbDataItems.Remove(0, sbDataItems.Length)
            Next
            Swriter.Close()

            MessageUtils.ShowInformation(String.Format("文件导出成功,导出位置：{0}{1}.csv!", strDirectory, tbname))

        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try

    End Sub

    Public Shared Function ExportFromExcelByAs(ByVal file As String, ByVal sheetName As String, ByVal rowStartIndex As Integer, ByVal colStartIndex As Integer, ByRef errorMsg As String) As DataTable
        Try
            Dim aBook As New Aspose.Cells.Workbook(file)
            Dim aSheet As Worksheet = aBook.Worksheets(sheetName)
            Dim aCell As Cells = aSheet.Cells
            Dim aOptions As Aspose.Cells.ExportTableOptions = New Aspose.Cells.ExportTableOptions
            aOptions.SkipErrorValue = True
            Using dt As DataTable = aCell.ExportDataTable(rowStartIndex, colStartIndex, aCell.MaxRow + 1, aCell.MaxColumn + 1)
                Return dt
            End Using
        Catch ex As Exception
            errorMsg = ex.Message
            Return Nothing
        End Try
    End Function

    Public Shared Function ExportFromExcelByAs(ByVal file As String, ByVal rowStartIndex As Integer, ByVal colStartIndex As Integer, maxColumn As Integer, ByRef errorMsg As String) As DataTable
        Try
            Dim aBook As New Aspose.Cells.Workbook(file)
            Dim aSheet As Worksheet = aBook.Worksheets(0)
            Dim aCell As Cells = aSheet.Cells
            Dim aOptions As Aspose.Cells.ExportTableOptions = New Aspose.Cells.ExportTableOptions
            aOptions.SkipErrorValue = True
            Using dt As DataTable = aCell.ExportDataTable(rowStartIndex, colStartIndex, aCell.MaxRow + 1, maxColumn)
                Return dt
            End Using
        Catch ex As Exception
            errorMsg = ex.Message
            Return Nothing
        End Try
    End Function
    'add ZKH 2019-10-14
    Public Shared Function ExportFromExcelByAsA(ByVal file As String, ByVal rowStartIndex As Integer, ByVal colStartIndex As Integer, ByRef errorMsg As String) As DataTable
        Try

            Dim aBook As New Aspose.Cells.Workbook(file)
            Dim aSheet As Worksheet = aBook.Worksheets(0)
            Dim aCell As Cells = aSheet.Cells
            Dim aOptions As Aspose.Cells.ExportTableOptions = New Aspose.Cells.ExportTableOptions
            aOptions.SkipErrorValue = True
            Using dt As DataTable = aCell.ExportDataTable(rowStartIndex, colStartIndex, aCell.MaxRow + 1, aCell.MaxColumn + 1)
                Return dt
            End Using
        Catch ex As Exception
            errorMsg = ex.Message
            Return Nothing
        End Try
    End Function




    Public Shared Sub GetExcelTemplate(path As String, fileNames As String)
        Dim FileName As String = fileNames + ".xls"
        Dim FileName2 As String = fileNames + ".xlsx"
        Dim FilePath As String = System.IO.Path.Combine(path, "MES\IMPORTTEMPLATE\" + FileName)
        If Not File.Exists(FilePath) Then
            FilePath = System.IO.Path.Combine(path, "MES\IMPORTTEMPLATE\" + FileName2)
            If Not File.Exists(FilePath) Then
                MessageUtils.ShowWarning("未找到导入格式文件！")
                Exit Sub
            End If
        End If

        Try
            Dim Process As New System.Diagnostics.Process
            Process.StartInfo.FileName = FilePath
            Process.StartInfo.Verb = "Open"
            Process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
            Process.Start()
        Catch ex As Exception
            MessageUtils.ShowError("名为【" + FileName + "】的文件打开出错！")
        End Try
    End Sub
End Class
