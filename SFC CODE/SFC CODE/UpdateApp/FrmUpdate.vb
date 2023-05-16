Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Net
''' <summary>
''' 创建者：华松
''' 
''' 修改者：田玉琳
''' 修改日期：20181120
''' 修改内容：
''' 正式库
''' 1.默认从服务器下载文件，下载地址：http://mes.luxshare-ict.com/mesdb/LoginlogDB.xml
''' 服务器如果没有文件不下载
''' 2.读取本地文件,没有本地文件自动创建一个服务器文件
''' 以后数据库服务器文件读取从LoginlogDB中读取
''' 测试库
''' 读到本地文件有155内容,文件不从服务器下载
''' 
''' </summary>
''' <remarks></remarks>
''' 
Public Class FrmUpdate
    Dim worker As BackgroundWorker = Nothing
    Dim Filepath As String = Application.StartupPath
    Dim Conn As New DbClass.SysDataHandle.SysDataBaseClass
    Dim SysClass As String = "0"
    Dim StartApp As String = "MesSystem.exe"
    Dim AppName As String = "MES"
    Dim SqlserverName As String = "" '"data source=172.17.32.12;initial catalog=MESDB;uid=sa;pwd=050033068027066029014023030"
    Dim updatecount As Int16 = 0
    Dim ServerIP As String
    Dim IsTESTServer As Boolean = False '是否测试服务器

    '新增从服务器上取得文件路径
    Dim ServerPath As String = "http://vnmes.luxshare-ict.com/mesdblxvn/LoginlogDB.xml"
    Dim localPath As String = Application.StartupPath & "\LoginlogDB.xml"

    'Dim m_strServerName As String = String.Empty  'loginlog.servername
    'Dim m_strProfitCenter As String = String.Empty
    'Dim m_strUserID As String = String.Empty
    'Dim m_strAutolog As String = String.Empty
    'Dim AttribeServer As String
    'Dim Start As String
    'Dim Count As Integer = 0
    'Dim NewDt As DateTime = System.DateTime.Now

    Dim m_CheckClientMac As String
    Dim m_CheckProgramFileVersion As String
    Dim m_ReleasedVersion As String
    Dim _dtClientMac As DataTable
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

    Public Property CheckClientMac() As String
        Get
            If (m_CheckClientMac Is Nothing) Then
                m_CheckClientMac = "N"
            End If
            Return m_CheckClientMac
        End Get
        Set(ByVal value As String)
            m_CheckClientMac = value
        End Set
    End Property

    Public Property CheckProgramFileVersion() As String
        Get
            If (m_CheckProgramFileVersion Is Nothing) Then
                m_CheckProgramFileVersion = "N"
            End If
            Return m_CheckProgramFileVersion
        End Get
        Set(ByVal value As String)
            m_CheckProgramFileVersion = value
        End Set
    End Property

    Public Property ReleasedVersion() As String
        Get
            If (m_ReleasedVersion Is Nothing) Then
                m_ReleasedVersion = "N"
            End If
            Return m_ReleasedVersion
        End Get
        Set(ByVal value As String)
            m_ReleasedVersion = value
        End Set
    End Property

    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        progressBar1.Minimum = 0
        progressBar1.Maximum = 100
        worker = New BackgroundWorker()
        worker.WorkerReportsProgress = True
        worker.WorkerSupportsCancellation = True

        AddHandler worker.DoWork, AddressOf worker_DoWork
        AddHandler worker.ProgressChanged, AddressOf worker_ProgressChanged
        AddHandler worker.RunWorkerCompleted, AddressOf worker_RunWorkerCompleted
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub
    Private Sub worker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Try
            If Not e.Argument Is Nothing Then
                Dim sbSql As New StringBuilder()
                Dim strMacWhere As String
                Dim totalByte As Long = 0
                Dim buffLength As Int32 = 20480
                Dim Offset As Long = 0
                Dim BytesRead As Long = 0
                Dim buff As Byte()
                ReDim buff(buffLength)

                'Dim sql As String = String.Format("select [filename],filetime,sizes=isnull(size,0) from M_Systemfile_t with (nolock) where usey='Y' and fileclass='{0}' and Filename<>'SFCSUpdate.exe' order by intime", SysClass)

                If (ReleasedVersion = "Y") Then
                    strMacWhere = GetClientMacWhere(dtClientMac)
                    sbSql.Append(" SELECT DISTINCT * FROM ( ")
                    sbSql.Append(" SELECT DISTINCT Fileno, [filename], FileTime, ISNULL(Size, 0) AS Size ") ', filecontent 
                    sbSql.Append(" FROM M_Systemfile_t  with (nolock) INNER JOIN m_ClientInfo_t ON m_ClientInfo_t.ReleasedVersionId=M_Systemfile_t.ReleasedVersionId ")
                    sbSql.Append(" INNER JOIN m_ClientMac_t ON m_ClientMac_t.ClientInfoId=m_ClientInfo_t.ClientInfoId ")
                    sbSql.Append(" WHERE usey='Y' and fileclass='0' and filename<>'SFCSUpdate.exe' AND m_ClientMac_t.ClientMacAddress IN (" & strMacWhere & ") ")
                    sbSql.Append(" UNION ALL SELECT DISTINCT Fileno, [filename], FileTime, ISNULL(Size, 0) AS Size ")  ', filecontent
                    sbSql.Append(" FROM M_Systemfile_t INNER JOIN m_ReleasedVersion_t ON m_ReleasedVersion_t.ReleasedVersionId=M_Systemfile_t.ReleasedVersionId ")
                    sbSql.Append(" WHERE usey='Y' and fileclass='0' and filename<>'SFCSUpdate.exe' and m_ReleasedVersion_t.ReleasedVersionTypeId='1' ")
                    sbSql.Append(" AND [filename] NOT IN (SELECT [filename] FROM M_Systemfile_t with (nolock) ")
                    sbSql.Append(" INNER JOIN m_ClientInfo_t ON m_ClientInfo_t.ReleasedVersionId=M_Systemfile_t.ReleasedVersionId ")
                    sbSql.Append(" INNER JOIN m_ClientMac_t ON m_ClientMac_t.ClientInfoId=m_ClientInfo_t.ClientInfoId ")
                    sbSql.Append(" WHERE usey='Y' and fileclass='0' and filename<>'SFCSUpdate.exe' AND m_ClientMac_t.ClientMacAddress IN (" & strMacWhere & ")) ")
                    sbSql.Append(" ) TEMP ")
                Else
                    sbSql.Append("select Fileno, [filename], FileTime, ISNULL(Size, 0) AS Size from M_Systemfile_t with (nolock) where usey='Y' and fileclass='0' and filename<>'SFCSUpdate.exe' and EffectTime<getdate() ")  ', filecontent
                End If

                Dim sql As String = String.Format(sbSql.ToString, SysClass)
                Dim dt As DataTable = Conn.GetDataTable(sql)
                Try

                    Dim mFile() As Byte
                    Dim indexcurr As Integer = 0
                    For k = 0 To dt.Rows.Count - 1
                        worker.ReportProgress(0)
                        Offset = 0
                        Dim LoacalFileModifyDateTime As String = CType((File.GetLastWriteTime(Filepath & "\" & Trim(dt.Rows(k)("filename")).ToString)), Date).ToString("yyyy-MM-dd HH:mm:ss").ToString()

                        If My.Computer.FileSystem.FileExists(Filepath & "\" & dt.Rows(k)("filename").ToString) = False Or LoacalFileModifyDateTime <> CType(Trim(dt.Rows(k)("filetime")), Date).ToString("yyyy-MM-dd HH:mm:ss").ToString Then
                            Dim LoadFName As String = Trim(dt.Rows(k)("filename")).ToString
                            Dim Fileno As String = dt.Rows(k)("Fileno").ToString.Trim
                            Dim sqlone As String = String.Format("select top 1 [filename],filetime,sizes=isnull(size,0),filecontent from M_Systemfile_t with (nolock) where usey='Y' and fileclass='{0}' and Filename='{1}' and Fileno='{2}' and EffectTime<getdate() ", SysClass, LoadFName, Fileno)
                            Dim Dread As SqlDataReader = Conn.GetDataReader(sqlone)
                            If Dread.Read Then
                                Dim fs As FileStream = File.Create(Filepath & "\" & Dread.Item("filename").ToString)
                                Dim fname As String = Dread.Item("filename").ToString
                                Dim fsize As Long = Dread.Item("sizes")
                                SetText(fname, lblinfo)

                                SetItemValue("更新文件：" & fname + " 进行中......", ListBox1, indexcurr)
                                If fsize = 0 Then
                                    mFile = Dread.Item(3)
                                    totalByte = mFile.Length
                                Else
                                    totalByte = fsize
                                End If

                                SetText(Offset.ToString + "/" + totalByte.ToString, lblprogress)
                                'SetText("b1", Label2)
                                BytesRead = Dread.GetBytes(3, Offset, buff, 0, buffLength)
                                While BytesRead > 0
                                    fs.Write(buff, 0, BytesRead)
                                    fs.Flush()
                                    Offset += BytesRead
                                    Dim percent As Integer = CType((Offset * 100 / totalByte), Integer)
                                    SetText(Offset.ToString + "/" + totalByte.ToString, lblprogress)
                                    SetItemValue("更新文件：" & fname + " " & percent & "%", ListBox1, indexcurr)

                                    worker.ReportProgress(percent)
                                    BytesRead = Dread.GetBytes(3, Offset, buff, 0, buffLength)
                                End While
                                fs.Close()
                                fs.Dispose()

                                'If Dread.Item("filename").ToString.Contains("LoginlogDB") Then 'cq20160128
                                '    Call ReWriteLogFile(Now)
                                'End If

                                File.SetLastWriteTime(Filepath & "\" & Dread.Item("filename").ToString, Dread.Item("filetime"))

                                worker.ReportProgress(100)
                                SetItemValue("更新文件：" & fname + " 100%", ListBox1, indexcurr)
                                SetText("检测到有" & updatecount.ToString & "个文件需要更新,已完成" & (indexcurr + 1).ToString & "/" & updatecount.ToString, Label1)
                                indexcurr += 1
                            End If
                            Dread.Close()


                        End If
                    Next
                    Conn.PubConnection.Close()
                Catch ex As Exception

                    MessageBox.Show("有异常发生：" + ex.Message.ToString + "退出自动更新")
                Finally
                    Conn.PubConnection.Close()
                End Try

            End If
        Catch ex As Exception
            worker.ReportProgress(100, ex)
        End Try
    End Sub
    Private Sub worker_ProgressChanged(ByVal sender As System.Object, ByVal e As ProgressChangedEventArgs)
        Try
            If Not e.UserState Is Nothing Then
                lblMsg.Text = CType(e.UserState, Exception).Message
            Else
                progressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub worker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        'lblMsg.Text = "文件复制完成"
        If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & StartApp) Then

            System.Diagnostics.Process.Start(Application.StartupPath & "\" & StartApp)
            Application.ExitThread()
        Else
            Me.ListBox1.Items.Add("启动程序【" & StartApp & "】不存在!自动退出")
            MessageBox.Show("启动程序【" & StartApp & "】不存在!程序自动退出")
            Me.Close()
        End If

    End Sub
  
    Private Sub FrmUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '强制取本地文件数据
            LoadSqlServerNametest()
            If IsTESTServer = False Then
                FromServerGetLoginXML()
                LoadSqlServerName()
            End If

            If (GetLoginSetting()) Then
                GetClientMac()
            End If
            LoadStartInfo()

            Dim sbSql As New StringBuilder()
            Dim IsNew As Boolean = True ' ReadVerson()
            If IsNew Then
                progressBar1.Value = 0
                lblMsg.Text = "检测更新文件列表"
                'Dim sql As String = String.Format("select [filename],filetime from M_Systemfile_t with (nolock) where usey='Y' and fileclass='{0}' and Filename<>'SFCSUpdate.exe' order by intime", SysClass)

                If (ReleasedVersion = "Y") Then
                    Dim strMacWhere As String
                    strMacWhere = GetClientMacWhere(dtClientMac)

                    sbSql.Append(" SELECT DISTINCT * FROM ( ")
                    sbSql.Append(" SELECT DISTINCT Fileno, [filename], FileTime, ISNULL(Size, 0) AS Size, intime ")
                    sbSql.Append(" FROM M_Systemfile_t  with (nolock) INNER JOIN m_ClientInfo_t ON m_ClientInfo_t.ReleasedVersionId=M_Systemfile_t.ReleasedVersionId ")
                    sbSql.Append(" INNER JOIN m_ClientMac_t ON m_ClientMac_t.ClientInfoId=m_ClientInfo_t.ClientInfoId ")
                    sbSql.Append(" WHERE usey='Y' and fileclass='{0}' and filename<>'SFCSUpdate.exe' AND m_ClientMac_t.ClientMacAddress IN (" & strMacWhere & ") ")
                    sbSql.Append(" UNION ALL SELECT DISTINCT Fileno, [filename], FileTime, ISNULL(Size, 0) AS Size, intime ")
                    sbSql.Append(" FROM M_Systemfile_t INNER JOIN m_ReleasedVersion_t ON m_ReleasedVersion_t.ReleasedVersionId=M_Systemfile_t.ReleasedVersionId ")
                    sbSql.Append(" WHERE usey='Y' and fileclass='0' and filename<>'SFCSUpdate.exe' and m_ReleasedVersion_t.ReleasedVersionTypeId='1' ")
                    sbSql.Append(" AND [filename] NOT IN (SELECT [filename] FROM M_Systemfile_t  with (nolock) ")
                    sbSql.Append(" INNER JOIN m_ClientInfo_t ON m_ClientInfo_t.ReleasedVersionId=M_Systemfile_t.ReleasedVersionId ")
                    sbSql.Append(" INNER JOIN m_ClientMac_t ON m_ClientMac_t.ClientInfoId=m_ClientInfo_t.ClientInfoId ")
                    sbSql.Append(" WHERE usey='Y' and fileclass='{0}' and filename<>'SFCSUpdate.exe' AND m_ClientMac_t.ClientMacAddress IN (" & strMacWhere & ")) ")
                    sbSql.Append(" ) TEMP ORDER BY intime ")
                Else
                    sbSql.Append("select Fileno, [filename], FileTime, ISNULL(Size, 0) AS Size, intime from M_Systemfile_t with (nolock) where usey='Y' and fileclass='{0}' and filename<>'SFCSUpdate.exe'  and EffectTime<getdate() order by intime ")
                End If

                Dim sql As String = String.Format(sbSql.ToString, SysClass)
                Dim dt As DataTable = Conn.GetDataTable(sql)

                Dim i As Int16 = 0
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        Dim fname As String = dt.Rows(i)("filename").ToString
                        Dim LoacalFileModifyDateTime As String = File.GetLastWriteTime(Filepath & "\" & Trim(dt.Rows(i)("filename")).ToString)
                        If My.Computer.FileSystem.FileExists(Filepath & "\" & dt.Rows(i)("filename").ToString) = False OrElse
                            LoacalFileModifyDateTime <> Trim(dt.Rows(i)("filetime").ToString()) Then
                            ListBox1.Items.Add("更新文件：" & fname + " ")
                            ListBox1.Refresh()
                            updatecount += 1
                        End If
                    Next
                End If
                Label1.Text = "检测到有" & updatecount & "个文件需要更新,已完成0/" & updatecount

                If ListBox1.Items.Count = 0 Then
                    Me.ListBox1.Items.Add("你的系統已是最新版!")
                    worker.CancelAsync()
                    If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & StartApp) Then
                        System.Diagnostics.Process.Start(Application.StartupPath & "\" & StartApp)
                        Application.ExitThread()
                    Else
                        Me.ListBox1.Items.Add("启动程序【" & StartApp & "】不存在!自动退出")
                        MessageBox.Show("启动程序【" & StartApp & "】不存在!自动退出")
                        Me.Close()
                    End If
                Else
                    Try
                        worker.RunWorkerAsync(0)
                    Catch ex As Exception

                    End Try

                End If
            Else
                If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & StartApp) Then
                    System.Diagnostics.Process.Start(Application.StartupPath & "\" & StartApp)
                    Application.ExitThread()
                Else
                    Me.ListBox1.Items.Add("启动程序【" & StartApp & "】不存在!自动退出")
                    MessageBox.Show("启动程序【" & StartApp & "】不存在!自动退出")
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            'Throw ex 'cq
        End Try
    End Sub

#Region "獲取上次登錄用戶名"

    Private Sub LoadSqlServerNametest()

        Dim xmldoc As New XmlDocument
        Try
            xmldoc.Load(Application.StartupPath & "\LoginlogDB.xml") '讀取XML中的上次登錄用戶名

            Dim nodeList As XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As XmlNode In nodeList
                'Modify by cq20160128
                Select Case LCase(xn.Name).Trim
                    Case "systemip"
                        SqlserverName = xn.InnerText
                    Case Else
                        'do nothing
                End Select
            Next

            '测试服务器文件
            If SqlserverName.IndexOf("155") > 0 Then
                IsTESTServer = True

                Dim IsSecurity As Boolean = False
                If SqlserverName.IndexOf("initial catalog") > 0 Then
                    If SqlserverName.IndexOf("uid=") > 0 Then
                        IsSecurity = True
                    End If
                End If
                If IsSecurity Then
                    DbClass.SysDataHandle.SysDataBaseClass.SqlserverName = SqlserverName
                    DbClass.SysDataHandle.SysDataBaseClass.IsSecurity = True
                    ServerIP = SqlserverName.Split(";")(0).Split("=")(1).ToString
                    'lbIP.Text = ServerIP
                Else
                    DbClass.SysDataHandle.SysDataBaseClass.SqlserverName = SqlserverName
                    DbClass.SysDataHandle.SysDataBaseClass.IsSecurity = False
                    ServerIP = SqlserverName
                    'lbIP.Text = ServerIP
                End If

                If ServerIP = "." Then
                    ServerIP = "127.0.0.1"
                End If
            End If
        Catch ex As Exception
            'MessageBox.Show("加载本地配置文件LoginlogDB.xml失败，请重新运行程序")
        End Try
    End Sub


    '读取本地LoginlogDB文件,如果没有自动生成一个
    Private Sub LoadSqlServerName()

        Dim xmldoc As New XmlDocument
        Try
            xmldoc.Load(Application.StartupPath & "\LoginlogDB.xml") '讀取XML中的上次登錄用戶名

            Dim nodeList As XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As XmlNode In nodeList
                'Modify by cq20160128
                Select Case LCase(xn.Name).Trim
                    Case "systemip"
                        SqlserverName = xn.InnerText
                    Case Else
                        'do nothing
                End Select
            Next
            Dim IsSecurity As Boolean = False
            If SqlserverName.IndexOf("initial catalog") > 0 Then
                If SqlserverName.IndexOf("uid=") > 0 Then
                    IsSecurity = True
                End If
            End If

            If IsSecurity Then
                DbClass.SysDataHandle.SysDataBaseClass.SqlserverName = SqlserverName
                DbClass.SysDataHandle.SysDataBaseClass.IsSecurity = True
                ServerIP = SqlserverName.Split(";")(0).Split("=")(1).ToString
                'lbIP.Text = ServerIP
            Else
                DbClass.SysDataHandle.SysDataBaseClass.SqlserverName = SqlserverName
                DbClass.SysDataHandle.SysDataBaseClass.IsSecurity = False
                ServerIP = SqlserverName
                'lbIP.Text = ServerIP
            End If
            If ServerIP = "." Then
                ServerIP = "127.0.0.1"
            End If
        Catch ex As Exception
            MessageBox.Show("加载本地配置文件LoginlogDB.xml失败，请重新运行程序")
            CreateConfigLoginXML()
        End Try
    End Sub

    Private Sub LoadStartInfo()
        Dim sql As String = String.Format("select SortDesc,SortName from  m_sortset_t where SortType='fileclass' and SortID='{0}'", SysClass)
        Dim ds As DataSet = Conn.GetDataSet(sql)
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then
                StartApp = ds.Tables(0).Rows(0)("SortDesc").ToString
                AppName = ds.Tables(0).Rows(0)("SortName").ToString
            End If
        End If
        Me.Text = "LUXSHARE-ICT自动更新程序-[" & AppName & "]在线升级"
    End Sub

#End Region
    Delegate Sub SetTextCallback(ByVal val As String, ByVal obj As Object)
    Sub SetText(ByVal TValue As String, ByVal TempC As Object)
        Try
            Dim obj As Control = CType(TempC, Control)
            If (obj.InvokeRequired) Then
                Dim d As SetTextCallback = New SetTextCallback(AddressOf SetText)
                Me.Invoke(d, New Object() {TValue, obj})
            Else
                obj.Text = TValue
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Delegate Sub SetAddItemCallback(ByVal val As String, ByVal obj As ListBox)
    Sub SetAddItem(ByVal TValue As String, ByVal TempC As ListBox)
        Try
            Dim obj As ListBox = TempC
            If (obj.InvokeRequired) Then
                Dim d As SetAddItemCallback = New SetAddItemCallback(AddressOf SetAddItem)
                Me.Invoke(d, New Object() {TValue, obj})
            Else
                obj.Items.Add(TValue)
                obj.Refresh()

            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Delegate Sub SetItemValueCallback(ByVal val As String, ByVal obj As ListBox, ByVal curr As Integer)
    Sub SetItemValue(ByVal TValue As String, ByVal TempC As ListBox, ByVal curr As Integer)
        Try
            Dim obj As ListBox = CType(TempC, ListBox)
            If (obj.InvokeRequired) Then
                Dim d As SetItemValueCallback = New SetItemValueCallback(AddressOf SetItemValue)
                Me.Invoke(d, New Object() {TValue, obj, curr})
            Else
                obj.Items(curr) = TValue
                obj.SelectedIndex = curr
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    '读服务器文件 
    Sub FromServerGetLoginXML()
        Dim client As WebClient = New WebClient()
        Try
            Dim stream As Stream = client.OpenRead(ServerPath)
            '读文件，有文件就下载
            If stream.CanRead Then
                Dim url As New Uri(ServerPath)
                client.DownloadFile(url, localPath)
            End If
        Catch ex As Exception
        Finally
            client.Dispose()
        End Try
    End Sub

    '下载完成重读配置文件
    Private Sub LoadSqlServerNameNoError()

        Dim xmldoc As New XmlDocument
        Try
            xmldoc.Load(Application.StartupPath & "\LoginlogDB.xml") '讀取XML中的上次登錄用戶名

            Dim nodeList As XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As XmlNode In nodeList
                Select Case LCase(xn.Name).Trim
                    Case "systemip"
                        SqlserverName = xn.InnerText
                    Case Else
                        'do nothing
                End Select
            Next
            Dim IsSecurity As Boolean = False
            If SqlserverName.IndexOf("initial catalog") > 0 Then
                If SqlserverName.IndexOf("uid=") > 0 Then
                    IsSecurity = True
                End If
            End If
            If IsSecurity Then
                DbClass.SysDataHandle.SysDataBaseClass.SqlserverName = SqlserverName
                DbClass.SysDataHandle.SysDataBaseClass.IsSecurity = True
                ServerIP = SqlserverName.Split(";")(0).Split("=")(1).ToString
                'lbIP.Text = ServerIP
            Else
                DbClass.SysDataHandle.SysDataBaseClass.SqlserverName = SqlserverName
                DbClass.SysDataHandle.SysDataBaseClass.IsSecurity = False
                ServerIP = SqlserverName
                'lbIP.Text = ServerIP
            End If
        Catch ex As Exception
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
        xe.InnerText = "vn4p-sfcdb.luxshare.com.cn;initial catalog=MESDB;uid=sfcuser;pwd=013012068009067051026008004090069083030"
        root.AppendChild(xe)

        XmlDoc.Save(Application.StartupPath & "\LoginlogDB.xml")

        DbClass.SysDataHandle.SysDataBaseClass.SqlserverName = "vn4p-sfcdb.luxshare.com.cn;initial catalog=MESDB;uid=sfcuser;pwd=013012068009067051026008004090069083030"
        DbClass.SysDataHandle.SysDataBaseClass.IsSecurity = True
    End Sub

    Private Function GetLoginSetting() As Boolean
        Dim rtValue As Boolean = False
        Dim Conn As New DbClass.SysDataHandle.SysDataBaseClass   '定義數據庫聯接對象
        Dim Dreader As SqlDataReader
        Dim strSQL As String
        Try
            strSQL = "SELECT PARAMETER_CODE,PARAMETER_VALUES FROM m_SystemSetting_t WHERE MODE_NAME='MES' AND PARAMETER_CODE IN ('CheckClientMac', 'CheckProgramFileVersion', 'ReleasedVersion')"
            Dreader = Conn.GetDataReader(strSQL)
            Do While Dreader.Read()
                Select Case Dreader.Item(0).ToString.ToUpper()
                    Case "CheckClientMac".ToUpper()
                        CheckClientMac = Dreader.Item(1).ToString
                    Case "CheckProgramFileVersion".ToUpper
                        CheckProgramFileVersion = Dreader.Item(1).ToString
                    Case "ReleasedVersion".ToUpper
                        ReleasedVersion = Dreader.Item(1).ToString
                End Select
            Loop
            Dreader.Close()
            Conn.PubConnection.Close()
            rtValue = True
        Catch ex As Exception
            If (Not Dreader Is Nothing And Not Dreader.IsClosed) Then
                Dreader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
            rtValue = False
            lblMsg.Text = "获取系统登录设置信息异常,请检查网络连接"
        End Try
        Return rtValue
    End Function

    Private Sub GetClientMac()
        Dim strLocalClientMACAddress As String = ""
        Dim ExistFlag As Boolean = False
        Try
            '2016-09-14    mafeng    解决域配置无权限，取消功能
            'Dim searcher As New System.Management.ManagementObjectSearcher("select * from win32_NetworkAdapterConfiguration")
            'Dim moc2 As System.Management.ManagementObjectCollection = searcher.Get()
            'For Each mo As System.Management.ManagementObject In moc2
            '    If CBool(mo("IPEnabled")) Then
            'strLocalClientMACAddress = mo("MACAddress")
            Dim drTemp As DataRow
            drTemp = dtClientMac.NewRow()
            drTemp("ClientMacAddress") = "‎48-5A-B6-68-D8-41"  'strLocalClientMACAddress
            dtClientMac.Rows.Add(drTemp)
            dtClientMac.AcceptChanges()
            '    End If
            'Next
        Catch ex As Exception
            MessageBox.Show("获取用户电脑IP异常，请确认登录用户是否有管理员权限")
            Me.Close()
        End Try
    End Sub

    Private Function GetClientMacWhere(ByVal dtTemp As DataTable) As String
        Dim strTemp As String = ""
        Try
            If (Not dtTemp Is Nothing) Then
                For i As Int16 = 0 To dtTemp.Rows.Count - 1
                    If (i = 0) Then
                        strTemp = "'" + dtTemp.Rows(i).Item("ClientMacAddress").ToString + "'"
                    Else
                        strTemp = strTemp + ",'" + dtTemp.Rows(i).Item("ClientMacAddress").ToString + "'"
                    End If
                Next
            End If
        Catch ex As Exception
            strTemp = ""
        End Try
        Return strTemp
    End Function

End Class

Public Class FilePair
    Private _orgFile As String
    Private _NewFile As String
    Public Sub New(ByVal orgfile As String, ByVal Newfile As String)
        _orgFile = orgfile
        _NewFile = Newfile
    End Sub
    Public Property OrgFile() As String
        Get
            Return _orgFile
        End Get
        Set(ByVal Value As String)
            _orgFile = Value
        End Set
    End Property
    Public Property NewFile() As String
        Get
            Return _NewFile
        End Get
        Set(ByVal Value As String)
            _NewFile = Value
        End Set
    End Property
End Class
