<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParetoMoidShow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParetoMoidShow))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblMOQty = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblLineID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPartId = New System.Windows.Forms.Label()
        Me.lblMoid = New System.Windows.Forms.Label()
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
        Me.toolPDF = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.cboQueryLine = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboMoid = New System.Windows.Forms.ComboBox()
        Me.BtnQuery = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer8 = New System.Windows.Forms.SplitContainer()
        Me.dgvNG = New System.Windows.Forms.DataGridView()
        Me.dgvNGProcess = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNGReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSolution = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWorker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFinishTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTrackingResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodeid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer8.Panel1.SuspendLayout()
        Me.SplitContainer8.Panel2.SuspendLayout()
        Me.SplitContainer8.SuspendLayout()
        CType(Me.dgvNG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNGProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblLineID)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblPartId)
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblMoid)
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
        Me.Label1.Size = New System.Drawing.Size(149, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "制程不良分析表(按工单)"
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
        Me.Label3.Text = "工单数量(PCS):"
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(471, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 12)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "线别:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(98, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "料号:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(275, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "工单:"
        '
        'lblPartId
        '
        Me.lblPartId.AutoSize = True
        Me.lblPartId.Location = New System.Drawing.Point(145, 6)
        Me.lblPartId.Name = "lblPartId"
        Me.lblPartId.Size = New System.Drawing.Size(17, 12)
        Me.lblPartId.TabIndex = 3
        Me.lblPartId.Text = "  "
        '
        'lblMoid
        '
        Me.lblMoid.AutoSize = True
        Me.lblMoid.Location = New System.Drawing.Point(317, 6)
        Me.lblMoid.Name = "lblMoid"
        Me.lblMoid.Size = New System.Drawing.Size(17, 12)
        Me.lblMoid.TabIndex = 3
        Me.lblMoid.Text = "  "
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
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator6, Me.toolSearch, Me.ToolStripSeparator3, Me.toolConifrm_Line, Me.toolConifrm_PG, Me.toolPDF, Me.ToolStripSeparator1, Me.toolExit})
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
        'toolPDF
        '
        Me.toolPDF.Image = CType(resources.GetObject("toolPDF.Image"), System.Drawing.Image)
        Me.toolPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolPDF.Name = "toolPDF"
        Me.toolPDF.Size = New System.Drawing.Size(89, 20)
        Me.toolPDF.Text = "生成PDF(&P)"
        Me.toolPDF.ToolTipText = "生成PDF"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
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
        Me.SplitContainer7.Size = New System.Drawing.Size(1175, 741)
        Me.SplitContainer7.SplitterDistance = 25
        Me.SplitContainer7.TabIndex = 49
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1175, 712)
        Me.SplitContainer1.SplitterDistance = 83
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
        Me.SplitContainer6.Panel1.Controls.Add(Me.cboQueryLine)
        Me.SplitContainer6.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer6.Panel1.Controls.Add(Me.cboMoid)
        Me.SplitContainer6.Panel1.Controls.Add(Me.BtnQuery)
        Me.SplitContainer6.Panel1.Controls.Add(Me.Label9)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer6.Size = New System.Drawing.Size(1175, 83)
        Me.SplitContainer6.SplitterDistance = 39
        Me.SplitContainer6.TabIndex = 1
        '
        'cboQueryLine
        '
        Me.cboQueryLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQueryLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQueryLine.FormattingEnabled = True
        Me.cboQueryLine.Location = New System.Drawing.Point(111, 3)
        Me.cboQueryLine.Name = "cboQueryLine"
        Me.cboQueryLine.Size = New System.Drawing.Size(121, 20)
        Me.cboQueryLine.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(238, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "工单:"
        '
        'cboMoid
        '
        Me.cboMoid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMoid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMoid.FormattingEnabled = True
        Me.cboMoid.Location = New System.Drawing.Point(277, 3)
        Me.cboMoid.Name = "cboMoid"
        Me.cboMoid.Size = New System.Drawing.Size(188, 20)
        Me.cboMoid.TabIndex = 4
        '
        'BtnQuery
        '
        Me.BtnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnQuery.Image = CType(resources.GetObject("BtnQuery.Image"), System.Drawing.Image)
        Me.BtnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnQuery.Location = New System.Drawing.Point(483, -3)
        Me.BtnQuery.Name = "BtnQuery"
        Me.BtnQuery.Size = New System.Drawing.Size(72, 30)
        Me.BtnQuery.TabIndex = 5
        Me.BtnQuery.Text = "查 詢"
        Me.BtnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnQuery.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(70, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 12)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "线别:"
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
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "ItemName"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "不良项目"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'colNGReason
        '
        Me.colNGReason.DataPropertyName = "NGReason"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colNGReason.DefaultCellStyle = DataGridViewCellStyle2
        Me.colNGReason.HeaderText = "不良原因"
        Me.colNGReason.MaxInputLength = 200
        Me.colNGReason.Name = "colNGReason"
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
        '
        'colFinishTime
        '
        Me.colFinishTime.DataPropertyName = "FinishTime"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colFinishTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.colFinishTime.HeaderText = "完成时间"
        Me.colFinishTime.MaxInputLength = 20
        Me.colFinishTime.Name = "colFinishTime"
        '
        'colTrackingResult
        '
        Me.colTrackingResult.DataPropertyName = "TrackingResult"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colTrackingResult.DefaultCellStyle = DataGridViewCellStyle6
        Me.colTrackingResult.HeaderText = "结果追踪"
        Me.colTrackingResult.MaxInputLength = 200
        Me.colTrackingResult.Name = "colTrackingResult"
        '
        'colCodeid
        '
        Me.colCodeid.DataPropertyName = "Codeid"
        Me.colCodeid.HeaderText = "Codeid"
        Me.colCodeid.Name = "colCodeid"
        Me.colCodeid.Visible = False
        Me.colCodeid.Width = 30
        '
        'FrmParetoMoidShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 741)
        Me.Controls.Add(Me.SplitContainer7)
        Me.Name = "FrmParetoMoidShow"
        Me.Text = "工单分析柏拉图"
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
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.PerformLayout()
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer8.Panel1.ResumeLayout(False)
        Me.SplitContainer8.Panel2.ResumeLayout(False)
        Me.SplitContainer8.ResumeLayout(False)
        CType(Me.dgvNG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNGProcess, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblMOQty As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLineID As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMoid As System.Windows.Forms.Label
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents toolConifrm_Line As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolConifrm_PG As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolPDF As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainer7 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer6 As System.Windows.Forms.SplitContainer
    Friend WithEvents cboQueryLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboMoid As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnQuery As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer8 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvNG As System.Windows.Forms.DataGridView
    Friend WithEvents dgvNGProcess As System.Windows.Forms.DataGridView
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNGReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolution As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWorker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFinishTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTrackingResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodeid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPartId As System.Windows.Forms.Label
End Class
