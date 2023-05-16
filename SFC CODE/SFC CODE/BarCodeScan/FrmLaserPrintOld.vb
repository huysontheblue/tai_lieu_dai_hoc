Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Threading
Imports MainFrame.SysCheckData

Public Class FrmLaserPrintOld

    Private icount As Long           '读取的行数计数器
    Private readCount As Long       '读取的总行数，计数器
    Private readLine As Long        '设置读取行数
    Private readStartChar As Long   '设置读取起始字符数
    Private readChrLen As Long      '设置读取字符串的长度
    Private IPNum As String         'IP地址
    Private PortID As Integer      '端口地址
    Private printChrLength As Integer  '蚀刻字符串长度
    Dim conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Private RdataSave As New Dictionary(Of String, Dictionary(Of String, String))      '读取的数据保存
    Private l_linkData As New MainFrame.SysDataHandle.SysDataBaseClass      '数据连接类型
    Private Mpartid As String = "" ''''料件编号
    Private Moid As String = "" ''''''工单编号

    'Private LaserCount As Integer = 0
    Private IsSendOkFlag As String = "" ''''''记录打标资料是否正确Flag

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
    Public Shared AllCilents As New Hashtable '（未使用）
    Private _client As Socket '（未使用）
    Private _clientIP As String '（未使用）
    ' Private cPort As Integer

    '' ''Private Sub txtInput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInput.TextChanged
    '' ''    '读取数据
    '' ''    If Microsoft.VisualBasic.Right(txtInput.Text, 1) = vbLf Then
    '' ''        icount = icount + 1
    '' ''    End If
    '' ''    If icount >= readCount Then
    '' ''        icount = 0
    '' ''        Call DataAnalysis()     '分析数据

    '' ''        txtInput.Text = ""

    '' ''        If chkAuto.Checked = True And TableLayoutPanel1.Controls.Item("lbl62").Text <> "" And TableLayoutPanel1.Controls.Item("lbl62").Text.Length = printChrLength Then
    '' ''            If dataPrint() Then
    '' ''                Call clearMem()
    '' ''            End If
    '' ''        End If

    '' ''    End If

    '' ''    Call cmdDelState()

    '' ''End Sub

    Private Sub FrmLaserPrint_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub FrmLaserPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LblReadCount.Text = "0"
        CobLaserStyle.SelectedIndex = 0
        'MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = "172.17.30.200"

        Call initPara()             '初始化参数
        Call startE()

    End Sub

    Private Sub clearMem()
        '清空输入的数据
        RdataSave.Clear()
        For i As Integer = 1 To 6
            TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = ""
            TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text = ""
        Next
    End Sub

    Private Sub initPara()
        '初始化参数
        readLine = 5            '5   4
        readStartChar = 26      '26  33
        readChrLen = 17
        readCount = 6
        printChrLength = 12

        IPNum = "127.0.0.1"
        PortID = 10001

        txtIP.Value = PortID
        txtAdd.Text = IPNum

        npLine.Value = readLine
        npStart.Value = readStartChar

        tsLable.Spring = True
        tsLable.Text = "标刻机IP地址： " + IPNum + " ； 端口： " + PortID.ToString() + " ；"
        tsLable.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Private Sub setPara()
        PortID = txtIP.Value
        IPNum = txtAdd.Text.Trim()
        readLine = npLine.Value
        readStartChar = npStart.Value
        tsLable.Text = "标刻机IP地址： " + IPNum + " ； 端口： " + PortID.ToString() + " ；"
    End Sub

    Private Function DataAnalysis(ByVal MsnId As String) As Boolean

        Try
            Lblmessage.Visible = False

            Dim str1 As String
            Dim str2 As String
            Dim i As Integer = 0
            '''''*********************************2013/10/10ouxiangfeng update**********************
            'str1 = Mid(txtInput.Lines(readLine), readStartChar, readChrLen).ToUpper()
            str1 = MsnId
            '''''*********************************2013/10/10ouxiangfeng update**********************

            '需添加读出数据检测,如合格，则写入窗体

            '检测读取总长度是否正确
            If str1.Length = 0 Then
                Call showResult("读取ASN为空!", False)
                LblReadCount.Text = "读取ASN为空，未进行NI测试烧录..."
                IsSendOkFlag = "false"
                Return False
                Exit Function
            End If

            If str1.Length <> readChrLen Then
                Call showResult("读取ASN长度应为：" + readChrLen.ToString() + "!", False)
                LblReadCount.Text = "读取ASN长度应为：" + readChrLen.ToString() + "..."
                IsSendOkFlag = "false"
                Return False
                Exit Function
            End If

            If (CobLaserStyle.SelectedIndex = 0) Then
                str2 = str1.Substring(0, 11) + str1.Substring(15, 1)
            Else
                str2 = str1
            End If

            If RdataSave.ContainsKey(str1) Then
                Call showResult("打标时治具连接器读取异常，重复读取!", False)
                LblReadCount.Text = "打标时治具连接器读取异常，重复读取..."
                IsSendOkFlag = "false"
                Return False
                Exit Function
            End If

            '检测是否已扫描
            Dim mRead As SqlClient.SqlDataReader
            Dim Result As String = ""
            Dim IsNiFlag As String = ""
            'mRead = conn.GetDataReader("select 1 from m_snsbarcode_t where sbarcode='" & str1 & "'")
            '*************************************************************************************************ouxiangfeng2013************************************
            mRead = l_linkData.GetDataReader("select a.moid,b.partid,isnull(a.NiResult,'') NiResult,isnull(a.Islaser,'') Islaser from m_snsbarcode_t a join m_mainmo_t b on a.moid=b.moid where sbarcode='" & str1 & "'")
            If mRead.HasRows Then
                While mRead.Read
                    Mpartid = mRead!partid.ToString
                    Moid = mRead!moid.ToString
                    Result = mRead!NiResult.ToString
                    IsNiFlag = mRead!Islaser.ToString()
                End While
                mRead.Close()
            Else
                mRead.Close()
                MessageBox.Show("NI烧录序号打印记录中不存在，或标刻读取错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LblReadCount.Text = "NI烧录序号打印记录中不存在，或标刻读取错误..."
                Me.txtInput.Clear()
                IsSendOkFlag = "false"
                clearMem()
                Exit Function
            End If
            mRead.Close()

            If IsNiFlag = "Y" Then
                MessageBox.Show("该产品已经过打标作业，不允许重复打标", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LblReadCount.Text = "该产品已经过打标作业，不允许重复打标..."
                Me.txtInput.Clear()
                conn.ExecSql(" insert into m_AssysnE_t(ppid,moid,Spoint,Errordest,userid,Intime)values('" & str1 & "','" & Moid & "','" & My.Computer.Name & "',N'重复打标','" & SysMessageClass.UseId & "', GETDATE())")
                clearMem()
                IsSendOkFlag = "false"
                Exit Function
            End If

            If Result = "F" Then
                MessageBox.Show("该产品NI测试结果为【FAIL】的不良品，不允许打标", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LblReadCount.Text = "该产品NI测试结果为【FAIL】的不良品，不允许打标..."
                Me.txtInput.Clear()
                IsSendOkFlag = "false"
                Return False
                Exit Function
            ElseIf Result = "" Then
                'MessageBox.Show("该产品NI测试结果未及时上传到SFCS系统，不允许打标", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'LblReadCount.Text = "该产品NI测试结果未及时上传到SFCS系统，不允许打标..."
                'Me.txtInput.Clear()
                'IsSendOkFlag = "false"
                'Return False
                'Exit Function
            End If
            '*************************************************************************************************ouxiangfeng2013************************************
            'Dim Result As String = ""
            'mRead = l_linkData.GetDataReader("select top 1 isnull(result,'') result from m_NitestRecord_t  where sn='" & str1 & "' order by intime desc")
            'If mRead.HasRows Then
            '    While mRead.Read
            '        Result = mRead!result
            '    End While
            '    mRead.Close()
            'Else
            '    mRead.Close()
            '    MessageBox.Show("该产品NI测试结果未及时上传到SFCS系统，不允许打标", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Me.txtInput.Clear()
            '    Exit Function
            'End If

            'If (Result = "") Then
            '    MessageBox.Show("该产品NI测试结果未及时上传到SFCS系统，不允许打标", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Me.txtInput.Clear()
            '    Exit Function
            'End If

            'If (Result = "FAIL") Then
            '    MessageBox.Show("该产品NI测试结果为【FAIL】的不良品，不允许打标", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Me.txtInput.Clear()
            '    Exit Function
            'End If

            If RdataSave.ContainsKey(str1) Then
                Call showResult("打标时治具连接器读取异常，重复读取!", False)
                LblReadCount.Text = "打标时治具连接器读取异常，重复读取..."
                IsSendOkFlag = "false"
                Return False
                Exit Function
            Else
                Call showResult("打标数据读取成功!", True)
            End If

            'mRead = conn.GetDataReader("select 1 from m_NitestRecord_t where sn='" & str1 & "'")
            'If mRead.HasRows Then
            '    mRead.Close()
            'Else
            '    mRead.Close()
            '    MessageBox.Show("该产品未经过NI烧录...", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Me.txtInput.Clear()
            '    Exit Sub
            'End If

            'If RdataSave.ContainsKey(str1) Then
            '    Call showResult("重复打标!", False)
            '    Exit Sub
            'Else
            '    Call showResult("打标数据读取成功!", True)
            'End If

            Dim e75 As String
            ''''''''''''''2013年11月13日 欧翔峰'''''''''''''''''''''''''
            Dim StarIndex As Integer
            StarIndex = Me.txtInput.Text.ToLower.IndexOf("interface module serial number:")
            Dim fixstr As String = "interface module serial number: "
            e75 = txtInput.Text.Substring(StarIndex + fixstr.Length, 17).Trim
            'MessageBox.Show(e75)
            'MessageBox.Show(txtInput.Text)
            'MessageBox.Show(txtInput.Text.Substring(StarIndex + fixstr.Length, 17).Trim())
            'e75 = Mid(txtInput.Lines(4), 33, 17).ToUpper()    '截取e75内容 old
            ''''''''''''''2013年11月13日 欧翔峰'''''''''''''''''''''''''

            Dim eV As New Dictionary(Of String, String)
            eV.Add(e75, Me.txtInput.Text)
            ''''''''''''''2013年12月27日 欧翔峰'''''''''''''''''''''''''
            RdataSave.Add(str1, eV)
            If RdataSave.Count > 6 Then
                Call showResult("治具连接器读取的数量，超过系统预设的6次!", False)
                LblReadCount.Text = "治具连接器读取的数量，超过系统预设的6次..."
                IsSendOkFlag = "false"
                Return False
                Exit Function
            End If
            '*************************************************************************************************ouxiangfeng2013************************************
            mRead = l_linkData.GetDataReader("select 1 from m_ppidlink_t where ppid='" & e75 & "'")
            If mRead.HasRows = False Then
                mRead.Close()
                Call showResult("该产品条码【" & e75 & "】,未进行E75绑定或绑混...", False)
                LblReadCount.Text = "该产品条码【" & e75 & "】,未进行E75绑定或绑混..."
                IsSendOkFlag = "false"
                Return False
                Exit Function
            End If
            mRead.Close()
            '*************************************************************************************************ouxiangfeng2013************************************
            ''''''''''''''2013年12月27日 欧翔峰'''''''''''''''''''''''''
            i = RdataSave.Count

            TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = str1
            TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text = str2
            Return True
        Catch ex As Exception
            Return False
            Lblmessage.Text = ex.Message.ToString().Replace(Chr(13) + Chr(10), "")
            Lblmessage.Visible = True
            ' MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub showResult(ByVal showValue As String, ByVal isOK As Boolean)
        'isOK＝
        If isOK Then
            Me.lblresult.ForeColor = Color.Blue
        Else
            Me.lblresult.ForeColor = Color.Red
        End If
        Me.lblresult.Text = showValue

    End Sub

    Private Function dataPrint() As Boolean

        Dim strPrint As String = ""
        Dim getValue As String
        Dim LaserCount As Integer = 0
        Dim LaserLogStr As String = "" '''''20131227 ouxiangfeng update

        For i As Integer = 1 To CType(TxtBkcount.Text.Trim, Integer)
            getValue = TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text.Trim
            If getValue = "" Then
                ''Exit For  20131227 ouxiangfeng update
                MessageBox.Show("打标时读取时,出现空字符内容，不允许打标", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LblReadCount.Text = "打标时读取时," & "第" & i.ToString() & "文本框出现空字符内容..."
                clearMem()
                Return False
                Exit Function
                ''''20131227 ouxiangfeng update
            Else
                LaserCount = LaserCount + 1
                strPrint = strPrint + getValue
                LaserLogStr = LaserLogStr + "sn：" + getValue
            End If
        Next
        ''''20131227 ouxiangfeng update
        If LaserCount <> CType(TxtBkcount.Text.Trim, Integer) Then
            MessageBox.Show("成功读取序号的数量，与实际打标数量不符，不能进行打标！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LblReadCount.Text = "成功读取序号的数量，与实际打标数量不符，不能进行打标..."
            clearMem()
            Return False
            Exit Function
        End If
        ''''20131227 ouxiangfeng update
        If strPrint = "" Then
            MessageBox.Show("无数据资料，不能进行打标！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LblReadCount.Text = "无数据资料，不能进行打标..."
            clearMem()
            Return False
            Exit Function
        End If

        Try
            'Dim bytes(1024) As Byte
            'Dim s = New Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            'Dim localEndPoint As New IPEndPoint(IPAddress.Parse(IPNum), PortID)
            's.Connect(localEndPoint)
            's.Send(Encoding.Unicode.GetBytes(strPrint))
            's.Close()

            Dim Sqlstr As New StringBuilder
            'Dim mRead As SqlClient.SqlDataReader
            For Each v As KeyValuePair(Of String, Dictionary(Of String, String)) In RdataSave
                'Dim l_e75 As String
                'Dim l_asn As String
                'Dim l_read As String
                'Dim v1 As Dictionary(Of String, String)
                'l_e75 =default（v.Key）

                'v1 = v.Value
                'l_asn = v1.Keys(0)
                'l_read = v1.Values(0)
                Dim l_e75 As String
                Dim l_asn As String = ""
                Dim l_read As String = ""
                'Dim v1 As Dictionary(Of String, String)
                l_e75 = v.Key

                'v1 = v.Value

                For Each vx As KeyValuePair(Of String, String) In v.Value
                    l_asn = vx.Key
                    l_read = vx.Value
                Next

                'l_asn = v1.Keys(0)
                'l_read = v1.Values(0)
                'mRead = l_linkData.GetDataReader("select partid from m_snsbarcode_t a join m_mainmo_t b on a.moid=b.moid where sbarcode='" & l_e75 & "'")
                Sqlstr.Append(vbNewLine & " insert into M_LineReadSn_t(CableSN,LineSn,LineMsg,Spoint,LaserLines,Partid,moid,intime) values('" & l_e75 & "','" & l_asn & "','" & l_read & "','" & My.Computer.Name & "','" & LaserLogStr & "','" & Mpartid & "','" & Moid & "',GETDATE())")
                Sqlstr.Append(" update m_SnSBarCode_t set Islaser='Y',LaserTime=getdate() where SBarCode='" & l_e75 & "'" & vbNewLine)
                'Sqlstr.Append(" insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,Userid,intime)values('" & l_e75 & "',N'" & LaserLogStr & "','" & SysMessageClass.UseId & "', GETDATE())")
            Next
            l_linkData.ExecSql(Sqlstr.ToString)
            'If System.IO.File.Exists("D:\Laser\Laser.txt") = False Then
            '    System.IO.File.Create("D:\Laser\Laser.txt")
            'Else
            '    System.IO.File.WriteAllText("D:\Laser\Laser.txt", "6pxs：" & strPrint & vbTab & LaserLogStr, Encoding.UTF8)
            'End If
            'MessageBox.Show("传送的数据:" & strPrint)
            If CobLaserStyle.SelectedIndex = 0 Then
                If strPrint.Length <> 72 Then
                    MessageBox.Show("无数据资料，不能进行打标！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LblReadCount.Text = "无数据资料，不能进行打标..."
                    clearMem()
                    Return False
                    Exit Function
                End If
            End If
            Dim msg As Byte() = Encoding.UTF8.GetBytes(strPrint)

            clientSocket.Send(msg)


            'Dim bytes(1024) As Byte
            'Dim s = New Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            'Dim localEndPoint As New IPEndPoint(IPAddress.Parse(IPNum), PortID)
            's.Connect(localEndPoint)
            's.Send(Encoding.Unicode.GetBytes(strPrint))
            's.Shutdown(SocketShutdown.Both)
            's.Close()
            's.Close()
            IsSendOkFlag = ""
            Call showResult("数据传送打标成功!", True)
            Return True

        Catch ex As Exception
            IsSendOkFlag = "false"
            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub cmdDelState()
        If TableLayoutPanel1.Controls.Item("lbl12").Text <> "" Then
            Me.cmdDel.Enabled = True
        Else
            Me.cmdDel.Enabled = False
        End If
    End Sub


    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        If dataPrint() Then
            Call clearMem()
        End If

    End Sub


    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        '删除全部打标数据

        Dim getValue As String = ""
        If MessageBox.Show("是否删除已读取打标读取数据！", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            clearMem()
            IsSendOkFlag = ""
            'RdataSave.Clear()

            'For i As Integer = 6 To 1 Step -1
            '    'getValue = TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text
            '    'RdataSave.Remove(getValue)
            '    TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = ""
            '    TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text = ""
            'Next
        End If

        Call cmdDelState()

        Me.txtInput.Focus()

    End Sub

    Private Sub butSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSet.Click
        Call setPara()
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
                BeginInvoke(New EventHandler(AddressOf AddInfo), "标刻机连接错误.....")
            Else
                BeginInvoke(New EventHandler(AddressOf AddInfo), "")
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


    '"TCP:Give me string"

    Private Sub TxtBkcount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBkcount.KeyPress

        If Char.IsDigit(e.KeyChar) = False AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

    End Sub

    Private Sub Butedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Butedit.Click

        'txtInput.Enabled = False
        'TxtBkcount.Enabled = True
        'Butedit.Enabled = False
        'ButOk.Enabled = True

    End Sub

    Private Sub ButOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButOk.Click

        'If cint(TxtBkcount.Text) > 6 Or cint(TxtBkcount.Text) < 1 Then
        '    MessageBox.Show("镭标的数量，必须大于等于1，同时小于等6pcs")
        '    Exit Sub
        'End If
        'TxtBkcount.Enabled = False
        'ButOk.Enabled = False
        'txtInput.Enabled = True
        'txtInput.Focus()

    End Sub

    Private Sub txtInput_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtInput.PreviewKeyDown

        If CobLaserStyle.SelectedIndex = -1 Then
            MessageBox.Show("请选择打标作业方式...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LblReadCount.Text = "请选择打标作业方式..."
            CobLaserStyle.Focus()
            Exit Sub
        End If
        'If lbl11.Text.Trim = "" Then
        '    LaserCount = 1
        '    LblReadCount.Text = LaserCount
        'Else
        '    LaserCount = LaserCount + 1
        '    LblReadCount.Text = LaserCount
        'End If
        'If LaserCount > 6 Then
        '    clearMem()
        '    Label1.Text = "治具读取过程中发生错误，读取超过6次，不允许打标..."
        '    Call cmdDelState()
        '    IsSendOkFlag = ""
        '    Exit Sub
        'End If
        If e.KeyValue = 13 Then
            Dim ReadSn As String = ""
            If InStr(txtInput.Text.ToLower, "accessory serial number:") <= 0 Then Exit Sub
            Try
                For i As Integer = 0 To txtInput.Lines.Length - 1
                    If InStr(txtInput.Lines(i).ToString.ToLower, "accessory serial number:") > 0 Then
                        ReadSn = txtInput.Lines(i).ToString.Split(":")(1).Trim.ToUpper
                        Exit For
                    End If
                Next
            Catch ex As Exception
                txtInput.Text = ""
                txtInput.Clear()
                txtInput.Focus()
                'txtInput.Text = ex.Message
            End Try
            If ReadSn = "" Then
                MessageBox.Show("读取的ASN序号为空或产品未经过NI烧录", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LblReadCount.Text = "读取的ASN序号为空或产品未经过NI烧录"
                txtInput.Text = ""
                txtInput.Focus()
                Exit Sub
            Else
                If DataAnalysis(ReadSn) = False Then
                    txtInput.Text = ""
                    clearMem()
                    cmdDelState()
                    Exit Sub
                End If
                '分析数据
                txtInput.Text = ""
                If chkAuto.Checked = True And TableLayoutPanel1.Controls.Item("lbl62").Text <> "" And TableLayoutPanel1.Controls.Item("lbl62").Text.Length = printChrLength Then
                    LblReadCount.Text = "当前产品都已读取成功..."
                    If IsSendOkFlag = "false" Then
                        clearMem()
                        LblReadCount.Text = "治具读取过程中，发生过错误提示，不允许打标..."
                        Call cmdDelState()
                        IsSendOkFlag = ""
                        Exit Sub
                    End If
                    If dataPrint() Then
                        LblReadCount.Text = ""
                        IsSendOkFlag = ""
                        'LaserCount = 0
                        'LblReadCount.Text = "0"
                        Call clearMem()
                    End If
                End If
            End If
            Call cmdDelState()
            IsSendOkFlag = ""
            'LaserCount = 0
            'LblReadCount.Text = "0"
        End If


    End Sub
End Class
