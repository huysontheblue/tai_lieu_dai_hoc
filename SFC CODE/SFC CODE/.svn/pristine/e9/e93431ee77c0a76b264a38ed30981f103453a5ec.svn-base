Imports System
Imports System.Drawing.Printing
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Text
Imports System.Windows.Forms
Imports MainFrame

Public Class FrmShowRunCard
    Public pn As String = ""
    Public mo As String = Nothing
    Public reportInputParametersVar As ReportInputParameters
    'for  test
    'Private Const runCardFilePath As String = "\\CrystalReport\\RunCard\\RunCardReport.rpt"
    'Private Const runCardDetailListFilePath As String = "\\CrystalReport\\RunCard\\RunCardDetailList2.rpt"
    Private Const processCardFilePath As String = "\\CrystalReport\\RunCard\\ProcessCard.rpt"
    Private Const processCard2DFilePath As String = "\\CrystalReport\\RunCard\\ProcessCard2D.rpt"
    Public fileImagePath As String = Nothing
    Public filePath As String = Nothing
    Public filePathList As String() 'Add by CQ
    Public m_iDirection As Integer = -1

#Region "初期化"

    Public Sub New(ByVal pnInput As String)
        reportInputParametersVar = New ReportInputParameters
        pn = pnInput
        InitializeComponent()
    End Sub

    Public Sub New()
        reportInputParametersVar = New ReportInputParameters
        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

#Region "Main Function "

    Private Sub FrmShowRunCard_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop

    End Sub

    ''' <summary>
    ''' 需要预览时调用可以打开form窗体预览报表的样式
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrmShowRunCard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
#End Region

#Region "属性"
    Public Enum ReportType
        RunCardReport = 0
        RunCardDetailReport '工艺流程卡明细表
        StdTimeReport
        'PorcessCardReport
    End Enum

    Public Enum PrintType
        ShowReport = 0
        PrintReport
        'ShowAndPrintReport
    End Enum
#End Region

    Private Sub FrmShowRunCard_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

#Region "Common Function"

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
                dr("ID") = dt.Rows(i)("ID")
                dr("WorkStationContent") = dt.Rows(i)("WorkStationContent")
                'dr("Equipment") = dt.Rows(i * 2)("Equipment")
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

    Private Sub UpdateMoStatus()
        'Dim sConn As SysDataBaseClass = Nothing
        Try
            'sConn = New SysDataBaseClass
            Dim sql As String = "UPDATE m_Mainmo_t SET ISPRINTED=N'已列印' WHERE MOID IN(" & reportInputParametersVar.Mo & ") AND PARTID IN(" & reportInputParametersVar.Pn & ") " & vbNewLine & _
            "UPDATE m_Mainmo_t SET ISPRINTED=(CASE WHEN EXISTS(SELECT top 1  1 FROM m_Mainmo_t WHERE PARENTMO='" & mo.Trim & "' AND MOID<>PARENTMO AND ISPRINTED IS NULL) THEN N'列印中' ELSE N'已列印' end) WHERE MOID='" & mo.Trim & "'"
            DbOperateUtils.ExecSQL(sql)
        Catch ex As Exception
            Throw ex
        Finally
            'If Not sConn Is Nothing Then
            '    sConn = Nothing
            'End If
        End Try
    End Sub

#End Region

#Region "Show Run Card"

    Private Sub ShowRunCardReport()
        Using dt As DataTable = GetRunCardDataTable()
            If dt.Rows.Count <= 1 Then
                MessageUtils.ShowInformation("该料件还没有维护工艺流程卡,请先维护工艺流程卡！！或输入的是成套料件或成套工单,请确认！！")
                Exit Sub
            End If
        End Using
    End Sub

    Public Function GetRunCardDataTable() As DataTable
        'Dim sqlConn As New SysDataBaseClass
        Using dt As DataTable = DbOperateUtils.GetDataTable(GetRunCardSql())
            'for test
            'For i As Integer = 1 To 15
            '    dt.Rows.Add("Test", "", i, "", "0", "", "", "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest", "", "", "")
            'Next
            dt.Rows.Add("test", "", "", dt.Rows.Count + 1, "", "0", "", "", "", "", "", "0", "", "", "0", "", Nothing, Nothing, "", "")
            Return dt
        End Using
    End Function

    Public Function GetRunCardDataTable_StdTime(ByVal strPNList As String) As DataTable
        'Dim sqlConn As New SysDataBaseClass
        Using dt As DataTable = DbOperateUtils.GetDataTable(GetStdTotalTimeSql(strPNList))
            ' dt.Rows.Add("test", "", "", dt.Rows.Count + 1, "", "0", "", "", "", "", "", "0", "", "", "0", "", Nothing, Nothing, "", "")
            Return dt
        End Using
    End Function
    Private Function GetStdTotalTimeSql(strPNList) As String
      

        Dim sql As String =
            "SELECT aa.PAvcPart,cast(SUM(aa.singleTime)+28+SUM(AmountQty)*10 AS DECIMAL(38,0)) TOTALTIME FROM " & _
            "(SELECT a.PartID,SUM(b.WorkingHours*part.AmountQty) AS singleTime,part.PAvcPart,part.AmountQty FROM m_RCardM_t AS a" & _
            " LEFT JOIN m_RCardD_t AS b  ON a.PartID =b.PartID" & _
            " LEFT JOIN v_m_PartContrast_t_1021 AS part ON  a.PartID= part.TAvcPart" & _
            " WHERE 1=1 "

        sql = sql + " and part.PAvcPart IN ( "
        Dim strloop As String = ""
        For i = 0 To strPNList.Split(";").Length - 1
            strloop = strloop + ",'" + strPNList.Split(";")(i) + "'"
        Next
        sql = sql + strloop.Substring(1) + ")"
        '904092860','904092861')" & _
        sql = sql + " GROUP BY a.PartID, part.PAvcPart,AmountQty)aa" & _
            " GROUP BY aa.PAvcPart"
        Return sql

    End Function

    'cq20161128  remove "   AND Part.TAvcPart <> part.PAvcPart    " & _
    Private Function GetRunCardSql() As String
        Dim sql =
            "SELECT   DRAWINGNO,DRAWINGVER,SHAPE,ID,WORKSTATIONCONTENT,LABORHOUR, " &
            "         EQUIPMENT,PROCESSSTANDARD,COMMENT,OPERATOR,IPQC,SID SECTIONNAME,DESCRIPTION,TypeDest, " &
            "         STATUS,USERID,CONVERT(VARCHAR(10),INTIME,111) INTIME,PartID,LEFT(RAWINFO,LEN(RAWINFO)-3) as RAWINFO, " &
            "         LEFT(EQUIPMENTINFO,LEN(EQUIPMENTINFO)-1) as EQUIPMENTINFO FROM( " &
            " SELECT A.*, " &
             "( " &
            "      SELECT distinct PARTD.TAvcPart+':'+PARTD.DESCRIPTION+' || '" &
            "      FROM m_RCardDPart_t PARTDETAIL,m_PartContrast_t PARTD" &
            "      WHERE PARTDETAIL.PartID  = A.PARTID" &
            "        AND PARTDETAIL.EWPartNumber=PARTD.TAvcPart" &
            "        AND PARTDETAIL.Stationid  = A.Stationid" &
            "        AND PARTDETAIL.PartID = A.PartID" &
            "        AND ISNULL(PARTD.TYPE,'R')='R'" &
            "        FOR XML PATH('')) AS RAWINFO, " &
            "( " &
            "        SELECT PARTD.TAvcPart+',' " &
            "        FROM m_RCardD_t DETAIL,m_RCardDPart_t PARTDETAIL,m_PartContrast_t PARTD " &
            "        WHERE DETAIL.PartID=PARTDETAIL.PartID " &
            "        AND PARTDETAIL.PartID=PARTD.TAvcPart " &
            "        AND PARTDETAIL.PartID=A.PartID " &
            "        AND PARTD.TYPE='E' " &
            "         FOR XML PATH('')) AS EQUIPMENTINFO " &
            "   FROM ( " &
            "   SELECT DISTINCT '' DRAWINGNO,HEADER.DRAWINGVER,HEADER.SHAPE,  " &
            "   CAST(ROW_NUMBER() OVER(ORDER BY DETAIL.STATIONSQ) AS INT) ID, STATION.Stationid, " &
            "   STATION.STATIONNAME WORKSTATIONCONTENT,ISNULL(DETAIL.WORKINGHOURS,0) LABORHOUR,  " &
            "   DETAIL.EQUIPMENT EQUIPMENT,DETAIL.PROCESSSTANDARD PROCESSSTANDARD,  " &
            "   DETAIL.REMARK COMMENT,'' OPERATOR,'' IPQC,SECTION.ID SID,PART.DESCRIPTION,PART.TypeDest, " &
            "   HEADER.STATUS,PART.USERID,PART.INTIME,DETAIL.PartID  " &
            "   FROM V_m_PartContrast_t PART,m_RCardM_t HEADER,m_RCardD_t DETAIL,m_Rstation_t STATION  " &
            "        LEFT JOIN m_RstationSection_t SECTION  " &
            "   ON STATION.SECTIONID=SECTION.ID AND SECTION.usey=1   " &
            "   WHERE PART.TAvcPart='" & pn & "'  " & _
            RCardComBusiness.GetFatoryProfitcenter("HEADER") & _
            RCardComBusiness.GetFatoryProfitcenter("DETAIL") & _
            "   AND TAvcPart =PAvcPart " &
            "   AND HEADER.PARTID =PART.TAvcPart   " & _
            "   AND HEADER.PARTID=DETAIL.PARTID AND TAvcPart =PAvcPart" & _
            "   AND DETAIL.STATIONID =STATION.Stationid   " & _
            "   )A)A ORDER BY A.ID "
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

    Public Function GetRCardStdTotalTimeDataTable() As DataTable
        'Dim sqlConn As New SysDataBaseClass
        Using dt As DataTable = DbOperateUtils.GetDataTable(GetRunCardSql())
            'for test
            'For i As Integer = 1 To 15
            '    dt.Rows.Add("Test", "", i, "", "0", "", "", "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest", "", "", "")
            'Next
            dt.Rows.Add("test", "", "", dt.Rows.Count + 1, "", "0", "", "", "", "", "", "0", "", "", "0", "", Nothing, Nothing, "", "")
            Return dt
        End Using
    End Function

#Region "Show Run Card Detail List"
    Private Sub ShowRunCardDetailList()
        If Not CheckPnType(ReportType.RunCardDetailReport) Then
            MessageUtils.ShowInformation("该料件下面没有要显示的子件料,请确认输入的是成套的料件编号或是成套的工单编号！！")
            Exit Sub
        End If
        Using dt As DataTable = GetRunCardDetailListDataTable()
            If dt.Rows.Count <= 1 Then
                MessageUtils.ShowInformation("该料件下面没有要显示的子件料或是子件料没有维护流程卡信息，请确认！！")
                Exit Sub
            End If
        End Using
    End Sub

    Public Function GetRunCardDetailListDataTable() As DataTable
        'Dim sqlConn As New SysDataBaseClass
        Dim lssql As String = ""
        lssql = "  SELECT * FROM dbo.fun_GetRCardListNew('" & pn.Trim & "') "
        Using dt As DataTable = DbOperateUtils.GetDataTable(lssql) 'GetRunCardDetailListSql()
            'for test
            'dt.Rows.Add(dt.Rows.Count + 1, "tst", "0", 0, "0", "0", "0")
            dt.Rows.Add(dt.Rows.Count + 1, "tst", "0", 0, "0", "0", "0", "0", "0", "0", "0", "0")
            Return dt
        End Using
    End Function

    'Private Function GetRunCardDetailListSql() As String
    '    Dim sql As String = ""
    '    '子件总工时	/裁切（04）/铆端（01）/半自动压接（A05）/成型（03）/产线（02）
    '    ' AND ISNULL(D.EXTENSIBLE,'Y')='Y'  " &,cq remove 20160618
    '    'cq remove m_PartContrast_t M 20160628
    '    'D.PAvcPart LIKE '%904011912%' , 20160811, like change to 904011912
    '    sql = "SELECT  " &
    '      " CAST(ROW_NUMBER() OVER(ORDER BY PN) AS INT)ID,  " &
    '      " A.PN,A.VERSION,CAST(A.QTY AS INT) QTY,  " &
    '      "  Convert(decimal(18,2), SUM(A.PREASSEMBLYHOURPRECHILD+A.ContourHourPreChild+A.MADEHOURPRECHILD + A.CutProPREChild + A.ProPrePREChild + A.SemiAutoPREChild)) TOTALHOURPRECHILD,  " &
    '      "  Convert(decimal(18,2),SUM(A.CutProPREChild)) CutProPREChild,  " & _
    '      " Convert(decimal(18,2),SUM(A.PREASSEMBLYHOURPRECHILD)) PREAssemblyHOURPREChild,  " &
    '      " SUM(A.SemiAutoPREChild) SemiAutoPREChild," & _
    '      " Convert(decimal(18,2),SUM(A.ContourHourPreChild)) ContourHourPreChild,  " &
    '      " SUM(A.MADEHOURPRECHILD) MadeHOURPRECHILD,  " & _
    '      " SUM(A.CutProPREMO)  CutProPREMO,  " & _
    '      " Convert(decimal(18,2),SUM(A.PREASSEMBLYHOURPREMO)) PREASSEMBLYHOURPREMO,  " &
    '      " SUM(A.SemiAutoPREMO)  SemiAutoPREMO,  " & _
    '      " SUM(A.ContourHOURPREMO) ContourHOURPREMO,  SUM(A.MADEHOURPREMO) MADEHOURPREMO " &
    '      " FROM (  " &
    '      " SELECT DISTINCT D.TAvcPart PN,B.StationSQ,A.DRAWINGVER VERSION,ISNULL(D.AmountQty,0) QTY ,  " &
    '      "            CASE F.ID  " &
    '      " WHEN '01' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)   ELSE 0 END PREASSEMBLYHOURPRECHILD,  " &
    '      "            CASE F.ID  " &
    '      " WHEN '02' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)   ELSE 0 END MadeHOURPRECHILD,  " &
    '      "             CASE F.ID  " &
    '      " WHEN '03' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)   ELSE 0 END ContourHourPreChild,  " & _
    '      "       CASE F.ID  " & _
    '      " WHEN '04' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)  " &
    '      " ELSE 0 END CutProPREChild,  " & _
    '       "       CASE F.ID  " & _
    '         " WHEN '05' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)  " &
    '      " ELSE 0 END ProPrePREChild,  " & _
    '      "       CASE F.ID  " &
    '      " WHEN 'A05' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)  " &
    '      " ELSE 0 END SemiAutoPREChild,  " & _
    '      "             CASE F.ID  " &
    '      " WHEN '01' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)    ELSE 0 END PREASSEMBLYHOURPREMO,  " &
    '      "             CASE F.ID  " &
    '      " WHEN '02' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)    ELSE 0 END MadeHOURPREMO,  " &
    '      "             CASE F.ID  " &
    '      " WHEN '03' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)    ELSE 0 END ContourHOURPREMO,  " & _
    '      " CASE F.ID" & _
    '      " WHEN '04' THEN ISNULL (B.WorkingHours, 0) * ISNULL(D.AmountQty, 0)" & _
    '       " ELSE 0 End  CutProPREMO," & _
    '       " CASE F.ID  " & _
    '       " WHEN '05' THEN  ISNULL(B.WorkingHours, 0) * ISNULL(D.AmountQty, 0)" & _
    '       " ELSE 0 End ProPrePREMO," & _
    '       " CASE F.ID " & _
    '       " WHEN 'A05' THEN ISNULL(B.WorkingHours, 0) * ISNULL (D.AmountQty, 0)" & _
    '       " ELSE 0  End SemiAutoPREMO" & _
    '      " FROM m_RCardM_t A,m_RCardD_t B,m_PartContrast_t D,  " &
    '      " m_Rstation_t E LEFT JOIN m_RstationSection_t F ON E.SECTIONID =F.ID AND F.usey =1  " &
    '      " WHERE ISNULL(D.EFFECTIVEDATE,GETDATE()-1)<=CONVERT(VARCHAR(10),GETDATE(),111)  " &
    '      " AND (D.EXPIRATIONDATE='' OR ISNULL(D.EXPIRATIONDATE, GETDATE() +1) >=GETDATE() )  " &
    '      " AND D.TAvcPart=A.PARTID " &
    '      " AND A.PartID =B.PartID " &
    '      " AND D.TAvcPart <> D.PAvcPart" & _
    '    " AND D.PAvcPart = '" & pn.Trim & "' " &
    '      RCardComBusiness.GetFatoryProfitcenter("A") &
    '      RCardComBusiness.GetFatoryProfitcenter("B") &
    '      " AND A.STATUS IN(1,2) " &
    '      " AND B.STATUS=1 " &
    '      " AND B.StationID =E.Stationid " &
    '      " AND A.PartID LIKE '9%' " &
    '      "  )A " &
    '      " GROUP BY PN,VERSION,QTY  "

    '    Return sql

    'End Function

    Private Function GetPnVersion(ByVal rpn As String) As String
        'Dim oConn As New SysDataBaseClass
        Dim sql As String = "SELECT A.DESCRIPTION FROM m_PartContrast_t A,m_PartContrast_t B WHERE B.TAvcPart='" & rpn & "' AND B.TAvcPart=A.PAvcPart"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Return GetVersion(dt.Rows(0)(0))
            End If
        End Using
        Return ""
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
        Dim sql As String = Nothing
        Select Case reportType
            Case FrmShowRunCard.ReportType.RunCardDetailReport
                sql = "SELECT A.PAvcPart FROM m_PartContrast_t A,m_PartContrast_t B WHERE A.PAvcPart=B.TAvcPart AND B.TAvcPart='" & pn & "' AND EXTENSIBLE=1"
                If DbOperateUtils.GetRowsCount(sql) > 0 Then Return True
            Case FrmShowRunCard.ReportType.RunCardReport
                sql = "SELECT A.PAvcPart FROM m_PartContrast_t A,m_PartContrast_t B WHERE A.PAvcPart=B.TAvcPart AND B.TAvcPart='" & pn & "' AND EXTENSIBLE=1"
                If DbOperateUtils.GetRowsCount(sql) > 0 Then Return True
        End Select
        Return False
    End Function

#End Region

#Region "Print Run Card Detail List"

    Private Sub PrintRunCardDetailList()
        Try
            Using dt As DataTable = GetRunCardDetailListDataTable()
                If dt.Rows.Count <= 1 Then
                    MessageUtils.ShowInformation("该料件下面没有要显示的子件料，请确认！！！")
                    Exit Sub
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Show Process Card"

    Private Sub ShowProcessCard()
        Using dt As DataTable = GetProcessCardDataTable()
            If dt.Rows.Count < 1 Then
                MessageUtils.ShowInformation("该工单对应的料件没有维护工艺流程卡或是流程卡未生效,请确认！！！！")
                Exit Sub
            End If
        End Using
    End Sub

    Private Function GetProcessCardDataTable() As DataTable
        Using dt As DataTable = DbOperateUtils.GetDataTable(GetProcessCardSql())
            Return dt
        End Using
    End Function

    Private Function GetProcessCardSql() As String
        Dim sql As String = ""
        sql =
            " SELECT ROW_NUMBER() OVER(PARTITION BY A.TAvcPart ORDER BY A.TAvcPart,C.STATIONSQ) ID, " &
            "        D.STATIONNAME WORKSTATIONCONTENT, " &
            "         'F/'+M.MOID+'/'+c.StationID FUNCTIONBARCODE,   " &
            "         M.MOQTY * ISNULL(f.AmountQty,1)  MOQTY ,A.TAvcPart PN,M.MOID,'' COMMENT,M.ORDERNO,ISNULL(f.AmountQty,1) ConfigQty,M.MOQTY MQTY,'' BarcodePath  " &
            "         FROM m_PartContrast_t A LEFT JOIN m_PartContrast_t F ON  F.TAvcPart='' AND a.PAvcPart=f.TAvcPart " &
            "         ,m_RCardM_t B,m_RCardD_t C,m_Mainmo_t M, m_Rstation_t D  " &
            "         WHERE M.PARTID IN(" & reportInputParametersVar.Pn & ")  " &
            "         AND M.MOID IN(" & reportInputParametersVar.Mo & ") " &
            RCardComBusiness.GetFatoryProfitcenter("B") &
            "         AND M.PARTID=A.TAvcPart " &
            "         AND A.TAvcPart =B.PARTID " &
            "         AND B.PARTID=C.PARTID   " &
            "         AND C.STATIONID =D.Stationid  " &
            "         AND B.STATUS=1  " &
            "         AND C.STATUS=1 "

        Return sql
    End Function

#End Region

#Region "Print Process Card"
    Private Sub PrintProcessCard()
        Try
            Using dt As DataTable = GetProcessCardDataTable()
                If dt.Rows.Count < 1 Then
                    MessageUtils.ShowInformation("该工单对应的料件没有维护工艺工时流程卡或是流程未通过审核,请确认！！！！")
                    Exit Sub
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Print"

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If cboPrinter.SelectedItem = "" Or cboPrinter.SelectedItem = Nothing Then
            MessageUtils.ShowError("请选择打印机！")
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
            If m_iDirection <> 1 AndAlso m_iDirection <> 2 Then
                m_iDirection = 2
            End If
            xlWorkSheet.PageSetup.Orientation = m_iDirection
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
Public Class ReportInputParameters
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
    Public reportTypeFlag As FrmShowRunCard.ReportType

    ''' <summary>
    ''' 直接打印还是显示
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public printTypeFlag As FrmShowRunCard.PrintType

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