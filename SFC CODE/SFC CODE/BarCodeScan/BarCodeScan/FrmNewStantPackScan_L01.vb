
'--新工站包装扫描
'--Create by :　马锋
'--Create date :　2014/07/17
'--Update :  田玉琳 2016/05/05
'--Update :  田玉琳 2016/08/30
'--更新内容：A.按快捷键F10打开产品看板
'--          B.扫描正常和错误有声音提示（更改声音显示）
'--          C.显示当前箱数量
'--Update :  田玉琳 2016/12/27
'--更新内容：非系统扫描箱条码，删除应该删除代码
'--Update :  田玉琳 2017/02/14
'--更新内容：对于流水校验码，对流水部位检查，同时对保存到数据库中
'--11，10要求验证条码流水号;01,11
'--Update :  田玉琳 2017/02/22
'--更新内容：删除对特殊字符检查，改到存储过程中处理
'--Update :  田玉琳 2017/03/14
'--更新内容：有子条码时，不对子条码验证，只对主条码验证
'--          对于实际装箱数量大于工单数量时，提示工单已扫描完成
'--Update :  田玉琳 2017/04/12
'--更新内容：对LXXN扫描慢的问题解决。
'--          删除多余注解代码
'--Update :  黄广都 2017/07/04
'--更新内容：部件扫描异常，继续完成上次未扫部件的条码
'--Update :  黄广都 2017/08/28
'--更新内容：界面加入扫描防呆，防止因为卡顿导致部件扫描异常
'--Update :  田玉琳 2018/03/20
'--更新内容：华为ASN扫描处理优化。
'--Update :  田玉琳 2018/10/10
'--更新内容：删除界面设备扣减相关操作,移动到存储过程中。

#Region "Imports"

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports BarCodeScan.Data
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports BarCodePrint
Imports System.IO
Imports System.Xml
Imports MainFrame
Imports UIHandler
Imports SysBasicClass
Imports System.Threading
Imports RouteManagement
Imports System.IO.Ports

#End Region

Public Class FrmNewStantPackScan_L01

#Region "窗體變量"

    Dim IsCustPart As Boolean
    Dim IsPrtPacking As Boolean
    Dim IsScanPallet As Boolean
    Dim PalletID As String                  '栈板条码
    Dim IsFull As Boolean = False           '棧板是否裝滿
    Dim IsLinePrint As String = "N"         '是否在线打印产品条码
    Dim IsReadSn As String = "N"            '是否读取序号
    Dim TgenCarton As String = "N"          '自动生面外箱
    Dim IsPackingPPID As String = "N"       '是否产品序号相同（允许箱产品同包装）
    Dim IsPackType As String = "N"          '包装类型
    Dim IsPrtSelf As String = "N"           '是否在系统里面打印
    Dim IsPrtSelfCarton As String = "N"     '是否在系统里面打印外箱
    Dim CODERULEID As String = ""           '外箱编码原则
    Dim IsScanN As String = "N"             '是否扫描多次
    Dim ScanNumber As Integer = 1           '扫描次数
    Dim LastScanIndex As Integer = 0        '上一次扫描序号 hgd 20170828
    Dim IsTrunk As String = "N"             '田玉琳 20160419
    Dim IsHaveChildCode As String = "N"     '田玉琳 20161102
    Dim IsSemiProduct As String = "N"       '田玉琳 20180308 是否是半成品
    Dim IsEquipmentLifeCheck As String = "N"  '魏莎 20161025，是否冶具寿命卡控
    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Dim PackArray As New SysMessageClass.PrtStructure
    Dim printscanPPid As String = String.Empty
    Public scanSetting As New ScanSetting
    Private okWavPlayTime As Integer = 700      '正确声音播放时间
    Private ngWavPlayTime As Integer = 2000     '错误声音播放时间
    Dim frmBoard As FrmProductionBoard          '看板窗体（可多次打开）

    '--自定义校验条码数量和内容
    Dim CheckCurIndex As Integer = 0
    Dim paraArrays As String()      '校验参数
    Dim IsRepeatStyleC As String = "N"
    Dim ssStartindex As Integer     '流水起始位置 田玉琳 2017014
    Dim ssStartLength As Integer    '流水起始长度 田玉琳 2017014
    Dim strIsCharacters As String
    Dim IsCheckCartonStyle As String = "Y"  '是否检查箱样式 田玉琳20171215

    Dim CheckCartonCurIndex As Integer = 0
    Dim paraCartonArrays As String()      '箱条码校验参数
    Dim iCartonStartindex As Integer     '
    Dim iCartonStartLength As Integer    '

    Dim CheckBigCartonCurIndex As Integer = 0
    Dim paraBigCartonArrays As String()      '大外箱条码校验参数
    Dim iBigCartonStartindex As Integer     '
    Dim iBigCartonStartLength As Integer    '
    Private m_strQRCode As String = String.Empty

    Dim WithEvents RS232 As SerialPort
#End Region

#Region "窗體事件"
    '快捷键
    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                BnScanSet_Click(sender, e)
            Case Keys.F10 '快捷键F10
                OpenProductionBoard()
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select

    End Sub

    '初期化
    Private Sub FrmBarScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btApp = New BarTender.ApplicationClass
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        SetMenuRight()

        TxtBarCode.Enabled = False
        LblMainBarCode.Text = ""
        LabResult.Text = ""
        lblMessage.Text = "请设置扫描资料"
        ToolUsename.Text = VbCommClass.VbCommClass.UseName
        txt_tmpbarcode.Text = ""
        SqlClassM.GetPrintersList(cboPrinterList)
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName '取得默认的打印
        cboPrinterList.Text = sDefaultPrinter
        '设置播放声音时间参数
        SetWavPlayTime()
        '设定用戶權限
    End Sub

    '掃描設置
    Private Sub BnScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolScanSet.Click
        Dim strSQL As String = ""
        scanSetting.FormName = Me.Name
        If LblMainBarCode.Text.Trim <> "" Then
            MessageUtils.ShowInformation("該站點對應的次條碼未掃描完整,不能再設置!")
            Exit Sub
        End If

        Try
            Dim FrmOpenLock As New FrmSetLock
            FrmNewShareSetForm.vStationType = "P"
            FrmOpenLock.ShowDialog()

            If CartonScanOption.CheckStr = True Then
                Dim FrmScanSet As New FrmNewShareSetForm(scanSetting)
                FrmScanSet.Owner = Me
                FrmScanSet.ShowDialog()

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

                Me.lblCartonStyle.Text = ""
                Me.lblCartonStyle2.Text = ""
                Me.LblCartonQty.Text = "0"
                Me.LblCurrCarQty.Text = "0"
                Me.LblPackQty.Text = "0"
                Me.LblCurrQty.Text = "0"
                Me.TxtPalletID.Text = ""
                'LblPackQty 应装产品  实装 LblCurrQty,'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                TxtBarCode.Focus()
                IsScanPallet = scanSetting.ScanPalletCheck ''是否掃描棧板
                IsCustPart = scanSetting.CustPartCheck ''是否核對客戶料號
                IsPrtPacking = scanSetting.PrtPackingCheck '是否在线打印外箱号
                DGridBarCode.DataSource = Nothing

                TxtMoId.Text = scanSetting.MoidStr           ''工單
                TxtSitName.Text = scanSetting.vStandId & scanSetting.vStandName    ''工單數量
                ''LabCust.Text = scanSetting.CustStr ''工單類型
                TxtPartid.Text = scanSetting.PartidStr ''料件編號
                '' LabMoCust.Text = scanSetting.MoCustStr ''客戶料號
                TxtLineId.Text = scanSetting.LineStr ''線別
                'LblTime.Text = scanSetting.TimeStr ''掃描開始時間
                'LabCartonQty.Text = scanSetting.PartPackQty
                'TxtSnStyle1.Text = scanSetting.SnStyleStr1


                SetMessage("PASS", "扫描资料设置完成")
                scanSetting.vCurrentStandIndex = 1
                Dim groupid As String = GetPrintGroup(scanSetting.PartidStr)
                Select Case groupid
                    Case "1"
                        '1S4XD0T04868HL****** 实际样式8S4XD0T04868HL****** *** 联想耳机
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0) = "1S" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0).Substring(2, 18)
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1) = "1S" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1).Substring(2, 18)
                    Case "2"
                        '1S4XD0T04868HL****** 实际样式(1S)GXD0T69863Z1920001 94 联想耳机
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0) = "1S" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0).Substring(4, 18)
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1) = "1S" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1).Substring(4, 18)
                    Case "3"
                        ' 1S4X90S92381UMY***** 实际样式8SSC10S92383UMY******联想6合一
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0) = "1S4X90S92381" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0).Substring(12, 8)
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1) = "1S4X90S92381" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1).Substring(12, 8)
                    Case "4"
                        ' SUMY***** 实际样式8SSC10S92383UMY******联想6合一
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0) = "S" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0).Substring(12, 8)
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1) = "S" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1).Substring(12, 8)
                    Case "5"
                        ' 1SSD20V02880ZSSSSS 实际样式1S40AUZPMSSSSS联想8合一
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0) = "1SSD20V02880ZPM" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0).Substring(9, 5)
                        scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1) = "1SSD20V02880ZPM" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1).Substring(9, 5) ''
                End Select

                'scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0) = "1S" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0).Substring(2, 18)
                'scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1) = "1S" + scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1).Substring(2, 18)
                '联想L01 扫描1S4XD0T04868HL****** 实际样式8S4XD0T04868HL****** ***
                TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                'TxtBarCode.MaxLength = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 2)
                ControlState(False)

                If GetIsScanFinish(TxtMoId.Text) = True Then
                    LblPackQty.Text = "0" : LblCurrQty.Text = "0"
                    SetMessage("FAIL", "该工单全部扫描完成！")
                    LoadPalletPaceQty()
                    Exit Sub
                End If

                strSQL = " SELECT ISNULL(IslineMbarcode,'N') IslineMbarcode,isnull(IsUsb,'N') IsUsb,isnull(LinePrtY,'N') LinePrtY," & _
                           " ISNULL(IsAllowRe,'N') as IsProductSame, isnull(IsPackType,'N') as IsPackType, isnull(RepeatStyleC,'N') as IsRepeatStyleC, " & _
                           " ISNULL(IsPrtSelf,'N') as IsPrtSelf, ISNULL(ISPRTSELFCARTON,'N')ISPRTSELFCARTON, " & _
                           " ISNULL(CODERULEID,'') as CODERULEID,ISNULL(IsScanN,'') as IsScanN ,ISNULL(IsSemiProduct,'') as IsSemiProduct " & _
                           " FROM m_RPartStationD_t where PPartid='" & TxtPartid.Text & "' and TPartid='" & TxtPartid.Text & "' " & _
                           " AND Stationid='" & scanSetting.vStandId & "'  and State='1'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    IsLinePrint = dt.Rows(0)!IslineMbarcode
                    IsReadSn = dt.Rows(0)!IsUsb
                    IsPackingPPID = dt.Rows(0)!IsProductSame
                    IsPackType = dt.Rows(0)!IsPackType
                    TgenCarton = dt.Rows(0)!LinePrtY
                    IsPrtSelf = dt.Rows(0)!IsPrtSelf
                    IsRepeatStyleC = dt.Rows(0)!IsRepeatStyleC '
                    IsPrtSelfCarton = dt.Rows(0)!IsPrtSelfCarton
                    CODERULEID = dt.Rows(0)!CODERULEID
                    IsScanN = dt.Rows(0)!IsScanN
                    IsSemiProduct = dt.Rows(0)!IsSemiProduct
                End If

                '*************************************************************
                '非系统箱条码扫描  田玉琳 20161220
                If IsPrtSelfCarton = "N" Then   '非系统单码扫描
                    If GetNonSelfCarton() = False Then
                        SetMessage("Fail", "（非系统打印外箱）编码原则设置错误,请重新设置")
                        Exit Sub
                    End If
                Else
                    GetIsSelfCarton()
                End If
                '*************************************************************
                If Not IsScanPallet Then
                    PnlPallet.Visible = False
                    '''''''獲取未裝滿外箱
                    '直接用箱的数据去取

                    strSQL = " SELECT a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,isnull(a.PackingQuantity,0) AS qty " & _
                              " FROM M_Carton_t a  " & _
                              " WHERE a.Moid='{0}' and a.Teamid='{1}' and a.CartonStatus='N' AND a.StationId='{2}' order by a.Intime desc"

                    '加入扫描站点条件
                    strSQL = String.Format(strSQL, Me.TxtMoId.Text.Trim, Me.TxtLineId.Text.Trim, scanSetting.vStandId)

                    dt.Reset()
                    dt = DbOperateUtils.GetDataTable(strSQL)
                    If dt.Rows.Count > 0 Then
                        TxtCartonID.Text = dt.Rows(0)("Cartonid").ToString
                        LblPackQty.Text = dt.Rows(0)("qty").ToString '应装数量
                        Me.LblCurrQty.Text = dt.Rows(0)("cartonqty").ToString '已装数量
                        GetScanItem(Me.TxtCartonID.Text)

                        ControlState(True)

                    Else
                        If scanSetting.PrtPackingCheck Then
                            ControlState(False)
                        Else
                            If scanSetting.IsOnlineGenCartonID Then
                                Me.TxtCartonID.Text = OnlineCartonID()
                                CartonIDScanHandle()
                                ControlState(True)
                            Else
                                ControlState(False)
                            End If
                        End If
                    End If
                    'Dim count As Integer = Integer.Parse(LblCurrQty.Text)
                    'Dim PackQty As Integer = Integer.Parse(LblPackQty.Text)
                    ''count = count + 1
                    'If PackQty > 0 And PackQty >= count Then
                    '    Dim pr As Decimal = count * 100 / PackQty

                    '    ' LblCurrQty.Text = count.ToString
                    '    ProgressBar1.Value = pr
                    '    'ProgressBar1.Text = count.ToString + "/" + PackQty.ToString
                    'End If
                Else
                    PnlPallet.Visible = True
                    SetPalletStyle(TxtPartid.Text)
                    '''''''獲取未裝滿棧板
                    'LblPackQty 应装产品  实装 LblCurrQty, 'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                    dt.Reset()
                    dt = DbOperateUtils.GetDataTable("select Palletid, MultiQty,Palletqty from M_PalletM_t where  Moid='" & Me.TxtMoId.Text.Trim &
                                                     "' and Teamid='" & Me.TxtLineId.Text.Trim & "'   and PalletStatus='N' ")
                    If dt.Rows.Count > 0 Then
                        TxtPalletID.Enabled = False
                        TxtPalletID.Text = dt.Rows(0)("Palletid").ToString
                        LblCartonQty.Text = dt.Rows(0)("MultiQty").ToString
                        Me.LblCurrCarQty.Text = (Convert.ToInt32(dt.Rows(0)("Palletqty").ToString)).ToString
                        TxtPalletID.Enabled = False

                        strSQL = " SELECT a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,isnull(a.PackingQuantity,0) AS qty " & _
                         " FROM M_Carton_t a  " & _
                         " WHERE a.Moid='{0}' and a.Teamid='{1}' and a.CartonStatus='N' AND a.StationId='{2}' order by a.Intime desc"
                        '加入扫描站点条件
                        strSQL = String.Format(strSQL, Me.TxtMoId.Text.Trim, Me.TxtLineId.Text.Trim, scanSetting.vStandId)

                        dt.Reset()
                        dt = DbOperateUtils.GetDataTable(strSQL)

                        If dt.Rows.Count > 0 Then
                            TxtCartonID.Text = dt.Rows(0)("Cartonid").ToString
                            LblPackQty.Text = dt.Rows(0)("qty").ToString
                            Me.LblCurrQty.Text = dt.Rows(0)("cartonqty").ToString
                            GetScanItem(Me.TxtCartonID.Text)
                            ControlState(True)
                        Else
                            ControlState(False)
                        End If
                    Else
                        TxtPalletID.Enabled = True
                        TxtCartonID.Enabled = False
                        TxtPalletID.Focus()
                        SetScanCodeStyle("P")
                    End If
                End If

                LoadPalletPaceQty()
                '*************************************************************
                '有子条码扫描  田玉琳 20161102
                IsChildCode()
                '*************************************************************

            End If
            scanSetting.CheckStr = False
            If (scanSetting.PrtPackingCheck) Then
                printscanPPid = Me.TxtCartonID.Text.Trim
            End If

            If scanSetting.vRepeatStyle = "Y" Then
                ReDim paraArrays(scanSetting.vRepeatPara.Split(",").Length - 1)
                Dim i As Integer = 0
                For i = 0 To paraArrays.Length - 1
                    paraArrays(i) = scanSetting.vRepeatPara.Split(",")(i).Replace("{", "").Replace("}", "").Trim
                Next
                '设置有检验时，流水段数据
                GetCodeRuleIdSSSS(TxtPartid.Text)
            End If


            If scanSetting.vCartonRepeatStyle = "Y" Then
                ReDim paraCartonArrays(scanSetting.vCartonRepeatPara.Split(",").Length - 1)
                Dim i As Integer = 0
                For i = 0 To paraCartonArrays.Length - 1
                    paraCartonArrays(i) = scanSetting.vCartonRepeatPara.Split(",")(i).Replace("{", "").Replace("}", "").Trim
                Next
                '设置有检验时，流水段数据
                GetCartonCodeRuleIdSSSS(TxtPartid.Text)
            End If

            'cq20180828,add support 三层，大外箱
            If scanSetting.vBigCartonRepeatStyle = "Y" Then
                ReDim paraBigCartonArrays(scanSetting.vBigCartonRepeatPara.Split(",").Length - 1)
                Dim i As Integer = 0
                For i = 0 To paraBigCartonArrays.Length - 1
                    paraBigCartonArrays(i) = scanSetting.vBigCartonRepeatPara.Split(",")(i).Replace("{", "").Replace("}", "").Trim
                Next
                '设置有检验时，流水段数据
                GetCartonCodeRuleIdSSSS(TxtPartid.Text)
            End If

            '判断卡关信息，决定是否需要冶具寿命卡关
            Dim EquipmentList As String = ScanCommon.GetEquipmentNo(TxtMoId.Text, TxtLineId.Text)
            strSQL = "execute CheckEquipmentLife '" & TxtPartid.Text & "', '" & EquipmentList & "'"
            Dim ds As DataSet = DbOperateUtils.GetDataSet(strSQL)
            Dim dt_CheckEquipmentLife As DataTable = ds.Tables(0)
            scanSetting.EquipmentLifeCheck = dt_CheckEquipmentLife.Rows(0)(0).ToString()

            '显示用户所选的冶具列表
            dgvEquipPart.Rows.Clear()
            If scanSetting.EquipmentLifeCheck = "Y" Then
                '读取之前的配置信息，显示冶具列表
                If EquipmentList <> "" Then
                    Dim dt_EquipmentList As DataTable = ds.Tables(1)
                    For Each row As DataRow In dt_EquipmentList.Rows
                        dgvEquipPart.Rows.Add(row("EquipmentNo").ToString(), row("ProcessParameters").ToString(),
                                              row("AlertCount").ToString(), row("ServiceCount").ToString(), row("RemainCount").ToString())
                    Next
                End If
            End If

            If Me.chkIsOhterLineScan.Checked = True Then
                Call RecordLineInfo()
            End If

            '取得是否检查箱样式
            GetIsCheckCartonStyle()

            '判断是否有未解锁的状况
            Dim errDt As DataTable = CheckErrLockData()
            If errDt.Rows.Count > 0 Then
                Dim errppid As String = errDt.Rows(0)("ppid")
                Dim Errordest As String = errDt.Rows(0)("Errordest")

                WorkStantOption.ErrorStr = Errordest
                SetMessage("Fail", Errordest)
                WorkStantOption.BarCodeStr = errppid
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                Me.ActiveControl.Focus()
                PlaySimpleSound(1)

                Exit Sub
            End If
        Catch ex As Exception
            scanSetting.MoidStr = ""
            TxtMoId.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtLineId.Text = String.Empty
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "设置扫描参数异常,请重新设置"
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#{1}", Me.TxtMoId.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "BnScanSet_Click", "sys")
        End Try
    End Sub
    ''' <summary>
    ''' 判断是否存在异常解锁情况
    ''' </summary>
    ''' <returns>返回发生异常解锁的条码</returns>
    ''' <remarks></remarks>
    Private Function CheckErrLockData() As DataTable
        Dim moid As String = IIf(scanSetting.MoidStr Is Nothing, "", scanSetting.MoidStr)
        Dim lineid As String = IIf(scanSetting.LineStr Is Nothing, "", scanSetting.LineStr)
        Dim Stationid As String = IIf(scanSetting.vStandId Is Nothing, "", scanSetting.vStandId)
        Dim sqlstr As StringBuilder = New StringBuilder
        sqlstr.Append("select ppid,Errordest from m_AssysnE_t WHERE  Userid='" & VbCommClass.VbCommClass.UseId & "' and spoint='" & My.Computer.Name & "' and Moid='" & moid & "' and Teamid='" & lineid & "' and Stationid='" & Stationid & "' and Intime>CONVERT(varchar(10),getdate(),23)  and isnull(Solvetime,'')='' ")
        Return DbOperateUtils.GetDataTable(sqlstr.ToString)
    End Function
    '记录辅助线扫描的设置线别信息,cq 20170221
    Private Sub RecordLineInfo()
        Try
            Dim strSQL As New StringBuilder
            strSQL.Append(" DECLARE @RTVALUE varchar(10), @strmsgText varchar(50) ")
            strSQL.Append(" EXECUTE [m_AutoScanRecordLine_P] '" & Trim(TxtMoId.Text) & "', '" & TxtLineId.Text.Trim & "',  ")
            strSQL.Append(" '" & My.Computer.Name & "', '" & VbCommClass.VbCommClass.UseId & "',@RTVALUE OUTPUT, @strmsgText OUTPUT ")
            strSQL.Append(" SELECT @RTVALUE,@strmsgText")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        SysMessageClass.WriteErrLog(dt.Rows(0)(1), "FrmNewStantPackScan", "RecordLineInfo", "BarCodeScan")
                    Case "1"
                        'OK
                    Case Else
                        'do nothing
                End Select
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmNewStantPackScan", "RecordLineInfo", "BarCodeScan")
        End Try
    End Sub

    '取消记录辅助线扫描的设置线别信息,cq 20170505
    Private Sub CancelRecordLineInfo()
        Try
            Dim strSQL As New StringBuilder
            strSQL.Append(" DECLARE @RTVALUE varchar(10), @strmsgText varchar(50) ")
            strSQL.Append(" EXECUTE [m_AutoScanRecordLineCancel_P] '" & Trim(TxtMoId.Text) & "', '" & TxtLineId.Text.Trim & "',  ")
            strSQL.Append(" '" & My.Computer.Name & "', '" & VbCommClass.VbCommClass.UseId & "',@RTVALUE OUTPUT, @strmsgText OUTPUT ")
            strSQL.Append(" SELECT @RTVALUE,@strmsgText")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        SysMessageClass.WriteErrLog(dt.Rows(0)(1), "FrmNewStantPackScan", "RecordLineInfo", "BarCodeScan")
                    Case "1"
                        'OK
                    Case Else
                        'do nothing
                End Select
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmNewStantPackScan", "CancelRecordLineInfo", "BarCodeScan")
        End Try
    End Sub

    '退出
    Private Sub BnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '条码扫描事件
    Private Sub TxtBarCode_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TxtBarCode.PreviewKeyDown
        If (scanSetting.MoidStr Is Nothing) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtBarCode.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtBarCode.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If e.KeyValue = 13 Then
            StandScan()

            '注释人 hgd 2018-06-14 可能引起出现红叉
            'Dim count As Integer = Integer.Parse(LblCurrQty.Text)
            'Dim PackQty As Integer = Integer.Parse(LblPackQty.Text)
            ''count = count + 1
            'If PackQty > 0 And PackQty >= count Then
            '    Dim pr As Decimal = count * 100 / PackQty
            '    ProgressBar1.Value = pr
            '    '注释人 hgd 2018-06-14 可能引起出现红叉
            '    'ProgressBar1.Text = count.ToString + "/" + PackQty.ToString
            'End If

        End If
    End Sub

    '箱号输入后事件
    Private Sub TxtCartonID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonID.KeyPress
        If e.KeyChar = Chr(13) Then
            CartonIDScanHandle()
        End If
    End Sub

    '棧板條碼处理事件
    Private Sub TxtPalletID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPalletID.KeyPress
        If (scanSetting.MoidStr Is Nothing) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtPalletID.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtPalletID.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If e.KeyChar = Chr(13) Then
            PalletIDScanHandle() ''掃入棧板條碼
        End If
    End Sub

    '批次扫描作业
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

    '尾数箱參數設置
    Private Sub ToolOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolOption.Click
        Dim strOldPackQty As String = LblPackQty.Text
        If Me.TxtMoId.Text = "" Then
            MsgBox("請先設置打印資料！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If
        ' TxtCartonID 
        If LblCurrQty.Text <> "0" Then
            MsgBox("當前箱未掃描完,不允許尾數設置！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If

        If Me.TxtCartonID.Text <> "" And Me.LblCurrQty.Text <> "0" Then
            MsgBox("正在掃描中,不允許尾數打印！", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "系統提示")
            Exit Sub
        End If

        Try
            Dim FrmLastLock As New FrmCartonLastQtySet
            Dim result As DialogResult = FrmLastLock.ShowDialog()

            If result = DialogResult.OK Then


                LblPackQty.Text = CStr(Val(WorkStantOption.LastPrintQty))

                'add by cq 20171010, update the carton.
                Call UpdateCartonPackQty(strOldPackQty)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        '' End If
    End Sub

    Private Sub UpdateCartonPackQty(ByVal strOldPackQty As String)
        Dim lsSQL As String = ""
        lsSQL = " Update m_Carton_t SET PackingQuantity= " & Val(LblPackQty.Text) & ",mark1=N'尾數箱設置:原容量:" & strOldPackQty & "' " & _
                " Where CartonID ='" & Me.TxtCartonID.Text.Trim & "'"
        DbOperateUtils.ExecSQL(lsSQL)

    End Sub

    '在线打印产品条码替换打印
    Private Sub tsbCodeReplacePrint_Click(sender As Object, e As EventArgs) Handles tsbCodeReplacePrint.Click
        If TxtPartid.Text = "" Then
            SetMessage("Fail", "扫描资料未设置...")
            Exit Sub
        End If
        If scanSetting.IsLinePrintFullCode = False Then
            SetMessage("Fail", "在线打印的整个外箱才能重新打印...")
            Exit Sub
        End If
        If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
            SetMessage("Fail", "请设置在线标签打印机选项...")
            Exit Sub
        End If

        Try
            Dim frm As New FrmBarCodeReplace()
            frm.Moid = TxtMoId.Text.Trim
            frm.PartId = TxtPartid.Text.Trim
            frm.LabelNum = scanSetting.LabelNum
            frm.PrintName = Me.cboPrinterList.Text.Trim
            frm.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNewStantPackScan", "tsbRepeatPrint_Click", "sys")
            Exit Sub
        End Try
    End Sub
    '
    Private Sub ToolReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TxtPartid.Text = "" Then
            SetMessage("Fail", "扫描资料未设置...")
            Exit Sub
        End If
        If scanSetting.IsLinePrintFullCode = False Then
            SetMessage("Fail", "在线打印的整个外箱才能重新打印...")
            Exit Sub
        End If
        If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
            SetMessage("Fail", "请设置在线标签打印机选项...")
            Exit Sub
        End If

        Try
            Dim frm As New FrmBarCodeReplace()
            frm.Moid = TxtMoId.Text.Trim
            frm.PartId = TxtPartid.Text.Trim
            frm.LabelNum = scanSetting.LabelNum
            frm.PrintName = Me.cboPrinterList.Text.Trim
            frm.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNewStantPackScan", "ToolReplace_Click", "sys")
            Exit Sub
        End Try
    End Sub

    Private Sub ToolCartonReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCartonReplace.Click
        If TxtPartid.Text = "" Then
            lblMessage.Text = "扫描资料未设置..."
            Exit Sub
        End If
        If scanSetting.PrtPackingCheck Then
            Dim frm As New FrmCartonReplace(TxtPartid.Text)
            frm.ShowDialog()
        Else
            lblMessage.Text = "在线打印的外箱才能替换打印..."
            Exit Sub
        End If
    End Sub

    '重新打印外箱
    Private Sub tsbRepeatPrint_Click(sender As Object, e As EventArgs) Handles tsbRepeatPrint.Click
        If TxtPartid.Text = "" Then
            SetMessage("Fail", "扫描资料未设置...")
            Exit Sub
        End If
        'If scanSetting.IsLinePrintFullCode = False Then
        '    SetMessage("Fail", "在线打印的整个外箱才能重新打印...")
        '    Exit Sub
        'End If
        If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
            SetMessage("Fail", "请设置在线标签打印机选项...")
            Exit Sub
        End If

        Try
            Dim frm As New FrmCartonRepeatPrint()
            frm.Moid = TxtMoId.Text.Trim
            frm.PartId = TxtPartid.Text.Trim
            frm.LabelNum = scanSetting.LabelNum
            frm.PrintName = Me.cboPrinterList.Text.Trim
            frm.PrintType = FrmCartonRepeatPrint.EnumPrintType.L01FullSn
            frm.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNewStantPackScan", "tsbRepeatPrint_Click", "sys")
            Exit Sub
        End Try
    End Sub

    '在线称重打印
    Private Sub tsbLineWeight_Click(sender As Object, e As EventArgs) Handles tsbLineWeight.Click
        If TxtPartid.Text = "" Then
            SetMessage("Fail", "扫描资料未设置...")
            Exit Sub
        End If
        'If scanSetting.IsLinePrintFullCode = False Then
        '    SetMessage("Fail", "在线打印的整个外箱才能打印...")
        '    Exit Sub
        'End If
        If scanSetting.IsLineWeight = False Then
            SetMessage("Fail", "在线打印的整个外箱且要求称重才能打印...")
            Exit Sub
        End If
        If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
            SetMessage("Fail", "请设置在线标签打印机选项...")
            Exit Sub
        End If

        Try
            OpenOnlineWeightForm(False)
        Catch ex As Exception
            lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNewStantPackScan", "tsbLineWeight_Click", "sys")
            Exit Sub
        End Try
    End Sub

    '显示看板
    Private Sub tsbDisplayBoard_Click(sender As Object, e As EventArgs)
        '看板
        'OpenProductionBoard()
    End Sub

    Private Sub FrmStantPackScan_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        DisposeData()
        scanSetting.CustIdString = Nothing
        scanSetting.MoidStr = Nothing
        scanSetting.LengthStr = Nothing
        scanSetting.DateCheck = Nothing
        If VbCommClass.VbCommClass.Factory = "BZLANTO" Then
            If RS232 IsNot Nothing Then
                If RS232.IsOpen Then
                    RS232.Close()
                End If
            End If
        End If

    End Sub

    '
    Private Sub TxtSnStyle2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSnStyle2.GotFocus, TxtSnStyle1.GotFocus
        If Me.TxtCartonID.ReadOnly = False Then
            TxtCartonID.Focus()
        Else
            If Me.TxtPalletID.ReadOnly = False Then
                TxtPalletID.Focus()
            ElseIf Me.TxtBarCode.ReadOnly = False Then
                TxtBarCode.Focus()
            End If
        End If
    End Sub

    '是否辅助扫描
    Private Sub chkIsOhterLineScan_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsOhterLineScan.CheckedChanged
        If String.IsNullOrEmpty(Me.TxtMoId.Text) Then Exit Sub
        If Me.chkIsOhterLineScan.Checked = True Then
            Call RecordLineInfo()
        Else
            Call CancelRecordLineInfo()
        End If

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

    Private Sub toolSpecialScanSet_Click(sender As Object, e As EventArgs) Handles toolSpecialScanSet.Click
        Me.cbIsReWork.Enabled = True
        Me.chkIsHWASN.Enabled = True
    End Sub

    Private Sub tsbProductDetail_Click(sender As Object, e As EventArgs) Handles tsbProductDetail.Click
        Try
            'Dim Production As New FrmProduction(TxtLineId.Text)
            'Production.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
#Region "工治具设定"

    Private Sub ToolEquipment_Click(sender As Object, e As EventArgs) Handles ToolEquipment.Click
        Try
            If Me.TxtMoId.Text = "" Then
                lblMessage.Text = "请先设置扫描资料,才能进行冶具设定..."
                Exit Sub
            End If

            If scanSetting.EquipmentLifeCheck = "Y" Then

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
                        dgvEquipPart.Rows.Add(row("EquipmentNo").ToString(), row("ProcessParameters").ToString(),
                                              row("AlertCount").ToString(), row("ServiceCount").ToString(), row("RemainCount").ToString())
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

#End Region

#Region "工单状态设置"

    Private Sub toolMOStatusSetting_Click(sender As Object, e As EventArgs) Handles toolMOStatusSetting.Click
        Try
            If (String.IsNullOrEmpty(Me.TxtMoId.Text.Trim)) Then
                SetMessage("FAIL", "请设置工单！")
                Exit Sub
            End If

            Dim FrmMOStatusSetting As New FrmMOStatusSetting(Me.TxtMoId.Text.Trim, Me.TxtLineId.Text.Trim)
            FrmMOStatusSetting.ShowDialog()

        Catch ex As Exception
            SetMessage("FAIL", "打开工单状态设置异常！")
        End Try
    End Sub

#End Region

#End Region

#Region "獲取掃描記錄"
    '扫描
    Private Sub GetScanItem(ByVal Cartonid As String)

        'Dim strSQL As String = "SELECT  moid.PartID AS ppartid, ppLink.StaOrderid AS staorderid, ppLink.ScanOrderid AS scanorderid, " &
        '"   ppLink.ppid,moid.PartID AS tparttext,CartonSn.Userid AS username,CartonSn.intime " &
        '"   FROM m_Cartonsn_t CartonSn INNER JOIN m_Carton_t carton ON carton.Cartonid=CartonSn.Cartonid  " &
        '"   INNER JOIN  m_Ppidlink_t ppLink on ppLink.Exppid = CartonSn.ppid" &
        '"   INNER JOIN m_Mainmo_t moid ON moid.Moid=carton.Moid WHERE CartonSn.Cartonid='{0}' " &
        '"   ORDER BY ppLink.intime desc ,ppLink.ScanOrderid"

        Dim strSQL As String = "SELECT  moid.PartID AS ppartid, ppLink.StaOrderid AS staorderid, ppLink.ScanOrderid AS scanorderid, " &
          "   ppLink.ppid,moid.PartID AS tparttext,CartonSn.Userid AS username,CartonSn.intime " &
          "   FROM {0} CartonSn INNER JOIN m_Carton_t carton ON carton.Cartonid=CartonSn.Cartonid  " &
          "   INNER JOIN  m_Ppidlink_t ppLink on ppLink.Exppid = CartonSn.ppid" &
          "   INNER JOIN m_Mainmo_t moid ON moid.Moid=carton.Moid WHERE CartonSn.Cartonid='{1}' and ppLink.Itemid = '{2}' " &
          "   ORDER BY ppLink.intime desc ,ppLink.ScanOrderid"
        Dim TableName = "m_Cartonsn_t"
        If IsSemiProduct = "Y" Then
            TableName = "m_CartonsnBan_t"
        End If
        Dim IitemId = "1"
        If IsSemiProduct = "Y" Then
            IitemId = "0"
        End If

        strSQL = String.Format(strSQL, TableName, Cartonid, IitemId)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim orderIndex As Integer = 0
        DGridBarCode.Rows.Clear()
        For iIndex As Integer = 0 To dt.Rows.Count - 1
            DGridBarCode.Rows.Add(dt.Rows(iIndex)!ppartid, dt.Rows(iIndex)!staorderid,
                                  dt.Rows(iIndex)!Ppid, dt.Rows(iIndex)!tparttext,
                                  dt.Rows(iIndex)!username, dt.Rows(iIndex)!intime)
        Next

        strSQL = "select COUNT(1) from m_RPartStationD_t where PPartid = '{0}' and State = 1"
        'add by hgd 2017-09-05 箱包装多个站需要加上工站条件
        'If scanSetting.vPackType = "Y" And scanSetting.vStandMaxStaIndex > 1 Then
        '    strSQL = strSQL & " and Stationid='" & scanSetting.vStandId & "'"
        'End If
        strSQL = strSQL & " and Stationid='" & scanSetting.vStandId & "'"
        strSQL = String.Format(strSQL, TxtPartid.Text)
        Dim dt2 As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If CInt(dt2.Rows(0)(0)) > 1 Then
            If dt.Rows.Count > 0 Then
                '如果只是扫描主条码中断后，再次进入扫描时，设置主条码，再扫次条码
                If dt.Rows(0)!scanorderid = "1" Then
                    LblMainBarCode.Text = dt.Rows(0)!Ppid.ToString
                    orderIndex = dt.Rows(0)!staorderid.ToString
                End If
            End If
        End If

        DGridBarCode.AutoResizeColumns()

        scanSetting.vCurrentStandIndex = IIf(scanSetting.vStandMaxStaIndex > orderIndex, orderIndex + 1, 1)
        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
        'TxtBarCode.MaxLength = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 2)
        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"

    End Sub

    '取得数据确认是否是有子条码
    Private Sub IsChildCode()
        IsHaveChildCode = "N"

        '如果没有设置工单退出 
        If scanSetting.vStandId Is Nothing Then Exit Sub

        Dim strSQL As String
        strSQL = "select COUNT(1) from m_RPartStationD_t where PPartid = '{0}' and Stationid = '{1}' and State = 1 "
        strSQL = String.Format(strSQL, TxtPartid.Text.Trim, scanSetting.vStandId.Trim)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If CInt(dt.Rows(0)(0)) > 1 Then
            IsHaveChildCode = "Y"
        End If
    End Sub

#End Region

#Region "條碼掃描"

    Private Sub StandScan()

        If InStr(TxtBarCode.Text, "'") Then
            TxtBarCode.Clear()
            Exit Sub
        End If
        If IsScanPallet Then
            If LblCartonQty.Text = "0" Then
                lblMessage.Text = "栈板应装数量不能为0，设置有误..."
                TxtBarCode.Clear()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If
        If LblPackQty.Text = "0" Then
            If LblCartonQty.Text = "0" Then
                lblMessage.Text = "外箱应装数量不能为0，设置有误..."
                TxtBarCode.Clear()
                PlaySimpleSound(1)
            End If
        End If

        '在线打印整箱
        If scanSetting.IsLinePrintFullCode Then
            If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
                WorkStantOption.ErrorStr = "请设置在线标签打印机选项..."
                SetMessage("Fail", "请设置在线标签打印机选项...")
                WorkStantOption.BarCodeStr = TxtBarCode.Text
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If

        '**************田玉琳 修改 20170510***********************Start 
        '扫描多个条码(目前只扫描两个，以后多个条码也可以)
        If scanSetting.IsScanN = "Y" And ScanNumber <> 2 Then
            ScanNumber = ScanNumber + 1
            Exit Sub
        Else
            ScanNumber = 1
        End If
        '**************田玉琳 修改 20170510***********************End 

        Dim BarCodeOriginal As String = TxtBarCode.Text

        'add by cq20171110
        If Me.TxtBarCode.Text.Length <> LTrim(Me.TxtBarCode.Text).Length Then

            WorkStantOption.ErrorStr = "ERROR,左端有空格！"
            SetMessage("Fail", "ERROR,左端有空格")
            WorkStantOption.BarCodeStr = TxtBarCode.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)

            Exit Sub
        Else
            ' do nothing
        End If

        If Me.TxtBarCode.Text.Length <> RTrim(Me.TxtBarCode.Text).Length Then
            WorkStantOption.ErrorStr = "ERROR,右端有空格！"
            SetMessage("Fail", "ERROR,右端有空格")
            WorkStantOption.BarCodeStr = TxtBarCode.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)

            Exit Sub
        Else
            ' do nothing
        End If

        'LblPackQty 应装产品  实装 LblCurrQty ,LblCartonQty(应装箱数)  已装箱LblCurrCarQty
        Dim BarCode As String = Trim(TxtBarCode.Text).Replace(vbNewLine, "")

        Dim ReadSn As String = ""
        Dim E75sn As String = "", E75Msg As String = "" ''E75序号内容

        If Me.TxtMoId.Text = "" Then
            WorkStantOption.ErrorStr = "請先設置好掃描基本信息！"
            SetMessage("Fail", "請先設置好掃描基本信息!")
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If BarCode = "" Then
            WorkStantOption.ErrorStr = "產品條碼不能為空！"
            SetMessage("Fail", "產品條碼不能為空!")
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)

            Exit Sub
        End If
        '子件扫描检测
        If (Me.IsHaveChildCode = "Y" AndAlso scanSetting.vCurrentStandIndex = 1 AndAlso Me.LastScanIndex = 1) Then

            SetMessage("Fail", "部件扫描异常,请重新进行扫描设置!")
            WorkStantOption.ErrorStr = "部件扫描异常,请重新进行扫描设置!"
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If
        '不区分大小写 20180731 邓炯
        If scanSetting.IsNotCaseSensitive = "Y" Then
            BarCode = BarCode.ToUpper
        End If
        '**************田玉琳 修改 20170112***********************Start 
        '验证样式
        If CheckStyle(BarCode) = False Then Exit Sub
        '**************田玉琳 修改 20170112***********************END 

        Dim Sqlstr As String = String.Empty
        Dim o_strIsRepaired As String = IIf(Me.chkIsRepaired.Checked, "Y", "N")
        '是否重工扫描(重工工单)--add by hgd 2017-12-05
        Dim isReWork As String = IIf(Me.cbIsReWork.Checked, "Y", "N")
        '箱层级判断/料件号判断     'TxtBarCode  扫描箱号：判断工站扫描是装箱/装产品 '" & o_strIsRework & "'
        Try
            Dim o_strCartonQty As String = "", o_strCurrCarQty As String = ""
            Dim tempstr() As String = scanSetting.vmReplaceArray(scanSetting.vCurrentStandIndex, 1).Split("|")

            Sqlstr = " DECLARE @strmsgid varchar(1), @strmsgText nvarchar(150), @currqty int, @currPqty int, @OutPQty int, @outPPID nvarchar(64) " & _
                     " EXECUTE [m_NewCheckPackScan_PL01] '" & Trim(BarCode) & "','" & E75sn & "','" & E75Msg & "'," & _
                        "'" & Trim(TxtMoId.Text) & "','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                        "'" & scanSetting.PartidStr & "','" & tempstr(tempstr.Length - 1) & "','" & LblMainBarCode.Text.Trim & "'," & _
                        "'" & scanSetting.vStandId & "','" & scanSetting.vStandIndex & "','" & scanSetting.vCurrentStandIndex & "'," & _
                        "'" & scanSetting.vStandMaxStaIndex & "','" & Me.TxtCartonID.Text & "','" & Me.TxtPalletID.Text.Trim & "','" &
                        Me.LblPackQty.Text & "','" & IsPackType.Trim & "','" & scanSetting.vSamePacking.Trim & "'," & _
                        " '" & o_strIsRepaired & "','" & isReWork & "'," & _
                        "@strmsgid output,@strmsgText output,@currqty output,@currPqty output, @OutPQty output,@OutPPID output " & _
                        "SELECT @strmsgid,@strmsgText,isnull(@currqty,1) as currqty,isnull(@currPqty,1) as currPqty, isnull(@OutPQty,0) as outPQty,@OutPPID as PPID"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0", "1", "2", "3", "5"
                        PlaySimpleSound(1)
                        WorkStantOption.BarCodeStr = BarCode
                        WorkStantOption.ErrorStr = dt.Rows(0)(1)
                        WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                        SetMessage("FAIL", BarCode & Space(3) & dt.Rows(0)(1))

                        ShowFrmScanErrPrompt()
                        SetMessage("PASS", "已解锁，请继续进行作业")
                        TxtBarCode.Text = ""
                        Me.TxtBarCode.Focus()
                        Exit Sub
                    Case "4" ''---掃描成功
                        PlaySimpleSound(0)
                        If scanSetting.vCurrentStandIndex = 1 Then
                            LblMainBarCode.Text = TxtBarCode.Text
                        End If
                        '记录下扫描序号,防止卡顿影响
                        Me.LastScanIndex = Me.LastScanIndex + 1
                        SetMessage("PASS", "扫描成功...")
                        '@OutPPID       
                        TxtBarCode.Text = dt.Rows(0).Item("PPID").ToString
                        Me.DGridBarCode.Rows.Insert(0, scanSetting.PartidStr, scanSetting.vStandIndex, _
                                                    TxtBarCode.Text, scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3), SysMessageClass.UseId, Now())

                        If DGridBarCode.Rows.Count > 10 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If
                        scanSetting.vCurrentStandIndex = scanSetting.vCurrentStandIndex + 1
                        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                        'TxtBarCode.MaxLength = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 2)
                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"

                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                    Case "6"
                        PlaySimpleSound(0)
                        Thread.Sleep(50)
                        Me.LblCurrQty.Text = dt.Rows(0)(2)
                        Me.TxtBarCode.Text = dt.Rows(0)(5)
                        SetMessage("PASS", "扫描成功...")
                        'UseName ==》 userid, cq 20160127
                        Me.DGridBarCode.Rows.Insert(0, scanSetting.PartidStr, scanSetting.vStandIndex, TxtBarCode.Text, _
                                                    scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3), SysMessageClass.UseId, Now())
                        '' DGridBarCode.AutoResizeColumns()
                        DGridBarCode.ClearSelection()
                        DGridBarCode.Rows(0).Cells(0).Selected = True
                        If DGridBarCode.Rows.Count > 10 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If

                        scanSetting.vCurrentStandIndex = 1
                        'cq 20170911 條碼掃描,next barcode
                        ' If Me.TxtPartid.Text = "L99U2041-CS-H" And Me.TxtMoId.Text.Substring(0, 8) = "1511T-17" Then
                        ' TxtSnStyle1.Text = "04071190-U2041-17**"
                        ' TxtSnStyle2.Text = "04071190-U2041-17**"
                        ' Else
                        TxtSnStyle1.Text = scanSetting.vstyleArray(1, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(1, 1)
                        'TxtBarCode.MaxLength = scanSetting.vstyleArray(1, 2)
                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"

                        If (scanSetting.ScanPalletCheck) Then
                            Me.LblCurrCarQty.Text = dt.Rows(0).Item("OutPQty").ToString
                            Me.LblCartonQty.Text = dt.Rows(0).Item("currPqty").ToString
                        End If

                        LblMainBarCode.Text = ""
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()

                        '记录下扫描序号,防止卡顿影响
                        Me.LastScanIndex = 0
                    Case "7"
                        PlaySimpleSound(0)
                        Me.LblCurrQty.Text = dt.Rows(0)(2)

                        If (scanSetting.ScanPalletCheck) Then
                            Me.LblCurrCarQty.Text = dt.Rows(0).Item("OutPQty").ToString
                            Me.LblCartonQty.Text = dt.Rows(0).Item("currPqty").ToString
                        End If
                        'LblPackQty 应装产品  实装 LblCurrQty, 'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                        o_strCartonQty = LblCartonQty.Text
                        o_strCurrCarQty = LblCurrCarQty.Text
                        If IsScanPallet AndAlso Val(o_strCartonQty) = Val(o_strCurrCarQty) Then   'Convert.ToInt32(LblCartonQty.Text) = Convert.ToInt32(LblCurrCarQty.Text) Then
                            SetMessage("PASS", "扫描成功，请扫描大外箱或栈板条码！")
                            DGridBarCode.Rows.Clear()
                            LblCartonQty.Text = "0"
                            LblCurrCarQty.Text = "0"
                            LblCurrQty.Text = "0"
                            LblPackQty.Text = "0"
                            'LblCurrQty
                            scanSetting.vCurrentStandIndex = 1

                            TxtSnStyle1.Text = scanSetting.vstyleArray(1, 0)
                            TxtSnStyle2.Text = scanSetting.vstyleArray(1, 1)

                            'TxtBarCode.MaxLength = scanSetting.vstyleArray(1, 2)
                            LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                            LblMainBarCode.Text = ""
                            ControlState(False, True)
                            SetScanCodeStyle("P")
                            '记录下扫描序号,防止卡顿影响
                            Me.LastScanIndex = 0
                        Else
                            '记录下扫描序号,防止卡顿影响
                            Me.LastScanIndex = 0
                            SetMessage("PASS", BarCode & Space(3) & "该箱已经包装完成,请扫描下一箱...")
                            DGridBarCode.Rows.Clear()
                            'SetGridHeadColumn()
                            scanSetting.vCurrentStandIndex = 1
                            TxtSnStyle1.Text = scanSetting.vstyleArray(1, 0)
                            TxtSnStyle2.Text = scanSetting.vstyleArray(1, 1)
                            'TxtBarCode.MaxLength = scanSetting.vstyleArray(1, 2)
                            LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                            LblMainBarCode.Text = ""

                            '如果在线称重先处理
                            If scanSetting.IsLineWeight Then
                                OpenOnlineWeightForm(True)
                            Else
                                If scanSetting.IsLinePrintFullCode Then
                                    '在线扫描完成后打印箱
                                    PrintFullCarton()
                                End If
                            End If

                            If scanSetting.PrtPackingCheck Then '是否在线打印外箱信息
                                ControlState(False)
                                Me.TxtCartonID.Focus()
                                SetScanCodeStyle("C")
                            Else
                                If scanSetting.IsOnlineGenCartonID Then
                                    '**************田玉琳 修改 20160419***********************Start 
                                    If IsTrunk = "N" Then
                                        If chkShowCartonFull.Checked = True Then
                                            If (MessageUtils.ShowConfirm("确定要进行下一箱？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                                                Me.TxtCartonID.Text = OnlineCartonID()
                                            End If
                                        Else
                                            Me.TxtCartonID.Text = OnlineCartonID()
                                        End If
                                        CartonIDScanHandle()
                                    Else
                                        lblMessage.Text = "该工单全部扫描完成！"
                                    End If
                                    '**************田玉琳 修改 20160419***********************End 
                                Else
                                    'add by cq 20180820, add show dialog  info to user
                                    If chkShowCartonFull.Checked = True Then
                                        If (MessageUtils.ShowConfirm("确定要进行下一箱？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                                            ControlState(False)
                                        End If
                                    Else
                                        ControlState(False)
                                    End If

                                    Me.TxtCartonID.Focus()
                                    SetScanCodeStyle("C")
                                End If
                            End If
                            LoadPalletPaceQty()
                        End If
                        ''更新冶具数量
                        'UpdateEquipmentCount(BarCodeOriginal)
                        'ChangeMouldLifeNum()
                End Select
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtBarCode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmNewStantPackScan", "StandScan", "sys")
        End Try
    End Sub

    Private Sub CartonIDScanHandle()
        Dim Sqlstr As String = String.Empty
        Dim StrQty As Integer

        If Me.TxtPartid.Text = "" Then
            WorkStantOption.ErrorStr = "扫描资料未设置，请先设置..."
            SetMessage("Fail", "扫描资料未设置，请先设置...")
            WorkStantOption.BarCodeStr = TxtCartonID.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtCartonID.Text = ""
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)

            Exit Sub
        End If

        If Me.TxtCartonID.Text = "00000000" Then

            lblMessage.Text = "该工单已扫描完成！"
            Me.TxtCartonID.Text = ""
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If Me.TxtCartonID.Text = "" Then
            WorkStantOption.ErrorStr = "箱號條碼序號不能為空"
            SetMessage("Fail", "箱號條碼序號不能為空")
            WorkStantOption.BarCodeStr = TxtCartonID.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtCartonID.Text = ""
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        'add by cq20171110
        If Me.TxtCartonID.Text.Length <> LTrim(Me.TxtCartonID.Text).Length Then
            WorkStantOption.ErrorStr = "ERROR,左端有空格"
            SetMessage("Fail", "ERROR,左端有空格")
            WorkStantOption.BarCodeStr = TxtCartonID.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtCartonID.Text = ""
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        Else
            ' do nothing
        End If

        If Me.TxtCartonID.Text.Length <> RTrim(Me.TxtCartonID.Text).Length Then
            WorkStantOption.ErrorStr = "ERROR,右端有空格"
            SetMessage("Fail", "ERROR,右端有空格")
            WorkStantOption.BarCodeStr = TxtCartonID.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtCartonID.Text = ""
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)

            Exit Sub
        Else
            ' do nothing
        End If

        If (scanSetting.MoidStr Is Nothing) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtCartonID.Text = ""
            Me.TxtPalletID.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtCartonID.Text = ""
            Me.TxtPalletID.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (scanSetting.PrtPackingCheck) Then
            printscanPPid = Me.TxtCartonID.Text.Trim
        End If



        '------------------------新增棧板對應多外箱掃描-------------
        Dim IsPallte As String = IIf(IsScanPallet, "Y", "N")
        If IsScanPallet = True Then
            ' 应装箱数（30） <  已装箱数(30) , cq20170508, <= → < (等于也让pass) 
            If CInt(LblCartonQty.Text) < CInt(LblCurrCarQty.Text) Then
                WorkStantOption.ErrorStr = "外箱装栈板时，发生异常...,应装箱数不能小于已经箱数..."
                SetMessage("Fail", "外箱装栈板时，发生异常...,应装箱数不能小于已经箱数...")
                WorkStantOption.BarCodeStr = TxtCartonID.Text
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If

        '产品条码
        If IsPrtSelf = "Y" Then
            Sqlstr = " DECLARE @outstrCompareResult  varchar(10)" & _
                     " EXECUTE [m_CheckWeekCodePC_P] '" & TxtPalletID.Text.Trim & "','" & Trim(TxtCartonID.Text) & "', '" & Trim(scanSetting.PartidStr) & "'," & _
                     " '" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "',@outstrCompareResult output " & _
                     " SELECT @outstrCompareResult"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        WorkStantOption.ErrorStr = "大箱与小箱條碼周别不匹配"
                        SetMessage("FAIL", "大箱与小箱條碼周别不匹配")
                        'PlaySimpleSound(1)
                        WorkStantOption.BarCodeStr = Trim(TxtCartonID.Text)
                        WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                        ShowFrmScanErrPrompt()
                        SetMessage("PASS", "已解锁，请继续进行作业")
                        Me.TxtCartonID.Focus()
                        Me.TxtCartonID.Clear()
                        PlaySimpleSound(1)
                        Exit Sub
                    Case "1"
                        'check OK, pass
                    Case Else
                        'do nothing
                End Select
            End If
        End If

        Dim CartonIDStr As String = TxtCartonID.Text

        '****************************************************************
        '勾选华为ASN扫描 二维码新规则代替外箱扫描 李素霞提出需求
        '华为ASN扫描
        If Me.chkIsHWASN.Checked = True Then
            Dim chkIsHWASNValue As String = IIf(Me.chkIsHWASN.Checked, "Y", "N")
            Dim sqlHWASN As String = "declare @PalletID varchar(200), @Msg nvarchar(200),@ReturnValue int" & vbCrLf &
       "exec m_NewCheckHWASN '" + CartonIDStr + "','" + TxtMoId.Text + "','" + TxtPartid.Text + "','" + chkIsHWASNValue + "','" + scanSetting.vStandId + "','" + m_strQRCode + "',2,@PalletID out,@Msg out,@ReturnValue out" & vbCrLf &
       "select @PalletID,@Msg,@ReturnValue"
            Dim dtHWASN As DataTable = DbOperateUtils.GetDataTable(sqlHWASN)
            '条码判断
            If dtHWASN.Rows(0)(2).ToString() = "0" Then 'S19二维条码
                m_strQRCode = TxtCartonID.Text
                CartonIDStr = dtHWASN.Rows(0)(0).ToString '新栈板号
                TxtCartonID.Text = CartonIDStr
            ElseIf dtHWASN.Rows(0)(2).ToString() = "1" Then '抛错误信息
                SetMessage("FAIL", dtHWASN.Rows(0)(1).ToString())
                Me.TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
                PlaySimpleSound(1)
                Exit Sub
            ElseIf dtHWASN.Rows(0)(2).ToString() = "2" Then '非S19二维码条码
                m_strQRCode = TxtCartonID.Text
                SetMessage("PASS", "请继续刷入19条码")
                Me.TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
                PlaySimpleSound(0)
                Exit Sub
                'ElseIf dtHWASN.Rows(0)(2).ToString() = "3" Then '普通条码
            End If
        End If

        'Dim BarCode As String = Trim(TxtCartonID.Text)
        '**************田玉琳 修改 20170328***********************Start 
        '验证样式
        If CheckStyleC(CartonIDStr) = False Then Exit Sub
        '**************田玉琳 修改 20170328***********************END 
        '是否重工扫描(重工工单)--add by hgd 2017-12-05
        Dim isReWork As String = IIf(Me.cbIsReWork.Checked, "Y", "N")
        Try
            '2015-04-02     马锋       Me.TxtMoId.Text  Me.TxtLineId.Text
            Sqlstr = "DECLARE @strmsgid varchar(1),@strmsgText nvarchar(50),@NewCartonid varchar(100),@qty int, @palletQty float " & _
                "EXECUTE [m_NewCheckPallMulletCarton_p] " & _
                "'" & Trim(scanSetting.MoidStr) & "','" & CartonIDStr & "','" & IsPallte.Trim & "','" & TxtPalletID.Text.Trim & "','" & Trim(scanSetting.LineStr) & "','" & SysMessageClass.UseId.Trim & "','" & scanSetting.vCartonSame.Trim & "','" & scanSetting.vSamePacking.Trim & "'," & _
                "'" & isReWork & "','" & scanSetting.vStandId.Trim & "',N'" & scanSetting.vStandName.Trim & "'," & _
                "@strmsgid output,@strmsgText output,@NewCartonid output,@qty output, @palletQty output " & _
                " SELECT @strmsgid ,isnull(@strmsgText,''),@qty ,@NewCartonid, @palletQty "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1" To "3"
                        WorkStantOption.ErrorStr = dt.Rows(0)(1).ToString()
                        SetMessage("FAIL", WorkStantOption.ErrorStr)
                        'PlaySimpleSound(1)
                        WorkStantOption.BarCodeStr = Trim(TxtCartonID.Text)
                        WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                        ShowFrmScanErrPrompt()
                        SetMessage("PASS", "已解锁，请继续进行作业")
                        Me.TxtCartonID.Focus()
                        Me.TxtCartonID.Clear()
                        PlaySimpleSound(1)

                        Exit Sub
                    Case "4"
                        PlaySimpleSound(0)
                        DGridBarCode.Rows.Clear()
                        'SetGridHeadColumn()
                        LblPackQty.Text = ""
                        LblCurrQty.Text = ""
                        StrQty = CInt(dt.Rows(0)(2).ToString)
                        TxtCartonID.Text = dt.Rows(0)(3).ToString

                        LblPackQty.Text = StrQty
                        Me.LblCurrQty.Text = 0
                        'LblPackQty 应装产品  实装 LblCurrQty 'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                        'scanSetting.vPPackingProduct.Trim = "N"
                        If (scanSetting.ScanPalletCheck = True) Then
                            LblCurrCarQty.Text = dt.Rows(0)(4).ToString
                        End If

                        'Add by cq 20170714
                        If (Me.chkIsHWASN.Checked = True) AndAlso (Not String.IsNullOrEmpty(m_strQRCode)) Then
                            Call RecordQRCodeInfo(TxtCartonID.Text)
                            m_strQRCode = ""
                        End If
                        SetMessage("PASS", "外箱条码序号，扫描成功...")
                        ControlState(True)
                        LoadPalletPaceQty() '更新显示第几箱
                End Select
            Else
                'SetMessage("FAIL", "系统无法识别此外箱标签序号！")
                'Me.TxtCartonID.Text = ""
                'PlaySimpleSound(1)
                WorkStantOption.ErrorStr = "系统无法识别此外箱标签序号"
                SetMessage("Fail", "系统无法识别此外箱标签序号")
                WorkStantOption.BarCodeStr = TxtCartonID.Text
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation("有异常发生，请联系管理员!异常信息：" + ex.ToString)
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtCartonID.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "CartonIDScanHandle", "sys")
            Exit Sub
        End Try
    End Sub

    Private Sub PalletIDScanHandle()
        Dim Sqlstr As String = String.Empty
        If Me.TxtMoId.Text = "" Then
            lblMessage.Text = "请设置扫描资料！"
            PlaySimpleSound(1)
            Exit Sub
        End If
        If Me.TxtPalletID.Text = "" Then
            lblMessage.Text = "栈板條碼序號不能為空！"
            Me.TxtPalletID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        'add by cq20171110
        If Me.TxtPalletID.Text.Length <> LTrim(Me.TxtPalletID.Text).Length Then
            WorkStantOption.ErrorStr = "ERROR,左端有空格"
            SetMessage("Fail", "ERROR,左端有空格")
            WorkStantOption.BarCodeStr = TxtPalletID.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtPalletID.Text = ""
            Me.TxtPalletID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        Else
            ' do nothing
        End If

        If Me.TxtPalletID.Text.Length <> RTrim(Me.TxtPalletID.Text).Length Then
            WorkStantOption.ErrorStr = "ERROR,右端有空格"
            SetMessage("Fail", "ERROR,右端有空格")
            WorkStantOption.BarCodeStr = TxtPalletID.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtPalletID.Text = ""
            Me.TxtPalletID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        Else
            ' do nothing
        End If


        Try

            Dim PalletIDStr As String = TxtPalletID.Text '勾选华为ASN扫描 二维码新规则代替外箱扫描 李素霞提出需求
            If scanSetting.vPalletSame = "Y" Then
                '**************田玉琳 修改 20180320***********************Start 
                If chkIsHWASN.Checked = True Then
                    Dim chkIsHWASNValue As String = IIf(Me.chkIsHWASN.Checked, "Y", "N")
                    Dim sqlHWASN As String = "declare @PalletID varchar(200), @Msg nvarchar(200),@ReturnValue int" & vbCrLf &
               "exec m_NewCheckHWASN '" + PalletIDStr + "','" + TxtMoId.Text + "','" + TxtPartid.Text + "','" + chkIsHWASNValue + "','" + scanSetting.vStandId + "','" + m_strQRCode + "',1,@PalletID out,@Msg out,@ReturnValue out" & vbCrLf &
               "select @PalletID,@Msg,@ReturnValue"
                    Dim dtHWASN As DataTable = DbOperateUtils.GetDataTable(sqlHWASN)
                    '条码判断
                    If dtHWASN.Rows(0)(2).ToString() = "0" Then 'S19二维条码
                        m_strQRCode = TxtPalletID.Text
                        PalletIDStr = dtHWASN.Rows(0)(0).ToString
                        TxtPalletID.Text = PalletIDStr
                    ElseIf dtHWASN.Rows(0)(2).ToString() = "1" Then '抛错误信息
                        SetMessage("FAIL", dtHWASN.Rows(0)(1).ToString())
                        Me.TxtPalletID.Text = ""
                        Me.TxtPalletID.Focus()
                        PlaySimpleSound(1)
                        Exit Sub
                    ElseIf dtHWASN.Rows(0)(2).ToString() = "2" Then '非S19二维码条码
                        m_strQRCode = TxtPalletID.Text
                        SetMessage("PASS", "请继续刷入19条码")
                        Me.TxtPalletID.Text = ""
                        Me.TxtPalletID.Focus()
                        PlaySimpleSound(0)
                        Exit Sub
                        'ElseIf dtHWASN.Rows(0)(2).ToString() = "3" Then '普通条码
                    End If

                    '验证样式
                    If CheckStyleP(PalletIDStr) = False Then Exit Sub
                End If
                '**************田玉琳 修改 20180320***********************END 

                '验证大外箱样式,cq 20180828
                If CheckStyleBigC(PalletIDStr) = False Then Exit Sub

                Sqlstr = "DECLARE @strmsgid varchar(1),@strmsgText varchar(50),@InventPalletid varchar(100),@qty int " & _
                  " EXECUTE [m_NewCheckPallet_p] " & _
                  "'" & Trim(Me.TxtMoId.Text) & "','" & Trim(PalletIDStr) & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "','" & scanSetting.vPalletSame & "'," & _
                  "'" & scanSetting.vStandId & "',N'" & scanSetting.vStandName & "'," & _
                  "@strmsgid output,@strmsgText output,@InventPalletid output,@qty output " & _
                  " SELECT @strmsgid ,isnull(@strmsgText,'') ,@qty,@InventPalletid "
            Else

                '验证大外箱样式,cq 20180828
                If CheckStyleBigC(PalletIDStr) = False Then Exit Sub

                Sqlstr = "declare @strmsgid varchar(1),@strmsgText varchar(50),@qty int execute [m_CheckPallet_p] " & _
                 " '" & Trim(Me.TxtMoId.Text) & "','" & Trim(Me.TxtPalletID.Text.Trim) & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "'," & _
                 "@strmsgid output,@strmsgText output,@qty output select @strmsgid ,isnull(@strmsgText,'') ,@qty "
            End If

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1" To "3"
                        WorkStantOption.ErrorStr = dt.Rows(0)(1).ToString()
                        SetMessage("Fail", WorkStantOption.ErrorStr)
                        WorkStantOption.BarCodeStr = TxtPalletID.Text
                        WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                        ShowFrmScanErrPrompt()
                        SetMessage("PASS", "已解锁，请继续进行作业")
                        TxtPalletID.Text = ""
                        Me.TxtPalletID.Focus()

                        PlaySimpleSound(1)
                        Exit Sub
                    Case "4"
                        DGridBarCode.Rows.Clear()
                        'LblPackQty 应装产品  实装 LblCurrQty
                        'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                        LblPackQty.Text = "0"
                        LblCurrQty.Text = "0"
                        LblCurrCarQty.Text = "0"
                        If scanSetting.vPalletSame = "Y" Then
                            TxtPalletID.Text = dt.Rows(0)(3).ToString
                        End If
                        LblCartonQty.Text = CInt(dt.Rows(0)(2).ToString)

                        'Add by cq20170714 
                        If (Me.chkIsHWASN.Checked = True) AndAlso (Not String.IsNullOrEmpty(m_strQRCode)) Then
                            Call RecordQRCodeInfo(Trim(TxtPalletID.Text))
                            m_strQRCode = ""
                        End If

                        SetMessage("PASS", "栈板标签序号扫描成功！")
                        TxtPalletID.Enabled = False
                        ControlState(False)
                        PlaySimpleSound(0)
                End Select
            Else
                WorkStantOption.ErrorStr = "系统无法识别此栈板标签序号"
                SetMessage("Fail", WorkStantOption.ErrorStr)
                WorkStantOption.BarCodeStr = TxtPalletID.Text
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                TxtPalletID.Text = ""
                Me.TxtPalletID.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtPalletID.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "PalletIDScanHandle", "sys")
            MessageUtils.ShowInformation("有异常发生，请联系管理员!" + errMsg.ToString)
            Exit Sub
        End Try

    End Sub

    '功能解鎖-
    Private Sub WorkStantOptionUnLock()

        WorkStantOption.ErrorStr = "此功能需要品管解鎖后才能使用！"
        SetMessage("Fail", "此功能需要品管解鎖后才能使用!")
        WorkStantOption.BarCodeStr = ""
        WorkStantOption.vMainBarCode = ""
        ShowFrmScanErrPrompt()
        SetMessage("PASS", "已解锁，请继续进行作业")
    End Sub

#End Region

#Region "方法"

    '条码验证样式
    Private Function CheckStyle(ByRef BarCode As String) As Boolean

        '********************************20170206 田玉琳 Start ****************************************************
        '扫描条码样式不能为空
        If TxtSnStyle1.Text.Trim.Length = 0 Then
            WorkStantOption.ErrorStr = "扫描条码样式不能为空！"
            SetMessage("Fail", "扫描条码样式不能为空！")
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Return False
        End If
        '********************************20170206 田玉琳 End ****************************************************

        '********************************20160615 田玉琳 Start ****************************************************
        '非系统打印条码要求验证样式
        ' 田玉琳 20161101 
        '系统条码也要验证样式（有子件处理）IsHaveChildCode IsPrtSelf <> "Y" And 

        ' 田玉琳 20171128 系统条码也需要验证样式，修改判断条件 
        'If (IsHaveChildCode = "Y" Or IsPrtSelf <> "Y") And TxtSnStyle1.Text.Trim.Length <> 0 Then
        If TxtSnStyle1.Text.Trim.Length <> 0 Then
            If BarCode.Trim.Length <> TxtSnStyle1.Text.Length Then
                WorkStantOption.ErrorStr = "扫描条码长度不对"
                SetMessage("Fail", "扫描条码长度不对")
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Return False
            End If

            If TextHandle.verfyBarCodeStyle(TxtSnStyle1.Text, BarCode, TxtSnStyle2.Text) = False Then
                WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                SetMessage("FAIL", "條碼不符合標準樣式")
                'PlaySimpleSound(1)
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Return False
            End If
        End If
        '********************************20160615 田玉琳 End ****************************************************

        '********************************20160617 田玉琳 Start ---Change by hs ke 20160927 ****************************************************
        '有子条码时，不对子条码验证，只对主条码验证 20170314 田玉琳
        '增加对验证条码流水和唯一性处理
        If scanSetting.vCurrentStandIndex = 1 And scanSetting.vRepeatStyle = "Y" Then
            If txt_tmpbarcode.Text = "" Then
                txt_tmpbarcode.Text = TxtBarCode.Text.Trim

                SetMessage("PASS", BarCode & Space(3) & "扫描成品条码成功，请继续扫描校验条码！")

                If paraArrays(CheckCurIndex).ToString.ToLower = "@ppid" Then
                    TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                    TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                Else
                    CheckCurIndex = 0
                    Dim styles() As String = paraArrays(CheckCurIndex).Split("|")
                    If styles(0) = "@ppid" Then
                        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                    Else
                        TxtSnStyle1.Text = styles(0)
                        TxtSnStyle2.Text = styles(0)
                    End If
                End If

                TxtBarCode.Clear()
                TxtBarCode.Focus()
                Return False
            Else
                Dim styles() As String = paraArrays(CheckCurIndex).Split("|")
                Dim str As String = styles(0)
                If str = "@ppid" Then
                    str = txt_tmpbarcode.Text
                End If

                If BarCode.Length = str.Length AndAlso TextHandle.verfyBarCodeStyle(str, TxtBarCode.Text, str) Then
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
                    End If
                    SetMessage("PASS", "校验码" & CheckCurIndex + 1 & "{" & BarCode & "}校验成功，请继续扫描下一个校验条码！")
                    TxtBarCode.Clear()
                    TxtBarCode.Focus()
                    If CheckCurIndex = paraArrays.Length - 1 Then
                        '扫描完成最后一个，样式返回第一个
                        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                        BarCode = txt_tmpbarcode.Text
                        TxtBarCode.Text = BarCode
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
        '********************************20160617 田玉琳 Start ---Change by hs ke 20160927 ****************************************************
        Return True
    End Function

    '条码验证样式
    Private Function CheckStyleC(ByRef BarCode As String) As Boolean
        '**************************非系统箱条码扫描 20161220 开始******************************************
        '非系统打印箱条码要求验证样式

        '不是自动生成外箱
        '取得是否检查箱样式 田玉琳 20171215 
        If IsCheckCartonStyle = "Y" And scanSetting.IsOnlineGenCartonID = False And lblCartonStyle.Text.Trim.Length <> 0 Then
            If BarCode.Trim.Length <> TxtSnStyle1.Text.Length Then
                WorkStantOption.ErrorStr = "扫描箱条码长度不对"
                SetMessage("Fail", "扫描箱条码长度不对")
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
                PlaySimpleSound(1)
                Exit Function
            End If

            If TextHandle.verfyBarCodeStyle(TxtSnStyle1.Text, BarCode, TxtSnStyle2.Text) = False Then
                WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                SetMessage("FAIL", "條碼不符合標準樣式")
                'PlaySimpleSound(1)
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
                PlaySimpleSound(1)
                Exit Function
            End If
        End If
        '**************************非系统箱条码扫描 20161220 结束******************************************
        '********************************20170323 田玉琳 Start  ****************************************************
        '增加对验证条码流水和唯一性处理
        If IsRepeatStyleC = "Y" Then
            If txt_tmpbarcode.Text = "" Then
                txt_tmpbarcode.Text = TxtCartonID.Text
                SetMessage("PASS", BarCode & Space(3) & "扫描成品箱条码成功，请继续扫描箱校验条码！")
                TxtCartonID.Clear()
                TxtCartonID.Focus()
                Return False
            Else
                If TxtCartonID.Text <> txt_tmpbarcode.Text Then
                    SetFailContent(BarCode, "校验码" & "{" & BarCode & "}校验不成功...Fail,请重新验证")
                    Return False
                End If
            End If
            txt_tmpbarcode.Text = ""
        End If
        '********************************20170323 田玉琳 End  ****************************************************

        '--------- add by cq 20171106  ---------------------
        If scanSetting.vCartonRepeatStyle = "Y" Then
            If txt_tmpbarcode.Text = "" Then
                txt_tmpbarcode.Text = TxtCartonID.Text.Trim

                SetMessage("PASS", BarCode & Space(3) & "扫描箱条码成功，请继续扫描校验条码！")

                If paraCartonArrays(CheckCartonCurIndex).ToString.ToLower = "@ppid" Then
                    TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                    TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                Else
                    CheckCartonCurIndex = 0
                    Dim styles() As String = paraCartonArrays(CheckCartonCurIndex).Split("|")
                    If styles(0) = "@ppid" Then
                        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                    Else
                        TxtSnStyle1.Text = styles(0)
                        TxtSnStyle2.Text = styles(0)
                    End If
                End If

                TxtCartonID.Clear()
                TxtCartonID.Focus()
                Return False
            Else
                Dim styles() As String = paraCartonArrays(CheckCartonCurIndex).Split("|")
                Dim str As String = styles(0)
                If str = "@ppid" Then
                    str = txt_tmpbarcode.Text
                End If

                If BarCode.Length = str.Length AndAlso TextHandle.verfyBarCodeStyle(str, TxtCartonID.Text, str) Then
                    If styles.Length > 1 Then
                        '要求验证条码流水号
                        If styles(1) = "10" Or styles(1) = "11" Then
                            If iCartonStartindex + iCartonStartLength <> txt_tmpbarcode.Text.Length Then
                                SetFailContent(BarCode, String.Format("请检查料件打印参数料号[{0}]设置参数代码对应的参数值的正确性", TxtPartid.Text))
                                Return False
                            End If
                            Dim ppidssss As String = txt_tmpbarcode.Text.Substring(iCartonStartindex, iCartonStartLength)
                            Dim checkssss As String = BarCode.Substring(str.IndexOf("*"), str.LastIndexOf("*") - str.IndexOf("*") + 1)
                            '流水不一致
                            If ppidssss <> checkssss Then
                                SetFailContent(BarCode, String.Format("校验码{0}[{1}]流水[{2}]校验不成功...Fail,请重新验证", CheckCartonCurIndex + 1, BarCode, checkssss))
                                Return False
                            End If
                        End If
                        '要求验证唯一性 保存到数据库中
                        If styles(1) = "01" Or styles(1) = "11" Then
                            If CheckppidIsRepeat(BarCode) = False Then
                                SetFailContent(BarCode, String.Format("校验码{0}[{1}]流水码重复扫描...Fail,请重新验证", CheckCartonCurIndex + 1, BarCode))
                                Return False
                            End If
                            '成功验证插入到表中
                            InsertAssysnCheck(BarCode, txt_tmpbarcode.Text)
                        End If
                    End If
                    SetMessage("PASS", "校验码" & CheckCartonCurIndex + 1 & "{" & BarCode & "}校验成功，请继续扫描下一个校验条码！")
                    TxtCartonID.Clear()
                    TxtCartonID.Focus()
                    If CheckCartonCurIndex = paraCartonArrays.Length - 1 Then
                        '扫描完成最后一个，样式返回第一个
                        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                        BarCode = txt_tmpbarcode.Text
                        TxtCartonID.Text = BarCode
                        txt_tmpbarcode.Text = ""
                        CheckCartonCurIndex = 0
                        Return True
                    Else
                        CheckCartonCurIndex = CheckCartonCurIndex + 1
                        Dim NextStr As String = paraCartonArrays(CheckCartonCurIndex).Split("|")(0)
                        If NextStr = "@ppid" Then
                            NextStr = txt_tmpbarcode.Text
                        End If
                        TxtSnStyle1.Text = NextStr
                        TxtSnStyle2.Text = NextStr
                        Return False
                    End If
                Else
                    SetFailContent(BarCode, "校验码" & CheckCartonCurIndex + 1 & "{" & BarCode & "}校验不成功...Fail,请重新验证")
                    Return False
                End If
            End If
            CheckCartonCurIndex = CheckCartonCurIndex + 1
        End If
        '-------  end add by cq  20171106-------------------

        Return True
    End Function

    '验证栈板样式
    Private Function CheckStyleP(BarCode As String) As Boolean
        If BarCode.Trim.Length <> TxtSnStyle1.Text.Length Then
            WorkStantOption.ErrorStr = "扫描箱栈板长度不对"
            SetMessage("Fail", "扫描箱栈板长度不对")
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            TxtPalletID.Text = ""
            Me.TxtPalletID.Focus()
            PlaySimpleSound(1)
            Exit Function
        End If

        If TextHandle.verfyBarCodeStyle(TxtSnStyle1.Text, BarCode, TxtSnStyle2.Text) = False Then
            WorkStantOption.ErrorStr = "條碼不符合標準樣式"
            SetMessage("FAIL", "條碼不符合標準樣式")
            'PlaySimpleSound(1)
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            TxtPalletID.Text = ""
            Me.TxtPalletID.Focus()
            PlaySimpleSound(1)
            Exit Function
        End If
        Return True
    End Function

    '验证大外箱样式
    Private Function CheckStyleBigC(BarCode As String) As Boolean
        If scanSetting.vBigCartonRepeatStyle = "Y" Then
            If txt_tmpbarcode.Text = "" Then
                txt_tmpbarcode.Text = TxtPalletID.Text.Trim

                SetMessage("PASS", BarCode & Space(3) & "扫描大外箱条码成功，请继续扫描校验条码！")

                If paraBigCartonArrays(CheckBigCartonCurIndex).ToString.ToLower = "@ppid" Then
                    TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                    TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                Else
                    CheckBigCartonCurIndex = 0
                    Dim styles() As String = paraBigCartonArrays(CheckBigCartonCurIndex).Split("|")
                    If styles(0) = "@ppid" Then
                        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                    Else
                        TxtSnStyle1.Text = styles(0)
                        TxtSnStyle2.Text = styles(0)
                    End If
                End If

                TxtPalletID.Clear()
                TxtPalletID.Focus()
                Return False
            Else
                Dim styles() As String = paraBigCartonArrays(CheckBigCartonCurIndex).Split("|")
                Dim str As String = styles(0)
                If str = "@ppid" Then
                    str = txt_tmpbarcode.Text
                End If

                If BarCode.Length = str.Length AndAlso TextHandle.verfyBarCodeStyle(str, TxtPalletID.Text, str) Then
                    If styles.Length > 1 Then
                        '要求验证条码流水号
                        If styles(1) = "10" Or styles(1) = "11" Then
                            If iBigCartonStartindex + iBigCartonStartLength <> txt_tmpbarcode.Text.Length Then
                                SetFailContent(BarCode, String.Format("请检查料件打印参数料号[{0}]设置参数代码对应的参数值的正确性", TxtPartid.Text))
                                Return False
                            End If
                            Dim ppidssss As String = txt_tmpbarcode.Text.Substring(iBigCartonStartindex, iBigCartonStartLength)
                            Dim checkssss As String = BarCode.Substring(str.IndexOf("*"), str.LastIndexOf("*") - str.IndexOf("*") + 1)
                            '流水不一致
                            If ppidssss <> checkssss Then
                                SetFailContent(BarCode, String.Format("校验码{0}[{1}]流水[{2}]校验不成功...Fail,请重新验证", CheckBigCartonCurIndex + 1, BarCode, checkssss))
                                Return False
                            End If
                        End If
                        '要求验证唯一性 保存到数据库中
                        If styles(1) = "01" Or styles(1) = "11" Then
                            If CheckppidIsRepeat(BarCode) = False Then
                                SetFailContent(BarCode, String.Format("校验码{0}[{1}]流水码重复扫描...Fail,请重新验证", CheckBigCartonCurIndex + 1, BarCode))
                                Return False
                            End If
                            '成功验证插入到表中
                            InsertAssysnCheck(BarCode, txt_tmpbarcode.Text)
                        End If
                    End If
                    SetMessage("PASS", "校验码" & CheckBigCartonCurIndex + 1 & "{" & BarCode & "}校验成功，请继续扫描下一个校验条码！")
                    TxtPalletID.Clear()
                    TxtPalletID.Focus()
                    If CheckBigCartonCurIndex = paraBigCartonArrays.Length - 1 Then
                        '扫描完成最后一个，样式返回第一个
                        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                        BarCode = txt_tmpbarcode.Text
                        TxtPalletID.Text = BarCode
                        txt_tmpbarcode.Text = ""
                        CheckBigCartonCurIndex = 0
                        Return True
                    Else
                        CheckBigCartonCurIndex = CheckBigCartonCurIndex + 1
                        Dim NextStr As String = paraBigCartonArrays(CheckBigCartonCurIndex).Split("|")(0)
                        If NextStr = "@ppid" Then
                            NextStr = txt_tmpbarcode.Text
                        End If
                        TxtSnStyle1.Text = NextStr
                        TxtSnStyle2.Text = NextStr
                        Return False
                    End If
                Else
                    SetFailContent(BarCode, "校验码" & CheckBigCartonCurIndex + 1 & "{" & BarCode & "}校验不成功...Fail,请重新验证")
                    Return False
                End If
            End If
            CheckBigCartonCurIndex = CheckBigCartonCurIndex + 1
        End If
        '-------  end add by cq  20180828 --------
        Return True
    End Function

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

    '保存验证数据，为验证唯一性
    Private Sub InsertAssysnCheck(ppid As String, exppid As String)
        Dim strSQL As String = " EXEC m_InsertAssysnCheck_P '{0}','{1}','{2}','{3}','{4}','{5}' "
        strSQL = String.Format(strSQL, ppid, exppid, TxtMoId.Text, TxtLineId.Text, My.Computer.Name, VbCommClass.VbCommClass.UseId)

        DbOperateUtils.ExecSQL(strSQL)
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

    '保存验证数据，为验证唯一性
    Private Sub GetCartonCodeRuleIdSSSS(partid As String)
        Dim strSQL As String = " EXEC GetCodeRuleIdSSSS '{0}' "
        strSQL = String.Format(strSQL, partid)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            iCartonStartindex = Val(dt.Rows(0)(0).ToString)
            iCartonStartLength = Val(dt.Rows(0)(1).ToString)
        End If
    End Sub

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
            'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
            LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
        End If
        TxtBarCode.Text = ""
        Me.TxtBarCode.Focus()
    End Sub

    '显示称重打印窗体
    Private Sub OpenOnlineWeightForm(bFlag As Boolean)
        Dim frm As New FrmOnlineWeightPrint
        frm.Moid = TxtMoId.Text.Trim
        frm.PartId = TxtPartid.Text.Trim
        frm.LabelNum = scanSetting.LabelNum
        frm.PrintName = Me.cboPrinterList.Text.Trim
        frm.CartonId = TxtCartonID.Text
        frm.SetTabVisible = bFlag
        frm.IsLinePrintFullCode = scanSetting.IsLinePrintFullCode
        frm.UpLimitWeight = scanSetting.UpLimitWeight
        frm.LowLimitWeight = scanSetting.LowLimitWeight
        frm.ShowDialog()
    End Sub

    '装满箱后打印条码
    Private Sub PrintFullCarton()
        Dim printBarcode As New PrintBarcode
        printBarcode.btApp = btApp
        printBarcode.btFormat = btFormat
        printBarcode.PrintName = Me.cboPrinterList.Text.Trim
        Dim alist As ArrayList = New ArrayList
        alist.Add(TxtPartid.Text)  '料号
        alist.Add(LblPackQty.Text) '包装数量
        alist.Add(TxtBarCode.Text.Substring(4, 2)) '扫描的条码的周别
        printBarcode.PrintL01FullCarton(TxtCartonID.Text, scanSetting.LabelNum, alist)
    End Sub

    '打开产品看板
    Private Sub OpenProductionBoard()

        If (scanSetting.MoidStr Is Nothing) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtBarCode.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtBarCode.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        '显示看板页面
        If (frmBoard Is Nothing) Then
            frmBoard = New FrmProductionBoard
            frmBoard.PmoidID = TxtMoId.Text.Trim
            frmBoard.PLineId = TxtLineId.Text.Trim
            frmBoard.Show()
        ElseIf frmBoard IsNot Nothing AndAlso frmBoard.IsDisposed Then
            frmBoard = New FrmProductionBoard
            frmBoard.PmoidID = TxtMoId.Text.Trim
            frmBoard.PLineId = TxtLineId.Text.Trim
            frmBoard.Show()
        Else
            frmBoard.Activate()
        End If
    End Sub

    '设置装箱数 设置目前第几箱数量
    Private Sub LoadPalletPaceQty()
        'update by hgd 2017-09-05 加入站点判断
        Dim dt As DataTable = DbOperateUtils.GetDataTable(" select isnull(count(Cartonid),0) packcount from m_carton_t where moid='" & Me.TxtMoId.Text & "' AND StationId='" & scanSetting.vStandId & "' ")

        If dt.Rows.Count > 0 Then
            LabCartonQty.Text = dt.Rows(0)("packcount").ToString
        End If
    End Sub

    Private Sub ControlState(ByVal BorC As Boolean)

        If BorC Then
            TxtCartonID.Enabled = False
            TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
            'TxtCartonID.BackColor = Color.White
            If IsReadSn = "Y" Then
                Me.TxtBarCode.WordWrap = True
                Me.TxtBarCode.Multiline = True
            End If
            TxtBarCode.Enabled = True
            TxtBarCode.BackColor = Color.White
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            SetScanCodeStyle("S")
        Else
            If TgenCarton = "N" Then
                TxtCartonID.Enabled = True
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtBarCode.BorderColor = Color.FromArgb(209, 31, 73)
                TxtBarCode.Enabled = False
                'TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                ''TxtCartonID.BackColor = Color.White
                If scanSetting.vCurrentStandIndex = 1 Then
                    TxtCartonID.Text = ""
                End If

                Me.TxtCartonID.Focus()
                SetScanCodeStyle("C")
                If IsReadSn = "Y" Then
                    Me.TxtBarCode.WordWrap = True
                    Me.TxtBarCode.Multiline = True
                End If
            Else
                TxtCartonID.Enabled = False
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtCartonID.BackColor = Color.White
                If IsReadSn = "Y" Then
                    Me.TxtBarCode.WordWrap = True
                    Me.TxtBarCode.Multiline = True
                End If
                TxtCartonID.Text = "GeneratePalletNo"
                TxtBarCode.Enabled = True
                TxtBarCode.BackColor = Color.White
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                SetScanCodeStyle("C")
            End If
        End If
    End Sub

    Private Sub ControlState(ByVal BorC As Boolean, ByVal isScanPallet As Boolean)
        If BorC Then
            TxtCartonID.Enabled = False
            TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
            TxtCartonID.BackColor = Color.White
            TxtBarCode.Enabled = True
            TxtBarCode.BackColor = Color.White
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
        Else
            If isScanPallet Then
                TxtCartonID.Enabled = False
                TxtBarCode.Enabled = False
                TxtPalletID.Enabled = True
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                TxtBarCode.Text = ""
                TxtPalletID.Text = ""
                TxtCartonID.Text = ""
                Me.TxtPalletID.Focus()
            Else
                TxtCartonID.Enabled = True
                TxtPalletID.Enabled = False
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                TxtBarCode.Enabled = False
                TxtBarCode.Enabled = False
                TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                ''TxtCartonID.BackColor = Color.White
                TxtCartonID.Text = ""
                TxtBarCode.Text = ""
                Me.TxtCartonID.Focus()
            End If
        End If

    End Sub

    ''' <summary>
    ''' 在线生成箱号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OnlineCartonID() As String
        Dim ServerDate As New DateTime ''''服務器日期時間
        Dim PackBarCode As New PrintJLabelNew
        Dim TimeSqlstr As String = ""

        OnlineCartonID = ""
        PackArray.AvcPartid = Me.TxtPartid.Text.Trim 'AVC料號
        PackArray.CusName = scanSetting.CustStr ' 客戶名稱
        PackArray.Deptid = scanSetting.DpetId ' '部門
        PackArray.Lineid = scanSetting.LineStr ' Me.TxtLineId.Text.Trim  '線別
        PackArray.Moid = Me.TxtMoId.Text.Trim   '工單
        TimeSqlstr = "select getdate() as nowtime"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(TimeSqlstr)
        If dt.Rows.Count > 0 Then
            ServerDate = CDate(dt.Rows(0)("nowtime").ToString)
        End If
        PackArray.NowDate = ServerDate.AddHours(-7.5).ToString("yyyy-MM-dd").ToString ''服務器日期
        PackArray.NowMonth = ServerDate.AddHours(-7.5).ToString("MM").ToString ''服務器月份
        PackArray.Qty = scanSetting.PartPackQty '

        PackBarCode.StaionId = scanSetting.vStandId
        PackBarCode.StaionName = scanSetting.vStandName
        If PackBarCode.MarkJLabel(PackArray.ToArray, "Y") Then
            If String.IsNullOrEmpty(PackBarCode.m_CartonID) Then
                OnlineCartonID = PackBarCode.JLabelStr ''生成箱號
            Else
                OnlineCartonID = PackBarCode.m_CartonID
            End If
            '是否尾箱号
            IsTrunk = PackBarCode.IsTrunk
        Else
            If PackBarCode.m_CartonID = "00000000" Then
                OnlineCartonID = "00000000"
                SetMessage("PASS", "该工单已扫描完成！")
            End If
        End If
    End Function

    Private Sub DisposeData()
        scanSetting.PackNumber = Nothing
        scanSetting.BarCodeStr = Nothing
        scanSetting.DpetNameStr = Nothing
        scanSetting.ErrorStr = Nothing
        scanSetting.GflenStr = Nothing
        ' scanSetting.LengthStr = Nothing
        scanSetting.LineStr = Nothing
        scanSetting.MoCustStr = Nothing
        scanSetting.MoidqtyStr = Nothing
        'scanSetting.MoidStr = Nothing
        scanSetting.PartidStr = Nothing
        scanSetting.PartPackQty = Nothing
        scanSetting.PrintPort = Nothing
        scanSetting.SnidStr = Nothing
        scanSetting.SnStyleStr1 = Nothing
        scanSetting.SnStyleStr2 = Nothing
        scanSetting.TimeStr = Nothing
        scanSetting.CustStr = Nothing
        ''''''''''''''''
        scanSetting.moType = Nothing
        ''''''''''''''''''''''''''''''''''

        scanSetting.CustIdString = Nothing
        scanSetting.InCartonScanCheck = False

        scanSetting.vStandId = Nothing
        scanSetting.vStandName = Nothing
        scanSetting.vCurrentStandIndex = Nothing
        scanSetting.vStandMaxStaIndex = Nothing
        scanSetting.vTimeStyleSet = Nothing
        Array.Clear(scanSetting.vstyleArray, 0, scanSetting.vstyleArray.Length)
        scanSetting.vStandIndex = Nothing
        scanSetting.TimeStr = Nothing

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
        Dim FrmError As New FrmScanErrPrompt(scanSetting)
        FrmError.ShowDialog()
    End Sub

    Private Sub SetScanCodeStyle(type As String)
        If type = "P" Then
            TxtSnStyle1.Text = lblPalletStyle.Text
            TxtSnStyle2.Text = lblPalletStyle2.Text
            TxtBarCode.Text = ""
            LblMainBarCode.Text = ""
        ElseIf type = "C" Then
            TxtSnStyle1.Text = lblCartonStyle.Text
            TxtSnStyle2.Text = lblCartonStyle2.Text
            TxtBarCode.Text = ""
            LblMainBarCode.Text = ""
        Else '产品条码

            'hgd 2017-07-04 注释掉
            'scanSetting.vCurrentStandIndex = 1
            '1511T-170800108
            ' If Me.TxtPartid.Text = "L99U2041-CS-H" And Me.TxtMoId.Text.Substring(0, 8) = "1511T-17" Then
            ' TxtSnStyle1.Text = "04071190-U2041-17**"
            ' TxtSnStyle2.Text = "04071190-U2041-17**"
            ' LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
            'Else
            TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
            TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
            LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
        End If
    End Sub

    '系统打印箱样式取得
    Private Function GetIsSelfCarton() As Boolean
        Dim strSQL As String =
            " select CodeRuleID  from m_partpack_t " &
            " where  partid='{0}' and usey='Y'  and (DisorderTypeId = 'C' and Packid = 'N' or Packid = 'C') order by cast(Qty as int) desc,PackingLevel desc "
        strSQL = String.Format(strSQL, TxtPartid.Text)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If dt.Rows.Count > 0 Then
            Dim ruleID As String = dt.Rows(0)(0).ToString
            SetCartonStyle(ruleID)
            Return True
        Else
            Return False
        End If
    End Function

    '非系统单码扫描，如固定码，直接insert DB，流水码 卡样式
    Private Function GetNonSelfCarton() As Boolean
        '只支持无流水码外箱
        If CODERULEID = "" Then Return False

        Dim ruleID As String = CODERULEID.Split("/")(2)
        SetCartonStyle(ruleID)
        Return True
    End Function

    Private Sub SetCartonStyle(ruleID As String)
        'cq20170912,add moid input, modify style 70-> 200, cq20171228
        Dim strSQL As String =
        " DECLARE @SnStyle1 varchar(200),@SnStyle2 varchar(200),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2='' set @Gflen='' " & _
        " EXECUTE m_StyleShow_p_AssembleSta_C '" & TxtPartid.Text & "','" & ruleID & "','" & scanSetting.vLabelDate & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output,'" & Me.TxtMoId.Text & "' " & _
        " SELECT @SnStyle1,@SnStyle2,@Gflen"
        Using dt1 As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt1.Rows.Count > 0 Then
                lblCartonStyle.Text = dt1.Rows(0)(0).ToString
                lblCartonStyle2.Text = dt1.Rows(0)(1).ToString
            End If
        End Using
    End Sub

    Private Sub SetPalletStyle(ruleID As String)
        Dim strSQL As String =
        " DECLARE @CodeRuleId varchar(200) " &
        " SELECT @CodeRuleId = CodeRuleID from m_PartPack_t where partid = '" + TxtPartid.Text + "' and usey='Y' and (DisorderTypeId = 'P' and Packid = 'N' or Packid = 'P') " &
        " DECLARE @SnStyle1 varchar(200),@SnStyle2 varchar(200),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2='' set @Gflen='' " & _
        " EXECUTE m_StyleShow_p_AssembleSta_P '" & TxtPartid.Text & "',@CodeRuleId,'" & scanSetting.vLabelDate & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output  " & _
        " SELECT @SnStyle1,@SnStyle2,@Gflen"
        Using dt1 As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt1.Rows.Count > 0 Then
                lblPalletStyle.Text = dt1.Rows(0)(0).ToString
                lblPalletStyle2.Text = dt1.Rows(0)(1).ToString
            End If
        End Using
    End Sub

    '记录HW二维码信息信息,cq 20170713
    Private Sub RecordQRCodeInfo(ByVal packBarCode As String)
        Try
            Dim strSQL As New StringBuilder
            strSQL.Append(" DECLARE @RTVALUE varchar(10), @strmsgText varchar(50) ")
            strSQL.Append(" EXECUTE [m_RecordHWQRCodeInfo_P] '" & Trim(TxtMoId.Text) & "', '" & TxtLineId.Text.Trim & "', '" & m_strQRCode & "','" & packBarCode & "',")
            strSQL.Append(" '" & My.Computer.Name & "', '" & VbCommClass.VbCommClass.UseId & "',@RTVALUE OUTPUT, @strmsgText OUTPUT ")
            strSQL.Append(" SELECT @RTVALUE,@strmsgText")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        SysMessageClass.WriteErrLog(dt.Rows(0)(1), "FrmHWPackScan", "RecordQRCodeInfo", "BarCodeScan")
                    Case "1"
                        'OK
                    Case Else
                        'do nothing
                End Select
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmHWPackScan", "RecordQRCodeInfo", "BarCodeScan")
        End Try
    End Sub

#Region "聲音播放"

    '取得声音播放参数 
    Private Sub SetWavPlayTime()
        Dim result As String = ""
        Dim strSQL As String = "select TEXT from m_BaseData_t where [ITEMKEY] = '{0}' "
        strSQL = String.Format(strSQL, "WavPlayTime")

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            okWavPlayTime = dt.Rows(0)(0).ToString
            ngWavPlayTime = dt.Rows(1)(0).ToString
        Else
            okWavPlayTime = 700
            ngWavPlayTime = 2000
        End If
    End Sub

    Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        If (Me.chbMessage.Checked) Then
            Select Case PassOrNg
                Case 0 '正常提示音
                    My.Computer.Audio.Play(My.Resources.Resource1.ok_zhcn, AudioPlayMode.Background)
                    'BeepUp.Beep(500, okWavPlayTime)
                    If VbCommClass.VbCommClass.Factory = "BZLANTO" Then
                        If cbIsCom.Checked Then
                            Try
                                RS232.DiscardInBuffer()  '清空接收缓冲区     
                                RS232.WriteLine("PASS")
                                Threading.Thread.Sleep(100)
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                        End If
                    End If
                Case 1 '错误提示音
                    My.Computer.Audio.Play(My.Resources.Resource1.fail_zhcn, AudioPlayMode.Background)
                    'BeepUp.Beep(2800, ngWavPlayTime)
                Case 2
                    'My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)
            End Select
        End If
    End Sub


#End Region

    '取得是否检查箱样式 
    Private Sub GetIsCheckCartonStyle()
        Dim strSQL As String = " exec  GetIsCheckCartonStyle  '{0}' "
        strSQL = String.Format(strSQL, TxtMoId.Text)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            IsCheckCartonStyle = dt.Rows(0)(0).ToString
        End If
    End Sub
    '打印群组 
    Private Function GetPrintGroup(ByVal partid As String)
        Dim strSQL As String = " select groupid from m_L01PrintGroup_t where partid= '{0}' "
        strSQL = String.Format(strSQL, partid)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString
        Else
            Return ""
        End If
    End Function
#Region "Com传输"
    Private Sub OpenSerialPort()

        Dim mBaudRate As Integer
        Dim mParity As IO.Ports.Parity
        Dim mDataBit As Integer
        Dim mStopBit As IO.Ports.StopBits
        Dim mPortName As String

        '默认COM20 避免冲突
        mPortName = "COM20"
        mBaudRate = "9600"
        mParity = Parity.None
        mDataBit = 8
        mStopBit = StopBits.One

        RS232 = New IO.Ports.SerialPort(mPortName, mBaudRate, mParity, mDataBit, mStopBit)

        Try
            If Not RS232.IsOpen Then
                RS232.Open()
                RS232.Encoding = Encoding.UTF8
                lblMessage.Text = "端口已打开..."
            Else
                lblMessage.Text = "端口打开时发生错误..."
            End If
        Catch ex As Exception
            lblMessage.Text = "端口打开时发生错误..."
        End Try
    End Sub

    Private Sub cbIsCom_CheckedChanged(sender As Object, e As EventArgs) Handles cbIsCom.CheckedChanged
        If cbIsCom.Checked Then
            OpenSerialPort()
        Else
            If RS232 IsNot Nothing And RS232.IsOpen Then
                RS232.Close()
            End If
        End If
    End Sub

#End Region

    ''' <summary>
    ''' 设置菜单权限-用户权限设定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMenuRight()
        Me.toolSpecialScanSet.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolSpecialScanSet.Tag) = "YES", True, False)

    End Sub

#End Region


    ''' <summary>
    ''' Mac条码打印，输入mac 打印mac, 联想8合一
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim frm As New FrmOnlineWorkPrintMAC()
        ' frm.Moid = TxtMoId.Text.Trim
        frm.PartId = TxtPartid.Text.Trim
        ' frm.LabelNum = scanSetting.LabelNum
        frm.PrintName = Me.cboPrinterList.Text.Trim
        '  frm.PrintType = FrmCartonRepeatPrint.EnumPrintType.L01FullSn
        frm.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles toolPrintScanBarcode.Click
        Dim frm As New FrmOnlineWorkPrintScanBar()
        ' frm.Moid = TxtMoId.Text.Trim
        frm.PartId = TxtPartid.Text.Trim
        ' frm.LabelNum = scanSetting.LabelNum
        frm.PrintName = Me.cboPrinterList.Text.Trim
        '  frm.PrintType = FrmCartonRepeatPrint.EnumPrintType.L01FullSn
        frm.ShowDialog()
    End Sub
End Class