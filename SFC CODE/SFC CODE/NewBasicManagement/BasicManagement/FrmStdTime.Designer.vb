<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStdTime
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStdTime))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvRstation = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbProductType = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAdd = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFinishMax = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFinishMin = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStdTime = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVarMax = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVarMin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkVariable = New System.Windows.Forms.CheckBox()
        Me.txtNewStationID = New TextBoxUL.TextBoxUL()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStationid = New TextBoxUL.TextBoxUL()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripLabel()
        Me.Labelcount = New System.Windows.Forms.ToolStripLabel()
        Me.TlelCount = New System.Windows.Forms.ToolStripLabel()
        Me.LblMsg = New System.Windows.Forms.ToolStripLabel()
        Me.dgvStdTime = New System.Windows.Forms.DataGridView()
        Me.SplitContainerB = New System.Windows.Forms.SplitContainer()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolCopy = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.tsProductTypeInfo = New System.Windows.Forms.ToolStripButton()
        Me.btnSelectDestSta = New System.Windows.Forms.Button()
        Me.BtnSelectSta = New System.Windows.Forms.Button()
        Me.ColID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColProductType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVariableMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVariableMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFinishSizeMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFinishSizeMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStandardHour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFinishSizeAdd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWorkHour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUserid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExistVariables = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStrip1.SuspendLayout()
        CType(Me.dgvRstation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.dgvStdTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerB.Panel1.SuspendLayout()
        Me.SplitContainerB.Panel2.SuspendLayout()
        Me.SplitContainerB.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.ToolCopy, Me.toolEdit, Me.toolDelete, Me.ToolStripSeparator1, Me.toolSave, Me.toolBack, Me.toolStripSeparator4, Me.toolQuery, Me.ToolStripSeparator2, Me.toolExit, Me.tsProductTypeInfo})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1757, 25)
        Me.toolStrip1.TabIndex = 129
        Me.toolStrip1.Text = "toolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        Me.dgvRstation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column13, Me.Column11, Me.Column12, Me.Column6, Me.Column1, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18})
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
        Me.dgvRstation.Size = New System.Drawing.Size(1131, 402)
        Me.dgvRstation.TabIndex = 131
        Me.dgvRstation.TabStop = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "工站类别"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "工站编号"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "工站名称"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "工站描述"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 120
        '
        'Column7
        '
        Me.Column7.HeaderText = "工段类型"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "设备治具"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "产品类型"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "岗位技能代码"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "岗位技能描述"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "品质报表类型"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "操作SOP"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "有效否"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 80
        '
        'Column1
        '
        Me.Column1.HeaderText = "冻结状态"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvStdTime)
        Me.SplitContainer1.Size = New System.Drawing.Size(1131, 366)
        Me.SplitContainer1.SplitterDistance = 90
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 120
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbProductType)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtAdd)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtFinishMax)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtFinishMin)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtStdTime)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtVarMax)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtVarMin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkVariable)
        Me.GroupBox1.Controls.Add(Me.btnSelectDestSta)
        Me.GroupBox1.Controls.Add(Me.txtNewStationID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtStationid)
        Me.GroupBox1.Controls.Add(Me.BtnSelectSta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1131, 90)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbProductType
        '
        Me.cmbProductType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProductType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProductType.FormattingEnabled = True
        Me.cmbProductType.Location = New System.Drawing.Point(79, 39)
        Me.cmbProductType.Name = "cmbProductType"
        Me.cmbProductType.Size = New System.Drawing.Size(221, 20)
        Me.cmbProductType.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 12)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "产品形态:"
        '
        'txtAdd
        '
        Me.txtAdd.Location = New System.Drawing.Point(830, 47)
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.Size = New System.Drawing.Size(207, 21)
        Me.txtAdd.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(753, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 12)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "长度加项(s):"
        '
        'txtFinishMax
        '
        Me.txtFinishMax.Location = New System.Drawing.Point(654, 47)
        Me.txtFinishMax.Name = "txtFinishMax"
        Me.txtFinishMax.Size = New System.Drawing.Size(70, 21)
        Me.txtFinishMax.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(631, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "～"
        '
        'txtFinishMin
        '
        Me.txtFinishMin.Location = New System.Drawing.Point(556, 48)
        Me.txtFinishMin.Name = "txtFinishMin"
        Me.txtFinishMin.Size = New System.Drawing.Size(70, 21)
        Me.txtFinishMin.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(445, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 12)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "成品尺寸L范围(mm):"
        '
        'txtStdTime
        '
        Me.txtStdTime.Location = New System.Drawing.Point(79, 65)
        Me.txtStdTime.Name = "txtStdTime"
        Me.txtStdTime.Size = New System.Drawing.Size(221, 21)
        Me.txtStdTime.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 12)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "标准工时(s):"
        '
        'txtVarMax
        '
        Me.txtVarMax.Location = New System.Drawing.Point(896, 17)
        Me.txtVarMax.Name = "txtVarMax"
        Me.txtVarMax.Size = New System.Drawing.Size(70, 21)
        Me.txtVarMax.TabIndex = 10
        Me.txtVarMax.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(873, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "～"
        Me.Label4.Visible = False
        '
        'txtVarMin
        '
        Me.txtVarMin.Location = New System.Drawing.Point(797, 17)
        Me.txtVarMin.Name = "txtVarMin"
        Me.txtVarMin.Size = New System.Drawing.Size(71, 21)
        Me.txtVarMin.TabIndex = 8
        Me.txtVarMin.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(699, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "变量项X范围(mm):"
        Me.Label3.Visible = False
        '
        'chkVariable
        '
        Me.chkVariable.AutoSize = True
        Me.chkVariable.Location = New System.Drawing.Point(617, 21)
        Me.chkVariable.Name = "chkVariable"
        Me.chkVariable.Size = New System.Drawing.Size(72, 16)
        Me.chkVariable.TabIndex = 6
        Me.chkVariable.Text = "含变量项"
        Me.chkVariable.UseVisualStyleBackColor = True
        Me.chkVariable.Visible = False
        '
        'txtNewStationID
        '
        Me.txtNewStationID.BackColor = System.Drawing.Color.White
        Me.txtNewStationID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.txtNewStationID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtNewStationID.ForeColor = System.Drawing.Color.Black
        Me.txtNewStationID.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.txtNewStationID.Location = New System.Drawing.Point(1069, 16)
        Me.txtNewStationID.Name = "txtNewStationID"
        Me.txtNewStationID.ReadOnly = True
        Me.txtNewStationID.Size = New System.Drawing.Size(45, 21)
        Me.txtNewStationID.TabIndex = 4
        Me.txtNewStationID.TabStop = False
        Me.txtNewStationID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1010, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "复制工站:"
        Me.Label2.Visible = False
        '
        'txtStationid
        '
        Me.txtStationid.BackColor = System.Drawing.Color.White
        Me.txtStationid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.txtStationid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtStationid.ForeColor = System.Drawing.Color.Black
        Me.txtStationid.HotColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.txtStationid.Location = New System.Drawing.Point(79, 11)
        Me.txtStationid.Name = "txtStationid"
        Me.txtStationid.ReadOnly = True
        Me.txtStationid.Size = New System.Drawing.Size(221, 21)
        Me.txtStationid.TabIndex = 1
        Me.txtStationid.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工站:"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ToolLblCount, Me.Labelcount, Me.TlelCount, Me.LblMsg})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 254)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1131, 20)
        Me.ToolStrip2.Stretch = True
        Me.ToolStrip2.TabIndex = 132
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 20)
        '
        'ToolLblCount
        '
        Me.ToolLblCount.ForeColor = System.Drawing.Color.Black
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(59, 17)
        Me.ToolLblCount.Text = "记录笔数:"
        '
        'Labelcount
        '
        Me.Labelcount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Labelcount.Name = "Labelcount"
        Me.Labelcount.Size = New System.Drawing.Size(0, 17)
        '
        'TlelCount
        '
        Me.TlelCount.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TlelCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TlelCount.Name = "TlelCount"
        Me.TlelCount.Size = New System.Drawing.Size(15, 17)
        Me.TlelCount.Text = "0"
        '
        'LblMsg
        '
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(0, 17)
        '
        'dgvStdTime
        '
        Me.dgvStdTime.AllowUserToAddRows = False
        Me.dgvStdTime.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvStdTime.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvStdTime.BackgroundColor = System.Drawing.Color.White
        Me.dgvStdTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvStdTime.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvStdTime.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStdTime.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvStdTime.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColID, Me.Comoid, Me.ColStationName, Me.ColProductType, Me.ColVariableMin, Me.ColVariableMax, Me.ColFinishSizeMin, Me.ColFinishSizeMax, Me.ColStandardHour, Me.ColFinishSizeAdd, Me.colWorkHour, Me.colUserid, Me.colInTime, Me.ColExistVariables})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStdTime.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvStdTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStdTime.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvStdTime.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgvStdTime.Location = New System.Drawing.Point(0, 0)
        Me.dgvStdTime.MultiSelect = False
        Me.dgvStdTime.Name = "dgvStdTime"
        Me.dgvStdTime.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvStdTime.RowHeadersWidth = 4
        Me.dgvStdTime.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvStdTime.RowTemplate.Height = 24
        Me.dgvStdTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvStdTime.ShowEditingIcon = False
        Me.dgvStdTime.Size = New System.Drawing.Size(1131, 274)
        Me.dgvStdTime.TabIndex = 131
        Me.dgvStdTime.TabStop = False
        '
        'SplitContainerB
        '
        Me.SplitContainerB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerB.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerB.Name = "SplitContainerB"
        Me.SplitContainerB.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerB.Panel1
        '
        Me.SplitContainerB.Panel1.Controls.Add(Me.toolStrip1)
        '
        'SplitContainerB.Panel2
        '
        Me.SplitContainerB.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainerB.Size = New System.Drawing.Size(1131, 402)
        Me.SplitContainerB.SplitterDistance = 35
        Me.SplitContainerB.SplitterWidth = 1
        Me.SplitContainerB.TabIndex = 19
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(73, 22)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'ToolCopy
        '
        Me.ToolCopy.Image = CType(resources.GetObject("ToolCopy.Image"), System.Drawing.Image)
        Me.ToolCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCopy.Name = "ToolCopy"
        Me.ToolCopy.Size = New System.Drawing.Size(73, 22)
        Me.ToolCopy.Tag = "NO"
        Me.ToolCopy.Text = "复 制(C)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(73, 22)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(73, 22)
        Me.toolDelete.Tag = "NO"
        Me.toolDelete.Text = "删 除(&D)"
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(75, 22)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(73, 22)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(81, 22)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(73, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'tsProductTypeInfo
        '
        Me.tsProductTypeInfo.Image = CType(resources.GetObject("tsProductTypeInfo.Image"), System.Drawing.Image)
        Me.tsProductTypeInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsProductTypeInfo.Name = "tsProductTypeInfo"
        Me.tsProductTypeInfo.Size = New System.Drawing.Size(145, 22)
        Me.tsProductTypeInfo.Text = "产品类型基础资料维护"
        '
        'btnSelectDestSta
        '
        Me.btnSelectDestSta.BackgroundImage = CType(resources.GetObject("btnSelectDestSta.BackgroundImage"), System.Drawing.Image)
        Me.btnSelectDestSta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSelectDestSta.Location = New System.Drawing.Point(1051, 43)
        Me.btnSelectDestSta.Name = "btnSelectDestSta"
        Me.btnSelectDestSta.Size = New System.Drawing.Size(30, 23)
        Me.btnSelectDestSta.TabIndex = 5
        Me.btnSelectDestSta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSelectDestSta.UseVisualStyleBackColor = True
        Me.btnSelectDestSta.Visible = False
        '
        'BtnSelectSta
        '
        Me.BtnSelectSta.BackgroundImage = CType(resources.GetObject("BtnSelectSta.BackgroundImage"), System.Drawing.Image)
        Me.BtnSelectSta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnSelectSta.Location = New System.Drawing.Point(473, 12)
        Me.BtnSelectSta.Name = "BtnSelectSta"
        Me.BtnSelectSta.Size = New System.Drawing.Size(30, 23)
        Me.BtnSelectSta.TabIndex = 2
        Me.BtnSelectSta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSelectSta.UseVisualStyleBackColor = True
        Me.BtnSelectSta.Visible = False
        '
        'ColID
        '
        Me.ColID.DataPropertyName = "ID"
        Me.ColID.HeaderText = "ID"
        Me.ColID.Name = "ColID"
        Me.ColID.Visible = False
        Me.ColID.Width = 5
        '
        'Comoid
        '
        Me.Comoid.HeaderText = "工站编号"
        Me.Comoid.Name = "Comoid"
        Me.Comoid.ReadOnly = True
        Me.Comoid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Comoid.Width = 90
        '
        'ColStationName
        '
        Me.ColStationName.DataPropertyName = "StationName"
        Me.ColStationName.HeaderText = "工站名称"
        Me.ColStationName.Name = "ColStationName"
        Me.ColStationName.ReadOnly = True
        Me.ColStationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColStationName.Width = 250
        '
        'ColProductType
        '
        Me.ColProductType.DataPropertyName = "ProductType"
        Me.ColProductType.HeaderText = "产品形态"
        Me.ColProductType.Name = "ColProductType"
        Me.ColProductType.Width = 250
        '
        'ColVariableMin
        '
        Me.ColVariableMin.DataPropertyName = "VariableMin"
        Me.ColVariableMin.HeaderText = "变量项最小值"
        Me.ColVariableMin.Name = "ColVariableMin"
        Me.ColVariableMin.ReadOnly = True
        Me.ColVariableMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColVariableMin.Visible = False
        Me.ColVariableMin.Width = 88
        '
        'ColVariableMax
        '
        Me.ColVariableMax.DataPropertyName = "VariableMax"
        Me.ColVariableMax.HeaderText = "变量项最大值"
        Me.ColVariableMax.Name = "ColVariableMax"
        Me.ColVariableMax.ReadOnly = True
        Me.ColVariableMax.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColVariableMax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColVariableMax.Visible = False
        Me.ColVariableMax.Width = 88
        '
        'ColFinishSizeMin
        '
        Me.ColFinishSizeMin.DataPropertyName = "FinishSizeMin"
        Me.ColFinishSizeMin.HeaderText = "成品尺寸最小值"
        Me.ColFinishSizeMin.Name = "ColFinishSizeMin"
        Me.ColFinishSizeMin.ReadOnly = True
        Me.ColFinishSizeMin.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColFinishSizeMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFinishSizeMin.Width = 120
        '
        'ColFinishSizeMax
        '
        Me.ColFinishSizeMax.DataPropertyName = "FinishSizeMax"
        Me.ColFinishSizeMax.HeaderText = "成品尺寸最大值"
        Me.ColFinishSizeMax.Name = "ColFinishSizeMax"
        Me.ColFinishSizeMax.ReadOnly = True
        Me.ColFinishSizeMax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFinishSizeMax.Width = 120
        '
        'ColStandardHour
        '
        Me.ColStandardHour.DataPropertyName = "StandardHour"
        Me.ColStandardHour.HeaderText = "标准工时"
        Me.ColStandardHour.Name = "ColStandardHour"
        Me.ColStandardHour.ReadOnly = True
        Me.ColStandardHour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColStandardHour.Width = 77
        '
        'ColFinishSizeAdd
        '
        Me.ColFinishSizeAdd.DataPropertyName = "FinishSizeAdd"
        Me.ColFinishSizeAdd.HeaderText = "长度加项"
        Me.ColFinishSizeAdd.Name = "ColFinishSizeAdd"
        Me.ColFinishSizeAdd.ReadOnly = True
        Me.ColFinishSizeAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColFinishSizeAdd.Width = 77
        '
        'colWorkHour
        '
        Me.colWorkHour.DataPropertyName = "WorkHour"
        Me.colWorkHour.HeaderText = "总标准工时"
        Me.colWorkHour.Name = "colWorkHour"
        Me.colWorkHour.ReadOnly = True
        Me.colWorkHour.Visible = False
        '
        'colUserid
        '
        Me.colUserid.DataPropertyName = "Userid"
        Me.colUserid.HeaderText = "设置人员"
        Me.colUserid.Name = "colUserid"
        Me.colUserid.ReadOnly = True
        Me.colUserid.Width = 80
        '
        'colInTime
        '
        Me.colInTime.DataPropertyName = "InTime"
        Me.colInTime.HeaderText = "设置时间"
        Me.colInTime.Name = "colInTime"
        Me.colInTime.Width = 150
        '
        'ColExistVariables
        '
        Me.ColExistVariables.DataPropertyName = "ExistVariables"
        Me.ColExistVariables.HeaderText = "含变量"
        Me.ColExistVariables.Name = "ColExistVariables"
        Me.ColExistVariables.Visible = False
        '
        'FrmStdTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 402)
        Me.Controls.Add(Me.SplitContainerB)
        Me.Controls.Add(Me.dgvRstation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmStdTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "标准工时资料维护"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.dgvRstation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.dgvStdTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerB.Panel1.ResumeLayout(False)
        Me.SplitContainerB.Panel2.ResumeLayout(False)
        Me.SplitContainerB.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvRstation As System.Windows.Forms.DataGridView
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtStationid As TextBoxUL.TextBoxUL
    Private WithEvents BtnSelectSta As System.Windows.Forms.Button
    Friend WithEvents txtAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFinishMax As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFinishMin As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStdTime As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtVarMax As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVarMin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkVariable As System.Windows.Forms.CheckBox
    Private WithEvents btnSelectDestSta As System.Windows.Forms.Button
    Private WithEvents txtNewStationID As TextBoxUL.TextBoxUL
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvStdTime As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Labelcount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TlelCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LblMsg As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainerB As System.Windows.Forms.SplitContainer
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbProductType As System.Windows.Forms.ComboBox
    Friend WithEvents tsProductTypeInfo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProductType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVariableMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVariableMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFinishSizeMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFinishSizeMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStandardHour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFinishSizeAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWorkHour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColExistVariables As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
