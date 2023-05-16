Imports SysBasicClass
Imports MainFrame
Imports VbCommClass
Imports System.Text

''' <summary>
''' 创建者：田玉琳
''' 创建日期：20190516
''' 内容：SAP关联查询共通化
''' </summary>
''' <remarks></remarks>
''' 
Public Class SapCommon

    'Private Shared FactoryID As String = VbCommClass.VbCommClass.Factory
    'Private Shared ProfitCenter As String = VbCommClass.VbCommClass.profitcenter
    Private Shared userID As String = VbCommClass.VbCommClass.UseId

    Public Shared Function GetTiptopLot(moid As String) As DataView
        Return OracleOperateUtils.getDataView(GetCheckTiptopLotSQL(moid))
    End Function

    Public Shared Function GetTiptopLotSAP(moid As String) As DataView
        Return OracleOperateUtils.getDataViewSap(GetCheckTiptopLotSQLSAP(moid))
    End Function

    Public Shared Function GetCheckTiptopLotSQL(ByVal LotName As String) As String
        Dim Sql As String
        'Sql = "select sfb05,nvl(sfb07,'') sfb07,sfb08,sfb22,to_char(sfb81,'yyyy/mm/dd') sfb81,nvl(sfb82,'') sfb82,sfbdate from " + OperationsCenter + ".sfb_file where sfb87 = 'Y' and sfb04 > '1' and sfb04 < '8' and sfb01 = " + LotName
        '下载订单预计交货日期oeb15、工单预计结束生产日期sfb15,cq 20151210
        'NVL(sfbud25,OEA10) OEA10==> nvl(sfbud25,nvl(OEBUD06,OEA10)) OEA10, cq20170714
        Sql = "SELECT sfb01,sfb05,ima021 partDesc,sfb22,sfb221,'' custor, tc_imc03,sfb82,sfb08,sfb02," _
               & " sfb04,to_char(sfb81,'yyyy/mm/dd') as sfb81, NVL(sfbud25,NVL(OEBUD06,OEA10)) OEA10, OCC34,OEB15,SFB15 " _
               & " FROM  " + VbCommClass.VbCommClass.Factory + ".sfb_file " _
               & " INNER JOIN " + VbCommClass.VbCommClass.Factory + ".ima_file ON " + VbCommClass.VbCommClass.Factory + ".sfb_file.SFB05=" + VbCommClass.VbCommClass.Factory + ".ima_file.IMA01 " _
               & " LEFT JOIN " + VbCommClass.VbCommClass.Factory + ".tc_imc_file ON   " + VbCommClass.VbCommClass.Factory + ".sfb_file.sfb82=" + VbCommClass.VbCommClass.Factory + ".tc_imc_file.tc_imc01 " _
               & " LEFT JOIN " + VbCommClass.VbCommClass.Factory + ".OEA_FILE ON   " + VbCommClass.VbCommClass.Factory + ".OEA_FILE.OEA01=" + VbCommClass.VbCommClass.Factory + ".sfb_file.SFB22 " _
               & " LEFT JOIN " + VbCommClass.VbCommClass.Factory + ".OCC_FILE ON " + VbCommClass.VbCommClass.Factory + ".OCC_FILE.OCC01=" + VbCommClass.VbCommClass.Factory + ".OEA_FILE.OEA03 " _
               & " LEFT JOIN " + VbCommClass.VbCommClass.Factory + ".OEB_FILE ON " + VbCommClass.VbCommClass.Factory + ".SFB_FILE.SFB22 = " + VbCommClass.VbCommClass.Factory + ".OEB_FILE.oeb01 " _
               & " AND " + VbCommClass.VbCommClass.Factory + ".SFB_FILE.sfb221 = " + VbCommClass.VbCommClass.Factory + ".OEB_FILE.oeb03" _
               & " WHERE sfb01='" + LotName + "' and sfb87 = 'Y' and sfb04 > '1' and sfb04 < '8'"
        If (Not String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter)) Then
            Sql = Sql + " and sfbbu = '" + VbCommClass.VbCommClass.profitcenter + "'"
        End If

        Return Sql
    End Function

    Public Shared Function GetCheckTiptopLotSQLSAP(ByVal LotName As String) As String
        Dim Sql As String
        Sql = " SELECT AUFNR as sfb01, MATNR as sfb05,'' partDesc,ZZVBELN as sfb22,ZZPOSNR as sfb221,'' custor, BUM as tc_imc03,ZZLINE as sfb82,GAMNG as sfb08," &
              "  (CASE AUART WHEN 'ZP01' THEN 1 WHEN 'ZP02' THEN 15 WHEN 'ZP03' THEN 5 WHEN 'ZP04' THEN 7  WHEN 'ZP05' THEN 8 ELSE 1 END) sfb02,'' AS sfb04," &
              " to_date(AEDAT,'yyyy-mm-dd') as sfb81, ZZBSTKD AS OEA10, '' OEB15,'' SFB15,ZZZEIVR,ZZCUST_VER,werks " &
              " FROM  ZTPP0017  WHERE AUFNR='" + LotName + "' and mandt = '" & VbCommClass.VbCommClass.SapServer & "'"
        Return Sql
    End Function
    Public Shared Function GetCheckTiptopLineLotSQLSAP(ByVal Line As String, ByVal moid As String) As String
        Dim Sql As String
        Dim strsql As New StringBuilder
        If Not String.IsNullOrEmpty(moid) Then
            strsql.Append(" and AUFNR like '%" & moid & "%'")
        End If
        If Not String.IsNullOrEmpty(Line) Then
            strsql.Append(" and ZZLINE like '%" & Line & "%'")
        End If
        Sql = " SELECT AUFNR as sfb01, MATNR as sfb05,'' partDesc,ZZVBELN as sfb22,ZZPOSNR as sfb221,'' custor, BUM as tc_imc03,ZZLINE as sfb82,GAMNG as sfb08," &
              "  (CASE AUART WHEN 'ZP01' THEN 1 WHEN 'ZP02' THEN 15 WHEN 'ZP03' THEN 5 WHEN 'ZP04' THEN 7  WHEN 'ZP05' THEN 8 ELSE 1 END) sfb02,'' AS sfb04," &
              " ZZBSTKD AS OEA10, '' OEB15,'' SFB15,ZZZEIVR,ZZCUST_VER,werks,AEDAT " &
              " FROM  ZTPP0017  WHERE  mandt = '" & VbCommClass.VbCommClass.SapServer & "' AND werks='" + VbCommClass.VbCommClass.Factory + "' AND AEDAT BETWEEN TO_CHAR(SYSDATE-10,'YYYYMMDD')  AND TO_CHAR(SYSDATE,'YYYYMMDD')" + strsql.ToString + "ORDER BY AEDAT desc"
        Return Sql
    End Function


    Public Shared Function GetPartInfo(dvTiptopLot As DataView) As DataView
        '下载料件信息
        Dim strSQL As String = "WITH BOM( BMB01, BMB03, BMB05, BMB06, MODIFYDATE, EXTENSIABLE ) AS ( " & _
        "SELECT BMB01, BMB03, BMB05, BMB06, BMBDATE AS MODIFYDATE, Decode(BMB19,3,'Y','N') as EXTENSIABLE " & _
        " FROM " + VbCommClass.VbCommClass.Factory + ".BMB_FILE " & _
        " WHERE BMB01='" & dvTiptopLot.Table.Rows(0).Item("SFB05").ToString & "' AND NVL(BMB_FILE.BMB05,SYSDATE)>=SYSDATE " &
        ") " & _
        "SELECT '" & dvTiptopLot.Table.Rows(0).Item("SFB05").ToString & "' AS PRODUCT_ID, NVL(BOM.BMB01,'" &
        dvTiptopLot.Table.Rows(0).Item("SFB05").ToString & "') AS PARENT_PART, IMA_FILE.IMA01, BOM.BMB05, NVL(BOM.BMB06,1) AS BMB06,  " &
        "MODIFYDATE, IMA_FILE.IMA021, IMA_FILE.IMA02, NVL(BMD_FILE.BMD03,0) AS BMD03, BMD_FILE.BMD04 " & _
        ",EXTENSIABLE,DECODE(INSTR(IMA021,'-',-1),0,'',SUBSTR(IMA021,INSTR(IMA021,'-',-1)+1,5)) Version " & _
        "FROM BOM " & _
        "INNER JOIN " + VbCommClass.VbCommClass.Factory + ".IMA_FILE ON IMA_FILE.IMA01=BOM.BMB03 " & _
        "LEFT JOIN " & VbCommClass.VbCommClass.Factory & ".BMD_FILE ON BMD_FILE.BMD01=IMA_FILE.IMA01 " & _
        "AND BMD_FILE.BMDACTI='Y' AND  NVL(BMD_FILE.BMD06,SYSDATE)>=SYSDATE AND BMD_FILE.BMD08='" &
        dvTiptopLot.Table.Rows(0).Item("SFB05").ToString & "' " & _
        "WHERE NVL(BOM.BMB05,SYSDATE)>=SYSDATE " & _
        "UNION ALL " & _
        "SELECT '" & dvTiptopLot.Table.Rows(0).Item("SFB05").ToString &
        "' AS PRODUCT_ID, BMA_FILE.BMA01 AS PARENT_PART, IMA_FILE.IMA01, SYSDATE AS BMB05, 1 AS BMB06, BMA_FILE.BMADATE MODIFYDATE, " &
        "IMA_FILE.IMA021, IMA_FILE.IMA02, 0 AS BMD03, '' AS BMD04, " & _
        " 'N'as  EXTENSIABLE, DECODE(INSTR(IMA021, '-', -1), 0, '', SUBSTR(IMA021, INSTR(IMA021, '-', -1) + 1, 5)) as version " & _
        "FROM " + VbCommClass.VbCommClass.Factory + ".BMA_FILE " & _
        "INNER JOIN " + VbCommClass.VbCommClass.Factory + ".IMA_FILE ON IMA_FILE.IMA01=BMA_FILE.BMA01 " & _
        "WHERE BMA01='" & dvTiptopLot.Table.Rows(0).Item("SFB05").ToString & "'"

        Dim dvChildPart As DataView = OracleOperateUtils.getDataView(strSQL)
        Return dvChildPart
    End Function

    Public Shared Function GetPartInfoSap(dvTiptopLot As DataView) As DataView
        '下载料件信息
        'Dim strSQL As String =
        '        " select detail.MATNR PRODUCT_ID,detail.MATNR PARENT_PART,detail.IDNRK IMA01," &
        '        " detail.idktx IMA02, detail.idktx IMA021, detail.MENGE AS BMB06, " &
        '        " (case when (select count(1) from bom_header where bom_header.matnr =  detail.idnrk and bom_header.werks = detail.werks ) =0 then 'N' else 'Y' end )EXTENSIABLE," &
        '        " header.ZEIVR  AS Version,0 AS BMD03, '' AS BMD04" &
        '        " from BOM_DETAIL  detail" &
        '        " left join BOM_HEADER header on detail.IDNRK = header.MATNR and detail.werks = header.werks  " &
        '        " where detail.STLAL = '01' and detail.MATNR = '{0}' and detail.werks = '{1}'"
        '"    union " &
        '" select MATNR,MATNR,MATNR,ZTEXT,ZTEXT,1,'Y',ZEIVR,0,'' " &
        '" from BOM_HEADER where MATNR = '{0}'"

        'strSQL = String.Format(strSQL, dvTiptopLot.Table.Rows(0).Item("SFB05").ToString, VbCommClass.VbCommClass.Factory)
        Dim strSQL As String = CommClass.GetErpFilterSqlSap(dvTiptopLot.Table.Rows(0).Item("SFB05").ToString, "1")

        Dim dvChildPart As DataView = OracleOperateUtils.getDataViewSap(strSQL)
        Return dvChildPart
    End Function

    Public Shared Function GetCustPartFromTT(ByVal parPartID As String) As String
        Dim strSQL As String = ""
        Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
        GetCustPartFromTT = ""
        Try
            strSQL = "SELECT OBK03 FROM (SELECT NVL(OBK03,OBK01)OBK03 FROM {0}.OBK_FILE WHERE OBK01 = '{1}' ORDER BY OBK04 DESC ) WHERE  ROWNUM = 1 "
            strSQL = String.Format(strSQL, VbCommClass.VbCommClass.Factory, parPartID)

            Dim dv As DataView = TiptopConn.getDataView(strSQL)
            If Not IsNothing(dv) Then
                GetCustPartFromTT = dv.Item(0).Item("OBK03")
            End If
            Return GetCustPartFromTT
        Catch ex As Exception
        Finally
            TiptopConn = Nothing
        End Try
    End Function

    Public Shared Function getCusIDFromTT(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
        getCusIDFromTT = ""
        Try
            lsSQL = " SELECT QCD01,TA_QCD09 FROM  " & VbCommClass.VbCommClass.Factory & ".QCD_FILE " & _
                    " WHERE QCD01='" & parPartID & "' AND TA_QCD09 IS NOT NULL AND ROWNUM=1"

            Dim dv As DataView = TiptopConn.getDataView(lsSQL)
            If Not IsNothing(dv) Then
                getCusIDFromTT = dv.Item(0).Item("TA_QCD09")
            Else
                getCusIDFromTT = ""
            End If
            Return getCusIDFromTT
        Catch ex As Exception
        Finally
            TiptopConn = Nothing
        End Try
    End Function

    Public Shared Function GetSerialIDFromTT(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        Dim TiptopConn As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
        GetSerialIDFromTT = ""
        Try
            lsSQL = " SELECT QCD01,TA_QCD10 FROM  " & VbCommClass.VbCommClass.Factory & ".QCD_FILE " & _
                    " WHERE QCD01='" & parPartID & "' AND TA_QCD10 IS NOT NULL AND ROWNUM=1 ORDER BY QCDDATE DESC"

            Dim dv As DataView = TiptopConn.getDataView(lsSQL)
            If Not IsNothing(dv) Then
                GetSerialIDFromTT = dv.Item(0).Item("TA_QCD10")
            Else
                GetSerialIDFromTT = ""
            End If
            Return GetSerialIDFromTT
        Catch ex As Exception
        Finally
            TiptopConn = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 从SPC取系列别和客户别
    ''' </summary>
    ''' <param name="parPN"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCustAndSeriesID(ByVal parPN As String) As DataTable

        Dim o_dt As DataSet = New DataSet
        Try
            Dim lsSQL As String = ""
            'lsSQL = " SELECT CusID=ISNULL(CusID,'') ,SeriesID=ISNULL(SeriesID,'')  FROM m_SpcPartCustSerial_t WHERE PartID  = '" & parPN & "'"
            'lsSQL = "select * from (SELECT b.TC_OAA01 as CusID, c.TC_OAB01 as SeriesID  FROM S2_MESMATERIALSITEMSET a,tc_oaa_file b ,tc_oab_file c  WHERE a.CUSTOMERCATEGEGORY=b.TC_OAA02 AND a.SERIESCATEGORY=c.TC_OAB02 and a.MATERIALNUMBER='" & parPN & "' order by a.ID desc ) A where ROWNUM<=1 "

            'update by 马跃平 2018-05-23 之前取客户ID和系列ID有问题,抓取的数据还是TT的数据
            '            lsSQL = "select c.tc_oaa01 as CusID,d.tc_oab01 as SeriesID" & vbCrLf &
            '"From  s2_MESMaterialsItemSet b " & vbCrLf &
            '            "Left Join " & vbCrLf &
            '"( " & vbCrLf &
            ' "select materialcode,customercategegory,seriescategory from ( " & vbCrLf &
            '"select * from S2_PRODUCTSTORE where materialcode='" & parPN & "' order by id desc" & vbCrLf &
            '") where rownum<=1" & vbCrLf &
            '") a  on b.materialnumber=a.materialcode  " & vbCrLf &
            ' "join tc_oaa_file c on c.tc_oaa02=b.customercategegory" & vbCrLf &
            '" join tc_oab_file d on d.tc_oab02=nvl(a.seriescategory,b.seriescategory)" & vbCrLf &
            ' "where b.materialnumber='" & parPN & "'"

            'add by 马跃平 2018-06-28
            lsSQL = "select * from (" & vbCrLf &
            "select nvl(customercategegoryid,'') as CusID," & vbCrLf &
            "nvl(seriescategoryid,'') as SeriesID from s2_MESMaterialsItemSet" & vbCrLf &
            "where materialnumber='" & parPN & "' order by id desc) where rownum<=1"
            o_dt = DBUtility.DbOracleForSpcHelperSQL.Query(lsSQL)
        Catch ex As Exception

        End Try
        Return o_dt.Tables(0)
    End Function

    Public Shared Function GetPartFatory() As String
        Dim strValue As String = " AND (factory='" & VbCommClass.VbCommClass.Factory & "' or factory = '') "

        Return strValue
    End Function

End Class
