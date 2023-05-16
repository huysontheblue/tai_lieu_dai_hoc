Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame
Imports System.Xml
Imports MainFrame.SysCheckData
Imports System.IO
Imports BarCodePrint

Public Class FrmMultiPackScan
    '外箱条码中间存储变量
    Private TempCartonId As String = ""
    Private CheckCartonIndex As Integer = 0
    Private IsConnect As Boolean = False
    Private ServerName As String
    Private ServerCon As String
    Public LockFile As String = ""
    Public IsServer As Boolean = False
    Public curindex As Integer = 0
    Public DoCount As Integer = 0
    Private QtyIndex As Integer = 0
    Private PackCheckQty As Integer = 0
    Private stationid As String = ""
    Private stationname As String = ""
    'Add By KyLin Qiu 20170905 增加客户料号和批次信息  用来截取非系统条码的装箱数量
    Private StrProNo As String = ""
    Private StrLotNo As String = ""
    Private txt_tmpbarcode As String = "" '校验码临时变量
    Dim IsTrunk As String = "N"
    Dim paraCartonArrays As String()      '箱条码校验参数
    Dim iCartonStartindex As Integer     '
    Dim iCartonStartLength As Integer
    Dim CheckCartonCurIndex As Integer = 0

    Dim paraArrays As String()      '条码校验参数
    Dim ssStartindex As Integer     '流水起始位置 田玉琳 2017014
    Dim ssStartLength As Integer    '流水起始长度 田玉琳 2017014
    Dim CheckCurIndex As Integer = 0
    Dim PackArray As New SysMessageClass.PrtStructure
    Public scanSetting As New ScanSetting

#Region "事件"
    '加载数据
    Private Sub FrmManualpacking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LoadSqlServerName()
        LoadLogTreeInfo()
        Dim printDoc As New System.Drawing.Printing.PrintDocument()
        lblPrint.Text = printDoc.PrinterSettings.PrinterName
    End Sub

    '扫描设置
    Private Sub toolScanSet_Click(sender As Object, e As EventArgs) Handles toolScanSet.Click
        Dim FrmConfigSet As New FrmConfigSet
        FrmConfigSet.ShowDialog()
        If ScanOption.IsExitFlag = True Then Exit Sub
        If GetIsScanFinish(ScanOption.SelMOID) = True Then
            lbHasPackqty.Text = "0" : lbNeedPackQty.Text = "0"
            SetMessage("FAIL", "该工单全部扫描完成！")
            Exit Sub
        End If
        txt_tmpbarcode = ""
        lbllineid.Text = ScanOption.SelLineID
        lblmoid.Text = ScanOption.SelMOID
        lblPartID.Text = ScanOption.Partid
        stationid = ScanOption.SelStationID.Split("-")(0).Trim
        stationname = ScanOption.SelStationID.Split("-")(1).Trim
        scanSetting.MoidStr = ScanOption.SelMOID
        scanSetting.PartidStr = ScanOption.Partid
        '条码校验
        If ScanOption.vRepeatStyle = "Y" Then
            ReDim paraArrays(ScanOption.vRepeatPara.Split(",").Length - 1)
            Dim i As Integer = 0
            For i = 0 To paraArrays.Length - 1
                paraArrays(i) = ScanOption.vRepeatPara.Split(",")(i).Replace("{", "").Replace("}", "").Trim
            Next
            '设置有检验时，流水段数据
            GetCodeRuleIdSSSS(lblPartID.Text)
        End If

        '箱条码校验
        If ScanOption.vCartonRepeatStyle = "Y" Then
            ReDim paraCartonArrays(ScanOption.vCartonRepeatPara.Split(",").Length - 1)
            Dim i As Integer = 0
            For i = 0 To paraCartonArrays.Length - 1
                paraCartonArrays(i) = ScanOption.vCartonRepeatPara.Split(",")(i).Replace("{", "").Replace("}", "").Trim
            Next
            '设置有检验时，流水段数据
            GetCartonCodeRuleIdSSSS(lblPartID.Text)
        End If

        Me.toolCartonHandle.Enabled = True

        GetHasQTY()
        ControlCartonState(0)
        If DoCount <= 0 Then
            If ScanOption.IsOnlineGenCartonID Then
                OnlineCartonID()
                ScanCarton()
            End If
        End If
        '加载已经包装
        LoadPackingData()
        LoadPalletPaceQty()
        If Me.DataGridView1.Rows.Count > 0 Then
            SetPackLevel()
            If DoCount > 0 Then
                SetInitLayout(PackCheckQty / ScanOption.SelPpidQty, ScanOption.SelSecondQty, ScanOption.SelThirdQty, ScanOption.SelPpidQty, ScanOption.LayerType - 1)
            End If
        End If
        '判断是否有未解锁的状况
        Dim errDt As DataTable = CheckErrLockData()
        If errDt.Rows.Count > 0 Then
            Dim errppid As String = errDt.Rows(0)("ppid")
            Dim Errordest As String = errDt.Rows(0)("Errordest")

            WorkStantOption.ErrorStr = Errordest
            SetMessage("Fail", Errordest)
            WorkStantOption.BarCodeStr = errppid
            WorkStantOption.vMainBarCode = errppid
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            Me.ActiveControl.Focus()
            Exit Sub
        End If
    End Sub

    '外箱条码扫描
    Private Sub txtCarton_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCarton.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtCarton.Text.Trim = "" Then
                Exit Sub
            End If
            ScanCarton()
        End If
    End Sub

    '二层外箱扫描
    Private Sub txtSecond_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSecond.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtSecond.Text.Trim = "" Then
                Exit Sub
            End If
            ScanInternalPack(2)
        End If
    End Sub

    '三层外箱扫描
    Private Sub txtThird_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtThird.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtThird.Text.Trim = "" Then
                Exit Sub
            End If
            ScanInternalPack(3)
        End If
    End Sub

    '扫描内包装
    Private Sub ScanInternalPack(ByVal level As String)
        '四层包装
        If level = "3" Then
            If CheckStyle(txtThird.Text.Trim, "内包装") = False Then
                WorkStantOption.ErrorStr = "三层包装样式不匹配！"
                SetMessage("FAIL", WorkStantOption.ErrorStr)
                WorkStantOption.BarCodeStr = Trim(txtThird.Text)
                WorkStantOption.vMainBarCode = Me.txtThird.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                Me.txtThird.Focus()
                Me.txtThird.Clear()
                Exit Sub
            End If
        End If
        '三层包装
        If level = "2" Then
            If CheckStyle(txtSecond.Text.Trim, "内包装") = False Then
                WorkStantOption.ErrorStr = "二层包装样式不匹配！"
                SetMessage("FAIL", WorkStantOption.ErrorStr)
                WorkStantOption.BarCodeStr = Trim(txtSecond.Text)
                WorkStantOption.vMainBarCode = Me.txtSecond.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                Me.txtSecond.Focus()
                Me.txtSecond.Clear()
                Exit Sub
            End If
        End If
        Try
            Dim thirdid As String = txtThird.Text.Trim.ToUpper
            Dim second As String = txtSecond.Text.Trim.ToUpper
            Dim Sqlstr As String = "DECLARE @strmsgid varchar(1),@strmsgText nvarchar(50),@NewCartonid varchar(100),@NextLevel varchar(2)" & _
               "EXECUTE [m_CheckMultiPack_p] " & _
               "'" & Trim(lblmoid.Text) & "','" & txtCarton.Text & "','" & thirdid & "','" & second & "','" & level & "','" & ScanOption.TotalPackLevel & "','" & _
                Trim(lbllineid.Text) & "','" & SysMessageClass.UseId.Trim & "','" & stationid & "',N'" & stationname & "'," & _
                "@strmsgid output,@strmsgText output,@NewCartonid output ,@NextLevel output SELECT @strmsgid ,isnull(@strmsgText,''),@NextLevel,@NewCartonid as NewCartonid "
            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)

            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1" To "3"
                        WorkStantOption.ErrorStr = dt.Rows(0)(1).ToString()
                        SetMessage("FAIL", WorkStantOption.ErrorStr)
                        'PlaySimpleSound(1)              
                        If level = 2 Then
                            WorkStantOption.BarCodeStr = Trim(txtSecond.Text)
                            WorkStantOption.vMainBarCode = Me.txtSecond.Text
                            ShowFrmScanErrPrompt()
                            SetMessage("PASS", "已解锁，请继续进行作业")
                            Me.txtSecond.Focus()
                            Me.txtSecond.Clear()
                        End If
                        If level = 3 Then
                            WorkStantOption.BarCodeStr = Trim(txtThird.Text)
                            WorkStantOption.vMainBarCode = Me.txtThird.Text
                            ShowFrmScanErrPrompt()
                            SetMessage("PASS", "已解锁，请继续进行作业")
                            Me.txtThird.Focus()
                            Me.txtThird.Clear()
                        End If
                        Exit Sub
                    Case "4"
                        'SetGridHeadColumn()
                        ' lbNeedPackQty.Text = ScanOption.CartonQty
                        ' lbHasPackqty.Text = 0
                        If level = 2 Then
                            txtSecond.Text = dt.Rows(0)("NewCartonid").ToString
                            SetMessage("PASS", "二层外箱条码序号，扫描成功...")
                        Else
                            txtThird.Text = dt.Rows(0)("NewCartonid").ToString
                            SetMessage("PASS", "三层外箱条码序号，扫描成功...")
                        End If

                        '下一层
                        If dt.Rows(0)(2) = "1" Then
                            ControlCartonState(2)
                        Else
                            ControlCartonState(4)
                        End If

                        LoadPackingData()
                End Select
            Else
                'SetMessage("FAIL", "系统无法识别此外箱标签序号！")
                'Me.TxtCartonID.Text = ""
                'PlaySimpleSound(1)
                WorkStantOption.ErrorStr = "系统无法识别此外箱标签序号"
                SetMessage("Fail", "系统无法识别此外箱标签序号")
                WorkStantOption.BarCodeStr = txtCarton.Text
                WorkStantOption.vMainBarCode = Me.txtCarton.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                txtCarton.Text = ""
                Me.txtCarton.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageUtils.ShowInformation("有异常发生，请联系管理员!异常信息：" + ex.ToString)
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.lblmoid.Text.Trim, txtCarton.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "CartonIDScanHandle", "sys")
        End Try
    End Sub

    '退出
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '跳过继续下一箱产品扫描
    Private Sub ToolNext_Click(sender As Object, e As EventArgs)
        If ScanOption.IsExitFlag = True Then Exit Sub
        ControlCartonState(0)
        lblResult.Text = "请重新扫描大外箱条码"
        lblMessage.Text = "开始扫描..."
        lblResult.ForeColor = Color.DarkGreen
        lblMessage.ForeColor = Color.Green
    End Sub

    '条码扫描更新进度
    Private Sub Set_SubItemsOK()
        SetLayoutCount(ScanOption.CartonQty, ScanOption.SelSecondQty, ScanOption.SelThirdQty, ScanOption.SelPpidQty, ScanOption.LayerType - 1) 'ScanOption.LayerType
    End Sub

    '条码扫描
    Private Sub txtPpid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPpid.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtCarton.Text.Trim = "" Then
                Exit Sub
            End If
            'add by cq20171110
            If Me.txtPpid.Text.Length <> LTrim(Me.txtPpid.Text).Length Then
                'lblMessage.Text = "ERROR,左端有空格"
                'TxtBarCode.Text = ""
                'Me.TxtBarCode.Focus()
                'PlaySimpleSound(1)

                WorkStantOption.ErrorStr = "ERROR,左端有空格！"
                SetMessage("Fail", "ERROR,左端有空格")
                WorkStantOption.BarCodeStr = txtPpid.Text
                WorkStantOption.vMainBarCode = Me.txtPpid.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                txtPpid.Text = ""
                Me.txtPpid.Focus()


                Exit Sub
            Else
                ' do nothing
            End If

            If Me.txtPpid.Text.Length <> RTrim(Me.txtPpid.Text).Length Then
                'lblMessage.Text = "ERROR,右端有空格"
                'TxtBarCode.Text = ""
                'Me.TxtBarCode.Focus()
                'PlaySimpleSound(1)

                WorkStantOption.ErrorStr = "ERROR,右端有空格！"
                SetMessage("Fail", "ERROR,右端有空格")
                WorkStantOption.BarCodeStr = txtPpid.Text
                WorkStantOption.vMainBarCode = Me.txtPpid.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                txtPpid.Text = ""
                Me.txtPpid.Focus()
                Exit Sub
            Else
                ' do nothing
            End If
            If txtPpid.Text.Trim = "" Then
                Exit Sub
            End If

            Dim ppid As String = txtPpid.Text.Trim
            '验证样式
            If CheckStyle(ppid) = False Then Exit Sub
            ''样式检查开启  Add By KyLin Qiu 20170905
            'If CheckStyle(ppid, "产品条码") = False Then
            '    ' ShowFrmScanErrPrompt(ppid, "产品条码样式不匹配", "请检查相产品条码样式！")
            '    txtPpid.Text = ""
            '    txtPpid.Focus()
            '    Exit Sub
            'End If

            Dim MO_ID As String = Trim(ScanOption.SelMOID)
            Dim TEAM_ID As String = Trim(ScanOption.SelLineID)
            Dim SPOINT As String = ""
            Dim USER_ID As String = SysMessageClass.UseId
            Dim STATION_ID As String = ScanOption.SelStationID.Split("-")(0)
            Dim STAORDER_ID As String = "1"
            Dim SCANORDER_ID As String = "1"
            Dim CARTON_ID As String = txtCarton.Text.Trim
            Dim SecondID As String = txtSecond.Text.Trim.ToUpper
            Dim ThirdID As String = txtThird.Text.Trim.ToUpper

            Dim FACT_QUANTITY As String = ScanOption.SelSecondQty
            Dim isrepair As String = IIf(chkIsRepaired.Checked, "Y", "N")
            'Dim tempstr() As String = scanSetting.vmReplaceArray(scanSetting.vCurrentStandIndex, 1).Split("|")
            Dim Sqlstr As String = String.Empty
            Sqlstr = " DECLARE @strmsgid varchar(1), @strmsgText nvarchar(150), @currqty int, @currPqty int, @OutPQty int, @outPPID nvarchar(64),@NextLevel varchar(2)" & _
                     " EXECUTE [m_CheckMultiPackScanPPID_P] '" & ppid & "','" & SecondID & "','" & ThirdID & "'," & _
                        "'" & MO_ID & "','" & TEAM_ID & "','" & My.Computer.Name & "','" & SysMessageClass.UseId & "'," & _
                        "'" & ScanOption.Partid & "','" & ScanOption.Partid & "','" & ppid & "'," & _
                        "'" & STATION_ID & "','1','1','1','" & CARTON_ID & "','','" & _
                        ScanOption.CartonQty & "','N','N','" & isrepair & "','N'," & _
                        "@strmsgid output,@strmsgText output,@currqty output,@currPqty output, @OutPQty output,@OutPPID output,@NextLevel output " & _
                        "SELECT @strmsgid,@strmsgText,isnull(@currqty,1) as currqty,isnull(@currPqty,1) as currPqty, isnull(@OutPQty,0) as outPQty,@OutPPID as PPID,@NextLevel as NextLevel "
            Try
                Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
                If dt.Rows.Count > 0 Then
                    Select Case dt.Rows(0)(0).ToString()
                        Case "0", "1", "2", "3", "5"
                            Dim ErrorStr As String = dt.Rows(0)(1).ToString()

                            WorkStantOption.ErrorStr = dt.Rows(0)(1).ToString()
                            SetMessage("FAIL", WorkStantOption.ErrorStr)
                            'PlaySimpleSound(1)
                            WorkStantOption.BarCodeStr = Trim(ppid)
                            WorkStantOption.vMainBarCode = Me.txtPpid.Text
                            ShowFrmScanErrPrompt()
                            'ShowFrmScanErrPrompt(ppid, ErrorStr, "请检查相关错误信息！")
                            SetMessage("PASS", "已解锁，请继续进行作业")
                            Me.txtPpid.Clear()
                            Exit Sub
                        Case 6
                            SetMessage("PASS", "产品条码" + Trim(ppid) + "扫描成功！")
                            Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                            DataGridView1.ClearSelection()
                            DataGridView1.Rows(0).Cells(0).Selected = True
                            If DataGridView1.Rows.Count > 30 Then
                                DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                            End If
                            ' SetPackLevel()
                            'ControlCartonState("4")
                            If dt.Rows(0)("NextLevel") <> "" Then
                                ControlCartonState(dt.Rows(0)("NextLevel"))
                            Else
                                '条码
                                ControlCartonState(4)
                            End If
                            ScanOption.CartonQtyI = dt.Rows(0)("currqty").ToString
                            DoCount = ScanOption.CartonQtyI
                            lbHasPackqty.Text = DoCount.ToString
                            '计算当前箱位置
                            CompQtyindex()
                            Set_SubItemsOK()
                            'Case 7
                            '    SetMessage("PASS", "产品条码" + Trim(ppid) + "扫描成功！请扫描下一个PE袋条码")
                            '    Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                            '    DataGridView1.ClearSelection()
                            '    DataGridView1.Rows(0).Cells(0).Selected = True
                            '    If DataGridView1.Rows.Count > 30 Then
                            '        DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                            '    End If
                            '    ' ControlCartonState("2")
                            '    'SetPackLevel()
                            '    DoCount = DoCount + 1 * ScanOption.SelPpidQty
                            '    lbHasPackqty.Text = DoCount.ToString
                            '    Set_SubItemsOK()
                        Case 8 '最外层大外箱装箱完成
                            Me.DataGridView1.Rows.Insert(0, ppid, CARTON_ID, USER_ID, Now())
                            DataGridView1.ClearSelection()
                            DataGridView1.Rows(0).Cells(0).Selected = True
                            If DataGridView1.Rows.Count > 30 Then
                                DataGridView1.Rows.RemoveAt(DataGridView1.Rows.Count - 2)
                            End If
                            Set_SubItemsOK()
                            LabInfo1.BackColor = Color.Gray
                            If ScanOption.IsScanSecondCode Then
                                LabInfo2.BackColor = Color.Gray
                            Else
                                LabInfo2.BackColor = SystemColors.Control
                            End If
                            If ScanOption.IsScanThirdCode Then
                                LabInfo3.BackColor = Color.Gray
                            Else
                                LabInfo3.BackColor = SystemColors.Control
                            End If
                            Dim cartonid As String = txtCarton.Text
                            LabInfo4.BackColor = Color.Gray
                            txtStyle.Text = ScanOption.SelCartonStyle
                            txtCarton.Enabled = True
                            txtCarton.ReadOnly = False
                            txtSecond.Enabled = False
                            txtSecond.ReadOnly = True
                            txtThird.Enabled = False
                            txtThird.ReadOnly = True
                            txtPpid.Enabled = False
                            txtPpid.ReadOnly = True
                            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
                            txtCarton.Clear()
                            txtSecond.Clear()
                            txtPpid.Clear()
                            txtThird.Clear()
                            CheckCartonIndex = 0
                            txtCarton.Focus()
                            '界面显示成装满的数量,而不是显示成0--按照用户的想法进行修改的Moidfied By KyLinQiu20170908
                            lbHasPackqty.Text = (DoCount + 1 * ScanOption.SelPpidQty).ToString
                            DoCount = 0
                            curindex = 0
                            QtyIndex = 0
                            LabInfo4.BackColor = Color.Green
                            '装完一箱后刷新一次
                            LoadPackingData()
                            LoadPalletPaceQty()
                            ControlCartonState(0)
                            SetMessage("PASS", "产品条码" + Trim(ppid) + "扫描成功！装箱完毕，请扫描下一个外箱条码")
                            If ScanOption.IsOnelinePrintCarton Then
                                Dim printBarcode As New MultiPackOnlinePrint
                                Dim str As String = printBarcode.PrintOnlineCarton(lblmoid.Text, lblPartID.Text, ScanOption.CartonCodeRuleID, lbllineid.Text, cartonid, VbCommClass.VbCommClass.UseId, lblPrint.Text)
                                If str <> "" Then
                                    MessageBox.Show("在线打印失败,请重新打印!")
                                    Exit Sub
                                End If
                            End If
                    End Select
                End If
            Catch ex As Exception
                Dim FileName As String = Path.Combine(System.Windows.Forms.Application.StartupPath, "ScanErrorLog.txt")
                File.AppendAllText(FileName, vbNewLine & ex.Message & "---" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                MessageUtils.ShowError(ex.Message)
            End Try
        End If
    End Sub

    '装箱数据明细
    Private Sub toolCartonHandle_Click(sender As Object, e As EventArgs) Handles toolCartonHandle.Click
        Dim obj As FrmMultiPackScanDetail = New FrmMultiPackScanDetail
        obj.ShowDialog()
    End Sub

    '刷新工单生产数据
    Private Sub ToolReflsh_Click(sender As Object, e As EventArgs) Handles ToolReflsh.Click
        LoadPackingData()
        LoadPalletPaceQty()
    End Sub

    '工单拷贝
    Private Sub lblmoid_DoubleClick(sender As Object, e As EventArgs) Handles lblmoid.DoubleClick, lblPartID.DoubleClick
        '双击复制工单和料件的内容,方面运维时复制粘贴Add By KyLinQiu 20170717
        Try
            Dim LabText As Label = sender
            If LabText Is Nothing Then
                Exit Sub
            End If
            Clipboard.SetText(LabText.Text.Trim)
        Catch ex As Exception
        End Try

    End Sub

    '再打印外箱
    Private Sub toolRePrint_Click(sender As Object, e As EventArgs) Handles toolRePrint.Click

        If lblPrint.Text = "" Then
            SetMessage("FAIL", "找不到默认打印机")
            Return
        End If
        If lblmoid.Text.Trim = "" Then
            SetMessage("FAIL", "请先扫描设置！")
            Return
        End If
        Dim frm As New FrmCartonRepeatPrint()
        frm.Moid = lblmoid.Text.Trim
        frm.PartId = lblPartID.Text.Trim
        frm.LabelNum = scanSetting.LabelNum
        frm.PrintName = lblPrint.Text
        frm.Lineid = lbllineid.Text
        frm.CodeRuleID = ScanOption.CartonCodeRuleID
        frm.UserID = VbCommClass.VbCommClass.UseId
        frm.PrintType = FrmCartonRepeatPrint.EnumPrintType.MultiPack
        frm.ShowDialog()
    End Sub
#End Region

#Region "方法"
    Private Sub ScanCarton()
        Dim CartonIDStr As String = txtCarton.Text
        If Me.txtCarton.Text.Length <> LTrim(Me.txtCarton.Text).Length Then
            WorkStantOption.ErrorStr = "ERROR,左端有空格"
            SetMessage("Fail", "ERROR,左端有空格")
            WorkStantOption.BarCodeStr = txtCarton.Text
            WorkStantOption.vMainBarCode = Me.txtCarton.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            txtCarton.Text = ""
            Me.txtCarton.Focus()
            Exit Sub
            ' do nothing
        End If

        If Me.txtCarton.Text.Length <> RTrim(Me.txtCarton.Text).Length Then
            WorkStantOption.ErrorStr = "ERROR,右端有空格"
            SetMessage("Fail", "ERROR,右端有空格")
            WorkStantOption.BarCodeStr = txtCarton.Text
            WorkStantOption.vMainBarCode = Me.txtCarton.Text
            ShowFrmScanErrPrompt()
            SetMessage("PASS", "已解锁，请继续进行作业")
            txtCarton.Text = ""
            Me.txtCarton.Focus()
            Exit Sub
        End If


        Dim m_strQRCode As String = String.Empty
        If CheckCartonIndex = 0 Then
            '****************************************************************
            '勾选华为ASN扫描 二维码新规则代替外箱扫描 李素霞提出需求
            '华为ASN扫描
            If Me.chkIsHWASN.Checked = True Then
                Dim chkIsHWASNValue As String = IIf(Me.chkIsHWASN.Checked, "Y", "N")
                Dim sqlHWASN As String = "declare @PalletID varchar(200), @Msg nvarchar(200),@ReturnValue int" & vbCrLf &
                  "exec m_NewCheckHWASN '" + CartonIDStr + "','" + lblmoid.Text + "','" + lblPartID.Text + "','" + chkIsHWASNValue + "','" + stationid + "','" + m_strQRCode + "',2,@PalletID out,@Msg out,@ReturnValue out" & vbCrLf &
                  "select @PalletID,@Msg,@ReturnValue"
                Dim dtHWASN As DataTable = DbOperateUtils.GetDataTable(sqlHWASN)
                '条码判断
                If dtHWASN.Rows(0)(2).ToString() = "0" Then 'S19二维条码
                    m_strQRCode = txtCarton.Text.Trim
                    CartonIDStr = dtHWASN.Rows(0)(0).ToString '新栈板号
                    txtCarton.Text = CartonIDStr
                ElseIf dtHWASN.Rows(0)(2).ToString() = "1" Then '抛错误信息
                    SetMessage("FAIL", dtHWASN.Rows(0)(1).ToString())
                    Me.txtCarton.Text = ""
                    m_strQRCode = ""
                    Me.txtCarton.Focus()

                    Exit Sub
                ElseIf dtHWASN.Rows(0)(2).ToString() = "2" Then '非S19二维码条码
                    m_strQRCode = txtCarton.Text.Trim
                    SetMessage("PASS", "请继续刷入19条码")
                    Me.txtCarton.Text = ""
                    Me.txtCarton.Focus()
                    Exit Sub
                    'ElseIf dtHWASN.Rows(0)(2).ToString() = "3" Then '普通条码
                End If
            End If
            'lbNeedPackQty.Text = ScanOption.CartonQty
            '验证样式
            If CheckStyle(txtCarton.Text.Trim, "外箱条码") = False Then
                WorkStantOption.ErrorStr = "外箱条码样式不匹配！"
                SetMessage("FAIL", WorkStantOption.ErrorStr)
                'PlaySimpleSound(1)
                WorkStantOption.BarCodeStr = Trim(txtCarton.Text)
                WorkStantOption.vMainBarCode = Me.txtCarton.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                Me.txtCarton.Focus()
                Me.txtCarton.Clear()
                Exit Sub
            End If
        End If
        '验证样式 箱校验
        If CheckStyleC(CartonIDStr) = False Then Exit Sub

        Try
            Dim Sqlstr As String = "DECLARE @strmsgid varchar(1),@strmsgText nvarchar(50),@NewCartonid varchar(100),@qty int, @palletQty float " & _
               "EXECUTE [m_CheckMultiCarton_C] " & _
               "'" & Trim(lblmoid.Text) & "','" & CartonIDStr & "','N','','" & Trim(lbllineid.Text) & "','" & SysMessageClass.UseId.Trim & "','" & ScanOption.IsSameCartonStyle & "',''," & _
               "'N','" & stationid & "',N'" & stationname & "'," & _
               "@strmsgid output,@strmsgText output,@NewCartonid output,@qty output, @palletQty output " & _
               " SELECT @strmsgid ,isnull(@strmsgText,''),@qty ,@NewCartonid, @palletQty "

            Dim dt As DataTable = DbOperateUtils.GetDataTable(Sqlstr)
            If dt.Rows.Count > 0 Then
                Select Case dt.Rows(0)(0).ToString()
                    Case "1" To "3"
                        WorkStantOption.ErrorStr = dt.Rows(0)(1).ToString()
                        SetMessage("FAIL", WorkStantOption.ErrorStr)
                        'PlaySimpleSound(1)
                        WorkStantOption.BarCodeStr = Trim(txtCarton.Text)
                        WorkStantOption.vMainBarCode = Me.txtCarton.Text
                        ShowFrmScanErrPrompt()
                        SetMessage("PASS", "已解锁，请继续进行作业")
                        Me.txtCarton.Focus()
                        Me.txtCarton.Clear()
                        Exit Sub
                    Case "4"
                        'SetGridHeadColumn()
                        lbNeedPackQty.Text = ScanOption.CartonQty
                        lbHasPackqty.Text = 0
                        txtCarton.Text = dt.Rows(0)(3).ToString
                        SetMessage("PASS", "外箱条码序号，扫描成功...")
                        LoadPackingData()
                        If ScanOption.IsScanThirdCode Then
                            ControlCartonState("3")
                            Exit Sub
                        End If
                        If ScanOption.IsScanSecondCode Then
                            ControlCartonState("2")
                            Exit Sub
                        End If
                        ControlCartonState("4")
                End Select
            Else
                'SetMessage("FAIL", "系统无法识别此外箱标签序号！")
                'Me.TxtCartonID.Text = ""
                'PlaySimpleSound(1)
                WorkStantOption.ErrorStr = "系统无法识别此外箱标签序号"
                SetMessage("Fail", "系统无法识别此外箱标签序号")
                WorkStantOption.BarCodeStr = txtCarton.Text
                WorkStantOption.vMainBarCode = Me.txtCarton.Text
                ShowFrmScanErrPrompt()
                SetMessage("PASS", "已解锁，请继续进行作业")
                txtCarton.Text = ""
                Me.txtCarton.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageUtils.ShowInformation("有异常发生，请联系管理员!异常信息：" + ex.ToString)
            Dim errMsg As Exception = New Exception(String.Format("MOID:{0}#BCode:{1}#{2}", Me.lblmoid.Text.Trim, txtCarton.Text.Trim, ex.ToString))
            SysMessageClass.WriteErrLog(errMsg, "BarCodeScan.FrmInCarton", "CartonIDScanHandle", "sys")
            Exit Sub
        End Try

    End Sub

    '设置相关信息
    Private Sub ControlCartonState(ByVal ScanIndex As String)
        If ScanIndex = "0" Then
            LabInfo1.BackColor = Color.Gray
            If ScanOption.IsScanSecondCode Then
                LabInfo2.BackColor = Color.Gray
            Else
                LabInfo2.BackColor = SystemColors.Control
            End If
            If ScanOption.IsScanThirdCode Then
                LabInfo3.BackColor = Color.Gray
            Else
                LabInfo3.BackColor = SystemColors.Control
            End If

            LabInfo4.BackColor = Color.Gray
            txtStyle.Text = ScanOption.SelCartonStyle
            txtCarton.Enabled = True
            txtCarton.ReadOnly = False
            txtThird.Enabled = False
            txtThird.ReadOnly = True
            txtSecond.Enabled = False
            txtSecond.ReadOnly = True
            txtPpid.Enabled = False
            txtPpid.ReadOnly = True
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            txtCarton.Clear()
            txtSecond.Clear()
            txtThird.Clear()
            txtPpid.Clear()
            CheckCartonIndex = 0

            'Me.PanelEx1.Controls.Clear()
            InitLayoutTable(ScanOption.CartonQty, ScanOption.SelSecondQty, ScanOption.SelThirdQty, ScanOption.SelPpidQty, ScanOption.LayerType - 1) 'ScanOption.LayerType


            'Me.lbHasPackqty.Text = 0
            'Me.lbNeedPackQty.Text = 0
            lbNeedPackQty.Text = ScanOption.CartonQty.ToString
            lblResult.Text = "请扫描最外层外箱条码"
            lblMessage.Text = "开始扫描..."
            lblResult.ForeColor = Color.DarkGreen
            lblMessage.ForeColor = Color.Green
            txtCarton.Focus()
            Select Case ScanOption.TotalPackLevel
                Case 1
                    If ScanOption.VirtualTrayQty <> 0 Then
                        lblDesc.Visible = True
                        lblDesc.Text = String.Format("每个外箱装{0}个托盘,每个托盘装{1}个产品", ScanOption.CartonQty / ScanOption.VirtualTrayQty, ScanOption.VirtualTrayQty)
                    End If
                Case 2
                    lblDesc.Visible = True
                    lblDesc.Text = String.Format("每个外箱装{0}个彩盒,每个彩盒装{1}个产品", ScanOption.CartonQty / ScanOption.SelSecondQty, ScanOption.SelSecondQty / ScanOption.SelPpidQty)
                Case 3
                    lblDesc.Visible = True
                    lblDesc.Text = String.Format("每个大外箱装{0}个中箱,每个中箱装{1}个彩盒,每个彩盒装{2}个产品", ScanOption.CartonQty / ScanOption.SelThirdQty, ScanOption.SelThirdQty / ScanOption.SelSecondQty, ScanOption.SelSecondQty)
            End Select
            '  Me.DoCount = 0
            Me.DataGridView1.Rows.Clear()
            If Outer_box.Checked = True Then
                If txtStyle.Text.Trim() <> "" And txtCarton.Text = "" Then
                    txtCarton.Text = txtStyle.Text.Trim()
                    If txtCarton.Text.Trim = "" Then
                        Exit Sub
                    End If
                    ScanCarton()
                End If

            End If
        ElseIf ScanIndex = "1" Then
            LabInfo1.BackColor = Color.Green
            If ScanOption.IsScanCartonQrCode Then
                LabInfo2.BackColor = Color.Gray
            Else
                LabInfo2.BackColor = SystemColors.Control
            End If
            If ScanOption.IsScanSecondCode Then
                LabInfo3.BackColor = Color.Gray
            Else
                LabInfo3.BackColor = SystemColors.Control
            End If
            LabInfo4.BackColor = Color.Gray
            txtStyle.Text = ScanOption.SelQrCodeStyle
            txtCarton.Enabled = True
            txtCarton.ReadOnly = False
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            txtSecond.Enabled = False
            txtSecond.ReadOnly = True
            txtSecond.BorderColor = Color.FromArgb(35, 130, 196)
            txtPpid.Enabled = False
            txtPpid.ReadOnly = True
            txtCarton.Text = ""
            Me.txtCarton.Focus()
            txtSecond.Text = ""
            txtPpid.Text = ""
        ElseIf ScanIndex = "2" Then
            LabInfo1.BackColor = Color.Green
            'If ScanOption.IsScanCartonQrCode Then
            '    LabInfo2.BackColor = Color.Green
            'Else
            '    LabInfo2.BackColor = SystemColors.Control
            'End If
            If ScanOption.IsScanThirdCode Then
                LabInfo3.BackColor = Color.Green
            Else
                LabInfo3.BackColor = SystemColors.Control
            End If

            LabInfo2.BackColor = Color.Gray
            LabInfo4.BackColor = Color.Gray
            txtStyle.Text = ScanOption.SelSecondStyle
            txtCarton.Enabled = False
            txtCarton.ReadOnly = True
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            txtThird.Enabled = False
            txtThird.ReadOnly = True
            txtSecond.Enabled = True
            txtSecond.ReadOnly = False
            txtSecond.Text = ""
            txtPpid.Text = ""
            Me.txtSecond.Focus()
            txtPpid.Enabled = False
            txtPpid.ReadOnly = True
            lblResult.Text = "请扫描二层外箱条码"
            lblMessage.Text = "开始扫描..."
            If Tray.Checked = True Then
                If txtStyle.Text.Trim() <> "" And txtSecond.Text = "" Then
                    txtSecond.Text = txtStyle.Text.Trim()
                    If txtSecond.Text.Trim = "" Then
                        Exit Sub
                    End If
                    ScanInternalPack(2)
                End If
            End If
        ElseIf ScanIndex = "3" Then
            LabInfo1.BackColor = Color.Green
            'If ScanOption.IsScanCartonQrCode Then
            '    LabInfo2.BackColor = Color.Green
            'Else
            '    LabInfo2.BackColor = SystemColors.Control
            'End If
            'If ScanOption.IsScanSecondCode Then
            '    LabInfo3.BackColor = Color.Gray
            'Else
            '    LabInfo3.BackColor = SystemColors.Control
            'End If
            LabInfo2.BackColor = Color.Gray
            'LabInfo3.BackColor = Color.Green
            LabInfo4.BackColor = Color.Gray
            txtStyle.Text = ScanOption.SelThirdStyle
            txtCarton.Enabled = False
            txtCarton.ReadOnly = True
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            txtSecond.Enabled = False
            txtSecond.ReadOnly = True
            txtSecond.Text = ""
            txtThird.Enabled = True
            txtThird.ReadOnly = False
            txtThird.Text = ""
            txtThird.Focus()
            txtPpid.Text = ""
            txtPpid.Enabled = False
            txtPpid.ReadOnly = True
            lblResult.Text = "请扫描三层外箱条码"
            lblMessage.Text = "开始扫描..."
        ElseIf ScanIndex = "4" Then '产品条码

            LabInfo1.BackColor = Color.Green
            If ScanOption.IsScanThirdCode Then
                LabInfo3.BackColor = Color.Green
            Else
                LabInfo3.BackColor = SystemColors.Control
            End If
            If ScanOption.IsScanSecondCode Then
                LabInfo2.BackColor = Color.Green
            Else
                LabInfo2.BackColor = SystemColors.Control
            End If
            LabInfo4.BackColor = Color.Gray
            ScanOption.vCurrentStandIndex = 4
            txtCarton.Enabled = False
            txtCarton.ReadOnly = True
            txtCarton.BorderColor = Color.FromArgb(35, 130, 196)
            txtSecond.Enabled = False
            txtSecond.ReadOnly = True
            txtThird.Enabled = False
            txtThird.ReadOnly = True
            txtSecond.BorderColor = Color.FromArgb(35, 130, 196)
            txtStyle.Text = ScanOption.SelPpidStyle
            txtPpid.Text = ""
            txtPpid.Enabled = True
            txtPpid.ReadOnly = False
            Me.txtPpid.Focus()
            lblResult.Text = "请扫描产品条码"
            lblMessage.Text = "开始扫描..."
        End If
    End Sub

    '加载权限 Add By KyLinQiu20170908
    Private Sub LoadLogTreeInfo()
        '装箱数据明细  toolCartonHandle
        Dim StrSql As String = String.Format("SELECT a.Tkey,a.ButtonID FROM dbo.m_Logtree_t a INNER JOIN dbo.m_UserRight_t b ON a.Tkey=b.Tkey " &
                                             " WHERE a.Tparent IN (SELECT Tkey FROM dbo.m_Logtree_t WHERE TreeTag='SysPrint.Frmpacking') " &
                                             " AND b.UserID='{0}'", VbCommClass.VbCommClass.UseId)
        Dim dtLogTree As DataTable = DbOperateUtils.GetDataTable(StrSql)
        If (Not dtLogTree Is Nothing) AndAlso dtLogTree.Rows.Count > 0 Then
            For Each dr As DataRow In dtLogTree.Rows
                Select Case dr("ButtonID").ToString.Trim
                    Case "toolCartonHandle"
                        Me.toolCartonHandle.Enabled = True
                End Select
            Next
        End If
    End Sub

    '设置错误信息
    Private Sub ShowFrmScanErrPrompt()
        Dim FrmError As New FrmScanErrPrompt(scanSetting)
        FrmError.ShowDialog()
    End Sub

    '设置信息
    Private Sub SetMessage(result As String, message As String)
        If result.ToUpper = "FAIL" Then
            lblResult.Text = message
            lblMessage.Text = "FAIL"
            lblResult.ForeColor = Color.DarkGreen
            lblMessage.ForeColor = Color.Red
        Else
            lblResult.Text = message
            lblMessage.Text = "PASS"
            lblResult.ForeColor = Color.DarkGreen
            lblMessage.ForeColor = Color.Green
        End If
    End Sub

    '查询已包装
    Private Sub LoadPackingData()
        Dim StrSql As String = String.Format(" EXEC p_GetMultiPackingData '{0}','{1}'  ", ScanOption.SelMOID, ScanOption.SelLineID)
        Dim dtLotData As DataTable = DbOperateUtils.GetDataTable(StrSql)
        DataGridView1.Rows.Clear()
        If (Not dtLotData Is Nothing) AndAlso dtLotData.Rows.Count > 0 Then
            lbHasPackqty.Text = dtLotData.Rows(0)("hasqty").ToString
            For Each DrRow As DataRow In dtLotData.Rows
                Me.DataGridView1.Rows.Add(DrRow("SN").ToString.Trim, DrRow("PSN").ToString.Trim, DrRow("Userid").ToString.Trim, DrRow("Intime").ToString.Trim)
                txtCarton.Text = DrRow("TopSN").ToString.Trim
            Next
        End If

    End Sub

    '条码验证样式
    Private Function CheckStyle(ByRef BarCode As String, Optional ByVal BarcodeType As String = "条码") As Boolean
        '扫描条码样式不能为空
        If txtStyle.Text.Trim.Length = 0 Then
            SetMessage("Fail", "扫描的" + BarcodeType + "样式不能为空！")
            Return False
        Else
            If ScanOption.IsOnlineGenCartonID = False Then
                If BarCode.Trim.Length <> txtStyle.Text.Length Then
                    SetMessage("Fail", "扫描的" + BarcodeType + "长度不符合標準樣式长度")
                    Return False
                End If
                If TextHandle.verfyBarCodeStyle(txtStyle.Text, BarCode, txtStyle.Text) = False Then
                    SetMessage("FAIL", "扫描的" + BarcodeType + "不符合標準樣式")
                    Return False
                End If
            End If
            End If
            Return True
    End Function

    '设置进度样式1
    Private Sub SetLayoutCount(ByVal FirstQty As Integer, ByVal SecondQty As Integer, ByVal ThirdQty As Integer, ByVal PpidQty As Integer, Optional ByVal layerType As Integer = 0)
        Dim cuur As Integer = QtyIndex
        Dim CartonQty As Integer = FirstQty
        Dim Text As String = ""
        Dim IsPackFinished As Boolean = False
        Dim trayqty As Integer = IIf(ScanOption.VirtualTrayQty = 0, 1, ScanOption.VirtualTrayQty)
        Select Case layerType
            Case 0
                CartonQty = FirstQty / PpidQty
                Dim txt As String = PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text
                Dim cuurtext As String = txt.Split("-")(0).ToString
                Dim arr As String() = txt.Split("-")(1).ToString.Split("/")
                Dim cuurqty As Integer = arr(0)
                Dim needqty As Integer = arr(1)

                If cuurqty + 1 < needqty Then
                    IsPackFinished = False
                Else
                    IsPackFinished = True
                End If
                cuurqty = cuurqty + 1
                PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text = cuurtext + "-" + cuurqty.ToString + "/" + trayqty.ToString
            Case 1
                CartonQty = FirstQty / SecondQty
                Dim txt As String = PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text
                Dim cuurtext As String = txt.Split("-")(0).ToString
                Dim arr As String() = txt.Split("-")(1).ToString.Split("/")
                Dim cuurqty As Integer = arr(0)
                Dim needqty As Integer = arr(1)

                If cuurqty + 1 < needqty Then
                    IsPackFinished = False
                Else
                    IsPackFinished = True
                End If
                cuurqty = cuurqty + 1
                PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text = cuurtext + "-" + cuurqty.ToString + "/" + SecondQty.ToString

            Case 2
                CartonQty = FirstQty / SecondQty
                Dim txt As String = PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text
                Dim cuurtext As String = txt.Split("-")(0).ToString
                Dim arr As String() = txt.Split("-")(1).ToString.Split("/")
                Dim cuurqty As Integer = arr(0)
                Dim needqty As Integer = arr(1)
                If cuurqty + 1 < needqty Then
                    IsPackFinished = False
                Else
                    IsPackFinished = True
                End If
                cuurqty = cuurqty + 1
                PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text = cuurtext + "-" + cuurqty.ToString + "/" + SecondQty.ToString ' + "/" + ThirdQty.ToString
                'Text = "0/" + SecondQty.ToString + "/" + ThirdQty.ToString
        End Select
        'If lbHasPackqty.Text = lbNeedPackQty.Text Then
        '    IsPackFinished = True
        'End If

        If IsPackFinished Then
            If PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls.Count > cuur Then
                PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).ForeColor = Color.White
                PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).BackColor = Color.Green

            End If
            QtyIndex = cuur + 1
        Else
            If Me.PanelEx1.Controls.Count > 0 Then
                If PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls.Count > cuur Then
                    PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).ForeColor = Color.Red
                    PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).BackColor = Color.Teal
                End If
            End If

            QtyIndex = cuur
        End If

    End Sub

    '设置进度样式4
    Private Sub InitLayoutTable(ByVal FirstQty As Integer, ByVal SecondQty As Integer, ByVal ThirdQty As Integer, ByVal PpidQty As Integer, Optional ByVal layerType As Integer = 0)
        Dim CartonQty As Integer = FirstQty
        Dim Text As String = ""
        Dim trayqty As Integer = IIf(ScanOption.VirtualTrayQty = 0, 1, ScanOption.VirtualTrayQty)
        Select Case layerType
            Case 0
                '存在PPID为1的数量
                CartonQty = FirstQty / trayqty
                Text = "0/" + trayqty.ToString
                '  Text = "0/1"
            Case 1
                CartonQty = FirstQty / SecondQty
                Text = "0/" + SecondQty.ToString
            Case 2
                CartonQty = FirstQty / SecondQty
                Text = "0/" + SecondQty.ToString '+ "/" + ThirdQty.ToString
        End Select

        Dim col As Integer = 10

        If CartonQty > 30 Then
            col = 10
        Else
            col = 5
        End If
        If CartonQty >= 80 Then
            col = 12
        End If
        Dim row As Integer = CartonQty \ col + 1
        If (CartonQty Mod col) = 0 Then
            row = CartonQty \ col
        End If

        If CartonQty < 10 Then
            Select Case CartonQty
                Case 9
                    row = 3
                    col = 3
                Case 8
                    row = 3
                    col = 3
                Case 7
                    row = 3
                    col = 3
                Case 6
                    row = 3
                    col = 2
                Case 5
                    row = 3
                    col = 2
                Case 4
                    row = 2
                    col = 2
                Case 3
                    row = 2
                    col = 2
                Case 2
                    row = 2
                    col = 2
                Case 1
                    row = 2
                    col = 2
            End Select
        End If


        Me.PanelEx1.Controls.Clear()
        'If CartonQty > 120 Then
        '    Label9.Visible = False
        '    Exit Sub
        'Else
        '    Label9.Visible = True
        'End If
        Label9.Visible = True
        QtyIndex = lbHasPackqty.Text
        Dim demoLayoutPanel As TableLayoutPanel = New TableLayoutPanel
        demoLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        demoLayoutPanel.Name = "TableLayoutPanel1"
        demoLayoutPanel.Dock = DockStyle.Fill
        '加载时不闪动
        demoLayoutPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic).SetValue(demoLayoutPanel, True, Nothing)

        Me.PanelEx1.Controls.Add(demoLayoutPanel)
        DynamicLayout(demoLayoutPanel, row, col)
        Dim i As Integer
        Dim m As Integer = 0
        For i = 0 To row - 1
            Dim j As Integer
            For j = 0 To col - 1
                If m < CartonQty Then
                    Dim btn As Button = New Button()
                    btn.BackColor = Color.LightGray
                    btn.Name = i.ToString + "_" + j.ToString
                    btn.Text = (m + 1).ToString
                    If Text <> "" Then
                        btn.Text = btn.Text + "-" + Text
                    End If

                    If (CartonQty <= 20) Then
                        btn.Font = New Font("a", 20)
                    ElseIf (CartonQty > 20 And CartonQty < 40) Then
                        btn.Font = New Font("a", 10)
                    End If
                    btn.Dock = DockStyle.Fill
                    btn.Enabled = False

                    demoLayoutPanel.Controls.Add(btn)
                End If

                m = m + 1
            Next
        Next
    End Sub

    '设置进度样式5
    Private Sub DynamicLayout(ByVal layoutPanel As TableLayoutPanel, ByVal row As Integer, ByVal col As Integer)
        layoutPanel.RowCount = row    '设置分成几行
        Dim i As Integer
        For i = 0 To row - 1
            layoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        Next
        layoutPanel.ColumnCount = col    '设置分成几列
        Dim j As Integer
        For j = 0 To col - 1
            layoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        Next
    End Sub

    '初始化进度
    Private Sub SetInitLayout(ByVal FirstQty As Integer, ByVal SecondQty As Integer, ByVal ThirdQty As Integer, ByVal PpidQty As Integer, Optional ByVal layerType As Integer = 0)
        '计算当前箱位置
        CompQtyindex()
        Dim cuur As Integer = QtyIndex
        Dim CartonQty As Integer = FirstQty
        Dim Text As String = ""
        Dim IsPackFinished As Boolean = False
        Dim trayqty As Integer = IIf(ScanOption.VirtualTrayQty = 0, 1, ScanOption.VirtualTrayQty)
        If Me.PanelEx1.Controls.Count > 0 Then
            Dim i As Integer = 0
            If cuur >= 1 Then
                '满小盒显示
                For i = 0 To (cuur - 1) Step 1
                    Select Case layerType
                        Case 0
                            PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(i).Text = (i + 1).ToString + "-" + trayqty.ToString + "/" + trayqty.ToString
                            'IsPackFinished = True
                        Case 1
                            'CartonQty = FirstQty / SecondQty
                            PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(i).Text = (i + 1).ToString + "-" + SecondQty.ToString + "/" + SecondQty.ToString
                        Case 2
                            ' CartonQty = FirstQty / SecondQty
                            Text = (i + 1).ToString + "-" + SecondQty.ToString + "/" + SecondQty.ToString '+ "/" + ThirdQty.ToString
                            PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(i).Text = Text
                    End Select
                    PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(i).ForeColor = Color.White
                    PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(i).BackColor = Color.Green
                Next
            End If
            Select Case layerType
                Case 0
                    If DoCount Mod trayqty = 0 Then
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text = (cuur + 1).ToString + "-" + trayqty.ToString + "/" + trayqty.ToString
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).ForeColor = Color.White
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).BackColor = Color.Green
                    Else
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text = (cuur + 1).ToString + "-" + (DoCount Mod trayqty).ToString + "/" + trayqty.ToString
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).ForeColor = Color.Red
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).BackColor = Color.Teal
                    End If
                Case 1
                    If DoCount Mod SecondQty = 0 Then
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text = (cuur + 1).ToString + "-" + SecondQty.ToString + "/" + SecondQty.ToString
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).ForeColor = Color.White
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).BackColor = Color.Green
                    Else
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text = (cuur + 1).ToString + "-" + (DoCount Mod SecondQty).ToString + "/" + SecondQty.ToString
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).ForeColor = Color.Red
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).BackColor = Color.Teal
                    End If
                Case 2
                    ' CartonQty = FirstQty / SecondQty
                    If DoCount Mod SecondQty = 0 Then
                        Text = (cuur + 1).ToString + "-" + SecondQty.ToString + "/" + SecondQty.ToString '+ "/" + ThirdQty.ToString
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text = Text
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).ForeColor = Color.White
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).BackColor = Color.Green
                    Else
                        Text = (cuur + 1).ToString + "-" + (DoCount Mod SecondQty).ToString + "/" + SecondQty.ToString '+ "/" + ThirdQty.ToString
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).Text = Text
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).ForeColor = Color.Red
                        PanelEx1.Controls.Find("TableLayoutPanel1", True)(0).Controls(cuur).BackColor = Color.Teal
                    End If
            End Select
        End If
    End Sub

    '设定当前层
    Private Sub SetPackLevel()
        Dim cartonid As String = txtCarton.Text
        Dim strSQL As String = "SELECT * FROM m_CartonLevel_t (nolock) WHERE  TopSN='" & cartonid & "' and  Status = 'N' order by SnLevel"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        If (dt.Rows.Count > 0) Then
            '扫描上一层
            Dim level As Integer = CInt(dt.Rows(0)("snlevel").ToString) - 1

            Select Case level
                Case 0
                    txtStyle.Text = ScanOption.SelPpidStyle
                    If ScanOption.TotalPackLevel = 3 Then
                        txtSecond.Text = dt.Rows(0)("SN").ToString '二层
                        txtThird.Text = dt.Rows(0)("PSN").ToString '三层
                    ElseIf ScanOption.TotalPackLevel = 2 Then
                        txtSecond.Text = dt.Rows(0)("PSN").ToString '二层
                    End If
                    ControlCartonState(4)
                Case 1
                    '扫了箱,三层
                    If ScanOption.TotalPackLevel = 3 Then
                        txtThird.Text = dt.Rows(0)("SN").ToString
                    Else
                        txtThird.Text = ""
                    End If
                    txtStyle.Text = ScanOption.SelSecondStyle
                    ControlCartonState(2)
                Case 2 '只扫了箱
                    txtStyle.Text = ScanOption.SelThirdStyle
                    ControlCartonState(3)
            End Select
        End If
    End Sub

    '已装数量
    Private Sub GetHasQTY()
        DoCount = 0
        Dim StrSql As String = String.Format("SELECT TOP 1 Cartonqty FROM m_Carton_t (nolock) A JOIN M_CARTONLEVEL_T (NOLOCK) B ON A.CARTONID=B.SN AND B.SN=B.TOPSN where MOID ='" & ScanOption.SelMOID & "' AND Teamid='" & ScanOption.SelLineID & "' AND CartonStatus ='N'")
        Dim dtLotData As DataTable = DbOperateUtils.GetDataTable(StrSql)
        If dtLotData.Rows.Count > 0 Then
            lbHasPackqty.Text = dtLotData.Rows(0)("Cartonqty").ToString
            DoCount = dtLotData.Rows(0)("Cartonqty").ToString
        Else
            lbHasPackqty.Text = "0"
            DoCount = 0
        End If
    End Sub

    '定位当前盒子
    Private Sub CompQtyindex()
        '每盒数或虚拟tray 数
        Dim Secpackqty As Integer
        If ScanOption.TotalPackLevel = 1 Then
            Secpackqty = IIf(ScanOption.VirtualTrayQty = 0, 1, ScanOption.VirtualTrayQty)
        Else
            Secpackqty = ScanOption.SelSecondQty
        End If
        If Secpackqty > 1 Then
            If (DoCount Mod Secpackqty) <> 0 Then
                QtyIndex = ((Secpackqty - (DoCount Mod Secpackqty) + DoCount.ToString) / Secpackqty) - 1
            Else
                QtyIndex = (DoCount / Secpackqty) - 1
            End If
        Else
            QtyIndex = DoCount - 1
        End If
        'QtyIndex = (DoCount - 1) / ScanOption.SelSecondQty
        'Else
        '    QtyIndex = DoCount - 1
        'End If
    End Sub

    '验证箱条码样式
    Private Function CheckStyleC(ByRef BarCode As String) As Boolean
        '**************************非系统箱条码扫描 20161220 开始******************************************
        '非系统打印箱条码要求验证样式

        '不是自动生成外箱
        '取得是否检查箱样式 田玉琳 20171215 
        If ScanOption.vCartonRepeatPara = "Y" And Me.txtStyle.Text.Trim.Length <> 0 Then
            If BarCode.Trim.Length <> txtStyle.Text.Length Then
                WorkStantOption.ErrorStr = "扫描箱条码长度不对"
                SetMessage("Fail", "扫描箱条码长度不对")
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = BarCode
                ShowFrmScanErrPrompt()
                Me.txtCarton.Text = ""
                Me.txtCarton.Focus()
                Exit Function
            End If

            If TextHandle.verfyBarCodeStyle(txtStyle.Text, BarCode, txtStyle.Text) = False Then
                WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                SetMessage("FAIL", "條碼不符合標準樣式")
                'PlaySimpleSound(1)
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = BarCode
                ShowFrmScanErrPrompt()
                txtCarton.Text = ""
                Me.txtCarton.Focus()
                Exit Function
            End If
        End If
        '**************************非系统箱条码扫描 20161220 结束******************************************
        '********************************20170323 田玉琳 Start  ****************************************************
        '增加对验证条码流水和唯一性处理
        If ScanOption.vCartonRepeatPara = "Y" Then
            If txt_tmpbarcode = "" Then
                txt_tmpbarcode = txtCarton.Text.Trim
                SetMessage("PASS", BarCode & Space(3) & "扫描成品箱条码成功，请继续扫描箱校验条码！")
                txtCarton.Clear()
                txtCarton.Focus()
                Return False
            Else
                If txtCarton.Text <> txt_tmpbarcode Then
                    SetMessage("FAIL", "校验码" & "{" & BarCode & "}校验不成功...Fail,请重新验证")
                    Return False
                End If
            End If
            txt_tmpbarcode = ""
        End If
        '********************************20170323 田玉琳 End  ****************************************************

        '--------- add by cq 20171106  ---------------------
        If ScanOption.vCartonRepeatStyle = "Y" Then
            If txt_tmpbarcode = "" Then
                txt_tmpbarcode = txtCarton.Text.Trim

                SetMessage("PASS", BarCode & Space(3) & "扫描箱条码成功，请继续扫描校验条码！")

                If paraCartonArrays(CheckCartonCurIndex).ToString.ToLower = "@ppid" Then
                    txtStyle.Text = ScanOption.SelCartonStyle
                Else
                    CheckCartonCurIndex = 0
                    Dim styles() As String = paraCartonArrays(CheckCartonCurIndex).Split("|")
                    If styles(0) = "@ppid" Then
                        txtStyle.Text = ScanOption.SelCartonStyle
                    Else
                        txtStyle.Text = styles(0)
                    End If
                End If
                txtCarton.Clear()
                txtCarton.Focus()
                Return False
            Else
                Dim styles() As String = paraCartonArrays(CheckCartonCurIndex).Split("|")
                Dim str As String = styles(0)
                If str = "@ppid" Then
                    str = txt_tmpbarcode
                End If

                If BarCode.Length = str.Length AndAlso TextHandle.verfyBarCodeStyle(str, txtCarton.Text, str) Then
                    If styles.Length > 1 Then
                        '要求验证条码流水号
                        If styles(1) = "10" Or styles(1) = "11" Then
                            If iCartonStartindex + iCartonStartLength <> txt_tmpbarcode Then
                                SetFailContent(BarCode, String.Format("请检查料件打印参数料号[{0}]设置参数代码对应的参数值的正确性", lblPartID.Text))
                                Return False
                            End If
                            Dim ppidssss As String = txt_tmpbarcode.Substring(iCartonStartindex, iCartonStartLength)
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
                            InsertAssysnCheck(BarCode, txt_tmpbarcode)
                        End If
                    End If
                    SetMessage("PASS", "校验码" & CheckCartonCurIndex + 1 & "{" & BarCode & "}校验成功，请继续扫描下一个校验条码！")
                    txtCarton.Clear()
                    txtCarton.Focus()
                    If CheckCartonCurIndex = paraCartonArrays.Length - 1 Then
                        '扫描完成最后一个，样式返回第一个
                        txtStyle.Text = scanSetting.vstyleArray(scanSetting.vCurrentStandIndex, 0)

                        BarCode = txt_tmpbarcode
                        txtCarton.Text = BarCode
                        txt_tmpbarcode = ""
                        CheckCartonCurIndex = 0
                        Return True
                    Else
                        CheckCartonCurIndex = CheckCartonCurIndex + 1
                        Dim NextStr As String = paraCartonArrays(CheckCartonCurIndex).Split("|")(0)
                        If NextStr = "@ppid" Then
                            NextStr = txt_tmpbarcode
                        End If
                        txtStyle.Text = NextStr
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

    '条码验证样式
    Private Function CheckStyle(ByRef BarCode As String) As Boolean

        '********************************20170206 田玉琳 Start ****************************************************
        '扫描条码样式不能为空
        If txtStyle.Text.Trim.Length = 0 Then
            WorkStantOption.ErrorStr = "扫描条码样式不能为空！"
            SetMessage("Fail", "扫描条码样式不能为空！")
            WorkStantOption.BarCodeStr = BarCode
            WorkStantOption.vMainBarCode = BarCode
            ShowFrmScanErrPrompt()
            txtPpid.Text = ""
            Me.txtPpid.Focus()
            Return False
        End If
        '********************************20170206 田玉琳 End ****************************************************

        '********************************20160615 田玉琳 Start ****************************************************
        '非系统打印条码要求验证样式
        ' 田玉琳 20161101 
        '系统条码也要验证样式（有子件处理）IsHaveChildCode IsPrtSelf <> "Y" And 

        ' 田玉琳 20171128 系统条码也需要验证样式，修改判断条件 
        'If (IsHaveChildCode = "Y" Or IsPrtSelf <> "Y") And TxtSnStyle1.Text.Trim.Length <> 0 Then
        If txtStyle.Text.Trim.Length <> 0 Then
            If BarCode.Trim.Length <> txtStyle.Text.Length Then
                WorkStantOption.ErrorStr = "扫描条码长度不对"
                SetMessage("Fail", "扫描条码长度不对")
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = BarCode
                ShowFrmScanErrPrompt()
                txtPpid.Text = ""
                Me.txtPpid.Focus()
                Return False
            End If

            If TextHandle.verfyBarCodeStyle(txtStyle.Text, BarCode, txtStyle.Text) = False Then
                WorkStantOption.ErrorStr = "條碼不符合標準樣式"
                SetMessage("FAIL", "條碼不符合標準樣式")
                'PlaySimpleSound(1)
                WorkStantOption.BarCodeStr = BarCode
                WorkStantOption.vMainBarCode = Me.txtPpid.Text
                ShowFrmScanErrPrompt()
                txtPpid.Text = ""
                Me.txtPpid.Focus()
                Return False
            End If
        End If
        '********************************20160615 田玉琳 End ****************************************************

        '********************************20160617 田玉琳 Start ---Change by hs ke 20160927 ****************************************************
        '有子条码时，不对子条码验证，只对主条码验证 20170314 田玉琳
        '增加对验证条码流水和唯一性处理
        If ScanOption.vRepeatStyle = "Y" Then
            If txt_tmpbarcode = "" Then
                txt_tmpbarcode = txtPpid.Text.Trim

                SetMessage("PASS", BarCode & Space(3) & "扫描成品条码成功，请继续扫描校验条码！")

                If paraArrays(CheckCurIndex).ToString.ToLower = "@ppid" Then
                    txtStyle.Text = ScanOption.SelPpidStyle
                Else
                    CheckCurIndex = 0
                    Dim styles() As String = paraArrays(CheckCurIndex).Split("|")
                    If styles(0) = "@ppid" Then
                        txtStyle.Text = ScanOption.SelPpidStyle
                    Else
                        txtStyle.Text = styles(0)
                    End If
                End If
                txtPpid.Clear()
                txtPpid.Focus()
                Return False
            Else
                Dim styles() As String = paraArrays(CheckCurIndex).Split("|")
                Dim str As String = styles(0)
                If str = "@ppid" Then
                    str = txt_tmpbarcode
                End If

                If BarCode.Length = str.Length AndAlso TextHandle.verfyBarCodeStyle(str, txtPpid.Text, str) Then
                    If styles.Length > 1 Then
                        '要求验证条码流水号
                        If styles(1) = "10" Or styles(1) = "11" Then
                            If ssStartindex + ssStartLength <> txt_tmpbarcode.Length Then
                                SetFailContent(BarCode, String.Format("请检查料件打印参数料号[{0}]设置参数代码对应的参数值的正确性", lblPartID.Text))
                                Return False
                            End If
                            Dim ppidssss As String = txt_tmpbarcode.Substring(ssStartindex, ssStartLength)
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
                            InsertAssysnCheck(BarCode, txt_tmpbarcode)
                        End If
                    End If
                    SetMessage("PASS", "校验码" & CheckCurIndex + 1 & "{" & BarCode & "}校验成功，请继续扫描下一个校验条码！")
                    txtPpid.Clear()
                    txtPpid.Focus()
                    If CheckCurIndex = paraArrays.Length - 1 Then
                        '扫描完成最后一个，样式返回第一个
                        txtStyle.Text = ScanOption.SelPpidStyle
                        BarCode = txt_tmpbarcode
                        txtPpid.Text = BarCode
                        txt_tmpbarcode = ""
                        CheckCurIndex = 0
                        Return True
                    Else
                        CheckCurIndex = CheckCurIndex + 1
                        Dim NextStr As String = paraArrays(CheckCurIndex).Split("|")(0)
                        If NextStr = "@ppid" Then
                            NextStr = txt_tmpbarcode
                        End If
                        txtStyle.Text = NextStr
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
        WorkStantOption.vMainBarCode = BarCode
        WorkStantOption.ErrorStr = errMsg
        SetMessage("FAIL", errMsg)
        ShowFrmScanErrPrompt()
    End Sub
    '保存验证数据，为验证唯一性
    Private Sub InsertAssysnCheck(ppid As String, exppid As String)
        Dim strSQL As String = " EXEC m_InsertAssysnCheck_P '{0}','{1}','{2}','{3}','{4}','{5}' "
        strSQL = String.Format(strSQL, ppid, exppid, lblmoid.Text, lbllineid.Text, My.Computer.Name, VbCommClass.VbCommClass.UseId)
        DbOperateUtils.ExecSQL(strSQL)
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
        PackArray.AvcPartid = Me.lblPartID.Text.Trim 'AVC料號
        PackArray.CusName = ScanOption.CustID  ' 客戶名稱
        PackArray.Deptid = ScanOption.Deptid  ' '部門
        PackArray.Lineid = ScanOption.SelLineID  ' Me.TxtLineId.Text.Trim  '線別
        PackArray.Moid = Me.lblmoid.Text.Trim   '工單
        TimeSqlstr = "select getdate() as nowtime"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(TimeSqlstr)
        If dt.Rows.Count > 0 Then
            ServerDate = CDate(dt.Rows(0)("nowtime").ToString)
        End If
        PackArray.NowDate = ServerDate.AddHours(-7.5).ToString("yyyy-MM-dd").ToString ''服務器日期
        PackArray.NowMonth = ServerDate.AddHours(-7.5).ToString("MM").ToString ''服務器月份
        PackArray.Qty = ScanOption.CartonQty
        PackArray.Extended1 = ScanOption.TotalPackLevel
        PackBarCode.StaionId = stationid
        PackBarCode.StaionName = stationname
        If PackBarCode.MarkJLabel(PackArray.ToArray, "Y10") Then
            If String.IsNullOrEmpty(PackBarCode.m_CartonID) Then
                OnlineCartonID = PackBarCode.JLabelStr ''生成箱號
            Else
                OnlineCartonID = PackBarCode.m_CartonID
            End If
            '是否尾箱号
            IsTrunk = PackBarCode.IsTrunk
            Me.txtCarton.Text = OnlineCartonID
        Else
            If PackBarCode.m_CartonID = "00000000" Then
                OnlineCartonID = "00000000"
                SetMessage("PASS", "该工单已扫描完成！")
            End If
        End If
    End Function


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
        sqlstr.Append("select ppid,Errordest from m_AssysnE_t WHERE  Userid='" & VbCommClass.VbCommClass.UseId & "' and spoint='" & My.Computer.Name & "' and Moid='" & Me.lblmoid.Text & "' and Teamid='" & Me.lbllineid.Text & "' and Stationid='" & Stationid & "' and Intime>CONVERT(varchar(10),getdate(),23)  and isnull(Solvetime,'')='' ")
        Return DbOperateUtils.GetDataTable(sqlstr.ToString)
    End Function
    '设置装箱数 设置目前第几箱数量
    Private Sub LoadPalletPaceQty()
        'update by hgd 2017-09-05 加入站点判断

        Dim dt As DataTable = DbOperateUtils.GetDataTable(" select isnull(count(Cartonid),0) packcount from m_carton_t(nolock) where moid='" & Me.lblmoid.Text & "' AND StationId='" & stationid & "' ")

        If dt.Rows.Count > 0 Then
            LabCartonQty.Text = dt.Rows(0)("packcount").ToString
        End If
    End Sub
#End Region

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Outer_box.CheckedChanged
        If Outer_box.Checked = True Then
            If txtStyle.Text.Trim() <> "" And txtCarton.Text = "" Then
                txtCarton.Text = txtStyle.Text.Trim()
                If txtCarton.Text.Trim = "" Then
                    Exit Sub
                End If
                ScanCarton()
            End If

        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles Tray.CheckedChanged
        If Tray.Checked = True Then
            If txtStyle.Text.Trim() <> "" And txtSecond.Text = "" Then
                txtSecond.Text = txtStyle.Text.Trim()
                If txtSecond.Text.Trim = "" Then
                    Exit Sub
                End If
                ScanInternalPack(2)
            End If

        End If
    End Sub

    'Private Sub txtSecond_Enter(sender As Object, e As EventArgs) Handles txtSecond.Enter
    '    If Tray.Checked = True Then
    '        If txtStyle.Text.Trim() <> "" And txtSecond.Text = "" Then
    '            txtSecond.Text = txtStyle.Text.Trim()
    '            If txtSecond.Text.Trim = "" Then
    '                Exit Sub
    '            End If
    '            ScanInternalPack(2)
    '        End If
    '    End If
    'End Sub

    'Private Sub txtCarton_Enter(sender As Object, e As EventArgs) Handles txtCarton.Enter
    '    If Outer_box.Checked = True Then
    '        If txtStyle.Text.Trim() <> "" And txtCarton.Text = "" Then
    '            txtCarton.Text = txtStyle.Text.Trim()
    '            If txtCarton.Text.Trim = "" Then
    '                Exit Sub
    '            End If
    '            ScanCarton()
    '        End If

    '    End If
    'End Sub
End Class
