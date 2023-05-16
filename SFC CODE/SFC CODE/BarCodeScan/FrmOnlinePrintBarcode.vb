
'--在线条码打印
'--Create by :　马锋
'--Create date :　2016/02/20
'--Update date :  
'--
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
Imports UIHandler

#End Region

Public Class FrmOnlinePrintBarcode

#Region "窗體變量"

    Dim IsCustPart As Boolean
    Dim IsPrtPacking As Boolean
    Dim IsScanPallet As Boolean
    Dim IsFull As Boolean = False           '棧板是否裝滿
    Dim IsScanN As String = "N"             '是否扫描多次
    Dim ScanNumber As Integer = 1           '扫描次数
    Dim IsTrunk As String = "N"             '是否尾箱
    Dim IsTPartIdScan As Boolean = False       '是否子件扫描 add by hgd 2017-08-03
    Dim BarcodeTPartIdArr() As String = Nothing    '子条码集 add by hgd 2017-08-01
    Dim PackArray As New SysMessageClass.PrtStructure

    Dim btApp As BarTender.Application
    Dim btFormat As New BarTender.Format
    Public scanSetting As New ScanSetting

    '--自定义校验条码数量和内容
    Dim CheckCurIndex As Integer = 0
    Dim paraArrays As String()      '校验参数
    Dim IsRepeatStyleC As String = "N"
    Dim ssStartindex As Integer     '流水起始位置 田玉琳 2017014
    Dim ssStartLength As Integer    '流水起始长度 田玉琳 2017014
    Dim strIsCharacters As String
    Private ngWavPlayTime As Integer = 2000     '错误声音播放时间
    Dim printscanPPid As String = String.Empty
    Dim TgenCarton As String = "N"     '自动生成外箱
    Dim IsLinePrint As String = "N"   '是否在线打印产品条码
    Dim IsReadSn As String = "N"      '是否读取序号
    Dim IsPackingPPID As String = "N" '是否产品序号相同（允许箱产品同包装）
    Dim IsPackType As String = "N"          '包装类型
    Dim IsPrtSelf As String = "N"           '是否在系统里面打印
    Dim IsPrtSelfCarton As String = "N"     '是否在系统里面打印外箱
    Dim IsSemiProduct As String = "N"    '田玉琳 20180308 是否是半成品
    Dim CODERULEID2 As String = ""       '外箱编码原则
    Dim IsCheckCartonStyle As String = "Y"  '是否检查箱样式 田玉琳20171215
    Dim IsOnlineWeightFinish As Boolean = True '是否称重完成
    Private m_strQRCode As String = String.Empty

    '在线称重状态
    Private Enum ScanFinishStatus
        ''' <summary>
        ''' 无
        ''' </summary>
        ''' <remarks></remarks>
        None = 0
        ''' <summary>
        ''' 整箱完成
        ''' </summary>
        ''' <remarks></remarks>
        Finsh = 1
        ''' <summary>
        ''' 整箱未完成
        ''' </summary>
        ''' <remarks></remarks>
        NoFinsh = 2
        ''' <summary>
        ''' 整个工单已完成
        ''' </summary>
        ''' <remarks></remarks>
        MoidFinsh = 3
    End Enum

    '称重完成状态
    Private _ScanFinishType As ScanFinishStatus
    Private Property ScanFinishType() As ScanFinishStatus
        Get
            Return _ScanFinishType
        End Get

        Set(ByVal Value As ScanFinishStatus)
            _ScanFinishType = Value
        End Set
    End Property

    Private _IsScanHWASN As Boolean
    Private Property IsScanHWASN() As Boolean
        Get
            Return _IsScanHWASN
        End Get

        Set(ByVal Value As Boolean)
            _IsScanHWASN = Value
        End Set
    End Property
#End Region

#Region "窗體事件"

    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BnScanSet_Click(sender, e)
                ''Case Keys.F2
                ''    toolCa_Click(sender, e)

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

        LabResult.Text = ""
        txt_tmpbarcode.Text = ""  'add by cq 20171101
        lblMessage.Text = "请设置扫描资料"
        ToolUsename.Text = SysMessageClass.UseName
        SqlClassM.GetPrintersList(cboPrinterList)
        '如果在线打印时，设置默认打印
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName '取得默认的打印
        cboPrinterList.Text = sDefaultPrinter
        Me.ActiveControl = Me.TxtBarCode
    End Sub

    '条码打印窗体关闭
    Private Sub FrmOnlinePrintBarcode_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        scanSetting.CustIdString = Nothing
        scanSetting.MoidStr = Nothing
        scanSetting.LengthStr = Nothing
        scanSetting.DateCheck = Nothing
    End Sub

#End Region

#Region "掃描設置/返回按鈕事件"

    Private Sub BnScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolScanSet.Click

        scanSetting.FormName = Me.Name

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

                TxtBarCode.Focus()
                IsScanPallet = scanSetting.ScanPalletCheck ''是否掃描棧板
                IsCustPart = scanSetting.CustPartCheck ''是否核對客戶料號
                IsPrtPacking = scanSetting.PrtPackingCheck '是否在线打印外箱号
                DGridBarCode.DataSource = Nothing

                TxtMoId.Text = scanSetting.MoidStr           ''工單
                TxtSitName.Text = scanSetting.vStandId & scanSetting.vStandName    ''工單數量
                TxtPartid.Text = scanSetting.PartidStr ''料件編號
                TxtLineId.Text = scanSetting.LineStr ''線別
                SetMessage("PASS", "扫描资料设置完成")
                scanSetting.vCurrentStandIndex = 1
                TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                '是否子件扫描
                Me.IsTPartIdScan = IIf(scanSetting.vStandMaxStaIndex > 1, True, False)

                If GetIsScanFinish(TxtMoId.Text) = True Then
                    LblPackQty.Text = "0" : LblCurrQty.Text = "0"
                    SetMessage("FAIL", "该工单全部扫描完成！")
                    LoadPalletPaceQty()
                    Exit Sub
                End If

                Dim strSQL As String = ""
                strSQL = " SELECT ISNULL(IslineMbarcode,'N') IslineMbarcode,isnull(IsUsb,'N') IsUsb,isnull(LinePrtY,'N') LinePrtY," & _
                         " ISNULL(IsAllowRe,'N') as IsProductSame, isnull(IsPackType,'N') as IsPackType, isnull(RepeatStyleC,'N') as IsRepeatStyleC, " & _
                         " ISNULL(IsPrtSelf,'N') as IsPrtSelf, ISNULL(ISPRTSELFCARTON,'N')ISPRTSELFCARTON, " & _
                         " ISNULL(CODERULEID2,'') as CODERULEID2,ISNULL(IsScanN,'') as IsScanN ,ISNULL(IsSemiProduct,'') as IsSemiProduct " & _
                         " FROM m_RPartStationD_t where PPartid='" & TxtPartid.Text & "' and TPartid='" & TxtPartid.Text & "' " & _
                         " AND Stationid='" & scanSetting.vStandId & "'  and State='1'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    IsLinePrint = dt.Rows(0)!IslineMbarcode
                    IsReadSn = dt.Rows(0)!IsUsb
                    IsPackingPPID = dt.Rows(0)!IsProductSame
                    IsPackType = dt.Rows(0)!IsPackType
                    TgenCarton = dt.Rows(0)!LinePrtY  '是否自动生成外箱编号
                    IsPrtSelf = dt.Rows(0)!IsPrtSelf
                    IsRepeatStyleC = dt.Rows(0)!IsRepeatStyleC '
                    IsPrtSelfCarton = dt.Rows(0)!IsPrtSelfCarton
                    CODERULEID2 = dt.Rows(0)!CODERULEID2
                    IsScanN = dt.Rows(0)!IsScanN
                    IsSemiProduct = dt.Rows(0)!IsSemiProduct
                End If

                '非系统箱条码扫描  田玉琳 20161220
                If IsPrtSelfCarton = "N" Then   '非系统单码扫描
                    If TxtPartid.Text.Substring(0, 3).ToUpper = "L99" Then
                        'BYPASS HW ASN SCAN,cq 20180829
                        Dim ruleID As String = GetCodeRule2()
                        SetCartonStyle(ruleID)
                    Else
                        If GetNonSelfCarton() = False Then
                            SetMessage("Fail", "（非系统打印外箱）编码原则设置错误,请重新设置")
                            Exit Sub
                        End If
                    End If
                Else
                    GetIsSelfCarton()
                End If

                'If scanSetting.IsOnlineGenCartonID2 = False Or scanSetting.CodeRuleID2 = "" Then
                '    SetMessage("FAIL", "请在料件资料表中设置二层箱的编码原则！")
                '    Exit Sub
                'End If

                If scanSetting.vRepeatStyle = "Y" Then
                    ReDim paraArrays(scanSetting.vRepeatPara.Split(",").Length - 1)
                    Dim i As Integer = 0
                    For i = 0 To paraArrays.Length - 1
                        paraArrays(i) = scanSetting.vRepeatPara.Split(",")(i).Replace("{", "").Replace("}", "").Trim
                    Next
                    '设置有检验时，流水段数据
                    GetCodeRuleIdSSSS(TxtPartid.Text)
                End If
                'add by hgd 2018-05-31 在线称重，重量上下限
                If scanSetting.IsPpidLineWeight = True Then
                    Me.lbWeight.Visible = True
                    Me.txtWeight.Visible = True
                    Me.txtWeight.Enabled = False
                Else
                    Me.lbWeight.Visible = False
                    Me.txtWeight.Visible = False
                End If
                ' Dim strSQL As String = ""
                '''''''獲取未裝滿外箱
                If scanSetting.vCartonSame = "Y" Then
                    'HW的高频房L99的不去join m_SnSBarCode_t
                    If Me.TxtPartid.Text.Trim.Substring(0, 3) = "L99" Then
                        strSQL = " SELECT a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity ,isnull(a.PackingQuantity,0) AS qty from M_Carton_t a " &
                            " where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc"
                    Else
                        strSQL = " SELECT a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,isnull(a.PackingQuantity,0) AS qty FROM M_Carton_t a  " &
                           " where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc"
                    End If
                Else
                    '是自制条码
                    If scanSetting.IsPrtSelf = "Y" Then
                        'HW的高频房L99的不去join m_SnSBarCode_t
                        If Me.TxtPartid.Text.Trim.Substring(0, 3) = "L99" Then
                            strSQL = " SELECT a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,isnull(a.PackingQuantity,0) AS qty FROM M_Carton_t a  " &
                                     " where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc"
                        Else
                            strSQL = " SELECT a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,b.qty FROM M_Carton_t a join m_SnSBarCode_t b on a.cartonid=b.sbarcode " &
                          " where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc"
                        End If
                    Else '非自制条码
                        strSQL = " SELECT a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,isnull(a.PackingQuantity,0) AS qty " & _
                                   " FROM M_Carton_t a  " & _
                                   " WHERE a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and " & _
                                   " a.CartonStatus='N' order by a.Intime desc"
                    End If
                End If
                dt.Reset()
                dt = DbOperateUtils.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    TxtCartonID.Text = dt.Rows(0)("Cartonid").ToString
                    LblPackQty.Text = dt.Rows(0)("qty").ToString '应装数量
                    Me.LblCurrQty.Text = dt.Rows(0)("cartonqty").ToString '已装数量
                    GetScanItem(Me.TxtCartonID.Text)
                    'add by cq 20180604
                    ControlState(True)
                Else
                    If scanSetting.IsOnlineGenCartonID2 Then
                        Me.TxtCartonID.Text = OnlineCartonID()
                        LblCurrQty.Text = 0
                    Else
                        ControlState(False)
                    End If
                End If
                GetScanItem(TxtCartonID.Text)
            End If
            scanSetting.CheckStr = False
            LoadPalletPaceQty()

        Catch ex As Exception
            lblMessage.ForeColor = Color.Red
            SetMessage("Fail", "设置扫描参数异常,请重新设置")
            scanSetting.MoidStr = ""
            TxtMoId.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtLineId.Text = String.Empty
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#{1}", Me.TxtMoId.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmOnlinePrintBarcode", "BnScanSet_Click", "sys")
        End Try
    End Sub

    ''' <summary>
    ''' 二层外箱生成不打印对应的编码原则
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCodeRule2() As String
        GetCodeRule2=""
        Dim strSQL As String = " EXEC GetCodeRuleId2 '{0}' "
        strSQL = String.Format(strSQL, TxtPartid.Text.Trim)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            GetCodeRule2 = dt.Rows(0)(0).ToString
        End If

    End Function

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

    Private Sub SetScanCodeStyle(type As String)
        If type = "P" Then
            'TxtSnStyle1.Text = lblPalletStyle.Text
            'TxtSnStyle2.Text = lblPalletStyle2.Text
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
        If CODERULEID2 = "" Then Return False

        Dim ruleID As String = CODERULEID2.Split("/")(2)
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

    Private Sub BnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

#End Region

#Region "控件事件"

    Private Sub TxtBarCode_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TxtBarCode.PreviewKeyDown
        If (scanSetting.MoidStr Is Nothing) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.LabResult.Text = "Fail"
            LabResult.ForeColor = Color.Crimson
            lblMessage.ForeColor = Color.Crimson
            Me.TxtBarCode.Text = ""
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.LabResult.Text = "Fail"
            LabResult.ForeColor = Color.Crimson
            lblMessage.ForeColor = Color.Crimson
            Me.TxtBarCode.Text = ""
            Exit Sub
        End If

        'add by hgd 2018-06-04 防止在线称重，有些电子称点击列印，列印时出现3列数值，其中有0的
        If TxtBarCode.Text.Trim = "0" AndAlso scanSetting.IsPpidLineWeight = True Then
            TxtBarCode.Text = ""

            Exit Sub
        End If

        If e.KeyValue = 13 Then

            StandScan()
        End If
    End Sub

    Private Sub tsbRepeatPrint_Click(sender As Object, e As EventArgs) Handles tsbRepeatPrint.Click
        Try
            If TxtPartid.Text = "" Then
                SetMessage("Fail", "扫描资料未设置...")
                Exit Sub
            End If
            If scanSetting.PrtPackingCheck = False Then
                SetMessage("Fail", "在线打印的PE袋才能重新打印...")
                Exit Sub
            End If
            If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
                SetMessage("Fail", "请设置在线标签打印机选项...")
                Exit Sub
            End If

            Dim frm As New FrmCartonRepeatPrint()
            frm.Moid = TxtMoId.Text.Trim
            frm.PartId = TxtPartid.Text.Trim
            frm.PrintName = Me.cboPrinterList.Text.Trim
            frm.PrintType = FrmCartonRepeatPrint.EnumPrintType.PEPocket
            frm.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmOnlinePrintBarcode", "tsbRepeatPrint_Click", "sys")
            Exit Sub
        End Try
    End Sub

    '打印外箱 A4
    Private Sub toolPrintCarton_Click(sender As Object, e As EventArgs) Handles toolPrintCarton.Click
        Try
            If TxtPartid.Text = "" Then
                SetMessage("Fail", "扫描资料未设置...")
                Exit Sub
            End If
            If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
                SetMessage("Fail", "请设置在线标签打印机选项...")
                Exit Sub
            End If

            Dim frmOnlinePrintCarton As New FrmOnlinePrintCarton()
            frmOnlinePrintCarton.Moid = TxtMoId.Text
            frmOnlinePrintCarton.PartId = TxtPartid.Text
            frmOnlinePrintCarton.PrintName = Me.cboPrinterList.Text.Trim
            frmOnlinePrintCarton.LabelNum = scanSetting.LabelNum
            frmOnlinePrintCarton.PrintType = frmOnlinePrintCarton.EnumPrintType.CartonA4
            frmOnlinePrintCarton.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmOnlinePrintBarcode", "toolPrintCarton", "sys")
        End Try
    End Sub

    '打印外箱 QR
    Private Sub toolPrintCartonQR_Click(sender As Object, e As EventArgs) Handles toolPrintCartonQR.Click
        Try
            If TxtPartid.Text = "" Then
                SetMessage("Fail", "扫描资料未设置...")
                Exit Sub
            End If
            If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
                SetMessage("Fail", "请设置在线标签打印机选项...")
                Exit Sub
            End If

            Dim frmOnlinePrintCarton As New FrmOnlinePrintCarton()
            frmOnlinePrintCarton.Moid = TxtMoId.Text
            frmOnlinePrintCarton.PartId = TxtPartid.Text
            frmOnlinePrintCarton.PrintName = Me.cboPrinterList.Text.Trim
            frmOnlinePrintCarton.LabelNum = scanSetting.LabelNum
            frmOnlinePrintCarton.PrintType = frmOnlinePrintCarton.EnumPrintType.CartonQR
            frmOnlinePrintCarton.ShowDialog()
        Catch ex As Exception
            lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmOnlinePrintBarcode", "toolPrintCartonQR", "sys")
        End Try
    End Sub

#End Region

#Region "函数"

    Private Sub StandScan()
        If Me.TxtPartid.Text = "" Then
            SetMessage("Fail", "扫描资料未设置，请先设置...")
            Me.TxtBarCode.Focus()
            Exit Sub
        End If

        If Me.TxtBarCode.Text = "" Then
            SetMessage("Fail", "扫描产品条码不能为空！")
            Me.TxtBarCode.Focus()
            Exit Sub
        End If

        If (scanSetting.MoidStr Is Nothing) Then
            SetMessage("Fail", "请选择扫描工单！")
            Me.TxtBarCode.Text = ""
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            SetMessage("Fail", "请选择扫描工单！")
            Me.TxtBarCode.Text = ""
            Exit Sub
        End If

        'If scanSetting.IsOnlineGenCartonID2 = False Then
        '    SetMessage("Fail", "请设置自动产生箱的编码原则！")
        '    Me.TxtBarCode.Text = ""
        '    Exit Sub
        'End If

        'EBU在线打印 = false
        If (scanSetting.PrtPackingCheck) = False Then
            SetMessage("Fail", "系统未设置在线打印标签参数...")
            TxtBarCode.Clear()
            Me.ActiveControl = Me.TxtBarCode
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.CodeRuleID)) Then
            SetMessage("Fail", "在线打印失败，没有配置打印标签参数...")
            TxtBarCode.Clear()
            Me.ActiveControl = Me.TxtBarCode
            Exit Sub
        End If

        If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
            SetMessage("Fail", "请设置在线标签打印机选项...")
            TxtBarCode.Clear()
            Me.ActiveControl = Me.TxtBarCode
            Exit Sub
        End If

        '**************周可海 修改 20190909***********************Start 
        '扫描多个条码拼接
        If scanSetting.IsScanN = "Y" And ScanNumber <> scanSetting.ScanNumber Then
            ScanNumber = ScanNumber + 1
            Exit Sub
        Else
            ScanNumber = 1
        End If



        '**************田玉琳 修改 20170510***********************End 

        '扫描条码
        Dim BarCode As String = Me.TxtBarCode.Text
        If TxtSnStyle1.Text.Trim.Length <> 0 Then
            If BarCode.Trim.Length <> TxtSnStyle1.Text.Length Then
                SetMessage("Fail", "扫描条码长度不对")
                TxtBarCode.Clear()
                Me.ActiveControl = Me.TxtBarCode
                Exit Sub
            End If

            If TextHandle.verfyBarCodeStyle(TxtSnStyle1.Text, BarCode, TxtSnStyle2.Text) = False Then
                SetMessage("FAIL", "條碼不符合標準樣式")
                TxtBarCode.Clear()
                Me.ActiveControl = Me.TxtBarCode
                Exit Sub
            End If
        End If

        '----  cq add  20171101 --- Start -------------
        '验证样式
        If CheckStyle(BarCode) = False Then Exit Sub
        '----  cq add  20171101 --- END  --------------

        '条码
        scanSetting.BarCodeStr = Me.TxtBarCode.Text.Trim
        scanSetting.vMainBarCode = IIf(Me.IsTPartIdScan = True, scanSetting.vMainBarCode, Me.TxtBarCode.Text.Trim)

        '验证PPID测试结果
        If CheckPPIDTest() = False Then
            Exit Sub
        End If
        '**************************** 田玉琳 20180802 开始****************************
        If CheckIsFull() = False Then
            Exit Sub
        End If
        '**************************** 田玉琳 20180802 结束****************************
        '**************************** 田玉琳 20190416 开始****************************
        '重工扫描
        If cbIsReWork.Checked = True Then
            If StandardReworkScan() = False Then
                Exit Sub
            End If
        End If
        '**************************** 田玉琳 20190416 结束****************************

        '打印PE袋
        PrintPepocket()
    End Sub

    '检查是否满箱
    Private Function CheckIsFull()
        Dim curCartonFinish As Boolean = False
        curCartonFinish = CheckIsCartonScanFinish()
        If curCartonFinish = True Then
            SetMessage("Fail", "此箱已经满箱,请换新箱扫描！")
            Return False
        End If
        Return True
    End Function

    '检查PPID
    Private Function CheckPPIDTest() As Boolean
        Dim strCheckProd As String
        Dim o_strIsRepaired As String = IIf(Me.chkIsRepaired.Checked, "Y", "N")
        Try
            Dim tempstr() As String = scanSetting.vmReplaceArray(scanSetting.vCurrentStandIndex, 1).Split("|")
            strCheckProd = " DECLARE @RTVALUE VARCHAR(8),@RTMSG NVARCHAR(128) EXECUTE Exec_CheckMorePPIDTest @RTVALUE OUTPUT, @RTMSG OUTPUT, " & _
                        " '" & SysMessageClass.UseId.Trim & "', '" & tempstr(tempstr.Length - 1) & "', '" & Trim(scanSetting.MoidStr) & "', '" & Trim(scanSetting.LineStr) & "', " & _
                        "'" & Trim(scanSetting.PartidStr) & "','" & scanSetting.vStandMaxStaIndex & "', '" & scanSetting.vStandId.Trim & "', '" & scanSetting.vStandIndex & "', '" & scanSetting.vCurrentStandIndex & "', '" & Me.TxtBarCode.Text.Trim & "','" & o_strIsRepaired & "' " & _
                        " SELECT @RTVALUE, @RTMSG "

            '2017-08-01 hgd 注释
            'strCheckProd = " DECLARE @RTVALUE VARCHAR(8),@RTMSG NVARCHAR(128) EXECUTE Exec_CheckPPIDTest @RTVALUE OUTPUT, @RTMSG OUTPUT, " & _
            '               " '" & SysMessageClass.UseId.Trim & "', '" & Trim(scanSetting.PartidStr) & "', '" & Trim(scanSetting.MoidStr) & "', '" & Trim(scanSetting.LineStr) & "', " & _
            '               " '" & scanSetting.vStandId.Trim & "', '" & scanSetting.vStandIndex & "', '" & scanSetting.vCurrentStandIndex & "', '" & Me.TxtBarCode.Text.Trim & "' " & _
            '               " SELECT @RTVALUE, @RTMSG "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(strCheckProd)
            If dt.Rows.Count > 0 Then
                'update by  hgd 2017-08-01  返回值处理
                Select Case dt.Rows(0)(0)
                    Case "0" ''---掃描失败
                        SetMessage("Fail", dt.Rows(0)(1).ToString())
                        TxtBarCode.Clear()
                        Me.ActiveControl = Me.TxtBarCode
                        scanSetting.ErrorStr = dt.Rows(0)(1).ToString()
                        Dim FrmError As New FrmScanErrPrompt(scanSetting)
                        FrmError.ShowDialog()
                        Return False
                    Case "4" ''---继续掃描子件
                        If scanSetting.vCurrentStandIndex = 1 Then
                            ReDim BarcodeTPartIdArr(scanSetting.vStandMaxStaIndex - 2)
                            scanSetting.vMainBarCode = Me.TxtBarCode.Text
                            SetMessage("PASS", "主条码" & Me.TxtBarCode.Text & "扫描成功,请继续扫描...")
                        Else '子条码数据
                            BarcodeTPartIdArr(scanSetting.vCurrentStandIndex - 2) = Me.TxtBarCode.Text
                            SetMessage("PASS", "部件条码" & Me.TxtBarCode.Text & "扫描成功,请继续扫描...")
                        End If


                        scanSetting.vCurrentStandIndex = scanSetting.vCurrentStandIndex + 1
                        TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)

                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"

                        TxtBarCode.Clear()
                        TxtBarCode.Focus()
                        Return False
                    Case "1"
                        If Me.IsTPartIdScan = True Then
                            BarcodeTPartIdArr(BarcodeTPartIdArr.Length - 1) = Me.TxtBarCode.Text
                            '切换样式
                            scanSetting.vCurrentStandIndex = 1
                            TxtSnStyle1.Text = scanSetting.vstyleArray(1, 0)
                            TxtSnStyle2.Text = scanSetting.vstyleArray(1, 1)
                            LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                            TxtBarCode.Focus()
                        End If
                        Return True
                End Select
                '2017-08-01 hgd 注释
                'If dt.Rows(0)(0).ToString() = "0" Then
                '    SetMessage("Fail", dt.Rows(0)(1).ToString())
                '    TxtBarCode.Clear()
                '    Me.ActiveControl = Me.TxtBarCode
                '    scanSetting.ErrorStr = dt.Rows(0)(1).ToString()
                '    Dim FrmError As New FrmScanErrPrompt(scanSetting)
                '    FrmError.ShowDialog()
                '    Exit Sub
                'End If
            Else
                SetMessage("Fail", "检查条码" & Me.TxtBarCode.Text & "测试结果异常...")
                TxtBarCode.Clear()
                Me.ActiveControl = Me.TxtBarCode
                scanSetting.ErrorStr = "检查条码" & Me.TxtBarCode.Text & "测试结果异常..."
                Dim FrmError As New FrmScanErrPrompt(scanSetting)
                FrmError.ShowDialog()
                Return False
            End If
        Catch ex As Exception
            SetMessage("Fail", "检查条码" & Me.TxtBarCode.Text & "测试结果异常...")
            TxtBarCode.Clear()
            Me.ActiveControl = Me.TxtBarCode
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmOnlinePrintBarcode", "StandScan", "sys")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 重工扫描
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function StandardReworkScan() As Boolean
        Dim strSQL = " DECLARE @strmsgid varchar(1), @strmsgText nvarchar(150) " &
                    "  exec m_StandardReworkOnlineScan_P '{0}','{1}','{2}','N','{3}', '{4}','{5}',@strmsgid output,@strmsgText output " &
                    "  SELECT @strmsgid,@strmsgText "

        '是否重工扫描(重工工单)
        Dim isReWork As String = IIf(Me.cbIsReWork.Checked, "Y", "N")

        strSQL = String.Format(strSQL, TxtBarCode.Text.Trim, TxtCartonID.Text, SysMessageClass.UseId, scanSetting.vStandId, TxtMoId.Text.Trim, isReWork)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then

            Select Case dt.Rows(0)(0)
                Case "1"
                    SetMessage("Fail", dt.Rows(0)(1).ToString)
                    TxtBarCode.Clear()
                    Return False
            End Select
        End If
        Return True
    End Function

    '打印PE袋
    Private Sub PrintPepocket()
        Try
            '扫描条码
            Dim BarCode As String = Me.TxtBarCode.Text

            Dim printBarcode As New PrintBarcode
            printBarcode.btApp = btApp
            printBarcode.btFormat = btFormat
            'update by hgd 2017-08-02 调整
            printBarcode.strScanBarcode = scanSetting.vMainBarCode
            'printBarcode.strScanBarcode = Me.TxtBarCode.Text.Trim
            printBarcode.strMOID = Me.TxtMoId.Text.Trim.ToUpper
            printBarcode.strPartid = Me.TxtPartid.Text.Trim.ToUpper
            printBarcode.PrintName = Me.cboPrinterList.Text.Trim
            'printBarcode.curCartonQty = txt
            printBarcode.BoxQty = LblPackQty.Text
            printBarcode.CartonID = Me.TxtCartonID.Text.Trim
            printBarcode.LineId = Me.TxtLineId.Text.Trim
            printBarcode.StaionId = scanSetting.vStandId
            printBarcode.StaionName = scanSetting.vStandName
            printBarcode.CartonSame = scanSetting.vCartonSame
            printBarcode.CodeRuleID = scanSetting.CodeRuleID.Split("/")(2)
            printBarcode.Packid = scanSetting.CodeRuleID.Split("/")(1)
            printBarcode.PackItems = scanSetting.CodeRuleID.Split("/")(0)
            printBarcode.IsRework = cbIsReWork.Checked


            'Dim PrintDate As String = DateTime.Now.ToString()
            'Dim sqlstr As New StringBuilder

            'sqlstr.Append(" insert into m_SnSBarCode_t(SBarCode,Moid,Lineid,Packid,Qty,UseY,Userid,Intime,Makedate,BartenderFile,PackItem,DisorderTypeId,PackingLevel)")
            'sqlstr.Append(" values('" & scanSetting.vMainBarCode & "','" & Me.TxtMoId.Text.Trim.ToUpper & "','" & Me.TxtLineId.Text.Trim & "','" & printBarcode.Packid & "','1','Y','" & SysMessageClass.UseId.ToLower & "',getdate(),'" & CDate(PrintDate).ToString("yyyy-MM-dd").ToString & "','" & pFilePath & "','" & LoadM.Packitem & "','" & LoadM.DisorderType & "','" & LoadM.PackingLevel & "')")

            '修改错误信息提示
            If printBarcode.InitializePrintParameter() = False Then
                If String.IsNullOrEmpty(printBarcode.errMessage) Then
                    SetMessage("Fail", "初始化数据失败，请确认编码原则数据...")
                Else
                    SetMessage("Fail", printBarcode.errMessage)
                End If
                Exit Sub
            End If

            printBarcode.BuildCBarCode()

            printBarcode.BoxQty = LblPackQty.Text

            Dim strErrorMsg As String = ""
            If (Not printBarcode.MainMarkCCode(strErrorMsg)) Then
                SetMessage("Fail", strErrorMsg)
                TxtBarCode.Clear()
                Me.ActiveControl = Me.TxtBarCode
                scanSetting.ErrorStr = strErrorMsg
                Dim FrmError As New FrmScanErrPrompt(scanSetting)
                FrmError.ShowDialog()
                Exit Sub
            End If

            Dim curCartonFinish As Boolean = False
            curCartonFinish = CheckIsCartonScanFinish()

            '满箱操作,打印外箱条码
            If chkFullCartonPrint.Checked = True And curCartonFinish = True Then
                Dim frmOnlinePrintCarton As New FrmOnlinePrintCarton()
                frmOnlinePrintCarton.Moid = TxtMoId.Text
                frmOnlinePrintCarton.PartId = TxtPartid.Text
                frmOnlinePrintCarton.PrintName = Me.cboPrinterList.Text.Trim
                frmOnlinePrintCarton.LabelNum = scanSetting.LabelNum
                frmOnlinePrintCarton.Barcode = scanSetting.vMainBarCode
                frmOnlinePrintCarton.PrintType = frmOnlinePrintCarton.EnumPrintType.CartonQR
                frmOnlinePrintCarton.NewPrint()
                'frmOnlinePrintCarton.btApp = btApp
                'frmOnlinePrintCarton.btFormat = btFormat
                frmOnlinePrintCarton.GetDataPrint()
            End If


            'add by hgd 2017-08-02 保存子件扫描记录
            If Me.IsTPartIdScan = True AndAlso SavePpLinkData() = False Then
                SetMessage("Fail", "PPidLink信息存储失败,请检查数据！")
                TxtBarCode.Clear()
                Exit Sub
            End If
            Me._ScanFinishType = ScanFinishStatus.None
            '**************田玉琳 修改 20160419***********************Start 
            '设置当前数量
            If IsTrunk = "N" Then
                If curCartonFinish = True Then
                    If chkShowCartonFull.Checked = True Then
                        MessageUtils.ShowInformation("确定要进行下一箱！")
                    End If

                    SetMessage("PASS", BarCode & Space(3) & "该箱已经包装完成,请扫描下一箱...")
                    Me._ScanFinishType = ScanFinishStatus.Finsh

                    '自动产线箱号处理
                    If scanSetting.IsOnlineGenCartonID2 = True Then
                        Me.TxtCartonID.Text = OnlineCartonID()
                        Me.LblCurrQty.Text = 0
                        LoadPalletPaceQty()
                    Else
                        DGridBarCode.Rows.Clear()
                        scanSetting.vCurrentStandIndex = 1
                        TxtSnStyle1.Text = scanSetting.vstyleArray(1, 0)
                        TxtSnStyle2.Text = scanSetting.vstyleArray(1, 1)
                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                        LblMainBarCode.Text = ""
                        ControlState(False)
                    End If
                Else
                    SetMessage("PASS", "在线条码打印成功...")
                    Me._ScanFinishType = ScanFinishStatus.NoFinsh
                    TxtBarCode.Clear()
                    Me.ActiveControl = Me.TxtBarCode
                End If
                '显示GRID数据
                GetScanItem(TxtCartonID.Text)
            Else
                If Val(LblPackQty.Text.Trim) = Val(LblCurrQty.Text.Trim) Then
                    SetMessage("PASS", "该工单全部扫描完成！")
                    Me._ScanFinishType = ScanFinishStatus.MoidFinsh
                    LblPackQty.Text = 0
                    LblCurrQty.Text = 0
                End If
            End If

            '在线称重重量
            If scanSetting.IsPpidLineWeight = True Then
                SetMessage("PASS", "主条码扫描成功,请开始称重......")
                Me.txtWeight.Enabled = True
                TxtBarCode.Enabled = False
                txt_tmpbarcode.Text = scanSetting.vMainBarCode
                Me.IsOnlineWeightFinish = False
                Me.txtWeight.Focus()
            End If

            TxtBarCode.Clear()
        Catch ex As Exception
            SetMessage("Fail", "在线条码打印异常,请检查料件打印参数设置...")
            MessageBox.Show("数据库连接异常,请检查网络后,重新确认数据扫描!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtBarCode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmOnlinePrintBarcode", "StandScan", "sys")
        End Try
    End Sub

    '条码验证样式
    Private Function CheckStyle(ByRef BarCode As String) As Boolean
        '********************************20160617 田玉琳 Start ---Change by hs ke 20160927 ****************************************************
        '有子条码时，不对子条码验证，只对主条码验证 20170314 田玉琳
        '增加对验证条码流水和唯一性处理
        If scanSetting.vCurrentStandIndex = 1 And scanSetting.vRepeatStyle = "Y" Then
            If txt_tmpbarcode.Text = "" Then
                txt_tmpbarcode.Text = TxtBarCode.Text.Trim

                SetMessage("PASS", BarCode & Space(1) & "扫描成品条码成功,请继续扫描校验条码!")

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

    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt
        FrmError.ShowDialog()
    End Sub

    ''' <summary>
    ''' 保存条码PPlink
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SavePpLinkData() As Boolean
        Dim result As Boolean = False
        Dim SqlStr As New StringBuilder
        Dim I As Int16
        Try

            SqlStr.Append("DECLARE @Revid VARCHAR(10),@StaOrderid VARCHAR(10), @ScanOrderid VARCHAR(10) ")

            For I = 0 To BarcodeTPartIdArr.Length - 1

                Dim tempstr() As String = scanSetting.vmReplaceArray(I + 2, 1).Split("|")
                SqlStr.Append(vbNewLine & String.Format(" SELECT @Revid = Revid ,@StaOrderid = StaOrderid ,@ScanOrderid = ScanOrderid FROM m_RPartStationD_t where TPartid = '{0}' AND State = 1", tempstr(tempstr.Length - 1)))
                SqlStr.Append(vbNewLine & " INSERT M_PPIDLINK_T(EXPPID,STAORDERID,SCANORDERID,ITEMID,PPID,USEY,USERID,INTIME,TPARTID,STATIONID,PARTID,REVID,MARK1) ")
                SqlStr.Append(String.Format(vbNewLine & "VALUES('{0}',@StaOrderid,@ScanOrderid,'{1}','{2}','Y','{3}',GETDATE(),'{4}','{5}','{6}',@Revid,N'{7}');",
                    scanSetting.vMainBarCode, I + 2, BarcodeTPartIdArr(I).ToString, SysMessageClass.UseId.ToLower, tempstr(tempstr.Length - 1),
                      scanSetting.vStandId, scanSetting.PartidStr, scanSetting.MoidStr))
            Next

            DbOperateUtils.ExecSQL(SqlStr.ToString)

            result = True
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmOnlinePrintBarcode", "SavePpLinkData()", "sys")
        End Try
        Return result
    End Function
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

#End Region


    ''' <summary>
    ''' 在线生成箱号
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OnlineCartonID() As String
        Dim printBarcode As New PrintBarcode

        OnlineCartonID = "" ' 初期值设置
        printBarcode.strMOID = Me.TxtMoId.Text.Trim.ToUpper
        printBarcode.LineId = Me.TxtLineId.Text.Trim
        printBarcode.StaionId = scanSetting.vStandId
        printBarcode.StaionName = scanSetting.vStandName
        printBarcode.CartonSame = scanSetting.vCartonSame
        '第二层箱生成规则
        printBarcode.CodeRuleID = scanSetting.CodeRuleID2.Split("/")(2)
        printBarcode.Packid = scanSetting.CodeRuleID2.Split("/")(1)
        printBarcode.PackItems = scanSetting.CodeRuleID2.Split("/")(0)
        printBarcode.IsOnlineGenCartonID2 = True

        If printBarcode.InitializePrintParameter() = False Then
            If printBarcode.CartonID = "00000000" Then
                SetMessage("PASS", "该工单已扫描完成！")
            End If
            Exit Function
        End If

        If printBarcode.BuildCBarCode() = False Then
            SetMessage("FAIL", "生成条码样式有问题，请检查数据！")
            Exit Function
        End If

        If printBarcode.MainMarkSCode("Y") Then
            If String.IsNullOrEmpty(printBarcode.CartonID) Then
                OnlineCartonID = printBarcode.JLabelStr ''生成箱號
            Else
                OnlineCartonID = printBarcode.CartonID
            End If
            '是否尾箱号
            IsTrunk = printBarcode.IsTrunk
            LblPackQty.Text = printBarcode.BoxQty
        Else
            If printBarcode.CartonID = "00000000" Then
                SetMessage("PASS", "该工单已扫描完成！")
            End If
        End If
    End Function

    '设置装箱数
    '设置目前第几箱数量
    Private Sub LoadPalletPaceQty()
        Dim dt As DataTable = DbOperateUtils.GetDataTable(" select isnull(count(Cartonid),0) packcount from m_carton_t where moid='" & Me.TxtMoId.Text & "' ")

        If dt.Rows.Count > 0 Then
            LabCartonQty.Text = dt.Rows(0)("packcount").ToString
        End If
    End Sub

    '当前箱包装完成满箱
    Private Function CheckIsCartonScanFinish() As Boolean
        Dim dt As DataTable = DbOperateUtils.GetDataTable(" select isnull(Cartonqty,0) curQty ,CartonStatus from m_carton_t where Cartonid='" & Me.TxtCartonID.Text & "' ")

        If dt.Rows.Count > 0 Then
            LblCurrQty.Text = dt.Rows(0)("curQty").ToString
            If dt.Rows(0)("CartonStatus").ToString = "Y" Then
                Return True
            End If
        End If
        Return False
    End Function

#Region "獲取掃描記錄"
    Private Sub GetScanItem(ByVal Cartonid As String)
        Dim strSQL As String =
            "SELECT m_Mainmo_t.PartID AS ppartid, 1 AS staorderid, 1 AS scanorderid,m_Cartonsn_t.ppid,m_Mainmo_t.PartID AS tparttext,m_Cartonsn_t.Userid AS username,m_Cartonsn_t.intime " &
            "FROM m_Cartonsn_t INNER JOIN m_Carton_t ON m_Carton_t.Cartonid=m_Cartonsn_t.Cartonid " &
            "INNER JOIN m_Mainmo_t ON m_Mainmo_t.Moid=m_Carton_t.Moid WHERE m_Cartonsn_t.Cartonid='{0}'" &
            "ORDER BY m_Cartonsn_t.intime DESC"
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

    '尾数箱參數設置
    Private Sub ToolOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolOption.Click
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

    ''' <summary>
    ''' Add by cq 20180601, for GP 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TxtCartonID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCartonID.KeyPress
        If e.KeyChar = Chr(13) Then
            CartonIDScanHandle()
        End If
    End Sub

    Private Sub CartonIDScanHandle()
        Dim Sqlstr As String = String.Empty
        Dim StrQty As Integer
        Me.IsScanHWASN = False

        If Me.TxtPartid.Text = "" Then
            WorkStantOption.ErrorStr = "扫描资料未设置，请先设置..."
            SetMessage("Fail", "扫描资料未设置，请先设置...")
            WorkStantOption.BarCodeStr = TxtCartonID.Text
            WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            TxtCartonID.Text = ""
            Me.TxtCartonID.Focus()
            ' PlaySimpleSound(1)
            Exit Sub
        End If

        If Me.TxtCartonID.Text = "00000000" Then

            lblMessage.Text = "该工单已扫描完成！"
            Me.TxtCartonID.Text = ""
            Me.TxtCartonID.Focus()
            ' PlaySimpleSound(1)
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
            ' PlaySimpleSound(1)
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
            'PlaySimpleSound(1)
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
            ' PlaySimpleSound(1)
            Exit Sub
        Else
            ' do nothing
        End If

        If (scanSetting.MoidStr Is Nothing) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtCartonID.Text = ""
            ' Me.TxtPalletID.Text = ""
            ' PlaySimpleSound(1)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.TxtCartonID.Text = ""
            'Me.TxtPalletID.Text = ""
            'PlaySimpleSound(1)
            Exit Sub
        End If

        If (scanSetting.PrtPackingCheck) Then
            printscanPPid = Me.TxtCartonID.Text.Trim
        End If

        Dim IsPallte As String = "" ' IIf(IsScanPallet, "Y", "N")
        Dim CartonIDStr As String = TxtCartonID.Text
        Dim strPalletID As String = String.Empty

        'add by cq 20180820
        '勾选华为ASN扫描 二维码新规则代替外箱扫描 李素霞提出需求
        '华为ASN扫描
        If Me.TxtCartonID.Text.StartsWith("[)>") Then
            Me.IsScanHWASN = True
        End If

        '类型改为
        If (Me.chkIsHWASN.Checked = True) OrElse (IsScanHWASN = True) Then
            Dim chkIsHWASNValue As String = "Y"
            Dim sqlHWASN As String = "declare @PalletID varchar(200), @Msg nvarchar(200),@ReturnValue int" & vbCrLf &
       "exec m_NewCheckHWASN '" + CartonIDStr + "','" + TxtMoId.Text + "','" + TxtPartid.Text + "','" + chkIsHWASNValue + "','" + scanSetting.vStandId + "','" + m_strQRCode + "',3,@PalletID out,@Msg out,@ReturnValue out" & vbCrLf &
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
        'If CheckStyleC(CartonIDStr) = False Then Exit Sub
        '**************田玉琳 修改 20170328***********************END 
        '是否重工扫描(重工工单)--add by hgd 2017-12-05
        Dim isReWork As String = "N"  'IIf(Me.cbIsReWork.Checked, "Y", "N")
        Try
            '2015-04-02     马锋       Me.TxtMoId.Text  Me.TxtLineId.Text
            Sqlstr = "DECLARE @strmsgid varchar(1),@strmsgText nvarchar(50),@NewCartonid varchar(100),@qty int, @palletQty float " & _
                "EXECUTE [m_NewCheckPallMulletCarton_p] " & _
                "'" & Trim(scanSetting.MoidStr) & "','" & CartonIDStr & "','" & IsPallte.Trim & "','" & strPalletID & "','" & Trim(scanSetting.LineStr) & "','" & SysMessageClass.UseId.Trim & "','" & scanSetting.vCartonSame.Trim & "','" & scanSetting.vSamePacking.Trim & "'," & _
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
                            LblCurrQty.Text = dt.Rows(0)(4).ToString  'LblCurrCarQty
                        End If

                        'Add by cq 20170714
                        If (Me.chkIsHWASN.Checked = True OrElse Me.IsScanHWASN = True) AndAlso (Not String.IsNullOrEmpty(m_strQRCode)) Then
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
        Return True
    End Function


    Private Sub PlaySimpleSound(ByVal PassOrNg As Integer)
        If (Me.chbMessage.Checked) Then
            Select Case PassOrNg
                Case 0 '正常提示音
                    'My.Computer.Audio.Play(My.Resources.Resource1.ok_zhcn, AudioPlayMode.Background)
                    'BeepUp.Beep(500, okWavPlayTime)
                Case 1 '错误提示音
                    'My.Computer.Audio.Play(My.Resources.Resource1.fail_zhcn, AudioPlayMode.Background)
                    BeepUp.Beep(2800, ngWavPlayTime)
                Case 2
                    'My.Computer.Audio.Play(My.Resources.Resource1.chimes, AudioPlayMode.Background)
            End Select
        End If
    End Sub


    '设置装箱数
    '设置目前第几箱数量
    'Private Sub SetCurQty()
    '    Dim strSQL As String = " select isnull(Cartonqty,0) curQty from m_carton_t where moid='{0}' and CartonStatus = 'N' "
    '    strSQL = String.Format(strSQL, TxtMoId.Text)
    '    Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

    '    If dt.Rows.Count > 0 Then
    '        LblCurrQty.Text = dt.Rows(0)("curQty").ToString
    '    Else
    '        LblCurrQty.Text = LblPackQty.Text
    '    End If
    'End Sub

    Private Sub txtWeight_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtWeight.PreviewKeyDown

        If e.KeyValue = 13 Then

            PpidOnlineWeight()
        End If

    End Sub

    '扫描重量
    Private Sub ScanWeight(ByVal Weight As String)
        Dim o_strSql As New StringBuilder

        Try
            o_strSql.Append("if not exists(select 1 from m_OnlineWeightPpid_t  where ppid='" & Me.txt_tmpbarcode.Text & "' and moid='" & Me.TxtMoId.Text & "'  and stationid='" & scanSetting.vStandId & "'  )")
            o_strSql.Append(" INSERT INTO m_OnlineWeightPpid_t (ppid,stationid,Moid,Weight,Userid,Intime)")
            o_strSql.Append(" VALUES('" & Me.txt_tmpbarcode.Text & "','" & scanSetting.vStandId & "' ,'" & Me.TxtMoId.Text & "','" & Weight & "','" & SysMessageClass.UseId.Trim & "',getdate())")
            DbOperateUtils.ExecSQL(o_strSql.ToString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    '在线产品称重
    Private Sub PpidOnlineWeight()

        Dim strWeight As String
        If String.IsNullOrEmpty(txtWeight.Text.Trim) Then
            txtWeight.Focus()
            Exit Sub
        End If
        strWeight = Me.txtWeight.Text.Trim
        If Not IsNumeric(strWeight) Then
            MessageBox.Show("重量格式不正确！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information)
            PlaySimpleSound(1)
            txtWeight.Text = ""
            Me.txtWeight.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If
        If CDec(strWeight) < CDec(scanSetting.PpidUpLimitWeight) OrElse CDec(strWeight) > CDec(scanSetting.PpidLowLimitWeight) Then
            Dim _ErrMsg As String = "重量" & strWeight & ",超出标准重量,该产品重量上下限为(" & scanSetting.PpidUpLimitWeight & "-" & scanSetting.PpidLowLimitWeight & ")....."
            WorkStantOption.ErrorStr = _ErrMsg
            SetMessage("Fail", _ErrMsg)
            WorkStantOption.BarCodeStr = strWeight
            WorkStantOption.vMainBarCode = strWeight
            Me.txtWeight.Text = ""
            ShowFrmScanErrPrompt()
            Me.txtWeight.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        ScanWeight(strWeight)
        Me.txtWeight.Text = ""
        TxtBarCode.Enabled = True
        txtWeight.Enabled = False
        LabResult.ForeColor = Color.Lime
        lblMessage.ForeColor = Color.Lime
        txt_tmpbarcode.Text = ""
        Select Case _ScanFinishType
            Case ScanFinishStatus.Finsh
                SetMessage("PASS", "重量" & strWeight & ",称重成功,该箱已经包装完成,请扫描下一箱...！")
            Case ScanFinishStatus.NoFinsh
                SetMessage("PASS", "重量" & strWeight & ",称重成功,在线条码打印成功...")
            Case ScanFinishStatus.MoidFinsh
                SetMessage("PASS", "重量" & strWeight & ",称重成功,该工单全部扫描完成！")
            Case Else
                SetMessage("PASS", "重量" & strWeight & ",称重成功,请继续扫描产品！")
        End Select

        Me.IsOnlineWeightFinish = True
        TxtBarCode.Focus()
    End Sub

    Private Sub txtWeight_Leave(sender As Object, e As EventArgs) Handles txtWeight.Leave
        If scanSetting.IsPpidLineWeight = True AndAlso Me.IsOnlineWeightFinish = False AndAlso Not String.IsNullOrEmpty(txt_tmpbarcode.Text) Then
            PpidOnlineWeight()
        End If
    End Sub

    Private Sub TxtSnStyle2_Enter(sender As Object, e As EventArgs) Handles TxtSnStyle2.Enter
        '2018-06-07 hgd  因电子称导致失去焦点
        TxtBarCode.Focus()
    End Sub

    Private Sub toolSpecialScanSet_Click(sender As Object, e As EventArgs) Handles toolSpecialScanSet.Click
        Me.cbIsReWork.Enabled = True
        Me.chkIsHWASN.Enabled = True
    End Sub

    ''' <summary>
    ''' 设置菜单权限-用户权限设定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMenuRight()
        Me.toolSpecialScanSet.Enabled = IIf(DbOperateUtils.DBNullToStr(Me.toolSpecialScanSet.Tag) = "YES", True, False)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            If TxtPartid.Text = "" Then
                SetMessage("Fail", "扫描资料未设置...")
                Exit Sub
            End If

            'If scanSetting.PrtPackingCheck = False Then
            '    SetMessage("Fail", "在线打印的PE袋才能重新打印...")
            '    Exit Sub
            'End If

            If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
                SetMessage("Fail", "请设置在线标签打印机选项...")
                Exit Sub
            End If

            Dim frm As New FrmOnlineWorkPrintPES()
            frm.Moid = TxtMoId.Text.Trim
            frm.PartId = TxtPartid.Text.Trim
            frm.PrintName = Me.cboPrinterList.Text.Trim
            ' frm.PrintType = FrmCartonRepeatPrint.EnumPrintType.PEPocket
            frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
End Class