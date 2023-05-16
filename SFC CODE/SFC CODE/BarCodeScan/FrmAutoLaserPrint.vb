Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Threading
Imports MainFrame.SysCheckData
Imports System.IO.Ports

Public Class FrmAutoLaserPrint

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
    Dim FailMsg As String = "" ''''''''未打标成功的数据反馈给NI机。
    'Private LaserCount As Integer = 0
    Private IsSendOkFlag As String = "" ''''''记录打标资料是否正确Flag
    Private IsAllOkFlag As String = ""
    Dim IsReapteLaser As String = ""
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


    Dim WithEvents RS232 As SerialPort
    Delegate Sub SetTextCallback(ByVal InputString As String)       '声明一个代理
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
    '*************************************************
    '代理子程序
    '处理上述通信端口的接收事件
    '由于欲将数据显示到接收文本框中，因此必须检查
    '是否由另外得Thread所调用的，若是，则必须先
    '建立代理对象
    'Invoke用于在拥有控件基础窗口控制代码的线程上
    '运行代理
    '*************************************************
    Private Sub DisplayText(ByVal comData As String)
        '如果调用txtReceive的另外的线程，返回true
        If Me.txtReceive.InvokeRequired Then
            '利用代理类型建立对象，并指定代理的函数
            Dim d As New SetTextCallback(AddressOf DisplayText)
            Me.Invoke(d, New Object() {comData})    '以指定的自变量列表调用函数
        Else '相同的线程
            'showstring(comData)     '将收到的数据填入接收文本框中
            Me.txtReceive.Text += comData
        End If
    End Sub


    Private Sub RS232_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles RS232.DataReceived

        Dim ReadStr As String = ""
        Dim InByte() As Byte, ReadCount As Integer, strRead As String
        If RS232.BytesToRead <= 0 Then Exit Sub
        ReDim InByte(RS232.BytesToRead - 1)
        ReadCount = RS232.Read(InByte, 0, RS232.BytesToRead)
        strRead = ""
        If ReadCount = 0 Then
            Exit Sub
        Else
            For Each bData As Byte In InByte
                strRead += bData.ToString & vbCrLf     '若有数据则加到接收文本框
                'DisplayText(strRead)
            Next
            'MsgBox(System.Text.Encoding.UTF8.GetString(InByte))
            ReadStr = System.Text.Encoding.UTF8.GetString(InByte)
            'SetText(System.Text.Encoding.UTF8.GetString(InByte))
            'MsgBox(System.Text.Encoding.GetEncoding("Gb2312").GetString(InByte))
            'If System.Text.Encoding.UTF8.GetString(InByte) <> "0" Then
            '    MsgBox(System.Text.Encoding.UTF8.GetString(InByte))
            'End If
            'SetText(System.Text.Encoding.GetEncoding("Gb2312").GetString(InByte))
        End If
        Me.txtReceive.Text = ReadStr

        Dim CurrIndex As Integer = CInt(Microsoft.VisualBasic.Left(txtReceive.Text, 1))
        If CurrIndex = 9 Then
            For i As Integer = 1 To 6
                If TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = "" Then
                    Dim e75 As String = ""
                    TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = "NoRead"
                    Dim eV As New Dictionary(Of String, String)
                    If CobLaserStyle.SelectedIndex = 0 Then
                        e75 = StrDup(12, " ")
                    Else
                        e75 = StrDup(17, " ")
                    End If
                    TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text = e75
                    eV.Add(e75, "lbl" + i.ToString() + "1")
                    Me.txtInput.Clear()
                    ''''''''''''''2013年12月27日 欧翔峰'''''''''''''''''''''''''
                    RdataSave.Add("lbl" + i.ToString() + "2", eV)
                    FailMsg = FailMsg & "C"
                    Me.TxtSendMsg.Text = FailMsg
                End If
            Next
        End If
        If ReadStr = "999999" And lbl61.Text <> "" Then
            If dataPrint() Then
                LblReadCount.Text = ""
                IsAllOkFlag = ""
                SendFailMessage()
                'LaserCount = 0
                'LblReadCount.Text = "0"
                TxtSendMsg.Text = ""
                FailMsg = ""
                Call clearMem()
            End If
        ElseIf ReadStr = "000000" Then
            FailMsg = ""
            TxtSendMsg.Text = ""
            txtInput.Clear()
            Call clearMem()
        End If
        'If InStr(System.Text.Encoding.GetEncoding("Gb2312").GetString(InByte), "F") > 0 Then
        '    MsgBox(System.Text.Encoding.GetEncoding("Gb2312").GetString(InByte))
        'End If

    End Sub


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
        InitSeriPort()
        'MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = "172.17.30.200"
        'For Each sp As String In SerialPort.GetPortNames()
        '    cmbCom.Items.Add(sp)
        'Next
        'cmbCom.Sorted = True
        'If cmbCom.Items.Count < 1 Then
        '    Lblmessage.Text = "电脑没有检测到可用的端口..."
        'Else
        '    cmbCom.SelectedIndex = 0
        'End If
        Call initPara()             '初始化参数
        Call startE()

    End Sub

    Private Sub InitSeriPort()

        Dim mBaudRate As Integer
        Dim mParity As IO.Ports.Parity
        Dim mDataBit As Integer
        Dim mStopBit As IO.Ports.StopBits
        Dim mPortName As String

        mPortName = cmbCom.Text
        mBaudRate = 9600
        mParity = Parity.None
        mDataBit = 7
        mStopBit = StopBits.One

        RS232 = New IO.Ports.SerialPort(mPortName, mBaudRate, mParity, mDataBit, mStopBit)
        Try
            If Not RS232.IsOpen Then
                RS232.Open()
                'btnSend.Enabled = True
                RS232.ReceivedBytesThreshold = 1        '设置引发事件的门限值
                LblReadCount.Text = "端口已打开..."
            Else
                LblReadCount.Text = "端口打开时发生错误..."
                'MsgBox("通讯端口打开错误！", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            LblReadCount.Text = "通讯端口打开错误！"
        End Try
        

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

        'tsLable.Spring = True
        LblParpValue.Text = "标刻机IP地址： " + IPNum + " ； 端口： " + PortID.ToString() + " ；"
        LblParpValue.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Private Sub setPara()
        PortID = txtIP.Value
        IPNum = txtAdd.Text.Trim()
        readLine = npLine.Value
        readStartChar = npStart.Value
        LblParpValue.Text = "标刻机IP地址： " + IPNum + " ； 端口： " + PortID.ToString() + " ；"
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
                'MessageBox.Show("NI烧录序号打印记录中不存在，或标刻读取错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LblReadCount.Text = "NI烧录序号打印记录中不存在，或标刻读取错误..."
                'Me.txtInput.Clear()
                IsSendOkFlag = "false"
                'clearMem()
                Exit Function
            End If
            mRead.Close()

            If IsNiFlag = "Y" Then
                'MessageBox.Show("该产品已经过打标作业，不允许重复打标", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LblReadCount.Text = "该产品已经过打标作业，不允许重复打标..."
                IsReapteLaser = "D"
                'Me.txtInput.Clear()
                conn.ExecSql(" insert into m_AssysnE_t(ppid,moid,Spoint,Errordest,userid,Intime)values('" & str1 & "','" & Moid & "','" & My.Computer.Name & "',N'重复打标','" & SysMessageClass.UseId & "', GETDATE())")
                'clearMem()
                IsSendOkFlag = "false"
                Exit Function
            End If

            If Result = "F" Then
                'LblReadCount.Text="该产品NI测试结果为【FAIL】的不良品，不允许打标", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LblReadCount.Text = "该产品NI测试结果为【FAIL】的不良品，不允许打标..."
                'Me.txtInput.Clear()
                IsSendOkFlag = "false"
                Return False
                Exit Function
            ElseIf Result = "" Then
                'MessageBox.Show("该产品NI测试结果未及时上传到SFCS系统，不允许打标", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LblReadCount.Text = "该产品NI测试结果未及时上传到SFCS系统，不允许打标..."
                'Me.txtInput.Clear()
                IsSendOkFlag = "false"
                Return False
                Exit Function
            End If
            '*************************************************************************************************ouxiangfeng2013************************************
            'Dim Result As String = ""
            mRead = l_linkData.GetDataReader("select top 1 isnull(result,'') result from m_NitestRecord_t  where sn='" & str1 & "' order by intime desc")
            If mRead.HasRows Then
                While mRead.Read
                    Result = mRead!result
                End While
                mRead.Close()
            Else
                mRead.Close()
                LblReadCount.Text = "该产品NI测试结果未及时上传到SFCS系统，不允许打标"
                'Me.txtInput.Clear()
                Exit Function
            End If

            If (Result = "") Then
                LblReadCount.Text = "该产品NI测试结果未及时上传到SFCS系统，不允许打标"
                'Me.txtInput.Clear()
                Exit Function
            End If

            If (Result = "FAIL") Then
                LblReadCount.Text = "该产品NI测试结果为【FAIL】的不良品，不允许打标"
                'Me.txtInput.Clear()
                Exit Function
            End If

            If RdataSave.Count > 6 Then
                Call showResult("治具连接器读取的数量，超过系统预设的6次!", False)
                LblReadCount.Text = "治具连接器读取的数量，超过系统预设的6次..."
                IsSendOkFlag = "false"
                Return False
                Exit Function
            End If
            '*************************************************************************************************ouxiangfeng2013************************************
            Dim e75 As String
            ''''''''''''''2013年11月13日 欧翔峰'''''''''''''''''''''''''
            Dim StarIndex As Integer
            StarIndex = Me.txtInput.Text.ToLower.IndexOf("interface module serial number:")
            Dim fixstr As String = "interface module serial number: "
            e75 = txtInput.Text.Substring(StarIndex + fixstr.Length, 17).Trim
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


            'MessageBox.Show(e75)
            'MessageBox.Show(txtInput.Text)
            'MessageBox.Show(txtInput.Text.Substring(StarIndex + fixstr.Length, 17).Trim())
            'e75 = Mid(txtInput.Lines(4), 33, 17).ToUpper()    '截取e75内容 old
            ''''''''''''''2013年11月13日 欧翔峰'''''''''''''''''''''''''

            Dim eV As New Dictionary(Of String, String)
            eV.Add(e75, Me.txtInput.Text)
            ''''''''''''''2013年12月27日 欧翔峰'''''''''''''''''''''''''
            RdataSave.Add(str1, eV)

            '*************************************************************************************************ouxiangfeng2013************************************
            ''''''''''''''2013年12月27日 欧翔峰'''''''''''''''''''''''''
            ''''*********************************2014-03-02ouxiangfeng********************
            i = RdataSave.Count
            If txtReceive.Text = "1111111" Then i = 1 : If txtReceive.Text = "222222" Then i = 2 : If txtReceive.Text = "333333" Then i = 3 : If txtReceive.Text = "444444" Then i = 4 : If txtReceive.Text = "555555" Then i = 5 : If txtReceive.Text = "666666" Then i = 6
            TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = str1
            TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text = str2
            ''''*********************************2014-03-02ouxiangfeng********************
            FailMsg = FailMsg & "A"
            Me.TxtSendMsg.Text = FailMsg
            Return True
        Catch ex As Exception
            Return False
            Lblmessage.Text = ex.Message.ToString().Replace(Chr(13) + Chr(10), "")
            Lblmessage.Visible = True
            ' MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub SetExceptionValue(ByVal MsnId As String)

        Dim str1 As String = MsnId
        Dim str2 As String = ""
        Dim e75 As String
        Dim ExHandleFlag As Boolean = True
        Dim i As Integer = 0
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
        If (CobLaserStyle.SelectedIndex = 0) Then
            'str2 = str1.Substring(0, 11) + str1.Substring(15, 1)
            str2 = StrDup(12, " ")
        Else
            'str2 = str1
            str2 = StrDup(17, Keys.Space)
        End If

        'If RdataSave.Count > 6 Then
        '    Call showResult("治具连接器读取的数量，超过系统预设的6次!", False)
        '    LblReadCount.Text = "治具连接器读取的数量，超过系统预设的6次..."
        '    ExHandleFlag = "false"
        '    Exit Sub
        'End If
        ''*************************************************************************************************ouxiangfeng2013************************************
        'Dim mRead = l_linkData.GetDataReader("select 1 from m_ppidlink_t where ppid='" & e75 & "'")
        'If mRead.HasRows = False Then
        '    mRead.Close()
        '    Call showResult("该产品条码【" & e75 & "】,未进行E75绑定或绑混...", False)
        '    LblReadCount.Text = "该产品条码【" & e75 & "】,未进行E75绑定或绑混..."
        '    ExHandleFlag = "false"
        '    Exit Sub
        'End If
        'mRead.Close()


        Dim eV As New Dictionary(Of String, String)
        e75 = e75 & "lbl" & Microsoft.VisualBasic.Left(txtReceive.Text, 1)
        eV.Add(e75, Me.txtInput.Text)
        Me.txtInput.Clear()
        ''''''''''''''2013年12月27日 欧翔峰'''''''''''''''''''''''''
        If RdataSave.ContainsKey(str1) Then
            Call showResult("打标时治具连接器读取异常，重复读取!", False)
            LblReadCount.Text = "打标时治具连接器读取异常，重复读取..."
            Exit Sub
        Else
            Call showResult("打标数据读取成功!", True)
        End If

        RdataSave.Add(str1, eV)
        '*************************************************************************************************ouxiangfeng2013************************************
        ''''''''''''''2013年12月27日 欧翔峰'''''''''''''''''''''''''
        i = RdataSave.Count
        If txtReceive.Text = "1111111" Then i = 1 : If txtReceive.Text = "222222" Then i = 2 : If txtReceive.Text = "333333" Then i = 3 : If txtReceive.Text = "444444" Then i = 4 : If txtReceive.Text = "555555" Then i = 5 : If txtReceive.Text = "666666" Then i = 6
        TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = "FAIL"
        TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text = str2
        'FailMsg = FailMsg + i.ToString
        If IsReapteLaser <> "" Then
            FailMsg = FailMsg & IsReapteLaser
        Else
            FailMsg = FailMsg & "B"
        End If
        Me.TxtSendMsg.Text = FailMsg

    End Sub

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
            getValue = TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text
            'If getValue = "" Then
            '    ''Exit For  20131227 ouxiangfeng update
            '    MessageBox.Show("打标时读取时,出现空字符内容，不允许打标", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    LblReadCount.Text = "打标时读取时," & "第" & i.ToString() & "文本框出现空字符内容..."
            '    clearMem()
            '    Return False
            '    Exit Function
            '    ''''20131227 ouxiangfeng update
            'Else
            '    LaserCount = LaserCount + 1
            strPrint = strPrint + getValue
            '    LaserLogStr = LaserLogStr + "sn：" + getValue
            'End If
        Next
        '''''20131227 ouxiangfeng update
        'If LaserCount <> CType(TxtBkcount.Text.Trim, Integer) Then
        '    MessageBox.Show("成功读取序号的数量，与实际打标数量不符，不能进行打标！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    LblReadCount.Text = "成功读取序号的数量，与实际打标数量不符，不能进行打标..."
        '    clearMem()
        '    Return False
        '    Exit Function
        'End If
        '''''20131227 ouxiangfeng update
        'If strPrint = "" Then
        '    MessageBox.Show("无数据资料，不能进行打标！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    LblReadCount.Text = "无数据资料，不能进行打标..."
        '    clearMem()
        '    Return False
        '    Exit Function
        'End If

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
                Dim l_e75 As String = ""
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
                If l_e75 = "            " Or l_e75 = "NoRead" Or l_e75 = "" Or InStr(l_e75, "lbl") > 0 Or l_asn = "FAIL" Or InStr(l_asn, "lbl") > 0 Then
                    Continue For
                End If
                Sqlstr.Append(vbNewLine & " insert into M_LineReadSn_t(CableSN,LineSn,LineMsg,Spoint,LaserLines,Partid,moid,intime) values('" & l_e75 & "','" & l_asn & "','" & l_read & "','" & My.Computer.Name & "','" & LaserLogStr & "','" & Mpartid & "','" & Moid & "',GETDATE())")
                Sqlstr.Append(" update m_SnSBarCode_t set Islaser='Y',LaserTime=getdate() where SBarCode='" & l_e75 & "'" & vbNewLine)
                'End If
                'Sqlstr.Append(" insert into m_BarcodeExch_t(Oldbarcode,Newbarcode,Userid,intime)values('" & l_e75 & "',N'" & LaserLogStr & "','" & SysMessageClass.UseId & "', GETDATE())")
            Next
            If Sqlstr.ToString <> "" Then
                l_linkData.ExecSql(Sqlstr.ToString)
            End If
            'If System.IO.File.Exists("D:\Laser\Laser.txt") = False Then
            '    System.IO.File.Create("D:\Laser\Laser.txt")
            'Else
            '    System.IO.File.WriteAllText("D:\Laser\Laser.txt", "6pxs：" & strPrint & vbTab & LaserLogStr, Encoding.UTF8)
            'End If
            'MessageBox.Show("传送的数据:" & strPrint)
            'If CobLaserStyle.SelectedIndex = 0 Then
            '    If strPrint.Length <> 72 Then
            '        MessageBox.Show("无数据资料，不能进行打标！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        LblReadCount.Text = "无数据资料，不能进行打标..."
            '        clearMem()
            '        Return False
            '        Exit Function
            '    End If
            'End If
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
        'TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = ""
        'TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text = ""
        Dim CurrIndex As Integer = 0
        If e.KeyValue = 13 And txtReceive.Text <> "" Then
            IsReapteLaser = ""
            CurrIndex = CInt(Microsoft.VisualBasic.Left(txtReceive.Text, 1))
            If CurrIndex = 9 Then Exit Sub
            For i As Integer = 1 To CurrIndex - 1
                If TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = "" Then
                    Dim e75 As String = ""
                    TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "1").Text = "NoRead"
                    Dim eV As New Dictionary(Of String, String)
                    If CobLaserStyle.SelectedIndex = 0 Then
                        e75 = StrDup(12, " ")
                    Else
                        e75 = StrDup(17, " ")
                    End If
                    TableLayoutPanel1.Controls.Item("lbl" + i.ToString() + "2").Text = e75
                    eV.Add(e75, "lbl" + i.ToString() + "1")
                    Me.txtInput.Clear()
                    ''''''''''''''2013年12月27日 欧翔峰'''''''''''''''''''''''''
                    RdataSave.Add("lbl" + i.ToString() + "2", eV)
                    FailMsg = FailMsg & "C"
                    Me.TxtSendMsg.Text = FailMsg
                End If
            Next

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

                    SetExceptionValue(ReadSn)
                    txtInput.Text = ""
                    'clearMem()
                    'cmdDelState()
                    'Exit Sub
                End If
                '分析数据
                txtInput.Text = ""
                'If chkAuto.Checked = True And TableLayoutPanel1.Controls.Item("lbl62").Text <> "" And TableLayoutPanel1.Controls.Item("lbl62").Text.Length = printChrLength Then
                If chkAuto.Checked = True And TableLayoutPanel1.Controls.Item("lbl62").Text <> "" Then
                    LblReadCount.Text = "当前产品都已读取成功..."
                    IsAllOkFlag = "Y"
                    'If IsSendOkFlag = "false" Then
                    '    clearMem()
                    '    LblReadCount.Text = "治具读取过程中，发生过错误提示，不允许打标..."
                    '    Call cmdDelState()
                    '    IsSendOkFlag = ""
                    '    Exit Sub
                    'End If
                    'If dataPrint() Then
                    '    LblReadCount.Text = ""
                    '    IsSendOkFlag = ""
                    '    SendFailMessage()
                    '    'LaserCount = 0
                    '    'LblReadCount.Text = "0"
                    '    Call clearMem()
                    'End If
                End If
            End If
            Call cmdDelState()
            IsSendOkFlag = ""
            'LaserCount = 0
            'LblReadCount.Text = "0"
        End If

    End Sub

    Private Sub SendFailMessage()

        Dim bDataOut(0) As Byte
        Try
            'Me.TxtSendMsg.Text = FailMsg
            'bDataOut(0) = CType(FailMsg, Byte)        '将类型转换为字节
            'RS232.Write(bDataOut, 0, 1)
            RS232.WriteLine(TxtSendMsg.Text)
            FailMsg = ""
        Catch ex As Exception
            Lblmessage.Text = "输入数值错误：" + ex.ToString
        End Try

    End Sub

    Private Sub FrmAutoLaserPrint_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If RS232 Is Nothing OrElse Not RS232.IsOpen Then   '尚未打开
            Lblmessage.Text = "通讯端口尚未打开"
        Else
            RS232.Close()
            RS232 = Nothing
        End If

    End Sub

    'Private Sub txtReceive_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceive.TextChanged

    '    If txtReceive.Text = "999999" And lbl61.Text <> "" Then
    '        If dataPrint() Then
    '            LblReadCount.Text = ""
    '            IsAllOkFlag = ""
    '            SendFailMessage()
    '            'LaserCount = 0
    '            'LblReadCount.Text = "0"
    '            Call clearMem()
    '        End If
    '    ElseIf txtReceive.Text = "000000" Then
    '        Call clearMem()
    '    End If

    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    SendFailMessage()
    'End Sub
End Class
