#Region "Imports區域"

Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.IO
Imports Microsoft.VisualBasic
'Imports Microsoft.Office.Core
'Imports Microsoft.Office.Interop
'Imports SFCSUpdate.MainFrame

''Imports VbBarClass

#End Region
''系統版本、程序模塊
''Public Structure SysUserLog

''    Dim PModule As String
''    Dim Version As String
''    Dim EmpHomePhone As String

''End Structure

#Region "數據庫數據處理"

Namespace DbClass.SysDataHandle

    Public Class SysDataBaseClass

        Private SysConnection As New SqlConnection
        Private SysCommand As New SqlCommand
        Shared m_SqlserverName As String
        Shared m_SqlserverIP As String
        Shared m_ServerFlag As String
        Shared m_SysCompany As String
        Shared m_IsSecurity As Boolean = False

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

        'Public Shared Sub ClearPool(ByVal connection As SqlConnection)
        '    '用法
        '    Dim connection As SqlConnection
        '    SqlConnection.ClearPool(connection)

        'End Sub

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

        '解密字符串
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
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=069084080089028064"
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
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=062012068009067000006000000017012"
                        Exit Select
                    Case "192.168.20.123\MESDB"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=063032055079094028007009030017"
                        Exit Select
                    Case "sql2012agl01.luxshare.com.cn"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=mes; password=016002068027066029014023030"
                        Exit Select
                    Case "127.0.0.1"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=023020"
                        Exit Select
                    Case "192.168.20.247"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=000000016028010000006000000017012"
                        Exit Select
                    Case "172.20.20.155"
                        GetConnString = "data source=" & m_SqlserverName & ";initial catalog=MESDB; user id=sa; password=048002068027066029014023030"
                        Exit Select
                End Select
            Else
                m_SqlserverIP = m_SqlserverName.Split(";")(0).Split("=")(1).ToString
                GetConnString = m_SqlserverName
            End If

            GetConnString = tool.GetOriginalConnString(GetConnString) + ";min pool size=10;max pool size=500;Connection Timeout=8000"

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
#End Region

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


#Region "校驗用戶登錄帳號"

        Public Function CheckUser() As Boolean

            Dim CheckRead As SqlDataReader
            Dim PassString As String
            Dim LoginClass As New SysCheckData.TextHandle
            SysCheckData.SysMessageClass.UsePassWord = LoginClass.EnCryptPassword(SysCheckData.SysMessageClass.UsePassWord)

            PassString = SysCheckData.SysMessageClass.UsePassWord
            CheckRead = Me.GetDataReader("select distinct a.* from m_Users_t a join m_userright_t b on a.userid=b.userid where a.userid='" & SysCheckData.SysMessageClass.UseId & "' and a.usey='1'")
            If Not CheckRead.HasRows Then
                If SysCheckData.SysMessageClass.Language = "big5" Then
                    Dim UserMessage As New Exception("用戶名不正確或無權限")
                    SysCheckData.SysMessageClass.ErrforUser = UserMessage.Message.ToString
                Else
                    Dim UserMessage As New Exception("* UserID Wrong Or no right")
                    SysCheckData.SysMessageClass.ErrforUser = UserMessage.Message.ToString
                End If

                CheckUser = False
                CheckRead = Nothing
                Exit Function
            End If
            CheckRead.Close()
            CheckRead = Me.GetDataReader("select distinct a.* from m_Users_t a join m_userright_t b on a.userid=b.userid  where a.userid='" & SysCheckData.SysMessageClass.UseId & "' and a.password='" & PassString & "' and a.usey='1'")
            If Not CheckRead.HasRows Then
                If SysCheckData.SysMessageClass.Language = "big5" Then
                    Dim UserMessage As New Exception("密碼不正確或無權限")
                    SysCheckData.SysMessageClass.ErrForPass = UserMessage.Message.ToString
                Else
                    Dim UserMessage As New Exception("* Passwrod Wrong Or no right")
                    SysCheckData.SysMessageClass.ErrForPass = UserMessage.Message.ToString
                End If
                CheckUser = False
                CheckRead.Close()
                Exit Function
            Else
                CheckRead.Read()
                SysCheckData.SysMessageClass.UseName = CheckRead.GetString(1)
                SysCheckData.SysMessageClass.UseDeptid = CheckRead.GetString(4)
                SysCheckData.SysMessageClass.FactoryId = CheckRead("FactoryId").ToString
            End If

            CheckRead.Close()
            CheckUser = True

        End Function
#End Region

#Region "根據語言類型(處理English)處理窗體對話框屬性"

        ''  Public Function TransDioToEnglish(ByVal FromName As Form, ByVal TransObjectName As String) As String

        Public Sub TransDioToEnglish(ByVal FromName As Form, ByRef ArgStr As String)

            'Dim LoadReader As SqlDataReader
            'Dim SqlBuilderString As New StringBuilder
            'Dim TransDioToEngStr As String
            'Dim I As Integer
            'I = 0
            'TransDioToEngStr = ""
            'SqlBuilderString.Append("select * from m_SysapObj_t where ApObjType='2' and apid in (")
            'SqlBuilderString.Append("select apid from m_SysapForm_t where Apformid='" & FromName.Name & "')")
            'LoadReader = Me.GetDataReader(SqlBuilderString.ToString)
            'SqlBuilderString.Remove(0, SqlBuilderString.Length)
            'While LoadReader.Read()

            '    If I = 0 Then
            '        SqlBuilderString.Append(LoadReader("enname"))
            '    Else
            '        SqlBuilderString.Append("|" & LoadReader("enname"))
            '    End If
            '    'Exit While
            '    'End If
            '    I = I + 1
            'End While
            'ArgStr = SqlBuilderString.ToString
            ' ''Array.Copy(ArgCopy, Arg, UBound(ArgCopy))
            ' ''TransDioToEnglish = TransDioToEngStr
            ' ''Return TransDioToEnglish
            'LoadReader.Close()
            'SqlBuilderString = Nothing

        End Sub

#End Region

#Region "根據語言類型(處理English)處理窗體對象屬性"

        Public Sub LoadObjectAttributes(ByVal ParentControl As Control, ByVal ControlName As String, ByVal ControlText As String)

            'Dim MyControl As Control

            'For Each MyControl In ParentControl.Controls

            '    If UCase(MyControl.Name).Trim = UCase(ControlName).ToString Then
            '        MyControl.Text = ControlText
            '        Exit For
            '    End If
            '    If TypeOf MyControl Is ToolStrip Then
            '        Dim TempControl As ToolStrip
            '        TempControl = MyControl
            '        Dim FormStripButton As ToolStripItem
            '        For Each FormStripButton In TempControl.Items
            '            If UCase(FormStripButton.Name) = UCase(ControlName).ToString Then
            '                FormStripButton.ToolTipText = ControlText
            '                FormStripButton.Text = ControlText
            '                Exit Sub
            '            End If
            '        Next
            '    End If
            '    If MyControl.HasChildren Then
            '        LoadObjectAttributes(MyControl, ControlName, ControlText)
            '    End If
            'Next

        End Sub

        Public Sub GetControlEnglishText(ByVal FromName As Form)

            'Dim LoadReader As SqlDataReader
            'Dim SqlBuilderString As New StringBuilder

            'SqlBuilderString.Append("select * from m_SysapObj_t where apid in (")
            'SqlBuilderString.Append("select apid from m_SysapForm_t where apFormid='" & FromName.Name & "')")

            'LoadReader = GetDataReader(SqlBuilderString.ToString)
            'While LoadReader.Read()
            '    LoadObjectAttributes(FromName, LoadReader("apObjid"), LoadReader("enname"))
            'End While
            'LoadReader.Close()
            'SqlBuilderString = Nothing

        End Sub

#End Region

#Region "讀取各個窗體控件權限"
        Public Sub GetControlright(ByVal FromName As Form)

            Dim Sdbc As New DbClass.SysDataHandle.SysDataBaseClass
            Dim RightDr As SqlDataReader

            RightDr = Sdbc.GetDataReader("select ButtonID from m_Logtree_t a left join m_userright_t b on a.Tkey=b.tkey where b.userid='" & SysCheckData.SysMessageClass.UseId & "' AND a.Formid=(select apid from m_SysapForm_t where Apformid='" & FromName.Name & "' ) and a.listy='N'")
            'FormRead = PubClass.FormBtset("select Ttext from E_UserRight_t where userid='sz19096'and listy= 'Y'and Tparent= (select Tkey from E_UserRight_t where Ttext= '入庫單維護'and userid='sz19096' )")
            If RightDr.HasRows Then
                While RightDr.Read
                    Setright(FromName, RightDr("ButtonID"))
                End While
            End If
            RightDr.Close()

        End Sub

        Private Sub Setright(ByVal ParentControl As Control, ByVal ControlName As String)

            Dim MyControl As Control

            For Each MyControl In ParentControl.Controls

                If UCase(MyControl.Name).Trim = UCase(ControlName).ToString Then
                    MyControl.Enabled = True
                    Exit For
                End If
                If TypeOf MyControl Is ToolStrip Then
                    Dim TempControl As ToolStrip
                    TempControl = MyControl
                    Dim FormStripButton As ToolStripItem
                    For Each FormStripButton In TempControl.Items
                        If TypeOf FormStripButton Is System.Windows.Forms.ToolStripButton Then

                            If UCase(FormStripButton.Name) = UCase(ControlName).ToString Then
                                FormStripButton.Tag = "YES"
                                FormStripButton.Enabled = True
                                Exit For
                            End If
                        End If
                    Next
                End If
                If MyControl.HasChildren Then
                    Setright(MyControl, ControlName)
                End If
            Next
        End Sub
#End Region

        '#Region "菜單的語言設置"

        '        Public Sub LoadMenuAttributes(ByVal MenuName As MenuStrip, ByVal MenuItems As ToolStripItemCollection)

        '            Dim LoadReader As SqlDataReader
        '            Dim SqlBuilderString As New StringBuilder
        '            SqlBuilderString.Append("select * from m_SysapObj_t where apid in (")
        '            SqlBuilderString.Append("select apid from m_SysapForm_t where apFormid='" & MenuName.Name & "')")
        '            LoadReader = Me.GetDataReader(SqlBuilderString.ToString)

        '            While LoadReader.Read()
        '                GetMenuItemName(MenuName, MenuItems, LoadReader("apObjid"), LoadReader("enname"))
        '            End While
        '            LoadReader.Close()

        '            SqlBuilderString = Nothing
        '        End Sub

        '        Private Sub GetMenuItemName(ByVal MenuName As MenuStrip, ByVal MenuItems As ToolStripItemCollection, ByVal MenuText As String, ByVal MenuTextEnglish As String)

        '            Dim MyMenuItem As ToolStripItem
        '            For Each MyMenuItem In MenuItems
        '                If UCase(MyMenuItem.Name).Trim = UCase(MenuText).ToString Then
        '                    MyMenuItem.Text = MenuTextEnglish
        '                End If
        '                If TypeOf MyMenuItem Is System.Windows.Forms.ToolStripMenuItem Then
        '                    GetMenuItemName(MenuName, CType(MyMenuItem, ToolStripMenuItem).DropDownItems, MenuText, MenuTextEnglish)
        '                End If
        '            Next

        '        End Sub
        '#End Region

        Public Sub LoadDataToExcel(ByVal ReportName As String, ByVal GridControl As DataGridView, Optional ByVal ConditionStr As String = "")



        End Sub


#Region "匯出Excel"
        '''' <summary>
        '''' 
        '''' </summary>
        '''' <param name="Sqlstring"> sql語句</param>
        '''' <param name="ReportName">報表名字</param>
        '''' <param name="ConditionStr">查詢條件</param>
        '''' <remarks></remarks>
        'Public Sub InportInExcel(ByVal Sqlstring As String, ByVal ReportName As String, ByVal GridControl As DataGridView, Optional ByVal ConditionStr As String = "")

        '    Dim xlApp As New Excel.Application
        '    Dim xlBook As Excel.Workbook
        '    Dim xlSheet As Excel.Worksheet
        '    Dim xlQuery As Excel.QueryTable
        '    Dim iField As Integer
        '    xlApp = Nothing
        '    xlApp = New Excel.Application
        '    xlBook = Nothing
        '    xlSheet = Nothing
        '    xlBook = xlApp.Workbooks().Add
        '    xlSheet = xlBook.Worksheets("sheet1")
        '    xlApp.Visible = True
        '    Try
        '        xlQuery = xlSheet.QueryTables.Add("OLEDB;Provider=SQLOLEDB.1;" + GetConnString(), xlSheet.Range("A6"), Sqlstring)
        '        With xlQuery
        '            .FieldNames = True
        '            .RowNumbers = False
        '            .FillAdjacentFormulas = False
        '            .PreserveFormatting = True
        '            .RefreshOnFileOpen = False
        '            .BackgroundQuery = True
        '            .RefreshStyle = Excel.XlCellInsertionMode.xlInsertDeleteCells
        '            .SavePassword = True
        '            .SaveData = True
        '            .AdjustColumnWidth = True
        '            .RefreshPeriod = 0
        '            .PreserveColumnInfo = True
        '        End With

        '        xlQuery.FieldNames = False
        '        ''xlQuery.FieldNames = True '顯示字段名
        '        xlQuery.Refresh(xlQuery.BackgroundQuery)

        '        For iField = 1 To GridControl.Columns.Count
        '            xlSheet.Cells(5, iField) = GridControl.Columns(iField - 1).HeaderText
        '        Next iField


        '        xlQuery.Delete()
        '        xlApp.Application.Visible = True
        '        xlSheet = Nothing
        '        xlBook = Nothing
        '        xlApp = Nothing
        '    Catch ex As Exception
        '        xlQuery.Delete()
        '        xlSheet = Nothing
        '        xlBook = Nothing
        '        xlApp = Nothing
        '    End Try

        'End Sub

#End Region

        Protected Overrides Sub Finalize()

            MyBase.Finalize()

            SysCommand.Dispose()
            SysConnection = Nothing

        End Sub
    End Class

End Namespace

#End Region

#Region "基本數據處理"

Namespace SysCheckData

    Public Class TextHandle

        ''Private LPassLen, Lnum, Ltmp As Integer
        ''Private lResult As String

        Private Event TextEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Private Event ButtonEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Private Event TransEnterEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Private WithEvents TextBoxHandle As TextBox


        Public Sub TxtSelectAll(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxHandle.Click, TextBoxHandle.GotFocus

            sender.SelectAll()

        End Sub

        Public Sub ValiDataText(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            RaiseEvent ButtonEvent(sender, e)
        End Sub

        Public Sub UpperControlTxt(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            RaiseEvent TextEvent(sender, e)
        End Sub

        Public Sub TabTransEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            RaiseEvent TransEnterEvent(sender, e)
        End Sub


#Region "Tab鍵轉換為Enter處理事件"

        Private Sub TransToEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.TransEnterEvent

            Try
                If e.KeyChar = Chr(13) Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

#End Region

#Region "限制只能輸入數字與小數點"

        Private Sub ValidaText(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.ButtonEvent

            Try
                If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Or e.KeyChar = vbTab Or e.KeyChar = vbCr Or e.KeyChar = vbLf Or e.KeyChar = Chr(22) Or e.KeyChar = Chr(24) Or e.KeyChar = Chr(3) Then
                    If (e.KeyChar = "." And InStr(sender.Text, ".") > 0) Or (e.KeyChar = "." And Trim(sender.text) = "") Then

                        e.Handled = True

                    Else

                        e.Handled = False

                    End If
                Else
                    e.Handled = True
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

#End Region

#Region "轉換為大寫"

        Private Sub UpperText(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.TextEvent

            Try
                If Char.IsLower(e.KeyChar) Then
                    sender.SelectedText = Char.ToUpper(e.KeyChar)
                    e.Handled = True
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

#End Region



        ''' <summary>
        ''' 功能描述：删除不可见字符。
        ''' </summary>
        ''' <param name="sourceString">原字符串</param>
        ''' <returns></returns>
        Public Shared Function DeleteUnVisibleChar(ByVal sourceString As String) As String
            Dim strBuilder As New System.Text.StringBuilder(131)

            Dim aaa() As Byte = Encoding.UTF8.GetBytes(sourceString)

            Dim uc() As Char = Encoding.UTF8.GetChars(aaa)
            For k As Integer = 0 To uc.Length - 1
                If Char.IsControl(uc(k)) = False Then
                    strBuilder.Append(uc(k))
                End If
            Next

            Return strBuilder.ToString()
        End Function


#Region "清空所有編輯控件同容"
        Public Shared Sub ClearControl(ByVal sender As Object)

            Dim Ctrl As Control
            Try
                For Each Ctrl In sender.Controls
                    If TypeOf Ctrl Is TextBox Then
                        Ctrl.Text = ""
                    ElseIf TypeOf Ctrl Is ComboBox Then
                        Ctrl.Text = ""
                    End If
                    If Ctrl.HasChildren Then
                        ClearControl(Ctrl)
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try

        End Sub
#End Region

#Region "處理控件是否有效"
        Public Shared Sub ControlIsEnable(ByVal sender As Object, ByVal Flag As Boolean)

            Dim Ctrl As Control
            Try
                For Each Ctrl In sender.Controls
                    If TypeOf Ctrl Is GroupBox Then
                        If Flag = False Then
                            Ctrl.Enabled = True
                        Else
                            Ctrl.Enabled = False
                        End If
                    End If
                    If Ctrl.HasChildren Then
                        ControlIsEnable(Ctrl, Flag)
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

#End Region

#Region "加密口令 16位MD5加密函數"

        ''Public Function EnCryptPassword(ByVal Lpass As String)

        ''    If Lpass = "" Then
        ''        EnCryptPassword = ""
        ''    Else
        ''        Lpass = Trim(Lpass)
        ''        LPassLen = Len(Lpass)
        ''        lResult = ""
        ''        For Lnum = 1 To LPassLen
        ''            Ltmp = Asc(Mid(Lpass, Lnum, 1))
        ''            lResult = lResult + Chr(Ltmp + Asc(Mid(Lpass, Ltmp Mod LPassLen + 1, 1)) + Lnum)
        ''        Next
        ''    End If
        ''    EnCryptPassword = lResult

        ''End Function

        Public Function EnCryptPassword(ByVal VstrSource As String) As String

            Dim dataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(VstrSource)
            Dim hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(dataToHash)
            Dim I As Integer
            EnCryptPassword = Nothing

            For I = 4 To 11
                EnCryptPassword += Hex(hashvalue(I)).ToLower
            Next

            Return EnCryptPassword

        End Function
        Public Function AddSecurity(ByVal sInCode As String) As String
            Dim iSlen, i, m As Integer
            Dim arrIn() As Byte
            Dim arrInbit As BitArray
            arrIn = System.Text.Encoding.UTF8.GetBytes(sInCode)
            arrInbit = New BitArray(arrIn)
            iSlen = arrInbit.Length

            arrInbit.Xor(Me.GetSecurityKey(iSlen))

            Dim arrOut(UBound(arrIn)) As Byte
            arrInbit.CopyTo(arrOut, 0)

            m = UBound(arrOut)
            Dim sTmp As String = ""
            For i = 0 To m
                With arrOut(i)
                    If .ToString.Length = 1 Then
                        sTmp = sTmp & "00" & .ToString
                    ElseIf arrOut(i).ToString.Length = 2 Then
                        sTmp = sTmp & "0" & .ToString
                    Else
                        sTmp = sTmp & .ToString
                    End If
                End With
            Next

            Return sTmp
        End Function

        Private Function GetSecurityKey(ByVal iSecurityLength As Integer) As BitArray
            Dim iDlen, i, n, j As Integer
            Dim sSec As String
            Dim arrSec() As Byte
            Dim arrSecBit As BitArray

            sSec = "tech-singhua.yi-aggression-csut"
            arrSec = System.Text.Encoding.UTF8.GetBytes(sSec)
            arrSecBit = New BitArray(arrSec)
            iDlen = arrSecBit.Length

            With arrSecBit
                If iDlen > iSecurityLength Then  'only get one piece
                    .Length = iSecurityLength
                Else     'fill arrSecBit by it self
                    .Length = iSecurityLength
                    n = iDlen
                    j = 0
                    For i = iDlen To iSecurityLength - 1
                        If j < n - 1 Then
                            .Set(i, .Get(j))
                        Else
                            .Set(i, .Get(j))
                            If j = n - 1 Then
                                j = -1
                            End If
                        End If
                        j = j + 1
                    Next
                End If
            End With

            Return arrSecBit
        End Function

        Public Function UnSecurity(ByVal sSecCode As String) As String
            Dim iSlen, i, m As Integer
            If sSecCode.Length Mod 3 <> 0 Then
                Throw New Exception("配置文件里面的密码不是经过加密加出来的!")
                Return ""
            End If

            m = (sSecCode.Length / 3 - 1)
            Dim arrIn2(m) As String
            Dim arrInbit As BitArray
            For i = 0 To m
                arrIn2(i) = Mid(sSecCode, i * 3 + 1, 3)
            Next

            Dim arrIn(m) As Byte
            For i = 0 To m
                If IsNumeric(arrIn2(i)) = True Then
                    If arrIn2(i) > 255 Then
                        Throw New Exception("配置文件里面的密码不是经过加密加出来的!")
                        Return ""
                    Else
                        arrIn(i) = CInt(arrIn2(i))
                    End If
                Else
                    Throw New Exception("配置文件里面的密码不是经过加密加出来的!")
                    Return ""
                End If
            Next

            arrInbit = New BitArray(arrIn)
            iSlen = arrInbit.Length

            arrInbit.Xor(Me.GetSecurityKey(iSlen))

            Dim arrOut(UBound(arrIn)) As Byte
            arrInbit.CopyTo(arrOut, 0)

            Return System.Text.Encoding.UTF8.GetString(arrOut)
        End Function
        'clsSec.GetOriginalConnString
        Public Function GetOriginalConnString(ByVal SecConnectionString As String) As String
            If InStr(SecConnectionString, "=") <= 0 Then
                Throw New Exception("连接字符串肯定不对!")
            Else
                Dim m As Integer
                Dim arr() As String = Split(SecConnectionString, "=")
                m = UBound(arr)

                If arr(m) <> "" Then
                    If IsNumeric(Left(arr(m), 3)) = False Or arr(m).Length Mod 3 <> 0 Then
                        Throw New Exception("请在配置文件中使用加密过的密码!")
                    End If
                End If

                arr(m) = Me.UnSecurity(arr(m))
                Return Join(arr, "=")
            End If
        End Function

#End Region

#Region "簡繁體轉換,處理因輸入法不同引起的亂碼"
        '''為真時簡體轉換為繁體 否則繁體轉換為簡單
        Public Function TraditionalChinese(ByVal ChineseStr As String, ByVal Flag As Boolean) As String


            ChineseStr = Trim(ChineseStr)

            If Flag = True Then
                TraditionalChinese = StrConv(ChineseStr, VbStrConv.TraditionalChinese, 2)
            Else
                TraditionalChinese = StrConv(ChineseStr, VbStrConv.SimplifiedChinese, 2)
            End If
            Return TraditionalChinese

        End Function

#End Region

#Region "判斷掃描條碼樣式是否正確"

        'Shared Function verfyBarCodeStyle(ByVal TxtSnStyle1 As String, ByVal TxtBarCode As String, ByVal TxtSnStyle2 As String) As Boolean

        '    ''Dim NewStylesStr As String = ""
        '    ''Dim SnStryle() As Char
        '    ''Dim SnBarCode() As Char
        '    ''Dim I As Byte

        '    ''SnStryle = TxtSnStyle1.ToCharArray
        '    ''SnBarCode = TxtBarCode.ToCharArray
        '    ''For I = 0 To UBound(SnStryle)
        '    ''    If SnStryle(I) = "*" Then
        '    ''        SnBarCode(I) = "*"
        '    ''    End If
        '    ''    NewStylesStr = NewStylesStr + SnBarCode(I)
        '    ''Next
        '    ''If TxtSnStyle2 = NewStylesStr OrElse TxtSnStyle1 = NewStylesStr Then ''不用instr,以防止出現兩者組合字符符合條件的情況
        '    ''    verfyBarCodeStyle = True
        '    ''End If

        '    Dim NewStylesStr As String = ""
        '    Dim SnStryle() As Char
        '    Dim SnBarCode() As Char
        '    Dim I As Byte
        '    Dim MultSnStyle As String()
        '    'If InStr(TxtSnStyle1, ";") > 0 Then
        '    '    MultSnStyle = (TxtSnStyle1 & ";" & TxtSnStyle2).Split(";")
        '    '    SnStryle = MultSnStyle(0)
        '    'Else
        '    SnStryle = TxtSnStyle1.ToCharArray
        '    'End If


        '    SnBarCode = TxtBarCode.ToCharArray
        '    For I = 0 To UBound(SnStryle)
        '        If SnStryle(I) = "*" Then
        '            SnBarCode(I) = "*"
        '        End If
        '        NewStylesStr = NewStylesStr + SnBarCode(I)
        '    Next
        '    If InStr(TxtSnStyle1, ";") > 0 Then
        '        For IFlag As Byte = 0 To MultSnStyle.Length - 1
        '            If MultSnStyle(IFlag) = NewStylesStr Then ''不用instr,以防止出現兩者組合字符符合條件的情況
        '                verfyBarCodeStyle = True
        '                Exit Function
        '            End If
        '        Next
        '    Else
        '        If TxtSnStyle2 = NewStylesStr OrElse TxtSnStyle1 = NewStylesStr Then ''不用instr,以防止出現兩者組合字符符合條件的情況
        '            verfyBarCodeStyle = True
        '            Exit Function
        '        End If
        '    End If

        'End Function

#End Region

#Region "數據測試是否OK"

        Public Function CheckPassy(ByVal TableName As String, ByVal StrKeyField As String, ByVal StrKeyFieldValue As String, Optional ByVal Partid As String = "") As String



            Return True

        End Function

#End Region

    End Class

    Public Class SysMessageClass

        Shared m_MainForm As ToolStripProgressBar
        Shared m_ToolLabel As ToolStripStatusLabel
        Shared m_PrinterPort As String
        Shared m_EditFlag As String
        Shared m_UseName As String
        Shared m_UseId As String
        Shared m_DeptId As String
        Shared m_LanguageId As String
        Shared m_UsePassWord As String
        Shared m_ErrforUser As String
        Shared m_ErrForPass As String
        Shared m_FactoryAreaId As String
        Private m_NtUser As String
        Private m_ErrNum As Integer
        Private m_ErrDest As String
        Private m_ErrForm As String
        Private m_Errformprg As String
        Private m_Errtype As String
        Private m_PModule As String
        Private m_Version As String

        Public Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As IntPtr
        Public Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hObject As IntPtr) As IntPtr

        Enum MessageBoxCaption

            InformationMessage = 1
            ErrorMessage = 2
            WarningMessage = 3

        End Enum

#Region "打印字體全部下載設置"

        Public Sub PrinterFontLoad(ByVal PrinterPort As String)

            Dim PathStr As String
            Try
                PathStr = "\\" & DbClass.SysDataHandle.SysDataBaseClass.SqlserverName
                PathStr = PathStr.ToLower.Replace("\label1", "").Trim
                SysMessageClass.FormProgressBar.Visible = True
                SysMessageClass.FormProgressBar.Maximum = My.Computer.FileSystem.GetFiles(PathStr & "\PrgUpdate\Barcodefont", FileIO.SearchOption.SearchAllSubDirectories, "*.txt").Count
                SysMessageClass.FormProgressBar.Value = 0

                For Each foundFile As String In My.Computer.FileSystem.GetFiles(PathStr & "\PrgUpdate\Barcodefont", FileIO.SearchOption.SearchAllSubDirectories, "*.txt")
                    LoadBarCodeFont(foundFile.Trim, PrinterPort)
                    SysMessageClass.FormProgressBar.Value = SysMessageClass.FormProgressBar.Value + 1
                Next
                SysMessageClass.FormProgressBar.Visible = False
            Catch ex As Exception
                Throw ex
                Exit Sub
            Finally
                If LCase(SysMessageClass.Language) = "english" Then
                    SysMessageClass.FormToolLabel.Text = "Ready"
                Else
                    SysMessageClass.FormToolLabel.Text = "就緒:"
                End If
                SysMessageClass.FormProgressBar.Visible = False
            End Try

        End Sub

#End Region

#Region "下載字體"

        Public Sub LoadBarCodeFont(ByVal FontFile As String, ByVal Lpt As String)

            Dim Compiler As New Process
            Try
                Compiler.StartInfo.FileName = "cmd.exe"
                Compiler.StartInfo.Arguments = "/c copy " & FontFile & " " & Lpt
                Compiler.StartInfo.UseShellExecute = False
                Compiler.StartInfo.RedirectStandardInput = False
                Compiler.StartInfo.RedirectStandardOutput = False
                Compiler.StartInfo.CreateNoWindow = True

                Compiler.Start()
                Compiler.WaitForExit()
            Catch ex As Exception
                Throw ex
            Finally
                Compiler.Close()
            End Try

        End Sub

#End Region

#Region "測試打印機端口"

        Public Shared Function CheckPrinterPort(ByVal Port As String) As Boolean

            Dim iPort As IntPtr
            Try
                iPort = CreateFile(Port, 31 Or 30, 1 Or 2, 0, 3, 0, 0)
                If (iPort.ToInt32 = -1) Then
                    CheckPrinterPort = False
                Else
                    CheckPrinterPort = True
                End If
            Catch ex As Exception
                Throw ex
                CheckPrinterPort = False
            Finally
                CloseHandle(iPort)
            End Try

        End Function

#End Region

#Region "指令打印條碼"

        'Public Function PrintCodeBar(ByVal PortStr As String, ByVal PrintString As String) As Boolean

        '    Dim Fs As FileStream
        '    Dim Sw As StreamWriter
        '    Dim iPort As IntPtr
        '    Sw = Nothing
        '    Fs = Nothing
        '    PrintCodeBar = True
        '    Try
        '        iPort = CreateFile(PortStr, 31 Or 30, 1 Or 2, 0, 3, 0, 0)
        '        Fs = New FileStream(iPort, FileAccess.ReadWrite, True)
        '        Sw = New StreamWriter(Fs, System.Text.Encoding.Default) '寫數據
        '        If (iPort.ToInt32 = -1) Then
        '            PrintCodeBar = False
        '        Else
        '            Fs.Flush()

        '            With Sw
        '                .WriteLine(PrintString)
        '                .Flush()

        '            End With
        '        End If
        '    Catch ex As Exception
        '        PrintCodeBar = False
        '        Throw ex
        '    Finally
        '        Sw.Dispose()
        '        Sw.Close()
        '        Fs.Dispose()
        '        Fs.Close()
        '        CloseHandle(iPort)
        '    End Try

        'End Function

#End Region

#Region "廠區代號"

        Public Shared Property FactoryId()
            Get
                Return m_FactoryAreaId
            End Get
            Set(ByVal value)
                m_FactoryAreaId = value
            End Set
        End Property
#End Region

#Region "打印機端口"
        Public Shared Property PrinterPort()
            Get
                Return m_PrinterPort
            End Get
            Set(ByVal value)
                m_PrinterPort = value
            End Set
        End Property
#End Region

#Region "用戶代碼錯誤信息"
        Public Shared Property ErrforUser()
            Get
                Return m_ErrforUser
            End Get
            Set(ByVal value)
                m_ErrforUser = value
            End Set
        End Property
#End Region

#Region "用戶密碼錯誤信息"
        Public Shared Property ErrForPass()
            Get
                Return m_ErrForPass
            End Get
            Set(ByVal value)
                m_ErrForPass = value
            End Set
        End Property
#End Region

#Region "錯誤類型"
        Public Property Errtype()
            Get
                Return m_Errtype
            End Get
            Set(ByVal value)
                m_Errtype = value
            End Set
        End Property
#End Region

#Region "錯誤發生窗體所在程式過程與函數等等"

        Public Property Errformprg()
            Get
                Return m_Errformprg
            End Get
            Set(ByVal value)
                m_Errformprg = value
            End Set
        End Property
#End Region

#Region "錯誤發生窗體"
        Public Property ErrForm()
            Get
                Return m_ErrForm
            End Get
            Set(ByVal value)
                m_ErrForm = value
            End Set
        End Property
#End Region
#Region "錯誤信息描述"
        Public Property ErrDest()
            Get
                Return m_ErrDest
            End Get
            Set(ByVal value)
                m_ErrDest = value
            End Set
        End Property
#End Region

#Region "錯誤參數代號"
        Public Property ErrNum()
            Get
                Return m_ErrNum
            End Get
            Set(ByVal value)
                m_ErrNum = value
            End Set
        End Property
#End Region

#Region "NT用戶"
        Public Property NtUser()
            Get
                Return m_NtUser
            End Get
            Set(ByVal value)
                m_NtUser = value
            End Set
        End Property
#End Region


#Region "用戶姓名"
        Public Shared Property UseName() As String
            Get
                Return m_UseName
            End Get

            Set(ByVal Value As String)
                m_UseName = Value
            End Set
        End Property
#End Region

#Region "打印參數結構体變量數組"
        ''增加動態數據d。
        Public Structure PrtStructure
            Public Moid As String
            Public CusName As String
            Public AvcPartid As String
            Public Deptid As String
            Public Lineid As String
            Public Qty As String
            Public NowDate As String
            Public NowMonth As String
            Public WorkType As String
            Public DateCode As String
            Public Suppliy As String
            Public weight As String
            Public CustomerPN As String
            Public ConfigFlag As String
            Public DriFlag As String
            Public CheckBit As String
            Public BuildAttribute As String

            Public Function ToArray() As Array
                Dim PrtArray(20) As String
                PrtArray(1) = Moid
                PrtArray(2) = CusName
                PrtArray(3) = AvcPartid
                PrtArray(4) = Deptid
                PrtArray(5) = Lineid
                PrtArray(6) = Qty
                PrtArray(7) = NowDate
                PrtArray(8) = NowMonth
                PrtArray(9) = WorkType
                PrtArray(10) = DateCode
                PrtArray(11) = Suppliy
                PrtArray(12) = weight
                PrtArray(13) = CustomerPN
                PrtArray(14) = ConfigFlag
                PrtArray(15) = DriFlag
                PrtArray(16) = CheckBit
                PrtArray(17) = BuildAttribute
                'Array14-固定列中的"Config-产品Config"
                Return PrtArray
            End Function
        End Structure

#End Region

#Region "用戶部門"
        Public Shared Property UseDeptid() As String
            Get
                Return m_DeptId
            End Get

            Set(ByVal Value As String)
                m_DeptId = Value
            End Set
        End Property
#End Region


#Region "用戶密碼"
        Public Shared Property UsePassWord() As String
            Get
                Return m_UsePassWord
            End Get

            Set(ByVal Value As String)
                m_UsePassWord = Value
            End Set
        End Property

#End Region

#Region "新增修改標識"

        Shared Property EditFlag() As Boolean

            Get
                Return m_EditFlag
            End Get
            Set(ByVal Value As Boolean)
                m_EditFlag = Value
            End Set

        End Property
#End Region

#Region "語言類別"

        Public Shared Property Language() As String
            Get
                Return m_LanguageId
            End Get
            Set(ByVal Value As String)
                m_LanguageId = Value
            End Set
        End Property

#End Region

#Region "語言類別"

        Public Property PModule() As String
            Get
                Return m_PModule
            End Get
            Set(ByVal Value As String)
                m_PModule = Value
            End Set
        End Property

#End Region

#Region "語言類別"

        Public Property Version() As String
            Get
                Return m_Version
            End Get
            Set(ByVal Value As String)
                m_Version = Value
            End Set
        End Property

#End Region

#Region "用戶帳號"

        Public Shared Property UseId() As String
            Get
                Return m_UseId
            End Get
            Set(ByVal Value As String)
                m_UseId = Value
            End Set
        End Property
#End Region
#Region "進度條狀態"
        ''與進度條未合並處理 使程序簡單化dd
        Public Shared Property FormToolLabel() As ToolStripStatusLabel
            Get
                Return m_ToolLabel
            End Get

            Set(ByVal Value As ToolStripStatusLabel)
                m_ToolLabel = Value
            End Set
        End Property

#End Region
#Region "進度條處理"
        Public Shared Property FormProgressBar() As ToolStripProgressBar
            Get
                Return m_MainForm
            End Get

            Set(ByVal Value As ToolStripProgressBar)
                m_MainForm = Value
            End Set
        End Property
#End Region

#Region "用戶登錄日志記錄"

        Public Sub WriteLoginLog(ByVal Flag As Boolean)

            Dim SqlStr As String
            Dim ExeCute As New DbClass.SysDataHandle.SysDataBaseClass
            If Flag = True Then
                SqlStr = "insert into m_Login_t(Userid,PModule,Version) values" & " ('" & SysMessageClass.UseId & "','" & m_PModule & "','" & m_Version & "')"
            Else
                SqlStr = "update m_Login_t set Logouttime=getdate() where Userid='" & SysMessageClass.UseId & "' and Logouttime is null"
            End If

            ExeCute.ExecSql(SqlStr)
            ExeCute = Nothing

        End Sub

#End Region
        Public Shared Function GetAuthenticate(ByVal UserID As String, ByVal PassWord As String) As String
            Dim sql, sRet As String
            Dim iRet As Integer = 0
            Dim ExeCute As New DbClass.SysDataHandle.SysDataBaseClass
            Dim para(2) As SqlParameter
            sql = "usp_User_Authenticate"
            Dim parameters() As SqlParameter = {New SqlParameter("@UserID", SqlDbType.VarChar, 20), New SqlParameter("@Pwd", SqlDbType.VarChar, 30), New SqlParameter("@iRet", SqlDbType.Int, 20)}

            parameters(0).Value = UserID
            parameters(1).Value = PassWord
            parameters(2).Value = iRet
            parameters(2).Direction = ParameterDirection.Output
            sRet = ExeCute.ExecuteNonQureyByProc(sql, parameters)
            If sRet = "" Then
                iRet = parameters(2).Value
                If iRet = 1 Then
                    sRet = ""
                ElseIf iRet = -4 Then
                    sRet = "MES用户密码不对!!"
                ElseIf iRet = -3 Then
                    sRet = "MES用户处于不可用/离职状态!!"
                ElseIf iRet = -2 Then
                    sRet = "MES用户不存在!!"
                End If
            End If
            '-4密码不对；-3用户不可用；-2 代表用户不存在；-1代表系统不存在； 0代表系统不可用； 1代表通过验证



            Return sRet
        End Function

#Region "用戶操作錯誤日志"

        Public Shared Sub WriteErrLog(ByVal ex As Exception, ByVal ErrForm As String, ByVal Errformprg As String, ByVal Errtype As String)

            Dim SqlString As New StringBuilder
            Dim ExeCute As New DbClass.SysDataHandle.SysDataBaseClass
            Dim ErrStr As New StringBuilder
            Dim ErrStr1 As String

            If LCase(SysMessageClass.Language) = "english" Then
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "System Error Prompt")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "系統錯誤提示")
            End If

            ErrStr.Append(Err.Description.Replace("'", "#"))
            ErrStr.Replace(ControlChars.CrLf, "")

            If Len(ErrStr.ToString) >= 201 Then
                ErrStr1 = ErrStr.ToString.Substring(0, 200)
            Else
                ErrStr1 = ErrStr.ToString
            End If

            SqlString.Append("insert into m_Errinfo_t(ErrTime,Userid,NTUser,ErrNum,ErrDest,ErrForm,Errformprg,Errtype) values(getdate()")
            SqlString.Append(",'" & SysMessageClass.UseId & "','" & System.Environment.UserName & "','" & Err.Number & "','" & ErrStr1 & "','" & ErrForm & "','" & Errformprg & "','" & Errtype & "')")
            ExeCute.ExecSql(SqlString.ToString)

        End Sub
#End Region



#Region "KILL系統進程指定的可執行文件進程"
        Private Sub KillProcess(ByVal ProStr As String)


        End Sub

#End Region

    End Class
End Namespace

#End Region




