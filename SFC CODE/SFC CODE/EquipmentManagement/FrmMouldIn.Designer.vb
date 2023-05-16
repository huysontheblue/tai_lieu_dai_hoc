<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMouldIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMouldIn))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolMouldIn = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBackUserName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMapID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtParaDesc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtApplyPart = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBackUserId = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMouldID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvMouldInOut = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MouldID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutToUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutDeptUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutFromUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Acceptor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BackDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.toolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMouldInOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolMouldIn, Me.toolStripSeparator4, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1114, 25)
        Me.toolStrip1.TabIndex = 135
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolMouldIn
        '
        Me.toolMouldIn.Image = CType(resources.GetObject("toolMouldIn.Image"), System.Drawing.Image)
        Me.toolMouldIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMouldIn.Name = "toolMouldIn"
        Me.toolMouldIn.Size = New System.Drawing.Size(68, 22)
        Me.toolMouldIn.Tag = "入库"
        Me.toolMouldIn.Text = "归 还(&I)"
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
        Me.toolExit.Size = New System.Drawing.Size(72, 22)
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvMouldInOut)
        Me.SplitContainer1.Size = New System.Drawing.Size(1114, 448)
        Me.SplitContainer1.SplitterDistance = 150
        Me.SplitContainer1.TabIndex = 138
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtBackUserName)
        Me.GroupBox1.Controls.Add(Me.Label8)
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
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMapID)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtParaDesc)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtApplyPart)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtBackUserId)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtMouldID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1114, 150)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(458, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 12)
        Me.Label3.TabIndex = 252
        Me.Label3.Text = "提示：请输入模号与归还人工号"
        '
        'txtBackUserName
        '
        Me.txtBackUserName.BackColor = System.Drawing.SystemColors.Window
        Me.txtBackUserName.Location = New System.Drawing.Point(529, 10)
        Me.txtBackUserName.Name = "txtBackUserName"
        Me.txtBackUserName.Size = New System.Drawing.Size(100, 21)
        Me.txtBackUserName.TabIndex = 250
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(455, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 12)
        Me.Label8.TabIndex = 251
        Me.Label8.Text = "归还人姓名："
        '
        'txtUseStatus
        '
        Me.txtUseStatus.Location = New System.Drawing.Point(647, 124)
        Me.txtUseStatus.Name = "txtUseStatus"
        Me.txtUseStatus.ReadOnly = True
        Me.txtUseStatus.Size = New System.Drawing.Size(100, 21)
        Me.txtUseStatus.TabIndex = 249
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(581, 128)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 248
        Me.Label18.Text = "使用状态："
        '
        'txtStorage
        '
        Me.txtStorage.Location = New System.Drawing.Point(827, 72)
        Me.txtStorage.Name = "txtStorage"
        Me.txtStorage.ReadOnly = True
        Me.txtStorage.Size = New System.Drawing.Size(100, 21)
        Me.txtStorage.TabIndex = 247
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(761, 76)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 12)
        Me.Label19.TabIndex = 246
        Me.Label19.Text = "固定储位："
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(74, 98)
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.Size = New System.Drawing.Size(100, 21)
        Me.txtType.TabIndex = 245
        '
        'txtAssetsID
        '
        Me.txtAssetsID.Location = New System.Drawing.Point(465, 124)
        Me.txtAssetsID.Name = "txtAssetsID"
        Me.txtAssetsID.ReadOnly = True
        Me.txtAssetsID.Size = New System.Drawing.Size(100, 21)
        Me.txtAssetsID.TabIndex = 244
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(398, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 243
        Me.Label12.Text = "资产编号："
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(268, 124)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.ReadOnly = True
        Me.txtLocation.Size = New System.Drawing.Size(109, 21)
        Me.txtLocation.TabIndex = 242
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(202, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 241
        Me.Label11.Text = "现有位置："
        '
        'txtSlots
        '
        Me.txtSlots.Location = New System.Drawing.Point(74, 124)
        Me.txtSlots.Name = "txtSlots"
        Me.txtSlots.ReadOnly = True
        Me.txtSlots.Size = New System.Drawing.Size(100, 21)
        Me.txtSlots.TabIndex = 238
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 128)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 237
        Me.Label13.Text = "线槽数："
        '
        'txtTails
        '
        Me.txtTails.Location = New System.Drawing.Point(647, 98)
        Me.txtTails.Name = "txtTails"
        Me.txtTails.ReadOnly = True
        Me.txtTails.Size = New System.Drawing.Size(100, 21)
        Me.txtTails.TabIndex = 236
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(592, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 235
        Me.Label14.Text = "网尾数："
        '
        'txtStrips
        '
        Me.txtStrips.Location = New System.Drawing.Point(465, 98)
        Me.txtStrips.Name = "txtStrips"
        Me.txtStrips.ReadOnly = True
        Me.txtStrips.Size = New System.Drawing.Size(100, 21)
        Me.txtStrips.TabIndex = 234
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(411, 101)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 233
        Me.Label15.Text = "模条数："
        '
        'txtCavitys
        '
        Me.txtCavitys.Location = New System.Drawing.Point(268, 98)
        Me.txtCavitys.Name = "txtCavitys"
        Me.txtCavitys.ReadOnly = True
        Me.txtCavitys.Size = New System.Drawing.Size(109, 21)
        Me.txtCavitys.TabIndex = 232
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(213, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 12)
        Me.Label16.TabIndex = 231
        Me.Label16.Text = "模穴数："
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(35, 101)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 12)
        Me.Label17.TabIndex = 229
        Me.Label17.Text = "模别："
        '
        'txtNewMouldID
        '
        Me.txtNewMouldID.Location = New System.Drawing.Point(647, 72)
        Me.txtNewMouldID.Name = "txtNewMouldID"
        Me.txtNewMouldID.ReadOnly = True
        Me.txtNewMouldID.Size = New System.Drawing.Size(100, 21)
        Me.txtNewMouldID.TabIndex = 228
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(592, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 227
        Me.Label2.Text = "旧模号："
        '
        'txtMapID
        '
        Me.txtMapID.Location = New System.Drawing.Point(465, 72)
        Me.txtMapID.Name = "txtMapID"
        Me.txtMapID.ReadOnly = True
        Me.txtMapID.Size = New System.Drawing.Size(100, 21)
        Me.txtMapID.TabIndex = 226
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(398, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 225
        Me.Label5.Text = "模具图号："
        '
        'txtParaDesc
        '
        Me.txtParaDesc.Location = New System.Drawing.Point(268, 72)
        Me.txtParaDesc.Name = "txtParaDesc"
        Me.txtParaDesc.ReadOnly = True
        Me.txtParaDesc.Size = New System.Drawing.Size(109, 21)
        Me.txtParaDesc.TabIndex = 224
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(185, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 12)
        Me.Label7.TabIndex = 223
        Me.Label7.Text = "尾网/线槽OD："
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(885, 118)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(42, 21)
        Me.txtID.TabIndex = 25
        Me.txtID.Visible = False
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(79, 34)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(357, 21)
        Me.txtRemark.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(36, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 12)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "备注："
        '
        'txtApplyPart
        '
        Me.txtApplyPart.Location = New System.Drawing.Point(75, 72)
        Me.txtApplyPart.Name = "txtApplyPart"
        Me.txtApplyPart.ReadOnly = True
        Me.txtApplyPart.Size = New System.Drawing.Size(100, 21)
        Me.txtApplyPart.TabIndex = 221
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "适应机种："
        '
        'txtBackUserId
        '
        Me.txtBackUserId.Location = New System.Drawing.Point(321, 7)
        Me.txtBackUserId.Name = "txtBackUserId"
        Me.txtBackUserId.Size = New System.Drawing.Size(115, 21)
        Me.txtBackUserId.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(242, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "归还人工号："
        '
        'txtMouldID
        '
        Me.txtMouldID.Location = New System.Drawing.Point(79, 7)
        Me.txtMouldID.Name = "txtMouldID"
        Me.txtMouldID.Size = New System.Drawing.Size(100, 21)
        Me.txtMouldID.TabIndex = 222
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "模号："
        '
        'dgvMouldInOut
        '
        Me.dgvMouldInOut.AllowUserToAddRows = False
        Me.dgvMouldInOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMouldInOut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.MouldID2, Me.Status, Me.OutToUserId, Me.OutDeptUnit, Me.OutFromUserId, Me.OutDate, Me.BackUserId, Me.Acceptor, Me.BackDate, Me.OutRemark, Me.InRemark})
        Me.dgvMouldInOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMouldInOut.Location = New System.Drawing.Point(0, 0)
        Me.dgvMouldInOut.Name = "dgvMouldInOut"
        Me.dgvMouldInOut.ReadOnly = True
        Me.dgvMouldInOut.RowTemplate.Height = 23
        Me.dgvMouldInOut.Size = New System.Drawing.Size(1114, 294)
        Me.dgvMouldInOut.TabIndex = 0
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'MouldID2
        '
        Me.MouldID2.DataPropertyName = "MouldID"
        Me.MouldID2.HeaderText = "模号"
        Me.MouldID2.Name = "MouldID2"
        Me.MouldID2.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "状态"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 70
        '
        'OutToUserId
        '
        Me.OutToUserId.DataPropertyName = "OutToUserId"
        Me.OutToUserId.HeaderText = "调出责任人"
        Me.OutToUserId.Name = "OutToUserId"
        Me.OutToUserId.ReadOnly = True
        '
        'OutDeptUnit
        '
        Me.OutDeptUnit.DataPropertyName = "OutDeptUnit"
        Me.OutDeptUnit.HeaderText = "调出单位"
        Me.OutDeptUnit.Name = "OutDeptUnit"
        Me.OutDeptUnit.ReadOnly = True
        Me.OutDeptUnit.Width = 80
        '
        'OutFromUserId
        '
        Me.OutFromUserId.DataPropertyName = "OutFromUserId"
        Me.OutFromUserId.HeaderText = "调出操作人"
        Me.OutFromUserId.Name = "OutFromUserId"
        Me.OutFromUserId.ReadOnly = True
        '
        'OutDate
        '
        Me.OutDate.DataPropertyName = "OutDate"
        Me.OutDate.HeaderText = "调出日期"
        Me.OutDate.Name = "OutDate"
        Me.OutDate.ReadOnly = True
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
        'BackDate
        '
        Me.BackDate.DataPropertyName = "BackDate"
        Me.BackDate.HeaderText = "归还日期"
        Me.BackDate.Name = "BackDate"
        Me.BackDate.ReadOnly = True
        '
        'OutRemark
        '
        Me.OutRemark.DataPropertyName = "OutRemark"
        Me.OutRemark.HeaderText = "调出备注"
        Me.OutRemark.Name = "OutRemark"
        Me.OutRemark.ReadOnly = True
        Me.OutRemark.Width = 110
        '
        'InRemark
        '
        Me.InRemark.DataPropertyName = "InRemark"
        Me.InRemark.HeaderText = "归还备注"
        Me.InRemark.Name = "InRemark"
        Me.InRemark.ReadOnly = True
        Me.InRemark.Width = 110
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(763, 103)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox1.TabIndex = 258
        Me.CheckBox1.Text = "是否有效"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FrmMouldIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 473)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmMouldIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "模具入库"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMouldInOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolMouldIn As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBackUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMapID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtParaDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtApplyPart As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBackUserId As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMouldID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvMouldInOut As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MouldID2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutToUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutDeptUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutFromUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BackUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Acceptor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BackDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
