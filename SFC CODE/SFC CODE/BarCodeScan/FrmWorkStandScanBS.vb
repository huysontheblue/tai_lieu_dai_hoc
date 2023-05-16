#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO.Ports
Imports BarCodeScan.Data
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports BarCodePrint
'Imports System.Windows.Forms.DataFormats
'Imports Seagull.BarTender.Print

#End Region

Public Class FrmWorkStandScanBS


    '' Dim PreStaion As String = ""

    '#Region "重繪datagridview單元格焦點"
    '    Private Sub dgScanShow_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)

    '        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    '    End Sub
    '#End Region

#Region "窗體變量"
    Dim WithEvents RS232 As SerialPort
    Private Delegate Sub ShowDelegate(ByVal strshow As String)
    Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim LocalData As New BarCodeScan.Data
    '當前站的掃描順序
    Dim scanOrderId As String = ""
    Dim PreBarcode As String = "" ''记录最近扫描成功的条码
    Dim CompleteFlag As Int16 = 0     '装配完成标示
    Private m_strIsRepaired As String = "N"

#End Region

#Region "窗體事件"

    Private Sub FrmInCarton_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        DisposeData()
        WorkStantOption.CustIdString = Nothing
        WorkStantOption.MoidStr = Nothing
        WorkStantOption.LengthStr = Nothing
        WorkStantOption.DateCheck = Nothing
    End Sub

    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                BnScanSet_Click(sender, e)
            Case Keys.F2
                'toolCa_Click(sender, e)
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select

    End Sub


    'Private Sub FrmWorkStantScan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    ''ToolUsename.Text=SysMessageClasss.UseName
    'End Sub


    Private Sub FrmBarScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'SetGridHeadColumn()
        Me.TxtBarCode.Focus()
        'TxtCartonNo.Text = ""
        LabResult.Text = "扫描准备中..."
        lblMessage.Text = "请进行扫描设置..."

        '進入的時候隱藏一些控件
        LblRcode.Visible = False
        TxtRcode.Visible = False
        'ToolNg.Visible = False


        'TxtBarCode.Enabled = False
        'TxtCartonScan.Enabled = False
        'LblPackQty.Text = ""
        ToolUsename.Text = SysMessageClass.UseName
        '''''''''''''''''''' 
        'Me.LblType.Visible = False
        '''''''''''''''''''''''''''''''''''
        Me.chkIsRepaired.Checked = False
    End Sub

#End Region

#Region "掃描設置/返回按鈕事件"

    Private Sub BnScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolScanSet.Click

        Dim CountReader As SqlDataReader
        'Dim DtGetCarton As DataTable
        WorkStantOption.FormName = Me.Name
        'If TxtCartonNo.Text.Trim <> "" Then
        '    MessageBox.Show("該站點對應的次條碼未掃描完整,不能再設置!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If

        Try
            Dim FrmOpenLock As New FrmSetLock
            FrmOpenLock.ShowDialog()

            If CartonScanOption.CheckStr = True Then
                'Application.EnableVisualStyles()
                Dim FrmScanSet As New FrmShareSetForm
                FrmShareSetForm.vStationType = "A"
                ''PreStaion = FrmShareSetForm.vPreStation
                FrmScanSet.ShowDialog()
                If WorkStantOption.IsExitFlag = True Then
                    TxtMoId.Text = String.Empty
                    TxtPartid.Text = String.Empty
                    TxtPartid.Text = String.Empty
                    TxtLineId.Text = String.Empty
                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "请设置扫描参数"
                    Exit Sub
                End If

                TxtBarCode.Focus()

                DGridBarCode.DataSource = Nothing
                LblMoqty.Text = WorkStantOption.MoidqtyStr
                TxtMoId.Text = WorkStantOption.MoidStr           ''工單
                TxtSitName.Text = WorkStantOption.vStandId & WorkStantOption.vStandName    ''工單數量
                ''LabCust.Text = WorkStantOption.CustStr ''工單類型
                TxtPartid.Text = WorkStantOption.PartidStr ''料件編號
                '' LabMoCust.Text = WorkStantOption.MoCustStr ''客戶料號
                TxtLineId.Text = WorkStantOption.LineStr ''線別
                'LblTime.Text = WorkStantOption.TimeStr ''掃描開始時間
                'LabCartonQty.Text = WorkStantOption.NowCartonScanQty
                'TxtSnStyle1.Text = WorkStantOption.SnStyleStr1
                'TxtSnStyle2.Text = WorkStantOption.SnStyleStr2
                ''Me.TxtBarCode.MaxLength = WorkStantOption.LengthStr
                LblScanTime.Text = WorkStantOption.TimeStr
                LabResult.ForeColor = Color.Lime
                lblMessage.ForeColor = Color.Lime
                LabResult.Text = "Ready..."
                lblMessage.Text = "扫描资料已设置..."
                WorkStantOption.vCurrentStandIndex = 1
                TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                If WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 5) = "Y" Then
                    Me.TxtBarCode.WordWrap = True
                    Me.TxtBarCode.Multiline = True
                Else
                    'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 2)
                End If

                ''如果測試站,則顯示輸入不良代碼
                'If WorkStantOption.StationFlag = "T" Then
                '    ToolNg.Visible = True
                'Else
                '    ToolNg.Visible = False
                '    LblRcode.Visible = False
                '    TxtRcode.Visible = False
                'End If

                ''''
                ''  LblType.Text = WorkStantOption.moType
                ''''''''''''''''''''''
                ''獲取未裝滿箱號
                CountReader = Conn.GetDataReader("select ppid from M_Assysn_t where Moid='" & Me.TxtMoId.Text.Trim & "' and Teamid='" & Me.TxtLineId.Text.Trim & "' and Stationid='" & WorkStantOption.vStandId & "' and Estateid='F' order by Intime desc")
                If CountReader.HasRows Then
                    CountReader.Read()
                    TxtCartonNo.Text = CountReader("ppid").ToString
                    CountReader.Close()
                    GetScanItem(Me.TxtCartonNo.Text)
                    LblBarName.ForeColor = Color.Gold
                Else
                    ''WorkStantOption.vStandId = 1
                    CountReader.Close()
                    '' ControlState(False)
                End If
                CountReader.Close()
                Conn.PubConnection.Close()
                ''CountReader = Conn.GetDataReader("select max(scanorderid) maxid from m_RPartStationM_t where Stationid='" & TxtSitName.Text & "' and ppartid='" & TxtPartid.Text & "' order by a.Intime desc")
                ''While CountReader.Read
                ''    WorkStantOption.vStandMaxStaIndex = CountReader!maxid
                ''End While
                ''CountReader.Close()
            End If
            WorkStantOption.CheckStr = False
            LoadPalletPaceQty()
        Catch ex As Exception

            TxtMoId.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtLineId.Text = String.Empty
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "设置扫描参数异常,请重新设置"
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmInCarton", "GetScanItem", "sys")
            'Finally
            '    DisposeData()
        End Try

    End Sub

    Private Sub LoadPalletPaceQty()
        'and intime > '" & Trim(LblScanTime.Text) & "'
        Dim read As SqlDataReader = Conn.GetDataReader("select count(*) packcount from m_AssysnD_t where moid='" & TxtMoId.Text & "' and stationid='" & WorkStantOption.vStandId & " ' and estateid='Y'")
        If read.HasRows Then
            While read.Read
                LabCartonQty.Text = read!packcount.ToString
            End While
        End If
        read.Close()
        Conn.PubConnection.Close()

    End Sub

    Private Sub BnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        LocalData = Nothing
        Me.Close()
    End Sub

#End Region

    Private Sub DisposeData()
        WorkStantOption.PackNumber = Nothing
        WorkStantOption.BarCodeStr = Nothing
        WorkStantOption.DpetNameStr = Nothing
        WorkStantOption.ErrorStr = Nothing
        WorkStantOption.GflenStr = Nothing
        ' WorkStantOption.LengthStr = Nothing
        WorkStantOption.LineStr = Nothing
        WorkStantOption.MoCustStr = Nothing
        WorkStantOption.MoidqtyStr = Nothing
        'WorkStantOption.MoidStr = Nothing
        WorkStantOption.PartidStr = Nothing
        WorkStantOption.PartPackQty = Nothing
        WorkStantOption.PrintPort = Nothing
        WorkStantOption.SnidStr = Nothing
        WorkStantOption.SnStyleStr1 = Nothing
        WorkStantOption.SnStyleStr2 = Nothing
        WorkStantOption.TimeStr = Nothing
        WorkStantOption.CustStr = Nothing
        ''不要用共享变量 实例化类。再将类传递回来。旧方式需整合。
        ''dim aa as string 
        ''''''''''''''''' 
        WorkStantOption.moType = Nothing
        ''''''''''''''''''''''''''''''''''

        WorkStantOption.CustIdString = Nothing
        WorkStantOption.InCartonScanCheck = False

        WorkStantOption.vStandId = Nothing
        WorkStantOption.vStandName = Nothing
        WorkStantOption.vCurrentStandIndex = Nothing
        WorkStantOption.vStandMaxStaIndex = Nothing
        WorkStantOption.vTimeStyleSet = Nothing
        Array.Clear(WorkStantOption.vstyleArray, 0, WorkStantOption.vstyleArray.Length)
        WorkStantOption.vStandIndex = Nothing
        WorkStantOption.TimeStr = Nothing

    End Sub

#Region "獲取掃描記錄"
    Private Sub GetScanItem(ByVal Cartonid As String)
        Dim orderIndex As Integer = 0
        ''  Dim dateStr As String = String.Empty
        DGridBarCode.Rows.Clear()
        'SetGridHeadColumn()
        Dim Dt As SqlDataReader
        Dt = Conn.GetDataReader("select b.ismainbarcode,a.scanorderid,a.Exppid,a.ppid,b.ppartid,b.staorderid,b.tparttext,c.username,a.intime from m_Ppidlink_t a  join m_RPartStationD_t b on  b.scanorderid=a.scanorderid and a.StaOrderid=b.staorderid  join m_users_t c on a.userid=c.userid where" & _
        " ppartid='" & WorkStantOption.PartidStr & "' and Exppid='" & Cartonid & "'  and b.staorderid='" & WorkStantOption.vStandIndex & "' and a.Usey='Y' and b.state='1' order by a.scanorderid")
        'If Dt.HasRows() Then
        While (Dt.Read())
            DGridBarCode.Rows.Add(Dt!ppartid, Dt!staorderid, Dt!Ppid, Dt!tparttext, Dt!username, Dt!intime)
            '獲取當前掃入的條碼
            'PreBarcode = Dt!Ppid.ToString
            PreBarcode = Dt!Ppid.ToString
            If Dt!scanorderid > orderIndex Then
                orderIndex = Dt!scanorderid
            End If
            'If Dt!ismainbarcode = "Y" Then
            '    dateStr = Dt!intime
            'End If
        End While
        'End If

        'While PubDataReader.Read
        '    Me.CobLine.Items.Add(PubDataReader("lineid").ToString)
        'End While
        'If PubDataReader.Read Then
        ''Dt.NextResult()
        ''While (Dt.Read)
        ''    dateStr = DateDiff("d", dateStr, Dt!Datet)
        ''    If dateStr >= 1 Then
        ''        ToolMainBarcode.Visible = True
        ''    End If
        ''End While
        DGridBarCode.AutoResizeColumns()
        ''WorkStantOption.vCurrentStandIndex = DGridBarCode.Rows.Count + 1
        '' WorkStantOption.vCurrentStandIndex = orderIndex + 1

        Dt.Close()
        Dt.Dispose()
        Conn.PubConnection.Close()
        WorkStantOption.vCurrentStandIndex = orderIndex + 1
        TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
        TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
        'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 2)
        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
        If WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 5) = "Y" Then
            Me.TxtBarCode.WordWrap = True
            Me.TxtBarCode.Multiline = True
            Me.TxtBarCode.MaxLength = 500
        End If

    End Sub
#End Region

#Region "舍棄功能"

    'Private Function UnDoMainBarcode() As Boolean

    '    If WorkStantOption.vDeserTionFlag = True Then
    '        TxtBarCode.Clear()
    '        WorkStantOption.vCurrentStandIndex = 1
    '        TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
    '        TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
    '        TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
    '        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
    '        TxtCartonNo.Text = ""
    '        lblMessage.Text = "舍棄主條碼成功!" ''
    '        UnDoMainBarcode = True
    '    Else
    '        TxtBarCode.Clear()
    '        If Me.TxtCartonNo.Text <> "" And WorkStantOption.vSq = "Y" Then
    '            lblMessage.Text = "舍棄主條碼失敗!"
    '        End If
    '        UnDoMainBarcode = False
    '    End If
    '    WorkStantOption.vDeserTionFlag = False
    '    WorkStantOption.vMainBarCode = Nothing
    '    TxtBarCode.Text = ""
    '    Me.TxtBarCode.Focus()
    '    Exit Function

    'End Function

#End Region

    'Public Sub ShowText(ByVal strshow As String)
    '    If Me.TxtBarCode.InvokeRequired Then
    '        '   this.txtreceive.BeginInvoke(new ShowDelegate(Show), strshow);//这个也可以
    '        Me.TxtBarCode.Invoke(New ShowDelegate(AddressOf ShowText), strshow)
    '    Else
    '        Me.TxtBarCode.Text += strshow
    '    End If

    'End Sub

    Private Sub OpenSerialPort()

        Dim mBaudRate As Integer
        Dim mParity As IO.Ports.Parity
        Dim mDataBit As Integer
        Dim mStopBit As IO.Ports.StopBits
        Dim mPortName As String

        mPortName = "COM8"
        mBaudRate = "115200"
        mParity = Parity.None
        mDataBit = 8
        mStopBit = StopBits.One


        RS232 = New IO.Ports.SerialPort(mPortName, mBaudRate, mParity, mDataBit, mStopBit)

        Try
            If Not RS232.IsOpen Then
                RS232.Open()
                'btnSend.Enabled = True
                'RS232.ReceivedBytesThreshold = 1        '设置引发事件的门限值
                'RS232.ReadBufferSize = 1024 '//接收缓冲区大小
                'If Microsoft.VisualBasic.Left(TxtReceiveStyle.Text, 1) = "1" Then
                RS232.Encoding = Encoding.UTF8
                'ElseIf Microsoft.VisualBasic.Left(TxtReceiveStyle.Text, 1) = "2" Then
                '    RS232.Encoding = Encoding.BigEndianUnicode
                'End If

                lblMessage.Text = "端口已打开..."
                'TxtInput.Enabled = True
                'TxtInput.Focus()
            Else
                lblMessage.Text = "端口打开时发生错误..."
            End If
        Catch ex As Exception
            lblMessage.Text = "端口打开时发生错误..."
        End Try
    End Sub

    'Private Sub RS232_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles RS232.DataReceived
    '    If Not RS232.IsOpen Then
    '        Return
    '    End If
    '    'Me.TxtInput.Text = ""
    '    ' This method will be called when there is data waiting in the port's buffer
    '    '        static int buffersize = 18;   ''十六进制数的大小（假设为6Byte）
    '    'byte[] buffer = new Byte[buffersize];   ''创建缓冲区

    '    ' Determain which mode (string or binary) the user is in
    '    'If Microsoft.VisualBasic.Left(TxtReceiveStyle.Text, 1) = "1" Then
    '    ' Read all the data waiting in the buffer
    '    Dim data As String = RS232.ReadExisting()
    '    'RS232.ReadLine(c
    '    ' Display the text to the user in the terminal
    '    'DisplayText(data)
    '    ShowText(data)
    '    'Else
    '    'RS232.Read(Buffer, 0, buffersize)
    '    'Dim ss As String
    '    'ss = ByteArrayToBinaryString(Buffer)
    '    'ss = byteToHexStr(buffer)
    '    'MessageBox.Show((ByteArrayToBinaryString(buffer)))
    '    '用到函数byteToHexStr
    '    'TxtRecevieString.Text = ss
    '    'ShowText(ss)
    '    'RS232.Close()
    '    'MessageBox.Show("数据接收成功！", "系统提示")
    '    '' Obtain the number of bytes waiting in the port's buffer
    '    'Dim bytes As Integer = RS232.BytesToRead
    '    '' Create a byte array buffer to hold the incoming data
    '    'Dim buffer As Byte() = New Byte(bytes - 1) {}

    '    '' Read the data from the port and store it in our buffer
    '    'RS232.Read(buffer, 0, bytes)
    '    'ShowText(bytes)
    '    ' Show the user the incoming data in hex format
    '    'Log(LogMsgType.Incoming, ByteArrayToHexString(buffer))
    '    'End If

    'End Sub


#Region "发送信息到端口"
    Private Sub SendFailMessage(ByVal SendMsg As String)

        If SendMsg = "" Then
            lblMessage.Text = "请输入读取或烧录的指令..."
            Exit Sub
        End If
        'Dim bDataOut(0) As Byte [FSN-DLCMTEST0001]
        Try
            'Me.TxtSendMsg.Text = FailMsg
            'bDataOut(0) = CType(FailMsg, Byte)        '将类型转换为字节
            'RS232.Write(bDataOut, 0, 1)
            RS232.WriteLine(SendMsg)
            lblMessage.Text = "烧录序号完成..."
            If RS232 Is Nothing OrElse Not RS232.IsOpen Then   '尚未打开

            Else
                RS232.Close()
                RS232 = Nothing
            End If
        Catch ex As Exception
            lblMessage.Text = "烧录序号发生错误：" + ex.ToString
        End Try

    End Sub

#End Region

    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt
        FrmError.ShowDialog()
    End Sub

#Region "條碼掃描"

    Private Sub StandScan()
        Dim RecDr As SqlDataReader = Nothing
        Dim Sqlstr As String
        Dim BarCode As String
        Dim sErrorCode As String

        If InStr(TxtBarCode.Text, "'") Then
            TxtBarCode.Clear()
            Exit Sub
        End If

        sErrorCode = TxtRcode.Text
        If Me.TxtMoId.Text = "" Then
            MessageBox.Show("請先設置好掃描基本信息！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If ''
        If TxtBarCode.Text = "" Then
            MessageBox.Show("產品條碼不能為空！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PlaySimpleSound(1)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If
        'If LabCartonQty.Text = LblMoqty.Text Then
        '    MessageBox.Show("产品扫描数量不允许超过工单数量！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    TxtBarCode.Text = ""
        '    Me.TxtBarCode.Focus()
        '    Exit Sub
        'End If
        If WorkStantOption.vCurrentStandIndex = 1 Then
            TxtCartonNo.Text = ""
        Else
            If TxtCartonNo.Text = "" Then
                lblMessage.Text = "主条码不能为空，请重新进行扫描设置..."
                PlaySimpleSound(1)
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If

        If WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 5) = "Y" Then
            Dim ReadSn As String = ""
            If InStr(TxtBarCode.Text.ToLower, "module serial number:") <= 0 Then Exit Sub
            Try
                For i As Integer = 0 To TxtBarCode.Lines.Length - 1
                    If InStr(TxtBarCode.Lines(i).ToString.ToLower, "accessory serial number:") > 0 And i > 1 Then
                        TxtBarCode.Clear()
                        Exit Sub
                    End If

                    If InStr(TxtBarCode.Lines(i).ToString.ToLower, "module serial number:") > 0 Then
                        ReadSn = TxtBarCode.Lines(i).ToString.Split(":")(1).Trim
                        Exit For
                    End If
                Next
            Catch ex As Exception
                TxtBarCode.Text = ""
                TxtBarCode.Clear()
                TxtBarCode.Focus()
                TxtBarCode.Text = ex.Message
            End Try

            Me.TxtBarCode.Text = UCase(ReadSn)
        End If
        If InStr(TxtBarCode.ToString.ToLower, "accessory serial") > 0 Then
            TxtBarCode.Clear()
            Exit Sub
        End If

        BarCode = RTrim(TxtBarCode.Text)

        '----------------- by hs ke 2014-5-26
        If txt_tmpbarcode.Text = "" Then
            If WorkStantOption.vRepeatStyle = "1" Then
                txt_tmpbarcode.Text = TxtBarCode.Text
                LabResult.ForeColor = Color.Green
                lblMessage.ForeColor = Color.Green
                LabResult.Text = BarCode & Space(3) & "扫描成品条码成功，请继续扫描镭射条码！"
                lblMessage.Text = "PASS"
                PlaySimpleSound(1)
                TxtBarCode.Clear()
                TxtBarCode.Focus()
                Exit Sub

            End If
        Else
            If WorkStantOption.vRepeatStyle = "1" Then
                If TxtBarCode.Text = txt_tmpbarcode.Text Then
                    txt_tmpbarcode.Text = ""
                Else
                    Me.LabResult.Text = ""
                    PlaySimpleSound(1)
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
                    WorkStantOption.ErrorStr = "成品条码与镭射的条码不相同..."
                    LabResult.ForeColor = Color.Gold
                    lblMessage.ForeColor = Color.Gold
                    lblMessage.Text = "FAIL..."
                    LabResult.Text = WorkStantOption.ErrorStr
                    Dim FrmError As New FrmScanErrPrompt
                    FrmError.ShowDialog() '' WorkStantOption.vPreStation
                    If WorkStantOption.vDeserTionFlag = True Then
                        TxtBarCode.Clear()
                        WorkStantOption.vCurrentStandIndex = 1
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                        'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                    End If
                    TxtBarCode.Text = ""
                    Me.TxtBarCode.Focus()
                    Exit Sub
                End If
            End If
        End If
        If TxtSnStyle1.Text.Trim.Length <> 0 Then
            If BarCode.Trim.Length <> TxtSnStyle1.Text.Length Then
                WorkStantOption.ErrorStr = "扫描条码长度不对"
                LabResult.Text = "Fail 扫描条码长度不对"
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
                ShowFrmScanErrPrompt()
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If

            If TextHandle.verfyBarCodeStyle(TxtSnStyle1.Text, BarCode, TxtSnStyle2.Text) = False Then
                WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                LabResult.Text = "FAIL 條碼不符合標準樣式"
                'PlaySimpleSound(1)
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
                ShowFrmScanErrPrompt()
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If
        '------------------------------------注释 by hs ke 2014-5-26
        Try
            '马锋   2014-07-24  增加产品序号相同功能
            If (True) Then
                Sqlstr = " DECLARE @strmsgid varchar(1),@strmsgText varchar(50),@currqty int, @NewSBarCode nvarchar(100),@CompleteFlag int " & _
                         " execute [m_CheckPallMulletAssemblyPPID_P20160804bak] '" & Trim(BarCode) & "', " & _
                         " '" & Trim(TxtMoId.Text) & "','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                         "'" & WorkStantOption.PartidStr & "','" & WorkStantOption.vmReplaceArray(WorkStantOption.vCurrentStandIndex, 1).Split("|")(1).ToString & "','" & TxtCartonNo.Text & "'," & _
                         " '" & WorkStantOption.vStandId & "' ,'" & WorkStantOption.vStandIndex & "','" & WorkStantOption.vCurrentStandIndex & "'," & _
                         " '" & WorkStantOption.vPreStation & "','" & WorkStantOption.vStandMaxStaIndex & "','" & LblCheckTime.Text & "', '" & WorkStantOption.vProductSame & "',  '" & m_strIsRepaired & "'," & _
                         "@strmsgid output,@strmsgText output,@currqty output,@NewSBarCode output,@CompleteFlag output  " & _
                        " select @strmsgid,@strmsgText,isnull(@currqty,1),@NewSBarCode AS NewBarCode, ISNULL(@CompleteFlag,0) AS CompleteFlag"
            Else
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''2011/12/21 m_CheckPPID_01PNew20102011---->[m_CheckAssemblyPPID_P]
                Sqlstr = "DECLARE @strmsgid varchar(1),@strmsgText varchar(50),@currqty int execute [m_CheckAssemblyPPID_P] '" & Trim(BarCode) & "', " & _
                         " '" & Trim(TxtMoId.Text) & "','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                         "'" & WorkStantOption.PartidStr & "','" & WorkStantOption.vmReplaceArray(WorkStantOption.vCurrentStandIndex, 1).Split("|")(1).ToString & "','" & TxtCartonNo.Text & "'," & _
                         " '" & WorkStantOption.vStandId & "' ,'" & WorkStantOption.vStandIndex & "','" & WorkStantOption.vCurrentStandIndex & "'," & _
                         " '" & WorkStantOption.vPreStation & "','" & WorkStantOption.vStandMaxStaIndex & "','" & LblCheckTime.Text & "', " & _
                         "@strmsgid output,@strmsgText output,@currqty output select @strmsgid,@strmsgText,isnull(@currqty,1),'' AS NewBarCode, 0 AS CompleteFlag"
                ''''''''''''''''2011/05/20'''''''''''''''''''''''''''''''''''''''
            End If

            RecDr = Conn.GetDataReader(Sqlstr)
            If RecDr.HasRows Then
                RecDr.Read()
                Dim ReturnFlag As String = RecDr.GetString(0)

                Select Case ReturnFlag
                    Case "0", "1", "2", "3"
                        WorkStantOption.ErrorStr = RecDr.GetString(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "4" ''---掃描成功
                        LabResult.ForeColor = Color.Lime
                        lblMessage.ForeColor = Color.Lime

                        If (WorkStantOption.vProductSame = "Y") Then
                            TxtBarCode.Text = RecDr("NewBarCode").ToString
                        End If

                        LabResult.Text = BarCode & Space(3) & "扫描成功！"
                        lblMessage.Text = "PASS"

                        If (CompleteFlag = 1) Then
                            Me.DGridBarCode.DataSource = Nothing
                            Me.DGridBarCode.Rows.Clear()
                        End If
                        Me.DGridBarCode.Rows.Insert(0, WorkStantOption.PartidStr, WorkStantOption.vStandIndex, TxtBarCode.Text, WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3), VbCommClass.VbCommClass.UseId, Now())
                        '顯示下一部件
                        Dim CurrentSer As Integer
                        If WorkStantOption.vCurrentStandIndex = 1 Then
                            TxtCartonNo.Text = TxtBarCode.Text
                            PreBarcode = TxtBarCode.Text
                            CurrentSer = 1
                        End If
                        LblBarName.ForeColor = Color.Gold
                        WorkStantOption.vCurrentStandIndex = WorkStantOption.vCurrentStandIndex + 1
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                        TxtBarCode.MaxLength = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 2)
                        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"

                        If WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 5) = "Y" Then
                            Me.TxtBarCode.WordWrap = True
                            Me.TxtBarCode.Multiline = True
                            TxtBarCode.MaxLength = 1000
                        Else
                            Me.TxtBarCode.WordWrap = False
                            Me.TxtBarCode.Multiline = False
                        End If

                        CompleteFlag = CInt(RecDr.Item("CompleteFlag").ToString)

                        RecDr.Close()
                        TxtBarCode.Text = ""
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                        Conn.PubConnection.Close()
                        If WorkStantOption.vWritePCB = "Y" And CurrentSer = 1 Then
                            Process.Start(Application.StartupPath & "\HID_ControlApp.exe")
                            OpenSerialPort()
                            SendFailMessage("[FSN-" & TxtCartonNo.Text & "]")
                        End If

                        PlaySimpleSound(0)
                        Exit Sub
                    Case "5"
                        WorkStantOption.ErrorStr = RecDr.GetString(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "6", "7"
                        LabCartonQty.Text = CInt(LabCartonQty.Text) + 1
                        PlaySimpleSound(0)
                        LabResult.ForeColor = Color.Lime
                        lblMessage.ForeColor = Color.Lime
                        LabResult.Text = BarCode & Space(3) & "扫描成功！"
                        lblMessage.Text = "PASS"
                        If WorkStantOption.vCurrentStandIndex = 1 Then
                            PreBarcode = TxtBarCode.Text
                        Else
                            PreBarcode = TxtCartonNo.Text
                        End If
                        Me.DGridBarCode.Rows.Insert(0, WorkStantOption.PartidStr, WorkStantOption.vStandIndex, TxtBarCode.Text, WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3), VbCommClass.VbCommClass.UseId, Now())
                        Dim CurrentSer As Integer = WorkStantOption.vCurrentStandIndex
                        WorkStantOption.vCurrentStandIndex = 1
                        LblBarName.ForeColor = Color.White
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                        'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"

                        If WorkStantOption.vstyleArray(1, 5) = "Y" Then
                            Me.TxtBarCode.WordWrap = True
                            Me.TxtBarCode.Multiline = True
                            Me.TxtBarCode.MaxLength = 1000
                        Else
                            Me.TxtBarCode.WordWrap = False
                            Me.TxtBarCode.Multiline = False
                        End If

                        If ReturnFlag = "7" Then
                            PrintMainBarcode(PreBarcode, TxtPartid.Text, WorkStantOption.vStandId)
                        End If
                        CompleteFlag = CInt(RecDr.Item("CompleteFlag").ToString)
                        RecDr.Close()
                        ''  ControlState(False)
                        TxtCartonNo.Text = ""
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                        Conn.PubConnection.Close()
                        If WorkStantOption.vWritePCB = "Y" And CurrentSer = 1 Then
                            Process.Start(Application.StartupPath & "\HID_ControlApp.exe")
                            OpenSerialPort()
                            SendFailMessage("[FSN-" & TxtCartonNo.Text & "]")
                        End If
                        Exit Sub
                End Select

                CompleteFlag = CInt(RecDr.Item("CompleteFlag").ToString)

                RecDr.Close()
                Conn.PubConnection.Close()
                'PlaySimpleSound(1)
                LabResult.ForeColor = Color.Gold
                lblMessage.ForeColor = Color.Gold

                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.TxtCartonNo.Text
                LabResult.Text = BarCode & Space(3) & "扫描失败..."
                lblMessage.Text = "FAIL..."
                Dim FrmError As New FrmScanErrPrompt
                FrmError.ShowDialog()
                If WorkStantOption.vDeserTionFlag = True Then
                    TxtBarCode.Clear()
                    WorkStantOption.vCurrentStandIndex = 1
                    TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                    TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                    'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                    LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                    TxtCartonNo.Text = ""
                    lblMessage.Text = "舍棄主條碼成功!"
                Else
                    TxtBarCode.Clear()
                    If Me.TxtCartonNo.Text <> "" And WorkStantOption.vSq = "Y" Then
                        lblMessage.Text = "舍棄主條碼失敗!"
                    End If
                End If
                WorkStantOption.vDeserTionFlag = False
                WorkStantOption.vMainBarCode = Nothing
                'TxtCartonNo.Text = ""
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                Conn.PubConnection.Close()
                Exit Sub
            End If
        Catch ex As Exception
            TxtBarCode.Text = ""
            TxtBarCode.Clear()
            If Not RecDr Is Nothing Then
                RecDr.Close()
                Conn.PubConnection.Close()
            End If
            PlaySimpleSound(1)
            MessageBox.Show("发生错误" & ex.Message, "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SysMessageClass.WriteErrLog(ex, Me.Name, "BtEnter_Click", "sys")
            Exit Sub
        End Try
    End Sub
#End Region

    Private Sub PrintMainBarcode(ByVal BarCodeStr As String, ByVal partid As String, ByVal Stationid As String)

        Dim BarRprintHandle As New VbCommClass.VbCommClass
        Try
            BarRprintHandle.BarCodeToFile(BarCodeStr, partid, Stationid)
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message
        End Try


    End Sub

    Private Sub TxtSnStyle2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSnStyle2.GotFocus, TxtSnStyle1.GotFocus
        TxtBarCode.Focus()
    End Sub


    'Private Sub ToolMainBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'If TxtCartonNo.Text = "" Then
    '    ToolMainBarcode.Visible = False
    '    Exit Sub
    'End If
    'Dim readStr As SqlDataReader
    'Dim preStation As String = String.Empty
    'Dim iFlag As Integer = WorkStantOption.vStandIndex - 1
    'Dim Sqlstr As String = String.Empty
    'If WorkStantOption.vStandIndex - 1 = 0 Then
    '    Sqlstr = "delete from m_Ppidlink_t where exppid='" & TxtCartonNo.Text & "' and staorderid='" & WorkStantOption.vStandIndex & "' " & vbNewLine
    '    Sqlstr = Sqlstr + " delete from m_AssysnD_t where ppid='" & TxtCartonNo.Text & "' and stationid='" & WorkStantOption.vStandId & "'" & vbNewLine
    '    Sqlstr = Sqlstr + " delete from m_Assysn_t where ppid='" & TxtCartonNo.Text & "' and stationid='" & WorkStantOption.vStandId & "'"
    'Else
    '    readStr = Conn.GetDataReader("select distinct stationid from m_RPartStationD_t where ppartid='" & WorkStantOption.PartidStr & "' and staorderid=' " & iFlag & "' and state='1'")
    '    While readStr.Read
    '        preStation = readStr!stationid.ToString()
    '    End While
    '    readStr.Close()
    '    Sqlstr = "delete from m_Ppidlink_t where exppid='" & TxtCartonNo.Text & "' and staorderid='" & WorkStantOption.vStandIndex & "' " & vbNewLine
    '    Sqlstr = Sqlstr + " delete from m_AssysnD_t where ppid='" & TxtCartonNo.Text & "' and stationid='" & WorkStantOption.vStandId & "'" & vbNewLine
    '    Sqlstr = Sqlstr + " update  m_Assysn_t set stationid='" & preStation & "',estateid='Y' where ppid='" & TxtCartonNo.Text & "' and stationid='" & WorkStantOption.vStandId & "'"
    'End If
    'Try
    '    Conn.ExecSql(Sqlstr)
    '    MessageBox.Show("舍棄主條碼成功！")
    '    ToolMainBarcode.Visible = False
    '    TxtCartonNo.Text = ""
    '    WorkStantOption.vCurrentStandIndex = 1
    '    TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
    '    TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
    '    LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
    '    TxtBarCode.MaxLength = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 2)
    '    Me.DGridBarCode.Rows.Clear()
    'Catch ex As Exception
    '    MessageBox.Show("舍棄主條碼成功！")
    '    Exit Sub
    'End Try



    'End Sub

    'Private Sub ToolOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolOption.Click

    '    If TxtMoId.Text = "" Then
    '        lblMessage.Text = "掃描資料未設置..."
    '        Exit Sub
    '    End If
    '    Dim FrmOpenLock As New FrmOptionSet(Me.LblCheckTime)
    '    FrmOpenLock.ShowDialog()
    '    FrmOpenLock = Nothing
    '    'If CartonScanOption.CheckStr = True Then

    '    'End If

    'End Sub

    'Private Sub ToolPCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolPCB.Click

    '    'Me.TxtBarCode.Clear()
    '    'Me.TxtBarCode.Enabled = True
    '    'Me.TxtBarCode.Focus()
    '    'Me.TxtLsn.Clear()
    '    'Me.TxtLsn.Enabled = False
    '    'Dim frm As New FrmPCBAInit
    '    'frm.ShowDialog()

    'End Sub

    Private Sub ToolN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolNg.Click

        If LblRcode.Visible = False And TxtRcode.Visible = False Then
            LblRcode.Visible = True
            TxtRcode.Visible = True
            TxtRcode.Focus()
            Me.TxtBarCode.ReadOnly = True
        Else
            LblRcode.Visible = False
            TxtRcode.Visible = False
            TxtBarCode.Focus()
            Me.TxtBarCode.ReadOnly = False
        End If
    End Sub

    'Private Sub TxtRcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRcode.KeyPress
    '    Dim sqlstr As String = ""
    '    Dim DRErrorcode As SqlDataReader = Nothing
    '    Dim sErrorCode As String = ""
    '    Dim sPrePpid As String = ""
    '    If e.KeyChar = Chr(13) Then
    '        If Me.PreBarcode = "" Then
    '            Me.lblMessage.Text = "产品或部件条码不能为空..."
    '            'MessageBox.Show("產品或部件條碼不能為空!", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            TxtRcode.Text = ""
    '            LblRcode.Visible = False
    '            TxtRcode.Visible = False
    '            TxtBarCode.Focus()
    '            TxtBarCode.ReadOnly = False
    '            Exit Sub
    '        End If
    '        If TxtRcode.Text <> "" Then
    '            '加入取不良代碼的邏輯
    '            sErrorCode = TxtRcode.Text.ToString.ToUpper
    '            sqlstr = "SELECT codeid,ccname,cename,csortname,esortname,usey from m_Code_t where codeid = '" & Trim(sErrorCode) & "' and usey='Y'"
    '            DRErrorcode = Conn.GetDataReader(sqlstr)
    '            If DRErrorcode.HasRows = False Then
    '                Me.lblMessage.Text = "不良现象代码不存在..."
    '                'MessageBox.Show("不良代碼不存在！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                DRErrorcode.Close()
    '                TxtRcode.Clear()
    '                Exit Sub
    '            End If
    '            DRErrorcode.Close()
    '            Conn.PubConnection.Close()
    '            Try
    '                Dim IsAllowN As String = ""
    '                Dim NGcount As Byte = 0
    '                DRErrorcode = Conn.GetDataReader("select IsAllowNG,IsAllowNGQTY from dbo.m_RPartStationD_t where ppartid='" & TxtPartid.Text & "' and stationid='" & WorkStantOption.vStandId & "' and state=1 ")
    '                If DRErrorcode.HasRows Then
    '                    While DRErrorcode.Read
    '                        IsAllowN = DRErrorcode!IsAllowNG.ToString
    '                        NGcount = DRErrorcode!IsAllowNGQTY
    '                    End While
    '                End If
    '                DRErrorcode.Close()
    '                Conn.PubConnection.Close()
    '                ''update ppidlink set codeid&&usey
    '                If PreBarcode = "" Then
    '                    Me.lblMessage.Text = "主条码为空，不允许进行不良代码录入..."
    '                End If
    '                sPrePpid = PreBarcode
    '                If IsAllowN = "Y" Then
    '                    If NGcount = 0 Then
    '                        Conn.ExecSql("update m_ppidlink_t set usey='E',codeid='" & Trim(sErrorCode) & "' where exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine & _
    '                                        " update m_assysn_t set estateid='E' where ppid= '" & Me.TxtCartonNo.Text & "'" & vbNewLine & " update m_assysnD_t set estateid='E',Codeid='" & sErrorCode & "' where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "'  and sitem=(select max(sitem) from m_assysnD_t where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "')")
    '                        lblMessage.Text = "该产品已作废，不允许维修..."
    '                    Else
    '                        Dim reaptCount As Byte = 0
    '                        DRErrorcode = Conn.GetDataReader("select count(*) ngcount from m_AssyTs_t where Pppid='" & Me.TxtCartonNo.Text & "'")
    '                        If DRErrorcode.HasRows Then
    '                            While DRErrorcode.Read
    '                                reaptCount = DRErrorcode!ngcount
    '                            End While
    '                        End If
    '                        DRErrorcode.Close()
    '                        If NGcount = reaptCount + 1 Then
    '                            Conn.ExecSql("UPDATE m_ppidlink_t set usey='E',codeid='" & Trim(sErrorCode) & "' where exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine & _
    '                                       " UPDATE m_assysn_t set estateid='E' where ppid= '" & Me.TxtCartonNo.Text & "'" & vbNewLine & " update m_assysnD_t set estateid='E' where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "'  and sitem=(select max(sitem) from m_assysnD_t where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "')")
    '                            lblMessage.Text = "该产品已作废，不允许维修..."
    '                        Else
    '                            Conn.ExecSql("update m_ppidlink_t set usey='D',codeid='" & Trim(sErrorCode) & "' where exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine & _
    '                                      " update m_assysn_t set estateid='D' where ppid= '" & Me.TxtCartonNo.Text & "'" & vbNewLine & " update m_assysnD_t set estateid='D' where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "'  and sitem=(select max(sitem) from m_assysnD_t where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "')")
    '                            lblMessage.Text = "该产品已为不良品，请进行维修..."
    '                        End If
    '                    End If
    '                Else



    '                    Conn.ExecSql("UPDATE m_ppidlink_t SET usey='D',codeid='" & Trim(sErrorCode) & "' WHERE exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine & _
    '                    " UPDATE m_assysn_t SET estateid='D' WHERE ppid= '" & sPrePpid & "'" & vbNewLine & _
    '                    " UPDATE m_assysnD_t set estateid='D' where ppid= '" & sPrePpid & "' and stationid= '" & WorkStantOption.vStandId & "'  and " & _
    '                   " sitem=(select max(sitem) from m_assysnD_t where ppid= '" & sPrePpid & "' and stationid= '" & WorkStantOption.vStandId & "')" & vbNewLine & _
    '                   " DELETE FROM m_ppidlink_t WHERE exppid='" & sPrePpid & "' AND stationid= '" & WorkStantOption.vStandId & "' and ScanOrderid>1")
    '                    lblMessage.Text = "该产品已为不良品，请进行维修..."
    '                    Conn.PubConnection.Close()
    '                End If

    '                ''update m_assysn_t表,estateid欄位為D
    '                'Conn.ExecSql("update m_assysn_t set estateid='D' where ppid= '" & WorkStantOption.vMainBarCode & "'")

    '                '顯示掃描成功
    '                LabResult.Text = "不良现象代码" & Space(3) & sErrorCode & Space(3) & "扫描成功"

    '                Me.DGridBarCode.Rows(0).DefaultCellStyle.ForeColor = Color.FromArgb(188, 41, 49)
    '                ''終止掃下一部件
    '                WorkStantOption.vCurrentStandIndex = 1
    '                TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
    '                TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
    '                'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
    '                LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
    '                TxtCartonNo.Text = ""
    '                TxtRcode.Text = ""
    '                TxtBarCode.Focus()
    '                TxtBarCode.ReadOnly = False
    '                Me.LblRcode.Visible = False
    '                Me.TxtRcode.Visible = False
    '            Catch ex As Exception
    '                TxtBarCode.ReadOnly = True
    '                MessageBox.Show(ex.ToString)
    '            End Try

    '        End If
    '    End If
    '    'End If
    'End Sub

    '录入不良代码处理
    Private Sub TxtRcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRcode.KeyPress
        Dim sqlstr As String = "", o_strSQL As StringBuilder = Nothing
        Dim DRErrorcode As SqlDataReader = Nothing
        Dim sErrorCode As String = ""
        Dim sPrePpid As String = ""
        If e.KeyChar = Chr(13) Then
            If Me.PreBarcode = "" Then
                Me.lblMessage.Text = "产品或部件条码不能为空..."
                'MessageBox.Show("產品或部件條碼不能為空!", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtRcode.Text = ""
                LblRcode.Visible = False
                TxtRcode.Visible = False
                TxtBarCode.Focus()
                TxtBarCode.ReadOnly = False
                Exit Sub
            End If
            If TxtRcode.Text <> "" Then
                '加入取不良代碼的邏輯
                sErrorCode = TxtRcode.Text.ToString.ToUpper.Trim()
                sqlstr = "SELECT codeid,ccname,cename,csortname,esortname,usey from m_Code_t where codeid = '" & Trim(sErrorCode) & "' and usey='Y'"
                DRErrorcode = Conn.GetDataReader(sqlstr)
                If DRErrorcode.HasRows = False Then
                    Me.lblMessage.Text = "不良现象代码不存在..."
                    'MessageBox.Show("不良代碼不存在！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DRErrorcode.Close()
                    TxtRcode.Clear()
                    Exit Sub
                End If
                DRErrorcode.Close()
                Conn.PubConnection.Close()
                Try
                    Dim IsAllowN As String = ""
                    Dim NGcount As Byte = 0
                    DRErrorcode = Conn.GetDataReader("SELECT IsAllowNG,IsAllowNGQTY from dbo.m_RPartStationD_t where ppartid='" & TxtPartid.Text & "' and stationid='" & WorkStantOption.vStandId & "' and state=1 ")
                    If DRErrorcode.HasRows Then
                        While DRErrorcode.Read
                            IsAllowN = DRErrorcode!IsAllowNG.ToString
                            NGcount = DRErrorcode!IsAllowNGQTY
                        End While
                    End If
                    DRErrorcode.Close()
                    Conn.PubConnection.Close()
                    ''update ppidlink set codeid&&usey
                    If PreBarcode = "" Then
                        Me.lblMessage.Text = "主条码为空，不允许进行不良代码录入..."
                    End If
                    sPrePpid = PreBarcode
                    If IsAllowN = "Y" Then
                        If NGcount = 0 Then
                            Conn.ExecSql("UPDATE m_ppidlink_t SET usey='E',codeid='" & Trim(sErrorCode) & "' where exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine & _
                                            " UPDATE m_assysn_t set estateid='E' where ppid= '" & Me.TxtCartonNo.Text & "'" & vbNewLine & " update m_assysnD_t set estateid='E',Codeid='" & sErrorCode & "' where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "'  and sitem=(select max(sitem) from m_assysnD_t where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "')")
                            lblMessage.Text = "该产品已作废，不允许维修..."
                        Else
                            Dim reaptCount As Byte = 0
                            DRErrorcode = Conn.GetDataReader("select count(*) ngcount from m_AssyTs_t where Pppid='" & Me.TxtCartonNo.Text & "'")
                            If DRErrorcode.HasRows Then
                                While DRErrorcode.Read
                                    reaptCount = DRErrorcode!ngcount
                                End While
                            End If
                            DRErrorcode.Close()
                            If NGcount = reaptCount + 1 Then
                                Conn.ExecSql("UPDATE m_ppidlink_t set usey='E',codeid='" & Trim(sErrorCode) & "' where exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine & _
                                           " UPDATE m_assysn_t set estateid='E' where ppid= '" & Me.TxtCartonNo.Text & "'" & vbNewLine & " update m_assysnD_t set estateid='E' where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "'  and sitem=(select max(sitem) from m_assysnD_t where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "')")
                                lblMessage.Text = "该产品已作废，不允许维修..."
                            Else
                                Conn.ExecSql("UPDATE m_ppidlink_t set usey='D',codeid='" & Trim(sErrorCode) & "' where exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine & _
                                          " UPDATE m_assysn_t set estateid='D' where ppid= '" & Me.TxtCartonNo.Text & "'" & vbNewLine & " update m_assysnD_t set estateid='D' where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "'  and sitem=(select max(sitem) from m_assysnD_t where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "')")
                                lblMessage.Text = "该产品已为不良品，请进行维修..."
                            End If
                        End If
                    Else
                        o_strSQL = New StringBuilder
                        o_strSQL.Append("UPDATE m_ppidlink_t SET usey='D',codeid='" & Trim(sErrorCode) & "' WHERE exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine)
                        o_strSQL.Append("UPDATE m_Assysn_t SET estateid='D' WHERE ppid= '" & sPrePpid & "'" & vbNewLine)
                        o_strSQL.Append("UPDATE m_assysnD_t set estateid='D' WHERE ppid= '" & sPrePpid & "' AND stationid= '" & WorkStantOption.vStandId & "'  and ")
                        o_strSQL.Append(" sitem=(SELECT MAX(sitem) FROM m_AssysnD_t WHERE ppid= '" & sPrePpid & "' and stationid= '" & WorkStantOption.vStandId & "')" & vbNewLine)
                        o_strSQL.Append("DELETE FROM m_ppidlink_t WHERE exppid='" & sPrePpid & "' AND stationid= '" & WorkStantOption.vStandId & "' AND ScanOrderid>1")
                        'Add insert to m_AssyTs_t by cq 20151222
                        o_strSQL.Append(" INSERT INTO m_AssyTs_t(ppid,pppid,itemid,stationid,partid,codeitem,codeid, issplit,userid,intime,")
                        o_strSQL.Append("ISok,Mtype,NgDate,Lineid,Resultid,Solution,MOID,Stateid,IsNew)  VALUES")
                        o_strSQL.Append("('" & sPrePpid & "',  '" & sPrePpid & "','1', '" & WorkStantOption.vStandId & "', '" & Me.TxtPartid.Text.Trim & "','" & sErrorCode.Substring(0, 2) & "',")
                        o_strSQL.Append("'" & sErrorCode & "','N','',getdate(),'N','2',getdate() ,'" & TxtLineId.Text.Trim() & "','','','" & TxtMoId.Text.Trim & "','D','Y') ")
                        Conn.ExecSql(o_strSQL.ToString)
                        lblMessage.Text = "该产品已为不良品，请进行维修..."
                        Conn.PubConnection.Close()
                    End If

                    '顯示掃描成功
                    LabResult.Text = "不良现象代码" & Space(3) & sErrorCode & Space(3) & "扫描成功"

                    Me.DGridBarCode.Rows(0).DefaultCellStyle.ForeColor = Color.FromArgb(188, 41, 49)
                    ''終止掃下一部件
                    WorkStantOption.vCurrentStandIndex = 1
                    TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                    TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                    'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                    LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                    TxtCartonNo.Text = ""
                    TxtRcode.Text = ""
                    TxtBarCode.Focus()
                    TxtBarCode.ReadOnly = False
                    Me.LblRcode.Visible = False
                    Me.TxtRcode.Visible = False
                Catch ex As Exception
                    TxtBarCode.ReadOnly = True
                    MessageBox.Show(ex.ToString)
                End Try

            End If
        End If
        'End If
    End Sub

    Private Sub TxtBarCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBarCode.KeyPress

        If e.KeyChar = Chr(13) Then
            StandScan()
        End If

    End Sub

    Private Sub ToolReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolReplace.Click
        Dim frm As New FrmMBarReplace(Me.TxtPartid.Text)
        frm.ShowDialog()
    End Sub

    Private Sub ToolOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolOption.Click

        If TxtMoId.Text = "" Then
            lblMessage.Text = "掃描資料未設置..."
            Exit Sub
        End If
        Dim FrmOpenLock As New FrmOptionSet(Me.LblCheckTime)
        FrmOpenLock.ShowDialog()
        FrmOpenLock = Nothing

    End Sub

#Region "批次扫描作业"
    Private Sub ToolLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolLot.Click

        If Me.TxtMoId.Text = "" Then
            lblMessage.Text = "请先设置扫描资料,才能进行批次扫描..."
            Exit Sub
        End If
        Dim FrmOpenLock As New FrmSetLock
        FrmOpenLock.ShowDialog()
        If CartonScanOption.CheckStr = True Then
            Dim frm As New FrmPartLotScan(Me.TxtMoId.Text, Me.TxtPartid.Text, Me.TxtSitName.Text)
            frm.ShowDialog()
        End If

    End Sub
#End Region

#Region "聲音播放"
    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        If (Me.chbMessage.Checked) Then
            Select Case PassOrNg
                Case 0
                    My.Computer.Audio.Play(My.Resources.Resource1.ok_zhcn, AudioPlayMode.Background)
                Case 1
                    My.Computer.Audio.Play(My.Resources.Resource1.fail_zhcn, AudioPlayMode.Background)
                Case 2
                    My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)

            End Select
        End If
        'Case 0  '
        'My.Computer.Audio.Play(My.Resources.Resource1.pass, AudioPlayMode.Background)
        '    Case 1
        'My.Computer.Audio.Play(My.Resources.Resource1.ERR, AudioPlayMode.Background)
        '    Case 2
        'My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)

    End Sub
#End Region

    Private Sub toolCa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCa.Click

        Dim frm As New FrmPartition
        frm.ShowDialog()

    End Sub

    Private Sub FrmWorkStantScan_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If RS232 Is Nothing OrElse Not RS232.IsOpen Then   '尚未打开

        Else
            RS232.Close()
            RS232 = Nothing
        End If

    End Sub

    Private Sub chkIsRepaired_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsRepaired.CheckedChanged
        If Me.chkIsRepaired.Checked = True Then
            m_strIsRepaired = "Y"
        Else
            m_strIsRepaired = "N"
        End If
    End Sub


#Region "工单状态设置"

    Private Sub toolMOStatusSetting_Click(sender As Object, e As EventArgs) Handles toolMOStatusSetting.Click
        Try
            If (String.IsNullOrEmpty(Me.TxtMoId.Text.Trim)) Then
                lblMessage.Text = "请设置工单！"
                Exit Sub
            End If

            Dim FrmMOStatusSetting As New FrmMOStatusSetting(Me.TxtMoId.Text.Trim, Me.TxtLineId.Text.Trim)
            FrmMOStatusSetting.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = "打开工单状态设置异常！"
        End Try
    End Sub

#End Region

End Class