Public Class SampleComDB

    Public Shared Function ExecSQL(ByVal sql As String) As String
        Dim result As String = String.Empty
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

End Class
