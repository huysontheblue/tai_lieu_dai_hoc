#Region "Imports"
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports System.Data.SqlClient
Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms.DataFormats
Imports MainFrame

#End Region
Public Class FrmNoBarCodePack
 
#Region "初期化"

    Dim EquipmentLifeCheck As String = "N"

    Dim frmBoard As FrmProductionBoard          '看板窗体（可多次打开）

    '快捷键
    Private Sub FrmWorkStantScan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.F1
                ToolStar_Click(sender, e)
                ''Case Keys.F2
                ''    toolCa_Click(sender, e)
            Case Keys.F10 '快捷键F10
                OpenProductionBoard()
            Case Keys.Alt + Keys.X
                Me.Close()
        End Select

    End Sub

    '初始化
    Private Sub FrmNoBarCodePack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialUI()
        IsFactory()
    End Sub

    ''' <summary>
    ''' 初始化
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitialUI()
        Me.lblMessage.Text = "请先设置基础资料"
        Me.lblMOID.Text = "" : Me.lblMOLot.Text = "" : Me.lblLineID.Text = "" : Me.lblFullPackQty.Text = "" : Me.lblPartID.Text = "" : Me.lblPackedQty.Text = ""
        Me.lblCartonQty.Text = "" : Me.lblOuterCartonaID.Text = ""

        'Pack UI
        Me.lblShouldPackQty.Text = "" : Me.lblNowPackedQty.Text = ""

        BindComboxDateJie(cmbDateJie)
        cmbDateJie.SelectedValue = GetCurrentSysteJie()
    End Sub

#End Region

#Region "事件"
    '基础设置
    Private Sub ToolStar_Click(sender As Object, e As EventArgs) Handles ToolStar.Click

        Try
            Dim FrmScanSet As New FrmNoBarCodeSet() 'm_NobarcodeData
            FrmScanSet.Owner = Me
            Dim result As DialogResult = FrmScanSet.ShowDialog()
            If result = DialogResult.OK Then
                Me.lblMOID.Text = Data.MoidStr  '工單编号
                Me.lblPartID.Text = Data.PartidStr    '料件编号
                Me.lblLineID.Text = Data.LineStr ''線別
                Me.lblMOLot.Text = Data.MoidqtyStr '工單数量
                Me.lblFullPackQty.Text = "0"  '满箱已包装数量
                Me.lblPackedQty.Text = "0" '已包装数量
                Me.lblMessage.Text = ""
                '关晓艳新增基础设置之后外箱条码为空 2017-12-17
                Me.txtPPid.Text = ""  '需要自己扫描的外箱条码

                Call PackProcessLoad()
                Call UpdateCatonQty(Data.CartonShouldQty)
                Call LoadDataToDataGrid()
                GetEquipmentCheck()

            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNoBarCodePack", "ToolStar_Click", "sys")
        End Try

        '关晓艳魏孟丽生成按钮为不可用 2017-10-26
        If CheckBox1.Checked = True Then
            btnGenOuterCartonID.Enabled = False '生成按钮
            txtPPid.Enabled = True
        Else
            btnGenOuterCartonID.Enabled = True '生成按钮
        End If

    End Sub

    '退出 
    Private Sub toolExit_Click(sender As Object, e As EventArgs) Handles toolExit.Click
        Me.Close()
    End Sub

    '生成
    Private Sub btnGenOuterCartonID_Click(sender As Object, e As EventArgs) Handles btnGenOuterCartonID.Click
        Try
            '	生成：只有当前外箱编号为空时，才可点击。
            '若勾选不超过工单数，则已包装数量<工单数，才可生成新外箱编号，并更新工单装箱数。
            If Val(Me.lblShouldPackQty.Text) = 0 Then
                Me.lblMessage.Text = "请先在基础设置时设置每箱包装数!"
                Exit Sub
            End If

            If Not String.IsNullOrEmpty(lblMOID.Text) Then
                If Me.chkMOQty.Checked = True Then
                    'If Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) < Val(lblMOLot.Text) Then
                    '    Call GenOuterCartonID()
                    'Else
                    '    Me.lblMessage.Text = "已经超过该工单数，请更换工单！"
                    'End If

                    '关晓艳 设置尾箱数量 2017-12-17
                    If (Val(lblNowPackedQty.Text) + Val(lblPackedQty.Text) + Val(lblShouldPackQty.Text)) > Val(lblMOLot.Text) AndAlso
                                   lblMOLot.Text <> lblFullPackQty.Text Then
                        Call GenOuterCartonID(Val(lblMOLot.Text) - Val(lblFullPackQty.Text))
                        lblShouldPackQty.Text = (Val(lblMOLot.Text) - Val(lblFullPackQty.Text)).ToString
                    ElseIf Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) < Val(lblMOLot.Text) Then
                        Call GenOuterCartonID()
                    Else
                        Me.lblMessage.Text = "已经超过该工单数，请更换工单！"
                    End If
                Else
                    Call GenOuterCartonID()
                End If
            Else
                Me.lblMessage.Text = "请先进行基础设置!"
                Exit Sub
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNoBarCodePack", "btnGenOuterCartonID_Click", "sys")
        End Try
    End Sub

    '提交
    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        Try
            Dim o_blnUpdatePerPackedQty As Boolean = True
            Dim o_iNowPerPackedQty As Integer = 0
            Me.lblMessage.Text = ""
            If Not BaseCheck() Then
                Exit Sub
            End If
            '①更新已装数量。
            '②清空此次包装数量（勾选依次累积装箱时，不清空）。
            '③装满时自动关箱，更新满箱已包装数量，刷新工单最后十笔包装记录，若
            '勾选满箱自动换箱, 则检查
            '勾选不超过工单数，没超过则自动生成(同上)和更新工单装箱数，超过不生成并清空，“生成”按钮变为可点击。
            '不勾选不超过工单数，则自动生成新的外箱(同上)和更新工单装箱数。
            '不勾选满箱自动换箱，清空外箱编号，“生成”按钮变为可点击。
            If Me.ChkFullChange.Checked = True Then
                '勾选不超过工单数，没超过则自动生成(同上)和更新工单装箱数，超过不生成并清空，“生成”按钮变为可点击。
                If Me.chkMOQty.Checked = True Then
                    If Val(Me.txtCurrentPackQty.Text) + Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) <= Val(lblMOLot.Text) Then
                        If UpdatePackingQty(Val(Me.txtCurrentPackQty.Text)) = False Then Exit Sub
                        UpdateEquipmentCount(lblOuterCartonaID.Text.Trim, Me.txtCurrentPackQty.Text.Trim)
                        '当前箱已装数量+此次包装数量=应装数量，关箱的同时，自动生成新的外箱号重新装箱（需检查是否勾选不超过工单数）。
                        If Val(lblNowPackedQty.Text) + Val(Me.txtCurrentPackQty.Text) = Val(lblShouldPackQty.Text) Then
                            'Me.lblNowPackedQty.Text = "0"
                            Me.lblFullPackQty.Text = CStr(Val(Me.lblFullPackQty.Text) + Val(lblShouldPackQty.Text))
                            o_blnUpdatePerPackedQty = False
                        End If
                        If Val(Me.txtCurrentPackQty.Text) + Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) <= Val(lblMOLot.Text) Then 'Val(Me.txtCurrentPackQty.Text) + Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) < Val(lblMOLot.Text) 
                            If Val(Me.lblNowPackedQty.Text) + Val(Me.txtCurrentPackQty.Text) >= Val(lblShouldPackQty.Text) Then '
                                '关晓艳 修改 生成外箱自己点击 2017-12-27
                                'Call GenOuterCartonID()
                                btnGenOuterCartonID.Enabled = True
                            End If
                        Else
                            If chkCloseCaton.Checked Then
                                If (Val(lblNowPackedQty.Text) + Val(txtCurrentPackQty.Text)) = Val(lblShouldPackQty.Text) AndAlso
                                    lblMOLot.Text <> lblFullPackQty.Text Then
                                    '关晓艳 修改尾箱需要自己生成 2017-12-17
                                    btnGenOuterCartonID.Enabled = True
                                    'Call GenOuterCartonID(Val(lblMOLot.Text) - Val(lblFullPackQty.Text))
                                    lblShouldPackQty.Text = (Val(lblMOLot.Text) - Val(lblFullPackQty.Text)).ToString
                                End If
                            End If
                        End If

                        '关晓艳 修改 工单扫漫立即提示  2017-12-17
                        If (Val(lblPackedQty.Text) + Val(txtCurrentPackQty.Text)) = Val(lblMOLot.Text) Then
                            Me.lblMessage.Text = "该工单已经包装完成"
                        End If

                    Else
                        '超过
                        Me.lblOuterCartonaID.Text = ""
                        Me.btnGenOuterCartonID.Enabled = True
                    End If
                Else
                    '不勾选不超过工单数，则自动生成新的外箱(同上)和更新工单装箱数。
                    Call GenOuterCartonID()
                End If
            End If
            If o_blnUpdatePerPackedQty Then
                Me.lblNowPackedQty.Text = CStr(Val(Me.lblNowPackedQty.Text) + Val(Me.txtCurrentPackQty.Text))
                'add by cq20170511
                Me.lblPackedQty.Text = Val(Me.lblFullPackQty.Text) + Val(Me.lblNowPackedQty.Text)
            Else
                'add by cq20170511
                RefeshPackedQty()

                Me.lblNowPackedQty.Text = "0"
            End If


            If Me.chkClearCurrentPackQty.Checked Then
                '清空此次包装记录
                txtCurrentPackQty.Text = ""
            End If
            'Refresh the data
            LoadDataToDataGrid()
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNoBarCodePack", "btnCommit_Click", "sys")
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub



    Private Sub tsbDisplayBoard_Click(sender As Object, e As EventArgs) Handles tsbDisplayBoard.Click
        OpenProductionBoard()
    End Sub

    Private Sub btnCurrrentJie_Click(sender As Object, e As EventArgs) Handles btnCurrrentJie.Click
        cmbDateJie.SelectedValue = GetCurrentSysteJie()
    End Sub

    Private Sub btnBefore_Click(sender As Object, e As EventArgs) Handles btnBefore.Click
        If cmbDateJie.SelectedIndex > 0 Then
            cmbDateJie.SelectedIndex = cmbDateJie.SelectedIndex - 1
        End If
    End Sub

    Private Sub ToolEquipment_Click(sender As Object, e As EventArgs) Handles ToolEquipment.Click
        Try
            If Me.lblMOID.Text = "" Then
                lblMessage.Text = "请先设置扫描资料,才能进行冶具设定..."
                Exit Sub
            End If

            If EquipmentLifeCheck = "Y" Then

                Dim FrmOpenLock As New FrmSetLock
                FrmNewShareSetForm.vStationType = "P"
                FrmOpenLock.ShowDialog()

                If CartonScanOption.CheckStr = True Then
                    Dim FrmEquipmentSet As New FrmNewEquipmentSetForm(TxtLineId.Text, lblMOID.Text)
                    FrmEquipmentSet.Owner = Me
                    FrmEquipmentSet.ShowDialog()

                End If

                '显示用户所选的冶具列表

                Dim strSQL As String = ""
                Dim EquipmentList As String = ScanCommon.GetEquipmentNo(lblMOID.Text, TxtLineId.Text)

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

                    dgvEquipPart.Hide()

                End If

            Else

                lblMessage.Text = "此料号在料件工艺设定没有设定冶具寿命卡控..."
                Exit Sub

            End If

        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNoBarCodePack", "ToolEquipment_Click", "sys")
        End Try
    End Sub


#End Region

#Region "方法"

    Private Sub GetEquipmentCheck()
        Try

            Dim strCheckEquipmentSQL As String = " SELECT A.TPartid, ISNULL(B.RuleId,'') AS RuleId FROM m_RPartStationD_t A LEFT JOIN m_RPartStationCheckRule_t B ON " & _
                                " A.TPartid=B.Tpartid AND A.Revid=B.Revid AND A.StaOrderid=B.StaOrderid AND A.ScanOrderid=B.ScanOrderid AND B.RuleId='18' " & _
                                " WHERE A.TPartid='" & Me.lblPartID.Text.Trim & "' AND A.State = '1' AND A.StaOrderid='1' AND A.ScanOrderid='1' "

            Dim dtEquipmentCheck As DataTable = DbOperateUtils.GetDataTable(strCheckEquipmentSQL)

            If (Not dtEquipmentCheck Is Nothing And dtEquipmentCheck.Rows.Count > 0) Then
                If (String.IsNullOrEmpty(dtEquipmentCheck.Rows(0).Item("RuleId").ToString)) Then
                    EquipmentLifeCheck = "N"
                    dgvEquipPart.Hide()
                    dgvEquipPart.DataSource = Nothing
                    dgvEquipPart.Rows.Clear()
                Else
                    EquipmentLifeCheck = "Y"
                    Dim strSQL As String = ""
                    Dim EquipmentList As String = ScanCommon.GetEquipmentNo(lblMOID.Text, TxtLineId.Text)

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
                        Me.dgvEquipPart.Rows.Clear()
                    End If
                End If
            Else
                EquipmentLifeCheck = "N"
                dgvEquipPart.Hide()
                dgvEquipPart.DataSource = Nothing
                dgvEquipPart.Rows.Clear()
            End If

        Catch ex As Exception
            EquipmentLifeCheck = "N"
            dgvEquipPart.Hide()
            dgvEquipPart.DataSource = Nothing
            dgvEquipPart.Rows.Clear()
        End Try
    End Sub

    ''' <summary>
    ''' 取得扫描数据
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadDataToDataGrid()
        Dim orderIndex As Integer = 0
        Dim lsSQL As String = ""
        dgvPackInfo.Rows.Clear()
        Dim dt As DataTable = Nothing
        Try
            '工单编号,外箱编号,应装数,已装数, 满箱否,操作人员,操作时间
            lsSQL = " SELECT TOP 100 MOID,CartonID ,CartonQty,PackingQuantity,CartonStatus,Teamid, Userid ,INTIME " & _
                    " FROM m_Carton_t     " & _
                    " WHERE MOID='" & Me.lblMOID.Text & "' ORDER BY CartonStatus , Intime DESC"

            dt = DbOperateUtils.GetDataTable(lsSQL)
            For rowIndex As Integer = 0 To dt.Rows.Count - 1
                dgvPackInfo.Rows.Add(dt.Rows(rowIndex)!MOID, dt.Rows(rowIndex)!CartonID, dt.Rows(rowIndex)!PackingQuantity,
                                     dt.Rows(rowIndex)!CartonQty, dt.Rows(rowIndex)!CartonStatus, dt.Rows(rowIndex)!Teamid,
                                     dt.Rows(rowIndex)!Userid, dt.Rows(rowIndex)!intime)
            Next
            dgvPackInfo.AutoResizeColumns()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 自动生成箱号(料件编号加流水)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GenOuterCartonID(Optional remainPackQty As String = "")
        Dim strSQL As String = ""
        Try
            Dim catonQty = Data.CartonShouldQty
            If remainPackQty <> "" Then
                catonQty = remainPackQty
            End If
            ' Dim dt As DataTable = GetDatatable(0, catonQty, 1)

            '关晓艳魏孟丽 判断Checkbox1状态调用存储过程 2017-10-26
            Dim dt As DataTable
            If CheckBox1.Checked Then
                dt = GetDatatable(0, catonQty, 4)
            Else
                dt = GetDatatable(0, catonQty, 1)
            End If

            '关晓艳 修改 尾箱显示数量 2017-12-27
            ' If dt.Rows.Count > 0 Then
            'If remainPackQty <> "" Then

            'Else
            Me.lblShouldPackQty.Text = dt.Rows(0)(1).ToString
            ' End If

            Me.lblOuterCartonaID.Text = dt.Rows(0)(0).ToString
            Me.lblNowPackedQty.Text = dt.Rows(0)(2).ToString
            Me.btnGenOuterCartonID.Enabled = False
            ' End If


            'If dt.Rows.Count > 0 Then
            '    Me.lblOuterCartonaID.Text = dt.Rows(0)(0).ToString
            '    Me.lblShouldPackQty.Text = dt.Rows(0)(1).ToString
            '    Me.lblNowPackedQty.Text = dt.Rows(0)(2).ToString
            '    Me.btnGenOuterCartonID.Enabled = False
            'End If
            Me.lblCartonQty.Text = CStr(Val(Me.lblCartonQty.Text) + 1)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '更新箱数量
    Private Function UpdatePackingQty(ByVal iCurrentPackQty As Integer) As Boolean
        Dim strSQL As String = ""

        Dim dt As DataTable = GetDatatable(iCurrentPackQty, lblShouldPackQty.Text, 2)
        If dt.Rows.Count > 0 Then
            lblMessage.Text = dt.Rows(0)(0).ToString
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 更新箱包装容量
    ''' </summary>
    ''' <param name="iNewCatonQty"></param>
    ''' <remarks></remarks>
    Private Sub UpdateCatonQty(ByVal iNewCatonQty As Integer)
        Dim dt As DataTable = GetDatatable("0", iNewCatonQty, 3)
        If dt.Rows.Count > 0 Then
        End If
    End Sub

    ''' <summary>
    ''' 取得包装数量
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PackProcessLoad()
        Dim lsSQL As String = ""
        Try
            'Cartonqty（已包装数量），PACKINGQUANTITY(装箱容量)
            Using o_dt As DataTable = GetDatatable(0, 0, 9)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.lblCartonQty.Text = o_dt.Rows(0).Item("CartonQty") '工单装箱数
                    Me.lblOuterCartonaID.Text = o_dt.Rows(0).Item("UnfullCartonId") '外箱编号
                    If String.IsNullOrEmpty(Me.lblOuterCartonaID.Text) Then
                        Me.btnGenOuterCartonID.Enabled = True
                    Else
                        Me.btnGenOuterCartonID.Enabled = False
                    End If
                    Me.lblNowPackedQty.Text = o_dt.Rows(0).Item("UnfullPackQty")  '已装数量
                    Me.lblFullPackQty.Text = o_dt.Rows(0).Item("FullPackQty")  '满箱已包装数量
                    Me.lblPackedQty.Text = o_dt.Rows(0).Item("PackedQty")  '已包装数量
                End If
            End Using
            '应装数量：即基础设置中的每箱装箱数
            Me.lblShouldPackQty.Text = Data.CartonShouldQty
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 取得包装数量
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefeshPackedQty()
        Dim lsSQL As String = ""
        Try
            'Cartonqty（已包装数量），PACKINGQUANTITY(装箱容量)
            Using o_dt As DataTable = GetDatatable(0, 0, 9)
                If Not IsNothing(o_dt) AndAlso o_dt.Rows.Count > 0 Then
                    Me.lblCartonQty.Text = o_dt.Rows(0).Item("CartonQty") '工单装箱数
                    Me.lblOuterCartonaID.Text = o_dt.Rows(0).Item("UnfullCartonId") '外箱编号
                    'If String.IsNullOrEmpty(Me.lblOuterCartonID.Text) Then
                    '    Me.btnGenOuterCartonID.Enabled = True
                    'Else
                    '    Me.btnGenOuterCartonID.Enabled = False
                    'End If
                    Me.lblNowPackedQty.Text = o_dt.Rows(0).Item("UnfullPackQty")  '已装数量
                    Me.lblFullPackQty.Text = o_dt.Rows(0).Item("FullPackQty")  '满箱已包装数量
                    Me.lblPackedQty.Text = o_dt.Rows(0).Item("PackedQty")  '已包装数量
                End If
            End Using
            '应装数量：即基础设置中的每箱装箱数
            Me.lblShouldPackQty.Text = Data.CartonShouldQty
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '基础检查
    Private Function BaseCheck() As Boolean
        If String.IsNullOrEmpty(Me.lblShouldPackQty.Text) Then '应装数量不为空（提示其先设置）
            lblMessage.Text = "请先进行基础设置！"
            Return False
        End If

        '关晓艳 2017-12-27
        '如果勾选不超过工单数，则要求此次已装数量!=工单数量 
        If Me.chkMOQty.Checked = True Then
            If Val(lblPackedQty.Text) = Val(lblMOLot.Text) Then
                Me.lblMessage.Text = "该工单已经包装完成"
                Return False
            End If
        End If
        '此次包装数量 +已装数量 <= 应装数量    '应装数量：文本上显示的数量
        If Val(Me.txtCurrentPackQty.Text) + Val(lblNowPackedQty.Text) > Val(lblShouldPackQty.Text) Then
            lblMessage.Text = "此次包装数量 +已装数量 > 应装数量, 请检查！"
            Return False
        End If


        If String.IsNullOrEmpty(Me.lblOuterCartonaID.Text) Then
            lblMessage.Text = "外箱编号不能为空！"
            Return False
        End If

        If Val(Me.txtCurrentPackQty.Text) <= 0 Then
            lblMessage.Text = "此次包装数量输入错误，应为正整数！"
            Me.txtCurrentPackQty.Focus()
            Return False
        End If

        '此次包装数量 +已装数量 <= 应装数量    '应装数量：即基础设置中的每箱装箱数
        If Val(Me.txtCurrentPackQty.Text) + Val(lblNowPackedQty.Text) > Data.CartonShouldQty Then
            lblMessage.Text = "此次包装数量 +已装数量 > 应装数量, 请检查！"
            Return False
        End If


        '关晓艳 2017-12-17
        If Val(Me.lblShouldPackQty.Text) + Val(lblFullPackQty.Text) > Val(lblMOLot.Text) Then
            lblMessage.Text = "扫描信息设置箱数量已超过工单数量，请检查！"
            Return False
        End If



        ''如果勾选不超过工单数，则要求此次包装数量+已装数量+满箱已包装数量<=工单数量
        If Me.chkMOQty.Checked = True Then
            If Val(Me.txtCurrentPackQty.Text) + Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) > Val(lblMOLot.Text) Then
                If Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) = Val(lblMOLot.Text) Then
                    lblMessage.Text = "该工单已经包装完成"
                Else
                    lblMessage.Text = "已经超过工单数, 请检查！"
                End If
                Return False
            End If



        End If
        Return True
    End Function

    ''' <summary>
    ''' 共通取得箱号和更新数据
    ''' </summary>
    ''' <param name="iCurrentPackQty"></param>
    ''' <param name="cartonQty"></param>
    ''' <param name="type"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDatatable(iCurrentPackQty As Integer, cartonQty As Integer, type As String) As DataTable
        '*************************************************
        Dim ngAlertTime As String = GetNgAlertTime(cmbDateJie.SelectedValue.ToString)
        Dim newTime As DateTime

        newTime = DateTime.Now.Date + " " + ngAlertTime
        '*************************************************

        Dim strSQL As String = ""
        strSQL = "  EXECUTE [m_NewCheckPackScanNoCode_P] '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}' "

        '关晓艳魏孟丽调用存储过程修改strSQL语句 2017-10-26
        If CheckBox1.Checked Then
            strSQL = String.Format(strSQL, lblMOID.Text, "P00000", Me.txtPPid.Text, lblLineID.Text, lblShouldPackQty.Text, cartonQty, SysMessageClass.UseId, newTime, type)
        Else
            strSQL = String.Format(strSQL, lblMOID.Text, "P00000", Me.lblOuterCartonaID.Text, lblLineID.Text, iCurrentPackQty, cartonQty, SysMessageClass.UseId, newTime, type)
        End If




        'strSQL = "  EXECUTE [m_NewCheckPackScanNoCode_P] '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}' "
        'strSQL = String.Format(strSQL, lblMOID.Text, "P00000", Me.lblOuterCartonaID.Text, lblLineID.Text, iCurrentPackQty, cartonQty, SysMessageClass.UseId, newTime, type)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
        Return dt
    End Function

    '打开产品看板
    Private Sub OpenProductionBoard()

        If (String.IsNullOrEmpty(lblMOID.Text)) Then
            lblMessage.Text = "请选择扫描工单！"
            Exit Sub
        End If

        '显示看板页面
        If (frmBoard Is Nothing) Then
            frmBoard = New FrmProductionBoard
            frmBoard.PmoidID = lblMOID.Text.Trim
            frmBoard.PLineId = TxtLineId.Text.Trim
            frmBoard.Show()
        ElseIf frmBoard IsNot Nothing AndAlso frmBoard.IsDisposed Then
            frmBoard = New FrmProductionBoard
            frmBoard.PmoidID = lblMOID.Text.Trim
            frmBoard.PLineId = TxtLineId.Text.Trim
            frmBoard.Show()
        Else
            frmBoard.Activate()
        End If
    End Sub

    ''' <summary>
    ''' 时间节次,只显示
    ''' </summary>
    ''' <param name="ColComboBox"></param>
    ''' <remarks></remarks>
    Public Shared Sub BindComboxDateJie(ByVal ColComboBox As ComboBox)
        Dim strSQL As String = " select ClassName ,OrderIndex  from m_KanbanClass_t " &
                               " where ClassType = 'C004'  order by OrderIndex"

        BindComboxNoBlank(strSQL, ColComboBox, "ClassName", "OrderIndex")
    End Sub

#Region "BindComBox"
    Public Shared Sub BindComboxNoBlank(ByVal SQL As String, ByVal ColComboBox As ComboBox, ByVal Text As String, value As String)
        Dim dt As DataTable = DbOperateUtils.GetDataTable(SQL)

        ColComboBox.DataSource = dt
        ColComboBox.DisplayMember = Text
        ColComboBox.ValueMember = value
    End Sub
#End Region

#Region "取得系统时间"

    Public Shared Function GetCurrentSysteJie() As String
        GetCurrentSysteJie = ""
        Dim strSQL As String = " select OrderIndex, StartDt,EndDt  from m_KanbanClass_t " &
                               " where ClassType = 'C004' and CONVERT(varchar(12),getdate(),108) between  StartDt and EndDt"
        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            GetCurrentSysteJie = dt.Rows(0)(0).ToString
        End If
    End Function

    Public Shared Function GetNgAlertTime(selectIndex As String) As String
        GetNgAlertTime = ""

        Dim strSQL As String =
            " declare @currentIndex varchar(2) " &
            " select @currentIndex = OrderIndex  from m_KanbanClass_t " &
            " where ClassType = 'C004' and CONVERT(varchar(12),getdate(),108) between  StartDt and EndDt" &
            " if (@currentIndex = '{0}')" &
            " begin select CONVERT(varchar(12),getdate(),108) end " &
            " else begin select NgAlertTime from m_KanbanClass_t " &
            " where ClassType = 'C004' and OrderIndex = '{0}' end"

        strSQL = String.Format(strSQL, selectIndex)

        Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)

        If dt.Rows.Count > 0 Then
            GetNgAlertTime = dt.Rows(0)(0).ToString
        End If
    End Function
#End Region


#Region "每次扫描成功，对应的冶具使用数量加1,余下数减1"

    Private Sub UpdateEquipmentCount(ByVal BarCodeString As String, ByVal strQuantity As String)

        '对应的冶具编号,卡控工冶具，且有配置工冶具

        If EquipmentLifeCheck = "Y" Then

            Dim strSQL As String = ""
            Dim EquipmentList As String = ScanCommon.GetEquipmentNo(lblMOID.Text, TxtLineId.Text)
            If EquipmentList <> "" Then

                EquipmentList = EquipmentList.TrimEnd(",")
                strSQL = "execute UpdateEquipmentListNOBarCodeCount '" & EquipmentList & "','" + BarCodeString + "', '" + strQuantity + "' "
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                Dim Qty As Integer = Val(dt.Rows(0)(0).ToString())

                ''取最新值
                'strSQL = "execute GetEquipmentListSelected '" & EquipmentList & "','1',''"
                'Me.dgvEquipPart.Rows.Clear()
                'Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                'For Each row As DataRow In dt.Rows
                '    dgvEquipPart.Rows.Add(row("EquipmentNo").ToString(), row("ProcessParameters").ToString(), row("AlertCount").ToString(), row("ServiceCount").ToString(), row("RemainCount").ToString())
                'Next

                For i As Integer = 0 To dgvEquipPart.Rows.Count - 1
                    dgvEquipPart.Rows(i).Cells("ServiceCount").Value = dgvEquipPart.Rows(i).Cells("ServiceCount").Value + Qty
                    dgvEquipPart.Rows(i).Cells("RemainCount").Value = dgvEquipPart.Rows(i).Cells("RemainCount").Value - Qty
                Next

            End If

        End If


    End Sub

#End Region

#End Region

#Region "工单状态设置"

    Private Sub toolMOStatusSetting_Click(sender As Object, e As EventArgs) Handles toolMOStatusSetting.Click
        Try
            If (String.IsNullOrEmpty(Me.lblMOID.Text.Trim)) Then
                lblMessage.Text = "请设置工单！"
                Exit Sub
            End If

            Dim FrmMOStatusSetting As New FrmMOStatusSetting(Me.lblMOID.Text.Trim, Me.lblLineID.Text.Trim)
            FrmMOStatusSetting.ShowDialog()

        Catch ex As Exception
            lblMessage.Text = "打开工单状态设置异常！"
        End Try
    End Sub

#End Region

    '双击复制工单和料件的内容,方面运维时复制粘贴Add By KyLinQiu 20170717
    Private Sub lblMOID_DoubleClick(sender As Object, e As EventArgs) Handles lblMOID.DoubleClick, lblPartID.DoubleClick
        Try
            Dim LabText As Label = sender
            If LabText Is Nothing Then
                Exit Sub
            End If
            Clipboard.SetText(LabText.Text.Trim)
        Catch ex As Exception
        End Try
    End Sub

    '关晓艳复选框状态改变时  2017-10-26
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtPPid.Enabled = True '箱条码
            txtCurrentPackQty.Enabled = False       '包装数量
            btnGenOuterCartonID.Enabled = False '生成按钮
            btnCommit.Enabled = False '提交按钮
        Else
            txtPPid.Enabled = False  '箱条码
            txtCurrentPackQty.Enabled = True '包装数量
            btnGenOuterCartonID.Enabled = True '生成按钮
            btnCommit.Enabled = True  '提交按钮
        End If

    End Sub

    '关晓艳魏孟丽扫描枪扫入条码时加的回车事件 2017-10-26
    Private Sub txtPPid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPPid.KeyPress


        Dim cartonPPid As String
        Me.lblMessage.Text = ""
        cartonPPid = txtPPid.Text.Trim()

        If e.KeyChar = ChrW(13) Then
            Try
                Dim o_blnUpdatePerPackedQty As Boolean = True
                Dim o_iNowPerPackedQty As Integer = 0
                ' Me.lblMessage.Text = ""
                Dim sMOID As String = ""
                Dim sQty As String = ""
                If Not BaseCheck2(sMOID, sQty) Then
                    Exit Sub
                End If


                ' Dim sMoid As String = ""
                ' Dim sQty As String = ""
                'Dim strSQL As String = ""
                'Dim dt As DataTable = Nothing
                '    '工单编号,外箱编号,应装数,已装数, 满箱否,操作人员,操作时间
                'strSQL = " select Moid ,Qty  from m_SnSBarCode_t where SBarCode = '" + cartonPPid + "'"
                'dt = DbOperateUtils.GetDataTable(strSQL)
                'sMoid = dt.Rows(0)(0)  '获取工单
                'sQty = dt.Rows(0)(1) '获取数量

                '①更新已装数量。
                '②清空此次包装数量（勾选依次累积装箱时，不清空）。
                '③装满时自动关箱，更新满箱已包装数量，刷新工单最后十笔包装记录，若
                '勾选满箱自动换箱, 则检查
                '勾选不超过工单数，没超过则自动生成(同上)和更新工单装箱数，超过不生成并清空，“生成”按钮变为可点击。
                '不勾选不超过工单数，则自动生成新的外箱(同上)和更新工单装箱数。
                '不勾选满箱自动换箱，清空外箱编号，“生成”按钮变为可点击。
                If Me.ChkFullChange.Checked = True Then
                    '勾选不超过工单数，没超过则自动生成(同上)和更新工单装箱数，超过不生成并清空，“生成”按钮变为可点击。
                    If Me.chkMOQty.Checked = True Then
                        If sQty + Val(lblPackedQty.Text) <= Val(lblMOLot.Text) Then
                            If UpdatePackingQty(sQty) = False Then Exit Sub
                            UpdateEquipmentCount(cartonPPid, sQty)
                            '当前箱已装数量+此次包装数量=应装数量，关箱的同时，自动生成新的外箱号重新装箱（需检查是否勾选不超过工单数）。
                            If sQty = Val(lblShouldPackQty.Text) Then
                                ' Me.lblNowPackedQty.Text = "0"
                                Me.lblFullPackQty.Text = CStr(Val(Me.lblFullPackQty.Text) + Val(lblShouldPackQty.Text))
                                o_blnUpdatePerPackedQty = False
                            End If
                            If sQty + Val(Me.lblPackedQty.Text) <= Val(lblMOLot.Text) Then 'Val(Me.txtCurrentPackQty.Text) + Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) < Val(lblMOLot.Text) 
                                If sQty = Val(lblShouldPackQty.Text) Then '
                                    Call GenOuterCartonID()
                                End If
                            Else
                                If chkCloseCaton.Checked Then
                                    If sQty = Val(lblShouldPackQty.Text) AndAlso
                                        lblMOLot.Text <> lblFullPackQty.Text Then
                                        '   Call GenOuterCartonID(Val(lblMOLot.Text) - Val(lblFullPackQty.Text))
                                        lblShouldPackQty.Text = (Val(lblMOLot.Text) - Val(lblFullPackQty.Text)).ToString
                                    End If
                                End If
                            End If

                            '超过工单会提示
                            If sQty + Val(lblPackedQty.Text) = Val(lblMOLot.Text) Then
                                Me.lblMessage.Text = "该工单已经包装完成"

                                '提示完成 txtpid不可用
                                txtPPid.Text = ""
                                txtPPid.Enabled = False
                            End If
                        Else

                            '超过
                            Me.txtPPid.Text = ""
                            Me.btnGenOuterCartonID.Enabled = True

                        End If
                    Else
                        '不勾选不超过工单数，则自动生成新的外箱(同上)和更新工单装箱数。
                        ' Call GenOuterCartonID()
                    End If
                End If
                If o_blnUpdatePerPackedQty Then
                    Me.lblNowPackedQty.Text = CStr(sQty)
                    'add by cq20170511
                    Me.lblPackedQty.Text = Val(Me.lblFullPackQty.Text) + Val(Me.lblNowPackedQty.Text)
                Else
                    'add by cq20170511
                    RefeshPackedQty()

                    Me.lblNowPackedQty.Text = "0"
                End If



                'Refresh the data
                LoadDataToDataGrid()

                'gg
                txtPPid.Text = ""

            Catch ex As Exception
                SysMessageClass.WriteErrLog(ex, "BarCodeScan.FrmNoBarCodePack", "btnCommit_Click", "sys")
                MessageUtils.ShowError(ex.Message)
            End Try

        End If


    End Sub

    '关晓艳魏孟丽 基础检查2 2017-10-26
    Private Function BaseCheck2(ByRef sMoid As String, ByRef sQty As String) As Boolean
        If String.IsNullOrEmpty(Me.lblShouldPackQty.Text) Then '应装数量不为空（提示其先设置）
            lblMessage.Text = "请先进行基础设置！"
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtPPid.Text) Then
            lblMessage.Text = "外箱编号不能为空！"
            Return False
        End If

        '判断数量及工单信息
        ' Dim sMoid As String = ""
        ' Dim sQty As String = ""
        Dim strSQL2 As String = ""
        Dim n As Integer
        Dim n1 As Integer
        Dim strSQL As String = ""
        Dim isSys As String = ""
        Dim dt2 As DataTable = Nothing
        Dim inTime As String
        Try
            '工单编号,外箱编号,应装数,已装数, 满箱否,操作人员,操作时间
            strSQL = " select Moid ,Qty  from m_SnSBarCode_t where SBarCode = '" + txtPPid.Text + "'"
            strSQL2 = "select Intime from m_Carton_t where moid = '" + lblMOID.Text + "' and Cartonid = '" + txtPPid.Text + "'"
            n = DbOperateUtils.GetRowsCount(strSQL)
            If n > 0 Then
                Dim dt As DataTable = DbOperateUtils.GetDataTable(strSQL)
                sMoid = dt.Rows(0)(0)  '获取工单
                sQty = dt.Rows(0)(1) '获取数量
                ' sQty = dt.Rows(0).Item("Qty")
                n1 = DbOperateUtils.GetRowsCount(strSQL2)
                If n1 > 0 Then
                    inTime = DbOperateUtils.GetDataTable(strSQL2).Rows(0)(0)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try


        If n <= 0 Then
            lblMessage.Text = "此条码不是系统打印条码！"
            Return False
        End If

        'If chkfixbarcode.Checked Then
        '    strSQL += "and Packid='N'"
        '    Dim n3 As Integer = DbOperateUtils.GetRowsCount(strSQL)
        '    If n3 <= 0 Then
        '        lblMessage.Text = "此条码不是固定箱条码！"
        '        Return False
        '    End If
        'End If


        If sMoid <> lblMOID.Text.Trim() Then
            lblMessage.Text = "此条码不是此工单打印条码！"
            Return False
        End If

        '判断是否为固定条码,生成外箱加流水码2017-12-27注释
        'If chkfixbarcode.Checked Then
        '    Dim strSQL3 As String
        '    strSQL3 = " declare @STYLEMAX varchar(10)" &
        '        " declare @CARTONID varchar(50) " &
        '        " declare @CurrentCartonID varchar(50) " &
        '        " set @CARTONID = '{0}' " &
        '        " IF NOT EXISTS(SELECT 1 FROM m_StyleFormat_t WHERE StyleFormat=@CARTONID AND StyleType='C')  " &
        '        " BEGIN " &
        '        " SET @STYLEMAX=10000000 " &
        '        " INSERT INTO m_StyleFormat_t(StyleFormat,StyleType,styleValue)VALUES(@CARTONID, 'C', @STYLEMAX)" &
        '        "         End " &
        '        " UPDATE m_StyleFormat_t SET styleValue=styleValue + 1 WHERE StyleFormat=@CARTONID AND StyleType='C'  " &
        '        " SELECT @CurrentCartonID=ISNULL(StyleFormat+ CONVERT(NVARCHAR(32),styleValue),'') " &
        '        " FROM m_StyleFormat_t WHERE StyleFormat=@CARTONID AND StyleType='C'" &
        '        "SELECT @CurrentCartonID"
        '    strSQL3 = String.Format(strSQL3, txtPPid.Text.Trim)
        '    Dim dt3 As DataTable = DbOperateUtils.GetDataTable(strSQL3)
        '    Me.txtPPid.Text = dt3.Rows(0)(0)
        '    ' lblMessage.Text = "此条码是固定条码"

        'End If

        '流水的箱条码
        If n1 > 0 Then
            lblMessage.Text = txtPPid.Text + "条码" + inTime + "已在系统扫描过"
            txtPPid.Text = ""
            Return False
        End If


        '此次包装数量 != 应装数量  '应装数量：即基础设置中的每箱装箱数
        If sQty <> Data.CartonShouldQty Then
            lblMessage.Text = String.Format("  此外箱条码包装数量是{0}与应装数量{1}不符", sQty, Me.lblShouldPackQty.Text)
            Return False
        End If

        '如果勾选不超过工单数，则要求此次包装数量+已装数量+满箱已包装数量<=工单数量
        If Me.chkMOQty.Checked = True Then
            If sQty + Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) > Val(lblMOLot.Text) Then
                If Val(lblNowPackedQty.Text) + Val(lblFullPackQty.Text) = Val(lblMOLot.Text) Then
                    lblMessage.Text = "该工单已经包装完成"
                    txtPPid.Text = ""
                    txtPPid.Enabled = False
                Else
                    lblMessage.Text = "已经超过工单数, 请检查！"
                End If
                Return False
            End If
        End If
        Return True
    End Function

    '关晓艳魏孟丽 判断厂区是否为立德  若是则check 2017-10-26
    Private Sub IsFactory()
        Dim factory As String
        factory = VbCommClass.VbCommClass.Factory
        If factory = "LX81" Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub
End Class