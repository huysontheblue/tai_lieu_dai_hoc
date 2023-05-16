<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParetoShow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParetoShow))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer8 = New System.Windows.Forms.SplitContainer()
        Me.dgvNG = New System.Windows.Forms.DataGridView()
        Me.dgvNGProcess = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.cboQueryLine = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboPartID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnQuery = New System.Windows.Forms.Button()
        Me.btnSub = New System.Windows.Forms.Button()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblMOQty = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblLineID = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPartID = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolConifrm_Line = New System.Windows.Forms.ToolStripButton()
        Me.toolConifrm_PG = New System.Windows.Forms.ToolStripButton()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.toolPDF = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolPartId = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRejectText = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer()
        Me.lblNgReason = New System.Windows.Forms.Label()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNGReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSolution = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWorker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFinishTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTrackingResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer8.Panel1.SuspendLayout()
        Me.SplitContainer8.Panel2.SuspendLayout()
        Me.SplitContainer8.SuspendLayout()
        CType(Me.dgvNG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNGProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.AutoScroll = True
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer8)
        Me.SplitContainer2.Size = New System.Drawing.Size(1175, 628)
        Me.SplitContainer2.SplitterDistance = 466
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer8
        '
        Me.SplitContainer8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer8.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer8.Name = "SplitContainer8"
        '
        'SplitContainer8.Panel1
        '
        Me.SplitContainer8.Panel1.Controls.Add(Me.dgvNG)
        '
        'SplitContainer8.Panel2
        '
        Me.SplitContainer8.Panel2.Controls.Add(Me.dgvNGProcess)
        Me.SplitContainer8.Size = New System.Drawing.Size(1175, 161)
        Me.SplitContainer8.SplitterDistance = 379
        Me.SplitContainer8.TabIndex = 1
        '
        'dgvNG
        '
        Me.dgvNG.AllowUserToAddRows = False
        Me.dgvNG.AllowUserToDeleteRows = False
        Me.dgvNG.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvNG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNG.Location = New System.Drawing.Point(0, 0)
        Me.dgvNG.Name = "dgvNG"
        Me.dgvNG.ReadOnly = True
        Me.dgvNG.RowHeadersWidth = 35
        Me.dgvNG.RowTemplate.Height = 23
        Me.dgvNG.Size = New System.Drawing.Size(379, 161)
        Me.dgvNG.TabIndex = 0
        '
        'dgvNGProcess
        '
        Me.dgvNGProcess.AllowUserToAddRows = False
        Me.dgvNGProcess.AllowUserToDeleteRows = False
        Me.dgvNGProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNGProcess.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.colNGReason, Me.colSolution, Me.colWorker, Me.colFinishTime, Me.colTrackingResult, Me.colCodeid})
        Me.dgvNGProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNGProcess.Location = New System.Drawing.Point(0, 0)
        Me.dgvNGProcess.Name = "dgvNGProcess"
        Me.dgvNGProcess.RowTemplate.Height = 23
        Me.dgvNGProcess.Size = New System.Drawing.Size(792, 161)
        Me.dgvNGProcess.TabIndex = 0
        Me.dgvNGProcess.Tag = ""
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer6)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1175, 713)
        Me.SplitContainer1.SplitterDistance = 84
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer6.Panel1.Controls.Add(Me.cmbType)
        Me.SplitContainer6.Panel1.Controls.Add(Me.dtpDate)
        Me.SplitContainer6.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer6.Panel1.Controls.Add(Me.lblStartDate)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer6.Size = New System.Drawing.Size(1175, 84)
        Me.SplitContainer6.SplitterDistance = 40
        Me.SplitContainer6.TabIndex = 1
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Location = New System.Drawing.Point(323, 3)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.dtpDateTo)
        Me.SplitContainer4.Panel1.Controls.Add(Me.lblEndDate)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.cboQueryLine)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer4.Panel2.Controls.Add(Me.cboPartID)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer4.Panel2.Controls.Add(Me.BtnQuery)
        Me.SplitContainer4.Panel2.Controls.Add(Me.btnSub)
        Me.SplitContainer4.Size = New System.Drawing.Size(840, 34)
        Me.SplitContainer4.SplitterDistance = 150
        Me.SplitContainer4.TabIndex = 7
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Enabled = False
        Me.dtpDateTo.Location = New System.Drawing.Point(43, 3)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(106, 21)
        Me.dtpDateTo.TabIndex = 2
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.lblEndDate.Location = New System.Drawing.Point(1, 8)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(47, 12)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "结束日:"
        '
        'cboQueryLine
        '
        Me.cboQueryLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQueryLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQueryLine.FormattingEnabled = True
        Me.cboQueryLine.Location = New System.Drawing.Point(47, 4)
        Me.cboQueryLine.Name = "cboQueryLine"
        Me.cboQueryLine.Size = New System.Drawing.Size(121, 20)
        Me.cboQueryLine.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(174, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "料号:"
        '
        'cboPartID
        '
        Me.cboPartID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartID.FormattingEnabled = True
        Me.cboPartID.Location = New System.Drawing.Point(213, 4)
        Me.cboPartID.Name = "cboPartID"
        Me.cboPartID.Size = New System.Drawing.Size(121, 20)
        Me.cboPartID.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 12)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "线别:"
        '
        'BtnQuery
        '
        Me.BtnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnQuery.Image = CType(resources.GetObject("BtnQuery.Image"), System.Drawing.Image)
        Me.BtnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnQuery.Location = New System.Drawing.Point(350, -4)
        Me.BtnQuery.Name = "BtnQuery"
        Me.BtnQuery.Size = New System.Drawing.Size(72, 30)
        Me.BtnQuery.TabIndex = 5
        Me.BtnQuery.Text = "查 詢"
        Me.BtnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnQuery.UseVisualStyleBackColor = True
        '
        'btnSub
        '
        Me.btnSub.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSub.Location = New System.Drawing.Point(447, -4)
        Me.btnSub.Name = "btnSub"
        Me.btnSub.Size = New System.Drawing.Size(72, 30)
        Me.btnSub.TabIndex = 6
        Me.btnSub.Text = "参照数据"
        Me.btnSub.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSub.UseVisualStyleBackColor = True
        '
        'cmbType
        '
        Me.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"日", "周", "月"})
        Me.cmbType.Location = New System.Drawing.Point(104, 7)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(57, 20)
        Me.cmbType.TabIndex = 0
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(211, 7)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(106, 21)
        Me.dtpDate.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(51, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 12)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "月周日:"
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.lblStartDate.Location = New System.Drawing.Point(169, 11)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(47, 12)
        Me.lblStartDate.TabIndex = 2
        Me.lblStartDate.Text = "开始日:"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblUserName)
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblMOQty)
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblNgReason)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblDate)
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblLineID)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblPartID)
        Me.SplitContainer3.Size = New System.Drawing.Size(1175, 40)
        Me.SplitContainer3.SplitterDistance = 25
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(545, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "制程不良分析表"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(887, 6)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(23, 12)
        Me.lblUserName.TabIndex = 7
        Me.lblUserName.Text = "   "
        '
        'lblMOQty
        '
        Me.lblMOQty.AutoSize = True
        Me.lblMOQty.Location = New System.Drawing.Point(727, 6)
        Me.lblMOQty.Name = "lblMOQty"
        Me.lblMOQty.Size = New System.Drawing.Size(23, 12)
        Me.lblMOQty.TabIndex = 7
        Me.lblMOQty.Text = "   "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(834, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "确认人:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(632, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "生产数量(PCS):"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(69, 7)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(23, 12)
        Me.lblDate.TabIndex = 1
        Me.lblDate.Text = "   "
        '
        'lblLineID
        '
        Me.lblLineID.AutoSize = True
        Me.lblLineID.Location = New System.Drawing.Point(513, 6)
        Me.lblLineID.Name = "lblLineID"
        Me.lblLineID.Size = New System.Drawing.Size(23, 12)
        Me.lblLineID.TabIndex = 5
        Me.lblLineID.Text = "   "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "日期:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(471, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "线别:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(275, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "料号:"
        '
        'lblPartID
        '
        Me.lblPartID.AutoSize = True
        Me.lblPartID.Location = New System.Drawing.Point(317, 6)
        Me.lblPartID.Name = "lblPartID"
        Me.lblPartID.Size = New System.Drawing.Size(17, 12)
        Me.lblPartID.TabIndex = 3
        Me.lblPartID.Text = "  "
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ItemSEQ"
        Me.DataGridViewTextBoxColumn1.HeaderText = "NO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 30
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ItemName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "不良项目"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NGReason"
        Me.DataGridViewTextBoxColumn3.HeaderText = "不良原因"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 460
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Action"
        Me.DataGridViewTextBoxColumn4.HeaderText = "处理方案"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 460
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "pic"
        Me.DataGridViewTextBoxColumn5.HeaderText = "责任人"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "finishtime"
        Me.DataGridViewTextBoxColumn6.HeaderText = "完成时间"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "TrackingResult"
        Me.DataGridViewTextBoxColumn7.HeaderText = "结果追踪"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.toolSearch, Me.ToolStripSeparator3, Me.toolConifrm_Line, Me.toolConifrm_PG, Me.toolAbandon, Me.toolPDF, Me.ToolStripSeparator2, Me.toolPartId, Me.ToolStripSeparator1, Me.tsbRejectText, Me.ToolStripSeparator4, Me.toolExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1175, 23)
        Me.ToolBt.TabIndex = 47
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'toolSearch
        '
        Me.toolSearch.Image = CType(resources.GetObject("toolSearch.Image"), System.Drawing.Image)
        Me.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSearch.Name = "toolSearch"
        Me.toolSearch.Size = New System.Drawing.Size(70, 20)
        Me.toolSearch.Text = "查 找(&F)"
        Me.toolSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'toolConifrm_Line
        '
        Me.toolConifrm_Line.Image = CType(resources.GetObject("toolConifrm_Line.Image"), System.Drawing.Image)
        Me.toolConifrm_Line.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolConifrm_Line.Name = "toolConifrm_Line"
        Me.toolConifrm_Line.Size = New System.Drawing.Size(90, 20)
        Me.toolConifrm_Line.Text = "产线确认(&L)"
        Me.toolConifrm_Line.ToolTipText = "产线确认"
        '
        'toolConifrm_PG
        '
        Me.toolConifrm_PG.Image = CType(resources.GetObject("toolConifrm_PG.Image"), System.Drawing.Image)
        Me.toolConifrm_PG.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolConifrm_PG.Name = "toolConifrm_PG"
        Me.toolConifrm_PG.Size = New System.Drawing.Size(91, 20)
        Me.toolConifrm_PG.Text = "品管确认(&T)"
        Me.toolConifrm_PG.ToolTipText = "品管确认"
        '
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(72, 20)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "驳 回(&B)"
        '
        'toolPDF
        '
        Me.toolPDF.Image = CType(resources.GetObject("toolPDF.Image"), System.Drawing.Image)
        Me.toolPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolPDF.Name = "toolPDF"
        Me.toolPDF.Size = New System.Drawing.Size(89, 20)
        Me.toolPDF.Text = "生成PDF(&P)"
        Me.toolPDF.ToolTipText = "生成PDF"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolPartId
        '
        Me.toolPartId.Image = CType(resources.GetObject("toolPartId.Image"), System.Drawing.Image)
        Me.toolPartId.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolPartId.Name = "toolPartId"
        Me.toolPartId.Size = New System.Drawing.Size(76, 20)
        Me.toolPartId.Tag = "NO"
        Me.toolPartId.Text = "料号维护"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'tsbRejectText
        '
        Me.tsbRejectText.Image = CType(resources.GetObject("tsbRejectText.Image"), System.Drawing.Image)
        Me.tsbRejectText.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRejectText.Name = "tsbRejectText"
        Me.tsbRejectText.Size = New System.Drawing.Size(76, 20)
        Me.tsbRejectText.Text = "驳回原因"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 20)
        Me.toolExit.Text = "退 出(&X)"
        Me.toolExit.ToolTipText = "退出"
        '
        'SplitContainer7
        '
        Me.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer7.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer7.Name = "SplitContainer7"
        Me.SplitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer7.Panel1
        '
        Me.SplitContainer7.Panel1.Controls.Add(Me.ToolBt)
        '
        'SplitContainer7.Panel2
        '
        Me.SplitContainer7.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer7.Size = New System.Drawing.Size(1175, 742)
        Me.SplitContainer7.SplitterDistance = 25
        Me.SplitContainer7.TabIndex = 48
        '
        'lblNgReason
        '
        Me.lblNgReason.AutoSize = True
        Me.lblNgReason.ForeColor = System.Drawing.Color.Red
        Me.lblNgReason.Location = New System.Drawing.Point(990, 6)
        Me.lblNgReason.Name = "lblNgReason"
        Me.lblNgReason.Size = New System.Drawing.Size(53, 12)
        Me.lblNgReason.TabIndex = 6
        Me.lblNgReason.Text = "驳回原因"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "ItemName"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "不良项目"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colNGReason
        '
        Me.colNGReason.DataPropertyName = "NGReason"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colNGReason.DefaultCellStyle = DataGridViewCellStyle2
        Me.colNGReason.HeaderText = "不良原因"
        Me.colNGReason.MaxInputLength = 200
        Me.colNGReason.Name = "colNGReason"
        Me.colNGReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colNGReason.Width = 140
        '
        'colSolution
        '
        Me.colSolution.DataPropertyName = "Solution"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colSolution.DefaultCellStyle = DataGridViewCellStyle3
        Me.colSolution.HeaderText = "处理方案&改善对策"
        Me.colSolution.MaxInputLength = 200
        Me.colSolution.Name = "colSolution"
        Me.colSolution.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSolution.Width = 150
        '
        'colWorker
        '
        Me.colWorker.DataPropertyName = "Worker"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colWorker.DefaultCellStyle = DataGridViewCellStyle4
        Me.colWorker.HeaderText = "责任人"
        Me.colWorker.MaxInputLength = 20
        Me.colWorker.Name = "colWorker"
        Me.colWorker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colFinishTime
        '
        Me.colFinishTime.DataPropertyName = "FinishTime"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colFinishTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.colFinishTime.HeaderText = "完成时间"
        Me.colFinishTime.MaxInputLength = 20
        Me.colFinishTime.Name = "colFinishTime"
        Me.colFinishTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colTrackingResult
        '
        Me.colTrackingResult.DataPropertyName = "TrackingResult"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colTrackingResult.DefaultCellStyle = DataGridViewCellStyle6
        Me.colTrackingResult.HeaderText = "结果追踪"
        Me.colTrackingResult.MaxInputLength = 200
        Me.colTrackingResult.Name = "colTrackingResult"
        Me.colTrackingResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colCodeid
        '
        Me.colCodeid.DataPropertyName = "Codeid"
        Me.colCodeid.HeaderText = "Codeid"
        Me.colCodeid.Name = "colCodeid"
        Me.colCodeid.Visible = False
        Me.colCodeid.Width = 30
        '
        'FrmParetoShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 742)
        Me.Controls.Add(Me.SplitContainer7)
        Me.Name = "FrmParetoShow"
        Me.Text = "料号分析柏拉图"
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer8.Panel1.ResumeLayout(False)
        Me.SplitContainer8.Panel2.ResumeLayout(False)
        Me.SplitContainer8.ResumeLayout(False)
        CType(Me.dgvNG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNGProcess, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.PerformLayout()
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.Panel2.PerformLayout()
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        Me.SplitContainer3.ResumeLayout(False)
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.SplitContainer7.Panel1.ResumeLayout(False)
        Me.SplitContainer7.Panel2.ResumeLayout(False)
        Me.SplitContainer7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvNG As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblLineID As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPartID As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMOQty As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvNGProcess As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer6 As System.Windows.Forms.SplitContainer
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BtnQuery As System.Windows.Forms.Button
    Friend WithEvents SplitContainer7 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer8 As System.Windows.Forms.SplitContainer
    Friend WithEvents toolConifrm_PG As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents toolPDF As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolConifrm_Line As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboQueryLine As System.Windows.Forms.ComboBox
    Friend WithEvents cboPartID As System.Windows.Forms.ComboBox
    Friend WithEvents btnSub As System.Windows.Forms.Button
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents toolPartId As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRejectText As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblNgReason As System.Windows.Forms.Label
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNGReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolution As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWorker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFinishTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTrackingResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodeid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
