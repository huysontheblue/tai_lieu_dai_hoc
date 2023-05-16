Imports SysBasicClass
Imports MainFrame

''' <summary>
''' 创建者：田玉琳
''' 创建日期：20190516
''' 内容：SAP关联查询共通化
''' </summary>
''' <remarks></remarks>
Public Class SapCommon

    Public Shared Function GetErpFilterSql(companyCode As String, profitCenter As String, partNo As String) As String
        Dim querySql As String =
            "SELECT ROW_NUMBER() OVER(ORDER BY A.BMB01) ID,A.BMB01 ParentPartId,A.BMB03 ChildPartId,B.IMA021 ParentFormat,C.IMA021 ChildFormat," &
            "B.IMA02 ParentDescription, C.IMA02 ChildDescription," &
           "DECODE(INSTR(B.IMA021,'-',-1),0,'',SUBSTR(B.IMA021,INSTR(B.IMA021,'-',-1)+1,5)) Version," &
           "A.BMB04 EffectiveDate,A.BMB05 ExpirationDate,DECODE(A.BMB19,3,'Y','N') Extensible,A.BMB06 Qty" &
           " FROM(" &
           "SELECT A.BMB01,A.BMB03,A.BMB19,A.BMB06,TO_CHAR(A.BMB04,'YYYY/MM/DD') BMB04,TO_CHAR(A.BMB05,'YYYY/MM/DD') BMB05 " &
           "FROM " + companyCode + ".BMB_FILE A " &
           "CONNECT BY prior A.BMB03=A.BMB01 AND LEVEL<2" &
           "START WITH A.BMB01 like'" & partNo & "%'" &
            ") A," + companyCode + ".IMA_FILE B, " + companyCode + ".IMA_FILE C " &
           "WHERE A.BMB01=B.IMA01 " &
           "AND A.BMB03=C.IMA01 " &
           "AND A.BMB04<=TO_CHAR(SYSDATE,'YYYY/MM/DD') AND (A.BMB05 IS NULL OR A.BMB05>TO_CHAR(SYSDATE,'YYYY/MM/DD'))"
        querySql = querySql + " ORDER BY A.BMB01"

        Return querySql
    End Function

    Public Shared Function GetCustIDFormTT(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetCustIDFormTT = ""
        Try
            lsSQL = " SELECT qcd01,TA_QCD09 from  " & VbCommClass.VbCommClass.Factory & ".qcd_file " & _
                    " WHERE qcd01='" & parPartID & "' AND TA_QCD09 IS NOT NULL AND ROWNUM=1"

            Dim dt As DataTable = OracleOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetCustIDFormTT = dt.Rows(0).Item("TA_QCD09")
            Else
                GetCustIDFormTT = ""
            End If
            Return GetCustIDFormTT
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function GetSerialFormTT(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetSerialFormTT = ""
        Try
            lsSQL = " SELECT qcd01,TA_QCD10 FROM  " & VbCommClass.VbCommClass.Factory & ".qcd_file " & _
                    " WHERE qcd01='" & parPartID & "' AND TA_QCD10 IS NOT NULL AND ROWNUM=1"

            Dim dt As DataTable = OracleOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetSerialFormTT = dt.Rows(0).Item("TA_QCD10")
            Else
                GetSerialFormTT = ""
            End If
            Return GetSerialFormTT
        Catch ex As Exception
        End Try

    End Function

    ''应该是没有使用
    Public Shared Function GetCheckTiptopOrderSQL(ByVal strFactory As String, ByVal strProfitcenter As String, ByVal strContractOrder As String) As String
        Dim strSQL As String

        strSQL = "SELECT OEA01 AS OrderNO, OEA04 AS DeliveryCustomerId, OCC02 AS DeliveryCustomerName, OEA06 AS ModifiedVersion, OEA02 AS ContractDate, OEA10 AS CustomerOrderNO, OEAUD10 AS TerminalCustomerOrderNO, '' AS CreateUserId, '' AS CreateTime, '' AS ModifyUserId, '' AS ModifyTime " & _
                 "FROM " & strFactory & ".OEA_FILE INNER JOIN " & strFactory & ".OCC_FILE ON OCC_FILE.OCC01=OEA_FILE.OEA04 WHERE OEA01 = '" & strContractOrder & "'"

        If (Not String.IsNullOrEmpty(strProfitcenter)) Then
            strSQL = strSQL + " AND OEABU = '" + strProfitcenter + "'"
        End If
        Return strSQL
    End Function

    ''应该是没有使用
    Public Shared Function GetCheckTiptopOrderItemSQL(ByVal strFactory As String, ByVal strProfitcenter As String, ByVal strContractOrder As String) As String
        Dim strSQL As String

        strSQL = "SELECT OEB03 AS ItemNO, OEB04 AS PartId, OEB11 AS CustomerPartId, OEB06 AS ProductSpecifications, OEB12 AS Quantity, OEB05 AS Unit, '' AS TitleMini FROM " & strFactory & ".OEB_FILE WHERE OEB01 = '" & strContractOrder & "'"
        Return strSQL
    End Function



End Class
