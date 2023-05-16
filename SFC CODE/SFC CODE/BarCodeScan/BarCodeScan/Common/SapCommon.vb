Imports SysBasicClass
''' <summary>
''' 创建者：田玉琳
''' 创建日期：20190516
''' 内容：SAP关联查询共通化
''' </summary>
''' <remarks></remarks>
''' 
Public Class SapCommon

    Private Shared Factory As String = VbCommClass.VbCommClass.Factory

    Public Shared Function GetTiptopLot(moid As String) As DataTable
        Return OracleOperateUtils.GetDataTable(GetErpMoSql(VbCommClass.VbCommClass.Factory, moid, VbCommClass.VbCommClass.profitcenter))
    End Function

    Public Shared Function GetTiptopLotSAP(moid As String) As DataTable
        Return OracleOperateUtils.getDataViewSap(GetCheckTiptopLotSQLSAP(moid)).Table
    End Function

    Public Shared Function GetCheckTiptopLotSQLSAP(ByVal LotName As String) As String
        Dim Sql As String
        Sql = " SELECT AUFNR as sfb01, MATNR as sfb05,'' partDesc,ZZVBELN as sfb22,ZZPOSNR as sfb221,'' custor, BUM as tc_imc03,ZZLINE as sfb82,GAMNG as sfb08," &
              "  (CASE AUART WHEN 'ZP01' THEN 1 WHEN 'ZP02' THEN 15 WHEN 'ZP03' THEN 3 WHEN 'ZP04' THEN 7  WHEN 'ZP05' THEN 8 ELSE 1 END) sfb02,'' AS sfb04," &
              " to_date(ERDAT,'yyyy-mm-dd') as sfb81, ZZBSTKD AS OEA10, '' OEB15,'' SFB15 " &
              " FROM  ZTPP0017  WHERE AUFNR='" + LotName + "' and werks = '" & Factory & "' "
        Return Sql
    End Function

    Public Shared Function GetErpMoSql()
        Dim sql As String = Nothing
        If String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter) Then

            sql = "SELECT DISTINCT SFB01,SFB05,IMA02 PARTNAME,SFB22,SFB221,'' CUSTOR, TC_IMC03,SFB82,SFB08,SFB02,SFB04,IMA021,OEB15,SFB15,OEA10 " & _
            " FROM {0}.SFB_FILE, {0}.TC_IMC_FILE, {0}.IMA_FILE, {0}.OEB_FILE, {0}.OEA_FILE " & _
            " WHERE SFB82 = TC_IMC01 And SFB05 = IMA01" & _
             " AND SFB22 = OEB01(+) AND SFB221=OEB03(+)" & _
             " AND SFB22=OEA01(+)" & _
             " AND UPPER(SFB01) IN('{1}')  AND SFB87 = 'Y'"
        Else

            sql = " SELECT DISTINCT SFB01,SFB05,IMA02 PARTNAME,SFB22,SFB221,'' CUSTOR, TC_IMC03,SFB82,SFB08,SFB02,SFB04,IMA021,OEB15,SFB15,OEA10 " & _
            "FROM {0}.SFB_FILE, {0}.TC_IMC_FILE, {0}.IMA_FILE, {0}.OEB_FILE, {0}.OEA_FILE" & _
            " WHERE SFB82 = TC_IMC01 And SFB05 = IMA01" & _
                  " AND SFB22 = OEB01(+) AND SFB221=OEB03(+) " & _
                  " AND SFB22=OEA01(+)" & _
                  " AND UPPER(SFB01) IN('{1}') " & _
                  " AND SFB87 = 'Y' AND SFBBU = '{2}'"
        End If
        Return sql
    End Function


End Class
