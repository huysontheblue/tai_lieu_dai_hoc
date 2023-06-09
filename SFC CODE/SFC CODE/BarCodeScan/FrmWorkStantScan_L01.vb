#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports System.IO.Ports
Imports BarCodeScan.Data
Imports MainFrame
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports BarCodePrint
'Imports System.Windows.Forms.DataFormats
'Imports Seagull.BarTender.Print

#End Region

Public Class FrmWorkStantScan_L01

    '' Dim PreStaion As String = ""

    '#Region "重繪datagridview單元格焦點"
    '    Private Sub dgScanShow_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)

    '        e.PaintParts = DataGridViewPaintParts.Focus Xor e.PaintParts

    '    End Sub
    '#End Region

#Region "窗體變量"
    Dim WithEvents RS232 As SerialPort
    Private Delegate Sub ShowDelegate(ByVal strshow As String)
    'Dim Conn As New MainFrame.SysDataHandle.SysDataBaseClass
    Dim LocalData As New BarCodeScan.Data

    Private btApp As BarTender.Application
    Private btFormat As BarTender.Format
    Private m_printName As String
    '當前站的掃描順序
    Dim scanOrderId As String = ""
    Dim PreBarcode As String = "" ''记录最近扫描成功的条码
    Dim CompleteFlag As Int16 = 0     '装配完成标示
    Private m_strIsRepaired As String = "N"
    Dim EquipmentLifeCheck As String = "Y"

    '--自定义校验条码数量和内容
    Dim CheckCurIndex As Integer = 0
    Dim paraArrays As String()      '校验参数
    Dim CheckCurIndexChild1 As Integer = 0
    Dim paraArraysChild1 As String()      '子料号1校验参数
    Dim IsRepeatStyleC As String = "N"
    Dim ssStartindex As Integer     '流水起始位置 田玉琳 2017014
    Dim ssStartLength As Integer    '流水起始长度 田玉琳 2017014
    Dim strIsCharacters As String
    '不良率管控 hgd 2017-11-21
    Dim StationNgRate As Decimal = 0
    Dim sPreMainBarcode As String   '主条码
    Dim IsOnlineWeightFinish As Boolean = True '是否称重完成

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
            Case Keys.Space
                If WorkStantOption.IsPpidLineWeight = True AndAlso Me.IsOnlineWeightFinish = False AndAlso Not String.IsNullOrEmpty(txtOnLineWeight.Text) Then
                    PpidOnlineWeight()
                End If
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select
    End Sub


    Private Sub FrmBarScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SetGridHeadColumn()
        Me.TxtBarCode.Focus()
        'TxtCartonNo.Text = ""
        LabResult.Text = "扫描准备中..."
        lblMessage.Text = "请进行扫描设置..."

        '進入的時候隱藏一些控件
        LblRcode.Visible = False
        TxtRcode.Visible = False
        lbOnLineWeight.Visible = False
        txtOnLineWeight.Visible = False
        ToolUsename.Text = VbCommClass.VbCommClass.UseName
        '''''''''''''''''''' 
        'Me.LblType.Visible = False
        '''''''''''''''''''''''''''''''''''
        Me.chkIsRepaired.Checked = False

        'add by hgd 2018-04-10加入打印机
        SqlClassM.GetPrintersList(cboPrinterList)
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName '取得默认的打印
        cboPrinterList.Text = sDefaultPrinter


        btApp = New BarTender.Application
        btFormat = New BarTender.Format
    End Sub

#End Region

#Region "掃描設置/返回按鈕事件"

    Private Sub BnScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolScanSet.Click

        Dim CountReader As DataTable
        WorkStantOption.FormName = Me.Name

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
                    lblMSCustType.Text = String.Empty
                    lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "请设置扫描参数"
                    Exit Sub
                End If

                TxtBarCode.Focus()

                DGridBarCode.DataSource = Nothing
                LblMoqty.Text = WorkStantOption.MoidqtyStr
                TxtMoId.Text = WorkStantOption.MoidStr           ''工單
                TxtSitName.Text = WorkStantOption.vStandId.Trim() & "-" + WorkStantOption.vStandName.Trim 'WorkStantOption.vStandId & WorkStantOption.vStandName
                ''LabCust.Text = WorkStantOption.CustStr ''工單類型
                TxtPartid.Text = WorkStantOption.PartidStr ''料件編號
                '' LabMoCust.Text = WorkStantOption.MoCustStr ''客戶料號
                TxtLineId.Text = WorkStantOption.LineStr ''線別
                LblScanTime.Text = WorkStantOption.TimeStr
                TxtTTPackQty.Text = WorkStantOption.TTPackQty  'TT成品包装数量
                lblMSCustType.Text = String.Empty
                If WorkStantOption.IsMsCustType = "Y" Then
                    lblMSCustType.Text = WorkStantOption.MsCustCodeType
                End If

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


                If WorkStantOption.vRepeatStyle = "Y" Then
                    ReDim paraArrays(WorkStantOption.vRepeatPara.Split(",").Length - 1)
                    Dim i As Integer = 0
                    For i = 0 To paraArrays.Length - 1
                        paraArrays(i) = WorkStantOption.vRepeatPara.Split(",")(i).Replace("{", "").Replace("}", "").Trim
                    Next
                    '设置有检验时，流水段数据
                    GetCodeRuleIdSSSS(TxtPartid.Text)
                End If

                'add by cq 20180425, 子料号1的校验
                If WorkStantOption.vRepeatStyleChild1 = "Y" Then
                    ReDim paraArraysChild1(WorkStantOption.vRepeatParaChild1.Split(",").Length - 1)
                    Dim i As Integer = 0
                    For i = 0 To paraArraysChild1.Length - 1
                        paraArraysChild1(i) = WorkStantOption.vRepeatParaChild1.Split(",")(i).Replace("{", "").Replace("}", "").Trim
                    Next
                    '设置有检验时，流水段数据
                    GetCodeRuleIdSSSS(TxtPartid.Text)
                End If
                'add by hgd 2018-05-31 在线称重，重量上下限
                If WorkStantOption.IsPpidLineWeight = True Then
                    Me.lbOnLineWeight.Visible = True
                    Me.txtOnLineWeight.Visible = True
                    Me.txtOnLineWeight.Enabled = False
                Else
                    Me.lbOnLineWeight.Visible = False
                    Me.txtOnLineWeight.Visible = False
                End If
                '判断卡关信息，决定是否需要冶具寿命卡关
                Dim EquipmentList As String = ScanCommon.GetEquipmentNo(TxtMoId.Text, TxtLineId.Text)
                Dim strSQL As String = "execute CheckEquipmentLife '" & TxtPartid.Text & "', '" & EquipmentList & "'"
                Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)
                Dim dt_CheckEquipmentLife As DataTable = ds.Tables(0)
                EquipmentLifeCheck = dt_CheckEquipmentLife.Rows(0)(0).ToString()
                If EquipmentLifeCheck = "Y" Then
                    '读取之前的配置信息，显示冶具列表
                    If EquipmentList <> "" Then
                        '显示用户所选的冶具列表
                        dgvEquipPart.Show()
                        dgvEquipPart.Rows.Clear()
                        Dim dt_EquipmentList As DataTable = ds.Tables(1)
                        For Each row As DataRow In dt_EquipmentList.Rows
                            dgvEquipPart.Rows.Add(row("EquipmentNo").ToString(), row("ProcessParameters").ToString(), row("AlertCount").ToString(), row("ServiceCount").ToString(), row("RemainCount").ToString())
                        Next
                        'Else
                        '    dgvEquipPart.Hide()
                    End If
                    'Else
                    Me.dgvEquipPart.Rows.Clear()
                    '    dgvEquipPart.Hide()
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
                CountReader = DbOperateUtils.GetDataTable("select ppid from M_AssysnD_t where Moid='" & Me.TxtMoId.Text.Trim & "' and Teamid='" & Me.TxtLineId.Text.Trim & "' and Stationid='" & WorkStantOption.vStandId & "' and Estateid='F' order by Intime desc")
                If CountReader.Rows.Count > 0 Then
                    TxtCartonNo.Text = CountReader.Rows(0)("ppid").ToString
                    GetScanItem(Me.TxtCartonNo.Text)
                    LblBarName.ForeColor = Color.Gold
                    'Else
                    ''WorkStantOption.vStandId = 1
                    'CountReader.Close()
                    '' ControlState(False)
                End If
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
        End Try
    End Sub

    '保存验证数据，为验证唯一性
    Private Sub GetCodeRuleIdSSSS(partid As String)
        Dim strSQL As String = " EXEC GetCodeRuleIdSSSS '{0}' "
        strSQL = String.Format(strSQL, partid)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            ssStartindex = dt.Rows(0)(0).ToString
            ssStartLength = dt.Rows(0)(1).ToString
        End If
    End Sub

    Private Sub LoadPalletPaceQty()
        'and intime > '" & Trim(LblScanTime.Text) & "'
        'count(*) ==>  SUM(ISNULL(ppidqty,1)),cq20181016
        Dim read As DataTable = DbOperateUtils.GetDataTable("select SUM(ISNULL(ppidqty,1)) packcount from m_AssysnD_t where moid='" & TxtMoId.Text & "' and stationid='" & WorkStantOption.vStandId & " ' and estateid='Y'")
        If read.Rows.Count > 0 Then
            LabCartonQty.Text = read.Rows(0)!packcount.ToString
        End If
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
        WorkStantOption.IsOnlineWorkPrint = Nothing
    End Sub

#Region "獲取掃描記錄"
    Private Sub GetScanItem(ByVal Cartonid As String)
        Dim orderIndex As Integer = 0
        DGridBarCode.Rows.Clear()
        Dim Dt As DataTable
        Dt = DbOperateUtils.GetDataTable("select b.ismainbarcode,a.scanorderid,a.Exppid,a.ppid,b.ppartid,b.staorderid,b.tparttext,c.username,a.intime " &
                                         "from m_Ppidlink_t a  join m_RPartStationD_t b on  b.scanorderid=a.scanorderid and a.StaOrderid=b.staorderid " &
                                         " join m_users_t c on a.userid=c.userid where ppartid='" & WorkStantOption.PartidStr & "' and Exppid='" & Cartonid &
                                         "'  and b.staorderid='" & WorkStantOption.vStandIndex & "' and a.Usey='Y' and b.state='1' order by a.scanorderid")
        'While (Dt.Read())
        '    DGridBarCode.Rows.Add(Dt!ppartid, Dt!staorderid, Dt!Ppid, Dt!tparttext, Dt!username, Dt!intime)
        '    '獲取當前掃入的條碼
        '    'PreBarcode = Dt!Ppid.ToString
        '    PreBarcode = Dt!Ppid.ToString
        '    If Dt!scanorderid > orderIndex Then
        '        orderIndex = Dt!scanorderid
        '    End If
        'End While
        For iIndex As Integer = 0 To Dt.Rows.Count - 1
            DGridBarCode.Rows.Add(Dt.Rows(iIndex)!ppartid, Dt.Rows(iIndex)!staorderid,
                                  Dt.Rows(iIndex)!Ppid, Dt.Rows(iIndex)!tparttext,
                                  Dt.Rows(iIndex)!username, Dt.Rows(iIndex)!intime)
            PreBarcode = Dt.Rows(iIndex)!Ppid.ToString
            If Dt.Rows(iIndex)!scanorderid > orderIndex Then
                orderIndex = Dt.Rows(iIndex)!scanorderid
            End If
        Next

        DGridBarCode.AutoResizeColumns()

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

#End Region

    'Public Sub ShowText(ByVal strshow As String)
    '    If Me.TxtBarCode.InvokeRequired Then
    '        '   this.txtreceive.BeginInvoke(new ShowDelegate(Show), strshow);//这个也可以
    '        Me.TxtBarCode.Invoke(New ShowDelegate(AddressOf ShowText), strshow)


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

#Region "发送信息到端口"
    Private Sub SendFailMessage(ByVal SendMsg As String)
        If SendMsg = "" Then
            lblMessage.Text = "请输入读取或烧录的指令..."
            Exit Sub
        End If
        Try
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

#Region "EMC判定不良"
    '扫描不良代码
    Private Sub NGCodeScan()
        Dim sErrorCode As String
        Dim NgCode As String
        If InStr(TxtBarCode.Text, "'") Then
            TxtBarCode.Clear()
            Exit Sub
        End If
        NgCode = TxtBarCode.Text.ToString
        '不良现象代码
        If NgCode.Contains("MESNG#") Then
            sErrorCode = NgCode.Replace("MESNG#", "")
        Else
            sErrorCode = NgCode.Replace("SFCSNG#", "")
        End If

        TxtRcode.Text = sErrorCode
        '检查是否存在
        If CheckNGCodeExists() = False Then
            MessageBox.Show(TxtRcode.Text & "：不良代码不存在！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        LabResult.ForeColor = Color.Green
        lblMessage.ForeColor = Color.Green
        LabResult.Text = sErrorCode & Space(3) & "不良代码扫描成功，请继续扫描不良产品条码......"
        lblMessage.Text = "PASS"
        LblRcode.Visible = True
        TxtRcode.Visible = True
        TxtBarCode.Clear()
        TxtBarCode.Focus()

    End Sub




    '判定不良
    Private Sub JudgeNgScan()
        Try
            '检查数据
            If CheckNGData() = True Then

                DoSureNG()

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmWorkStantScan", "JudgeNgScan()", "SYS")
        End Try

    End Sub


    '检查不良代码是否存在
    Private Function CheckNGCodeExists() As Boolean
        Dim o_strSql As String
        Dim b As Boolean = False
        Dim item As Int16 = 0
        o_strSql = "SELECT codeid,ccname,cename,csortname,esortname,usey from m_Code_t  where codeid = '" & TxtRcode.Text.ToString & "' and usey='Y' "
        item = DbOperateUtils.GetRowsCount(o_strSql)
        b = IIf(item > 0, True, False)
        Return b
    End Function

    '检查数据
    Private Function CheckNGData() As Boolean
        Dim BarCode As String
        Dim o_strSql As String
        Dim Status As String = ""
        Dim dt As New DataTable
        If InStr(TxtBarCode.Text, "'") Then
            TxtBarCode.Clear()
            Return False
        End If


        If Me.TxtMoId.Text = "" Then
            MessageBox.Show("請先設置好掃描基本信息！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Return False
        End If ''
        If TxtBarCode.Text = "" Then
            MessageBox.Show("產品條碼不能為空！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PlaySimpleSound(1)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Return False
        End If

        If WorkStantOption.vCurrentStandIndex = 1 Then
            TxtCartonNo.Text = ""
        Else
            If TxtCartonNo.Text = "" Then
                lblMessage.Text = "主条码不能为空，请重新进行扫描设置..."
                PlaySimpleSound(1)
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Return False
            End If
        End If
        BarCode = Trim(TxtBarCode.Text).Replace(vbNewLine, "")
        'add by hgd 2017-08-28 验证样式
        If CheckStyle(BarCode) = False Then
            lblMessage.Text = "产品条码与扫描样式不符合..."
            PlaySimpleSound(1)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            Return False
        End If
        '检查该产品是否已判定过不良
        o_strSql = "select Stateid,ppid from m_AssyTs_t(nolock) where ppid='" & Me.TxtBarCode.Text.Trim & "'"
        dt = DbOperateUtils.GetDataTable(o_strSql)
        If dt.Rows.Count > 0 Then
            lblMessage.Text = "该产品条码已判定过不良,请勿重复判定!"
            PlaySimpleSound(1)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            Return False
        End If
        If IsLineConfirm() = False Then
            lblMessage.Text = "生产已回复当日柏拉图，不能判定不良!"
            PlaySimpleSound(1)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            Return False
        End If
        Return True
    End Function
    ''' <summary>
    ''' 生产若已回复了当日的柏拉图，不能再录入系统,以免数据产生变异
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsLineConfirm() As Boolean
        Dim strSQL As String = "select distinct 1 from [m_AssyTsProcss_t] where PartID = '{0}' and CONVERT(VARCHAR(10),CAST(NgDate AS datetime),111) = CONVERT(VARCHAR(10),CAST('{1}' AS datetime),111) AND LINEID='{2}' "
        strSQL = String.Format(strSQL, TxtPartid.Text.Trim, Now.ToShortDateString, TxtLineId.Text)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub DoSureNG()
        Dim strSQL As String = ""
        Dim dt As DataTable

        Dim vFlag As Boolean = False
        Dim sqlstr As StringBuilder = New StringBuilder
        Dim ItemID As Integer = GetAssyTsItemId(Me.TxtBarCode.Text.Trim)
        Dim NgDate As String = ""
        Dim sStaionId As String = WorkStantOption.vStandId.Trim()
        Try
            strSQL = "select 1 from m_ProduceRecordDay_t where moid='" & Me.TxtMoId.Text & "' and  StationID='" & sStaionId & "'"

            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                vFlag = True
            End If
            Dim NGQty As Integer = GetNgQtyStaionId(Me.TxtMoId.Text, sStaionId)
            Dim NGCodeType As String = GetNGCodeType()
            sqlstr.Append(" update m_SnSBarCode_t set usey='D' where SBarCode='" & Me.TxtBarCode.Text & "'")
            If vFlag = False Then
                sqlstr.Append(vbNewLine & "INSERT INTO m_ProduceRecordDay_t(Moid,StationID,Partid,ScanQty,NGqty,NGRate,Status,intime)values('" &
                          Me.TxtMoId.Text & "','" & sStaionId & "','" & TxtPartid.Text & "',0, 1,100,'Y',GETDATE())")
            Else
                sqlstr.Append(vbNewLine & " update m_ProduceRecordDay_t set NGqty=isnull(NGqty,0) + 1,NGRate= ROUND((NGqty+1)/((ScanQty+NGqty+1)*1.00),4)*100 ")
                sqlstr.Append(vbNewLine & String.Format(" where moid='{0}' and StationID='{1}' ", Me.TxtMoId.Text.ToString, sStaionId))
            End If
            '生成新的维修ID,防止重复
            sqlstr.Append(vbNewLine & " declare @MaintainID varchar(50) ")
            sqlstr.Append(vbNewLine & " select  @MaintainID = dbo.GetMainTainID('MAI',getdate()) ")

            sqlstr.Append(" insert into m_AssyTs_t(MaintainID,moid,Lineid,NgDate,ppid,Pppid,Itemid,Stationid,NGStationid,SmallSit,partid,Codeitem,Codeid,Stateid,IsNew,NgQty,Userid,Intime)values" & _
            " (@MaintainID,'" & TxtMoId.Text & "','" & TxtLineId.Text & "', getdate(),'" & Me.TxtBarCode.Text & "','" & Me.TxtPartid.Text & "'" & _
            "," & ItemID & ",'" & sStaionId.ToUpper & "','" & sStaionId.ToUpper & "','" & sStaionId.ToUpper & "','" & TxtPartid.Text & "','" &
             NGCodeType & "','" & Me.TxtRcode.Text.ToUpper() & "','D','Y',1,'" & SysMessageClass.UseId & "',GETDATE() ) ")

            DbOperateUtils.ExecSQL(sqlstr.ToString)
            LabResult.ForeColor = Color.Green
            lblMessage.ForeColor = Color.Green
            LabResult.Text = Me.TxtBarCode.Text & Space(3) & "判断不良成功，请继续......"
            lblMessage.Text = "PASS"

            TxtRcode.Text = ""
            '当不良率大于或等于允许的最大不良率，锁住界面，提示需要进行维修
            Dim _ngrate As Decimal = GetTolDayStationIdNgRate(Me.TxtMoId.Text, WorkStantOption.vStandId.Trim())
            If _ngrate > 0 AndAlso _ngrate >= Me.StationNgRate Then

                Dim _ErrMsg As String = "当前站点不良率为：" & _ngrate.ToString & "%,请先进行维修才能继续扫描....."
                WorkStantOption.ErrorStr = _ErrMsg
                SetMessage("Fail", _ErrMsg)
                WorkStantOption.BarCodeStr = TxtBarCode.Text
                WorkStantOption.vMainBarCode = TxtBarCode.Text
                ShowFrmScanErrPrompt()
                TxtBarCode.Text = ""
                TxtBarCode.Focus()
            Else
                Me.TxtBarCode.Text = ""
                LblRcode.Visible = False
                TxtRcode.Visible = False
                Me.TxtBarCode.Focus()
            End If


        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmWorkStantScan", "DoSureNG()", "SYS")
        End Try

    End Sub
    '获取不良大分类
    Private Function GetNGCodeType() As String
        Dim sCode As String = ""
        Dim strSQL As String = "select EsortName from m_Code_t where CodeId='{0}'"
        strSQL = String.Format(strSQL, Me.TxtRcode.Text)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            sCode = dt.Rows(0)!EsortName.ToString
        End If
        Return sCode
    End Function

    '获取项目允许的不良率
    Private Function GetItemNameNgRate(ByVal ItemName As String) As Decimal
        Dim dNgRate As Decimal = 0
        Dim strSQL As String = "SELECT NGRate FROM m_NGRateBaseSet_t where ItemName='{0}' and Usey='Y'"
        strSQL = String.Format(strSQL, ItemName)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            dNgRate = CDec(dt.Rows(0)!NGRate.ToString)
        End If
        Return dNgRate
    End Function

    '获取当前站点当天不良率
    Private Function GetTolDayStationIdNgRate(ByVal moid As String, ByVal stationId As String) As Decimal
        Dim dNgRate As Decimal = 0
        Dim strSQL As String = "SELECT NGRate FROM m_ProduceRecordDay_t where Moid='{0}' and StationID='{1}'  "
        strSQL = String.Format(strSQL, moid, stationId)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            dNgRate = CDec(dt.Rows(0)!NGRate.ToString)
        End If
        Return dNgRate
    End Function



    ''工单SN历史NG个数(ProTotNGQty)
    'Private Function GetNGQtyByPPID(ppid As String) As Integer
    '    Dim strSQL As String = "select 1 from m_AssyTs_t where ppid = '{0}'"
    '    strSQL = String.Format(strSQL, ppid)

    '    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

    '    Return dt.Rows.Count
    'End Function

    ' ''' <summary>
    ' ''' SN当前NG个数(ProNGQty) <>'P'
    ' ''' </summary>
    ' ''' <param name="ppid"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function GetProNGQtyByPPID(ppid As String) As Integer
    '    Dim strSQL As String = "select 1  from m_AssyTs_t where ppid = '{0}' and Stateid <>'P'"
    '    strSQL = String.Format(strSQL, ppid)

    '    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

    '    Return dt.Rows.Count
    'End Function


    ' ''' <summary>
    ' ''' 工站SN历史NG个数(TotNGQty) 带P
    ' ''' </summary>
    ' ''' <param name="ppid"></param>
    ' ''' <param name="stationId"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function GetNGQtyByPPIDStaionID(ppid As String, stationId As String) As Integer
    '    Dim strSQL As String = "select 1 from m_AssyTs_t where ppid = '{0}' and  Stationid = '{1}'"
    '    strSQL = String.Format(strSQL, ppid, stationId)

    '    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

    '    Return dt.Rows.Count
    'End Function

    ' ''' <summary>
    ' ''' 工站SN当前NG个数(NGQty)  <>'P'
    ' ''' </summary>
    ' ''' <param name="ppid"></param>
    ' ''' <param name="stationId"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Private Function GetProNGQtyByPPIDStaionID(ppid As String, stationId As String) As Integer
    '    Dim strSQL As String = "select 1 from m_AssyTs_t where ppid = '{0}' and  Stationid = '{1}' and Stateid <>'P'"
    '    strSQL = String.Format(strSQL, ppid, stationId)

    '    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

    '    Return dt.Rows.Count
    'End Function

    ''' <summary>
    ''' 获取不良个数
    ''' </summary>
    ''' <param name="moid">工单</param>
    ''' <param name="stationId">站点</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNgQtyStaionId(ByVal moid As String, ByVal stationId As String) As Integer
        Dim NGqty As Integer = 0
        Dim strSQL As String = "select ISNULL(NGqty,0) AS NGqty from m_ProduceRecordDay_t where Moid = '{0}' and  StationID = '{1}' "
        strSQL = String.Format(strSQL, moid, stationId)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If (dt.Rows.Count > 0) Then
            NGqty = CInt(dt.Rows(0)!NGqty.ToString)
        End If
        Return NGqty
    End Function



    ''' <summary>
    ''' 取得数据不良数据表Itemid
    ''' </summary>
    ''' <param name="ppid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAssyTsItemId(ppid As String) As Integer
        Dim strSQL As String = "select isnull(MAX(Itemid),0) +1  from m_AssyTs_t where Ppid='" & ppid & "'"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return Convert.ToInt16(dt.Rows(0)(0).ToString)
    End Function
#End Region
#Region "條碼掃描"

    Private Sub StandScan()
        Dim RecDr As DataTable = Nothing
        Dim Sqlstr As String
        Dim BarCode As String
        Dim sErrorCode As String
        Dim sPartId As String
        Dim iScanIndex As Integer
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

        '------------  add by cq20171110 start ---------------
        If Me.TxtBarCode.Text.Length <> LTrim(Me.TxtBarCode.Text).Length Then
            lblMessage.Text = "ERROR,左端有空格"
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        Else
            ' do nothing
        End If

        If Me.TxtBarCode.Text.Length <> RTrim(Me.TxtBarCode.Text).Length Then
            lblMessage.Text = "ERROR,右端有空格"
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        Else
            ' do nothing
        End If
        '----------- add by cq20171110 end  ------------------------

        'add by cq20171030
        BarCode = Trim(TxtBarCode.Text).Replace(vbNewLine, "")
        'add by hgd 2017-08-28 验证样式
        If CheckStyle(BarCode) = False Then Exit Sub

        '验证微软厂商来料
        If WorkStantOption.IsMsCustType = "Y" Then
            Dim strSQL As String = "select dbo.f_CheckMSCustCode( '" & Me.TxtBarCode.Text & "','" & WorkStantOption.MsCustCodeType & "')"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                Dim retval As String = dt.Rows(0)(0).ToString()
                If retval <> "OK" Then
                    WorkStantOption.BarCodeStr = RTrim(TxtBarCode.Text)
                    WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
                    WorkStantOption.ErrorStr = retval
                    LabResult.Text = Me.TxtBarCode.Text & Space(3) & "扫描失败..." + WorkStantOption.ErrorStr
                    lblMessage.Text = "FAIL..."
                    LabResult.ForeColor = Color.Gold
                    lblMessage.ForeColor = Color.Gold
                    Dim FrmError As New FrmScanErrPrompt
                    FrmError.ShowDialog()
                    If WorkStantOption.vDeserTionFlag = True Then
                        TxtBarCode.Clear()
                        WorkStantOption.vCurrentStandIndex = 1
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                    End If
                    TxtBarCode.Text = ""
                    Me.TxtBarCode.Focus()
                    Exit Sub
                End If
            End If

        End If

        Dim BarCodeOriginal As String = TxtBarCode.Text

        If EquipmentLifeCheck = "Y" Then
            Dim EquipmentList As String = ""
            Dim EquipmentListAlert As String = ""
            Dim EquipmentListstr As String = ScanCommon.GetEquipmentNo(TxtMoId.Text, TxtLineId.Text)
            If EquipmentListstr <> "" Then
                '扫描前取得最新值
                EquipmentListstr = EquipmentListstr.TrimEnd(",")
                Dim strSQL As String = "execute GetEquipmentListSelected '" & EquipmentListstr & "','1',''"
                Me.dgvEquipPart.Rows.Clear()
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                For Each row As DataRow In dt.Rows
                    dgvEquipPart.Rows.Add(row("EquipmentNo").ToString(), row("ProcessParameters").ToString(), row("AlertCount").ToString(), row("ServiceCount").ToString(), row("RemainCount").ToString())
                Next

                '每次扫描时，提前检测工装使用寿命是否到期！
                For i As Integer = 0 To dgvEquipPart.Rows.Count - 1
                    If dgvEquipPart.Rows(i).Cells("ServiceCount").Value = dgvEquipPart.Rows(i).Cells("AlertCount").Value Then
                        dgvEquipPart.Rows(i).Cells(1).Style.BackColor = Color.Red
                        EquipmentListAlert = EquipmentListAlert + dgvEquipPart.Rows(i).Cells("EquipmentNo").Value & ","
                    End If
                    If dgvEquipPart.Rows(i).Cells("RemainCount").Value <= 0 Then
                        dgvEquipPart.Rows(i).Cells(1).Style.BackColor = Color.Red
                        EquipmentList = EquipmentList + dgvEquipPart.Rows(i).Cells("EquipmentNo").Value & ","
                    End If

                Next

                '达到预警数量，只是提醒，还可以继续扫描
                If EquipmentListAlert <> "" Then
                    MessageUtils.ShowInformation(" 仅此提醒：冶具" & EquipmentListAlert.TrimEnd(",") & " 使用数量已达到预警数量！")
                End If

                If EquipmentList <> "" Then
                    MessageUtils.ShowInformation(EquipmentList.TrimEnd(",") & "工装使用寿命到期，请维护保养")
                    Exit Sub
                End If
            End If
        End If


        BarCode = RTrim(TxtBarCode.Text)
        sPartId = WorkStantOption.PartidStr
        iScanIndex = WorkStantOption.vCurrentStandIndex
        If iScanIndex = 1 Then
            '记录主条码
            sPreMainBarcode = BarCode
        End If
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
                        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                    End If
                    TxtBarCode.Text = ""
                    Me.TxtBarCode.Focus()
                    Exit Sub
                End If
            End If
        End If

        '------------------------------------注释 by hs ke 2014-5-26
        Try
            '马锋   2014-07-24  增加产品序号相同功能
            If (True) Then
                '@StaOrderid   int,          --工站序號  WorkStantOption.vStandIndex                                          
                '@ScanOrderid  int,          --掃描序號   WorkStantOption.vCurrentStandIndex                       
                '@preStaOrderid varchar(6),----前一站掃描站點 WorkStantOption.vPreStation                             
                '@maxindexqty  int,          --工站需要掃描序號總數  WorkStantOption.vStandMaxStaIndex    
                Sqlstr = " DECLARE @strmsgid varchar(1),@strmsgText varchar(300),@currqty int, @NewSBarCode nvarchar(100),@CompleteFlag int " & _
                         " execute [m_L01CheckPallMulletAssemblyPPID_P] '" & Trim(BarCode) & "', " & _
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

           RecDr = DbOperateUtils.GetDataTable(Sqlstr)
            If RecDr.Rows.Count > 0 Then
                Dim ReturnFlag As String = RecDr.Rows(0)(0).ToString

                Select Case ReturnFlag
                    Case "0", "1", "2", "3"
                        WorkStantOption.ErrorStr = RecDr.Rows(0)(1).ToString
                        PlaySimpleSound(1)
                        Exit Select
                    Case "4" ''---掃描成功
                        LabResult.ForeColor = Color.Lime
                        lblMessage.ForeColor = Color.Lime

                        If (WorkStantOption.vProductSame = "Y") Then
                            TxtBarCode.Text = RecDr.Rows(0)("NewBarCode").ToString
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
                            iScanIndex = 1
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

                        CompleteFlag = Val(RecDr.Rows(0).Item("CompleteFlag").ToString)    'CInt

                        TxtBarCode.Text = ""
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                        If WorkStantOption.vWritePCB = "Y" And CurrentSer = 1 Then
                            Process.Start(Application.StartupPath & "\HID_ControlApp.exe")
                            OpenSerialPort()
                            SendFailMessage("[FSN-" & TxtCartonNo.Text & "]")
                        End If

                        PlaySimpleSound(0)

                        '更新冶具数量
                        UpdateEquipmentCount(BarCodeOriginal)
                        '是否在线打印外箱
                        If WorkStantOption.IsOnlineWorkPrint = True AndAlso iScanIndex = WorkStantOption.vStandMaxStaIndex Then
                            OnlineWorkPrint(sPreMainBarcode, sPartId)
                        End If
                        '在线称重重量
                        If WorkStantOption.IsPpidLineWeight = True Then
                            LabResult.Text = LabResult.Text & ",请开始称重......"
                            Me.txtOnLineWeight.Enabled = True
                            TxtBarCode.Enabled = False
                            TxtCartonNo.Text = BarCode
                            Me.IsOnlineWeightFinish = False
                        End If
                        Exit Sub
                    Case "5"
                        WorkStantOption.ErrorStr = RecDr.Rows(0)(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "9" '增加条码扫描，工单重置功能
                        MessageUtils.ShowInformation(RecDr.Rows(0)(1))
                        Dim bflag As Boolean = SetNewMoidInfo(Trim(BarCode))
                        If bflag = True Then
                            LabResult.Text = BarCode & Space(3) & "切换工单成功,继续扫描！"
                            TxtBarCode.Text = ""
                            TxtBarCode.Clear()
                            TxtBarCode.Focus()
                        End If
                        Exit Sub
                    Case "6", "7"
                        LabCartonQty.Text = Val(LabCartonQty.Text) + 1     'cq 20200701, CInt(LabCartonQty.Text)==>val
                        PlaySimpleSound(0)
                        LabResult.ForeColor = Color.Lime
                        lblMessage.ForeColor = Color.Lime
                        LabResult.Text = BarCode & Space(3) & "扫描成功！"
                        lblMessage.Text = "PASS"
                        If WorkStantOption.vCurrentStandIndex = 1 Then
                            PreBarcode = TxtBarCode.Text
                            iScanIndex = 1
                        Else
                            PreBarcode = TxtCartonNo.Text
                        End If
                        Me.DGridBarCode.Rows.Insert(0, WorkStantOption.PartidStr, WorkStantOption.vStandIndex, TxtBarCode.Text, WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3), VbCommClass.VbCommClass.UseId, Now())
                        Dim CurrentSer As Integer = WorkStantOption.vCurrentStandIndex
                        WorkStantOption.vCurrentStandIndex = 1
                        LblBarName.ForeColor = Color.White
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
                        TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
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
                        CompleteFlag = Val(RecDr.Rows(0).Item("CompleteFlag").ToString)   'CInt
                        ''  ControlState(False)
                        TxtCartonNo.Text = ""
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                        If WorkStantOption.vWritePCB = "Y" And CurrentSer = 1 Then
                            Process.Start(Application.StartupPath & "\HID_ControlApp.exe")
                            OpenSerialPort()
                            SendFailMessage("[FSN-" & TxtCartonNo.Text & "]")
                        End If

                        '更新冶具数量
                        UpdateEquipmentCount(BarCodeOriginal)
                        '是否在线打印外箱
                        If WorkStantOption.IsOnlineWorkPrint = True AndAlso iScanIndex = WorkStantOption.vStandMaxStaIndex Then
                            OnlineWorkPrint(sPreMainBarcode, sPartId)
                        End If

                        '在线称重重量
                        If WorkStantOption.IsPpidLineWeight = True Then
                            LabResult.Text = LabResult.Text & ",请开始称重......"
                            Me.txtOnLineWeight.Enabled = True
                            TxtBarCode.Enabled = False
                            TxtCartonNo.Text = BarCode
                            Me.txtOnLineWeight.Focus()
                            Me.IsOnlineWeightFinish = False
                        End If
                        Exit Sub
                End Select

                CompleteFlag = Val(RecDr.Rows(0).Item("CompleteFlag").ToString)     'CInt

                'PlaySimpleSound(1)
                LabResult.ForeColor = Color.Gold
                lblMessage.ForeColor = Color.Gold

                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.TxtCartonNo.Text
                LabResult.Text = BarCode & Space(3) & "扫描失败..." + WorkStantOption.ErrorStr
                lblMessage.Text = "FAIL..."
                Dim FrmError As New FrmScanErrPrompt
                FrmError.ShowDialog()
                If WorkStantOption.vDeserTionFlag = True Then
                    TxtBarCode.Clear()
                    WorkStantOption.vCurrentStandIndex = 1
                    TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
                    TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
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
                Exit Sub
            End If
        Catch ex As Exception
            TxtBarCode.Text = ""
            TxtBarCode.Clear()
         
            PlaySimpleSound(1)
            MessageBox.Show("发生错误" & ex.Message, "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SysMessageClass.WriteErrLog(ex, Me.Name, "BtEnter_Click", "sys")
            Exit Sub
        End Try
    End Sub

    Private Function SetNewMoidInfo(ppid As String)
        Try
            Dim strSQL As String = " exec m_CheckPallMulletAssemblyGetNewMoidInfo '{0}','{1}'"

            strSQL = String.Format(strSQL, ppid, WorkStantOption.vStandId)

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                LabCartonQty.Text = dt.Rows(0)(2)
                LblMoqty.Text = dt.Rows(0)(1)
                TxtMoId.Text = dt.Rows(0)(0)
                Return True
            End If
            Return False
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, Me.Name, "SetNewMoidInfo", "sys")
            Return False
        End Try
    End Function

#End Region

    Private Sub PrintMainBarcode(ByVal BarCodeStr As String, ByVal partid As String, ByVal Stationid As String)

        Dim BarRprintHandle As New VbCommClass.VbCommClass
        Try
            BarRprintHandle.BarCodeToFile(BarCodeStr, partid, Stationid)
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, Me.Name, "PrintMainBarcode", "sys")
        End Try

    End Sub

    Private Sub TxtSnStyle2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSnStyle2.GotFocus, TxtSnStyle1.GotFocus
        TxtBarCode.Focus()
    End Sub

    '在线打印制程外箱（华为零售打印）
    Private Sub OnlineWorkPrint(ByVal ppid As String, ByVal partId As String)
        Try
            'Dim strSql As String

            'strSql = "select BatchNo,StationId from m_WorkStationScanBatch_t where CartonStatus='Y' and exists(select 1 from m_WorkStationScanBatchD_t where m_WorkStationScanBatchD_t.BatchNo=m_WorkStationScanBatch_t.BatchNo and m_WorkStationScanBatchD_t.ppid='" & ppid & "') and stationid='" & WorkStantOption.vStandId & "'"
                Dim printBarcode As New PrintBarcode
                printBarcode.btApp = btApp
                printBarcode.btFormat = btFormat
                printBarcode.PrintName = cboPrinterList.Text
            printBarcode.PrintL01WorkList(ppid, partId, WorkStantOption.vStandId)
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, Me.Name, "OnlineWorkPrint", "sys")
        End Try
    End Sub


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

    Private Sub TxtBarCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBarCode.KeyPress

        If e.KeyChar = Chr(13) Then
            '如果是EMC不良代码,或其他不良，则判定不良

            If TxtBarCode.Text.ToString.StartsWith("MESNG#") OrElse TxtBarCode.Text.ToString.StartsWith("SFCSNG#") Then

                '扫描不良代码
                NGCodeScan()
                '获取允许不良率（目前仅EMC管控不良率）
                Me.StationNgRate = GetItemNameNgRate("EMC")

            Else
                If Not String.IsNullOrEmpty(TxtRcode.Text.Trim) Then
                    '判定不良
                    JudgeNgScan()
                Else

                    If Me.StationNgRate > 0 Then
                        '当不良率大于或等于允许的最大不良率，锁住界面，提示需要进行维修
                        Dim _ngrate As Decimal = GetTolDayStationIdNgRate(Me.TxtMoId.Text, WorkStantOption.vStandId.Trim())
                        If _ngrate > 0 AndAlso _ngrate >= Me.StationNgRate Then

                            Dim _ErrMsg As String = "当前站点不良率为" & _ngrate.ToString & "%,请先进行维修才能继续扫描....."
                            WorkStantOption.ErrorStr = _ErrMsg
                            SetMessage("Fail", _ErrMsg)
                            WorkStantOption.BarCodeStr = TxtBarCode.Text
                            WorkStantOption.vMainBarCode = TxtBarCode.Text
                            ShowFrmScanErrPrompt()
                            TxtBarCode.Text = ""
                            TxtBarCode.Focus()
                            Exit Sub
                        End If
                    End If

                    'add by hgd 2018-06-04 防止在线称重，点击列印，列印时出现3列数值，其中有0的
                    If TxtBarCode.Text.Trim = "0" Then
                        TxtBarCode.Text = ""
                        Exit Sub
                    End If
                    '正常扫描
                    StandScan()
                End If
            End If
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

    Private Sub ToolEquipment_Click(sender As Object, e As EventArgs) Handles ToolEquipment.Click
        Try
            If Me.TxtMoId.Text = "" Then
                lblMessage.Text = "请先设置扫描资料,才能进行冶具设定..."
                Exit Sub
            End If

            If EquipmentLifeCheck = "Y" Then
                Dim FrmOpenLock As New FrmSetLock
                FrmNewShareSetForm.vStationType = "P"
                FrmOpenLock.ShowDialog()

                If CartonScanOption.CheckStr = True Then
                    Dim FrmEquipmentSet As New FrmNewEquipmentSetForm(TxtLineId.Text, TxtMoId.Text)
                    FrmEquipmentSet.Owner = Me
                    FrmEquipmentSet.ShowDialog()
                End If

                '显示用户所选的冶具列表
                Dim strSQL As String = ""
                Dim EquipmentList As String = ScanCommon.GetEquipmentNo(TxtMoId.Text, TxtLineId.Text)
                If EquipmentList <> "" Then
                    dgvEquipPart.Show()
                    EquipmentList = EquipmentList.TrimEnd(",")
                    strSQL = "execute GetEquipmentListSelected '" & EquipmentList & "','1',''"
                    Me.dgvEquipPart.Rows.Clear()
                    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                    For Each row As DataRow In dt.Rows
                        dgvEquipPart.Rows.Add(row("EquipmentNo").ToString(), row("ProcessParameters").ToString(), row("AlertCount").ToString(), row("ServiceCount").ToString(), row("RemainCount").ToString())
                    Next

                    dgvEquipPart.Columns(1).ReadOnly = True
                    dgvEquipPart.Columns(2).ReadOnly = True
                Else
                    'dgvEquipPart.Hide()
                End If

            Else
                lblMessage.Text = "此料号在料件工艺设定没有设定冶具寿命卡控..."
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

#Region "每次扫描成功，对应的冶具使用数量加1,余下数减1"

    Private Sub UpdateEquipmentCount(ByVal BarCodeString As String)
        Try
            '对应的冶具编号,卡控工冶具，且有配置工冶具
            If EquipmentLifeCheck = "Y" Then
                Dim strSQL As String = ""
                Dim EquipmentList As String = ScanCommon.GetEquipmentNo(TxtMoId.Text, TxtLineId.Text)
                If EquipmentList <> "" Then

                    EquipmentList = EquipmentList.TrimEnd(",")
                    strSQL = "execute UpdateEquipmentListCount '" & EquipmentList & "','" + BarCodeString + "'"
                    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                    Dim Qty As Integer = Val(dt.Rows(0)(0).ToString())

                    For i As Integer = 0 To dgvEquipPart.Rows.Count - 1
                        dgvEquipPart.Rows(i).Cells("ServiceCount").Value = dgvEquipPart.Rows(i).Cells("ServiceCount").Value + Qty
                        dgvEquipPart.Rows(i).Cells("RemainCount").Value = dgvEquipPart.Rows(i).Cells("RemainCount").Value - Qty
                    Next
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, Me.Name, "UpdateEquipmentCount", "sys")
        End Try
    End Sub

#End Region

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

    '双击复制工单和料件的内容,方面运维时复制粘贴Add By KyLinQiu 20170717
    Private Sub TxtMoId_DoubleClick(sender As Object, e As EventArgs) Handles TxtMoId.DoubleClick, TxtPartid.DoubleClick
        Try
            Dim LabText As Label = sender
            If LabText Is Nothing Then
                Exit Sub
            End If
            Clipboard.SetText(LabText.Text.Trim)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub toolPrint_Click(sender As Object, e As EventArgs) Handles toolPrint.Click
        If TxtMoId.Text = "" Then
            lblMessage.Text = "掃描資料未設置..."
            Exit Sub
        End If
        Dim frm As New FrmOnlineWorkPrint
        frm.PartId = TxtPartid.Text.Trim
        frm.StationId = WorkStantOption.vStandId
        frm.PrintName = Me.cboPrinterList.Text.Trim
        frm.ShowDialog()
    End Sub

    Private Sub ToolScanPrt_Click(sender As Object, e As EventArgs) Handles ToolScanPrt.Click
        If TxtMoId.Text = "" Then
            lblMessage.Text = "掃描資料未設置..."
            Exit Sub
        End If
        Dim frm As New FrmScanPrt
        frm.ShowDialog()
    End Sub

    Private Sub txtOnLineWeight_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtOnLineWeight.PreviewKeyDown

        If e.KeyValue = 13 Then

            PpidOnlineWeight()
        End If

    End Sub

#Region "方法"
    '条码验证样式--add by hgd 20170828
    Private Function CheckStyle(ByRef BarCode As String) As Boolean
        Try
            '********************************20170206 田玉琳 Start ****************************************************
            '扫描条码样式不能为空
            If TxtSnStyle1.Text.Trim.Length = 0 Then
                WorkStantOption.ErrorStr = "扫描条码样式不能为空！"
                SetMessage("Fail", "扫描条码样式不能为空！")
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
                ShowFrmScanErrPrompt()
                Me.TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Return False
            End If
            '********************************20170206 田玉琳 End ****************************************************

            '********************************20160615 田玉琳 Start ****************************************************
            '非系统打印条码要求验证样式
            ' 田玉琳 20161101 
            '系统条码也要验证样式（有子件处理）
            'Me.IsPrtSelf <> "Y" And
            If TxtSnStyle1.Text.Trim.Length <> 0 Then
                If BarCode.Trim.Length <> TxtSnStyle1.Text.Length Then
                    WorkStantOption.ErrorStr = "扫描条码长度不对"
                    SetMessage("Fail", "扫描条码长度不对")

                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
                    Me.TxtBarCode.Text = ""
                    ShowFrmScanErrPrompt()

                    Me.TxtBarCode.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If

                If TextHandle.verfyBarCodeStyle(TxtSnStyle1.Text, BarCode, TxtSnStyle2.Text) = False Then
                    WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                    SetMessage("FAIL", "條碼不符合標準樣式")
                    'PlaySimpleSound(1)
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
                    ShowFrmScanErrPrompt()
                    Me.TxtBarCode.Text = ""
                    Me.TxtBarCode.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If
            End If
            '********************************20160615 田玉琳 End ***************************************************

            '--------- 20160617 田玉琳 Start ---Change by hs ke 20160927 ------------
            '有子条码时，不对子条码验证，只对主条码验证 20170314 田玉琳
            '增加对验证条码流水和唯一性处理, mark ,cq20180425
            If WorkStantOption.vCurrentStandIndex = 1 And WorkStantOption.vRepeatStyle = "Y" Then
                If txt_tmpbarcode.Text = "" Then
                    txt_tmpbarcode.Text = Me.TxtBarCode.Text.Trim

                    SetMessage("PASS", BarCode & Space(3) & "扫描成品条码成功，请继续扫描校验条码！")

                    If paraArrays(CheckCurIndex).ToString.ToLower = "@ppid" Then
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                    Else
                        CheckCurIndex = 0
                        Dim styles() As String = paraArrays(CheckCurIndex).Split("|")
                        If styles(0) = "@ppid" Then
                            TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                            TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                        Else
                            TxtSnStyle1.Text = styles(0)
                            TxtSnStyle2.Text = styles(0)
                        End If
                    End If

                    Me.TxtBarCode.Text = ""
                    BarCode = ""  'add by cq20171030
                    TxtBarCode.Focus()
                    Return False
                Else
                    Dim styles() As String = paraArrays(CheckCurIndex).Split("|")
                    Dim str As String = styles(0)
                    If str = "@ppid" Then
                        str = txt_tmpbarcode.Text
                    End If

                    If BarCode.Length = str.Length AndAlso TextHandle.verfyBarCodeStyle(str, Me.TxtBarCode.Text, str) Then
                        If styles.Length > 1 Then
                            '要求验证条码流水号
                            If styles(1) = "10" Or styles(1) = "11" Then
                                If ssStartindex + ssStartLength <> txt_tmpbarcode.Text.Length Then
                                    SetFailContent(BarCode, String.Format("请检查料件打印参数料号[{0}]设置参数代码对应的参数值的正确性", TxtPartid.Text))
                                    Return False
                                End If
                                Dim ppidssss As String = txt_tmpbarcode.Text.Substring(ssStartindex, ssStartLength)
                                Dim checkssss As String = BarCode.Substring(str.IndexOf("*"), str.LastIndexOf("*") - str.IndexOf("*") + 1)
                                '流水不一致
                                If ppidssss <> checkssss Then
                                    SetFailContent(BarCode, String.Format("校验码{0}[{1}]流水[{2}]校验不成功...Fail,请重新验证", CheckCurIndex + 1, BarCode, checkssss))
                                    Return False
                                End If
                            End If
                            '要求验证唯一性 保存到数据库中
                            If styles(1) = "01" Or styles(1) = "11" Then
                                If CheckppidIsRepeat(BarCode) = False Then
                                    SetFailContent(BarCode, String.Format("校验码{0}[{1}]流水码重复扫描...Fail,请重新验证", CheckCurIndex + 1, BarCode))
                                    Return False
                                End If
                                '成功验证插入到表中
                                InsertAssysnCheck(BarCode, txt_tmpbarcode.Text)
                            End If
                            If styles(1) = "02" Then
                                '固定码 成功验证插入到表中
                                InsertAssysnCheckFix(BarCode, txt_tmpbarcode.Text)
                            End If
                        End If
                        SetMessage("PASS", "校验码" & CheckCurIndex + 1 & "{" & BarCode & "}校验成功，请继续扫描下一个校验条码！")
                        Me.TxtBarCode.Clear()
                        BarCode = "" 'add by cq 20171030
                        TxtBarCode.Focus()
                        If CheckCurIndex = paraArrays.Length - 1 Then
                            '扫描完成最后一个，样式返回第一个
                            TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                            TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                            BarCode = txt_tmpbarcode.Text
                            Me.TxtBarCode.Text = BarCode
                            txt_tmpbarcode.Text = ""
                            CheckCurIndex = 0
                            Return True
                        Else
                            CheckCurIndex = CheckCurIndex + 1
                            Dim NextStr As String = paraArrays(CheckCurIndex).Split("|")(0)
                            If NextStr = "@ppid" Then
                                NextStr = txt_tmpbarcode.Text
                            End If
                            TxtSnStyle1.Text = NextStr
                            TxtSnStyle2.Text = NextStr
                            Return False
                        End If
                    Else
                        SetFailContent(BarCode, "校验码" & CheckCurIndex + 1 & "{" & BarCode & "}校验不成功...Fail,请重新验证")
                        Return False
                    End If
                End If
                CheckCurIndex = CheckCurIndex + 1
            End If
            '---------------------------------cq 20171030 end  ---------------------------

            ''---------------------------------cq 20180425 start 校验子料号1  ---------------------------
            If WorkStantOption.vCurrentStandIndex = 2 AndAlso WorkStantOption.vRepeatStyleChild1 = "Y" Then
                If Not CheckChildBarcode(BarCode) Then
                    Return False
                End If
            End If
            ''--------------------  add child 1 校验 end ------------------------------
            Return True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, Me.Name, "CheckStyle", "sys")
        End Try
    End Function


    ''' <summary>
    ''' 校验子件1
    ''' </summary>
    ''' <param name="BarCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckChildBarcode(ByVal BarCode As String) As Boolean
        Try
            If txt_tmpbarcode.Text = "" Then
                txt_tmpbarcode.Text = Me.TxtBarCode.Text.Trim

                SetMessage("PASS", BarCode & Space(3) & "扫描成品条码成功，请继续扫描校验条码！")

                If paraArraysChild1(CheckCurIndexChild1).ToString.ToLower = "@ppid" Then
                    TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                    TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                Else
                    CheckCurIndexChild1 = 0
                    Dim styles() As String = paraArraysChild1(CheckCurIndexChild1).Split("|")
                    If styles(0) = "@ppid" Then
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                    Else
                        TxtSnStyle1.Text = styles(0)
                        TxtSnStyle2.Text = styles(0)
                    End If
                End If

                Me.TxtBarCode.Text = ""
                BarCode = ""  'add by cq20171030
                TxtBarCode.Focus()
                Return False
            Else
                Dim styles() As String = paraArraysChild1(CheckCurIndexChild1).Split("|")
                Dim str As String = styles(0)
                If str = "@ppid" Then
                    str = txt_tmpbarcode.Text
                End If

                If BarCode.Length = str.Length AndAlso TextHandle.verfyBarCodeStyle(str, Me.TxtBarCode.Text, str) Then
                    If styles.Length > 1 Then
                        '要求验证条码流水号
                        If styles(1) = "10" Or styles(1) = "11" Then
                            If ssStartindex + ssStartLength <> txt_tmpbarcode.Text.Length Then
                                SetFailContent(BarCode, String.Format("请检查料件打印参数料号[{0}]设置参数代码对应的参数值的正确性", TxtPartid.Text))
                                Return False
                            End If
                            Dim ppidssss As String = txt_tmpbarcode.Text.Substring(ssStartindex, ssStartLength)
                            Dim checkssss As String = BarCode.Substring(str.IndexOf("*"), str.LastIndexOf("*") - str.IndexOf("*") + 1)
                            '流水不一致
                            If ppidssss <> checkssss Then
                                SetFailContent(BarCode, String.Format("校验码{0}[{1}]流水[{2}]校验不成功...Fail,请重新验证", CheckCurIndexChild1 + 1, BarCode, checkssss))
                                Return False
                            End If
                        End If
                        '要求验证唯一性 保存到数据库中
                        If styles(1) = "01" Or styles(1) = "11" Then
                            If CheckppidIsRepeat(BarCode) = False Then
                                SetFailContent(BarCode, String.Format("校验码{0}[{1}]流水码重复扫描...Fail,请重新验证", CheckCurIndexChild1 + 1, BarCode))
                                Return False
                            End If
                            '成功验证插入到表中
                            InsertAssysnCheck(BarCode, txt_tmpbarcode.Text)
                        End If

                        If styles(1) = "02" Then
                            '固定码 成功验证插入到表中
                            InsertAssysnCheckFix(BarCode, txt_tmpbarcode.Text)
                        End If
                    End If
                    SetMessage("PASS", "校验码" & CheckCurIndexChild1 + 1 & "{" & BarCode & "}校验成功，请继续扫描下一个校验条码！")
                    Me.TxtBarCode.Clear()
                    BarCode = "" 'add by cq 20171030
                    TxtBarCode.Focus()
                    If CheckCurIndexChild1 = paraArraysChild1.Length - 1 Then
                        '扫描完成最后一个，样式返回第一个
                        TxtSnStyle1.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 1)
                        BarCode = txt_tmpbarcode.Text
                        Me.TxtBarCode.Text = BarCode
                        txt_tmpbarcode.Text = ""
                        CheckCurIndexChild1 = 0
                        Return True
                    Else
                        CheckCurIndexChild1 = CheckCurIndexChild1 + 1
                        Dim NextStr As String = paraArraysChild1(CheckCurIndexChild1).Split("|")(0)
                        If NextStr = "@ppid" Then
                            NextStr = txt_tmpbarcode.Text
                        End If
                        TxtSnStyle1.Text = NextStr
                        TxtSnStyle2.Text = NextStr
                        Return False
                    End If
                Else
                    SetFailContent(BarCode, "校验码" & CheckCurIndexChild1 + 1 & "{" & BarCode & "}校验不成功...Fail,请重新验证")
                    Return False
                End If
            End If
            CheckCurIndexChild1 = CheckCurIndexChild1 + 1
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, Me.Name, "CheckChildBarcode", "sys")
        End Try
    End Function

    '保存验证数据，为验证唯一性
    Private Sub InsertAssysnCheck(ppid As String, exppid As String)
        Dim strSQL As String = " EXEC m_InsertAssysnCheck_P '{0}','{1}','{2}','{3}','{4}','{5}' "
        strSQL = String.Format(strSQL, ppid, exppid, TxtMoId.Text, TxtLineId.Text, My.Computer.Name, VbCommClass.VbCommClass.UseId)

        DbOperateUtils.ExecSQL(strSQL)
    End Sub

    '固定码 保存验证数据，cq 20180508
    Private Sub InsertAssysnCheckFix(ppid As String, exppid As String)
        Dim strSQL As String = " EXEC m_InsertAssysnCheckFix_P '{0}','{1}','{2}','{3}','{4}','{5}' "
        strSQL = String.Format(strSQL, ppid, exppid, TxtMoId.Text, TxtLineId.Text, My.Computer.Name, VbCommClass.VbCommClass.UseId)

        DbOperateUtils.ExecSQL(strSQL)
    End Sub

    '检查是否存在重复数据
    Private Function CheckppidIsRepeat(ppid As String) As Boolean
        Dim strSQL As String = "select 1 as cnt from m_AssysnCheck_t where ppid = '{0}' and SCANY = 'Y'"
        strSQL = String.Format(strSQL, ppid)
        Dim count As Integer = DbOperateUtils.GetRowsCount(strSQL)
        '存在数据返回错误
        If count > 0 Then
            Return False
        End If
        Return True
    End Function

    '设置错误信息内容
    Private Sub SetFailContent(BarCode As String, errMsg As String)
        WorkStantOption.BarCodeStr = BarCode
        WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
        WorkStantOption.ErrorStr = errMsg
        SetMessage("FAIL", errMsg)
        ShowFrmScanErrPrompt()
        If WorkStantOption.vDeserTionFlag = True Then
            TxtBarCode.Clear()
            WorkStantOption.vCurrentStandIndex = 1
            TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
            TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
            LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
        End If
        TxtBarCode.Text = ""
        Me.TxtBarCode.Focus()
    End Sub

    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            LabResult.Text = "FAIL"
            lblMessage.Text = message
            LabResult.ForeColor = Color.Crimson
            lblMessage.ForeColor = Color.Crimson
        Else
            LabResult.Text = "PASS"
            lblMessage.Text = message
            LabResult.ForeColor = Color.FromArgb(0, 192, 0)
            lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub

    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt
        FrmError.ShowDialog()
    End Sub


    '扫描重量
    Private Sub ScanWeight(ByVal Weight As String)
        'Dim o_strSql As New StringBuilder

        'Try
        '    o_strSql.Append("update m_OnlineWeightPpid_t set Weight='" & Weight & "'  where ppid='" & Me.TxtCartonNo.Text & "' and moid='" & Me.TxtMoId.Text & "'  and stationid='" & WorkStantOption.vStandId & "' ")

        '    DbOperateUtils.ExecSQL(o_strSql.ToString)
        'Catch ex As Exception
        '    Throw ex
        'End Try

        Dim o_strSql As New StringBuilder

        Try
            o_strSql.Append("if not exists(select 1 from m_OnlineWeightPpid_t  where ppid='" & Me.txt_tmpbarcode.Text & "' and moid='" & Me.TxtMoId.Text & "'  and stationid='" & WorkStantOption.vStandId & "'  )")
            o_strSql.Append(" INSERT INTO m_OnlineWeightPpid_t (ppid,stationid,Moid,Weight,Userid,Intime)")
            o_strSql.Append(" VALUES('" & Me.TxtCartonNo.Text & "','" & WorkStantOption.vStandId & "' ,'" & Me.TxtMoId.Text & "','" & Weight & "','" & SysMessageClass.UseId.Trim & "',getdate())")
            DbOperateUtils.ExecSQL(o_strSql.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '在线称重
    Private Sub PpidOnlineWeight()
        Dim strWeight As String
        If String.IsNullOrEmpty(txtOnLineWeight.Text.Trim) Then
            Exit Sub
        End If
        strWeight = Me.txtOnLineWeight.Text.Trim
        If Not IsNumeric(strWeight) Then
            MessageBox.Show("重量格式不正确！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PlaySimpleSound(1)
            txtOnLineWeight.Text = ""
            Me.txtOnLineWeight.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If
        If CDec(strWeight) < CDec(WorkStantOption.PpidUpLimitWeight) OrElse CDec(strWeight) > CDec(WorkStantOption.PpidLowLimitWeight) Then
            Dim _ErrMsg As String = "重量" & strWeight & ",超出标准重量,该产品重量上下限为(" & WorkStantOption.PpidUpLimitWeight & "-" & WorkStantOption.PpidLowLimitWeight & ")....."
            WorkStantOption.ErrorStr = _ErrMsg
            SetMessage("Fail", _ErrMsg)
            WorkStantOption.BarCodeStr = strWeight
            WorkStantOption.vMainBarCode = strWeight
            Me.txtOnLineWeight.Text = ""
            ShowFrmScanErrPrompt()
            Me.txtOnLineWeight.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        ScanWeight(strWeight)
        Me.txtOnLineWeight.Text = ""
        TxtBarCode.Enabled = True
        txtOnLineWeight.Enabled = False
        LabResult.ForeColor = Color.Lime
        lblMessage.ForeColor = Color.Lime
        TxtBarCode.Focus()
        TxtCartonNo.Text = ""
        LabResult.Text = "重量" & strWeight & ",称重成功,请继续扫描产品！"
        lblMessage.Text = "PASS"
        Me.IsOnlineWeightFinish = True
    End Sub

#End Region


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        If TxtMoId.Text = "" Then
            lblMessage.Text = "掃描資料未設置..."
            Exit Sub
        End If
        Dim frm As New FrmOnlineWorkPrintMAC
        frm.PartId = TxtPartid.Text.Trim
        frm.StationId = WorkStantOption.vStandId
        frm.PrintName = Me.cboPrinterList.Text.Trim
        frm.ShowDialog()
    End Sub
End Class
