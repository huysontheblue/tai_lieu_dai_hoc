<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNCode
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNCode))
        Me.statusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtNGXXENName = New System.Windows.Forms.TextBox()
        Me.cboNGXXType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNGXXCode = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkUsey = New System.Windows.Forms.CheckBox()
        Me.cmbNgStationId = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNGXXName = New System.Windows.Forms.TextBox()
        Me.dgvRstation = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.F_codeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F_codename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.F_codelen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DResource = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.station = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.不良等级 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Itime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolExport = New System.Windows.Forms.ToolStripButton()
        Me.statusStrip2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvRstation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusStrip2
        '
        Me.statusStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.toolStripStatusLabel3})
        Me.statusStrip2.Location = New System.Drawing.Point(0, 492)
        Me.statusStrip2.Name = "statusStrip2"
        Me.statusStrip2.Size = New System.Drawing.Size(1036, 22)
        Me.statusStrip2.TabIndex = 28
        Me.statusStrip2.Text = "statusStrip2"
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.toolStripStatusLabel1.Text = "记录笔数:"
        '
        'toolStripStatusLabel3
        '
        Me.toolStripStatusLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.toolStripStatusLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.toolStripStatusLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.toolStripStatusLabel3.Name = "toolStripStatusLabel3"
        Me.toolStripStatusLabel3.Size = New System.Drawing.Size(15, 17)
        Me.toolStripStatusLabel3.Text = "0"
        '
        'txtNGXXENName
        '
        Me.txtNGXXENName.Location = New System.Drawing.Point(370, 45)
        Me.txtNGXXENName.MaxLength = 50
        Me.txtNGXXENName.Name = "txtNGXXENName"
        Me.txtNGXXENName.Size = New System.Drawing.Size(136, 21)
        Me.txtNGXXENName.TabIndex = 3
        '
        'cboNGXXType
        '
        Me.cboNGXXType.FormattingEnabled = True
        Me.cboNGXXType.Items.AddRange(New Object() {""})
        Me.cboNGXXType.Location = New System.Drawing.Point(101, 16)
        Me.cboNGXXType.Name = "cboNGXXType"
        Me.cboNGXXType.Size = New System.Drawing.Size(146, 20)
        Me.cboNGXXType.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "不良现象类别："
        '
        'txtNGXXCode
        '
        Me.txtNGXXCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNGXXCode.Location = New System.Drawing.Point(348, 16)
        Me.txtNGXXCode.MaxLength = 20
        Me.txtNGXXCode.Name = "txtNGXXCode"
        Me.txtNGXXCode.Size = New System.Drawing.Size(158, 21)
        Me.txtNGXXCode.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 30)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvRstation)
        Me.SplitContainer1.Size = New System.Drawing.Size(1036, 460)
        Me.SplitContainer1.SplitterDistance = 71
        Me.SplitContainer1.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ChkUsey)
        Me.GroupBox1.Controls.Add(Me.txtNGXXENName)
        Me.GroupBox1.Controls.Add(Me.cmbNgStationId)
        Me.GroupBox1.Controls.Add(Me.cboNGXXType)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNGXXCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNGXXName)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1036, 71)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "重缺", "次缺", "主缺"})
        Me.ComboBox1.Location = New System.Drawing.Point(618, 45)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(86, 20)
        Me.ComboBox1.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(523, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "不良等级："
        '
        'ChkUsey
        '
        Me.ChkUsey.AutoSize = True
        Me.ChkUsey.Location = New System.Drawing.Point(710, 49)
        Me.ChkUsey.Name = "ChkUsey"
        Me.ChkUsey.Size = New System.Drawing.Size(48, 16)
        Me.ChkUsey.TabIndex = 26
        Me.ChkUsey.Text = "启用"
        Me.ChkUsey.UseVisualStyleBackColor = True
        '
        'cmbNgStationId
        '
        Me.cmbNgStationId.FormattingEnabled = True
        Me.cmbNgStationId.Items.AddRange(New Object() {""})
        Me.cmbNgStationId.Location = New System.Drawing.Point(101, 44)
        Me.cmbNgStationId.Name = "cmbNgStationId"
        Me.cmbNgStationId.Size = New System.Drawing.Size(146, 20)
        Me.cmbNgStationId.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 12)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "不良现象站点："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(263, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "不良现象代码："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(523, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "不良现象名称："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(263, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 12)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "不良现象英文名称："
        '
        'txtNGXXName
        '
        Me.txtNGXXName.AcceptsReturn = True
        Me.txtNGXXName.Location = New System.Drawing.Point(618, 15)
        Me.txtNGXXName.MaxLength = 20
        Me.txtNGXXName.Name = "txtNGXXName"
        Me.txtNGXXName.Size = New System.Drawing.Size(140, 21)
        Me.txtNGXXName.TabIndex = 2
        '
        'dgvRstation
        '
        Me.dgvRstation.AllowUserToAddRows = False
        Me.dgvRstation.AllowUserToDeleteRows = False
        Me.dgvRstation.AllowUserToOrderColumns = True
        Me.dgvRstation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRstation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRstation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRstation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.F_codeID, Me.F_codename, Me.F_codelen, Me.Column1, Me.DResource, Me.station, Me.Column2, Me.UnitID, Me.不良等级, Me.Itime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRstation.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRstation.EnableHeadersVisualStyles = False
        Me.dgvRstation.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvRstation.Location = New System.Drawing.Point(0, 0)
        Me.dgvRstation.Name = "dgvRstation"
        Me.dgvRstation.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRstation.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRstation.RowHeadersWidth = 4
        Me.dgvRstation.RowTemplate.Height = 23
        Me.dgvRstation.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.dgvRstation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRstation.Size = New System.Drawing.Size(1036, 360)
        Me.dgvRstation.TabIndex = 11
        '
        'F_codeID
        '
        Me.F_codeID.HeaderText = "不良现象代码"
        Me.F_codeID.Name = "F_codeID"
        Me.F_codeID.ReadOnly = True
        Me.F_codeID.Width = 120
        '
        'F_codename
        '
        Me.F_codename.HeaderText = "不良现象名称"
        Me.F_codename.Name = "F_codename"
        Me.F_codename.ReadOnly = True
        Me.F_codename.Width = 120
        '
        'F_codelen
        '
        Me.F_codelen.HeaderText = "不良现象英文名称"
        Me.F_codelen.Name = "F_codelen"
        Me.F_codelen.ReadOnly = True
        Me.F_codelen.Width = 130
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "EsortName"
        Me.Column1.HeaderText = "不良现象类别编号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 130
        '
        'DResource
        '
        Me.DResource.HeaderText = "不良现象类别"
        Me.DResource.Name = "DResource"
        Me.DResource.ReadOnly = True
        Me.DResource.Width = 120
        '
        'station
        '
        Me.station.HeaderText = "不良站点编号"
        Me.station.Name = "station"
        Me.station.ReadOnly = True
        Me.station.Width = 90
        '
        'Column2
        '
        Me.Column2.HeaderText = "不良站点名称"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'UnitID
        '
        Me.UnitID.HeaderText = "有效否"
        Me.UnitID.Name = "UnitID"
        Me.UnitID.ReadOnly = True
        Me.UnitID.Width = 80
        '
        '不良等级
        '
        Me.不良等级.HeaderText = "不良等级"
        Me.不良等级.Name = "不良等级"
        Me.不良等级.ReadOnly = True
        '
        'Itime
        '
        Me.Itime.HeaderText = "设置时间"
        Me.Itime.Name = "Itime"
        Me.Itime.ReadOnly = True
        Me.Itime.Width = 130
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 18)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(73, 18)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "作 废(&D)"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 18)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        Me.toolAdd.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 21)
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.toolAbandon, Me.ToolStripSeparator1, Me.toolSave, Me.toolBack, Me.toolStripSeparator4, Me.toolQuery, Me.ToolStripSeparator3, Me.toolExport, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 2)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1036, 21)
        Me.toolStrip1.TabIndex = 29
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 18)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(72, 18)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 21)
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 18)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 21)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 18)
        Me.toolExit.Text = "退 出(&X)"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "工站类别"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "工站编号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "工站名称"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 130
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "工站描述"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "有效否"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "设置人员"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "设置时间"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'toolExport
        '
        Me.toolExport.Image = CType(resources.GetObject("toolExport.Image"), System.Drawing.Image)
        Me.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExport.Name = "toolExport"
        Me.toolExport.Size = New System.Drawing.Size(64, 18)
        Me.toolExport.Text = "汇   出"
        '
        'FrmNCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 514)
        Me.Controls.Add(Me.statusStrip2)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmNCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "不良现象代码维护"
        Me.statusStrip2.ResumeLayout(False)
        Me.statusStrip2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvRstation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents statusStrip2 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtNGXXENName As System.Windows.Forms.TextBox
    Friend WithEvents cboNGXXType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNGXXCode As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNGXXName As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvRstation As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ChkUsey As System.Windows.Forms.CheckBox
    Friend WithEvents cmbNgStationId As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents F_codeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F_codename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F_codelen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DResource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents station As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 不良等级 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Itime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents toolExport As System.Windows.Forms.ToolStripButton
End Class
