<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMainTainHandle
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMainTainHandle))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolUsename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStar = New System.Windows.Forms.ToolStripButton()
        Me.ToolConfig = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Toolcomfire = New System.Windows.Forms.ToolStripButton()
        Me.ToolRset = New System.Windows.Forms.ToolStripButton()
        Me.ToolCancel = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.DGMainTain = New System.Windows.Forms.DataGridView()
        Me.Col1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txtppid = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.TxtNGdes = New System.Windows.Forms.TextBox()
        Me.GroupHandle = New System.Windows.Forms.GroupBox()
        Me.CobRuturn = New System.Windows.Forms.TextBox()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.CobHandle = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComSmallCode = New System.Windows.Forms.ComboBox()
        Me.TxtIdea = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CobResult = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComMidCode = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CoblargeCode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkSplit = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtBarcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.statusStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.DGMainTain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupHandle.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.ToolUsename})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 561)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1058, 22)
        Me.statusStrip1.TabIndex = 93
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
        Me.toolStripStatusLabel1.Text = "掃描人員："
        '
        'ToolUsename
        '
        Me.ToolUsename.Name = "ToolUsename"
        Me.ToolUsename.Size = New System.Drawing.Size(44, 17)
        Me.ToolUsename.Text = "歐翔烽"
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStar, Me.ToolConfig, Me.ToolStripButton1, Me.Toolcomfire, Me.ToolRset, Me.ToolCancel, Me.toolStripSeparator1, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 1)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1058, 25)
        Me.toolStrip1.TabIndex = 94
        Me.toolStrip1.Text = "toolStrip1"
        '
        'ToolStar
        '
        Me.ToolStar.Image = CType(resources.GetObject("ToolStar.Image"), System.Drawing.Image)
        Me.ToolStar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStar.Name = "ToolStar"
        Me.ToolStar.Size = New System.Drawing.Size(92, 22)
        Me.ToolStar.Text = "开始维修(&B)"
        '
        'ToolConfig
        '
        Me.ToolConfig.Enabled = False
        Me.ToolConfig.Image = CType(resources.GetObject("ToolConfig.Image"), System.Drawing.Image)
        Me.ToolConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolConfig.Name = "ToolConfig"
        Me.ToolConfig.Size = New System.Drawing.Size(91, 22)
        Me.ToolConfig.Text = "維修完成(&S)"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripButton1.Text = "不良原因(&C)"
        '
        'Toolcomfire
        '
        Me.Toolcomfire.Enabled = False
        Me.Toolcomfire.Image = CType(resources.GetObject("Toolcomfire.Image"), System.Drawing.Image)
        Me.Toolcomfire.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Toolcomfire.Name = "Toolcomfire"
        Me.Toolcomfire.Size = New System.Drawing.Size(99, 22)
        Me.Toolcomfire.Text = "IPOC确认(&O)"
        '
        'ToolRset
        '
        Me.ToolRset.Enabled = False
        Me.ToolRset.Image = CType(resources.GetObject("ToolRset.Image"), System.Drawing.Image)
        Me.ToolRset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolRset.Name = "ToolRset"
        Me.ToolRset.Size = New System.Drawing.Size(104, 22)
        Me.ToolRset.Text = "不良品恢复(&R)"
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
        Me.DGMainTain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col1, Me.Col2, Me.Col3, Me.Col4, Me.Col5, Me.Col9, Me.Col8, Me.Col7, Me.Col10})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGMainTain.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGMainTain.Location = New System.Drawing.Point(0, 347)
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
        Me.DGMainTain.Size = New System.Drawing.Size(1058, 211)
        Me.DGMainTain.TabIndex = 95
        '
        'Col1
        '
        Me.Col1.HeaderText = "工单编号"
        Me.Col1.Name = "Col1"
        Me.Col1.ReadOnly = True
        '
        'Col2
        '
        Me.Col2.HeaderText = "成品料号"
        Me.Col2.Name = "Col2"
        Me.Col2.ReadOnly = True
        '
        'Col3
        '
        Me.Col3.HeaderText = "线别"
        Me.Col3.Name = "Col3"
        Me.Col3.ReadOnly = True
        '
        'Col4
        '
        Me.Col4.HeaderText = "成品条码序号"
        Me.Col4.Name = "Col4"
        Me.Col4.ReadOnly = True
        '
        'Col5
        '
        Me.Col5.HeaderText = "不良发生站点"
        Me.Col5.Name = "Col5"
        Me.Col5.ReadOnly = True
        '
        'Col9
        '
        Me.Col9.HeaderText = "不良现象"
        Me.Col9.Name = "Col9"
        Me.Col9.ReadOnly = True
        '
        'Col8
        '
        Me.Col8.HeaderText = "不良品料号"
        Me.Col8.Name = "Col8"
        Me.Col8.ReadOnly = True
        '
        'Col7
        '
        Me.Col7.HeaderText = "测试人员"
        Me.Col7.Name = "Col7"
        Me.Col7.ReadOnly = True
        '
        'Col10
        '
        Me.Col10.HeaderText = "项次"
        Me.Col10.Name = "Col10"
        Me.Col10.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "条码序号："
        '
        'Txtppid
        '
        Me.Txtppid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtppid.Location = New System.Drawing.Point(117, 14)
        Me.Txtppid.Name = "Txtppid"
        Me.Txtppid.Size = New System.Drawing.Size(319, 21)
        Me.Txtppid.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Txtppid)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.label11)
        Me.GroupBox1.Controls.Add(Me.TxtNGdes)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1058, 53)
        Me.GroupBox1.TabIndex = 100
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询条码"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(452, 20)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(65, 12)
        Me.label11.TabIndex = 96
        Me.label11.Text = "不良现象："
        '
        'TxtNGdes
        '
        Me.TxtNGdes.BackColor = System.Drawing.Color.GhostWhite
        Me.TxtNGdes.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TxtNGdes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TxtNGdes.Location = New System.Drawing.Point(527, 14)
        Me.TxtNGdes.Name = "TxtNGdes"
        Me.TxtNGdes.ReadOnly = True
        Me.TxtNGdes.Size = New System.Drawing.Size(194, 23)
        Me.TxtNGdes.TabIndex = 97
        '
        'GroupHandle
        '
        Me.GroupHandle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupHandle.Controls.Add(Me.CobRuturn)
        Me.GroupHandle.Controls.Add(Me.LblMsg)
        Me.GroupHandle.Controls.Add(Me.CobHandle)
        Me.GroupHandle.Controls.Add(Me.Label3)
        Me.GroupHandle.Controls.Add(Me.ComSmallCode)
        Me.GroupHandle.Controls.Add(Me.TxtIdea)
        Me.GroupHandle.Controls.Add(Me.Label9)
        Me.GroupHandle.Controls.Add(Me.Label8)
        Me.GroupHandle.Controls.Add(Me.CobResult)
        Me.GroupHandle.Controls.Add(Me.Label7)
        Me.GroupHandle.Controls.Add(Me.Label6)
        Me.GroupHandle.Controls.Add(Me.ComMidCode)
        Me.GroupHandle.Controls.Add(Me.Label5)
        Me.GroupHandle.Controls.Add(Me.CoblargeCode)
        Me.GroupHandle.Controls.Add(Me.Label4)
        Me.GroupHandle.Controls.Add(Me.ChkSplit)
        Me.GroupHandle.Location = New System.Drawing.Point(-1, 154)
        Me.GroupHandle.Name = "GroupHandle"
        Me.GroupHandle.Size = New System.Drawing.Size(1059, 188)
        Me.GroupHandle.TabIndex = 101
        Me.GroupHandle.TabStop = False
        Me.GroupHandle.Text = "故障维修"
        '
        'CobRuturn
        '
        Me.CobRuturn.BackColor = System.Drawing.Color.White
        Me.CobRuturn.Location = New System.Drawing.Point(118, 54)
        Me.CobRuturn.Name = "CobRuturn"
        Me.CobRuturn.ReadOnly = True
        Me.CobRuturn.Size = New System.Drawing.Size(175, 21)
        Me.CobRuturn.TabIndex = 117
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(412, 84)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(72, 15)
        Me.LblMsg.TabIndex = 116
        Me.LblMsg.Text = "提示信息："
        '
        'CobHandle
        '
        Me.CobHandle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobHandle.FormattingEnabled = True
        Me.CobHandle.Items.AddRange(New Object() {"0---报废", "1---维修OK"})
        Me.CobHandle.Location = New System.Drawing.Point(118, 81)
        Me.CobHandle.Name = "CobHandle"
        Me.CobHandle.Size = New System.Drawing.Size(233, 20)
        Me.CobHandle.TabIndex = 115
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(611, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "不良原因代码："
        '
        'ComSmallCode
        '
        Me.ComSmallCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComSmallCode.FormattingEnabled = True
        Me.ComSmallCode.Location = New System.Drawing.Point(702, 23)
        Me.ComSmallCode.Name = "ComSmallCode"
        Me.ComSmallCode.Size = New System.Drawing.Size(176, 20)
        Me.ComSmallCode.TabIndex = 113
        '
        'TxtIdea
        '
        Me.TxtIdea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIdea.Location = New System.Drawing.Point(117, 107)
        Me.TxtIdea.MaxLength = 200
        Me.TxtIdea.Multiline = True
        Me.TxtIdea.Name = "TxtIdea"
        Me.TxtIdea.Size = New System.Drawing.Size(921, 75)
        Me.TxtIdea.TabIndex = 112
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 12)
        Me.Label9.TabIndex = 111
        Me.Label9.Text = "改善对策描述："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(343, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "维修结果："
        '
        'CobResult
        '
        Me.CobResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobResult.FormattingEnabled = True
        Me.CobResult.Items.AddRange(New Object() {"0-报废", "1-维修OK"})
        Me.CobResult.Location = New System.Drawing.Point(414, 51)
        Me.CobResult.Name = "CobResult"
        Me.CobResult.Size = New System.Drawing.Size(176, 20)
        Me.CobResult.TabIndex = 109
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 12)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "维修处理方式："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(307, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 12)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "不良原因中分类："
        '
        'ComMidCode
        '
        Me.ComMidCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComMidCode.FormattingEnabled = True
        Me.ComMidCode.Location = New System.Drawing.Point(414, 23)
        Me.ComMidCode.Name = "ComMidCode"
        Me.ComMidCode.Size = New System.Drawing.Size(176, 20)
        Me.ComMidCode.TabIndex = 105
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 12)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "不良原因大分类："
        '
        'CoblargeCode
        '
        Me.CoblargeCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CoblargeCode.FormattingEnabled = True
        Me.CoblargeCode.Location = New System.Drawing.Point(117, 23)
        Me.CoblargeCode.Name = "CoblargeCode"
        Me.CoblargeCode.Size = New System.Drawing.Size(176, 20)
        Me.CoblargeCode.TabIndex = 103
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "回流起始工序："
        '
        'ChkSplit
        '
        Me.ChkSplit.AutoSize = True
        Me.ChkSplit.Location = New System.Drawing.Point(702, 50)
        Me.ChkSplit.Name = "ChkSplit"
        Me.ChkSplit.Size = New System.Drawing.Size(72, 16)
        Me.ChkSplit.TabIndex = 100
        Me.ChkSplit.Text = "拆分关联"
        Me.ChkSplit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TxtBarcode)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1058, 53)
        Me.GroupBox2.TabIndex = 130
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "IPQC维修确认或不良品恢复"
        '
        'TxtBarcode
        '
        Me.TxtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBarcode.Location = New System.Drawing.Point(117, 14)
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.Size = New System.Drawing.Size(341, 21)
        Me.TxtBarcode.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "条码序号："
        '
        'FrmMainTainHandle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 583)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupHandle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGMainTain)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMainTainHandle"
        Me.Text = "在线维护处理单"
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.DGMainTain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupHandle.ResumeLayout(False)
        Me.GroupHandle.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolUsename As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DGMainTain As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txtppid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupHandle As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNGdes As System.Windows.Forms.TextBox
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents ChkSplit As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComMidCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CoblargeCode As System.Windows.Forms.ComboBox
    Friend WithEvents ToolConfig As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CobResult As System.Windows.Forms.ComboBox
    Friend WithEvents TxtIdea As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComSmallCode As System.Windows.Forms.ComboBox
    Friend WithEvents CobHandle As System.Windows.Forms.ComboBox
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents ToolStar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Col1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CobRuturn As System.Windows.Forms.TextBox
    Friend WithEvents Toolcomfire As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolRset As System.Windows.Forms.ToolStripButton
End Class
