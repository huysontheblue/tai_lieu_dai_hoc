Imports SysBasicClass
Imports Aspose.Cells
Imports MainFrame
Imports MainFrame.SysCheckData
'Imports SysBasicClass
Imports RCard.RunCardBusiness
Imports VbCommClass

Public Class MOComBusiness
    'Private Shared NewFactory As String = VbCommClass.VbCommClass.Factory
    'Private Shared Newprofitcenter As String = VbCommClass.VbCommClass.profitcenter
    Private Shared userID As String = VbCommClass.VbCommClass.UseId
    Public Structure stcMO
        Public MOID As String
        Public PartID As String
        Public LineID As String
        Public MOQty As String
        Public ParentMo As String
    End Structure
    Public Enum BomInfo
        ID = 0
        ParentPartId
        ChildPartId
        Version
        ParentFormat
        ChildFormat
        ParentDescription
        ChildDescription
        EffectiveDate
        ExpirationDate
        Extensible
        ExtensibleF
        Qty
        CustID
        SeriesID
    End Enum


    '下载BOM数据
    Public Shared Function DownloadBom(ByVal pn As String, ByRef msg As String, Optional ByVal HasUI As Boolean = False) As Boolean
        Dim strCustID As String = "", strSeriesID
        Try
            Dim strSQL As String
            Dim dt As DataTable

            '连接到SAP
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                'strSQL = CommClass.GetErpFilterSqlSap(pn, "2")
                'dt = OracleOperateUtils.GetDataTableSap(strSQL)
                strSQL = CommClass.GetErpFilterSqlSap(pn, "4")
                dt = DbOperateUtils.GetDataTable(strSQL)
            Else
                strSQL = SapCommon.GetErpFilterSql(pn)
                dt = OracleOperateUtils.GetDataTable(strSQL)
            End If

            If dt.Rows.Count <= 0 Then
                msg = "ERP 中找不到料件""" & pn & """ 信息"
                Return False
            Else
                ' first get from MES  , cq 
                strCustID = MOComBusiness.GetCustIDFromMES(pn)
                If String.IsNullOrEmpty(strCustID) Then
                    strCustID = "99"
                Else
                    'do nothing
                End If

                'first get from MES  , cq 2016/06/14
                strSeriesID = MOComBusiness.GetSerialIDFromMES(pn)
                If String.IsNullOrEmpty(strSeriesID) Then
                    strSeriesID = "018"
                Else
                    'do nothing
                End If

                dt.Columns.Add("CustID", GetType(String))
                For Each dr As DataRow In dt.Rows
                    dr.Item("CustID") = strCustID
                Next

                dt.Columns.Add("SeriesID", GetType(String))
                For Each dr As DataRow In dt.Rows
                    dr.Item("SeriesID") = strSeriesID
                Next

                MOComBusiness.SaveErpSetPNData(dt)
            End If

            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmMoMain", "DownloadBom", "RCard")
            Throw ex
        End Try
    End Function

    Public Shared Function GetPartIDByMO(ByVal parMO As String) As String
        Dim lsSQL As String = ""
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        GetPartIDByMO = ""
        Try
            lsSQL = " SELECT PartID FROM m_MainMO_t  WHERE MOID='" & parMO & "' " & _
                    " UNION " & _
                    " SELECT PartID FROM m_RCardMO_t  WHERE MOID='" & parMO & "' "

            Dim dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetPartIDByMO = MoComDB.DBNullToStr(dt.Rows(0).Item("PartID"))
            Else
                GetPartIDByMO = ""
            End If
            Return GetPartIDByMO
        Catch ex As Exception

        Finally
            sConn = Nothing
        End Try
    End Function

    '保存ERP下载数据
    Public Shared Function SaveErpData(dt As DataTable) As Boolean
        Dim tavcPart As String = String.Empty
        Dim pavcPart As String = String.Empty
        Dim Version As String = String.Empty
        Dim ParentFormat As String = String.Empty
        Dim ChildFormat As String = String.Empty
        Dim ParentDes As String = String.Empty
        Dim ChildDes As String = String.Empty
        Dim EffectiveDate As String = String.Empty
        Dim ExpirationDate As Object = Nothing
        Dim EXTENSIABLE As String = String.Empty
        Dim Qty As String = String.Empty
        Dim strCustID As String = "", strSeriesID As String = ""
        Dim pavcPartList As ArrayList = New ArrayList
        Dim insertSql As New System.Text.StringBuilder
        Dim o_strExecuteSQLResult As String = ""
        Try
            'Add by cq 20160606, modify 20160617
            insertSql.Append("DELETE FROM m_PartContrast_t WHERE PAVCPART = '" & dt.Rows(0)(BomInfo.ParentPartId.ToString) &
                             "' AND isnull([TYPE],'R')='R'" & MOComBusiness.GetPartFatoryNoBlank)

            Dim strInsertSQL As String =
                "INSERT INTO dbo.m_PartContrast_t " &
                    "(TAvcPart ,PAvcPart ,UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
                     "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID)"
            Dim strUpdateSQL As String =
                    " UPDATE dbo.m_PartContrast_t "
            '子料号
            For iCnt As Integer = 0 To dt.Rows.Count - 1

                tavcPart = dt.Rows(iCnt)(BomInfo.ChildPartId.ToString).ToString
                pavcPart = dt.Rows(iCnt)(BomInfo.ParentPartId.ToString).ToString
                Version = dt.Rows(iCnt)(BomInfo.Version.ToString).ToString
                ParentFormat = dt.Rows(iCnt)(BomInfo.ParentFormat.ToString).ToString
                ChildFormat = dt.Rows(iCnt)(BomInfo.ChildFormat.ToString).ToString
                ParentDes = dt.Rows(iCnt)(BomInfo.ParentDescription.ToString).ToString
                ChildDes = dt.Rows(iCnt)(BomInfo.ChildDescription.ToString).ToString
                EffectiveDate = dt.Rows(iCnt)(BomInfo.EffectiveDate.ToString).ToString

                If IsDBNull(dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)) Then 'Modify by CQ 20151220
                    ExpirationDate = DBNull.Value
                Else
                    ExpirationDate = dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)
                End If
                ' ExpirationDate = dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString).ToString
                EXTENSIABLE = dt.Rows(iCnt)(BomInfo.Extensible.ToString).ToString
                Qty = dt.Rows(iCnt)(BomInfo.Qty.ToString).ToString
                strCustID = dt.Rows(iCnt)(BomInfo.CustID.ToString).ToString
                strSeriesID = dt.Rows(iCnt)(BomInfo.SeriesID.ToString).ToString

                '料件修改 20151108 Daniel
                If (pavcPartList.Contains(pavcPart)) = False Then
                    pavcPartList.Add(pavcPart)
                    '父料号
                    insertSql.AppendFormat("IF EXISTS (SELECT 1 FROM m_PartContrast_t where TAvcPart = '{0}' and PAvcPart = '{1}' " & MOComBusiness.GetPartFatoryNoBlank &
                                           ")", pavcPart, pavcPart)
                    insertSql.Append(strUpdateSQL)
                    insertSql.AppendFormat(" SET PAvcPart = N'{0}',", pavcPart)
                    insertSql.AppendFormat(" Userid = N'{0}',", userID)
                    insertSql.AppendFormat(" Intime = getdate(),")
                    insertSql.AppendFormat(" TypeDest = N'{0}',", TransferDBSpecChar(ParentDes))
                    insertSql.AppendFormat(" DESCRIPTION = N'{0}',", TransferDBSpecChar(ParentFormat))
                    insertSql.AppendFormat(" CusID = N'{0}', ", strCustID)
                    insertSql.AppendFormat(" SeriesID = N'{0}'", strSeriesID)
                    insertSql.AppendFormat(" WHERE TAvcPart ='{0}'", pavcPart)
                    insertSql.AppendFormat(" AND PAvcPart = '{0}' " & MOComBusiness.GetPartFatory, pavcPart)
                    insertSql.Append(" ELSE ")
                    insertSql.Append(strInsertSQL)
                    insertSql.Append(" VALUES(")
                    insertSql.AppendFormat("N'{0}',", pavcPart)
                    insertSql.AppendFormat("N'{0}',", pavcPart)
                    insertSql.AppendFormat("N'Y',")
                    insertSql.AppendFormat("N'{0}',", userID)
                    insertSql.AppendFormat("getdate(),") 'Intime ,TypeDest ,AmountQty ,DESCRIPTION
                    insertSql.AppendFormat("N'{0}',", ParentDes)
                    insertSql.AppendFormat("N'{0}',", Qty)
                    insertSql.AppendFormat("N'{0}',", ParentFormat)
                    insertSql.AppendFormat("'{0}',", "Y")
                    insertSql.AppendFormat("{0},", "NULL")
                    insertSql.AppendFormat("{0},", "NULL")
                    insertSql.AppendFormat("N'{0}',", "")
                    insertSql.AppendFormat("N'{0}',", "R")
                    insertSql.AppendFormat("N'{0}',", strCustID)
                    insertSql.AppendFormat("N'{0}'", strSeriesID)
                    insertSql.Append(");")
                End If
                insertSql.AppendFormat("IF EXISTS (SELECT 1 from m_PartContrast_t where TAvcPart = '{0}' and PAvcPart = '{1}' " & MOComBusiness.GetPartFatoryNoBlank &
                                       ")", tavcPart, pavcPart)
                insertSql.Append(strUpdateSQL)
                insertSql.AppendFormat(" SET PAvcPart = N'{0}',", pavcPart)
                insertSql.AppendFormat("UseY = 'Y',")
                insertSql.AppendFormat("Userid = N'{0}',", userID)
                insertSql.AppendFormat("Intime = getdate(),")
                insertSql.AppendFormat("TypeDest = N'{0}',", TransferDBSpecChar(ChildDes))
                insertSql.AppendFormat("AmountQty = '{0}',", Qty)
                insertSql.AppendFormat("DESCRIPTION = N'{0}',", TransferDBSpecChar(ChildFormat))
                insertSql.AppendFormat("Extensible = N'{0}',", EXTENSIABLE)
                insertSql.AppendFormat("EffectiveDate = N'{0}',", EffectiveDate)
                If IsDBNull(ExpirationDate) Then  'Modify by CQ 20151220
                    insertSql.AppendFormat("ExpirationDate = NULL,")
                Else
                    insertSql.AppendFormat("ExpirationDate = '{0}',", ExpirationDate)
                End If
                ' insertSql.AppendFormat("ExpirationDate = '{0}',", ExpirationDate)
                insertSql.AppendFormat("VERSION = N'{0}',", Version)
                insertSql.AppendFormat(" CusID = N'{0}', ", strCustID)
                insertSql.AppendFormat(" SeriesID = N'{0}',", strSeriesID)
                insertSql.AppendFormat("TYPE = N'{0}'", "R")
                insertSql.AppendFormat("WHERE TAvcPart ='{0}'", tavcPart)
                insertSql.AppendFormat("AND PAvcPart = '{0}'" & MOComBusiness.GetPartFatory, pavcPart)
                insertSql.Append(" ELSE ")
                insertSql.Append(strInsertSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", tavcPart)
                insertSql.AppendFormat("N'{0}',", pavcPart)
                insertSql.AppendFormat("N'Y',")
                insertSql.AppendFormat("N'{0}',", userID)
                insertSql.AppendFormat("getdate(),")
                insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildDes))
                insertSql.AppendFormat("N'{0}',", Qty)
                insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildFormat))
                insertSql.AppendFormat("N'{0}',", EXTENSIABLE)  'N ==> EXTENSIABLE,cq 20160618
                insertSql.AppendFormat("N'{0}',", EffectiveDate)
                insertSql.AppendFormat("'{0}',", ExpirationDate)
                insertSql.AppendFormat("N'{0}',", Version)
                insertSql.AppendFormat("N'{0}',", "R")
                insertSql.AppendFormat("N'{0}',", strCustID)
                insertSql.AppendFormat("N'{0}'", strSeriesID)
                insertSql.Append(");")
            Next
            '保存数据，有事务处理
            o_strExecuteSQLResult = MoComDB.ExecSQL(insertSql.ToString)
            If Not String.IsNullOrEmpty(o_strExecuteSQLResult) Then
                Return False
            End If
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MOComBusiness", "SaveErpData", "RCard")
        End Try
    End Function

    Public Shared Function TransferDBSpecChar(target As String) As String
        TransferDBSpecChar = target.Replace("'", "''")
    End Function

    Public Shared Function GetCustIDFromMES(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetCustIDFromMES = ""
        Try
            lsSQL = " SELECT CUSID From m_PartContrast_t " & _
                    " WHERE TAvcPart ='" & parPartID & "'"

            Dim dt As DataTable = MoComDB.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetCustIDFromMES = dt.Rows(0).Item("CUSID")
            Else
                GetCustIDFromMES = ""
            End If
            Return GetCustIDFromMES
        Catch ex As Exception
        End Try
    End Function


    Public Shared Function GetAmountQtyFromMES(ByVal parChildPartID As String, ByVal parChildMO As String) As Integer
        Dim lsSQL As String = ""
        GetAmountQtyFromMES = 1
        Try
            lsSQL = " SELECT part.AmountQty" & _
                    " FROM m_PartContrast_t  part " & _
                   " left join m_Mainmo_t PMO on part.PAvcPart = PMO.PartID " & _
                   " Left join m_Mainmo_t CMO on part.TAvcPart = cmo.PartID" & _
                   " where TAvcPart ='" & parChildPartID & "' " & _
                   " and pmo.ParentMo= cmo.ParentMo" & _
                   " and part.TAvcPart <> part.PAvcPart" & _
                  " and cmo.Moid = '" & parChildMO & " '"
            Dim dt As DataTable = MoComDB.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetAmountQtyFromMES = dt.Rows(0).Item(0)
            Else
                GetAmountQtyFromMES = 1
            End If
            Return GetAmountQtyFromMES
        Catch ex As Exception
        End Try
    End Function


    Public Shared Function GetSerialIDFromMES(ByVal parPartID As String) As String
        Dim lsSQL As String = ""
        GetSerialIDFromMES = ""
        Try
            lsSQL = " SELECT ISNULL(SeriesID,'') FROM m_PartContrast_t " & _
                    " WHERE TAvcPart='" & parPartID & "'"

            Dim dt As DataTable = MoComDB.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetSerialIDFromMES = dt.Rows(0).Item(0)
            Else
                GetSerialIDFromMES = ""
            End If
            Return GetSerialIDFromMES
        Catch ex As Exception
        End Try
    End Function


    Public Shared Function GetCustIDFromMES(ByVal parPartID As String, ByRef o_strCustID As String, ByRef o_strSeriesID As String) As Boolean
        Dim lsSQL As String = ""
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        GetCustIDFromMES = True
        Try
            lsSQL = " SELECT CUSID,SERIESID FROM m_PartContrast_t " & _
                    " WHERE TAVCPART='" & parPartID & "' "

            Dim dt As DataTable = sConn.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                o_strCustID = MoComDB.DBNullToStr(dt.Rows(0).Item("CUSID"))
                o_strSeriesID = MoComDB.DBNullToStr(dt.Rows(0).Item("SERIESID"))
            Else
                o_strCustID = ""
                o_strSeriesID = ""
            End If
            Return True
        Catch ex As Exception

        Finally
            sConn = Nothing
        End Try
    End Function

    Public Shared Function IsHavePartContrast(partid As String) As Boolean
        IsHavePartContrast = False

        Dim strSQL As String = "SELECT 1 FROM m_PartContrast_t WHERE TAvcPart = '{0}' AND TAvcPart= PAvcPart " & GetPartFatoryNoBlank()
        strSQL = String.Format(strSQL, partid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If (dt.Rows.Count > 0) Then
            IsHavePartContrast = True
        End If
    End Function

    Public Shared Function GetPartFatoryNoBlank() As String
        Dim strValue As String = " AND (factory='" & VbCommClass.VbCommClass.Factory & "') "

        Return strValue
    End Function

    Public Shared Function GetPartFatory() As String
        Dim strValue As String = " AND (factory='" & VbCommClass.VbCommClass.Factory & "' or factory = '') "

        Return strValue
    End Function

    Public Shared Function GetFatoryProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND Factoryid='" & VbCommClass.VbCommClass.Factory & "'"
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return strValue
    End Function

    'mark 利润中心条件, 20180517
    Public Shared Function GetFatoryProfitcenterOne(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.Factoryid={0}.Factoryid", table)  'VbCommClass.VbCommClass.Factory
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.Profitcenter= {0}.Profitcenter", table)
        End If
        Return strValue
    End Function

#Region "检查TIPTOP的版本"

    Public Shared Function GetChildPnByCurrentMoPn(ByVal moPn As String) As DataTable
        ' Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim lsSQL As String = ""
        'cq 20170110, 
        ' 工单 开立展开选项
        '3: 展开, 2 : 不展开但自动开立工单, now: EXTENSIBLE=Y/N (=3 /<>3)
        'cq 20180120, remove SUBSTRING(pavcpart, 1, 1) = SUBSTRING(TAvcPart, 1, 1)
        lsSQL = " SELECT TAvcPart, PAvcPart, VERSION" & _
                " FROM m_PartContrast_t" & _
                " WHERE 1=1" & _
                " AND PAvcPart = '" & moPn & "'" & _
                " AND ISNULL (EffectiveDate, getdate ()) <= getdate ()" & _
                " AND ISNULL (ExpirationDate, getdate ()) >= getdate ()" & _
                " AND Pavcpart <> TAvcPart" & _
                " AND EXTENSIBLE ='Y'" & _
                  MOComBusiness.GetPartFatory &
                " UNION " &
                " SELECT TAvcPart, PAvcPart, VERSION" & _
                " FROM m_PartContrast_t" & _
                " WHERE 1=1" & _
                " AND PAvcPart = '" & moPn & "'" & _
                " AND ISNULL (EffectiveDate, getdate ()) <= getdate ()" & _
                " AND CONVERT (NVARCHAR (10), cast (ExpirationDate AS DATETIME), 112) =" & _
                " CONVERT (NVARCHAR (10),cast ('1900-01-01 00:00:00.000' AS DATETIME), 112)" & _
                " AND Pavcpart <> TAvcPart" & _
                " AND EXTENSIBLE ='Y'" &
                MOComBusiness.GetPartFatory()
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            Return o_dt
        End Using
    End Function

    Public Shared Function ExistUnfinishRCard(ByVal strPartID As String) As Boolean
        Dim str As String = String.Empty
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        str = "SELECT STATUS,PartID  FROM m_RCardM_t WHERE partid LIKE '%" & strPartID & "%'  AND STATUS IN(0)  "
        Using o_dt As DataTable = sConn.GetDataTable(str)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                ExistUnfinishRCard = True
            Else
                ExistUnfinishRCard = False
            End If
            Return ExistUnfinishRCard
        End Using
    End Function

    Public Shared Function GetRunCardDetailListDataTable(ByVal pn As String) As DataTable
        Using dt As DataTable = DbOperateUtils.GetDataTable(GetRunCardDetailListSql(pn))
            'for test
            dt.Rows.Add(dt.Rows.Count + 1, "tst", "0", 0, "0", "0", "0", "0", "0", "0", "0", "0")
            Return dt
        End Using
    End Function

    Private Shared Function GetRunCardDetailListSql(ByVal pn As String) As String
        Dim sql As String = ""
        '子件总工时	/裁切（04）/铆端（01）/半自动压接（A05）/成型（03）/产线（02）
        ' AND ISNULL(D.EXTENSIBLE,'Y')='Y'  " &,cq remove 20160618
        'cq remove m_PartContrast_t M 20160628
        'D.PAvcPart LIKE '%904011912%' , 20160811
        sql = "SELECT  " &
          " CAST(ROW_NUMBER() OVER(ORDER BY PN) AS INT)ID,  " &
          " A.PN,A.VERSION,CAST(A.QTY AS INT) QTY,  " &
          "  Convert(decimal(18,2), SUM(A.PREASSEMBLYHOURPRECHILD+A.ContourHourPreChild+A.MADEHOURPRECHILD + A.CutProPREChild + A.ProPrePREChild + A.SemiAutoPREChild)) TOTALHOURPRECHILD,  " &
          "  Convert(decimal(18,2),SUM(A.CutProPREChild)) CutProPREChild,  " & _
          " Convert(decimal(18,2),SUM(A.PREASSEMBLYHOURPRECHILD)) PREAssemblyHOURPREChild,  " &
          " SUM(A.SemiAutoPREChild) SemiAutoPREChild," & _
          " Convert(decimal(18,2),SUM(A.ContourHourPreChild)) ContourHourPreChild,  " &
          " SUM(A.MADEHOURPRECHILD) MadeHOURPRECHILD,  " & _
          " SUM(A.CutProPREMO)  CutProPREMO,  " & _
          " Convert(decimal(18,2),SUM(A.PREASSEMBLYHOURPREMO)) PREASSEMBLYHOURPREMO,  " &
          " SUM(A.SemiAutoPREMO)  SemiAutoPREMO,  " & _
          " SUM(A.ContourHOURPREMO) ContourHOURPREMO,  SUM(A.MADEHOURPREMO) MADEHOURPREMO " &
          " FROM (  " &
          " SELECT DISTINCT D.TAvcPart PN,B.StationSQ,A.DRAWINGVER VERSION,ISNULL(D.AmountQty,0) QTY ,  " &
          "            CASE F.ID  " &
          " WHEN '01' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)   ELSE 0 END PREASSEMBLYHOURPRECHILD,  " &
          "            CASE F.ID  " &
          " WHEN '02' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)   ELSE 0 END MadeHOURPRECHILD,  " &
          "             CASE F.ID  " &
          " WHEN '03' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)   ELSE 0 END ContourHourPreChild,  " & _
          "       CASE F.ID  " & _
          " WHEN '04' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)  " &
          " ELSE 0 END CutProPREChild,  " & _
           "       CASE F.ID  " & _
             " WHEN '05' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)  " &
          " ELSE 0 END ProPrePREChild,  " & _
          "       CASE F.ID  " &
          " WHEN 'A05' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)  " &
          " ELSE 0 END SemiAutoPREChild,  " & _
          "             CASE F.ID  " &
          " WHEN '01' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)    ELSE 0 END PREASSEMBLYHOURPREMO,  " &
          "             CASE F.ID  " &
          " WHEN '02' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)    ELSE 0 END MadeHOURPREMO,  " &
          "             CASE F.ID  " &
          " WHEN '03' THEN ISNULL(B.WorkingHours,0)*ISNULL(D.AmountQty,0)    ELSE 0 END ContourHOURPREMO,  " & _
          " CASE F.ID" & _
          " WHEN '04' THEN ISNULL (B.WorkingHours, 0) * ISNULL(D.AmountQty, 0)" & _
           " ELSE 0 End  CutProPREMO," & _
           " CASE F.ID  " & _
           " WHEN '05' THEN  ISNULL(B.WorkingHours, 0) * ISNULL(D.AmountQty, 0)" & _
           " ELSE 0 End ProPrePREMO," & _
           " CASE F.ID " & _
           " WHEN 'A05' THEN ISNULL(B.WorkingHours, 0) * ISNULL (D.AmountQty, 0)" & _
           " ELSE 0  End SemiAutoPREMO" & _
          " FROM m_RCardM_t A,m_RCardD_t B,m_PartContrast_t D,  " &
          " m_Rstation_t E LEFT JOIN m_RstationSection_t F ON E.SECTIONID =F.ID AND F.usey =1  " &
          " WHERE ISNULL(D.EFFECTIVEDATE,GETDATE()-1)<=CONVERT(VARCHAR(10),GETDATE(),111)  " &
          " AND (D.EXPIRATIONDATE='' OR ISNULL(D.EXPIRATIONDATE, GETDATE() +1) >=GETDATE() )  " &
          " AND D.TAvcPart=A.PARTID " &
          " AND A.PartID =B.PartID " &
          " AND D.TAvcPart <> D.PAvcPart" & _
          " AND D.PAvcPart LIKE '%" & pn & "%' " &
          GetFatoryProfitcenter("A") &
          " AND A.STATUS IN(1,2) " &
          " AND B.STATUS=1 " &
          " AND B.StationID =E.Stationid " &
          "  )A " &
          " GROUP BY PN,VERSION,QTY  "

        Return sql

    End Function

    Private Shared Function GetFatoryProfitcenter(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.Factoryid='" & VbCommClass.VbCommClass.Factory & "'", table)
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'", table)
        End If
        Return strValue
    End Function

    ''' <summary>
    ''' 获取成套料号下面的子件列表和个数。
    ''' </summary>
    ''' <param name="pn"></param>
    ''' <param name="dtReal"></param>
    ''' <param name="o_stdPartID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChildPNCount(ByVal pn As String, ByVal dtReal As DataTable, ByRef o_stdPartID As DataTable) As Integer
        Dim strSQL As String = String.Empty
        'strSQL = " SELECT TAvcPart FROM m_PartContrast_t " & _
        '      " WHERE pavcpart ='" & pn & "'" & _
        '      " AND TAvcPart <> PAvcPart" & _
        '      " AND  CHARINDEX(N'电缆',TypeDest) >0" & _
        '      " UNION " & _
        '      " SELECT TAvcPart FROM m_PartContrast_t " & _
        '      " WHERE pavcpart ='" & pn & "'" & _
        '      " AND TAvcPart <> PAvcPart" & _
        '      " AND TAvcPart like '" & pn & "%'"

        strSQL = " SELECT TAvcPart FROM [dbo].[fun_getRCardChildAmountQty]('" & pn & "')"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                GetChildPNCount = o_dt.Rows.Count
                o_stdPartID = o_dt
            Else
                GetChildPNCount = 0
            End If
            Return GetChildPNCount
        End Using
    End Function

    Public Shared Function GetNotExistPartIDList(ByVal dtReal As DataTable, ByVal o_stdPartID As DataTable) As String
        GetNotExistPartIDList = ""
        dtReal.Rows.RemoveAt(dtReal.Rows.Count - 1)
        '找出那个料件是没有制作
        For Each dr As DataRow In o_stdPartID.Rows
            If dtReal.Select("PN = '" & dr.Item(0) & "'").Length <= 0 Then
                GetNotExistPartIDList &= dr.Item(0) & ","
            End If
        Next
        If Not String.IsNullOrEmpty(GetNotExistPartIDList) Then
            GetNotExistPartIDList = GetNotExistPartIDList.Substring(0, GetNotExistPartIDList.Length - 1)
        End If
    End Function

    Private Shared Assort As String = Nothing
    Private Shared TotalHourPreMo As String = Nothing
    Private Shared QTY As String = Nothing
    Private Shared TotalHourPreMoSum As String = Nothing
    Private Shared PreAssemblyHourPreChildSum As String = Nothing
    Private Shared ContourHourPreChildSum As String = Nothing
    Private Shared MadeHourPreChildSum As String = Nothing
    Private Shared m_CutProPreChildSum As String = String.Empty
    Private Shared m_ProPrePREChildSum As String = String.Empty
    Private Shared m_SemiAutoPREChildSum As String = String.Empty
    Private Shared Version As String = Nothing
    Public Shared Sub GetRunCardDetailListParameters(ByVal pn As String, ByVal dt As DataTable)
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            Version = SapCommon.GetVerFromTiptopSap(pn)
        Else
            Version = SapCommon.GetVerFromTiptop(pn)
        End If


        If dt.Rows.Count > 0 Then
            Assort = CStr(CDbl(dt.Compute("sum(QTY)", "").ToString) * RCard.RunCardBusiness.GetAssortMultiple())  ' RunCardBusiness.GetAssortMultiple()
            TotalHourPreMoSum = dt.Compute("sum(TOTALHOURPRECHILD)", "")   'dt.Compute("sum(TOTALHOURPRECHILD)", "") + 28 + dt.Compute("sum(QTY)", "") * 15
            '铆端前加工/产线/成型/裁切前加工/生产线前加工/半自动压接连接
            '子件总工时	/裁切（04）	/铆端（01）/	半自动压接（A05）/	成型（03）/	产线（02）
            PreAssemblyHourPreChildSum = CStr(dt.Compute("sum(PreAssemblyHourPreChild)", ""))
            'AssemblyHourPreChildSum = (dt.Compute("sum(TotalHourPreMo)", "") + 28 + dt.Compute("sum(QTY)", "") * 15)  - dt.Compute("sum(PreAssemblyHourPreChild)", "")
            ContourHourPreChildSum = dt.Compute("sum(ContourHourPreChild)", "")
            MadeHourPreChildSum = CStr(dt.Compute("sum(MadeHourPreChild)", ""))
            m_CutProPreChildSum = CStr(dt.Compute("sum(CutProPreChild)", "")) '裁切前加工
            ' m_ProPrePREChildSum = CStr(dt.Compute("sum(ProPrePREChild)", "")) '生产线前加工,cq remove 20160328
            m_SemiAutoPREChildSum = CStr(dt.Compute("sum(SemiAutoPREChild)", ""))
        Else
            Assort = CStr(0)
            TotalHourPreMoSum = ""
            PreAssemblyHourPreChildSum = ""
            ContourHourPreChildSum = ""
            MadeHourPreChildSum = ""
        End If
    End Sub

    Private Enum RunCardDetailGrid
        ID = 0
        Pn ' 1
        Version
        Qty
        TotalHourPreChild
        CutProPREMO  '04
        PreAssemblyHourPreMo '01
        SemiAutoPREMO 'A05
        ContourHourPreMo '03
        MadeHourPreMo '02
        Remark
        ' 铆端前加工= rivet point/产线加工/成型加工contour/裁切前加工/生产线前加工/半自动压接连接, 裁切（04）/铆端（01） rivet/半自动压接（A05）Semi-Auto/成型（03）/产线（02）
    End Enum
    Public Shared Function ChangeDataTableStyle(ByVal o_strTempMO As stcMO, ByVal dtRaw As DataTable) As DataTable
        Using dt As DataTable = New DataTable
            For index As Integer = 0 To RunCardDetailGrid.Remark
                dt.Columns.Add(dtRaw.Columns(index).ColumnName, GetType(String))
            Next
            '铆端前加工,产线加工,成型加工,裁切前加工,生产线前加工,半自动压接连接
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = o_strTempMO.MOQty  '"工单量:" + ""
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = "产品图号:" + o_strTempMO.PartID
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = o_strTempMO.MOID    '"工单号:" + ""

            If String.IsNullOrEmpty(Version) Then
                If VbCommClass.VbCommClass.IsConSap = "Y" Then
                    Version = SapCommon.GetVerFromTiptopSap(o_strTempMO.PartID)
                Else
                    Version = SapCommon.GetVerFromTiptop(o_strTempMO.PartID)
                End If
            End If
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = "版次:" + Version 'AssemblyHourPreMo
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ID) = "ID"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Pn) = "子件"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "子件版本"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "配置"
            ' PreAssemblyHourPreMo 01/MadeHourPreMo 02/ ContourHourPreMo 03/ CutProPREMO 04/ ProPrePREMO/ SemiAutoPREMO A05
            '  裁切（04）/铆端（01）/半自动压接（A05）/成型（03）/产线（02）, cq 20160325
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = "子件总工时"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.CutProPREMO) = "裁切(04)" 'cq 20160105
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = "铆端(01)"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.SemiAutoPREMO) = "半自动压接(A05)"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = "成型(03)"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = "产线(02)"
            'dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ProPrePREMO) = "子件生产线前加工"

            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Remark) = "备注项"
            For rowIndex As Integer = 0 To dtRaw.Rows.Count - 1
                dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ID) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.ID)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Pn) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Pn)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Version)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.Qty)
                '  裁切（04）/铆端（01）/半自动压接（A05）/成型（03）/产线（02）, cq 20160328
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.TotalHourPreChild)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.CutProPREMO) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.CutProPREMO)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.PreAssemblyHourPreMo) '6, Modify by cq 20160105
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.SemiAutoPREMO) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.SemiAutoPREMO) 'Add by cq 20160105
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.ContourHourPreMo)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.MadeHourPreMo)
                ' dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ProPrePREMO) = dtRaw.Rows(rowIndex)(RunCardDetailGrid.ProPrePREMO)
                dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Remark) = ""
            Next
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "贴标签:"  'Qty, cq 20160331
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "3" 'TotalHourPreChild
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "入/封胶袋(配套):"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = Assort
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "终检:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "10"
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "包装:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "15"

            'Add by cq 20160331
            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Version) = "配套工时:"
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = CStr(Val(Assort) + 28)

            dt.Rows.InsertAt(dt.NewRow, dt.Rows.Count)
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.Qty) = "总计:"
            '总计/ PreAssemblyHourPreMo/MadeHourPreMo/ AssemblyHourPreMo/ CutProPREMO/ ProPrePREMO/ SemiAutoPREMO
            ' 子件总工时/裁切（04）/铆端（01）/半自动压接（A05）/成型(03)/产线（02）
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.TotalHourPreChild) = TotalHourPreMoSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.CutProPREMO) = m_CutProPreChildSum  'cq 20160105
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.PreAssemblyHourPreMo) = PreAssemblyHourPreChildSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.SemiAutoPREMO) = m_SemiAutoPREChildSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.ContourHourPreMo) = ContourHourPreChildSum
            dt.Rows(dt.Rows.Count - 1)(RunCardDetailGrid.MadeHourPreMo) = MadeHourPreChildSum
            Return dt
        End Using
    End Function

    Public Shared Function GetRCardListVariable(ByVal dt As DataTable, ByVal o_stctempMO As stcMO) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        Try
            Dim o_dt As DataTable = dt.Copy()
            If o_dt.Rows.Count >= 5 Then
                For i As Integer = o_dt.Rows.Count - 1 To i > o_dt.Rows.Count - 5 Step -1
                    dt.Rows.RemoveAt(i)
                    If i < o_dt.Rows.Count - 5 Then
                        Exit For
                    End If
                Next
            End If

            Dim o_dtNew As DataTable = dt.Clone()
            For Each col As DataColumn In o_dtNew.Columns
                If col.ColumnName = "QTY" Then
                    col.DataType = GetType(Integer)
                End If
            Next

            For Each dr As DataRow In dt.Rows
                o_dtNew.Rows.Add(dr.ItemArray)
            Next

            If dt.Rows.Count > 0 Then
                ' ID/PN/Version/Qty/TotalHourPreChild/CutProPreChild/PreAssemblyHourPreChild/
                'SemiAutoPreChild/ContourHourPreChild/MadeHourPreChild/CutProPreMO
                ' dics.Add("PN", dt.Rows(0)("PN").ToString.Split("-")(0))
                If VbCommClass.VbCommClass.IsConSap = "Y" Then
                    Version = SapCommon.GetVerFromTiptopSap(o_stctempMO.PartID)
                Else
                    Version = SapCommon.GetVerFromTiptop(o_stctempMO.PartID)
                End If

                dics.Add("PN", o_stctempMO.PartID)
                dics.Add("VERSION", Version)  ' cq20170216,  dt.Rows(0)("PN").ToString.Split("-")(0))
                '&=$Total	&=Cut	&=$PreAssembly	&=$SemiAuto	&=$Contour	&=$Made
                dics.Add("Pack", CStr(Val(o_dtNew.Compute("sum(QTY)", "")) * RCard.RunCardBusiness.GetAssortMultiple())) '15
                dics.Add("Lot", CStr(Val(o_dtNew.Compute("sum(QTY)", "")) * RCard.RunCardBusiness.GetAssortMultiple() + 28))
                dics.Add("Cut", o_dt.Rows(o_dt.Rows.Count - 1).Item("CutProPreChild"))
                dics.Add("PreAssembly", o_dt.Rows(o_dt.Rows.Count - 1).Item("PreAssemblyHourPreChild"))
                dics.Add("SemiAuto", o_dt.Rows(o_dt.Rows.Count - 1).Item("SemiAutoPreChild"))
                dics.Add("Contour", o_dt.Rows(o_dt.Rows.Count - 1).Item("ContourHourPreChild"))
                dics.Add("Made", o_dt.Rows(o_dt.Rows.Count - 1).Item("MadeHourPreChild"))
                dics.Add("Total", o_dt.Rows(o_dt.Rows.Count - 1).Item("TotalHourPreChild"))
                dics.Add("MOID", o_stctempMO.MOID)
                dics.Add("MOQty", o_stctempMO.MOQty)
            End If
            Return dics
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "MOComBusiness", "GetRCardListVariable", "RCard")
            Throw ex
        End Try
    End Function

    Public Shared Function Import2ExcelByAsMO(ByVal file As String, ByVal outPutFile As String, ByVal dt As DataTable, _
                                  ByVal dics As System.Collections.Generic.Dictionary(Of String, String), _
                                  ByVal strMOID As String, ByVal strPartID As String, _
                                  ByRef errorMsg As String) As Boolean
        Dim workBookDesigner As WorkbookDesigner = Nothing
        Dim wk As Workbook = Nothing
        Dim o_strPicturePath As String = "", o_strPartIDPicturePath As String = ""
        Try
            workBookDesigner = New WorkbookDesigner
            wk = New Workbook(file)
            workBookDesigner.Workbook = wk

            workBookDesigner.SetDataSource(dt)

            Dim bc1 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.QRCode)
            bc1.SaveFileType = DotNetBarcode.SaveFileTypes.Gif

            o_strPicturePath = Environment.CurrentDirectory + "\" & "barcode.bmp"
            o_strPartIDPicturePath = Environment.CurrentDirectory + "\" & "barcodePartID.bmp"
            bc1.QRSave(strMOID, o_strPicturePath, 3)

            'cq 20161119
            System.IO.File.Copy(o_strPicturePath, o_strPartIDPicturePath, True)

            'for partid qrcode
            Dim bc2 As DotNetBarcode = New DotNetBarcode(DotNetBarcode.Types.QRCode)
            bc2.SaveFileType = DotNetBarcode.SaveFileTypes.Gif
            bc2.QRSave(strPartID, o_strPartIDPicturePath, 3)

            For Each dic As System.Collections.Generic.KeyValuePair(Of String, String) In dics
                workBookDesigner.SetDataSource(dic.Key, dic.Value)
            Next

            Dim pictures As Aspose.Cells.Drawing.PictureCollection = workBookDesigner.Workbook.Worksheets(0).Pictures
            'D1,moid
            pictures.Add(0, 3, o_strPicturePath)

            'C1, PartID
            pictures.Add(0, 2, o_strPartIDPicturePath)

            workBookDesigner.Process()
            workBookDesigner.Workbook.Save(outPutFile, SaveFormat.Xlsx)
            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        Finally
            If Not workBookDesigner Is Nothing Then
                workBookDesigner = Nothing
            End If
            If Not wk Is Nothing Then
                wk = Nothing
            End If
        End Try
    End Function


#End Region

    Public Shared Function SaveErpSetPNData(dt As DataTable) As Boolean
        Dim tavcPart As String = String.Empty
        Dim pavcPart As String = String.Empty
        Dim Version As String = String.Empty
        Dim ParentFormat As String = String.Empty
        Dim ChildFormat As String = String.Empty
        Dim ParentDes As String = String.Empty
        Dim ChildDes As String = String.Empty
        Dim EffectiveDate As String = String.Empty
        Dim ExpirationDate As Object = String.Empty
        Dim EXTENSIABLE As String = String.Empty
        Dim Qty As String = String.Empty
        Dim strCustID As String = "", strSeriesID As String = ""
        Dim pavcPartList As ArrayList = New ArrayList
        Dim insertSql As New System.Text.StringBuilder
        Dim o_strExecuteSQLResult As String = ""
        Dim strInsertSQL As String = ""
        Try
            'mark cq 20160824, AND (Amountqty is null or Amountqty<=0)
            insertSql.Append("DELETE FROM m_PartContrast_t WHERE ")
            insertSql.Append(" PAVCPART  = '" & dt.Rows(0)(BomInfo.ParentPartId.ToString).ToString & "'")
            insertSql.Append(" AND TAvcPart <> PAvcPart AND isnull([TYPE],'R')='R' ")
            'insertSql.Append(" AND Tavcpart like '9%'")
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                insertSql.Append(" AND factory = '" & VbCommClass.VbCommClass.Factory & "'")
            End If

            '子料号
            For iCnt As Integer = 0 To dt.Rows.Count - 1
                tavcPart = dt.Rows(iCnt)(BomInfo.ChildPartId.ToString).ToString
                pavcPart = dt.Rows(iCnt)(BomInfo.ParentPartId.ToString).ToString
                Version = dt.Rows(iCnt)(BomInfo.Version.ToString).ToString
                ParentFormat = dt.Rows(iCnt)(BomInfo.ParentFormat.ToString).ToString
                ChildFormat = dt.Rows(iCnt)(BomInfo.ChildFormat.ToString).ToString
                ParentDes = dt.Rows(iCnt)(BomInfo.ParentDescription.ToString).ToString
                ChildDes = dt.Rows(iCnt)(BomInfo.ChildDescription.ToString).ToString
                EffectiveDate = dt.Rows(iCnt)(BomInfo.EffectiveDate.ToString).ToString

                If IsDBNull(dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)) Then 'Modify by CQ 20151208
                    ExpirationDate = DBNull.Value
                    strInsertSQL =
                        "INSERT INTO dbo.m_PartContrast_t " &
                            "(TAvcPart ,PAvcPart , factory, UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
                             "Extensible ,EffectiveDate ,VERSION ,TYPE,CusID, SeriesID)"
                Else
                    ExpirationDate = dt.Rows(iCnt)(BomInfo.ExpirationDate.ToString)
                    strInsertSQL =
                        "INSERT INTO dbo.m_PartContrast_t " &
                            "(TAvcPart ,PAvcPart , factory, UseY ,Userid ,Intime ,TypeDest ,AmountQty ,DESCRIPTION ," &
                             "Extensible ,EffectiveDate ,ExpirationDate ,VERSION ,TYPE,CusID, SeriesID)"
                End If

                EXTENSIABLE = dt.Rows(iCnt)(BomInfo.Extensible.ToString).ToString
                Qty = dt.Rows(iCnt)(BomInfo.Qty.ToString).ToString
                strCustID = dt.Rows(iCnt)(BomInfo.CustID.ToString).ToString
                strSeriesID = dt.Rows(iCnt)(BomInfo.SeriesID.ToString).ToString

                insertSql.AppendFormat("IF NOT EXISTS (SELECT 1 from m_PartContrast_t where TAvcPart = '{0}' and PAvcPart = '{1}' and factory = '{2}')",
                                       tavcPart, pavcPart, VbCommClass.VbCommClass.Factory)
                insertSql.Append(strInsertSQL)
                insertSql.Append(" VALUES(")
                insertSql.AppendFormat("N'{0}',", tavcPart)
                insertSql.AppendFormat("N'{0}',", pavcPart)
                insertSql.AppendFormat("N'{0}',", VbCommClass.VbCommClass.Factory)
                insertSql.AppendFormat("N'Y',")
                insertSql.AppendFormat("N'{0}',", userID)
                insertSql.AppendFormat("getdate(),")
                insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildDes))
                insertSql.AppendFormat("N'{0}',", Qty)  '--田玉琳 20180402，父料号=子料号 数量为1 
                insertSql.AppendFormat("N'{0}',", TransferDBSpecChar(ChildFormat))
                insertSql.AppendFormat("N'{0}',", EXTENSIABLE)  'cq20160618  N ==> EXTENSIABLE
                insertSql.AppendFormat("N'{0}',", EffectiveDate)
                If Not IsDBNull(ExpirationDate) Then  'cq 20160614
                    insertSql.AppendFormat("'{0}',", ExpirationDate)
                End If
                insertSql.AppendFormat("N'{0}',", Version)
                insertSql.AppendFormat("N'{0}',", "R")
                insertSql.AppendFormat("N'{0}',", strCustID)
                insertSql.AppendFormat("N'{0}'", strSeriesID)
                'insertSql.AppendFormat("N'{0}'", VbCommClass.VbCommClass.Factory)
                insertSql.Append(");")
            Next
            '保存数据，有事务处理
            o_strExecuteSQLResult = DbOperateUtils.ExecSQL(insertSql.ToString)
            If Not String.IsNullOrEmpty(o_strExecuteSQLResult) Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
