Imports System.Text
Imports System.IO
Imports System.Threading
Public Class FrmUpdateConsole
    Dim rtValue As String
    Dim rtMsg As String
    Dim serverName As String
    Dim conn As New DbClass.SysDataHandle.SysDataBaseClass()
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Minimized
        Control.CheckForIllegalCrossThreadCalls = False
        Dim autoUpdateFlag As String = GetSysInit("DGMesAutoUpdateFlag")
        If autoUpdateFlag = "1" Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

    End Sub
    Private Sub GetServerIP()
        If My.Computer.Network.IsAvailable = False Then
            MessageBox.Show("电脑检测不到网络...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Close()
            Exit Sub
        End If
        lblMsg.Text = "正在获取服务器IP，请稍后..."
        Try
            Dim strSysAddress As String = Common.GetSystemAddress("", "", "0", rtValue, rtMsg)
            If rtValue = "1" Then
                If CmdPing(strSysAddress) = False Then
                    lblMsg.Text = "网络ping不通，请检查网络状态..."
                    btnInstallAll.Enabled = False
                    btnCheckUpdate.Enabled = False
                Else
                    lblMsg.Text = "服务器链接成功！"
                    lblMsg.ForeColor = Color.Green
                    btnInstallAll.Enabled = True
                    btnCheckUpdate.Enabled = True
                    serverName = strSysAddress
                    DbClass.SysDataHandle.SysDataBaseClass.SqlserverIP = strSysAddress
                    DbClass.SysDataHandle.SysDataBaseClass.SqlserverName = strSysAddress
                End If
            Else
                lblMsg.Text = "获取服务器IP出错，错误原因：" + rtMsg
                btnInstallAll.Enabled = False
                btnCheckUpdate.Enabled = False
            End If

        Catch ex As Exception
            lblMsg.Text = "系统异常，异常信息：" + ex.Message
            btnInstallAll.Enabled = False
            btnCheckUpdate.Enabled = False
            Common.AlertAotuCloseMeessageBox("系统更新出现异常，程序将在6秒后跳过更新自动进入MES系统.", 6000)
            System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
            Application.ExitThread()
        End Try
    End Sub
    Private Sub BindGridViewInfo()
        Dim sbSql As New StringBuilder()
        Try
            sbSql.Append("select [filename],Fileversion,Updatetime,Remark,UpdateType,MinimumVersion from M_Systemfile_t where usey='Y' and fileclass='0' ")
            Dim dtUpFile = conn.GetDataTable(sbSql.ToString())
            Dim dt As New DataTable()
            dt.Columns.Add("Name")
            dt.Columns.Add("LocationVersion")
            dt.Columns.Add("NewVersion")
            dt.Columns.Add("PublishDate")
            dt.Columns.Add("Description")
            dt.Columns.Add("IsMust")
            Dim dr As DataRow
            If Not dtUpFile Is Nothing Then
                Dim flagHasUpdateItem As Boolean = False
                If dtUpFile.Rows.Count > 0 Then
                    For Each drUpFile As DataRow In dtUpFile.Rows
                        dr = dt.NewRow()
                        dr(0) = drUpFile(0)
                        '本地版本'
                        dr(1) = Common.GetFileVersion(Application.StartupPath & "\" + drUpFile(0).ToString())
                        dr(2) = drUpFile(1)
                        dr(3) = drUpFile(2)
                        dr(4) = drUpFile(3)
                        If drUpFile("UpdateType") = "0" And Common.CompareFileVersion(IIf(IsDBNull(dr(1)), "", dr(1)), IIf(IsDBNull(drUpFile("Fileversion")), "", drUpFile("Fileversion"))) Then
                            dr(5) = "Y" '设置为必须更新'
                            flagHasUpdateItem = True
                        ElseIf (Common.CompareFileVersion(IIf(IsDBNull(dr(1)), "", dr(1)), IIf(IsDBNull(drUpFile("MinimumVersion")), "", drUpFile("MinimumVersion")))) Then
                            dr(5) = "Y" '设置为必须更新'
                            flagHasUpdateItem = True
                        Else
                            dr(5) = "N"
                        End If
                        dt.Rows.Add(dr)
                    Next
                    dgvUpdateContent.DataSource = dt
                    If Not flagHasUpdateItem Then
                        btnInstallAll.Text = "立即启动"
                    End If

                Else
                    Common.AlertAotuCloseMeessageBox("暂无需要更新的系统文件，程序将在3秒后自动进入MES系统,点击确定立即进入.", 3000)
                    System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
                    Application.ExitThread()
                End If
            Else
                Common.AlertAotuCloseMeessageBox("暂无需要更新的系统文件，程序将在3秒后自动进入MES系统,点击确定立即进入.", 3000)
                System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
                Application.ExitThread()
            End If
        Catch ex As Exception
            lblMsg.Text = "系统异常，异常信息：" + ex.Message
            Common.AlertAotuCloseMeessageBox("系统更新出现异常，程序将在6秒后跳过更新自动进入MES系统,点击确定立即进入.", 6000)
            System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
            Me.Close()
            Application.ExitThread()
        End Try
    End Sub
    Private Sub GetUpdateFile()
        Try
            BindGridViewInfo()
            If CheckBox2.Checked Then
                btnInstallAll.Enabled = False
                Dim thread1 As New Thread(AddressOf UpdateFile)
                thread1.IsBackground = True
                thread1.Start()
            End If
        Catch ex As Exception
            lblMsg.Text = "系统异常，异常信息：" + ex.Message
            Common.AlertAotuCloseMeessageBox("系统更新出现异常，程序将在6秒后跳过更新自动进入MES系统,点击确定立即进入.", 6000)
            System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
            Me.Close()
            Application.ExitThread()
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim diaResult As DialogResult = MessageBox.Show("确定要关闭更新控制台吗？", "提示", MessageBoxButtons.YesNo)
        If diaResult = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = False
        Me.Visible = False
    End Sub


    Private Sub VisibleUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisibleUpdateToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        Me.Visible = True
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
        Application.ExitThread()
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        Me.Visible = True
    End Sub

    Private Sub chkBoxSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxSelectAll.CheckedChanged
        If chkBoxSelectAll.Checked Then
            For Each dgvRow As DataGridViewRow In dgvUpdateContent.Rows
                dgvRow.Cells(0).Value = True
            Next
        Else
            For Each dgvRow As DataGridViewRow In dgvUpdateContent.Rows
                If dgvRow.Cells(6).Value <> "Y" Then
                    dgvRow.Cells(0).Value = False
                End If
            Next
        End If

    End Sub

    Private Sub dgvUpdateContent_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUpdateContent.CellClick
        If e.ColumnIndex = 0 Then
            If dgvUpdateContent.Rows(e.RowIndex).Cells(0).Value = True Then
                If dgvUpdateContent.Rows(e.RowIndex).Cells(6).Value <> "Y" Then
                    dgvUpdateContent.Rows(e.RowIndex).Cells(0).Value = False
                Else
                    MessageBox.Show("此项为必须更新项.")
                End If
            Else
                dgvUpdateContent.Rows(e.RowIndex).Cells(0).Value = True
                btnInstallAll.Text = "一键更新"
            End If
        End If
    End Sub

    Private Sub dgvUpdateContent_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvUpdateContent.DataBindingComplete
        For Each dgvDr As DataGridViewRow In dgvUpdateContent.Rows
            If dgvDr.Cells(6).Value = "Y" Then
                dgvDr.Cells(0).Value = True
                dgvDr.DefaultCellStyle.BackColor = Color.Red
                dgvDr.DefaultCellStyle.ForeColor = Color.White
            End If
        Next
    End Sub

    Private Sub UpdateFile()
        KillProcess("MesSystem.exe")
        System.Threading.Thread.Sleep(1000)
        Dim countFile As Integer = dgvUpdateContent.Rows.Count
        Dim sbSql As String
        Dim index As Integer = 1
        Dim dtFileContent As New DataTable
        Dim fileLocalPath As String
        For Each dgvDr As DataGridViewRow In dgvUpdateContent.Rows
            fileLocalPath = Application.StartupPath & "\" & dgvDr.Cells(1).Value.ToString()
            lblMsg.Text = "正在检测更新" + dgvDr.Cells(1).Value + "... " + (index).ToString() + "/" + countFile.ToString()
            If dgvDr.Cells(0).Value = True Then
                sbSql = "select filecontent from M_Systemfile_t where usey='Y' and fileclass='0'  and filename='" + dgvDr.Cells(1).Value.ToString() + "'"
                dtFileContent.Clear()
                dtFileContent = conn.GetDataTable(sbSql)
                If Not dtFileContent Is Nothing And dtFileContent.Rows.Count > 0 Then
                    Dim mFile() As Byte
                    mFile = dtFileContent.Rows(0)(0)
                    Common.ByteSaveAsFile(mFile, fileLocalPath)
                End If
            End If
            index += 1
        Next
        lblMsg.ForeColor = Color.Green
        lblMsg.Text = "更新完成！"
        Common.AlertAotuCloseMeessageBox("更新完成，3秒后将自动进入MES系统,点击确定立即进入.", 3000)
        System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
        Me.WindowState = FormWindowState.Minimized
        btnInstallAll.Enabled = True
        BindGridViewInfo()
    End Sub

    Private Sub btnInstallAll_Click(sender As Object, e As EventArgs) Handles btnInstallAll.Click
        btnInstallAll.Enabled = False
        Dim thread1 As New Thread(AddressOf UpdateFile)
        thread1.IsBackground = True
        thread1.Start()
    End Sub
    Public Function CmdPing(ByVal strIp As String) As Boolean
        Return My.Computer.Network.Ping(strIp, 2000)
    End Function

    Private Sub FrmUpdateConsole_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        GetServerIP() '获取服务器IP'
        GetUpdateFile() '获取更新文件'
    End Sub

    Private Sub btnCheckUpdate_Click(sender As Object, e As EventArgs) Handles btnCheckUpdate.Click
        GetUpdateFile()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            SaveSysInit("1")
        Else
            SaveSysInit("0")
        End If

    End Sub
    Private Sub SaveSysInit(ByRef value As String)
        Common.InsertRegeditValue("DGMesAutoUpdateFlag", value)
    End Sub
    Private Function GetSysInit(ByRef keyName As String) As String
        Return Common.ReadRegistValue(keyName)
    End Function
    Private Sub KillProcess(ByVal ProStr As String)

        Dim SysPro As New Process
        For Each SysPro In System.Diagnostics.Process.GetProcessesByName(ProStr)
            Try
                If Not SysPro.CloseMainWindow Then
                    SysPro.Kill()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                SysPro.Close()
            End Try
        Next

    End Sub

End Class