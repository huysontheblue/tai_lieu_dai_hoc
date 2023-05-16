Imports System.Xml
Imports System.IO
Imports MainFrame
Imports MainFrame.SysCheckData
Imports MainFrame.SysDataHandle
Imports SysBasicClass
Imports System.Data.SqlClient
Imports System.Net.NetworkInformation
Imports System.Diagnostics
Imports Microsoft.Win32
Imports System.Text
Imports MESUserManage
Imports LDAPHelp
Imports DBUtility
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Resources
Imports System.Globalization
Imports System.Threading

Public Class Login
    Dim IsAdLink As String = "Y"
    Dim IsLinkErp As String = "Y"
    Dim ErpServer As String = ""
    Dim IsAdLinkLastDate As Date = Now
    Dim LoadFactory As String
    Dim LoadProfitCenter As String
    Dim rtValue As String
    Dim rtMsg As String
    Dim ServerName As String
    Dim _dtClientMac As DataTable
    Dim IsOutUser As String
    Dim usey As String
    Dim OMd As String
    Dim SapServer As String
    Dim SapServerBU10 As String
    Public Language As String

    'Dim ConnectionStringSapBU10 As String


    'Dim SystemIP As String = "data source=DG-MESDB.luxshare.com.cn;initial catalog=MESDB;uid=sfcuser;pwd=007003000029094022027079039075082018065023014084024"
    Dim _dtLang As DataTable
    Public Property DtLang() As DataTable
        Get
            Dim dtSource As DataTable = New DataTable()
            dtSource.Columns.Add("id")
            dtSource.Columns.Add("value")
            dtSource.Rows.Add("zh-CN", "简体中文")
            dtSource.Rows.Add("zh-TW", "繁體中文")
            dtSource.Rows.Add("en-US", "English")
            dtSource.Rows.Add("vi-VN", "Việt nam")
            Return dtSource
        End Get
        Set(value As DataTable)
            _dtLang = value
        End Set
    End Property

    Public Property dtClientMac() As DataTable
        Get
            If (_dtClientMac Is Nothing) Then
                _dtClientMac = New DataTable()
                _dtClientMac.Columns.Add("ClientMacAddress", Type.GetType("System.String"))
            End If
            Return _dtClientMac
        End Get

        Set(value As DataTable)
            _dtClientMac = value
        End Set
    End Property

    Dim _dtFactory As DataTable
    Public Property DtFactory() As DataTable
        Get
            Return _dtFactory
        End Get
        Set(value As DataTable)
            _dtFactory = value
        End Set
    End Property

    Dim _dtProfitC As DataTable
    Public Property DtProfitC() As DataTable
        Get
            Return _dtProfitC
        End Get
        Set(value As DataTable)
            _dtProfitC = value
        End Set
    End Property

    Dim AW_HOR_POSITIVE As Int32 = &H1
    Dim AW_HOR_NEGATIVE As Int32 = &H2
    Dim AW_VER_POSITIVE As Int32 = &H4
    Dim AW_VER_NEGATIVE As Int32 = &H8
    Dim AW_CENTER As Int32 = &H10
    Dim AW_HIDE As Int32 = &H10000
    Dim AW_ACTIVATE As Int32 = &H20000
    Dim AW_SLIDE As Int32 = &H40000
    Dim AW_BLEND As Int32 = &H80000
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function AnimateWindow(ByVal hwnd As IntPtr, ByVal dwTime As Integer, ByVal dwFlags As Integer) As Boolean
    End Function

#Region "初期化"

    '初期化
    Private Sub FrmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CobLang.DataSource = DtLang
        CobLang.ValueMember = DtLang.Columns(0).ColumnName
        CobLang.DisplayMember = DtLang.Columns(1).ColumnName
        'CobLang.SelectedIndex = 0

        SetBgImg()
        'AnimateWindow(Me.Handle, 1000, AW_BLEND)
        'If (Not GetClientMac()) Then
        '    Me.TxtUsername.Enabled = False
        '    Me.TxtPassword.Enabled = False
        '    Me.btnLogin.Enabled = False
        'Else
        '    Me.TxtUsername.Enabled = True
        '    Me.TxtPassword.Enabled = True
        '    Me.btnLogin.Enabled = True
        '    VbCommClass.VbCommClass.dtClientMac = dtClientMac
        'End If

        '******************************田玉琳 20181119 开始******************************
        '分离出数据库配置文件,放在86服务器上
        '獲取上次登錄用戶名
        LoadSqlServerName()

        '取得MES相关设置数据
        LoadMesSet()
        '设置切换厂区
        SetFactory()
        '******************************田玉琳 20180227 开始******************************
        '只强制修改91正式库密码
        'If SystemIP <> MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName And
        '    MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName.ToString.Contains("DG-MESDB.luxshare.com.cn") Then

        '    UpdateSqlServerName() '配置文件用新密码
        '    MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = SystemIP
        'End If
        '******************************田玉琳 20180227 结束******************************
        '******************************田玉琳 20181119 结束******************************

        '******************************田玉琳 20180302 开始******************************
        '增加日志处理,只有配置的用户才可以出log
        DbOperateUtils.UserId = TxtUsername.Text.Trim
        DbOperateReportUtils.UserId = TxtUsername.Text.Trim
        '******************************田玉琳 20180302 开始******************************

        If (Not GetCheckClientLogin()) Then
            Me.TxtUsername.Enabled = False
            Me.TxtPassword.Enabled = False
            Me.btnLogin.Enabled = False
        End If

        '判断更新程序是否需要更新 '
        'InitFact_ProfData()
        'IsHasUpdateSFCSUpdate()

        '读取本地配置
        LoadUserLogin()


        If VbCommClass.VbCommClass.AutoLogin = "1" Or VbCommClass.VbCommClass.AutoLogin = "2" Then
            AutoLogin()
        End If
        If VbCommClass.VbCommClass.AutoLogin = "3" Then
            AutoLogin1()
        End If

        SetLangTexts()
    End Sub
    ''' <summary>
    ''' 多语言版本UI控件赋值
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetLangTexts()

        lblFactory.Text = Multilingual.Resource.MesSystem_Login_lblFactory
        lblProfit.Text = Multilingual.Resource.MesSystem_Login_lblProfit
        lblUser.Text = Multilingual.Resource.MesSystem_Login_lblUser
        lblPwd.Text = Multilingual.Resource.MesSystem_Login_lblPwd
        btnLogin.Text = Multilingual.Resource.MesSystem_Login_btnLogin
        btnClose.Text = Multilingual.Resource.MesSystem_Login_btnClose
        lbllang.Text = Multilingual.Resource.MesSystem_Login_lblLang
        lblbtitle.Text = Multilingual.Resource.MesSystem_Login_lblbtitle

        ' chkSap.Text = Multilingual.Resource.MesSystem_Login_chkSap

    End Sub
#Region "更新程序是否需要更新?将更新程序更新-->关闭MES系统-->重新执行更新程序:不做任何操作"
    Private Sub IsHasUpdateSFCSUpdate()

        Dim sql As String = "select top 1 [filename],filetime,filecontent from M_Systemfile_t with (nolock) where   Usey=N'Y' and fileclass='0' and [filename]='SFCSUpdate.exe' order by intime desc"
        Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass

        Try
            Dim dt As DataTable = Conn.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                Dim filetime As String = dt.Rows(0)("filetime").ToString
                'Dim filetime As String = "SFCSUpdate.exe"
                Dim localPath As String = Application.StartupPath & "\" & Trim(dt.Rows(0)("filename")).ToString
                'Dim localPath As String = Application.StartupPath & "\SFCSUpdate.exe"
                Dim LoacalFileModifyDateTime As String = CType((File.GetLastWriteTime(localPath)), Date).ToString("yyyy-MM-dd HH:mm:ss").ToString()
                If My.Computer.FileSystem.FileExists(localPath) = False Or LoacalFileModifyDateTime <> CType(filetime, Date).ToString("yyyy-MM-dd HH:mm:ss").ToString() Then

                    System.Threading.Thread.Sleep(1000)
                    KillProcess("SFCSUpdate.exe")
                    'Dim CurrentFileName As String = dt.Rows(0)("filename").ToString
                    If My.Computer.FileSystem.FileExists(localPath) Then
                        File.SetAttributes(localPath, FileAttributes.Normal)
                    End If
                    Dim mFile() As Byte
                    mFile = dt.Rows(0)("filecontent")
                    Dim retry As Boolean = True
                    While retry
                        Try
                            System.Threading.Thread.Sleep(100)
                            Dim fs As FileStream = File.Create(localPath, mFile.Length - 1)
                            fs.Write(mFile, 0, mFile.Length - 1)
                            fs.Close()
                            fs.Dispose()
                            File.SetLastWriteTime(localPath, filetime)
                            retry = False
                        Catch ex As Exception
                            retry = True
                        End Try

                    End While

                    '重新启动更新程序，关闭MES系统'
                    'KillProcess("MesSystem.exe")
                    'System.Diagnostics.Process.Start(localPath)
                    'Application.ExitThread()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "更新程序更新失败", "提示信息", MessageBoxButtons.OK)
        End Try
    End Sub
    Private Sub KillProcess(ByVal ProStr As String)
        Dim SysPro As New Process
        For Each SysPro In System.Diagnostics.Process.GetProcessesByName(ProStr)
            Try
                If Not SysPro.CloseMainWindow Then
                    SysPro.CloseMainWindow()
                    SysPro.Close()
                    SysPro.Dispose()
                    SysPro.Kill()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                SysPro.Close()
            End Try
        Next

    End Sub
#End Region

    '解决域配置无权限
    Private Function GetClientMac() As Boolean
        Dim strLocalClientMACAddress As String = ""
        Dim rtValue As Boolean = False
        Try
            '2016-09-14    mafeng    解决域配置无权限，取消功能
            'Dim searcher As New System.Management.ManagementObjectSearcher("select * from win32_NetworkAdapterConfiguration")
            'Dim moc2 As System.Management.ManagementObjectCollection = searcher.Get()
            'For Each mo As System.Management.ManagementObject In moc2
            '    If CBool(mo("IPEnabled")) Then
            '        strLocalClientMACAddress = mo("MACAddress")
            Dim drTemp As DataRow
            drTemp = dtClientMac.NewRow()
            drTemp("ClientMacAddress") = "‎48-5A-B6-68-D8-41"   'strLocalClientMACAddress
            dtClientMac.Rows.Add(drTemp)
            dtClientMac.AcceptChanges()
            '    End If
            'Next
            rtValue = True
        Catch ex As Exception
            rtValue = False
            Lblmsg.Text = ("获取用户电脑IP异常，请确认登录用户是否有管理员权限")
        End Try
        Return rtValue
    End Function

    Private Sub LoadSqlServerName()
        Dim xmldoc As New XmlDocument
        Try
            xmldoc.Load(Application.StartupPath & "\LoginlogDB.xml") '讀取XML中的上次登錄用戶名
            Dim nodeList As XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As XmlNode In nodeList
                If LCase(xn.Name) = "systemip" Then
                    MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = xn.InnerText
                    Continue For
                End If
            Next
            Me.TxtPassword.Select()
        Catch ex As Exception
            'MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
            CreateConfigLoginXML()
        End Try
    End Sub

    Sub CreateConfigLoginXML()
        Dim XmlDoc As New XmlDocument
        Dim xmlelem As XmlElement
        Dim xmldecl As XmlDeclaration
        xmldecl = XmlDoc.CreateXmlDeclaration("1.0", "gb2312", Nothing)
        XmlDoc.AppendChild(xmldecl)
        xmlelem = XmlDoc.CreateElement("", "filelist", "")
        XmlDoc.AppendChild(xmlelem)
        Dim root As XmlNode = XmlDoc.SelectSingleNode("filelist")
        Dim xe As XmlElement = XmlDoc.CreateElement("ServerName") '创建一个<Node>节点   

        xe = XmlDoc.CreateElement("SystemIP") '创建一个<Node>节点   
        xe.InnerText = "data source=DG-MESDB.luxshare.com.cn;initial catalog=MESDB;uid=mes;pwd=016002068027066029014023030"
        root.AppendChild(xe)

        XmlDoc.Save(Application.StartupPath & "\LoginlogDB.xml")
        MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = xe.InnerText
    End Sub

    '獲取上次登錄用戶名
    Private Sub LoadMesSet()
        Dim xmldoc As New XmlDocument
        Try
            xmldoc.Load(Application.StartupPath & "\Loginlog.xml") '讀取XML中的上次登錄用戶名
            Dim nodeList As XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As XmlNode In nodeList
                If LCase(xn.Name) = "servername" Then
                    LoadFactory = xn.InnerText
                    Continue For
                End If                'If LCase(xn.Name) = "systemip" Then
                '    MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = xn.InnerText
                '    Continue For
                'End If
                If LCase(xn.Name) = "username" Then
                    Me.TxtUsername.Text = xn.InnerText
                    Continue For
                End If
                If LCase(xn.Name) = "printfile" Then
                    VbCommClass.VbCommClass.PrintDataModle = xn.InnerText
                    Continue For
                End If
                VbCommClass.VbCommClass.IsConSap = "Y"
                'If LCase(xn.Name) = "isconsap" Then
                '    If xn.InnerText = "1" Then
                '        VbCommClass.VbCommClass.IsConSap = "Y"
                '        chkSap.Checked = True
                '    Else
                '        VbCommClass.VbCommClass.IsConSap = "N"
                '        chkSap.Checked = False
                '    End If

                '    Continue For
                'End If

                If LCase(xn.Name) = "profitcenter" Then
                    VbCommClass.VbCommClass.profitcenter = xn.InnerText
                    'Dim i As Integer = Coprofitcenter.FindString(xn.InnerText)
                    'CobProfitcenter.Text = xn.InnerText
                    LoadProfitCenter = xn.InnerText
                    Continue For
                End If

                If LCase(xn.Name) = "islinkerp" Then
                    'IsAdLink = xn.InnerText , Mark by cq 20160113
                    'VbCommClass.VbCommClass.vIslinkErp = xn.InnerText
                    Continue For
                End If
                If LCase(xn.Name) = "erpserver" Then
                    ErpServer = xn.InnerText
                    Continue For
                End If
                'If LCase(xn.Name) = "testpfile" Then
                '    Me.TestPserver = xn.InnerText
                '    Continue For
                'End If
                If LCase(xn.Name) = "sopfile" Then
                    VbCommClass.VbCommClass.SopFilePath = xn.InnerText
                    Continue For
                End If
                If LCase(xn.Name) = "autologin" Then
                    VbCommClass.VbCommClass.AutoLogin = xn.InnerText
                    Continue For
                End If
            Next
            Me.TxtPassword.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
            Exit Sub
        End Try
    End Sub

    Private Sub InitFact_ProfData()
        Try
            Dim sql As StringBuilder = New StringBuilder()
            If VbCommClass.VbCommClass.IsConSap = "Y" Then
                sql.Append("select Factoryid,Factoryid+'-'+Shortname name,ISNULL(IsBU10,'')IsBU10 from m_Dcompany_t where usey='Y' and SapState='Y' ")
                sql.Append("select PROFITCENTER_CODE=Factoryid, Factoryid+'('+Shortname+')' AS PROFITCENTER_NAME,FACTORY_ID=PCompany  from m_Factory_t where usey='Y'  ")
            Else
                sql.Append("select Factoryid,Factoryid+'-'+Shortname name,ISNULL(IsBU10,'')IsBU10 from m_Dcompany_t where usey='Y' and SapState='N' ")
                sql.Append("SELECT PROFITCENTER_CODE, PROFITCENTER_CODE+'('+PROFITCENTER_NAME+')' AS PROFITCENTER_NAME,FACTORY_ID FROM m_ProfitCenter_t where ACTIVEFLGE='Y' ")

            End If
           
            Dim ds As DataSet = DbOperateUtils.GetDataSet(sql.ToString())
            DtFactory = ds.Tables(0)
            DtProfitC = ds.Tables(1)
            If (DtFactory.Rows.Count > 0) Then
                CobFartory.DisplayMember = "name"
                CobFartory.ValueMember = "Factoryid"

                CobFartory.DataSource = DtFactory
            End If
          
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Lblmsg.Text = "MES数据库连接失败..."
            DevComponents.DotNetBar.Controls.DesktopAlert.Show(Me.Lblmsg.Text, DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red)

        End Try
    End Sub

    Private Sub InitFact_ProfDataSap()
        Try
            Dim sql As StringBuilder = New StringBuilder()
            sql.Append("select Factoryid,Factoryid+'-'+Shortname name,ISNULL(IsBU10,'')IsBU10 from m_Factory_t where usey='Y' ")

            Dim ds As DataTable = DbOperateUtils.GetDataTable(sql.ToString())
            DtFactory = ds
            CobFartory.DisplayMember = "name"
            CobFartory.ValueMember = "Factoryid"

            CobFartory.DataSource = DtFactory
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Lblmsg.Text = "MES数据库连接失败..."
            DevComponents.DotNetBar.Controls.DesktopAlert.Show(Me.Lblmsg.Text, DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red)

        End Try
    End Sub


    '初始化长区信息
    Private Sub InitFactoryData()
        Try
            Dim sql As String = "select Factoryid,Factoryid+'-'+Shortname name from m_Dcompany_t where usey='Y'"
            Dim dtGroup As DataTable = DbOperateUtils.GetDataTable(sql)
            CobFartory.DisplayMember = "name"
            CobFartory.ValueMember = "Factoryid"

            CobFartory.DataSource = dtGroup
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Lblmsg.Text = "MES数据库连接失败..."
            DevComponents.DotNetBar.Controls.DesktopAlert.Show(Me.Lblmsg.Text, DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red)

        End Try
    End Sub

    '读取本地配置设置 
    Private Sub LoadUserLogin()
        If Not (String.IsNullOrEmpty(LoadFactory)) Then
            Me.CobFartory.SelectedIndex = Me.CobFartory.FindString(LoadFactory)
        End If

        If Not (String.IsNullOrEmpty(LoadProfitCenter)) Then
            Me.CobProfitcenter.SelectedIndex = Me.CobProfitcenter.FindString(LoadProfitCenter)
        End If
    End Sub


    Private Function GetCheckClientLogin() As Boolean
        Dim rtValue As Boolean = False
        Try
            If (Not GetLoginSetting()) Then
                rtValue = False
                Exit Function
            End If

            If (VbCommClass.VbCommClass.CheckClientMac = "Y") Then
                If (Not GetCheckClientMac(GetClientMacWhere(dtClientMac))) Then
                    rtValue = False
                    Exit Function
                Else
                    rtValue = True
                End If
            End If
            rtValue = True
        Catch ex As Exception
            Lblmsg.Text = "检查用户电脑权限异常,请确认网络连接"
            rtValue = False
        End Try
        Return rtValue
    End Function

    '取得数据库配置
    Private Function GetLoginSetting() As Boolean
        Dim rtValue As Boolean = False
        Try
            Dim strSQL As String = "SELECT PARAMETER_CODE,PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='MES' " &
                "AND PARAMETER_CODE IN ('CheckClientMac','VersionConn', 'CheckProgramFileVersion','IsAdLink','MESOracleConnect','MESOracleConnectSap','MESOracleConnectSapSerer','MESOracleConnectSapBU10','MESOracleConnectSapSererBU10','OutputLogUserList')"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            '设置默认数据,如果数据库取不到按这些设置 
            VbCommClass.VbCommClass.IsAdLink = IsAdLink
            VbCommClass.VbCommClass.CheckClientMac = "N"
            VbCommClass.VbCommClass.VersionConn = "N"
            VbCommClass.VbCommClass.CheckProgramFileVersion = "N"
            VbCommClass.VbCommClass.vIsTestSystem = "N"
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(rowIndex).Item(0).ToString.ToUpper()
                    Case "CheckClientMac".ToUpper()
                        VbCommClass.VbCommClass.CheckClientMac = dt.Rows(rowIndex).Item(1).ToString
                    Case "VersionConn".ToUpper()
                        VbCommClass.VbCommClass.VersionConn = dt.Rows(rowIndex).Item(1).ToString
                        SysDataHandle.SysDataBaseClass.ClientVersionConn = dt.Rows(rowIndex).Item(1).ToString
                    Case "CheckProgramFileVersion".ToUpper
                        VbCommClass.VbCommClass.CheckProgramFileVersion = dt.Rows(rowIndex).Item(1).ToString
                    Case "IsAdLink".ToUpper
                        VbCommClass.VbCommClass.IsAdLink = dt.Rows(rowIndex).Item(1).ToString
                        IsAdLink = dt.Rows(rowIndex).Item(1).ToString
                    Case "MESOracleConnect".ToUpper
                        DbOracleHelperSQL.connectionString = dt.Rows(rowIndex).Item(1).ToString
                    Case "MESOracleConnectSap".ToUpper
                        SysBasicClass.OracleOperateUtils.connectionStringSap = dt.Rows(rowIndex).Item(1).ToString
                    Case "MESOracleConnectSapSerer".ToUpper
                        SapServer = dt.Rows(rowIndex).Item(1).ToString
                        VbCommClass.VbCommClass.SapServer = dt.Rows(rowIndex).Item(1).ToString
                        'Case "MESOracleConnectSapBU10".ToUpper 'ADD 田玉琳20200304
                        '    ConnectionStringSapBU10 = dt.Rows(rowIndex).Item(1).ToString
                    Case "MESOracleConnectSapSererBU10".ToUpper 'ADD 田玉琳20200304
                        SapServerBU10 = dt.Rows(rowIndex).Item(1).ToString
                        'VbCommClass.VbCommClass.SapServerBU10 = dt.Rows(rowIndex).Item(1).ToString
                    Case "OutputLogUserList".ToUpper
                        DbOperateUtils.UserIdList = dt.Rows(rowIndex).Item(1).ToString
                        DbOperateReportUtils.UserIdList = dt.Rows(rowIndex).Item(1).ToString
                End Select
            Next
            rtValue = True
        Catch ex As Exception
            rtValue = False
            Lblmsg.Text = "获取系统登录设置信息异常,请检查网络连接"
        End Try
        Return rtValue
    End Function

    Private Function GetCheckClientMac(ByVal strClientMac As String) As Boolean
        Dim rtValue As Boolean = False
        Dim strSQL As String
        Try
            strSQL = " SELECT TOP 1 ClientMacId FROM m_ClientMac_t INNER JOIN m_ClientInfo_t ON m_ClientInfo_t.ClientInfoId=m_ClientMac_t.ClientInfoId " & _
                    " WHERE m_ClientMac_t.ClientMacAddress IN (" & strClientMac & ") AND m_ClientMac_t.StatusFlag='Y' AND m_ClientInfo_t.StatusFlag='Y'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

            If (dt.Rows.Count > 0) Then
                rtValue = True
            Else
                rtValue = False
            End If

            rtValue = True
        Catch ex As Exception
            Lblmsg.Text = "当前电脑没有登录MES授权"
            rtValue = False
        End Try
        Return False
    End Function

    Private Function GetClientMacWhere(ByVal dtTemp As DataTable) As String
        Dim strTemp As String = ""
        Try
            If (Not dtTemp Is Nothing) Then
                For i As Int16 = 0 To dtTemp.Rows.Count - 1
                    If (i = 0) Then
                        strTemp = "'" + dtTemp.Rows(0).Item("ClientMacAddress").ToString + "'"
                    Else
                        strTemp = strTemp + ",'" + dtTemp.Rows(0).Item("ClientMacAddress").ToString + "'"
                    End If
                Next
            End If
        Catch ex As Exception
            strTemp = ""
        End Try
        Return strTemp
    End Function

#End Region

#Region " 事件处理"

    '取消
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    '确认
    Private Sub CmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        VbCommClass.VbCommClass.vIslinkErp = "N"
        ExeLoginHandle()
    End Sub

    '密码输入后确认
    Private Sub TxtPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPassword.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            ExeLoginHandle()
        End If
    End Sub

    '用户输入后
    Private Sub TxtUsername_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUsername.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.TxtPassword.Focus()
        End If
    End Sub

    '厂区确认后
    Private Sub CobFartory_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CobFartory.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.TxtUsername.Focus()
        End If
    End Sub

    '厂区选择后
    Private Sub CobFartory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobFartory.SelectedIndexChanged
        If Me.CobFartory.SelectedValue Is Nothing Then
            Exit Sub
        End If

        If (String.IsNullOrEmpty(Me.CobFartory.SelectedValue.ToString.Trim)) Then
            Exit Sub
        End If
        Try
            'If chkSap.Checked = True Then
            '    Me.CobProfitcenter.DataSource = Nothing
            '    Exit Sub
            'End If

            Me.CobProfitcenter.DataSource = Nothing
            Dim dv As DataView = DtProfitC.DefaultView
            dv.RowFilter = " FACTORY_ID='" & Me.CobFartory.SelectedValue.ToString.Trim & "' "

            Me.CobProfitcenter.DisplayMember = "PROFITCENTER_NAME"
            Me.CobProfitcenter.ValueMember = "PROFITCENTER_CODE"
            Me.CobProfitcenter.DataSource = dv
            Me.dvPro = dv

            '**************************************田玉琳 20200304 增加 开始**************************************
            '增加厂区
            Dim dr() As DataRow = DtFactory.Select(" Factoryid='" & Me.CobFartory.SelectedValue.ToString.Trim & "' ")
            If dr.Length > 0 And SapServerBU10 IsNot Nothing And SapServer IsNot Nothing Then
                If dr(0)(2) = "Y" Then
                    VbCommClass.VbCommClass.SapServer = SapServerBU10
                Else
                    VbCommClass.VbCommClass.SapServer = SapServer
                End If
                'MessageUtils.ShowWarning(VbCommClass.VbCommClass.SapServer)
            End If
            '**************************************田玉琳 20200304 增加 结束**************************************

        Catch ex As Exception
            MessageBox.Show("获取工厂利润中心失败,请确认网络是否连接正常，重启后重试。")
            DevComponents.DotNetBar.Controls.DesktopAlert.Show("获取工厂利润中心失败,请确认网络是否连接正常,重启后重试", DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red)

        End Try
    End Sub
    Dim _dvPro As DataView
    ''' <summary>
    ''' 载入所在公司对应的子工厂列表、利润中心列表，以方便随时切换
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property dvPro() As DataView
        Get
            Return _dvPro
        End Get
        Set(value As DataView)
            _dvPro = value
        End Set
    End Property

    Private Sub chkSap_CheckedChanged(sender As Object, e As EventArgs)
        SetFactory()
    End Sub


#End Region

#Region "方法"

    Private Sub SetFactory()
        '判断更新程序是否需要更新 '
        'If chkSap.Checked = True Then
        '    lblProfit.Visible = False
        '    CobProfitcenter.Visible = False
        '    lblUser.Location = New Point(256, 125)
        '    TxtUsername.Location = New Point(308, 125)

        '    VbCommClass.VbCommClass.IsConSap = "Y"
        '    InitFact_ProfDataSap()
        'Else
        '    lblProfit.Visible = True
        '    CobProfitcenter.Visible = True
        '    lblUser.Location = New Point(256, 141)
        '    TxtUsername.Location = New Point(308, 141)

        '    VbCommClass.VbCommClass.IsConSap = "N"

        '    InitFact_ProfData()
        'End If
        'If chkSap.Checked = True Then
        '    VbCommClass.VbCommClass.IsConSap = "Y"

        '    lblFactory.Text = "公司代码："
        '    lblProfit.Text = "工厂代码："
        '    'InitFact_ProfDataSap()
        'Else

        '    VbCommClass.VbCommClass.IsConSap = "N"
        '    lblProfit.Text = "利润中心："
        '    lblFactory.Text = "营运中心："
        '    ' InitFact_ProfData()
        'End If
        InitFact_ProfData()
    End Sub

    '执行登录处理
    Private Sub ExeLoginHandle()
        Dim sqlstr As String = ""

        If CobFartory.Text.Trim = "" Then
            Exit Sub
        End If

        '先取得用户相关数据
        SetLoginUserInfo(TxtUsername.Text)

        '如果是外协用户不用验证域认证
        If IsOutUser = "Y" Then
            IsAdLink = "N"
        End If

        '连接到SAP
        'If chkSap.Checked = True Then
        '    VbCommClass.VbCommClass.IsConSap = "Y"

        'Else
        '    VbCommClass.VbCommClass.IsConSap = "N"
        'End If

        Try
            If (My.Computer.Network.Ping(ErpServer)) Then
                IsLinkErp = "Y"
                VbCommClass.VbCommClass.vIslinkErp = "Y"
            Else
                IsLinkErp = "N"
                VbCommClass.VbCommClass.vIslinkErp = "N"
            End If
        Catch exPing As PingException
            IsLinkErp = "N"
            VbCommClass.VbCommClass.vIslinkErp = "N"
        Catch exInvalidate As InvalidOperationException
            IsLinkErp = "N"
            VbCommClass.VbCommClass.vIslinkErp = "N"
        End Try

        Try
            '*************************田玉琳 开始 20181112 *************************
            'Dim dt As DataTable = DbOperateUtils.GetDataTable("select userid from m_Users_t where userid='" & TxtUsername.Text & "' and usey='1' ")
            'If dt.Rows.Count = 0 Then
            '    Lblmsg.Text = "该用户不存在或者没有MES系统权限...."
            '    DevComponents.DotNetBar.Controls.DesktopAlert.Show(Lblmsg.Text, DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red)
            '    Exit Sub
            'End If
            If usey <> "1" Then
                Lblmsg.Text = Multilingual.Resource.MesSystem_Login_UserNotExists '"该用户不存在或者没有MES系统权限...."
                DevComponents.DotNetBar.Controls.DesktopAlert.Show(Lblmsg.Text, DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red)
                Exit Sub
            End If
            '*************************田玉琳 结束 20181112 *************************
        Catch ex As Exception
            Lblmsg.Text = ex.Message
            Exit Sub
        End Try

        If VbCommClass.VbCommClass.AutoLogin = "2" Then
            AutoLogin()
        ElseIf VbCommClass.VbCommClass.AutoLogin = "3" Then
            AutoLogin1()
        Else
            Dim tool As New MainFrame.SysCheckData.TextHandle
            Dim pwdkey As String = tool.EnCryptPassword(IIf(VbCommClass.VbCommClass.AutoLogin = "0", Me.TxtPassword.Text, "123")) 'tool.EnCryptPassword(Me.TxtPassword.Text)
            Dim refMessage As String = ""
            If IsAdLink = "Y" Then
                '*****************************田玉琳 20170926 LDAP验证方法 开始******************************************
                CheckLDAPUser(refMessage)
                '*****************************田玉琳 20170926 LDAP验证方法 结束******************************************
            ElseIf IsAdLink = "E" Then
                refMessage = "" '不验证密码，任何密码都可以登录
            Else
                refMessage = MainFrame.SysCheckData.SysMessageClass.GetAuthenticate(Me.TxtUsername.Text.Trim(), pwdkey)
            End If

            If refMessage <> "" Then
                Lblmsg.Text = refMessage.ToString()
                DevComponents.DotNetBar.Controls.DesktopAlert.Show(Lblmsg.Text, DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red)
                Exit Sub
            Else
                '*****************************田玉琳 20170302 开始******************************************
                SysMessageClass.UseId = TxtUsername.Text
                VbCommClass.VbCommClass.UseId = TxtUsername.Text
                VbCommClass.VbCommClass.Language = CobLang.Text

                '连接到SAP
                'If chkSap.Checked = True Then
                '    VbCommClass.VbCommClass.PCompany = CobFartory.Text.Split("-")(0)
                '    If (Me.CobProfitcenter.Items.Count > 0) Then
                '        VbCommClass.VbCommClass.Factory = CobProfitcenter.Text.Trim.Split("(")(0)
                '    Else
                '        VbCommClass.VbCommClass.Factory = ""
                '    End If
                '    VbCommClass.VbCommClass.profitcenter = ""
                'Else
                '    VbCommClass.VbCommClass.PCompany = ""
                '    VbCommClass.VbCommClass.Factory = CobFartory.Text.Split("-")(0)
                '    If (Me.CobProfitcenter.Items.Count > 0) Then
                '        VbCommClass.VbCommClass.profitcenter = CobProfitcenter.Text.Trim.Split("(")(0)
                '    Else
                '        VbCommClass.VbCommClass.profitcenter = ""
                '    End If
                'End If
                VbCommClass.VbCommClass.PCompany = CobFartory.Text.Split("-")(0)
                If (Me.CobProfitcenter.Items.Count > 0) Then
                    VbCommClass.VbCommClass.Factory = CobProfitcenter.Text.Trim.Split("(")(0)
                Else
                    VbCommClass.VbCommClass.Factory = ""
                End If
                VbCommClass.VbCommClass.profitcenter = ""


                SysBasicClass.OracleOperateUtils.FactoryID = VbCommClass.VbCommClass.Factory
                '确认是否有更新过权限数据
                If OMd <> "Y" Then
                    Dim frm As New FrmSetUserProfit
                    frm.ShowDialog()

                    '没有设置成功，要重新设置
                    If frm.DialogResult <> Windows.Forms.DialogResult.OK Then
                        Exit Sub
                    End If
                End If

                '设置成功后，选择错误的利润中心登录
                If IsHaveProfitAuth() = False Then
                    Exit Sub
                End If

                '***************************** Yuanfeng.Yu 20180829 ****************************************
                Dim frmMainForm As New FrmMainDynamic

                '*****************************田玉琳 20170302 结束******************************************
                'Dim frmMainForm As New frmMain
                AnimateWindow(Handle, 1000, AW_SLIDE Or AW_HIDE Or AW_BLEND)
                Me.Hide()

                ModfiyLogInName()

                SaveLoginLog()
                frmMainForm.dvPro = Me.dvPro
                frmMainForm.Show()

                'VbCommClass.VbCommClass.Factory = ""
                'VbCommClass.VbCommClass.profitcenter = ""

                frmMainForm.WindowState = FormWindowState.Maximized
            End If
        End If
    End Sub

    '验证LDAP用户密码是否正确
    Private Sub CheckLDAPUser(ByRef message As String)
        Dim userId As String = Me.TxtUsername.Text.Trim().ToUpper()
        Dim pwd As String = Me.TxtPassword.Text

        Dim ldap As LDAPHelper = New LDAPHelper(userId, pwd)

        '验证
        If (ldap.VerifyUser(message)) = False Then
            ''如果共通方法验证不OK再做一次API调用,存在部分电脑外网电脑用VPN连接不上 
            Dim strPath = "{" + String.Format("""code"":""{0}"",""password"" :""{1}""", userId, pwd) + "}"
            Dim cheStr As String = SysBasicClass.ApiHelper.Post("https://hr.luxshare-ict.com/api/Account/CheckUser", strPath)

            message = cheStr.Split(",")(1).Split(":")(1).Replace("}", "").Replace("{", "").Replace("""", "")

            If (message <> "" And message.Contains("账号或密码不正确") = False) Then '有错误信息加入到LOG中
                'SysMessageClass.WriteErrLog(New Exception(message), "Login", "ExeLoginHandle", "dns")
            End If

            '修改错误信息
            If (message <> "") Then
                message = Multilingual.Resource.MesSystem_Login_PasswordError '"密码不正确！"
            End If
        End If
    End Sub

    '确认是否有利润中心权限
    Private Function IsHaveProfitAuth()
        Dim strSQL As String = " DECLARE @strmsgid varchar(1), @strmsgText nvarchar(150)" &
                               " EXEC [GetCheckUserRight] '{0}','{1}','{2}',@strmsgid OUTPUT ,@strmsgText OUTPUT " &
                               " SELECT @strmsgid,@strmsgText"
        strSQL = String.Format(strSQL, SysMessageClass.UseId, VbCommClass.VbCommClass.Factory, VbCommClass.VbCommClass.profitcenter)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0) = "1" Then
                Lblmsg.Text = dt.Rows(0)(1).ToString
                Return False
            End If
        End If
        Return True
    End Function

    ''' <summary>
    ''' 记录登录用户主机名称，IP等信息，方便统计
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveLoginLog()
        Dim strsql As StringBuilder = New StringBuilder
        Dim ipAddress As String = "127.0.0.1"
        Dim HostName As String = System.Net.Dns.GetHostName
        Dim arrIPAddresses() As Net.IPAddress = Net.Dns.GetHostAddresses(Net.Dns.GetHostName())
        Dim ip As Net.IPAddress
        For Each ip In arrIPAddresses
            If ip.AddressFamily.Equals(Net.Sockets.AddressFamily.InterNetwork) Then
                ipAddress = ip.ToString()
            End If
        Next
        strsql.Append("declare @remark nvarchar(250)=N'用户登录验证通过，主机名称：" & My.Computer.Name & "'")
        strsql.Append("declare @Userid varchar(30)='" & SysMessageClass.UseId.ToString & "' ")
        strsql.Append("INSERT INTO [m_UserOperateLog_t]([user_id],[modle_type],[action_type],[remark],[user_ip],[intime]) VALUES (@Userid,N'" & My.Computer.Name & "','Login',@remark,'" & ipAddress & "',GETDATE()) ")
        DbOperateUtils.ExecSQL(strsql.ToString)
    End Sub

    ''' <summary>
    ''' 设置登录用户信息
    ''' </summary>
    ''' <param name="userid"></param>
    ''' <remarks>提前取得用户相关信息</remarks>
    Private Sub SetLoginUserInfo(ByVal userid As String)
        Dim strSql As String = Nothing
        Dim dt As New DataTable
        strSql = " select UserName,Dept,StyleID=isnull(StyleID,99),IsOutUser = isnull(IsOutUser,''),usey = isnull(usey,''),OMd = isnull(OMd,'') " &
                 " from m_Users_t where UserID='" & userid & "'"

        dt = DbOperateUtils.GetDataTable(strSql)
        If dt.Rows.Count > 0 Then
            VbCommClass.VbCommClass.UseName = dt.Rows(0)("UserName").ToString
            VbCommClass.VbCommClass.UseDeptid = dt.Rows(0)("Dept").ToString
            VbCommClass.VbCommClass.StyleID = dt.Rows(0)("StyleID").ToString
            IsOutUser = dt.Rows(0)("IsOutUser").ToString
            usey = dt.Rows(0)("usey").ToString
            OMd = dt.Rows(0)("OMd").ToString
        End If
    End Sub


    '保存上次登入用戶
    Private Sub ModfiyLogInName()
        Dim XmlDoc As New XmlDocument
        Try
            XmlDoc.Load(Application.StartupPath & "\Loginlog.xml")  ''打開XML文件
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
            DevComponents.DotNetBar.Controls.DesktopAlert.Show(ex.Message & vbNewLine & "不存在XML文件", DevComponents.DotNetBar.Controls.eDesktopAlertColor.Red)

        End Try
        File.SetAttributes(Application.StartupPath & "\Loginlog.xml", FileAttributes.Normal) ''設置XML文件為可讀寫

        Dim nodeList As XmlNodeList = XmlDoc.SelectSingleNode("filelist").ChildNodes
        Dim bHave As Boolean = False

        For Each xn As XmlNode In nodeList
            If LCase(xn.Name) = "language" Then
                xn.InnerText = CobLang.Text
                Language = CobLang.Text
                Continue For
            End If
            If LCase(xn.Name) = "username" Then
                xn.InnerText = Me.TxtUsername.Text
                Continue For
            End If
            If LCase(xn.Name) = "servername" Then
                xn.InnerText = CobFartory.Text
                Continue For
            End If

            'If LCase(xn.Name) = "isconsap" Then
            '    bHave = True
            '    If chkSap.Checked = True Then
            '        xn.InnerText = 1
            '    Else
            '        xn.InnerText = 0
            '    End If
            '    Continue For
            'End If
            If LCase(xn.Name) = "profitcenter" Then
                xn.InnerText = CobProfitcenter.Text
                Continue For
            End If
            If LCase(xn.Name) = "autologin" Then
                xn.InnerText = VbCommClass.VbCommClass.AutoLogin
                Continue For
            End If
            ''add by 马跃平 2018-06-13 防止用户打印获取模板路径异常
            'If LCase(xn.Name) = "printfile" Then
            '    xn.InnerText = "\\192.168.20.123\PrintFile2\" + CobFartory.SelectedValue + "\" + CobProfitcenter.SelectedValue + "\"
            '    Continue For
            'End If
        Next

        'If bHave = False Then
        '    Dim root As XmlNode = XmlDoc.SelectSingleNode("filelist")
        '    Dim xe As XmlElement
        '    xe = XmlDoc.CreateElement("isconsap") '创建一个<Node>节点   
        '    If chkSap.Checked = True Then
        '        xe.InnerText = "1"
        '    Else
        '        xe.InnerText = "0"
        '    End If
        '    'root.AppendChild(xe)
        '    root.InsertBefore(xe, root.FirstChild)
        'End If

        XmlDoc.Save(Application.StartupPath & "\Loginlog.xml")
        ''更新M_UserSetting_t表数据
        UpdateUserSetting("FactoryCode", CobFartory.Text)
        UpdateUserSetting("ProfitCenter", CobProfitcenter.Text)
        UpdateUserSetting("AutoLogin", VbCommClass.VbCommClass.AutoLogin)
    End Sub

    ''' <summary>
    ''' 更新用户配置信息
    ''' </summary>
    ''' <param name="paramCode">配置代码</param>
    ''' <param name="paramCodeValue">配置名称</param>
    ''' <remarks></remarks>
    Private Sub UpdateUserSetting(ByRef paramCode, ByRef paramCodeValue)
        Dim sql As String = ""
        sql = "IF EXISTS(SELECT * FROM M_USERSETTING_T WHERE USERID='" + Me.TxtUsername.Text.Trim() + "' AND PARAMETER_CODE='" + paramCode + "')"
        sql += " BEGIN"
        sql += " UPDATE M_USERSETTING_T SET PARAMETER_VALUES=N'" + paramCodeValue + "',UPDATETIME=GETDATE() WHERE USERID='" + Me.TxtUsername.Text.Trim() + "' AND PARAMETER_CODE='" + paramCode + "'"
        sql += " END"
        sql += " ELSE"
        sql += " BEGIN"
        sql += " INSERT INTO M_USERSETTING_T(USERID,PARAMETER_CODE,PARAMETER_VALUES,UPDATEUSER_ID)"
        sql += " VALUES('" + Me.TxtUsername.Text.Trim() + "','" + paramCode + "',N'" + paramCodeValue + "','" + Me.TxtUsername.Text.Trim() + "')"
        sql += " END"
        DbOperateUtils.ExecSQL(sql)
    End Sub

    '自动登录，不需要密码
    Private Sub AutoLogin()
        If VbCommClass.VbCommClass.AutoLogin = "2" Then
            Try
                Dim frmLotScan As Form = CType(Activator.CreateInstance(Type.GetType("RCard.FrmLotScan,RCard")), Form) ''客戶端呼叫實例
                frmLotScan.TopMost = True
                ModfiyLogInName()
                VbCommClass.VbCommClass.Factory = LoadFactory.Split("-")(0)
                VbCommClass.VbCommClass.profitcenter = LoadProfitCenter.Split("(")(0)

                frmMain.SaveAppUseInfo("RCard.FrmLotScan", "流程卡工站扫描")
                frmLotScan.Activate()
                frmLotScan.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub AutoLogin1()
        If VbCommClass.VbCommClass.AutoLogin = "3" Then
            Try
                Dim frmLotScan As Form = CType(Activator.CreateInstance(Type.GetType("EquipmentManagement.FrmShowEquList,EquipmentManagement")), Form) ''客戶端呼叫實例
                frmLotScan.TopMost = True
                ModfiyLogInName()
                VbCommClass.VbCommClass.Factory = LoadFactory.Split("-")(0)
                VbCommClass.VbCommClass.profitcenter = LoadProfitCenter.Split("(")(0)

                frmMain.SaveAppUseInfo("EquipmentManagement.FrmShowEquList", "工治具管理轮播看板")
                frmLotScan.Activate()
                frmLotScan.WindowState = FormWindowState.Maximized
                frmLotScan.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
        End If
    End Sub

#End Region

    Private Sub FrmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        AnimateWindow(Handle, 1000, AW_SLIDE Or AW_HIDE Or AW_BLEND)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        VbCommClass.VbCommClass.vIslinkErp = "N"
        ExeLoginHandle()
    End Sub

    Private Sub SetBgImg()
        Dim i As Integer
        Dim r As Random = New Random(Integer.Parse(DateTime.Now.ToString("HHmmssfff")) + i)
        Dim num As Integer = r.Next(1, 5) '随机获取背景

        Select Case num
            Case 1
                Me.BackgroundImage = MesSystem.My.Resources.Resources.bg01
            Case 2
                Me.BackgroundImage = MesSystem.My.Resources.Resources.bg02
            Case 3
                Me.BackgroundImage = MesSystem.My.Resources.Resources.bg03
            Case 4
                Me.BackgroundImage = MesSystem.My.Resources.Resources.bg04
        End Select
    End Sub


    '******************************田玉琳 20180227******************************
    '更新用户本地连接,可以在运行几个月后，删除
    'Private Sub UpdateSqlServerName()
    '    Dim XmlDoc As New XmlDocument

    '    XmlDoc.Load(Application.StartupPath & "\Loginlog.xml")  ''打開XML文件
    '    File.SetAttributes(Application.StartupPath & "\Loginlog.xml", FileAttributes.Normal) ''設置XML文件為可讀寫

    '    Dim nodeList As XmlNodeList = XmlDoc.SelectNodes("filelist/SystemIP")

    '    For Each xn As XmlNode In nodeList
    '        If LCase(xn.Name) = "systemip" Then
    '            xn.InnerText = SystemIP
    '            Continue For
    '        End If
    '    Next
    '    XmlDoc.Save(Application.StartupPath & "\Loginlog.xml")
    'End Sub

    '确认是否更新过数据
    'Private Function GetIsUpdated()
    '    Dim strSQL As String = "select UserID from m_Users_t where OMd = 'Y' and UserID = '{0}'"
    '    strSQL = String.Format(strSQL, SysMessageClass.UseId)

    '    Dim cnt As Integer = DbOperateUtils.GetRowsCount(strSQL)

    '    If cnt = 0 Then
    '        Return False
    '    Else
    '        Return True
    '    End If
    'End Function
    '
    'Private Function DoGet(ByVal url As String) As String

    '    'url = "https://hr.luxshare-ict.com/api/Account/CheckUser"

    '    Dim data As String = ""
    '    Dim webReqst As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
    '    webReqst.Method = "GET"
    '    'webReqst.UserAgent = DefaultUserAgent
    '    webReqst.KeepAlive = True

    '    webReqst.Timeout = 30000

    '    Try
    '        Dim webResponse As HttpWebResponse = CType(webReqst.GetResponse(), HttpWebResponse)

    '        If webResponse.StatusCode = HttpStatusCode.OK And webResponse.ContentLength < 1024 * 1024 Then
    '            Dim reader As StreamReader = New StreamReader(webResponse.GetResponseStream(), Encoding.Default)
    '            data = reader.ReadToEnd()
    '        End If
    '    Catch

    '    End Try

    '    Return data
    'End Function

    Private Sub CobLang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CobLang.SelectedIndexChanged
        Dim lang As String = CobLang.SelectedValue.ToString()
        If (lang <> "" And lang <> "System.Data.DataRowView") Then
            Thread.CurrentThread.CurrentCulture = New CultureInfo(lang)
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(lang)
        End If
        SetLangTexts()
    End Sub

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub
End Class
