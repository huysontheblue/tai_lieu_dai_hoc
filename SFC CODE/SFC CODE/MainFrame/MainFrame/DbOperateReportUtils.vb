Imports System.Data.SqlClient
Imports UIHandler

Public Class DbOperateReportUtils

    Public Shared UserIdList As String = "AA," 'L042481,
    Public Shared UserId As String = "AAA"     'L042481     

    Public Shared IsOutPutLog As Boolean = False  '是否输出LOG

    Public Shared Function GetRowsCount(Sql As String) As Integer
        Dim iCnt As Integer = 0

        Dim sConn = New MainFrame.SysDataHandle.SysDataBaseClassReport

        Try
            WriteLog(Sql)
            iCnt = sConn.GetRowsCount(Sql)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                If (sConn.PubConnection.State = ConnectionState.Open) Then
                    sConn.PubConnection.Close()
                    sConn.PubConnection.Dispose()
                End If
                sConn = Nothing
            End If
        End Try

        Return iCnt
    End Function

    Public Shared Function GetDataTable(ByVal sql As String) As DataTable
        Dim dt As DataTable

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClassReport
        Try
            WriteLog(sql)
            dt = sConn.GetDataTable(sql)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                If (sConn.PubConnection.State = ConnectionState.Open) Then
                    sConn.PubConnection.Close()
                    sConn.PubConnection.Dispose()
                End If
                sConn = Nothing
            End If
        End Try

        Return dt
    End Function

    Public Shared Function GetDataSet(ByVal sql As String) As DataSet
        Dim ds As DataSet

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClassReport
        Try
            WriteLog(sql)
            ds = sConn.GetDataSet(sql)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                If (sConn.PubConnection.State = ConnectionState.Open) Then
                    sConn.PubConnection.Close()
                    sConn.PubConnection.Dispose()
                End If
                sConn = Nothing
            End If
        End Try

        Return ds
    End Function


    Public Shared Function GetDataTable(sql As String, paramsList As ArrayList) As System.Data.DataTable
        Dim dt As DataTable
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClassReport

        Try

            Dim cmdParms(paramsList.Count - 1) As SqlParameter
            Dim sqlParam As SqlParameter = Nothing

            Dim iCnt As Integer
            For iCnt = 0 To paramsList.Count - 1
                AddParams(paramsList(iCnt), sqlParam)
                cmdParms(iCnt) = sqlParam
            Next

            WriteLog(sql)

            dt = sConn.GetDataTable(sql, cmdParms)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                If (sConn.PubConnection.State = ConnectionState.Open) Then
                    sConn.PubConnection.Close()
                    sConn.PubConnection.Dispose()
                End If
                sConn = Nothing
            End If
        End Try
        Return dt
    End Function

    Public Shared Function GetDataTable(ByVal sql As String, ByVal ParamArray cmdParms As SqlParameter()) As System.Data.DataTable
        Dim dt As DataTable
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClassReport

        Try
            WriteLog(sql)

            dt = sConn.GetDataTable(sql, cmdParms)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                If (sConn.PubConnection.State = ConnectionState.Open) Then
                    sConn.PubConnection.Close()
                    sConn.PubConnection.Dispose()
                End If
                sConn = Nothing
            End If
        End Try
        Return dt
    End Function

    Public Shared Sub FillDataSetBySql(ByVal sql As String, ByRef ds As DataSet, _
             Optional ByVal parameters As IDataParameter() = Nothing, _
             Optional ByVal TableName As String = "")
        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClassReport

        Try

            WriteLog(sql)

            sConn.FillDataSetBySql(sql, ds, parameters)
        Catch ex As Exception
            Throw ex
        Finally
            If Not sConn Is Nothing Then
                If (sConn.PubConnection.State = ConnectionState.Open) Then
                    sConn.PubConnection.Close()
                    sConn.PubConnection.Dispose()
                End If
                sConn = Nothing
            End If
        End Try
    End Sub

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

    '输出LOG信息
    Private Shared Sub WriteLog(sql As String)

        Dim filaPath As String = AppDomain.CurrentDomain.BaseDirectory + "\SQLLOG\"

        If UserIdList.Contains(UserId) Then
            IsOutPutLog = True
        End If

        If IsOutPutLog = True Then
            Dim log As LogHelper = New LogHelper(IsOutPutLog, filaPath)

            log.WriteLog(sql)
        End If
    End Sub


End Class
