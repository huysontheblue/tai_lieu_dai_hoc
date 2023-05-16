<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKeyPartAlter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKeyPartAlter))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolUsename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolCancel = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolConfig = New System.Windows.Forms.ToolStripButton()
        Me.GroupHandle = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtMark = New System.Windows.Forms.TextBox()
        Me.Butdelete = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtbarcode = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtbagbarcode = New System.Windows.Forms.TextBox()
        Me.txtcablebarcode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtbarcoderule = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbstage = New System.Windows.Forms.ComboBox()
        Me.txtmsn = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMSNrule = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txtpartid = New System.Windows.Forms.ComboBox()
        Me.LblQty = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ButSet = New System.Windows.Forms.Button()
        Me.Chk = New System.Windows.Forms.CheckBox()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Toolcomfire = New System.Windows.Forms.ToolStripButton()
        Me.DGMainTain = New System.Windows.Forms.DataGridView()
        Me.Col1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtinput = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CobType = New System.Windows.Forms.ComboBox()
        Me.RadPPID = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusStrip1.SuspendLayout()
        Me.GroupHandle.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.DGMainTain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "料件编号："
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(399, 92)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(160, 17)
        Me.LblMsg.TabIndex = 116
        Me.LblMsg.Text = "请读取或扫描产品序号..."
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.ToolUsename})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 541)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1041, 22)
        Me.statusStrip1.TabIndex = 131
        Me.statusStrip1.Text = "statusStrip1"
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.toolStripStatusLabel1.Image = CType(resources.GetObject("toolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(84, 17)
        Me.toolStripStatusLabel1.Text = "扫描人员："
        '
        'ToolUsename
        '
        Me.ToolUsename.Name = "ToolUsename"
        Me.ToolUsename.Size = New System.Drawing.Size(56, 17)
        Me.ToolUsename.Text = "L031976"
        '
        'ToolCancel
        '
        Me.ToolCancel.Enabled = False
        Me.ToolCancel.Image = CType(resources.GetObject("ToolCancel.Image"), System.Drawing.Image)
        Me.ToolCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCancel.Name = "ToolCancel"
        Me.ToolCancel.Size = New System.Drawing.Size(68, 22)
        Me.ToolCancel.Text = "取消(&C)"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'ToolConfig
        '
        Me.ToolConfig.Enabled = False
        Me.ToolConfig.Image = CType(resources.GetObject("ToolConfig.Image"), System.Drawing.Image)
        Me.ToolConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolConfig.Name = "ToolConfig"
        Me.ToolConfig.Size = New System.Drawing.Size(67, 22)
        Me.ToolConfig.Text = "保存(&S)"
        '
        'GroupHandle
        '
        Me.GroupHandle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupHandle.Controls.Add(Me.Label9)
        Me.GroupHandle.Controls.Add(Me.TxtMark)
        Me.GroupHandle.Controls.Add(Me.Butdelete)
        Me.GroupHandle.Controls.Add(Me.Label2)
        Me.GroupHandle.Controls.Add(Me.Txtbarcode)
        Me.GroupHandle.Controls.Add(Me.GroupBox3)
        Me.GroupHandle.Controls.Add(Me.GroupBox2)
        Me.GroupHandle.Location = New System.Drawing.Point(3, 206)
        Me.GroupHandle.Name = "GroupHandle"
        Me.GroupHandle.Size = New System.Drawing.Size(1045, 159)
        Me.GroupHandle.TabIndex = 135
        Me.GroupHandle.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(483, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 123
        Me.Label9.Text = "备注："
        '
        'TxtMark
        '
        Me.TxtMark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMark.Enabled = False
        Me.TxtMark.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtMark.Location = New System.Drawing.Point(549, 131)
        Me.TxtMark.Name = "TxtMark"
        Me.TxtMark.Size = New System.Drawing.Size(301, 21)
        Me.TxtMark.TabIndex = 122
        '
        'Butdelete
        '
        Me.Butdelete.Enabled = False
        Me.Butdelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Butdelete.Location = New System.Drawing.Point(890, 130)
        Me.Butdelete.Name = "Butdelete"
        Me.Butdelete.Size = New System.Drawing.Size(63, 23)
        Me.Butdelete.TabIndex = 121
        Me.Butdelete.Text = "作废"
        Me.Butdelete.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "产品序号："
        '
        'Txtbarcode
        '
        Me.Txtbarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtbarcode.Enabled = False
        Me.Txtbarcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Txtbarcode.Location = New System.Drawing.Point(146, 132)
        Me.Txtbarcode.Name = "Txtbarcode"
        Me.Txtbarcode.Size = New System.Drawing.Size(301, 21)
        Me.Txtbarcode.TabIndex = 119
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtbagbarcode)
        Me.GroupBox3.Controls.Add(Me.txtcablebarcode)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtbarcoderule)
        Me.GroupBox3.Location = New System.Drawing.Point(471, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(484, 112)
        Me.GroupBox3.TabIndex = 118
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cable Barcode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Barcode Rule："
        '
        'txtbagbarcode
        '
        Me.txtbagbarcode.Location = New System.Drawing.Point(120, 51)
        Me.txtbagbarcode.MaxLength = 19
        Me.txtbagbarcode.Name = "txtbagbarcode"
        Me.txtbagbarcode.Size = New System.Drawing.Size(319, 21)
        Me.txtbagbarcode.TabIndex = 2
        '
        'txtcablebarcode
        '
        Me.txtcablebarcode.Location = New System.Drawing.Point(120, 78)
        Me.txtcablebarcode.MaxLength = 20
        Me.txtcablebarcode.Name = "txtcablebarcode"
        Me.txtcablebarcode.Size = New System.Drawing.Size(319, 21)
        Me.txtcablebarcode.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Bag Barcode："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 12)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Cable Barcode："
        '
        'txtbarcoderule
        '
        Me.txtbarcoderule.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtbarcoderule.ForeColor = System.Drawing.Color.Black
        Me.txtbarcoderule.Location = New System.Drawing.Point(120, 24)
        Me.txtbarcoderule.Name = "txtbarcoderule"
        Me.txtbarcoderule.ReadOnly = True
        Me.txtbarcoderule.Size = New System.Drawing.Size(319, 21)
        Me.txtbarcoderule.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbstage)
        Me.GroupBox2.Controls.Add(Me.txtmsn)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtMSNrule)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(437, 112)
        Me.GroupBox2.TabIndex = 117
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Module SN"
        '
        'cmbstage
        '
        Me.cmbstage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbstage.FormattingEnabled = True
        Me.cmbstage.Location = New System.Drawing.Point(136, 20)
        Me.cmbstage.Name = "cmbstage"
        Me.cmbstage.Size = New System.Drawing.Size(291, 20)
        Me.cmbstage.TabIndex = 13
        '
        'txtmsn
        '
        Me.txtmsn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmsn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmsn.ForeColor = System.Drawing.Color.Black
        Me.txtmsn.Location = New System.Drawing.Point(136, 76)
        Me.txtmsn.Name = "txtmsn"
        Me.txtmsn.ReadOnly = True
        Me.txtmsn.Size = New System.Drawing.Size(291, 21)
        Me.txtmsn.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(50, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Build Stage："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Module Serial No："
        '
        'txtMSNrule
        '
        Me.txtMSNrule.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMSNrule.ForeColor = System.Drawing.Color.Black
        Me.txtMSNrule.Location = New System.Drawing.Point(136, 48)
        Me.txtMSNrule.Name = "txtMSNrule"
        Me.txtMSNrule.ReadOnly = True
        Me.txtMSNrule.Size = New System.Drawing.Size(291, 21)
        Me.txtMSNrule.TabIndex = 11
        Me.txtMSNrule.Text = "DYF3042**********"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(68, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "MSN Rule："
        '
        'ToolStar
        '
        Me.ToolStar.Image = CType(resources.GetObject("ToolStar.Image"), System.Drawing.Image)
        Me.ToolStar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStar.Name = "ToolStar"
        Me.ToolStar.Size = New System.Drawing.Size(92, 22)
        Me.ToolStar.Text = "开始扫描(&B)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Gray
        Me.GroupBox1.Controls.Add(Me.Txtpartid)
        Me.GroupBox1.Controls.Add(Me.LblQty)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ButSet)
        Me.GroupBox1.Controls.Add(Me.Chk)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(6, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1058, 50)
        Me.GroupBox1.TabIndex = 134
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "设置料件资料"
        '
        'Txtpartid
        '
        Me.Txtpartid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Txtpartid.FormattingEnabled = True
        Me.Txtpartid.Items.AddRange(New Object() {"Golden Unit"})
        Me.Txtpartid.Location = New System.Drawing.Point(111, 19)
        Me.Txtpartid.Name = "Txtpartid"
        Me.Txtpartid.Size = New System.Drawing.Size(258, 20)
        Me.Txtpartid.TabIndex = 120
        '
        'LblQty
        '
        Me.LblQty.AutoSize = True
        Me.LblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQty.ForeColor = System.Drawing.Color.White
        Me.LblQty.Location = New System.Drawing.Point(1006, 19)
        Me.LblQty.Name = "LblQty"
        Me.LblQty.Size = New System.Drawing.Size(19, 20)
        Me.LblQty.TabIndex = 119
        Me.LblQty.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(957, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 17)
        Me.Label10.TabIndex = 118
        Me.Label10.Text = "数量："
        '
        'ButSet
        '
        Me.ButSet.BackColor = System.Drawing.Color.White
        Me.ButSet.Enabled = False
        Me.ButSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButSet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButSet.Location = New System.Drawing.Point(383, 17)
        Me.ButSet.Name = "ButSet"
        Me.ButSet.Size = New System.Drawing.Size(63, 23)
        Me.ButSet.TabIndex = 97
        Me.ButSet.Text = "设置"
        Me.ButSet.UseVisualStyleBackColor = False
        '
        'Chk
        '
        Me.Chk.AutoSize = True
        Me.Chk.Enabled = False
        Me.Chk.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Chk.ForeColor = System.Drawing.Color.White
        Me.Chk.Location = New System.Drawing.Point(820, 23)
        Me.Chk.Name = "Chk"
        Me.Chk.Size = New System.Drawing.Size(132, 16)
        Me.Chk.TabIndex = 117
        Me.Chk.Text = "读取序号时自动作废"
        Me.Chk.UseVisualStyleBackColor = True
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStar, Me.ToolConfig, Me.ToolCancel, Me.Toolcomfire, Me.toolStripSeparator1, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(-11, 2)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1058, 25)
        Me.toolStrip1.TabIndex = 132
        Me.toolStrip1.Text = "toolStrip1"
        '
        'Toolcomfire
        '
        Me.Toolcomfire.Enabled = False
        Me.Toolcomfire.Image = CType(resources.GetObject("Toolcomfire.Image"), System.Drawing.Image)
        Me.Toolcomfire.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Toolcomfire.Name = "Toolcomfire"
        Me.Toolcomfire.Size = New System.Drawing.Size(69, 22)
        Me.Toolcomfire.Text = "作废(&D)"
        '
        'DGMainTain
        '
        Me.DGMainTain.AllowUserToAddRows = False
        Me.DGMainTain.AllowUserToDeleteRows = False
        Me.DGMainTain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGMainTain.BackgroundColor = System.Drawing.Color.White
        Me.DGMainTain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGMainTain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGMainTain.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGMainTain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGMainTain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col1, Me.Column1, Me.Col9, Me.Col8})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGMainTain.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGMainTain.Location = New System.Drawing.Point(-5, 371)
        Me.DGMainTain.Name = "DGMainTain"
        Me.DGMainTain.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGMainTain.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGMainTain.RowHeadersWidth = 4
        Me.DGMainTain.RowTemplate.Height = 24
        Me.DGMainTain.Size = New System.Drawing.Size(1046, 167)
        Me.DGMainTain.TabIndex = 133
        '
        'Col1
        '
        Me.Col1.HeaderText = "产品序号"
        Me.Col1.Name = "Col1"
        Me.Col1.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "当前状态"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Col9
        '
        Me.Col9.HeaderText = "扫描人员"
        Me.Col9.Name = "Col9"
        Me.Col9.ReadOnly = True
        '
        'Col8
        '
        Me.Col8.HeaderText = "扫描时间"
        Me.Col8.Name = "Col8"
        Me.Col8.ReadOnly = True
        '
        'txtinput
        '
        Me.txtinput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtinput.BackColor = System.Drawing.Color.White
        Me.txtinput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtinput.Enabled = False
        Me.txtinput.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinput.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtinput.Location = New System.Drawing.Point(3, 165)
        Me.txtinput.MaxLength = 100
        Me.txtinput.Name = "txtinput"
        Me.txtinput.Size = New System.Drawing.Size(1038, 35)
        Me.txtinput.TabIndex = 140
        Me.txtinput.WordWrap = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(47, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 141
        Me.Label11.Text = "作业类型："
        '
        'CobType
        '
        Me.CobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CobType.FormattingEnabled = True
        Me.CobType.Location = New System.Drawing.Point(117, 89)
        Me.CobType.Name = "CobType"
        Me.CobType.Size = New System.Drawing.Size(258, 20)
        Me.CobType.TabIndex = 142
        '
        'RadPPID
        '
        Me.RadPPID.AutoSize = True
        Me.RadPPID.Checked = True
        Me.RadPPID.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadPPID.ForeColor = System.Drawing.Color.Maroon
        Me.RadPPID.Location = New System.Drawing.Point(48, 128)
        Me.RadPPID.Name = "RadPPID"
        Me.RadPPID.Size = New System.Drawing.Size(101, 16)
        Me.RadPPID.TabIndex = 143
        Me.RadPPID.TabStop = True
        Me.RadPPID.Text = "产品编号扫描"
        Me.RadPPID.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.SeaGreen
        Me.RadioButton2.Location = New System.Drawing.Point(312, 128)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(101, 16)
        Me.RadioButton2.TabIndex = 144
        Me.RadioButton2.Text = "外箱编号扫描"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "成品料号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "产品序号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "项次"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "产品属性"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "类别"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "扫描工站"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "扫描人员"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "扫描时间"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'FrmKeyPartAlter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 563)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadPPID)
        Me.Controls.Add(Me.CobType)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtinput)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.GroupHandle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.DGMainTain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmKeyPartAlter"
        Me.Text = "关键物料预警作业"
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.GroupHandle.ResumeLayout(False)
        Me.GroupHandle.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.DGMainTain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolUsename As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCancel As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolConfig As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupHandle As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DGMainTain As System.Windows.Forms.DataGridView
    Friend WithEvents ButSet As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtbagbarcode As System.Windows.Forms.TextBox
    Friend WithEvents txtcablebarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtbarcoderule As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbstage As System.Windows.Forms.ComboBox
    Friend WithEvents txtmsn As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMSNrule As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtinput As System.Windows.Forms.TextBox
    Friend WithEvents Chk As System.Windows.Forms.CheckBox
    Friend WithEvents Butdelete As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txtbarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtMark As System.Windows.Forms.TextBox
    Friend WithEvents Toolcomfire As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblQty As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CobType As System.Windows.Forms.ComboBox
    Friend WithEvents Txtpartid As System.Windows.Forms.ComboBox
    Friend WithEvents RadPPID As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Col1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
