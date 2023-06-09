
'--新工站包装扫描
'--Create by :　田玉琳
'--Create date :　2016/08/02
'--更新日期 : 2016/10/13
'--更新内容 ：增加日志处理
'--更新日期 ：2017/04/06
'--更新内容 : 取得扫描数据内容
'--Ver : V01

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
Imports MainFrame
Imports SysBasicClass
Imports UIHandler
Imports System.Net
Imports System.Net.Sockets
Imports System.IO.Ports

#End Region

Public Class FrmAutoScanSendData

#Region "窗體變量"

    Dim IsFull As Boolean = False           '棧板是否裝滿
    Dim IsLinePrint As String = "N"         '是否在线打印产品条码
    Dim IsReadSn As String = "N"            '是否读取序号
    Dim TgenCarton As String = "N"          '自动生面外箱
    Dim IsPackingPPID As String = "N"       '是否产品序号相同（允许箱产品同包装）
    Dim IsPackType As String = "N"          '包装类型
    Dim IsPrtSelf As String = "N"           '是否在系统里面打印
    Dim IsTrunk As String = "N"             '田玉琳 
    Dim PackArray As New SysMessageClass.PrtStructure
    Public scanSetting As New ScanSetting
    Private scanCode As String              '扫描数据内容
    Dim scanparsKey As String = "AUTOSCANPATS232" '扫描端口相关内容取得KEY
    Dim MachineType As String = "1"         '东莞机台

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

    Dim serverip As String = ""
    Dim serverport As String = ""

    Dim IsPrtSelfCarton As String = "N"     '是否在系统里面打印外箱
    Dim CODERULEID As String = ""           '外箱编码原则
    Private m_strQRCodeOne As String = String.Empty '第一次扫描二维码（同时扫描华为和立讯二维码）
    Private m_strQRCodeTwo As String = String.Empty '第二次扫描二维码（同时扫描华为和立讯二维码）


    Dim plclib As PLCLib.PLCLib = New PLCLib.PLCLib
    '发送PLC枚举
    Enum ResultType
        RESET = 0
        OK = 1
        NG = 2
        NGSTOP = 3
    End Enum

#End Region
    '  Dim log As UIHandler.LogHelper
#Region "窗體事件"
    '快捷键
    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BnScanSet_Click(sender, e)
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select
    End Sub

    '初期化
    Private Sub FrmBarScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ERigth As New SysDataBaseClass
        ERigth.GetControlright(Me)
        SetMenuRight()

        TxtBarCode.Enabled = False
        LblMainBarCode.Text = ""
        LabResult.Text = ""
        txt_tmpbarcode.Text = ""  'add by cq20171121
        lblMessage.Text = "请设置扫描资料"
        ToolUsename.Text = VbCommClass.VbCommClass.UseName
        lblComputerName.Text = My.Computer.Name
    End Sub

    '外箱检查
    Private Sub tsbCheckCarton_Click(sender As Object, e As EventArgs) Handles tsbCheckCarton.Click
        Dim frm As FrmCheckCarton = New FrmCheckCarton

        frm.Customer = scanSetting.CustIdString
        frm.Moid = scanSetting.MoidStr

        frm.ShowDialog()
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
                Me.LblPackQty.Text = "0"
                Me.LblCurrQty.Text = "0"
                m_strQRCodeOne = ""
                m_strQRCodeTwo = ""
                'LblPackQty 应装产品  /实装 LblCurrQty/LblCartonQty(应装箱数) / 已装箱LblCurrCarQty
                TxtBarCode.Focus()
                'IsScanPallet = scanSetting.ScanPalletCheck ''是否掃描棧板
                'IsCustPart = scanSetting.CustPartCheck ''是否核對客戶料號
                'IsPrtPacking = scanSetting.PrtPackingCheck '是否在线打印外箱号
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

                '''''''獲取未裝滿外箱 '直接用箱的数据去取
                strSQL = " SELECT a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,isnull(a.PackingQuantity,0) AS qty " & _
                          " FROM M_Carton_t a  " & _
                          " WHERE a.Moid='{0}' and a.Teamid='{1}' and a.CartonStatus='N' order by a.Intime desc"
                strSQL = String.Format(strSQL, Me.TxtMoId.Text.Trim, Me.TxtLineId.Text.Trim)

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
                            '和包装扫描统一作删除处理，田玉琳 20190110 
                            'If CheckIsLoadCartonFinish(Me.TxtMoId.Text.Trim) = True Then
                            '    lblMessage.Text = "已装箱完成,请重新设置"
                            '    Exit Sub
                            'End If
                            CartonIDScanHandle()
                            ControlState(True)
                        Else
                            ControlState(False)
                        End If
                    End If
                End If
                LoadPalletPaceQty()

                '写日志初期化设置
                'Dim IsWrite As String = "false"
                'Dim logFilePath As String = ""
                'GetLogHelperPars(IsWrite, logFilePath)
                'logFilePath = logFilePath + "\" + Me.TxtLineId.Text.Trim
                'log = New LogHelper(IsWrite, logFilePath)

                '**********************写日志处理  开始*****************************************************
                'log.WriteLog(String.Format("成功设置工单{0}参数", Me.TxtMoId.Text.Trim))
                '**********************写日志处理  结束*****************************************************
                '自动扫描初始化
                SendMessageInit()
                '**********************写日志处理  开始*****************************************************
                'log.WriteLog("自动初始化成功！")
                '**********************写日志处理  结束*****************************************************

                '20161027 田玉琳 删除非今天扫描条码
                DeleteAutoScanData()

                'Add by cq 20170221, Record the set line info
                Call RecordLineInfo()

                '取得是否检查箱样式
                GetIsCheckCartonStyle()

                '
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
            End If
            TxtBarCode.Focus()
            scanSetting.CheckStr = False
            SendModbusQTY()
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
        End If
    End Sub

    '箱号输入后事件
    Private Sub TxtCartonID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCartonID.KeyPress
        If e.KeyChar = Chr(13) Then
            CartonIDScanHandle()
        End If
    End Sub

    '尾数箱參數設置
    Private Sub ToolOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
        '' End If
    End Sub


    Private Sub toolCOMSet_Click(sender As Object, e As EventArgs) Handles toolCOMSet.Click
        Dim FrmCOMSet As New FrmCOMSet()
        FrmCOMSet.ShowDialog()
        cmbCOM.Text = FrmCOMSet.txtCOMValue.Text.Trim
        '自动扫描初始化
        SendMessageInit()
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
        Me.chkHwAsnLxAsn.Enabled = True
    End Sub

    Private Sub FrmStantPackScan_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If RS232.IsOpen Then  '開啟
            RS232.Close()
        End If
        If plclib.SerialPort1.IsOpen Then
            plclib.SerialPort1.Close()
        End If
        DisposeData()
        scanSetting.CustIdString = Nothing
        scanSetting.MoidStr = Nothing
        scanSetting.LengthStr = Nothing
        scanSetting.DateCheck = Nothing
    End Sub


    '记录自动扫描的设置线别信息,cq 20170221
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
                        SysMessageClass.WriteErrLog(dt.Rows(0)(1), "FrmAutoScanSendDate", "RecordLineInfo", "BarCodeScan")
                    Case "1"
                        'OK
                    Case Else
                        'do nothing
                End Select
            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmAutoScanSendDate", "RecordLineInfo", "BarCodeScan")
        End Try
    End Sub

#End Region

#Region "獲取掃描記錄"
    Private Sub GetScanItem(ByVal Cartonid As String)
        Dim strSQL As String = " EXEC GetAutoScanList '{0}'"
        strSQL = String.Format(strSQL, Cartonid)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        Dim orderIndex As Integer = 0
        DGridBarCode.Rows.Clear()
        For iIndex As Integer = 0 To dt.Rows.Count - 1
            DGridBarCode.Rows.Add(dt.Rows(iIndex)!ppartid, dt.Rows(iIndex)!staorderid,
                                  dt.Rows(iIndex)!Ppid, dt.Rows(iIndex)!tparttext,
                                  dt.Rows(iIndex)!username, dt.Rows(iIndex)!intime)
        Next

        DGridBarCode.AutoResizeColumns()
    End Sub
#End Region

    '#Region "條碼掃描"
    ''' <summary>
    ''' 设置菜单权限-用户权限设定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMenuRight()
        Me.toolSpecialScanSet.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolSpecialScanSet.Tag) = "YES", True, False)

    End Sub

    Private Sub StandScan()

        If InStr(TxtBarCode.Text, "'") Then
            TxtBarCode.Clear()
            Exit Sub
        End If
        'LblPackQty 应装产品  实装 LblCurrQty ,LblCartonQty(应装箱数)  已装箱LblCurrCarQty
        Dim BarCode As String = Trim(TxtBarCode.Text)
        scanCode = Trim(TxtBarCode.Text) ' 扫描结果保存

        If Me.TxtMoId.Text = "" Then
            'MessageUtils.ShowError("請先設置好掃描基本信息!")
            'TxtBarCode.Text = ""
            'Me.TxtBarCode.Focus()
            'PlaySimpleSound(1)
            'Exit Sub
            'Modify by cq20171121
            WorkStantOption.ErrorStr = "請先設置好掃描基本信息!"
            SetMessage("Fail", "請先設置好掃描基本信息!")
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()

            'Add by cq20171121
            ShowFrmScanErrPromptLock()
            SetMessage("PASS", "已解锁，请继续进行作业")

            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If ''
        If BarCode = "" Then
            'MessageUtils.ShowError("產品條碼不能為空!")
            'TxtBarCode.Text = ""
            'Me.TxtBarCode.Focus()
            'PlaySimpleSound(1)
            'Exit Sub
            'Modify by cq 20171121
            WorkStantOption.ErrorStr = "產品條碼不能為空!"
            SetMessage("Fail", "產品條碼不能為空!")
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()

            'Add by cq20171121
            ShowFrmScanErrPromptLock()
            SetMessage("PASS", "已解锁，请继续进行作业")

            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        '********************************20160615 田玉琳 Start ****************************************************
        '非系统打印条码要求验证样式
        'TxtBarCode
        If IsPrtSelf <> "Y" And TxtSnStyle1.Text.Trim.Length <> 0 Then
            If BarCode.Trim.Length <> TxtSnStyle1.Text.Length Then
                WorkStantOption.ErrorStr = "扫描条码长度不对"
                SetMessage("Fail", "扫描条码长度不对")
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()
                'Add by cq20171121
                ShowFrmScanErrPromptLock()
                SetMessage("PASS", "已解锁，请继续进行作业")

                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If

            If TextHandle.verfyBarCodeStyle(TxtSnStyle1.Text, BarCode, TxtSnStyle2.Text) = False Then
                WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                SetMessage("FAIL", "條碼不符合標準樣式")
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                ShowFrmScanErrPrompt()

                'Add by cq20171121
                ShowFrmScanErrPromptLock()
                SetMessage("PASS", "已解锁，请继续进行作业")
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If
        '********************************20160615 田玉琳 End ****************************************************
        Dim dtstart As DateTime = Date.Now
        BarCode = Me.TxtBarCode.Text.Replace(vbNewLine, "").Trim()

        Dim IsWrite As String = "false"




        'log.WriteLog(String.Format("扫描起始时间{0}！", dtstart))
        '
        If CheckStyle(BarCode) = False Then Exit Sub

        '**********************写日志处理  开始*****************************************************
        'log.WriteLog(String.Format("扫描条码：{0}开始,执行存储过程！", BarCode))
        '**********************写日志处理  结束*****************************************************
        Dim Sqlstr As String = String.Empty

        '箱层级判断/料件号判断     'TxtBarCode  扫描箱号：判断工站扫描是装箱/装产品
        Try
            Dim tempstr() As String = scanSetting.vmReplaceArray(scanSetting.vCurrentStandIndex, 1).Split("|")
            Sqlstr = " DECLARE @strmsgid varchar(1), @strmsgText varchar(50), @currqty int, @currPqty int, @OutPQty int, @outPPID nvarchar(64) " & _
                     " EXECUTE [m_NewCheckPackScan_P] '" & Trim(BarCode) & "','',''," & _
                      "'" & Trim(TxtMoId.Text) & "','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                      "'" & scanSetting.PartidStr & "','" & tempstr(tempstr.Length - 1) & "','" & LblMainBarCode.Text.Trim & "'," & _
                      "'" & scanSetting.vStandId & "','" & scanSetting.vStandIndex & "','" & scanSetting.vCurrentStandIndex & "'," & _
                      "'" & scanSetting.vStandMaxStaIndex & "','" & Me.TxtCartonID.Text & "','','" &
                      Me.LblPackQty.Text & "','" & IsPackType.Trim & "','" & scanSetting.vSamePacking.Trim & "'," & _
                      " ''," & "'N'," & _
                      "@strmsgid output,@strmsgText output,@currqty output,@currPqty output, @OutPQty output,@OutPPID output " & _
                      "SELECT @strmsgid,@strmsgText,isnull(@currqty,1) as currqty,isnull(@currPqty,1) as currPqty, isnull(@OutPQty,0) as outPQty,@OutPPID as PPID"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                '**********************写日志处理  开始*****************************************************
                'If IsReadSQL = "true" Then
                '    log.WriteLog(String.Format("执行存储过程SQL：{0}", Sqlstr))
                'End If
                'log.WriteLog("执行存储过程结束！")
                '**********************写日志处理  结束*****************************************************
                Select Case dt.Rows(0)(0)
                    Case "0", "1", "2", "3"
                        WorkStantOption.ErrorStr = dt.Rows(0)(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "4" ''---掃描成功
                        PlaySimpleSound(0)
                        If scanSetting.vCurrentStandIndex = 1 Then
                            LblMainBarCode.Text = TxtBarCode.Text
                        End If
                        SetMessage("PASS", "扫描成功...")
                        '@OutPPID       
                        TxtBarCode.Text = dt.Rows(0).Item("PPID").ToString
                        scanSetting.vCurrentStandIndex = scanSetting.vCurrentStandIndex + 1
                        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                        'TxtBarCode.MaxLength = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 2)
                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"

                        '*****************************田玉琳 20170406 开始*****************************
                        Me.DGridBarCode.Rows.Insert(0, scanSetting.PartidStr, scanSetting.vStandIndex, _
                                    TxtBarCode.Text, scanSetting.PartidStr, SysMessageClass.UseId, Now())
                        If DGridBarCode.Rows.Count > 10 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If
                        '*****************************田玉琳 20170406 结束*****************************
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                        '发送信息到RS232机器中

                        SendMessageRs232(ResultType.OK)
                        Threading.Thread.Sleep(200) ' 暂停0.2秒


                        Exit Sub
                    Case "5"
                        WorkStantOption.ErrorStr = dt.Rows(0)(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "6"
                        PlaySimpleSound(0)
                        Me.LblCurrQty.Text = dt.Rows(0)(2)
                        Me.TxtBarCode.Text = dt.Rows(0)(5)
                        SetMessage("PASS", "扫描成功...")
                        'UseName ==》 userid, cq 20160127

                        scanSetting.vCurrentStandIndex = 1
                        TxtSnStyle1.Text = scanSetting.vstyleArray(1, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(1, 1)
                        'TxtBarCode.MaxLength = scanSetting.vstyleArray(1, 2)
                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                        '*****************************田玉琳 20170406 开始*****************************
                        Me.DGridBarCode.Rows.Insert(0, scanSetting.PartidStr, scanSetting.vStandIndex, _
                                    TxtBarCode.Text, scanSetting.PartidStr, SysMessageClass.UseId, Now())
                        If DGridBarCode.Rows.Count > 10 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If
                        '*****************************田玉琳 20170406 结束*****************************

                        LblMainBarCode.Text = ""
                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                        Dim dtdata As DateTime = Date.Now
                        Dim a1 As TimeSpan = dtdata - dtstart
                        'log.WriteLog(String.Format("数据执行开始{0},结束时间{1}！", BarCode & "===" & dtstart, dtdata & ",时间差(ms):" & a1.TotalMilliseconds))
                        '发送信息到RS232机器中
                        SendMessageRs232(ResultType.OK)
                        Threading.Thread.Sleep(200) ' 暂停0.2秒
                        If MachineType = "3" Then
                            SendMessageRs232(ResultType.OK)
                        End If
                        SendModbusQTY()
                        a1 = Date.Now - dtdata
                        'log.WriteLog(String.Format("发送信号开始{0},结束时间{1}！", BarCode & "===" & dtdata, Date.Now & ",时间差(ms):" & a1.TotalMilliseconds))

                        Exit Sub
                    Case "7"
                        PlaySimpleSound(0)
                        'Me.LabCartonQty.Text = RecDr.GetInt32(3)
                        Me.LblCurrQty.Text = dt.Rows(0)(2)
                        Me.TxtBarCode.Text = dt.Rows(0)(5)

                        SetMessage("PASS", BarCode & Space(3) & "该箱已经包装完成,请扫描下一箱...")
                        DGridBarCode.Rows.Clear()
                        'SetGridHeadColumn()
                        scanSetting.vCurrentStandIndex = 1
                        TxtSnStyle1.Text = scanSetting.vstyleArray(1, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(1, 1)
                        'TxtBarCode.MaxLength = scanSetting.vstyleArray(1, 2)
                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                        LblMainBarCode.Text = ""

                        If scanSetting.PrtPackingCheck Then
                            ControlState(False)
                            Me.TxtCartonID.Focus()
                        Else
                            If scanSetting.IsOnlineGenCartonID Then
                                '**************田玉琳 修改 20160419***********************Start 
                                If IsTrunk = "N" Then
                                    '自动进行下一箱操作
                                    Me.TxtCartonID.Text = OnlineCartonID()

                                    CartonIDScanHandle()
                                    SendMessageRs232(ResultType.OK)
                                    If MachineType = "3" Then
                                        Threading.Thread.Sleep(200) ' 暂停0.2秒
                                        SendMessageRs232(ResultType.OK)
                                    End If
                                    SendModbusQTY()
                                Else
                                    lblMessage.Text = "该工单全部扫描完成！"
                                    SendMessageRs232(ResultType.NGSTOP)
                                End If
                                '**************田玉琳 修改 20160419***********************End 
                            Else
                                SendMessageRs232(ResultType.OK)
                                If MachineType = "3" Then
                                    Threading.Thread.Sleep(200) ' 暂停0.2秒
                                    SendMessageRs232(ResultType.OK)
                                End If
                                ControlState(False)
                                Me.TxtCartonID.Focus()
                            End If
                        End If
                        LoadPalletPaceQty()
                        Exit Sub
                End Select
                'scanSetting.BarCodeStr = BarCode
                'scanSetting.vMainBarCode = Me.LblMainBarCode.Text
                'WorkStantOption.ErrorStr
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                SetMessage("FAIL", WorkStantOption.ErrorStr)
                '设置扫描错误时处理
                ShowFrmScanErrPrompt()

                'Add by cq20171121
                ShowFrmScanErrPromptLock()
                SetMessage("PASS", "已解锁，请继续进行作业")

                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation(ex.Message)
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtBarCode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "StandScan", "sys")
        End Try
    End Sub

    Private Sub ShowFrmScanErrPromptLock()
        Dim FrmError As New FrmScanErrPrompt(scanSetting)
        FrmError.ShowDialog()
    End Sub

    Private Sub CartonIDScanHandle()
        Dim Sqlstr As String = String.Empty
        Dim StrQty As Integer

        If Me.TxtPartid.Text = "" Then
            lblMessage.Text = "扫描资料未设置，请先设置..."
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If Me.TxtCartonID.Text = "" Then
            lblMessage.Text = "箱號條碼序號不能為空！"
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (scanSetting.MoidStr Is Nothing) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtCartonID.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtCartonID.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        Dim CartonIDStr As String = TxtCartonID.Text

        '***********************田玉琳 修改 20190605***********************Start 
        '勾选华为ASN扫描 二维码新规则代替外箱扫描 谢开太提出需求
        '华为ASN扫描和立讯ASN扫描
        If chkHwAsnLxAsn.Checked = True And (m_strQRCodeOne = "" Or m_strQRCodeTwo = "") Then
            'Dim chkIsHWASNValue As String = IIf(Me.chkHwAsnLxAsn.Checked, "Y", "N")
            Dim strSQL As String = ""
            strSQL = "declare @cartonId varchar(200), @Msg nvarchar(500),@ReturnValue int" & vbCrLf &
                     "exec m_NewCheckHWASNLXASN '{0}','{1}','{2}','{3}','{4}','{5}',@cartonId out,@Msg out,@ReturnValue out" & vbCrLf &
                     "select @cartonId,@Msg,@ReturnValue"
            If m_strQRCodeOne = "" Then
                m_strQRCodeOne = CartonIDStr
                strSQL = String.Format(strSQL, CartonIDStr, "", TxtMoId.Text, TxtPartid.Text, scanSetting.vStandId, 1)
            Else
                m_strQRCodeTwo = CartonIDStr
                strSQL = String.Format(strSQL, m_strQRCodeOne, m_strQRCodeTwo, TxtMoId.Text, TxtPartid.Text, scanSetting.vStandId, 2)
            End If

            Dim dtHWASN As DataTable = DbOperateUtils.GetDataTable(strSQL)
            '条码判断
            If dtHWASN.Rows(0)(2).ToString() = "0" Then '
                CartonIDStr = dtHWASN.Rows(0)(0).ToString '新箱号
                TxtCartonID.Text = CartonIDStr
            ElseIf dtHWASN.Rows(0)(2).ToString() = "1" Then '抛错误信息
                SetMessage("FAIL", dtHWASN.Rows(0)(1).ToString())
                Me.TxtCartonID.Text = ""
                m_strQRCodeOne = ""
                m_strQRCodeTwo = ""
                Me.TxtCartonID.Focus()
                PlaySimpleSound(1)
                Exit Sub
            ElseIf dtHWASN.Rows(0)(2).ToString() = "2" Then '二维码条码
                m_strQRCodeOne = TxtCartonID.Text.Trim
                SetMessage("PASS", dtHWASN.Rows(0)(1).ToString())
                Me.TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
                PlaySimpleSound(0)
                Exit Sub
            End If
        End If
        '***********************田玉琳 修改 20190605***********************End 

        'add by cq20171120
        If CheckStyleC(Trim(TxtCartonID.Text)) = False Then Exit Sub

        Try
            '2015-04-02     马锋       Me.TxtMoId.Text  Me.TxtLineId.Text
            Sqlstr = "DECLARE @strmsgid varchar(1),@strmsgText varchar(50),@NewCartonid varchar(100),@qty int, @palletQty float " & _
                "EXECUTE [m_NewCheckPallMulletCarton_p] " & _
                "'" & Trim(scanSetting.MoidStr) & "','" & Trim(TxtCartonID.Text) & "','','','" & Trim(scanSetting.LineStr) & "','" & SysMessageClass.UseId.Trim & "','" & scanSetting.vCartonSame.Trim & "','" & scanSetting.vSamePacking.Trim & "'," & _
                 "'N','" & scanSetting.vStandId.Trim & "',N'" & scanSetting.vStandName.Trim & "'," & _
                "@strmsgid output,@strmsgText output,@NewCartonid output,@qty output, @palletQty output " & _
                " SELECT @strmsgid ,isnull(@strmsgText,''),@qty ,@NewCartonid, @palletQty "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1" To "3"
                        PlaySimpleSound(1)
                        SetMessage("FAIL", dt.Rows(0)(1).ToString())
                        Me.TxtCartonID.Clear()
                        Exit Sub
                    Case "4"
                        PlaySimpleSound(0)
                        DGridBarCode.Rows.Clear()
                        'SetGridHeadColumn()
                        LblPackQty.Text = ""
                        LblCurrQty.Text = ""
                        StrQty = CInt(dt.Rows(0)(2).ToString)
                        If scanSetting.vCartonSame = "Y" Then
                            TxtCartonID.Text = dt.Rows(0)(3).ToString
                        End If

                        LblPackQty.Text = StrQty
                        Me.LblCurrQty.Text = 0

                        '***********************田玉琳 修改 20190605***********************Start 
                        If (Me.chkHwAsnLxAsn.Checked = True) AndAlso (Not String.IsNullOrEmpty(m_strQRCodeOne)) AndAlso (Not String.IsNullOrEmpty(m_strQRCodeTwo)) Then
                            Call RecordQRCodeInfoByHwLx(TxtCartonID.Text)
                            m_strQRCodeOne = ""
                            m_strQRCodeTwo = ""
                        End If
                        '***********************田玉琳 修改 20190605***********************End 

                        'LblPackQty 应装产品  实装 LblCurrQty 'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                        SetMessage("PASS", "外箱条码序号，扫描成功...")
                        ControlState(True)
                End Select
            Else
                SetMessage("FAIL", "系统无法识别此外箱标签序号！")
                Me.TxtCartonID.Text = ""
                PlaySimpleSound(1)
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtCartonID.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "CartonIDScanHandle", "sys")
            Exit Sub
        End Try
    End Sub

    '#End Region

#Region "方法"

    '条码验证样式
    Private Function CheckStyle(ByRef BarCode As String) As Boolean

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

    '箱条码验证样式
    Private Function CheckStyleC(ByRef BarCode As String) As Boolean

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

    '保存验证数据，为验证唯一性
    Private Sub InsertAssysnCheck(ppid As String, exppid As String)
        Dim strSQL As String = " EXEC m_InsertAssysnCheck_P '{0}','{1}','{2}','{3}','{4}','{5}' "
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
            'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
            LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
        End If
        TxtBarCode.Text = ""
        Me.TxtBarCode.Focus()
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
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                TxtBarCode.Text = ""
                TxtCartonID.Text = ""
            Else
                TxtCartonID.Enabled = True
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
        End If
    End Function

    Private Sub DisposeData()
        scanSetting.PackNumber = Nothing
        scanSetting.BarCodeStr = Nothing
        scanSetting.DpetNameStr = Nothing
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
        '报警
        PlaySimpleSound(1)
        '发送错误信息 到
        SendMessageRs232(ResultType.NG)
    End Sub

    '检查是否装完成
    'Private Function CheckIsLoadCartonFinish(moid As String) As Boolean
    '    Dim strSQL As String =
    '        " SELECT ISNULL((SELECT MOQTY FROM M_MAINMO_T WHERE MOID = '{0}')-ISNULL(SUM(PACKINGQUANTITY),0),0)  " &
    '        "  FROM M_CARTON_T  " &
    '        "  WHERE MOID = '{0}'"
    '    strSQL = String.Format(strSQL, moid)
    '    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
    '    If (dt.Rows.Count > 0) Then
    '        If Val(dt.Rows(0)(0)) = 0 Then '全部装箱完成
    '            Return True
    '        End If
    '    End If
    '    Return False
    'End Function

    '设置装箱数
    '设置目前第几箱数量
    Private Sub LoadPalletPaceQty()
        Dim dt As DataTable = DbOperateUtils.GetDataTable(" select isnull(count(Cartonid),0) packcount from m_carton_t where moid='" & Me.TxtMoId.Text & "' ")

        If dt.Rows.Count > 0 Then
            LabCartonQty.Text = dt.Rows(0)("packcount").ToString
        End If
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

    '取得是否检查箱样式 
    Private Sub GetIsCheckCartonStyle()
        Dim strSQL As String = " exec  GetIsCheckCartonStyle  '{0}' "
        strSQL = String.Format(strSQL, TxtMoId.Text)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            IsCheckCartonStyle = dt.Rows(0)(0).ToString
        End If
    End Sub

    '记录HW和立讯二维码信息信息,田玉琳 20190605
    Private Sub RecordQRCodeInfoByHwLx(ByVal packBarCode As String)
        Try
            Dim strSQL As New StringBuilder
            strSQL.Append(" DECLARE @RTVALUE varchar(10), @strmsgText varchar(500) ")
            strSQL.AppendFormat(" EXECUTE [m_RecordHWLXQRCodeInfo_P] '{0}','{1}','{2}','{3}','{4}','{5}','{6}',@RTVALUE OUTPUT, @strmsgText OUTPUT  ", Trim(TxtMoId.Text),
                                TxtLineId.Text.Trim, m_strQRCodeOne, m_strQRCodeTwo, packBarCode, My.Computer.Name, VbCommClass.VbCommClass.UseId)
            strSQL.Append(" SELECT @RTVALUE,@strmsgText")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0"
                        'OK
                    Case "1"
                        SysMessageClass.WriteErrLog(dt.Rows(0)(1), "FrmHWPackScan", "RecordQRCodeInfoByHwLx", "BarCodeScan")
                    Case Else
                        'do nothing
                End Select
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmHWPackScan", "RecordQRCodeInfo", "BarCodeScan")
        End Try
    End Sub
    '取得自动扫描参数 
    'Private Function GetLogHelperPars(ByRef IsWrite As Boolean, ByRef logFilePath As String) As String
    '    Dim result As String = ""
    '    Dim strSQL As String = "select TEXT,VALUE from m_BaseData_t where [ITEMKEY] = 'LogHelper' order by SORT asc "

    '    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

    '    If dt.Rows.Count = 0 Then
    '        IsWrite = False
    '        Return ""
    '    Else
    '        IsWrite = dt.Rows(0)(0).ToString        '是否写日志
    '        logFilePath = dt.Rows(1)(0).ToString    '写日志路径
    '        'IsReadSQL = dt.Rows(2)(0).ToString      '是否写存储过程SQL
    '    End If
    '    Return result
    'End Function

#Region "RS232处理"

    '发送日志初始化
    Private Sub SendMessageInit()
        Try
            Dim values As String = GetRs232Pars()

            If values <> "" Then

                If values.Split("|").Length <> 5 Then
                    MessageUtils.ShowError("连接设备的扫描参数设置格式不正确！")
                    Exit Sub
                End If
                If MachineType <> "4" Then
                    If RS232.IsOpen Then  '開啟
                        RS232.Close()
                    End If

                    '设置参数
                    RS232.PortName = values.Split("|")(0)  '欲開啟的通訊埠
                    RS232.BaudRate = values.Split("|")(1)  '通訊速度
                    RS232.Parity = values.Split("|")(2)    '不发生奇偶校验位检查
                    RS232.DataBits = values.Split("|")(3)  '資料位元設定值
                    RS232.StopBits = values.Split("|")(4)  '停止位 

                    cmbCOM.Text = RS232.PortName
                    If Not RS232.IsOpen Then  '尚未開啟
                        RS232.Open()  '開啟通訊埠
                        RS232.ReadTimeout = 5000   '5s
                        'RS232.WriteTimeout = 2000
                    End If
                Else
                    '兴宁机台PLC
                    If RS232.IsOpen Then  '開啟
                        RS232.Close()
                    End If
                    plclib.PLCStation = "01"
                    plclib.COM = values.Split("|")(0)
                    plclib.SerialPort1.BaudRate = values.Split("|")(1)
                    plclib.SerialPort1.Parity = values.Split("|")(2)    '不发生奇偶校验位检查
                    plclib.SerialPort1.DataBits = values.Split("|")(3)  '資料位元設定值
                    plclib.SerialPort1.StopBits = values.Split("|")(4)  '停止位 
                    If Not plclib.SerialPort1.IsOpen Then
                        plclib.SerialPort1.PortName = values.Split("|")(0)
                        plclib.SerialPort1.Open()
                        plclib.SerialPort1.WriteTimeout = 2000 '2S
                        plclib.SerialPort1.ReadTimeout = 5000   '5s
                    End If
                End If
            Else
                values = GetTcpPars()
                If values = "" Then
                    MessageUtils.ShowError("扫描参数未设置！")
                    Exit Sub
                End If
                serverip = values.Split("|")(0)
                serverport = values.Split("|")(1)
            End If


        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SetMessage("Fail", ex.Message)
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.SendMessageInit", "Load", "sys")
            'MessageUtils.ShowError("没有打开RS232端口或没有连接对应设备！")
        End Try
    End Sub

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
    Private Function GetTcpPars() As String
        Dim result As String = ""
        Dim strSQL As String = ""

        strSQL = "SELECT TEXT, isnull(MachineType,'1') MachineType FROM m_AutoScanBaseData_t WHERE   VALUE = '{0}'"
        strSQL = String.Format(strSQL, My.Computer.Name)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count = 0 Then
            Return ""
        Else
            result = dt.Rows(0)(0).ToString
            MachineType = dt.Rows(0)(1).ToString
        End If
        Return result
    End Function
    Dim strMsg As String = ""
    Dim builder As New StringBuilder()

    '1. 扫描OK，2. 扫描NG,  3. 扫描NG停止
    Private Sub SendMessageRs232(msg As String)
        Select Case MachineType
            Case "1"
                SendMachineOne(msg)
            Case "3" 'MODBUS TCP 
                If msg = ResultType.OK Then
                    msg = "2"
                ElseIf msg = ResultType.NG Then
                    msg = "4"
                ElseIf msg = ResultType.NGSTOP Then
                    msg = "8"
                ElseIf msg = ResultType.RESET Then

                End If
                SenDModbusTCP(msg)
            Case "4"
                If msg = ResultType.OK Then
                    msg = "11"
                ElseIf msg = ResultType.NG Then
                    msg = "22"
                End If
                SendMachinePLC(msg)
            Case Else
                If msg = ResultType.OK Then
                    msg = "AA"
                ElseIf msg = ResultType.NG Then
                    msg = "BB"
                ElseIf msg = ResultType.NGSTOP Then
                    msg = "CC"
                ElseIf msg = ResultType.RESET Then

                End If
                SendMachineTwo(msg)
        End Select
        'If MachineType = "1" Then
        '    SendMachineOne(msg)
        'Else

        '    If msg = ResultType.OK Then
        '        msg = "AA"
        '    ElseIf msg = ResultType.NG Then
        '        msg = "BB"
        '    ElseIf msg = ResultType.NGSTOP Then
        '        msg = "CC"
        '    ElseIf msg = ResultType.RESET Then

        '    End If
        '    SendMachineTwo(msg)
        'End If
    End Sub

    '东莞机种
    Private Sub SendMachineOne(msg As String)
        '**********************写日志处理  开始*****************************************************
        'log.WriteLog(String.Format("执行发送信息开始！{0}", ""))
        '**********************写日志处理  结束*****************************************************
        Dim buf As New List(Of Byte)  '= new list(of byte)
        Dim scanQty As String = LblCurrQty.Text.Trim

        Try
            RS232.DiscardInBuffer()  '清空接收缓冲区     

            'TextBox1.Clear()
            strMsg = msg

            Dim qty As String
            qty = "0000" + Hex(scanQty)
            qty = qty.Substring(Len(qty) - 4)

            Dim sendMsg As String = "@00WD0040" + msg.PadLeft(4, "0") + qty
            Dim resetMsg As String = "@00WD0040" + "0".PadLeft(4, "0") + qty

            Dim AA As String = sendMsg + SumChk(sendMsg) + "*" + Chr(13)
            RS232.WriteLine(AA)
            Threading.Thread.Sleep(200) ' 暂停0.2秒

            '**********************写日志处理  开始*****************************************************
            'log.WriteLog(String.Format("执行发送信息1结束！发送内容：{0}", AA))
            '**********************写日志处理  结束*****************************************************

            Dim BB As String = resetMsg + SumChk(resetMsg) + "*" + Chr(13)
            RS232.WriteLine(BB)
            Threading.Thread.Sleep(200) ' 暂停0.2秒

            '**********************写日志处理  开始*****************************************************
            'log.WriteLog(String.Format("执行发送信息2结束！发送内容：{0}", BB))
            '**********************写日志处理  结束*****************************************************

            SaveScanSendData(scanCode, AA, My.Computer.Name, VbCommClass.VbCommClass.UseId, "W")

        Catch ex As Exception

        End Try
    End Sub

    '江西机种
    Private Sub SendMachineTwo(msg As String)
        Dim buf As New List(Of Byte)  '= new list(of byte)

        Try
            RS232.DiscardInBuffer()  '清空接收缓冲区     

            strMsg = msg

            Dim sendMsg As String = strMsg

            Dim AA As String = sendMsg
            RS232.WriteLine(AA)
            Threading.Thread.Sleep(200) ' 暂停0.2秒

            SaveScanSendData(scanCode, AA, My.Computer.Name, VbCommClass.VbCommClass.UseId, "W")

        Catch ex As Exception

        End Try
    End Sub
    'MODBUS TCP
    Private Sub SenDModbusTCP(msg As String)
        Dim buf As New List(Of Byte)  '= new list(of byte)

        Try
            Dim ip As IPAddress = IPAddress.Parse(serverip)
            Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            clientSocket.Connect(New IPEndPoint(ip, 502))
            Threading.Thread.Sleep(200) ' 暂停0.2秒
            Dim by(14) As Byte
            by(0) = &H97
            by(1) = &H79
            by(2) = 0
            by(3) = 0
            by(4) = 0
            by(5) = &H9
            by(6) = &H4
            by(7) = &H10
            by(8) = 0
            by(9) = 0
            by(10) = 0
            by(11) = &H1
            by(12) = &H2
            by(13) = &H0
            by(14) = Hex(Convert.ToInt32(msg))
            clientSocket.Send(by)
            Threading.Thread.Sleep(200)
            clientSocket.Close()
            SaveScanSendData(scanCode, "TCP", My.Computer.Name, VbCommClass.VbCommClass.UseId, "W")
        Catch ex As Exception
            'log.WriteLog(String.Format("发送{0}信号异常,异常信息{1}", msg, ex.Message))
        End Try
    End Sub

    'MODBUS TCP
    Private Sub SenDModbusCurrQTY(msg As String)
        Dim buf As New List(Of Byte)  '= new list(of byte)

        Try
            Dim h1 As String = "0"
            Dim h2 As String = "0"

            If (Convert.ToInt32(msg)) > 255 Then
                h1 = Hex(Convert.ToInt32(msg)).ToString().Substring(0, 1)
                h2 = Hex(Convert.ToInt32(msg)).ToString().Substring(1, 2)
            End If
            Dim ip As IPAddress = IPAddress.Parse(serverip)
            Dim clientSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            clientSocket.Connect(New IPEndPoint(ip, 502))
            Threading.Thread.Sleep(200) ' 暂停0.2秒
            Dim by(14) As Byte
            by(0) = &H97
            by(1) = &H79
            by(2) = 0
            by(3) = 0
            by(4) = 0
            by(5) = &H9
            by(6) = &H4
            by(7) = &H10
            by(8) = 0
            by(9) = 2
            by(10) = 0
            by(11) = &H1
            by(12) = &H2
            If (Convert.ToInt32(msg)) > 255 Then
                by(13) = CLng("&H" & h1)
                by(14) = CLng("&H" & h2)
            Else
                by(13) = &H0
                by(14) = Convert.ToInt32(msg)
            End If
            ' Hex(Convert.ToInt32(748))
            clientSocket.Send(by)
            Threading.Thread.Sleep(200)
            clientSocket.Close()
            Dim h3 As String = "h13:" & by(13) & " h14 :" & by(14) & " h0 :" & msg
            SaveScanSendData(scanCode, "TCPQTY:" & h3, My.Computer.Name, VbCommClass.VbCommClass.UseId, "W")
        Catch ex As Exception
            'log.WriteLog(String.Format("发送{0}信号异常,异常信息{1}", msg, ex.Message))
        End Try
    End Sub

    Private Sub SendModbusQTY()
        ' 暂停0.2秒
        If MachineType = "3" Then
            Try
                SenDModbusCurrQTY(LblCurrQty.Text)
                Threading.Thread.Sleep(200)
                SenDModbusCurrQTY(LblCurrQty.Text)
            Catch ex As Exception
                lblMessage.Text = "发送数量失败,请重新设置!"
            End Try
        End If
    End Sub
    '比较处理
    Private Function SumChk(Dats) As String  '校验码（FCS校验）
        Dim i
        Dim CHK
        For i = 1 To Len(Dats)                  ''统计字符串数量
            CHK = CHK Xor Asc(Mid(Dats, i, 1)) ' 从字符串第一个字符开始，2个ASCII字符执行“异或”操作的结果,再和下一个字符异或
        Next i
        SumChk = Hex(CHK)    '算出累加后的CHK值的16进制字符串，然后取其最后两位
        SumChk = "00" + SumChk
        SumChk = Microsoft.VisualBasic.Right(SumChk, 2)

    End Function
    '兴宁机种 松下PLC
    Private Sub SendMachinePLC(msg As String)
        '**********************写日志处理  开始*****************************************************
        'log.WriteLog(String.Format("执行发送信息开始！{0}", ""))
        '**********************写日志处理  结束*****************************************************
        Dim buf As New List(Of Byte)  '= new list(of byte)
    
        Try
            'RS232.DiscardInBuffer()  '清空接收缓冲区     

            'TextBox1.Clear()
            strMsg = msg

            Dim qty As String
            Dim sendMsg As String
            Dim resetMsg As String
 
 
            plclib.PLCStation = "01"
            If plclib.SerialPort1.IsOpen Then
                plclib.SerialPort1.DiscardInBuffer()
            Else
                plclib.SerialPort1.Open()
            End If

            plclib.COMPLC("WriteD", "4100", msg)
            ' p.SerialPort1.Close()
            Threading.Thread.Sleep(200) ' 暂停0.2秒

            '**********************写日志处理  开始*****************************************************
            'log.WriteLog(String.Format("执行发送信息1结束！发送内容：{0}", AA))
            '**********************写日志处理  结束*****************************************************

            'Dim BB As String = resetMsg + SumChk(resetMsg) + "*" + Chr(13)
            'RS232.WriteLine(BB)
            'Threading.Thread.Sleep(200) ' 暂停0.2秒

            '**********************写日志处理  开始*****************************************************
            'log.WriteLog(String.Format("执行发送信息2结束！发送内容：{0}", BB))
            '**********************写日志处理  结束*****************************************************

            SaveScanSendData(scanCode, msg, My.Computer.Name, VbCommClass.VbCommClass.UseId, "P")

        Catch ex As Exception

        End Try
    End Sub

    '数据接收
    Private Sub RS232_DataReceived(sender As Object, e As Ports.SerialDataReceivedEventArgs) Handles RS232.DataReceived
        Invoke(Sub()
                   If MachineType = "1" Then
                       ReceivedMachineOne()
                   Else
                       ReceivedMachineTwo()
                   End If
               End Sub)
    End Sub

    '东莞机种接收
    Private Sub ReceivedMachineOne()
        '**********************写日志处理  开始*****************************************************
        'log.WriteLog(String.Format("执行数据接收信息开始！{0}", ""))
        '**********************写日志处理  结束*****************************************************

        Dim n As Integer = RS232.BytesToRead     '先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
        Dim buf(n) As Byte                      '声明一个临时数组存储当前来的串口数据
        RS232.Read(buf, 0, n)                    '读取缓冲数据
        Threading.Thread.Sleep(100) ' 暂停0.1秒

        '因为要访问ui资源，所以需要使用invoke方式同步ui。同步委托的方法Invoke
        builder.Remove(0, Len(builder.ToString))
        '直接按ASCII规则转换成字符串
        builder.Append(Encoding.ASCII.GetString(buf))

        '追加的形式添加到文本框末端，并滚动到最后。
        TextBox1.Text = builder.ToString()

        Dim Y As String = Microsoft.VisualBasic.Left(TextBox1.Text, 9)
        If (Y = "@00WD0053") Then
            lblReadWriteData.Text = "发送成功"
            '保存读取信息
            SaveScanSendData(scanCode, TextBox1.Text.ToString(), My.Computer.Name, VbCommClass.VbCommClass.UseId, "R")
        Else
            lblReadWriteData.Text = "发送不成功"
            '保存读取信息
            SaveScanSendData(scanCode, TextBox1.Text.ToString(), My.Computer.Name, VbCommClass.VbCommClass.UseId, "R")
            SendMessageRs232(strMsg)
        End If

        '**********************写日志处理  开始*****************************************************
        'log.WriteLog(String.Format("执行数据接收信息结束！接收信息内容：{0}", Y))
        '**********************写日志处理  结束*****************************************************
    End Sub

    '江西机种接收
    Private Sub ReceivedMachineTwo()
        Try
            Dim data As String = RS232.ReadExisting()
            MessageUtils.ShowInformation(data)
            '接收到数据
            If (data = "E") Then
                lblReadWriteData.Text = "发送成功"
                '保存读取信息
                'SaveScanSendData(scanCode, TextBox1.Text.ToString(), My.Computer.Name, VbCommClass.VbCommClass.UseId, "R")
            Else
                lblReadWriteData.Text = "发送不成功"
                '保存读取信息
                'SaveScanSendData(scanCode, TextBox1.Text.ToString(), My.Computer.Name, VbCommClass.VbCommClass.UseId, "R")
                SendMessageRs232(strMsg)
            End If
        Catch ex As Exception
            MessageUtils.ShowInformation("接受信息失败" + ex.Message)
        End Try
    End Sub

    '删除自动扫描数据 非当天日期的条码
    Private Sub DeleteAutoScanData()
        Dim strSQL As String = " DELETE [m_AutoScaninfo_t] WHERE CONVERT(VARCHAR(10), inTime ,111) <> CONVERT(VARCHAR(10), GETDATE() ,111) "

        DbOperateUtils.ExecSQL(strSQL)
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
    End Sub
#End Region

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
            MessageUtils.ShowConfirm("", MessageBoxButtons.AbortRetryIgnore)
        End Try
    End Sub

#End Region

End Class