#Region "Imports區域"

Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.IO
Imports Microsoft.VisualBasic
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop


#End Region


#Region "數據庫數據處理-ERP服务器"

Namespace SysDataHandle

    Public Class SysDataBaseClassErp
        Private SysConnection As New SqlConnection
        Private SysCommand As New SqlCommand
        Shared m_SqlserverName As String
        Shared m_SqlserverIP As String
        Shared m_ServerFlag As String
        Shared m_SysCompany As String
        Shared m_IsSecurity As Boolean = False
        Shared m_ReportDBSqlserverName As String

#Region "公司名稱"
        Public Shared Property SysCompany() As String
            Get
                Return m_SysCompany
            End Get

            Set(ByVal Value As String)
                m_SysCompany = Value
            End Set
        End Property
#End Region

#Region "獲取服務器名"

        Public Shared Property ServerFlag()

            Get
                Return m_ServerFlag
            End Get
            Set(ByVal value)
                m_ServerFlag = value
            End Set

        End Property

#End Region

#Region "是否加密"

        Public Shared Property IsSecurity()

            Get
                Return m_IsSecurity
            End Get
            Set(ByVal value)
                m_IsSecurity = value
            End Set

        End Property

#End Region

#Region "獲取服務器名"

        Public Shared Property SqlserverName()

            Get
                Return m_SqlserverName
            End Get
            Set(ByVal value)
                m_SqlserverName = value
            End Set

        End Property

#End Region

#Region "獲取服務器IP"

        Public Shared Property SqlserverIP()

            Get
                Return m_SqlserverIP
            End Get
            Set(ByVal value)
                m_SqlserverIP = value
            End Set

        End Property

#End Region

#Region "連接數據庫"

        Public ReadOnly Property PubConnection() As SqlConnection

            Get
                '' SqlConnection.ClearPool(SysConnection)
                Try
                    If Not SysConnection Is Nothing Then
                        If SysConnection.State = ConnectionState.Open Then
                            PubConnection = SysConnection
                        Else
                            SysConnection = New SqlClient.SqlConnection
                            SysConnection.ConnectionString = GetConnString()
                            SysConnection.Open()
                            PubConnection = SysConnection
                        End If

                    Else
                        PubConnection = Nothing
                        PubConnection.Dispose()
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try

            End Get


        End Property

#End Region

#Region "Sql參數化"
        Private Shared Sub PrepareCommand(ByVal cmd As SqlCommand, ByVal trans As SqlTransaction, ByVal cmdParms As SqlParameter())

            If trans IsNot Nothing Then
                cmd.Transaction = trans
            End If
            cmd.CommandType = CommandType.Text
            If cmdParms IsNot Nothing Then
                For Each parm As SqlParameter In cmdParms
                    cmd.Parameters.Add(parm)
                Next
            End If
        End Sub
#End Region
#Region "解密字符串"
        Private Function Decrypt(ByVal pToDecrypt As String, ByVal sKey As String) As String
            Dim des As New Security.Cryptography.DESCryptoServiceProvider()


            Dim jiemi As New Jiami_and_Jiemi.JiaMiJieMi(sKey)
            ''sKey = jiemi.jiemiout()
            '把字符串放入byte数组
            Dim len As Integer
            len = pToDecrypt.Length / 2 - 1
            Dim inputByteArray(len) As Byte
            Dim x, i As Integer
            For x = 0 To len
                i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16)
                inputByteArray(x) = CType(i, Byte)
            Next
            '建立加密对象的密钥和偏移量，此值重要，不能修改
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey)
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey)
            Dim ms As New System.IO.MemoryStream()
            Dim cs As New Security.Cryptography.CryptoStream(ms, des.CreateDecryptor, Security.Cryptography.CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Encoding.Default.GetString(ms.ToArray)

        End Function
#End Region

#Region "連接數據字符串"
        ''' <summary>
        ''' 数据库密码全部使用加密字符串,从外部传入，为了不影响现有配置文件，目前写死的这些链接保留，以后新增SQL链接，不再修改MainFrame，直接从外部传入加密字符串  by hs ke 20140617
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetConnString() As String
            Dim tool As New SysCheckData.TextHandle()
            If m_SqlserverName.IndexOf("initial catalog") > 0 Then
                If m_SqlserverName.IndexOf("uid=") > 0 Then
                    IsSecurity = True
                End If
            End If
            If Not IsSecurity Then
                m_SqlserverIP = m_SqlserverName
                GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=024029068027066029014023030"
                Select Case m_SqlserverName
                    Case "172.17.32.12"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=050033068027066029014023030"
                        Exit Select
                    Case "172.17.32.122"
                        GetConnString = "data source=172.17.32.12;initial catalog=MESDataCenter; user id=sa; password=050033068027066029014023030"
                        Exit Select
                    Case "172.17.32.105"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=050033068027066029014023030"
                        Exit Select
                    Case "172.17.32.14"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=050033068027066029014023030"
                        Exit Select
                    Case "172.18.32.200"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=062012068009067000006000000017012"
                        Exit Select
                    Case "172.18.32.210"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=062012068009067000006000000017012"
                        Exit Select
                    Case "172.17.32.200", "."
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=069084080089028064" ''mesuser  Lt'songyy
                        Exit Select
                    Case "172.17.32.210"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=069084080089028064"
                        Exit Select
                    Case "172.18.20.75"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=054054068027066029014023030"
                        Exit Select
                    Case "172.17.32.106"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=038035068027066029014023030"
                        Exit Select
                    Case "172.17.17.102"
                        ' GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=062012068009067000006000000017012"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=069084080089028064"
                        Exit Select
                    Case "172.20.20.114"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=mesuser; password=016002068027066029014023030"
                        Exit Select
                End Select
            Else
                m_SqlserverIP = m_SqlserverName.Split(";")(0).Split("=")(1).ToString
                GetConnString = m_SqlserverName
            End If

            GetConnString = tool.GetOriginalConnString(GetConnString) + ";max pool size=500;Connection Timeout=8000"

            '''''''''''''''''''''************************2011 oxf *******************************************
            'GetConnString = "data source=" & m_SqlserverName & ConnStr



        End Function
#End Region

#Region "大数量批次插入"

        Public Function BulkCopy(ByVal ds As Object, ByVal DestinationTableName As String) As Boolean

            SysCommand.Connection = PubConnection
            Dim rv As Boolean = False
            Dim myTrans As SqlTransaction
            myTrans = SysConnection.BeginTransaction
            Dim bCopy As New SqlBulkCopy(SysCommand.Connection, SqlBulkCopyOptions.CheckConstraints, myTrans)
            bCopy.DestinationTableName = DestinationTableName
            'bCopy.ColumnMappings("","")
            Try
                bCopy.WriteToServer(ds)
                myTrans.Commit()
                rv = True
            Catch ex As Exception
                myTrans.Rollback()
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Finally
                bCopy.Close()
                myTrans.Dispose()
            End Try
            Return rv
        End Function

#End Region

#Region "獲取datareader"
        Public Function GetDataReader(ByVal SqlStr As String) As SqlDataReader

            SysCommand.Connection = PubConnection
            SysCommand.CommandTimeout = 999
            SysCommand.CommandText = Trim(SqlStr)
            ''SqlStr = Replace(SqlStr, "'", "''")
            Try
                Dim SysReader As SqlDataReader = SysCommand.ExecuteReader()
                GetDataReader = SysReader
                SysReader = Nothing
                SysCommand.Dispose()
                '' SysCommand.Connection.Dispose()
            Catch ex As Exception
                SysCommand.Dispose()
                Throw ex
            End Try

        End Function
        Public Function GetDataReader(ByVal SqlStr As String, ByVal ParamArray cmdParms As SqlParameter()) As SqlDataReader

            SysCommand.Connection = PubConnection
            SysCommand.CommandText = Trim(SqlStr)
            '' SysCommand.CommandTimeout = 1000
            Try
                Dim SysReader As SqlDataReader
                PrepareCommand(SysCommand, Nothing, cmdParms)
                SysReader = SysCommand.ExecuteReader()
                SysCommand.Parameters.Clear()
                GetDataReader = SysReader
                SysReader = Nothing
                SysCommand.Dispose()
                ''SysCommand.Connection.Dispose()
            Catch ex As Exception
                SysCommand.Dispose()
                ''  SysCommand.Connection.Dispose()
                Throw ex
            End Try

        End Function
#End Region



#Region "取得dataset數據集"
        Public Function GetDataSet(ByVal SqlStr As String) As DataSet

            Dim SysAdapter As New SqlDataAdapter
            Dim SysDataSet As New DataSet
            'SqlStr = Replace(SqlStr, "'", "''")
            SysCommand.Connection = PubConnection
            SysCommand.CommandTimeout = 999
            '' SysCommand.CommandTimeout = 3000
            SysCommand.CommandText = Trim(SqlStr)
            SysAdapter.SelectCommand = SysCommand
            SysAdapter.Fill(SysDataSet)
            GetDataSet = SysDataSet
            SysDataSet = Nothing
        End Function
        Public Function GetDataSet(ByVal SqlStr As String, ByVal TableName As String) As DataSet

            Dim SysAdapter As New SqlDataAdapter
            Dim SysDataSet As New DataSet

            SysCommand.Connection = PubConnection
            SysCommand.CommandText = Trim(SqlStr)
            SysAdapter.SelectCommand = SysCommand
            SysAdapter.Fill(SysDataSet, TableName)
            GetDataSet = SysDataSet
            SysDataSet = Nothing
        End Function

#End Region

#Region "取得datatable"
        Public Function GetDataTable(ByVal SqlStr As String) As System.Data.DataTable

            'SqlStr = Replace(SqlStr, "'", "''")
            Dim SysAdapter As New SqlDataAdapter(SqlStr, PubConnection)
            '' SysAdapter.SelectCommand.CommandTimeout = 3000
            SysCommand.CommandTimeout = 999
            Dim SysDataTable As New System.Data.DataTable
            SysAdapter.Fill(SysDataTable)

            GetDataTable = SysDataTable
            SysAdapter = Nothing
            SysDataTable = Nothing
            'SysAdapter.Dispose()
            ' SysDataTable.Dispose()

        End Function

        Public Function GetDataTable(ByVal SqlStr As String, ByVal ParamArray cmdParms As SqlParameter()) As System.Data.DataTable
            SysCommand.Connection = PubConnection
            SysCommand.CommandText = Trim(SqlStr)

            PrepareCommand(SysCommand, Nothing, cmdParms)
            Dim SysAdapter As New SqlDataAdapter(SysCommand)
            ''  SysAdapter.SelectCommand.CommandTimeout = 3000
            Dim SysDataTable As New System.Data.DataTable
            SysAdapter.Fill(SysDataTable)
            SysCommand.Parameters.Clear()
            GetDataTable = SysDataTable
            SysAdapter = Nothing
            '' SysDataTable = Nothing

        End Function
#End Region

#Region "執行SQL對數據的維護操作"

        Public Sub ExecSql(ByVal SqlStr As String)

            Dim sysExeTran As SqlTransaction
            SysCommand.Connection = PubConnection
            SysCommand.CommandTimeout = 999
            sysExeTran = SysConnection.BeginTransaction

            'SqlStr = Replace(SqlStr, "'", "''")

            Try
                SysCommand.Transaction = sysExeTran
                SysCommand.CommandText = Trim(SqlStr)
                SysCommand.ExecuteNonQuery()
                sysExeTran.Commit()
                '' SysCommand.Connection.Dispose()
                SysCommand.Dispose()
            Catch ex As Exception
                sysExeTran.Rollback()
                '' SysCommand.Connection.Dispose()
                SysCommand.Dispose()
                Throw ex
            End Try

        End Sub
        Public Sub ExecSql(ByVal SqlStr As String, ByVal ParamArray cmdParms As SqlParameter())

            Try
                SysCommand.Connection = PubConnection
                ''  SysCommand.CommandTimeout = 999
                SysCommand.CommandText = Trim(SqlStr)
                PrepareCommand(SysCommand, Nothing, cmdParms)
                SysCommand.ExecuteNonQuery()
                SysCommand.Parameters.Clear()
            Catch E As System.Data.SqlClient.SqlException
                Throw New Exception(E.Message)
            End Try

        End Sub
        '--ExecSql方法不支持多线程并发，特增加ExecuteNonQuery方法，代替ExecSql by hs ke 20140616
        Private Function OpenConn() As SqlConnection
            Dim connection As SqlConnection = Nothing
            connection = New SqlConnection(GetConnString())
            connection.Open()

            Return connection
        End Function
        ''' <summary>
        ''' 造一个存储过程的参数
        ''' </summary>
        ''' <param name="PName">参数名称</param>
        ''' <param name="PType">参数类型</param>
        ''' <param name="PValue">参数值</param>
        ''' <param name="PSize">参数SIZE</param>
        ''' <param name="PDirection">参数方向</param>
        ''' <param name="Scale">参数精确度</param>
        ''' <returns>返回参数</returns>
        Public Function MakeParam(ByVal PName As String, ByVal PType As SqlDbType, _
                        Optional ByVal PValue As Object = Nothing, _
                        Optional ByVal PSize As Int32 = 0, _
                        Optional ByVal PDirection As ParameterDirection = ParameterDirection.Input, _
                        Optional ByVal Scale As Integer = -1) As SqlParameter
            Dim Param As SqlParameter
            If PSize > 0 Then
                Param = New SqlParameter(PName, PType, PSize)
                If Scale >= 0 Then
                    Param.Scale = Scale
                End If
            Else
                Param = New SqlParameter(PName, PType)
            End If
            Param.Direction = PDirection



            If Not (PDirection = ParameterDirection.Output And PValue Is Nothing) Then
                If PDirection = ParameterDirection.Input And PValue Is Nothing Then
                    Param.Value = System.DBNull.Value
                Else
                    Param.Value = PValue
                End If

            Else
                Param.Value = System.DBNull.Value
            End If
            Return Param
        End Function
        ''' <summary>
        ''' 造一个存储过程的空白参数
        ''' </summary>
        ''' <param name="PName">参数名称</param>
        ''' <param name="PType">参数类型</param>
        ''' <param name="PSize">参数SIZE</param>
        ''' <param name="PDirection">参数方向</param>
        ''' <param name="Scale">参数精确度</param>
        ''' <returns>返回参数</returns>
        Public Function MakeParamN(ByVal PName As String, ByVal PType As SqlDbType, _
                        Optional ByVal PSize As Int32 = 0, _
                        Optional ByVal PDirection As ParameterDirection = ParameterDirection.Input, _
                        Optional ByVal Scale As Integer = -1) As SqlParameter
            Dim Param As SqlParameter
            If PSize > 0 Then
                Param = New SqlParameter(PName, PType, PSize)
                If Scale >= 0 Then
                    Param.Scale = Scale
                End If
            Else
                Param = New SqlParameter(PName, PType)
            End If
            Param.Direction = PDirection
            Return Param
        End Function
        ''' ＜summary＞
        ''' 执行SQL命令，并返回SqlDataReader
        ''' ＜/summary＞
        ''' ＜param name="sql"＞SQL命令＜/param＞
        ''' ＜param name="sqlReader"＞包含查询结果的SqlDataReader＜/param＞
        ''' ＜param name="parameters"＞SQL参数＜/param＞
        ''' ＜returns＞返回错误信息，为空表示执行成功＜/returns＞
        Public Function FillDataReaderBySql(ByVal sql As String, _
                        ByRef sqlReader As SqlDataReader, _
                        Optional ByRef parameters As IDataParameter() = Nothing) As String

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing

            Try
                connection = OpenConn()
                Command = New SqlCommand(sql, connection)
                Command.CommandTimeout = 3600

                '附加参数
                AttachParameters(Command, parameters)


                sqlReader = Command.ExecuteReader(CommandBehavior.CloseConnection)
                Return ""

            Catch ex As Exception
                Return ex.Message
            Finally
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function

        '直接传sql语句检查是否存在记录, 存在返回True ,否则False 
        Public Function CheckDataExistsBySql(ByVal sql As String, _
                Optional ByRef parameters As IDataParameter() = Nothing) As Boolean

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            Dim sqlReader As SqlDataReader
            Try
                connection = OpenConn()
                Command = New SqlCommand(sql, connection)
                Command.CommandTimeout = 3600

                '附加参数
                AttachParameters(Command, parameters)

                sqlReader = Command.ExecuteReader(CommandBehavior.CloseConnection)
                If sqlReader.Read Then
                    sqlReader.Close() : Return True
                Else
                    sqlReader.Close() : Return False
                End If

            Catch ex As Exception
                Return ex.Message
            Finally
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function
        '2010-10-26

        ''' ＜summary＞
        ''' 执行存储过程，传入参数值的数组，返回SqlDataReader
        ''' ＜/summary＞
        ''' ＜param name="spName"＞存储过程名＜/param＞
        ''' ＜param name="sqlReader"＞包含查询结果的SqlDataReader＜/param＞
        ''' ＜param name="parameterValues"＞参数值＜/param＞
        ''' ＜returns＞返回错误信息，为空表示执行成功＜/returns＞
        Public Function FillDataReaderByProc(ByVal spName As String, _
                    ByRef sqlReader As SqlDataReader, _
                    ByVal ParamArray parameterValues() As Object) As String

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            Dim commandParameters As SqlParameter() = Nothing
            Dim _sqlConnectionString As String = GetConnString()
            Try
                If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
                    '获取存储过程的所有参数
                    commandParameters = GetSpParameterSet(_sqlConnectionString, spName)

                    '为SP参数分配值
                    AssignParameterValues(commandParameters, parameterValues)
                End If


                connection = New SqlConnection(_sqlConnectionString)
                Command = New SqlCommand(spName, connection)
                Command.CommandType = CommandType.StoredProcedure
                Command.CommandTimeout = 3600
                AttachParameters(Command, commandParameters)


                connection.Open()
                sqlReader = Command.ExecuteReader(CommandBehavior.CloseConnection)
                Return ""

            Catch ex As Exception
                Return ex.Message

            Finally
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function
        ''' ＜summary＞
        ''' 执行存储，传入SQL参数，并返回SqlDataReader
        ''' ＜/summary＞
        ''' ＜param name="spName"＞存储过程名＜/param＞
        ''' ＜param name="sqlReader"＞包含查询结果的SqlDataReader＜/param＞
        ''' ＜param name="parameters"＞存储过程SQL参数＜/param＞
        ''' ＜returns＞返回错误信息，为空表示执行成功＜/returns＞
        Public Function FillDataReaderByProc(ByVal spName As String, _
                    ByRef sqlReader As SqlDataReader, _
                    Optional ByVal parameters As IDataParameter() = Nothing) As String

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            Dim commandParameters As SqlParameter() = Nothing

            Try

                connection = OpenConn()
                Command = New SqlCommand(spName, connection)
                Command.CommandType = CommandType.StoredProcedure
                Command.CommandTimeout = 3600
                AttachParameters(Command, parameters)


                sqlReader = Command.ExecuteReader(CommandBehavior.CloseConnection)
                Return ""

            Catch ex As Exception
                Return ex.Message

            Finally
                Command.Dispose()
            End Try
        End Function

        ''' ＜summary＞
        ''' 执行SQL命令，并返回DataSeet
        ''' ＜/summary＞
        ''' ＜param name="sql"＞SQL命令＜/param＞
        ''' ＜param name="ds"＞包含查询结果的DATASET＜/param＞
        ''' ＜param name="parameters"＞SQL参数＜/param＞
        ''' ＜param name="TableName"＞DATASET TABLENAME＜/param＞
        ''' ＜returns＞返回错误信息，为空表示执行成功＜/returns＞
        Public Function FillDataSetBySql(ByVal sql As String, ByRef ds As DataSet, _
                Optional ByVal parameters As IDataParameter() = Nothing, _
                Optional ByVal TableName As String = "") As String

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Try
                connection = OpenConn()
                Command = New SqlCommand(sql, connection)
                Command.CommandTimeout = 3600

                '附加参数
                AttachParameters(Command, parameters)

                da = New SqlDataAdapter(Command)
                If (TableName.Length <> 0) Then
                    da.Fill(ds, TableName)
                Else
                    da.Fill(ds)
                End If
                Return ""

            Catch ex As Exception
                Return ex.Message

            Finally
                If Not da Is Nothing Then da.Dispose()
                If Not connection Is Nothing AndAlso connection.State = ConnectionState.Open Then connection.Close()
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function

        ''' ＜summary＞
        ''' 执行存储过程，传入参数值的数组，并返回DataSet
        ''' ＜/summary＞
        ''' ＜param name="ProcName"＞存储过程名称＜/param＞
        ''' ＜param name="ds"＞包含查询结果的DATASET＜/param＞
        ''' ＜param name="parameterValues"＞参数值＜/param＞
        ''' ＜param name="TableName"＞DATASET TABLENAME＜/param＞
        ''' ＜returns＞返回错误信息，为空表示执行成功＜/returns＞
        Public Function FillDataSetByProc(ByVal ProcName As String, ByRef ds As DataSet, _
                    ByVal TableName As String, _
                    ByVal ParamArray parameterValues() As Object) As String

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim commandParameters As SqlParameter() = Nothing
            Dim _sqlConnectionString As String = GetConnString()
            Try
                If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
                    '获取存储过程的所有参数
                    commandParameters = GetSpParameterSet(_sqlConnectionString, ProcName)

                    '为SP参数分配值
                    AssignParameterValues(commandParameters, parameterValues)
                End If


                connection = New SqlConnection(_sqlConnectionString)
                Command = New SqlCommand(ProcName, connection)
                Command.CommandType = CommandType.StoredProcedure
                Command.CommandTimeout = 3600
                AttachParameters(Command, commandParameters)

                da = New SqlDataAdapter(Command)
                If (TableName.Length <> 0) Then
                    da.Fill(ds, TableName)
                Else
                    da.Fill(ds)
                End If

                Return ""

            Catch ex As Exception
                Return ex.Message
            Finally
                If Not da Is Nothing Then da.Dispose()
                If Not connection Is Nothing AndAlso connection.State = ConnectionState.Open Then connection.Close()
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function

        ''' ＜summary＞
        ''' 执行存储过程，传入SQL参数，并返回DataSet
        ''' ＜/summary＞
        ''' ＜param name="ProcName"＞存储过程名称＜/param＞
        ''' ＜param name="ds"＞包含查询结果的DATASET＜/param＞
        ''' ＜param name="parameters"＞存储过程SQL参数＜/param＞
        ''' ＜param name="TableName"＞DATASET TABLENAME＜/param＞
        ''' ＜returns＞返回错误信息，为空表示执行成功＜/returns＞
        Public Function FillDataSetByProc(ByVal ProcName As String, ByRef ds As DataSet, _
                    Optional ByVal parameters As IDataParameter() = Nothing, _
                    Optional ByVal TableName As String = "") As String

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Dim commandParameters As SqlParameter() = Nothing

            Try
                connection = OpenConn()
                'connection = New SqlConnection(_sqlConnectionString)
                Command = New SqlCommand(ProcName, connection)
                Command.CommandType = CommandType.StoredProcedure
                Command.CommandTimeout = 3600
                AttachParameters(Command, parameters)

                da = New SqlDataAdapter(Command)
                If (TableName.Length <> 0) Then
                    da.Fill(ds, TableName)
                Else
                    da.Fill(ds)
                End If

                Return ""

            Catch ex As Exception
                Return ex.Message
            Finally
                If Not da Is Nothing Then da.Dispose()
                If Not connection Is Nothing AndAlso connection.State = ConnectionState.Open Then connection.Close()
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function
        Public Function FillDatasetBySql_ForCurPage(ByVal strSql As String, _
                   ByRef DS As DataSet, _
                   ByVal TableName As String, _
                   ByVal OrderFld As String, _
                   ByRef total_pages As Integer, _
                   ByRef items_count As Integer, _
                   Optional ByVal current_page As Integer = 1, _
                   Optional ByVal rows_per_page As Int16 = 10) As String

            If rows_per_page = 0 Then Return "每页显示行数不能设置为[0]!"

            Dim start_item As Integer
            items_count = GetRowsCount(strSql)
            total_pages = IIf(items_count Mod rows_per_page = 0, items_count / rows_per_page, Int(items_count / rows_per_page) + 1)


            '计算此页中从第几个开始显示
            '组合SQL语句
            Dim _sbSql As StringBuilder = New StringBuilder()
            Dim _Sql As StringBuilder = New StringBuilder()
            If strSql.Length > 6 AndAlso Left(strSql, 6).ToLower() = "select" Then
                _sbSql.Append(" select ROW_NUMBER() OVER (" + OrderFld + ") as AutoRowId, ")
                _sbSql = _sbSql.Append(strSql.Substring(7, strSql.Length - 7))
            End If
            start_item = rows_per_page * (current_page - 1)
            _Sql.Append("select * from ( ").Append(_sbSql).Append(" ) as T  where T.AutoRowId >= " & (start_item + 1).ToString & " AND T.AutoRowId <= " & (start_item + rows_per_page).ToString)

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            Dim da As SqlDataAdapter = Nothing
            Try
                connection = OpenConn()
                'connection = New SqlConnection(_sqlConnectionString)
                Command = New SqlCommand(_Sql.ToString, connection)
                Command.CommandTimeout = 3600

                da = New SqlDataAdapter(Command)
                If (TableName.Length <> 0) Then
                    da.Fill(DS, TableName)
                Else
                    da.Fill(DS)
                End If
                Return ""

            Catch ex As Exception
                Return ex.Message
            Finally
                If Not da Is Nothing Then da.Dispose()
                If Not connection Is Nothing AndAlso connection.State = ConnectionState.Open Then connection.Close()
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function
        Public Function FillDataReaderBySql_ForCurPage(ByVal strSql As String, _
                   ByRef sqlReader As SqlDataReader, _
                   ByVal OrderFld As String, _
                   ByRef total_pages As Integer, _
                   ByRef items_count As Integer, _
                   Optional ByVal current_page As Integer = 1, _
                   Optional ByVal rows_per_page As Int16 = 10) As String

            If rows_per_page = 0 Then Return "每页显示行数不能设置为[0]!"

            Dim start_item As Integer
            items_count = GetRowsCount(strSql)
            total_pages = IIf(items_count Mod rows_per_page = 0, items_count / rows_per_page, Int(items_count / rows_per_page) + 1)


            '计算此页中从第几个开始显示
            '组合SQL语句
            Dim _sbSql As StringBuilder = New StringBuilder()
            Dim _Sql As StringBuilder = New StringBuilder()
            If strSql.Length > 6 AndAlso Left(strSql, 6).ToLower() = "select" Then
                _sbSql.Append(" select ROW_NUMBER() OVER (" + OrderFld + ") as AutoRowId, ")
                ' _sbSql.Append(" ," & items_count.ToString & " AS items_count")
                ' _sbSql.Append("," & current_page.ToString & " AS current_page ")
                '_sbSql.Append("," & total_pages.ToString & " AS total_pages " & ",")
                _sbSql = _sbSql.Append(strSql.Substring(7, strSql.Length - 7))
            End If
            start_item = rows_per_page * (current_page - 1)
            _Sql.Append("select * from ( ").Append(_sbSql).Append(" ) as T  where T.AutoRowId >= " & (start_item + 1).ToString & " AND T.AutoRowId <= " & (start_item + rows_per_page).ToString)

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            Try
                connection = OpenConn()
                Command = New SqlCommand(_Sql.ToString, connection)
                Command.CommandTimeout = 3600

                sqlReader = Command.ExecuteReader(CommandBehavior.CloseConnection)
                Return ""
            Catch ex As Exception
                sqlReader = Nothing
                Return ex.Message
            Finally
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function
        ''' <summary>
        ''' 获取总页数
        ''' </summary>
        ''' <param name="strSql">SQL语句</param>
        ''' <returns>返回总页数</returns>
        Public Function GetRowsCount(ByVal strSql As String) As Integer
            Dim DataReader As SqlDataReader = Nothing
            Dim _rtnVal As String = ""
            Dim _strSql As String = "SELECT COUNT(*) as items_count FROM (" & strSql & ") tbl"
            Dim items_count As Integer

            _rtnVal = FillDataReaderBySql(_strSql, DataReader)
            If _rtnVal.Length <> 0 Then
                Throw New Exception(_rtnVal)
            End If

            If DataReader.Read Then
                items_count = DataReader.Item("items_count")
            Else
                items_count = 0
            End If
            DataReader.Close()
            Return items_count
        End Function
        Private Sub PrepareCommand(ByVal command As SqlCommand, _
                                          ByVal connection As SqlConnection, _
                                          ByVal transaction As SqlTransaction, _
                                          ByVal commandType As CommandType, _
                                          ByVal commandText As String, _
                                          ByVal commandParameters() As SqlParameter)

            'if the provided connection is not open, we will open it            
            'associate the connection with the command
            command.Connection = connection

            'set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText

            'if we were provided a transaction, assign it.
            If Not (transaction Is Nothing) Then
                command.Transaction = transaction
            End If

            'set the command type
            command.CommandType = commandType
            command.CommandTimeout = 3600

            '附加参数
            If Not (commandParameters Is Nothing) Then
                AttachParameters(command, commandParameters)
            End If
            command.Parameters.Add(New SqlParameter("ReturnValue", _
                                        SqlDbType.Int, _
                                        4, _
                                        ParameterDirection.ReturnValue, _
                                        False, _
                                        0, _
                                        0, _
                                        String.Empty, _
                                        DataRowVersion.Default, _
                                        Nothing))

            Return
        End Sub 'PrepareCommand
        ''' <summary>
        ''' 转换DBNULL为NOTHING
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConvertNullToNothing(ByVal FieldValue As Object) As Object
            If FieldValue.GetType.FullName = "System.DBNull" Then
                Return Nothing
            Else
                Return FieldValue
            End If
        End Function
        Private Sub AttachParameters(ByVal command As SqlCommand, ByVal commandParameters() As SqlParameter)
            If commandParameters Is Nothing Then Exit Sub
            Dim p As SqlParameter
            For Each p In commandParameters
                'check for derived output value with no value assigned
                If p.Direction = ParameterDirection.InputOutput And p.Value Is Nothing Then
                    p.Value = Nothing
                End If
                command.Parameters.Add(p)
            Next p
        End Sub
        Private Shared Sub AssignParameterValues(ByVal commandParameters() As SqlParameter, ByVal parameterValues() As Object)

            Dim i As Short
            Dim j As Short

            If (commandParameters Is Nothing) And (parameterValues Is Nothing) Then
                'do nothing if we get no data
                Return
            End If

            ' we must have the same number of values as we pave parameters to put them in
            If commandParameters.Length <> parameterValues.Length Then
                Throw New ArgumentException("Parameter count does not match Parameter Value count.")
            End If

            'value array
            j = commandParameters.Length - 1
            For i = 0 To j
                commandParameters(i).Value = parameterValues(i)
            Next

        End Sub
        Private paramCache As Hashtable = Hashtable.Synchronized(New Hashtable())
        Public Overloads Function GetSpParameterSet(ByVal connectionString As String, ByVal spName As String) As SqlParameter()
            Return GetSpParameterSet(connectionString, spName, False)
        End Function 'GetSpParameterSet 
        Public Overloads Function GetSpParameterSet(ByVal connectionString As String, _
                                                           ByVal spName As String, _
                                                           ByVal includeReturnValueParameter As Boolean) As SqlParameter()

            Dim cachedParameters() As SqlParameter
            Dim hashKey As String

            hashKey = connectionString + ":" + spName + IIf(includeReturnValueParameter = True, ":include ReturnValue Parameter", "")

            cachedParameters = CType(paramCache(hashKey), SqlParameter())

            If (cachedParameters Is Nothing) Then
                paramCache(hashKey) = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter)
                cachedParameters = CType(paramCache(hashKey), SqlParameter())

            End If

            Return CloneParameters(cachedParameters)

        End Function
        Private Function DiscoverSpParameterSet(ByVal connectionString As String, _
                                                       ByVal spName As String, _
                                                       ByVal includeReturnValueParameter As Boolean, _
                                                       ByVal ParamArray parameterValues() As Object) As SqlParameter()

            Dim cn As New SqlConnection(connectionString)
            Dim cmd As SqlCommand = New SqlCommand(spName, cn)
            Dim discoveredParameters() As SqlParameter

            Try
                cn.Open()
                cmd.CommandType = CommandType.StoredProcedure
                SqlCommandBuilder.DeriveParameters(cmd)
                If Not includeReturnValueParameter Then
                    cmd.Parameters.RemoveAt(0)
                End If

                discoveredParameters = New SqlParameter(cmd.Parameters.Count - 1) {}
                cmd.Parameters.CopyTo(discoveredParameters, 0)
            Finally
                cmd.Dispose()
                cn.Dispose()

            End Try

            Return discoveredParameters

        End Function 'DiscoverSpParameterSet

        'deep copy of cached SqlParameter array
        Private Function CloneParameters(ByVal originalParameters() As SqlParameter) As SqlParameter()

            Dim i As Short
            Dim j As Short = originalParameters.Length - 1
            Dim clonedParameters(j) As SqlParameter

            For i = 0 To j
                clonedParameters(i) = CType(CType(originalParameters(i), ICloneable).Clone, SqlParameter)
            Next

            Return clonedParameters
        End Function 'CloneParameters
        Public Function ExecuteNonQuery(ByVal sql As String, _
                  Optional ByVal parameters As IDataParameter() = Nothing) As String
            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing

            Try
                connection = OpenConn()
                Command = New SqlCommand()
                PrepareCommand(Command, connection, Nothing, CommandType.Text, sql, parameters)

                Command.ExecuteNonQuery()
                Return ""

            Catch ex As Exception
                Return ex.Message
            Finally
                If Not connection Is Nothing AndAlso connection.State = ConnectionState.Open Then connection.Close()
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function
        ''' ＜summary＞
        ''' 执行存储过程，只需传入参数值的数组
        ''' ＜/summary＞
        ''' ＜param name="spName"＞存储过程名＜/param＞
        ''' ＜param name="parameterValues"＞参数值＜/param＞
        ''' ＜returns＞返回错误信息，为空表示执行成功＜/returns＞
        Public Function ExecuteNonQureyByProc(ByVal spName As String, _
                         ByVal commandParameters As SqlParameter()) As String

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            'Dim commandParameters As SqlParameter() = parameters
            Dim _sqlConnectionString As String = GetConnString()
            Try
                'If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
                '    '获取存储过程的所有参数
                '    commandParameters = GetSpParameterSet(_sqlConnectionString, spName)

                '    '为SP参数分配值
                '    AssignParameterValues(commandParameters, parameterValues)
                'End If

                connection = OpenConn()
                Command = New SqlCommand()
                PrepareCommand(Command, connection, Nothing, CommandType.StoredProcedure, spName, commandParameters)

                Command.ExecuteNonQuery()

                Return ""

            Catch ex As Exception
                Return ex.Message
            Finally
                If Not connection Is Nothing AndAlso connection.State = ConnectionState.Open Then connection.Close()
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function

        ''' ＜summary＞
        ''' 执行存储过程，只需传入参数值的数组
        ''' ＜/summary＞
        ''' ＜param name="spName"＞存储过程名＜/param＞
        ''' ＜param name="parameterValues"＞参数值＜/param＞
        ''' ＜returns＞返回错误信息，为空表示执行成功＜/returns＞
        Public Function ExecuteProcWithErrMsg(ByVal spName As String, ByRef ErrMsg As String, ByVal commandParameters As SqlParameter()) As String

            Dim connection As SqlConnection = Nothing
            Dim Command As SqlCommand = Nothing
            'Dim commandParameters As SqlParameter() = Nothing
            Dim _sqlConnectionString As String = GetConnString()
            Try
                'If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
                '    '获取存储过程的所有参数
                '    commandParameters = GetSpParameterSet(_sqlConnectionString, spName)

                '    '为SP参数分配值
                '    AssignParameterValues(commandParameters, parameterValues)
                'End If

                connection = OpenConn()
                Command = New SqlCommand()
                PrepareCommand(Command, connection, Nothing, CommandType.StoredProcedure, spName, commandParameters)

                Command.ExecuteNonQuery()
                '获取存储过程中返回的提示信息
                ErrMsg = Command.Parameters("@ErrMsg").Value
                Return ""

            Catch ex As Exception
                Return ex.Message
            Finally
                If Not connection Is Nothing AndAlso connection.State = ConnectionState.Open Then connection.Close()
                If Not Command Is Nothing Then Command.Dispose()
            End Try
        End Function
        '--ExecSql方法不支持多线程并发，特增加ExecuteNonQuery方法，代替ExecSql by hs ke 20140616

#End Region

#Region "帶參數的SQL處理"
        Public Sub ExecSqlAddParameter(ByVal Sqlstr As String, ByVal Para As SqlParameter())

            Dim sysExeTran As SqlTransaction
            SysCommand.Connection = PubConnection
            '' SysCommand.CommandTimeout = 999
            sysExeTran = SysConnection.BeginTransaction
            Try
                SysCommand.Parameters.Clear()
                SysCommand.Transaction = sysExeTran
                SysCommand.CommandText = Trim(Sqlstr)
                '加入參數
                For Each parameter As SqlParameter In Para
                    SysCommand.Parameters.Add(parameter)
                Next

                SysCommand.ExecuteNonQuery()
                sysExeTran.Commit()
            Catch ex As Exception
                sysExeTran.Rollback()
            End Try

        End Sub
#End Region


    End Class

End Namespace

#End Region





