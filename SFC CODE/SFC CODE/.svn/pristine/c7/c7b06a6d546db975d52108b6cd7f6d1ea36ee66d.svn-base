Imports System.Text
Imports SysBasicClass
Imports MainFrame
'Imports SysBasicClass

Public Class SapCommon


    Private Shared factoryID As String = VbCommClass.VbCommClass.Factory
    Private Shared profitCenter As String = VbCommClass.VbCommClass.profitcenter
    Private Shared userID As String = VbCommClass.VbCommClass.UseId

    'Public Shared Function GetErpFilterSqlSap(partNo As String) As String
    '    Dim querySql As String =
    '        "   select ROW_NUMBER() OVER(ORDER BY detail.IDNRK) ID,detail.MATNR ParentPartId,detail.IDNRK ChildPartId," &
    '        "   header.MAKTX ParentFormat,detail.idktx ChildFormat," &
    '        "   header.MAKTX ParentDescription,detail.idktx ChildDescription," &
    '        "   header.ZEIVR Version,DATUV EffectiveDate,DATUB ExpirationDate,detail.MENGE Qty, " &
    '        "(case when (select count(1) from bom_header where bom_header.matnr=detail.idnrk and bom_header.werks = detail.werks ) =0 then 'N' else 'Y' end )Extensible     " &
    '        "   from BOM_DETAIL  detail" &
    '        "   left join BOM_HEADER header on detail.IDNRK = header.MATNR and detail.werks = header.werks " &
    '        "   where detail.STLAL = '01' and detail.MATNR = '{0}' and detail.werks = '{1}'"
    '    querySql = String.Format(querySql, partNo, VbCommClass.VbCommClass.Factory)

    '    Return querySql
    'End Function
    '获取SAP料件信息
    Public Shared Function GetErpFilterSqlSap(partNo As String) As String
        Dim strSQL As String = "declare @sql varchar(max)  exec GetSapBOMSql '{0}', '{1}','{2}','{3}','{4}',@sql output select @sql"
        strSQL = String.Format(strSQL, VbCommClass.VbCommClass.SapServer, VbCommClass.VbCommClass.Factory, partNo, "01", "2")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim querySql As String = ""
        If (dt.Rows.Count > 0) Then
            querySql = dt.Rows(0)(0).ToString
        End If

        Return querySql
    End Function


    Public Shared Function GetErpFilterSql(partNo As String) As String
        Dim querySql As String =
            "SELECT ROW_NUMBER() OVER(ORDER BY A.BMB01) ID,A.BMB01 ParentPartId,A.BMB03 ChildPartId,B.IMA021 ParentFormat,C.IMA021 ChildFormat," &
            "B.IMA02 ParentDescription, C.IMA02 ChildDescription," &
           "DECODE(INSTR(B.IMA021,'-',-1),0,'',SUBSTR(B.IMA021,INSTR(B.IMA021,'-',-1)+1,5)) Version," &
           "A.BMB04 EffectiveDate,A.BMB05 ExpirationDate,DECODE(A.BMB19,3,'Y','N') Extensible,A.BMB06 Qty" &
           " FROM(" &
           "SELECT A.BMB01,A.BMB03,A.BMB19,A.BMB06,TO_CHAR(A.BMB04,'YYYY/MM/DD') BMB04,TO_CHAR(A.BMB05,'YYYY/MM/DD') BMB05 " &
           "FROM " + factoryID + ".BMB_FILE A " &
           "CONNECT BY prior A.BMB03=A.BMB01 AND LEVEL<2" &
           "START WITH A.BMB01 LIKE'" & partNo & "%'" &
            ") A," + factoryID + ".IMA_FILE B, " + factoryID + ".IMA_FILE C " &
           "WHERE A.BMB01=B.IMA01 " &
           "AND A.BMB03=C.IMA01 " &
           "AND A.BMB04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMB05 IS NULL OR A.BMB05>TO_CHAR(SYSDATE,'YYYY/MM/DD'))"
        querySql = querySql + " ORDER BY A.BMB01"
        Return querySql
    End Function

    Public Shared Function GetErpFilterSqlUnion(partNo As String) As String
        'START WITH A.BMB01='" & partNo & "'" &
        'Dim querySql As String =
        '    "SELECT ROW_NUMBER() OVER(ORDER BY A.BMB01) ID,A.BMB01 ParentPartId,A.BMB03 ChildPartId,B.IMA021 ParentFormat,C.IMA021 ChildFormat," &
        '    "B.IMA02 ParentDescription, C.IMA02 ChildDescription," &
        '   "DECODE(INSTR(B.IMA021,'-',-1),0,'',SUBSTR(B.IMA021,INSTR(B.IMA021,'-',-1)+1,5)) Version," &
        '   "A.BMB04 EffectiveDate,A.BMB05 ExpirationDate,DECODE(A.BMB19,3,'Y','N') Extensible,A.BMB06 Qty" &
        '   " FROM(" &
        '   "SELECT A.BMB01,A.BMB03,A.BMB19,A.BMB06,TO_CHAR(A.BMB04,'YYYY/MM/DD') BMB04,TO_CHAR(A.BMB05,'YYYY/MM/DD') BMB05 " &
        '   "FROM " + factoryID + ".BMB_FILE A " &
        '   "CONNECT BY prior A.BMB03=A.BMB01 AND LEVEL<2" &
        '   "START WITH A.BMB01 LIKE'" & partNo & "%'" &
        '    ") A," + factoryID + ".IMA_FILE B, " + factoryID + ".IMA_FILE C " &
        '   "WHERE A.BMB01=B.IMA01 " &
        '   "AND A.BMB03=C.IMA01 " &
        '   "AND A.BMB04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMB05 IS NULL OR A.BMB05>TO_CHAR(SYSDATE,'YYYY/MM/DD'))"
        '' querySql = querySql + " ORDER BY A.BMB01"
        'querySql = querySql + "UNION  SELECT ROW_NUMBER() OVER(ORDER BY A.BMP01) ID,A.BMP01 ParentPartId,A.BMP03 ChildPartId,B.IMA021 ParentFormat,C.IMA021 ChildFormat," & _
        '    " B.IMA02 ParentDescription, C.IMA02 ChildDescription," & _
        '    " DECODE(INSTR(B.IMA021,'-',-1),0,'',SUBSTR(B.IMA021,INSTR(B.IMA021,'-',-1)+1,5)) Version," & _
        '    " A.BMP04 EffectiveDate,A.BMP05 ExpirationDate,DECODE(A.BMP19,3,'Y','N') Extensible,A.BMP06 Qty" & _
        '    " FROM(" & _
        '    " SELECT A.BMp01,A.BMP03,A.BMP19,A.BMP06,TO_CHAR(A.BMP04,'YYYY/MM/DD') BMP04,TO_CHAR(A.BMP05,'YYYY/MM/DD') BMP05 " & _
        '    " FROM " + factoryID + ".Bmp_file A " & _
        '    " CONNECT BY prior A.BMp03=A.BMp01 AND LEVEL<2" & _
        '    " START WITH A.BMp01 LIKE'" & partNo & "%'" & _
        '    " ) A," + factoryID + ".IMA_FILE B, " + factoryID + ".IMA_FILE C " & _
        '    " WHERE A.BMP01=B.IMA01 " & _
        '    " AND A.BMP03=C.IMA01 " & _
        '    " AND A.BMP04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMP05 IS NULL OR A.BMP05>TO_CHAR(SYSDATE,'YYYY/MM/DD')) "
        ''  " ORDER BY A.BMP01"
        '  Return querySql
        Dim querySql As New StringBuilder
        querySql.Append(" WITH s1 as ")
        querySql.Append("(SELECT ROW_NUMBER() OVER(ORDER BY A.BMB01) ID,A.BMB01 ParentPartId,A.BMB03 ChildPartId,B.IMA021 ParentFormat,C.IMA021 ChildFormat,")
        querySql.Append("B.IMA02 ParentDescription, C.IMA02 ChildDescription,DECODE(INSTR(B.IMA021,'-',-1),0,'',SUBSTR(B.IMA021,INSTR(B.IMA021,'-',-1)+1,5)) ")
        querySql.Append(" Version,A.BMB04 EffectiveDate,A.BMB05 ExpirationDate,DECODE(A.BMB19,3,'Y','N') Extensible,")
        querySql.Append(" A.BMB06 Qty FROM(SELECT A.BMB01,A.BMB03,A.BMB19,A.BMB06,TO_CHAR(A.BMB04,'YYYY/MM/DD') BMB04,TO_CHAR(A.BMB05,'YYYY/MM/DD') BMB05")
        querySql.Append(" FROM " + factoryID + ".BMB_FILE A CONNECT BY prior A.BMB03=A.BMB01 AND LEVEL<2 START WITH A.BMB01 LIKE '" & partNo & "%') A," + factoryID + ".IMA_FILE B, " + factoryID + ".IMA_FILE C ")
        querySql.Append(" WHERE A.BMB01=B.IMA01 AND A.BMB03=C.IMA01 AND A.BMB04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMB05 IS NULL OR A.BMB05>TO_CHAR(SYSDATE,'YYYY/MM/DD')) ")
        querySql.Append(" ORDER BY A.BMB01")
        querySql.Append("),")
        querySql.Append(" s2 as ")
        querySql.Append("(SELECT ROW_NUMBER() OVER(ORDER BY A.BMP01) ID,A.BMP01 ParentPartId,A.BMP03 ChildPartId,")
        querySql.Append("B.IMA021 ParentFormat,C.IMA021 ChildFormat, B.IMA02 ParentDescription, C.IMA02 ChildDescription,")
        querySql.Append(" DECODE(INSTR(B.IMA021,'-',-1),0,'',SUBSTR(B.IMA021,INSTR(B.IMA021,'-',-1)+1,5)) Version, A.BMP04 EffectiveDate,A.BMP05 ExpirationDate,")
        querySql.Append(" DECODE(A.BMP19,3,'Y','N') Extensible,A.BMP06 Qty FROM( SELECT A.BMp01,A.BMP03,A.BMP19,A.BMP06,TO_CHAR(A.BMP04,'YYYY/MM/DD')")
        querySql.Append(" BMP04,TO_CHAR(A.BMP05,'YYYY/MM/DD') BMP05  ")
        querySql.Append(" FROM " + factoryID + ".Bmp_file A  CONNECT BY prior A.BMp03=A.BMp01 AND LEVEL<2 START WITH A.BMp01 LIKE '" & partNo & "%' ) A," + factoryID + ".IMA_FILE B, " + factoryID + ".IMA_FILE C ")
        querySql.Append(" WHERE A.BMP01=B.IMA01  AND A.BMP03=C.IMA01  AND A.BMP04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') ")
        querySql.Append(" AND (A.BMP05 IS NULL OR A.BMP05>TO_CHAR(SYSDATE,'YYYY/MM/DD'))")
        querySql.Append(" ORDER BY A.BMP01)")
        querySql.Append(" SELECT * from s1 ")
        querySql.Append(" UNION")
        querySql.Append(" select * from s2")
        Return querySql.ToString
    End Function

    Public Shared Function GetCustIDFromTT(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetCustIDFromTT = ""
        Dim dt As DataTable
        Try
            lsSQL = " SELECT QCD01,TA_QCD09 FROM  " & VbCommClass.VbCommClass.Factory & ".QCD_FILE " & _
                    " WHERE QCD01='" & parPartID & "' AND TA_QCD09 IS NOT NULL AND ROWNUM=1"

            dt = RCardComBusiness.GetDataTableOracle(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetCustIDFromTT = dt.Rows(0).Item("TA_QCD09")
            Else
                GetCustIDFromTT = ""
            End If
            Return GetCustIDFromTT
        Catch ex As Exception
        Finally
            dt = Nothing
        End Try
    End Function

    Public Shared Function GetSerialIDFromTT(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetSerialIDFromTT = ""
        Try
            lsSQL = " SELECT QCD01,TA_QCD10 FROM  " & VbCommClass.VbCommClass.Factory & ".QCD_FILE " & _
                    " WHERE QCD01='" & parPartID & "' AND TA_QCD10 IS NOT NULL AND ROWNUM=1"

            Dim dt As DataTable = RCardComBusiness.GetDataTableOracle(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetSerialIDFromTT = dt.Rows(0).Item("TA_QCD10")
            Else
                GetSerialIDFromTT = ""
            End If
            Return GetSerialIDFromTT
        Catch ex As Exception
        End Try
    End Function

    '先从zzcust_ver 获取版本信息，没有再到描述中查找maktx
    Public Shared Function GetVerFromTiptopSap(partNumber As String) As String
        Dim returnValue As String = ""
        'MAXTX 
        Dim StrSql As String = "select nvl(zzcust_ver,''),maktx from V_BOM_HEADER where matnr = '{0}' and MANDT = '{1}' AND WERKS = '{2}' AND STLAL = '01'"
        StrSql = String.Format(StrSql, partNumber, VbCommClass.VbCommClass.SapServer, VbCommClass.VbCommClass.Factory)
        Dim dt As DataTable = OracleOperateUtils.GetDataTableSap(StrSql)
        If dt.Rows.Count > 0 Then
            Dim zzcust_ver As String = dt.Rows(0)(0)
            Dim maktx = ""
            If zzcust_ver.Trim = "" Then
                maktx = dt.Rows(0)(1)
                Dim index As Integer = maktx.LastIndexOf("-")
                If index >= 0 Then
                    returnValue = maktx.Substring(index + 1, maktx.Length - index - 1)
                Else
                    '无需再截取
                    ' returnValue = ""
                End If
            Else
                returnValue = zzcust_ver
            End If
        End If
        Return returnValue
    End Function

    Public Shared Function GetVerFromTiptop(partNumber As String) As String
        Dim returnValue As String
        Dim StrSql As String = "SELECT NVL(IMA021,IMA02)  FROM " & VbCommClass.VbCommClass.Factory & ".IMA_FILE WHERE IMA01='" & partNumber & "'"

        returnValue = OracleOperateUtils.ExecuteScalar(StrSql)
        If returnValue <> "" Then
            Dim index As Integer = returnValue.LastIndexOf("-")
            If index >= 0 Then
                returnValue = returnValue.Substring(index + 1, returnValue.Length - index - 1)
            Else
                returnValue = ""
            End If
        End If
        Return returnValue
    End Function


    ''' <summary>
    ''' 获取SAP料号表中料号描述
    ''' </summary>
    ''' <param name="part"></param>
    ''' <remarks></remarks>
    Public Shared Function SetPartDescBySap(ByVal part As String) As DataView
        Try
            Dim StrSql As String = "select '' PARTDESC ,maktx as PARTNAME from V_BOM_HEADER where matnr = '{0}' and MANDT = '{1}' AND WERKS = '{2}' AND STLAL = '01'"
            StrSql = String.Format(StrSql, part, VbCommClass.VbCommClass.SapServer, VbCommClass.VbCommClass.Factory)
            Dim dv As DataView = OracleOperateUtils.GetDataTableSap(StrSql).DefaultView
            Return dv
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 获取TTop料号表中料号品名规格
    ''' </summary>
    ''' <param name="part"></param>
    ''' <remarks></remarks>
    Public Shared Function SetPartDescByTiptop(ByVal part As String) As DataView
        Try
            Dim TTopdb As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
            Dim StrSql As String = String.Format("select  IMA02 as PARTNAME ,IMA021 as PARTDESC FROM {0}.ima_file where IMA01='{1}'", VbCommClass.VbCommClass.Factory, part)
            Dim dv As DataView = TTopdb.getDataView(StrSql)

            Return dv
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '增加替代料不显示，条件ALPGR = ' ' or EWAHR > 0
    Public Shared Function GetPartInfoSap(PartID As String, condition As String) As DataView
        Try
            Dim o_strSql As New StringBuilder

            Dim StrSql As String = " select * from (" &
                                    " select idnrk as TAVCPART,idktx as TYPEDEST, '' as DESCRIPTION from V_BOM_DETAIL " &
                                   " where matnr = '{0}' and MANDT = '{1}' AND WERKS = '{2}' AND STLAL = '01' and (ALPGR = ' ' or EWAHR > 0 )  " &
                                   " union select distinct idnrk as TAVCPART,idktx as TYPEDEST, '' as DESCRIPTION  from V_BOM_DETAIL where matnr " &
                                   " in(select idnrk  from V_BOM_DETAIL where matnr ='{0}' and itsob = '50' and MANDT = '{1}' AND WERKS = '{2}' AND STLAL = '01' " &
                                   " and (ALPGR = ' ' or EWAHR > 0 )  )) AA"

            o_strSql.AppendFormat(StrSql, PartID, VbCommClass.VbCommClass.SapServer, VbCommClass.VbCommClass.Factory)

            o_strSql.Append(String.Format(" where TAVCPART NOT LIKE  '%-V2%' ", PartID))
            If Not String.IsNullOrEmpty(condition) Then
                o_strSql.Append(String.Format(" AND ( TAVCPART like'%{0}%' or TYPEDEST like'%{0}%') ", condition.ToUpper))
            End If

            Dim dv As DataView = OracleOperateUtils.GetDataTableSap(o_strSql.ToString).DefaultView
            Return dv
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetPartInfoTitop(PartID As String, condition As String) As DataView
        Try
            Dim _Factory As String
            Dim o_strSql As New StringBuilder
            _Factory = VbCommClass.VbCommClass.Factory

            Dim TTopdb As New OracleDb(VbCommClass.VbCommClass.Factory)  'Tiptop连接对象(Oracle)
            '查询料件资料
            o_strSql.Append("SELECT a.BMB03 as TAVCPART ,B.IMA02 as TYPEDEST,replace(B.IMA021,'""','')as DESCRIPTION  FROM " & _Factory & ".BMB_FILE a left join  ")
            o_strSql.Append("  " & _Factory & ".ima_file b on B.IMA01=a.BMB03 where a.BMB01='" & PartID & "'  AND NVL(a.BMB05,SYSDATE)>=SYSDATE ")
            If Not String.IsNullOrEmpty(condition) Then
                o_strSql.Append(String.Format(" AND ( a.BMB03 like'%{0}%' or B.IMA02 like '%{0}%' or B.IMA021 like '%{0}%') ", condition))
            End If
            Dim dv As DataView = TTopdb.getDataView(o_strSql.ToString)
            Return dv
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '同步工时到SAP
    Public Shared Sub syncTTTimeSap(ByVal PartID As String, ECB03 As String, ECB06 As String, ECB17 As String, hous As Double, ByRef o_strSQL As StringBuilder)
        If hous > 0 Then '01
            o_strSQL.AppendLine(" MERGE INTO ZTPP0001 T1")
            o_strSQL.AppendFormat(" USING (SELECT '{0}' MATNR,'{1}' KTSCH, '{2}' WERKS FROM DUAL) T2", PartID, ECB06, "1021")
            o_strSQL.AppendLine()
            o_strSQL.AppendLine(" ON (T1.MATNR = T2.MATNR AND T1.KTSCH = T2.KTSCH AND T1.WERKS = T2.WERKS)")
            o_strSQL.AppendLine(" WHEN MATCHED THEN")
            o_strSQL.AppendFormat("  UPDATE SET T1.VGW01 = '{0}',TMARK = 'N',TIME=to_char(SYSDATE,'yyyy-mm-dd hh24:mi:ss') ", hous)
            o_strSQL.AppendLine()
            o_strSQL.AppendFormat("    WHERE MATNR='{0}' AND KTSCH='{1}'", PartID, ECB06)
            o_strSQL.AppendLine()
            o_strSQL.AppendLine("  WHEN NOT MATCHED THEN")
            o_strSQL.AppendLine("  INSERT (MATNR,PLNAL,VORNR,KTSCH,") '物料编号,制程编号,制程序号,作业编号
            o_strSQL.Append(" VGW01,") '标准人工生产时间
            o_strSQL.Append(" KTEXT,") '变更来源
            o_strSQL.Append(" WERKS, VERWE, STATU, ARBPL, ") '工厂,用途,状态,工作中心
            o_strSQL.Append(" STEUS,BMSCH,TMARK,TDATE,TIME)") '控制码,基本数量,是否同步,同步时间
            o_strSQL.AppendLine(" VALUES")
            o_strSQL.AppendFormat("  ('{0}', 1, {1},'{2}',", PartID, ECB03, ECB06)
            o_strSQL.Append("  '" & hous & "',")
            o_strSQL.Append("  'MES', ")
            o_strSQL.AppendLine(" '1021', '1', '4','W001','ZLX1','1','N',null,to_char(SYSDATE,'yyyy-mm-dd hh24:mi:ss'));")
            '增加播放到0251厂区数据 BY 田玉琳 20190930 ADD
            o_strSQL.AppendLine(" MERGE INTO ZTPP0001 T1")
            o_strSQL.AppendFormat(" USING (SELECT '{0}' MATNR,'{1}' KTSCH, '{2}' WERKS FROM DUAL) T2", PartID, ECB06, "0251")
            o_strSQL.AppendLine()
            o_strSQL.AppendLine(" ON (T1.MATNR = T2.MATNR AND T1.KTSCH = T2.KTSCH AND T1.WERKS = T2.WERKS)")
            o_strSQL.AppendLine(" WHEN MATCHED THEN")
            o_strSQL.AppendFormat("  UPDATE SET T1.VGW01 = '{0}', tmark = 'N',TIME=to_char(SYSDATE,'yyyy-mm-dd hh24:mi:ss') ", hous)
            o_strSQL.AppendLine()
            o_strSQL.AppendFormat("  WHERE MATNR='{0}' AND KTSCH='{1}'", PartID, ECB06)
            o_strSQL.AppendLine()
            o_strSQL.AppendLine("  WHEN NOT MATCHED THEN")
            o_strSQL.AppendLine("  INSERT (MATNR,PLNAL,VORNR,KTSCH,") '物料编号,制程编号,制程序号,作业编号
            o_strSQL.Append(" VGW01,") '标准人工生产时间
            o_strSQL.Append(" KTEXT,") '变更来源
            o_strSQL.Append(" WERKS, VERWE, STATU, ARBPL, ") '工厂,用途,状态,工作中心
            o_strSQL.Append(" STEUS,BMSCH,TMARK,TDATE,TIME)") '控制码,基本数量,是否同步,同步时间
            o_strSQL.AppendLine(" VALUES")
            o_strSQL.AppendFormat("  ('{0}', 1, {1},'{2}',", PartID, ECB03, ECB06)
            o_strSQL.Append("  '" & hous & "',")
            o_strSQL.Append("  'MES', ")
            o_strSQL.AppendLine(" '0251', '1', '4','W001','ZLX1','1','N',null,to_char(SYSDATE,'yyyy-mm-dd hh24:mi:ss'));")
        Else
            o_strSQL.AppendLine(" UPDATE ZTPP0001  ")
            o_strSQL.AppendLine("SET VGW01=0, KTEXT ='MES',TMARK = 'N',TIME=to_char(SYSDATE,'yyyy-mm-dd hh24:mi:ss') WHERE MATNR='" & PartID & "'")
            o_strSQL.AppendFormat("AND KTSCH='{0}' ;", ECB06)
        End If
    End Sub


    '增加更新标准工时表数据 田玉琳 20190927
    Public Shared Sub syncSTTimeMes(ByVal PartID As String, ECB03 As String, ECB06 As String, ECB17 As String, hous As Double, ByRef o_strSQL As StringBuilder)
        If hous > 0 Then '
            o_strSQL.AppendFormat(" IF NOT EXISTS(SELECT 1 FROM m_TiptopStandardHours_t WHERE ECB01 = '{0}'AND ECB06 = '{1}' )", PartID, ECB06)
            o_strSQL.AppendLine()
            o_strSQL.AppendLine(" BEGIN INSERT INTO m_TiptopStandardHours_t(ECB01,ECB03,ECB06,ECB17,ECB38,ECB15,ECB19,ECBDATE,CreateUserId,CreateTime)")
            o_strSQL.AppendFormat(" SELECT N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',getdate(),N'{7}',getdate() END",
                                  PartID, ECB03, ECB06, ECB17, "0", "0", hous, VbCommClass.VbCommClass.UseId)
            o_strSQL.AppendLine()
            o_strSQL.AppendLine(" ELSE BEGIN")
            o_strSQL.AppendFormat(" UPDATE m_TiptopStandardHours_t SET ECB19 = '{2}',ECBDATE = GETDATE() WHERE ECB01 = '{0}'AND ECB06 = '{1}' ",
                                PartID, ECB06, hous)
            o_strSQL.AppendLine(" END")
            o_strSQL.AppendLine()
        Else
            o_strSQL.AppendLine()
            o_strSQL.AppendFormat(" UPDATE m_TiptopStandardHours_t SET ECB19 = '{2}',ECBDATE = GETDATE() WHERE ECB01 = '{0}'AND ECB06 = '{1}' ",
                                PartID, ECB06, hous)
            o_strSQL.AppendLine()
        End If
    End Sub




    'Public Shared Function GetErpFilterSetPNSql(partNo As String) As String
    '    'remove AND A.BMB03 LIKE'" & partNo & "%', cq 20160825
    '    Dim querySql As String =
    '        "SELECT ROW_NUMBER() OVER(ORDER BY A.BMB01) ID,A.BMB01 ParentPartId,A.BMB03 ChildPartId,B.IMA021 ParentFormat,C.IMA021 ChildFormat," &
    '        "B.IMA02 ParentDescription, C.IMA02 ChildDescription," &
    '       "DECODE(INSTR(C.IMA021,'-',-1),0,'',SUBSTR(C.IMA021,INSTR(C.IMA021,'-',-1)+1,5)) Version," &
    '       "A.BMB04 EffectiveDate,A.BMB05 ExpirationDate,DECODE(A.BMB19,3,'Y','N') Extensible,A.BMB06 Qty" &
    '       " FROM(" &
    '       "SELECT A.BMB01,A.BMB03,A.BMB19,A.BMB06,TO_CHAR(A.BMB04,'YYYY/MM/DD') BMB04,TO_CHAR(A.BMB05,'YYYY/MM/DD') BMB05 " &
    '       "FROM " + factoryID + ".BMB_FILE A " &
    '       "CONNECT BY prior A.BMB03=A.BMB01 AND LEVEL<2" &
    '       "START WITH A.BMB01 LIKE'" & partNo & "%'" &
    '        ") A," + factoryID + ".IMA_FILE B, " + factoryID + ".IMA_FILE C " &
    '       "WHERE A.BMB01=B.IMA01 " &
    '       "AND A.BMB03=C.IMA01 " &
    '       "AND A.BMB04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMB05 IS NULL OR A.BMB05>TO_CHAR(SYSDATE,'YYYY/MM/DD'))" & _
    '       "AND  A.BMB01='" & partNo & "' "
    '    querySql = querySql + " ORDER BY A.BMB01"

    '    Return querySql
    'End Function


End Class
