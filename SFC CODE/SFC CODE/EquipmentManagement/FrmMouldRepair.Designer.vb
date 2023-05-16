<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMouldRepair
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMouldRepair))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolBeginRepair = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolEndRepair = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUseStatus = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtStorage = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.txtAssetsID = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSlots = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTails = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtStrips = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCavitys = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNewMouldID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMapID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtParaDesc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtApplyPart = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtMouldID = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboRepairResult = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRepairUserId = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRepairDeptUnit = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRepartInfo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtRepairDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvMouldRepair = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MouldID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepartInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepairDeptUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepairDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepairUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RepairResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMouldRepair, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBeginRepair, Me.ToolStripSeparator1, Me.toolEndRepair, Me.toolStripSeparator4, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(941, 25)
        Me.toolStrip1.TabIndex = 134
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolBeginRepair
        '
        Me.toolBeginRepair.Image = CType(resources.GetObject("toolBeginRepair.Image"), System.Drawing.Image)
        Me.toolBeginRepair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBeginRepair.Name = "toolBeginRepair"
        Me.toolBeginRepair.Size = New System.Drawing.Size(91, 22)
        Me.toolBeginRepair.Tag = "新 增"
        Me.toolBeginRepair.Text = "开始维修(&B)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolEndRepair
        '
        Me.toolEndRepair.Image = CType(resources.GetObject("toolEndRepair.Image"), System.Drawing.Image)
        Me.toolEndRepair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEndRepair.Name = "toolEndRepair"
        Me.toolEndRepair.Size = New System.Drawing.Size(91, 22)
        Me.toolEndRepair.Tag = ""
        Me.toolEndRepair.Text = "维修结束(&E)"
        Me.toolEndRepair.ToolTipText = "维修结束(E)"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(73, 22)
        Me.toolExit.Text = "退 出(&X)"
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvMouldRepair)
        Me.SplitContainer1.Size = New System.Drawing.Size(941, 483)
        Me.SplitContainer1.SplitterDistance = 214
        Me.SplitContainer1.TabIndex = 135
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUseStatus)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtStorage)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtType)
        Me.GroupBox1.Controls.Add(Me.txtAssetsID)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtLocation)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtSlots)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtTails)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtStrips)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtCavitys)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtNewMouldID)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtMapID)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtParaDesc)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtApplyPart)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtMouldID)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboRepairResult)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtRepairUserId)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtRepairDeptUnit)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtRepartInfo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtRepairDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(941, 214)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtUseStatus
        '
        Me.txtUseStatus.Location = New System.Drawing.Point(73, 129)
        Me.txtUseStatus.Name = "txtUseStatus"
        Me.txtUseStatus.ReadOnly = True
        Me.txtUseStatus.Size = New System.Drawing.Size(100, 21)
        Me.txtUseStatus.TabIndex = 277
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 133)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 276
        Me.Label18.Text = "使用状态："
        '
        'txtStorage
        '
        Me.txtStorage.Location = New System.Drawing.Point(823, 158)
        Me.txtStorage.Name = "txtStorage"
        Me.txtStorage.ReadOnly = True
        Me.txtStorage.Size = New System.Drawing.Size(100, 21)
        Me.txtStorage.TabIndex = 275
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(757, 161)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 12)
        Me.Label19.TabIndex = 274
        Me.Label19.Text = "固定储位："
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(73, 158)
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.Size = New System.Drawing.Size(100, 21)
        Me.txtType.TabIndex = 273
        '
        'txtAssetsID
        '
        Me.txtAssetsID.Location = New System.Drawing.Point(450, 187)
        Me.txtAssetsID.Name = "txtAssetsID"
        Me.txtAssetsID.ReadOnly = True
        Me.txtAssetsID.Size = New System.Drawing.Size(109, 21)
        Me.txtAssetsID.TabIndex = 272
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(382, 191)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 271
        Me.Label12.Text = "资产编号："
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(256, 187)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(100, 21)
        Me.txtLocation.TabIndex = 270
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(190, 191)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 269
        Me.Label11.Text = "现有位置："
        '
        'txtSlots
        '
        Me.txtSlots.Location = New System.Drawing.Point(73, 187)
        Me.txtSlots.Name = "txtSlots"
        Me.txtSlots.ReadOnly = True
        Me.txtSlots.Size = New System.Drawing.Size(100, 21)
        Me.txtSlots.TabIndex = 268
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 191)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 267
        Me.Label13.Text = "线槽数："
        '
        'txtTails
        '
        Me.txtTails.Location = New System.Drawing.Point(641, 158)
        Me.txtTails.Name = "txtTails"
        Me.txtTails.ReadOnly = True
        Me.txtTails.Size = New System.Drawing.Size(100, 21)
        Me.txtTails.TabIndex = 266
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(586, 161)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 265
        Me.Label14.Text = "网尾数："
        '
        'txtStrips
        '
        Me.txtStrips.Location = New System.Drawing.Point(450, 158)
        Me.txtStrips.Name = "txtStrips"
        Me.txtStrips.ReadOnly = True
        Me.txtStrips.Size = New System.Drawing.Size(109, 21)
        Me.txtStrips.TabIndex = 264
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(395, 161)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 263
        Me.Label15.Text = "模条数："
        '
        'txtCavitys
        '
        Me.txtCavitys.Location = New System.Drawing.Point(256, 158)
        Me.txtCavitys.Name = "txtCavitys"
        Me.txtCavitys.ReadOnly = True
        Me.txtCavitys.Size = New System.Drawing.Size(100, 21)
        Me.txtCavitys.TabIndex = 262
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(201, 161)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 12)
        Me.Label16.TabIndex = 261
        Me.Label16.Text = "模穴数："
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(29, 161)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 12)
        Me.Label17.TabIndex = 260
        Me.Label17.Text = "模别："
        '
        'txtNewMouldID
        '
        Me.txtNewMouldID.Location = New System.Drawing.Point(823, 129)
        Me.txtNewMouldID.Name = "txtNewMouldID"
        Me.txtNewMouldID.ReadOnly = True
        Me.txtNewMouldID.Size = New System.Drawing.Size(100, 21)
        Me.txtNewMouldID.TabIndex = 259
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(768, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 258
        Me.Label8.Text = "旧模号："
        '
        'txtMapID
        '
        Me.txtMapID.Location = New System.Drawing.Point(641, 129)
        Me.txtMapID.Name = "txtMapID"
        Me.txtMapID.ReadOnly = True
        Me.txtMapID.Size = New System.Drawing.Size(100, 21)
        Me.txtMapID.TabIndex = 257
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(574, 133)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 256
        Me.Label9.Text = "模具图号："
        '
        'txtParaDesc
        '
        Me.txtParaDesc.Location = New System.Drawing.Point(450, 129)
        Me.txtParaDesc.Name = "txtParaDesc"
        Me.txtParaDesc.ReadOnly = True
        Me.txtParaDesc.Size = New System.Drawing.Size(109, 21)
        Me.txtParaDesc.TabIndex = 255
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(365, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 12)
        Me.Label10.TabIndex = 254
        Me.Label10.Text = "尾网/线槽OD："
        '
        'txtApplyPart
        '
        Me.txtApplyPart.Location = New System.Drawing.Point(256, 129)
        Me.txtApplyPart.Name = "txtApplyPart"
        Me.txtApplyPart.ReadOnly = True
        Me.txtApplyPart.Size = New System.Drawing.Size(100, 21)
        Me.txtApplyPart.TabIndex = 252
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(188, 133)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 12)
        Me.Label20.TabIndex = 251
        Me.Label20.Text = "适应机种："
        '
        'txtMouldID
        '
        Me.txtMouldID.Location = New System.Drawing.Point(76, 7)
        Me.txtMouldID.Name = "txtMouldID"
        Me.txtMouldID.Size = New System.Drawing.Size(127, 21)
        Me.txtMouldID.TabIndex = 253
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(34, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 12)
        Me.Label21.TabIndex = 250
        Me.Label21.Text = "模号："
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(847, 37)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(35, 21)
        Me.txtID.TabIndex = 21
        Me.txtID.Visible = False
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(306, 68)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(409, 21)
        Me.txtRemark.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(264, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "备注："
        '
        'cboRepairResult
        '
        Me.cboRepairResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRepairResult.FormattingEnabled = True
        Me.cboRepairResult.Items.AddRange(New Object() {"", "OK", "NG"})
        Me.cboRepairResult.Location = New System.Drawing.Point(76, 67)
        Me.cboRepairResult.Name = "cboRepairResult"
        Me.cboRepairResult.Size = New System.Drawing.Size(127, 20)
        Me.cboRepairResult.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "维修结果："
        '
        'txtRepairUserId
        '
        Me.txtRepairUserId.Location = New System.Drawing.Point(76, 37)
        Me.txtRepairUserId.Name = "txtRepairUserId"
        Me.txtRepairUserId.Size = New System.Drawing.Size(127, 21)
        Me.txtRepairUserId.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "送修人："
        '
        'txtRepairDeptUnit
        '
        Me.txtRepairDeptUnit.Location = New System.Drawing.Point(307, 7)
        Me.txtRepairDeptUnit.Name = "txtRepairDeptUnit"
        Me.txtRepairDeptUnit.Size = New System.Drawing.Size(127, 21)
        Me.txtRepairDeptUnit.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(240, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "送修单位："
        '
        'txtRepartInfo
        '
        Me.txtRepartInfo.Location = New System.Drawing.Point(308, 37)
        Me.txtRepartInfo.Name = "txtRepartInfo"
        Me.txtRepartInfo.Size = New System.Drawing.Size(407, 21)
        Me.txtRepartInfo.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(217, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "送修不良状况："
        '
        'dtRepairDate
        '
        Me.dtRepairDate.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.dtRepairDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtRepairDate.Location = New System.Drawing.Point(557, 7)
        Me.dtRepairDate.Name = "dtRepairDate"
        Me.dtRepairDate.Size = New System.Drawing.Size(158, 21)
        Me.dtRepairDate.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(490, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "送修时间："
        '
        'dgvMouldRepair
        '
        Me.dgvMouldRepair.AllowUserToAddRows = False
        Me.dgvMouldRepair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMouldRepair.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.MouldID, Me.RepartInfo, Me.RepairDeptUnit, Me.RepairDate, Me.RepairUserId, Me.RepairResult, Me.Remark})
        Me.dgvMouldRepair.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMouldRepair.Location = New System.Drawing.Point(0, 0)
        Me.dgvMouldRepair.Name = "dgvMouldRepair"
        Me.dgvMouldRepair.ReadOnly = True
        Me.dgvMouldRepair.RowTemplate.Height = 23
        Me.dgvMouldRepair.Size = New System.Drawing.Size(941, 265)
        Me.dgvMouldRepair.TabIndex = 0
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'MouldID
        '
        Me.MouldID.DataPropertyName = "MouldID"
        Me.MouldID.HeaderText = "送修模号"
        Me.MouldID.Name = "MouldID"
        Me.MouldID.ReadOnly = True
        '
        'RepartInfo
        '
        Me.RepartInfo.DataPropertyName = "RepartInfo"
        Me.RepartInfo.HeaderText = "送修不良状况"
        Me.RepartInfo.Name = "RepartInfo"
        Me.RepartInfo.ReadOnly = True
        Me.RepartInfo.Width = 170
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
        Me.RepairResult.HeaderText = "维修结果"
        Me.RepairResult.Name = "RepairResult"
        Me.RepairResult.ReadOnly = True
        Me.RepairResult.Width = 80
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 120
        '
        'FrmMouldRepair
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 508)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmMouldRepair"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "模具维修"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMouldRepair, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolBeginRepair As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolEndRepair As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboRepairResult As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRepairUserId As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRepairDeptUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRepartInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtRepairDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvMouldRepair As System.Windows.Forms.DataGridView
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MouldID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepartInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepairDeptUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepairDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepairUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RepairResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtUseStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtStorage As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents txtAssetsID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSlots As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTails As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtStrips As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCavitys As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNewMouldID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMapID As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtParaDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtApplyPart As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtMouldID As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
