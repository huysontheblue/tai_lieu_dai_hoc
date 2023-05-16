<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOnlineSop
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOnlineSop))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.sbStatus = New DevComponents.DotNetBar.SideBar()
        Me.sbPanelFinish = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelDCC = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelApproval = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelProd = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelQC = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelVerify = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelMake = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSearch = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgvSopBody = New System.Windows.Forms.DataGridView()
        Me.Column21 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvSopHeader = New System.Windows.Forms.DataGridView()
        Me.Column11 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarkSign = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBoxItem1 = New DevComponents.DotNetBar.TextBoxItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtCount = New System.Windows.Forms.ToolStripTextBox()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnCopySop = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnAudit = New System.Windows.Forms.ToolStripButton()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExportSop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExportHeader = New System.Windows.Forms.ToolStripButton()
        Me.btnEmail = New System.Windows.Forms.ToolStripButton()
        Me.toolExportChangeLog = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslMsg = New System.Windows.Forms.ToolStripLabel()
        Me.ContextMenuHeader = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiHeaderSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderModify = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiHeaderDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderReject = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderRetract = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderComfirm = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiHeaderPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderChangeLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuBody = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiBodyDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyModify = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiBodyCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyCopyRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyPasteRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiRemark = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyExprot = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStationChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvSopBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvSopHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStrip1.SuspendLayout()
        Me.ContextMenuHeader.SuspendLayout()
        Me.ContextMenuBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.sbStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Splitter1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(941, 421)
        Me.SplitContainer1.SplitterDistance = 130
        Me.SplitContainer1.TabIndex = 4
        '
        'sbStatus
        '
        Me.sbStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.sbStatus.BorderStyle = DevComponents.DotNetBar.eBorderType.None
        Me.sbStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sbStatus.ExpandedPanel = Me.sbPanelFinish
        Me.sbStatus.Location = New System.Drawing.Point(0, 24)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Panels.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.sbPanelFinish, Me.sbPanelDCC, Me.sbPanelApproval, Me.sbPanelProd, Me.sbPanelQC, Me.sbPanelVerify, Me.sbPanelMake})
        Me.sbStatus.Size = New System.Drawing.Size(130, 397)
        Me.sbStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbStatus.TabIndex = 65
        '
        'sbPanelFinish
        '
        Me.sbPanelFinish.FontBold = True
        Me.sbPanelFinish.Name = "sbPanelFinish"
        Me.sbPanelFinish.Text = "已生效"
        '
        'sbPanelDCC
        '
        Me.sbPanelDCC.FontBold = True
        Me.sbPanelDCC.Name = "sbPanelDCC"
        Me.sbPanelDCC.Text = "待DCC审核"
        '
        'sbPanelApproval
        '
        Me.sbPanelApproval.FontBold = True
        Me.sbPanelApproval.Name = "sbPanelApproval"
        Me.sbPanelApproval.Text = "待核准"
        '
        'sbPanelProd
        '
        Me.sbPanelProd.FontBold = True
        Me.sbPanelProd.Name = "sbPanelProd"
        Me.sbPanelProd.Text = "待生产审核"
        '
        'sbPanelQC
        '
        Me.sbPanelQC.FontBold = True
        Me.sbPanelQC.Name = "sbPanelQC"
        Me.sbPanelQC.Text = "待品管审核"
        '
        'sbPanelVerify
        '
        Me.sbPanelVerify.FontBold = True
        Me.sbPanelVerify.Name = "sbPanelVerify"
        Me.sbPanelVerify.Text = "待审核"
        '
        'sbPanelMake
        '
        Me.sbPanelMake.FontBold = True
        Me.sbPanelMake.Name = "sbPanelMake"
        Me.sbPanelMake.Text = "制作中"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(130, 24)
        Me.Panel1.TabIndex = 0
        '
        'txtSearch
        '
        '
        '
        '
        Me.txtSearch.BackgroundStyle.Class = "TextBoxBorder"
        Me.txtSearch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSearch.ButtonCustom.Visible = True
        Me.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearch.Location = New System.Drawing.Point(0, 0)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(130, 24)
        Me.txtSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtSearch.TabIndex = 3
        Me.txtSearch.Text = ""
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgvSopBody)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 146)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(807, 275)
        Me.Panel3.TabIndex = 1
        '
        'dgvSopBody
        '
        Me.dgvSopBody.AllowUserToAddRows = False
        Me.dgvSopBody.AllowUserToDeleteRows = False
        Me.dgvSopBody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSopBody.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column21, Me.Column12, Me.Column13, Me.Column14, Me.Column20, Me.Column24, Me.Column15, Me.Column16, Me.Column17, Me.Column23, Me.Column18})
        Me.dgvSopBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSopBody.Location = New System.Drawing.Point(0, 0)
        Me.dgvSopBody.Name = "dgvSopBody"
        Me.dgvSopBody.RowHeadersVisible = False
        Me.dgvSopBody.RowTemplate.Height = 23
        Me.dgvSopBody.Size = New System.Drawing.Size(807, 275)
        Me.dgvSopBody.TabIndex = 0
        '
        'Column21
        '
        Me.Column21.FalseValue = "False"
        Me.Column21.HeaderText = "选择"
        Me.Column21.Name = "Column21"
        Me.Column21.TrueValue = "True"
        Me.Column21.Width = 50
        '
        'Column12
        '
        Me.Column12.DataPropertyName = "StationName"
        Me.Column12.HeaderText = "工站名称"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 150
        '
        'Column13
        '
        Me.Column13.DataPropertyName = "VerNo"
        Me.Column13.HeaderText = "版本"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.DataPropertyName = "EcnNo"
        Me.Column14.HeaderText = "ECN编号"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column20
        '
        Me.Column20.DataPropertyName = "PageSize"
        Me.Column20.HeaderText = "页次"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        '
        'Column24
        '
        Me.Column24.DataPropertyName = "IsFocusStation"
        Me.Column24.HeaderText = "重要程度"
        Me.Column24.Name = "Column24"
        Me.Column24.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.DataPropertyName = "UserName"
        Me.Column15.HeaderText = "修改人"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.DataPropertyName = "ModifyTime"
        Me.Column16.HeaderText = "修改日期"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 150
        '
        'Column17
        '
        Me.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column17.DataPropertyName = "Remark"
        Me.Column17.HeaderText = "备注"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        '
        'Column23
        '
        Me.Column23.DataPropertyName = "IsColor"
        Me.Column23.HeaderText = "是否颜色区分"
        Me.Column23.Name = "Column23"
        Me.Column23.Visible = False
        '
        'Column18
        '
        Me.Column18.DataPropertyName = "ID"
        Me.Column18.HeaderText = "ID"
        Me.Column18.Name = "Column18"
        Me.Column18.Visible = False
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 143)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(807, 3)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvSopHeader)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(807, 143)
        Me.Panel2.TabIndex = 0
        '
        'dgvSopHeader
        '
        Me.dgvSopHeader.AllowUserToAddRows = False
        Me.dgvSopHeader.AllowUserToDeleteRows = False
        Me.dgvSopHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSopHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column11, Me.Column1, Me.Column6, Me.Column19, Me.Column2, Me.Column4, Me.Column22, Me.Column5, Me.Column3, Me.Column10, Me.Column7, Me.Column8, Me.Column9, Me.Column25, Me.Column26, Me.Column27, Me.RemarkSign})
        Me.dgvSopHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSopHeader.Location = New System.Drawing.Point(0, 0)
        Me.dgvSopHeader.MultiSelect = False
        Me.dgvSopHeader.Name = "dgvSopHeader"
        Me.dgvSopHeader.RowHeadersVisible = False
        Me.dgvSopHeader.RowTemplate.Height = 23
        Me.dgvSopHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSopHeader.Size = New System.Drawing.Size(807, 143)
        Me.dgvSopHeader.TabIndex = 0
        '
        'Column11
        '
        Me.Column11.FalseValue = "False"
        Me.Column11.HeaderText = "选择"
        Me.Column11.Name = "Column11"
        Me.Column11.TrueValue = "True"
        Me.Column11.Width = 50
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "SopName"
        Me.Column1.HeaderText = "SOP名称"
        Me.Column1.Name = "Column1"
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "DocId"
        Me.Column6.HeaderText = "文件编码"
        Me.Column6.Name = "Column6"
        '
        'Column19
        '
        Me.Column19.DataPropertyName = "PartName"
        Me.Column19.HeaderText = "描述"
        Me.Column19.Name = "Column19"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "PartDesc"
        Me.Column2.HeaderText = "规格"
        Me.Column2.Name = "Column2"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Version"
        Me.Column4.HeaderText = "版本"
        Me.Column4.Name = "Column4"
        '
        'Column22
        '
        Me.Column22.DataPropertyName = "PageAmount"
        Me.Column22.HeaderText = "总页数"
        Me.Column22.Name = "Column22"
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "Shape"
        Me.Column5.HeaderText = "形态"
        Me.Column5.Name = "Column5"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Status"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "状态"
        Me.Column3.Name = "Column3"
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "Remark"
        Me.Column10.HeaderText = "备注"
        Me.Column10.Name = "Column10"
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "UserName"
        Me.Column7.HeaderText = "创建人"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "CreateTime"
        Me.Column8.HeaderText = "创建日期"
        Me.Column8.Name = "Column8"
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "RecentlyModifyTime"
        Me.Column9.HeaderText = "最近修改日期"
        Me.Column9.Name = "Column9"
        '
        'Column25
        '
        Me.Column25.DataPropertyName = "ModifyUserId"
        Me.Column25.HeaderText = "最近修改人"
        Me.Column25.Name = "Column25"
        '
        'Column26
        '
        Me.Column26.DataPropertyName = "ModifyTime"
        Me.Column26.HeaderText = "修改日期"
        Me.Column26.Name = "Column26"
        '
        'Column27
        '
        Me.Column27.DataPropertyName = "CreateUserId"
        Me.Column27.HeaderText = "创建人"
        Me.Column27.Name = "Column27"
        Me.Column27.Visible = False
        '
        'RemarkSign
        '
        Me.RemarkSign.DataPropertyName = "RemarkSign"
        Me.RemarkSign.HeaderText = "签核批注"
        Me.RemarkSign.Name = "RemarkSign"
        '
        'TextBoxItem1
        '
        Me.TextBoxItem1.FocusHighlightColor = System.Drawing.Color.Azure
        Me.TextBoxItem1.FocusHighlightEnabled = True
        Me.TextBoxItem1.Name = "TextBoxItem1"
        Me.TextBoxItem1.TextBoxWidth = 150
        Me.TextBoxItem1.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
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
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(100, 21)
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCopySop, Me.ToolStripSeparator10, Me.btnPrint, Me.ToolStripSeparator1, Me.btnAudit, Me.toolStripSeparator3, Me.btnRefresh, Me.ToolStripSeparator8, Me.btnExportSop, Me.ToolStripSeparator11, Me.btnExportHeader, Me.ToolStripSeparator9, Me.btnEmail, Me.toolExportChangeLog, Me.ToolStripSeparator7, Me.btnExit, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.txtCount, Me.ToolStripSeparator12, Me.tslMsg})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(941, 25)
        Me.toolStrip1.TabIndex = 3
        Me.toolStrip1.Text = "toolStrip1"
        '
        'btnCopySop
        '
        Me.btnCopySop.Image = CType(resources.GetObject("btnCopySop.Image"), System.Drawing.Image)
        Me.btnCopySop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCopySop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopySop.Name = "btnCopySop"
        Me.btnCopySop.Size = New System.Drawing.Size(85, 22)
        Me.btnCopySop.Tag = "复制流程"
        Me.btnCopySop.Text = "复制SOP(&C)"
        Me.btnCopySop.ToolTipText = "复制SOP(C)"
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(91, 22)
        Me.btnPrint.Text = "在线打印(&P)"
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
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(73, 22)
        Me.btnRefresh.Text = "刷 新(&R)"
        Me.btnRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'btnExportSop
        '
        Me.btnExportSop.Image = CType(resources.GetObject("btnExportSop.Image"), System.Drawing.Image)
        Me.btnExportSop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportSop.Name = "btnExportSop"
        Me.btnExportSop.Size = New System.Drawing.Size(85, 22)
        Me.btnExportSop.Text = "导出SOP(&O)"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'btnExportHeader
        '
        Me.btnExportHeader.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportHeader.Name = "btnExportHeader"
        Me.btnExportHeader.Size = New System.Drawing.Size(75, 22)
        Me.btnExportHeader.Text = "导出单头(&E)"
        '
        'btnEmail
        '
        Me.btnEmail.Image = CType(resources.GetObject("btnEmail.Image"), System.Drawing.Image)
        Me.btnEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(73, 22)
        Me.btnEmail.Text = "提醒名单"
        '
        'toolExportChangeLog
        '
        Me.toolExportChangeLog.Image = Global.RCard.My.Resources.Resources.excel
        Me.toolExportChangeLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExportChangeLog.Name = "toolExportChangeLog"
        Me.toolExportChangeLog.Size = New System.Drawing.Size(115, 22)
        Me.toolExportChangeLog.Text = "查看变更履历(&P)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(73, 22)
        Me.btnExit.Text = "退 出(&X)"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'tslMsg
        '
        Me.tslMsg.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.tslMsg.Name = "tslMsg"
        Me.tslMsg.Size = New System.Drawing.Size(0, 0)
        '
        'ContextMenuHeader
        '
        Me.ContextMenuHeader.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiHeaderSearch, Me.tsmiHeaderAdd, Me.tsmiHeaderModify, Me.tsmiHeaderCopy, Me.ToolStripSeparator4, Me.tsmiHeaderDelete, Me.tsmiHeaderReject, Me.tsmiHeaderRetract, Me.tsmiHeaderComfirm, Me.ToolStripSeparator5, Me.tsmiHeaderPrint, Me.tsmiHeaderExport, Me.tsmiHeaderChangeLog})
        Me.ContextMenuHeader.Name = "ContextMenuStrip1"
        Me.ContextMenuHeader.Size = New System.Drawing.Size(149, 258)
        '
        'tsmiHeaderSearch
        '
        Me.tsmiHeaderSearch.Name = "tsmiHeaderSearch"
        Me.tsmiHeaderSearch.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderSearch.Tag = "查询"
        Me.tsmiHeaderSearch.Text = "查询(&Q)"
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
        'tsmiHeaderCopy
        '
        Me.tsmiHeaderCopy.Image = CType(resources.GetObject("tsmiHeaderCopy.Image"), System.Drawing.Image)
        Me.tsmiHeaderCopy.Name = "tsmiHeaderCopy"
        Me.tsmiHeaderCopy.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderCopy.Tag = "复制"
        Me.tsmiHeaderCopy.Text = "复制单元格(&C)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(145, 6)
        '
        'tsmiHeaderDelete
        '
        Me.tsmiHeaderDelete.Image = CType(resources.GetObject("tsmiHeaderDelete.Image"), System.Drawing.Image)
        Me.tsmiHeaderDelete.Name = "tsmiHeaderDelete"
        Me.tsmiHeaderDelete.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderDelete.Tag = ""
        Me.tsmiHeaderDelete.Text = "作废(&D)"
        '
        'tsmiHeaderReject
        '
        Me.tsmiHeaderReject.Image = CType(resources.GetObject("tsmiHeaderReject.Image"), System.Drawing.Image)
        Me.tsmiHeaderReject.Name = "tsmiHeaderReject"
        Me.tsmiHeaderReject.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderReject.Tag = "驳回"
        Me.tsmiHeaderReject.Text = "驳回(&R)"
        '
        'tsmiHeaderRetract
        '
        Me.tsmiHeaderRetract.Image = CType(resources.GetObject("tsmiHeaderRetract.Image"), System.Drawing.Image)
        Me.tsmiHeaderRetract.Name = "tsmiHeaderRetract"
        Me.tsmiHeaderRetract.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderRetract.Text = "撤回(T)"
        '
        'tsmiHeaderComfirm
        '
        Me.tsmiHeaderComfirm.Image = CType(resources.GetObject("tsmiHeaderComfirm.Image"), System.Drawing.Image)
        Me.tsmiHeaderComfirm.Name = "tsmiHeaderComfirm"
        Me.tsmiHeaderComfirm.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderComfirm.Text = "确认(&F)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(145, 6)
        '
        'tsmiHeaderPrint
        '
        Me.tsmiHeaderPrint.Image = CType(resources.GetObject("tsmiHeaderPrint.Image"), System.Drawing.Image)
        Me.tsmiHeaderPrint.Name = "tsmiHeaderPrint"
        Me.tsmiHeaderPrint.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderPrint.Tag = "打印"
        Me.tsmiHeaderPrint.Text = "打印(&P)"
        '
        'tsmiHeaderExport
        '
        Me.tsmiHeaderExport.Image = CType(resources.GetObject("tsmiHeaderExport.Image"), System.Drawing.Image)
        Me.tsmiHeaderExport.Name = "tsmiHeaderExport"
        Me.tsmiHeaderExport.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderExport.Text = "导出(&E)"
        '
        'tsmiHeaderChangeLog
        '
        Me.tsmiHeaderChangeLog.Name = "tsmiHeaderChangeLog"
        Me.tsmiHeaderChangeLog.Size = New System.Drawing.Size(148, 22)
        Me.tsmiHeaderChangeLog.Text = "查看变更记录"
        '
        'ContextMenuBody
        '
        Me.ContextMenuBody.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiBodyDetail, Me.tsmiBodyAdd, Me.tsmiBodyModify, Me.tsmiBodyDelete, Me.ToolStripSeparator6, Me.tsmiBodyCopy, Me.tsmiBodyCopyRow, Me.tsmiBodyPasteRow, Me.ToolStripSeparator13, Me.tsmiRemark, Me.tsmiBodyPrint, Me.tsmiBodyExprot, Me.toolStationChange})
        Me.ContextMenuBody.Name = "ContextMenuStrip1"
        Me.ContextMenuBody.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuBody.Size = New System.Drawing.Size(149, 258)
        '
        'tsmiBodyDetail
        '
        Me.tsmiBodyDetail.Name = "tsmiBodyDetail"
        Me.tsmiBodyDetail.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyDetail.Text = "查看(&V)"
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
        Me.tsmiBodyModify.Text = "修改(&E)"
        '
        'tsmiBodyDelete
        '
        Me.tsmiBodyDelete.Image = CType(resources.GetObject("tsmiBodyDelete.Image"), System.Drawing.Image)
        Me.tsmiBodyDelete.Name = "tsmiBodyDelete"
        Me.tsmiBodyDelete.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyDelete.Tag = "删除"
        Me.tsmiBodyDelete.Text = "删除(&D)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(145, 6)
        '
        'tsmiBodyCopy
        '
        Me.tsmiBodyCopy.Image = CType(resources.GetObject("tsmiBodyCopy.Image"), System.Drawing.Image)
        Me.tsmiBodyCopy.Name = "tsmiBodyCopy"
        Me.tsmiBodyCopy.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyCopy.Tag = "复制"
        Me.tsmiBodyCopy.Text = "复制单元格(&C)"
        '
        'tsmiBodyCopyRow
        '
        Me.tsmiBodyCopyRow.Image = CType(resources.GetObject("tsmiBodyCopyRow.Image"), System.Drawing.Image)
        Me.tsmiBodyCopyRow.Name = "tsmiBodyCopyRow"
        Me.tsmiBodyCopyRow.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyCopyRow.Text = "复制行(&R)"
        '
        'tsmiBodyPasteRow
        '
        Me.tsmiBodyPasteRow.Enabled = False
        Me.tsmiBodyPasteRow.Image = CType(resources.GetObject("tsmiBodyPasteRow.Image"), System.Drawing.Image)
        Me.tsmiBodyPasteRow.Name = "tsmiBodyPasteRow"
        Me.tsmiBodyPasteRow.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyPasteRow.Text = "粘贴行(&A)"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(145, 6)
        '
        'tsmiRemark
        '
        Me.tsmiRemark.Image = CType(resources.GetObject("tsmiRemark.Image"), System.Drawing.Image)
        Me.tsmiRemark.Name = "tsmiRemark"
        Me.tsmiRemark.Size = New System.Drawing.Size(148, 22)
        Me.tsmiRemark.Text = "加入备注(&B)"
        '
        'tsmiBodyPrint
        '
        Me.tsmiBodyPrint.Image = CType(resources.GetObject("tsmiBodyPrint.Image"), System.Drawing.Image)
        Me.tsmiBodyPrint.Name = "tsmiBodyPrint"
        Me.tsmiBodyPrint.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyPrint.Tag = ""
        Me.tsmiBodyPrint.Text = "打印(&P)"
        '
        'tsmiBodyExprot
        '
        Me.tsmiBodyExprot.Name = "tsmiBodyExprot"
        Me.tsmiBodyExprot.Size = New System.Drawing.Size(148, 22)
        Me.tsmiBodyExprot.Text = "导出(&O)"
        '
        'toolStationChange
        '
        Me.toolStationChange.Enabled = False
        Me.toolStationChange.Name = "toolStationChange"
        Me.toolStationChange.Size = New System.Drawing.Size(148, 22)
        Me.toolStationChange.Text = "查看变更记录"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "make_tree.png")
        Me.ImageList1.Images.SetKeyName(1, "sign_tree.png")
        Me.ImageList1.Images.SetKeyName(2, "dept_tree.png")
        Me.ImageList1.Images.SetKeyName(3, "approval_tree.png")
        Me.ImageList1.Images.SetKeyName(4, "ok.png")
        '
        'FrmOnlineSop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 446)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmOnlineSop"
        Me.Text = "在线SOP制作"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvSopBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvSopHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ContextMenuHeader.ResumeLayout(False)
        Me.ContextMenuBody.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgvSopHeader As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSopBody As System.Windows.Forms.DataGridView
    Private WithEvents btnCopySop As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnAudit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Private WithEvents btnExportHeader As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtCount As System.Windows.Forms.ToolStripTextBox
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ContextMenuHeader As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiHeaderCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderModify As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderReject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuBody As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiBodyCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyModify As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyDetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderComfirm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents tsmiRemark As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEmail As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportSop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslMsg As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tsmiBodyExprot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderRetract As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyCopyRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyPasteRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents toolExportChangeLog As System.Windows.Forms.ToolStripButton
    Private WithEvents TextBoxItem1 As DevComponents.DotNetBar.TextBoxItem
    Private WithEvents sbStatus As DevComponents.DotNetBar.SideBar
    Private WithEvents sbPanelFinish As DevComponents.DotNetBar.SideBarPanelItem
    Private WithEvents sbPanelApproval As DevComponents.DotNetBar.SideBarPanelItem
    Private WithEvents sbPanelQC As DevComponents.DotNetBar.SideBarPanelItem
    Private WithEvents sbPanelProd As DevComponents.DotNetBar.SideBarPanelItem
    Private WithEvents sbPanelVerify As DevComponents.DotNetBar.SideBarPanelItem
    Private WithEvents sbPanelMake As DevComponents.DotNetBar.SideBarPanelItem
    Private WithEvents txtSearch As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Private WithEvents sbPanelDCC As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents toolStationChange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemarkSign As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsmiHeaderChangeLog As System.Windows.Forms.ToolStripMenuItem
End Class
