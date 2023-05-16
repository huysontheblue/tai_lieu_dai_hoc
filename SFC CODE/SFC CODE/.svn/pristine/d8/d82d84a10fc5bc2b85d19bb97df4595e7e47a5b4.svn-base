Imports MainFrame.SysCheckData
Imports System.Text
Imports SysBasicClass
Imports MainFrame

''' <summary>
''' 创建者：田玉琳
''' 创建日期：20190516
''' 内容：SAP关联查询共通化
''' 工单下载 共通
''' </summary>
''' <remarks></remarks>
''' 
Public Class SapCommon

    'Private Shared VbCommClass.VbCommClass.Factory As String = VbCommClass.VbCommClass.Factory
    'Private Shared VbCommClass.VbCommClass.profitcenter As String = VbCommClass.VbCommClass.profitcenter
    Private Shared userID As String = VbCommClass.VbCommClass.UseId


    Public Shared Function GetCustIDFromTT(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetCustIDFromTT = ""
        Try
            lsSQL = " SELECT QCD01,TA_QCD09 FROM  " & VbCommClass.VbCommClass.Factory & ".QCD_FILE " & _
                    " WHERE QCD01='" & parPartID & "' AND TA_QCD09 IS NOT NULL AND ROWNUM=1"

            Dim dt As DataTable = MoComDB.GetErpData(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetCustIDFromTT = dt.Rows(0).Item("TA_QCD09")
            Else
                GetCustIDFromTT = ""
            End If
            Return GetCustIDFromTT
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function GetSeriesIDFromTT(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetSeriesIDFromTT = ""
        Try
            lsSQL = " SELECT QCD01,TA_QCD10 FROM  " & VbCommClass.VbCommClass.Factory & ".QCD_FILE " & _
                    " WHERE QCD01='" & parPartID & "' AND TA_QCD10 IS NOT NULL AND ROWNUM=1"

            Dim dt As DataTable = MoComDB.GetErpData(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetSeriesIDFromTT = dt.Rows(0).Item("TA_QCD10")
            Else
                GetSeriesIDFromTT = ""
            End If
            Return GetSeriesIDFromTT
        Catch ex As Exception
        End Try
    End Function

    'AmountQty
    Public Shared Function GetAmountQtyFromTT(ByVal parParentPartID As String, ByVal parChildPN As String) As Integer
        Dim lsSQL As String = ""
        GetAmountQtyFromTT = 1
        Try
            lsSQL = " SELECT BMB06 FROM  " & VbCommClass.VbCommClass.Factory & ".BMB_FILE " & _
                    " WHERE BMB01='" & parParentPartID & "' AND BMB03 ='" & parChildPN & "'  ORDER BY BMB02 DESC "
            Dim dt As DataTable = MoComDB.GetErpData(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetAmountQtyFromTT = dt.Rows(0).Item(0)
            Else
                GetAmountQtyFromTT = 1
            End If
            Return GetAmountQtyFromTT
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function GetErpFilterSql(partNo As String) As String
        Dim querySql As String =
            "SELECT ROW_NUMBER() OVER(ORDER BY A.BMB01) ID,A.BMB01 ParentPartId,A.BMB03 ChildPartId,B.IMA021 ParentFormat,C.IMA021 ChildFormat," &
            "B.IMA02 ParentDescription, C.IMA02 ChildDescription," &
           "DECODE(INSTR(B.IMA021,'-',-1),0,'',SUBSTR(B.IMA021,INSTR(B.IMA021,'-',-1)+1,5)) Version," &
           "A.BMB04 EffectiveDate,A.BMB05 ExpirationDate,DECODE(A.BMB19,3,'Y','N') Extensible,A.BMB06 Qty" &
           " FROM(" &
           "SELECT A.BMB01,A.BMB03,A.BMB19,A.BMB06,TO_CHAR(A.BMB04,'YYYY/MM/DD') BMB04,TO_CHAR(A.BMB05,'YYYY/MM/DD') BMB05 " &
           "FROM " + VbCommClass.VbCommClass.Factory + ".BMB_FILE A " &
           "CONNECT BY prior A.BMB03=A.BMB01 AND LEVEL<2" &
           "START WITH A.BMB01='" & partNo & "'" &
            ") A," + VbCommClass.VbCommClass.Factory + ".IMA_FILE B, " + VbCommClass.VbCommClass.Factory + ".IMA_FILE C " &
           "WHERE A.BMB01=B.IMA01 " &
           "AND A.BMB03=C.IMA01 " &
           "AND A.BMB04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMB05 IS NULL OR A.BMB05>TO_CHAR(SYSDATE,'YYYY/MM/DD'))"
        '") A," + companyCode + ".IMA_FILE B," + companyCode + ".sfb_file " & _
        'If (String.IsNullOrEmpty(profitCenter)) = False Then
        '    querySql = querySql + " and sfbbu = '" + profitCenter + "'"
        'End If

        querySql = querySql + " ORDER BY A.BMB01"

        Return querySql
    End Function

    Public Shared Function GetSql2Erp(TxtMoNo As String, ByVal strProfitCenter As String) As String
        Dim sql As String = "", strFactory As String = VbCommClass.VbCommClass.Factory
        If VbCommClass.VbCommClass.Factory = "BZLANTO" Then
            strProfitCenter = ""
        End If
        Dim mos As String = Nothing
        For Each sMO As String In TxtMoNo.Trim.Split(vbNewLine)
            If Not String.IsNullOrEmpty(sMO) Then
                mos &= "'" & sMO.ToUpper.Trim & "'" & ","
            End If
        Next
        If Not String.IsNullOrEmpty(mos) Then mos = mos.Trim(",")

        If String.IsNullOrEmpty(strProfitCenter) Then
            sql = "SELECT DISTINCT SFB01,SFB05,IMA02 PARTNAME,SFB22,SFB221,'' CUSTOR, TC_IMC03,SFB82,SFB08,SFB02,SFB04,IMA021,OEB15,SFB15,OEA10 " & _
            " FROM  " & strFactory & ".SFB_FILE," & strFactory & ".TC_IMC_FILE," & strFactory & ".IMA_FILE," & strFactory & ".OEB_FILE," & strFactory & ".OEA_FILE " & _
            " WHERE SFB82=TC_IMC01 AND SFB05=IMA01 " & _
            " AND SFB22 = OEB01(+) AND SFB221=OEB03(+) " & _
            " AND SFB22=OEA01(+)" & _
            " AND UPPER(SFB01) IN(" & mos & ")  AND SFB87 = 'Y' "
        Else
            sql = " SELECT DISTINCT SFB01,SFB05,IMA02 PARTNAME,SFB22,SFB221,'' CUSTOR, TC_IMC03,SFB82,SFB08,SFB02,SFB04,IMA021,OEB15,SFB15,OEA10 " & _
                  " FROM " & strFactory & ".SFB_FILE," & strFactory & ".TC_IMC_FILE," & strFactory & ".IMA_FILE," & strFactory & ".OEB_FILE," & strFactory & ".OEA_FILE " & _
                  " WHERE SFB82=TC_IMC01 AND SFB05=IMA01 " & _
                  " AND SFB22 = OEB01(+) AND SFB221=OEB03(+) " & _
                  " AND SFB22=OEA01(+)" & _
                  " AND UPPER(SFB01) IN(" & mos & ") " & _
                  " AND SFB87 = 'Y' AND SFBBU = '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If

        Return sql
    End Function

    Public Shared Function GetSql2ErpSap(TxtMoNo As String, ByVal strProfitCenter As String) As String
        Dim sql As String = "", strFactory As String = VbCommClass.VbCommClass.Factory
        If VbCommClass.VbCommClass.Factory = "BZLANTO" Then
            strProfitCenter = ""
        End If
        Dim mos As String = Nothing
        For Each sMO As String In TxtMoNo.Trim.Split(vbNewLine)
            If Not String.IsNullOrEmpty(sMO) Then
                mos &= "'" & sMO.ToUpper.Trim & "'" & ","
            End If
        Next
        If Not String.IsNullOrEmpty(mos) Then mos = mos.Trim(",")

        'sql = "SELECT DISTINCT AUFNR AS SFB01, MATNR AS SFB05,'' AS PARTNAME,ZZVBELN AS SFB22,ZZPOSNR AS SFB221,'' CUSTOR, BUM AS TC_IMC03,ZZLINE AS SFB82," &
        '      "GAMNG AS SFB08,  (CASE AUART WHEN 'ZP01' THEN 1 WHEN 'ZP02' THEN 15 WHEN 'ZP03' THEN 5 WHEN 'ZP04' THEN 7  WHEN 'ZP05' THEN 8 ELSE 1 END) sfb02," &
        '      "'' AS SFB04,ZZZEIVR AS IMA021,'' AS OEB15,'' AS SFB15,ZZBSTKD AS OEA10,werks " &
        '      " FROM  ZTPP0017 " &
        '      " WHERE AUFNR IN(" & mos & ") "
        'and werks = '" & VbCommClass.VbCommClass.Factory & "'

        sql = "SELECT TOP 1  AUFNR AS SFB01, PLNBEZ AS SFB05,'' AS PARTNAME,'' AS SFB22,GSUZP AS SFB221,''AS CUSTOR,BUM AS TC_IMC03,ZZLINE AS SFB82," &
        "CAST(GAMNG AS INT) AS SFB08,  (CASE AUART WHEN 'ZP01' THEN 1 WHEN 'ZP02' THEN 15 WHEN 'ZP03' THEN 5 WHEN 'ZP04' THEN 7  WHEN 'ZP05' THEN 8 ELSE 1 END) SFB02," &
        "'' AS SFB04,ZZZEIVR AS IMA021,'' AS OEB15,'' AS SFB15,ZZBSTKD AS OEA10,WERKS   FROM  SAPDB.MESDBZJ.dbo.orderheaderHeads  WHERE AUFNR IN(" & mos & ")ORDER BY ID DESC"
        Return sql
    End Function

    Public Shared Function GetSql(ByVal rpn As String) As String
        'ID,ParentPartId,ChildPartId,Version,Format,CFormat,ParentDescription,ChildDescription,EffectiveDate,ExpirationDate,Extensible,Qty
        Dim sql As String = "SELECT ROW_NUMBER() OVER(ORDER BY A.BMB01) ID,A.BMB01 ParentPN,A.BMB03 PN," & _
                            " DECODE(INSTR(B.IMA021,'-',-1),0,'',SUBSTR(B.IMA021,INSTR(B.IMA021,'-',-1)+1,5)) Verson ," & _
                            " B.IMA021 ParentFormat,C.IMA021 Format,B.IMA02 ParentDes,C.IMA02 Des," & _
                            " A.BMB04 as 生效日期,A.BMB05 失效日期 ,DECODE(A.BMB19,3,'Y','N') EXTENSIABLE,A.BMB06 as 配置数" & _
        " FROM(" & _
        "SELECT A.BMB01,A.BMB03,A.BMB19,A.BMB06,TO_CHAR(A.BMB04,'YYYY/MM/DD') BMB04,TO_CHAR(A.BMB05,'YYYY/MM/DD') BMB05 " & _
        "FROM " & VbCommClass.VbCommClass.Factory & ".BMB_FILE A " & _
        "CONNECT BY prior A.BMB03=A.BMB01 AND LEVEL<=1" & _
        "START WITH A.BMB01='" & rpn & "') A," & VbCommClass.VbCommClass.Factory & ".IMA_FILE B," & VbCommClass.VbCommClass.Factory & ".IMA_FILE C " & _
        "WHERE A.BMB01=B.IMA01 " & _
        "AND A.BMB03=C.IMA01 " & _
        "AND A.BMB04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMB05 IS NULL OR A.BMB05>TO_CHAR(SYSDATE,'YYYY/MM/DD'))"
        Return sql
    End Function


    ''' <summary>
    ''' 单独支持流程卡和裁线卡的工单下载
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSql2ErpRCard(ByVal TxtMoNo As String) As String
        Dim sql As String = "", strFactory As String = VbCommClass.VbCommClass.Factory
        Dim mos As String = Nothing
        For Each sMO As String In TxtMoNo.Trim.Split(CChar(vbNewLine))
            If Not String.IsNullOrEmpty(sMO) Then
                mos &= "'" & sMO.ToUpper.Trim & "'" & ","
            End If
        Next
        If Not String.IsNullOrEmpty(mos) Then mos = mos.Trim(CChar(","))

        If String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter) Then 'cq20160908, add right join for no line mo
            sql = "SELECT DISTINCT SFB01,SFB05,IMA02 PARTNAME,SFB22,SFB221,'' CUSTOR, TC_IMC03,SFB82,SFB08,SFB02,SFB04,IMA021,OEB15,SFB15 " & _
            " FROM  " & strFactory & ".SFB_FILE," & strFactory & ".TC_IMC_FILE," & strFactory & ".IMA_FILE," & strFactory & ".OEB_FILE" & _
            " WHERE SFB82=TC_IMC01(+) AND SFB05=IMA01 " & _
            " AND SFB22 = OEB01(+) AND SFB221=OEB03(+) " & _
            " AND UPPER(SFB01) IN(" & mos & ")  AND SFB87 = 'Y' "
        Else

            sql = " SELECT DISTINCT SFB01,SFB05,IMA02 PARTNAME,SFB22,SFB221,'' CUSTOR, TC_IMC03,SFB82,SFB08,SFB02,SFB04,IMA021,OEB15,SFB15 " & _
                  " FROM " & strFactory & ".SFB_FILE," & strFactory & ".TC_IMC_FILE," & strFactory & ".IMA_FILE," & strFactory & ".OEB_FILE" & _
                  " WHERE SFB82=TC_IMC01(+) AND SFB05=IMA01 " & _
                  " AND SFB22 = OEB01(+) AND SFB221=OEB03(+) " & _
                  " AND UPPER(SFB01) IN(" & mos & ") " & _
                  " AND SFB87 = 'Y' "
            'AND SFBBU = '" & VbCommClass.VbCommClass.profitcenter & "'  -- mark by cq 20180518, For support case LXXT.SEE-HW MO send to LXXN MADE.
        End If

        Return sql
    End Function

#Region "检查TIPTOP的版本"


    Public Shared Function GetPnByInputMoSql(ByVal pn As String) As String
        Return "SELECT IMA01 PN,IMA021 VERSION FROM " & VbCommClass.VbCommClass.Factory & ".IMA_FILE WHERE IMA01='" & pn & "'"  'cq, 20150907,add lxxt
    End Function

    Public Shared Function GetVerFromTiptop(partNumber As String) As String
        Dim returnValue As String
        Dim StrSql As String = "SELECT NVL(IMA021,IMA02)  FROM " & VbCommClass.VbCommClass.Factory & ".IMA_FILE WHERE IMA01='" & partNumber & "'"

        returnValue = MoComDB.ExecuteScalarOracle(StrSql).ToString()

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


    Public Shared Function GetTTCustVer(ParentMoID As String) As String
        Dim returnValue As String = ""
        Dim StrSql As String = "SELECT sfbud27 CustVer  from " & VbCommClass.VbCommClass.Factory & ".sfb_file WHERE sfb01='" & ParentMoID & "'"

        returnValue = MoComDB.ExecuteScalarOracle(StrSql).ToString()
        Return returnValue
    End Function

    Public Shared Function GetTTPartVer(ParentMoID As String) As String
        Dim returnValue As String = ""
        Dim StrSql As String = "SELECT NVL(IMA021,IMA02) FROM " & VbCommClass.VbCommClass.Factory & ".IMA_FILE ," & VbCommClass.VbCommClass.Factory & ".sfb_file WHERE  sfb05=ima01 AND sfb01='" & ParentMoID & "'"

        returnValue = MoComDB.ExecuteScalarOracle(StrSql).ToString()
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

    Public Shared Function GetTTPartVerSap(ParentMoID As String) As String
        Dim returnValue As String = ""
        Dim StrSql As String = "select NVL(ZTPP0017.ZZCUST_VER,V_BOM_HEADER.maktx) from ZTPP0017,V_BOM_HEADER " &
       " where ZTPP0017.MATNR = V_BOM_HEADER.MATNR And ZTPP0017.werks = V_BOM_HEADER.werks and  aufnr= '{0}' and ZTPP0017.werks  = '{1}'"
        StrSql = String.Format(StrSql, ParentMoID, VbCommClass.VbCommClass.Factory)

        returnValue = MoComDB.ExecuteScalarOracle(StrSql).ToString()
        If returnValue <> "" Then
            Dim index As Integer = returnValue.LastIndexOf("-")
            If index >= 0 Then
                returnValue = returnValue.Substring(index + 1, returnValue.Length - index - 1)
            Else
                ' returnValue = ""
            End If
        End If
        Return returnValue
    End Function


#End Region

    ''' <summary>
    ''' 更新TT时间
    ''' </summary>
    ''' <param name="m_Assort"></param>
    ''' <param name="PartID"></param>
    ''' <remarks></remarks>
    Public Shared Sub AutoUploadTimeToTiptop(m_Assort As String, ByVal PartID As String)
        Dim o_strSQL As StringBuilder = Nothing
        Dim o_CreateUserID As String = VbCommClass.VbCommClass.UseId
        Dim o_ModifyUserID As String = VbCommClass.VbCommClass.UseId
        Try
            o_strSQL = New StringBuilder
            o_strSQL.Append("BEGIN")


            '01, 
            'o_strSQL.Append(" MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
            'o_strSQL.Append(" USING (SELECT '" & PartID & "' ECB01,'01' ecb06 FROM DUAL) T2")
            'o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
            'o_strSQL.Append(" WHEN MATCHED THEN")
            'o_strSQL.Append(" UPDATE SET T1.ECB19 = '0'")
            'o_strSQL.Append("  WHERE ECB01='" & PartID & "' AND ECB06='01';")

            '02
            'o_strSQL.Append(" MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
            'o_strSQL.Append(" USING (SELECT '" & PartID & "' ECB01,'02' ecb06 FROM DUAL) T2")
            'o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
            'o_strSQL.Append(" WHEN MATCHED THEN")
            'o_strSQL.Append(" UPDATE SET T1.ECB19 = '0'")
            'o_strSQL.Append("  WHERE ECB01='" & PartID & "' AND ECB06='02';")

            '03
            'o_strSQL.Append(" MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
            'o_strSQL.Append(" USING (SELECT '" & PartID & "' ECB01,'03' ecb06 FROM DUAL) T2")
            'o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
            'o_strSQL.Append(" WHEN MATCHED THEN")
            'o_strSQL.Append(" UPDATE SET T1.ECB19 = '0'")
            'o_strSQL.Append("  WHERE ECB01='" & PartID & "' AND ECB06='03';")

            '04
            'o_strSQL.Append(" MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
            'o_strSQL.Append(" USING (SELECT '" & PartID & "' ECB01,'04' ecb06 FROM DUAL) T2")
            'o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
            'o_strSQL.Append(" WHEN MATCHED THEN")
            'o_strSQL.Append(" UPDATE SET T1.ECB19 = '0'")
            'o_strSQL.Append("  WHERE ECB01='" & PartID & "' AND ECB06='04';")

            'A05
            'o_strSQL.Append(" MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
            'o_strSQL.Append(" USING (SELECT '" & PartID & "' ECB01,'A05' ECB06 FROM DUAL) T2")
            'o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND T1.ECB06 = T2.ECB06) ")
            'o_strSQL.Append(" WHEN MATCHED THEN")
            'o_strSQL.Append(" UPDATE SET T1.ECB19 = '0'")
            'o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='A05';")

            If Val(m_Assort) > 0 Then
                o_strSQL.Append(" MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECB_FILE T1")
                o_strSQL.Append(" USING (SELECT '" & PartID & "' ECB01,'09' ECB06 FROM DUAL) T2")
                o_strSQL.Append(" ON (T1.ECB01 = T2.ECB01 AND  T1.ECB06 = T2.ECB06) ")
                o_strSQL.Append(" WHEN MATCHED THEN")
                o_strSQL.Append(" UPDATE SET T1.ECB19 = '" & CStr(Val(m_Assort)) & "'")
                o_strSQL.Append("    WHERE ECB01='" & PartID & "' AND  ECB06='09'")
                o_strSQL.Append("  WHEN NOT MATCHED THEN")
                o_strSQL.Append(" INSERT (ECB01,ECB02,ECB03,ECB04,ECB06,")
                o_strSQL.Append(" ECB08,ECB15, ECB17, ECB18, ECB19,")
                o_strSQL.Append(" ECB20, ECB21, ECB34, ECB38, ECB39,")
                o_strSQL.Append(" ECB40, ECB41, ECB44, ECB45, ECB46,")
                o_strSQL.Append(" ECBACTI, ECBDATE, ECBUD01, ECBUD02, ECBUD08,ECBUD13)")
                o_strSQL.Append(" VALUES")
                o_strSQL.Append("  ('" & PartID & "', 1, 9,0,'09',")
                o_strSQL.Append("  '0', 0,N'配套',0,'" & CStr(Val(m_Assort)) & "',")
                o_strSQL.Append("  '0', 0, 0,0,'N',")
                o_strSQL.Append("  'N', 'N', 'PCS', 'PCS', 1,")
                o_strSQL.Append("  'Y', SYSDATE, '0', 'MES', 0,SYSDATE);")
            Else
                o_strSQL.Append(" UPDATE  " & VbCommClass.VbCommClass.Factory & ".ECB_FILE  ")
                o_strSQL.Append("SET ECB19=0, ECBUD13 = SYSDATE, ECBUD02 ='MES' WHERE ECB01='" & PartID & "'")
                o_strSQL.Append("AND  ECB06='09' ;")
            End If

            o_strSQL.Append(" MERGE INTO " & VbCommClass.VbCommClass.Factory & ".ECU_FILE T1")
            o_strSQL.Append(" USING (SELECT '" & PartID & "' ECU01 FROM DUAL) T2")
            o_strSQL.Append(" ON (T1.ECU01 = T2.ECU01) ")
            o_strSQL.Append("  WHEN  MATCHED THEN")
            o_strSQL.Append("  UPDATE SET T1.ECUMODU = '" & o_ModifyUserID & "',T1.ECUDATE = SYSDATE")
            o_strSQL.Append("    WHERE ECU01='" & PartID & "'")
            o_strSQL.Append("  WHEN NOT MATCHED THEN")
            o_strSQL.Append(" INSERT (ECU01, ECU02, ECU04, ECU05, ECUACTI, ")
            o_strSQL.Append(" ECUUSER, ECUGRUP, ECUMODU, ECUDATE, ECU10, ")
            o_strSQL.Append(" ECU11)")
            o_strSQL.Append(" VALUES")
            o_strSQL.Append("  ('" & PartID & "','1', 10, 30,'Y',")
            o_strSQL.Append(("  '" & o_CreateUserID & "','P17234',NULL,SYSDATE, "))
            o_strSQL.Append(" 'Y', 0);")
            o_strSQL.Append("COMMIT;")
            o_strSQL.Append(" END;")
            MoComDB.Oracle_ExecuteNonQuery(o_strSQL.ToString)

            ' MessageUtils.ShowInformation("同步工时到Tiptop成功！")
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmShowRunCardDetail", "AutoUploadTimeToTiptop", "RCard")
            Throw ex
        Finally
        End Try
    End Sub


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


End Class
