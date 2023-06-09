Imports System.Xml
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.Text



Public Class FrmUpdateForm

    Private BP As Bitmap
    Private SF As New StringFormat
    Private sBP As Bitmap

    Dim AberrantFlag As Boolean = False
    Dim SysConnection As New SqlConnection
    Dim SysCommand As New SqlCommand
    Dim ServerName As String
    Dim AttribeServer As String
    Dim Start As String
    Dim Filepath As String = Application.StartupPath
    Dim Count As Integer = 0
    Dim NewDt As DateTime = System.DateTime.Now
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Private Sub llv()
        'Dim Conn As New SysDataBaseClass
        Dim LoacalFileModifyDateTime As String
        'Dim mFile As Byte() = Nothing
        Dim CurrentFileName As String = String.Empty
        'ProgressBarX1.Value = 0
        Timer1.Enabled = False
        Try

            Dim VerReader As SqlDataReader = Conn.GetDataReader("select [filename],filetime,filecontent from M_Systemfile_t where usey='Y' and fileclass='0'")
            While VerReader.Read()
                Dim updateFileName As String = VerReader("filename").ToString
                If LCase(updateFileName) = LCase("MainFrame.DLL") Or LCase(updateFileName) = LCase("Loginlog.xml") Then
                    Continue While
                End If
                LoacalFileModifyDateTime = File.GetLastWriteTime(Filepath & "\" & Trim(VerReader("filename")).ToString)
                If My.Computer.FileSystem.FileExists(Filepath & "\" & VerReader("filename").ToString) = False Or LoacalFileModifyDateTime <> Trim(VerReader("filetime").ToString()) Then
                    CurrentFileName = VerReader("filename").ToString

                    Me.ListBox1.Items.Add("更新文件：" & CurrentFileName)
                    Me.ListBox1.Refresh()
                    If My.Computer.FileSystem.FileExists(Filepath & "\" & VerReader("filename").ToString) Then
                        File.SetAttributes(Filepath & "\" & VerReader("filename").ToString, FileAttributes.Normal)
                    End If
                    'Dim mFile As Byte() = New UTF8Encoding(True).GetBytes(VerReader("filecontent").ToString)
                    Dim mFile() As Byte
                    mFile = VerReader("filecontent")
                    Dim fs As FileStream = File.Create(Filepath & "\" & VerReader("filename").ToString, mFile.Length - 1)
                    fs.Write(mFile, 0, mFile.Length - 1)
                    fs.Close()
                    fs.Dispose()
                    File.SetLastWriteTime(Filepath & "\" & VerReader("filename").ToString, VerReader("filetime"))
                End If
            End While
            VerReader.Close() : VerReader.Dispose()
            KillProcess("Update.exe")
            If Me.ListBox1.Items.Count = 0 Then
                Me.ListBox1.Items.Add("你的系統已是最新版!")
            Else
                Me.ListBox1.Items.Add("系統更新了" & Me.ListBox1.Items.Count.ToString & "筆記錄,更新完成,正在重新啟動")
            End If
            Me.ListBox1.Refresh()
            System.Threading.Thread.Sleep(1000)
            WriteVersion(NewDt)
            'Shell("RCCP.exe", AppWinStyle.NormalFocus)
            System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
            Application.ExitThread()
        Catch ex As Exception
            'AberrantFlag = True
            MessageBox.Show(ex.Message & vbNewLine & "文件：" & CurrentFileName & "自動更新時出錯!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '' KillProcess("SystemUpdateAppcation.exe")
            KillProcess("DataCollect.exe")
            KillProcess("MesSystem.exe")
            Application.ExitThread()
            Exit Sub
        End Try

    End Sub


#Region "獲取上次登錄用戶名"

    Private Sub LoadSqlServerName()

        Dim xmldoc As New XmlDocument
        Try
            xmldoc.Load(Application.StartupPath & "\Loginlog.xml") '讀取XML中的上次登錄用戶名

            Dim nodeList As XmlNodeList = xmldoc.SelectSingleNode("filelist").ChildNodes
            For Each xn As XmlNode In nodeList
                If LCase(xn.Name) = "systemip" Then
                    ServerName = xn.InnerText.Split("\")(0)
                    MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = xn.InnerText
                ElseIf xn.Name = "AttribeServer" Then
                    AttribeServer = xn.InnerText
                ElseIf xn.Name = "StartCollect" Then
                    Start = xn.InnerText
                End If

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK) ''不存在能繼續執行下去。
            Exit Sub
        End Try

    End Sub

#End Region

#Region "保存上次登入用戶"

    Private Sub ModfiyLogInName(ByVal ServerName As String)

        Dim XmlDoc As New XmlDocument
        Try
            XmlDoc.Load(Application.StartupPath & "\Loginlog.xml")  ''打開XML文件
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
        End Try
        File.SetAttributes(Application.StartupPath & "\Loginlog.xml", FileAttributes.Normal) ''設置XML文件為可讀寫

        Dim nodeList As XmlNodeList = XmlDoc.SelectSingleNode("filelist").ChildNodes
        For Each xn As XmlNode In nodeList
            If LCase(xn.Name) = "systemip" Then
                xn.InnerText = ServerName
                Continue For
            End If
            If LCase(xn.Name) = "printfile" Then
                xn.InnerText = "\\" & ServerName & "\PrintFile\"
                Continue For
            End If
        Next

        XmlDoc.Save(Application.StartupPath & "\Loginlog.xml")

    End Sub

#End Region



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


    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    llv()
    'End Sub

    Public Function ReadVerson() As Boolean

        Dim VerReader As SqlDataReader = Conn.GetDataReader("select count(1), max(convert(varchar(19),intime,120)) dt from M_Systemfile_t where  usey='Y' and fileclass='0'")
        While VerReader.Read
            Count = CType(VerReader(0).ToString, Integer)
            NewDt = CType(VerReader(1).ToString, DateTime)
            If CType(VerReader(1).ToString, DateTime) > Readdt() Then
                VerReader.Close()
                VerReader.Dispose()
                Return True
            Else
                VerReader.Close()
                VerReader.Dispose()
                Return False
            End If
        End While
        Return False

    End Function

    Public Function Readdt() As DateTime
        Dim ds As New DataSet
        ds.ReadXml(Filepath & "\" & "Loginlog.xml")
        Return CType(ds.Tables(0).Rows(0).Item("Version").ToString, DateTime)
    End Function

    Sub WriteVersion(ByVal dt As DateTime)
        Dim XmlDoc As New XmlDocument
        Try
            XmlDoc.Load(Application.StartupPath & "\Loginlog.xml")  ''打開XML文件
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "不存在XML文件", "提示信息", MessageBoxButtons.OK)
        End Try
        File.SetAttributes(Application.StartupPath & "\Loginlog.xml", FileAttributes.Normal) ''設置XML文件為可讀寫

        Dim nodeList As XmlNodeList = XmlDoc.SelectSingleNode("filelist").ChildNodes ''
        For Each xn As XmlNode In nodeList
            If xn.Name = "Version" Then
                xn.InnerText = dt.ToString("yyyy/MM/dd HH:mm:ss")
                Exit For
            End If
        Next
        XmlDoc.Save(Application.StartupPath & "\Loginlog.xml")
    End Sub

    Private Sub FrmUpdateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadSqlServerName()

    End Sub

    Public Function CmdPing(ByVal strIp As String) As Boolean
        Return My.Computer.Network.Ping(ServerName, 2000)
    End Function

    Private Sub FrmUpdateForm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If My.Computer.Network.IsAvailable = False Then
            MessageBox.Show("电脑检测不到网络...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Close()
            Exit Sub
        End If

        If CmdPing(ServerName) = False Then
            Dim dResult As DialogResult = MessageBox.Show("网络ping不通，请检查网络状态..." & vbNewLine & "继续尝试连接30秒(Cancel)，或切换备援服务器(Yes)？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            If dResult = Windows.Forms.DialogResult.Cancel Then
                If My.Computer.Network.Ping(ServerName, 30000) = False Then
                    MessageBox.Show("检测不到网络，系统自动切换到备援服务器...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    If My.Computer.Network.Ping(AttribeServer, 2000) = False Then
                        MessageBox.Show("备援服务器网络ping不通...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Exit Sub
                    Else
                        ServerName = AttribeServer
                        ModfiyLogInName(ServerName)
                        Dim IsNew As Boolean = ReadVerson()
                        If IsNew Then
                            llv()
                        Else
                            System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
                            Application.ExitThread()
                        End If
                    End If
                End If
            ElseIf dResult = Windows.Forms.DialogResult.Yes Then
                If My.Computer.Network.Ping(AttribeServer, 2000) = False Then
                    MessageBox.Show("备援服务器网络ping不通...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                Else
                    ServerName = AttribeServer
                    ModfiyLogInName(ServerName)
                    Dim IsNew As Boolean = ReadVerson()
                    If IsNew Then
                        llv()
                    Else
                        System.Diagnostics.Process.Start(Application.StartupPath & "\DataCollect.exe")
                        Application.ExitThread()
                    End If
                End If
            End If
            Me.Close()
            Exit Sub
        Else
            Dim IsNew As Boolean = ReadVerson()
            If IsNew Then
                llv()
            Else
                If Start = "1" Then
                    System.Diagnostics.Process.Start(Application.StartupPath & "\DataCollect.exe")
                    Application.ExitThread()
                Else
                    System.Diagnostics.Process.Start(Application.StartupPath & "\MesSystem.exe")
                    Application.ExitThread()
                End If
               
            End If
        End If
    End Sub
End Class
