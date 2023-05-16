<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIssueReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIssueReport))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtSolveUser = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DtCreateEnd = New System.Windows.Forms.DateTimePicker()
        Me.DtCreateStar = New System.Windows.Forms.DateTimePicker()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtIssue = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtContactUser = New System.Windows.Forms.TextBox()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblPartID = New System.Windows.Forms.Label()
        Me.CobType = New System.Windows.Forms.ComboBox()
        Me.LelTpart = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.CobFactory = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtItems = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.toolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExcelAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.CobStatus = New System.Windows.Forms.ComboBox()
        Me.DtSolveEnd = New System.Windows.Forms.DateTimePicker()
        Me.DtSolveStart = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DgvIssue = New System.Windows.Forms.DataGridView()
        Me.咨询编号 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.厂区 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.类别 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.问题摘要 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.状态 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.负责人 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.最后处理时间 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.完成时间 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.咨询时间 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.联系人 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.dgvIssueAll = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1.SuspendLayout()
        Me.toolStrip.SuspendLayout()
        CType(Me.DgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIssueAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtSolveUser
        '
        Me.TxtSolveUser.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.TxtSolveUser.Location = New System.Drawing.Point(305, 63)
        Me.TxtSolveUser.Name = "TxtSolveUser"
        Me.TxtSolveUser.Size = New System.Drawing.Size(128, 21)
        Me.TxtSolveUser.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(259, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 12)
        Me.Label13.TabIndex = 247
        Me.Label13.Text = "负责人:"
        '
        'DtCreateEnd
        '
        Me.DtCreateEnd.CustomFormat = "yyyy/MM/dd"
        Me.DtCreateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtCreateEnd.Location = New System.Drawing.Point(219, 116)
        Me.DtCreateEnd.Name = "DtCreateEnd"
        Me.DtCreateEnd.ShowCheckBox = True
        Me.DtCreateEnd.Size = New System.Drawing.Size(105, 21)
        Me.DtCreateEnd.TabIndex = 10
        Me.DtCreateEnd.Value = New Date(2014, 6, 20, 0, 0, 0, 0)
        '
        'DtCreateStar
        '
        Me.DtCreateStar.CustomFormat = "yyyy/MM/dd"
        Me.DtCreateStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtCreateStar.Location = New System.Drawing.Point(68, 116)
        Me.DtCreateStar.Name = "DtCreateStar"
        Me.DtCreateStar.ShowCheckBox = True
        Me.DtCreateStar.Size = New System.Drawing.Size(106, 21)
        Me.DtCreateStar.TabIndex = 9
        Me.DtCreateStar.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(68, 17)
        Me.StatusLabel.Text = "记录笔数："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 245
        Me.Label6.Text = "咨询时间:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(199, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 12)
        Me.Label4.TabIndex = 246
        Me.Label4.Text = "至 "
        '
        'TxtIssue
        '
        Me.TxtIssue.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.TxtIssue.Location = New System.Drawing.Point(68, 89)
        Me.TxtIssue.Name = "TxtIssue"
        Me.TxtIssue.Size = New System.Drawing.Size(594, 21)
        Me.TxtIssue.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(9, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 241
        Me.Label7.Text = "问题摘要:"
        '
        'TxtContactUser
        '
        Me.TxtContactUser.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.TxtContactUser.Location = New System.Drawing.Point(68, 62)
        Me.TxtContactUser.Name = "TxtContactUser"
        Me.TxtContactUser.Size = New System.Drawing.Size(120, 21)
        Me.TxtContactUser.TabIndex = 4
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(21, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 239
        Me.Label1.Text = "联系人:"
        '
        'LblPartID
        '
        Me.LblPartID.AutoSize = True
        Me.LblPartID.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.LblPartID.Location = New System.Drawing.Point(268, 39)
        Me.LblPartID.Name = "LblPartID"
        Me.LblPartID.Size = New System.Drawing.Size(35, 12)
        Me.LblPartID.TabIndex = 237
        Me.LblPartID.Text = "类别:"
        '
        'CobType
        '
        Me.CobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobType.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.CobType.FormattingEnabled = True
        Me.CobType.Location = New System.Drawing.Point(305, 35)
        Me.CobType.Name = "CobType"
        Me.CobType.Size = New System.Drawing.Size(128, 20)
        Me.CobType.TabIndex = 2
        '
        'LelTpart
        '
        Me.LelTpart.AutoSize = True
        Me.LelTpart.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.LelTpart.Location = New System.Drawing.Point(32, 42)
        Me.LelTpart.Name = "LelTpart"
        Me.LelTpart.Size = New System.Drawing.Size(35, 12)
        Me.LelTpart.TabIndex = 236
        Me.LelTpart.Text = "厂区:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 513)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(962, 22)
        Me.StatusStrip1.TabIndex = 235
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'CobFactory
        '
        Me.CobFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobFactory.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.CobFactory.FormattingEnabled = True
        Me.CobFactory.Location = New System.Drawing.Point(68, 37)
        Me.CobFactory.Name = "CobFactory"
        Me.CobFactory.Size = New System.Drawing.Size(120, 20)
        Me.CobFactory.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(520, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 234
        Me.Label3.Text = "状态:"
        '
        'TxtItems
        '
        Me.TxtItems.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.TxtItems.Location = New System.Drawing.Point(556, 36)
        Me.TxtItems.Name = "TxtItems"
        Me.TxtItems.Size = New System.Drawing.Size(106, 21)
        Me.TxtItems.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(496, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 232
        Me.Label2.Text = "咨询编号:"
        '
        'toolStrip
        '
        Me.toolStrip.AutoSize = False
        Me.toolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnSearch, Me.ToolStripSeparator7, Me.BtnExcel, Me.ToolStripSeparator2, Me.BtnExcelAll, Me.ToolStripSeparator3, Me.btnExit})
        Me.toolStrip.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.Size = New System.Drawing.Size(962, 23)
        Me.toolStrip.TabIndex = 253
        Me.toolStrip.TabStop = True
        Me.toolStrip.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(70, 20)
        Me.btnSearch.Text = "查 找(&F)"
        Me.btnSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'BtnExcel
        '
        Me.BtnExcel.Image = CType(resources.GetObject("BtnExcel.Image"), System.Drawing.Image)
        Me.BtnExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(60, 20)
        Me.BtnExcel.Text = "汇  出"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'BtnExcelAll
        '
        Me.BtnExcelAll.Image = CType(resources.GetObject("BtnExcelAll.Image"), System.Drawing.Image)
        Me.BtnExcelAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExcelAll.Name = "BtnExcelAll"
        Me.BtnExcelAll.Size = New System.Drawing.Size(88, 20)
        Me.BtnExcelAll.Text = "汇 出 细 项"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 20)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'CobStatus
        '
        Me.CobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobStatus.FormattingEnabled = True
        Me.CobStatus.Items.AddRange(New Object() {"All", "0.新开立", "1.进行中", "2.完成"})
        Me.CobStatus.Location = New System.Drawing.Point(556, 63)
        Me.CobStatus.Name = "CobStatus"
        Me.CobStatus.Size = New System.Drawing.Size(106, 20)
        Me.CobStatus.TabIndex = 6
        '
        'DtSolveEnd
        '
        Me.DtSolveEnd.Checked = False
        Me.DtSolveEnd.CustomFormat = "yyyy/MM/dd"
        Me.DtSolveEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtSolveEnd.Location = New System.Drawing.Point(555, 116)
        Me.DtSolveEnd.Name = "DtSolveEnd"
        Me.DtSolveEnd.ShowCheckBox = True
        Me.DtSolveEnd.Size = New System.Drawing.Size(107, 21)
        Me.DtSolveEnd.TabIndex = 11
        Me.DtSolveEnd.Value = New Date(2014, 6, 20, 0, 0, 0, 0)
        '
        'DtSolveStart
        '
        Me.DtSolveStart.Checked = False
        Me.DtSolveStart.CustomFormat = "yyyy/MM/dd"
        Me.DtSolveStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtSolveStart.Location = New System.Drawing.Point(413, 116)
        Me.DtSolveStart.Name = "DtSolveStart"
        Me.DtSolveStart.ShowCheckBox = True
        Me.DtSolveStart.Size = New System.Drawing.Size(106, 21)
        Me.DtSolveStart.TabIndex = 10
        Me.DtSolveStart.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(354, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 257
        Me.Label5.Text = "处理时间:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(535, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 12)
        Me.Label8.TabIndex = 258
        Me.Label8.Text = "至 "
        '
        'DgvIssue
        '
        Me.DgvIssue.AllowUserToAddRows = False
        Me.DgvIssue.AllowUserToDeleteRows = False
        Me.DgvIssue.AllowUserToOrderColumns = True
        Me.DgvIssue.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DgvIssue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvIssue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvIssue.BackgroundColor = System.Drawing.Color.White
        Me.DgvIssue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvIssue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvIssue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvIssue.ColumnHeadersHeight = 24
        Me.DgvIssue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.咨询编号, Me.厂区, Me.类别, Me.问题摘要, Me.状态, Me.负责人, Me.最后处理时间, Me.完成时间, Me.咨询时间, Me.联系人})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvIssue.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvIssue.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgvIssue.Location = New System.Drawing.Point(0, 159)
        Me.DgvIssue.MultiSelect = False
        Me.DgvIssue.Name = "DgvIssue"
        Me.DgvIssue.ReadOnly = True
        Me.DgvIssue.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvIssue.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvIssue.RowHeadersVisible = False
        Me.DgvIssue.RowHeadersWidth = 4
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.DgvIssue.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvIssue.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgvIssue.RowTemplate.Height = 24
        Me.DgvIssue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgvIssue.ShowEditingIcon = False
        Me.DgvIssue.Size = New System.Drawing.Size(962, 351)
        Me.DgvIssue.TabIndex = 259
        Me.DgvIssue.TabStop = False
        '
        '咨询编号
        '
        Me.咨询编号.DataPropertyName = "咨询编号"
        Me.咨询编号.Frozen = True
        Me.咨询编号.HeaderText = "咨询编号"
        Me.咨询编号.Name = "咨询编号"
        Me.咨询编号.ReadOnly = True
        '
        '厂区
        '
        Me.厂区.DataPropertyName = "厂区"
        Me.厂区.Frozen = True
        Me.厂区.HeaderText = "厂区"
        Me.厂区.Name = "厂区"
        Me.厂区.ReadOnly = True
        '
        '类别
        '
        Me.类别.DataPropertyName = "类别"
        Me.类别.Frozen = True
        Me.类别.HeaderText = "类别"
        Me.类别.Name = "类别"
        Me.类别.ReadOnly = True
        '
        '问题摘要
        '
        Me.问题摘要.DataPropertyName = "问题摘要"
        Me.问题摘要.HeaderText = "问题摘要"
        Me.问题摘要.Name = "问题摘要"
        Me.问题摘要.ReadOnly = True
        Me.问题摘要.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.问题摘要.Width = 300
        '
        '状态
        '
        Me.状态.DataPropertyName = "状态"
        Me.状态.HeaderText = "状态"
        Me.状态.Name = "状态"
        Me.状态.ReadOnly = True
        '
        '负责人
        '
        Me.负责人.DataPropertyName = "负责人"
        Me.负责人.HeaderText = "负责人"
        Me.负责人.Name = "负责人"
        Me.负责人.ReadOnly = True
        '
        '最后处理时间
        '
        Me.最后处理时间.DataPropertyName = "最后处理时间"
        Me.最后处理时间.HeaderText = "最后处理时间"
        Me.最后处理时间.Name = "最后处理时间"
        Me.最后处理时间.ReadOnly = True
        '
        '完成时间
        '
        Me.完成时间.DataPropertyName = "完成时间"
        Me.完成时间.HeaderText = "完成时间"
        Me.完成时间.Name = "完成时间"
        Me.完成时间.ReadOnly = True
        '
        '咨询时间
        '
        Me.咨询时间.DataPropertyName = "咨询时间"
        Me.咨询时间.HeaderText = "咨询时间"
        Me.咨询时间.Name = "咨询时间"
        Me.咨询时间.ReadOnly = True
        '
        '联系人
        '
        Me.联系人.DataPropertyName = "联系人"
        Me.联系人.HeaderText = "联系人"
        Me.联系人.Name = "联系人"
        Me.联系人.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "咨询编号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "厂区"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "类别"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "问题摘要"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn4.Width = 300
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "负责人"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "处理时间"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "完成时间"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "咨询时间"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "联系人"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'dgvIssueAll
        '
        Me.dgvIssueAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIssueAll.Location = New System.Drawing.Point(0, 159)
        Me.dgvIssueAll.Name = "dgvIssueAll"
        Me.dgvIssueAll.RowTemplate.Height = 23
        Me.dgvIssueAll.Size = New System.Drawing.Size(240, 150)
        Me.dgvIssueAll.TabIndex = 260
        '
        'FrmIssueReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 535)
        Me.Controls.Add(Me.DgvIssue)
        Me.Controls.Add(Me.DtSolveEnd)
        Me.Controls.Add(Me.DtSolveStart)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CobStatus)
        Me.Controls.Add(Me.toolStrip)
        Me.Controls.Add(Me.TxtSolveUser)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DtCreateEnd)
        Me.Controls.Add(Me.DtCreateStar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtIssue)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtContactUser)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblPartID)
        Me.Controls.Add(Me.CobType)
        Me.Controls.Add(Me.LelTpart)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CobFactory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtItems)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvIssueAll)
        Me.Name = "FrmIssueReport"
        Me.Text = "问题报表"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        CType(Me.DgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIssueAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSolveUser As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DtCreateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtCreateStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtIssue As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtContactUser As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblPartID As System.Windows.Forms.Label
    Friend WithEvents CobType As System.Windows.Forms.ComboBox
    Friend WithEvents LelTpart As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents CobFactory As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtItems As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CobStatus As System.Windows.Forms.ComboBox
    Friend WithEvents DtSolveEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtSolveStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnExcelAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DgvIssue As System.Windows.Forms.DataGridView
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
    Friend WithEvents dgvIssueAll As System.Windows.Forms.DataGridView
    Friend WithEvents 咨询编号 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 厂区 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 类别 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 问题摘要 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 状态 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 负责人 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 最后处理时间 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 完成时间 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 咨询时间 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 联系人 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
