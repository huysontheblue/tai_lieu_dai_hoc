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
Imports System.Management
'Imports System.Windows.Forms.DataFormats
'Imports Seagull.BarTender.Print
'--Update :  田玉琳 2020/02/19
'--更新内容：A.打印按钮整合在一个LIST中
'--          B.扫描正常主条码和子条码声音,子件扫描完成才提示

#End Region

Public Class FrmWorkStantScan


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
	Dim UsbBarcode As String = "" '记录从USB读取的Barcode信息

    '--自定义校验条码数量和内容
    Dim CheckCurIndex As Integer = 0
    Dim paraArrays As String()      '校验参数
    Dim CheckCurIndexChild1 As Integer = 0
    Dim paraArraysChild1 As String()      '子料号1校验参数
    Dim IsRepeatStyleC As String = "N"
    Dim ssStartindex As Integer     '流水起始位置 田玉琳 2017014
    Dim ssStartLength As Integer    '流水起始长度 田玉琳 2017014
    Dim strIsCharacters As String
    Dim KEY As String '是否启用禁止手动输入 周可海 20200407
    '不良率管控 hgd 2017-11-21
    Dim StationNgRate As Decimal = 0
    Dim sPreMainBarcode As String   '主条码
    Dim IsOnlineWeightFinish As Boolean = True '是否称重完成
    Dim IsWifi6Print As Boolean = False '是否称重完成
    Dim ScanNumber As Integer = 1           '扫描次数
    Public scanSetting As New ScanSetting
    Public m_strProductSNStyle As String = ""
    Private bPGConfirm As Boolean = False
    Private PGConfirmWeight As String = ""
    Private ppidLinkList As ArrayList = New ArrayList
    '20200623 增加显示批次号 邓炯
    Dim strLotid As String
    Dim Sleeptime As Integer
    Dim Sleeptime1 As Integer

    Public m_iWeightMode As Int16
    Public Enum WeightMode
        PpidWeight
        BarePPidWeight
    End Enum

#End Region

#Region "窗體事件"

    '关闭
    Private Sub FrmInCarton_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        DisposeData()
        WorkStantOption.CustIdString = Nothing
        WorkStantOption.MoidStr = Nothing
        WorkStantOption.LengthStr = Nothing
        WorkStantOption.DateCheck = Nothing
    End Sub

    '共通KEYDOWN
    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                BnScanSet_Click(sender, e)
            Case Keys.F2
                'toolCa_Click(sender, e)
            Case Keys.Space
                If WorkStantOption.IsPpidLineWeight = True AndAlso Me.IsOnlineWeightFinish = False AndAlso Not String.IsNullOrEmpty(txtOnLineWeight.Text) Then
                    '  PpidOnlineWeight()
                    Dim strWeight As String
                    strWeight = Me.txtOnLineWeight.Text.Trim

                    If CheckWeight() = False Then
                        Exit Sub
                    End If
                End If
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select
    End Sub

    '初期化
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
        TxtTTPackQty.Visible = False
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

        Try
            btApp = New BarTender.Application
            btFormat = New BarTender.Format
        Catch ex As Exception

        End Try

    End Sub

    '打印
    Private Sub menuPrint_Click(sender As Object, e As EventArgs) Handles menuPrint.Click
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

    Private Sub menuPrintMac_Click(sender As Object, e As EventArgs) Handles menuPrintMac.Click
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

    Private Sub menuRepalace_Click(sender As Object, e As EventArgs) Handles menuRepalace.Click
        Dim frm As New FrmMBarReplace(Me.TxtPartid.Text)
        frm.ShowDialog()
    End Sub

    Private Sub menuScanPrint_Click(sender As Object, e As EventArgs) Handles menuScanPrint.Click
        If TxtMoId.Text = "" Then
            lblMessage.Text = "掃描資料未設置..."
            Exit Sub
        End If
        Dim frm As New FrmScanPrt
        frm.ShowDialog()
    End Sub


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


    Private Sub txtOnLineWeight_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtOnLineWeight.PreviewKeyDown
        If e.KeyValue = 13 Then
            Dim strWeight As String
            strWeight = Me.txtOnLineWeight.Text.Trim
            '电子称和手输入统一
            SetWeightDown(strWeight)
        End If
    End Sub

    ''' <summary>
    ''' 电子称和手输入统一
    ''' </summary>
    ''' <param name="strWeight"></param>
    ''' <remarks></remarks>
    Private Sub SetWeightDown(strWeight As String, Optional model As String = "")
        bPGConfirm = False
        PGConfirmWeight = strWeight

        If CheckWeight(model) = False Then
            Exit Sub
        Else
            SetCBg(LabResult, Color.Lime)
            SetCBg(lblMessage, Color.Lime)
            SetCValues(TxtBarCode, "")
            SetCEnabled(TxtBarCode, True)
            SetCFocus(TxtBarCode)
            If bPGConfirm = True Then
                txtOnLineWeight.Text = PGConfirmWeight
                SetCValues(LabResult, "重量：" + CDec(PGConfirmWeight).ToString + ",产品超重异常,异常确认OK, 请继续扫描产品条码")
                SetCValues(lblMessage, "PASS,称重成功")
            Else
                SetCValues(LabResult, "重量：" + CDec(strWeight).ToString + ",校验OK, 请继续扫描产品条码")
                SetCValues(lblMessage, "PASS,称重成功")
            End If
        End If
    End Sub


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
            'scanSetting.MoidStr = ""
            'TxtMoId.Text = String.Empty
            'TxtPartid.Text = String.Empty
            'TxtPartid.Text = String.Empty
            'TxtLineId.Text = String.Empty
            'lblMessage.ForeColor = Color.Red
            'lblMessage.Text = "设置扫描参数异常,请重新设置"
            'Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#{1}", Me.TxtMoId.Text.Trim, ex.ToString))
            'SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "BnScanSet_Click", "sys")
        End Try

    End Sub

    '录入不良代码(R)
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

    '参数设置
    Private Sub ToolOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolOption.Click

        If TxtMoId.Text = "" Then
            lblMessage.Text = "掃描資料未設置..."
            Exit Sub
        End If
        Dim FrmOpenLock As New FrmOptionSet(Me.LblCheckTime)
        FrmOpenLock.ShowDialog()
        FrmOpenLock = Nothing

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

                ppidLinkList.Clear()
                DGridBarCode.DataSource = Nothing
                LblMoqty.Text = WorkStantOption.MoidqtyStr
                TxtMoId.Text = WorkStantOption.MoidStr           ''工單
                TxtSitName.Text = WorkStantOption.vStandId.Trim() & "-" + WorkStantOption.vStandName.Trim 'WorkStantOption.vStandId & WorkStantOption.vStandName
                ''LabCust.Text = WorkStantOption.CustStr ''工單類型
                TxtPartid.Text = WorkStantOption.PartidStr ''料件編號
                '20200407新增H01禁止手动输入
                Dim SQL As String = " SELECT TOP 1 * FROM m_PartInput_t WHERE PartId = '" + TxtPartid.Text + "'"
                Dim dr As DataTable = DbOperateUtils.GetDataTable(SQL)
                If dr.Rows.Count = 1 Then
                    KEY = "Y"
                Else
                    KEY = "N"
                End If
                '20220921
                Dim printBarcode As New PrintBarcode
                IsWifi6Print = printBarcode.CheckWiFi6Print(TxtPartid.Text)

                '' LabMoCust.Text = WorkStantOption.MoCustStr ''客戶料號
                TxtLineId.Text = WorkStantOption.LineStr ''線別
                LblScanTime.Text = WorkStantOption.TimeStr
                ' TxtTTPackQty.Text = WorkStantOption.TTPackQty  'TT成品包装数量 不需要 20181227 邓炯

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
                'cq20200221
                m_strProductSNStyle = TxtSnStyle1.Text
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

                WorkStantOption.IsBarePpidLineWeight = False

                If Not String.IsNullOrEmpty(WorkStantOption.BarePpidLowLimitWeight) Then
                    m_iWeightMode = WeightMode.BarePPidWeight
                    WorkStantOption.IsBarePpidLineWeight = True
                    lbOnLineWeight.Text = "裸机产品重量:"
                ElseIf Not String.IsNullOrEmpty(WorkStantOption.PpidLowLimitWeight) Then
                    m_iWeightMode = WeightMode.PpidWeight
                End If

                'add by hgd 2018-05-31 在线称重，重量上下限
                If WorkStantOption.IsPpidLineWeight = True OrElse (WorkStantOption.IsBarePpidLineWeight = True) Then
                    Me.lbOnLineWeight.Visible = True
                    Me.txtOnLineWeight.Visible = True
                    Me.txtOnLineWeight.Enabled = True
                    LabResult.Text = "请设置电子秤通讯端口"
                    lblMessage.Text = "先称重后扫描"
                    lbWeightFW.Visible = True
                    Select Case m_iWeightMode
                        Case WeightMode.PpidWeight
                            lbWeightFW.Text = WorkStantOption.PpidLowLimitWeight.ToString + "-" + WorkStantOption.PpidUpLimitWeight.ToString
                        Case WeightMode.BarePPidWeight
                            lbWeightFW.Text = WorkStantOption.BarePpidLowLimitWeight.ToString + "-" + WorkStantOption.BarePpidUpLimitWeight.ToString
                    End Select
                    TxtBarCode.Enabled = False
                    txtOnLineWeight.Enabled = True
                    txtOnLineWeight.Focus()
                Else
                    Me.lbOnLineWeight.Visible = False
                    Me.txtOnLineWeight.Visible = False
                    Me.IsOnlineWeightFinish = False
                    TxtBarCode.Enabled = True
                    txtOnLineWeight.Enabled = False
                    lbWeightFW.Visible = False
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

                ''獲取未裝滿箱號
                CountReader = DbOperateUtils.GetDataTable("select ppid from M_AssysnD_t where Moid='" & Me.TxtMoId.Text.Trim & "' and Teamid='" & Me.TxtLineId.Text.Trim & "' and Stationid='" & WorkStantOption.vStandId & "' and Estateid='F' order by Intime desc")
                If CountReader.Rows.Count > 0 Then
                    TxtCartonNo.Text = CountReader.Rows(0)("ppid").ToString
                    GetScanItem(Me.TxtCartonNo.Text)
                    LblBarName.ForeColor = Color.Gold
                End If
            End If

            strLotid = GetLot(WorkStantOption.MoidStr)

            WorkStantOption.CheckStr = False
            LoadPalletPaceQty()
        Catch ex As Exception
            TxtMoId.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtLineId.Text = String.Empty
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "设置扫描参数异常,请重新设置"
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#CartonNo:{1}#{2}", Me.TxtMoId.Text.Trim, TxtCartonNo.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, Me.Name, "GetScanItem", "sys")
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

        TxtRcode.Text = TxtRcode.Text + sErrorCode + ";"
        '检查是否存在
        If CheckNGCodeExists() = False Then
            MessageBox.Show(TxtRcode.Text & "：不良代码不存在！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        LabResult.ForeColor = Color.Green
        lblMessage.ForeColor = Color.Green
        LabResult.Text = sErrorCode & Space(3) & "不良代码扫描成功，请继续扫描不良代码或产品条码......"
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
        Dim eCode = TxtBarCode.Text

        Dim sErrorCode As String = eCode.Substring(eCode.IndexOf("#") + 1)
        o_strSql = "SELECT codeid,ccname,cename,csortname,esortname,usey from m_Code_t  where codeid = '" & sErrorCode & "' and usey='Y' "
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
        'Dim ItemID As Integer = GetAssyTsItemId(Me.TxtBarCode.Text.Trim)
        Dim ItemID As Integer = 1
        Dim NgDate As String = ""
        Dim o_ErrCodeArr As String()
        Dim itemCode As String = String.Empty
        Dim sStaionId As String = WorkStantOption.vStandId.Trim()
        Try
            strSQL = "select 1 from m_ProduceRecordDay_t where moid='" & Me.TxtMoId.Text & "' and  StationID='" & sStaionId & "'"

            dt = DbOperateUtils.GetDataTable(strSQL)
            If dt.Rows.Count > 0 Then
                vFlag = True
            End If
            Dim NGQty As Integer = GetNgQtyStaionId(Me.TxtMoId.Text, sStaionId)
            Dim NGCodeType As String
            'Dim NGCodeType As String = GetNGCodeType()
            'GetNGCodeTypeEsortName
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

            Dim o_Item As Integer = 1

            o_ErrCodeArr = TxtRcode.Text.Split(";")

            For Each errorCode As String In o_ErrCodeArr
                NGCodeType = GetNGCodeTypeEsortName(errorCode)

                'add by hgd 20200326 相同不良现象不重复统计
                If String.IsNullOrEmpty(itemCode) Then
                    itemCode = errorCode
                Else
                    If itemCode = errorCode Then
                        Continue For
                    End If
                End If
                'MODIFY BY HGD 20200326增加支持多个EerrorCode
                If NGCodeType <> "" Then
                    If o_Item = 1 Then
                        sqlstr.Append(" insert into m_AssyTs_t(MaintainID,moid,Lineid,NgDate,ppid,Pppid,Itemid,Stationid,NGStationid,SmallSit,partid,Codeitem,Codeid,Stateid,IsNew,NgQty,Userid,Intime)values" & _
                        " (@MaintainID,'" & TxtMoId.Text & "','" & TxtLineId.Text & "', getdate(),'" & Me.TxtBarCode.Text & "','" & Me.TxtPartid.Text & "'" & _
                        "," & ItemID & ",'" & sStaionId.ToUpper & "','" & sStaionId.ToUpper & "','" & sStaionId.ToUpper & "','" & TxtPartid.Text & "','" &
                        NGCodeType & "','" & errorCode.ToUpper() & "','D','Y',1,'" & SysMessageClass.UseId & "',GETDATE() ) ")
                        o_Item = o_Item + 1
                    End If

                    sqlstr.Append(" INSERT INTO m_AssyTsDetail_t(Ppid,Itemid,MaintainID,Codeitem,Codeid,Stateid,Stationid,Remark,Userid,Intime)")
                    sqlstr.Append("VALUES('" & Me.TxtBarCode.Text & "'," & ItemID & ",@MaintainID,'" & NGCodeType & "','" & errorCode.ToUpper() & "','D','" & sStaionId.ToUpper & "',N'制程站不良','" & SysMessageClass.UseId & "',GETDATE()) ")

                End If

                itemCode = errorCode
            Next


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
    '获取不良大分类
    Private Function GetNGCodeTypeEsortName(ByVal errorcode As String) As String
        Dim sCode As String = ""
        Dim strSQL As String = "select EsortName from m_Code_t where CodeId='{0}'"
        strSQL = String.Format(strSQL, errorcode)

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
        '**************周可海 修改 20190909***********************Start 
        '可支持扫描多个条码拼接 
        If WorkStantOption.IsScanN = "Y" And ScanNumber <> WorkStantOption.ScanNumber Then
            ScanNumber = ScanNumber + 1
            Exit Sub
        Else
            ScanNumber = 1
        End If

        If TxtBarCode.Text = "" Then
            MessageBox.Show("產品條碼不能為空！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PlaySimpleSound(1)
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If
        '扫MAC 地址带出SN
        Dim sql As String
        sql = "select top 1 * from Wifi6_sn_mac where  REPLACE(MAC, ':', '')='" & TxtBarCode.Text & "'"
        Dim dt1 As DataTable = DbOperateUtils.GetDataTable(sql)
        If dt1.Rows.Count > 0 Then
            TxtBarCode.Text = dt1.Rows(0)("SN")
        End If
        If WorkStantOption.vCurrentStandIndex = 1 Then
            TxtCartonNo.Text = ""
        Else
            If TxtCartonNo.Text = "" Then
                lblMessage.Text = "主条码不能为空，请重新进行扫描设置..."
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

        Sqlstr = "DECLARE @RTVALUE varchar(70),@RTMSG varchar(70)  EXECUTE m_NewCheckPPIDMo_P '" & Trim(BarCode) & "','" & WorkStantOption.PartidStr & "', '" & Trim(TxtMoId.Text) & "',@RTVALUE output ,@RTMSG output  SELECT @RTVALUE  st1,@RTMSG st2 "
        RecDr = DbOperateUtils.GetDataTable(Sqlstr)
        If RecDr.Rows.Count > 0 Then
            Dim ReturnFlag As String = RecDr.Rows(0)(0).ToString
            Select Case ReturnFlag
                Case "0", "1", "2", "3"
                    If MsgBox("前製程工單與當前工單不一致，是否强制過站?", vbYesNo, "Công lệnh không đồng nhất, không thể tiếp tục quét?") <> vbYes Then
                        TxtBarCode.Text = ""
                        Me.TxtBarCode.Focus()
                        Exit Sub
                    End If
                    Exit Select
            End Select
        End If

        'add by hgd 2017-08-28 验证样式
        If CheckStyle(BarCode) = False Then Exit Sub

        If WorkStantOption.IsPpidLineWeight = True Or WorkStantOption.IsBarePpidLineWeight = True And TxtCartonNo.Text = "" Then '检查称重
            If CheckWeight() = False Then Exit Sub

            If CheckPPidIsPgConfirm(Trim(TxtBarCode.Text)) = False Then Exit Sub
        End If

        '是否LINK
        If WorkStantOption.IsCheckLink = "Y" Then
            If CheckGetPPidLink(Trim(TxtBarCode.Text)) = False Then Exit Sub
        End If

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
                        'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
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
                        'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
                        LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
                    End If
                    TxtBarCode.Text = ""
                    Me.TxtBarCode.Focus()
                    Exit Sub
                End If
            End If
        End If

        '------------------------------------注释 测试结果判断 2020-03-18
        Sqlstr = " DECLARE @RTVALUE varchar(70),@RTMSG varchar(70)  EXECUTE m_NewCheckTestStationResult_P '" & Trim(BarCode) & "','" & WorkStantOption.PartidStr & "', '" & WorkStantOption.vStandId & "',@RTVALUE output ,@RTMSG output  SELECT @RTVALUE  st1,@RTMSG st2 "
        RecDr = DbOperateUtils.GetDataTable(Sqlstr)
        If RecDr.Rows.Count > 0 Then
            Dim ReturnFlag As String = RecDr.Rows(0)(0).ToString

            Select Case ReturnFlag
                Case "0", "1", "2", "3"
                    WorkStantOption.ErrorStr = RecDr.Rows(0)(1).ToString
                    PlaySimpleSound(1)
                    LabResult.ForeColor = Color.Gold
                    lblMessage.ForeColor = Color.Gold
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.TxtCartonNo.Text
                    LabResult.Text = BarCode & Space(3) & "扫描失败..." + WorkStantOption.ErrorStr
                    lblMessage.Text = "FAIL..."
                    Dim FrmError As New FrmScanErrPrompt
                    FrmError.ShowDialog()
                    TxtBarCode.Text = ""
                    Me.TxtBarCode.Focus()
                    Exit Sub
                    Exit Select
            End Select
        End If
        '------------------------------------注释 by hs ke 2014-5-26

        Try
            '马锋   2014-07-24  增加产品序号相同功能
            If (True) Then
                Sqlstr = " DECLARE @strmsgid varchar(1),@strmsgText nvarchar(100),@currqty int, @NewSBarCode nvarchar(100),@CompleteFlag int " &
                         " execute [m_CheckPallMulletAssemblyPPID_P] '" & Trim(BarCode) & "', " &
                         " '" & Trim(TxtMoId.Text) & "','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," &
                         "'" & WorkStantOption.PartidStr & "','" & WorkStantOption.vmReplaceArray(WorkStantOption.vCurrentStandIndex, 1).Split("|")(1).ToString & "','" & TxtCartonNo.Text & "'," &
                         " '" & WorkStantOption.vStandId & "' ,'" & WorkStantOption.vStandIndex & "','" & WorkStantOption.vCurrentStandIndex & "'," &
                         " '" & WorkStantOption.vPreStation & "','" & WorkStantOption.vStandMaxStaIndex & "','" & LblCheckTime.Text & "', '" & WorkStantOption.vProductSame & "',  '" & m_strIsRepaired & "'," &
                         "@strmsgid output,@strmsgText output,@currqty output,@NewSBarCode output,@CompleteFlag output  " &
                        " select @strmsgid,@strmsgText,isnull(@currqty,1),@NewSBarCode AS NewBarCode, ISNULL(@CompleteFlag,0) AS CompleteFlag"
            Else
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''2011/12/21 m_CheckPPID_01PNew20102011---->[m_CheckAssemblyPPID_P]
                Sqlstr = "DECLARE @strmsgid varchar(1),@strmsgText nvarchar(100),@currqty int execute [m_CheckAssemblyPPID_P] '" & Trim(BarCode) & "', " &
                         " '" & Trim(TxtMoId.Text) & "','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," &
                         "'" & WorkStantOption.PartidStr & "','" & WorkStantOption.vmReplaceArray(WorkStantOption.vCurrentStandIndex, 1).Split("|")(1).ToString & "','" & TxtCartonNo.Text & "'," &
                         " '" & WorkStantOption.vStandId & "' ,'" & WorkStantOption.vStandIndex & "','" & WorkStantOption.vCurrentStandIndex & "'," &
                         " '" & WorkStantOption.vPreStation & "','" & WorkStantOption.vStandMaxStaIndex & "','" & LblCheckTime.Text & "', " &
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

                        '组合扫描完成提示
                        If WorkStantOption.vCurrentStandIndex < WorkStantOption.vStandMaxStaIndex Then
                            LabResult.Text = BarCode & Space(3) & "该条码扫描成功,请继续扫描下一个绑定条码！"
                            lblMessage.Text = "PASS"
                        Else
                            LabResult.Text = BarCode & Space(3) & "扫描成功！"
                            lblMessage.Text = "PASS"
                        End If

                        If (CompleteFlag = 1) Then
                            'PlaySimpleSound(0)
                            Me.DGridBarCode.DataSource = Nothing
                            Me.DGridBarCode.Rows.Clear()
                        End If

                        Me.DGridBarCode.Rows.Insert(0, WorkStantOption.PartidStr, WorkStantOption.vStandIndex, TxtBarCode.Text, txtOnLineWeight.Text, WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3), VbCommClass.VbCommClass.UseId, Now(), strLotid)
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

                        CompleteFlag = CInt(RecDr.Rows(0).Item("CompleteFlag").ToString)

                        TxtBarCode.Text = ""
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
                    Case "6", "7", "8"
                        LabCartonQty.Text = Val(LabCartonQty.Text) + Val(RecDr.Rows(0)(2))   'CInt(LabCartonQty.Text) + 1
                        PlaySimpleSound(0)

                        If ReturnFlag = "8" Then
                            '进入品质抽检
                            LabResult.Text = BarCode & Space(3) & "扫描成功！" + "该产品已进入品质抽检Check In,请与正常产品区别放置！"
                            LabResult.ForeColor = Color.Yellow
                            lblMessage.ForeColor = Color.Yellow
                        Else
                            LabResult.ForeColor = Color.Lime
                            lblMessage.ForeColor = Color.Lime
                            LabResult.Text = BarCode & Space(3) & "扫描成功！"
                        End If

                        lblMessage.Text = "PASS"
                        If WorkStantOption.vCurrentStandIndex = 1 Then
                            PreBarcode = TxtBarCode.Text
                            iScanIndex = 1
                        Else
                            PreBarcode = TxtCartonNo.Text
                        End If
                        Me.DGridBarCode.Rows.Insert(0, WorkStantOption.PartidStr, WorkStantOption.vStandIndex, TxtBarCode.Text, WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3), VbCommClass.VbCommClass.UseId, Now(), strLotid)
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
                        CompleteFlag = CInt(RecDr.Rows(0).Item("CompleteFlag").ToString)

                        '在线称重重量
                        If WorkStantOption.IsPpidLineWeight = True Then
                            PpidOnlineWeight(BarCode)
                        ElseIf m_iWeightMode = WeightMode.BarePPidWeight Then
                            BarePpidOnlineWeight(BarCode)
                        End If
                        bPGConfirm = False
                        ''  ControlState(False)
                        ppidLinkList.Clear()
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

                        Exit Sub
                End Select

                CompleteFlag = CInt(RecDr.Rows(0).Item("CompleteFlag").ToString)

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
                'Conn.PubConnection.Close()
                Exit Sub
            End If
        Catch ex As Exception
            TxtBarCode.Text = ""
            TxtBarCode.Clear()
            PlaySimpleSound(1)
            MessageBox.Show("发生错误" & ex.Message.ToString(), "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtBarCode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, Me.Name, "BtEnter_Click", "sys")
            Exit Sub
        End Try
    End Sub

    Private Function SetNewMoidInfo(ppid As String)
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
    End Function

#End Region

    Private Sub toolNGBarcodeLink_Click(sender As Object, e As EventArgs) Handles toolNGBarcodeLink.Click

        Try
            If Me.TxtMoId.Text = "" Then
                lblMessage.Text = "请先设置扫描资料,才能进行不良品关联..."
                Exit Sub
            End If

            ' If String.IsNullOrEmpty(m_strProductSNStyle) Then
            'SetScanCodeStyle("S")
            If String.IsNullOrEmpty(m_strProductSNStyle) Then
                lblMessage.Text = "获取产品条码样式失败，请检查..."
                Exit Sub
            End If
            ' End If

            Dim frmNGBarLink As New FrmNGBarLink(TxtLineId.Text, TxtMoId.Text, TxtPartid.Text, m_strProductSNStyle, WorkStantOption.vStandId.Trim())
            frmNGBarLink.Owner = Me
            frmNGBarLink.StartPosition = FormStartPosition.CenterScreen
            frmNGBarLink.ShowDialog()

        Catch ex As Exception
        End Try

    End Sub

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

    '在线打印制程外箱（华为零售打印）
    Private Sub OnlineWorkPrint(ByVal ppid As String, ByVal partId As String)
        Try
            Dim strSql As String

            strSql = "select BatchNo,StationId from m_WorkStationScanBatch_t where CartonStatus='Y' and exists(select 1 from m_WorkStationScanBatchD_t where m_WorkStationScanBatchD_t.BatchNo=m_WorkStationScanBatch_t.BatchNo and m_WorkStationScanBatchD_t.ppid='" & ppid & "') and stationid='" & WorkStantOption.vStandId & "'"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                Dim printBarcode As New PrintBarcode
                printBarcode.btApp = btApp
                printBarcode.btFormat = btFormat
                printBarcode.PrintName = cboPrinterList.Text
                '20220922
                If IsWifi6Print = True Then
                    printBarcode.PrintOnlineWifiList(dt.Rows(0)!BatchNo.ToString, partId, dt.Rows(0)!StationId.ToString)
                Else
                    printBarcode.PrintOnlineWorkList(dt.Rows(0)!BatchNo.ToString, partId, dt.Rows(0)!StationId.ToString)
                End If
                'printBarcode.PrintOnlineWorkList(dt.Rows(0)!BatchNo.ToString, partId, dt.Rows(0)!StationId.ToString)
            End If
        Catch ex As Exception

        End Try
    End Sub

    '录入不良代码处理
    Private Sub TxtRcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRcode.KeyPress
        Dim sqlstr As String = "", o_strSQL As StringBuilder = Nothing
        Dim DRErrorcode As DataTable = Nothing
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
                DRErrorcode = DbOperateUtils.GetDataTable(sqlstr)
                If DRErrorcode.Rows.Count = 0 Then
                    Me.lblMessage.Text = "不良现象代码不存在..."
                    'MessageBox.Show("不良代碼不存在！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TxtRcode.Clear()
                    Exit Sub
                End If

                Try
                    Dim IsAllowN As String = ""
                    Dim NGcount As Byte = 0
                    DRErrorcode = DbOperateUtils.GetDataTable("SELECT IsAllowNG,IsAllowNGQTY from dbo.m_RPartStationD_t where ppartid='" & TxtPartid.Text & "' and stationid='" & WorkStantOption.vStandId & "' and state=1 ")
                    If DRErrorcode.Rows.Count > 0 Then
                        IsAllowN = DRErrorcode.Rows(0)!IsAllowNG.ToString
                        NGcount = DRErrorcode.Rows(0)!IsAllowNGQTY
                    End If

                    ''update ppidlink set codeid&&usey
                    If PreBarcode = "" Then
                        Me.lblMessage.Text = "主条码为空，不允许进行不良代码录入..."
                    End If
                    sPrePpid = PreBarcode
                    If IsAllowN = "Y" Then
                        If NGcount = 0 Then
                            DbOperateUtils.ExecSQL("UPDATE m_ppidlink_t SET usey='E',codeid='" & Trim(sErrorCode) & "' where exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine &
                                            " UPDATE m_assysn_t set estateid='E' where ppid= '" & Me.TxtCartonNo.Text & "'" & vbNewLine & " update m_assysnD_t set estateid='E',Codeid='" & sErrorCode & "' where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "'  and sitem=(select max(sitem) from m_assysnD_t where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "')")
                            lblMessage.Text = "该产品已作废，不允许维修..."
                        Else
                            Dim reaptCount As Byte = 0
                            DRErrorcode = DbOperateUtils.GetDataTable("select count(*) ngcount from m_AssyTs_t where Pppid='" & Me.TxtCartonNo.Text & "'")
                            If DRErrorcode.Rows.Count > 0 Then
                                reaptCount = DRErrorcode.Rows(0)!ngcount
                            End If
                            If NGcount = reaptCount + 1 Then
                                DbOperateUtils.ExecSQL("UPDATE m_ppidlink_t set usey='E',codeid='" & Trim(sErrorCode) & "' where exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine &
                                           " UPDATE m_assysn_t set estateid='E' where ppid= '" & Me.TxtCartonNo.Text & "'" & vbNewLine & " update m_assysnD_t set estateid='E' where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "'  and sitem=(select max(sitem) from m_assysnD_t where ppid= '" & Me.TxtCartonNo.Text & "' and stationid= '" & WorkStantOption.vStandId & "')")
                                lblMessage.Text = "该产品已作废，不允许维修..."
                            Else
                                DbOperateUtils.ExecSQL("UPDATE m_ppidlink_t set usey='D',codeid='" & Trim(sErrorCode) & "' where exppid='" & sPrePpid & "' and staorderid= '" & WorkStantOption.vStandIndex & "' and usey='Y' " & vbNewLine &
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
                        DbOperateUtils.ExecSQL(o_strSQL.ToString)
                        lblMessage.Text = "该产品已为不良品，请进行维修..."
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
    Private _dt As DateTime = DateTime.Now
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
        Else
            If KEY = "Y" Then
                ''禁止用键盘手动输入
                Dim tempDt As DateTime = DateTime.Now
                Dim ts As TimeSpan = tempDt.Subtract(_dt)
                If (ts.Milliseconds > 50) Then
                    TxtBarCode.Text = ""
                End If
                _dt = tempDt
            End If
        End If
    End Sub


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

#Region "每次扫描成功，对应的冶具使用数量加1,余下数减1"

    Private Sub UpdateEquipmentCount(ByVal BarCodeString As String)

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


    End Sub

#End Region

#Region "方法"
    '条码验证样式--add by hgd 20170828
    Private Function CheckStyle(ByRef BarCode As String) As Boolean

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
                TxtBarCode.MaxLength = 1000
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
    End Function


    ''' <summary>
    ''' 校验子件1
    ''' </summary>
    ''' <param name="BarCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckChildBarcode(ByVal BarCode As String) As Boolean

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
            SetCBg(LabResult, Color.Crimson)
            SetCBg(lblMessage, Color.Crimson)
            SetCValues(LabResult, "FAIL")
            SetCValues(lblMessage, message)
            'LabResult.Text = "FAIL"
            'lblMessage.Text = message
            'LabResult.ForeColor = Color.Crimson
            'lblMessage.ForeColor = Color.Crimson
        Else
            SetCBg(LabResult, Color.FromArgb(0, 192, 0))
            SetCBg(lblMessage, Color.FromArgb(0, 192, 0))
            SetCValues(LabResult, "PASS")
            SetCValues(lblMessage, message)
            'LabResult.Text = "PASS"
            'lblMessage.Text = message
            'LabResult.ForeColor = Color.FromArgb(0, 192, 0)
            'lblMessage.ForeColor = Color.FromArgb(0, 192, 0)
        End If
    End Sub

    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt
        FrmError.ShowDialog()
    End Sub

    '扫描重量
    Private Sub ScanWeight(ByVal barcode As String, ByVal Weight As String)

        Dim o_strSql As New StringBuilder

        Try
            Select Case m_iWeightMode
                Case WeightMode.PpidWeight
                    o_strSql.Append("if not exists(select 1 from m_OnlineWeightPpid_t  where ppid='" & barcode & "' and moid='" & Me.TxtMoId.Text & "'  and stationid='" & WorkStantOption.vStandId & "'  )")
                    o_strSql.Append("BEGIN INSERT INTO m_OnlineWeightPpid_t (ppid,stationid,Moid,Weight,Userid,Intime)")
                    o_strSql.Append(" VALUES('" & barcode & "','" & WorkStantOption.vStandId & "' ,'" & Me.TxtMoId.Text & "','" & Weight & "','" & SysMessageClass.UseId.Trim & "',getdate()) END")
                    o_strSql.Append(" ELSE BEGIN  UPDATE m_OnlineWeightPpid_t SET Weight='" & Weight & "' WHERE PPID='" & barcode & "' and moid='" & Me.TxtMoId.Text & "'  and stationid='" & WorkStantOption.vStandId & "' END ")

                Case WeightMode.BarePPidWeight
                    o_strSql.Append("if not exists(select 1 from m_OnlineWeightBarePpid_t  where ppid='" & barcode & "' and moid='" & Me.TxtMoId.Text & "'  and stationid='" & WorkStantOption.vStandId & "'  )")
                    o_strSql.Append("BEGIN INSERT INTO m_OnlineWeightBarePpid_t (ppid,stationid,Moid,Weight,Userid,Intime)")
                    o_strSql.Append(" VALUES('" & barcode & "','" & WorkStantOption.vStandId & "' ,'" & Me.TxtMoId.Text & "','" & Weight & "','" & SysMessageClass.UseId.Trim & "',getdate()) END")
                    o_strSql.Append(" ELSE BEGIN  UPDATE m_OnlineWeightBarePpid_t SET Weight='" & Weight & "' WHERE PPID='" & barcode & "' and moid='" & Me.TxtMoId.Text & "'  and stationid='" & WorkStantOption.vStandId & "' END ")

            End Select
            DbOperateUtils.ExecSQL(o_strSql.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function CheckWeight(Optional model As String = "") As Boolean
        Dim strWeight As String
        strWeight = Me.txtOnLineWeight.Text.Trim

        If strWeight = "" Then
            LabResult.Text = "重量不能为空！"
            lblMessage.Text = "请将产品放在电子秤上先称重后扫描"
            txtOnLineWeight.Text = ""
            Me.txtOnLineWeight.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtOnLineWeight.Text.Trim) Then
            MessageBox.Show("重量格式不正确！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LabResult.Text = "重量格式不正确！"
            txtOnLineWeight.Text = ""
            Me.txtOnLineWeight.Focus()
            Return False
        End If

        If Not IsNumeric(strWeight) Then
            MessageBox.Show("重量格式不正确！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LabResult.Text = "重量格式不正确！"
            txtOnLineWeight.Text = ""
            Me.txtOnLineWeight.Focus()
            PlaySimpleSound(1)
            Return False
        End If

        Select Case m_iWeightMode
            Case WeightMode.PpidWeight
                If CDec(WorkStantOption.PpidUpLimitWeight) < CDec(WorkStantOption.PpidLowLimitWeight) Then
                    Dim dec As Decimal = WorkStantOption.PpidUpLimitWeight
                    WorkStantOption.PpidUpLimitWeight = WorkStantOption.PpidLowLimitWeight
                    WorkStantOption.PpidLowLimitWeight = dec
                End If
                If CDec(strWeight) < CDec(WorkStantOption.PpidLowLimitWeight) Or CDec(strWeight) > CDec(WorkStantOption.PpidUpLimitWeight) Then
                    Dim _ErrMsg As String = "重量" & strWeight & ",超出标准重量,该产品重量上下限为(" & WorkStantOption.PpidLowLimitWeight & "-" & WorkStantOption.PpidUpLimitWeight & ")....."

                    WorkStantOption.ErrorStr = _ErrMsg

                    ScanPpidWeight(strWeight)

                    If bPGConfirm = False Then
                        If model = "2" Then
                            SetCBg(LabResult, Color.Crimson)
                            SetCBg(lblMessage, Color.Crimson)
                            SetCValues(LabResult, _ErrMsg)
                            SetCValues(lblMessage, "FAIL")
                            SetCEnabled(TxtBarCode, False)
                            SetCValues(txtOnLineWeight, "")
                            SetCFocus(txtOnLineWeight)
                            Return False
                        Else
                            WorkStantOption.BarCodeStr = strWeight
                            WorkStantOption.vMainBarCode = strWeight
                            'Me.TxtBarCode.Text = ""
                            SetMessage("Fail", _ErrMsg)
                            Me.txtOnLineWeight.Text = ""
                            ' ShowFrmScanErrPrompt()     'mark by cq20200519
                            Me.txtOnLineWeight.Focus()
                            PlaySimpleSound(1)
                            Return False
                        End If
                    End If

                End If
            Case WeightMode.BarePPidWeight
                If CDec(WorkStantOption.BarePpidUpLimitWeight) < CDec(WorkStantOption.BarePpidLowLimitWeight) Then
                    Dim dec As Decimal = WorkStantOption.BarePpidUpLimitWeight
                    WorkStantOption.BarePpidUpLimitWeight = WorkStantOption.PpidLowLimitWeight
                    WorkStantOption.PpidLowLimitWeight = dec
                End If
                If CDec(strWeight) < CDec(WorkStantOption.BarePpidLowLimitWeight) Or CDec(strWeight) > CDec(WorkStantOption.BarePpidUpLimitWeight) Then
                    Dim _ErrMsg As String = "重量" & strWeight & ",超出标准重量,该产品重量上下限为(" & WorkStantOption.BarePpidLowLimitWeight & "-" & WorkStantOption.BarePpidUpLimitWeight & ")....."

                    WorkStantOption.ErrorStr = _ErrMsg

                    ScanPpidWeight(strWeight)

                    If bPGConfirm = False Then
                        If model = "2" Then
                            SetCBg(LabResult, Color.Crimson)
                            SetCBg(lblMessage, Color.Crimson)
                            SetCValues(LabResult, _ErrMsg)
                            SetCValues(lblMessage, "FAIL")
                            SetCEnabled(TxtBarCode, False)
                            SetCValues(txtOnLineWeight, "")
                            SetCFocus(txtOnLineWeight)
                            Return False
                        Else
                            WorkStantOption.BarCodeStr = strWeight
                            WorkStantOption.vMainBarCode = strWeight
                            'Me.TxtBarCode.Text = ""
                            SetMessage("Fail", _ErrMsg)
                            Me.txtOnLineWeight.Text = ""
                            'ShowFrmScanErrPrompt()    'mark by cq20200519
                            Me.txtOnLineWeight.Focus()
                            PlaySimpleSound(1)
                            Return False
                        End If
                    End If

                End If
        End Select
        Return True
    End Function

    ''' <summary>
    ''' ppid link确认扫描
    ''' 增加人员 田玉琳 20200525
    ''' </summary>
    ''' <param name="ppid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckGetPPidLink(ppid As String) As Boolean
        If ppidLinkList.Contains(ppid) Then
            Dim errMsg As String = "產品條碼:{0}已掃描,請確認!"
            errMsg = String.Format(errMsg, ppid)
            WorkStantOption.ErrorStr = errMsg
            SetMessage("Fail", errMsg)

            WorkStantOption.BarCodeStr = ppid
            WorkStantOption.vMainBarCode = ppid
            ShowFrmScanErrPrompt()
            PlaySimpleSound(1)
            Return False
        End If
        '增加到LIST
        ppidLinkList.Add(ppid)

        Return True
    End Function

    Private Function CheckPPidIsPgConfirm(ppid As String) As Boolean
        Dim strSQL As String = ""
        strSQL = " declare @flag varchar(10)  EXEC m_SearchPPidIsPgConfirm '{0}','{1}','{2}','{3}','{4}',@flag out  select @flag"
        strSQL = String.Format(strSQL, TxtBarCode.Text, WorkStantOption.vStandId, WorkStantOption.MoidStr, WorkStantOption.PartidStr, m_iWeightMode)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            If dt.Rows(0)(0).ToString = "1" Then
                Return True
            End If
        End If

        Dim errMsg As String = "扫描条码没有经过确认品管确认!"
        WorkStantOption.ErrorStr = errMsg
        SetMessage("Fail", errMsg)

        WorkStantOption.BarCodeStr = ppid
        WorkStantOption.vMainBarCode = ppid
        ShowFrmScanErrPrompt()
        PlaySimpleSound(1)

        Return False
    End Function


    ''' <summary>
    ''' 处理不良重量
    ''' </summary>
    ''' <param name="weight"></param>
    ''' <remarks></remarks>
    Private Sub ScanPpidWeight(weight As String)
        '品管确认退出 
        If bPGConfirm = True Then Exit Sub

        Dim strSQL As String = "SELECT 1 FROM m_partinput_t WHERE partid = '{0}' AND usey = 'Y'"
        strSQL = String.Format(strSQL, WorkStantOption.PartidStr)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        '要求设置过的料号中才处理保存不良记录，要走不良流程
        If dt.Rows.Count > 0 Then
            Dim frm As FrmWorkStantScanPpidWeight = New FrmWorkStantScanPpidWeight
            frm.m_iWeightMode = m_iWeightMode
            frm.weight = weight

            frm.ShowDialog()

            bPGConfirm = frm.bPGConfirm
            PGConfirmWeight = frm.PGConfirmWeight
        End If
    End Sub

    '在线称重
    Private Sub PpidOnlineWeight(ByVal BarCode As String)
        Dim strWeight As String
        strWeight = Me.txtOnLineWeight.Text.Trim

        'If CheckWeight() = False Then
        '    Exit Sub
        'End If
        ScanWeight(BarCode, strWeight)
        Me.txtOnLineWeight.Text = ""
        TxtBarCode.Enabled = False
        txtOnLineWeight.Enabled = True
        LabResult.ForeColor = Color.Lime
        lblMessage.ForeColor = Color.Lime

        TxtCartonNo.Text = ""
        LabResult.Text = "产品:" & BarCode & "扫描成功！重量:" & strWeight & ",请继续下一个产品！"
        txt_tmpbarcode.Text = ""
        lblMessage.Text = "PASS"
        txtOnLineWeight.Focus()

        Me.IsOnlineWeightFinish = True
    End Sub

    ''' <summary>
    ''' 在线裸机称重
    ''' </summary>
    ''' <param name="BarCode"></param>
    ''' <remarks></remarks>
    Private Sub BarePpidOnlineWeight(ByVal BarCode As String)
        Dim strWeight As String
        strWeight = Me.txtOnLineWeight.Text.Trim

        'If CheckWeight() = False Then
        '    Exit Sub
        'End If
        ScanWeight(BarCode, strWeight)
        Me.txtOnLineWeight.Text = ""
        TxtBarCode.Enabled = False
        txtOnLineWeight.Enabled = True
        LabResult.ForeColor = Color.Lime
        lblMessage.ForeColor = Color.Lime

        TxtCartonNo.Text = ""
        LabResult.Text = "裸机产品:" & BarCode & "扫描成功！重量:" & strWeight & ",请继续下一个裸机产品！"
        txt_tmpbarcode.Text = ""
        lblMessage.Text = "PASS"
        txtOnLineWeight.Focus()

        Me.IsOnlineWeightFinish = True
    End Sub

    Private Function GetLot(ByVal moid As String) As String
        Dim lot As String = ""
        Try
            Dim strSql As String
            strSql = "select top 1  lotid from M_PCBLot_t   where  Moid ='" & moid & "' and ISNULL (Splitqty ,1)<=Linkqty   order by Intime desc"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
            If dt.Rows.Count > 0 Then
                lot = dt.Rows(0)("lotid").ToString
            End If
        Catch
        End Try
        Return lot
    End Function
#End Region

    '释放资源
    Private Sub DisposeData()
        WorkStantOption.PackNumber = Nothing
        WorkStantOption.BarCodeStr = Nothing
        WorkStantOption.DpetNameStr = Nothing
        WorkStantOption.ErrorStr = Nothing
        WorkStantOption.GflenStr = Nothing
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

    '打开端口
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

    '设置COM口
    Private Sub toolComSet_Click(sender As Object, e As EventArgs) Handles toolComSet.Click
        If TxtMoId.Text = "" Then
            lblMessage.Text = "掃描資料未設置..."
            Exit Sub
        End If
        Dim FrmCOMSet As New FrmCOMSet()
        FrmCOMSet.ShowDialog()
        If FrmCOMSet.txtCOMValue.Text.Trim <> "" Then
            ''自动扫描初始化
            Rs232Init()
        End If
    End Sub
    Dim scanparsKey As String = "AUTOSCANPATS232" '扫描端口相关内容取得KEY
    Dim MachineType As String = "1"         '东莞机台
    Dim comname As String = ""
    '取得自动扫描参数 
    Private Function GetRs232Pars() As String
        Dim result As String = ""
        Dim strSQL As String = ""

        strSQL = "  SELECT TEXT, isnull(MachineType,'1') MachineType FROM m_AutoScanBaseData_t WHERE [ITEMKEY] = '{0}' and VALUE = '{1}'"
        strSQL = String.Format(strSQL, scanparsKey, My.Computer.Name)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            Return ""
        Else
            result = dt.Rows(0)(0).ToString
            MachineType = dt.Rows(0)(1).ToString
        End If
        Return result
    End Function
    Private Sub Rs232Init()
        Try
            Dim values As String = GetRs232Pars()

            If values <> "" Then

                If values.Split("|").Length <> 5 Then
                    '  MessageUtils.ShowError("连接设备的扫描参数设置格式不正确！")
                    Exit Sub
                End If
                If Not RS232 Is Nothing Then
                    If RS232.IsOpen Then  '開啟
                        RS232.Close()
                        RS232.Dispose()
                    End If
                End If


                '  设置参数()
                RS232 = New SerialPort
                RS232.PortName = values.Split("|")(0)  '欲開啟的通訊埠
                RS232.BaudRate = values.Split("|")(1)  '通訊速度
                RS232.Parity = values.Split("|")(2)    '不发生奇偶校验位检查
                RS232.DataBits = values.Split("|")(3)  '資料位元設定值
                RS232.StopBits = values.Split("|")(4)  '停止位 

                Try
                    AddHandler RS232.DataReceived, AddressOf RS232_DataReceived
                    RS232.Open()
                    LabResult.ForeColor = Color.Lime
                    lblMessage.ForeColor = Color.Lime
                    LabResult.Text = "电子秤通讯端口已打开"
                    lblMessage.Text = "请先称重后扫描"
                Catch ex As Exception
                    MessageUtils.ShowError(ex.Message)
                    SetMessage("Fail", ex.Message)
                    SysMessageClass.WriteErrLog(ex, "FrmWorkStantScan.Rs232Init", "Load", "sys")
                End Try

                '  txtOnLineWeight.ReadOnly = True

            End If


        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SetMessage("Fail", ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmWorkStantScan.Rs232Init", "Load", "sys")
            MessageUtils.ShowError("没有打开RS232端口或没有连接对应设备！")
        End Try
    End Sub
#Region "公共接收端口指令数据方法函数"
    Private Sub RS232_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)

        Dim buffer() As Byte = Nothing
        Dim data() As Byte = New Byte(2048) {}
        Dim receiveCount As Integer = 0
        While (True)
            System.Threading.Thread.Sleep(20)
            If RS232.BytesToRead < 1 Then
                buffer = New Byte(receiveCount) {}
                Array.Copy(data, 0, buffer, 0, receiveCount)
                Exit While
            End If
            receiveCount += RS232.Read(data, receiveCount, RS232.BytesToRead)
        End While
        If receiveCount = 0 Then
            Return
        End If
        Dim msg As String = String.Empty
        msg = Encoding.ASCII.GetString(buffer)
        'msg = msg.Replace("KG", "").Replace("kg", "").Trim()
        msg = msg.Replace("G", "").Replace("g", "").Trim()

        SetCValues(txtOnLineWeight, msg)
        '电子称和手输入统一
        SetWeightDown(msg, "2")

    End Sub
#End Region
#Region "公共发送指令到端口方法函数"
    Private Sub SendRs232Data(ByVal SendMsg As String)
        If SendMsg = "" Then
            'LabResult.Text = "NG"
            'lblMessage.Text = "发送指令不能为空..."
            Exit Sub
        End If
        Try
            Dim send() As Byte = Nothing
            send = Encoding.ASCII.GetBytes(SendMsg)
            RS232.Write(send, 0, send.Length)
            lblMessage.Text = "OK"
            LabResult.Text = "发送指令" + SendMsg + "完成..."
        Catch ex As Exception
            lblMessage.Text = "NG"
            LabResult.Text = "发送指令发生错误：" + ex.ToString
        End Try

    End Sub

#End Region
    Private Sub SetCValues(ByVal TempC As Object, ByVal TValue As String)
        Dim obj_delegate As New ThreadControl(AddressOf SetControlValue)
        Me.Invoke(obj_delegate, TValue, TempC)
    End Sub
    Sub SetControlValue(ByVal TValue As String, ByVal TempC As Object)
        If TempC.GetType().Name = "TextBox" Then
            CType(TempC, TextBox).Text = TValue
        ElseIf TempC.GetType().Name = "textBoxUL" Then
            CType(TempC, ULControls.textBoxUL).Text = TValue
        ElseIf TempC.GetType().Name = "ListBox" Then
            CType(TempC, ListBox).Items.Add(TValue)
        ElseIf TempC.GetType().Name = "Label" Then
            CType(TempC, Label).Text = TValue
        ElseIf TempC.GetType().Name = "CheckBox" Then
            CType(TempC, CheckBox).Checked = Convert.ToBoolean(TValue)
        Else
            TempC.Text = TValue
        End If
    End Sub
    ''' <summary>
    ''' 控制項賦值必須使用委託
    ''' </summary>
    ''' <param name="val"></param>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Delegate Sub ThreadControl(ByVal val As String, ByVal obj As Object)
    Private Sub SetCBg(ByVal TempC As Object, ByVal TValue As Color)
        Dim obj_delegate As New ThreadBgControl(AddressOf SetControlBg)
        Me.Invoke(obj_delegate, TValue, TempC)
    End Sub
    Sub SetControlBg(ByVal TValue As Color, ByVal TempC As Object)

        If TempC.GetType().Name = "Label" Then
            CType(TempC, Label).ForeColor = TValue
        Else
            CType(TempC, Label).ForeColor = TValue
        End If
    End Sub
    Delegate Sub ThreadBgControl(ByVal val As Color, ByVal obj As Object)

    Private Sub SetCFocus(ByVal TempC As Object)
        Dim obj_delegate As New ThreadFocusControl(AddressOf SetControlFocus)
        Me.Invoke(obj_delegate, TempC)
    End Sub
    Sub SetControlFocus(ByVal TempC As Object)

        If TempC.GetType().Name = "TextBox" Then
            CType(TempC, TextBox).Focus()
        ElseIf TempC.GetType().Name = "textBoxUL" Then
            CType(TempC, ULControls.textBoxUL).Focus()
        Else
            TempC.Focus()
        End If
    End Sub
    Delegate Sub ThreadFocusControl(ByVal obj As Object)

    Private Sub SetCEnabled(ByVal TempC As Object, ByVal TValue As Boolean)
        Dim obj_delegate As New ThreadEnabledControl(AddressOf SetControlEnabled)
        Me.Invoke(obj_delegate, TValue, TempC)
    End Sub
    Sub SetControlEnabled(ByVal TValue As Boolean, ByVal TempC As Object)

        If TempC.GetType().Name = "TextBox" Then
            CType(TempC, Label).Enabled = TValue
        ElseIf TempC.GetType().Name = "textBoxUL" Then
            CType(TempC, ULControls.textBoxUL).Enabled = TValue
        Else
            TempC.Enabled = TValue
        End If
    End Sub
    Delegate Sub ThreadEnabledControl(ByVal val As Boolean, ByVal obj As Object)

    Private Sub MenProductPrint_Click(sender As Object, e As EventArgs) Handles MenProductPrint.Click
        If TxtMoId.Text = "" Then
            lblMessage.Text = "掃描資料未設置..."
            Exit Sub
        End If
        Dim frm As New FrmOnlineWorkPrintanker(Me.TxtPartid.Text)
        frm.PartId = TxtPartid.Text.Trim
        frm.ShowDialog()
    End Sub

	Private Sub chbReadSN_CheckedChanged(sender As Object, e As EventArgs) Handles chbReadSN.CheckedChanged
		If Not chbReadSN.Checked Then
			Timer1.Stop()
			UsbBarcode = ""
			TxtBarCode.Text = ""
			Exit Sub
		End If
		If TxtPartid.Text.Trim.Length = 0 Then
			Timer1.Stop()
			Exit Sub
		End If
		Dim strSql As String
		strSql = "select * from MESDB.dbo.m_GetUSBInfoSet_t where usey='Y' and PartID='" & TxtPartid.Text.Trim & "'"
		Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
		If dt.Rows.Count = 0 Then
			lblMessage.Text = "该料号还未设置USB配置信息..."
			Timer1.Stop()
			Exit Sub
		End If
		UsbBarcode = ""
		Timer1.Start()
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		Dim strSql As String
		strSql = "select top 1 * from MESDB.dbo.m_GetUSBInfoSet_t where usey='Y' and PartID='" & TxtPartid.Text.Trim & "' order by Intime desc"
		Dim dt As DataTable = DbOperateUtils.GetDataTable(strSql)
		Dim searcher As New ManagementObjectSearcher(dt.Rows(0)("Scope").ToString(), dt.Rows(0)("QueryString").ToString())
		Dim result As ManagementObjectCollection = searcher.Get()
		If (result Is Nothing) Or (result.Count = 0) Then
			UsbBarcode = ""
			TxtBarCode.Text = ""
			Exit Sub
		End If
		For Each queryObj As ManagementObject In searcher.Get()
			For Each item As PropertyData In queryObj.Properties
				Try
					If item.Value <> "" Then
						Dim convert = Split(item.Value, "\")
						Dim _barcode As String = convert(dt.Rows(0)("Section").ToString()).ToString
						TxtBarCode.Text = _barcode
						If (UsbBarcode.Length = 0) Then
							UsbBarcode = _barcode
							Timer1.Stop()
							USBBarcodeSan()
							Timer1.Start()
						Else
							If UsbBarcode <> _barcode Then
								UsbBarcode = _barcode
								Timer1.Stop()
								USBBarcodeSan()
								Timer1.Start()
							Else
								Exit Sub
							End If
						End If
					End If
				Catch ex As Exception
				End Try
			Next
		Next
	End Sub
	Private Sub USBBarcodeSan()
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
	End Sub


End Class
