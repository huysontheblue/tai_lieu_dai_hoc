
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
Imports MainFrame

#End Region

Public Class GetMesData

    Public Shared Function GetLinkServer(ByVal LinkServerId As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(LinkServerId)) Then
                strWhere = " AND LinkServerId='" & LinkServerId & "'"
            End If
            strSQL = "SELECT LinkServerId, LinkServerName, LoginUserName, LoginPassword, Rework, StatusFlag, CreateUserId, CONVERT(VARCHAR(32), CreateTime, 120) AS CreateTime FROM m_LinkServer_t WHERE DeleteFlag='0' " & strWhere & " ORDER BY CreateTime DESC"

            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetTableName(ByVal strTableName As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(strTableName)) Then
                strWhere = " AND name LIKE '%" & strTableName & "%'"
            End If
            strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY NAME) AS RowNumId, name FROM dbo.sysobjects WHERE xtype='u' " & strWhere & " ORDER BY name"
            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetLinkServerQuery(ByVal strLinkeServerName As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(strLinkeServerName)) Then
                strWhere = " AND LinkServerName LIKE '%" & strLinkeServerName & "%'"
            End If
            strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY LinkServerName) AS RowNumId, LinkServerId, LinkServerName, Rework FROM m_LinkServer_t WHERE StatusFlag='1' " & strWhere & " ORDER BY LinkServerName"
            dtTemp = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
        Return dtTemp
    End Function

    Public Shared Function GetTargetDataBase(ByVal strTargetDataBase As String, ByVal strLinkServerName As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(strTargetDataBase)) Then
                strWhere = " AND name LIKE '%" & strTargetDataBase & "%'"
            End If

            If (String.IsNullOrEmpty(strLinkServerName)) Then
                strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY name) AS RowNumId, name AS TargetDataBaseName FROM master.sys.databases WHERE DATABASE_ID > 4 " & strWhere & " AND [name]<>DB_NAME() ORDER BY [Name] ASC "
            Else
                strSQL = "SELECT ROW_NUMBER() OVER(ORDER BY name) AS RowNumId, name AS TargetDataBaseName FROM [" & strLinkServerName & "].master.sys.databases WHERE DATABASE_ID > 4 " & strWhere & " AND [name]<>DB_NAME() ORDER BY [Name] ASC "
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

    Public Shared Function GetMOList(ByVal MoId As String, ByVal strSupportId As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Try

            Dim strSQL As String
            Dim strWhere As String = ""
            If (Not String.IsNullOrEmpty(MoId)) Then
                strWhere = " AND Moid LIKE '%" & MoId & "%'"
            End If

            If (Not String.IsNullOrEmpty(strSupportId)) AndAlso Not factory.IndexOf(VbCommClass.VbCommClass.Factory) > -1 Then
                strWhere = strWhere + " AND cusid='" & strSupportId & "' "
            End If

            strWhere = strWhere + " AND Factory = '" & VbCommClass.VbCommClass.Factory & "'"
            If Not String.IsNullOrEmpty(VbCommClass.VbCommClass.profitcenter) Then
                strWhere = strWhere + " AND profitcenter = '" & VbCommClass.VbCommClass.profitcenter & "'"
            End If

            strSQL = "SELECT TOP 100 Moid, PartID, Moqty, Remark FROM m_Mainmo_t WHERE FinalY='N' " & strWhere & " ORDER BY Createtime DESC"

            dtTemp = DbOperateUtils.GetDataTable(strSQL)
        Catch ex As Exception
        End Try
        Return dtTemp
    End Function
    Shared factory As String = "LX53,WANXUN,M02600,JIZHOU,XINYU,LX21,COCRXIN"

    Public Shared Function GetMOSKUStyleList(ByVal MoId As String) As DataTable
        Dim dtTemp As DataTable = Nothing
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
        Try

            Dim strSQL As String
            Dim strWhere As String = ""

            strSQL = "SELECT MOID, SBarCode, qty FROM m_MOPackingLevel WHERE PackId = 'N' AND DisorderTypeId = 'S' AND MOID='" & MoId & "' ORDER BY Createtime DESC"

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
