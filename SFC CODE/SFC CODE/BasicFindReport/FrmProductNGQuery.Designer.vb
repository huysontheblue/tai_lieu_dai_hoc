<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductNGQuery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductNGQuery))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DtEnd = New System.Windows.Forms.DateTimePicker()
        Me.DtStar = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbLine = New System.Windows.Forms.ComboBox()
        Me.cbbDept = New System.Windows.Forms.ComboBox()
        Me.txtWorkCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.DgData = New System.Windows.Forms.DataGridView()
        Me.colDept = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.DgDataDetail = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMoid2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.StatusStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.DgData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgDataDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel1.Text = "記錄筆數:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 400)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1167, 22)
        Me.StatusStrip1.TabIndex = 184
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolCount
        '
        Me.ToolCount.BackColor = System.Drawing.SystemColors.Control
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolCount.Text = "0"
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(308, 27)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.Size = New System.Drawing.Size(154, 21)
        Me.DtEnd.TabIndex = 1
        Me.DtEnd.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(70, 27)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.Size = New System.Drawing.Size(155, 21)
        Me.DtStar.TabIndex = 0
        Me.DtStar.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(12, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 182
        Me.Label6.Text = "起始时间："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(263, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 12)
        Me.Label5.TabIndex = 183
        Me.Label5.Text = "至 "
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolExcel
        '
        Me.toolExcel.Image = CType(resources.GetObject("toolExcel.Image"), System.Drawing.Image)
        Me.toolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExcel.Name = "toolExcel"
        Me.toolExcel.Size = New System.Drawing.Size(64, 22)
        Me.toolExcel.Text = "汇   出"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'txtPartNo
        '
        Me.txtPartNo.Location = New System.Drawing.Point(308, 54)
        Me.txtPartNo.MaxLength = 50
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(154, 21)
        Me.txtPartNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(247, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "料件编号："
        '
        'cbbLine
        '
        Me.cbbLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbbLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbbLine.FormattingEnabled = True
        Me.cbbLine.Location = New System.Drawing.Point(556, 54)
        Me.cbbLine.Name = "cbbLine"
        Me.cbbLine.Size = New System.Drawing.Size(138, 20)
        Me.cbbLine.TabIndex = 5
        '
        'cbbDept
        '
        Me.cbbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbDept.FormattingEnabled = True
        Me.cbbDept.Location = New System.Drawing.Point(556, 27)
        Me.cbbDept.Name = "cbbDept"
        Me.cbbDept.Size = New System.Drawing.Size(138, 20)
        Me.cbbDept.TabIndex = 4
        '
        'txtWorkCode
        '
        Me.txtWorkCode.Location = New System.Drawing.Point(70, 54)
        Me.txtWorkCode.MaxLength = 50
        Me.txtWorkCode.Name = "txtWorkCode"
        Me.txtWorkCode.Size = New System.Drawing.Size(155, 21)
        Me.txtWorkCode.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(496, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "生产部门："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(495, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "生产线别："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 174
        Me.Label3.Text = "工单编号："
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolQuery, Me.ToolStripSeparator1, Me.toolExcel, Me.ToolStripSeparator2, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, -1)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1167, 25)
        Me.toolStrip1.TabIndex = 169
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'DgData
        '
        Me.DgData.AllowUserToAddRows = False
        Me.DgData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DgData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgData.BackgroundColor = System.Drawing.Color.White
        Me.DgData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDept, Me.ColLine, Me.colMoid, Me.colPartId, Me.Column6, Me.Column2, Me.Column1, Me.Column9})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgData.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgData.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgData.Location = New System.Drawing.Point(0, 0)
        Me.DgData.MultiSelect = False
        Me.DgData.Name = "DgData"
        Me.DgData.ReadOnly = True
        Me.DgData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgData.RowHeadersWidth = 4
        Me.DgData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgData.RowTemplate.Height = 24
        Me.DgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgData.ShowEditingIcon = False
        Me.DgData.Size = New System.Drawing.Size(748, 316)
        Me.DgData.TabIndex = 171
        Me.DgData.TabStop = False
        '
        'colDept
        '
        Me.colDept.DataPropertyName = "生产部门"
        Me.colDept.HeaderText = "生产部门"
        Me.colDept.Name = "colDept"
        Me.colDept.ReadOnly = True
        Me.colDept.Width = 180
        '
        'ColLine
        '
        Me.ColLine.DataPropertyName = "生产线别"
        Me.ColLine.HeaderText = "生产线别"
        Me.ColLine.Name = "ColLine"
        Me.ColLine.ReadOnly = True
        Me.ColLine.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colMoid
        '
        Me.colMoid.DataPropertyName = "工单编号"
        Me.colMoid.HeaderText = "工单编号"
        Me.colMoid.Name = "colMoid"
        Me.colMoid.ReadOnly = True
        Me.colMoid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colMoid.Width = 110
        '
        'colPartId
        '
        Me.colPartId.DataPropertyName = "料件编号"
        Me.colPartId.HeaderText = "料件编号"
        Me.colPartId.Name = "colPartId"
        Me.colPartId.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "工单数量"
        Me.Column6.HeaderText = "工单数量"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 90
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "总产出"
        Me.Column2.HeaderText = "总产出"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "总不良数"
        Me.Column1.HeaderText = "总不良数"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "总不良率"
        Me.Column9.HeaderText = "总不良率"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 80
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(712, 59)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblMsg.TabIndex = 185
        '
        'DgDataDetail
        '
        Me.DgDataDetail.AllowUserToAddRows = False
        Me.DgDataDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue
        Me.DgDataDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DgDataDetail.BackgroundColor = System.Drawing.Color.White
        Me.DgDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgDataDetail.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgDataDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgDataDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgDataDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.colMoid2, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgDataDetail.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgDataDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgDataDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgDataDetail.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgDataDetail.Location = New System.Drawing.Point(0, 0)
        Me.DgDataDetail.MultiSelect = False
        Me.DgDataDetail.Name = "DgDataDetail"
        Me.DgDataDetail.ReadOnly = True
        Me.DgDataDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgDataDetail.RowHeadersWidth = 4
        Me.DgDataDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgDataDetail.RowTemplate.Height = 24
        Me.DgDataDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgDataDetail.ShowEditingIcon = False
        Me.DgDataDetail.Size = New System.Drawing.Size(415, 316)
        Me.DgDataDetail.TabIndex = 186
        Me.DgDataDetail.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "生产部门"
        Me.DataGridViewTextBoxColumn1.HeaderText = "生产部门"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "生产线别"
        Me.DataGridViewTextBoxColumn2.HeaderText = "生产线别"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'colMoid2
        '
        Me.colMoid2.DataPropertyName = "工单编号"
        Me.colMoid2.HeaderText = "工单编号"
        Me.colMoid2.Name = "colMoid2"
        Me.colMoid2.ReadOnly = True
        Me.colMoid2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "料件编号"
        Me.DataGridViewTextBoxColumn4.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "工单数量"
        Me.DataGridViewTextBoxColumn5.HeaderText = "工单数量"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "不良现象大类"
        Me.DataGridViewTextBoxColumn9.HeaderText = "不良现象大类"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "不良现象"
        Me.DataGridViewTextBoxColumn10.HeaderText = "不良现象"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "不良数"
        Me.DataGridViewTextBoxColumn11.HeaderText = "不良数"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 70
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "不良率"
        Me.DataGridViewTextBoxColumn12.HeaderText = "不良率"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 70
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 81)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgData)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgDataDetail)
        Me.SplitContainer1.Size = New System.Drawing.Size(1167, 316)
        Me.SplitContainer1.SplitterDistance = 748
        Me.SplitContainer1.TabIndex = 187
        '
        'FrmProductNGQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 422)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DtEnd)
        Me.Controls.Add(Me.DtStar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPartNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbbLine)
        Me.Controls.Add(Me.cbbDept)
        Me.Controls.Add(Me.txtWorkCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmProductNGQuery"
        Me.Text = "生产不良统计报表"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.DgData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgDataDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbLine As System.Windows.Forms.ComboBox
    Friend WithEvents cbbDept As System.Windows.Forms.ComboBox
    Friend WithEvents txtWorkCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DgData As System.Windows.Forms.DataGridView
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents DgDataDetail As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMoid2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
