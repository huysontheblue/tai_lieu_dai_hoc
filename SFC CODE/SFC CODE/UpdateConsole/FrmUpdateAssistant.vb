
'--MES小助手
'--Create by :　马锋
'--Create date :　2016/01/06
'--Ver : V01
'--Update date :  
'--

Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class FrmUpdateAssistant

#Region "变量申明"
    Dim worker As BackgroundWorker = Nothing
    Dim SysClass As String = "0"
    Dim Filepath As String = Application.StartupPath
    Dim updatecount As Int16 = 0

    Dim rtValue As String
    Dim rtMsg As String
    Dim serverName As String

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
#End Region

#Region "窗体构造函数"

    Public Sub New()
        MyBase.New()
        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()
        progressBar1.Minimum = 0
        progressBar1.Maximum = 100
        worker = New BackgroundWorker()
        worker.WorkerReportsProgress = True
        worker.WorkerSupportsCancellation = True

        AddHandler worker.DoWork, AddressOf worker_DoWork
        AddHandler worker.ProgressChanged, AddressOf worker_ProgressChanged
        AddHandler worker.RunWorkerCompleted, AddressOf worker_RunWorkerCompleted
    End Sub

#End Region

#Region "加载事件"

    Private Sub FrmUpdateAssistant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.dgvUpdateList.AutoGenerateColumns = False
            GetServerIP()
            UpdateProgress(False)
            LoadControlData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "MES小助手加载异常!", False)
        End Try
    End Sub

    Private Sub FrmUpdateConsole_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            GetUpdateFile()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查更新异常!", False)
        End Try
    End Sub

#End Region

#Region "works"

    Private Sub worker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim Conn As New DbClass.SysDataHandle.SysDataBaseClass
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
                    sbSql.Append("select Fileno, [filename], FileTime, ISNULL(Size, 0) AS Size from M_Systemfile_t with (nolock) where usey='Y' and fileclass='0' and filename<>'SFCSUpdate.exe' ")  ', filecontent
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
                            Dim sqlone As String = String.Format("select top 1 [filename],filetime,sizes=isnull(size,0),filecontent from M_Systemfile_t with (nolock) where usey='Y' and fileclass='{0}' and Filename='{1}' and Fileno='{2}' ", SysClass, LoadFName, Fileno)
                            Dim Dread As SqlDataReader = Conn.GetDataReader(sqlone)
                            If Dread.Read Then
                                Dim fs As FileStream = File.Create(Filepath & "\" & Dread.Item("filename").ToString)
                                Dim fname As String = Dread.Item("filename").ToString
                                Dim fsize As Long = Dread.Item("sizes")
                                'SetText(fname, lblinfo)
                                'SetItemValue("更新文件：" & fname + " 进行中......", dgvUpdateList, indexcurr)

                                SetText("更新文件：" + fname + " 进行中......", lblinfo)

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
                                    'SetItemValue("更新文件：" & fname + " " & percent & "%", dgvUpdateList, indexcurr)
                                    SetText("更新文件：" + fname + " 进行中......(" + percent.ToString + "%)", lblinfo)
                                    worker.ReportProgress(percent)
                                    BytesRead = Dread.GetBytes(3, Offset, buff, 0, buffLength)
                                End While
                                fs.Close()
                                fs.Dispose()
                                File.SetLastWriteTime(Filepath & "\" & Dread.Item("filename").ToString, Dread.Item("filetime"))
                                worker.ReportProgress(100)
                                'SetItemValue("更新文件：" & fname + " 100%", dgvUpdateList, indexcurr)
                                SetText("更新文件：" + fname + " 进行中......(100%)", lblinfo)
                                SetText("检测到有" & updatecount.ToString & "个文件需要更新,已完成" & (indexcurr + 1).ToString & "/" & updatecount.ToString, lblUpdateSchedule)
                                indexcurr += 1
                            End If
                            Dread.Close()
                        End If
                    Next
                    Conn.PubConnection.Close()
                Catch ex As Exception

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
                'lblMsg.Text = CType(e.UserState, Exception).Message
                GetMesData.SetMessage(Me.lblMessage, CType(e.UserState, Exception).Message, False)
            Else
                progressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub worker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        'lblMsg.Text = "文件复制完成"
        'WriteVersion(NewDt)
        'If My.Computer.FileSystem.FileExists(Application.StartupPath & "\" & StartApp) Then
        '    System.Diagnostics.Process.Start(Application.StartupPath & "\" & StartApp)
        '    Application.ExitThread()
        'Else
        '    Me.ListBox1.Items.Add("启动程序【" & StartApp & "】不存在!自动退出")
        '    MessageBox.Show("启动程序【" & StartApp & "】不存在!程序自动退出")
        '    Me.Close()
        'End If
        UpdateProgress(False)
        GetUpdateFile()
    End Sub

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

#End Region

#Region "控件事件"

    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Try
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False
            Me.Visible = False
            Me.ShowIcon = False
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "最小化异常!", False)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False
            Me.Visible = False
            Me.ShowIcon = False
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "关闭异常!", False)
        End Try
    End Sub

    Private Sub VisibleUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisibleUpdateToolStripMenuItem.Click
        Try
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            Me.Visible = True
            Me.ShowIcon = True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "显示MES小助手异常!", False)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "关闭MES小助手异常!", False)
        End Try
    End Sub

    Private Sub NotifyIconTool_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIconTool.DoubleClick
        Try
            Me.WindowState = FormWindowState.Normal
            Me.ShowIcon = True
            Me.ShowInTaskbar = True
            Me.Visible = True
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "任务右击异常!", False)
        End Try
    End Sub

    Private Sub linklblCheckUpdate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linklblCheckUpdate.LinkClicked
        Try
            GetUpdateFile()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "检查更新异常!", False)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            'GetUpdateFile()
            UpdateProgress(True)
            'UpdateFile()
            worker.RunWorkerAsync(0)
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "MES小助手更新异常!", False)
        End Try
    End Sub

    Private Sub dgvUpdateList_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvUpdateList.DataBindingComplete
        Try
            'For Each dgvDr As DataGridViewRow In dgvUpdateList.Rows
            '    If dgvDr.Cells("IsMust").Value = "Y" Then
            '        dgvDr.Cells("lbtnUpdate").ReadOnly = True
            '        dgvDr.DefaultCellStyle.BackColor = Color.Red
            '        dgvDr.DefaultCellStyle.ForeColor = Color.White
            '    End If
            'Next
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新项目状态异常!", False)
        End Try
    End Sub

    Private Sub dgvUpdateList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUpdateList.CellContentClick
        Try
            If (e.ColumnIndex = 9) Then
                If (e.RowIndex <> -1) Then
                    Dim str As String = Me.dgvUpdateList.Rows(e.RowIndex).Cells(0).Value.ToString()
                End If
            End If
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新项目异常!", False)
        End Try
    End Sub
#End Region

#Region "函数"

    Public Function CmdPing(ByVal strIp As String) As Boolean
        Return My.Computer.Network.Ping(strIp, 2000)
    End Function

    Private Sub GetServerIP()
        If My.Computer.Network.IsAvailable = False Then
            GetMesData.SetMessage(Me.lblMessage, "电脑网络异常...", False)
            'Me.Close()
            ConnPictureStatus(False)
            Exit Sub
        End If
        'GetMesData.SetMessage(Me.lblMessage, "正在获取服务器IP，请稍等...", True)
        Try
            Dim strSysAddress As String = Common.GetSystemAddress("", "", "0", rtValue, rtMsg)
            If rtValue = "1" Then
                If CmdPing(strSysAddress) = False Then
                    GetMesData.SetMessage(Me.lblMessage, "检查服务器链接异常，请检查网络...", False)
                    ConnPictureStatus(False)
                    Me.btnUpdate.Enabled = False
                Else
                    'GetMesData.SetMessage(Me.lblMessage, "服务器链接成功", True)
                    ConnPictureStatus(True)
                    Me.btnUpdate.Enabled = True
                    Me.serverName = strSysAddress
                    DbClass.SysDataHandle.SysDataBaseClass.SqlserverIP = strSysAddress
                    DbClass.SysDataHandle.SysDataBaseClass.SqlserverName = strSysAddress
                    GetClientMac()
                    GetCheckClientMac(GetClientMacWhere(dtClientMac))
                End If
            Else
                GetMesData.SetMessage(Me.lblMessage, "获取服务器IP出错，错误原因：" + rtMsg, False)
                ConnPictureStatus(False)
                Me.btnUpdate.Enabled = False
            End If
        Catch ex As Exception
            Me.btnUpdate.Enabled = False
            GetMesData.SetMessage(Me.lblMessage, "获取服务器IP出错，错误原因：" + ex.Message, False)
            ConnPictureStatus(False)
            'Common.AlertAotuCloseMeessageBox("系统更新出现异常，程序将在6秒后跳过更新自动进入MES系统.", 6000)
            'System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
            'Application.ExitThread()
        End Try
    End Sub

    Private Sub BindGridViewInfo()
        Dim sbSql As New StringBuilder()
        Dim conn As New DbClass.SysDataHandle.SysDataBaseClass()
        Try
            sbSql.Append("select Fileno, [Filename], ReleasedVersionName, Fileversion, ProgramVersion, filetime, Remark, Intime, UpdateType, MinimumVersion from M_Systemfile_t where usey='Y' and fileclass='0' ")
            Dim dtUpFile = conn.GetDataTable(sbSql.ToString())
            conn.PubConnection.Close()
            If Not dtUpFile Is Nothing Then
                Dim strIsMust As String
                If dtUpFile.Rows.Count > 0 Then
                    dtUpFile.Columns.Add("LocationVersion")
                    dtUpFile.Columns.Add("IsMust")
                    dtUpFile.Columns.Add("lkUpdate")
                    Dim LoacalFileModifyDateTime As String
                    For Each drUpFile As DataRow In dtUpFile.Rows
                        'drUpFile("LocationVersion") = Common.GetFileVersion(Application.StartupPath & "\" + drUpFile("Filename").ToString())
                        'If drUpFile("UpdateType") = "0" And Common.CompareFileVersion(IIf(IsDBNull(drUpFile("LocationVersion")), "", drUpFile("LocationVersion")), IIf(IsDBNull(drUpFile("Fileversion")), "", drUpFile("Fileversion"))) Then
                        '    strIsMust = "Y"
                        '    drUpFile("lkUpdate") = "更新"
                        'ElseIf (Common.CompareFileVersion(IIf(IsDBNull(drUpFile("LocationVersion")), "", drUpFile("LocationVersion")), IIf(IsDBNull(drUpFile("MinimumVersion")), "", drUpFile("MinimumVersion")))) Then
                        '    strIsMust = "Y"
                        '    drUpFile("lkUpdate") = "更新"
                        'Else
                        '    strIsMust = "N"
                        '    drUpFile("lkUpdate") = "已更新"
                        'End If

                        LoacalFileModifyDateTime = CType((File.GetLastWriteTime(Filepath & "\" & Trim(drUpFile("filename")).ToString)), Date).ToString("yyyy-MM-dd HH:mm:ss").ToString()
                        If My.Computer.FileSystem.FileExists(Filepath & "\" & drUpFile("filename").ToString) = False Or LoacalFileModifyDateTime <> CType(Trim(drUpFile("filetime")), Date).ToString("yyyy-MM-dd HH:mm:ss").ToString Then
                            strIsMust = "Y"
                            drUpFile("lkUpdate") = "更新"
                            updatecount = updatecount + 1
                        Else
                            strIsMust = "N"
                            drUpFile("lkUpdate") = "已更新"
                        End If

                        drUpFile("IsMust") = strIsMust
                    Next
                    dtUpFile.AcceptChanges()
                    Me.dgvUpdateList.DataSource = dtUpFile
                End If
            End If
        Catch ex As Exception
            If (conn.PubConnection.State = ConnectionState.Open) Then
                conn.PubConnection.Close()
            End If
            GetMesData.SetMessage(Me.lblMessage, "系统异常，异常信息：" + ex.Message, False)
        End Try
    End Sub

    Private Sub GetUpdateFile()
        Try
            BindGridViewInfo()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "系统异常，异常信息：" + ex.Message, False)
        End Try
    End Sub

    Private Sub UpdateFile()
        Dim conn As New DbClass.SysDataHandle.SysDataBaseClass()
        Try
            'KillProcess("MesSystem.exe")
            System.Threading.Thread.Sleep(1000)
            Dim countFile As Integer = Me.dgvUpdateList.Rows.Count
            Dim sbSql As String
            Dim index As Integer = 1
            Dim dtFileContent As New DataTable
            Dim fileLocalPath As String
            Dim fileNo As String
            For Each dgvDr As DataGridViewRow In Me.dgvUpdateList.Rows
                fileNo = dgvDr.Cells("Fileno").Value.ToString
                fileLocalPath = Application.StartupPath & "\" & dgvDr.Cells("Filename").Value.ToString()
                GetMesData.SetMessage(Me.lblMessage, "正在检测更新" + dgvDr.Cells("Filename").Value + "... " + (index).ToString() + "/" + countFile.ToString(), True)
                'If dgvDr.Cells(0).Value = True Then
                sbSql = "select filecontent from M_Systemfile_t where usey='Y' and fileclass='0' and Fileno='" + fileNo + "' and filename='" + dgvDr.Cells("Filename").Value.ToString() + "'"
                dtFileContent.Clear()
                dtFileContent = conn.GetDataTable(sbSql)
                If Not dtFileContent Is Nothing And dtFileContent.Rows.Count > 0 Then
                    Dim mFile() As Byte
                    mFile = dtFileContent.Rows(0)(0)
                    Common.ByteSaveAsFile(mFile, fileLocalPath)
                End If
                'End If
                index += 1
            Next
            GetMesData.SetMessage(Me.lblMessage, "更新完成", True)
            BindGridViewInfo()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "更新异常", False)
        End Try
    End Sub

    Private Sub UpdateProgress(ByVal UpdateStatus As Boolean)
        If (UpdateStatus) Then
            Me.lblprogress.Visible = True
            Me.lblinfo.Visible = True
            Me.progressBar1.Visible = True
            Me.lblUpdateDesc.Visible = False
            Me.btnUpdate.Visible = False
            Me.PictureBoxLoading.Visible = True
            Me.lblUpdateSchedule.Visible = True
        Else
            Me.lblprogress.Visible = False
            Me.lblinfo.Visible = False
            Me.progressBar1.Visible = False
            Me.lblUpdateDesc.Visible = True
            Me.btnUpdate.Visible = True
            Me.PictureBoxLoading.Visible = False
            Me.lblUpdateSchedule.Visible = False
        End If
    End Sub

    Private Sub ConnPictureStatus(ByVal ConnStatus As Boolean)
        If (ConnStatus) Then
            Me.lblConnectionStatus.Text = "已连接"
            Me.PictureBoxConnStatus.Image = UpdateConsole.My.Resources.Resources.preferences_system_network
        Else
            Me.lblConnectionStatus.Text = "已断开"
            Me.PictureBoxConnStatus.Image = UpdateConsole.My.Resources.Resources.notification_wireless_disconnected
        End If
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
            GetMesData.SetMessage(Me.lblMessage, "获取系统登录设置信息异常,请检查网络连接", False)
        End Try
        Return rtValue
    End Function

    Private Sub GetClientMac()
        Dim strLocalClientMACAddress As String = ""
        Dim ExistFlag As Boolean = False
        Try
            Dim searcher As New System.Management.ManagementObjectSearcher("select * from win32_NetworkAdapterConfiguration")
            Dim moc2 As System.Management.ManagementObjectCollection = searcher.Get()
            For Each mo As System.Management.ManagementObject In moc2
                If CBool(mo("IPEnabled")) Then
                    strLocalClientMACAddress = mo("MACAddress")
                    Dim drTemp As DataRow
                    drTemp = dtClientMac.NewRow()
                    drTemp("ClientMacAddress") = strLocalClientMACAddress
                    dtClientMac.Rows.Add(drTemp)
                    dtClientMac.AcceptChanges()
                End If
            Next
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "获取用户电脑IP异常，请确认登录用户是否有管理员权限", False)
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

    Private Sub GetCheckClientMac(ByVal strClientMac As String)
        Dim rtValue As Boolean = False
        Dim Conn As New DbClass.SysDataHandle.SysDataBaseClass()
        Dim Dreader As SqlDataReader
        Dim strSQL As String
        Try
            strSQL = " SELECT TOP 1 ClientName, LineId, ReleasedVersionName FROM m_ClientMac_t INNER JOIN m_ClientInfo_t ON m_ClientInfo_t.ClientInfoId=m_ClientMac_t.ClientInfoId " & _
                    " WHERE m_ClientMac_t.ClientMacAddress IN (" & strClientMac & ") AND m_ClientMac_t.StatusFlag='Y' AND m_ClientInfo_t.StatusFlag='Y'"
            Dreader = Conn.GetDataReader(strSQL)

            If (Dreader.HasRows) Then
                Dreader.Read()
                Me.lblItemClientUser.Text = Dreader(0).ToString
                Me.lblItemLine.Text = Dreader(1).ToString
                Me.lblItemReleasedVersionName.Text = Dreader(2).ToString
            End If

            Dreader.Close()
            Conn.PubConnection.Close()

        Catch ex As Exception
            If (Not Dreader Is Nothing And Not Dreader.IsClosed) Then
                Dreader.Close()
            End If

            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If
        End Try
    End Sub

    Private Sub LoadControlData()
        Try
            LoadHelpAssistantData()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "加载控件数据异常!", False)
        End Try
    End Sub
#End Region

#Region "帮助助手"

    Private Sub LoadHelpAssistantData()
        Dim Conn As New DbClass.SysDataHandle.SysDataBaseClass
        Dim strSQL As String
        Dim dtHelpAssistant As DataTable
        Try
            strSQL = "SELECT   HelpAssistantId, SubjectName, ContentDesc FROM m_HelpAssistant_t"
            dtHelpAssistant = Conn.GetDataTable(strSQL)
            Conn.PubConnection.Close()

            If (Not dtHelpAssistant Is Nothing) Then
                If (dtHelpAssistant.Rows.Count > 0) Then
                    CreateHelpAssistantList(dtHelpAssistant)
                End If
            End If
        Catch ex As Exception
            If (Conn.PubConnection.State = ConnectionState.Open) Then
                Conn.PubConnection.Close()
            End If

            GetMesData.SetMessage(Me.lblMessage, "帮助助手加载数据异常!", False)
        End Try
    End Sub

    Private Sub CreateHelpAssistantList(ByVal dtHelpAssistant As DataTable)
        Try
            For i As Int16 = 0 To dtHelpAssistant.Rows.Count - 1
                Dim ExpandablePanelTemp As DevComponents.DotNetBar.ExpandablePanel
                ExpandablePanelTemp = New DevComponents.DotNetBar.ExpandablePanel
                ExpandablePanelTemp.Name = i.ToString
                ExpandablePanelTemp.TitleText = dtHelpAssistant.Rows(i).Item("SubjectName").ToString
                ExpandablePanelTemp.Text = dtHelpAssistant.Rows(i).Item("ContentDesc").ToString
                ExpandablePanelTemp.AutoScroll = True
                ExpandablePanelTemp.ExpandOnTitleClick = True
                ExpandablePanelTemp.ButtonImageCollapse = My.Resources.collapse_large_orange
                ExpandablePanelTemp.ButtonImageExpand = My.Resources.expand_large_orange
                ExpandablePanelTemp.Dock = DockStyle.Top
                ExpandablePanelTemp.ExpandButtonAlignment = eTitleButtonAlignment.Left

                ExpandablePanelTemp.Font = New System.Drawing.Font("宋体", 10)
                ExpandablePanelTemp.Width = 675
                ExpandablePanelTemp.Height = 100
                ExpandablePanelTemp.Style.ForeColor.Color = Color.Black
                ExpandablePanelTemp.Style.MarginTop = 10
                ExpandablePanelTemp.Style.LineAlignment = StringAlignment.Near
                ExpandablePanelTemp.Style.BackColor1.Color = Color.Gainsboro
                ExpandablePanelTemp.Style.BackColor2.Color = Color.LightGray
                ExpandablePanelTemp.Style.Border = eBorderType.SingleLine
                ExpandablePanelTemp.Style.BorderColor.Color = Color.Gray
                ExpandablePanelTemp.Style.WordWrap = True

                ExpandablePanelTemp.TitleStyle.Font = New System.Drawing.Font("宋体", 10)
                ExpandablePanelTemp.TitleStyle.ForeColor.Color = Color.Black
                ExpandablePanelTemp.TitleStyle.Border = eBorderType.None
                ExpandablePanelTemp.TitleStyle.BorderColor.Color = Color.Transparent
                ExpandablePanelTemp.TitleStyle.BackColor1.Color = Color.Transparent
                ExpandablePanelTemp.TitleStyle.BackColor2.Color = Color.Transparent
                ExpandablePanelTemp.Expanded = False
                plHelpAssistant.Controls.Add(ExpandablePanelTemp)
            Next
            plHelpAssistant.Update()
        Catch ex As Exception
            GetMesData.SetMessage(Me.lblMessage, "创建帮助助手列表异常!", False)
        End Try
    End Sub

#End Region

End Class