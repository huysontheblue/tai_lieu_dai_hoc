Imports System
Imports System.Drawing.Printing
Imports MainFrame.SysDataHandle
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Text
Imports System.Windows.Forms

Public Class FrmSTDShowRunCard
    Public pn As String = ""
    Public mo As String = Nothing
    Public reportInputParametersVar As STDReportInputParameters
    'for  test
    Private Const runCardFilePath As String = "\\CrystalReport\\RunCard\\RunCardReport.rpt"
    Private Const runCardDetailListFilePath As String = "\\CrystalReport\\RunCard\\RunCardDetailList2.rpt"
    Private Const processCardFilePath As String = "\\CrystalReport\\RunCard\\ProcessCard.rpt"
    Private Const processCard2DFilePath As String = "\\CrystalReport\\RunCard\\ProcessCard2D.rpt"
    Public fileImagePath As String = Nothing
    Public filePath As String = Nothing
    Public filePathList As String() 'Add by CQ
    'Private Const runCardFilePath As String = "\\RunCardReport.rpt"

    Public Enum ReportType
        RunCardReport = 0
        RunCardDetailReport
        PorcessCardReport
    End Enum

    Public Enum PrintType
        ShowReport = 0
        PrintReport
        'ShowAndPrintReport
    End Enum

    Public Sub New(ByVal pnInput As String)
        reportInputParametersVar = New STDReportInputParameters
        pn = pnInput
        InitializeComponent()
    End Sub

    Public Sub New()
        reportInputParametersVar = New STDReportInputParameters
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    'Public Shared Sub InitRDoc()
    'If rDoc Is Nothing Then
    '    rDoc = New ReportDocument()
    '    'rDoc.Load(VbCommClass.VbCommClass.SopFilePath + runCardFilePath)
    'End If
    'End Sub
    Private Sub FrmShowRunCard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'DisposeReportDocument()
        Me.Dispose()
    End Sub

#Region "Main Function "

    ''' <summary>
    ''' 需要预览时调用可以打开form窗体预览报表的样式
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmShowRunCard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ShowOrPrintReport()
        If Not String.IsNullOrEmpty(fileImagePath) Then
            PictureBox1.Image = Image.FromFile(fileImagePath)
        End If
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

#End Region

#Region "Common Function"

    Private Sub ShowMessage(ByVal message As String, ByVal caption As String)
        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ShowReport(ByVal fileName As String, ByVal dt As DataTable)
        'If Not System.IO.File.Exists(VbCommClass.VbCommClass.SopFilePath + fileName) Then
        '    'DisposeReportDocument()
    End Sub

    Private Function ChangeDataSource(ByVal dt As DataTable) As DataTable
        Using dtNew As DataTable = New DataTable
            dtNew.Columns.Add("ID", GetType(Integer))
            dtNew.Columns.Add("WorkStationContent", GetType(String))
            dtNew.Columns.Add("Equipment", GetType(String))
            dtNew.Columns.Add("ProcessStandand", GetType(String))
            dtNew.Columns.Add("Comment", GetType(String))
            dtNew.Columns.Add("FunctionBarcode", GetType(String))
            dtNew.Columns.Add("MoId", GetType(String))
            dtNew.Columns.Add("Pn", GetType(String))
            dtNew.Columns.Add("MoQty", GetType(Integer))
            dtNew.Columns.Add("ConfigQty", GetType(String))
            dtNew.Columns.Add("MQty", GetType(Integer))
            dtNew.Columns.Add("BarcodePath", GetType(Byte()))
            dtNew.Columns.Add("PBarcode", GetType(Byte()))
            dtNew.Columns.Add("MoBarcode", GetType(Byte()))
            dtNew.Columns.Add("ID1", GetType(Integer)) '以下为第二列
            dtNew.Columns.Add("WorkStationContent1", GetType(String))
            dtNew.Columns.Add("MoQty1", GetType(Integer))
            dtNew.Columns.Add("BarcodePath1", GetType(Byte()))
            dtNew.Columns.Add("FunctionBarcode1", GetType(String))
            Dim dr As DataRow
            Dim totalCount As Integer = dt.Rows.Count / 2
            For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                dr = dtNew.NewRow
                'dr("ID") = dt.Rows(i * 2)("ID")
                'dr("WorkStationContent") = dt.Rows(i * 2)("WorkStationContent")
                dr("ID") = dt.Rows(i)("ID")
                dr("WorkStationContent") = dt.Rows(i)("WorkStationContent")
                dr("Comment") = dt.Rows(i)("Comment")
                dr("FunctionBarcode") = dt.Rows(i)("FunctionBarcode")
                dr("MoId") = dt.Rows(i)("MoId")
                dr("Pn") = dt.Rows(i)("Pn")
                dr("MoQty") = dt.Rows(i)("MoQty")
                dr("ConfigQty") = dt.Rows(i)("ConfigQty")
                dr("MQty") = dt.Rows(i)("MQty")
                dr("BarcodePath") = dt.Rows(i)("BarcodePath")
                dr("PBarcode") = dt.Rows(i)("PBarcode")
                dr("MoBarcode") = dt.Rows(i)("MoBarcode")
                pn = dt.Rows(i)("Pn")
                If dt.Rows.Count > i + 1 AndAlso pn = dt.Rows(i + 1)("pn") Then
                    dr("ID1") = dt.Rows(i + 1)("ID")
                    dr("WorkStationContent1") = dt.Rows(i + 1)("WorkStationContent")
                    dr("MoQty1") = dt.Rows(i + 1)("MoQty")
                    dr("BarcodePath1") = dt.Rows(i + 1)("BarcodePath")
                    dr("FunctionBarcode1") = dt.Rows(i + 1)("FunctionBarcode")
                    i += 1
                End If
                dtNew.Rows.Add(dr)
                If i > dt.Rows.Count Then Exit For
            Next
            Return dtNew
        End Using
    End Function
    Private Function PrintReport(ByVal filePath As String, ByVal dt As DataTable) As Boolean
        'If Not System.IO.File.Exists(VbCommClass.VbCommClass.SopFilePath + filePath) Then
        '    ShowMessage(filePath + " 不存在", "错误信息")
        '    Return False
        'End If
        ''rDoc.Load(Environment.CurrentDirectory + filePath)
        'rDoc.Load(VbCommClass.VbCommClass.SopFilePath + filePath)
        'If reportInputParametersVar.PrintMethod = "TWO-D" Then
        '    Generate2DBarcode.Generate2DBarcodes(dt)
        '    dt = ChangeDataSource(dt)
        'End If
        'rDoc.SetDataSource(dt)
        'BindReportParameters(dt)
        'rDoc.PrintOptions.PrinterName = reportInputParametersVar.printerName
        'rDoc.PrintOptions.PaperSize = PaperSize.PaperA5
        'If reportInputParametersVar.reportTypeFlag = ReportType.PorcessCardReport Then
        '    rDoc.PrintOptions.PaperOrientation = PaperOrientation.Portrait
        'Else
        '    rDoc.PrintOptions.PaperOrientation = PaperOrientation.Landscape
        'End If
        'rDoc.PrintToPrinter(reportInputParametersVar.copies, True, 1, 400)
        'UpdateMoStatus()
        'DisposeReportDocument()
        'Return True
    End Function

    Private Sub BindReportParameters(ByVal dt As DataTable)
        Select Case reportInputParametersVar.reportTypeFlag
            Case ReportType.RunCardReport
                BindRunCardParameters(dt)
            Case ReportType.RunCardDetailReport
                BindRunCardDetailListParameters(dt)
            Case ReportType.PorcessCardReport
                BindSTDProcessCardParameters(dt)
        End Select
    End Sub

    Private Sub ShowReportByReportType()
        Select Case reportInputParametersVar.reportTypeFlag
            Case ReportType.RunCardReport
                ShowRunCardReport()
            Case ReportType.RunCardDetailReport
                ShowRunCardDetailList()
            Case ReportType.PorcessCardReport
                ShowProcessCard()
        End Select
    End Sub

    Private Sub PrintReportByReportType()
        Select Case reportInputParametersVar.reportTypeFlag
            Case ReportType.RunCardReport
                PrintRunCardReport()  'Maybe no use, 20150922,cq
            Case ReportType.RunCardDetailReport
                PrintRunCardDetailList()
            Case ReportType.PorcessCardReport
                PrintSTDProcessCard()
        End Select
    End Sub

    Private Sub UpdateMoStatus()
        Dim sConn As SysDataBaseClass = Nothing
        Try
            sConn = New SysDataBaseClass
            Dim sql As String = "UPDATE M_RUNCARDWORKORDER_T SET ISPRINTED=N'已列印' WHERE MOID IN(" & reportInputParametersVar.Mo & ") AND PARTID IN(" & reportInputParametersVar.Pn & ") " & vbNewLine & _
            "UPDATE M_RUNCARDWORKORDER_T SET ISPRINTED=(CASE WHEN EXISTS(SELECT top 1  1 FROM M_RUNCARDWORKORDER_T WHERE PARENTMO='" & mo.Trim & "' AND MOID<>PARENTMO AND ISPRINTED IS NULL) THEN N'列印中' ELSE N'已列印' end) WHERE MOID='" & mo.Trim & "'"
            sConn.ExecSql(sql)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Sub

#End Region

#Region "Show Run Card"

    Private Sub ShowRunCardReport()
        Using dt As DataTable = GetRunCardDataTable()
            If dt.Rows.Count <= 1 Then
                'DisposeReportDocument()
                ShowMessage("该料件还没有维护工艺流程卡,请先维护工艺流程卡！！或输入的是成套料件或成套工单,请确认！！", "提示信息")
                Exit Sub
            End If
            ShowReport(runCardFilePath, dt)
        End Using
    End Sub

    Public Function GetRunCardDataTable() As DataTable
        Dim sqlConn As New SysDataBaseClass
        Using dt As DataTable = sqlConn.GetDataTable(GetRunCardSql())
            'for test
            'For i As Integer = 1 To 15
            '    dt.Rows.Add("Test", "", i, "", "0", "", "", "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest", "", "", "")
            'Next
            dt.Rows.Add("test", "", "", dt.Rows.Count + 1, "", "0", "", "", "", "", "", "0", "", "", "0", "", Nothing, Nothing, "", "")
            Return dt
        End Using
    End Function

    Private Function GetRunCardSql() As String
        Dim sql = "SELECT DRAWINGNO,DRAWINGVER,SHAPE,ID,WORKSTATIONCONTENT,LABORHOUR," & vbNewLine & _
        " EQUIPMENT,PROCESSSTANDARD,COMMENT,OPERATOR,IPQC,SID SECTIONNAME,DESCRIPTION1,DESCRIPTION," & vbNewLine & _
        " STATUS,USERID,CONVERT(VARCHAR(10),INTIME,111) INTIME,DID,LEFT(RAWINFO,LEN(RAWINFO)-3) as RAWINFO," & vbNewLine & _
        " LEFT(EQUIPMENTINFO,LEN(EQUIPMENTINFO)-1) as EQUIPMENTINFO FROM(" & vbNewLine & _
         "SELECT A.*," & vbNewLine & _
         " (SELECT PARTD.DESCRIPTION1+' || '" & vbNewLine & _
         " FROM M_RUNCARDDETAIL_T DETAIL," & vbNewLine & _
         " M_RUNCARDPARTDETAIL_T PARTDETAIL,M_RUNCARDPARTNUMBER_T PARTD" & vbNewLine & _
          "        WHERE(DETAIL.ID = A.DID)" & vbNewLine & _
          " AND DETAIL.ID=PARTDETAIL.RUNCARDDETAILID" & vbNewLine & _
          " AND PARTDETAIL.PARTID=PARTD.ID" & vbNewLine & _
          " AND ISNULL(PARTD.TYPE,'R')='R'" & vbNewLine & _
          " FOR XML PATH('')) AS RAWINFO," & vbNewLine & _
          " (" & vbNewLine & _
          " SELECT PARTD.PARTNUMBER+','" & vbNewLine & _
         " FROM M_RUNCARDDETAIL_T DETAIL," & vbNewLine & _
         " M_RUNCARDPARTDETAIL_T PARTDETAIL,M_RUNCARDPARTNUMBER_T PARTD" & vbNewLine & _
         " WHERE DETAIL.ID=PARTDETAIL.RUNCARDDETAILID" & vbNewLine & _
          " AND PARTDETAIL.PARTID=PARTD.ID" & vbNewLine & _
          " AND DETAIL.ID=A.DID" & vbNewLine & _
          " AND PARTD.TYPE='E'" & vbNewLine & _
          " FOR XML PATH('')" & vbNewLine & _
          " ) AS EQUIPMENTINFO" & vbNewLine & _
          " FROM (" & vbNewLine & _
          " SELECT DISTINCT '' DRAWINGNO,HEADER.DRAWINGVER,HEADER.SHAPE, " & vbNewLine & _
          " CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID, " & vbNewLine & _
          " STATION.STATIONNAME WORKSTATIONCONTENT,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR, " & vbNewLine & _
          " DETAIL.EQUIPMENT EQUIPMENT,DETAIL.PROCESSSTANDARD PROCESSSTANDARD, " & vbNewLine & _
          " DETAIL.REMARK COMMENT,'' OPERATOR,'' IPQC,SECTION.ID SID,PART.DESCRIPTION1," & vbNewLine & _
          " PART.DESCRIPTION,HEADER.STATUS,PART.USERID,PART.INTIME,DETAIL.ID DID" & vbNewLine & _
          " FROM M_RUNCARDPARTNUMBER_T PART,M_RUNCARD_T HEADER,M_RUNCARDDETAIL_T DETAIL," & vbNewLine & _
          " M_RUNCARDSTATION_T STATION LEFT JOIN M_RUNCARDSTATIONSECTION_T SECTION " & vbNewLine & _
          " ON STATION.SECTIONID=SECTION.ID AND SECTION.STATUS=1  " & vbNewLine & _
          " WHERE PART.PARTNUMBER='" & pn & "' " & vbNewLine & _
          " AND HEADER.PARTID =PART.ID  " & vbNewLine & _
          " AND HEADER.ID=DETAIL.RUNCARDID  " & vbNewLine & _
          " AND DETAIL.STATIONID =STATION.ID  " & vbNewLine & _
         " ) A)A ORDER BY A.ID"
        Return sql
    End Function

    Private Enum RunCardEnum
        DrawingNo = 0
        DrawingVer
        Shape
        ID
        WorkStationContent
        LaborHour
        Equipment
        ProcessStandard
        Comment
        Operater
        IPQC
        SectionName
        Description1
        Description
        Status
        UserId
        Intime
        DID
        RawInfo
        EquipmentInfo
    End Enum
#End Region

#Region "Print Run Card"
    Private Sub PrintRunCardReport()
        Try
            Using dt As DataTable = GetRunCardDataTable()
                If dt.Rows.Count <= 1 Then
                    'DisposeReportDocument()
                    ShowMessage("该料件还没有维护工艺流程卡,请先维护工艺流程卡", "提示信息")
                    Exit Sub
                End If
                If PrintReport(runCardFilePath, dt) Then
                    ShowMessage("工艺流程卡打印成功", "提示信息")
                End If
            End Using
        Catch ex As Exception
            'DisposeReportDocument()
            Throw ex
        End Try
    End Sub

    Private Sub BindRunCardParameters(ByVal dt As DataTable)
        'If dt.Rows.Count > 1 Then
        '    '图号
        '    rDoc.SetParameterValue("RunCardGraphPar", pn)
        '    '版本
        '    rDoc.SetParameterValue("RunCardVersionPar", dt.Rows(0)(RunCardEnum.DrawingVer).ToString())
        '    '形态
        '    rDoc.SetParameterValue("RunCardShapePar", dt.Rows(0)(RunCardEnum.Shape).ToString())
        '    '总工时
        '    rDoc.SetParameterValue("RunCardTotalHourPar", Convert.ToDouble(dt.Compute("sum(LaborHour)", "")) * (1 + 0.005 * (dt.Rows.Count - 1)))
        '    If dt.Select("SECTIONNAME = 1").Length > 0 Then
        '        rDoc.SetParameterValue("RunCardPreAssemblyPar", dt.Compute("sum(LaborHour)", "SECTIONNAME = 1"))
        '    Else
        '        rDoc.SetParameterValue("RunCardPreAssemblyPar", "")
        '    End If
        '    '成型
        '    If dt.Select("SECTIONNAME = 3").Length > 0 Then
        '        rDoc.SetParameterValue("RunCardAssemblyPar", dt.Compute("sum(LaborHour)", "SECTIONNAME = 3"))
        '    Else
        '        rDoc.SetParameterValue("RunCardAssemblyPar", "")
        '    End If
        '    '规格
        '    rDoc.SetParameterValue("RunCardDescriptionPar", dt.Rows(0)(RunCardEnum.Description))
        '    '描述
        '    rDoc.SetParameterValue("RunCardDescription1Par", dt.Rows(0)(RunCardEnum.Description1))
        '    '状态

    End Sub

#End Region

#Region "Show Run Card Detail List"
    Private Sub ShowRunCardDetailList()
        If Not CheckPnType(ReportType.RunCardDetailReport) Then
            ShowMessage("该料件下面没有要显示的子件料,请确认输入的是成套的料件编号或是成套的工单编号！！", "提示信息")
            Exit Sub
        ElseIf True = False Then
            STDReloadBomInfo.ReloadBom(pn)
        End If
        Using dt As DataTable = GetRunCardDetailListDataTable()
            If dt.Rows.Count <= 1 Then
                ShowMessage("该料件下面没有要显示的子件料或是子件料没有维护流程卡信息，请确认！！", "提示信息")
                Exit Sub
            End If
            ShowReport(runCardDetailListFilePath, dt)
        End Using
    End Sub

    Public Function GetRunCardDetailListDataTable() As DataTable
        Dim sqlConn As New SysDataBaseClass
        Using dt As DataTable = sqlConn.GetDataTable(GetRunCardDetailListSql())
            'for test
            dt.Rows.Add(dt.Rows.Count + 1, "tst", "0", 0, "0", "0", "0", "0", "0", "0", "0", "0")
            Return dt
        End Using
    End Function

    Private Function GetRunCardDetailListSql() As String
        Dim sql = "SELECT CAST(ROW_NUMBER() OVER(ORDER BY PN) AS INT)ID,A.PN,A.VERSION,CAST(A.QTY AS INT) QTY," & vbNewLine & _
        " SUM(A.PREASSEMBLYHOURPRECHILD+A.ASSEMBLYHOURPRECHILD+A.MADEHOURPRECHILD) TOTALHOURPRECHILD," & vbNewLine & _
        " SUM(A.PREASSEMBLYHOURPREMO+A.ASSEMBLYHOURPREMO+A.MADEHOURPREMO) TOTALHOURPREMO," & vbNewLine & _
        " SUM(A.PREASSEMBLYHOURPRECHILD) PREASSEMBLYHOURPRECHILD," & vbNewLine & _
        " SUM(A.ASSEMBLYHOURPRECHILD) ASSEMBLYHOURPRECHILD," & vbNewLine & _
        " SUM(A.MADEHOURPRECHILD) MADEHOURPRECHILD," & vbNewLine & _
        " SUM(A.PREASSEMBLYHOURPREMO) PREASSEMBLYHOURPREMO," & vbNewLine & _
        " SUM(A.ASSEMBLYHOURPREMO) ASSEMBLYHOURPREMO," & vbNewLine & _
        " SUM(A.MADEHOURPREMO)  MADEHOURPREMO" & vbNewLine & _
        " FROM (" & vbNewLine & _
        " SELECT M.PARTNUMBER PN,A.DRAWINGVER VERSION,ISNULL(D.QTY,0) QTY ," & vbNewLine & _
        "            CASE F.ID" & vbNewLine & _
        " WHEN 1 THEN ISNULL(B.WORKINGHOURS,0)*ISNULL(D.QTY,0)" & vbNewLine & _
        " ELSE 0 END PREASSEMBLYHOURPRECHILD," & vbNewLine & _
        "            CASE F.ID" & vbNewLine & _
        " WHEN 2 THEN ISNULL(B.WORKINGHOURS,0)*ISNULL(D.QTY,0)" & vbNewLine & _
        " ELSE 0 END ASSEMBLYHOURPRECHILD," & vbNewLine & _
        "             CASE F.ID" & vbNewLine & _
        " WHEN 3 THEN ISNULL(B.WORKINGHOURS,0)*ISNULL(D.QTY,0)" & vbNewLine & _
        " ELSE 0 END MADEHOURPRECHILD," & vbNewLine & _
                    " CASE F.ID" & vbNewLine & _
        " WHEN 1 THEN ISNULL(B.WORKINGHOURS,0)*ISNULL(D.QTY,0)  " & vbNewLine & _
        " ELSE 0 END PREASSEMBLYHOURPREMO," & vbNewLine & _
                    " CASE F.ID" & vbNewLine & _
        " WHEN 2 THEN ISNULL(B.WORKINGHOURS,0)*ISNULL(D.QTY,0)  " & vbNewLine & _
        " ELSE 0 END ASSEMBLYHOURPREMO," & vbNewLine & _
                    " CASE F.ID" & vbNewLine & _
        " WHEN 3 THEN ISNULL(B.WORKINGHOURS,0)*ISNULL(D.QTY,0)  " & vbNewLine & _
        " ELSE 0 END MADEHOURPREMO" & vbNewLine & _
        " FROM M_RUNCARD_T A,M_RUNCARDDETAIL_T B,M_RUNCARDBOMINFO_T D,M_RUNCARDPARTNUMBER_T H,M_RUNCARDPARTNUMBER_T M," & vbNewLine & _
        " M_RUNCARDSTATION_T E LEFT JOIN M_RUNCARDSTATIONSECTION_T F ON E.SECTIONID =F.ID AND F.STATUS ='1'" & vbNewLine & _
        " WHERE H.PARTNUMBER='" & pn & "'" & vbNewLine & _
        " AND H.ID=D.PARENTPARTID " & vbNewLine & _
        " AND D.EFFECTIVEDATE<=CONVERT(VARCHAR(10),GETDATE(),111)" & vbNewLine & _
        " AND (D.EXPIRATIONDATE='' OR D.EXPIRATIONDATE>=CONVERT(VARCHAR(10),GETDATE(),111) )" & vbNewLine & _
        " AND D.EXTENSIBLE='Y'" & vbNewLine & _
        " AND D.PARTID=A.PARTID" & vbNewLine & _
        " AND A.ID=B.RUNCARDID" & vbNewLine & _
        " AND D.PARTID=M.ID " & vbNewLine & _
        " AND M.PARTNUMBER LIKE '" & pn.Substring(0, 1) & "%'" & vbNewLine & _
        " AND A.STATUS IN(1,2)" & vbNewLine & _
        " AND B.STATUS=1" & vbNewLine & _
        " AND B.STATIONID =E.ID " & vbNewLine & _
        "  )A" & vbNewLine & _
        " GROUP BY PN,VERSION,QTY "

        Return sql
    End Function


    Private Function GetVersion(ByVal format As String) As String
        Dim arr() As String
        arr = format.Split("-")
        If arr.Length > 1 Then
            Return arr(arr.Length - 1)
        End If
        Return ""
    End Function

    Private Function CheckPnType(ByVal reportType As ReportType) As Boolean
        Dim sConn As New SysDataBaseClass
        Dim sql As String = Nothing
        Select Case reportType
            Case FrmSTDShowRunCard.ReportType.RunCardDetailReport
                sql = "SELECT PARENTPARTID FROM M_RUNCARDBOMINFO_T A,M_RUNCARDPARTNUMBER_T B WHERE A.PARENTPARTID=B.ID AND B.PARTNUMBER='" & pn & "' AND EXTENSIBLE='Y'"
                If sConn.GetRowsCount(sql) > 0 Then Return True
            Case FrmSTDShowRunCard.ReportType.RunCardReport
                sql = "SELECT PARENTPARTID FROM M_RUNCARDBOMINFO_T A,M_RUNCARDPARTNUMBER_T B WHERE A.PARTID=B.ID AND B.PARTNUMBER='" & pn & "' AND EXTENSIBLE='Y'"
                If sConn.GetRowsCount(sql) > 0 Then Return True
        End Select
        Return False
    End Function

#End Region

#Region "Print Run Card Detail List"

    Private Sub PrintRunCardDetailList()
        Try
            Using dt As DataTable = GetRunCardDetailListDataTable()
                If dt.Rows.Count <= 1 Then
                    'DisposeReportDocument()
                    ShowMessage("该料件下面没有要显示的子件料，请确认！！！", "提示信息")
                    Exit Sub
                End If
                If PrintReport(runCardDetailListFilePath, dt) Then
                    ShowMessage("工艺流程卡明细表列印成功", "提示信息")
                End If
            End Using
        Catch ex As Exception
            'DisposeReportDocument()
            Throw ex
        End Try
    End Sub

    Private Sub BindRunCardDetailListParameters(ByVal dt As DataTable)
        '
    End Sub

    Private Shared Sub DisposeReportDocument()
        'If Not rDoc Is Nothing Then
        '    rDoc.Dispose()
        '    rDoc = Nothing
        'End If
    End Sub
#End Region

#Region "Show Process Card"
    Private Sub ShowProcessCard()
        Using dt As DataTable = GetProcessCardDataTable()
            If dt.Rows.Count < 1 Then
                'DisposeReportDocument()
                ShowMessage("该工单对应的料件没有维护工艺流程卡或是流程卡未生效,请确认！！！！", "提示信息")
                Exit Sub
            End If
            ShowReport(processCardFilePath, dt)
        End Using
    End Sub

    Private Function GetProcessCardDataTable() As DataTable
        Dim sqlConn As New SysDataBaseClass
        Using dt As DataTable = sqlConn.GetDataTable(GetProcessCardSql())
            'for test
            'For i As Integer = 1 To 3
            '    dt.Rows.Add(i, "裁玻璃纤维管副本", "1111111/111111/1111111" + i.ToString, "123", "9041506EW1-00E000E", "0515C-1405008010094", "")
            'Next
            Return dt
        End Using
    End Function

    Private Function GetProcessCardSql() As String
        Dim sql As String = ""
        sql = "SELECT ROW_NUMBER() OVER(PARTITION BY A.PARTNUMBER ORDER BY A.PARTNUMBER,C.STATIONSQ) ID," & vbNewLine & _
        "D.STATIONNAME WORKSTATIONCONTENT," & vbNewLine & _
        " 'F/'+M.MOID+'/'+CAST(A.ID AS VARCHAR)+'/'+CAST(D.ID AS VARCHAR) FUNCTIONBARCODE,  " & vbNewLine & _
        " M.MOQTY * ISNULL(E.QTY,1)  MOQTY ,A.PARTNUMBER PN,M.MOID,'' COMMENT,M.ORDERNO,ISNULL(E.QTY,1) ConfigQty,M.MOQTY MQTY,'' BarcodePath " & vbNewLine & _
        " FROM M_RUNCARDPARTNUMBER_T A LEFT JOIN M_RUNCARDBOMINFO_T E ON A.ID=E.PARTID LEFT JOIN M_RUNCARDPARTNUMBER_T F ON  F.PARTNUMBER='" & pn & "' AND E.PARENTPARTID=F.ID" & vbNewLine & _
        ",M_RUNCARD_T B,M_RUNCARDDETAIL_T C,M_RUNCARDWORKORDER_T M, M_RUNCARDSTATION_T D " & vbNewLine & _
        " WHERE M.PARTID IN(" & reportInputParametersVar.Pn & ") " & vbNewLine & _
        " AND M.MOID IN(" & reportInputParametersVar.Mo & ")" & vbNewLine & _
        " AND M.PARTID=A.PARTNUMBER" & vbNewLine & _
        " AND A.ID =B.PARTID" & vbNewLine & _
        " AND B.ID=C.RUNCARDID  " & vbNewLine & _
        " AND C.STATIONID =D.ID " & vbNewLine & _
        " AND B.STATUS=1 " & vbNewLine & _
        " AND C.STATUS=1"
        Return sql
    End Function

    'Private Function GetPorcessCardParameters(ByVal dt As DataTable) As ParameterFields
    '    Dim pFields As New ParameterFields
    '    If dt.Rows.Count > 0 Then
    '        '产品名称
    '        pFields.Add(SetReportParameterValues("ProductName", dt.Rows(0)("Pn").ToString))
    '        '工单
    '        pFields.Add(SetReportParameterValues("MO", dt.Rows(0)("MoId").ToString))
    '        pFields.Add(SetReportParameterValues("MoNonBarcode", dt.Rows(0)("MoId").ToString))
    '        '工单数量
    '        pFields.Add(SetReportParameterValues("MoQty", dt.Rows(0)("MoQty").ToString))
    '        '配置数
    '        pFields.Add(SetReportParameterValues("ConfigQty", dt.Rows(0)("ConfigQty").ToString))
    '    Else
    '        '产品名称
    '        pFields.Add(SetReportParameterValues("ProductName", ""))
    '        '工单
    '        pFields.Add(SetReportParameterValues("MO", ""))
    '        pFields.Add(SetReportParameterValues("MoNonBarcode", ""))
    '        '工单数量
    '        pFields.Add(SetReportParameterValues("MoQty", ""))
    '        '配置数
    '        pFields.Add(SetReportParameterValues("ConfigQty", 1))
    '    End If
    '    Return pFields
    'End Function
#End Region

#Region "Print Process Card"
    Private Sub PrintSTDProcessCard()
        Try
            Using dt As DataTable = GetProcessCardDataTable()
                If dt.Rows.Count < 1 Then
                    'DisposeReportDocument()
                    ShowMessage("该工单对应的料件没有维护工艺工时流程卡或是流程未通过审核,请确认！！！！", "提示信息")
                    Exit Sub
                End If
                If reportInputParametersVar.PrintMethod = "ONE-D" Then
                    PrintReport(processCardFilePath, dt)
                ElseIf reportInputParametersVar.PrintMethod = "TWO-D" Then
                    PrintReport(processCard2DFilePath, dt)
                End If
            End Using
        Catch ex As Exception
            'DisposeReportDocument()
            Throw ex
        End Try
    End Sub

    Private Sub BindSTDProcessCardParameters(ByVal dt As DataTable)
        'If dt.Rows.Count > 0 Then
        '    rDoc.SetParameterValue("ProductName", dt.Rows(0)("Pn").ToString)
        '    rDoc.SetParameterValue("MO", dt.Rows(0)("MoId").ToString)
        '    rDoc.SetParameterValue("MoNonBarcode", dt.Rows(0)("MoId").ToString)
        '    rDoc.SetParameterValue("MoQty", dt.Rows(0)("MoQty").ToString)
        '    rDoc.SetParameterValue("ConfigQty", dt.Rows(0)("ConfigQty").ToString)
        'Else
        '    rDoc.SetParameterValue("ProductName", "")
        '    rDoc.SetParameterValue("MO", "")
        '    rDoc.SetParameterValue("MoNonBarcode", "")
        '    rDoc.SetParameterValue("MoQty", "")
        '    rDoc.SetParameterValue("ConfigQty", 1)
        'End If
    End Sub

#End Region

#Region "Print"

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If cboPrinter.SelectedItem = "" Or cboPrinter.SelectedItem = Nothing Then
            MessageBox.Show("请选择打印机", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        For Each o_filePath As String In filePath.Split(",")
            Print(o_filePath)
        Next
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
            xlWorkSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape
            xlWorkSheet.PrintOut(1, 10, 1, Nothing, cboPrinter.SelectedItem, Nothing, Nothing, Nothing)
            Me.lblMsg.Text &= "打印 " & o_filePath & " OK" & vbNewLine
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
#End Region

End Class

#Region "输入参数"
''' <summary>
''' 用作输入参数，未来如果还有其他报表时可以添加自己所需的参数
''' </summary>
''' <remarks></remarks>
Public Class STDReportInputParameters
    ''' <summary>
    ''' 打印份数,默认为1表示一份
    ''' </summary>
    ''' <remarks></remarks>
    Public copies As Integer = 1

    ''' <summary>
    ''' 打印机名称，默认为Microsoft XPS Document Writer
    ''' </summary>
    ''' <remarks></remarks>
    Public printerName As String = "Microsoft XPS Document Writer"

    ''' <summary>
    ''' 需要显示那种Report
    ''' </summary>
    ''' <remarks></remarks>
    Public reportTypeFlag As FrmSTDShowRunCard.ReportType

    ''' <summary>
    ''' 直接打印还是显示
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public printTypeFlag As FrmSTDShowRunCard.PrintType

    ''' <summary>
    ''' 是否需要显示打印，刷新，导出的按钮
    ''' </summary>
    ''' <remarks></remarks>
    Public showPrintButton As Boolean = True
    Public showRefreshButton As Boolean = False
    Public showExportButton As Boolean = True

    ''' <summary>
    ''' 列印所有的料件，目前已废弃不用
    ''' </summary>
    ''' <remarks></remarks>
    Public printAll As Boolean = False

    ''' <summary>
    ''' 料件编号
    ''' </summary>
    ''' <remarks></remarks>
    Public Pn As String

    ''' <summary>
    ''' 工单编号
    ''' </summary>
    ''' <remarks></remarks>
    Public Mo As String

    ''' <summary>
    ''' 列印方式
    ''' </summary>
    ''' <remarks></remarks>
    Public PrintMethod As String

End Class
#End Region