<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRunCardCut
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRunCardCut))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtCount = New System.Windows.Forms.ToolStripTextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtSearch = New DevComponents.DotNetBar.TextBoxItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SideBar1 = New DevComponents.DotNetBar.SideBar()
        Me.sbPanelUnfinish = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelFinish = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.sbPanelAudit = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.barSearch = New DevComponents.DotNetBar.Bar()
        Me.ContextMenuHeader = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ComboBoxItem1 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.ComboBoxItem2 = New DevComponents.DotNetBar.ComboBoxItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.ContextMenuDetail = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuBody = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.dgvCutCardHeader = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.dgvCutCardBody = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.StationSQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SectionID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WorkingHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Equipment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessStandard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeftProcessStandard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightProcessStandard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewProcessStandard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LCLValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvPartNumber = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsmiPartAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiPartDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClear = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCopy = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnAudit = New System.Windows.Forms.ToolStripButton()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.btnExportHeader = New System.Windows.Forms.ToolStripButton()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.tsmiHeaderCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderModify = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderReject = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHeaderExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyModify = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyConfirm = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBodyInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolCopyBodyStation = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolExportChangeLog = New System.Windows.Forms.ToolStripButton()
        Me.toolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.barSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuHeader.SuspendLayout()
        Me.ContextMenuDetail.SuspendLayout()
        Me.ContextMenuBody.SuspendLayout()
        CType(Me.dgvCutCardHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvCutCardBody, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPartNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCopy, Me.ToolStripSeparator10, Me.btnPrint, Me.ToolStripSeparator1, Me.btnAudit, Me.toolStripSeparator3, Me.btnRefresh, Me.btnExportHeader, Me.ToolStripSeparator9, Me.btnExit, Me.ToolStripSeparator2, Me.toolExportChangeLog, Me.ToolStripLabel1, Me.txtCount})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1030, 25)
        Me.toolStrip1.TabIndex = 2
        Me.toolStrip1.Text = "toolStrip1"
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
        Me.txtCount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(100, 25)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "00013.ico")
        Me.ImageList1.Images.SetKeyName(1, "00028.ico")
        Me.ImageList1.Images.SetKeyName(2, "00015.ico")
        '
        'txtSearch
        '
        Me.txtSearch.FocusHighlightColor = System.Drawing.Color.Azure
        Me.txtSearch.FocusHighlightEnabled = True
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.TextBoxWidth = 150
        Me.txtSearch.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.SideBar1)
        Me.Panel1.Controls.Add(Me.barSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(182, 373)
        Me.Panel1.TabIndex = 52
        '
        'SideBar1
        '
        Me.SideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.SideBar1.BorderStyle = DevComponents.DotNetBar.eBorderType.None
        Me.SideBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SideBar1.ExpandedPanel = Me.sbPanelFinish
        Me.SideBar1.Location = New System.Drawing.Point(0, 25)
        Me.SideBar1.Name = "SideBar1"
        Me.SideBar1.Panels.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.sbPanelFinish, Me.sbPanelAudit, Me.sbPanelUnfinish})
        Me.SideBar1.Size = New System.Drawing.Size(182, 348)
        Me.SideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SideBar1.TabIndex = 64
        Me.SideBar1.Text = "SideBar1"
        '
        'sbPanelUnfinish
        '
        Me.sbPanelUnfinish.FontBold = True
        Me.sbPanelUnfinish.Name = "sbPanelUnfinish"
        Me.sbPanelUnfinish.Text = "制作中"
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
        'barSearch
        '
        Me.barSearch.AntiAlias = True
        Me.barSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.barSearch.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.barSearch.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.barSearch.IsMaximized = False
        Me.barSearch.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.txtSearch, Me.btnClear})
        Me.barSearch.Location = New System.Drawing.Point(0, 0)
        Me.barSearch.Name = "barSearch"
        Me.barSearch.Size = New System.Drawing.Size(182, 25)
        Me.barSearch.Stretch = True
        Me.barSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.barSearch.TabIndex = 63
        Me.barSearch.TabStop = False
        Me.barSearch.Text = "Bar1"
        '
        'ContextMenuHeader
        '
        Me.ContextMenuHeader.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiHeaderCopy, Me.tsmiHeaderAdd, Me.tsmiHeaderDelete, Me.tsmiHeaderHide, Me.tsmiHeaderModify, Me.tsmiHeaderSearch, Me.tsmiHeaderCancel, Me.tsmiHeaderReject, Me.tsmiHeaderPrint, Me.tsmiHeaderImport, Me.tsmiHeaderExport})
        Me.ContextMenuHeader.Name = "ContextMenuStrip1"
        Me.ContextMenuHeader.Size = New System.Drawing.Size(137, 246)
        '
        'ComboBoxItem1
        '
        Me.ComboBoxItem1.DropDownHeight = 106
        Me.ComboBoxItem1.ItemHeight = 16
        Me.ComboBoxItem1.Name = "ComboBoxItem1"
        Me.ComboBoxItem1.Text = "ComboBoxItem1"
        '
        'ComboBoxItem2
        '
        Me.ComboBoxItem2.DropDownHeight = 106
        Me.ComboBoxItem2.ItemHeight = 16
        Me.ComboBoxItem2.Name = "ComboBoxItem2"
        Me.ComboBoxItem2.Text = "ComboBoxItem2"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        '
        'ContextMenuDetail
        '
        Me.ContextMenuDetail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiPartAdd, Me.tsmiPartDelete})
        Me.ContextMenuDetail.Name = "ContextMenuStrip2"
        Me.ContextMenuDetail.Size = New System.Drawing.Size(137, 48)
        '
        'ContextMenuBody
        '
        Me.ContextMenuBody.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiBodyCopy, Me.tsmiBodyAdd, Me.tsmiBodyModify, Me.tsmiBodyDelete, Me.tsmiBodyConfirm, Me.tsmiBodyInsert, Me.RToolStripMenuItem, Me.ToolCopyBodyStation})
        Me.ContextMenuBody.Name = "ContextMenuStrip1"
        Me.ContextMenuBody.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuBody.Size = New System.Drawing.Size(119, 180)
        '
        'dgvCutCardHeader
        '
        Me.dgvCutCardHeader.AllowUserToAddRows = False
        Me.dgvCutCardHeader.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCutCardHeader.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCutCardHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCutCardHeader.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCutCardHeader.ColumnHeadersHeight = 24
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCutCardHeader.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCutCardHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvCutCardHeader.EnableHeadersVisualStyles = False
        Me.dgvCutCardHeader.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvCutCardHeader.HighlightSelectedColumnHeaders = False
        Me.dgvCutCardHeader.Location = New System.Drawing.Point(182, 25)
        Me.dgvCutCardHeader.Name = "dgvCutCardHeader"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCutCardHeader.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCutCardHeader.RowHeadersVisible = False
        Me.dgvCutCardHeader.RowHeadersWidth = 20
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgvCutCardHeader.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCutCardHeader.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.dgvCutCardHeader.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue
        Me.dgvCutCardHeader.RowTemplate.Height = 30
        Me.dgvCutCardHeader.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCutCardHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCutCardHeader.Size = New System.Drawing.Size(848, 248)
        Me.dgvCutCardHeader.TabIndex = 73
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ExpandableSplitter1)
        Me.Panel2.Controls.Add(Me.dgvCutCardBody)
        Me.Panel2.Controls.Add(Me.dgvPartNumber)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(182, 273)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(848, 125)
        Me.Panel2.TabIndex = 79
        '
        'ExpandableSplitter1
        '
        Me.ExpandableSplitter1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ExpandableSplitter1.BackColor2 = System.Drawing.Color.Empty
        Me.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.ExpandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground
        Me.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.Empty
        Me.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground
        Me.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(563, 0)
        Me.ExpandableSplitter1.MinExtra = 20
        Me.ExpandableSplitter1.MinimumSize = New System.Drawing.Size(4, 0)
        Me.ExpandableSplitter1.MinSize = 4
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(4, 125)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Mozilla
        Me.ExpandableSplitter1.TabIndex = 82
        Me.ExpandableSplitter1.TabStop = False
        '
        'dgvCutCardBody
        '
        Me.dgvCutCardBody.AllowUserToAddRows = False
        Me.dgvCutCardBody.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCutCardBody.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCutCardBody.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCutCardBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCutCardBody.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvCutCardBody.ColumnHeadersHeight = 24
        Me.dgvCutCardBody.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StationSQ, Me.StationName, Me.SectionID, Me.WorkingHours, Me.Equipment, Me.ProcessStandard, Me.LeftProcessStandard, Me.RightProcessStandard, Me.NewProcessStandard, Me.Remark, Me.SOP, Me.LCLValue, Me.Status, Me.UserId, Me.InTime, Me.PartID, Me.StationID})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCutCardBody.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvCutCardBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCutCardBody.EnableHeadersVisualStyles = False
        Me.dgvCutCardBody.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvCutCardBody.Location = New System.Drawing.Point(0, 0)
        Me.dgvCutCardBody.MultiSelect = False
        Me.dgvCutCardBody.Name = "dgvCutCardBody"
        Me.dgvCutCardBody.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCutCardBody.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvCutCardBody.RowHeadersVisible = False
        Me.dgvCutCardBody.RowHeadersWidth = 24
        Me.dgvCutCardBody.RowTemplate.Height = 23
        Me.dgvCutCardBody.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCutCardBody.Size = New System.Drawing.Size(567, 125)
        Me.dgvCutCardBody.TabIndex = 79
        '
        'StationSQ
        '
        Me.StationSQ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.StationSQ.DataPropertyName = "StationSQ"
        Me.StationSQ.HeaderText = "工序"
        Me.StationSQ.Name = "StationSQ"
        Me.StationSQ.ReadOnly = True
        Me.StationSQ.Width = 54
        '
        'StationName
        '
        Me.StationName.DataPropertyName = "StationName"
        Me.StationName.HeaderText = "工站名称"
        Me.StationName.Name = "StationName"
        Me.StationName.ReadOnly = True
        '
        'SectionID
        '
        Me.SectionID.DataPropertyName = "SectionID"
        Me.SectionID.HeaderText = "工段ID"
        Me.SectionID.Name = "SectionID"
        Me.SectionID.ReadOnly = True
        Me.SectionID.Visible = False
        '
        'WorkingHours
        '
        Me.WorkingHours.DataPropertyName = "WorkingHours"
        Me.WorkingHours.HeaderText = "工时"
        Me.WorkingHours.Name = "WorkingHours"
        Me.WorkingHours.ReadOnly = True
        Me.WorkingHours.Visible = False
        '
        'Equipment
        '
        Me.Equipment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Equipment.DataPropertyName = "Equipment"
        Me.Equipment.HeaderText = "设备治具"
        Me.Equipment.Name = "Equipment"
        Me.Equipment.ReadOnly = True
        Me.Equipment.Width = 78
        '
        'ProcessStandard
        '
        Me.ProcessStandard.DataPropertyName = "ProcessStandard"
        Me.ProcessStandard.HeaderText = "工艺标准"
        Me.ProcessStandard.Name = "ProcessStandard"
        Me.ProcessStandard.ReadOnly = True
        '
        'LeftProcessStandard
        '
        Me.LeftProcessStandard.DataPropertyName = "LeftProcessStandard"
        Me.LeftProcessStandard.HeaderText = "左参数"
        Me.LeftProcessStandard.Name = "LeftProcessStandard"
        Me.LeftProcessStandard.ReadOnly = True
        '
        'RightProcessStandard
        '
        Me.RightProcessStandard.DataPropertyName = "RightProcessStandard"
        Me.RightProcessStandard.HeaderText = "右参数"
        Me.RightProcessStandard.Name = "RightProcessStandard"
        Me.RightProcessStandard.ReadOnly = True
        '
        'NewProcessStandard
        '
        Me.NewProcessStandard.DataPropertyName = "NewProcessStandard"
        Me.NewProcessStandard.HeaderText = "新工艺标准"
        Me.NewProcessStandard.Name = "NewProcessStandard"
        Me.NewProcessStandard.ReadOnly = True
        Me.NewProcessStandard.Visible = False
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'SOP
        '
        Me.SOP.HeaderText = "SOP"
        Me.SOP.Name = "SOP"
        Me.SOP.ReadOnly = True
        Me.SOP.Visible = False
        '
        'LCLValue
        '
        Me.LCLValue.DataPropertyName = "LCLValue"
        Me.LCLValue.HeaderText = "裁线尺寸"
        Me.LCLValue.Name = "LCLValue"
        Me.LCLValue.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "状态"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Visible = False
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        Me.UserId.HeaderText = "修改人"
        Me.UserId.Name = "UserId"
        Me.UserId.ReadOnly = True
        '
        'InTime
        '
        Me.InTime.DataPropertyName = "InTime"
        Me.InTime.HeaderText = "修改时间"
        Me.InTime.Name = "InTime"
        Me.InTime.ReadOnly = True
        '
        'PartID
        '
        Me.PartID.DataPropertyName = "PartID"
        Me.PartID.HeaderText = "料件ID"
        Me.PartID.Name = "PartID"
        Me.PartID.ReadOnly = True
        Me.PartID.Visible = False
        '
        'StationID
        '
        Me.StationID.DataPropertyName = "StationID"
        Me.StationID.HeaderText = "工站ID"
        Me.StationID.Name = "StationID"
        Me.StationID.ReadOnly = True
        Me.StationID.Visible = False
        '
        'dgvPartNumber
        '
        Me.dgvPartNumber.AllowUserToAddRows = False
        Me.dgvPartNumber.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvPartNumber.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvPartNumber.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartNumber.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvPartNumber.ColumnHeadersHeight = 24
        Me.dgvPartNumber.ContextMenuStrip = Me.ContextMenuDetail
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPartNumber.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvPartNumber.Dock = System.Windows.Forms.DockStyle.Right
        Me.dgvPartNumber.EnableHeadersVisualStyles = False
        Me.dgvPartNumber.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvPartNumber.Location = New System.Drawing.Point(567, 0)
        Me.dgvPartNumber.MultiSelect = False
        Me.dgvPartNumber.Name = "dgvPartNumber"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPartNumber.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPartNumber.RowHeadersVisible = False
        Me.dgvPartNumber.RowHeadersWidth = 20
        Me.dgvPartNumber.RowTemplate.Height = 23
        Me.dgvPartNumber.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartNumber.Size = New System.Drawing.Size(281, 125)
        Me.dgvPartNumber.TabIndex = 77
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "料件ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 42
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "图号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 66
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "客户图纸"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 78
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "当前状态"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 54
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "创建者"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 66
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "创建时间"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 78
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "料件ID"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 78
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 66
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 78
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "料件ID"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 54
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 66
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "工站序号"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 78
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "工站编号"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 54
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "工站名称"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 42
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "工时"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 78
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "设备/治具"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Width = 78
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "工艺标准"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 78
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Width = 54
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Width = 84
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "创建人"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Width = 78
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "创建时间"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Width = 54
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Width = 54
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.HeaderText = "Sop"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.Width = 48
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "创建人"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.Width = 66
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "创建时间"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.Width = 78
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.Width = 54
        '
        'tsmiPartAdd
        '
        Me.tsmiPartAdd.Checked = True
        Me.tsmiPartAdd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmiPartAdd.Image = CType(resources.GetObject("tsmiPartAdd.Image"), System.Drawing.Image)
        Me.tsmiPartAdd.Name = "tsmiPartAdd"
        Me.tsmiPartAdd.Size = New System.Drawing.Size(136, 22)
        Me.tsmiPartAdd.Tag = "添加料件"
        Me.tsmiPartAdd.Text = "添加料件(&N)"
        '
        'tsmiPartDelete
        '
        Me.tsmiPartDelete.Image = CType(resources.GetObject("tsmiPartDelete.Image"), System.Drawing.Image)
        Me.tsmiPartDelete.Name = "tsmiPartDelete"
        Me.tsmiPartDelete.Size = New System.Drawing.Size(136, 22)
        Me.tsmiPartDelete.Tag = "删除"
        Me.tsmiPartDelete.Text = "删除(&D)"
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Text = "ButtonItem14"
        '
        'btnCopy
        '
        Me.btnCopy.Image = CType(resources.GetObject("btnCopy.Image"), System.Drawing.Image)
        Me.btnCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(103, 22)
        Me.btnCopy.Tag = "复制流程"
        Me.btnCopy.Text = "复制裁线卡(&S)"
        '
        'btnPrint
        '
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(73, 22)
        Me.btnPrint.Text = "打 印(&P)"
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
        'btnExportHeader
        '
        Me.btnExportHeader.Image = CType(resources.GetObject("btnExportHeader.Image"), System.Drawing.Image)
        Me.btnExportHeader.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportHeader.Name = "btnExportHeader"
        Me.btnExportHeader.Size = New System.Drawing.Size(91, 22)
        Me.btnExportHeader.Text = "导出单头(&P)"
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(73, 22)
        Me.btnExit.Text = "退 出(&X)"
        '
        'tsmiHeaderCopy
        '
        Me.tsmiHeaderCopy.Image = CType(resources.GetObject("tsmiHeaderCopy.Image"), System.Drawing.Image)
        Me.tsmiHeaderCopy.Name = "tsmiHeaderCopy"
        Me.tsmiHeaderCopy.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderCopy.Tag = "复制"
        Me.tsmiHeaderCopy.Text = "复制(&C)"
        '
        'tsmiHeaderAdd
        '
        Me.tsmiHeaderAdd.Image = CType(resources.GetObject("tsmiHeaderAdd.Image"), System.Drawing.Image)
        Me.tsmiHeaderAdd.Name = "tsmiHeaderAdd"
        Me.tsmiHeaderAdd.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderAdd.Tag = "新增"
        Me.tsmiHeaderAdd.Text = "新增(&N)"
        '
        'tsmiHeaderDelete
        '
        Me.tsmiHeaderDelete.Image = CType(resources.GetObject("tsmiHeaderDelete.Image"), System.Drawing.Image)
        Me.tsmiHeaderDelete.Name = "tsmiHeaderDelete"
        Me.tsmiHeaderDelete.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderDelete.Tag = "删除"
        Me.tsmiHeaderDelete.Text = "删除(&D)"
        '
        'tsmiHeaderHide
        '
        Me.tsmiHeaderHide.Image = CType(resources.GetObject("tsmiHeaderHide.Image"), System.Drawing.Image)
        Me.tsmiHeaderHide.Name = "tsmiHeaderHide"
        Me.tsmiHeaderHide.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderHide.Tag = "隐藏"
        Me.tsmiHeaderHide.Text = "隐藏(&H)"
        '
        'tsmiHeaderModify
        '
        Me.tsmiHeaderModify.Image = CType(resources.GetObject("tsmiHeaderModify.Image"), System.Drawing.Image)
        Me.tsmiHeaderModify.Name = "tsmiHeaderModify"
        Me.tsmiHeaderModify.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderModify.Tag = "修改"
        Me.tsmiHeaderModify.Text = "修改(&M)"
        '
        'tsmiHeaderSearch
        '
        Me.tsmiHeaderSearch.Image = CType(resources.GetObject("tsmiHeaderSearch.Image"), System.Drawing.Image)
        Me.tsmiHeaderSearch.Name = "tsmiHeaderSearch"
        Me.tsmiHeaderSearch.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderSearch.Tag = "查询"
        Me.tsmiHeaderSearch.Text = "查询(&Q)"
        '
        'tsmiHeaderCancel
        '
        Me.tsmiHeaderCancel.Image = CType(resources.GetObject("tsmiHeaderCancel.Image"), System.Drawing.Image)
        Me.tsmiHeaderCancel.Name = "tsmiHeaderCancel"
        Me.tsmiHeaderCancel.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderCancel.Text = "取消生效(&C)"
        '
        'tsmiHeaderReject
        '
        Me.tsmiHeaderReject.Image = CType(resources.GetObject("tsmiHeaderReject.Image"), System.Drawing.Image)
        Me.tsmiHeaderReject.Name = "tsmiHeaderReject"
        Me.tsmiHeaderReject.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderReject.Tag = "驳回"
        Me.tsmiHeaderReject.Text = "驳回(&R)"
        '
        'tsmiHeaderPrint
        '
        Me.tsmiHeaderPrint.Image = CType(resources.GetObject("tsmiHeaderPrint.Image"), System.Drawing.Image)
        Me.tsmiHeaderPrint.Name = "tsmiHeaderPrint"
        Me.tsmiHeaderPrint.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderPrint.Tag = "打印"
        Me.tsmiHeaderPrint.Text = "打印(&P)"
        '
        'tsmiHeaderImport
        '
        Me.tsmiHeaderImport.Image = CType(resources.GetObject("tsmiHeaderImport.Image"), System.Drawing.Image)
        Me.tsmiHeaderImport.Name = "tsmiHeaderImport"
        Me.tsmiHeaderImport.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderImport.Text = "导入(&I)"
        '
        'tsmiHeaderExport
        '
        Me.tsmiHeaderExport.Image = CType(resources.GetObject("tsmiHeaderExport.Image"), System.Drawing.Image)
        Me.tsmiHeaderExport.Name = "tsmiHeaderExport"
        Me.tsmiHeaderExport.Size = New System.Drawing.Size(136, 22)
        Me.tsmiHeaderExport.Text = "导出(&E)"
        '
        'tsmiBodyCopy
        '
        Me.tsmiBodyCopy.Image = CType(resources.GetObject("tsmiBodyCopy.Image"), System.Drawing.Image)
        Me.tsmiBodyCopy.Name = "tsmiBodyCopy"
        Me.tsmiBodyCopy.Size = New System.Drawing.Size(118, 22)
        Me.tsmiBodyCopy.Tag = "复制"
        Me.tsmiBodyCopy.Text = "复制(&C)"
        '
        'tsmiBodyAdd
        '
        Me.tsmiBodyAdd.Image = CType(resources.GetObject("tsmiBodyAdd.Image"), System.Drawing.Image)
        Me.tsmiBodyAdd.Name = "tsmiBodyAdd"
        Me.tsmiBodyAdd.Size = New System.Drawing.Size(118, 22)
        Me.tsmiBodyAdd.Tag = "新增"
        Me.tsmiBodyAdd.Text = "新增(&N)"
        '
        'tsmiBodyModify
        '
        Me.tsmiBodyModify.Image = CType(resources.GetObject("tsmiBodyModify.Image"), System.Drawing.Image)
        Me.tsmiBodyModify.Name = "tsmiBodyModify"
        Me.tsmiBodyModify.Size = New System.Drawing.Size(118, 22)
        Me.tsmiBodyModify.Tag = "修改"
        Me.tsmiBodyModify.Text = "修改(&M)"
        '
        'tsmiBodyDelete
        '
        Me.tsmiBodyDelete.Image = CType(resources.GetObject("tsmiBodyDelete.Image"), System.Drawing.Image)
        Me.tsmiBodyDelete.Name = "tsmiBodyDelete"
        Me.tsmiBodyDelete.Size = New System.Drawing.Size(118, 22)
        Me.tsmiBodyDelete.Tag = "删除"
        Me.tsmiBodyDelete.Text = "删除(&D)"
        '
        'tsmiBodyConfirm
        '
        Me.tsmiBodyConfirm.Image = CType(resources.GetObject("tsmiBodyConfirm.Image"), System.Drawing.Image)
        Me.tsmiBodyConfirm.Name = "tsmiBodyConfirm"
        Me.tsmiBodyConfirm.Size = New System.Drawing.Size(118, 22)
        Me.tsmiBodyConfirm.Tag = "确认"
        Me.tsmiBodyConfirm.Text = "确认(&F)"
        '
        'tsmiBodyInsert
        '
        Me.tsmiBodyInsert.Image = CType(resources.GetObject("tsmiBodyInsert.Image"), System.Drawing.Image)
        Me.tsmiBodyInsert.Name = "tsmiBodyInsert"
        Me.tsmiBodyInsert.Size = New System.Drawing.Size(118, 22)
        Me.tsmiBodyInsert.Tag = "插入"
        Me.tsmiBodyInsert.Text = "插入(&I)"
        '
        'RToolStripMenuItem
        '
        Me.RToolStripMenuItem.Image = CType(resources.GetObject("RToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RToolStripMenuItem.Name = "RToolStripMenuItem"
        Me.RToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.RToolStripMenuItem.Text = "重置(R)"
        '
        'ToolCopyBodyStation
        '
        Me.ToolCopyBodyStation.Image = CType(resources.GetObject("ToolCopyBodyStation.Image"), System.Drawing.Image)
        Me.ToolCopyBodyStation.Name = "ToolCopyBodyStation"
        Me.ToolCopyBodyStation.Size = New System.Drawing.Size(118, 22)
        Me.ToolCopyBodyStation.Text = "复制工站"
        '
        'toolExportChangeLog
        '
        Me.toolExportChangeLog.Image = Global.RCard.My.Resources.Resources.excel
        Me.toolExportChangeLog.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExportChangeLog.Name = "toolExportChangeLog"
        Me.toolExportChangeLog.Size = New System.Drawing.Size(115, 22)
        Me.toolExportChangeLog.Text = "查看变更履历(&P)"
        '
        'FrmRunCardCut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1030, 398)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvCutCardHeader)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.toolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRunCardCut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "RCard.FrmRunCard"
        Me.Text = "裁线卡工艺流程设定"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.barSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuHeader.ResumeLayout(False)
        Me.ContextMenuDetail.ResumeLayout(False)
        Me.ContextMenuBody.ResumeLayout(False)
        CType(Me.dgvCutCardHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvCutCardBody, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPartNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents btnAudit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem8 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem9 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem10 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem11 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem12 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem13 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtSearch As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents barSearch As DevComponents.DotNetBar.Bar
    Friend WithEvents ComboBoxItem1 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents ComboBoxItem2 As DevComponents.DotNetBar.ComboBoxItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SideBar1 As DevComponents.DotNetBar.SideBar
    Friend WithEvents sbPanelFinish As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents sbPanelAudit As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents sbPanelUnfinish As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents ContextMenuHeader As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuDetail As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiPartAdd As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnCopy As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuBody As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiBodyModify As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderModify As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBodyConfirm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvCutCardHeader As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvCutCardBody As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvPartNumber As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents RToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderReject As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolCopyBodyStation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderPrint11 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnExportHeader As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsmiBodyInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtCount As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsmiPartDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHeaderDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StationSQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SectionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkingHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Equipment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessStandard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeftProcessStandard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightProcessStandard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewProcessStandard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LCLValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents toolExportChangeLog As System.Windows.Forms.ToolStripButton
End Class
