Imports System.Drawing.Printing
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells

Public Class FrmPrint

    Private Sub FrmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitPrinter()
    End Sub

    Public FilePathList As List(Of String) = New List(Of String)

    Private Sub InitPrinter()
        cboPrinter.Items.Clear()
        Using pDoc As New PrintDocument
            Dim defaultPrinter As String = pDoc.PrinterSettings.PrinterName
            For Each printer As String In PrinterSettings.InstalledPrinters
                cboPrinter.Items.Add(printer)
            Next
            cboPrinter.Items.Insert(0, "")

        End Using
    End Sub

    Private Sub Print(ByVal o_filePath As String)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Try
            xlApp = New Microsoft.Office.Interop.Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(o_filePath)
            xlWorkSheet = xlWorkBook.Sheets(1)
            xlApp.Visible = False
            xlWorkSheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4
            xlWorkSheet.PageSetup.LeftMargin = 27
            xlWorkSheet.PageSetup.TopMargin = 10
            xlWorkSheet.PageSetup.CenterHorizontally = True
            
            xlWorkSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait
            xlWorkSheet.PrintOut(1, 10, 1, Nothing, cboPrinter.SelectedItem, Nothing, Nothing, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If Not xlWorkBook Is Nothing Then
                xlWorkBook.Close(False, Nothing, Nothing)
            End If
            If Not xlApp Is Nothing Then
                xlApp.Workbooks.Close()
                xlApp.Quit()
            End If
            If Not xlWorkSheet Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet)
            End If
            If Not xlWorkBook Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook)
            End If
            If Not xlApp Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)
            End If
            xlWorkSheet = Nothing
            xlWorkBook = Nothing
            xlApp = Nothing
            GC.Collect()
        End Try
    End Sub

    ''' <summary>
    ''' 打印
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If String.IsNullOrEmpty(cboPrinter.Text.Trim()) Then
            MessageUtils.ShowError("请选择打印机!")
            Exit Sub
        End If
        For Each FilePath As String In FilePathList
            'System.Diagnostics.Process.Start(FilePath)
            'Dim MyBook = New Workbook(FilePath)
            'Dim sheet = MyBook.Worksheets(0)
            'Dim pageSet = sheet.PageSetup
            'pageSet.Orientation = PageOrientationType.Portrait
            'pageSet.PaperSize = PaperSizeType.PaperA4
            'Dim options = New Rendering.ImageOrPrintOptions()
            'Dim sheetRender = New Aspose.Cells.Rendering.SheetRender(sheet, options)
            'sheetRender.ToImage(1)
            'sheetRender.ToPrinter(cboPrinter.Text.Trim())
            'Dim pro() = System.Diagnostics.Process.GetProcesses()
            'For i As Integer = 0 To pro.Length - 1
            '    If pro(i).ProcessName = "EXCEL" Then
            '        pro(i).Kill()
            '    End If
            'Next
            Print(FilePath)
        Next
        Me.Close()
    End Sub

    Private Sub FrmPrint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        For Each FilePath As String In FilePathList
            If System.IO.File.Exists(FilePath) Then
                System.IO.File.Delete(FilePath)
            End If
        Next
    End Sub
End Class