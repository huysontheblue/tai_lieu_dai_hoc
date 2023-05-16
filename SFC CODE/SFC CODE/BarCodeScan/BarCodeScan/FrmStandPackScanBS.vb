

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

#End Region
Public Class FrmStantPackScanBS

#Region "窗體變量"

    Dim IsCustPart As Boolean
    Dim IsPrtPacking As Boolean
    Dim IsScanPallet As Boolean
    Dim PalletID As String
    Dim IsFull As Boolean = False           '棧板是否裝滿
    Dim IsLinePrint As String = "N"         '是否在线打印产品条码
    Dim IsReadSn As String = "N"            '是否读取序号
    Dim TgenCarton As String = "N"          '自动生面外箱
    Dim IsPackingPPID As String = "N"       '是否产品序号相同（允许箱产品同包装）
    Dim IsPackType As String = "N"          '包装类型
    Dim IsPrtSelf As String = "N"           '是否在系统里面打印, cq 20160218
    Dim IsTrunk As String = "N"             '田玉琳 20160419
    Dim IsPrtSelfCarton As String = "N"            '是否在系统里面打印, LG 20160920
    Dim IsPrtSelfPALLET As String = "N"
    'Dim btApp As BarTender.Application
    'Dim btFormat As New BarTender.Format
    Dim PackArray As New SysMessageClass.PrtStructure
    Dim printscanPPid As String = String.Empty
    Public scanSetting As New ScanSetting
    Dim repeatPara As String

#End Region

#Region "窗體事件"
    '快捷键
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
        'btApp = New BarTender.ApplicationClass
        Try
            TxtBarCode.Enabled = False
            LblMainBarCode.Text = ""
            LabResult.Text = ""
            lblMessage.Text = "请设置扫描资料"
            ToolUsename.Text = SysMessageClass.UseName
            txt_tmpbarcode.Text = ""

            ' SqlClassM.GetPrintersList(cboPrinterList)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    '掃描設置
    Private Sub BnScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolScanSet.Click
        Dim strSQL As String = ""
        isCartonPalletScan = False
        scanSetting.FormName = Me.Name
        If LblMainBarCode.Text.Trim <> "" Then
            MessageUtils.ShowInformation("該站點對應的次條碼未掃描完整,不能再設置!")
            Exit Sub
        End If

        Try
            Label11.Text = ""
            Label13.Text = ""
            Label24.Text = ""
            Label25.Text = ""
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

                Me.LblCartonQty.Text = "0"
                Me.LblCurrCarQty.Text = "0"
                Me.LblPackQty.Text = "0"
                Me.LblCurrQty.Text = "0"
                Me.LabScanQty.Text = "0"
                Me.LabMoQty.Text = "0"
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
                TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
                TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
                LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                'TxtBarCode.MaxLength = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 2)
                ControlState(False)

                strSQL = " SELECT ISNULL(IslineMbarcode,'N') IslineMbarcode,isnull(IsUsb,'N') IsUsb,isnull(LinePrtY,'N') LinePrtY," & _
                           " ISNULL(IsAllowRe,'N') as IsProductSame, isnull(IsPackType,'N') as IsPackType,isnull(repeatPara,'') repeatPara, " & _
                           " ISNULL(IsPrtSelf,'N') as IsPrtSelf,ISNULL(IsPrtSelfCarton,'N') as IsPrtSelfCarton,ISNULL(IsPrtSelfPALLET,'N') as IsPrtSelfPALLET" & _
                           " FROM m_RPartStationD_t where PPartid='" & TxtPartid.Text & "' and TPartid='" & TxtPartid.Text & "' " & _
                           " AND Stationid='" & scanSetting.vStandId & "'  and State='1'"
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    IsLinePrint = dt.Rows(0)!IslineMbarcode
                    IsReadSn = dt.Rows(0)!IsUsb
                    IsPackingPPID = dt.Rows(0)!IsProductSame
                    IsPackType = dt.Rows(0)!IsPackType
                    TgenCarton = dt.Rows(0)!LinePrtY
                    IsPrtSelf = dt.Rows(0)!IsPrtSelf 'cq20160218
                    IsPrtSelfCarton = dt.Rows(0)!IsPrtSelfCarton 'LG20160920
                    IsPrtSelfPALLET = dt.Rows(0)!IsPrtSelfPALLET 'LG20160920
                    repeatPara = dt.Rows(0)!repeatPara
                    'Me.TxtBarCode.Multiline = True
                End If

                ''''  IsUsb成品是否读取usb序号
                ''  LblType.Text = scanSetting.moType
                '''强制检查工单是否完成
                TxtBarCode.Clear()
                TxtCartonID.Clear()
                TxtPalletID.Clear()
                If CheckIsMoFinish() Then
                    TxtPalletID.Enabled = False
                    TxtCartonID.Enabled = False
                    Exit Sub
                End If
                If isCartonPalletScan Then
                    scanSetting.IsOnlineGenCartonID = False
                    scanSetting.IsOnlineGenPalletID = False
                    TxtBarCode.Enabled = False
                End If
                If Not IsScanPallet Then
                    PnlPallet.Visible = False
                    '''''''獲取未裝滿外箱
                    If scanSetting.vCartonSame = "Y" Then
                        strSQL = "select a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as qty from M_Carton_t a join m_SnSBarCode_t b on rtrim(replace(a.cartonid,right(a.cartonid,8),''))=b.sbarcode " &
                           " where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc"
                    Else
                        '是自制条码
                        If IsPrtSelf = "Y" Then
                            strSQL = "select a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,b.qty from M_Carton_t a join m_SnSBarCode_t b on a.cartonid=b.sbarcode " &
                                    " where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc"
                        Else '非自制条码
                            'cq 20160218
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
                        ControlState(True)
                    Else
                        If scanSetting.PrtPackingCheck Then
                            ControlState(False)
                        Else
                            If scanSetting.IsOnlineGenCartonID Then  'Add by cq 20160126
                                Me.TxtCartonID.Text = OnlineCartonID()
                                CartonIDScanHandle()
                                ControlState(True)
                            Else
                                ControlState(False)
                            End If
                        End If
                    End If
                Else
                    TxtPalletID.Clear()
                    PnlPallet.Visible = True
                    '''''''獲取未裝滿棧板
                    'LblPackQty 应装产品  实装 LblCurrQty, 'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                    dt.Reset()
                    dt = DbOperateUtils.GetDataTable("select Palletid, MultiQty,Palletqty from M_PalletM_t where  Moid='" & Me.TxtMoId.Text.Trim & "' and Teamid='" & Me.TxtLineId.Text.Trim & "'   and PalletStatus='N' ")
                    If dt.Rows.Count > 0 Then
                        TxtPalletID.Enabled = False
                        'CountReader.Read()
                        TxtPalletID.Text = dt.Rows(0)("Palletid").ToString
                        LblCartonQty.Text = dt.Rows(0)("MultiQty").ToString
                        Me.LblCurrCarQty.Text = (Convert.ToInt32(dt.Rows(0)("Palletqty").ToString)).ToString
                        TxtPalletID.Enabled = False
                        'TxtPalletID.BorderColor = Color.FromArgb(35, 130, 196)

                        '''''''獲取未裝滿外箱
                        Dim Ncarton As Boolean = False
                        dt.Reset()
                        If scanSetting.vCartonSame = "Y" Then
                            '  dt = DbOperateUtils.GetDataTable("select a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,b.qty from M_Carton_t a join m_SnSBarCode_t b on rtrim(replace(a.cartonid,right(a.cartonid,8),''))=b.sbarcode where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc")
                            'Else
                            '  dt = DbOperateUtils.GetDataTable("select a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,b.qty from M_Carton_t a join m_SnSBarCode_t b on a.cartonid=b.sbarcode where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' order by a.Intime desc")
                            ' End If
                            strSQL = "select a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as qty from M_Carton_t a join m_SnSBarCode_t b on rtrim(replace(a.cartonid,right(a.cartonid,8),''))=b.sbarcode join m_palletcarton_t c on a.cartonid=c.cartonid" &
                             " where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' and c.palletid='" & TxtPalletID.Text.Trim & "' order by a.Intime desc"
                        Else
                            '是自制条码
                            If IsPrtSelf = "Y" Then
                                strSQL = "select a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,b.qty from M_Carton_t a join m_SnSBarCode_t b on a.cartonid=b.sbarcode join m_palletcarton_t c on a.cartonid=c.cartonid" &
                                        " where a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and a.CartonStatus='N' and c.palletid='" & TxtPalletID.Text.Trim & "'  order by a.Intime desc"
                            Else '非自制条码
                                'cq 20160218
                                strSQL = " SELECT a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity,isnull(a.PackingQuantity,0) AS qty " & _
                                           " FROM M_Carton_t a  " & _
                                           " WHERE a.Moid='" & Me.TxtMoId.Text.Trim & "' and a.Teamid='" & Me.TxtLineId.Text.Trim & "' and " & _
                                           " a.CartonStatus='N' order by a.Intime desc"
                            End If
                        End If
                        dt = DbOperateUtils.GetDataTable(strSQL)
                        If dt.Rows.Count > 0 Then
                            Ncarton = True
                            'CountReader.Read()
                            TxtCartonID.Text = dt.Rows(0)("Cartonid").ToString
                            LblPackQty.Text = dt.Rows(0)("qty").ToString
                            Me.LblCurrQty.Text = dt.Rows(0)("cartonqty").ToString
                            'CountReader.Close()
                            GetScanItem(Me.TxtCartonID.Text)
                            ControlState(True)
                        Else
                            'CountReader.Close()
                            ' ControlState(False)
                            If scanSetting.IsOnlineGenCartonID Then  'Add by LG 20160126
                                Me.TxtCartonID.Text = OnlineCartonID()
                                CartonIDScanHandle()
                                ControlState(True)
                            Else
                                ControlState(False)
                            End If
                        End If
                        'CountReader.Close()
                        'Conn.PubConnection.Close()
                    Else
                        'CountReader.Close()
                        'Conn.PubConnection.Close()
                        TxtPalletID.Enabled = True
                        TxtCartonID.Enabled = False
                        TxtPalletID.Focus()
                        If scanSetting.IsOnlineGenPalletID Then  'Add by cq 20160126
                            Me.TxtPalletID.Text = OnlinePalletID()
                            If Not String.IsNullOrEmpty(Me.TxtPalletID.Text) Then
                                PalletIDScanHandle()
                                ControlState(False, False)
                            End If
                        End If
                        If scanSetting.IsOnlineGenCartonID Then  'Add by LG 20160126
                            Me.TxtCartonID.Text = OnlineCartonID()
                            CartonIDScanHandle()
                            ControlState(True)
                        End If
                    End If
                End If
            End If
            scanSetting.CheckStr = False
            If (scanSetting.PrtPackingCheck) Then
                printscanPPid = Me.TxtCartonID.Text.Trim
            End If
            'add by LG 20160920 for non self print carton,just for non flow code
            isNonSelfCartonSeries = False
            If IsPrtSelfCarton = "N" AndAlso repeatPara.IndexOf("C-") < 0 Then   '非系统单码扫描
                GetNonSelfCarton()
            Else '多码扫描，直接卡样式
            End If
            isNonSelfPalletSeries = False
            If IsPrtSelfPALLET = "N" AndAlso repeatPara.IndexOf("P-") < 0 Then  '非系统单码扫描
                GetNonSelfPallet()
            Else '多码扫描直接卡样式
            End If
            If IsPackType = "Y" Then
                getCartonScanItem()
            End If
            If Not String.IsNullOrEmpty(repeatPara) Then
                ClearBarcodeStyle()
                ParseBarcodeStyle()
            Else
                ClearBarcodeStyle()
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
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmStandPackScanBS", "BnScanSet_Click", "sys")
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
            If chkMoQty.Checked Then
                If CInt(LabMoQty.Text) = CInt(LabScanQty.Text) Then
                    SetMessage("FAIL", "工单已扫描完成")
                    Exit Sub
                End If
            End If
            StandScan()
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
        'If TxtPartid.Text = "" Then
        '    SetMessage("Fail", "扫描资料未设置...")
        '    Exit Sub
        'End If
        'If scanSetting.IsLinePrintFullCode = False Then
        '    SetMessage("Fail", "在线打印的整个外箱才能重新打印...")
        '    Exit Sub
        'End If
        'If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
        '    SetMessage("Fail", "请设置在线标签打印机选项...")
        '    Exit Sub
        'End If

        'Try
        '    Dim frm As New FrmCartonRepeatPrint()
        '    frm.Moid = TxtMoId.Text.Trim
        '    frm.PartId = TxtPartid.Text.Trim
        '    frm.LabelNum = scanSetting.LabelNum
        '    frm.PrintName = Me.cboPrinterList.Text.Trim
        '    frm.PrintType = FrmCartonRepeatPrint.EnumPrintType.FullCartonSn
        '    frm.ShowDialog()

        'Catch ex As Exception
        '    lblMessage.Text = ex.Message
        '    SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNewStantPackScan", "tsbRepeatPrint_Click", "sys")
        '    Exit Sub
        'End Try
        Try
            isCartonPalletScan = True
            BnScanSet_Click(Nothing, Nothing)
            TxtBarCode.Enabled = False
            If String.IsNullOrEmpty(TxtMoId.Text) Then
                MessageBox.Show("请先做扫描设置")
                Exit Sub
            End If
            GetBarcodeStyle()
            Dim a As String() = {"true", "false", "true"}
            Using frm As FrmIssueHandler = New FrmIssueHandler(TxtMoId.Text, a)
                frm.StartPosition = FormStartPosition.CenterParent
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '在线称重打印
    Private Sub tsbLineWeight_Click(sender As Object, e As EventArgs) Handles tsbLineWeight.Click
        If TxtPartid.Text = "" Then
            SetMessage("Fail", "扫描资料未设置...")
            Exit Sub
        End If
        If scanSetting.IsLinePrintFullCode = False Then
            SetMessage("Fail", "在线打印的整个外箱才能打印...")
            Exit Sub
        End If
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

    '错误扫描清除
    Private Sub ToolError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '权限检查
        Dim CheckRead As SqlClient.SqlDataReader
        Dim PubClass As New MainFrame.SysDataHandle.SysDataBaseClass

        CheckRead = PubClass.GetDataReader("select distinct a.userid from m_Users_t a left join m_userright_t b on a.userid=b.userid where a.UserId='" & SysMessageClass.UseId & "' and b.tkey='m0510m_'")
        If Not CheckRead.Read Then
            MessageBox.Show("你没有扫描设置的权限...", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        CheckRead.Close()
        PubClass = Nothing

        If String.IsNullOrEmpty(TxtMoId.Text.Trim) Then
            lblMessage.Text = "获取清除工单信息失败，请设置扫描参数！"
            Exit Sub
        End If

        If String.IsNullOrEmpty(TxtCartonID.Text.Trim) And String.IsNullOrEmpty(TxtPalletID.Text.Trim) Then
            lblMessage.Text = "未做包装扫描，无法执行清除！"
            Exit Sub
        End If

        Dim Sqlstr As String = String.Empty
        Try
            Sqlstr = "declare @strmsgid varchar(8),@strmsgText varchar(64)" & _
                    " execute Exec_PackingError @strmsgid output,@strmsgText output,'" & Me.TxtMoId.Text.Trim & "','" & Me.TxtCartonID.Text.Trim & "','" & Me.TxtPalletID.Text.Trim & " ' " & _
                    " select @strmsgid ,isnull(@strmsgText,'')"

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1"
                        lblMessage.Text = dt.Rows(0)(1).ToString()
                        Me.TxtCartonID.Clear()
                        Me.TxtPalletID.Clear()
                    Case "0"
                        lblMessage.Text = dt.Rows(0)(1).ToString()
                End Select
            Else
                lblMessage.Text = "系统无法识别此外箱标签序号！"
                PlaySimpleSound(1)
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmInCarton", "GetScanItem", "sys")
            Exit Sub
        End Try

    End Sub

    Private Sub FrmStantPackScan_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' If Not btApp Is Nothing Then
        'btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
        ' System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp)
        ' End If
        DisposeData()
        scanSetting.CustIdString = Nothing
        scanSetting.MoidStr = Nothing
        scanSetting.LengthStr = Nothing
        scanSetting.DateCheck = Nothing

        ' Quit the BarTender Print Engine, but do not save changes to any open formats.
        'If engine IsNot Nothing Then
        '    engine.Stop(SaveOptions.DoNotSaveChanges)
        'End If
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
#End Region

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
            'If CInt(dt.Rows(iIndex)!scanorderid) > orderIndex Then
            '    orderIndex = CInt(dt.Rows(iIndex)!scanorderid)
            'End If
        Next

        DGridBarCode.AutoResizeColumns()

        'scanSetting.vCurrentStandIndex = IIf(scanSetting.vStandMaxStaIndex > orderIndex, orderIndex + 1, 1)
        'TxtSnStyle1.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)
        'TxtSnStyle2.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 1)
        'TxtBarCode.MaxLength = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 2)
        'LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"

    End Sub
#End Region

#Region "條碼掃描"

    Private Sub StandScan()

        If (scanSetting.PrtPackingCheck) Then
            If (printscanPPid.Trim.ToUpper <> Me.TxtBarCode.Text.Trim.ToUpper) Then
                lblMessage.Text = "掃描產品標籤于打印PE袋標籤不符..."
                TxtBarCode.Clear()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If

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
        'LblPackQty 应装产品  实装 LblCurrQty ,LblCartonQty(应装箱数)  已装箱LblCurrCarQty
        Dim BarCode As String = Trim(TxtBarCode.Text)
        'TxtBarCode.Text = ""
        Dim ReadSn As String = ""
        Dim E75sn As String = "" ''E75序号
        Dim E75Msg As String = "" ''E75序号内容
        If IsReadSn = "Y" Then

            If InStr(TxtBarCode.Text.ToLower, "accessory serial number:") <= 0 Then Exit Sub
            Try
                For i As Integer = 0 To TxtBarCode.Lines.Length - 1
                    If InStr(TxtBarCode.Lines(i).ToString.ToLower, "module serial number:") > 0 Then
                        E75sn = TxtBarCode.Lines(i).ToString.Split(":")(1).Trim
                        Continue For
                    End If
                    If InStr(TxtBarCode.Lines(i).ToString.ToLower, "accessory serial number:") > 0 Then
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

            E75Msg = TxtBarCode.Text.Trim()
            If ReadSn = "" Then
                lblMessage.Text = "该关键物料未经过NI测试站，进行烧录..."
                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                PlaySimpleSound(1)
                Exit Sub
            Else
                Me.TxtBarCode.Text = ReadSn
            End If
        Else
            ReadSn = Me.TxtBarCode.Text.Trim
        End If

        If Me.TxtMoId.Text = "" Then
            MessageUtils.ShowError("請先設置好掃描基本信息!")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If ''90241
        If BarCode = "" Then
            MessageUtils.ShowError("產品條碼不能為空!")
            TxtBarCode.Text = ""
            Me.TxtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        '********************************20160615 田玉琳 Start ****************************************************
        '非系统打印条码要求验证样式
        'TxtBarCode
        'If IsPrtSelf <> "Y" And TxtSnStyle1.Text.Trim.Length <> 0 Then
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
                Exit Sub
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
                Exit Sub
            End If
        End If
        '********************************20160615 田玉琳 End ****************************************************

        '********************************20160617 田玉琳 Start ****************************************************
        ' 重复扫描条码验证
        If txt_tmpbarcode.Text = "" Then
            'If scanSetting.vRepeatStyle = "Y" Then
            '    txt_tmpbarcode.Text = TxtBarCode.Text
            '    LabResult.ForeColor = Color.Green
            '    lblMessage.ForeColor = Color.Green
            '    LabResult.Text = BarCode & Space(3) & "扫描成品条码成功，请继续扫描产品条码！"
            '    lblMessage.Text = "PASS"
            '    TxtBarCode.Clear()
            '    TxtBarCode.Focus()
            '    Exit Sub
            'End If
        Else
            'If scanSetting.vRepeatStyle = "Y" Then
            '    If TxtBarCode.Text = txt_tmpbarcode.Text Then
            '        txt_tmpbarcode.Text = ""
            '    Else
            '        Me.LabResult.Text = ""
            '        PlaySimpleSound(1)
            '        WorkStantOption.BarCodeStr = BarCode
            '        WorkStantOption.vMainBarCode = Me.TxtBarCode.Text
            '        WorkStantOption.ErrorStr = "两次扫描成品条码不相同..."
            '        LabResult.ForeColor = Color.Gold
            '        lblMessage.ForeColor = Color.Gold
            '        lblMessage.Text = "FAIL..."
            '        LabResult.Text = WorkStantOption.ErrorStr
            '        ShowFrmScanErrPrompt()
            '        If WorkStantOption.vDeserTionFlag = True Then
            '            TxtBarCode.Clear()
            '            WorkStantOption.vCurrentStandIndex = 1
            '            TxtSnStyle1.Text = WorkStantOption.vstyleArray(1, 0)
            '            TxtSnStyle2.Text = WorkStantOption.vstyleArray(1, 1)
            '            'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
            '            LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
            '        End If
            '        TxtBarCode.Text = ""
            '        Me.TxtBarCode.Focus()
            '        Exit Sub
            '    End If
            'End If
        End If
        '********************************20160617 田玉琳 End ****************************************************

        '在线打印整箱
        If scanSetting.IsLinePrintFullCode Then
            If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
                SetMessage("Fail", "请设置在线标签打印机选项...")
                TxtBarCode.Clear()
                Me.ActiveControl = Me.TxtBarCode
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If

        BarCode = Me.TxtBarCode.Text.Replace(vbNewLine, "").Trim()

        Dim Sqlstr As String = String.Empty
        Dim o_strIsRepaired As String = IIf(Me.chkIsRepaired.Checked, "Y", "N")

        '箱层级判断/料件号判断     'TxtBarCode  扫描箱号：判断工站扫描是装箱/装产品
        Try
            Dim tempstr() As String = scanSetting.vmReplaceArray(scanSetting.vCurrentStandIndex, 1).Split("|")
            Sqlstr = " DECLARE @strmsgid varchar(1), @strmsgText varchar(150), @currqty int, @currPqty int, @OutPQty int, @outPPID nvarchar(64) " & _
                     " EXECUTE [m_NewCheckPackScan_P] '" & Trim(BarCode) & "','" & E75sn & "','" & E75Msg & "'," & _
                      "'" & Trim(TxtMoId.Text) & "','" & Trim(TxtLineId.Text) & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                      "'" & scanSetting.PartidStr & "','" & tempstr(tempstr.Length - 1) & "','" & LblMainBarCode.Text.Trim & "'," & _
                      "'" & scanSetting.vStandId & "','" & scanSetting.vStandIndex & "','" & scanSetting.vCurrentStandIndex & "'," & _
                      "'" & scanSetting.vStandMaxStaIndex & "','" & Me.TxtCartonID.Text & "','" & Me.TxtPalletID.Text.Trim & "','" &
                      Me.LblPackQty.Text & "','" & IsPackType.Trim & "','" & scanSetting.vSamePacking.Trim & "'," & _
                      " '" & o_strIsRepaired & "'," & _
                      "@strmsgid output,@strmsgText output,@currqty output,@currPqty output, @OutPQty output,@OutPPID output " & _
                      "SELECT @strmsgid,@strmsgText,isnull(@currqty,1) as currqty,isnull(@currPqty,1) as currPqty, isnull(@OutPQty,0) as outPQty,@OutPPID as PPID"
            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0", "1", "2", "3"
                        scanSetting.ErrorStr = dt.Rows(0)(1)
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
                        Exit Sub
                    Case "5"
                        scanSetting.ErrorStr = dt.Rows(0)(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "6"
                        PlaySimpleSound(0)
                        Me.LblCurrQty.Text = dt.Rows(0)(2)
                        Me.TxtBarCode.Text = dt.Rows(0)(5)
                        Me.LabScanQty.Text = CInt(LabScanQty.Text) + 1
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

                        'If ToolMainBarcode.Visible = False Then ToolMainBarcode.Visible = True
                        scanSetting.vCurrentStandIndex = 1
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
                        Exit Sub
                    Case "7"
                        PlaySimpleSound(0)
                        'Me.LabCartonQty.Text = RecDr.GetInt32(3)
                        Me.LblCurrQty.Text = dt.Rows(0)(2)
                        Me.TxtBarCode.Text = dt.Rows(0)(5)
                        Me.LabScanQty.Text = CInt(LabScanQty.Text) + 1
                        If (scanSetting.ScanPalletCheck) Then
                            Me.LblCurrCarQty.Text = dt.Rows(0).Item("OutPQty").ToString
                            Me.LblCartonQty.Text = dt.Rows(0).Item("currPqty").ToString
                        End If
                        'PlaySimpleSound(0)
                        'LblPackQty 应装产品  实装 LblCurrQty, 'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                        If IsScanPallet AndAlso Convert.ToInt32(LblCartonQty.Text) = Convert.ToInt32(LblCurrCarQty.Text) Then
                            SetMessage("PASS", "扫描成功，请扫描大外箱/袋或栈板条码！")
                            '2015-03-10     马锋    调整到存储过程更新
                            'Conn.ExecSql("update M_palletM_t set palletstatus='Y' where palletid='" & Me.TxtPalletID.Text & "'")
                            DGridBarCode.Rows.Clear()
                            'SetGridHeadColumn()
                            'LblCurrCarQty.Text = (Convert.ToInt32(LblCurrCarQty.Text) + 1).ToString
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
                            'LblCurrQty.Text = Int(LblCurrQty.Text) + 1
                            ControlState(False, True)
                            If scanSetting.IsOnlineGenPalletID Then
                                If chkShowCartonFull.Checked = True Then
                                    If ShowOkCancel() = True Then
                                        Me.TxtPalletID.Text = OnlinePalletID()
                                        If Not String.IsNullOrEmpty(Me.TxtPalletID.Text) Then
                                            PalletIDScanHandle()
                                            Me.TxtPalletID.Enabled = False
                                            ControlState(False)
                                        End If
                                        If scanSetting.IsOnlineGenCartonID Then  'Add by LG 20160126
                                            Me.TxtCartonID.Text = OnlineCartonID()
                                            CartonIDScanHandle()
                                            ControlState(True)
                                        End If
                                    Else
                                        ControlState(False, True)
                                        Me.TxtPalletID.Focus()
                                        Exit Sub
                                    End If
                                Else
                                    Me.TxtPalletID.Text = OnlinePalletID()
                                    If Not String.IsNullOrEmpty(Me.TxtPalletID.Text) Then
                                        PalletIDScanHandle()
                                        Me.TxtPalletID.Enabled = False
                                        ControlState(False)
                                    End If
                                    If scanSetting.IsOnlineGenCartonID Then  'Add by LG 20160126
                                        Me.TxtCartonID.Text = OnlineCartonID()
                                        CartonIDScanHandle()
                                        ControlState(True)
                                    End If
                                End If

                            End If
                            Exit Sub
                        Else
                            SetMessage("PASS", BarCode & Space(3) & "该箱/袋已经包装完成,请扫描下一箱/袋...")
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

                            If scanSetting.PrtPackingCheck Then
                                ControlState(False)
                                Me.TxtCartonID.Focus()
                            Else
                                If scanSetting.IsOnlineGenCartonID Then 'Add by cq20160127
                                    '**************田玉琳 修改 20160419***********************Start 
                                    If IsTrunk = "N" Then
                                        If chkShowCartonFull.Checked = True Then
                                            If ShowOkCancel() = True Then
                                                Me.TxtCartonID.Text = OnlineCartonID()
                                            Else
                                                ControlState(False, False)
                                                Me.TxtCartonID.Focus()
                                                Exit Sub
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
                                    ControlState(False)
                                    Me.TxtCartonID.Focus()
                                End If
                            End If

                            Exit Sub
                        End If
                End Select
                scanSetting.BarCodeStr = BarCode
                scanSetting.vMainBarCode = Me.LblMainBarCode.Text
                SetMessage("FAIL", BarCode & Space(3) & "扫描时发生错误！")
                Dim FrmError As New FrmScanErrPrompt(scanSetting)
                FrmError.ShowDialog()

                TxtBarCode.Text = ""
                Me.TxtBarCode.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtBarCode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmNewStantPackScan", "StandScan", "sys")
        End Try
    End Sub

    Dim currentCartonIndex As Integer = 0
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
            If CInt(LblCartonQty.Text) <= CInt(LblCurrCarQty.Text) Then
                lblMessage.Text = "外箱装栈板时，发生异常..."
                TxtCartonID.Clear()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If

        'EBU在线打印
        If (scanSetting.PrtPackingCheck) Then
            If (String.IsNullOrEmpty(scanSetting.CodeRuleID)) Then
                lblMessage.Text = "在线打印失败，没有配置打印标签参数..."
                TxtCartonID.Clear()
                Me.ActiveControl = Me.TxtCartonID
                PlaySimpleSound(1)
                Exit Sub
            End If

            If (String.IsNullOrEmpty(Me.cboPrinterList.Text)) Then
                lblMessage.Text = "请设置在线标签打印机选项..."
                TxtCartonID.Clear()
                Me.ActiveControl = Me.TxtCartonID
                PlaySimpleSound(1)
                Exit Sub
            End If
            Dim strCheckProd As String
            Try
                strCheckProd = " DECLARE @RTVALUE VARCHAR(8),@RTMSG NVARCHAR(128) EXECUTE Exec_CheckPPIDTest @RTVALUE OUTPUT, @RTMSG OUTPUT, " & _
                               " '" & SysMessageClass.UseId.Trim & "', '" & Trim(scanSetting.PartidStr) & "', '" & Trim(scanSetting.MoidStr) & "', '" & Trim(scanSetting.LineStr) & "', " & _
                               " '" & scanSetting.vStandId.Trim & "', '" & scanSetting.vStandIndex & "', '" & scanSetting.vCurrentStandIndex & "', '" & Me.TxtCartonID.Text.Trim & "' " & _
                               " SELECT @RTVALUE, @RTMSG "
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strCheckProd)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)(0).ToString() = "0" Then
                        lblMessage.Text = dt.Rows(0)(1).ToString()
                        TxtCartonID.Clear()
                        Me.ActiveControl = Me.TxtCartonID
                        PlaySimpleSound(1)
                        Exit Sub
                    End If
                Else
                    lblMessage.Text = "检查条码" & Me.TxtCartonID.Text & "测试结果异常..."
                    TxtCartonID.Clear()
                    Me.ActiveControl = Me.TxtCartonID
                    PlaySimpleSound(1)
                    Exit Sub
                End If
            Catch ex As Exception
                lblMessage.Text = "检查条码" & Me.TxtCartonID.Text & "测试结果异常..."
                TxtCartonID.Clear()
                Me.ActiveControl = Me.TxtCartonID
                PlaySimpleSound(1)
                Exit Sub
            End Try

            Dim printBarcode As New PrintBarcode
            'If Not btApp Is Nothing Then
            '    printBarcode.btApp = btApp
            '    printBarcode.btFormat = btFormat
            '    printBarcode.strScanBarcode = Me.TxtCartonID.Text.Trim
            '    printBarcode.strMOID = Me.TxtMoId.Text.Trim.ToUpper
            '    printBarcode.PrintName = Me.cboPrinterList.Text.Trim
            '    printBarcode.LineId = Me.TxtLineId.Text.Trim
            '    printBarcode.CodeRuleID = scanSetting.CodeRuleID.Split("/")(2)
            '    printBarcode.Packid = scanSetting.CodeRuleID.Split("/")(1)
            '    printBarcode.PackItems = scanSetting.CodeRuleID.Split("/")(0)
            '    printBarcode.InitializePrintParameter()
            '    printBarcode.BuildCBarCode()
            'End If
            If (Not printBarcode.CMainMarkSCode()) Then
                lblMessage.Text = "扫描条码" & Me.TxtCartonID.Text & "已经打印对应箱/PE袋标签..."
                TxtCartonID.Clear()
                Me.ActiveControl = Me.TxtCartonID
                PlaySimpleSound(1)
                Exit Sub
            Else
                Me.TxtCartonID.Text = printBarcode.strPrintBarcode
            End If
        End If

        If IsPrtSelfCarton = "N" Then
            If TxtCartonID.Text.Trim.ToUpper <> Label11.Text.Trim.ToUpper Then
                lblMessage.Text = "扫描条码" & Me.TxtCartonID.Text & "格式不正确,请确认"
            End If
        End If

        Try
            If currentCartonIndex = 0 AndAlso IsPrtSelfCarton = "N" Then
                If isNonSelfCartonSeries OrElse CLength > 0 Then
                    If Not CompareCarton(TxtCartonID.Text) Then
                        Exit Sub
                    End If
                End If
            End If
            If currentCartonIndex > 0 AndAlso CLength > 0 Then
                If Not CompareAttachedCarton(TxtCartonID.Text, currentCartonIndex) Then
                    'SetMessage("FAIL", "大箱袋附属条码错误！")
                    TxtCartonID.Clear()
                    Exit Sub
                Else
                    SetMessage("PASS", "大箱袋附属条码正确！")
                    currentCartonIndex += 1
                    DGridBarCode.Rows.Insert(0, TxtPartid.Text, 1, TxtCartonID.Text, "", VbCommClass.VbCommClass.UseId, Now())
                    TxtCartonID.Clear()
                End If
            End If
            If currentCartonIndex = 0 OrElse currentCartonIndex = CLength Then
                If currentCartonIndex = 0 Then txttempCarton.Text = TxtCartonID.Text
                '2015-04-02            Me.TxtMoId.Text  Me.TxtLineId.Text
                Sqlstr = "DECLARE @strmsgid varchar(1),@strmsgText varchar(50),@NewCartonid varchar(100),@qty int, @palletQty float " & _
                    "EXECUTE [m_NewCheckPallMulletCartonNEW_p] " & _
                    "'" & Trim(scanSetting.MoidStr) & "','" & Trim(txttempCarton.Text) & "','" & IsPallte.Trim & "','" & TxtPalletID.Text.Trim & "','" & Trim(scanSetting.LineStr) & "','" & SysMessageClass.UseId.Trim & "','" & scanSetting.vCartonSame.Trim & "','" & scanSetting.vSamePacking.Trim & "','" & currentCartonIndex & "','" & CLength & "'," & _
                    "'" & scanSetting.vStandId.Trim & "',N'" & scanSetting.vStandName.Trim & "'," & _
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
                            'LblPackQty 应装产品  实装 LblCurrQty 'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                            'scanSetting.vPPackingProduct.Trim = "N"
                            If (scanSetting.ScanPalletCheck = True) Then
                                ' LblCurrCarQty.Text = dt.Rows(0)(4).ToString
                                'CInt(LblCurrCarQty.Text) + 1
                            End If
                            If CLength = 0 Then
                                SetMessage("PASS", "外箱条码序号，扫描成功...请扫描产品条码")
                            ElseIf currentCartonIndex <> CLength Then
                                SetMessage("PASS", "外箱条码序号，扫描成功...请扫描附属条码")
                            Else
                                SetMessage("PASS", "外箱条码序号，扫描成功...请扫描产品条码")
                            End If

                            If CLength > 0 AndAlso currentCartonIndex = CLength Then
                                If scanSetting.vCartonSame = "Y" Then txttempCarton.Text = TxtCartonID.Text
                            End If
                            'DGridBarCode.Rows.Insert(0, TxtPartid.Text, 1, TxtCartonID.Text, "", VbCommClass.VbCommClass.UseId, Now())
                            ControlState(True)
                            If (CLength > 0 AndAlso currentCartonIndex = 0) OrElse IsPackType = "Y" Then
                                DGridBarCode.Rows.Insert(0, TxtPartid.Text, 1, txttempCarton.Text, "", VbCommClass.VbCommClass.UseId, Now())
                            End If
                            If CLength > 0 AndAlso currentCartonIndex = 0 Then
                                ReSetCartonBarCodeStyle()
                                ControlState(False, False)
                                currentCartonIndex += 1
                                ' DGridBarCode.Rows.Insert(0, TxtPartid.Text, 1, txttempPallet.Text, "", VbCommClass.VbCommClass.UseId, Now())
                            End If
                         
                            If IsPackType = "Y" Then
                                ControlState(False, False)
                                TxtPalletID.Enabled = True
                            Else
                                If CLength > 0 Then
                                    If CLength = currentCartonIndex Then
                                        ControlState(True)
                                        TxtCartonID.Text = txttempCarton.Text
                                    Else
                                        ControlState(False, False)
                                    End If
                                Else
                                    ControlState(True)
                                End If
                            End If
                            If currentCartonIndex = CLength Then
                                currentCartonIndex = 0
                            End If
                    End Select
                Else
                    SetMessage("FAIL", "系统无法识别此外箱标签序号！")
                    Me.TxtCartonID.Text = ""
                    PlaySimpleSound(1)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtCartonID.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmStandPackScanBS", "CartonIDScanHandle", "sys")
            Exit Sub
        End Try
    End Sub

    Dim currentPalletScanIndex = 0
    Private Sub PalletIDScanHandle()
        Dim Sqlstr As String = String.Empty
        If Me.TxtMoId.Text = "" Then
            lblMessage.Text = "请设置扫描资料！"
            PlaySimpleSound(1)
            Exit Sub
        End If
        If Me.TxtPalletID.Text = "" Then
            lblMessage.Text = "栈板條碼序號不能為空！"
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        Try
            ' If scanSetting.vPalletSame = "Y" OrElse scanSetting.IsOnlineGenPalletID Then
            If True Then
                If currentPalletScanIndex = 0 AndAlso IsPrtSelfPALLET = "N" Then
                    If isNonSelfPalletSeries OrElse PLength > 0 Then
                        If Not ComparePallet(TxtPalletID.Text) Then
                            Exit Sub
                        End If
                    End If
                End If
                If currentPalletScanIndex > 0 AndAlso PLength > 0 Then
                    If Not CompareAttachedPallet(TxtPalletID.Text, currentPalletScanIndex) Then
                        ' SetMessage("FAIL", "大箱袋附属条码错误！")
                        TxtPalletID.Clear()
                        Exit Sub
                    Else
                        SetMessage("PASS", "大箱袋附属条码正确！")
                        currentPalletScanIndex += 1
                        DGridBarCode.Rows.Insert(0, TxtPartid.Text, 1, TxtPalletID.Text, "", VbCommClass.VbCommClass.UseId, Now())
                        TxtPalletID.Clear()
                    End If
                End If
                If currentPalletScanIndex = 0 OrElse currentPalletScanIndex = PLength Then
                    If currentPalletScanIndex = 0 Then txttempPallet.Text = TxtPalletID.Text
                    Sqlstr = "DECLARE @strmsgid varchar(1),@strmsgText varchar(50),@InventPalletid varchar(100),@qty int " & _
                      " EXECUTE [m_NewCheckPalletNEW_p] " & _
                      "'" & Trim(Me.TxtMoId.Text) & "','" & Trim(txttempPallet.Text) & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "','" & scanSetting.vPalletSame & "','" & currentPalletScanIndex & "','" & PLength & "'," & _
                      "'" & scanSetting.vStandId & "',N'" & scanSetting.vStandName & "'," & _
                      "@strmsgid output,@strmsgText output,@InventPalletid output,@qty output " & _
                      " SELECT @strmsgid ,isnull(@strmsgText,'') ,@qty,@InventPalletid "
                End If
            Else
                Sqlstr = "declare @strmsgid varchar(1),@strmsgText varchar(50),@qty int execute [m_CheckPallet_p] " & _
                 " '" & Trim(Me.TxtMoId.Text) & "','" & Trim(TxtPalletID.Text) & "','" & Trim(Me.TxtLineId.Text) & "','" & SysMessageClass.UseId & "'," & _
                 "@strmsgid output,@strmsgText output,@qty output select @strmsgid ,isnull(@strmsgText,'') ,@qty "
            End If

            If currentPalletScanIndex = 0 OrElse currentPalletScanIndex = PLength Then
                Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                If dt.Rows.Count > 0 Then
                    Select Case dt.Rows(0)(0).ToString()
                        Case "1" To "3"
                            LabResult.ForeColor = Color.Crimson
                            lblMessage.ForeColor = Color.Crimson
                            lblMessage.Text = dt.Rows(0)(1).ToString()
                            Me.TxtPalletID.Clear()
                            currentPalletScanIndex = 0
                            PlaySimpleSound(1)
                            Exit Sub
                        Case "4"
                            DGridBarCode.Rows.Clear()
                            'SetGridHeadColumn()
                            'LblPackQty 应装产品  实装 LblCurrQty
                            'LblCartonQty(应装箱数)  已装箱LblCurrCarQty
                            LblPackQty.Text = "0"
                            LblCurrQty.Text = "0"
                            LblCurrCarQty.Text = "0"
                            If scanSetting.vPalletSame = "Y" Then
                                TxtPalletID.Text = dt.Rows(0)(3).ToString
                            End If
                            LblCartonQty.Text = CInt(dt.Rows(0)(2).ToString)
                            If PLength > 0 AndAlso currentPalletScanIndex = PLength Then
                                If scanSetting.vPalletSame = "Y" Then txttempPallet.Text = TxtPalletID.Text
                            End If
                            If PLength = 0 Then
                                SetMessage("PASS", "大箱袋标签序号扫描成功！请扫描小箱袋条码")
                            ElseIf currentPalletScanIndex <> PLength Then
                                SetMessage("PASS", "大箱袋标签序号扫描成功！请扫描附属条码")
                            Else
                                SetMessage("PASS", "大箱袋标签序号扫描成功！请扫描小箱袋条码")
                            End If
                            TxtPalletID.Enabled = False
                            ControlState(False)
                            PlaySimpleSound(0)

                            If (PLength > 0 AndAlso currentPalletScanIndex = 0) OrElse IsPackType = "Y" Then
                                DGridBarCode.Rows.Insert(0, TxtPartid.Text, 1, txttempPallet.Text, "", VbCommClass.VbCommClass.UseId, Now())
                            End If
                            If PLength > 0 AndAlso currentPalletScanIndex = 0 Then
                                ReSetBarCodeStyle()
                                ControlState(False, True)
                                currentPalletScanIndex += 1
                                ' DGridBarCode.Rows.Insert(0, TxtPartid.Text, 1, txttempPallet.Text, "", VbCommClass.VbCommClass.UseId, Now())
                            End If

                            If IsPackType = "Y" Then
                                ControlState(False, True)
                                TxtCartonID.Enabled = True
                            Else
                                If PLength > 0 Then
                                    If PLength = currentPalletScanIndex Then
                                        ControlState(False)
                                        TxtPalletID.Text = txttempPallet.Text
                                    Else
                                        ControlState(False, True)
                                    End If
                                Else
                                    ' TxtPalletID.Text = txttempPallet.Text
                                    ControlState(False, False)
                                End If
                            End If
                            If currentPalletScanIndex = PLength Then
                                currentPalletScanIndex = 0
                            End If
                    End Select
                Else
                    SetMessage("FAIL", "系统无法识别此栈板标签序号！")
                    Me.TxtCartonID.Text = ""
                    PlaySimpleSound(1)
                    currentPalletScanIndex = 0
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            TxtPalletID.Clear()
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, TxtPalletID.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "PalletIDScanHandle", "sys")
            Exit Sub
        End Try

    End Sub

#End Region

#Region "方法"

    '显示称重打印窗体
    Private Sub OpenOnlineWeightForm(bFlag As Boolean)
        Dim frm As New FrmOnlineWeightPrint
        frm.Moid = TxtMoId.Text.Trim
        frm.PartId = TxtPartid.Text.Trim
        frm.LabelNum = scanSetting.LabelNum
        frm.PrintName = Me.cboPrinterList.Text.Trim
        frm.CartonId = TxtCartonID.Text
        frm.SetTabVisible = bFlag
        frm.ShowDialog()
    End Sub

    '装满箱后打印条码
    Private Sub PrintFullCarton()
        Dim printBarcode As New PrintBarcode
        'printBarcode.btApp = btApp
        ' printBarcode.btFormat = btFormat
        printBarcode.PrintName = Me.cboPrinterList.Text.Trim
        Dim alist As ArrayList = New ArrayList
        alist.Add(TxtPartid.Text)  '料号
        alist.Add(LblPackQty.Text) '包装数量
        alist.Add(TxtBarCode.Text.Substring(4, 2)) '扫描的条码的周别
        printBarcode.PrintFullCarton(TxtCartonID.Text, scanSetting.LabelNum, alist)
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
        Else
            If TgenCarton = "N" Then
                TxtCartonID.Enabled = True
                TxtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtBarCode.BorderColor = Color.FromArgb(209, 31, 73)
                TxtBarCode.Enabled = False
                'TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                ''TxtCartonID.BackColor = Color.White
                TxtCartonID.Text = ""
                Me.TxtCartonID.Focus()
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
        If PackBarCode.MarkJLabel(PackArray.ToArray, "Y1") Then
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
        Dim FrmError As New FrmScanErrPrompt
        FrmError.ShowDialog()
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
    End Sub
#End Region

#End Region

#Region "删除代码"
    'Private Sub PrintMainBarcode(ByVal BarCodeStr As String, ByVal partid As String)
    '    Try
    '        'MessageBox.Show(BarCodeStr)
    '        'btFormat.PrintSetup.IdenticalCopiesOfLabel = 1
    '        'btFormat.PrintSetup.NumberSerializedLabels = 1
    '        btFormat.SetNamedSubStringValue("barcode1", BarCodeStr)
    '        'btFormat.
    '        'btFormat.Print("", False, -1, Nothing)
    '        btFormat.PrintOut(False, False)
    '        'btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
    '        'btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    '        'TxtBarCode.Clear()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    '    'BarCodeToFile(BarCodeStr, Me.TxtPartid.Text)      
    'End Sub
    'Private Sub ChkLinePrint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If ChkLinePrint.Checked = True Then
    '        IsLinePrint = "Y"
    '    Else
    '        IsLinePrint = "N"
    '    End If
    'End Sub
#Region "条码数据生成至File数据库"
    'Public Sub BarCodeToFile(ByVal BarDataStr As String, ByVal partid As String)

    '    Dim TxtFileStr As New StringBuilder
    '    Dim pFilePath As String = ""
    '    Dim mDataRaed As SqlClient.SqlDataReader = Nothing
    '    Dim PubClass As New SysDataBaseClass
    '    Try
    '        'Dim sqlstr As String = " select [barcodesnid],[label10],[label11],[label12],[label13],[label14]," & _
    '        '                "[label15],[label16],[label17],[label18],[labe19],[label20],[label21],[label22]," & _
    '        '                "[label23],[label24] from m_BarRecordValue_t   where [barcodesnid]='" & BarDataStr & "'"
    '        'mDataRaed = PubClass.GetDataReader(sqlstr)
    '        'If mDataRaed.HasRows Then
    '        '    While mDataRaed.Read
    '        '        TxtFileStr.Append("""" & mDataRaed!barcodesnid.ToString & """" & "," & """" & mDataRaed!label10.ToString & """" & "," & """" & mDataRaed!label11.ToString & """" _
    '        '                          & "," & """" & mDataRaed!label12.ToString & """" & "," & """" & mDataRaed!label13.ToString & """" & "," & """" & mDataRaed!label14.ToString & """" _
    '        '                          & "," & """" & mDataRaed!label15.ToString & """" & "," & """" & mDataRaed!label16.ToString & """" & "," & """" & mDataRaed!label17.ToString & """" _
    '        '                          & "," & """" & mDataRaed!label18.ToString & """" & "," & """" & mDataRaed!labe19.ToString & """" & "," & """" & mDataRaed!label20.ToString & """" _
    '        '                          & "," & """" & mDataRaed!label21.ToString & """" & "," & """" & mDataRaed!label22.ToString & """" & "," & """" & mDataRaed!label23.ToString & """" & "," & """" & mDataRaed!label24.ToString & """")
    '        '        'pFilePath = mDataRaed!BartenderFile.ToString()
    '        '    End While
    '        'End If
    '        'mDataRaed.Close()
    '        'MessageBox.Show(TxtFileStr.ToString)
    '        mDataRaed = PubClass.GetDataReader("select  isRplacePath from  m_RPartStationD_t where ppartid='" & partid & "' and state=1 and  IslineMbarcode='Y'")
    '        If mDataRaed.HasRows Then
    '            While mDataRaed.Read
    '                pFilePath = mDataRaed!isRplacePath.ToString
    '            End While
    '            mDataRaed.Close()
    '            Conn.PubConnection.Close()
    '        Else
    '            mDataRaed.Close()
    '            Conn.PubConnection.Close()
    '            'Throw New Exception("模板不能为空")
    '            mDataRaed = PubClass.GetDataReader("select top 1 BartenderFile from m_SnSBarCode_t where sbarcode='" & BarDataStr & "'")
    '            If mDataRaed.HasRows Then
    '                pFilePath = mDataRaed!BartenderFile.ToString
    '                mDataRaed.Close()
    '                Conn.PubConnection.Close()
    '            Else
    '                MessageBox.Show("没有该条码的任何资料...")
    '                mDataRaed.Close()
    '                Conn.PubConnection.Close()
    '                Exit Sub
    '            End If
    '            MessageBox.Show("")
    '            Exit Sub
    '        End If ''

    '        'MessageBox.Show(pFilePath.ToString)
    '        If pFilePath = "" Then Exit Sub
    '        TxtFileStr.Append("""" & BarDataStr & """")
    '        TxtFileStr.Insert(0, """barcodeSN"",""lable10"",""lable11"",""lable12"",""lable13"",""lable14"",""lable15"",""lable16"",""lable17"",""lable18"",""lable19"",""lable20"",""lable21"",""lable22"",""lable23"",""lable24""" & vbNewLine)
    '        'If File.Exists(Application.StartupPath & "\Bartender.txt") = False Then
    '        'File.Copy(PrintDataModle, Application.StartupPath & "\Bartender.txt", True)
    '        'End If

    '        IO.File.WriteAllText(Application.StartupPath & "\Bartender.txt", TxtFileStr.ToString)
    '        TxtFileStr = Nothing
    '        FileToBarCodePrint(pFilePath)
    '    Catch ex As Exception
    '        If mDataRaed.IsClosed = False Then
    '            mDataRaed.Close()
    '            Conn.PubConnection.Close()
    '        End If

    '        Throw ex
    '    End Try


    'End Sub
#End Region

#Region "条码打印方法更新，优化速度"

    'Private Sub FileToBarCodePrint(ByVal LableFile As String)


    '    If LableFile = "" Then
    '        MessageBox.Show("该料件的打印格式，未上传打印模版...")
    '        Exit Sub
    '    End If


    '    btFormat = btApp.Formats.Open(LableFile, False, String.Empty)
    '    'Me.Timer1.Stop()
    '    'MessageBox.Show(mytime)
    '    'btFormat.PrintOut(False, False)
    '    btFormat.Print("", False, -1, Nothing)
    '    'Me.Timer1.Stop()
    '    'End the BarTender process 
    '    btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
    '    btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    'End Sub


    'Private Sub AutoGenCartonID()
    '    Dim printBarcode As New PrintBarcode
    '    printBarcode.btApp = btApp
    '    printBarcode.btFormat = btFormat
    '    printBarcode.strScanBarcode = Me.TxtCartonID.Text.Trim
    '    printBarcode.strMOID = Me.TxtMoId.Text.Trim.ToUpper
    '    printBarcode.PrintName = Me.cboPrinterList.Text.Trim
    '    printBarcode.LineId = Me.TxtLineId.Text.Trim
    '    printBarcode.CodeRuleID = scanSetting.CodeRuleID.Split("/")(2)
    '    printBarcode.Packid = scanSetting.CodeRuleID.Split("/")(1)
    '    printBarcode.PackItems = scanSetting.CodeRuleID.Split("/")(0)
    '    printBarcode.InitializePrintParameter()
    '    printBarcode.BuildCBarCode(False)

    '    If (Not printBarcode.CMainMarkSCode(False)) Then
    '        lblMessage.Text = " 生成外箱号失败!"
    '        TxtCartonID.Clear()
    '        Me.ActiveControl = Me.TxtCartonID
    '        PlaySimpleSound(1)
    '        Exit Sub
    '    Else
    '        Me.TxtCartonID.Text = printBarcode.strPrintBarcode
    '    End If
    'End Sub

#End Region

    'Private Sub PrintCartonBarcode(ByVal CartonBarCodeStr As String, ByVal moid As String, ByVal partid As String, ByVal Stationid As String)
    '    Dim datastr As String = ""
    '    Dim i As Integer = 0
    '    Dim pn As String = ""
    '    Dim sql_GPN As String = "select top 1 PN from m_Carton_t a left join m_Cartonsn_t b on a.Cartonid =b.Cartonid left join m_A20Box_t c on b.ppid =c.SN where a.Cartonid='" & CartonBarCodeStr & "'"
    '    Dim Reads As SqlDataReader = Conn.GetDataReader(sql_GPN)
    '    While (Reads.Read)
    '        pn = Reads("PN").ToString
    '    End While
    '    Reads.Close()

    '    Dim insertsql As String = "insert m_BarRecordValue_t(barcodeSNID,label10,PrintFlag,Printpc,moid,intime,partid"
    '    Dim valuesql As String = "select  barcodeSNID='" & CartonBarCodeStr & "',PN='" & pn & "',PrintFlag='1',Printpc='system',moid='" & moid & "',intime=getdate(),partid='" & partid & "'  "
    '    Dim sql As String = String.Format("declare @datastr varchar(1000)='' select @datastr=@datastr+ppid+''',''' from m_Cartonsn_t where Cartonid='{0}' select ''''+SUBSTRING(@datastr,0,LEN(@datastr)-1) colstr", CartonBarCodeStr)
    '    Dim RecTable As SqlDataReader = Conn.GetDataReader(sql)
    '    While (RecTable.Read)
    '        datastr = RecTable("colstr").ToString
    '    End While
    '    RecTable.Close()
    '    RecTable.Dispose()
    '    Conn.PubConnection.Close()
    '    If datastr.Length > 0 Then
    '        ' datastr = datastr.Substring(0, datastr.Length - 1)
    '        If datastr.Split(",").Length > 0 Then
    '            Dim index As Integer = 11
    '            For i = 0 To datastr.Split(",").Length - 1
    '                insertsql = insertsql + ",label" + index.ToString
    '                valuesql = valuesql + "," + datastr.Split(",")(i).ToString
    '                index = index + 1
    '            Next

    '        End If
    '    End If
    '    insertsql = insertsql + ")" + valuesql
    '    Try
    '        insertsql = insertsql
    '        ' MessageBox.Show(insertsql)
    '        Conn.ExecSql(insertsql)
    '        Conn.PubConnection.Close()
    '    Catch ex As Exception
    '        Me.lblMessage.Text = ex.Message
    '    End Try
    '    Dim BarRprintHandle As New VbCommClass.VbCommClass
    '    Try
    '        BarRprintHandle.BarCodeToFile(CartonBarCodeStr, partid, Stationid)
    '    Catch ex As Exception
    '        Me.lblMessage.Text = ex.Message
    '    End Try

    'End Sub
    'Private Sub FrmInCarton_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    DisposeData()
    '    scanSetting.CustIdString = Nothing
    '    scanSetting.MoidStr = Nothing
    '    scanSetting.LengthStr = Nothing
    '    scanSetting.DateCheck = Nothing
    'End Sub

    'Private Sub FrmWorkStantScan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    ''ToolUsename.Text=SysMessageClasss.UseName
    'End Sub


    'Private Sub LoadPalletPaceQty()

    '    ''  Dim PalletStr As String = String.Empty
    '    Dim dt As DataTable = Conn.GetDataTable(" select isnull(count(Cartonid),0) packcount from m_carton_t where moid='" & Me.TxtMoId.Text & "' and cartonstatus<>'E' ")

    '    If dt.Rows.Count > 0 Then
    '        LabCartonQty.Text = dt.Rows(0)("packcount").ToString
    '    End If
    '    Conn.PubConnection.Close()
    'End Sub

    'Private Sub ControlState(ByVal BorC As Boolean)
    '    'Dim value As Color
    '    'If BorC Then
    '    '    TxtBarCode.Enabled = True
    '    '    BtEnter.Enabled = True
    '    '    TxtCartonScan.Enabled = False
    '    '    BtCatronScan.Enabled = False
    '    '    value = TxtColor.BackColor
    '    '    TxtBarCode.BackColor = value
    '    '    Me.TxtCartonScan.BackColor = Color.White
    '    '    TxtBarCode.Text = ""
    '    '    Me.TxtBarCode.Focus()
    '    'Else
    '    '    TxtBarCode.Enabled = False
    '    '    BtEnter.Enabled = False
    '    '    TxtCartonScan.Enabled = True
    '    '    BtCatronScan.Enabled = True
    '    '    value = TxtColor.BackColor
    '    '    TxtCartonScan.BackColor = value
    '    '    Me.TxtBarCode.BackColor = Color.White
    '    '    TxtCartonScan.Text = ""
    '    '    Me.TxtCartonScan.Focus()
    '    'End If

    'End Sub


    ''Private Sub GetCartonScanItem()

    ''    Dim ChColsText As String
    ''    Dim DtCtScan As DataTable
    ''    Try
    ''        DGridBarCode.DataSource = Nothing
    ''        DtCtScan = Conn.GetDataTable("select * from m_Ppidlink_t where moid='" & Trim(TxtMoId.Text) & "' and teamid='" & Me.TxtLineId.Text & "' and intime >'" & TxtLineId.Text & "' order by intime desc ")
    ''        Me.DGridBarCode.DataSource = DtCtScan
    ''        '' Me.LabCartonQty.Text = DtCtScan.Rows.Count
    ''        If LCase(SysMessageClass.Language) = "english" Then
    ''            ChColsText = ""
    ''        Else
    ''            ChColsText = "裝箱序號|掃描人員|掃描時間"
    ''        End If
    ''        Dim colNames As String() = ChColsText.Split("|")
    ''        Dim i%
    ''        For i = 0 To DGridBarCode.Columns.Count - 1
    ''            DGridBarCode.Columns(i).HeaderText = colNames(i)
    ''            DGridBarCode.Columns(i).Name = colNames(i)
    ''        Next
    ''        DtCtScan = Nothing
    ''    Catch ex As Exception
    ''        SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmInCarton", "GetCartonScanItem", "sys")
    ''    End Try

    ''End Sub

#End Region

    Private Function OnlinePalletID() As String
        Dim ServerDate As New DateTime ''''服務器日期時間
        Dim PackBarCode As New PrintJLabelNew
        Dim TimeSqlstr As String = ""
        Dim sql As String = ""
        OnlinePalletID = ""
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
        If PackBarCode.MarkJLabel(PackArray.ToArray, "S3") Then
            If String.IsNullOrEmpty(PackBarCode.m_CartonID) Then
                OnlinePalletID = PackBarCode.JLabelStr ''生成箱號
            Else
                OnlinePalletID = PackBarCode.m_CartonID
            End If
            '是否尾箱号
            IsTrunk = PackBarCode.IsTrunk
        Else
            OnlinePalletID = ""
            If PackBarCode.m_CartonID = "00000000" Then
                SetMessage("PASS", "该工单已扫描完成！")
            End If
        End If
    End Function

    Private Function CheckIsMoFinish()
        Dim sql = "   SELECT ISNULL(A.MOQTY,0) MOQTY,ISNULL(B.SCANQTY,0) SCANQTY FROM " & _
   " (SELECT MOID,MOQTY FROM M_MAINMO_T WHERE MOID='" & TxtMoId.Text.Trim & "' ) A left join (SELECT MOID, SUM(CARTONQTY) SCANQTY FROM M_CARTON_T WHERE MOID='" & TxtMoId.Text.Trim & "' GROUP BY MOID) B" & _
"        on A.MOID = B.MOID"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                LabMoQty.Text = dt.Rows(0)("MOQTY")
                LabScanQty.Text = dt.Rows(0)("SCANQTY")
            End If
        End Using
        If Int(LabMoQty.Text) = Int(LabScanQty.Text) Then
            SetMessage("FAIL", "该工单已扫描完成，无需再扫描，请确认")
            Return True
        End If
        Return False
    End Function


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim a As String() = {"true", "false"}
        Using frm As FrmIssueHandler = New FrmIssueHandler(TxtMoId.Text, a)
            frm.StartPosition = FormStartPosition.CenterParent
            frm.ShowDialog()
        End Using
    End Sub

    Private Function ShowOkCancel()
        Using frm As FrmOkCancel = New FrmOkCancel
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Return True
            Else
                Return False
            End If
        End Using
        Return False
    End Function


    '非系统单码扫描，如固定码，直接insert DB，流水码 卡样式
    Dim isNonSelfCartonSeries As Boolean = False
    Private Sub GetNonSelfCarton()
        '只支持无流水码外箱
        Dim QTY As String = Nothing
        Dim sql As String = "SELECT CODERULEID,QTY FROM M_PARTPACK_T WHERE PARTID='" & TxtPartid.Text & "' AND DISORDERTYPEID='C' AND USEY='Y' "
        Using dt2 As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt2.Rows.Count > 0 Then
                Dim SqlStr As String = " DECLARE @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' " & _
                        " EXECUTE [m_MultipStyleShow_p_AssembleSta] '" & TxtPartid.Text & "','" & TxtMoId.Text & "','" & dt2.Rows(0)("CODERULEID").ToString & "','" & scanSetting.vLabelDate & "','C',@SnStyle1 output ,@SnStyle2 output,@Gflen output " & _
                        " SELECT @SnStyle1,@SnStyle2,@Gflen"
                Using dt1 As DataTable = DbOperateUtils.GetDataTable(SqlStr)
                    If dt1.Rows.Count > 0 Then
                        Label11.Text = dt1.Rows(0)(0).ToString
                        Label13.Text = dt1.Rows(0)(1).ToString
                    End If
                End Using
                QTY = dt2.Rows(0)("QTY").ToString
            Else
                sql = "SELECT CODERULEID,QTY FROM M_PARTPACK_T WHERE PARTID='" & TxtPartid.Text & "' AND PACKID='C' AND USEY='Y' "
                Using dt3 As DataTable = DbOperateUtils.GetDataTable(sql)
                    If dt3.Rows.Count > 0 Then
                        Dim SqlStr As String = " DECLARE @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' " & _
                                " EXECUTE m_MultipStyleShow_p_AssembleSta '" & TxtPartid.Text & "','" & TxtMoId.Text & "','" & dt3.Rows(0)("CODERULEID").ToString & "','" & scanSetting.vLabelDate & "','C',@SnStyle1 output ,@SnStyle2 output,@Gflen output " & _
                                " SELECT @SnStyle1,@SnStyle2,@Gflen"
                        Using dt1 As DataTable = DbOperateUtils.GetDataTable(SqlStr)
                            If dt1.Rows.Count > 0 Then
                                Label11.Text = dt1.Rows(0)(0).ToString
                                Label13.Text = dt1.Rows(0)(1).ToString
                            End If
                        End Using
                        isNonSelfCartonSeries = True
                    End If
                End Using
                Exit Sub
            End If
        End Using

        'Dim ServerDate As New DateTime ''''服務器日期時間
        Dim PackBarCode As New PrintJLabelNew
        Dim TimeSqlstr As String = ""
        PackArray.AvcPartid = Me.TxtPartid.Text.Trim 'AVC料號
        PackArray.CusName = scanSetting.CustStr ' 客戶名稱
        PackArray.Deptid = scanSetting.DpetId ' '部門
        PackArray.Lineid = scanSetting.LineStr ' Me.TxtLineId.Text.Trim  '線別
        PackArray.Moid = Me.TxtMoId.Text.Trim   '工單
        'TimeSqlstr = "select getdate() as nowtime"
        'Dim dt As DataTable = DbOperateUtils.GetDataTable(TimeSqlstr)
        'If dt.Rows.Count > 0 Then
        '    ServerDate = CDate(dt.Rows(0)("nowtime").ToString)
        'End If
        PackArray.NowDate = scanSetting.vLabelDate
        PackArray.NowMonth = scanSetting.vLabelDate.Substring(5, 2)
        PackArray.Qty = QTY '
        PackArray.DateCode = scanSetting.vLabelDate.Substring(8, 2)

        PackBarCode.StaionId = scanSetting.vStandId
        PackBarCode.StaionName = scanSetting.vStandName
        If PackBarCode.MarkJLabel(PackArray.ToArray, "Y2") Then
            'If String.IsNullOrEmpty(PackBarCode.m_CartonID) Then
            '    OnlineCartonID = PackBarCode.JLabelStr ''生成箱號
            'Else
            '    OnlineCartonID = PackBarCode.m_CartonID
            'End If
            ''是否尾箱号
            'IsTrunk = PackBarCode.IsTrunk
        End If
    End Sub

    Dim isNonSelfPalletSeries As Boolean = False
    Private Sub GetNonSelfPallet()
        '只支持无流水码外箱
        Dim QTY As String = Nothing
        Dim sql As String = "SELECT CODERULEID,QTY FROM M_PARTPACK_T WHERE PARTID='" & TxtPartid.Text & "' AND DISORDERTYPEID='P' AND USEY='Y' "
        Using dt2 As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt2.Rows.Count > 0 Then
                Dim SqlStr As String = " DECLARE @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' " & _
                        " EXECUTE m_MultipStyleShow_p_AssembleSta '" & TxtPartid.Text & "','" & TxtMoId.Text & "','" & dt2.Rows(0)("CODERULEID").ToString & "','" & scanSetting.vLabelDate & "','P',@SnStyle1 output ,@SnStyle2 output,@Gflen output " & _
                        " SELECT @SnStyle1,@SnStyle2,@Gflen"
                Using dt1 As DataTable = DbOperateUtils.GetDataTable(SqlStr)
                    If dt1.Rows.Count > 0 Then
                        Label24.Text = dt1.Rows(0)(0).ToString
                        Label25.Text = dt1.Rows(0)(1).ToString
                    End If
                End Using
                QTY = dt2.Rows(0)("QTY").ToString
            Else
                sql = "SELECT CODERULEID,QTY FROM M_PARTPACK_T WHERE PARTID='" & TxtPartid.Text & "' AND PACKID='P' AND USEY='Y' "
                Using dt3 As DataTable = DbOperateUtils.GetDataTable(sql)
                    If dt3.Rows.Count > 0 Then
                        Dim SqlStr As String = " DECLARE @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' " & _
                                " EXECUTE m_MultipStyleShow_p_AssembleSta '" & TxtPartid.Text & "','" & TxtMoId.Text & "','" & dt3.Rows(0)("CODERULEID").ToString & "','" & scanSetting.vLabelDate & "','P',@SnStyle1 output ,@SnStyle2 output,@Gflen output " & _
                                " SELECT @SnStyle1,@SnStyle2,@Gflen"
                        Using dt1 As DataTable = DbOperateUtils.GetDataTable(SqlStr)
                            If dt1.Rows.Count > 0 Then
                                Label24.Text = dt1.Rows(0)(0).ToString
                                Label25.Text = dt1.Rows(0)(1).ToString
                            End If
                        End Using
                        isNonSelfPalletSeries = True
                    End If
                End Using
                Exit Sub
            End If
        End Using

        'Dim ServerDate As New DateTime ''''服務器日期時間
        Dim PackBarCode As New PrintJLabelNew
        Dim TimeSqlstr As String = ""
        PackArray.AvcPartid = Me.TxtPartid.Text.Trim 'AVC料號
        PackArray.CusName = scanSetting.CustStr ' 客戶名稱
        PackArray.Deptid = scanSetting.DpetId ' '部門
        PackArray.Lineid = scanSetting.LineStr ' Me.TxtLineId.Text.Trim  '線別
        PackArray.Moid = Me.TxtMoId.Text.Trim   '工單
        'TimeSqlstr = "select getdate() as nowtime"
        'Dim dt As DataTable = DbOperateUtils.GetDataTable(TimeSqlstr)
        'If dt.Rows.Count > 0 Then
        '    ServerDate = CDate(dt.Rows(0)("nowtime").ToString)
        'End If
        PackArray.NowDate = scanSetting.vLabelDate
        PackArray.NowMonth = scanSetting.vLabelDate.Substring(5, 2)
        PackArray.Qty = QTY '
        PackArray.DateCode = scanSetting.vLabelDate.Substring(8, 2)

        PackBarCode.StaionId = scanSetting.vStandId
        PackBarCode.StaionName = scanSetting.vStandName
        If PackBarCode.MarkJLabel(PackArray.ToArray, "S4") Then
            'If String.IsNullOrEmpty(PackBarCode.m_CartonID) Then
            '    OnlineCartonID = PackBarCode.JLabelStr ''生成箱號
            'Else
            '    OnlineCartonID = PackBarCode.m_CartonID
            'End If
            ''是否尾箱号
            'IsTrunk = PackBarCode.IsTrunk
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim sql As String = Nothing
        If (MessageBox.Show("请确认是否需要关箱", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        If IsScanPallet Then
            sql = "UPDATE M_PALLETM_T SET PALLETSTATUS='Y',MULTIQTY=PALLETQTY,MARK3=N'强制关箱',MARK2='" & VbCommClass.VbCommClass.UseId & "' WHERE PALLETID='" & TxtPalletID.Text & "'"
            sql = sql + vbNewLine + "UPDATE M_CARTON_T SET CARTONSTATUS='Y',PackingQuantity=CARTONQTY,MARK1='" & VbCommClass.VbCommClass.UseId & "',MARK2=N'强制关箱',UPDATETIME=GETDATE() WHERE CARTONID='" & TxtCartonID.Text & "'"
        Else
            sql = "UPDATE M_CARTON_T SET CARTONSTATUS='Y',PackingQuantity=CARTONQTY,MARK1='" & VbCommClass.VbCommClass.UseId & "',MARK2=N'强制关箱',UPDATETIME=GETDATE() WHERE CARTONID='" & TxtCartonID.Text & "'"
        End If
        Try
            If Not String.IsNullOrEmpty(sql) Then
                DbOperateUtils.ExecSQL(sql)
            End If
            lblMessage.Text = "强制关箱成功,请重新做扫描设定"
            If IsScanPallet Then
                ControlState(False, True)
            Else
                ControlState(False, False)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub getCartonScanItem()
        DGridBarCode.Rows.Clear()
        Dim sql As String = Nothing
        If IsScanPallet Then
            If Not String.IsNullOrEmpty(TxtPalletID.Text) Then
                sql = "SELECT B.PARTID,1,C.CARTONID,'',A.USERID,A.INTIME FROM M_PALLETM_T A JOIN M_MAINMO_T B ON A.MOID=B.MOID JOIN M_PALLETCARTON_T C ON A.PALLETID=C.PALLETID  WHERE A.MOID='" & TxtMoId.Text & "'"
            Else
                sql = "SELECT B.PARTID,1,CARTONID,'',A.USERID,A.INTIME FROM M_CARTON_T A JOIN M_MAINMO_T B  ON A.MOID=B.MOID WHERE A.MOID='" & TxtMoId.Text & "'"
            End If

        Else
            sql = "SELECT B.PARTID,1,CARTONID,'',A.USERID,A.INTIME FROM M_CARTON_T A JOIN M_MAINMO_T B  ON A.MOID=B.MOID WHERE A.MOID='" & TxtMoId.Text & "'"
        End If
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    DGridBarCode.Rows.Add(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5))
                Next
            End If
        End Using
    End Sub

    Dim PBarcodeStyle() As String
    Dim CBarcodeStyle() As String
    Dim SBarcodeStyle() As String
    Dim PLength As Integer = 0
    Dim CLength As Integer = 0
    Dim SLength As Integer = 0
    Dim PBdic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim PB2dic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim CBdic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim CB2dic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim SBdic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim SB2dic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim PBTdic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim PBT2dic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim CBTdic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim CBT2dic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim SBTdic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Dim SBT2dic As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private Sub ParseBarcodeStyle()
        Dim styles() As String = repeatPara.Split(",")
        For Each style As String In styles
            '增加非流水校验逻辑 Modified By KyLinQiu20180324
            Dim strCheckRuleID As String = ""
            Dim isNPallet As Boolean = False
            Dim isNCarton As Boolean = False
            Dim isNSbarcode As Boolean = False
            If style.Substring(0, 1) = "N" Then
                strCheckRuleID = style.Substring(2).Split("|")(0)
                Dim dtForRule As DataTable = DbOperateUtils.GetDataTable(String.Format("SELECT DisorderTypeId FROM dbo.m_PartPack_t(NOLOCK) WHERE Partid='{0}' AND CodeRuleID='{1}'", Me.TxtPartid.Text.Trim, strCheckRuleID))
                If (Not dtForRule Is Nothing) AndAlso dtForRule.Rows.Count > 0 Then
                    Dim strDisorderTypeId = dtForRule.Rows(0)("DisorderTypeId").ToString.ToUpper.Trim
                    If strDisorderTypeId = "P" Then
                        isNPallet = True
                    ElseIf strDisorderTypeId = "C" Then
                        isNCarton = True
                    ElseIf strDisorderTypeId = "S" Then
                        isNSbarcode = True
                    End If
                End If
            End If
            If style.Substring(0, 1) = "P" OrElse isNPallet Then
                PBarcodeStyle = style.Substring(2).Split("|")
            ElseIf style.Substring(0, 1) = "C" OrElse isNCarton Then
                CBarcodeStyle = style.Substring(2).Split("|")
            ElseIf style.Substring(0, 1) = "S" OrElse isNSbarcode Then
                SBarcodeStyle = style.Substring(2).Split("|")
            End If
        Next
        If Not PBarcodeStyle Is Nothing Then
            GetBarcodeStyle("P")
            PLength = PBarcodeStyle.Length
        Else
            PLength = 0
        End If
        If Not CBarcodeStyle Is Nothing Then
            GetBarcodeStyle("C")
            CLength = CBarcodeStyle.Length
        Else
            CLength = 0
        End If
        If Not SBarcodeStyle Is Nothing Then
            GetBarcodeStyle("S")
            SLength = SBarcodeStyle.Length
        Else
            SLength = 0
        End If
    End Sub

    Private Sub GetBarcodeStyle(ByVal type As String)
        Dim SqlStr As String = " DECLARE @SnStyle1 varchar(70),@SnStyle2 varchar(70),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2=''  set @Gflen='' " & _
                     " EXECUTE [m_MultipStyleShow_p_AssembleSta] '{0}','{1}','{2}','{3}','{4}',@SnStyle1 output ,@SnStyle2 output,@Gflen output " & _
                     " SELECT @SnStyle1,@SnStyle2,@Gflen"
        Dim outStyle As String = ""
        Dim out2Style As String = ""
        Dim index As Integer = 0
        If type = "P" Then
            PBdic.Clear()
            PB2dic.Clear()
            For Each codeId As String In PBarcodeStyle
                Using dt As DataTable = DbOperateUtils.GetDataTable(String.Format(SqlStr, TxtPartid.Text, TxtMoId.Text, codeId, scanSetting.vLabelDate, "P"))
                    If dt.Rows.Count > 0 Then
                        If Not String.IsNullOrEmpty(dt.Rows(0)(0).ToString) Then
                            outStyle += dt.Rows(0)(0).ToString + vbNewLine
                            PBdic.Add(index, dt.Rows(0)(0).ToString)
                        Else
                            outStyle += codeId + vbNewLine
                            PBdic.Add(index, codeId)
                        End If
                        If Not String.IsNullOrEmpty(dt.Rows(0)(1).ToString) Then
                            out2Style += dt.Rows(0)(1).ToString + vbNewLine
                            PB2dic.Add(index, dt.Rows(0)(1).ToString)
                        Else
                            out2Style += codeId + vbNewLine
                            PB2dic.Add(index, codeId)
                        End If
                    End If
                End Using
                index += 1
            Next
            txtPalletStyle.Text = outStyle.Trim(vbNewLine)
        ElseIf type = "C" Then
            CBdic.Clear()
            CB2dic.Clear()
            For Each codeId As String In CBarcodeStyle
                Using dt As DataTable = DbOperateUtils.GetDataTable(String.Format(SqlStr, TxtPartid.Text, TxtMoId.Text, codeId, scanSetting.vLabelDate, "C"))
                    If Not String.IsNullOrEmpty(dt.Rows(0)(0).ToString) Then
                        outStyle += dt.Rows(0)(0).ToString + vbNewLine
                        CBdic.Add(index, dt.Rows(0)(0).ToString)
                    Else
                        outStyle += codeId + vbNewLine
                        CBdic.Add(index, codeId)
                    End If
                    If Not String.IsNullOrEmpty(dt.Rows(0)(1).ToString) Then
                        out2Style += dt.Rows(0)(1).ToString + vbNewLine
                        CB2dic.Add(index, dt.Rows(0)(1).ToString)
                    Else
                        out2Style += codeId + vbNewLine
                        CB2dic.Add(index, codeId)
                    End If
                End Using
                index += 1
            Next
            txtCartonStyle.Text = outStyle.Trim(vbNewLine)
        ElseIf type = "S" Then
            SBdic.Clear()
            SB2dic.Clear()
            For Each codeId As String In SBarcodeStyle
                Using dt As DataTable = DbOperateUtils.GetDataTable(String.Format(SqlStr, TxtPartid.Text, TxtMoId.Text, codeId, scanSetting.vLabelDate, "S"))
                    If dt.Rows.Count > 0 Then
                        If Not String.IsNullOrEmpty(dt.Rows(0)(0).ToString) Then
                            outStyle += dt.Rows(0)(0).ToString + vbNewLine
                            SBdic.Add(index, dt.Rows(0)(0).ToString)
                        Else
                            outStyle += codeId + vbNewLine
                            SBdic.Add(index, codeId)
                        End If
                        If Not String.IsNullOrEmpty(dt.Rows(0)(1).ToString) Then
                            out2Style += dt.Rows(0)(1).ToString + vbNewLine
                            SB2dic.Add(index, dt.Rows(0)(1).ToString)
                        Else
                            out2Style += codeId + vbNewLine
                            SB2dic.Add(index, codeId)
                        End If
                    End If
                End Using
                index += 1
            Next
            txtSnStyle.Text = outStyle.Trim(vbNewLine)
        End If
    End Sub

    Private Sub ReSetBarCodeStyle()
        PBTdic.Clear()
        PBT2dic.Clear()
        For item As Integer = 0 To PBdic.Count - 1
            Dim value As String = PBdic(item)
            If value.Contains("{ID}") Then
                value = value.Replace("{ID}", txttempPallet.Text)
            End If
            If value.Contains("{&}") Then
                Dim startIndex = value.indexof("{&}")
                Dim endIndex = value.LastIndexOf("{&}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = LblCartonQty.Text.PadLeft((endIndex - startIndex) / 3, "0")
                value = value.Replace(valueS, replaceValue)
            End If
            If value.Contains("{?}") Then
                Dim startIndex = value.IndexOf("{?}")
                Dim endIndex = value.LastIndexOf("{?}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = LblCartonQty.Text '.PadLeft((endIndex - startIndex) / 3, "0")
                value = value.Replace(valueS, replaceValue)
            End If
            PBTdic(item) = value
        Next

        For item As Integer = 0 To PB2dic.Count - 1
            Dim value As String = PB2dic(item)
            If value.Contains("{ID}") Then
                value = value.Replace("{ID}", txttempPallet.Text)
            End If
            If value.Contains("{&}") Then
                Dim startIndex = value.IndexOf("{&}")
                Dim endIndex = value.LastIndexOf("{&}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = LblCartonQty.Text.PadLeft((endIndex - startIndex) / 3, "0")
                value = value.Replace(valueS, replaceValue)
            End If
            If value.Contains("{?}") Then
                Dim startIndex = value.IndexOf("{?}")
                Dim endIndex = value.LastIndexOf("{?}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = LblCartonQty.Text '.PadLeft((endIndex - startIndex) / 3, "0")
                value = value.Replace(valueS, replaceValue)
            End If
            PBT2dic(item) = value
        Next

    End Sub
    Private Sub ReSetCartonBarCodeStyle()
        CBTdic.Clear()
        CBT2dic.Clear()
        For item As Integer = 0 To CBdic.Count - 1
            Dim value As String = CBdic(item)
            If value.Contains("{ID}") Then
                value = value.Replace("{ID}", txttempCarton.Text)
            End If
            If value.Contains("{&}") Then
                Dim startIndex = value.IndexOf("{&}")
                Dim endIndex = value.LastIndexOf("{&}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = LblPackQty.Text.PadLeft((endIndex - startIndex) / 3, "0")
                value = value.Replace(valueS, replaceValue)
            End If
            If value.Contains("{?}") Then
                Dim startIndex = value.IndexOf("{?}")
                Dim endIndex = value.LastIndexOf("{?}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = LblPackQty.Text
                value = value.Replace(valueS, replaceValue)
            End If
            CBTdic(item) = value
        Next

        For item As Integer = 0 To CB2dic.Count - 1
            Dim value As String = CB2dic(item)
            If value.Contains("{ID}") Then
                value = value.Replace("{ID}", txttempCarton.Text)
            End If
            If value.Contains("{&}") Then
                Dim startIndex = value.IndexOf("{&}")
                Dim endIndex = value.LastIndexOf("{&}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = LblPackQty.Text.PadLeft((endIndex - startIndex) / 3, "0")
                value = value.Replace(valueS, replaceValue)
            End If
            If value.Contains("{?}") Then
                Dim startIndex = value.IndexOf("{?}")
                Dim endIndex = value.LastIndexOf("{?}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = LblPackQty.Text
                value = value.Replace(valueS, replaceValue)
            End If
            CBT2dic(item) = value
        Next
    End Sub

    Private Sub ReSetSBarCodeStyle()
        SBTdic.Clear()
        SBT2dic.Clear()
        For item As Integer = 0 To SBdic.Count - 1
            Dim value As String = SBdic(item)
            If value.Contains("{ID}") Then
                value = value.Replace("{ID}", txttempPallet.Text)
            End If
            If value.Contains("{&}") Then
                Dim startIndex = value.IndexOf("{&}")
                Dim endIndex = value.LastIndexOf("{&}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = "1".PadLeft((endIndex - startIndex) / 3, "0")
                value = value.Replace(valueS, replaceValue)
            End If
            If value.Contains("{?}") Then
                Dim startIndex = value.IndexOf("{?}")
                Dim endIndex = value.LastIndexOf("{?}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = "1"
                value = value.Replace(valueS, replaceValue)
            End If
            SBTdic(item) = value
        Next

        For item As Integer = 0 To SB2dic.Count - 1
            Dim value As String = SB2dic(item)
            If value.Contains("{ID}") Then
                value = value.Replace("{ID}", txttempPallet.Text)
            End If
            If value.Contains("{&}") Then
                Dim startIndex = value.IndexOf("{&}")
                Dim endIndex = value.LastIndexOf("{&}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = "1".PadLeft((endIndex - startIndex) / 3, "0")
                value = value.Replace(valueS, replaceValue)
            End If
            If value.Contains("{?}") Then
                Dim startIndex = value.IndexOf("{?}")
                Dim endIndex = value.LastIndexOf("{?}") + 3
                Dim valueS = value.Substring(startIndex, endIndex - startIndex)
                Dim replaceValue As String = "1"
                value = value.Replace(valueS, replaceValue)
            End If
            SBT2dic(item) = value
        Next
    End Sub

    Private Sub ClearBarcodeStyle()
        CLength = 0
        CBT2dic.Clear()
        CBTdic.Clear()
        CBdic.Clear()
        CB2dic.Clear()
        PLength = 0
        PB2dic.Clear()
        PBTdic.Clear()
        PBT2dic.Clear()
        PBdic.Clear()
        SLength = 0
        SBT2dic.Clear()
        SBTdic.Clear()
        SBdic.Clear()
        SB2dic.Clear()
        currentCartonIndex = 0
        currentPalletScanIndex = 0
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        currentPalletScanIndex = 0
        currentCartonIndex = 0
    End Sub

    Private Function ComparePallet(ByVal BarCode As String)
        If Not PBdic Is Nothing AndAlso PBdic.Count > 0 Then
            If PBdic(0).Length > 0 Then
                If BarCode.Trim.Length <> PBdic(0).Length Then
                    WorkStantOption.ErrorStr = "扫描条码长度不对"
                    SetMessage("Fail", "扫描条码长度不对")
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtPalletID.Text = ""
                    Me.TxtPalletID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If

                If TextHandle.verfyBarCodeStyle(PBdic(0), BarCode, PB2dic(0)) = False Then
                    WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                    SetMessage("FAIL", "條碼不符合標準樣式")
                    'PlaySimpleSound(1)
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtPalletID.Text = ""
                    Me.TxtPalletID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If
            End If
        Else
            If Not String.IsNullOrEmpty(Label24.Text) Then
                If BarCode.Trim.Length <> Label24.Text.Length Then
                    WorkStantOption.ErrorStr = "扫描条码长度不对"
                    SetMessage("Fail", "扫描条码长度不对")
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtPalletID.Text = ""
                    Me.TxtPalletID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If

                If TextHandle.verfyBarCodeStyle(Label24.Text, BarCode, Label25.Text) = False Then
                    WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                    SetMessage("FAIL", "條碼不符合標準樣式")
                    'PlaySimpleSound(1)
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtPalletID.Text = ""
                    Me.TxtPalletID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Function CompareAttachedPallet(ByVal BarCode As String, ByVal index As Integer)
        If Not PBTdic Is Nothing AndAlso PBTdic.Count > 0 AndAlso PBTdic.Count >= index Then
            If PBTdic(index).Length > 0 Then
                If BarCode.Trim.Length <> PBTdic(index).Length Then
                    WorkStantOption.ErrorStr = "附属扫描条码长度不对"
                    SetMessage("Fail", "附属扫描条码长度不对")
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtPalletID.Text = ""
                    Me.TxtPalletID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If

                If TextHandle.verfyBarCodeStyle(PBTdic(index), BarCode, PBT2dic(index)) = False Then
                    WorkStantOption.ErrorStr = "附属條碼不符合標準樣式"
                    SetMessage("FAIL", "附属條碼不符合標準樣式")
                    'PlaySimpleSound(1)
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtPalletID.Text = ""
                    Me.TxtPalletID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Function CompareCarton(ByVal BarCode As String)
        If Not CBdic Is Nothing AndAlso CBdic.Count > 0 Then
            If CBdic(0).Length > 0 Then
                If BarCode.Trim.Length <> CBdic(0).Length Then
                    WorkStantOption.ErrorStr = "扫描条码长度不对"
                    SetMessage("Fail", "扫描条码长度不对")
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtCartonID.Text = ""
                    Me.TxtCartonID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If

                If TextHandle.verfyBarCodeStyle(CBdic(0), BarCode, CB2dic(0)) = False Then
                    WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                    SetMessage("FAIL", "條碼不符合標準樣式")
                    'PlaySimpleSound(1)
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtCartonID.Text = ""
                    Me.TxtCartonID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If
            End If
        Else
            If Not String.IsNullOrEmpty(Label11.Text) Then
                If BarCode.Trim.Length <> Label11.Text.Length Then
                    WorkStantOption.ErrorStr = "扫描条码长度不对"
                    SetMessage("Fail", "扫描条码长度不对")
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtCartonID.Text = ""
                    Me.TxtCartonID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If

                If TextHandle.verfyBarCodeStyle(Label11.Text, BarCode, Label13.Text) = False Then
                    WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                    SetMessage("FAIL", "條碼不符合標準樣式")
                    'PlaySimpleSound(1)
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtCartonID.Text = ""
                    Me.TxtCartonID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Function CompareAttachedCarton(ByVal BarCode As String, ByVal index As Integer)
        If Not CBTdic Is Nothing AndAlso CBTdic.Count > 0 AndAlso CBTdic.Count >= index Then
            If CBTdic(index).Length > 0 Then
                If BarCode.Trim.Length <> CBTdic(index).Length Then
                    WorkStantOption.ErrorStr = "附属扫描条码长度不对"
                    SetMessage("Fail", "附属扫描条码长度不对")
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtCartonID.Text = ""
                    Me.TxtCartonID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If

                If TextHandle.verfyBarCodeStyle(CBTdic(index), BarCode, CBT2dic(index)) = False Then
                    WorkStantOption.ErrorStr = "附属條碼不符合標準樣式"
                    SetMessage("FAIL", "附属條碼不符合標準樣式")
                    'PlaySimpleSound(1)
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = Me.LblMainBarCode.Text
                    ShowFrmScanErrPrompt()
                    TxtCartonID.Text = ""
                    Me.TxtCartonID.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If String.IsNullOrEmpty(TxtMoId.Text) Then
            MessageBox.Show("请先做扫描设置")
            Exit Sub
        End If
        Dim sql As String = "SELECT * FROM M_USERRIGHT_T WHERE USERID='" & VbCommClass.VbCommClass.UseId & "' AND TKEY='m0521a_'"
        Using dt As DataTable = DbOperateUtils.GetDataTable(sql)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("无权限操作，请通知品管")
                Exit Sub
            End If
        End Using
        GetBarcodeStyle()
        Using frm As FrmIssueHandler = New FrmIssueHandler(TxtMoId.Text, 1)
            frm.StartPosition = FormStartPosition.CenterParent
            frm.ShowDialog()
        End Using
    End Sub

    Public Sub GetBarcodeStyle()
        sStyle.Clear()
        If SBdic.Count > 0 Then
            sStyle.Add(0, SBdic(0))
            sStyle.Add(1, SB2dic(0))
        Else
            sStyle.Add(0, TxtSnStyle1.Text)
            sStyle.Add(1, TxtSnStyle2.Text)
        End If
        cStyle.Clear()
        If CBdic.Count > 0 Then
            cStyle.Add(0, CBdic(0))
            cStyle.Add(1, CB2dic(0))
        Else
            cStyle.Add(0, Label11.Text)
            cStyle.Add(1, Label13.Text)
        End If
        pStyle.Clear()
        If PBdic.Count > 0 Then
            pStyle.Add(0, PBdic(0))
            pStyle.Add(1, PB2dic(0))
        Else
            pStyle.Add(0, Label24.Text)
            pStyle.Add(1, Label25.Text)
        End If
        isCartonSame = scanSetting.vCartonSame = "Y"
        isPalletSame = scanSetting.vPalletSame = "Y"
    End Sub

    Public Shared sStyle As New Dictionary(Of Integer, String)
    Public Shared cStyle As New Dictionary(Of Integer, String)
    Public Shared pStyle As New Dictionary(Of Integer, String)
    Public Shared isCartonSame As Boolean = False
    Public Shared isPalletSame As Boolean = False
    Public isCartonPalletScan As Boolean = False

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
End Class