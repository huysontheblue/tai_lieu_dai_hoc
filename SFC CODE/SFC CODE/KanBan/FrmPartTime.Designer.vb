<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPartTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPartTime))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtPartID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TlelCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtRealNum = New System.Windows.Forms.TextBox()
        Me.txtQuorum = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CboMOStatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboLine = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboDept = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblTo = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolSign = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolProduction = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolCancelClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolLock = New System.Windows.Forms.ToolStripButton()
        Me.ToolCancelLock = New System.Windows.Forms.ToolStripButton()
        Me.Separator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtParentMO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DateTimePickerEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePickerStart = New System.Windows.Forms.DateTimePicker()
        Me.LblCreatDate = New System.Windows.Forms.Label()
        Me.TxtMoNo = New System.Windows.Forms.TextBox()
        Me.LelMoNo = New System.Windows.Forms.Label()
        Me.dgvMOInfo = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.motype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.moqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deptid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lineid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentMo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgvMOShift = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusStrip2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvMOInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip1.SuspendLayout()
        CType(Me.dgvMOShift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPartID
        '
        Me.txtPartID.Location = New System.Drawing.Point(934, 1)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(100, 21)
        Me.txtPartID.TabIndex = 102
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(868, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "料件编号:"
        '
        'TlelCount
        '
        Me.TlelCount.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TlelCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TlelCount.LinkColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.TlelCount.Name = "TlelCount"
        Me.TlelCount.Size = New System.Drawing.Size(12, 17)
        Me.TlelCount.Text = "0"
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'statusStrip2
        '
        Me.statusStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.TlelCount})
        Me.statusStrip2.Location = New System.Drawing.Point(0, 117)
        Me.statusStrip2.Name = "statusStrip2"
        Me.statusStrip2.Size = New System.Drawing.Size(1235, 22)
        Me.statusStrip2.TabIndex = 135
        Me.statusStrip2.Text = "statusStrip2"
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.toolStripStatusLabel1.Text = "记录笔数:"
        '
        'txtRealNum
        '
        Me.txtRealNum.Location = New System.Drawing.Point(762, 28)
        Me.txtRealNum.Name = "txtRealNum"
        Me.txtRealNum.Size = New System.Drawing.Size(100, 21)
        Me.txtRealNum.TabIndex = 98
        '
        'txtQuorum
        '
        Me.txtQuorum.Location = New System.Drawing.Point(549, 29)
        Me.txtQuorum.Name = "txtQuorum"
        Me.txtQuorum.Size = New System.Drawing.Size(131, 21)
        Me.txtQuorum.TabIndex = 97
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(696, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 96
        Me.Label5.Text = "实到人数:"
        '
        'CboMOStatus
        '
        Me.CboMOStatus.FormattingEnabled = True
        Me.CboMOStatus.Items.AddRange(New Object() {"All", "0-新建", "1-在制过程中", "2-结案", "3-冻结"})
        Me.CboMOStatus.Location = New System.Drawing.Point(934, 27)
        Me.CboMOStatus.Name = "CboMOStatus"
        Me.CboMOStatus.Size = New System.Drawing.Size(100, 20)
        Me.CboMOStatus.TabIndex = 92
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(892, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "状态:"
        '
        'CboLine
        '
        Me.CboLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboLine.FormattingEnabled = True
        Me.CboLine.Location = New System.Drawing.Point(549, 3)
        Me.CboLine.Name = "CboLine"
        Me.CboLine.Size = New System.Drawing.Size(131, 20)
        Me.CboLine.TabIndex = 90
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(475, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "生产线别:"
        '
        'CboDept
        '
        Me.CboDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboDept.FormattingEnabled = True
        Me.CboDept.Location = New System.Drawing.Point(301, 5)
        Me.CboDept.Name = "CboDept"
        Me.CboDept.Size = New System.Drawing.Size(159, 20)
        Me.CboDept.TabIndex = 88
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(239, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "生产部门:"
        '
        'LblTo
        '
        Me.LblTo.AutoSize = True
        Me.LblTo.Location = New System.Drawing.Point(475, 35)
        Me.LblTo.Name = "LblTo"
        Me.LblTo.Size = New System.Drawing.Size(59, 12)
        Me.LblTo.TabIndex = 23
        Me.LblTo.Text = "应到人数:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.menuStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvMOShift)
        Me.SplitContainer1.Panel2.Controls.Add(Me.statusStrip2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1235, 465)
        Me.SplitContainer1.SplitterDistance = 325
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.ToolBt)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer3.Size = New System.Drawing.Size(1235, 300)
        Me.SplitContainer3.SplitterDistance = 25
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 138
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolQuery, Me.ToolStripSeparator6, Me.ToolStripButton1, Me.ToolStripSeparator2, Me.ToolSign, Me.ToolStripSeparator5, Me.ToolProduction, Me.ToolStripSeparator1, Me.ToolClose, Me.ToolCancelClose, Me.ToolLock, Me.ToolCancelLock, Me.Separator, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(5, -1)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1225, 27)
        Me.ToolBt.TabIndex = 134
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolQuery
        '
        Me.ToolQuery.Image = CType(resources.GetObject("ToolQuery.Image"), System.Drawing.Image)
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(66, 24)
        Me.ToolQuery.Text = "查询(&F)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(68, 24)
        Me.ToolStripButton1.Text = "清空(&C)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'ToolSign
        '
        Me.ToolSign.Image = Global.KanBan.My.Resources.Resources.sign
        Me.ToolSign.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSign.Name = "ToolSign"
        Me.ToolSign.Size = New System.Drawing.Size(67, 24)
        Me.ToolSign.Text = "签到(&S)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 27)
        '
        'ToolProduction
        '
        Me.ToolProduction.Image = CType(resources.GetObject("ToolProduction.Image"), System.Drawing.Image)
        Me.ToolProduction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolProduction.Name = "ToolProduction"
        Me.ToolProduction.Size = New System.Drawing.Size(68, 24)
        Me.ToolProduction.Tag = "NO"
        Me.ToolProduction.Text = "生产(&A)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'ToolClose
        '
        Me.ToolClose.Image = CType(resources.GetObject("ToolClose.Image"), System.Drawing.Image)
        Me.ToolClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolClose.Name = "ToolClose"
        Me.ToolClose.Size = New System.Drawing.Size(65, 24)
        Me.ToolClose.Text = "结案(&J)"
        Me.ToolClose.ToolTipText = "工單結案"
        '
        'ToolCancelClose
        '
        Me.ToolCancelClose.Image = CType(resources.GetObject("ToolCancelClose.Image"), System.Drawing.Image)
        Me.ToolCancelClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCancelClose.Name = "ToolCancelClose"
        Me.ToolCancelClose.Size = New System.Drawing.Size(93, 24)
        Me.ToolCancelClose.Text = "取消结案(&U)"
        '
        'ToolLock
        '
        Me.ToolLock.Image = CType(resources.GetObject("ToolLock.Image"), System.Drawing.Image)
        Me.ToolLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLock.Name = "ToolLock"
        Me.ToolLock.Size = New System.Drawing.Size(65, 24)
        Me.ToolLock.Text = "冻结(&J)"
        Me.ToolLock.ToolTipText = "工單結案"
        '
        'ToolCancelLock
        '
        Me.ToolCancelLock.Image = CType(resources.GetObject("ToolCancelLock.Image"), System.Drawing.Image)
        Me.ToolCancelLock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCancelLock.Name = "ToolCancelLock"
        Me.ToolCancelLock.Size = New System.Drawing.Size(93, 24)
        Me.ToolCancelLock.Text = "取消冻结(&U)"
        '
        'Separator
        '
        Me.Separator.Name = "Separator"
        Me.Separator.Size = New System.Drawing.Size(6, 27)
        '
        'ToolExitFrom
        '
        Me.ToolExitFrom.Image = CType(resources.GetObject("ToolExitFrom.Image"), System.Drawing.Image)
        Me.ToolExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExitFrom.Name = "ToolExitFrom"
        Me.ToolExitFrom.Size = New System.Drawing.Size(68, 24)
        Me.ToolExitFrom.Text = "退出(&X)"
        Me.ToolExitFrom.ToolTipText = "退出"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvMOInfo)
        Me.SplitContainer2.Size = New System.Drawing.Size(1235, 274)
        Me.SplitContainer2.SplitterDistance = 53
        Me.SplitContainer2.SplitterWidth = 2
        Me.SplitContainer2.TabIndex = 137
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtPartID)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtParentMO)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtRealNum)
        Me.Panel2.Controls.Add(Me.txtQuorum)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.DateTimePickerEnd)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.CboMOStatus)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.CboLine)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.DateTimePickerStart)
        Me.Panel2.Controls.Add(Me.CboDept)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.LblTo)
        Me.Panel2.Controls.Add(Me.LblCreatDate)
        Me.Panel2.Controls.Add(Me.TxtMoNo)
        Me.Panel2.Controls.Add(Me.LelMoNo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1235, 53)
        Me.Panel2.TabIndex = 135
        '
        'txtParentMO
        '
        Me.txtParentMO.Location = New System.Drawing.Point(762, 1)
        Me.txtParentMO.Name = "txtParentMO"
        Me.txtParentMO.Size = New System.Drawing.Size(100, 21)
        Me.txtParentMO.TabIndex = 100
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(698, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "上级工单:"
        '
        'DateTimePickerEnd
        '
        Me.DateTimePickerEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerEnd.Location = New System.Drawing.Point(301, 29)
        Me.DateTimePickerEnd.Name = "DateTimePickerEnd"
        Me.DateTimePickerEnd.Size = New System.Drawing.Size(159, 21)
        Me.DateTimePickerEnd.TabIndex = 95
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(239, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "结束时间:"
        '
        'DateTimePickerStart
        '
        Me.DateTimePickerStart.Checked = False
        Me.DateTimePickerStart.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerStart.Location = New System.Drawing.Point(65, 29)
        Me.DateTimePickerStart.Name = "DateTimePickerStart"
        Me.DateTimePickerStart.Size = New System.Drawing.Size(151, 21)
        Me.DateTimePickerStart.TabIndex = 86
        '
        'LblCreatDate
        '
        Me.LblCreatDate.AutoSize = True
        Me.LblCreatDate.Location = New System.Drawing.Point(6, 34)
        Me.LblCreatDate.Name = "LblCreatDate"
        Me.LblCreatDate.Size = New System.Drawing.Size(59, 12)
        Me.LblCreatDate.TabIndex = 22
        Me.LblCreatDate.Text = "开始时间:"
        '
        'TxtMoNo
        '
        Me.TxtMoNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMoNo.Location = New System.Drawing.Point(65, 5)
        Me.TxtMoNo.Name = "TxtMoNo"
        Me.TxtMoNo.Size = New System.Drawing.Size(151, 21)
        Me.TxtMoNo.TabIndex = 14
        '
        'LelMoNo
        '
        Me.LelMoNo.AutoSize = True
        Me.LelMoNo.Location = New System.Drawing.Point(6, 5)
        Me.LelMoNo.Name = "LelMoNo"
        Me.LelMoNo.Size = New System.Drawing.Size(59, 12)
        Me.LelMoNo.TabIndex = 15
        Me.LelMoNo.Text = "工单编号:"
        '
        'dgvMOInfo
        '
        Me.dgvMOInfo.AllowUserToAddRows = False
        Me.dgvMOInfo.AllowUserToDeleteRows = False
        Me.dgvMOInfo.AllowUserToOrderColumns = True
        Me.dgvMOInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMOInfo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvMOInfo.ColumnHeadersHeight = 24
        Me.dgvMOInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.moid, Me.motype, Me.partid, Me.moqty, Me.deptid, Me.lineid, Me.status, Me.ParentMo, Me.colButton})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMOInfo.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvMOInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMOInfo.EnableHeadersVisualStyles = False
        Me.dgvMOInfo.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvMOInfo.Location = New System.Drawing.Point(0, 0)
        Me.dgvMOInfo.Name = "dgvMOInfo"
        Me.dgvMOInfo.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMOInfo.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvMOInfo.RowHeadersWidth = 4
        Me.dgvMOInfo.RowTemplate.Height = 23
        Me.dgvMOInfo.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.dgvMOInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMOInfo.Size = New System.Drawing.Size(1235, 219)
        Me.dgvMOInfo.TabIndex = 135
        '
        'moid
        '
        Me.moid.DataPropertyName = "MOID"
        Me.moid.HeaderText = "工单编号"
        Me.moid.Name = "moid"
        Me.moid.ReadOnly = True
        Me.moid.Width = 110
        '
        'motype
        '
        Me.motype.DataPropertyName = "motype"
        Me.motype.HeaderText = "工单类型"
        Me.motype.Name = "motype"
        Me.motype.ReadOnly = True
        '
        'partid
        '
        Me.partid.DataPropertyName = "partid"
        Me.partid.HeaderText = "料件编号"
        Me.partid.Name = "partid"
        Me.partid.ReadOnly = True
        Me.partid.Width = 110
        '
        'moqty
        '
        Me.moqty.DataPropertyName = "moqty"
        Me.moqty.HeaderText = "工单数量"
        Me.moqty.Name = "moqty"
        Me.moqty.ReadOnly = True
        Me.moqty.Width = 110
        '
        'deptid
        '
        Me.deptid.DataPropertyName = "deptid"
        Me.deptid.HeaderText = "生产部门"
        Me.deptid.Name = "deptid"
        Me.deptid.ReadOnly = True
        Me.deptid.Width = 145
        '
        'lineid
        '
        Me.lineid.DataPropertyName = "lineid"
        Me.lineid.HeaderText = "生产线别"
        Me.lineid.Name = "lineid"
        Me.lineid.ReadOnly = True
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        Me.status.HeaderText = "状态"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Width = 120
        '
        'ParentMo
        '
        Me.ParentMo.DataPropertyName = "ParentMo"
        Me.ParentMo.HeaderText = "上级工单"
        Me.ParentMo.Name = "ParentMo"
        Me.ParentMo.ReadOnly = True
        '
        'colButton
        '
        Me.colButton.HeaderText = ""
        Me.colButton.Name = "colButton"
        Me.colButton.ReadOnly = True
        Me.colButton.Text = "自动生成"
        Me.colButton.UseColumnTextForButtonValue = True
        Me.colButton.Visible = False
        Me.colButton.Width = 80
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1235, 25)
        Me.menuStrip1.TabIndex = 136
        Me.menuStrip1.Text = "menuStrip1"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem1.Text = "系统(&S)"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(58, 21)
        Me.toolStripMenuItem2.Text = "文件(&F)"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(60, 21)
        Me.toolStripMenuItem3.Text = "查看(&V)"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem4.Text = "工具(&T)"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(64, 21)
        Me.toolStripMenuItem5.Text = "窗口(&W)"
        '
        'toolStripMenuItem6
        '
        Me.toolStripMenuItem6.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        Me.toolStripMenuItem6.Size = New System.Drawing.Size(61, 21)
        Me.toolStripMenuItem6.Text = "帮助(&H)"
        '
        'dgvMOShift
        '
        Me.dgvMOShift.AllowUserToAddRows = False
        Me.dgvMOShift.AllowUserToDeleteRows = False
        Me.dgvMOShift.AllowUserToOrderColumns = True
        Me.dgvMOShift.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMOShift.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvMOShift.ColumnHeadersHeight = 24
        Me.dgvMOShift.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMOShift.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvMOShift.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMOShift.EnableHeadersVisualStyles = False
        Me.dgvMOShift.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvMOShift.Location = New System.Drawing.Point(0, 0)
        Me.dgvMOShift.Name = "dgvMOShift"
        Me.dgvMOShift.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMOShift.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvMOShift.RowHeadersWidth = 4
        Me.dgvMOShift.RowTemplate.Height = 23
        Me.dgvMOShift.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.dgvMOShift.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMOShift.Size = New System.Drawing.Size(1235, 117)
        Me.dgvMOShift.TabIndex = 136
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "moid"
        Me.Column1.HeaderText = "工单编号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.Width = 110
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "lineid"
        Me.DataGridViewTextBoxColumn7.HeaderText = "线别"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 110
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "workshift"
        Me.DataGridViewTextBoxColumn8.HeaderText = "班别"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "starttime"
        Me.DataGridViewTextBoxColumn9.HeaderText = "开始时间"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 130
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "endtime"
        Me.DataGridViewTextBoxColumn10.HeaderText = "结束时间"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 130
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Quorum"
        Me.DataGridViewTextBoxColumn11.HeaderText = "应到人数"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "RealNum"
        Me.DataGridViewTextBoxColumn12.HeaderText = "实到人数"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "userid"
        Me.DataGridViewTextBoxColumn13.HeaderText = "维护人员"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 120
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Intime"
        Me.DataGridViewTextBoxColumn14.HeaderText = "维护时间"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'FrmPartTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1236, 465)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmPartTime"
        Me.Text = "工单生产班别资料维护"
        Me.statusStrip2.ResumeLayout(False)
        Me.statusStrip2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvMOInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.dgvMOShift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents TlelCount As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents statusStrip2 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtRealNum As System.Windows.Forms.TextBox
    Friend WithEvents txtQuorum As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboMOStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblTo As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtMoNo As System.Windows.Forms.TextBox
    Friend WithEvents LelMoNo As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvMOInfo As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvMOShift As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents motype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents moqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deptid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lineid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentMo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colButton As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents txtParentMO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblCreatDate As System.Windows.Forms.Label
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolSign As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolProduction As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCancelClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolLock As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCancelLock As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
