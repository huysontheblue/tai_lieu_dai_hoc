<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEquipment
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

    '  Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEquipment))
        Me.dgvPA = New System.Windows.Forms.DataGridView()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolPrint = New System.Windows.Forms.ToolStripButton()
        Me.toolSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImport = New System.Windows.Forms.ToolStripButton()
        Me.toolExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolImportPJ = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolMJSMGK = New System.Windows.Forms.ToolStripButton()
        Me.tsmiBtnLoadMoBan = New System.Windows.Forms.ToolStripButton()
        Me.tsmiBtnMojuHuiRu = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.TabEquipment = New System.Windows.Forms.TabControl()
        Me.m131a6_ = New System.Windows.Forms.TabPage()
        Me.m131a7_ = New System.Windows.Forms.TabPage()
        Me.dgvMA = New System.Windows.Forms.DataGridView()
        Me.m131a8_ = New System.Windows.Forms.TabPage()
        Me.dgvMJ = New System.Windows.Forms.DataGridView()
        Me.m131a11_ = New System.Windows.Forms.TabPage()
        Me.dgvFX = New System.Windows.Forms.DataGridView()
        Me.m131a9_ = New System.Windows.Forms.TabPage()
        Me.dgvYPZJ = New System.Windows.Forms.DataGridView()
        Me.m131a10_ = New System.Windows.Forms.TabPage()
        Me.dgvPJ = New System.Windows.Forms.DataGridView()
        Me.M131A013_ = New System.Windows.Forms.TabPage()
        Me.dgvATE = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCopyRecord = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_MaintenanceDay = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_MaintenanceMonth = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_MaintenanceType = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiMaintenanceDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtPartid = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtOutUserID = New System.Windows.Forms.TextBox()
        Me.txtUseMultiple = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtEquipmentNo = New System.Windows.Forms.TextBox()
        Me.dtpNextSeasonKeep = New System.Windows.Forms.DateTimePicker()
        Me.dtpNextMonthKeep = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBoxkc = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkPrint = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.txtStorage = New System.Windows.Forms.TextBox()
        Me.lblStorage = New System.Windows.Forms.Label()
        Me.txtProcessParameters = New System.Windows.Forms.TextBox()
        Me.txtAlertCount = New System.Windows.Forms.TextBox()
        Me.txtRemainCount = New System.Windows.Forms.TextBox()
        Me.txtServiceCount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPrinter = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboInOut = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboBigCategory = New System.Windows.Forms.ComboBox()
        Me.cboSmallCategory = New System.Windows.Forms.ComboBox()
        Me.txtEquipmentPN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboMiddleCategory = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.dgvPA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBt.SuspendLayout()
        Me.TabEquipment.SuspendLayout()
        Me.m131a6_.SuspendLayout()
        Me.m131a7_.SuspendLayout()
        CType(Me.dgvMA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.m131a8_.SuspendLayout()
        CType(Me.dgvMJ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.m131a11_.SuspendLayout()
        CType(Me.dgvFX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.m131a9_.SuspendLayout()
        CType(Me.dgvYPZJ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.m131a10_.SuspendLayout()
        CType(Me.dgvPJ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.M131A013_.SuspendLayout()
        CType(Me.dgvATE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPA
        '
        Me.dgvPA.AllowUserToAddRows = False
        Me.dgvPA.AllowUserToDeleteRows = False
        Me.dgvPA.BackgroundColor = System.Drawing.Color.White
        Me.dgvPA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPA.Location = New System.Drawing.Point(3, 3)
        Me.dgvPA.Name = "dgvPA"
        Me.dgvPA.ReadOnly = True
        Me.dgvPA.RowHeadersVisible = False
        Me.dgvPA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPA.RowTemplate.Height = 23
        Me.dgvPA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPA.Size = New System.Drawing.Size(1279, 330)
        Me.dgvPA.TabIndex = 0
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.toolNew, Me.ToolStripSeparator4, Me.toolModify, Me.ToolStripSeparator5, Me.toolSave, Me.ToolStripSeparator9, Me.toolDelete, Me.ToolStripSeparator10, Me.toolUndo, Me.ToolStripSeparator6, Me.toolPrint, Me.toolSearch, Me.ToolStripSeparator3, Me.toolRefresh, Me.ToolStripSeparator8, Me.toolImport, Me.toolExport, Me.ToolImportPJ, Me.ToolStripSeparator7, Me.toolMJSMGK, Me.tsmiBtnLoadMoBan, Me.tsmiBtnMojuHuiRu, Me.ToolStripSeparator2, Me.toolExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1293, 23)
        Me.ToolBt.TabIndex = 46
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'toolNew
        '
        Me.toolNew.Image = CType(resources.GetObject("toolNew.Image"), System.Drawing.Image)
        Me.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolNew.Name = "toolNew"
        Me.toolNew.Size = New System.Drawing.Size(74, 20)
        Me.toolNew.Tag = "新增"
        Me.toolNew.Text = "新 增(&N)"
        Me.toolNew.ToolTipText = "新增"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'toolModify
        '
        Me.toolModify.Image = CType(resources.GetObject("toolModify.Image"), System.Drawing.Image)
        Me.toolModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModify.Name = "toolModify"
        Me.toolModify.Size = New System.Drawing.Size(71, 20)
        Me.toolModify.Tag = "修改"
        Me.toolModify.Text = "修 改(&E)"
        Me.toolModify.ToolTipText = "修 改"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'toolSave
        '
        Me.toolSave.Enabled = False
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(71, 20)
        Me.toolSave.Text = "保 存(&S)"
        Me.toolSave.ToolTipText = "保存"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 23)
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(73, 20)
        Me.toolDelete.Tag = "删 除"
        Me.toolDelete.Text = "删 除(&D)"
        Me.toolDelete.ToolTipText = "刪除"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 23)
        '
        'toolUndo
        '
        Me.toolUndo.Enabled = False
        Me.toolUndo.Image = CType(resources.GetObject("toolUndo.Image"), System.Drawing.Image)
        Me.toolUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolUndo.Name = "toolUndo"
        Me.toolUndo.Size = New System.Drawing.Size(68, 20)
        Me.toolUndo.Text = "返回(&C)"
        Me.toolUndo.ToolTipText = "返回"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'toolPrint
        '
        Me.toolPrint.Image = CType(resources.GetObject("toolPrint.Image"), System.Drawing.Image)
        Me.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolPrint.Name = "toolPrint"
        Me.toolPrint.Size = New System.Drawing.Size(71, 20)
        Me.toolPrint.Tag = "NO"
        Me.toolPrint.Text = "列 印(&P)"
        '
        'toolSearch
        '
        Me.toolSearch.Image = CType(resources.GetObject("toolSearch.Image"), System.Drawing.Image)
        Me.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSearch.Name = "toolSearch"
        Me.toolSearch.Size = New System.Drawing.Size(70, 20)
        Me.toolSearch.Text = "查 找(&F)"
        Me.toolSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'toolRefresh
        '
        Me.toolRefresh.Image = CType(resources.GetObject("toolRefresh.Image"), System.Drawing.Image)
        Me.toolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolRefresh.Name = "toolRefresh"
        Me.toolRefresh.Size = New System.Drawing.Size(72, 20)
        Me.toolRefresh.Text = "刷 新(&R)"
        Me.toolRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
        '
        'toolImport
        '
        Me.toolImport.Image = CType(resources.GetObject("toolImport.Image"), System.Drawing.Image)
        Me.toolImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImport.Name = "toolImport"
        Me.toolImport.Size = New System.Drawing.Size(64, 20)
        Me.toolImport.Text = "汇   入"
        '
        'toolExport
        '
        Me.toolExport.Image = CType(resources.GetObject("toolExport.Image"), System.Drawing.Image)
        Me.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExport.Name = "toolExport"
        Me.toolExport.Size = New System.Drawing.Size(64, 20)
        Me.toolExport.Text = "汇   出"
        '
        'ToolImportPJ
        '
        Me.ToolImportPJ.Image = CType(resources.GetObject("ToolImportPJ.Image"), System.Drawing.Image)
        Me.ToolImportPJ.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolImportPJ.Name = "ToolImportPJ"
        Me.ToolImportPJ.Size = New System.Drawing.Size(76, 20)
        Me.ToolImportPJ.Text = "配件汇入"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'toolMJSMGK
        '
        Me.toolMJSMGK.Enabled = False
        Me.toolMJSMGK.Image = CType(resources.GetObject("toolMJSMGK.Image"), System.Drawing.Image)
        Me.toolMJSMGK.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMJSMGK.Name = "toolMJSMGK"
        Me.toolMJSMGK.Size = New System.Drawing.Size(124, 20)
        Me.toolMJSMGK.Tag = "模具寿命管制维护"
        Me.toolMJSMGK.Text = "模具寿命管制维护"
        '
        'tsmiBtnLoadMoBan
        '
        Me.tsmiBtnLoadMoBan.Image = CType(resources.GetObject("tsmiBtnLoadMoBan.Image"), System.Drawing.Image)
        Me.tsmiBtnLoadMoBan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsmiBtnLoadMoBan.Name = "tsmiBtnLoadMoBan"
        Me.tsmiBtnLoadMoBan.Size = New System.Drawing.Size(148, 20)
        Me.tsmiBtnLoadMoBan.Text = "下载模具导入准表模板"
        '
        'tsmiBtnMojuHuiRu
        '
        Me.tsmiBtnMojuHuiRu.Image = CType(resources.GetObject("tsmiBtnMojuHuiRu.Image"), System.Drawing.Image)
        Me.tsmiBtnMojuHuiRu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsmiBtnMojuHuiRu.Name = "tsmiBtnMojuHuiRu"
        Me.tsmiBtnMojuHuiRu.Size = New System.Drawing.Size(80, 20)
        Me.tsmiBtnMojuHuiRu.Text = "模具汇 入"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 20)
        Me.toolExit.Text = "退 出(&X)"
        Me.toolExit.ToolTipText = "退出"
        '
        'TabEquipment
        '
        Me.TabEquipment.Controls.Add(Me.m131a6_)
        Me.TabEquipment.Controls.Add(Me.m131a7_)
        Me.TabEquipment.Controls.Add(Me.m131a8_)
        Me.TabEquipment.Controls.Add(Me.m131a11_)
        Me.TabEquipment.Controls.Add(Me.m131a9_)
        Me.TabEquipment.Controls.Add(Me.m131a10_)
        Me.TabEquipment.Controls.Add(Me.M131A013_)
        Me.TabEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabEquipment.Location = New System.Drawing.Point(0, 0)
        Me.TabEquipment.Name = "TabEquipment"
        Me.TabEquipment.SelectedIndex = 0
        Me.TabEquipment.Size = New System.Drawing.Size(1293, 362)
        Me.TabEquipment.TabIndex = 0
        '
        'm131a6_
        '
        Me.m131a6_.Controls.Add(Me.dgvPA)
        Me.m131a6_.Location = New System.Drawing.Point(4, 22)
        Me.m131a6_.Name = "m131a6_"
        Me.m131a6_.Padding = New System.Windows.Forms.Padding(3)
        Me.m131a6_.Size = New System.Drawing.Size(1285, 336)
        Me.m131a6_.TabIndex = 0
        Me.m131a6_.Text = "标准部件"
        Me.m131a6_.UseVisualStyleBackColor = True
        '
        'm131a7_
        '
        Me.m131a7_.Controls.Add(Me.dgvMA)
        Me.m131a7_.Location = New System.Drawing.Point(4, 22)
        Me.m131a7_.Name = "m131a7_"
        Me.m131a7_.Padding = New System.Windows.Forms.Padding(3)
        Me.m131a7_.Size = New System.Drawing.Size(1285, 336)
        Me.m131a7_.TabIndex = 1
        Me.m131a7_.Text = "机台设备"
        Me.m131a7_.UseVisualStyleBackColor = True
        '
        'dgvMA
        '
        Me.dgvMA.AllowUserToAddRows = False
        Me.dgvMA.BackgroundColor = System.Drawing.Color.White
        Me.dgvMA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMA.Location = New System.Drawing.Point(3, 3)
        Me.dgvMA.Name = "dgvMA"
        Me.dgvMA.ReadOnly = True
        Me.dgvMA.RowHeadersVisible = False
        Me.dgvMA.RowTemplate.Height = 23
        Me.dgvMA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMA.Size = New System.Drawing.Size(1279, 330)
        Me.dgvMA.TabIndex = 0
        '
        'm131a8_
        '
        Me.m131a8_.Controls.Add(Me.dgvMJ)
        Me.m131a8_.Location = New System.Drawing.Point(4, 22)
        Me.m131a8_.Name = "m131a8_"
        Me.m131a8_.Padding = New System.Windows.Forms.Padding(3)
        Me.m131a8_.Size = New System.Drawing.Size(1285, 336)
        Me.m131a8_.TabIndex = 2
        Me.m131a8_.Text = "模具"
        Me.m131a8_.UseVisualStyleBackColor = True
        '
        'dgvMJ
        '
        Me.dgvMJ.AllowUserToAddRows = False
        Me.dgvMJ.BackgroundColor = System.Drawing.Color.White
        Me.dgvMJ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMJ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMJ.Location = New System.Drawing.Point(3, 3)
        Me.dgvMJ.Name = "dgvMJ"
        Me.dgvMJ.RowHeadersVisible = False
        Me.dgvMJ.RowTemplate.Height = 23
        Me.dgvMJ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMJ.Size = New System.Drawing.Size(1279, 330)
        Me.dgvMJ.TabIndex = 0
        '
        'm131a11_
        '
        Me.m131a11_.Controls.Add(Me.dgvFX)
        Me.m131a11_.Location = New System.Drawing.Point(4, 22)
        Me.m131a11_.Name = "m131a11_"
        Me.m131a11_.Padding = New System.Windows.Forms.Padding(3)
        Me.m131a11_.Size = New System.Drawing.Size(1285, 336)
        Me.m131a11_.TabIndex = 3
        Me.m131a11_.Text = "治具"
        Me.m131a11_.UseVisualStyleBackColor = True
        '
        'dgvFX
        '
        Me.dgvFX.AllowUserToAddRows = False
        Me.dgvFX.BackgroundColor = System.Drawing.Color.White
        Me.dgvFX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFX.Location = New System.Drawing.Point(3, 3)
        Me.dgvFX.Name = "dgvFX"
        Me.dgvFX.RowHeadersVisible = False
        Me.dgvFX.RowTemplate.Height = 23
        Me.dgvFX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvFX.Size = New System.Drawing.Size(1279, 330)
        Me.dgvFX.TabIndex = 1
        '
        'm131a9_
        '
        Me.m131a9_.Controls.Add(Me.dgvYPZJ)
        Me.m131a9_.Location = New System.Drawing.Point(4, 22)
        Me.m131a9_.Name = "m131a9_"
        Me.m131a9_.Padding = New System.Windows.Forms.Padding(3)
        Me.m131a9_.Size = New System.Drawing.Size(1285, 336)
        Me.m131a9_.TabIndex = 4
        Me.m131a9_.Text = "样品治具"
        Me.m131a9_.UseVisualStyleBackColor = True
        '
        'dgvYPZJ
        '
        Me.dgvYPZJ.AllowUserToAddRows = False
        Me.dgvYPZJ.BackgroundColor = System.Drawing.Color.White
        Me.dgvYPZJ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvYPZJ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvYPZJ.Location = New System.Drawing.Point(3, 3)
        Me.dgvYPZJ.Name = "dgvYPZJ"
        Me.dgvYPZJ.RowHeadersVisible = False
        Me.dgvYPZJ.RowTemplate.Height = 23
        Me.dgvYPZJ.Size = New System.Drawing.Size(1279, 330)
        Me.dgvYPZJ.TabIndex = 0
        '
        'm131a10_
        '
        Me.m131a10_.Controls.Add(Me.dgvPJ)
        Me.m131a10_.Location = New System.Drawing.Point(4, 22)
        Me.m131a10_.Name = "m131a10_"
        Me.m131a10_.Padding = New System.Windows.Forms.Padding(3)
        Me.m131a10_.Size = New System.Drawing.Size(1285, 336)
        Me.m131a10_.TabIndex = 5
        Me.m131a10_.Text = "消耗性配件"
        Me.m131a10_.UseVisualStyleBackColor = True
        '
        'dgvPJ
        '
        Me.dgvPJ.AllowUserToAddRows = False
        Me.dgvPJ.BackgroundColor = System.Drawing.Color.White
        Me.dgvPJ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPJ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPJ.Location = New System.Drawing.Point(3, 3)
        Me.dgvPJ.Name = "dgvPJ"
        Me.dgvPJ.RowHeadersVisible = False
        Me.dgvPJ.RowTemplate.Height = 23
        Me.dgvPJ.Size = New System.Drawing.Size(1279, 330)
        Me.dgvPJ.TabIndex = 1
        '
        'M131A013_
        '
        Me.M131A013_.Controls.Add(Me.dgvATE)
        Me.M131A013_.Location = New System.Drawing.Point(4, 22)
        Me.M131A013_.Name = "M131A013_"
        Me.M131A013_.Padding = New System.Windows.Forms.Padding(3)
        Me.M131A013_.Size = New System.Drawing.Size(1285, 336)
        Me.M131A013_.TabIndex = 6
        Me.M131A013_.Text = "声学测试治具"
        Me.M131A013_.UseVisualStyleBackColor = True
        '
        'dgvATE
        '
        Me.dgvATE.AllowUserToAddRows = False
        Me.dgvATE.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvATE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvATE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvATE.Location = New System.Drawing.Point(3, 3)
        Me.dgvATE.Name = "dgvATE"
        Me.dgvATE.RowHeadersVisible = False
        Me.dgvATE.RowTemplate.Height = 23
        Me.dgvATE.Size = New System.Drawing.Size(1279, 330)
        Me.dgvATE.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCopy, Me.tsmiCopyRecord, Me.tsmi_MaintenanceDay, Me.tsmi_MaintenanceMonth, Me.tsmi_MaintenanceType, Me.tsmiMaintenanceDetails})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(174, 136)
        '
        'tsmiCopy
        '
        Me.tsmiCopy.Image = CType(resources.GetObject("tsmiCopy.Image"), System.Drawing.Image)
        Me.tsmiCopy.Name = "tsmiCopy"
        Me.tsmiCopy.Size = New System.Drawing.Size(173, 22)
        Me.tsmiCopy.Tag = "复制"
        Me.tsmiCopy.Text = "复制(&C)"
        '
        'tsmiCopyRecord
        '
        Me.tsmiCopyRecord.Image = CType(resources.GetObject("tsmiCopyRecord.Image"), System.Drawing.Image)
        Me.tsmiCopyRecord.Name = "tsmiCopyRecord"
        Me.tsmiCopyRecord.Size = New System.Drawing.Size(173, 22)
        Me.tsmiCopyRecord.Tag = "复制记录"
        Me.tsmiCopyRecord.Text = "复制记录(&R)"
        '
        'tsmi_MaintenanceDay
        '
        Me.tsmi_MaintenanceDay.Name = "tsmi_MaintenanceDay"
        Me.tsmi_MaintenanceDay.Size = New System.Drawing.Size(173, 22)
        Me.tsmi_MaintenanceDay.Text = "治具日保养(&D)"
        '
        'tsmi_MaintenanceMonth
        '
        Me.tsmi_MaintenanceMonth.Name = "tsmi_MaintenanceMonth"
        Me.tsmi_MaintenanceMonth.Size = New System.Drawing.Size(173, 22)
        Me.tsmi_MaintenanceMonth.Text = "治具月/季保养(&M)"
        '
        'tsmi_MaintenanceType
        '
        Me.tsmi_MaintenanceType.Name = "tsmi_MaintenanceType"
        Me.tsmi_MaintenanceType.Size = New System.Drawing.Size(173, 22)
        Me.tsmi_MaintenanceType.Text = "保养项目维护(&T)"
        '
        'tsmiMaintenanceDetails
        '
        Me.tsmiMaintenanceDetails.Name = "tsmiMaintenanceDetails"
        Me.tsmiMaintenanceDetails.Size = New System.Drawing.Size(173, 22)
        Me.tsmiMaintenanceDetails.Text = "保养明细"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 483)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1293, 22)
        Me.StatusStrip1.TabIndex = 48
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStatusLabel
        '
        Me.ToolStatusLabel.Name = "ToolStatusLabel"
        Me.ToolStatusLabel.Size = New System.Drawing.Size(100, 17)
        Me.ToolStatusLabel.Text = "ToolStatusLabel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtPartid)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtOutUserID)
        Me.GroupBox1.Controls.Add(Me.txtUseMultiple)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtEquipmentNo)
        Me.GroupBox1.Controls.Add(Me.dtpNextSeasonKeep)
        Me.GroupBox1.Controls.Add(Me.dtpNextMonthKeep)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.TextBoxkc)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.chkPrint)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtLine)
        Me.GroupBox1.Controls.Add(Me.txtStorage)
        Me.GroupBox1.Controls.Add(Me.lblStorage)
        Me.GroupBox1.Controls.Add(Me.txtProcessParameters)
        Me.GroupBox1.Controls.Add(Me.txtAlertCount)
        Me.GroupBox1.Controls.Add(Me.txtRemainCount)
        Me.GroupBox1.Controls.Add(Me.txtServiceCount)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboPrinter)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cboInOut)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboBigCategory)
        Me.GroupBox1.Controls.Add(Me.cboSmallCategory)
        Me.GroupBox1.Controls.Add(Me.txtEquipmentPN)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cboMiddleCategory)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1293, 94)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(277, 14)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 12)
        Me.Label19.TabIndex = 113
        Me.Label19.Text = "产品料号："
        '
        'txtPartid
        '
        Me.txtPartid.Location = New System.Drawing.Point(342, 11)
        Me.txtPartid.Name = "txtPartid"
        Me.txtPartid.Size = New System.Drawing.Size(120, 21)
        Me.txtPartid.TabIndex = 112
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(485, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 12)
        Me.Label18.TabIndex = 111
        Me.Label18.Text = "借出工号:"
        '
        'txtOutUserID
        '
        Me.txtOutUserID.Location = New System.Drawing.Point(550, 70)
        Me.txtOutUserID.Name = "txtOutUserID"
        Me.txtOutUserID.Size = New System.Drawing.Size(61, 21)
        Me.txtOutUserID.TabIndex = 110
        '
        'txtUseMultiple
        '
        Me.txtUseMultiple.Location = New System.Drawing.Point(849, 65)
        Me.txtUseMultiple.Name = "txtUseMultiple"
        Me.txtUseMultiple.Size = New System.Drawing.Size(48, 21)
        Me.txtUseMultiple.TabIndex = 109
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(768, 71)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(83, 12)
        Me.Label17.TabIndex = 108
        Me.Label17.Text = "模具使用倍数:"
        '
        'txtEquipmentNo
        '
        Me.txtEquipmentNo.Location = New System.Drawing.Point(64, 11)
        Me.txtEquipmentNo.MaxLength = 50
        Me.txtEquipmentNo.Name = "txtEquipmentNo"
        Me.txtEquipmentNo.Size = New System.Drawing.Size(206, 21)
        Me.txtEquipmentNo.TabIndex = 107
        '
        'dtpNextSeasonKeep
        '
        Me.dtpNextSeasonKeep.CustomFormat = " "
        Me.dtpNextSeasonKeep.Enabled = False
        Me.dtpNextSeasonKeep.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNextSeasonKeep.Location = New System.Drawing.Point(992, 68)
        Me.dtpNextSeasonKeep.Name = "dtpNextSeasonKeep"
        Me.dtpNextSeasonKeep.Size = New System.Drawing.Size(100, 21)
        Me.dtpNextSeasonKeep.TabIndex = 106
        '
        'dtpNextMonthKeep
        '
        Me.dtpNextMonthKeep.CustomFormat = " "
        Me.dtpNextMonthKeep.Enabled = False
        Me.dtpNextMonthKeep.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNextMonthKeep.Location = New System.Drawing.Point(1188, 68)
        Me.dtpNextMonthKeep.Name = "dtpNextMonthKeep"
        Me.dtpNextMonthKeep.Size = New System.Drawing.Size(100, 21)
        Me.dtpNextMonthKeep.TabIndex = 105
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(895, 71)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 12)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "下次季保养日期:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1098, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 12)
        Me.Label15.TabIndex = 103
        Me.Label15.Text = "下次月保养日期:"
        '
        'TextBoxkc
        '
        Me.TextBoxkc.Location = New System.Drawing.Point(445, 68)
        Me.TextBoxkc.Name = "TextBoxkc"
        Me.TextBoxkc.Size = New System.Drawing.Size(40, 21)
        Me.TextBoxkc.TabIndex = 102
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(390, 73)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 12)
        Me.Label14.TabIndex = 101
        Me.Label14.Text = "安全库存:"
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Location = New System.Drawing.Point(622, 70)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(144, 16)
        Me.chkPrint.TabIndex = 100
        Me.chkPrint.Text = "刀模模板打印(大标签)"
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(258, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "借出线别:"
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.White
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"", "0.无效", "1.有效", "2.待检收"})
        Me.cboStatus.Location = New System.Drawing.Point(652, 41)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(84, 20)
        Me.cboStatus.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(608, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "状态:"
        '
        'txtLine
        '
        Me.txtLine.Location = New System.Drawing.Point(323, 68)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(61, 21)
        Me.txtLine.TabIndex = 10
        '
        'txtStorage
        '
        Me.txtStorage.Location = New System.Drawing.Point(64, 67)
        Me.txtStorage.Name = "txtStorage"
        Me.txtStorage.Size = New System.Drawing.Size(54, 21)
        Me.txtStorage.TabIndex = 3
        '
        'lblStorage
        '
        Me.lblStorage.AutoSize = True
        Me.lblStorage.Location = New System.Drawing.Point(27, 68)
        Me.lblStorage.Name = "lblStorage"
        Me.lblStorage.Size = New System.Drawing.Size(35, 12)
        Me.lblStorage.TabIndex = 90
        Me.lblStorage.Text = "储位:"
        '
        'txtProcessParameters
        '
        Me.txtProcessParameters.Location = New System.Drawing.Point(952, 39)
        Me.txtProcessParameters.Name = "txtProcessParameters"
        Me.txtProcessParameters.Size = New System.Drawing.Size(336, 21)
        Me.txtProcessParameters.TabIndex = 7
        Me.txtProcessParameters.Tag = "加工参数"
        '
        'txtAlertCount
        '
        Me.txtAlertCount.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtAlertCount.Location = New System.Drawing.Point(375, 39)
        Me.txtAlertCount.Name = "txtAlertCount"
        Me.txtAlertCount.Size = New System.Drawing.Size(65, 21)
        Me.txtAlertCount.TabIndex = 5
        Me.txtAlertCount.Tag = "预警次数"
        '
        'txtRemainCount
        '
        Me.txtRemainCount.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtRemainCount.Location = New System.Drawing.Point(189, 67)
        Me.txtRemainCount.Name = "txtRemainCount"
        Me.txtRemainCount.Size = New System.Drawing.Size(65, 21)
        Me.txtRemainCount.TabIndex = 6
        Me.txtRemainCount.Tag = "剩余次数"
        '
        'txtServiceCount
        '
        Me.txtServiceCount.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtServiceCount.Location = New System.Drawing.Point(811, 40)
        Me.txtServiceCount.Name = "txtServiceCount"
        Me.txtServiceCount.Size = New System.Drawing.Size(65, 21)
        Me.txtServiceCount.TabIndex = 4
        Me.txtServiceCount.Tag = "使用次数"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(895, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "加工参数:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(750, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "使用次数:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(124, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "剩余次数:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(314, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "预警次数:"
        '
        'cboPrinter
        '
        Me.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrinter.FormattingEnabled = True
        Me.cboPrinter.Location = New System.Drawing.Point(1045, 12)
        Me.cboPrinter.Name = "cboPrinter"
        Me.cboPrinter.Size = New System.Drawing.Size(243, 20)
        Me.cboPrinter.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(995, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 12)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "打印机:"
        '
        'cboInOut
        '
        Me.cboInOut.BackColor = System.Drawing.Color.White
        Me.cboInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInOut.FormattingEnabled = True
        Me.cboInOut.Items.AddRange(New Object() {"", "0.借出", "1.在库"})
        Me.cboInOut.Location = New System.Drawing.Point(509, 40)
        Me.cboInOut.Name = "cboInOut"
        Me.cboInOut.Size = New System.Drawing.Size(85, 20)
        Me.cboInOut.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(447, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 12)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "在库状态:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(468, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "大分类:"
        '
        'cboBigCategory
        '
        Me.cboBigCategory.BackColor = System.Drawing.Color.White
        Me.cboBigCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBigCategory.FormattingEnabled = True
        Me.cboBigCategory.Location = New System.Drawing.Point(518, 11)
        Me.cboBigCategory.Name = "cboBigCategory"
        Me.cboBigCategory.Size = New System.Drawing.Size(120, 20)
        Me.cboBigCategory.TabIndex = 2
        '
        'cboSmallCategory
        '
        Me.cboSmallCategory.BackColor = System.Drawing.Color.White
        Me.cboSmallCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSmallCategory.FormattingEnabled = True
        Me.cboSmallCategory.Location = New System.Drawing.Point(869, 13)
        Me.cboSmallCategory.Name = "cboSmallCategory"
        Me.cboSmallCategory.Size = New System.Drawing.Size(120, 20)
        Me.cboSmallCategory.TabIndex = 2
        '
        'txtEquipmentPN
        '
        Me.txtEquipmentPN.Location = New System.Drawing.Point(64, 40)
        Me.txtEquipmentPN.MaxLength = 50
        Me.txtEquipmentPN.Name = "txtEquipmentPN"
        Me.txtEquipmentPN.Size = New System.Drawing.Size(206, 21)
        Me.txtEquipmentPN.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "设备料号:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "设备编号:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(816, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 12)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "小分类:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(643, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 12)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "中分类:"
        '
        'cboMiddleCategory
        '
        Me.cboMiddleCategory.BackColor = System.Drawing.Color.White
        Me.cboMiddleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMiddleCategory.FormattingEnabled = True
        Me.cboMiddleCategory.Location = New System.Drawing.Point(690, 13)
        Me.cboMiddleCategory.Name = "cboMiddleCategory"
        Me.cboMiddleCategory.Size = New System.Drawing.Size(120, 20)
        Me.cboMiddleCategory.TabIndex = 2
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 23)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabEquipment)
        Me.SplitContainer1.Size = New System.Drawing.Size(1293, 460)
        Me.SplitContainer1.SplitterDistance = 94
        Me.SplitContainer1.TabIndex = 1
        '
        'FrmEquipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1293, 505)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmEquipment"
        Me.Text = "载治具基础资料维护"
        CType(Me.dgvPA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.TabEquipment.ResumeLayout(False)
        Me.m131a6_.ResumeLayout(False)
        Me.m131a7_.ResumeLayout(False)
        CType(Me.dgvMA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.m131a8_.ResumeLayout(False)
        CType(Me.dgvMJ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.m131a11_.ResumeLayout(False)
        CType(Me.dgvFX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.m131a9_.ResumeLayout(False)
        CType(Me.dgvYPZJ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.m131a10_.ResumeLayout(False)
        CType(Me.dgvPJ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.M131A013_.ResumeLayout(False)
        CType(Me.dgvATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabEquipment As System.Windows.Forms.TabControl
    Friend WithEvents m131a6_ As System.Windows.Forms.TabPage
    Friend WithEvents m131a7_ As System.Windows.Forms.TabPage
    Friend WithEvents m131a8_ As System.Windows.Forms.TabPage
    Friend WithEvents dgvPA As System.Windows.Forms.DataGridView
    Friend WithEvents dgvMA As System.Windows.Forms.DataGridView
    Friend WithEvents dgvMJ As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCopyRecord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m131a11_ As System.Windows.Forms.TabPage
    Friend WithEvents dgvFX As System.Windows.Forms.DataGridView
    Friend WithEvents toolExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLine As System.Windows.Forms.TextBox
    Friend WithEvents txtStorage As System.Windows.Forms.TextBox
    Friend WithEvents lblStorage As System.Windows.Forms.Label
    Friend WithEvents txtProcessParameters As System.Windows.Forms.TextBox
    Friend WithEvents txtAlertCount As System.Windows.Forms.TextBox
    Friend WithEvents txtRemainCount As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceCount As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboInOut As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboMiddleCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboBigCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboSmallCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtEquipmentPN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
    Friend WithEvents tsmi_MaintenanceDay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_MaintenanceMonth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_MaintenanceType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m131a9_ As System.Windows.Forms.TabPage
    Friend WithEvents dgvYPZJ As System.Windows.Forms.DataGridView
    Friend WithEvents m131a10_ As System.Windows.Forms.TabPage
    Friend WithEvents dgvPJ As System.Windows.Forms.DataGridView
    Friend WithEvents ToolImportPJ As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolMJSMGK As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBoxkc As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpNextMonthKeep As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpNextSeasonKeep As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEquipmentNo As System.Windows.Forms.TextBox
    Friend WithEvents tsmiMaintenanceDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtUseMultiple As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtOutUserID As System.Windows.Forms.TextBox
    Friend WithEvents tsmiBtnLoadMoBan As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsmiBtnMojuHuiRu As System.Windows.Forms.ToolStripButton
    Friend WithEvents M131A013_ As System.Windows.Forms.TabPage
    Friend WithEvents dgvATE As System.Windows.Forms.DataGridView
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtPartid As System.Windows.Forms.TextBox
End Class
