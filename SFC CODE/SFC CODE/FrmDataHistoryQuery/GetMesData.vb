
'--MES数据转移类库
'--Create by :　马锋
'--Create date :　2015/09/18
'--Ver : V01
'--Update date :  
'--

#Region "Imports"

Imports System.Windows.Forms
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports DevComponents.DotNetBar
Imports DevComponents.WinForms
#End Region

Public Class GetMesData

    Public Shared Function GetServerProviders() As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            strSQL = "exec sp_enum_oledb_providers"

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetLinkServer(ByVal LinkServerId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(LinkServerId)) Then
                strWhere = " AND LinkServerId='" & LinkServerId & "'"
            End If
            strSQL = "SELECT LinkServerId, LinkServerName, LoginUserName, LinkServerType, Providers, ProductName, DataSources, Catalog, Location, ProvidersStrings, LoginPassword, Rework, StatusFlag, CreateUserId, CONVERT(VARCHAR(32), CreateTime, 120) AS CreateTime FROM m_LinkServer_t WHERE DeleteFlag='0' " & strWhere & " ORDER BY CreateTime DESC"

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetTableName(ByVal strTableName As String, ByVal strLinkServer As String, ByVal strTargetDataBase As String, ByVal strLinkSererType As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            Dim strOracleUser As String = ""

            Select Case (strLinkSererType)
                Case "0"
                    If (Not String.IsNullOrEmpty(strTableName)) Then
                        strWhere = " AND TABLE_NAME = ''" & strTableName & "''"
                    End If

                    If (String.IsNullOrEmpty(strTargetDataBase)) Then
                        strOracleUser = strLinkServer.ToUpper
                    Else
                        strOracleUser = strTargetDataBase
                    End If

                    strSQL = "SELECT * FROM OPENQUERY(" & strLinkServer & ",'SELECT ROWNUM AS RowNumId,TABLE_NAME AS name FROM ALL_TABLES WHERE OWNER=''" + strOracleUser + "'' AND ROWNUM <=20 " & strWhere & "')"
                Case "1"
                    If (Not String.IsNullOrEmpty(strTableName)) Then
                        strWhere = " AND name LIKE '%" & strTableName & "%'"
                    End If

                    If (String.IsNullOrEmpty(strLinkServer)) Then
                        If (String.IsNullOrEmpty(strTargetDataBase)) Then
                            strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY NAME) AS RowNumId, name FROM dbo.sysobjects WHERE xtype='u' " & strWhere & " ORDER BY name"
                        Else
                            strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY NAME) AS RowNumId, name FROM [" & strTargetDataBase & "].dbo.sysobjects WHERE xtype='u' " & strWhere & " ORDER BY name"
                        End If
                    Else
                        strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY NAME) AS RowNumId, name FROM [" & strLinkServer & "].[" & strTargetDataBase & "].dbo.sysobjects WHERE xtype='u' " & strWhere & " ORDER BY name"
                    End If
            End Select
           

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetCheckTableIdentity(ByVal strLinkServer As String, ByVal strTargetDataBase As String, ByVal strTableName As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String

            If (String.IsNullOrEmpty(strLinkServer)) Then
                If (String.IsNullOrEmpty(strTargetDataBase)) Then
                    strSQL = " SELECT col.[name] FROM sys.columns col inner join sys.tables tab on col.object_id= tab.object_id WHERE col.is_identity = 1 and tab.name='" & strTableName & "'"
                Else
                    strSQL = " SELECT col.[name] FROM [" & strTargetDataBase & "].sys.columns col inner join [" & strTargetDataBase & "].sys.tables tab on col.object_id= tab.object_id WHERE col.is_identity = 1 and tab.name='" & strTableName & "'"
                End If
            Else
                strSQL = " SELECT col.[name] FROM [" & strLinkServer & "].[" & strTargetDataBase & "].sys.columns col inner join [" & strLinkServer & "].[" & strTargetDataBase & "].sys.tables tab on col.object_id= tab.object_id WHERE col.is_identity = 1 and tab.name='" & strTableName & "'"
            End If

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetLinkServerQuery(ByVal strLinkeServerName As String, ByVal strDataHostoryType As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(strLinkeServerName)) Then
                strWhere = " AND LinkServerName LIKE '%" & strLinkeServerName & "%' "
            End If

            If (Not String.IsNullOrEmpty(strDataHostoryType)) Then
                strWhere = strWhere & " AND LinkServerType='" & strDataHostoryType & "' "
            End If

            strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY LinkServerName) AS RowNumId, LinkServerId, LinkServerName, Rework, LinkServerType FROM m_LinkServer_t WHERE StatusFlag='Y' " & strWhere & " ORDER BY LinkServerName"
            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetTargetDataBase(ByVal strTargetDataBase As String, ByVal strLinkServerName As String, ByVal strSererType As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            Select Case (strSererType)
                Case "0"
                    If (Not String.IsNullOrEmpty(strLinkServerName)) Then
                        strWhere = " AND ServerCode = '" + strLinkServerName + "' "
                    End If

                    If (Not String.IsNullOrEmpty(strTargetDataBase)) Then
                        strWhere = strWhere + " AND FactoyCode LIKE '%" & strTargetDataBase & "%'"
                    End If

                    strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY DataHistoryFactoryId) AS RowNumId, FactoyCode AS TargetDataBaseName FROM m_DataHistoryFactoy_t WHERE DeleteFlag='N' " & strWhere
                Case "1"

                    If (Not String.IsNullOrEmpty(strTargetDataBase)) Then
                        strWhere = " AND name LIKE '%" & strTargetDataBase & "%'"
                    End If

                    If (String.IsNullOrEmpty(strLinkServerName)) Then
                        strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY name) AS RowNumId, name AS TargetDataBaseName FROM master.sys.databases WHERE DATABASE_ID > 4 " & strWhere & " AND [name]<>DB_NAME() ORDER BY [Name] ASC "
                    Else
                        'AND [name]<>DB_NAME()
                        strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY name) AS RowNumId, name AS TargetDataBaseName FROM [" & strLinkServerName & "].master.sys.databases WHERE DATABASE_ID > 4 " & strWhere & " ORDER BY [Name] ASC "
                    End If
            End Select

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetDataHistoryRecordQuery(ByVal strDataHistoryId As String, ByVal strExecuteResult As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(strDataHistoryId)) Then
                strWhere = " AND DataHistoryId = '" & strDataHistoryId & "'"
            End If
            strSQL = "SELECT TOP 20 ROW_NUMBER() OVER(ORDER BY DataHistoryRecordId) AS RowNumId, DataHistoryRecordId, MigrateServerName, MigrateDataBaseName, DataHistoryTableName, SourceDatabase, LinkServerName, TargetDataBaseName, TargetTableName, CONVERT(VARCHAR(30), StartExecuteTime, 120) AS StartExecuteTime, CONVERT(VARCHAR(30), EndExecuteTime, 120) AS EndExecuteTime, RecordRemark, ExecuteResult FROM m_DataHistoryRecord_t WHERE 1=1 " & strWhere & " AND ExecuteResult = '" & strExecuteResult & "' ORDER BY StartExecuteTime DESC "
            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetSequenceColumnQuery(ByVal strLinkServer As String, ByVal strMigrateDataBase As String, ByVal strServerType As String, ByVal strTableName As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As New StringBuilder
            Dim strWhere As String = ""
            Dim strLinkSQL As String = ""
            Dim strOracleUser As String = ""

            If (Not String.IsNullOrEmpty(strLinkServer)) Then
                strLinkSQL = "[" + strLinkServer + "]."
            End If
            If (Not String.IsNullOrEmpty(strTableName)) Then
                strLinkSQL = strLinkSQL + strTableName + "."
            End If

            Select Case (strServerType)

                Case "0"
                    If (strLinkServer.ToUpper = "Tiptop".ToUpper) Then
                        strOracleUser = strMigrateDataBase
                    Else
                        strOracleUser = strLinkServer.ToUpper
                    End If
                    strSQL.AppendLine("SELECT * FROM OPENQUERY(" & strLinkServer & ",'SELECT ROWNUM, TABLE_NAME, COLUMN_NAME AS COLUMNNAME, DATA_TYPE AS TYPENAME, DATA_LENGTH AS TYPELENGTH FROM ALL_TAB_COLUMNS WHERE OWNER=''" + strOracleUser + "'' AND TABLE_NAME=''" & strTableName & "''')")
                Case "1"
                    strSQL.AppendLine(" SELECT ROW_NUMBER() OVER(ORDER BY B.NAME) AS RowNumId, B.NAME AS TABLENAME,A.NAME AS COLUMNNAME,C.NAME AS TYPENAME,A.MAX_LENGTH AS TYPELENGTH ")
                    strSQL.AppendLine(" FROM  " + strLinkSQL + "SYS.COLUMNS A INNER JOIN " + strLinkSQL + "SYS.TABLES B ON B.OBJECT_ID=A.OBJECT_ID ")
                    strSQL.AppendLine(" INNER JOIN  " + strLinkSQL + "SYS.TYPES C ON C.SYSTEM_TYPE_ID=A.SYSTEM_TYPE_ID ")
                    strSQL.AppendLine(" WHERE B.NAME='" & strTableName & "' ")
                    strSQL.AppendLine(" ORDER BY B.NAME,A.COLUMN_ID ")
            End Select

            dtTemp = Conn.GetDataTable(strSQL.ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetColumnQuery(ByVal strLinkServer As String, ByVal strDataBase As String, ByVal strTableName As String, ByVal strLinkServerType As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As New StringBuilder
            Dim strOracleUser As String = ""

            Select Case (strLinkServerType)

                Case "0"
                    If (String.IsNullOrEmpty(strDataBase)) Then
                        strOracleUser = strLinkServer.ToUpper
                    Else
                        strOracleUser = strDataBase
                    End If
                    strSQL.AppendLine("SELECT * FROM OPENQUERY(" & strLinkServer & ", 'SELECT ROWNUM AS RowNumId, TABLE_NAME AS TABLENAME, COLUMN_NAME AS COLUMNNAME, DATA_TYPE AS TYPENAME, DATA_LENGTH AS TYPELENGTH  FROM ALL_TAB_COLUMNS WHERE OWNER=''" + strOracleUser + "'' AND TABLE_NAME=''" & strTableName & "''')")
                Case "1"
                    If (String.IsNullOrEmpty(strLinkServer)) Then
                        If (String.IsNullOrEmpty(strDataBase)) Then

                            strSQL.AppendLine(" SELECT ROW_NUMBER() OVER(ORDER BY B.NAME) AS RowNumId, B.NAME AS TABLENAME,A.NAME AS COLUMNNAME,C.NAME AS TYPENAME,A.MAX_LENGTH AS TYPELENGTH ")
                            strSQL.AppendLine(" FROM SYS.COLUMNS A INNER JOIN SYS.TABLES B ON B.OBJECT_ID=A.OBJECT_ID ")
                            strSQL.AppendLine(" INNER JOIN SYS.TYPES C ON C.SYSTEM_TYPE_ID=A.SYSTEM_TYPE_ID ")
                            strSQL.AppendLine(" WHERE C.name <> 'sysname' AND B.NAME='" & strTableName & "' ")
                            strSQL.AppendLine(" ORDER BY B.NAME,A.COLUMN_ID ")
                        Else

                            strSQL.AppendLine(" SELECT ROW_NUMBER() OVER(ORDER BY B.NAME) AS RowNumId, B.NAME AS TABLENAME,A.NAME AS COLUMNNAME,C.NAME AS TYPENAME,A.MAX_LENGTH AS TYPELENGTH ")
                            strSQL.AppendLine(" FROM [" & strDataBase & "].SYS.COLUMNS A INNER JOIN [" & strDataBase & "].SYS.TABLES B ON B.OBJECT_ID=A.OBJECT_ID ")
                            strSQL.AppendLine(" INNER JOIN SYS.TYPES C ON C.SYSTEM_TYPE_ID=A.SYSTEM_TYPE_ID ")
                            strSQL.AppendLine(" WHERE C.name <> 'sysname' AND B.NAME='" & strTableName & "' ")
                            strSQL.AppendLine(" ORDER BY B.NAME,A.COLUMN_ID ")
                        End If
                    Else
                        strSQL.AppendLine(" SELECT ROW_NUMBER() OVER(ORDER BY B.NAME) AS RowNumId, B.NAME AS TABLENAME,A.NAME AS COLUMNNAME,C.NAME AS TYPENAME,A.MAX_LENGTH AS TYPELENGTH ")
                        strSQL.AppendLine(" FROM [" & strLinkServer & "].[" & strDataBase & "].SYS.COLUMNS A INNER JOIN [" & strLinkServer & "].[" & strDataBase & "].SYS.TABLES B ON B.OBJECT_ID=A.OBJECT_ID ")
                        strSQL.AppendLine(" INNER JOIN SYS.TYPES C ON C.SYSTEM_TYPE_ID=A.SYSTEM_TYPE_ID ")
                        strSQL.AppendLine(" WHERE C.name <> 'sysname' AND B.NAME='" & strTableName & "' ")
                        strSQL.AppendLine(" ORDER BY B.NAME,A.COLUMN_ID ")

                    End If
            End Select

            dtTemp = Conn.GetDataTable(strSQL.ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetDataHistoryQuery(ByVal strDataHistoryId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As New StringBuilder
            Dim strWhere As String = ""

            If (Not String.IsNullOrEmpty(strDataHistoryId)) Then
                strWhere = "AND DataHistoryId='" & strDataHistoryId & "' "
            End If

            strSQL.AppendLine(" SELECT ROW_NUMBER() OVER(ORDER BY DataHistoryId) AS RowNumId, DataHistoryId, MigrateServerName, ExecuteType, MigrateDataBaseName, DataHistoryTableName, SourceDatabase, LinkServerName, TargetDataBaseName, TargetTableName, ")
            strSQL.AppendLine(" TreatmentFlag, SequenceColumn, SequenceType, ColumnType, ColumnSQL, WhereSQL, ProcessingNumber, ExecEndTime, ")
            strSQL.AppendLine(" ExecutionInterval, IntervalFrequency, IntervalType, StartTime, EndTime, RetentionDays, ExecIncrementalTime, IncrementalType, Remark, StatusFlag, MigrateServerConfigName, TargetServerConfigName, ")
            strSQL.AppendLine(" DeleteFlag, m_DataHistory_t.CreateUserId, m_DataHistory_t.CreateTime, m_DataHistory_t.UpdateUserId, m_DataHistory_t.UpdateTime, IntervalType.PARAMETER_NAME AS IntervalTypeName, DateHistoryTreatment.PARAMETER_NAME AS DateHistoryTreatmentName, DataHistoryType.PARAMETER_NAME AS DataHistoryTypeNAME, MigrateDataDelete.PARAMETER_NAME AS MigrateDataDeleteName, ExecuteType.PARAMETER_NAME AS ExecuteTypeName ")
            strSQL.AppendLine(" FROM m_DataHistory_t ")
            strSQL.AppendLine(" INNER JOIN m_SystemSetting_t IntervalType ON IntervalType.PARAMETER_VALUES=m_DataHistory_t.IntervalType ")
            strSQL.AppendLine(" INNER JOIN m_SystemSetting_t DateHistoryTreatment ON DateHistoryTreatment.PARAMETER_VALUES=m_DataHistory_t.TreatmentFlag ")
            strSQL.AppendLine(" INNER JOIN m_SystemSetting_t DataHistoryType ON DataHistoryType.PARAMETER_VALUES=m_DataHistory_t.DataHistoryType ")
            strSQL.AppendLine(" INNER JOIN m_SystemSetting_t MigrateDataDelete ON MigrateDataDelete.PARAMETER_VALUES=m_DataHistory_t.MigrateDataDelete ")
            strSQL.AppendLine(" INNER JOIN m_SystemSetting_t ExecuteType ON ExecuteType.PARAMETER_VALUES=m_DataHistory_t.ExecuteType ")
            strSQL.AppendLine(" WHERE IntervalType.PARAMETER_CODE='IntervalType' AND DateHistoryTreatment.PARAMETER_CODE='DateHistoryTreatment' AND DataHistoryType.PARAMETER_CODE='DataHistoryType' AND MigrateDataDelete.PARAMETER_CODE='MigrateDataDelete' AND ExecuteType.PARAMETER_CODE='ExecuteType' " & strWhere & " ")
            strSQL.AppendLine(" ORDER BY CreateTime DESC ")

            dtTemp = Conn.GetDataTable(strSQL.ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetDataHistoryColumn(ByVal strDataHistoryId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As New StringBuilder

            strSQL.AppendLine(" SELECT ROW_NUMBER() OVER(ORDER BY DataHistoryColumnId) AS RowNumId, DataHistoryColumnId, DataHistoryId, SourceColumn, TargetColumn, DateColumnFlag, CreateUserId, CreateTime ")
            strSQL.AppendLine(" FROM m_DataHistoryColumn_t WHERE DeleteFlag='0' AND DataHistoryId='" & strDataHistoryId & "' ")

            dtTemp = Conn.GetDataTable(strSQL.ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetDataHistoryWhere(ByVal strDataHistoryId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As New StringBuilder

            strSQL.AppendLine(" SELECT ROW_NUMBER() OVER(ORDER BY DataHistoryWhereId) AS RowNumId, DataHistoryWhereId, DataHistoryId, WhereColumn, SQLWhere, WhereType, OperatorsType, CreateUserId, CreateTime ")
            strSQL.AppendLine(" FROM m_DataHistoryWhere_t WHERE DeleteFlag='0' AND DataHistoryId='" & strDataHistoryId & "' ")

            dtTemp = Conn.GetDataTable(strSQL.ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetDataHistoryChild(ByVal strDataHistoryId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As New StringBuilder

            strSQL.AppendLine(" SELECT DataHistoryChildId, DataHistoryId, ItemNo, ChildTableName, ParentColumnName, ChildColumnName, WhereSQL, ")
            strSQL.AppendLine(" Remark, DeleteFlag, CreateUserId, CreateTime, UpdateUserId, UpdateTime ")
            strSQL.AppendLine(" FROM m_DataHistoryChild_t WHERE DeleteFlag='0' AND DataHistoryId='" & strDataHistoryId & "' ")

            dtTemp = Conn.GetDataTable(strSQL.ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetDataHistoryPrimaryKey(ByVal strDataHistoryId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As New StringBuilder

            strSQL.AppendLine(" SELECT DataHistoryPrimaryKeyId, DataHistoryId, SourcePrimaryKeyColumn, TargetPrimaryKeyColumn, CreateUserId, CreateTime, DeleteFlag, UpdateUserId, UpdateTime ")
            strSQL.AppendLine(" FROM m_DataHistoryPrimaryKey_t WHERE DeleteFlag='0' AND DataHistoryId='" & strDataHistoryId & "' ")

            dtTemp = Conn.GetDataTable(strSQL.ToString)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function


    Public Shared Function GetSettingSQL(ByVal ParameterCode As String) As String
        Return "SELECT PARAMETER_VALUES, PARAMETER_NAME FROM m_SystemSetting_t WHERE PARAMETER_CODE='" & ParameterCode & "' ORDER BY SYSTEMSETTING_ID ASC"
    End Function

    Public Shared Function GetSettingParameterSQL(ByVal ParameterCode As String) As String
        Return "SELECT PARAMETER_VALUE, PARAMETER_NAME + '[' + PARAMETER_VALUE + ']' AS PARAMETER_NAME FROM m_SettingParameter_t WHERE PARAMETER_MODE='" & ParameterCode & "' ORDER BY ORDERID ASC"
    End Function

    Public Shared Sub SetMessage(ByVal lblMessage As LabelX, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As Label, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

    Public Shared Sub SetMessage(ByVal lblMessage As LabelItem, ByVal strMessage As String, ByVal Type As Boolean)
        If (Type) Then
            lblMessage.ForeColor = Color.Green
        Else
            lblMessage.ForeColor = Color.Red
        End If
        lblMessage.Text = strMessage
    End Sub

#Region "获取本地打印机列表"

    Public Shared Sub GetPrintersList(ByVal CboName As ComboBox)
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Sub GetPrintersList(ByVal CboName As DataGridViewComboBoxColumn)
        CboName.Items.Clear()
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            CboName.Items.Add(iprt)
        Next
    End Sub

    Public Shared Function CheckPrintersList(ByVal PrintName As String) As Boolean
        For Each iprt As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            If (iprt.Trim = PrintName) Then
                Return True
            End If
        Next
        Return False
    End Function

#End Region

End Class
