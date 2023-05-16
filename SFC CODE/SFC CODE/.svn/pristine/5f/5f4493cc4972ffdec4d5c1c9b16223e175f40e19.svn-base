Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OracleClient
Imports System
Imports MainFrame
Imports MainFrame.SysCheckData
Imports SysBasicClass

Public Class RCardComBusiness

    Public Enum RCardStaus
        制作中 = 0
        已完成
        待审核
    End Enum

    Public Structure stcRuncard
        Public Status As String
        Public RunCardPartPN As String
        Public RCardVersion As String
    End Structure

    Public Structure stcCutcard
        Public Status As String
        Public CutCardPartPN As String
        Public CutCardVersion As String
    End Structure

    Public Shared Function GetWhereAnd(tableFieldName As String, value As String) As String
        Dim strValue As String = String.Format(" AND {0}='{1}'", tableFieldName, value)
        Return strValue
    End Function

    Public Shared Function GetWhereAndN(tableFieldName As String, value As String) As String
        Dim strValue As String = String.Format(" AND {0}=N'{1}'", tableFieldName, value)
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

    Public Shared Function IsQueryOldRCardVersion(ByVal PN As String, ByVal strRCardVersion As String) As Boolean
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT TOP 1 1  from m_RCardMOldVer_t where partid ='" & PN & "' and DrawingVer='" & strRCardVersion & "'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)

            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsQueryOldRCardVersion = True
            Else
                IsQueryOldRCardVersion = False
            End If
        End Using
        Return IsQueryOldRCardVersion
    End Function
    ''' <summary>
    ''' 查询裁线卡是否是旧版本
    ''' </summary>
    ''' <param name="PN"></param>
    ''' <param name="strCutCardVersion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsQueryOldCutCardVersion(ByVal PN As String, ByVal strCutCardVersion As String) As Boolean
        Dim lsSQL As String = String.Empty
        lsSQL = " SELECT TOP 1 1  FROM m_CutCardMOldVer_t WHERE partid ='" & PN & "' AND DrawingVer='" & strCutCardVersion & "'"

        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)

            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                IsQueryOldCutCardVersion = True
            Else
                IsQueryOldCutCardVersion = False
            End If
        End Using
        Return IsQueryOldCutCardVersion
    End Function

    Public Shared Function GetFatoryProfitcenter(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.Factoryid='" & VbCommClass.VbCommClass.Factory & "'", table)
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'", table)
        End If
        Return strValue
    End Function

    '执行查询，并返回查询所返回的结果集中第一行的第一列
    Public Shared Function ExecuteScalarOracle(ByVal sql As String) As String
        Dim returnValue As String

        Dim oracleConn As New SysBasicClass.OracleDb("")
        Try
            returnValue = oracleConn.ExecuteScalar(sql).ToString()
        Catch ex As Exception
            Throw
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try

        Return returnValue
    End Function

    Public Shared Function GetDataTableOracle(ByVal sql As String) As DataTable
        Dim dt As DataTable

        Dim oracleConn As New SysBasicClass.OracleDb("")
        Try
            dt = oracleConn.ExecuteQuery(sql).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try

        Return dt
    End Function

    Public Shared Sub Oracle_ExecuteNonQuery(ByVal sql As String)

        Dim oracleConn As New SysBasicClass.OracleDb("")

        ' Dim oracleConn As New SysBasicClass.OracleDataBaseHelper()
        Try
            oracleConn.ExecuteNonQuery(sql)
        Catch ex As Exception
            Throw ex
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try
    End Sub

    Public Shared Sub Oracle_ExecuteNonQuery_QAS(ByVal sql As String)

        Dim oracleConn As New RCardDB.OracleDb()

        Try
            oracleConn.ExecuteNonQuery(sql)

        Catch ex As Exception
            Throw ex
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try
    End Sub

    Public Shared Function GetDataTable(ByVal sql As String) As DataTable
        Dim dt As DataTable

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            dt = sConn.GetDataTable(sql)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return dt
    End Function

    Public Shared Function GetDataSet(ByVal sql As String) As DataSet
        Dim ds As DataSet

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            ds = sConn.GetDataSet(sql)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return ds
    End Function

    Public Shared Function ExecSQL(ByVal sql As String, Optional ByRef IsQAS As Boolean = False) As String
        Dim result As String

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        'If sConn.m_SqlserverIP = "172.20.20.155" Then

        'End If

        Try
            If sConn.PubConnection.ConnectionString.Contains("172.20.20.155") Then
                IsQAS = True
            End If
            result = sConn.ExecuteNonQuery(sql)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return result
    End Function

    Public Shared Function ExecuteNonQureyByProc(ByVal SPName As String, paramsList As ArrayList) As String
        Dim result As String

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim cmdParms(paramsList.Count - 1) As SqlParameter
            Dim sqlParam As SqlParameter = Nothing

            Dim iCnt As Integer
            For iCnt = 0 To paramsList.Count - 1
                AddParams(paramsList(iCnt), sqlParam)
                cmdParms(iCnt) = sqlParam
            Next
            result = sConn.ExecuteNonQureyByProc(SPName, cmdParms)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return result
    End Function

    Public Shared Function ExecuteNonQureyByProc(ByVal SPName As String, ByVal Paramters() As SqlClient.SqlParameter) As String
        Dim result As String

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            result = sConn.ExecuteNonQureyByProc(SPName, Paramters)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return result
    End Function

    Public Shared Sub ExecSQL(sql As String, paramsList As ArrayList)
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try

            Dim cmdParms(paramsList.Count - 1) As SqlParameter
            Dim sqlParam As SqlParameter = Nothing

            Dim iCnt As Integer
            For iCnt = 0 To paramsList.Count - 1
                AddParams(paramsList(iCnt), sqlParam)
                cmdParms(iCnt) = sqlParam
            Next

            sConn.ExecSql(sql, cmdParms)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
    End Sub

    Public Shared Function GetDataTable(sql As String, paramsList As ArrayList)
        Dim dt As DataTable
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try

            Dim cmdParms(paramsList.Count - 1) As SqlParameter
            Dim sqlParam As SqlParameter = Nothing

            Dim iCnt As Integer
            For iCnt = 0 To paramsList.Count - 1
                AddParams(paramsList(iCnt), sqlParam)
                cmdParms(iCnt) = sqlParam
            Next

            dt = sConn.GetDataTable(sql, cmdParms)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try
        Return dt
    End Function

    Public Shared Sub AddParams(strParamNameValue As String, ByRef sqlParam As SqlParameter)
        Dim keyValue As String() = strParamNameValue.Split("|")
        If keyValue.Length <> 2 Then
            Exit Sub
        End If
        sqlParam = New SqlParameter
        sqlParam.ParameterName = "@" & keyValue(0)
        sqlParam.SqlDbType = SqlDbType.NVarChar
        If keyValue(1).Trim.Length > 0 Then
            sqlParam.Value = keyValue(1)
        Else
            sqlParam.Value = DBNull.Value
        End If
    End Sub

    Public Shared Function DBNullToStr(ByVal obj As Object) As String
        If IsDBNull(obj) Then
            Return ""
        Else
            If obj Is Nothing Then
                Return ""
            Else
                Return obj.ToString().Trim()
            End If
        End If
    End Function

    Public Shared Function GetNewDataTable(ByVal o_dt As DataTable, ByVal strCondition As String, ByVal strSort As String) As DataTable
        Dim newdt As DataTable
        Dim o_arrDr As DataRow()
        newdt = o_dt.Clone
        o_arrDr = o_dt.Select(strCondition, strSort)
        For Each o_dr As DataRow In o_arrDr
            newdt.ImportRow(o_dr)
        Next
        Return newdt
    End Function

    '同步CNC数据
    Public Shared Sub ExecCNCUpdate(tvpn As String, wirepn As String)
        Try
            Dim strSQL As String = " exec [m_CNCUpdate_TerminalInfo_P] '{0}','{1}','{2}' "
            strSQL = String.Format(strSQL, tvpn, wirepn, VbCommClass.VbCommClass.UseId)

            DbOperateUtils.ExecSQL(strSQL)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ExecUCNCpdate", "ExecUCNCpdate", "RCard")
        End Try
    End Sub

    '同步CNC数据
    Public Shared Sub ExecCNCUpdateList(dt As DataTable)
        Try
            Dim strSQL As String
            Dim strSQLs As String = ""
            Dim tvpn As String
            Dim wirepn As String
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                tvpn = dt.Rows(rowIndex)("TVPN").ToString
                wirepn = dt.Rows(rowIndex)("WirePN").ToString
                strSQL = " exec [m_CNCUpdate_TerminalInfo_P] '{0}','{1}','{2}' "
                strSQL = String.Format(strSQL, tvpn, wirepn, VbCommClass.VbCommClass.UseId)
                strSQLs = strSQLs + vbNewLine + strSQL
            Next
            DbOperateUtils.ExecSQL(strSQLs)

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "ExecUCNCpdate", "ExecUCNCpdate", "RCard")
        End Try
    End Sub

    Public Shared Function GetPPartID(ByVal o_strPartID As String) As String
        Dim lsSQL As String = ""
        GetPPartID = ""
        lsSQL = " SELECT PAvcPart FROM dbo.m_PartContrast_t WHERE TAvcPart ='" & o_strPartID & "'" & _
                " AND TAvcPart<> PAvcPart "
        Using dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                GetPPartID = RCardComBusiness.DBNullToStr(dt.Rows(0).Item(0))
            Else
                GetPPartID = ""
            End If
        End Using
        Return GetPPartID

    End Function

    ''' <summary>
    ''' 执行TT/sap数据COMMIT
    ''' 共通化
    ''' </summary>
    ''' <param name="o_strSQL">执行SQL</param>
    ''' <remarks></remarks>
    Public Shared Sub ExecuteNonQuery(o_strSQL As String)
        If VbCommClass.VbCommClass.IsConSap = "Y" Then
            ' DBUtility.DbOracleHelperSQL.ExecuteSql(o_strSQL.ToString)
            OracleOperateUtils.ExecuteNonQuerySap(o_strSQL.ToString)
        Else
            OracleOperateUtils.ExecuteNonQuery(o_strSQL.ToString)
            ' DBUtility.DbOracleHelperSQL.ExecuteSql(o_strSQL.ToString)
        End If
    End Sub

    Public Shared Function getPartNumList(ByVal PartID As String, ByVal partStationID As String) As String
        Dim lsSQL As String = String.Empty
        getPartNumList = ""
        lsSQL = " DECLARE @EWPartNumbers NVARCHAR(max)='' " & _
                " SELECT  @EWPartNumbers=@EWPartNumbers+ISNULL(A.EWPartNumber,'')+','" & _
                " FROM m_RCardDPart_t  AS A   WHERE  PARTID ='" & PartID & "'" & _
                " AND Stationid='" & partStationID & "'" & _
               " SELECT @EWPartNumbers AS 'EWPartNumbers'"
        Using o_dt As DataTable = DbOperateUtils.GetDataTable(lsSQL)
            If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                getPartNumList = DbOperateUtils.DBNullToStr(o_dt.Rows(0).Item(0))
                If getPartNumList.Length > 0 Then
                    getPartNumList = getPartNumList.Substring(0, Len(getPartNumList) - 1)
                End If
            End If
        End Using
        Return getPartNumList
    End Function
End Class
