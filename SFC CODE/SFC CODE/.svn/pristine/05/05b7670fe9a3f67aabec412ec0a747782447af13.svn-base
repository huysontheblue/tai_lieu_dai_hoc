Imports System.Drawing.Printing
Imports MainFrame
Imports MainFrame.SysCheckData
Imports System.Text
Imports System.Windows.Forms
Imports Aspose.Cells


Public Class FrmBOFToolListPrint

    Private _PartIDList As List(Of String)
    ''' <summary>
    ''' 勾选的料号集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PartIDList() As List(Of String)
        Get
            Return _PartIDList
        End Get
        Set(ByVal value As List(Of String))
            _PartIDList = value
        End Set
    End Property


    Private Sub FrmBOFToolListPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitPrinter()
    End Sub

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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        If String.IsNullOrEmpty(cboPrinter.Text.Trim()) Then
            MessageUtils.ShowError("请选择打印机!")
            Exit Sub
        End If

        Dim FilePathList = New List(Of String)
        For Each Item As String In PartIDList
            Dim ds = DbOperateUtils.GetDataSet("exec Proc_BOFExportAndPrintSql '" & Item & "'")
            ds.Tables(0).TableName = "dtMain"
            Dim dtMain = ds.Tables(0)
            ds.Tables(1).TableName = "A"
            Dim dtDetail = ds.Tables(1)

            Dim Designer = New WorkbookDesigner()

            Dim book = New Workbook("\\192.168.20.123\RunCard\EMCBOFEquipmentList.xls")
            Designer.Workbook = book
            Dim sheet = book.Worksheets(0)

            sheet.Name = "BOF清单"

            Dim dics = New Dictionary(Of String, String)
            dics.Add("PartID", dtMain.Rows(0)("PartID").ToString())
            dics.Add("CustName", dtMain.Rows(0)("CustName").ToString())
            dics.Add("Version", "版本:" + dtMain.Rows(0)("Version").ToString())
            dics.Add("AllTotal", dtMain.Rows(0)("AllTotal").ToString())
            dics.Add("InTime", Convert.ToDateTime(dtMain.Rows(0)("InTime").ToString()).ToString("yyyy-MM-dd"))
            dics.Add("PIEName", "PIE:" + dtMain.Rows(0)("PIEName").ToString())
            dics.Add("FEName", "FE:" + dtMain.Rows(0)("FEName").ToString())
            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                Designer.SetDataSource(dic.Key, dic.Value)
            Next

            Designer.SetDataSource(dtDetail)
            Designer.Process()
            Dim cells As Cells = sheet.Cells

            Dim list = New List(Of String)

            For i As Integer = 0 To dtDetail.Rows.Count - 1
                Dim StationName = dtDetail.Rows(i)("StationName").ToString()
                Dim R = dtDetail.Rows(i)("R").ToString()
                If (list.Contains(R + "_" + StationName) = False) Then
                    list.Add(R + "_" + StationName)
                    Dim Count As Integer = dtDetail.Select("R='" & R & "' and StationName='" & StationName & "'").Length
                    cells.Merge(3 + i, 0, Count, 1)
                    cells.Merge(3 + i, 1, Count, 1)
                End If
            Next
            Dim path = Application.StartupPath + "\\" & Replace(Item, "/", "_") & "-" & "治具BOF清单.xls"
            Designer.Workbook.Save(path)
            FilePathList.Add(path)

        Next
        For Each FilePath As String In FilePathList
            Dim MyBook = New Workbook(FilePath)
            Dim sheet = MyBook.Worksheets(0)
            Dim pageSet = sheet.PageSetup
            pageSet.Orientation = PageOrientationType.Portrait
            pageSet.PaperSize = PaperSizeType.PaperA4
            Dim options = New Rendering.ImageOrPrintOptions()
            Dim sheetRender = New Aspose.Cells.Rendering.SheetRender(sheet, options)
            'Dim printSettings = New System.Drawing.Printing.PrinterSettings()
            'Dim strPrinterName = printSettings.PrinterName
            sheetRender.ToImage(1)
            sheetRender.ToPrinter(cboPrinter.Text.Trim())
            System.IO.File.Delete(FilePath)
        Next
        Me.Close()
    End Sub
End Class