<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMouldManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMouldManagement))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolMouldBasis = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStorage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolMouldPic = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolMouldRepair = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolMouldLife = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolMouldOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolMouldIn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolMouldImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolLoadMoBan = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboStorage = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAssetsID = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtParts = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMouldID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabBasis = New System.Windows.Forms.TabPage()
        Me.dgvBasis = New System.Windows.Forms.DataGridView()
        Me.MouldID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UseStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MoldDrawingp = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ProductDrawingp = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.FIlePathp = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.ParaDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MapID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewMouldID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cavitys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Strips = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Slots = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.借出线别 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssetsID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Storage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LimitTimes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlertTimes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsedTimes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FactoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProfileID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.月保养时间 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.季保养时间 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MoldDrawing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductDrawing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIlePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuMould = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi_MaintenanceType = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_MaintenanceDay = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_MaintenanceMonth = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiMaintenanceDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabInOut = New System.Windows.Forms.TabPage()
        Me.dgvInOut = New System.Windows.Forms.DataGridView()
        Me.MouldID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutDeptUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutLineID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutToUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutFromUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApplyPart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Acceptor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabRepair = New System.Windows.Forms.TabPage()
        Me.dgvRepair = New System.Windows.Forms.DataGridView()
        Me.ID3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MouldID3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepartInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepairDeptUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepairDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepairUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepairResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabLife = New System.Windows.Forms.TabPage()
        Me.dgvLife = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MouldID4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsedTimes4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckedTimes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.query = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.tabPastr = New System.Windows.Forms.TabPage()
        Me.dgvPastr = New System.Windows.Forms.DataGridView()
        Me.Mould = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Library = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabBasis.SuspendLayout()
        CType(Me.dgvBasis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuMould.SuspendLayout()
        Me.tabInOut.SuspendLayout()
        CType(Me.dgvInOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRepair.SuspendLayout()
        CType(Me.dgvRepair, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLife.SuspendLayout()
        CType(Me.dgvLife, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPastr.SuspendLayout()
        CType(Me.dgvPastr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolQuery, Me.ToolStripSeparator2, Me.toolMouldBasis, Me.ToolStripSeparator5, Me.toolStorage, Me.ToolStripSeparator7, Me.toolMouldPic, Me.ToolStripSeparator8, Me.toolMouldRepair, Me.ToolStripSeparator10, Me.toolMouldLife, Me.ToolStripSeparator3, Me.toolMouldOut, Me.ToolStripSeparator4, Me.toolMouldIn, Me.ToolStripSeparator6, Me.toolMouldImport, Me.ToolStripSeparator11, Me.toolLoadMoBan, Me.ToolStripSeparator12, Me.toolExit, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1101, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(70, 22)
        Me.toolQuery.Text = "查 询(&F)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolMouldBasis
        '
        Me.toolMouldBasis.Image = CType(resources.GetObject("toolMouldBasis.Image"), System.Drawing.Image)
        Me.toolMouldBasis.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMouldBasis.Name = "toolMouldBasis"
        Me.toolMouldBasis.Size = New System.Drawing.Size(94, 22)
        Me.toolMouldBasis.Text = "基础信息(&N)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'toolStorage
        '
        Me.toolStorage.Image = CType(resources.GetObject("toolStorage.Image"), System.Drawing.Image)
        Me.toolStorage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStorage.Name = "toolStorage"
        Me.toolStorage.Size = New System.Drawing.Size(76, 22)
        Me.toolStorage.Text = "储位维护"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'toolMouldPic
        '
        Me.toolMouldPic.Image = CType(resources.GetObject("toolMouldPic.Image"), System.Drawing.Image)
        Me.toolMouldPic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMouldPic.Name = "toolMouldPic"
        Me.toolMouldPic.Size = New System.Drawing.Size(76, 22)
        Me.toolMouldPic.Text = "模具图档"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'toolMouldRepair
        '
        Me.toolMouldRepair.Image = CType(resources.GetObject("toolMouldRepair.Image"), System.Drawing.Image)
        Me.toolMouldRepair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMouldRepair.Name = "toolMouldRepair"
        Me.toolMouldRepair.Size = New System.Drawing.Size(76, 22)
        Me.toolMouldRepair.Text = "模具维修"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'toolMouldLife
        '
        Me.toolMouldLife.Image = CType(resources.GetObject("toolMouldLife.Image"), System.Drawing.Image)
        Me.toolMouldLife.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMouldLife.Name = "toolMouldLife"
        Me.toolMouldLife.Size = New System.Drawing.Size(100, 22)
        Me.toolMouldLife.Text = "模具寿命管制"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolMouldOut
        '
        Me.toolMouldOut.Image = CType(resources.GetObject("toolMouldOut.Image"), System.Drawing.Image)
        Me.toolMouldOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMouldOut.Name = "toolMouldOut"
        Me.toolMouldOut.Size = New System.Drawing.Size(76, 22)
        Me.toolMouldOut.Text = "模具出库"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolMouldIn
        '
        Me.toolMouldIn.Image = CType(resources.GetObject("toolMouldIn.Image"), System.Drawing.Image)
        Me.toolMouldIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMouldIn.Name = "toolMouldIn"
        Me.toolMouldIn.Size = New System.Drawing.Size(76, 22)
        Me.toolMouldIn.Text = "模具入库"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'toolMouldImport
        '
        Me.toolMouldImport.Image = CType(resources.GetObject("toolMouldImport.Image"), System.Drawing.Image)
        Me.toolMouldImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMouldImport.Name = "toolMouldImport"
        Me.toolMouldImport.Size = New System.Drawing.Size(124, 22)
        Me.toolMouldImport.Text = "模具使用数据导入"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'toolLoadMoBan
        '
        Me.toolLoadMoBan.Image = CType(resources.GetObject("toolLoadMoBan.Image"), System.Drawing.Image)
        Me.toolLoadMoBan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolLoadMoBan.Name = "toolLoadMoBan"
        Me.toolLoadMoBan.Size = New System.Drawing.Size(172, 22)
        Me.toolLoadMoBan.Text = "下载模具使用数据导入模板"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退    出"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1101, 393)
        Me.SplitContainer1.SplitterDistance = 81
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cboStorage)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtAssetsID)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtLocation)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtParts)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtMouldID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1101, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.DarkGray
        Me.Label18.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label18.Location = New System.Drawing.Point(60, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(427, 14)
        Me.Label18.TabIndex = 226
        Me.Label18.Text = "红色表示[达到寿命次数],黄色表示[达到预警次数],白色表示[正常]"
        '
        'cboStorage
        '
        Me.cboStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStorage.FormattingEnabled = True
        Me.cboStorage.Location = New System.Drawing.Point(60, 39)
        Me.cboStorage.Name = "cboStorage"
        Me.cboStorage.Size = New System.Drawing.Size(139, 20)
        Me.cboStorage.TabIndex = 43
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 12)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "储位："
        '
        'txtAssetsID
        '
        Me.txtAssetsID.Location = New System.Drawing.Point(292, 39)
        Me.txtAssetsID.Name = "txtAssetsID"
        Me.txtAssetsID.Size = New System.Drawing.Size(139, 21)
        Me.txtAssetsID.TabIndex = 41
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(226, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "资产编号："
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(531, 9)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(139, 21)
        Me.txtLocation.TabIndex = 39
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(465, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "现有位置："
        '
        'txtParts
        '
        Me.txtParts.Location = New System.Drawing.Point(292, 9)
        Me.txtParts.Name = "txtParts"
        Me.txtParts.Size = New System.Drawing.Size(139, 21)
        Me.txtParts.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(226, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "适应机种："
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"", "0-闲置中", "1-使用中", "2-维修中"})
        Me.cboStatus.Location = New System.Drawing.Point(531, 39)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(139, 20)
        Me.cboStatus.TabIndex = 35
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(465, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 12)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "使用状态："
        '
        'txtMouldID
        '
        Me.txtMouldID.Location = New System.Drawing.Point(60, 9)
        Me.txtMouldID.Name = "txtMouldID"
        Me.txtMouldID.Size = New System.Drawing.Size(139, 21)
        Me.txtMouldID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "模号："
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabBasis)
        Me.TabControl1.Controls.Add(Me.tabInOut)
        Me.TabControl1.Controls.Add(Me.tabRepair)
        Me.TabControl1.Controls.Add(Me.tabLife)
        Me.TabControl1.Controls.Add(Me.tabPastr)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1101, 308)
        Me.TabControl1.TabIndex = 0
        '
        'tabBasis
        '
        Me.tabBasis.Controls.Add(Me.dgvBasis)
        Me.tabBasis.Location = New System.Drawing.Point(4, 22)
        Me.tabBasis.Name = "tabBasis"
        Me.tabBasis.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBasis.Size = New System.Drawing.Size(1093, 282)
        Me.tabBasis.TabIndex = 0
        Me.tabBasis.Text = "基础信息"
        Me.tabBasis.UseVisualStyleBackColor = True
        '
        'dgvBasis
        '
        Me.dgvBasis.AllowUserToAddRows = False
        Me.dgvBasis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBasis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MouldID, Me.UseStatus, Me.MoldDrawingp, Me.ProductDrawingp, Me.FIlePathp, Me.ParaDesc, Me.MapID, Me.NewMouldID, Me.Type, Me.Cavitys, Me.Strips, Me.Tails, Me.Slots, Me.Parts, Me.Location, Me.借出线别, Me.AssetsID, Me.Storage, Me.LimitTimes, Me.AlertTimes, Me.UsedTimes, Me.UserID, Me.Intime, Me.FactoryID, Me.ProfileID, Me.sort, Me.月保养时间, Me.季保养时间, Me.MoldDrawing, Me.ProductDrawing, Me.FIlePath})
        Me.dgvBasis.ContextMenuStrip = Me.ContextMenuMould
        Me.dgvBasis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBasis.Location = New System.Drawing.Point(3, 3)
        Me.dgvBasis.Name = "dgvBasis"
        Me.dgvBasis.ReadOnly = True
        Me.dgvBasis.RowTemplate.Height = 23
        Me.dgvBasis.Size = New System.Drawing.Size(1087, 276)
        Me.dgvBasis.TabIndex = 0
        '
        'MouldID
        '
        Me.MouldID.DataPropertyName = "MouldID"
        Me.MouldID.HeaderText = "模号"
        Me.MouldID.Name = "MouldID"
        Me.MouldID.ReadOnly = True
        '
        'UseStatus
        '
        Me.UseStatus.DataPropertyName = "UseStatus"
        Me.UseStatus.HeaderText = "使用状态"
        Me.UseStatus.Name = "UseStatus"
        Me.UseStatus.ReadOnly = True
        Me.UseStatus.Width = 90
        '
        'MoldDrawingp
        '
        Me.MoldDrawingp.DataPropertyName = "MoldDrawingp"
        Me.MoldDrawingp.HeaderText = "模具图"
        Me.MoldDrawingp.LinkColor = System.Drawing.Color.Red
        Me.MoldDrawingp.Name = "MoldDrawingp"
        Me.MoldDrawingp.ReadOnly = True
        Me.MoldDrawingp.VisitedLinkColor = System.Drawing.Color.Red
        '
        'ProductDrawingp
        '
        Me.ProductDrawingp.DataPropertyName = "ProductDrawingp"
        Me.ProductDrawingp.HeaderText = "产品图"
        Me.ProductDrawingp.LinkColor = System.Drawing.Color.Red
        Me.ProductDrawingp.Name = "ProductDrawingp"
        Me.ProductDrawingp.ReadOnly = True
        Me.ProductDrawingp.VisitedLinkColor = System.Drawing.Color.Red
        '
        'FIlePathp
        '
        Me.FIlePathp.DataPropertyName = "FIlePathp"
        Me.FIlePathp.HeaderText = "报告文件"
        Me.FIlePathp.LinkColor = System.Drawing.Color.Red
        Me.FIlePathp.Name = "FIlePathp"
        Me.FIlePathp.ReadOnly = True
        Me.FIlePathp.VisitedLinkColor = System.Drawing.Color.Red
        '
        'ParaDesc
        '
        Me.ParaDesc.DataPropertyName = "ParaDesc"
        Me.ParaDesc.HeaderText = "尾网OD/线槽OD"
        Me.ParaDesc.Name = "ParaDesc"
        Me.ParaDesc.ReadOnly = True
        Me.ParaDesc.Width = 120
        '
        'MapID
        '
        Me.MapID.DataPropertyName = "MapID"
        Me.MapID.HeaderText = "模具图号"
        Me.MapID.Name = "MapID"
        Me.MapID.ReadOnly = True
        '
        'NewMouldID
        '
        Me.NewMouldID.DataPropertyName = "NewMouldID"
        Me.NewMouldID.HeaderText = "旧模号"
        Me.NewMouldID.Name = "NewMouldID"
        Me.NewMouldID.ReadOnly = True
        '
        'Type
        '
        Me.Type.DataPropertyName = "Type"
        Me.Type.HeaderText = "模别"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        Me.Type.Width = 90
        '
        'Cavitys
        '
        Me.Cavitys.DataPropertyName = "Cavitys"
        Me.Cavitys.HeaderText = "模穴数"
        Me.Cavitys.Name = "Cavitys"
        Me.Cavitys.ReadOnly = True
        Me.Cavitys.Width = 70
        '
        'Strips
        '
        Me.Strips.DataPropertyName = "Strips"
        Me.Strips.HeaderText = "模条数"
        Me.Strips.Name = "Strips"
        Me.Strips.ReadOnly = True
        Me.Strips.Width = 70
        '
        'Tails
        '
        Me.Tails.DataPropertyName = "Tails"
        Me.Tails.HeaderText = "网尾数"
        Me.Tails.Name = "Tails"
        Me.Tails.ReadOnly = True
        Me.Tails.Width = 70
        '
        'Slots
        '
        Me.Slots.DataPropertyName = "Slots"
        Me.Slots.HeaderText = "线槽数"
        Me.Slots.Name = "Slots"
        Me.Slots.ReadOnly = True
        Me.Slots.Width = 70
        '
        'Parts
        '
        Me.Parts.DataPropertyName = "Parts"
        Me.Parts.HeaderText = "适应机种"
        Me.Parts.Name = "Parts"
        Me.Parts.ReadOnly = True
        '
        'Location
        '
        Me.Location.DataPropertyName = "Location"
        Me.Location.HeaderText = "现有位置"
        Me.Location.Name = "Location"
        Me.Location.ReadOnly = True
        '
        '借出线别
        '
        Me.借出线别.DataPropertyName = "OutLineID"
        Me.借出线别.HeaderText = "借出线别"
        Me.借出线别.Name = "借出线别"
        Me.借出线别.ReadOnly = True
        '
        'AssetsID
        '
        Me.AssetsID.DataPropertyName = "AssetsID"
        Me.AssetsID.HeaderText = "资产编号"
        Me.AssetsID.Name = "AssetsID"
        Me.AssetsID.ReadOnly = True
        '
        'Storage
        '
        Me.Storage.DataPropertyName = "Storage"
        Me.Storage.HeaderText = "固定储位"
        Me.Storage.Name = "Storage"
        Me.Storage.ReadOnly = True
        '
        'LimitTimes
        '
        Me.LimitTimes.DataPropertyName = "LimitTimes"
        Me.LimitTimes.HeaderText = "寿命次数"
        Me.LimitTimes.Name = "LimitTimes"
        Me.LimitTimes.ReadOnly = True
        Me.LimitTimes.Width = 85
        '
        'AlertTimes
        '
        Me.AlertTimes.DataPropertyName = "AlertTimes"
        Me.AlertTimes.HeaderText = "预警次数"
        Me.AlertTimes.Name = "AlertTimes"
        Me.AlertTimes.ReadOnly = True
        Me.AlertTimes.Width = 85
        '
        'UsedTimes
        '
        Me.UsedTimes.DataPropertyName = "UsedTimes"
        Me.UsedTimes.HeaderText = "使用次数"
        Me.UsedTimes.Name = "UsedTimes"
        Me.UsedTimes.ReadOnly = True
        Me.UsedTimes.Width = 85
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "创建人"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.DataPropertyName = "Intime"
        Me.Intime.HeaderText = "创建时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'FactoryID
        '
        Me.FactoryID.DataPropertyName = "FactoryID"
        Me.FactoryID.HeaderText = "厂区"
        Me.FactoryID.Name = "FactoryID"
        Me.FactoryID.ReadOnly = True
        '
        'ProfileID
        '
        Me.ProfileID.DataPropertyName = "ProfileID"
        Me.ProfileID.HeaderText = "利润中心"
        Me.ProfileID.Name = "ProfileID"
        Me.ProfileID.ReadOnly = True
        '
        'sort
        '
        Me.sort.DataPropertyName = "sort"
        Me.sort.HeaderText = "sort"
        Me.sort.Name = "sort"
        Me.sort.ReadOnly = True
        Me.sort.Visible = False
        '
        '月保养时间
        '
        Me.月保养时间.DataPropertyName = "NextMonthKeep"
        Me.月保养时间.HeaderText = "月保养时间"
        Me.月保养时间.Name = "月保养时间"
        Me.月保养时间.ReadOnly = True
        '
        '季保养时间
        '
        Me.季保养时间.DataPropertyName = "NextSeasonKeep"
        Me.季保养时间.HeaderText = "季保养时间"
        Me.季保养时间.Name = "季保养时间"
        Me.季保养时间.ReadOnly = True
        '
        'MoldDrawing
        '
        Me.MoldDrawing.DataPropertyName = "MoldDrawing"
        Me.MoldDrawing.HeaderText = "MoldDrawing"
        Me.MoldDrawing.Name = "MoldDrawing"
        Me.MoldDrawing.ReadOnly = True
        Me.MoldDrawing.Visible = False
        '
        'ProductDrawing
        '
        Me.ProductDrawing.DataPropertyName = "ProductDrawing"
        Me.ProductDrawing.HeaderText = "ProductDrawing"
        Me.ProductDrawing.Name = "ProductDrawing"
        Me.ProductDrawing.ReadOnly = True
        Me.ProductDrawing.Visible = False
        '
        'FIlePath
        '
        Me.FIlePath.DataPropertyName = "FIlePath"
        Me.FIlePath.HeaderText = "FIlePath"
        Me.FIlePath.Name = "FIlePath"
        Me.FIlePath.ReadOnly = True
        Me.FIlePath.Visible = False
        '
        'ContextMenuMould
        '
        Me.ContextMenuMould.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_MaintenanceType, Me.tsmi_MaintenanceDay, Me.tsmi_MaintenanceMonth, Me.tsmiMaintenanceDetails})
        Me.ContextMenuMould.Name = "ContextMenuMould"
        Me.ContextMenuMould.Size = New System.Drawing.Size(174, 92)
        '
        'tsmi_MaintenanceType
        '
        Me.tsmi_MaintenanceType.Name = "tsmi_MaintenanceType"
        Me.tsmi_MaintenanceType.Size = New System.Drawing.Size(173, 22)
        Me.tsmi_MaintenanceType.Text = "保养项目维护(&T)"
        '
        'tsmi_MaintenanceDay
        '
        Me.tsmi_MaintenanceDay.Name = "tsmi_MaintenanceDay"
        Me.tsmi_MaintenanceDay.Size = New System.Drawing.Size(173, 22)
        Me.tsmi_MaintenanceDay.Text = "模具日保养(&D)"
        '
        'tsmi_MaintenanceMonth
        '
        Me.tsmi_MaintenanceMonth.Name = "tsmi_MaintenanceMonth"
        Me.tsmi_MaintenanceMonth.Size = New System.Drawing.Size(173, 22)
        Me.tsmi_MaintenanceMonth.Text = "模具月/季保养(&M)"
        '
        'tsmiMaintenanceDetails
        '
        Me.tsmiMaintenanceDetails.Name = "tsmiMaintenanceDetails"
        Me.tsmiMaintenanceDetails.Size = New System.Drawing.Size(173, 22)
        Me.tsmiMaintenanceDetails.Text = "保养明细"
        '
        'tabInOut
        '
        Me.tabInOut.Controls.Add(Me.dgvInOut)
        Me.tabInOut.Location = New System.Drawing.Point(4, 22)
        Me.tabInOut.Name = "tabInOut"
        Me.tabInOut.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInOut.Size = New System.Drawing.Size(1093, 282)
        Me.tabInOut.TabIndex = 1
        Me.tabInOut.Text = "出入库记录"
        Me.tabInOut.UseVisualStyleBackColor = True
        '
        'dgvInOut
        '
        Me.dgvInOut.AllowUserToAddRows = False
        Me.dgvInOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInOut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MouldID2, Me.OutDate, Me.OutDeptUnit, Me.OutLineID, Me.OutToUserId, Me.OutFromUserId, Me.ApplyPart, Me.BackDate, Me.BackUserId, Me.Acceptor, Me.Status, Me.Remark})
        Me.dgvInOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInOut.Location = New System.Drawing.Point(3, 3)
        Me.dgvInOut.Name = "dgvInOut"
        Me.dgvInOut.ReadOnly = True
        Me.dgvInOut.RowTemplate.Height = 23
        Me.dgvInOut.Size = New System.Drawing.Size(1087, 276)
        Me.dgvInOut.TabIndex = 0
        '
        'MouldID2
        '
        Me.MouldID2.DataPropertyName = "MouldID"
        Me.MouldID2.HeaderText = "模号"
        Me.MouldID2.Name = "MouldID2"
        Me.MouldID2.ReadOnly = True
        '
        'OutDate
        '
        Me.OutDate.DataPropertyName = "OutDate"
        Me.OutDate.HeaderText = "调出日期"
        Me.OutDate.Name = "OutDate"
        Me.OutDate.ReadOnly = True
        '
        'OutDeptUnit
        '
        Me.OutDeptUnit.DataPropertyName = "OutDeptUnit"
        Me.OutDeptUnit.HeaderText = "调出单位"
        Me.OutDeptUnit.Name = "OutDeptUnit"
        Me.OutDeptUnit.ReadOnly = True
        '
        'OutLineID
        '
        Me.OutLineID.DataPropertyName = "OutLineID"
        Me.OutLineID.HeaderText = "调出线别"
        Me.OutLineID.Name = "OutLineID"
        Me.OutLineID.ReadOnly = True
        '
        'OutToUserId
        '
        Me.OutToUserId.DataPropertyName = "OutToUserId"
        Me.OutToUserId.HeaderText = "调出责任人"
        Me.OutToUserId.Name = "OutToUserId"
        Me.OutToUserId.ReadOnly = True
        '
        'OutFromUserId
        '
        Me.OutFromUserId.DataPropertyName = "OutFromUserId"
        Me.OutFromUserId.HeaderText = "调出操作人"
        Me.OutFromUserId.Name = "OutFromUserId"
        Me.OutFromUserId.ReadOnly = True
        '
        'ApplyPart
        '
        Me.ApplyPart.DataPropertyName = "ApplyPart"
        Me.ApplyPart.HeaderText = "适应机种"
        Me.ApplyPart.Name = "ApplyPart"
        Me.ApplyPart.ReadOnly = True
        '
        'BackDate
        '
        Me.BackDate.DataPropertyName = "BackDate"
        Me.BackDate.HeaderText = "归还日期"
        Me.BackDate.Name = "BackDate"
        Me.BackDate.ReadOnly = True
        '
        'BackUserId
        '
        Me.BackUserId.DataPropertyName = "BackUserId"
        Me.BackUserId.HeaderText = "归还人"
        Me.BackUserId.Name = "BackUserId"
        Me.BackUserId.ReadOnly = True
        '
        'Acceptor
        '
        Me.Acceptor.DataPropertyName = "Acceptor"
        Me.Acceptor.HeaderText = "归还验收人"
        Me.Acceptor.Name = "Acceptor"
        Me.Acceptor.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "状态"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'tabRepair
        '
        Me.tabRepair.Controls.Add(Me.dgvRepair)
        Me.tabRepair.Location = New System.Drawing.Point(4, 22)
        Me.tabRepair.Name = "tabRepair"
        Me.tabRepair.Size = New System.Drawing.Size(1093, 282)
        Me.tabRepair.TabIndex = 2
        Me.tabRepair.Text = "维修记录"
        Me.tabRepair.UseVisualStyleBackColor = True
        '
        'dgvRepair
        '
        Me.dgvRepair.AllowUserToAddRows = False
        Me.dgvRepair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRepair.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID3, Me.MouldID3, Me.RepartInfo, Me.RepairDeptUnit, Me.RepairDate, Me.RepairUserId, Me.RepairResult, Me.Remark3})
        Me.dgvRepair.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRepair.Location = New System.Drawing.Point(0, 0)
        Me.dgvRepair.Name = "dgvRepair"
        Me.dgvRepair.ReadOnly = True
        Me.dgvRepair.RowTemplate.Height = 23
        Me.dgvRepair.Size = New System.Drawing.Size(1093, 282)
        Me.dgvRepair.TabIndex = 0
        '
        'ID3
        '
        Me.ID3.DataPropertyName = "ID"
        Me.ID3.HeaderText = "ID"
        Me.ID3.Name = "ID3"
        Me.ID3.ReadOnly = True
        Me.ID3.Visible = False
        '
        'MouldID3
        '
        Me.MouldID3.DataPropertyName = "MouldID"
        Me.MouldID3.HeaderText = "送修模号"
        Me.MouldID3.Name = "MouldID3"
        Me.MouldID3.ReadOnly = True
        '
        'RepartInfo
        '
        Me.RepartInfo.DataPropertyName = "RepartInfo"
        Me.RepartInfo.HeaderText = "送修不良状况"
        Me.RepartInfo.Name = "RepartInfo"
        Me.RepartInfo.ReadOnly = True
        '
        'RepairDeptUnit
        '
        Me.RepairDeptUnit.DataPropertyName = "RepairDeptUnit"
        Me.RepairDeptUnit.HeaderText = "送修单位"
        Me.RepairDeptUnit.Name = "RepairDeptUnit"
        Me.RepairDeptUnit.ReadOnly = True
        '
        'RepairDate
        '
        Me.RepairDate.DataPropertyName = "RepairDate"
        Me.RepairDate.HeaderText = "送修时间"
        Me.RepairDate.Name = "RepairDate"
        Me.RepairDate.ReadOnly = True
        Me.RepairDate.Visible = False
        '
        'RepairUserId
        '
        Me.RepairUserId.DataPropertyName = "RepairUserId"
        Me.RepairUserId.HeaderText = "送修人"
        Me.RepairUserId.Name = "RepairUserId"
        Me.RepairUserId.ReadOnly = True
        '
        'RepairResult
        '
        Me.RepairResult.DataPropertyName = "RepairResult"
        Me.RepairResult.HeaderText = "维修试模结果"
        Me.RepairResult.Name = "RepairResult"
        Me.RepairResult.ReadOnly = True
        '
        'Remark3
        '
        Me.Remark3.DataPropertyName = "Remark"
        Me.Remark3.HeaderText = "备注"
        Me.Remark3.Name = "Remark3"
        Me.Remark3.ReadOnly = True
        '
        'tabLife
        '
        Me.tabLife.Controls.Add(Me.dgvLife)
        Me.tabLife.Location = New System.Drawing.Point(4, 22)
        Me.tabLife.Name = "tabLife"
        Me.tabLife.Size = New System.Drawing.Size(1093, 282)
        Me.tabLife.TabIndex = 3
        Me.tabLife.Text = "寿命管制记录"
        Me.tabLife.UseVisualStyleBackColor = True
        '
        'dgvLife
        '
        Me.dgvLife.AllowUserToAddRows = False
        Me.dgvLife.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLife.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.MouldID4, Me.CheckInfo, Me.CheckDate, Me.CheckUserId, Me.UsedTimes4, Me.CheckedTimes, Me.Result, Me.Remark4, Me.query})
        Me.dgvLife.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLife.Location = New System.Drawing.Point(0, 0)
        Me.dgvLife.Name = "dgvLife"
        Me.dgvLife.ReadOnly = True
        Me.dgvLife.RowTemplate.Height = 23
        Me.dgvLife.Size = New System.Drawing.Size(1093, 282)
        Me.dgvLife.TabIndex = 0
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'MouldID4
        '
        Me.MouldID4.DataPropertyName = "MouldID"
        Me.MouldID4.HeaderText = "模号"
        Me.MouldID4.Name = "MouldID4"
        Me.MouldID4.ReadOnly = True
        '
        'CheckInfo
        '
        Me.CheckInfo.DataPropertyName = "CheckInfo"
        Me.CheckInfo.HeaderText = "校验状况"
        Me.CheckInfo.Name = "CheckInfo"
        Me.CheckInfo.ReadOnly = True
        '
        'CheckDate
        '
        Me.CheckDate.DataPropertyName = "CheckDate"
        Me.CheckDate.HeaderText = "校验时间"
        Me.CheckDate.Name = "CheckDate"
        Me.CheckDate.ReadOnly = True
        '
        'CheckUserId
        '
        Me.CheckUserId.DataPropertyName = "CheckUserId"
        Me.CheckUserId.HeaderText = "校验人"
        Me.CheckUserId.Name = "CheckUserId"
        Me.CheckUserId.ReadOnly = True
        '
        'UsedTimes4
        '
        Me.UsedTimes4.DataPropertyName = "UsedTimes"
        Me.UsedTimes4.HeaderText = "使用次数"
        Me.UsedTimes4.Name = "UsedTimes4"
        Me.UsedTimes4.ReadOnly = True
        '
        'CheckedTimes
        '
        Me.CheckedTimes.DataPropertyName = "CheckedTimes"
        Me.CheckedTimes.HeaderText = "校验后使用次数"
        Me.CheckedTimes.Name = "CheckedTimes"
        Me.CheckedTimes.ReadOnly = True
        Me.CheckedTimes.Width = 120
        '
        'Result
        '
        Me.Result.DataPropertyName = "Result"
        Me.Result.HeaderText = "试模结果"
        Me.Result.Name = "Result"
        Me.Result.ReadOnly = True
        '
        'Remark4
        '
        Me.Remark4.DataPropertyName = "Remark"
        Me.Remark4.HeaderText = "备注"
        Me.Remark4.Name = "Remark4"
        Me.Remark4.ReadOnly = True
        Me.Remark4.Width = 160
        '
        'query
        '
        Me.query.HeaderText = "查看明细"
        Me.query.Name = "query"
        Me.query.ReadOnly = True
        Me.query.Text = "查看明细"
        '
        'tabPastr
        '
        Me.tabPastr.Controls.Add(Me.dgvPastr)
        Me.tabPastr.Location = New System.Drawing.Point(4, 22)
        Me.tabPastr.Name = "tabPastr"
        Me.tabPastr.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPastr.Size = New System.Drawing.Size(1093, 282)
        Me.tabPastr.TabIndex = 4
        Me.tabPastr.Text = "模具绑定机种信息记录"
        Me.tabPastr.UseVisualStyleBackColor = True
        '
        'dgvPastr
        '
        Me.dgvPastr.AllowUserToAddRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPastr.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPastr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPastr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Mould, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Line, Me.Library})
        Me.dgvPastr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPastr.Location = New System.Drawing.Point(3, 3)
        Me.dgvPastr.Name = "dgvPastr"
        Me.dgvPastr.ReadOnly = True
        Me.dgvPastr.RowTemplate.Height = 23
        Me.dgvPastr.Size = New System.Drawing.Size(1087, 276)
        Me.dgvPastr.TabIndex = 2
        '
        'Mould
        '
        Me.Mould.DataPropertyName = "MouldID"
        Me.Mould.HeaderText = "模具号"
        Me.Mould.Name = "Mould"
        Me.Mould.ReadOnly = True
        Me.Mould.Width = 90
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Slots"
        Me.DataGridViewTextBoxColumn1.HeaderText = "线槽"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Parts"
        Me.DataGridViewTextBoxColumn2.HeaderText = "机种"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Storage"
        Me.DataGridViewTextBoxColumn3.HeaderText = "储位"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'Line
        '
        Me.Line.DataPropertyName = "Line"
        Me.Line.HeaderText = "线别"
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        '
        'Library
        '
        Me.Library.DataPropertyName = "Library"
        Me.Library.HeaderText = "在库"
        Me.Library.Name = "Library"
        Me.Library.ReadOnly = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(676, 11)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox1.TabIndex = 227
        Me.CheckBox1.Text = "是否有效"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FrmMouldManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 418)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmMouldManagement"
        Me.Text = "模具管理"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabBasis.ResumeLayout(False)
        CType(Me.dgvBasis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuMould.ResumeLayout(False)
        Me.tabInOut.ResumeLayout(False)
        CType(Me.dgvInOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRepair.ResumeLayout(False)
        CType(Me.dgvRepair, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLife.ResumeLayout(False)
        CType(Me.dgvLife, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPastr.ResumeLayout(False)
        CType(Me.dgvPastr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolMouldBasis As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMouldID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStorage As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabBasis As System.Windows.Forms.TabPage
    Friend WithEvents dgvBasis As System.Windows.Forms.DataGridView
    Friend WithEvents tabInOut As System.Windows.Forms.TabPage
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolMouldPic As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolMouldRepair As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolMouldLife As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tabRepair As System.Windows.Forms.TabPage
    Friend WithEvents tabLife As System.Windows.Forms.TabPage
    Friend WithEvents dgvInOut As System.Windows.Forms.DataGridView
    Friend WithEvents dgvRepair As System.Windows.Forms.DataGridView
    Friend WithEvents dgvLife As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtParts As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAssetsID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboStorage As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents toolMouldOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolMouldIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolMouldImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolLoadMoBan As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuMould As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi_MaintenanceType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ID3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MouldID3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepartInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepairDeptUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepairDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepairUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepairResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tsmi_MaintenanceDay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_MaintenanceMonth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiMaintenanceDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MouldID2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutDeptUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutLineID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutToUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutFromUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApplyPart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BackDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BackUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acceptor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tabPastr As System.Windows.Forms.TabPage
    Friend WithEvents dgvPastr As System.Windows.Forms.DataGridView
    Friend WithEvents Mould As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Library As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MouldID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UseStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MoldDrawingp As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ProductDrawingp As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents FIlePathp As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents ParaDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MapID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewMouldID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cavitys As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Strips As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Slots As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 借出线别 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssetsID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Storage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LimitTimes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlertTimes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsedTimes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FactoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProfileID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 月保养时间 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 季保养时间 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MoldDrawing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductDrawing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIlePath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MouldID4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsedTimes4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckedTimes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents query As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
