Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports MainFrame
Imports System.Net.Sockets
Imports System.Net
Imports System.Threading
Imports System.Text
Imports BarCodePrint

Public Class FrmLaserPrint
    Public scanSetting As New ScanSetting
    Private IPNum As String         'IP地址
    Private PortID As Integer      '端口地址
    '服务端的Socket
    Dim listener As Socket
    '服务端的运行状态
    Dim IsRun As Boolean = False
    '监听接收数据线程
    Dim myThread As Thread
    '接入端计数器（有那么一点点问题）
    Dim count As Integer = 0
    '公用套接字
    Dim clientSocket As Socket
    '执行与客户端通信的线程
    Dim clientThread As Thread



    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        Try
            scanSetting.FormName = Me.Name
            Dim FrmOpenLock As New FrmSetLock
            FrmNewShareSetForm.vStationType = "P"
            FrmOpenLock.ShowDialog()
            If CartonScanOption.CheckStr = True Then
                Dim FrmScanSet As New FrmNewShareSetForm(scanSetting)
                FrmScanSet.Owner = Me
                FrmScanSet.ShowDialog()
            End If
            If scanSetting.IsExitFlag = True Then
                scanSetting.MoidStr = ""
                TxtMoId.Text = String.Empty
                TxtPartid.Text = String.Empty
                TxtPartid.Text = String.Empty
                TxtLineId.Text = String.Empty
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "请设置扫描参数"
                Exit Sub
            End If
            TxtMoId.Text = scanSetting.MoidStr           ''工單
            TxtSitName.Text = scanSetting.vStandId & scanSetting.vStandName    ''工單數量
            ''LabCust.Text = scanSetting.CustStr ''工單類型
            TxtPartid.Text = scanSetting.PartidStr ''料件編號
            '' LabMoCust.Text = scanSetting.MoCustStr ''客戶料號
            TxtLineId.Text = scanSetting.LineStr ''線別
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lblMessage.Text = ex.Message
        End Try
    End Sub

    Private Sub btnLaser_Click(sender As Object, e As EventArgs) Handles btnLaser.Click
        If String.IsNullOrEmpty(TxtMoId.Text) Then
            lblMessage.Text = "请先做扫描设定"
            Exit Sub
        End If
        If txtQty.Value = 0 Then
            lblMessage.Text = "镭雕数量不能为0"
            Exit Sub
        End If
        Try
            drResult.Rows.Clear()
            Dim sn As String = Nothing
            Dim SQL As String = "EXEC M_GETSONYLASERPPID_T '" & TxtMoId.Text & "','" & TxtLineId.Text & "','" & txtQty.Value & "'"
            Using dt As DataTable = DbOperateUtils.GetDataTable(SQL)
                If dt.Rows.Count < txtQty.Value Then
                    lblMessage.Text = "当前获取的条码数量小于需雕刻的数量,请打印新的条码"
                Else
                    For Each dr As DataRow In dt.Rows
                        sn += dr("PPID").ToString + dr("BARCODE").ToString
                        drResult.Rows.Insert(0, dr("PPID"), dr("BARCODE"))
                    Next
                End If
            End Using
            If Not String.IsNullOrEmpty(sn) Then
                Label7.Text = sn
                Dim msg As Byte() = Encoding.UTF8.GetBytes(sn)
                clientSocket.Send(msg)
                lblMessage.Text = "发送镭雕信息成功"
            End If
        Catch ex As Exception
            lblMessage.Text = ex.Message
        End Try
    End Sub

    Private Sub FrmLaser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If IsRun Then      'true表示客户端还在连接
                'Dim msg As Byte() = Encoding.UTF8.GetBytes("Exit|服务端退出: " + Me.Handle.ToString)
                'Dim bytesSent As Integer = clientSocket.Send(msg)
                clientSocket.Close() '关闭套接字
                clientThread.Abort() '终止线程
            End If
            myThread.Abort() '中止线程
            listener.Close()
        Catch ex As Exception
            Me.Close()
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmLaser_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

      
        Call initPara()             '初始化参数
            Call startE()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub initPara()
        '初始化参数
        IPNum = "127.0.0.1"
        PortID = 10001

        txtIP.Value = PortID
        txtAdd.Text = IPNum


    End Sub

#Region "Socket"
    Private Sub startE()
        listener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) '设置套接字属性
        Dim localEndPoint As New IPEndPoint(Net.IPAddress.Parse(IPNum), PortID)  '将网路的端点表示成IP地址和端口号
        listener.Bind(localEndPoint) '绑定
        listener.Listen(10) '侦听，最多可以侦听10连接
        'BeginInvoke(New EventHandler(AddressOf AddInfo1), "服务端已启动，正在等待连接...")
        myThread = New Thread(AddressOf Create_Thread) '监听主线程
        myThread.Start()
    End Sub
    '为每个接入建立一个线程
    Public Sub Create_Thread()
        While True
            Try
                '在套接字上接收接入的连接 
                clientSocket = listener.Accept()
                '_clientIP = clientSocket.RemoteEndPoint.ToString
                'AllCilents.Add(_clientIP, Me)
                clientThread = New Thread(New ThreadStart(AddressOf startclient))
                clientThread.Start()
            Catch ex As Exception
                MessageBox.Show("listening Error: " & ex.Message)
            End Try
        End While
    End Sub

    Public Sub startclient()
        count += 1
        'BeginInvoke(New EventHandler(AddressOf AddInfo1), "端号：" + Convert.ToString(count) + "客户端已连接")
        'Dim scThread As Threading.Thread = New Threading.Thread(AddressOf Listen)
        'scThread.Start()
        Listen(clientSocket)
    End Sub

    '接受接入端的数据
    Public Sub Listen(ByVal mysocket As Socket)
        Dim bytes() As Byte = New [Byte](1024) {}
        Dim data As String = String.Empty
        ' Dim tokens() As String
        IsRun = True
        While True
            Dim bytesRec As Integer = mysocket.Receive(bytes)
            data = Encoding.UTF8.GetString(bytes, 0, bytesRec)

            If Not data.Equals("TCP:Give me string") Then
                '  BeginInvoke(New EventHandler(AddressOf AddInfo), "标刻机连接错误.....")
                BeginInvoke(New EventHandler(AddressOf AddInfo), "标刻机连接错误.....")
            Else
                BeginInvoke(New EventHandler(AddressOf AddInfo), "标刻机连接成功.....")
            End If
            'BeginInvoke(New EventHandler(AddressOf AddInfo), data) 'Invoke保证线程安全

            'tokens = data.Trim.Split("|")
            'Select Case tokens(0) '分析接收到的数据，可自己定义更多一些
            '    Case "Chat"
            '        BeginInvoke(New EventHandler(AddressOf AddInfo), tokens(1)) 'Invoke保证线程安全
            '    Case "Exit"
            '        IsRun = False
            '        ' AllCilents.Remove(_clientIP)
            '        BeginInvoke(New EventHandler(AddressOf AddInfo1), tokens(1)) 'Invoke保证线程安全
            '        mySocket.Shutdown(SocketShutdown.Both)
            '        mySocket.Close()
            '        Exit Sub
            'End Select
        End While
    End Sub

    Sub AddInfo(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Lblmessage.Text = sender.ToString()

        If sender.ToString() = "" Then
            Lblmessage.Visible = False
        Else
            Lblmessage.Visible = True
        End If

    End Sub

#End Region


    Private Sub ToolPrint_Click(sender As Object, e As EventArgs) Handles ToolPrint.Click
        If Not String.IsNullOrEmpty(TxtMoId.Text) Then
            Using frm As BarCodePrint.FrmListPrintJX = New FrmListPrintJX
                frm.mo = TxtMoId.Text
                frm.ShowDialog()
            End Using
        Else
            lblMessage.Text = "请设置扫描参数"
        End If
    End Sub
End Class