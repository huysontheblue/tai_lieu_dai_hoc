
'--海翼包装扫描作业
'--Create by :　马锋
'--Create date :　2016/09/01
'--Update : 
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

#End Region

Public Class FrmHWITScan

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
    Dim PackArray As New SysMessageClass.PrtStructure
    Dim printscanPPid As String = String.Empty
    Public scanSetting As New ScanSetting
    Dim CheckCurIndex As Integer = 0
    Dim paraArrays As String()      '校验参数
    Dim selectStyle As String
    Dim IsRepeatStyleC As String = "N"
    Dim IsPrtSelfCarton As String = "N"     '是否在系统里面打印外箱
    Dim CODERULEID As String = ""           '外箱编码原则

#End Region

#Region "加载事件"

    Private Sub FrmHWITScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBarCode.Enabled = False
        lblMessage.Text = "请设置扫描资料"
        ToolUsename.Text = SysMessageClass.UseName
        txt_tmpbarcode.Text = ""
    End Sub

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

    '掃描設置
    Private Sub BnScanSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolScanSet.Click
        Dim strSQL As String = ""
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
                    SetMessage("FAIL", "请设置扫描参数")
                    Exit Sub
                End If

                Me.LblPackQty.Text = "0"
                Me.LblCurrQty.Text = "0"

                txtBarCode.Focus()
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
                'LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                ControlState(False)

                If GetIsScanFinish(TxtMoId.Text) = True Then
                    LblPackQty.Text = "0" : LblCurrQty.Text = "0"
                    SetMessage("FAIL", "该工单全部扫描完成！")
                    LoadPalletPaceQty()
                    Exit Sub
                End If

                strSQL = " SELECT ISNULL(IslineMbarcode,'N') IslineMbarcode,isnull(IsUsb,'N') IsUsb,isnull(LinePrtY,'N') LinePrtY," & _
                           " ISNULL(IsAllowRe,'N') as IsProductSame, isnull(IsPackType,'N') as IsPackType, isnull(RepeatStyleC,'N') as IsRepeatStyleC, " & _
                           " ISNULL(IsPrtSelf,'N') as IsPrtSelf,ISNULL(ISPRTSELFCARTON,'N')ISPRTSELFCARTON,ISNULL(CODERULEID,'') as CODERULEID  " & _
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
                '非系统箱条码扫描  田玉琳 20170323
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
                    '''''''獲取未裝滿外箱
                    If scanSetting.vCartonSame = "Y" Then
                        strSQL = "select a.Cartonid,a.cartonqty, isnull(a.PackingQuantity,0) as PackingQuantity ,b.qty from M_Carton_t a join m_SnSBarCode_t b on rtrim(replace(a.cartonid,right(a.cartonid,8),''))=b.sbarcode " &
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
                        txtCartonID.Text = dt.Rows(0)("Cartonid").ToString
                        LblPackQty.Text = dt.Rows(0)("qty").ToString '应装数量
                        Me.LblCurrQty.Text = dt.Rows(0)("cartonqty").ToString '已装数量
                        GetScanItem(Me.txtCartonID.Text)
                        ControlState(True)
                    Else
                        'ControlState(False)
                        If scanSetting.PrtPackingCheck Then
                            ControlState(False)
                        Else
                            If scanSetting.IsOnlineGenCartonID Then
                                Me.txtCartonID.Text = OnlineCartonID()
                                CartonIDScanHandle()
                                ControlState(True)
                            Else
                                ControlState(False)
                            End If
                        End If
                    End If
                Else

                End If
            End If

            LoadPalletPaceQty()

            '***********************田玉琳 20170313 开始*********************************
            If scanSetting.vRepeatStyle = "Y" Then
                ReDim paraArrays(scanSetting.vRepeatPara.Split(",").Length - 1)
                Dim i As Integer = 0
                For i = 0 To paraArrays.Length - 1
                    paraArrays(i) = scanSetting.vRepeatPara.Split(",")(i).Replace("{", "").Replace("}", "")
                Next
            End If
            '***********************田玉琳 20170313 结束*********************************

            scanSetting.CheckStr = False
            If (scanSetting.PrtPackingCheck) Then
                printscanPPid = Me.txtCartonID.Text.Trim
            End If
        Catch ex As Exception
            scanSetting.MoidStr = ""
            TxtMoId.Text = String.Empty
            TxtPartid.Text = String.Empty
            TxtLineId.Text = String.Empty
            SetMessage("FAIL", "设置扫描参数异常,请重新设置")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#{1}", Me.TxtMoId.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "BnScanSet_Click", "sys")
        End Try
    End Sub

    '退出
    Private Sub BnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '条码扫描事件
    Private Sub TxtBarCode_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        If (scanSetting.MoidStr Is Nothing) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.txtBarCode.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            lblMessage.Text = "请选择扫描工单！"
            Me.txtBarCode.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If e.KeyValue = 13 Then
            StandScan()
        End If
    End Sub

    '箱号输入后事件
    Private Sub TxtCartonID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCartonID.KeyPress
        If e.KeyChar = Chr(13) Then
            CartonIDScanHandle()
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

        If Me.txtCartonID.Text <> "" And Me.LblCurrQty.Text <> "0" Then
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
    Private Sub tsbCodeReplacePrint_Click(sender As Object, e As EventArgs)
        If TxtPartid.Text = "" Then
            SetMessage("Fail", "扫描资料未设置...")
            Exit Sub
        End If
        If scanSetting.IsLinePrintFullCode = False Then
            SetMessage("Fail", "在线打印的整个外箱才能重新打印...")
            Exit Sub
        End If

        Try
            Dim frm As New FrmBarCodeReplace()
            frm.Moid = TxtMoId.Text.Trim
            frm.PartId = TxtPartid.Text.Trim
            frm.LabelNum = scanSetting.LabelNum
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

        Try
            Dim frm As New FrmBarCodeReplace()
            frm.Moid = TxtMoId.Text.Trim
            frm.PartId = TxtPartid.Text.Trim
            frm.LabelNum = scanSetting.LabelNum
            frm.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = ex.Message
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNewStantPackScan", "ToolReplace_Click", "sys")
            Exit Sub
        End Try
    End Sub


    Private Sub FrmStantPackScan_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        DisposeData()
        scanSetting.CustIdString = Nothing
        scanSetting.MoidStr = Nothing
        scanSetting.LengthStr = Nothing
        scanSetting.DateCheck = Nothing

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
        Next

        DGridBarCode.AutoResizeColumns()
    End Sub
#End Region

#Region "條碼掃描"

    Private Sub StandScan()

        If (scanSetting.PrtPackingCheck) Then
            If (printscanPPid.Trim.ToUpper <> Me.txtBarCode.Text.Trim.ToUpper) Then
                SetMessage("FAIL", "掃描產品標籤于打印PE袋標籤不符...")
                txtBarCode.Clear()
                PlaySimpleSound(1)
                Exit Sub
            End If
        End If

        If InStr(TxtBarCode.Text, "'") Then
            TxtBarCode.Clear()
            Exit Sub
        End If

        If (String.IsNullOrEmpty(Me.txtBarCodeStyle.Text.Trim)) Then
            SetMessage("FAIL", "请选择海翼SKU码样式...")
            txtBarCode.Clear()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If LblPackQty.Text = "0" Then
            SetMessage("FAIL", "外箱应装数量不能为0，设置有误...")
            txtBarCode.Clear()
            PlaySimpleSound(1)
        End If

        'add by cq20171110
        If Me.txtBarCode.Text.Length <> LTrim(Me.txtBarCode.Text).Length Then
            WorkStantOption.ErrorStr = "ERROR,左端有空格！"
            SetMessage("Fail", "ERROR,左端有空格")
            WorkStantOption.BarCodeStr = txtBarCode.Text
            WorkStantOption.vMainBarCode = txtBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            txtBarCode.Text = ""
            Me.txtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        Else
            ' do nothing
        End If

        If Me.txtBarCode.Text.Length <> RTrim(Me.txtBarCode.Text).Length Then
            WorkStantOption.ErrorStr = "ERROR,右端有空格！"
            SetMessage("Fail", "ERROR,右端有空格")
            WorkStantOption.BarCodeStr = txtBarCode.Text
            WorkStantOption.vMainBarCode = txtBarCode.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            txtBarCode.Text = ""
            Me.txtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        Else
            ' do nothing
        End If

        Dim BarCode As String = Me.txtBarCode.Text.Replace(vbNewLine, "").Trim()

        If Me.TxtMoId.Text = "" Then
            lblMessage.ForeColor = Color.Red
            MessageUtils.ShowError("請先設置好掃描基本信息!")
            txtBarCode.Text = ""
            Me.txtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If BarCode = "" Then
            lblMessage.ForeColor = Color.Red
            MessageUtils.ShowError("產品條碼不能為空!")
            txtBarCode.Text = ""
            Me.txtBarCode.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        Dim Sqlstr As String = String.Empty

        Try

            '**************田玉琳 修改 20170112***********************Start 
            '验证样式
            If CheckStyle(BarCode) = False Then Exit Sub
            '**************田玉琳 修改 20170112***********************END 

            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine(" DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(256), @RTCURR_QUANTITY VARCHAR(256), @RTCURR_PQUANTITY VARCHAR(32), @OUTPPID VARCHAR(256) ")
            strSQL.AppendLine(" EXECUTE Exec_HWITPackingBarcodeScan @RTVALUE OUT, @RTMSG OUT, @RTCURR_QUANTITY OUT, @RTCURR_PQUANTITY OUT, @OUTPPID OUT,  ")
            strSQL.AppendLine(" '" & SysMessageClass.UseId & "', '" & Me.TxtMoId.Text.Trim & "', '" & Me.TxtLineId.Text.Trim & "', '" & My.Computer.Name & "', '" & scanSetting.PartidStr & "', '" & scanSetting.PartidStr & "', '" & scanSetting.vStandId & "', '" & scanSetting.vStandIndex & "','" & scanSetting.vCurrentStandIndex & "', '" & IsPackType.Trim & "', '" & scanSetting.vSamePacking.Trim & "', '" & Me.txtCartonID.Text.Trim & "', '" & BarCode & "' ")
            strSQL.AppendLine(" SELECT @RTVALUE, @RTMSG, @RTCURR_QUANTITY, @RTCURR_PQUANTITY, @OUTPPID AS PPID ")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0)
                    Case "0", "1", "2", "3"
                        scanSetting.ErrorStr = dt.Rows(0)(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "4" ''---掃描成功
                        PlaySimpleSound(0)
                        SetMessage("PASS", "扫描成功...")

                        txtBarCode.Text = dt.Rows(0).Item("PPID").ToString
                        Me.DGridBarCode.Rows.Insert(0, scanSetting.PartidStr, scanSetting.vStandIndex, _
                                                    txtBarCode.Text, scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3), SysMessageClass.UseId, Now())

                        If DGridBarCode.Rows.Count > 100 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If
                        scanSetting.vCurrentStandIndex = scanSetting.vCurrentStandIndex + 1
                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                        txtBarCode.Clear()
                        txtBarCode.Focus()
                        Exit Sub
                    Case "5"
                        scanSetting.ErrorStr = dt.Rows(0)(1)
                        PlaySimpleSound(1)
                        Exit Select
                    Case "6"
                        PlaySimpleSound(0)
                        Me.LblCurrQty.Text = dt.Rows(0)(2)
                        Me.txtBarCode.Text = dt.Rows(0)(4)
                        SetMessage("PASS", "扫描成功...")

                        Me.DGridBarCode.Rows.Insert(0, scanSetting.PartidStr, scanSetting.vStandIndex, txtBarCode.Text, _
                                                    scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3), SysMessageClass.UseId, Now())

                        DGridBarCode.ClearSelection()
                        DGridBarCode.Rows(0).Cells(0).Selected = True
                        If DGridBarCode.Rows.Count > 100 Then
                            DGridBarCode.Rows.RemoveAt(DGridBarCode.Rows.Count - 1)
                        End If

                        scanSetting.vCurrentStandIndex = 1
                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"
                        txtBarCode.Clear()
                        txtBarCode.Focus()
                        Exit Sub
                    Case "7"
                        PlaySimpleSound(0)
                        Me.LblCurrQty.Text = dt.Rows(0)(2)
                        Me.txtBarCode.Text = dt.Rows(0)(4)

                        SetMessage("PASS", BarCode & Space(3) & "该箱已经包装完成,请扫描下一箱...")
                        DGridBarCode.Rows.Clear()
                        scanSetting.vCurrentStandIndex = 1
                        LblBarName.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 3) & ":"

                        'ControlState(False)
                        'Me.txtCartonID.Focus()

                        If scanSetting.IsOnlineGenCartonID Then
                            '**************田玉琳 修改 20160419***********************Start 
                            If IsTrunk = "N" Then
                                If chkShowCartonFull.Checked = True Then
                                    If (MessageUtils.ShowConfirm("确定要进行下一箱？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                                        Me.txtCartonID.Text = OnlineCartonID()
                                    End If
                                Else
                                    Me.txtCartonID.Text = OnlineCartonID()
                                End If
                                CartonIDScanHandle()
                            Else
                                lblMessage.Text = "该工单全部扫描完成！"
                            End If
                            '**************田玉琳 修改 20160419***********************End 
                        Else
                            If chkShowCartonFull.Checked = True Then
                                If (MessageUtils.ShowConfirm("确定要进行下一箱？", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK) Then
                                    ControlState(False)
                                End If
                            Else
                                ControlState(False)
                            End If

                            Me.txtCartonID.Focus()
                            SetScanCodeStyle("C")
                        End If
                        LoadPalletPaceQty()
                        Exit Sub
                End Select
                scanSetting.BarCodeStr = BarCode
                SetMessage("FAIL", BarCode & Space(3) & scanSetting.ErrorStr)
                scanSetting.vMainBarCode = BarCode
                Dim FrmError As New FrmScanErrPrompt(scanSetting)
                FrmError.ShowDialog()

                txtBarCode.Text = ""
                Me.txtBarCode.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, txtBarCode.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmNewStantPackScan", "StandScan", "sys")
        End Try
    End Sub

    Private Sub CartonIDScanHandle()
        Dim Sqlstr As String = String.Empty
        Dim StrQty As Integer

        If Me.TxtPartid.Text = "" Then
            SetMessage("FAIL", "扫描资料未设置，请先设置...")
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If Me.TxtCartonID.Text = "" Then
            SetMessage("FAIL", "箱號條碼序號不能為空！")
            Me.TxtCartonID.Focus()
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (scanSetting.MoidStr Is Nothing) Then
            SetMessage("FAIL", "请选择扫描工单！")
            Me.TxtCartonID.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If (String.IsNullOrEmpty(scanSetting.MoidStr)) Then
            SetMessage("FAIL", "请选择扫描工单！")
            Me.TxtCartonID.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        If scanSetting.IsOnlineGenCartonID = False And (String.IsNullOrEmpty(Me.txtBarCodeStyle.Text.Trim)) Then
            SetMessage("FAIL", "请设置扫描SKU码样式！")
            Me.txtCartonID.Text = ""
            PlaySimpleSound(1)
            Exit Sub
        End If

        Try
            Dim barcode As String = txtCartonID.Text.Trim
            '**************田玉琳 修改 20170323***********************Start 
            '验证样式
            If CheckStyleC(barcode) = False Then Exit Sub
            '**************田玉琳 修改 20170323***********************END 

            Dim strSQL As StringBuilder = New StringBuilder
            strSQL.AppendLine("DECLARE @RTVALUE VARCHAR(8), @RTMSG NVARCHAR(256), @RTCARTON_ID VARCHAR(256), @RTQUANTITY VARCHAR(32) ")
            strSQL.AppendLine("EXECUTE Exec_HWITPackingCartonScan @RTVALUE OUT, @RTMSG OUT, @RTCARTON_ID OUT, @RTQUANTITY OUT, ")
            strSQL.AppendLine("'" & Trim(scanSetting.MoidStr) & "', '" & Trim(scanSetting.LineStr) & "', '" & SysMessageClass.UseId.Trim & "', '" &
                              scanSetting.vCartonSame.Trim & "', '" & scanSetting.vStandId.Trim & "', N'" & scanSetting.vStandName.Trim & "', '" &
                              barcode & "' ")
            strSQL.AppendLine("SELECT @RTVALUE, @RTMSG, @RTCARTON_ID, @RTQUANTITY ")

            Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL.ToString)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1" To "3"
                        PlaySimpleSound(1)
                        SetMessage("FAIL", dt.Rows(0)(1).ToString())
                        Me.txtCartonID.Clear()
                        Exit Sub
                    Case "4"
                        PlaySimpleSound(0)
                        DGridBarCode.Rows.Clear()
                        'SetGridHeadColumn()
                        LblPackQty.Text = ""
                        LblCurrQty.Text = ""
                        StrQty = CInt(dt.Rows(0)(3).ToString)
                        If scanSetting.vCartonSame = "Y" Then
                            txtCartonID.Text = dt.Rows(0)(2).ToString
                        End If

                        LblPackQty.Text = StrQty
                        Me.LblCurrQty.Text = 0
                        SetMessage("PASS", "外箱条码序号，扫描成功...")
                        ControlState(True)
                End Select
            Else
                SetMessage("FAIL", "系统无法识别此外箱标签序号！")
                Me.txtCartonID.Text = ""
                PlaySimpleSound(1)
                Exit Sub
            End If
        Catch ex As Exception
            PlaySimpleSound(1)
            MessageUtils.ShowInformation("数据库连接异常,请检查网络后,重新确认数据扫描!")
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.TxtMoId.Text.Trim, txtCartonID.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "CartonIDScanHandle", "sys")
            Exit Sub
        End Try
    End Sub

#End Region

#Region "方法"

    '条码验证样式
    Private Function CheckStyle(ByRef BarCode As String) As Boolean

        If txtBarCodeStyle.Text.Trim.Length <> 0 Then
            If (IsPackType = "Y") Then
                If (Me.txtBarCode.Text.Trim <> Me.txtCartonID.Text) Then
                    SetMessage("Fail", "无SKU条码扫描，扫描条码与PR条码不符!")
                    WorkStantOption.ErrorStr = "无SKU条码扫描，扫描条码与PR条码不符!"
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = BarCode
                    ShowFrmScanErrPrompt()
                    txtBarCode.Text = ""
                    Me.txtBarCode.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If
            Else
                If BarCode.Trim.Length <> txtBarCodeStyle.Text.Length Then
                    SetMessage("Fail", "扫描条码长度不对")
                    WorkStantOption.ErrorStr = "扫描条码长度不对"
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = BarCode
                    ShowFrmScanErrPrompt()
                    txtBarCode.Text = ""
                    Me.txtBarCode.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If

                If TextHandle.verfyBarCodeStyle(txtBarCodeStyle.Text, BarCode, txtBarCodeStyle.Text) = False Then
                    SetMessage("FAIL", "條碼不符合標準樣式")
                    WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                    WorkStantOption.BarCodeStr = BarCode
                    WorkStantOption.vMainBarCode = BarCode
                    ShowFrmScanErrPrompt()
                    txtBarCode.Text = ""
                    Me.txtBarCode.Focus()
                    PlaySimpleSound(1)
                    Return False
                End If
            End If
        Else
            If (Me.txtBarCode.Text.Trim <> Me.txtCartonID.Text) Then
                SetMessage("Fail", "无SKU条码扫描，扫描条码与PR条码不符!")
                WorkStantOption.ErrorStr = "无SKU条码扫描，扫描条码与PR条码不符!"
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = BarCode
                ShowFrmScanErrPrompt()
                txtBarCode.Text = ""
                Me.txtBarCode.Focus()
                PlaySimpleSound(1)
                Return False
            End If
        End If

        '********************************20170315 田玉琳 Start ****************************************************
        If scanSetting.vRepeatStyle = "Y" Then
            If txt_tmpbarcode.Text = "" Then
                txt_tmpbarcode.Text = TxtBarCode.Text

                SetMessage("PASS", BarCode & Space(3) & "扫描成品条码成功，请继续扫描校验条码！")

                If paraArrays(CheckCurIndex).ToString.ToLower = "@ppid" Then
                    txtBarCodeStyle.Text = selectStyle
                Else
                    CheckCurIndex = 0
                    Dim styles() As String = paraArrays(CheckCurIndex).Split("|")
                    txtBarCodeStyle.Text = styles(0)
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
                    SetMessage("PASS", "校验码" & CheckCurIndex + 1 & "{" & BarCode & "}校验成功，请继续扫描下一个校验条码！")
                    TxtBarCode.Clear()
                    TxtBarCode.Focus()
                    If CheckCurIndex = paraArrays.Length - 1 Then
                        '扫描完成最后一个，样式返回第一个
                        txtBarCodeStyle.Text = selectStyle
                        BarCode = txt_tmpbarcode.Text
                        'TxtBarCode.Text = BarCode
                        txt_tmpbarcode.Text = ""
                        Return True
                    Else
                        CheckCurIndex = CheckCurIndex + 1
                        Dim NextStr As String = paraArrays(CheckCurIndex).Split("|")(0)
                        If NextStr = "@ppid" Then
                            NextStr = txt_tmpbarcode.Text
                        End If
                        txtBarCodeStyle.Text = NextStr
                        Return False
                    End If
                Else
                    SetFailContent(BarCode, "校验码" & CheckCurIndex + 1 & "{" & BarCode & "}校验不成功...Fail,请重新验证")
                    Return False
                End If
            End If
            CheckCurIndex = CheckCurIndex + 1
        End If
        '********************************20170315 田玉琳 End ****************************************************
        Return True
    End Function

    Private Sub SetScanCodeStyle(type As String)
        If type = "P" Then
        ElseIf type = "C" Then
            txtBarCodeStyle.Text = lblCartonStyle.Text
            TxtBarCode.Text = ""
        Else '产品条码
            scanSetting.vCurrentStandIndex = 1
            txtBarCodeStyle.Text = selectStyle
        End If
    End Sub

    '非系统单码扫描，如固定码，直接insert DB，流水码 卡样式
    Private Function GetNonSelfCarton() As Boolean
        '只支持无流水码外箱
        If CODERULEID = "" Then Return False

        Dim ruleID As String = CODERULEID.Split("/")(2)
        SetCartonStyle(ruleID)
        Return True
    End Function

    Private Sub SetCartonStyle(ruleID As String)
        Dim strSQL As String =
        " DECLARE @SnStyle1 varchar(200),@SnStyle2 varchar(200),@Gflen varchar(2) set @SnStyle1='' set @SnStyle2='' set @Gflen='' " & _
        " EXECUTE m_StyleShow_p_AssembleSta_C '" & TxtPartid.Text & "','" & ruleID & "','" & scanSetting.vLabelDate & "',@SnStyle1 output ,@SnStyle2 output,@Gflen output " & _
        " SELECT @SnStyle1,@SnStyle2,@Gflen"
        Using dt1 As DataTable = DbOperateUtils.GetDataTable(strSQL)
            If dt1.Rows.Count > 0 Then
                lblCartonStyle.Text = dt1.Rows(0)(0).ToString
            End If
        End Using
    End Sub

    '系统打印箱样式取得
    Private Function GetIsSelfCarton() As Boolean
        Dim strSQL As String = " select CodeRuleID  from m_partpack_t " &
                               " where  partid='{0}' and usey='Y'  and (DisorderTypeId = 'C' and Packid = 'N' or Packid = 'C') "
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

    '条码验证样式
    Private Function CheckStyleC(ByRef BarCode As String) As Boolean
        If (IsPrtSelfCarton <> "Y") And scanSetting.IsOnlineGenCartonID = False And lblCartonStyle.Text.Trim.Length <> 0 Then
            If BarCode.Trim.Length <> txtBarCodeStyle.Text.Length Then
                WorkStantOption.ErrorStr = "扫描箱条码长度不对"
                SetMessage("Fail", "扫描箱条码长度不对")
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = BarCode
                ShowFrmScanErrPrompt()
                txtCartonID.Text = ""
                Me.txtCartonID.Focus()
                PlaySimpleSound(1)
                Return False
            End If

            If TextHandle.verfyBarCodeStyle(txtBarCodeStyle.Text, BarCode, txtBarCodeStyle.Text) = False Then
                WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                SetMessage("FAIL", "條碼不符合標準樣式")
                'PlaySimpleSound(1)
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = BarCode
                ShowFrmScanErrPrompt()
                txtCartonID.Text = ""
                Me.txtCartonID.Focus()
                PlaySimpleSound(1)
                Return False
            End If
        End If
        '********************************20170323 田玉琳 Start  ****************************************************
        '增加对验证条码流水和唯一性处理
        If IsRepeatStyleC = "Y" Then
            If txt_tmpbarcode.Text = "" Then
                txt_tmpbarcode.Text = txtCartonID.Text
                SetMessage("PASS", BarCode & Space(3) & "扫描成品箱条码成功，请继续扫描箱校验条码！")
                txtCartonID.Clear()
                txtCartonID.Focus()
                Return False
            Else
                If txtCartonID.Text <> txt_tmpbarcode.Text Then
                    SetFailContent(BarCode, "校验码" & "{" & BarCode & "}校验不成功...Fail,请重新验证")
                    Return False
                End If
            End If
            txt_tmpbarcode.Text = ""
        End If
        '********************************20170323 田玉琳 End  ****************************************************
        Return True
    End Function

    Private Sub ControlState(ByVal BorC As Boolean)

        If BorC Then
            txtCartonID.Enabled = False
            txtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
            'TxtCartonID.BackColor = Color.White
            If IsReadSn = "Y" Then
                Me.txtBarCode.WordWrap = True
                Me.txtBarCode.Multiline = True
            End If
            txtBarCode.Enabled = True
            txtBarCode.BackColor = Color.White
            txtBarCode.Text = ""
            Me.txtBarCode.Focus()
            SetScanCodeStyle("S")
        Else
            If TgenCarton = "N" Then
                txtCartonID.Enabled = True
                txtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtBarCode.BorderColor = Color.FromArgb(209, 31, 73)
                txtBarCode.Enabled = False
                'TxtBarCode.BackColor = Color.FromArgb(246, 252, 255)
                ''TxtCartonID.BackColor = Color.White
                txtCartonID.Text = ""
                Me.txtCartonID.Focus()
                SetScanCodeStyle("C")
                If IsReadSn = "Y" Then
                    Me.txtBarCode.WordWrap = True
                    Me.txtBarCode.Multiline = True
                End If
            Else
                txtCartonID.Enabled = False
                txtCartonID.BorderColor = Color.FromArgb(35, 130, 196)
                'TxtCartonID.BackColor = Color.White
                If IsReadSn = "Y" Then
                    Me.txtBarCode.WordWrap = True
                    Me.txtBarCode.Multiline = True
                End If
                txtCartonID.Text = "GeneratePalletNo"
                txtBarCode.Enabled = True
                txtBarCode.BackColor = Color.White
                txtBarCode.Text = ""
                Me.txtBarCode.Focus()
                SetScanCodeStyle("S")
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
            txtBarCodeStyle.Text = WorkStantOption.vstyleArray(1, 0)
            'txtBarCodeStyle.Text = WorkStantOption.vstyleArray(1, 1)
            'TxtBarCode.MaxLength = WorkStantOption.vstyleArray(1, 2)
            'LblBarName.Text = WorkStantOption.vstyleArray(WorkStantOption.vCurrentStandIndex, 3) & ":"
        End If
        TxtBarCode.Text = ""
        Me.TxtBarCode.Focus()
    End Sub

    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt
        FrmError.ShowDialog()
    End Sub

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

    '设置装箱数 设置目前第几箱数量
    Private Sub LoadPalletPaceQty()
        'update by hgd 2017-09-05 加入站点判断
        Dim dt As DataTable = DbOperateUtils.GetDataTable(" select isnull(count(Cartonid),0) packcount from m_carton_t where moid='" & Me.TxtMoId.Text & "' AND StationId='" & scanSetting.vStandId & "' ")

        If dt.Rows.Count > 0 Then
            LabCartonQty.Text = dt.Rows(0)("packcount").ToString
        End If
    End Sub

#End Region

#Region "控件事件"

    Private Sub txtBarCodeStyle_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtBarCodeStyle.ButtonCustomClick
        lblMessage.Text = ""
        LabResult.Text = ""
        Try
            If (String.IsNullOrEmpty(Me.TxtMoId.Text.Trim)) Then
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "Fail:工单不能为空，请扫描设置参数!"
                Exit Sub
            End If

            Dim dtTemp As DataTable = DbOperateUtils.GetDataTable("select  buttonid from m_UserRight_t a inner join m_Logtree_t b on a.tkey =b.tkey where b.tparent in('m059l_') and userid='" & VbCommClass.VbCommClass.UseId & "' and ButtonID='txtBarCodeStyle'")

            If (dtTemp.Rows.Count > 0) Then
                Dim frmHWITMoStyleQuery As New FrmHWITMoStyleQuery(Me.txtBarCodeStyle, Me.TxtMoId.Text.Trim)
                frmHWITMoStyleQuery.Owner = Me
                frmHWITMoStyleQuery.ShowDialog()
                selectStyle = Me.txtBarCodeStyle.Text
            Else
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "Fail:用户无设置海翼样式权限"
                Exit Sub
            End If

        Catch ex As Exception
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Fail:设置海翼SKU异常,请重新设置"
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
End Class