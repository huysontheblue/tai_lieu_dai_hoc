Imports MainFrame.SysDataHandle
Imports MainFrame.SysCheckData
Imports System.Windows.Forms
Imports RCard
Imports System.Text
Imports MainFrame
Imports System.IO


''' <summary>
''' 修改者： 田玉琳
''' 修改日： 2015/09/09
''' 修改内容：表变更
''' </summary>
''' <remarks>修改流程卡后影响范围</remarks>
''' ---------------------------------------------------------
''' update by hgd 2017-08-24 调整内容：
''' 1.导出资料加入创建人、创建日期
''' 2.调整分页功能，由100笔增加显示5000笔，并显示总笔数，可进行分页
''' 3.调整了下页面对齐
Public Class FrmProcessParametersMaintain

    Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

#Region "变量"

    Private ActionMode As ActionGrid
    'Private sConn As New SysDataBaseClass
    Private drawForce As String = Nothing
    Private cutSize As String = Nothing
    Private peelSize As String = Nothing
    Private brassHeight As String = Nothing
    Private brassWidth As String = Nothing
    Private outDaoHeight As String = Nothing
    Private outDaoWidth As String = Nothing
    Private frontSize As String = Nothing
    Private filePath As String = VbCommClass.VbCommClass.SopFilePath & "\Templates" & "\ProcessParametersTemplate.xlsx"
    '导出模板路径
    'Private expfilePath As String = VbCommClass.VbCommClass.SopFilePath & "\Templates" & "\ProcessParametersExpTemplate.xlsx"

    'add by 马跃平 2018-04-24 何建邦提出要求导入和导出共一个模板
    Private expfilePath As String = VbCommClass.VbCommClass.SopFilePath & "\Templates" & "\加工参数导入导出模板.xlsx"

    'Private filePath As String = Environment.CurrentDirectory & "\Templates" & "\ProcessParametersTemplate.xlsx"
    Private selectedPath As String = Nothing

    '刷选查询
    Private IsDialogQuery As Boolean = False
    Private DialogSqlWhere As String = Nothing
    Public pageData As New SysBasicClass.PageData()

    Private Enum ActionGrid
        Load = 0
        Add
        Modify
        Save
        Undo
        Search
        Query
        Import
        Export
    End Enum

    Private Enum ProcessGrid
        'TVPN '端子料号',TVDes '通用名称', WirePN '线材料号1',WirePNDes '适用线规',WirePN2 '线材料号2',WirePNDes2 '适用线规2',
        'WirePN3 '线材料号3',WirePNDes3 '适用线规3', 
        'WirePN4'线材料号4',WirePNDes4 '适用线规4' ,BrassHeight 
        '内刀压着高度H1',BrassWidth '内刀压着宽度W1',
        '外刀压着高度H2， 外刀压着宽度W2
        '上芯SX、下芯XX、上皮SP、下皮XP
        'DrawForce '拉拔力',
        'peelSize '脱皮尺寸',CutSize '裁线尺寸',FrontSize '前端尺寸'," & _
        'CutPN '刀模', EquPN 工治具料号,InTime '创建时间',UserID '创建人',状态
        Seq = 0
        TVPN
        TVDes
        WirePN
        WirePNDes
        WirePN2
        WirePNDes2
        WirePN3
        WirePNDes3
        WirePN4
        WirePNDes4
        BrassHeight
        BrassWidth
        OutDaoHeight
        OutDaoWidth
        SX
        XX
        SP
        XP
        DrawForce
        PeelSize
        CutSize
        FrontSize
        CutPN  'Cut part Number
        EquPN
        FileName
        FilePath
        InTime
        UserID
        Status
    End Enum

    Private Enum CDGrid
        'Seq = 0
        ID
        FinishMin
        FinishMax
        HWSize
        EmSize
        OtherSize
        CutSizeMin
        Tolerance
        CreateTime
        CreateUser
        Status1
        Status
    End Enum


    Private Enum HWGCGrid
        'Seq = 0
        ID
        ItemName
        RangeMin
        RangeMax
        Tolerance
        CreateTime
        CreateUser
        Status1
        Status
    End Enum

    '导出 BrassHeight,BrassWidth, OutDaoHeight,OutDaoWidth,DrawForce,
    Private Enum ProcessExportGrid
        TVPN
        TVDes
        WirePN
        WirePNDes
        WirePN2
        WirePNDes2
        WirePN3
        WirePNDes3
        WirePN4
        WirePNDes4
        BrassHeight
        BrassWidth
        OutDaoHeight
        OutDaoWidth
        SX
        XX
        SP
        XP
        DrawForce
        PeelSize
        CutSize
        FrontSize
        CutPN
    End Enum

#End Region

#Region "事件"

    Private Sub FrmProcessParametersMaintain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Me.PagerPaging.PagerGrid.DataGrid = Me.dgvProcessParameter
            'Me.PagerPaging.PagerGrid.Sort = "创建时间 DESC"
            'AddHandler Me.dgvProcessParameter.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
            'Me.PagerPaging.PagerGrid.PageSize = 100


            '设定用戶权限
            Dim ERigth As New SysDataBaseClass
            ERigth.GetControlright(Me)
            SetControlStatus(ActionGrid.Load)

            LoadProcessParameters()
            'dgvBind()
            'PagerPaging.LoadData()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "FrmProcessParametersMaintain", "FrmProcessParametersMaintain_Load", "RCard")
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ActionMode = ActionGrid.Add
        SetControlStatus(ActionGrid.Add)
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        ActionMode = ActionGrid.Modify
        SetControlStatus(ActionGrid.Modify)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Not BasicCheck() Then Exit Sub
            If TabControl1.SelectedIndex = 0 Then
                SaveProcessParameter()
            ElseIf TabControl1.SelectedIndex = 1 Then
                SaveCommonDifferenceParameter()
            ElseIf TabControl1.SelectedIndex = 2 Then
                SaveCommonDifferenceParameterHW()
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "RunCard.FrmProcessParametersMaintain", "btnSave_Click", "RCard")
        End Try
    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        ActionMode = ActionGrid.Undo
        SetControlStatus(ActionGrid.Undo)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ActionMode = ActionGrid.Search
        SetControlStatus(ActionGrid.Search)
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            ActionMode = ActionGrid.Query

            LoadProcessParameters()
            Me.IsDialogQuery = False
            Me.DialogSqlWhere = Nothing
            'PagerPaging.LoadData()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "RCard.FrmProcessParametersMaintain", "btnSearch_Click", "RCard")
        End Try
    End Sub


    Private Function dgvBind() As Integer
        'DataGridViewX1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        'DataGridViewX1.ColumnHeadersHeight = 30
        pageData.PageIndex = Pager1.PageCurrent
        pageData.PageSize = Pager1.PageSize
        pageData.RowNumberOrderStr = " a.Intime desc "


        Pager1.bindingSource.DataSource = pageData.QueryDataTable()
        Pager1.bindingNavigator.BindingSource = Pager1.bindingSource
        Pager1.QuerySeconds = pageData.QuerySeconds


        dgvProcessParameter.DataSource = Pager1.bindingSource

        dgvProcessParameter.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvProcessParameter.Columns(0).HeaderText = "序号"
        dgvProcessParameter.Columns(0).Width = 60
        dgvProcessParameter.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvProcessParameter.Columns(ProcessGrid.WirePNDes).Visible = False
        dgvProcessParameter.Columns(ProcessGrid.WirePNDes2).Visible = False
        dgvProcessParameter.Columns(ProcessGrid.WirePNDes3).Visible = False
        dgvProcessParameter.Columns(ProcessGrid.WirePNDes4).Visible = False
        dgvProcessParameter.Columns(ProcessGrid.CutSize).Visible = False
        dgvProcessParameter.Columns(ProcessGrid.Status).Visible = False
        dgvProcessParameter.Columns(ProcessGrid.FilePath).Visible = False
        Return pageData.TotalCount
    End Function

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            ActionMode = ActionGrid.Import
            Using frm As FrmProcessParametersImport = New FrmProcessParametersImport
                If TabControl1.SelectedIndex = 0 Then
                    frm._importType = FrmProcessParametersImport.ImportTypeGrid.ProcessParameters
                ElseIf TabControl1.SelectedIndex = 1 Then
                    frm._importType = FrmProcessParametersImport.ImportTypeGrid.CommonDiff
                End If
                frm.ShowDialog()
            End Using
            '黄广都
            'PagerPaging.LoadData()

            LoadProcessParameters()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "RunCard.FrmProcessParametersMaintain", "btnImport_Click", "sys")
        End Try
    End Sub

    Private Sub dgvProcessParameter_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProcessParameter.CellClick
        Try
            SetControlData()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "RunCard.FrmProcessParametersMaintain", "dgvProcessParameter_CellClick", "sys")
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            FolderBrowserDialog1.Description = "请选择保存文件路径"
            FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
            FolderBrowserDialog1.ShowNewFolderButton = True
            Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
            If result = System.Windows.Forms.DialogResult.OK Then
                Cursor.Current = Cursors.WaitCursor
                selectedPath = FolderBrowserDialog1.SelectedPath
                Cursor.Current = Cursors.Default
                DoExport()
            End If
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "RunCard.FrmProcessParametersMaintain", "btnExport_Click", "sys")
        End Try
    End Sub

    Private Sub dgvCD_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCD.CellClick
        Try
            If dgvCD.Rows.Count <= 0 Then Exit Sub
            Me.lblID.Text = Me.dgvCD.Item(CDGrid.ID, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDFinishSizeMin.Text = Me.dgvCD.Item(CDGrid.FinishMin, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDFinishSizeMax.Text = Me.dgvCD.Item(CDGrid.FinishMax, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDHWFinishStandard.Text = Me.dgvCD.Item(CDGrid.HWSize, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDEmFinishStandard.Text = Me.dgvCD.Item(CDGrid.EmSize, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDOtherFinishStandard.Text = Me.dgvCD.Item(CDGrid.OtherSize, dgvCD.CurrentRow.Index).Value.ToString()
            Me.txtCDCutSize.Text = Me.dgvCD.Item(CDGrid.CutSizeMin, dgvCD.CurrentRow.Index).Value.ToString
            Me.txtToleranceRange.Text = Me.dgvCD.Item(CDGrid.Tolerance, dgvCD.CurrentRow.Index).Value.ToString
            Me.cdCobStatus.SelectedIndex = Me.cdCobStatus.FindString(Me.dgvCD.Item(CDGrid.Status1, dgvCD.CurrentRow.Index).Value.ToString())
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "RunCard.FrmProcessParametersMaintain", "dgvCD_CellClick", "sys")
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If TabControl1.SelectedIndex = 0 Then
                '黄广都
                'PagerPaging.ResetPagerParameters("创建时间 desc", Me.dgvProcessParameter)
                'AddHandler Me.dgvProcessParameter.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
                'RemoveHandler Me.dgvCD.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
            ElseIf TabControl1.SelectedIndex = 1 Then
                '黄广都
                'PagerPaging.ResetPagerParameters("创建时间 desc", Me.dgvCD)
                'RemoveHandler Me.dgvProcessParameter.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
                'AddHandler Me.dgvCD.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
            ElseIf TabControl1.SelectedIndex = 2 Then

                '黄广都
                'add by cq 20170328
                'PagerPaging.ResetPagerParameters("创建时间 desc", Me.dgvHWGC)
                'RemoveHandler Me.dgvHWGC.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
                'AddHandler Me.dgvHWGC.ColumnHeaderMouseClick, AddressOf Me.PagerPaging.OnSortCommand
            End If
            '黄广都
            'PagerPaging.LoadData()
            LoadProcessParameters()
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "RunCard.FrmProcessParametersMaintain", "TabControl1_SelectedIndexChanged", "RCard")
        End Try
    End Sub

#End Region

#Region "方法"



    Private Function BasicCheck() As Boolean
        If TabControl1.SelectedIndex = 0 Then
            Select Case ActionMode
                Case ActionGrid.Add
                    If String.IsNullOrEmpty(txtPnOfTV.Text) Then
                        MessageUtils.ShowError("端子料号不能为空")
                        txtPnOfTV.SelectAll()
                        Return False
                    End If
                    If String.IsNullOrEmpty(txtPnOfLine.Text) Then
                        MessageUtils.ShowError("线材料号不能为空")
                        txtPnOfLine.SelectAll()
                        Return False
                    End If

                    If Not String.IsNullOrEmpty(Me.txtPnOfLineTwo.Text) Then
                        If String.IsNullOrEmpty(Me.txtPnOfLine.Text) Then
                            MessageUtils.ShowError("线材料号1不能为空")
                            txtPnOfLine.SelectAll()
                            Return False
                        End If
                    End If

                    If Not String.IsNullOrEmpty(Me.txtPnOfLineThree.Text) Then
                        If String.IsNullOrEmpty(Me.txtPnOfLineTwo.Text) Then
                            MessageUtils.ShowError("线材料号2不能为空")
                            txtPnOfLineTwo.SelectAll()
                            Return False
                        End If
                    End If

                    If Not String.IsNullOrEmpty(Me.txtPnOfLineFour.Text) Then
                        If String.IsNullOrEmpty(Me.txtPnOfLineThree.Text) Then
                            MessageUtils.ShowError("线材料号3不能为空")
                            txtPnOfLineThree.SelectAll()
                            Return False
                        End If
                    End If

                    If TVAlreadyExists() Then
                        MessageUtils.ShowError(String.Format("端子料号:{0},线材料号1:{1},线材料号2:{2},线材料号3:{3},线材料号4:{4}已经存在！",
                                                             txtPnOfTV.Text, txtPnOfLine.Text, txtPnOfLineTwo.Text,
                                                             txtPnOfLineThree.Text, txtPnOfLineFour.Text))
                        Return False
                    End If
                    If cboStatus.SelectedIndex = 1 Then
                        MessageUtils.ShowError("新增时状态只能选择有效！")
                        Return False
                    End If
                    'Add check EquPN whether is exist m_PartContrast_t, cq20151230
                    If Not String.IsNullOrEmpty(Me.txtEquPN.Text.Trim) Then
                        If Not IsEquPN(Me.txtEquPN.Text.Trim) Then
                            MessageUtils.ShowError("输入的工治具料号不存在，请检查！")
                            Return False
                        End If
                    End If
                Case ActionGrid.Modify
                    If Not String.IsNullOrEmpty(Me.txtEquPN.Text.Trim) Then
                        If Not IsEquPN(Me.txtEquPN.Text.Trim) Then
                            MessageUtils.ShowError("输入的工治具料号不存在，请检查！")
                            Return False
                        End If
                    End If
                Case Else
                    'do nothing 
            End Select
            Return True
        ElseIf TabControl1.SelectedIndex = 1 Then
            If String.IsNullOrEmpty(txtCDFinishSizeMin.Text) Then
                MessageUtils.ShowError("请输入成品尺寸最小值")
                txtCDFinishSizeMin.SelectAll()
                Return False
            End If
            If String.IsNullOrEmpty(txtCDFinishSizeMin.Text) AndAlso String.IsNullOrEmpty(txtCDFinishSizeMax.Text) Then
                MessageUtils.ShowError("请输入成品尺寸最大值")
                txtCDFinishSizeMax.SelectAll()
                Return False
            End If
            If String.IsNullOrEmpty(txtCDCutSize.Text) Then
                MessageUtils.ShowError("请输入裁线下公差")
                txtCDCutSize.SelectAll()
                Return False
            End If
            If cdCobStatus.SelectedIndex = -1 Then
                MessageUtils.ShowError("请选择状态")
                Return False
            End If
            Return True
        End If
        Return True
    End Function



    Private Function IsEquPN(ByVal parEquPN As String) As Boolean
        Dim lsSQL As String = String.Empty
        IsEquPN = False
        lsSQL = " SELECT TAvcPart FROM m_PartContrast_t  WHERE TAvcPart='" & parEquPN & "' "
        If DbOperateUtils.GetRowsCount(lsSQL) > 0 Then Return True
    End Function

    Private Sub SetControlStatus(ByVal _actionType As ActionGrid)
        If btnNew.Tag Is Nothing Then btnNew.Tag = "NO"
        If btnModify.Tag Is Nothing Then btnModify.Tag = "NO"
        If btnImport.Tag Is Nothing Then btnImport.Tag = "NO"

        Select Case _actionType
            Case ActionGrid.Load
                btnNew.Enabled = IIf(btnNew.Tag.ToString = "YES", True, False)
                btnModify.Enabled = IIf(btnModify.Tag.ToString = "YES", True, False)
                btnSearch.Enabled = True
                btnRefresh.Enabled = False
                btnExport.Enabled = True
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                btnSave.Enabled = False
                btnUndo.Enabled = True
                SetTextBoxStatus(ActionGrid.Load)
            Case ActionGrid.Undo
                btnNew.Enabled = IIf(btnNew.Tag.ToString = "YES", True, False)
                btnModify.Enabled = IIf(btnModify.Tag.ToString = "YES", True, False)
                btnSearch.Enabled = True
                btnRefresh.Enabled = False
                btnExport.Enabled = True
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                btnSave.Enabled = False
                SetTextBoxStatus(ActionGrid.Undo)
            Case ActionGrid.Add
                btnModify.Enabled = False
                btnSave.Enabled = True
                btnSearch.Enabled = False
                btnRefresh.Enabled = False
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                btnExport.Enabled = True
                SetTextBoxStatus(ActionGrid.Add)
            Case ActionGrid.Modify
                btnNew.Enabled = False
                btnSave.Enabled = True
                btnSearch.Enabled = False
                btnRefresh.Enabled = False
                btnExport.Enabled = True
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                SetTextBoxStatus(ActionGrid.Modify)
            Case ActionGrid.Search
                btnNew.Enabled = False
                btnModify.Enabled = False
                btnSave.Enabled = False
                btnRefresh.Enabled = True
                btnExport.Enabled = True
                btnImport.Enabled = IIf(btnImport.Tag.ToString = "YES", True, False)
                SetTextBoxStatus(ActionGrid.Search)
        End Select
    End Sub

    Private Sub SetTextBoxStatus(ByVal _actionType As ActionGrid)
        If TabControl1.SelectedIndex = 0 Then
            Select Case _actionType
                Case ActionGrid.Load, ActionGrid.Undo
                    txtPnOfTV.Enabled = False
                    txtTvName.Enabled = False
                    txtPnOfLine.Enabled = False
                    txtLineDesc.Enabled = False
                    Me.txtPnOfLineTwo.Enabled = False
                    Me.txtLineDesc2.Enabled = False
                    Me.txtPnOfLineThree.Enabled = False
                    Me.txtLineDesc3.Enabled = False
                    Me.txtPnOfLineFour.Enabled = False
                    Me.txtLineDesc4.Enabled = False
                    txtDrawForce.Enabled = False
                    txtSizeOfCut.Enabled = False
                    txtWireHeight.Enabled = False
                    txtWireWidth.Enabled = False
                    txtCutSize.Enabled = False
                    txtFrontSize.Enabled = False
                    Me.txtPnOfCut.Enabled = False
                    Me.txtEquPN.Enabled = False 'Add by CQ 20151231
                    Me.txtOutDaoHeight.Enabled = False
                    Me.txtOutDaoWidth.Enabled = False ''Add by CQ 20170112
                    Me.txtSX.Enabled = False
                    Me.txtXX.Enabled = False
                    Me.txtSP.Enabled = False
                    Me.txtXP.Enabled = False 'Add by cq 20170523
                    txtPnOfTV.Text = "" : txtTvName.Text = ""
                    txtPnOfLine.Text = "" : txtLineDesc.Text = ""
                    txtDrawForce.Text = ""
                    txtSizeOfCut.Text = ""
                    txtWireHeight.Text = ""
                    txtWireWidth.Text = ""
                    txtCutSize.Text = ""
                    txtFrontSize.Text = ""
                    txtPnOfCut.Text = "" : txtPnOfLineTwo.Text = ""
                    txtPnOfLineThree.Text = ""
                    txtPnOfLineFour.Text = ""
                    txtLineDesc2.Text = ""
                    txtLineDesc3.Text = ""
                    txtLineDesc4.Text = ""
                Case ActionGrid.Add, ActionGrid.Search
                    txtPnOfTV.Enabled = True
                    txtTvName.Enabled = True
                    txtPnOfLine.Enabled = True
                    txtLineDesc.Enabled = True
                    Me.txtPnOfLineTwo.Enabled = True
                    Me.txtLineDesc2.Enabled = True
                    Me.txtPnOfLineThree.Enabled = True
                    Me.txtLineDesc3.Enabled = True
                    Me.txtPnOfLineFour.Enabled = True
                    Me.txtLineDesc4.Enabled = True
                    Me.txtPnOfCut.Enabled = True
                    txtDrawForce.Enabled = True
                    txtSizeOfCut.Enabled = True
                    txtWireHeight.Enabled = True
                    txtWireWidth.Enabled = True
                    Me.txtCutSize.Enabled = True
                    txtFrontSize.Enabled = True
                    Me.txtEquPN.Enabled = True 'cq 20151231
                    Me.txtOutDaoHeight.Enabled = True
                    Me.txtOutDaoWidth.Enabled = True ''Add by CQ 20170417
                    Me.txtSX.Enabled = True : Me.txtXX.Enabled = True : Me.txtSP.Enabled = True : Me.txtXP.Enabled = True 'Add by cq 20170523
                    txtPnOfTV.Text = ""
                    txtTvName.Text = ""
                    txtPnOfLine.Text = ""
                    txtLineDesc.Text = ""
                    txtDrawForce.Text = ""
                    txtSizeOfCut.Text = ""
                    txtWireHeight.Text = ""
                    txtWireWidth.Text = ""
                    txtCutSize.Text = ""
                    txtFrontSize.Text = ""
                    txtPnOfCut.Text = ""
                    txtPnOfLineTwo.Text = ""
                    txtPnOfLineThree.Text = ""
                    txtPnOfLineFour.Text = ""
                    txtLineDesc2.Text = "" : txtLineDesc3.Text = "" : txtLineDesc4.Text = ""
                    txtOutDaoHeight.Text = "" : txtOutDaoWidth.Text = ""  'add by cq20170817
                    cboStatus.SelectedIndex = 0
                    txtSX.Text = ""
                    txtXX.Text = ""
                    txtSP.Text = ""
                    txtXP.Text = ""
                Case ActionGrid.Modify
                    txtPnOfTV.Enabled = False
                    txtTvName.Enabled = True
                    txtPnOfLine.Enabled = False
                    txtLineDesc.Enabled = True
                    Me.txtPnOfLineTwo.Enabled = False
                    Me.txtLineDesc2.Enabled = True
                    Me.txtPnOfLineThree.Enabled = False
                    Me.txtLineDesc3.Enabled = True
                    Me.txtPnOfLineFour.Enabled = False
                    Me.txtLineDesc4.Enabled = True
                    txtDrawForce.Enabled = True
                    txtSizeOfCut.Enabled = True
                    txtWireHeight.Enabled = True
                    txtWireWidth.Enabled = True
                    txtCutSize.Enabled = True
                    txtFrontSize.Enabled = True
                    Me.txtPnOfCut.Enabled = True
                    Me.txtEquPN.Enabled = True 'cq 20151231
                    Me.txtOutDaoHeight.Enabled = True
                    Me.txtOutDaoWidth.Enabled = True ''Add by CQ 20170112
                    Me.txtSX.Enabled = True : Me.txtXX.Enabled = True : Me.txtSP.Enabled = True : Me.txtXP.Enabled = True  'Add by cq 20170523
            End Select
        ElseIf TabControl1.SelectedIndex = 1 Then
            Select Case _actionType
                Case ActionGrid.Load, ActionGrid.Undo
                    txtCDCutSize.Enabled = False
                    txtCDEmFinishStandard.Enabled = False
                    txtCDFinishSizeMax.Enabled = False
                    txtCDFinishSizeMin.Enabled = False
                    txtCDHWFinishStandard.Enabled = False
                    txtCDOtherFinishStandard.Enabled = False
                    txtCDCutSize.Text = ""
                    txtCDEmFinishStandard.Text = ""
                    txtCDFinishSizeMax.Text = ""
                    txtCDFinishSizeMin.Text = ""
                    txtCDHWFinishStandard.Text = ""
                    txtCDOtherFinishStandard.Text = ""
                    txtToleranceRange.Text = ""
                Case ActionGrid.Add, ActionGrid.Search
                    txtCDCutSize.Enabled = True
                    txtCDEmFinishStandard.Enabled = True
                    txtCDFinishSizeMax.Enabled = True
                    txtCDFinishSizeMin.Enabled = True
                    txtCDHWFinishStandard.Enabled = True
                    txtCDOtherFinishStandard.Enabled = True
                    txtCDCutSize.Text = ""
                    txtCDEmFinishStandard.Text = ""
                    txtCDFinishSizeMax.Text = ""
                    txtCDFinishSizeMin.Text = ""
                    txtCDHWFinishStandard.Text = ""
                    txtCDOtherFinishStandard.Text = ""
                    txtToleranceRange.Text = ""
                Case ActionGrid.Modify
                    txtCDCutSize.Enabled = True
                    txtCDEmFinishStandard.Enabled = True
                    txtCDFinishSizeMax.Enabled = True
                    txtCDFinishSizeMin.Enabled = True
                    txtCDHWFinishStandard.Enabled = True
                    txtCDOtherFinishStandard.Enabled = True
                    txtToleranceRange.Enabled = True

            End Select
        ElseIf TabControl1.SelectedIndex = 2 Then
            Select Case _actionType
                Case ActionGrid.Load, ActionGrid.Undo
                    txtItemName.Enabled = False
                    txtRangeMin.Enabled = False
                    txtRangeMax.Enabled = False
                    txtGCRange.Enabled = False

                    txtItemName.Text = ""
                    txtRangeMin.Text = ""
                    txtRangeMax.Text = ""
                    txtGCRange.Text = ""


                Case ActionGrid.Add, ActionGrid.Search
                    txtItemName.Enabled = True
                    txtRangeMin.Enabled = True
                    txtRangeMax.Enabled = True
                    txtGCRange.Enabled = True

                    txtItemName.Text = ""
                    txtRangeMin.Text = ""
                    txtRangeMax.Text = ""
                    txtGCRange.Text = ""
                Case ActionGrid.Modify
                    txtItemName.Enabled = True
                    txtRangeMin.Enabled = True
                    txtRangeMax.Enabled = True
                    txtGCRange.Enabled = True

            End Select
        End If
    End Sub

    Private Sub LoadProcessParameters()
        Dim sql As String = Nothing
        sql = GetSql()
        If ActionMode = ActionGrid.Query Then
            sql += GetWhereSql()
        End If

        'Add by cq20170817
        If TabControl1.SelectedIndex = 0 Then
            'sql += " ORDER BY a.InTime DESC"
        End If

        If TabControl1.SelectedIndex = 0 Then
            pageData.QuerySQL = sql
            Pager1.PageCount = 1
            Pager1.Bind()
            Pager1.Enabled = True
            dgvBind()
        Else
            LoadData(sql)
        End If

    End Sub

    Private Sub LoadData(ByVal sql As String)
        Dim sConn As New SysDataBaseClass
        Dim dt As DataTable = DbOperateUtils.GetDataTable(sql)
        'Dim dt As DataTable = PagerPaging.GetPagingDataTable(sql, sConn.GetConnectionString(), True)
        If TabControl1.SelectedIndex = 0 Then
            'dgvProcessParameter.DataSource = dt
            '黄广都
            'dgvProcessParameter.Columns(ProcessGrid.Status).Visible = False
            'dgvProcessParameter.Columns(ProcessGrid.Seq).HeaderText = "序号"
            'For Each col As DataGridViewColumn In dgvProcessParameter.Columns
            '    col.SortMode = DataGridViewColumnSortMode.Programmatic
            'Next
            'dgvProcessParameter.Columns(ProcessGrid.Seq).SortMode = DataGridViewColumnSortMode.NotSortable
            'dgvProcessParameter.Columns(ProcessGrid.Seq).Width = 40
            'dgvProcessParameter.Columns(ProcessGrid.InTime).Width = 60
            '' dgvProcessParameter.Columns(ProcessGrid.Status2).Width = 60
            'dgvProcessParameter.Columns(ProcessGrid.UserID).Width = 80
            'dgvProcessParameter.Columns(ProcessGrid.PeelSize).Width = 80
            'dgvProcessParameter.Columns(ProcessGrid.DrawForce).Width = 80
            'dgvProcessParameter.Columns(ProcessGrid.WirePNDes).Visible = False
            'dgvProcessParameter.Columns(ProcessGrid.WirePNDes2).Visible = False
            'dgvProcessParameter.Columns(ProcessGrid.WirePNDes3).Visible = False
            'dgvProcessParameter.Columns(ProcessGrid.WirePNDes4).Visible = False
            'dgvProcessParameter.Columns(ProcessGrid.CutSize).Visible = False
        ElseIf TabControl1.SelectedIndex = 1 Then
            dgvCD.DataSource = dt
            dgvCD.Columns(CDGrid.Status1).Visible = False
            dgvCD.Columns(CDGrid.ID).Visible = False
            'dgvCD.Columns(CDGrid.Seq).HeaderText = "序号"
            'For Each col As DataGridViewColumn In dgvCD.Columns
            '    col.SortMode = DataGridViewColumnSortMode.Programmatic
            'Next
            'dgvCD.Columns(CDGrid.Seq).SortMode = DataGridViewColumnSortMode.NotSortable
            'dgvCD.Columns(CDGrid.Seq).Width = 40
            Me.toolStripAllowanceParam.Text = "记录笔数：" + dt.Rows.Count.ToString
        ElseIf TabControl1.SelectedIndex = 2 Then
            dgvHWGC.DataSource = dt
            dgvHWGC.Columns(HWGCGrid.Status1).Visible = False
            dgvHWGC.Columns(HWGCGrid.ID).Visible = False
            'dgvHWGC.Columns(HWGCGrid.Seq).HeaderText = "序号"
            'For Each col As DataGridViewColumn In dgvHWGC.Columns
            '    col.SortMode = DataGridViewColumnSortMode.Programmatic
            'Next
            'dgvHWGC.Columns(HWGCGrid.Seq).SortMode = DataGridViewColumnSortMode.NotSortable
            'dgvHWGC.Columns(HWGCGrid.Seq).Width = 40
            Me.toolStripAllowanceParamHW.Text = "记录笔数：" + dt.Rows.Count.ToString
        End If
    End Sub

    Private Sub SetControlData()
        If Me.dgvProcessParameter.RowCount < 1 Then Exit Sub
        With Me.dgvProcessParameter
            'TVPN '端子料号',TVDes '通用名称', WirePN '线材料号1',WirePNDes '适用线规',WirePN2 '线材料号2',WirePNDes2 '适用线规2',
            'WirePN3 '线材料号3',WirePNDes3 '适用线规3', 
            'WirePN4'线材料号4',WirePNDes4 '适用线规4' ,
            'brassHeight '内刀压着高度H1',BrassWidth '内刀压着宽度W1',
            'drawForce '拉拔力',
            'peelSize '脱皮尺寸',CutSize '裁线尺寸',FrontSize '前端尺寸'," & _
            'CutPN '刀模', EquPN 工治具料号,InTime '创建时间',UserID '创建人',状态
            Me.txtPnOfTV.Text = .Item(ProcessGrid.TVPN, .CurrentRow.Index).Value.ToString()
            Me.txtTvName.Text = .Item(ProcessGrid.TVDes, .CurrentRow.Index).Value.ToString()
            Me.txtPnOfLine.Text = .Item(ProcessGrid.WirePN, .CurrentRow.Index).Value.ToString()
            Me.txtLineDesc.Text = .Item(ProcessGrid.WirePNDes, .CurrentRow.Index).Value.ToString()
            Me.txtPnOfLineTwo.Text = .Item(ProcessGrid.WirePN2, .CurrentRow.Index).Value.ToString()
            Me.txtLineDesc2.Text = .Item(ProcessGrid.WirePNDes2, .CurrentRow.Index).Value.ToString()
            Me.txtPnOfLineThree.Text = .Item(ProcessGrid.WirePN3, .CurrentRow.Index).Value.ToString()
            Me.txtLineDesc3.Text = .Item(ProcessGrid.WirePNDes3, .CurrentRow.Index).Value.ToString()
            Me.txtPnOfLineFour.Text = .Item(ProcessGrid.WirePN4, .CurrentRow.Index).Value.ToString()
            Me.txtLineDesc4.Text = .Item(ProcessGrid.WirePNDes4, .CurrentRow.Index).Value.ToString()
            Me.txtDrawForce.Text = .Item(ProcessGrid.DrawForce, .CurrentRow.Index).Value.ToString()
            Me.txtCutSize.Text = .Item(ProcessGrid.CutSize, .CurrentRow.Index).Value.ToString
            Me.txtSizeOfCut.Text = .Item(ProcessGrid.PeelSize, .CurrentRow.Index).Value.ToString()
            Me.cboStatus.SelectedIndex = Me.cboStatus.FindString(.Item(ProcessGrid.Status, .CurrentRow.Index).Value.ToString())
            Me.txtWireHeight.Text = .Item(ProcessGrid.BrassHeight, .CurrentRow.Index).Value.ToString
            Me.txtWireWidth.Text = .Item(ProcessGrid.BrassWidth, .CurrentRow.Index).Value.ToString

            Me.txtOutDaoHeight.Text = .Item(ProcessGrid.OutDaoHeight, .CurrentRow.Index).Value.ToString 'cq 20170112
            Me.txtOutDaoWidth.Text = .Item(ProcessGrid.OutDaoWidth, .CurrentRow.Index).Value.ToString

            Me.txtSX.Text = .Item(ProcessGrid.SX, .CurrentRow.Index).Value.ToString
            Me.txtXX.Text = .Item(ProcessGrid.XX, .CurrentRow.Index).Value.ToString
            Me.txtSP.Text = .Item(ProcessGrid.SP, .CurrentRow.Index).Value.ToString
            Me.txtXP.Text = .Item(ProcessGrid.XP, .CurrentRow.Index).Value.ToString 'cq 20170523

            Me.txtFrontSize.Text = .Item(ProcessGrid.FrontSize, .CurrentRow.Index).Value.ToString()
            Me.txtPnOfCut.Text = .Item(ProcessGrid.CutPN, .CurrentRow.Index).Value.ToString()
            Me.txtEquPN.Text = .Item(ProcessGrid.EquPN, .CurrentRow.Index).Value.ToString()
            LinkFileName.Text = .Item(ProcessGrid.FileName, .CurrentRow.Index).Value.ToString
            LinkPath.Text = .Item(ProcessGrid.FilePath, .CurrentRow.Index).Value.ToString
        End With
        drawForce = txtDrawForce.Text
        cutSize = txtCutSize.Text
        peelSize = txtSizeOfCut.Text
        brassHeight = txtWireHeight.Text
        brassWidth = txtWireWidth.Text
        outDaoHeight = txtOutDaoHeight.Text
        outDaoWidth = txtOutDaoWidth.Text
        frontSize = txtFrontSize.Text

    End Sub

    Public Sub DoExport()
        Dim errorMsg As String = Nothing
        Dim outputFile As String = selectedPath & "\" & "加工工艺参数" & Date.Now.ToString("yyyyMMddhh24missfff") & ".xlsx"
        Try
            ActionMode = ActionGrid.Export
            Using dt As DataTable = DbOperateUtils.GetDataTable(GetExportSql)
                If dt.Rows.Count > 0 Then
                    dt.TableName = "Process"
                    If SysDataBaseClass.Import2ExcelByAs(expfilePath, outputFile, dt, GetVariables(dt), errorMsg) Then
                        MessageUtils.ShowInformation("导出成功,请查看！")
                    Else
                        MessageUtils.ShowError(errorMsg)
                    End If
                Else
                    MessageUtils.ShowInformation("无资料供导出！")
                End If
            End Using
        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
        End Try
    End Sub

    Private Function GetVariables(ByVal dt As DataTable) As System.Collections.Generic.Dictionary(Of String, String)
        Dim dics As New System.Collections.Generic.Dictionary(Of String, String)
        If dt.Rows.Count > 0 Then
            dics.Add(ProcessExportGrid.TVPN.ToString, dt.Rows(0)(ProcessExportGrid.TVPN).ToString)
            dics.Add(ProcessExportGrid.TVDes.ToString, dt.Rows(0)(ProcessExportGrid.TVDes).ToString)
            dics.Add(ProcessExportGrid.WirePN.ToString, dt.Rows(0)(ProcessExportGrid.WirePN).ToString)
            dics.Add(ProcessExportGrid.WirePNDes.ToString, dt.Rows(0)(ProcessExportGrid.WirePNDes).ToString)
            dics.Add(ProcessExportGrid.WirePN2.ToString, dt.Rows(0)(ProcessExportGrid.WirePN2).ToString)
            dics.Add(ProcessExportGrid.WirePNDes2.ToString, dt.Rows(0)(ProcessExportGrid.WirePNDes2).ToString)
            dics.Add(ProcessExportGrid.WirePN3.ToString, dt.Rows(0)(ProcessExportGrid.WirePN3).ToString)
            dics.Add(ProcessExportGrid.WirePNDes3.ToString, dt.Rows(0)(ProcessExportGrid.WirePNDes3).ToString)
            dics.Add(ProcessExportGrid.WirePN4.ToString, dt.Rows(0)(ProcessExportGrid.WirePN4).ToString)
            dics.Add(ProcessExportGrid.WirePNDes4.ToString, dt.Rows(0)(ProcessExportGrid.WirePNDes4).ToString)
            dics.Add(ProcessExportGrid.BrassHeight.ToString, dt.Rows(0)(ProcessExportGrid.BrassHeight).ToString)
            dics.Add(ProcessExportGrid.BrassWidth.ToString, dt.Rows(0)(ProcessExportGrid.BrassWidth).ToString)
            'add by cq20170522
            dics.Add(ProcessExportGrid.OutDaoHeight.ToString, dt.Rows(0)(ProcessExportGrid.OutDaoHeight).ToString)
            dics.Add(ProcessExportGrid.OutDaoWidth.ToString, dt.Rows(0)(ProcessExportGrid.OutDaoWidth).ToString)

            'add by cq20170531
            dics.Add(ProcessExportGrid.SX.ToString, dt.Rows(0)(ProcessExportGrid.SX).ToString)
            dics.Add(ProcessExportGrid.XX.ToString, dt.Rows(0)(ProcessExportGrid.XX).ToString)
            dics.Add(ProcessExportGrid.SP.ToString, dt.Rows(0)(ProcessExportGrid.SP).ToString)
            dics.Add(ProcessExportGrid.XP.ToString, dt.Rows(0)(ProcessExportGrid.XP).ToString)

            dics.Add(ProcessExportGrid.DrawForce.ToString, dt.Rows(0)(ProcessExportGrid.DrawForce).ToString)
            dics.Add(ProcessExportGrid.PeelSize.ToString, dt.Rows(0)(ProcessExportGrid.PeelSize).ToString)
            dics.Add(ProcessExportGrid.FrontSize.ToString, dt.Rows(0)(ProcessExportGrid.FrontSize).ToString)
            dics.Add(ProcessExportGrid.CutSize.ToString, dt.Rows(0)(ProcessExportGrid.CutSize).ToString)
            dics.Add(ProcessExportGrid.CutPN.ToString, dt.Rows(0)(ProcessExportGrid.CutPN).ToString)
        End If
        Return dics
    End Function

    Private Function GetWhereSql() As String
        Dim sql As New System.Text.StringBuilder()
        If TabControl1.SelectedIndex = 0 Then
            If Not String.IsNullOrEmpty(txtPnOfTV.Text) Then
                sql.Append("AND  TVPN  LIKE N'%" & txtPnOfTV.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtTvName.Text) Then
                sql.Append("AND  TVDes LIKE N'%" & txtTvName.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql.Append("AND  WirePN LIKE N'%" & txtPnOfLine.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtLineDesc.Text) Then
                sql.Append("AND  WirePNDes LIKE N'%" & txtLineDesc.Text.Trim & "%'").Append(vbNewLine)
            End If
            'Add by CQ 20150603
            If Not String.IsNullOrEmpty(Me.txtPnOfLineTwo.Text) Then
                sql.Append("AND  WirePN2 LIKE N'%" & txtPnOfLineTwo.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtPnOfLineThree.Text) Then
                sql.Append("AND  WirePN3 LIKE N'LIKE" & txtPnOfLineThree.Text.Trim & "LIKE'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtPnOfLineFour.Text) Then
                sql.Append("AND WirePN4 LIKE N'%" & txtPnOfLineFour.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtLineDesc2.Text) Then
                sql.Append("AND WirePNDes2 LIKE N'%" & txtLineDesc2.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtLineDesc3.Text) Then
                sql.Append("AND WirePNDes3 LIKE N'%" & txtLineDesc3.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(Me.txtLineDesc4.Text) Then
                sql.Append("AND WirePNDes4 LIKE N'%" & txtLineDesc4.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(txtWireHeight.Text) Then
                sql.Append("AND  BrassHeight LIKE N'%" & txtWireHeight.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtWireWidth.Text) Then
                sql.Append("AND  BrassWidth LIKE N'%" & txtWireWidth.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtDrawForce.Text) Then
                sql.Append("AND  DrawForce LIKE N'%" & txtDrawForce.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtSizeOfCut.Text) Then
                sql.Append("AND  PeelSize LIKE N'%" & txtSizeOfCut.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtCutSize.Text) Then
                sql.Append("AND  CutSize LIKE N'%" & txtCutSize.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtFrontSize.Text) Then
                sql.Append("AND  FrontSize LIKE N'%" & txtFrontSize.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(txtPnOfCut.Text) Then
                sql.Append("AND  CutPN LIKE N'%" & txtPnOfCut.Text.Trim & "%'").Append(vbNewLine)
            End If
            If cboStatus.SelectedIndex <> -1 Then
                sql.Append(" AND Status='" & cboStatus.SelectedItem.ToString.Substring(0, 1) & "'")
            End If

            If Not String.IsNullOrEmpty(txtEquPN.Text) Then 'cq 20151231
                sql.Append(" AND EquPN LIKE '%" & txtEquPN.Text.Trim & "%'")
            End If

            If sql.Length > 0 Then Return sql.ToString
        ElseIf TabControl1.SelectedIndex = 1 Then
            If Not String.IsNullOrEmpty(txtCDFinishSizeMin.Text) Then
                sql.Append("AND FinishSizeRangeMin LIKE N'%" & txtCDFinishSizeMin.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDFinishSizeMax.Text) Then
                sql.Append("AND FinishSizeRangeMax LIKE N'%" & txtCDFinishSizeMax.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDHWFinishStandard.Text) Then
                sql.Append("AND HWStandardSize LIKE N'%" & txtCDHWFinishStandard.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDEmFinishStandard.Text) Then
                sql.Append("AND EmersonStandardSize LIKE N'%" & txtCDEmFinishStandard.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDOtherFinishStandard.Text) Then
                sql.Append("AND OtherStandardSize LIKE N'%" & txtCDOtherFinishStandard.Text & "%'")
            End If
            If Not String.IsNullOrEmpty(txtCDCutSize.Text) Then
                sql.Append("AND CutSizeMin LIKE N'%" & txtCDCutSize.Text & "%'")
            End If

            If Not String.IsNullOrEmpty(txtToleranceRange.Text) Then
                sql.Append("AND ToleranceRange LIKE N'%" & txtToleranceRange.Text & "%'")
            End If

            If cdCobStatus.SelectedIndex <> -1 Then
                sql.Append("AND Status='" & cdCobStatus.SelectedItem.ToString.Substring(0, 1) & "'")
            End If
            If sql.Length > 0 Then Return sql.ToString
        End If
        Return Nothing
    End Function

    Private Function GetPns()
        Dim pns As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            pns &= "'" & txtPnOfLine.Text & "'" & ","
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            pns &= "'" & txtPnOfLineTwo.Text & "'" & ","
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            pns &= "'" & txtPnOfLineThree.Text & "'" & ","
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            pns &= "'" & txtPnOfLineFour.Text & "'" & ","
        End If
        Return pns.Trim(",")
    End Function

    Private Function GetLeftSqlWhere()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            'sql &= " AND ( LeftWirePN1='" & txtPnOfLine.Text & "'"
            'sql &= " OR LeftWirePN2='" & txtPnOfLine.Text & "'"
            'sql &= " OR LeftWirePN3='" & txtPnOfLine.Text & "'"
            'sql &= " OR LeftWirePN4='" & txtPnOfLine.Text & "')"
            'Modify by cq20170724
            sql &= " AND (LeftWirePN1='" & txtPnOfLine.Text & "')"
        Else
            sql &= " AND LeftWirePN1 IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( LeftWirePN1='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR LeftWirePN2='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR LeftWirePN3='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR LeftWirePN4='" & txtPnOfLineTwo.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND LeftWirePN2 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND LeftWirePN2 IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( LeftWirePN1='" & txtPnOfLineThree.Text & "'"
            sql &= " OR LeftWirePN2='" & txtPnOfLineThree.Text & "'"
            sql &= " OR LeftWirePN3='" & txtPnOfLineThree.Text & "'"
            sql &= " OR LeftWirePN4='" & txtPnOfLineThree.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND LeftWirePN3 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND LeftWirePN3 IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( LeftWirePN1='" & txtPnOfLineFour.Text & "'"
            sql &= " OR LeftWirePN2='" & txtPnOfLineFour.Text & "'"
            sql &= " OR LeftWirePN3='" & txtPnOfLineFour.Text & "'"
            sql &= " OR LeftWirePN4='" & txtPnOfLineFour.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND LeftWirePN4 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND LeftWirePN4 IS NULL "
        End If
        Return sql
    End Function

    Private Function GetRightSqlWhere()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            'Modify by cq20170724
            'sql &= " AND ( RightWirePN1='" & txtPnOfLine.Text & "'"
            'sql &= " OR RightWirePN2='" & txtPnOfLine.Text & "'"
            'sql &= " OR RightWirePN3='" & txtPnOfLine.Text & "'"
            'sql &= " OR RightWirePN4='" & txtPnOfLine.Text & "')"
            sql &= " AND ( RightWirePN1='" & txtPnOfLine.Text & "')"
        Else
            sql &= " AND RightWirePN1 IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( RightWirePN1='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR RightWirePN2='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR RightWirePN3='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR RightWirePN4='" & txtPnOfLineTwo.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND RightWirePN2 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND RightWirePN2 IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( RightWirePN1='" & txtPnOfLineThree.Text & "'"
            sql &= " OR RightWirePN2='" & txtPnOfLineThree.Text & "'"
            sql &= " OR RightWirePN3='" & txtPnOfLineThree.Text & "'"
            sql &= " OR RightWirePN4='" & txtPnOfLineThree.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND RightWirePN3 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND RightWirePN3 IS NULL "
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( RightWirePN1='" & txtPnOfLineFour.Text & "'"
            sql &= " OR RightWirePN2='" & txtPnOfLineFour.Text & "'"
            sql &= " OR RightWirePN3='" & txtPnOfLineFour.Text & "'"
            sql &= " OR RightWirePN4='" & txtPnOfLineFour.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND RightWirePN4 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND RightWirePN4 IS NULL "
        End If
        Return sql
    End Function

    Private Function GetLeftSqlWhereByWirePartNumber()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( A.LeftWirePN1=B.WirePN "
            sql &= " OR A.LeftWirePN2=B.WirePN"
            sql &= " OR A.LeftWirePN3=B.WirePN "
            sql &= " OR A.LeftWirePN4=B.WirePN )"
        Else
            sql &= " AND A.LeftWirePN1 IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( A.LeftWirePN1=B.WirePN2"
            sql &= " OR A.LeftWirePN2=B.WirePN2"
            sql &= " OR A.LeftWirePN3=B.WirePN2"
            sql &= " OR A.LeftWirePN4=B.WirePN2)"
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND A.LeftWirePN2 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND A.LeftWirePN2 IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( A.LeftWirePN1=B.WirePN3"
            sql &= " OR A.LeftWirePN2=B.WirePN3"
            sql &= " OR A.LeftWirePN3=B.WirePN3"
            sql &= " OR A.LeftWirePN4=B.WirePN3)"
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND A.LeftWirePN3 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND A.LeftWirePN3 IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( A.LeftWirePN1=B.WirePN4"
            sql &= " OR A.LeftWirePN2=B.WirePN4"
            sql &= " OR A.LeftWirePN3=B.WirePN4"
            sql &= " OR A.LeftWirePN4=B.WirePN4)"
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND A.LeftWirePN4 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND A.LeftWirePN4 IS NULL"
        End If
        Return sql

    End Function

    Private Function GetRightSqlWhereByWirePartNumber()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( A.RightWirePN1=C.WirePN "
            sql &= " OR A.RightWirePN2=C.WirePN"
            sql &= " OR A.RightWirePN3=C.WirePN "
            sql &= " OR A.RightWirePN4=C.WirePN )"
        Else
            sql &= "  AND A.RightWirePN1 IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( A.RightWirePN1=C.WirePN2"
            sql &= " OR A.RightWirePN2=C.WirePN2"
            sql &= " OR A.RightWirePN3=C.WirePN2"
            sql &= " OR A.RightWirePN4=C.WirePN2)"
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND A.RightWirePN2 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND A.RightWirePN2 IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( A.RightWirePN1=C.WirePN3"
            sql &= " OR A.RightWirePN2=C.WirePN3"
            sql &= " OR A.RightWirePN3=C.WirePN3"
            sql &= " OR A.RightWirePN4=C.WirePN3)"
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND A.RightWirePN3 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND A.RightWirePN3 IS NULL"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( A.RightWirePN1=C.WirePN4"
            sql &= " OR A.RightWirePN2=C.WirePN4"
            sql &= " OR A.RightWirePN3=C.WirePN4"
            sql &= " OR A.RightWirePN4=C.WirePN4)"
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND A.RightWirePN4 IN(" & GetPns() & ")"
            End If
        Else
            sql &= " AND A.RightWirePN4 IS NULL"
        End If
        Return sql

    End Function

    Private Function GetLeftCutSqlWhere()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( LeftWirePN1='" & txtPnOfLine.Text & "'"
            sql &= " OR LeftWirePN2='" & txtPnOfLine.Text & "'"
            sql &= " OR LeftWirePN3='" & txtPnOfLine.Text & "'"
            sql &= " OR LeftWirePN4='" & txtPnOfLine.Text & "')"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( LeftWirePN1='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR LeftWirePN2='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR LeftWirePN3='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR LeftWirePN4='" & txtPnOfLineTwo.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND LeftWirePN2 IN(" & GetPns() & ")"
            End If
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( LeftWirePN1='" & txtPnOfLineThree.Text & "'"
            sql &= " OR LeftWirePN2='" & txtPnOfLineThree.Text & "'"
            sql &= " OR LeftWirePN3='" & txtPnOfLineThree.Text & "'"
            sql &= " OR LeftWirePN4='" & txtPnOfLineThree.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND LeftWirePN3 IN(" & GetPns() & ")"
            End If
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( LeftWirePN1='" & txtPnOfLineFour.Text & "'"
            sql &= " OR LeftWirePN2='" & txtPnOfLineFour.Text & "'"
            sql &= " OR LeftWirePN3='" & txtPnOfLineFour.Text & "'"
            sql &= " OR LeftWirePN4='" & txtPnOfLineFour.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND LeftWirePN4 IN(" & GetPns() & ")"
            End If
        End If
        Return sql
    End Function

    Private Function GetRightCutSqlWhere()
        Dim sql As String = Nothing
        If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
            sql &= " AND ( RightWirePN1='" & txtPnOfLine.Text & "'"
            sql &= " OR RightWirePN2='" & txtPnOfLine.Text & "'"
            sql &= " OR RightWirePN3='" & txtPnOfLine.Text & "'"
            sql &= " OR RightWirePN4='" & txtPnOfLine.Text & "')"
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
            sql &= " AND ( RightWirePN1='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR RightWirePN2='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR RightWirePN3='" & txtPnOfLineTwo.Text & "'"
            sql &= " OR RightWirePN4='" & txtPnOfLineTwo.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                sql &= " AND RightWirePN2 IN(" & GetPns() & ")"
            End If
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
            sql &= " AND ( RightWirePN1='" & txtPnOfLineThree.Text & "'"
            sql &= " OR RightWirePN2='" & txtPnOfLineThree.Text & "'"
            sql &= " OR RightWirePN3='" & txtPnOfLineThree.Text & "'"
            sql &= " OR RightWirePN4='" & txtPnOfLineThree.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                sql &= " AND RightWirePN3 IN(" & GetPns() & ")"
            End If
        End If
        If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
            sql &= " AND ( RightWirePN1='" & txtPnOfLineFour.Text & "'"
            sql &= " OR RightWirePN2='" & txtPnOfLineFour.Text & "'"
            sql &= " OR RightWirePN3='" & txtPnOfLineFour.Text & "'"
            sql &= " OR RightWirePN4='" & txtPnOfLineFour.Text & "')"
            If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                sql &= " AND RightWirePN4 IN(" & GetPns() & ")"
            End If
        End If
        Return sql
    End Function

    Private Function TVAlreadyExists() As Boolean
        Dim sql As String = ""
        Dim strWirePNList As String = "", sqlWirePNList As String = ""
        If Me.txtPnOfLineTwo.Text <> String.Empty Then
            sqlWirePNList = " AND WirePN2 = '" & Me.txtPnOfLineTwo.Text.Trim() & "'"
        Else
            sqlWirePNList = " AND WirePN2 IS NULL"
        End If
        If Me.txtPnOfLineThree.Text <> String.Empty Then
            sqlWirePNList &= " AND WirePN3 = '" & Me.txtPnOfLineThree.Text.Trim() & "'"
        Else
            sqlWirePNList &= " AND WirePN3 IS NULL"
        End If
        If Me.txtPnOfLineFour.Text <> String.Empty Then
            sqlWirePNList &= " AND WirePN4 = '" & Me.txtPnOfLineFour.Text.Trim() & "'"
        Else
            sqlWirePNList &= " AND WirePN4 IS NULL"
        End If

        sql = "SELECT TVPN FROM m_RCardProParam_t a  WHERE TVPN='" & txtPnOfTV.Text & "' AND WirePN='" & txtPnOfLine.Text & "' " & _
              GetFatoryProfitcenter() & sqlWirePNList
        If DbOperateUtils.GetRowsCount(sql) > 0 Then Return True
        Return False
    End Function

    Private Function GetFatoryProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND a.Factoryid='" & VbCommClass.VbCommClass.Factory & "' "
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND a.Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'  "
        End If
        Return strValue
    End Function
    Private Function GetDefultFatoryProfitcenter() As String
        Dim strValue As String = String.Empty
        strValue = " AND Factoryid='" & VbCommClass.VbCommClass.Factory & "'"
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + " AND Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'"
        End If
        Return strValue
    End Function
    Private Function GetFatoryProfitcenter(table As String) As String
        Dim strValue As String = String.Empty
        strValue = String.Format(" AND {0}.Factoryid='" & VbCommClass.VbCommClass.Factory & "'", table)
        If VbCommClass.VbCommClass.profitcenter <> String.Empty Then
            strValue = strValue + String.Format(" AND {0}.Profitcenter= '" & VbCommClass.VbCommClass.profitcenter & "'", table)
        End If
        Return strValue
    End Function

    'Modify by cq20151231
    Private Function GetExportSql()
        'Dim sql As String = " SELECT  TVPN ,TVDes ," & _
        '                    " WirePN ,WirePNDes ,WirePN2 ,WirePNDes2,WirePN3 ,WirePNDes3,WirePN4 ,WirePNDes4 " & _
        '                    " ,BrassHeight ,BrassWidth , OutDaoHeight,OutDaoWidth, SX,XX,SP,XP," & _
        '                    " DrawForce,PeelSize ,CutSize ,FrontSize ," & _
        '                    " CutPN,EquPN ,b.username,a.intime" & _
        '                    " FROM m_RCardProParam_t a inner join m_users_t b on b.userid=a.userid WHERE 1=1  " & GetFatoryProfitcenter()
        Dim sql As String = " SELECT  TVPN ,TVDes ," & _
                           " WirePN ,WirePNDes ,WirePN2 ,WirePNDes2,WirePN3 ,WirePNDes3,WirePN4 ,WirePNDes4 " & _
                           " ,BrassHeight ,BrassWidth , OutDaoHeight,OutDaoWidth, SX,XX,SP,XP," & _
                           " DrawForce,PeelSize ,CutSize ,FrontSize ," & _
                           " CutPN,EquPN" & _
                           " FROM m_RCardProParam_t a inner join m_users_t b on b.userid=a.userid WHERE 1=1  " & GetFatoryProfitcenter()
        If ActionMode = ActionGrid.Query OrElse ActionMode = ActionGrid.Export Then
            'sql += GetWhereSql()
            If Me.IsDialogQuery = False Then
                sql += GetWhereSql()
            Else
                sql += Me.DialogSqlWhere
            End If

            sql += " order by a.intime desc "
        End If
        Return sql
    End Function

    Private Function GetSql()
        If TabControl1.SelectedIndex = 0 Then
            Select Case ActionMode
                Case ActionGrid.Load, ActionGrid.Undo
                    Return "SELECT  TVPN '端子料号',TVDes '通用名称'," & _
                            " WirePN '线材料号1',WirePNDes '适用线规', " & _
                            " WirePN2 '线材料号2',WirePNDes2 '适用线规2', " & _
                            " WirePN3 '线材料号3',WirePNDes3 '适用线规3', " & _
                            " WirePN4 '线材料号4',WirePNDes4 '适用线规4' " & _
                            " ,BrassHeight '内刀压着高度H1',BrassWidth '内刀压着宽度W1'" & _
                            " ,OutDaoHeight '外刀压着高度H2',OutDaoWidth '外刀压着宽度W2'," & _
                            " SX '上芯刀片规格',XX '下芯刀片规格',SP '上皮刀片规格',XP '下皮刀片规格'," & _
                            " DrawForce '拉拔力',PeelSize '脱皮尺寸',CutSize '裁线尺寸',FrontSize '前端尺寸'," & _
                            " CutPN '刀模', EquPN 工治具料号,FileName as '附件名称',isnull(FilePath,'') FilePath,a.InTime '创建时间',b.UserName '创建人'," & _
                            " CASE Status WHEN '1' THEN N'1.有效' ELSE N'0.无效' END '状态'" & _
                            " FROM m_RCardProParam_t a LEFT JOIN m_Users_t b ON a.UserID=b.UserID WHERE 1=1 " & GetFatoryProfitcenter()
                Case ActionGrid.Modify
                    Return "SELECT  TVPN '端子料号',TVDes '通用名称'," & _
                          " WirePN '线材料号1',WirePNDes '适用线规', " & _
                          " WirePN2 '线材料号2',WirePNDes2 '适用线规2', " & _
                          " WirePN3 '线材料号3',WirePNDes3 '适用线规3', " & _
                          " WirePN4 '线材料号4',WirePNDes4 '适用线规4' " & _
                          " ,BrassHeight '内刀压着高度H1',BrassWidth '内刀压着宽度W1'" & _
                          " ,OutDaoHeight '外刀压着高度H2',OutDaoWidth '外刀压着宽度W2'," & _
                           " SX '上芯刀片规格',XX '下芯刀片规格',SP '上皮刀片规格',XP '下皮刀片规格'," & _
                          " DrawForce '拉拔力',PeelSize '脱皮尺寸',CutSize '裁线尺寸',FrontSize '前端尺寸'," & _
                          " CutPN '刀模',EquPN 工治具料号,FileName as '附件名称',isnull(FilePath,'') FilePath,a.InTime '创建时间',b.UserName '创建人'," & _
                          " CASE Status WHEN '1' THEN N'1.有效' ELSE N'0.无效' END '状态'" & _
                          " FROM m_RCardProParam_t   a left join m_Users_t b on a.UserID=b.UserID WHERE 1=1 " & GetFatoryProfitcenter()
                Case Else
                    Return "SELECT   TVPN '端子料号',TVDes '通用名称'," & _
                            " WirePN '线材料号1',WirePNDes '适用线规', " & _
                            " WirePN2 '线材料号2',WirePNDes2 '适用线规2', " & _
                            " WirePN3 '线材料号3',WirePNDes3 '适用线规3', " & _
                            " WirePN4 '线材料号4',WirePNDes4 '适用线规4' " & _
                            " ,BrassHeight '内刀压着高度H1',BrassWidth '内刀压着宽度W1'" & _
                            " ,OutDaoHeight '外刀压着高度H2',OutDaoWidth '外刀压着宽度W2'," & _
                            " SX '上芯刀片规格',XX '下芯刀片规格',SP '上皮刀片规格',XP '下皮刀片规格'," & _
                            " DrawForce '拉拔力',PeelSize '脱皮尺寸',CutSize '裁线尺寸',FrontSize '前端尺寸'," & _
                            " CutPN '刀模',EquPN 工治具料号,FileName as '附件名称',isnull(FilePath,'') FilePath,a.InTime '创建时间',b.UserName '创建人'," & _
                            " CASE Status WHEN '1' THEN N'1.有效' ELSE N'0.无效' END '状态'" & _
                            " FROM m_RCardProParam_t a left join m_Users_t b on a.UserID=b.UserID  WHERE 1=1 " & GetFatoryProfitcenter()
            End Select
        ElseIf TabControl1.SelectedIndex = 1 Then
            Return "SELECT ID,  FinishSizeRangeMin '成品尺寸最小值',FinishSizeRangeMax '成品尺寸最大值'," & _
                    " HWStandardSize '华为成品公差标准',EmersonStandardSize '爱默生成品公差标准' " & _
                    " ,OtherStandardSize '其他公差标准',CutSizeMin '裁线下公差',ToleranceRange '公差范围'," & _
                    " a.InTime '创建时间',b.UserName '创建人'," & _
                    " Status,CASE Status WHEN 'Y' THEN N'有效' ELSE N'无效' END '状态'" & _
                    " FROM m_RCardAllowanceParam_t a left join m_Users_t b on a.UserID=b.UserID  WHERE 1=1 " & GetFatoryProfitcenter()
        ElseIf TabControl1.SelectedIndex = 2 Then
            Return "SELECT ID, ItemName '压接部位', RangeMin '范围最小值',RangeMax '范围最大值' ,ToleranceRange '公差范围'," & _
                  " a.InTime '创建时间',b.UserName '创建人'," & _
                  " Status,CASE Status WHEN '1' THEN N'有效' ELSE N'无效' END '状态'" & _
                  " FROM m_RCardAllowanceParamHW_t  a left join m_Users_t b on a.UserID=b.UserID  WHERE 1=1 " & GetFatoryProfitcenter()
        End If
        Return Nothing
    End Function

    Private Sub SaveProcessParameter()
        Dim sql As String = Nothing
        Dim errMsg As String = Nothing
        Dim strWirePNColumn As String = ""
        Dim strWirePNValue As String = ""
        Dim FrontSize As Object = IIf(String.IsNullOrEmpty(txtFrontSize.Text.Trim), Nothing, txtFrontSize.Text.Trim)
        Select Case ActionMode
            Case ActionGrid.Modify
                sql = "UPDATE m_RCardProParam_t SET TVDes=N'" & txtTvName.Text.Trim & "',WirePNDes=N'" & txtLineDesc.Text & "'" & _
                ", WirePNDes2=N'" & Me.txtLineDesc2.Text & "', WirePNDes3=N'" & Me.txtLineDesc3.Text & "',WirePNDes4=N'" & Me.txtLineDesc4.Text & "' " & _
                " ,BrassHeight=N'" & txtWireHeight.Text & "',BrassWidth=N'" & txtWireWidth.Text & "'" & _
                " ,OutDaoHeight=N'" & txtOutDaoHeight.Text & "',OutDaoWidth=N'" & txtOutDaoWidth.Text & "'" & _
                " ,SX=N'" & txtSX.Text.Trim & "',XX=N'" & txtXX.Text.Trim & "',SP=N'" & txtSP.Text.Trim & "',XP=N'" & txtXP.Text.Trim & "'" & _
                " ,DrawForce=N'" & txtDrawForce.Text & "',CutPN=N'" & txtPnOfCut.Text & "'," & _
                " PeelSize=N'" & txtSizeOfCut.Text & "',FrontSize=N'" & FrontSize & "', CutSize=N'" & txtCutSize.Text & "', " & _
                " EquPN='" & txtEquPN.Text.Trim & "',Intime=GETDATE()," & _
                " UserID='" & VbCommClass.VbCommClass.UseId & "',status='" & cboStatus.SelectedItem.ToString.Substring(0, 1) & "'" & _
                " WHERE TVPN='" & txtPnOfTV.Text & "'" & GetDefultFatoryProfitcenter()
                If Not String.IsNullOrEmpty(txtPnOfLine.Text) Then
                    sql &= " AND WirePN='" & txtPnOfLine.Text & "'"
                Else
                    sql &= "  AND WirePN IS NULL"
                End If
                If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                    sql &= " AND WirePN2='" & txtPnOfLineTwo.Text & "'"
                Else
                    sql &= "  AND WirePN2 IS NULL"
                End If

                If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then
                    sql &= " AND WirePN3='" & txtPnOfLineThree.Text & "'"
                Else
                    sql &= "  AND WirePN3 IS NULL"
                End If

                If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
                    sql &= " AND WirePN4='" & txtPnOfLineFour.Text & "'"
                Else
                    sql &= "  AND WirePN4 IS NULL"
                End If

                sql &= GetReleateSql(txtPnOfTV.Text, txtPnOfLine.Text)

                If MessageUtils.ShowConfirm("艺参数都将改变并且流程卡回到制作中状态,请确认？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                If cboStatus.SelectedIndex = 1 Then
                    If MessageUtils.ShowConfirm("将工艺参数改成无效状态将会删除与之对应的流程卡的所有工艺参数？", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            Case ActionGrid.Add

                If Not String.IsNullOrEmpty(txtPnOfLineTwo.Text) Then
                    strWirePNColumn = ",WirePN2,WirePNDes2"
                    ' strWirePNValue = ",'" & txtPnOfLineTwo.Text & "'," & IIf(Me.txtLineDesc2.Text.Equals(String.Empty), "'NA'", "N'" & Me.txtLineDesc2.Text & "'") & ","  'Modify by cq20151231
                    strWirePNValue = ",'" & txtPnOfLineTwo.Text & "'," & "N'" & Me.txtLineDesc2.Text & "'" & ","
                Else
                    strWirePNColumn &= ""
                    strWirePNValue &= ""
                End If

                If Not String.IsNullOrEmpty(txtPnOfLineThree.Text) Then

                    strWirePNColumn &= " ,WirePN3,WirePNDes3"
                    strWirePNValue &= "'" & Me.txtPnOfLineThree.Text & "'," & "N'" & Me.txtLineDesc3.Text.Trim() & "'" & ","
                Else
                    strWirePNColumn &= ""
                    strWirePNValue &= ""
                End If

                If Not String.IsNullOrEmpty(txtPnOfLineFour.Text) Then
                    strWirePNColumn &= ",WirePN4,WirePNDes4"
                    strWirePNValue &= "'" & txtPnOfLineFour.Text & "'," & "N'" & Me.txtLineDesc4.Text.Trim & "'" & ","
                Else
                    strWirePNColumn &= ""
                    strWirePNValue &= ""
                End If

                If strWirePNValue <> String.Empty Then
                    strWirePNValue = strWirePNValue.Substring(0, strWirePNValue.Length - 1)
                End If

                sql = " INSERT INTO m_RCardProParam_t(TVPN,TVDes,WirePN,WirePNDes,EquPN, " & _
                      " brassHeight, BrassWidth, OutDaoHeight,OutDaoWidth,SX,XX,SP,XP,DrawForce,PeelSize,FrontSize,CutSize,CutPN,InTime,UserID,Status,Factoryid,Profitcenter " & strWirePNColumn & " ) VALUES(" & _
                      "N'" & txtPnOfTV.Text.Trim & "',N'" & txtTvName.Text.Trim & "',N'" & txtPnOfLine.Text.Trim.Trim & "',N'" & txtLineDesc.Text.Trim & "','" & txtEquPN.Text.Trim.Trim & "'" & _
                      ",N'" & txtWireHeight.Text.Trim & "',N'" & txtWireWidth.Text & "'," & _
                      " N'" & txtOutDaoHeight.Text.Trim & "',N'" & txtOutDaoWidth.Text & "'," & _
                      " N'" & txtSX.Text.Trim & "',N'" & txtXX.Text.Trim & "',N'" & txtSP.Text.Trim & "',N'" & txtXP.Text.Trim.Trim & "'," & _
                      " N'" & txtDrawForce.Text.Trim & "',N'" & txtSizeOfCut.Text.Trim & "' " & _
                      ",N'" & txtFrontSize.Text.Trim & "',N'" & txtCutSize.Text.Trim & "',N'" & txtPnOfCut.Text & "',GETDATE(),'" & VbCommClass.VbCommClass.UseId & "' " & _
                      ",'" & cboStatus.SelectedItem.ToString.Substring(0, 1) & _
                      "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "'" & strWirePNValue & ") "
        End Select
        If Not String.IsNullOrEmpty(sql) Then
            'cq 20161121
            errMsg = DbOperateUtils.ExecSQL(sql)
            If String.IsNullOrEmpty(errMsg) Then
                '*************************************************田玉琳 20171101 开始*************************************************
                If (txtPnOfLineTwo.Text.Trim = "" AndAlso txtPnOfLineThree.Text.Trim = "" AndAlso txtPnOfLineFour.Text.Trim = "") Then
                    RCardComBusiness.ExecCNCUpdate(txtPnOfTV.Text.Trim, txtPnOfLine.Text.Trim)
                End If
                '*************************************************田玉琳 20171101 结束*************************************************
                MessageUtils.ShowInformation("保存成功")
                '黄广都
                '  PagerPaging.LoadData()
                SetControlStatus(ActionGrid.Undo)
                '黄广都
                'PagerPaging.LoadData()
                LoadProcessParameters()
            Else
                MessageUtils.ShowError(errMsg)
            End If
        End If
    End Sub

    Private Sub SaveCommonDifferenceParameter()
        Dim sql As String = Nothing
        Dim errMsg As String = Nothing
        Select Case ActionMode
            Case ActionGrid.Modify
                sql = "UPDATE m_RCardAllowanceParam_t SET FinishSizeRangeMin=N'" & txtCDFinishSizeMin.Text & "',FinishSizeRangeMax=N'" & txtCDFinishSizeMax.Text & "'" & _
                " ,HWStandardSize=N'" & txtCDHWFinishStandard.Text & "',EmersonStandardSize=N'" & txtCDEmFinishStandard.Text & "',OtherStandardSize=N'" & txtCDOtherFinishStandard.Text & "'," & _
                " InTime=GETDATE(),CutSizeMin='" & txtCDCutSize.Text & "', ToleranceRange =N'" & Me.txtToleranceRange.Text.Trim & "'" & _
                " ,UserID='" & VbCommClass.VbCommClass.UseId & "',Status='" & cdCobStatus.SelectedItem.ToString.Substring(0, 1) & "' " & _
                " WHERE ID=" & Me.lblID.Text & ""
            Case ActionGrid.Add
                sql = " INSERT INTO m_RCardAllowanceParam_t(FinishSizeRangeMin,FinishSizeRangeMax" & _
                 " ,HWStandardSize,EmersonStandardSize,OtherStandardSize,CutSizeMin,ToleranceRange,InTime,UserID,Status,Factoryid,Profitcenter) VALUES(" & _
                      "N'" & txtCDFinishSizeMin.Text & "',N'" & txtCDFinishSizeMax.Text & "',N'" & txtCDHWFinishStandard.Text & "',N'" & txtCDEmFinishStandard.Text & "'" & _
                      ",N'" & txtCDOtherFinishStandard.Text & "','" & txtCDCutSize.Text & "', N'" & Me.txtToleranceRange.Text.Trim & " ',GETDATE(),'" & VbCommClass.VbCommClass.UseId & "' " & _
                      ",'" & cdCobStatus.SelectedItem.ToString.Substring(0, 1) & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "') "
        End Select
        If Not String.IsNullOrEmpty(sql) Then
            errMsg = DbOperateUtils.ExecSQL(sql)
            If String.IsNullOrEmpty(errMsg) Then
                MessageUtils.ShowInformation("保存成功")
                '黄广都
                'PagerPaging.LoadData()
                LoadProcessParameters()
                SetControlStatus(ActionGrid.Undo)
            Else
                MessageUtils.ShowError(errMsg)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 保存压接高宽度公差
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveCommonDifferenceParameterHW()
        Dim sql As New StringBuilder
        Dim errMsg As String = Nothing
        Try
            Select Case ActionMode
                Case ActionGrid.Modify
                    sql.Append("UPDATE m_RCardAllowanceParamHW_t SET ItemName =N'" & txtItemName.Text & "',RangeMin=N'" & txtRangeMin.Text & "',RangeMax=N'" & txtRangeMax.Text & "'")
                    sql.Append(" ,InTime=GETDATE(), ToleranceRange =N'" & Me.txtGCRange.Text.Trim & "'")
                    sql.Append(" ,UserID='" & VbCommClass.VbCommClass.UseId & "',Status='" & cobStatus.SelectedItem.ToString.Substring(0, 1) & "'")
                    sql.Append(" WHERE ID=" & Me.lblID.Text & "")
                Case ActionGrid.Add
                    sql.Append(" INSERT INTO m_RCardAllowanceParamHW_t(ItemName,RangeMin,RangeMax")
                    sql.Append(" ,ToleranceRange,InTime,UserID,Status,Factoryid,Profitcenter) VALUES(")
                    sql.Append(" N'" & txtItemName.Text & "',N'" & txtRangeMin.Text & "',N'" & txtRangeMax.Text & "',N'" & txtGCRange.Text & "'")
                    sql.Append(",GETDATE(),'" & VbCommClass.VbCommClass.UseId & "' ")
                    sql.Append(",'" & cobStatus.SelectedItem.ToString.Substring(0, 1) & "','" & VbCommClass.VbCommClass.Factory & "','" & VbCommClass.VbCommClass.profitcenter & "') ")
            End Select
            If Not String.IsNullOrEmpty(sql.ToString) Then
                errMsg = DbOperateUtils.ExecSQL(sql.ToString)
                If String.IsNullOrEmpty(errMsg) Then
                    MessageUtils.ShowInformation("保存成功")
                    '黄广都
                    'PagerPaging.LoadData()
                    LoadProcessParameters()
                    SetControlStatus(ActionGrid.Undo)
                Else
                    MessageUtils.ShowError(errMsg)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmProcessParametersMaintain", "SaveCommonDifferenceParameterHW", "RCard")
        End Try
    End Sub

    '1．	针对加工参数（譬如脱皮尺寸和前段尺寸）修改时，相关的流程卡驳回到制作中，并在head部分的备注栏“因工艺资料修改ByC045427,流程卡退回制作中”，
    '    当将该流程卡审核至生效状态时，备注自动清空
    '2．	针对加工参数资料库 其他地方的修改（譬如线材端子规格、端子高宽度及拉拔力、刀片尺寸、刀模、工治具料号等），
    '相关流程卡的工站的校验项值自动更新和打印显示（不用进标准工艺处 选端子和线材），而且流程卡状态保持不变（保持原状态）
    '3．	查询 增加备注栏位：全模糊查询（类似其他栏位的查询方式）
    Private Function GetReleateSql(ByVal pnOfTv As String, ByVal pnOfLine As String)
        Dim blnBackToMade As Boolean = False
        Dim sql As String = Nothing
        Dim strRemark As String = String.Empty
        If txtDrawForce.Text <> drawForce Then '拉拔力
            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtDrawForce.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID IN ('LDF','DF') AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtDrawForce.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RDF' AND RightTVPN='" & pnOfTv & "'" & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            'Add by cq20170724
            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtDrawForce.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
       "' ,InTime=GETDATE() WHERE CheckItemID IN ('LDF','DF') AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtDrawForce.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RDF' AND RightTVPN='" & pnOfTv & "'" & GetRightSqlWhere() & GetDefultFatoryProfitcenter()
        End If

        If peelSize <> txtSizeOfCut.Text Then '脱皮尺寸
            ' sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue=ResultValue WHERE 1=0"
            ' sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
            '     "' ,InTime=GETDATE() WHERE CheckItemID='LPL' AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            ' sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
            '     "' ,InTime=GETDATE() WHERE CheckItemID='RPL' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            ' sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
            '"' ,InTime=GETDATE() WHERE CheckItemID='LPL' AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            ' sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
            '     "' ,InTime=GETDATE() WHERE CheckItemID='RPL' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            sql &= " UPDATE m_CutCardDCheckItem_t SET ResultValue='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='LPL' AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_CutCardDCheckItem_t SET ResultValue='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RPL' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            'add by cq20180115
            sql &= " UPDATE m_CutCardDCheckItemPrint_t SET ResultValue='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
           "' ,InTime=GETDATE() WHERE CheckItemID='LPL' AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_CutCardDCheckItemPrint_t SET ResultValue='" & txtSizeOfCut.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RPL' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            strRemark = strRemark + "脱皮尺寸修改旧值[" & peelSize & "],新值[" & txtSizeOfCut.Text & "]"
            blnBackToMade = True
        End If

        If brassHeight <> txtWireHeight.Text Then '高度
            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtWireHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID IN('LCH','CH') AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtWireHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCH' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            'Add by cq20170724, ADD LCH,CH, in order to for combin case.
            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtWireHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
               "' ,InTime=GETDATE() WHERE CheckItemID in('LCH','CH') AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtWireHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCH' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()
        End If

        '高度H2
        If outDaoHeight <> Me.txtOutDaoHeight.Text Then
            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtOutDaoHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
               "' ,InTime=GETDATE() WHERE CheckItemID='LCH2' AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtOutDaoHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCH2' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            'Add by cq20170724, ADD LCH,CH, in order to for combin case.
            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtOutDaoHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
               "' ,InTime=GETDATE() WHERE CheckItemID in('LCH2','CH2') AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtOutDaoHeight.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCH2' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()
        End If

        If brassWidth <> txtWireWidth.Text Then '宽度
            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtWireWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='LCW' AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()

            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtWireWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCW' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()


            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtWireWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
               "' ,InTime=GETDATE() WHERE CheckItemID IN('LCW','CW') AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()

            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtWireWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCW' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            'add by cq 20171212 for 裁线卡
            sql &= " UPDATE m_CutCardDCheckItem_t SET ResultValue='" & txtWireWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
      "' ,InTime=GETDATE() WHERE CheckItemID='LCW' AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()

            sql &= " UPDATE m_CutCardDCheckItem_t SET ResultValue='" & txtWireWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCW' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

        End If

        If outDaoWidth <> Me.txtOutDaoWidth.Text Then '宽度W2
            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtOutDaoWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='LCW2' AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue='" & txtOutDaoWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCW2' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()


            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtOutDaoWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
               "' ,InTime=GETDATE() WHERE CheckItemID IN( 'LCW2','CW2') AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_RCardDCheckItemPrint_t SET ResultValue='" & txtOutDaoWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCW2' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            'add by cq 20171212
            sql &= " UPDATE m_CutCardDCheckItem_t SET ResultValue='" & txtOutDaoWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
    "' ,InTime=GETDATE() WHERE CheckItemID='LCW2' AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_CutCardDCheckItem_t SET ResultValue='" & txtOutDaoWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCW2' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

            'add by cq 20191217 裁线卡
            sql &= " UPDATE m_CutCardDCheckItemPrint_t SET ResultValue='" & txtOutDaoWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
             "' ,InTime=GETDATE() WHERE CheckItemID IN( 'LCW2','CW2') AND LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & GetDefultFatoryProfitcenter()
            sql &= " UPDATE m_CutCardDCheckItemPrint_t SET ResultValue='" & txtOutDaoWidth.Text & "',USERID='" & VbCommClass.VbCommClass.UseId & _
                "' ,InTime=GETDATE() WHERE CheckItemID='RCW2' AND RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & GetDefultFatoryProfitcenter()

        End If

        If frontSize <> txtFrontSize.Text Then '前端尺寸
            '            SET ResultValue=  CAST((A.FinishSize-ISNULL(B.FrontSize,A.LeftCutSize) - 
            'ISNULL(C.FrontSize,A.RightCutSize)- 
            'iif(len(ToleranceRange) >=2,ISNULL(SUBSTRING(ToleranceRange,2,LEN(ToleranceRange)-1),0),0)) AS VARCHAR)+ A.ToleranceRange  ,
            'sql &= " UPDATE m_RCardDCheckItem_t SET ResultValue= " & _
            '       " CAST((A.FinishSize-ISNULL(B.FrontSize,A.LeftCutSize) - ISNULL(C.FrontSize,A.RightCutSize)-" & _
            '       " ISNULL(SUBSTRING(ToleranceRange,2,LEN(ToleranceRange)-1),0)) AS VARCHAR)+ A.ToleranceRange " & _
            '       " ,LeftCutSize=(CASE WHEN B.FrontSize IS NULL THEN A.LeftCutSize ELSE B.FrontSize END) " & _
            '       " ,RightCutSize=(CASE WHEN C.FrontSize IS NULL THEN A.RightCutSize ELSE C.FrontSize END) " & _
            '       " FROM  m_RCardDCheckItem_t A LEFT JOIN m_RCardProParam_t B " & _
            '       " ON A.LeftTVPN=B.TVPN " & GetLeftSqlWhereByWirePartNumber() & " " & _
            '       " LEFT JOIN m_RCardProParam_t C " & _
            '       " ON A.RightTVPN=C.TVPN " & GetRightSqlWhereByWirePartNumber() & " " & _
            '       " WHERE ((A.LeftTVPN='" & pnOfTv & "' " & GetLeftCutSqlWhere() & ")" & _
            '       " OR(A.RightTVPN='" & pnOfTv & "' " & GetRightCutSqlWhere() & ")) AND CheckItemID='LCL'" & _
            '       GetDefultFatoryProfitcenter("A")

            'sql &= " UPDATE m_RCardDCheckItem_t SET LeftCutSize=(CASE WHEN B.FrontSize IS NULL THEN A.LeftCutSize ELSE B.FrontSize END) " & _
            '     " ,RightCutSize=(CASE WHEN C.FrontSize IS NULL THEN A.RightCutSize ELSE C.FrontSize END) " & _
            '     " FROM  m_RCardDCheckItem_t A LEFT JOIN m_RCardProParam_t B " & _
            '     " ON A.LeftTVPN=B.TVPN " & GetLeftSqlWhereByWirePartNumber() & " " & _
            '     " LEFT JOIN m_RCardProParam_t C " & _
            '     " ON A.RightTVPN=C.TVPN " & GetRightSqlWhereByWirePartNumber() & " " & _
            '     " WHERE ((A.LeftTVPN='" & pnOfTv & "' " & GetLeftCutSqlWhere() & ")" & _
            '     " OR(A.RightTVPN='" & pnOfTv & "' " & GetRightCutSqlWhere() & ")) AND CheckItemID='LCL'" & _
            '     GetDefultFatoryProfitcenter("A")

            'Add by cq 20170724, for no update, let back to made to reset the frontSize
            sql &= " UPDATE m_RCardDCheckItem_t SET PartID=PartID " & _
                   " FROM  m_RCardDCheckItem_t A LEFT JOIN m_RCardProParam_t B " & _
                   " ON A.LeftTVPN=B.TVPN " & GetLeftSqlWhereByWirePartNumber() & " " & _
                   " LEFT JOIN m_RCardProParam_t C " & _
                   " ON A.RightTVPN=C.TVPN " & GetRightSqlWhereByWirePartNumber() & " " & _
                   " WHERE ((A.LeftTVPN='" & pnOfTv & "' " & GetLeftCutSqlWhere() & ")" & _
                   " OR(A.RightTVPN='" & pnOfTv & "' " & GetRightCutSqlWhere() & ")) AND CheckItemID='LCL'" & _
                   GetFatoryProfitcenter("A")

            strRemark = strRemark + "前端尺寸修改"

            blnBackToMade = True
        End If

        If Not String.IsNullOrEmpty(sql) Then
            'Add If by cq20170724
            If blnBackToMade Then
                strRemark = strRemark + String.Format(",By{0},流程卡退回制作中", VbCommClass.VbCommClass.UseId)
                sql &= " UPDATE m_RCardM_t SET Status=0,Remark=N'" & strRemark & "' " & _
                        " FROM m_RCardM_t A,m_RCardDCheckItem_t B" & _
                        " WHERE ((B.LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
                        " OR(B.RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))" & _
                        " AND B.PartID=A.PartID" & GetFatoryProfitcenter("A")

                sql &= " UPDATE m_RCardCutM_t SET Status=0,Remark=N'" & strRemark & "' " & _
                      " FROM m_RCardCutM_t A,m_CutCardDCheckItem_t B" & _
                      " WHERE ((B.LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
                      " OR(B.RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))" & _
                      " AND B.PartID=A.PartID" & GetFatoryProfitcenter("A")
            End If

            'Modify by cq20170726, 
            sql &= " UPDATE m_RCardD_t SET ProcessStandard=ISNULL(B.RVAL,A.ProcessStandard)" & _
                    " FROM m_RCardD_t A JOIN" & _
                    "( SELECT A.PartID,A.StationID,( SELECT (B.DESCRIPTION+':'+B.ResultValue)+'; '  " & _
                    " FROM m_RCardDCheckItem_t B  LEFT JOIN  m_CheckItem_t item on b.checkitemid = item.CheckItemID" & _
                    " WHERE B.ResultValue<>'/' AND B.Status='1'  " & _
                    " AND B.PartID=A.PartID AND A.Stationid = B.StationID  ORDER BY B.CheckGroup,item.SortSeq FOR XML PATH('') ) RVAL " & _
                    " FROM m_RCardDCheckItem_t A," & _
                    " (SELECT DISTINCT PartID FROM m_RCardDCheckItem_t  " & _
                    " WHERE ((LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
                    " OR(RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))) C" & _
                    " WHERE A.PartID = C.PartID" & _
                    " GROUP BY A.PartID,A.StationID) B " & _
                    " ON A.PartID=B.PartID AND A.StationID=B.StationID " & GetFatoryProfitcenter("A")
            ' add by cq20170724
            sql &= " UPDATE m_RCardD_t SET ProcessStandardPrint=ISNULL(B.RVAL,A.ProcessStandardPrint)" & _
                  " FROM m_RCardD_t A JOIN" & _
                  "( SELECT A.PartID,A.StationID,(  SELECT (B.DESCRIPTION+':'+B.ResultValue)+'; '  " & _
                  " FROM m_RCardDCheckItemPrint_t B LEFT JOIN  m_CheckItem_t item on b.checkitemid = item.CheckItemID" & _
                  " WHERE B.ResultValue<>'/' AND B.Status='1'  " & _
                  " AND B.PartID=A.PartID AND A.Stationid = B.StationID ORDER BY B.CheckGroup,item.SortSeq FOR XML PATH('') ) RVAL  " & _
                  " FROM m_RCardDCheckItemPrint_t A," & _
                  " (SELECT DISTINCT PartID FROM m_RCardDCheckItemPrint_t  " & _
                  " WHERE ((LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
                  " OR(RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))) C" & _
                  " WHERE A.PartID = C.PartID" & _
                  " GROUP BY A.PartID,A.StationID) B " & _
                  " ON A.PartID=B.PartID AND A.StationID=B.StationID " & GetFatoryProfitcenter("A")

            'add by cq20170821, 裁线卡 cq 20171211 m_RCardDCheckItem_t ==> m_CutCardDCheckItem_t 
            sql &= " UPDATE m_RCardCutD_t SET ProcessStandard=ISNULL(B.RVAL,A.ProcessStandard)" & _
                   " FROM m_RCardCutD_t A JOIN" & _
                   "( SELECT A.PartID,A.StationID,( SELECT (B.DESCRIPTION+':'+B.ResultValue)+'; '  " & _
                   " FROM m_CutCardDCheckItem_t B LEFT JOIN  m_CheckItem_t item on b.checkitemid = item.CheckItemID    " & _
                   " WHERE B.ResultValue<>'/' AND B.Status='1'  " & _
                   " AND B.PartID=A.PartID AND A.Stationid = B.StationID  ORDER BY B.CheckGroup,item.sortseq FOR XML PATH('') ) RVAL " & _
                   " FROM m_CutCardDCheckItem_t A," & _
                   " (SELECT DISTINCT PartID FROM m_CutCardDCheckItem_t  " & _
                   " WHERE ((LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
                   " OR(RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))) C" & _
                   " WHERE A.PartID = C.PartID" & _
                   " GROUP BY A.PartID,A.StationID) B " & _
                   " ON A.PartID=B.PartID AND A.StationID=B.StationID " & GetFatoryProfitcenter("A")

            '裁线卡 cq 20171211 m_RCardDCheckItem_t ==> m_CutCardDCheckItem_t 
            sql &= " UPDATE m_RCardCutD_t SET ProcessStandardPrint=ISNULL(B.RVAL,A.ProcessStandardPrint)" & _
               " FROM m_RCardCutD_t A JOIN" & _
               "( SELECT A.PartID,A.StationID,(  SELECT (B.DESCRIPTION+':'+B.ResultValue)+'; '  " & _
               " FROM m_CutCardDCheckItemPrint_t B  LEFT JOIN  m_CheckItem_t item on b.checkitemid = item.CheckItemID       " & _
               " WHERE B.ResultValue<>'/' AND B.Status='1'  " & _
               " AND B.PartID=A.PartID AND A.Stationid = B.StationID ORDER BY B.CheckGroup,item.sortseq FOR XML PATH('') ) RVAL  " & _
               " FROM m_CutCardDCheckItemPrint_t A," & _
               " (SELECT DISTINCT PartID FROM m_CutCardDCheckItemPrint_t  " & _
               " WHERE ((LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
               " OR(RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))) C" & _
               " WHERE A.PartID = C.PartID" & _
               " GROUP BY A.PartID,A.StationID) B " & _
               " ON A.PartID=B.PartID AND A.StationID=B.StationID " & GetFatoryProfitcenter("A")

            'add by cq20170825, modify by cq 20171212 m_RCardDCheckItem_t ==> m_CutCardDCheckItem_t
            sql &= " UPDATE m_RCardCutD_t SET LeftProcessStandard=ISNULL(B.RVAL,A.LeftProcessStandard)" & _
            " FROM m_RCardCutD_t A JOIN" & _
            "( SELECT A.PartID,A.StationID,(  SELECT (CC.DESCCut+':'+B.ResultValue)+'; '  " & _
            " FROM m_CutCardDCheckItem_t B  LEFT JOIN m_CheckItem_t cc ON b.checkitemid = cc.checkitemid" & _
            " WHERE B.ResultValue<>'/' AND B.Status='1' AND B.CheckGroup='LH' " & _
            " AND B.PartID=A.PartID AND A.Stationid = B.StationID ORDER BY B.CheckGroup,cc.sortseq FOR XML PATH('') ) RVAL  " & _
            " FROM m_CutCardDCheckItem_t A," & _
            " (SELECT DISTINCT PartID FROM m_CutCardDCheckItem_t  " & _
            " WHERE ((LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
            " OR(RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))) C" & _
            " WHERE A.PartID = C.PartID" & _
            " GROUP BY A.PartID,A.StationID) B " & _
            " ON A.PartID=B.PartID AND A.StationID=B.StationID " & GetFatoryProfitcenter("A")

            sql &= " UPDATE m_RCardCutD_t SET RightProcessStandard=ISNULL(B.RVAL,A.RightProcessStandard)" & _
         " FROM m_RCardCutD_t A JOIN" & _
         "( SELECT A.PartID,A.StationID,(  SELECT (CC.DESCCut+':'+B.ResultValue)+'; '  " & _
         " FROM m_CutCardDCheckItem_t B LEFT JOIN m_CheckItem_t cc ON b.checkitemid = cc.checkitemid " & _
         " WHERE B.ResultValue<>'/' AND B.Status='1' AND B.CheckGroup='RH' " & _
         " AND B.PartID=A.PartID AND A.Stationid = B.StationID ORDER BY B.CheckGroup,cc.sortseq FOR XML PATH('') ) RVAL  " & _
         " FROM m_CutCardDCheckItem_t A," & _
         " (SELECT DISTINCT PartID FROM m_CutCardDCheckItem_t  " & _
         " WHERE ((LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
         " OR(RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))) C" & _
         " WHERE A.PartID = C.PartID" & _
         " GROUP BY A.PartID,A.StationID) B " & _
         " ON A.PartID=B.PartID AND A.StationID=B.StationID " & GetFatoryProfitcenter("A")

            'add by cq20171212, 
            sql &= " Insert into m_RCardProParamLog_t([TVPN],[WirePN]" & _
                   " ,[WirePN2] ,[WirePN3] ,WirePN4 ,UserID , Intime ,Remark) Values " & _
                   " ('" & pnOfTv & "','" & txtPnOfLine.Text & "','" & txtPnOfLineTwo.Text & "', " & _
                   " '" & Me.txtPnOfLineThree.Text & "', '" & txtPnOfLineFour.Text & "','" & VbCommClass.VbCommClass.UseId & "',getdate(), N'" & strRemark & "')"


        End If

        If cboStatus.SelectedIndex = 1 Then '置为无效
            sql = Nothing
            sql &= " UPDATE m_RCardM_t SET Status=0 ,Remark=N'" & String.Format("因工艺资料作废By{0},流程卡退回制作中", VbCommClass.VbCommClass.UseId) & "'" & _
                   " FROM m_RCardM_t A,m_RCardDCheckItem_t B" & _
                   " WHERE ((B.LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
                   " OR(B.RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))" & _
                   " AND B.PartID=A.PartID" & GetFatoryProfitcenter("A")

            'mark by cq 20170401
            'sql &= " UPDATE m_RCardD_t SET ProcessStandard=NULL " & _
            '      " FROM m_RCardM_t A,m_RCardDCheckItem_t B" & _
            '      " WHERE ((B.LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
            '      " OR(B.RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & "))" & _
            '      " AND B.PartID=A.PartID" & GetFatoryProfitcenter("A")

            sql &= " DELETE FROM m_RCardDCheckItem_t " & _
                    " WHERE (LeftTVPN='" & pnOfTv & "' " & GetLeftSqlWhere() & ")" & _
                    " OR(RightTVPN='" & pnOfTv & "' " & GetRightSqlWhere() & ")" & _
                      GetDefultFatoryProfitcenter()
        End If
        Return sql
    End Function

#End Region


    Private Sub dgvProcessParameter_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProcessParameter.CellDoubleClick
        Dim lsSQL As String = ""
        Dim o_strTVPN As String = String.Empty
        Dim o_strWirePN1 As String = String.Empty
        Dim o_strWirePN2 As String = String.Empty
        Dim o_strWirePN3 As String = String.Empty
        Dim o_strWirePN4 As String = String.Empty
        Try
            If IsNothing(Me.dgvProcessParameter.CurrentRow) Then Exit Sub
            o_strTVPN = Me.dgvProcessParameter.CurrentRow.Cells(ProcessGrid.TVPN).Value.ToString
            o_strWirePN1 = Me.dgvProcessParameter.CurrentRow.Cells(ProcessGrid.WirePN).Value.ToString
            o_strWirePN2 = Me.dgvProcessParameter.CurrentRow.Cells(ProcessGrid.WirePN2).Value.ToString
            o_strWirePN3 = Me.dgvProcessParameter.CurrentRow.Cells(ProcessGrid.WirePN3).Value.ToString
            o_strWirePN4 = Me.dgvProcessParameter.CurrentRow.Cells(ProcessGrid.WirePN4).Value.ToString
            If Not dgvProcessParameter.Columns(e.ColumnIndex).Name = dgvProcessParameter.Columns(ProcessGrid.FileName).Name Then
                If String.IsNullOrEmpty(o_strTVPN) Then Exit Sub
                Using o_FrmPNList As FrmPNList = New FrmPNList(o_strTVPN, o_strWirePN1, o_strWirePN2, o_strWirePN3, o_strWirePN4)
                    o_FrmPNList.ShowDialog()
                End Using
            Else
                Dim FileName = Me.dgvProcessParameter.CurrentRow.Cells(ProcessGrid.FilePath).Value.ToString
                If File.Exists(FileName) Then
                    System.Diagnostics.Process.Start(FileName)
                End If
            End If
        Catch ex As Exception
            SysMessageClass.WriteErrLog(ex, "FrmProcessParametersMaintain", "dgvProcessParameter_CellDoubleClick", "RCard")
        End Try
    End Sub

    Private Sub dgvHWGC_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHWGC.CellClick
        Try
            If dgvHWGC.Rows.Count <= 0 Then Exit Sub
            Me.lblID.Text = Me.dgvHWGC.Item(HWGCGrid.ID, dgvHWGC.CurrentRow.Index).Value.ToString()
            Me.txtItemName.Text = Me.dgvHWGC.Item(HWGCGrid.ItemName, dgvHWGC.CurrentRow.Index).Value.ToString()
            Me.txtRangeMin.Text = Me.dgvHWGC.Item(HWGCGrid.RangeMin, dgvHWGC.CurrentRow.Index).Value.ToString()
            Me.txtRangeMax.Text = Me.dgvHWGC.Item(HWGCGrid.RangeMax, dgvHWGC.CurrentRow.Index).Value.ToString()
            Me.txtToleranceRange.Text = Me.dgvHWGC.Item(HWGCGrid.Tolerance, dgvHWGC.CurrentRow.Index).Value.ToString
            Me.cobStatus.SelectedIndex = Me.cobStatus.FindString(Me.dgvHWGC.Item(HWGCGrid.Status1, dgvHWGC.CurrentRow.Index).Value.ToString())
            Me.txtGCRange.Text = Me.dgvHWGC.Item(HWGCGrid.Tolerance, dgvHWGC.CurrentRow.Index).Value.ToString()

        Catch ex As Exception
            MessageUtils.ShowError(ex.Message)
            SysMessageClass.WriteErrLog(ex, "RunCard.FrmProcessParametersMaintain", "dgvHWGC_CellClick", "RCard")
        End Try
    End Sub


    Private Sub toolQuery_Click(sender As Object, e As EventArgs) Handles toolQuery.Click

        Dim FrmProcessParametersQuerySet As New FrmProcessParametersQuery()
        FrmProcessParametersQuerySet.Owner = Me
        FrmProcessParametersQuerySet.ShowDialog()
        If FrmProcessParametersQuerySet.DialogResult = Windows.Forms.DialogResult.OK Then

            Dim strSql As New StringBuilder
            TabControl1.SelectedIndex = 0
            'strSql.Append(GetSql())
            If (Not String.IsNullOrEmpty(FrmProcessParametersQuerySet.txtDialogTvpn.Text.Trim)) Then
                strSql.Append("AND  TVPN  like N'%" & FrmProcessParametersQuerySet.txtDialogTvpn.Text.Trim & "%'").Append(vbNewLine)
            End If
            If Not String.IsNullOrEmpty(FrmProcessParametersQuerySet.txtPnOfLineOne.Text.Trim) Then
                strSql.Append("AND  WirePN like N'%" & FrmProcessParametersQuerySet.txtPnOfLineOne.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(FrmProcessParametersQuerySet.txtPnOfLineTwo.Text.Trim) Then
                strSql.Append("AND  WirePN2 like N'%" & FrmProcessParametersQuerySet.txtPnOfLineTwo.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(FrmProcessParametersQuerySet.txtPnOfLineFour.Text.Trim) Then
                strSql.Append("AND  WirePN3  like N'%" & FrmProcessParametersQuerySet.txtPnOfLineFour.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(FrmProcessParametersQuerySet.txtPnOfLineFour.Text.Trim) Then
                strSql.Append("AND WirePN4 like N'%" & FrmProcessParametersQuerySet.txtPnOfLineFour.Text.Trim & "%'").Append(vbNewLine)
            End If

            If Not String.IsNullOrEmpty(FrmProcessParametersQuerySet.txtUserID.Text.Trim) Then
                strSql.Append("AND b.UserName like N'%" & FrmProcessParametersQuerySet.txtUserID.Text.Trim & "%'").Append(vbNewLine)
            End If

            If FrmProcessParametersQuerySet.ckDateBegin.Checked AndAlso Not String.IsNullOrEmpty(FrmProcessParametersQuerySet.dateTimeFrom.Text.Trim) AndAlso FrmProcessParametersQuerySet.ckDateEnd.Checked AndAlso Not String.IsNullOrEmpty(FrmProcessParametersQuerySet.dateTimeTo.Text.Trim) Then
                strSql.Append("AND a.intime between '" & FrmProcessParametersQuerySet.dateTimeFrom.Text.Trim & "' and '" & FrmProcessParametersQuerySet.dateTimeTo.Text.Trim & "' ")
            End If
            pageData.QuerySQL = GetSql() + strSql.ToString
            Pager1.PageCount = 1
            Pager1.Bind()
            Pager1.Enabled = True
            dgvBind()
            Me.IsDialogQuery = True
            Me.DialogSqlWhere = strSql.ToString
            ' Me.sqlWhere = FrmProcessParametersQuerySet.sqlWhere
        End If
        '  LoadDataToDatagridview(Me.sqlWhere)
    End Sub

    Private Function Pager1_EventPaging(e As SysBasicClass.EventPagingArg) As System.Int32 Handles Pager1.EventPaging
        Return dgvBind()
    End Function

    Private Sub lkFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkFile.LinkClicked
        ExcelUtils.GetExcelTemplate(VbCommClass.VbCommClass.PrintDataModle, "加工参数工艺资料上传模板")
    End Sub

#Region "上传附件"
    Private Sub tsBtnUploadFile_Click(sender As Object, e As EventArgs) Handles tsBtnUploadFile.Click
        Dim frmUploadFile = New FrmUploadFile()
        Dim dgvr As DataGridViewRow = dgvProcessParameter.CurrentRow
        frmUploadFile.DuanZi = dgvr.Cells(1).Value
        frmUploadFile.XianCai = dgvr.Cells(3).Value
        frmUploadFile.FilePathName = dgvr.Cells(ProcessGrid.FilePath).Value
        frmUploadFile.ShowDialog()
        If (frmUploadFile.DialogResult = Windows.Forms.DialogResult.OK) Then
            LoadProcessParameters()
        End If
    End Sub
#End Region


    Private Sub LinkFileName_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkFileName.LinkClicked
        If File.Exists(LinkPath.Text.Trim) Then
            'Dim ssf As SaveFileDialog = New SaveFileDialog()
            'ssf.RestoreDirectory = True
            'ssf.Filter = "*.ppt|*.ppt|*.xls|*.xls|*.xlsx|*.xlsx|*.pdf|*,pdf|*.doc|*.doc|*.docx|*.docx|CAD文件|*.dwg"
            'ssf.FileName = LinkFileName.Text.Trim
            'If ssf.ShowDialog() = DialogResult.OK Then
            '    Dim by As Byte() = File.ReadAllBytes(LinkPath.Text.Trim)
            '    Using fs As FileStream = ssf.OpenFile()
            '        fs.Write(by, 0, by.Length)
            '        fs.Dispose()
            '    End Using
            'End If
            System.Diagnostics.Process.Start(LinkPath.Text.Trim)
        End If

    End Sub
End Class


