<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMjBasicMessage
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMjBasicMessage))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cobdept = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CobLineid = New System.Windows.Forms.ComboBox()
        Me.CobMatype = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtCcavQty = New System.Windows.Forms.TextBox()
        Me.TxtCarriType = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtAlertCount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtAllowUseCount = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCarrierID = New System.Windows.Forms.TextBox()
        Me.TxtCarrierDesc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCarrierName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvRstation = New System.Windows.Forms.DataGridView()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolCheck = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
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
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvRstation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip2.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 29)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1020, 433)
        Me.SplitContainer1.SplitterDistance = 125
        Me.SplitContainer1.TabIndex = 131
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cobdept)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.CobLineid)
        Me.GroupBox1.Controls.Add(Me.CobMatype)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TxtPartid)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TxtCcavQty)
        Me.GroupBox1.Controls.Add(Me.TxtCarriType)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtAlertCount)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TxtAllowUseCount)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtCarrierID)
        Me.GroupBox1.Controls.Add(Me.TxtCarrierDesc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtCarrierName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1020, 125)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'Cobdept
        '
        Me.Cobdept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cobdept.FormattingEnabled = True
        Me.Cobdept.Location = New System.Drawing.Point(284, 90)
        Me.Cobdept.Name = "Cobdept"
        Me.Cobdept.Size = New System.Drawing.Size(144, 20)
        Me.Cobdept.TabIndex = 44
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(215, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "部门编号："
        '
        'CobLineid
        '
        Me.CobLineid.BackColor = System.Drawing.Color.White
        Me.CobLineid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLineid.FormattingEnabled = True
        Me.CobLineid.Location = New System.Drawing.Point(516, 91)
        Me.CobLineid.Name = "CobLineid"
        Me.CobLineid.Size = New System.Drawing.Size(192, 20)
        Me.CobLineid.TabIndex = 42
        '
        'CobMatype
        '
        Me.CobMatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobMatype.FormattingEnabled = True
        Me.CobMatype.Location = New System.Drawing.Point(81, 89)
        Me.CobMatype.Name = "CobMatype"
        Me.CobMatype.Size = New System.Drawing.Size(114, 20)
        Me.CobMatype.TabIndex = 41
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(447, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "产量线别："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "机台类别："
        '
        'TxtPartid
        '
        Me.TxtPartid.BackColor = System.Drawing.Color.White
        Me.TxtPartid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPartid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtPartid.Location = New System.Drawing.Point(516, 59)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(192, 21)
        Me.TxtPartid.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(447, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "料件编号："
        '
        'TxtCcavQty
        '
        Me.TxtCcavQty.AcceptsReturn = True
        Me.TxtCcavQty.BackColor = System.Drawing.Color.White
        Me.TxtCcavQty.Location = New System.Drawing.Point(825, 25)
        Me.TxtCcavQty.MaxLength = 20
        Me.TxtCcavQty.Name = "TxtCcavQty"
        Me.TxtCcavQty.Size = New System.Drawing.Size(148, 21)
        Me.TxtCcavQty.TabIndex = 33
        '
        'TxtCarriType
        '
        Me.TxtCarriType.BackColor = System.Drawing.Color.White
        Me.TxtCarriType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCarriType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtCarriType.Location = New System.Drawing.Point(83, 25)
        Me.TxtCarriType.Name = "TxtCarriType"
        Me.TxtCarriType.Size = New System.Drawing.Size(112, 21)
        Me.TxtCarriType.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "载具类别："
        '
        'TxtAlertCount
        '
        Me.TxtAlertCount.BackColor = System.Drawing.Color.White
        Me.TxtAlertCount.Location = New System.Drawing.Point(284, 58)
        Me.TxtAlertCount.Name = "TxtAlertCount"
        Me.TxtAlertCount.Size = New System.Drawing.Size(144, 21)
        Me.TxtAlertCount.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(215, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "预警次数："
        '
        'TxtAllowUseCount
        '
        Me.TxtAllowUseCount.BackColor = System.Drawing.Color.White
        Me.TxtAllowUseCount.Location = New System.Drawing.Point(81, 58)
        Me.TxtAllowUseCount.Name = "TxtAllowUseCount"
        Me.TxtAllowUseCount.Size = New System.Drawing.Size(114, 21)
        Me.TxtAllowUseCount.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "使用寿命："
        '
        'TxtCarrierID
        '
        Me.TxtCarrierID.BackColor = System.Drawing.Color.White
        Me.TxtCarrierID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCarrierID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtCarrierID.Location = New System.Drawing.Point(284, 25)
        Me.TxtCarrierID.Name = "TxtCarrierID"
        Me.TxtCarrierID.Size = New System.Drawing.Size(144, 21)
        Me.TxtCarrierID.TabIndex = 26
        '
        'TxtCarrierDesc
        '
        Me.TxtCarrierDesc.BackColor = System.Drawing.Color.White
        Me.TxtCarrierDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCarrierDesc.Location = New System.Drawing.Point(825, 52)
        Me.TxtCarrierDesc.MaxLength = 50
        Me.TxtCarrierDesc.Name = "TxtCarrierDesc"
        Me.TxtCarrierDesc.Size = New System.Drawing.Size(148, 21)
        Me.TxtCarrierDesc.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(215, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "载具编号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(445, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "载具名称："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(754, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "载具描述："
        '
        'TxtCarrierName
        '
        Me.TxtCarrierName.AcceptsReturn = True
        Me.TxtCarrierName.BackColor = System.Drawing.Color.White
        Me.TxtCarrierName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCarrierName.Location = New System.Drawing.Point(516, 25)
        Me.TxtCarrierName.MaxLength = 20
        Me.TxtCarrierName.Name = "TxtCarrierName"
        Me.TxtCarrierName.Size = New System.Drawing.Size(192, 21)
        Me.TxtCarrierName.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(718, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 12)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "单载具产品数量："
        '
        'dgvRstation
        '
        Me.dgvRstation.AllowUserToAddRows = False
        Me.dgvRstation.AllowUserToDeleteRows = False
        Me.dgvRstation.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvRstation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRstation.BackgroundColor = System.Drawing.Color.White
        Me.dgvRstation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvRstation.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvRstation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRstation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRstation.ColumnHeadersHeight = 25
        Me.dgvRstation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.Column7, Me.Column2, Me.Column3, Me.Column8, Me.Column4, Me.Column5, Me.Column1, Me.Column6, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRstation.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRstation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRstation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvRstation.GridColor = System.Drawing.Color.Silver
        Me.dgvRstation.Location = New System.Drawing.Point(0, 0)
        Me.dgvRstation.MultiSelect = False
        Me.dgvRstation.Name = "dgvRstation"
        Me.dgvRstation.ReadOnly = True
        Me.dgvRstation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvRstation.RowHeadersWidth = 4
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgvRstation.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRstation.RowTemplate.Height = 24
        Me.dgvRstation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvRstation.ShowEditingIcon = False
        Me.dgvRstation.Size = New System.Drawing.Size(1020, 304)
        Me.dgvRstation.TabIndex = 26
        Me.dgvRstation.TabStop = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "料件编号"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "载具类别"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "载具编号"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "载具名称"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "单载具产品数量"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 120
        '
        'Column4
        '
        Me.Column4.HeaderText = "使用寿命"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 80
        '
        'Column5
        '
        Me.Column5.HeaderText = "预警次数"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 80
        '
        'Column1
        '
        Me.Column1.HeaderText = "载具描述"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "有效否"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 80
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "设置人员"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "设置时间"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'statusStrip2
        '
        Me.statusStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.toolStripStatusLabel3})
        Me.statusStrip2.Location = New System.Drawing.Point(0, 465)
        Me.statusStrip2.Name = "statusStrip2"
        Me.statusStrip2.Size = New System.Drawing.Size(1020, 22)
        Me.statusStrip2.TabIndex = 129
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
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(73, 22)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "删 除(&D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 22)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(72, 22)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 22)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 22)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.toolAbandon, Me.ToolStripSeparator1, Me.toolSave, Me.toolBack, Me.toolStripSeparator4, Me.toolQuery, Me.ToolStripSeparator2, Me.toolCheck, Me.toolStripSeparator3, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 3)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1020, 25)
        Me.toolStrip1.TabIndex = 130
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 22)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolCheck
        '
        Me.toolCheck.Image = CType(resources.GetObject("toolCheck.Image"), System.Drawing.Image)
        Me.toolCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolCheck.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolCheck.Name = "toolCheck"
        Me.toolCheck.Size = New System.Drawing.Size(142, 22)
        Me.toolCheck.Tag = ""
        Me.toolCheck.Text = "更新产能统计线别(&C)"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "工站类别"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "工站编号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "工站名称"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
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
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "设置时间"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "设置人员"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "设置时间"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'FrmMjBasicMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 487)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.statusStrip2)
        Me.Controls.Add(Me.toolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMjBasicMessage"
        Me.Text = "载治具基本资料维护"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvRstation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip2.ResumeLayout(False)
        Me.statusStrip2.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCarrierDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCarrierName As System.Windows.Forms.TextBox
    Friend WithEvents dgvRstation As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents statusStrip2 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolCheck As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtCarrierID As System.Windows.Forms.TextBox
    Friend WithEvents TxtAlertCount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtAllowUseCount As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCarriType As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCcavQty As System.Windows.Forms.TextBox
    Friend WithEvents TxtPartid As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CobMatype As System.Windows.Forms.ComboBox
    Friend WithEvents CobLineid As System.Windows.Forms.ComboBox
    Friend WithEvents Cobdept As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
