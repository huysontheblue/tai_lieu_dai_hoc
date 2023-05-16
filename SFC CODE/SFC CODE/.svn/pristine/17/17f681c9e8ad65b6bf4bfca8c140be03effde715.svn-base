
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

    Public Shared Function GetCustomerList(ByVal strCustmoerCode As String) As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Dim dtTemp As DataTable

        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strCustmoerCode)) Then
                strWhere = " WHERE CusCode='" & strCustmoerCode & "'"
            End If

            If (String.IsNullOrEmpty(strCustmoerCode)) Then
                strSQL = "SELECT   CusID, CusName, Address, CusCode FROM m_Customer_t "
            Else
                strSQL = "SELECT   CusID, CusName, Address, CusCode FROM m_Customer_t " & strWhere
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

    Public Shared Function GetConnectDatabaseList(ByVal strConnectDatabaseName As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strConnectDatabaseName)) Then
                strWhere = " AND ConnectDatabaseName = '" & strConnectDatabaseName & "'"
            End If

            strSQL = "SELECT   ConnectDatabaseId, ConnectDatabaseName FROM  m_ConnectDatabase_t WHERE 1=1 " & strWhere & " AND StatusFlag='Y' ORDER BY CreateTime DESC"

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetReleasedVersionList(ByVal strReleasedVersionName As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strReleasedVersionName)) Then
                strWhere = " AND ReleasedVersionName = '" & strReleasedVersionName & "'"
            End If

            strSQL = "SELECT   ReleasedVersionId, ReleasedVersionName FROM  m_ReleasedVersion_t WHERE 1=1 " & strWhere & " AND StatusFlag='Y' ORDER BY CreateTime DESC"

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetConnectDatabaseQuery(ByVal strConnectDatabaseId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strConnectDatabaseId)) Then
                strWhere = " AND ConnectDatabaseId = '" & strConnectDatabaseId & "'"
            End If

            strSQL = "SELECT   ConnectDatabaseId, ConnectDatabaseName, ConnectDatabaseAddress, ConnnectDataBase, LoginUserId, " & _
                 " LoginPassword, Remark, StatusFlag, DeleteFlag, CreateUserId, CreateTime, UpdateUserId, UpdateTime " & _
                 " FROM  m_ConnectDatabase_t WHERE 1=1 " & strWhere & " ORDER BY CreateTime DESC"

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetReleasedVersionQuery(ByVal strReleasedVersionId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strReleasedVersionId)) Then
                strWhere = " AND ReleasedVersionId = '" & strReleasedVersionId & "'"
            End If

            strSQL = "SELECT   ReleasedVersionId, ReleasedVersionName, ReleasedVersionTypeId, ReleasedVersionTypeName, SoftWareName, " & _
                 " CustomerId, CustomerName, ConnectDatabaseId, ConnectDatabaseName, FactoryId, FactoryName, ProfitCenterId, ProfitCenterName, Remark, StatusFlag, " & _
                 " DeleteFlag, CreateUserId, CreateTime, UpdateUserId, UpdateTime " & _
                 " FROM  m_ReleasedVersion_t WHERE 1=1 " & strWhere & " ORDER BY CreateTime DESC"

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetClientQuery(ByVal strClientInfoId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strClientInfoId)) Then
                strWhere = " AND ClientInfoId = '" & strClientInfoId & "'"
            End If

            strSQL = "SELECT   ClientInfoId, ClientName, ClientMacAddress, AdministratorName, FactoryId, FactoryName, ProfitCenterId, ProfitCenterName, DeptId, LineId, ReleasedVersionId, ReleasedVersionName, Remark, " & _
                 " StatusFlag, DeleteFlag, CreateUserId, CreateTime, UpdateUserId, UpdateTime" & _
                 " FROM  m_ClientInfo_t WHERE 1=1 " & strWhere & " ORDER BY CreateTime DESC"

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetClientMacQuery(ByVal strClientInfoId As String) As DataTable
        Dim dtTemp As DataTable
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            If Not (String.IsNullOrEmpty(strClientInfoId)) Then
                strWhere = " AND ClientInfoId = '" & strClientInfoId & "'"
            End If

            strSQL = "SELECT  ClientMacId, ClientInfoId, ClientMacAddress, Remark, StatusFlag, CreateUserId, CreateTime, UpdateUserId, UpdateTime FROM m_ClientMac_t WHERE 1=1 " & strWhere & " ORDER BY CreateTime DESC"

            dtTemp = Conn.GetDataTable(strSQL)
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
