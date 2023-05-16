<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRunCardHSL
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRunCardHSL))
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SideBar1 = New DevComponents.DotNetBar.SideBar()
        Me.sbPanelFinish = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelAudit = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelUnfinish = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.dgvRunCardHeader = New System.Windows.Forms.DataGridView()
        Me.ColChk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeDest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrawingVer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Shape = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeriesName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrawingFilePath = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ZStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinishSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuHeader = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiHeaderCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderModify = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderReject = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderLookLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvRunCardBody = New System.Windows.Forms.DataGridView()
        Me.StationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationSQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Equipment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessStandard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BodyRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BodyInTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StaionHour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BodyPartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SectionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuBody = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiBodyCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyModify = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyConfirm = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolCopyBodyStation = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyStationLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvPartNumber = New System.Windows.Forms.DataGridView()
        Me.ColPartIDChk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EWPartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartTypeDest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartDESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuDetail = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiPartAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiPartDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnCopy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAudit = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.btnExportHeader = New System.Windows.Forms.ToolStripButton()
        Me.toolExportChangeLog = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtCount = New System.Windows.Forms.ToolStripTextBox()
        Me.txtSearch = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnClear = New DevComponents.DotNetBar.ButtonX()
        Me.CheckAll = New System.Windows.Forms.CheckBox()
        CType(Me.dgvRunCardHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuHeader.SuspendLayout()
        CType(Me.dgvRunCardBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuBody.SuspendLayout()
        CType(Me.dgvPartNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuDetail.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SideBar1
        '
        Me.SideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.SideBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SideBar1.BorderStyle = DevComponents.DotNetBar.eBorderType.None
        Me.SideBar1.ExpandedPanel = Me.sbPanelFinish
        Me.SideBar1.Location = New System.Drawing.Point(0, 47)
        Me.SideBar1.Name = "SideBar1"
        Me.SideBar1.Panels.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.sbPanelFinish, Me.sbPanelAudit, Me.sbPanelUnfinish})
        Me.SideBar1.Size = New System.Drawing.Size(142, 347)
        Me.SideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SideBar1.TabIndex = 5
        Me.SideBar1.Text = "SideBar1"
        '
        'sbPanelFinish
        '
        Me.sbPanelFinish.FontBold = True
        Me.sbPanelFinish.Name = "sbPanelFinish"
        Me.sbPanelFinish.Text = "已生效"
        '
        'sbPanelAudit
        '
        Me.sbPanelAudit.FontBold = True
        Me.sbPanelAudit.Name = "sbPanelAudit"
        Me.sbPanelAudit.Text = "待审核"
        '
        'sbPanelUnfinish
        '
        Me.sbPanelUnfinish.FontBold = True
        Me.sbPanelUnfinish.Name = "sbPanelUnfinish"
        Me.sbPanelUnfinish.Text = "制作中"
        '
        'dgvRunCardHeader
        '
        Me.dgvRunCardHeader.AllowUserToAddRows = False
        Me.dgvRunCardHeader.AllowUserToDeleteRows = False
        Me.dgvRunCardHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRunCardHeader.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRunCardHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRunCardHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColChk, Me.PartID, Me.TypeDest, Me.TotalHours, Me.DESCRIPTION, Me.DrawingVer, Me.Shape, Me.SeriesName, Me.FileNO, Me.DrawingFilePath, Me.ZStatus, Me.UserID, Me.InTime, Me.ModifyTime, Me.Remark, Me.Status, Me.FinishSize})
        Me.dgvRunCardHeader.ContextMenuStrip = Me.ContextMenuHeader
        Me.dgvRunCardHeader.Location = New System.Drawing.Point(143, 26)
        Me.dgvRunCardHeader.Name = "dgvRunCardHeader"
        Me.dgvRunCardHeader.RowHeadersVisible = False
        Me.dgvRunCardHeader.RowTemplate.Height = 23
        Me.dgvRunCardHeader.Size = New System.Drawing.Size(882, 211)
        Me.dgvRunCardHeader.TabIndex = 6
        '
        'ColChk
        '
        Me.ColChk.FalseValue = "False"
        Me.ColChk.HeaderText = "选择"
        Me.ColChk.Name = "ColChk"
        Me.ColChk.TrueValue = "True"
        Me.ColChk.Width = 60
        '
        'PartID
        '
        Me.PartID.DataPropertyName = "PartID"
        Me.PartID.HeaderText = "料号"
        Me.PartID.Name = "PartID"
        Me.PartID.ReadOnly = True
        Me.PartID.Width = 120
        '
        'TypeDest
        '
        Me.TypeDest.DataPropertyName = "TypeDest"
        Me.TypeDest.HeaderText = "描述"
        Me.TypeDest.Name = "TypeDest"
        Me.TypeDest.ReadOnly = True
        '
        'TotalHours
        '
        Me.TotalHours.DataPropertyName = "TotalHours"
        Me.TotalHours.HeaderText = "总工时"
        Me.TotalHours.Name = "TotalHours"
        Me.TotalHours.ReadOnly = True
        Me.TotalHours.Width = 65
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.DataPropertyName = "DESCRIPTION"
        Me.DESCRIPTION.HeaderText = "规格"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.ReadOnly = True
        '
        'DrawingVer
        '
        Me.DrawingVer.DataPropertyName = "DrawingVer"
        Me.DrawingVer.HeaderText = "版本"
        Me.DrawingVer.Name = "DrawingVer"
        Me.DrawingVer.ReadOnly = True
        Me.DrawingVer.Width = 55
        '
        'Shape
        '
        Me.Shape.DataPropertyName = "Shape"
        Me.Shape.HeaderText = "形态"
        Me.Shape.Name = "Shape"
        Me.Shape.ReadOnly = True
        Me.Shape.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'SeriesName
        '
        Me.SeriesName.DataPropertyName = "SeriesName"
        Me.SeriesName.HeaderText = "产品系列"
        Me.SeriesName.Name = "SeriesName"
        Me.SeriesName.ReadOnly = True
        '
        'FileNO
        '
        Me.FileNO.DataPropertyName = "FileNO"
        Me.FileNO.HeaderText = "文件编号"
        Me.FileNO.Name = "FileNO"
        Me.FileNO.ReadOnly = True
        '
        'DrawingFilePath
        '
        Me.DrawingFilePath.DataPropertyName = "DrawingFilePath"
        DataGridViewCellStyle51.ForeColor = System.Drawing.Color.Red
        Me.DrawingFilePath.DefaultCellStyle = DataGridViewCellStyle51
        Me.DrawingFilePath.HeaderText = "图纸文件"
        Me.DrawingFilePath.LinkColor = System.Drawing.Color.Red
        Me.DrawingFilePath.Name = "DrawingFilePath"
        Me.DrawingFilePath.ReadOnly = True
        Me.DrawingFilePath.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DrawingFilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DrawingFilePath.VisitedLinkColor = System.Drawing.Color.Red
        Me.DrawingFilePath.Width = 78
        '
        'ZStatus
        '
        Me.ZStatus.DataPropertyName = "ZStatus"
        Me.ZStatus.HeaderText = "制作状态"
        Me.ZStatus.Name = "ZStatus"
        Me.ZStatus.ReadOnly = True
        Me.ZStatus.Width = 78
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "创建人"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        Me.UserID.Width = 70
        '
        'InTime
        '
        Me.InTime.DataPropertyName = "InTime"
        Me.InTime.HeaderText = "创建时间"
        Me.InTime.Name = "InTime"
        Me.InTime.ReadOnly = True
        '
        'ModifyTime
        '
        Me.ModifyTime.DataPropertyName = "ModifyTime"
        Me.ModifyTime.HeaderText = "修改时间"
        Me.ModifyTime.Name = "ModifyTime"
        Me.ModifyTime.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "状态ID"
        Me.Status.Name = "Status"
        Me.Status.Visible = False
        '
        'FinishSize
        '
        Me.FinishSize.DataPropertyName = "FinishSize"
        Me.FinishSize.HeaderText = "FinishSize"
        Me.FinishSize.Name = "FinishSize"
        Me.FinishSize.Visible = False
        '
        'ContextMenuHeader
        '
        Me.ContextMenuHeader.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiHeaderCopy, Me.tsmiHeaderAdd, Me.tsmiHeaderModify, Me.tsmiHeaderDelete, Me.tsmiHeaderSearch, Me.tsmiHeaderCancel, Me.tsmiHeaderReject, Me.tsmiHeaderPrint, Me.tsmiHeaderImport, Me.tsmiHeaderExport, Me.tsmiHeaderLookLog})
        Me.ContextMenuHeader.Name = "ContextMenuStrip1"
        Me.ContextMenuHeader.Size = New System.Drawing.Size(149, 246)
        '
        'tsmiHeaderCopy
        '
        Me.tsmiHeaderCopy.Image = CType(resources.GetObject("tsmiHeaderCopy.Image"), System.Drawing.Image)
        Me.tsmiHeaderCopy.Name = "tsmiHeaderCopy"
        Me.tsmiHeaderCopy.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderCopy.Tag = "复制"
        Me.tsmiHeaderCopy.Text = "复制(&C)"
        '
        'tsmiHeaderAdd
        '
        Me.tsmiHeaderAdd.Image = CType(resources.GetObject("tsmiHeaderAdd.Image"), System.Drawing.Image)
        Me.tsmiHeaderAdd.Name = "tsmiHeaderAdd"
        Me.tsmiHeaderAdd.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderAdd.Tag = "新增"
        Me.tsmiHeaderAdd.Text = "新增(&N)"
        '
        'tsmiHeaderModify
        '
        Me.tsmiHeaderModify.Image = CType(resources.GetObject("tsmiHeaderModify.Image"), System.Drawing.Image)
        Me.tsmiHeaderModify.Name = "tsmiHeaderModify"
        Me.tsmiHeaderModify.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderModify.Tag = "修改"
        Me.tsmiHeaderModify.Text = "修改(&M)"
        '
        'tsmiHeaderDelete
        '
        Me.tsmiHeaderDelete.Image = CType(resources.GetObject("tsmiHeaderDelete.Image"), System.Drawing.Image)
        Me.tsmiHeaderDelete.Name = "tsmiHeaderDelete"
        Me.tsmiHeaderDelete.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderDelete.Tag = "删除"
        Me.tsmiHeaderDelete.Text = "删除(&D)"
        '
        'tsmiHeaderSearch
        '
        Me.tsmiHeaderSearch.Image = CType(resources.GetObject("tsmiHeaderSearch.Image"), System.Drawing.Image)
        Me.tsmiHeaderSearch.Name = "tsmiHeaderSearch"
        Me.tsmiHeaderSearch.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderSearch.Tag = "查询"
        Me.tsmiHeaderSearch.Text = "查询(&Q)"
        '
        'tsmiHeaderCancel
        '
        Me.tsmiHeaderCancel.Image = CType(resources.GetObject("tsmiHeaderCancel.Image"), System.Drawing.Image)
        Me.tsmiHeaderCancel.Name = "tsmiHeaderCancel"
        Me.tsmiHeaderCancel.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderCancel.Text = "取消生效(&C)"
        '
        'tsmiHeaderReject
        '
        Me.tsmiHeaderReject.Image = CType(resources.GetObject("tsmiHeaderReject.Image"), System.Drawing.Image)
        Me.tsmiHeaderReject.Name = "tsmiHeaderReject"
        Me.tsmiHeaderReject.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderReject.Tag = "驳回"
        Me.tsmiHeaderReject.Text = "驳回(&R)"
        '
        'tsmiHeaderPrint
        '
        Me.tsmiHeaderPrint.Image = CType(resources.GetObject("tsmiHeaderPrint.Image"), System.Drawing.Image)
        Me.tsmiHeaderPrint.Name = "tsmiHeaderPrint"
        Me.tsmiHeaderPrint.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderPrint.Tag = "打印"
        Me.tsmiHeaderPrint.Text = "打印(&P)"
        '
        'tsmiHeaderImport
        '
        Me.tsmiHeaderImport.Image = Global.RCard.My.Resources.Resources.query
        Me.tsmiHeaderImport.Name = "tsmiHeaderImport"
        Me.tsmiHeaderImport.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderImport.Text = "导入"
        '
        'tsmiHeaderExport
        '
        Me.tsmiHeaderExport.Image = CType(resources.GetObject("tsmiHeaderExport.Image"), System.Drawing.Image)
        Me.tsmiHeaderExport.Name = "tsmiHeaderExport"
        Me.tsmiHeaderExport.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderExport.Text = "导出(&E)"
        '
        'tsmiHeaderLookLog
        '
        Me.tsmiHeaderLookLog.Name = "tsmiHeaderLookLog"
        Me.tsmiHeaderLookLog.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderLookLog.Text = "查看变更记录"
        '
        'dgvRunCardBody
        '
        Me.dgvRunCardBody.AllowUserToAddRows = False
        Me.dgvRunCardBody.AllowUserToDeleteRows = False
        Me.dgvRunCardBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRunCardBody.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvRunCardBody.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvRunCardBody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRunCardBody.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StationID, Me.StationSQ, Me.StationName, Me.WorkingHours, Me.Equipment, Me.ProcessStandard, Me.BodyRemark, Me.SOP, Me.Uid, Me.BodyInTime, Me.StaionHour, Me.BodyPartID, Me.SectionID})
        Me.dgvRunCardBody.ContextMenuStrip = Me.ContextMenuBody
        Me.dgvRunCardBody.Location = New System.Drawing.Point(143, 237)
        Me.dgvRunCardBody.Name = "dgvRunCardBody"
        Me.dgvRunCardBody.RowHeadersVisible = False
        Me.dgvRunCardBody.RowTemplate.Height = 23
        Me.dgvRunCardBody.Size = New System.Drawing.Size(616, 157)
        Me.dgvRunCardBody.TabIndex = 7
        '
        'StationID
        '
        Me.StationID.DataPropertyName = "StationID"
        Me.StationID.HeaderText = "StationID"
        Me.StationID.Name = "StationID"
        Me.StationID.ReadOnly = True
        Me.StationID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StationID.Visible = False
        '
        'StationSQ
        '
        Me.StationSQ.DataPropertyName = "StationSQ"
        DataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle52.Font = New System.Drawing.Font("宋体", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.StationSQ.DefaultCellStyle = DataGridViewCellStyle52
        Me.StationSQ.HeaderText = "工序"
        Me.StationSQ.Name = "StationSQ"
        Me.StationSQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StationSQ.Width = 52
        '
        'StationName
        '
        Me.StationName.DataPropertyName = "StationName"
        Me.StationName.HeaderText = "工站"
        Me.StationName.Name = "StationName"
        Me.StationName.ReadOnly = True
        Me.StationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StationName.Width = 120
        '
        'WorkingHours
        '
        Me.WorkingHours.DataPropertyName = "WorkingHours"
        Me.WorkingHours.HeaderText = "工时"
        Me.WorkingHours.Name = "WorkingHours"
        Me.WorkingHours.ReadOnly = True
        Me.WorkingHours.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.WorkingHours.Width = 75
        '
        'Equipment
        '
        Me.Equipment.DataPropertyName = "Equipment"
        Me.Equipment.HeaderText = "设备治具"
        Me.Equipment.Name = "Equipment"
        Me.Equipment.ReadOnly = True
        Me.Equipment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ProcessStandard
        '
        Me.ProcessStandard.DataPropertyName = "ProcessStandard"
        DataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProcessStandard.DefaultCellStyle = DataGridViewCellStyle53
        Me.ProcessStandard.HeaderText = "工艺标准"
        Me.ProcessStandard.Name = "ProcessStandard"
        Me.ProcessStandard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessStandard.Width = 310
        '
        'BodyRemark
        '
        Me.BodyRemark.DataPropertyName = "Remark"
        DataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BodyRemark.DefaultCellStyle = DataGridViewCellStyle54
        Me.BodyRemark.HeaderText = "备注"
        Me.BodyRemark.Name = "BodyRemark"
        Me.BodyRemark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BodyRemark.Width = 120
        '
        'SOP
        '
        Me.SOP.DataPropertyName = "SOP"
        Me.SOP.HeaderText = "SOP"
        Me.SOP.Name = "SOP"
        Me.SOP.ReadOnly = True
        Me.SOP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SOP.Visible = False
        '
        'Uid
        '
        Me.Uid.DataPropertyName = "UserId"
        Me.Uid.HeaderText = "修改人"
        Me.Uid.Name = "Uid"
        Me.Uid.ReadOnly = True
        Me.Uid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Uid.Width = 75
        '
        'BodyInTime
        '
        Me.BodyInTime.DataPropertyName = "InTime"
        DataGridViewCellStyle55.NullValue = Nothing
        Me.BodyInTime.DefaultCellStyle = DataGridViewCellStyle55
        Me.BodyInTime.HeaderText = "修改时间"
        Me.BodyInTime.Name = "BodyInTime"
        Me.BodyInTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BodyInTime.Width = 110
        '
        'StaionHour
        '
        Me.StaionHour.DataPropertyName = "StaionHour"
        Me.StaionHour.HeaderText = "StaionHour"
        Me.StaionHour.Name = "StaionHour"
        Me.StaionHour.ReadOnly = True
        Me.StaionHour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StaionHour.Visible = False
        '
        'BodyPartID
        '
        Me.BodyPartID.DataPropertyName = "PartID"
        Me.BodyPartID.HeaderText = "BodyPartID"
        Me.BodyPartID.Name = "BodyPartID"
        Me.BodyPartID.ReadOnly = True
        Me.BodyPartID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.BodyPartID.Visible = False
        '
        'SectionID
        '
        Me.SectionID.DataPropertyName = "SectionID"
        Me.SectionID.HeaderText = "SectionID"
        Me.SectionID.Name = "SectionID"
        Me.SectionID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SectionID.Visible = False
        '
        'ContextMenuBody
        '
        Me.ContextMenuBody.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiBodyCopy, Me.tsmiBodyAdd, Me.tsmiBodyModify, Me.tsmiBodyConfirm, Me.tsmiBodyInsert, Me.tsmiBodyDelete, Me.RToolStripMenuItem, Me.ToolCopyBodyStation, Me.tsmiBodyStationLog})
        Me.ContextMenuBody.Name = "ContextMenuStrip1"
        Me.ContextMenuBody.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuBody.Size = New System.Drawing.Size(149, 202)
        '
        'tsmiBodyCopy
        '
        Me.tsmiBodyCopy.Image = CType(resources.GetObject("tsmiBodyCopy.Image"), System.Drawing.Image)
        Me.tsmiBodyCopy.Name = "tsmiBodyCopy"
        Me.tsmiBodyCopy.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyCopy.Tag = "复制"
        Me.tsmiBodyCopy.Text = "复制(&C)"
        '
        'tsmiBodyAdd
        '
        Me.tsmiBodyAdd.Image = CType(resources.GetObject("tsmiBodyAdd.Image"), System.Drawing.Image)
        Me.tsmiBodyAdd.Name = "tsmiBodyAdd"
        Me.tsmiBodyAdd.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyAdd.Tag = "新增"
        Me.tsmiBodyAdd.Text = "新增(&N)"
        '
        'tsmiBodyModify
        '
        Me.tsmiBodyModify.Image = CType(resources.GetObject("tsmiBodyModify.Image"), System.Drawing.Image)
        Me.tsmiBodyModify.Name = "tsmiBodyModify"
        Me.tsmiBodyModify.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyModify.Tag = "修改"
        Me.tsmiBodyModify.Text = "修改(&M)"
        '
        'tsmiBodyConfirm
        '
        Me.tsmiBodyConfirm.Image = CType(resources.GetObject("tsmiBodyConfirm.Image"), System.Drawing.Image)
        Me.tsmiBodyConfirm.Name = "tsmiBodyConfirm"
        Me.tsmiBodyConfirm.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyConfirm.Tag = "确认"
        Me.tsmiBodyConfirm.Text = "确认(&F)"
        '
        'tsmiBodyInsert
        '
        Me.tsmiBodyInsert.Image = CType(resources.GetObject("tsmiBodyInsert.Image"), System.Drawing.Image)
        Me.tsmiBodyInsert.Name = "tsmiBodyInsert"
        Me.tsmiBodyInsert.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyInsert.Tag = "插入"
        Me.tsmiBodyInsert.Text = "插入(&I)"
        '
        'tsmiBodyDelete
        '
        Me.tsmiBodyDelete.Image = CType(resources.GetObject("tsmiBodyDelete.Image"), System.Drawing.Image)
        Me.tsmiBodyDelete.Name = "tsmiBodyDelete"
        Me.tsmiBodyDelete.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyDelete.Tag = "删除"
        Me.tsmiBodyDelete.Text = "删除(&D)"
        '
        'RToolStripMenuItem
        '
        Me.RToolStripMenuItem.Image = CType(resources.GetObject("RToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RToolStripMenuItem.Name = "RToolStripMenuItem"
        Me.RToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.RToolStripMenuItem.Text = "重置(R)"
        '
        'ToolCopyBodyStation
        '
        Me.ToolCopyBodyStation.Image = CType(resources.GetObject("ToolCopyBodyStation.Image"), System.Drawing.Image)
        Me.ToolCopyBodyStation.Name = "ToolCopyBodyStation"
        Me.ToolCopyBodyStation.Size = New System.Drawing.Size(148, 22)
        Me.ToolCopyBodyStation.Text = "复制工站"
        '
        'tsmiBodyStationLog
        '
        Me.tsmiBodyStationLog.Name = "tsmiBodyStationLog"
        Me.tsmiBodyStationLog.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyStationLog.Text = "工站变更记录"
        '
        'dgvPartNumber
        '
        Me.dgvPartNumber.AllowUserToAddRows = False
        Me.dgvPartNumber.AllowUserToDeleteRows = False
        Me.dgvPartNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPartNumber.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPartNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartNumber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPartIDChk, Me.EWPartNumber, Me.PartTypeDest, Me.PartDESCRIPTION})
        Me.dgvPartNumber.ContextMenuStrip = Me.ContextMenuDetail
        Me.dgvPartNumber.Location = New System.Drawing.Point(760, 237)
        Me.dgvPartNumber.Name = "dgvPartNumber"
        Me.dgvPartNumber.RowHeadersVisible = False
        Me.dgvPartNumber.RowTemplate.Height = 23
        Me.dgvPartNumber.Size = New System.Drawing.Size(265, 157)
        Me.dgvPartNumber.TabIndex = 8
        '
        'ColPartIDChk
        '
        Me.ColPartIDChk.DataPropertyName = "False"
        Me.ColPartIDChk.FalseValue = "False"
        Me.ColPartIDChk.HeaderText = "选择"
        Me.ColPartIDChk.Name = "ColPartIDChk"
        Me.ColPartIDChk.TrueValue = "True"
        Me.ColPartIDChk.Width = 40
        '
        'EWPartNumber
        '
        Me.EWPartNumber.DataPropertyName = "partid"
        Me.EWPartNumber.HeaderText = "料号"
        Me.EWPartNumber.Name = "EWPartNumber"
        Me.EWPartNumber.ReadOnly = True
        '
        'PartTypeDest
        '
        Me.PartTypeDest.DataPropertyName = "TypeDest"
        Me.PartTypeDest.HeaderText = "品名"
        Me.PartTypeDest.Name = "PartTypeDest"
        Me.PartTypeDest.ReadOnly = True
        '
        'PartDESCRIPTION
        '
        Me.PartDESCRIPTION.DataPropertyName = "DESCRIPTION"
        Me.PartDESCRIPTION.HeaderText = "规格"
        Me.PartDESCRIPTION.Name = "PartDESCRIPTION"
        Me.PartDESCRIPTION.ReadOnly = True
        '
        'ContextMenuDetail
        '
        Me.ContextMenuDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiPartAdd, Me.tsmiPartDelete})
        Me.ContextMenuDetail.Name = "ContextMenuStrip2"
        Me.ContextMenuDetail.Size = New System.Drawing.Size(143, 48)
        '
        'tsmiPartAdd
        '
        Me.tsmiPartAdd.Checked = True
        Me.tsmiPartAdd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmiPartAdd.Image = CType(resources.GetObject("tsmiPartAdd.Image"), System.Drawing.Image)
        Me.tsmiPartAdd.Name = "tsmiPartAdd"
        Me.tsmiPartAdd.Size = New System.Drawing.Size(142, 22)
        Me.tsmiPartAdd.Tag = "添加料件"
        Me.tsmiPartAdd.Text = "添加料件(&N)"
        '
        'tsmiPartDelete
        '
        Me.tsmiPartDelete.Image = CType(resources.GetObject("tsmiPartDelete.Image"), System.Drawing.Image)
        Me.tsmiPartDelete.Name = "tsmiPartDelete"
        Me.tsmiPartDelete.Size = New System.Drawing.Size(142, 22)
        Me.tsmiPartDelete.Tag = "删除"
        Me.tsmiPartDelete.Text = "删除(&D)"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "00013.ico")
        Me.ImageList1.Images.SetKeyName(1, "00028.ico")
        Me.ImageList1.Images.SetKeyName(2, "00015.ico")
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCopy, Me.ToolStripSeparator10, Me.btnPrint, Me.ToolStripSeparator1, Me.btnAudit, Me.toolStripSeparator3, Me.btnRefresh, Me.btnExportHeader, Me.toolExportChangeLog, Me.ToolStripSeparator9, Me.btnExit, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.txtCount})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1026, 25)
        Me.toolStrip1.TabIndex = 9
        Me.toolStrip1.Text = "toolStrip1"
        '
        'btnCopy
        '
        Me.btnCopy.Image = CType(resources.GetObject("btnCopy.Image"), System.Drawing.Image)
        Me.btnCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(91, 22)
        Me.btnCopy.Tag = "复制流程"
        Me.btnCopy.Text = "复制流程(&S)"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(71, 22)
        Me.btnPrint.Text = "打 印(&P)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnAudit
        '
        Me.btnAudit.Image = CType(resources.GetObject("btnAudit.Image"), System.Drawing.Image)
        Me.btnAudit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAudit.Name = "btnAudit"
        Me.btnAudit.Size = New System.Drawing.Size(67, 22)
        Me.btnAudit.Tag = "审核"
        Me.btnAudit.Text = "审核(&S)"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 22)
        Me.btnRefresh.Text = "刷 新(&R)"
        Me.btnRefresh.ToolTipText = "刷新"
        '
        'btnExportHeader
        '
        Me.btnExportHeader.Image = CType(resources.GetObject("btnExportHeader.Image"), System.Drawing.Image)
        Me.btnExportHeader.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportHeader.Name = "btnExportHeader"
        Me.btnExportHeader.Size = New System.Drawing.Size(91, 22)
        Me.btnExportHeader.Text = "导出单头(&P)"
        '
        'toolExportChangeLog
        '
        Me.toolExportChangeLog.Image = Global.RCard.My.Resources.Resources.excel
        Me.toolExportChangeLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExportChangeLog.Name = "toolExportChangeLog"
        Me.toolExportChangeLog.Size = New System.Drawing.Size(115, 22)
        Me.toolExportChangeLog.Text = "查看变更履历(&P)"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 22)
        Me.btnExit.Text = "退 出(&X)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripLabel1.Text = "记录数:"
        '
        'txtCount
        '
        Me.txtCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(100, 25)
        '
        'txtSearch
        '
        '
        '
        '
        Me.txtSearch.Border.Class = "TextBoxBorder"
        Me.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSearch.Location = New System.Drawing.Point(0, 25)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(122, 21)
        Me.txtSearch.TabIndex = 10
        '
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(121, 24)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(22, 23)
        Me.btnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnClear.TabIndex = 11
        Me.btnClear.Text = "ButtonX1"
        '
        'CheckAll
        '
        Me.CheckAll.Location = New System.Drawing.Point(181, 29)
        Me.CheckAll.Name = "CheckAll"
        Me.CheckAll.Size = New System.Drawing.Size(15, 14)
        Me.CheckAll.TabIndex = 115
        Me.CheckAll.UseVisualStyleBackColor = True
        '
        'FrmRunCardHSL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 394)
        Me.Controls.Add(Me.CheckAll)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.dgvPartNumber)
        Me.Controls.Add(Me.dgvRunCardBody)
        Me.Controls.Add(Me.dgvRunCardHeader)
        Me.Controls.Add(Me.SideBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRunCardHSL"
        Me.Text = "标准工艺流程设计-高速线"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvRunCardHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuHeader.ResumeLayout(False)
        CType(Me.dgvRunCardBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuBody.ResumeLayout(False)
        CType(Me.dgvPartNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuDetail.ResumeLayout(False)
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SideBar1 As DevComponents.DotNetBar.SideBar
    Friend WithEvents sbPanelFinish As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents sbPanelAudit As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents sbPanelUnfinish As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents dgvRunCardHeader As System.Windows.Forms.DataGridView
    Friend WithEvents dgvRunCardBody As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPartNumber As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenuHeader As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiHeaderCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderModify As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderReject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderLookLog As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents btnCopy As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnAudit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Private WithEvents btnExportHeader As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExportChangeLog As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtCount As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ContextMenuBody As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiBodyCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyModify As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyConfirm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolCopyBodyStation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyStationLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuDetail As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiPartAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiPartDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSearch As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tsmiHeaderDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckAll As System.Windows.Forms.CheckBox
    Friend WithEvents tsmiBodyInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColPartIDChk As DataGridViewCheckBoxColumn
    Friend WithEvents EWPartNumber As DataGridViewTextBoxColumn
    Friend WithEvents PartTypeDest As DataGridViewTextBoxColumn
    Friend WithEvents PartDESCRIPTION As DataGridViewTextBoxColumn
    Friend WithEvents StationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationSQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Equipment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessStandard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BodyRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Uid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BodyInTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StaionHour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BodyPartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SectionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColChk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeDest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrawingVer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Shape As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeriesName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DrawingFilePath As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ZStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifyTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinishSize As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
