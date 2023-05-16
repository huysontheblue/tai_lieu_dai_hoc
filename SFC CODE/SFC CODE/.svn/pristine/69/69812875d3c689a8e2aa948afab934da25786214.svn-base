Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports System.IO.Ports
Imports MainFrame.SysCheckData
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmVoltageTest

#Region "Public Enumerations"
    Public Enum DataMode
        Text
        Hex
    End Enum
    Public Enum LogMsgType
        Incoming
        Outgoing
        Normal
        Warning
        [Error]
    End Enum
#End Region

    Dim Conn As New SysDataBaseClass
    Dim WithEvents RS232 As SerialPort
    Delegate Sub SetTextCallback(ByVal InputString As String)       '声明一个代理
    Dim ReceiveData As String = ""

    Private Delegate Sub ShowDelegate(ByVal strshow As String)

    Shared buffersize As Integer = 1
    '十六进制数的大小（假设为6Byte）
    Private buffer As Byte() = New [Byte](buffersize - 1) {}
    '创建缓冲区
    Dim IDStr As String = ""
    Dim DeviceInfo As String = ""
    Dim DeviceSN As String
    Dim MsnStr As String = ""


    Public Sub ShowText(ByVal strshow As String)
        If Me.TxtRecevieString.InvokeRequired Then
            '   this.txtreceive.BeginInvoke(new ShowDelegate(Show), strshow);//这个也可以
            Me.TxtRecevieString.Invoke(New ShowDelegate(AddressOf ShowText), strshow)
        Else
            Me.TxtRecevieString.Text += strshow
        End If

    End Sub

    Private Sub FrmVoltageTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'MainFrame.SysDataHandle.SysDataBaseClass.SqlserverName = "172.17.32.200"
        For Each sp As String In SerialPort.GetPortNames()
            Txtserportid.Items.Add(sp)
        Next
        Txtserportid.Sorted = True
        If Txtserportid.Items.Count < 1 Then
            Lblmessage.Text = "电脑没有检测到可用的端口..."
        Else
            Txtserportid.SelectedIndex = 0
        End If

        Dim mRead As SqlDataReader = Conn.GetDataReader("select Stationid,Stationname from m_Rstation_t where Stationtype='E' and usey='Y'")
        If mRead.HasRows Then
            While mRead.Read
                CobStationid.Items.Add(mRead!Stationid & "-" & mRead!Stationname)
            End While
        End If
        mRead.Close()
        CobStationid.SelectedIndex = -1


    End Sub


    Private Sub CobStationid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobStationid.SelectedIndexChanged

        Dim mRead As SqlDataReader = Conn.GetDataReader("select serportid,DataByte,StopByte,BaudRate,CheckByte,ReceiveStyle,ReadStyle from m_EquipmentCheck_t where Stationid='" & CobStationid.Text.Split("-")(0).Trim & "'")
        Dim ReadStyle As String = ""
        If mRead.HasRows Then
            While mRead.Read
                Txtserportid.Text = mRead!serportid
                TxtDataByte.Text = mRead!DataByte
                TxtStopByte.Text = mRead!StopByte
                TxtBaudRate.Text = mRead!BaudRate
                TxtCheckByte.Text = mRead!CheckByte
                TxtReceiveStyle.Text = IIf(mRead!ReceiveStyle = "1", "1-接收为字符串", "2-接收为字节")
                ReadStyle = mRead!ReadStyle
            End While
        End If
        mRead.Close()
        If ReadStyle = "1" Then TxtReadStyle.Text = "1-读取芯片序号ASN" : If ReadStyle = "2" Then TxtReadStyle.Text = "2-读取芯片序号MSN" : If ReadStyle = "3" Then TxtReadStyle.Text = "3-扫描条码序号"


    End Sub

    Private Sub ToolAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAddNew.Click

        CobStationid.Enabled = True

    End Sub

    Private Sub ToolEditTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolEditTask.Click

        Txtserportid.Enabled = False
        CobStationid.Enabled = False
        OpenSerialPort()

    End Sub

    Private Sub OpenSerialPort()

        Dim mBaudRate As Integer
        Dim mParity As IO.Ports.Parity
        Dim mDataBit As Integer
        Dim mStopBit As IO.Ports.StopBits
        Dim mPortName As String

        mPortName = Txtserportid.Text
        mBaudRate = CInt(Me.TxtBaudRate.Text)
        mParity = Parity.None
        mDataBit = CInt(Me.TxtDataByte.Text)
        mStopBit = StopBits.One

        RS232 = New IO.Ports.SerialPort(mPortName, mBaudRate, mParity, mDataBit, mStopBit)
       
        Try
            If Not RS232.IsOpen Then
                RS232.Open()
                'btnSend.Enabled = True
                'RS232.ReceivedBytesThreshold = 1        '设置引发事件的门限值
                'RS232.ReadBufferSize = 1024 '//接收缓冲区大小
                If Microsoft.VisualBasic.Left(TxtReceiveStyle.Text, 1) = "1" Then
                    RS232.Encoding = Encoding.UTF8
                ElseIf Microsoft.VisualBasic.Left(TxtReceiveStyle.Text, 1) = "2" Then
                    RS232.Encoding = Encoding.BigEndianUnicode
                End If

                Lblmessage.Text = "端口已打开..."
                TxtInput.Enabled = True
                TxtInput.Focus()
            Else
                Lblmessage.Text = "端口打开时发生错误..."
            End If
        Catch ex As Exception
            Lblmessage.Text = "端口打开时发生错误..."
        End Try
    End Sub

    Private Sub ToolDelTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolDelTask.Click

        If RS232 Is Nothing OrElse Not RS232.IsOpen Then   '尚未打开
            Lblmessage.Text = "通讯端口尚未打开"
        Else
            Lblmessage.Text = "通讯端口已关闭"
            RS232.Close()
            RS232 = Nothing
        End If

    End Sub

    Private Sub FrmVoltageTest_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If RS232 Is Nothing OrElse Not RS232.IsOpen Then   '尚未打开
            Lblmessage.Text = "通讯端口尚未打开"
        Else
            RS232.Close()
            RS232 = Nothing
        End If

    End Sub

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
        If Me.TxtRecevieString.InvokeRequired Then
            '利用代理类型建立对象，并指定代理的函数
            'Dim d As New SetTextCallback(AddressOf DisplayText)
            'Me.Invoke(d, New Object() {comData})    '以指定的自变量列表调用函数
        Else '相同的线程
            'showstring(comData)     '将收到的数据填入接收文本框中
            Me.TxtInput.Text += comData
        End If
    End Sub

    Private Sub RS232_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles RS232.DataReceived
        If Not RS232.IsOpen Then
            Return
        End If
        'Me.TxtInput.Text = ""
        ' This method will be called when there is data waiting in the port's buffer
        '        static int buffersize = 18;   ''十六进制数的大小（假设为6Byte）
        'byte[] buffer = new Byte[buffersize];   ''创建缓冲区

        ' Determain which mode (string or binary) the user is in
        If Microsoft.VisualBasic.Left(TxtReceiveStyle.Text, 1) = "1" Then
            ' Read all the data waiting in the buffer
            Dim data As String = RS232.ReadExisting()
            'RS232.ReadLine(c
            ' Display the text to the user in the terminal
            'DisplayText(data)
            ShowText(data)
        Else
            RS232.Read(Buffer, 0, buffersize)
            Dim ss As String
            ss = ByteArrayToBinaryString(buffer)
            'ss = byteToHexStr(buffer)
            'MessageBox.Show((ByteArrayToBinaryString(buffer)))
            '用到函数byteToHexStr
            'TxtRecevieString.Text = ss
            ShowText(ss)
            'RS232.Close()
            'MessageBox.Show("数据接收成功！", "系统提示")
            '' Obtain the number of bytes waiting in the port's buffer
            'Dim bytes As Integer = RS232.BytesToRead
            '' Create a byte array buffer to hold the incoming data
            'Dim buffer As Byte() = New Byte(bytes - 1) {}

            '' Read the data from the port and store it in our buffer
            'RS232.Read(buffer, 0, bytes)
            'ShowText(bytes)
            ' Show the user the incoming data in hex format
            'Log(LogMsgType.Incoming, ByteArrayToHexString(buffer))
        End If

    End Sub

    ''' <summary>
    ''' 字节数组节转换成二进制字符串
    ''' </summary>
    ''' 要转换的字节数组
    ''' <returns></returns>
    Private Shared Function ByteArrayToBinaryString(ByVal byteArray As Byte()) As String
        Dim capacity As Integer = byteArray.Length * 8
        Dim sb As New StringBuilder(capacity)
        For i As Integer = 0 To byteArray.Length - 1
            sb.Append(byte2BinString(byteArray(i)))
        Next
        Return sb.ToString()
    End Function

    Private Shared Function byte2BinString(ByVal b As Byte) As String
        Return Convert.ToString(b, 2).PadLeft(8, "0"c)
    End Function


    '    用途：将十六进制转化为二进制
    '输入：Hex(十六进制数)
    '输入数据类型：String
    '输出：HEX_to_BIN(二进制数)
    '输出数据类型：String
    '输入的最大数为2147483647个字符  

    Public Function HEX_to_BIN(ByVal Hex As String) As String
        Dim i As Long
        Dim B As String=""

        Hex = UCase(Hex)
        For i = 1 To Len(Hex)
            Select Case Mid(Hex, i, 1)
                Case "0" : B = B & "0000"
                Case "1" : B = B & "0001"
                Case "2" : B = B & "0010"
                Case "3" : B = B & "0011"
                Case "4" : B = B & "0100"
                Case "5" : B = B & "0101"
                Case "6" : B = B & "0110"
                Case "7" : B = B & "0111"
                Case "8" : B = B & "1000"
                Case "9" : B = B & "1001"
                Case "A" : B = B & "1010"
                Case "B" : B = B & "1011"
                Case "C" : B = B & "1100"
                Case "D" : B = B & "1101"
                Case "E" : B = B & "1110"
                Case "F" : B = B & "1111"
            End Select
        Next i
        While Microsoft.VisualBasic.Left(B, 1) = "0"
            B = Microsoft.VisualBasic.Right(B, Len(B) - 1)
        End While
        HEX_to_BIN = B

    End Function
    '字节数组转16进制字符串
    Public Shared Function byteToHexStr(ByVal bytes As Byte()) As String
        Dim returnStr As String = ""
        If bytes IsNot Nothing Then
            For i As Integer = 0 To bytes.Length - 1
                returnStr += bytes(i).ToString("X2")
            Next
        End If
        Return returnStr
    End Function


    ''' <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
    ''' <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
    ''' <returns> Returns a well formatted string of hex digits with spacing. </returns>
    Private Function ByteArrayToHexString(ByVal data As Byte()) As String
        Dim sb As New StringBuilder(data.Length * 3)
        For Each b As Byte In data
            sb.Append(Convert.ToString(b, 16).PadLeft(2, "0"c).PadRight(3, " "c))
        Next
        Return sb.ToString().ToUpper()
    End Function


    '''' <summary> Log data to the terminal window. </summary>
    '''' <param name="msgtype"> The type of message to be written. </param>
    '''' <param name="msg"> The string containing the message to be shown. </param>
    ''   Private Sub Log(ByVal msgtype As LogMsgType, ByVal msg As String)
    ''TxtRecevieString.Invoke(New EventHandler(Sub() TxtRecevieString.AppendText(msg)))

    ''   End Sub


    'Private Sub RS232_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles RS232.DataReceived

    '    Dim ReadStr As String = ""
    '    Dim InByte() As Byte, ReadCount As Integer, strRead As String
    '    If RS232.BytesToRead <= 0 Then Exit Sub
    '    'MsgBox(RS232.ReadExisting)
    '    'DisplayText(strRead)
    '    'TxtRecevieString.Text = RS232.ReadExisting
    '    ReDim InByte(RS232.BytesToRead - 1)
    '    ReadCount = RS232.Read(InByte, 0, RS232.BytesToRead)
    '    strRead = ""
    '    If ReadCount = 0 Then
    '        Exit Sub
    '    Else
    '        'For Each bData As Byte In InByte
    '        strRead += System.Text.Encoding.UTF8.GetString(InByte).ToString     '若有数据则加到接收文本框
    '        MsgBox(strRead)
    '        DisplayText(strRead)
    '        'NextInByte)
    '        ReadStr = System.Text.Encoding.UTF8.GetString(InByte)
    '        'SetText(System.Text.Encoding.UTF8.GetString(InByte))
    '        'MsgBox(System.Text.Encoding.GetEncoding("Gb2312").GetString(InByte))
    '        'If System.Text.Encoding.UTF8.GetString(InByte) <> "0" Then
    '        '    MsgBox(System.Text.Encoding.UTF8.GetString(InByte))
    '        'End If
    '        'SetText(System.Text.Encoding.GetEncoding("Gb2312").GetString(InByte))
    '    End If
    '    'Me.TxtRecevieString.Text = strRead


    'End Sub

    Private Sub TxtInput_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TxtInput.PreviewKeyDown

        'Dim IDStr As String = ""
        'Dim DeviceInfo As String = ""
        'Dim DeviceSN As String
        'Dim MsnStr As String = ""
        If e.KeyValue = 13 Then
            Dim ReadSn As String = ""
          
            If TxtReadStyle.Text.Split("-")(0) = "1" Then
                If InStr(TxtInput.Text.ToLower, "accessory serial number:") <= 0 Then Exit Sub               
                For i = 0 To TxtInput.Lines.Length - 1
                    If InStr(TxtInput.Lines(i), ":") < 0 Then Continue For
                    If InStr(TxtInput.Lines(i).ToLower, "digital id:") > 0 Then
                        IDStr = TxtInput.Lines(i).Split(":")(1).Trim.ToUpper
                    End If
                    If InStr(TxtInput.Lines(i).ToLower, "interface device info:") > 0 Then
                        DeviceInfo = TxtInput.Lines(i).Split(":")(1).Trim.ToUpper
                    End If
                    If InStr(TxtInput.Lines(i).ToLower, "interface device serial number:") > 0 Then
                        DeviceSN = TxtInput.Lines(i).Split(":")(1).Trim.ToUpper
                    End If
                    If InStr(TxtInput.Lines(i).ToLower, "interface module serial number:") > 0 Then
                        MsnStr = TxtInput.Lines(i).Split(":")(1).Trim.ToUpper
                    End If
                    If InStr(TxtInput.Lines(i).ToLower, "accessory serial number:") > 0 Then
                        ReadSn = TxtInput.Lines(i).Split(":")(1).Trim.ToUpper
                    End If
                Next
                '   Digital(ID)
                '   Interface device info:
                '   Interface device serial number:
                'Interface module serial number:
                'If InStr(TxtInput.Text.ToLower, "accessory serial number:") <= 0 Then Exit Sub
                'For i As Integer = 0 To TxtInput.Lines.Length - 1
                '    If InStr(TxtInput.Lines(i).ToString.ToLower, "accessory serial number:") > 0 Then
                '        ReadSn = TxtInput.Lines(i).ToString.Split(":")(1).Trim.ToUpper
                '        Exit For
                '    End If
                'Next
                TxtPpid.Text = ReadSn.Trim
                TxtInput.Clear()
                TxtInput.Focus()
                LblResult.Text = "Read PASS"
                Lblmessage.Text = "E75产品条码读取PASS"
            ElseIf TxtReadStyle.Text.Split("-")(0) = "2" Then
                If InStr(TxtInput.Text.ToLower, "module serial number:") <= 0 Then Exit Sub
                For i As Integer = 0 To TxtInput.Lines.Length - 1
                    If InStr(TxtInput.Lines(i).ToString.ToLower, "accessory serial number:") > 0 And i > 1 Then
                        TxtInput.Clear()
                        Exit Sub
                    End If

                    If InStr(TxtInput.Lines(i).ToString.ToLower, "module serial number:") > 0 Then
                        ReadSn = TxtInput.Lines(i).ToString.Split(":")(1).Trim
                        TxtPpid.Text = ReadSn.Trim
                        Exit For
                    End If
                Next
            Else
                ReadSn = TxtInput.Text.Trim
            End If



            If CobStationid.SelectedIndex = 1 Then
                SendFailMessage("#11111")
            End If
            If CobStationid.SelectedIndex = 0 Then
                If ReadSn = "" Then
                    Lblmessage.Text = "读取的ASN序号为空或产品未经过NI烧录" : TxtInput.Text = "" : TxtInput.Focus()
                    Exit Sub
                Else
                    Dim Mreader As SqlDataReader
                    Dim Islaster As String = ""
                    Mreader = Conn.GetDataReader(" select isnull(Islaser,'') Islaser from m_SnSBarCode_t where sbarcode='" & ReadSn & "'")
                    If Mreader.HasRows Then
                        While Mreader.Read
                            Islaster = Mreader!Islaser
                        End While
                    End If
                    Mreader.Close()
                    If Islaster <> "Y" Then
                        Lblmessage.Text = "读取的ASN序号为空或产品未经过NI烧录"
                        TxtInput.Clear()
                        TxtPpid.Clear()
                        TxtInput.Focus()
                    Else
                        'TxtInput.ReadOnly = True
                        TxtInput.Focus()
                    End If
                End If
            End If
        End If

    End Sub

#Region "发送信息到端口"
    Private Sub SendFailMessage(ByVal SendMsg As String)

        If SendMsg = "" Then
            MessageBox.Show("请输入读取或烧录的指令...")
            TextBox1.Focus()
            Exit Sub
        End If
        'Dim bDataOut(0) As Byte
        Try
            'Me.TxtSendMsg.Text = FailMsg
            'bDataOut(0) = CType(FailMsg, Byte)        '将类型转换为字节
            'RS232.Write(bDataOut, 0, 1)
            RS232.WriteLine(SendMsg)
        Catch ex As Exception
            Lblmessage.Text = "输入数值错误：" + ex.ToString
        End Try

    End Sub

#End Region

    Private Sub TxtRecevieString_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRecevieString.TextChanged

        If CobStationid.SelectedIndex = 0 Then
            If InStr(TxtRecevieString.Text, "F") > 0 Or InStr(TxtRecevieString.Text, "P") Then
                Dim ResultStr As String = IIf(InStr(TxtRecevieString.Text, "F") > 0, "PASS", "FAIL")
                Dim mSqlStr As String = " insert into m_ChargeTestRecord_t(Ppid,DNmv,DPmv,VBusmv,AllReceiveStr,Result,PointId,Userid,Intime)" & _
                "values('" & TxtPpid.Text & "','" & TxtRecevieString.Text.Split("")(0) & "','" & TxtRecevieString.Text.Split("")(1) & "'," & _
                "'" & TxtRecevieString.Text.Split("")(2) & "','" & TxtRecevieString.Text & "','" & ResultStr & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate())"

                Dim mReader As SqlDataReader = Conn.GetDataReader("select 1 from m_TestResult_t where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'")
                If mReader.HasRows Then
                    mSqlStr = mSqlStr & vbNewLine & " insert into m_TestResult_t(ppid,stationid,result,TestCount,intime)values(" & _
                    "'" & TxtPpid.Text & "','" & CobStationid.Text.Split("-")(0).Trim & "','" & ResultStr & "',1,getdate())"
                Else
                    mSqlStr = mSqlStr & vbNewLine & " update m_TestResult_t set result='" & ResultStr & "',TestCount=TestCount+1 where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'"
                End If
                mReader.Close()
                Try
                    Conn.ExecSql(mSqlStr)
                    TxtInput.ReadOnly = False
                    TxtInput.Clear()
                    TxtInput.Focus()
                    TxtPpid.Clear()
                    TxtRecevieString.Clear()
                    DgTestRecord.Rows.Add(CobStationid.Text.Split("-")(0).Trim, TxtPpid.Text, ResultStr, SysMessageClass.UseId, Now.ToLongTimeString)
                    DgTestRecord.AutoResizeColumns()
                    Lblmessage.Text = "充电测试数据保存成功..."
                Catch ex As Exception
                    Lblmessage.Text = "充电测试数据保存时,发生错误..."
                    Exit Sub
                End Try

            End If
        ElseIf CobStationid.SelectedIndex = 2 Then
            If TxtRecevieString.Text.Length = 8 Then
                'TxtRecevieString.Text = TxtInput.Text.Trim
                MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                MetroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                MetroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                MetroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                MetroTileItem6.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
                TxtInput.Clear()
                ExeCuteSaveRecord()
                Exit Sub
            End If
        ElseIf CobStationid.SelectedIndex = 3 Then
            If TxtRecevieString.Text.Split(",").Length = 9 Then
                TxtInput.Clear()
                ExeCuteSaveRecord()
                Exit Sub
            End If
        ElseIf CobStationid.SelectedIndex = 4 Then
            If InStr(TxtRecevieString.Text.Trim, ">") > 0 Then
                TxtInput.Clear()
                ExeCuteSaveRecord()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ToolExitFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolExitFrom.Click

        Me.Close()

    End Sub

    Private Sub TxtRecevieString_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TxtRecevieString.PreviewKeyDown

        'If e.KeyValue <> 13 Then Exit Sub
        'Dim mSqlStr As String = ""
        'Dim ResultStr As String = ""
        'If CobStationid.SelectedIndex = 0 Then
        '    If InStr(TxtRecevieString.Text, "F") > 0 Or InStr(TxtRecevieString.Text, "P") > 0 Then
        '        If TxtPpid.Text.Trim = "" Then
        '            Lblmessage.Text = "未读取E75序号,请确认治具是否连接正确.."
        '            Exit Sub
        '        End If
        '        ResultStr = IIf(InStr(TxtRecevieString.Text, "F") > 0, "FAIL", "PASS")
        '        mSqlStr = " insert into m_ChargeTestRecord_t(Ppid,DNmv,DPmv,VBusmv,AllReceiveStr,Result,PointId,Userid,Intime)" & _
        '        "values('" & TxtPpid.Text & "','" & TxtRecevieString.Text.Split(" ")(0) & "','" & TxtRecevieString.Text.Split(" ")(1) & "'," & _
        '        "'" & TxtRecevieString.Text.Split(" ")(2) & "','" & TxtRecevieString.Text & "','" & ResultStr & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate())"

        '        Dim mReader As SqlDataReader = Conn.GetDataReader("select 1 from m_TestResult_t where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'")
        '        If mReader.HasRows = False Then
        '            mSqlStr = mSqlStr & vbNewLine & " insert into m_TestResult_t(ppid,stationid,result,TestCount,intime)values(" & _
        '            "'" & TxtPpid.Text & "','" & CobStationid.Text.Split("-")(0).Trim & "','" & ResultStr & "',1,getdate())"
        '        Else
        '            mSqlStr = mSqlStr & vbNewLine & " update m_TestResult_t set result='" & ResultStr & "',TestCount=TestCount+1 where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'"
        '        End If
        '        mReader.Close()
        '        Try
        '            Conn.ExecSql(mSqlStr)
        '            DgTestRecord.Rows.Add(CobStationid.Text.Split("-")(0).Trim, TxtPpid.Text, ResultStr, SysMessageClass.UseId, Now.ToLongTimeString)
        '            TxtInput.ReadOnly = False
        '            TxtInput.Clear()
        '            TxtInput.Focus()
        '            TxtPpid.Clear()
        '            TxtRecevieString.Clear()
        '            DgTestRecord.AutoResizeColumns()
        '            Lblmessage.Text = "充电测试数据保存成功..."
        '        Catch ex As Exception
        '            Lblmessage.Text = "充电测试数据保存时,发生错误..."
        '            Exit Sub
        '        End Try
        '    ElseIf CobStationid.SelectedIndex = 1 Then
        '        If TxtRecevieString.Text = "#AAAAA" Then ResultStr = "PASS"
        '        If TxtRecevieString.Text = "#BBBBB" Then ResultStr = "FAIL"
        '        If ResultStr = "" Then Exit Sub
        '        Try
        '            Dim mReader As SqlDataReader = Conn.GetDataReader("select 1 from m_TestResult_t where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'")
        '            If mReader.HasRows = False Then
        '                mSqlStr = mSqlStr & vbNewLine & " insert into m_TestResult_t(ppid,stationid,result,TestCount,intime)values(" & _
        '                "'" & TxtPpid.Text & "','" & CobStationid.Text.Split("-")(0).Trim & "','" & ResultStr & "',1,getdate())"
        '            Else
        '                mSqlStr = mSqlStr & vbNewLine & " update m_TestResult_t set result='" & ResultStr & "',TestCount=TestCount+1 where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'"
        '            End If
        '            mReader.Close()
        '        Catch ex As Exception

        '        End Try


        '    End If

        'End If

    End Sub

    Private Sub ToolBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBack.Click

        TxtPpid.Clear()
        TxtInput.Clear()
        TxtInput.Enabled = False
        TxtRecevieString.Enabled = False
        TxtRecevieString.Clear()
        Txtserportid.Enabled = True
        CobStationid.Enabled = True

    End Sub

    Private Sub ExeCuteSaveRecord()

        Dim mSqlStr As String = ""
        Dim ResultStr As String = ""
        If CobStationid.SelectedIndex = 0 Then
            If InStr(TxtRecevieString.Text, "F") > 0 Or InStr(TxtRecevieString.Text, "P") > 0 Then
                ResultStr = IIf(InStr(TxtRecevieString.Text, "F") > 0, "FAIL", "PASS")
                LblResult.Text = "充电测试：" & ResultStr
                If ResultStr = "PASS" Then
                    LblResult.ForeColor = Color.Green
                Else
                    LblResult.ForeColor = Color.Red
                End If
                mSqlStr = " insert into m_ChargeTestRecord_t(Ppid,StationId,DNmv,DPmv,VBusmv,AllReceiveStr,Result,PointId,Userid,Intime)" & _
                "values('" & TxtPpid.Text & "','" & CobStationid.Text.Split("-")(0).Trim & "','" & TxtRecevieString.Text.Split(" ")(0) & "','" & TxtRecevieString.Text.Split(" ")(1) & "'," & _
                "'" & TxtRecevieString.Text.Split(" ")(2) & "','" & TxtRecevieString.Text & "','" & ResultStr & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate())"

                Dim mReader As SqlDataReader = Conn.GetDataReader("select 1 from m_TestResult_t where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'")
                If mReader.HasRows = False Then
                    mSqlStr = mSqlStr & vbNewLine & " insert into m_TestResult_t(ppid,stationid,result,TestCount,intime)values(" & _
                    "'" & TxtPpid.Text & "','" & CobStationid.Text.Split("-")(0).Trim & "','" & ResultStr & "',1,getdate())"
                Else
                    mSqlStr = mSqlStr & vbNewLine & " update m_TestResult_t set result='" & ResultStr & "',TestCount=TestCount+1 where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'"
                End If
                mReader.Close()
                Try
                    Conn.ExecSql(mSqlStr)
                    DgTestRecord.Rows.Add(CobStationid.Text.Split("-")(0).Trim, TxtPpid.Text, ResultStr, SysMessageClass.UseId, Now.ToLongTimeString)
                    TxtInput.ReadOnly = False
                    TxtInput.Clear()
                    TxtInput.Focus()
                    TxtPpid.Clear()
                    TxtRecevieString.Clear()
                    DgTestRecord.AutoResizeColumns()
                    Lblmessage.Text = "充电测试数据保存成功..."
                Catch ex As Exception
                    Lblmessage.Text = "充电测试数据保存时,发生错误..."
                    Exit Sub
                End Try
            End If

        ElseIf CobStationid.SelectedIndex = 1 Then
            If TxtRecevieString.Text = "#AAAAA" Then ResultStr = "PASS"
            If TxtRecevieString.Text = "#BBBBB" Then ResultStr = "FAIL"
            If ResultStr = "" Then Exit Sub
            Try
                Dim mReader As SqlDataReader = Conn.GetDataReader("select 1 from m_TestResult_t where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'")
                If mReader.HasRows = False Then
                    mSqlStr = mSqlStr & vbNewLine & " insert into m_TestResult_t(ppid,stationid,result,TestCount,intime)values(" & _
                    "'" & TxtPpid.Text & "','" & CobStationid.Text.Split("-")(0).Trim & "','" & ResultStr & "',1,getdate())"
                Else
                    mSqlStr = mSqlStr & vbNewLine & " update m_TestResult_t set result='" & ResultStr & "',TestCount=TestCount+1 where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'"
                End If
                mReader.Close()
            Catch ex As Exception
                Lblmessage.Text = "Wiggle测试数据保存时,发生错误..."
                Exit Sub
            End Try
        ElseIf CobStationid.SelectedIndex = 2 Then

            If TxtRecevieString.Text.Trim.Length < 8 Or TxtRecevieString.Text.Trim.Length > 8 Then
                Lblmessage.Text = "SIB测试工站接收数据不正确..."
                Exit Sub
            End If
            Dim mReader As SqlDataReader
            mReader = Conn.GetDataReader(" select 1 from m_SnSBarCode_t where sbarcode='" & TxtPpid.Text & "' and isnull(NiResult,'')='G'")
            If mReader.HasRows = False Then
                mReader.Close()
                TxtPpid.Clear()
                TxtInput.Clear()
                TxtRecevieString.Clear()
                TxtInput.Focus()
                Lblmessage.Text = "该产品未经过NI测试或结果为FAIL..."
                Exit Sub
            End If
            mReader.Close()

            Dim FialResult As String = Microsoft.VisualBasic.Right(TxtRecevieString.Text, 6)
            ResultStr = IIf(InStr(FialResult, "0") > 0, "FAIL", "PASS")
            LblResult.Text = "SIB测试：" & ResultStr
            If ResultStr = "PASS" Then
                LblResult.ForeColor = Color.Green
            Else
                LblResult.ForeColor = Color.Red
            End If
            Dim ReceStr As Char() = FialResult.ToArray()

            For i As Integer = 0 To ReceStr.Length - 1
                If ReceStr(i) = "0" And i = 0 Then
                    MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
                End If
                If ReceStr(i) = "0" And i = 1 Then
                    MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
                End If
                If ReceStr(i) = "0" And i = 2 Then
                    MetroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
                End If
                If ReceStr(i) = "0" And i = 3 Then
                    MetroTileItem4.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
                End If
                If ReceStr(i) = "0" And i = 4 Then
                    MetroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
                End If
                If ReceStr(i) = "0" And i = 5 Then
                    MetroTileItem6.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange
                End If
            Next

            'Dim IDStr As String = ""
            'Dim DeviceInfo As String = ""
            'Dim DeviceSN As String
            'Dim MsnStr As String = ""

            mSqlStr = "INSERT INTO [m_IpadSibTestData_t]([ppid],[Result],[ASN],[ASNPF],[MSN],[MSNPF],[E75ID],[DEVICEinfo],[DeviceSN],[PinUnMated]" & _
            ",[PinMated],[PinUnMatedOne],[DPUnMated],[DPMated],[DPUnMatedOne],[DNUnMated],[DNMated],[DNUnMatedOne],[Point],[Userid],[Collecttime]) VALUES(" & _
            " '" & TxtPpid.Text & "','" & ResultStr & "','" & TxtPpid.Text & "','P','" & MsnStr & "','P','" & IDStr & "','" & DeviceInfo & "','" & DeviceSN & "','" & ReceStr(5) & "'," & _
            " '" & ReceStr(3) & "', '" & ReceStr(1) & "', '" & ReceStr(4) & "', '" & ReceStr(2) & "', '" & ReceStr(0) & "', '" & ReceStr(4) & "'," & _
            "'" & ReceStr(2) & "', '" & ReceStr(0) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate())"

            'mSqlStr = " insert into m_ChargeTestRecord_t(Ppid,StationId,DNmv,Result,Userid,Intime)" & _
            '"values('" & TxtPpid.Text & "','" & CobStationid.Text.Split("-")(0).Trim & "','" & TxtRecevieString.Text.Split(" ")(0) & "','" & TxtRecevieString.Text.Split(" ")(1) & "'," & _
            '"'" & TxtRecevieString.Text.Split(" ")(2) & "','" & TxtRecevieString.Text & "','" & ResultStr & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate())"

            mReader = Conn.GetDataReader("select 1 from m_TestResult_t where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'")
            If mReader.HasRows = False Then
                mSqlStr = mSqlStr & vbNewLine & " insert into m_TestResult_t(ppid,stationid,result,TestCount,intime)values(" & _
                "'" & TxtPpid.Text & "','" & CobStationid.Text.Split("-")(0).Trim & "','" & ResultStr & "',1,getdate())"
            Else
                mSqlStr = mSqlStr & vbNewLine & " update m_TestResult_t set result='" & ResultStr & "',TestCount=TestCount+1 where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'"
            End If
            mReader.Close()
            Try
                Conn.ExecSql(mSqlStr)
                DgTestRecord.Rows.Insert(0, CobStationid.Text.Split("-")(0).Trim, TxtPpid.Text, ResultStr, SysMessageClass.UseId, Now.ToLongDateString)
                TxtInput.ReadOnly = False
                TxtInput.Clear()
                TxtInput.Focus()
                TxtPpid.Clear()
                TxtRecevieString.Clear()
                DgTestRecord.AutoResizeColumns()
                Lblmessage.Text = "SIB数据保存成功..."
            Catch ex As Exception
                Lblmessage.Text = "SIB数据保存失败..." & ex.Message
                Exit Sub
            End Try
        ElseIf CobStationid.SelectedIndex = 3 Then
            'MessageBox.Show(TxtRecevieString.Text.Split(",")(14))
            If TxtRecevieString.Text.Split(",")(8) = "" Then Exit Sub
            If TxtRecevieString.Text.Split(",")(8) = "1" Then ResultStr = "PASS" Else ResultStr = "FAIL"
            LblResult.Text = "3 IN 1EUT测试：" & ResultStr
            If ResultStr = "PASS" Then
                LblResult.ForeColor = Color.Green
            Else
                LblResult.ForeColor = Color.Red
            End If
            If ResultStr = "" Then Exit Sub
            'Dim TestCount As Integer = 0
            'Dim Result As String = ""
            'Dim mRead As SqlDataReader = Conn.GetDataReader("select TestCount,result from m_TestResult_t where ppid='" & TxtPpid.Text & "' ")
            'If mRead.HasRows Then
            '    While mRead.Read
            '        TestCount = CInt(mRead!TestCount.ToString)
            '        Result = mRead!result
            '    End While
            'End If
            'mRead.Close()
            'If TestCount > 2 And Result <> "PASS" Then
            '    Lblmessage.Text = "该产品测试次数不允许超过3次..."
            '    TxtInput.ReadOnly = False
            '    TxtInput.Clear()
            '    TxtInput.Focus()
            '    TxtPpid.Clear()
            '    TxtRecevieString.Clear()
            '    Exit Sub
            'End If
            '    mSqlStr = "INSERT INTO [m_ThreeInOneTestData_t]([ppid],[Result],[uLightBit],[uPIN],[uDP],[uDN],[LightBit],[PIN],[DP],[DN]" & _
            '    ",[AudioFrequency],[AudioAmplitude],[uLightBitOne],[uPINOne],[uDPOne],[uDNOne],[Point],[Userid],[Collecttime]) VALUES(" & _
            '" '" & TxtPpid.Text & "','" & ResultStr & "','" & TxtRecevieString.Text.Split(",")(0) & "','" & TxtRecevieString.Text.Split(",")(1) & "'," & _
            '" '" & TxtRecevieString.Text.Split(",")(2) & "', '" & TxtRecevieString.Text.Split(",")(3) & "', '" & TxtRecevieString.Text.Split(",")(4) & "'," & _
            '"'" & TxtRecevieString.Text.Split(",")(5) & "', '" & TxtRecevieString.Text.Split(",")(6) & "', '" & TxtRecevieString.Text.Split(",")(7) & "'," & _
            '"'" & TxtRecevieString.Text.Split(",")(8) & "', '" & TxtRecevieString.Text.Split(",")(9) & "', '" & TxtRecevieString.Text.Split(",")(10) & "'," & _
            '"'" & TxtRecevieString.Text.Split(",")(11) & "', '" & TxtRecevieString.Text.Split(",")(12) & "', '" & TxtRecevieString.Text.Split(",")(13) & "'," & _
            '"'" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate())"

            mSqlStr = "INSERT INTO [m_ThreeInOneTestData_t]([ppid],[Result],[ASN],[MSN],[E75ID],[DeviceInfo], [DeviceSN],[uLightBit],[LightBit],[PIN],[DP],[DN]" & _
          ",[AudioFrequency],[AudioAmplitude],[uLightBitOne],[Point],[Userid],[Collecttime],[AllDataStr]) VALUES(" & _
      " '" & TxtPpid.Text & "','" & ResultStr & "', '" & TxtPpid.Text & "','" & MsnStr & "','" & IDStr & "','" & DeviceInfo & "','" & DeviceSN & "'," & _
      "'" & TxtRecevieString.Text.Split(",")(0) & "','" & TxtRecevieString.Text.Split(",")(1) & "'," & _
      " '" & TxtRecevieString.Text.Split(",")(2) & "', '" & TxtRecevieString.Text.Split(",")(3) & "', '" & TxtRecevieString.Text.Split(",")(4) & "'," & _
      "'" & TxtRecevieString.Text.Split(",")(5) & "', '" & TxtRecevieString.Text.Split(",")(6) & "', '" & TxtRecevieString.Text.Split(",")(7) & "'," & _
       "'" & My.Computer.Name & "','" & SysMessageClass.UseId & "',getdate(),'" & TxtRecevieString.Text & "')"
            '"'" & TxtRecevieString.Text.Split(",")(8) & "', '" & TxtRecevieString.Text.Split(",")(9) & "', '" & TxtRecevieString.Text.Split(",")(10) & "'," & _
            '"'" & TxtRecevieString.Text.Split(",")(11) & "', '" & TxtRecevieString.Text.Split(",")(12) & "', '" & TxtRecevieString.Text.Split(",")(13) & "'," & _


            '[ASN],  [MSN],  [E75ID], [DeviceInfo], [DeviceSN]
            Dim mReader As SqlDataReader = Conn.GetDataReader("select 1 from m_TestResult_t where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'")
            If mReader.HasRows = False Then
                mSqlStr = mSqlStr & vbNewLine & " insert into m_TestResult_t(ppid,stationid,result,TestCount,intime)values(" & _
                "'" & TxtPpid.Text & "','" & CobStationid.Text.Split("-")(0).Trim & "','" & ResultStr & "',1,getdate())"
            Else
                mSqlStr = mSqlStr & vbNewLine & " update m_TestResult_t set result='" & ResultStr & "',TestCount=TestCount+1 where ppid='" & TxtPpid.Text & "' and stationid='" & CobStationid.Text.Split("-")(0).Trim & "'"
            End If
            mReader.Close()
            Try
                Conn.ExecSql(mSqlStr)
                DgTestRecord.Rows.Insert(0, CobStationid.Text.Split("-")(0).Trim, TxtPpid.Text, ResultStr, SysMessageClass.UseId, Now.ToLongDateString)
                TxtInput.ReadOnly = False
                TxtInput.Clear()
                TxtInput.Focus()
                TxtPpid.Clear()
                TxtRecevieString.Clear()
                DgTestRecord.AutoResizeColumns()
                Lblmessage.Text = "3 IN 1EUT测试数据保存成功..."
            Catch ex As Exception
                TxtInput.ReadOnly = False
                TxtInput.Clear()
                TxtInput.Focus()
                TxtPpid.Clear()
                TxtRecevieString.Clear()
                Lblmessage.Text = "3 IN 1EUT测试数据保存时,发生错误..."
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub TxtInput_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtInput.TextChanged

        If CobStationid.SelectedIndex = 0 Then
            For j As Integer = 0 To TxtInput.Lines.Length - 1
                If InStr(TxtInput.Lines(j).ToString.ToUpper, "F ") > 0 Or InStr(TxtInput.Lines(j).ToString.ToUpper, "P ") > 0 Then
                    TxtRecevieString.Text = TxtInput.Text.Trim
                    TxtInput.Clear()
                    ExeCuteSaveRecord()
                    Exit Sub
                End If
            Next
       
        End If


    End Sub

    Private Sub TxtPpid_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPpid.Enter
        TxtInput.Focus()
    End Sub

    Private Sub TxtRecevieString_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRecevieString.Enter
        TxtInput.Focus()
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendMsg.Click

    '    Dim bDataOut(0) As Byte
    '    Try
    '        'Me.TxtSendMsg.Text = FailMsg
    '        'bDataOut(0) = CType(FailMsg, Byte)        '将类型转换为字节
    '        'RS232.Write(bDataOut, 0, 1)
    '        RS232.WriteLine("<FSN>")
    '        Lblmessage.Text = "发送<FSN>指令成功..."
    '    Catch ex As Exception
    '        Lblmessage.Text = "输入数值错误：" + ex.ToString
    '    End Try

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SendFailMessage(TextBox1.Text)
        'Dim bDataOut(0) As Byte
        'Try
        '    'Me.TxtSendMsg.Text = FailMsg
        '    'bDataOut(0) = CType(FailMsg, Byte)        '将类型转换为字节
        '    'RS232.Write(bDataOut, 0, 1)
        '    RS232.WriteLine(TextBox1.Text)
        '    Lblmessage.Text = "发送<FSN>指令成功..."
        'Catch ex As Exception
        '    Lblmessage.Text = "输入数值错误：" + ex.ToString
        'End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SendFailMessage(TextBox1.Text)
    End Sub
End Class