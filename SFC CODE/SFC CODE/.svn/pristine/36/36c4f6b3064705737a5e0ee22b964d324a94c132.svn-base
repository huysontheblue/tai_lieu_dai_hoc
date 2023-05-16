Imports DevExpress.XtraCharts
Imports MainFrame
Imports System.Xml
Imports MainFrame.SysDataHandle
Imports System.Text
Imports MainFrame.SysCheckData
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraCharts.Printing
Imports System.Drawing.Imaging
Imports DevComponents.DotNetBar

Public Class FrmReportChar
    Dim Conn As New SysDataHandle.SysDataBaseClass
    Dim SysClass As String = "0"
    Dim SqlserverName As String = "" '"data source=172.17.32.12;initial catalog=MESDB;uid=sa;pwd=050033068027066029014023030"
    Dim ServerIP As String
    Public opFlag As Integer = 0
    Enum MyViewType
        ViewBar
        ViewLine
    End Enum
    ''' <summary>
    ''' 默认统计图标题
    ''' </summary>
    ''' <remarks></remarks>
    Private _CharTitle As String = "统计分析报表"
    Public Property CharTitle() As String
        Get
            Return _CharTitle
        End Get
        Set(ByVal value As String)
            _CharTitle = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private _MultipleSeries As Boolean = False
    Public Property MultipleSeries() As Boolean
        Get
            Return _MultipleSeries
        End Get
        Set(ByVal value As Boolean)
            _MultipleSeries = value
        End Set
    End Property
    ''' <summary>
    ''' 统计图样式，
    ''' </summary>
    ''' <remarks></remarks>
    Private _ChartViewType As DevExpress.XtraCharts.ViewType = ViewType.Bar
    Public Property ChartViewType() As DevExpress.XtraCharts.ViewType
        Get
            Return _ChartViewType
        End Get
        Set(ByVal value As DevExpress.XtraCharts.ViewType)
            _ChartViewType = value
        End Set
    End Property
    ''' <summary>
    ''' 统计图样式，
    ''' </summary>
    ''' <remarks></remarks>
    Private _ChartViewType1 As DevExpress.XtraCharts.ViewType = ViewType.Line
    Public Property ChartViewType1() As DevExpress.XtraCharts.ViewType
        Get
            Return _ChartViewType1
        End Get
        Set(ByVal value As DevExpress.XtraCharts.ViewType)
            _ChartViewType1 = value
        End Set
    End Property

    ''' <summary>
    ''' 默认统计图标题
    ''' </summary>
    ''' <remarks></remarks>
    Private _SummaryTitle As String = "工站1不良数" '"不良率"
    Public Property SummaryTitle() As String
        Get
            Return _SummaryTitle
        End Get
        Set(ByVal value As String)
            _SummaryTitle = value
        End Set
    End Property
    ''' <summary>
    ''' 复合统计图，第二个统计标题名称
    ''' </summary>
    ''' <remarks></remarks>
    Private _SummaryTitle1 As String = "工站2不良数" ' "累积增长量"
    Public Property SummaryTitle1() As String
        Get
            Return _SummaryTitle1
        End Get
        Set(ByVal value As String)
            _SummaryTitle1 = value
        End Set
    End Property

    ''' <summary>
    ''' 传递汇总后的数据DataTable，呈现统计图
    ''' </summary>
    ''' <remarks></remarks>
    Private _SummaryDs As DataSet = New DataSet
    Public Property SummaryDs() As DataSet
        Get
            'Dim sql As String = "select date,qty from test where name='C027902'  select date,qty from test where name='C123245'"
            '_SummaryDs = Conn.GetDataSet(sql)
            Return _SummaryDs
        End Get
        Set(ByVal value As DataSet)
            _SummaryDs = value
        End Set
    End Property
    Private Sub FrmReportChar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If SummaryDs.Tables.Count > 0 Then
            ComboBoxItem2.Visible = False
        Else
            ComboBoxItem2.Visible = True
        End If
        CreateChar()
    End Sub
    
    Private Sub CreateChar()

        'Dim sql As String = "select Argument,Frate=round(1.0000*FailCount/(FailCount+PassCount),4),Prate=round(1.0000*PassCount/(FailCount+PassCount),4),FailCount,PassCount from (select Argument,max(case when result='FAIL' then cout end) 'FailCount',max(case when result='PASS' then cout end) 'PassCount' from (select Argument=CONVERT(varchar(7),Collecttime,121),result=Result,cout=count(Result) from [m_GaussRecord_t] where Collecttime>'2015-04-01' group by CONVERT(varchar(7),Collecttime,121),Result) AA group by Argument) BB "
        Dim sql As String = "declare @tb table(Xcol varchar(30),Ycol decimal(9,4) )" '产生随机DEMO数据'
        sql = sql + "declare @i int=1"
        sql = sql + "insert @tb(Xcol,Ycol)"
        sql = sql + "select 'X001',100+cast(rand()*1000 as int)"
        sql = sql + "insert @tb(Xcol,Ycol)"
        sql = sql + "select 'X002',200+cast(rand()*1000 as int)"
        sql = sql + "insert @tb(Xcol,Ycol)"
        sql = sql + "select 'X003',300+cast(rand()*1000 as int)"
        sql = sql + "insert @tb(Xcol,Ycol)"
        sql = sql + "select 'X004',1000+cast(rand()*1000 as int)"
        sql = sql + "insert @tb(Xcol,Ycol)"
        sql = sql + "select 'X005',1000+cast(rand()*1000 as int)"
        sql = sql + "insert @tb(Xcol,Ycol)"
        sql = sql + "select 'X006',1000+cast(rand()*1000 as int)"
        sql = sql + "insert @tb(Xcol,Ycol)"
        sql = sql + "select 'X007',1000+cast(rand()*1000 as int)"
        sql = sql + "insert @tb(Xcol,Ycol)"
        sql = sql + "select 'X008',1000+cast(rand()*1000 as int)"
        sql = sql + "select * from @tb"

        sql = sql + " declare @tb1 table(Xcol varchar(30),Ycol decimal(9,4) )" '产生随机DEMO数据'
        'sql = sql + "declare @i int=1"
        sql = sql + " insert @tb1(Xcol,Ycol)"
        sql = sql + " select 'X001',100+cast(rand()*1000 as int)"
        sql = sql + " insert @tb1(Xcol,Ycol)"
        sql = sql + " select 'X002',200+cast(rand()*1000 as int)"
        sql = sql + " insert @tb1(Xcol,Ycol)"
        sql = sql + " select 'X003',300+cast(rand()*1000 as int)"
        sql = sql + " insert @tb1(Xcol,Ycol)"
        sql = sql + " select 'X004',1000+cast(rand()*1000 as int)"
        sql = sql + " insert @tb1(Xcol,Ycol)"
        sql = sql + " select 'X005',1000+cast(rand()*1000 as int)"
        sql = sql + " insert @tb1(Xcol,Ycol)"
        sql = sql + " select 'X006',1000+cast(rand()*1000 as int)"
        sql = sql + " insert @tb1(Xcol,Ycol)"
        sql = sql + " select 'X007',1000+cast(rand()*1000 as int)"
        sql = sql + " insert @tb1(Xcol,Ycol)"
        sql = sql + " select 'X008',1000+cast(rand()*1000 as int)"
        sql = sql + " select * from @tb1"
        Dim dt As DataTable = New DataTable
        If SummaryDs.Tables.Count > 0 Then
            dt = SummaryDs.Tables(0)

        Else

            SummaryDs = Conn.GetDataSet(sql)
            dt = SummaryDs.Tables(0)
         
        End If


        Dim dv As DataView = dt.DefaultView
        dv.Sort = dt.Columns(0).ColumnName
        Dim dtnew As DataTable = dv.ToTable
        If MultipleSeries Then
            ChartControl1.Series.Clear()
            For i = 0 To dtnew.Rows.Count - 1
                Dim _Series As Series = New Series(dtnew.Rows(i)(0).ToString, ViewType.Bar)
                Dim _SeriesPoint As SeriesPoint() = New SeriesPoint() {New SeriesPoint(dtnew.Rows(i)(0).ToString, (Double.Parse(dtnew.Rows(i)(1))))}
                _Series.Points.Add(_SeriesPoint(0))
                ChartControl1.Series.Add(_Series)
            Next
        Else
            ChartControl1.Series.Clear()
            Dim _Series As Series = New Series(SummaryTitle, ChartViewType)
            For i = 0 To dtnew.Rows.Count - 1
                Dim _SeriesPoint As SeriesPoint() = New SeriesPoint() {New SeriesPoint(dtnew.Rows(i)(0).ToString, (Double.Parse(dtnew.Rows(i)(1))))}
                _Series.Points.Add(_SeriesPoint(0))
            Next
            ChartControl1.Series.Add(_Series)
            If SummaryDs.Tables.Count = 2 Then
                dt = SummaryDs.Tables(1)
                dv = dt.DefaultView
                dv.Sort = dt.Columns(0).ColumnName
                dtnew = dv.ToTable
                _Series = New Series(SummaryTitle1, ChartViewType1)
                For i = 0 To dtnew.Rows.Count - 1
                    Dim _SeriesPoint As SeriesPoint() = New SeriesPoint() {New SeriesPoint(dtnew.Rows(i)(0).ToString, (Double.Parse(dtnew.Rows(i)(1))))}
                    _Series.Points.Add(_SeriesPoint(0))
                Next
                ChartControl1.Series.Add(_Series)
            End If
        End If
        ChartControl1.Titles(0).Text = CharTitle
    End Sub

#Region "ExportTo Char Data"
    Private Function PrepeareForPrintOrExport(ByVal checkPrinterAvailable As Boolean) As ChartControl
        If (Not PrintHelper.IsPrintingAvailable) AndAlso checkPrinterAvailable Then
            XtraMessageBox.Show("XtraPrinting Library is currently inaccesible.", "XtraCharts Demo")
            Return Nothing
        End If
        Return ChartControl1
    End Function
    Private Function ShowSaveFileDialog(ByVal title As String, ByVal filter As String) As String
        Dim dlg As SaveFileDialog = New SaveFileDialog()
        Dim name As String = Application.ProductName
        Dim n As Integer = name.LastIndexOf(".") + 1
        If n > 0 Then
            name = name.Substring(n, name.Length - n)
        End If
        dlg.Title = "Export To " & title
        dlg.FileName = name
        dlg.Filter = filter
        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Return dlg.FileName
        End If
        Return ""
    End Function
    Private Sub OpenFile(ByVal fileName As String)
        If XtraMessageBox.Show("Do you want to open this file?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Dim process As System.Diagnostics.Process = New System.Diagnostics.Process()
                process.StartInfo.FileName = fileName
                process.StartInfo.Verb = "Open"
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                process.Start()
            Catch
                XtraMessageBox.Show("Cannot find an application on your system suitable for openning the file with exported data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub ExportTo(ByVal title As String, ByVal filter As String, ByVal exportFormat As String)
        ExportTo(title, filter, exportFormat, Nothing, True)
    End Sub

    Private Sub ExportTo(ByVal title As String, ByVal filter As String, ByVal exportFormat As String, ByVal format As ImageFormat, ByVal checkPrinterAvailable As Boolean)
        Dim chart As ChartControl = PrepeareForPrintOrExport(checkPrinterAvailable)
        If chart Is Nothing Then
            Return
        End If
        Dim fileName As String = ShowSaveFileDialog(title, filter)
        If fileName <> "" Then
            Dim currentCursor As Cursor = Cursor.Current
            Cursor.Current = Cursors.WaitCursor
            Select Case exportFormat
                Case "HTML"
                    chart.ExportToHtml(fileName)
                Case "MHT"
                    chart.ExportToMht(fileName)
                Case "PDF"
                    Dim sizeMode As PrintSizeMode = chart.OptionsPrint.SizeMode
                    chart.OptionsPrint.SizeMode = PrintSizeMode.Zoom
                    Try
                        chart.ExportToPdf(fileName)
                    Finally
                        chart.OptionsPrint.SizeMode = sizeMode
                    End Try
                Case "XLS"
                    chart.ExportToXls(fileName)
                Case "XLSX"
                    chart.ExportToXlsx(fileName)
                Case "RTF"
                    chart.ExportToRtf(fileName)
                Case "IMAGE"
                    chart.ExportToImage(fileName, format)
            End Select
            Cursor.Current = currentCursor
            OpenFile(fileName)
        End If
    End Sub
    Public Sub ExportToHtml()
        ExportTo("HTML Document", "HTML Documents (*.htm; *.html)|*.htm; *.html", "HTML")
    End Sub
    Public Sub ExportToMht()
        ExportTo("MHT Document", "MHT Documents (*.mht)|*.mht", "MHT")
    End Sub
    Public Sub ExportToPdf()
        ExportTo("PDF Document", "PDF Documents (*.pdf)|*.pdf", "PDF")
    End Sub
    Public Sub ExportToXls()
        ExportTo("XLS Document", "XLS Documents (*.xls)|*.xls", "XLS")
    End Sub
    Public Sub ExportToXlsx()
        ExportTo("XLSX Document", "XLSX Documents (*.xlsx)|*.xlsx", "XLSX")
    End Sub
    Public Sub ExportToRtf()
        ExportTo("RTF Document", "RTF Documents (*.rtf)|*.rtf", "RTF")
    End Sub
    Public Sub ExportToJPG()
        ExportTo("JPEG Document", "JPEG Documents (*.JPEG)|*.JPEG", "JPEG", ImageFormat.Jpeg, False)
    End Sub
    Public Sub ExportToBMP()
        ExportTo("BMP Document", "BMP Documents (*.BMP)|*.BMP", "BMP", ImageFormat.Bmp, False)
    End Sub
    Public Sub ExportToPNG()
        Dim formatTitle As String = "PNG image"
        Dim fileMask As String = "*.PNG"
        Dim format As ImageFormat = ImageFormat.Png
        ExportTo(formatTitle, String.Format("{0} ({1})|{1}", formatTitle, fileMask), "IMAGE", format, False)
    End Sub
    Public Sub ExportToImage(ByVal imageCodecInfo As ImageCodecInfo, ByVal format As ImageFormat)
        Dim formatTitle As String = String.Format("{0} image", imageCodecInfo.FormatDescription)
        Dim fileMask As String = imageCodecInfo.FilenameExtension
        ExportTo(formatTitle, String.Format("{0} ({1})|{1}", formatTitle, fileMask), "IMAGE", format, False)
    End Sub

#End Region


    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub CheckBoxItem1_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItem1.CheckedChanged
        For Each series As Series In ChartControl1.Series
            If series.Label IsNot Nothing Then
                series.Label.Visible = Me.CheckBoxItem1.Checked
            End If
        Next series
        'UpdateControls()
    End Sub



    Private Sub ComboBoxItem1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItem1.SelectedIndexChanged

        Dim ExportType As String = ComboBoxItem1.SelectedItem.ToString
        Select Case ExportType
            Case "Export to PDF"
                ExportToPdf()
            Case "Export to HTML"
                ExportToHtml()
            Case "Export to XLS"
                ExportToXls()
            Case "Export to XLSX"
                ExportToXlsx()
            Case "Export to JPEG"
                ExportToJPG()
            Case "Export to PNG"
                ExportToPNG()
            Case "Export to BMP"
                ExportToBMP()
        End Select


    End Sub

    Private Sub ComboBoxItem2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItem2.SelectedIndexChanged
        If ComboBoxItem2.SelectedIndex = 0 Then
            MultipleSeries = True
        Else
            MultipleSeries = False
        End If
        CreateChar()
    End Sub
End Class