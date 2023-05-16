Imports SysBasicClass
Imports System.Data.SqlClient

Public Class MoComDB


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


    Public Shared Function GetErpData(strSQL As String) As DataTable
        Dim dt As DataTable
        Dim oracleConn As New OracleDb("")
        Try
            dt = oracleConn.ExecuteQuery(strSQL).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try
        Return dt
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

    Public Shared Function GetDataTable(ByVal sql As String) As DataTable
        Dim dt As DataTable

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
            dt = sConn.GetDataTable(sql)
        Catch ex As Exception
            Throw
        Finally
            If Not sConn Is Nothing Then
                sConn = Nothing
            End If
        End Try

        Return dt
    End Function

    Public Shared Function ExecSQL(ByVal sql As String) As String
        Dim result As String

        Dim sConn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try
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

    Public Shared Function GetDataTableOracle(ByVal sql As String) As DataTable
        Dim dt As DataTable

        Dim oracleConn As New SysBasicClass.OracleDb("")
        Try
            dt = oracleConn.ExecuteQuery(sql).Tables(0)
        Catch ex As Exception
            Throw
        Finally
            If Not oracleConn Is Nothing Then
                oracleConn = Nothing
            End If
        End Try

        Return dt
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

    Public Shared Sub Oracle_ExecuteNonQuery(ByVal sql As String)
        Dim oracleConn As New SysBasicClass.OracleDb("")
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
End Class
