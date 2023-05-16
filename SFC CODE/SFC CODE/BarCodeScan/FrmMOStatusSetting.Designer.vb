<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMOStatusSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMOStatusSetting))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtMOId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dgvQuery = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.MOQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrackStartUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrackStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrackEndUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrackEndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStart = New System.Windows.Forms.ToolStripButton()
        Me.ToolEnd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolSuspend = New System.Windows.Forms.ToolStripButton()
        Me.ToolRestore = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommodityinspection = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolCard = New System.Windows.Forms.ToolStripButton()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.txtLineId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.txtMOAlreadyQty = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtNotAlreadyQty = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtAlreadyInspectionQty = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txtNotInspectionQty = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.txtMOQuantity = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.txtInspectionQuantity = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvInspectionQuery = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.InspectionMOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOInspectionQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONotInspectionQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspectionLineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspectionQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspectionUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspectionTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBt.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvInspectionQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMOId
        '
        '
        '
        '
        Me.txtMOId.Border.Class = "TextBoxBorder"
        Me.txtMOId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMOId.Enabled = False
        Me.txtMOId.Location = New System.Drawing.Point(64, 43)
        Me.txtMOId.Name = "txtMOId"
        Me.txtMOId.Size = New System.Drawing.Size(127, 21)
        Me.txtMOId.TabIndex = 0
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToAddRows = False
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvQuery.ColumnHeadersHeight = 28
        Me.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MOQty, Me.MOID, Me.StartUserId, Me.StartTime, Me.EndUserId, Me.EndTime, Me.TrackStartUserId, Me.TrackStartTime, Me.TrackEndUserId, Me.TrackEndTime})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuery.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvQuery.Location = New System.Drawing.Point(3, 17)
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.RowHeadersWidth = 15
        Me.dgvQuery.RowTemplate.Height = 23
        Me.dgvQuery.Size = New System.Drawing.Size(558, 308)
        Me.dgvQuery.TabIndex = 1
        '
        'MOQty
        '
        Me.MOQty.DataPropertyName = "MOQty"
        Me.MOQty.HeaderText = "MOQty"
        Me.MOQty.Name = "MOQty"
        Me.MOQty.ReadOnly = True
        Me.MOQty.Visible = False
        '
        'MOID
        '
        Me.MOID.DataPropertyName = "MOID"
        Me.MOID.HeaderText = "工单"
        Me.MOID.Name = "MOID"
        Me.MOID.ReadOnly = True
        Me.MOID.Width = 120
        '
        'StartUserId
        '
        Me.StartUserId.DataPropertyName = "StartUserId"
        Me.StartUserId.HeaderText = "开始用户"
        Me.StartUserId.Name = "StartUserId"
        Me.StartUserId.ReadOnly = True
        Me.StartUserId.Width = 80
        '
        'StartTime
        '
        Me.StartTime.DataPropertyName = "StartTime"
        Me.StartTime.HeaderText = "开始时间"
        Me.StartTime.Name = "StartTime"
        Me.StartTime.ReadOnly = True
        Me.StartTime.Width = 80
        '
        'EndUserId
        '
        Me.EndUserId.DataPropertyName = "EndUserId"
        Me.EndUserId.HeaderText = "结束用户"
        Me.EndUserId.Name = "EndUserId"
        Me.EndUserId.ReadOnly = True
        Me.EndUserId.Width = 80
        '
        'EndTime
        '
        Me.EndTime.DataPropertyName = "EndTime"
        Me.EndTime.HeaderText = "结束时间"
        Me.EndTime.Name = "EndTime"
        Me.EndTime.ReadOnly = True
        Me.EndTime.Width = 80
        '
        'TrackStartUserId
        '
        Me.TrackStartUserId.DataPropertyName = "TrackStartUserId"
        Me.TrackStartUserId.HeaderText = "暂停开始用户"
        Me.TrackStartUserId.Name = "TrackStartUserId"
        Me.TrackStartUserId.ReadOnly = True
        Me.TrackStartUserId.Width = 80
        '
        'TrackStartTime
        '
        Me.TrackStartTime.DataPropertyName = "TrackStartTime"
        Me.TrackStartTime.HeaderText = "暂停开始时间"
        Me.TrackStartTime.Name = "TrackStartTime"
        Me.TrackStartTime.ReadOnly = True
        Me.TrackStartTime.Width = 80
        '
        'TrackEndUserId
        '
        Me.TrackEndUserId.DataPropertyName = "TrackEndUserId"
        Me.TrackEndUserId.HeaderText = "暂停结束用户"
        Me.TrackEndUserId.Name = "TrackEndUserId"
        Me.TrackEndUserId.ReadOnly = True
        Me.TrackEndUserId.Width = 80
        '
        'TrackEndTime
        '
        Me.TrackEndTime.DataPropertyName = "TrackEndTime"
        Me.TrackEndTime.HeaderText = "暂停结束时间"
        Me.TrackEndTime.Name = "TrackEndTime"
        Me.TrackEndTime.ReadOnly = True
        Me.TrackEndTime.Width = 80
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(21, 43)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "工单："
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStart, Me.ToolEnd, Me.ToolStripSeparator2, Me.ToolSuspend, Me.ToolRestore, Me.ToolCommodityinspection, Me.ToolStripSeparator4, Me.toolCard, Me.ToolQuery, Me.ToolStripSeparator1, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(906, 25)
        Me.ToolBt.TabIndex = 140
        '
        'ToolStart
        '
        Me.ToolStart.ForeColor = System.Drawing.Color.Black
        Me.ToolStart.Image = CType(resources.GetObject("ToolStart.Image"), System.Drawing.Image)
        Me.ToolStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStart.Name = "ToolStart"
        Me.ToolStart.Size = New System.Drawing.Size(91, 22)
        Me.ToolStart.Tag = "NO"
        Me.ToolStart.Text = "生产开始(&S)"
        Me.ToolStart.ToolTipText = "生产开始"
        '
        'ToolEnd
        '
        Me.ToolEnd.Image = CType(resources.GetObject("ToolEnd.Image"), System.Drawing.Image)
        Me.ToolEnd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEnd.Name = "ToolEnd"
        Me.ToolEnd.Size = New System.Drawing.Size(91, 22)
        Me.ToolEnd.Tag = ""
        Me.ToolEnd.Text = "生产完成(&E)"
        Me.ToolEnd.ToolTipText = "生产完成"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolSuspend
        '
        Me.ToolSuspend.Image = CType(resources.GetObject("ToolSuspend.Image"), System.Drawing.Image)
        Me.ToolSuspend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSuspend.Name = "ToolSuspend"
        Me.ToolSuspend.Size = New System.Drawing.Size(68, 22)
        Me.ToolSuspend.Text = "暂停(&B)"
        Me.ToolSuspend.ToolTipText = "暂停"
        '
        'ToolRestore
        '
        Me.ToolRestore.Image = Global.BarCodeScan.My.Resources.Resources.edit
        Me.ToolRestore.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolRestore.Name = "ToolRestore"
        Me.ToolRestore.Size = New System.Drawing.Size(72, 22)
        Me.ToolRestore.Text = "恢 复(&B)"
        Me.ToolRestore.ToolTipText = "恢 复"
        '
        'ToolCommodityinspection
        '
        Me.ToolCommodityinspection.ForeColor = System.Drawing.Color.Black
        'Me.ToolCommodityinspection.Image = Global.BarCodeScan.My.Resources.Resources.Tick
        Me.ToolCommodityinspection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCommodityinspection.Name = "ToolCommodityinspection"
        Me.ToolCommodityinspection.Size = New System.Drawing.Size(74, 22)
        Me.ToolCommodityinspection.Text = "送 检(&Q)"
        Me.ToolCommodityinspection.ToolTipText = "送 检"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolCard
        '
        Me.toolCard.ForeColor = System.Drawing.Color.Black
        Me.toolCard.Image = Global.BarCodeScan.My.Resources.Resources.edit
        Me.toolCard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCard.Name = "toolCard"
        Me.toolCard.Size = New System.Drawing.Size(74, 22)
        Me.toolCard.Text = "打 卡(&Q)"
        Me.toolCard.ToolTipText = "打 卡"
        '
        'ToolQuery
        '
        Me.ToolQuery.ForeColor = System.Drawing.Color.Black
        Me.ToolQuery.Image = CType(resources.GetObject("ToolQuery.Image"), System.Drawing.Image)
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(74, 22)
        Me.ToolQuery.Text = "查 询(&Q)"
        Me.ToolQuery.ToolTipText = "查 詢"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExitFrom
        '
        Me.ToolExitFrom.ForeColor = System.Drawing.Color.Black
        Me.ToolExitFrom.Image = CType(resources.GetObject("ToolExitFrom.Image"), System.Drawing.Image)
        Me.ToolExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExitFrom.Name = "ToolExitFrom"
        Me.ToolExitFrom.Size = New System.Drawing.Size(72, 22)
        Me.ToolExitFrom.Text = "退 出(&X)"
        Me.ToolExitFrom.ToolTipText = "退 出"
        '
        'txtLineId
        '
        '
        '
        '
        Me.txtLineId.Border.Class = "TextBoxBorder"
        Me.txtLineId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLineId.Enabled = False
        Me.txtLineId.Location = New System.Drawing.Point(64, 79)
        Me.txtLineId.Name = "txtLineId"
        Me.txtLineId.Size = New System.Drawing.Size(127, 21)
        Me.txtLineId.TabIndex = 141
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(23, 79)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 142
        Me.LabelX2.Text = "产线："
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(633, 118)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(267, 23)
        Me.lblMessage.TabIndex = 143
        '
        'txtMOAlreadyQty
        '
        '
        '
        '
        Me.txtMOAlreadyQty.Border.Class = "TextBoxBorder"
        Me.txtMOAlreadyQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMOAlreadyQty.Enabled = False
        Me.txtMOAlreadyQty.Location = New System.Drawing.Point(278, 43)
        Me.txtMOAlreadyQty.Name = "txtMOAlreadyQty"
        Me.txtMOAlreadyQty.Size = New System.Drawing.Size(127, 21)
        Me.txtMOAlreadyQty.TabIndex = 144
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(224, 43)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 145
        Me.LabelX3.Text = "已完工："
        '
        'txtNotAlreadyQty
        '
        '
        '
        '
        Me.txtNotAlreadyQty.Border.Class = "TextBoxBorder"
        Me.txtNotAlreadyQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNotAlreadyQty.Enabled = False
        Me.txtNotAlreadyQty.Location = New System.Drawing.Point(278, 79)
        Me.txtNotAlreadyQty.Name = "txtNotAlreadyQty"
        Me.txtNotAlreadyQty.Size = New System.Drawing.Size(127, 21)
        Me.txtNotAlreadyQty.TabIndex = 146
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(224, 79)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 147
        Me.LabelX4.Text = "未完工："
        '
        'txtAlreadyInspectionQty
        '
        '
        '
        '
        Me.txtAlreadyInspectionQty.Border.Class = "TextBoxBorder"
        Me.txtAlreadyInspectionQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlreadyInspectionQty.Enabled = False
        Me.txtAlreadyInspectionQty.Location = New System.Drawing.Point(490, 79)
        Me.txtAlreadyInspectionQty.Name = "txtAlreadyInspectionQty"
        Me.txtAlreadyInspectionQty.Size = New System.Drawing.Size(127, 21)
        Me.txtAlreadyInspectionQty.TabIndex = 148
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(437, 79)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 149
        Me.LabelX5.Text = "已送检："
        '
        'txtNotInspectionQty
        '
        '
        '
        '
        Me.txtNotInspectionQty.Border.Class = "TextBoxBorder"
        Me.txtNotInspectionQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNotInspectionQty.Enabled = False
        Me.txtNotInspectionQty.Location = New System.Drawing.Point(490, 119)
        Me.txtNotInspectionQty.Name = "txtNotInspectionQty"
        Me.txtNotInspectionQty.Size = New System.Drawing.Size(127, 21)
        Me.txtNotInspectionQty.TabIndex = 150
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(437, 119)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 151
        Me.LabelX6.Text = "未送检："
        '
        'txtMOQuantity
        '
        '
        '
        '
        Me.txtMOQuantity.Border.Class = "TextBoxBorder"
        Me.txtMOQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMOQuantity.Enabled = False
        Me.txtMOQuantity.Location = New System.Drawing.Point(64, 118)
        Me.txtMOQuantity.Name = "txtMOQuantity"
        Me.txtMOQuantity.Size = New System.Drawing.Size(127, 21)
        Me.txtMOQuantity.TabIndex = 152
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(23, 118)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 153
        Me.LabelX7.Text = "数量："
        '
        'txtInspectionQuantity
        '
        '
        '
        '
        Me.txtInspectionQuantity.Border.Class = "TextBoxBorder"
        Me.txtInspectionQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInspectionQuantity.Location = New System.Drawing.Point(490, 43)
        Me.txtInspectionQuantity.Name = "txtInspectionQuantity"
        Me.txtInspectionQuantity.Size = New System.Drawing.Size(127, 21)
        Me.txtInspectionQuantity.TabIndex = 154
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(437, 43)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 23)
        Me.LabelX8.TabIndex = 155
        Me.LabelX8.Text = "送检数："
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvQuery)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 141)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(564, 328)
        Me.GroupBox1.TabIndex = 156
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgvInspectionQuery)
        Me.GroupBox2.Location = New System.Drawing.Point(564, 141)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(342, 328)
        Me.GroupBox2.TabIndex = 157
        Me.GroupBox2.TabStop = False
        '
        'dgvInspectionQuery
        '
        Me.dgvInspectionQuery.AllowUserToAddRows = False
        Me.dgvInspectionQuery.AllowUserToDeleteRows = False
        Me.dgvInspectionQuery.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvInspectionQuery.ColumnHeadersHeight = 28
        Me.dgvInspectionQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInspectionQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InspectionMOID, Me.MOInspectionQuantity, Me.MONotInspectionQuantity, Me.InspectionLineId, Me.InspectionQuantity, Me.InspectionUserId, Me.InspectionTime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInspectionQuery.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInspectionQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInspectionQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvInspectionQuery.Location = New System.Drawing.Point(3, 17)
        Me.dgvInspectionQuery.Name = "dgvInspectionQuery"
        Me.dgvInspectionQuery.RowHeadersWidth = 15
        Me.dgvInspectionQuery.RowTemplate.Height = 23
        Me.dgvInspectionQuery.Size = New System.Drawing.Size(336, 308)
        Me.dgvInspectionQuery.TabIndex = 0
        '
        'InspectionMOID
        '
        Me.InspectionMOID.DataPropertyName = "MOID"
        Me.InspectionMOID.HeaderText = "工单"
        Me.InspectionMOID.Name = "InspectionMOID"
        Me.InspectionMOID.ReadOnly = True
        Me.InspectionMOID.Width = 120
        '
        'MOInspectionQuantity
        '
        Me.MOInspectionQuantity.DataPropertyName = "MOInspectionQuantity"
        Me.MOInspectionQuantity.HeaderText = "已送检数"
        Me.MOInspectionQuantity.Name = "MOInspectionQuantity"
        Me.MOInspectionQuantity.ReadOnly = True
        Me.MOInspectionQuantity.Width = 60
        '
        'MONotInspectionQuantity
        '
        Me.MONotInspectionQuantity.DataPropertyName = "MONotInspectionQuantity"
        Me.MONotInspectionQuantity.HeaderText = "待送检数"
        Me.MONotInspectionQuantity.Name = "MONotInspectionQuantity"
        Me.MONotInspectionQuantity.ReadOnly = True
        Me.MONotInspectionQuantity.Width = 60
        '
        'InspectionLineId
        '
        Me.InspectionLineId.DataPropertyName = "LineId"
        Me.InspectionLineId.HeaderText = "产线"
        Me.InspectionLineId.Name = "InspectionLineId"
        Me.InspectionLineId.ReadOnly = True
        Me.InspectionLineId.Width = 60
        '
        'InspectionQuantity
        '
        Me.InspectionQuantity.DataPropertyName = "InspectionQuantity"
        Me.InspectionQuantity.HeaderText = "送检数"
        Me.InspectionQuantity.Name = "InspectionQuantity"
        Me.InspectionQuantity.ReadOnly = True
        Me.InspectionQuantity.Width = 60
        '
        'InspectionUserId
        '
        Me.InspectionUserId.DataPropertyName = "InspectionUserId"
        Me.InspectionUserId.HeaderText = "送检人"
        Me.InspectionUserId.Name = "InspectionUserId"
        Me.InspectionUserId.ReadOnly = True
        Me.InspectionUserId.Width = 80
        '
        'InspectionTime
        '
        Me.InspectionTime.DataPropertyName = "InspectionTime"
        Me.InspectionTime.HeaderText = "送检时间"
        Me.InspectionTime.Name = "InspectionTime"
        Me.InspectionTime.ReadOnly = True
        Me.InspectionTime.Width = 80
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "InspectionMOID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "工单"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "MOQty"
        Me.DataGridViewTextBoxColumn2.HeaderText = "工单数量"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "InspectionLineId"
        Me.DataGridViewTextBoxColumn3.HeaderText = "产线"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "InspectionQuantity"
        Me.DataGridViewTextBoxColumn4.HeaderText = "送检数量"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "InspectionUseriID"
        Me.DataGridViewTextBoxColumn5.HeaderText = "送检人"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "InspectionTime"
        Me.DataGridViewTextBoxColumn6.HeaderText = "送检时间"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "MOID"
        Me.DataGridViewTextBoxColumn7.HeaderText = "工单"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 120
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "StartUserId"
        Me.DataGridViewTextBoxColumn8.HeaderText = "开始用户"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "StartTime"
        Me.DataGridViewTextBoxColumn9.HeaderText = "开始时间"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 80
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "EndUserId"
        Me.DataGridViewTextBoxColumn10.HeaderText = "结束用户"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "EndTime"
        Me.DataGridViewTextBoxColumn11.HeaderText = "结束时间"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 80
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "TrackUserId"
        Me.DataGridViewTextBoxColumn12.HeaderText = "暂停开始用户"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 80
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "TrackStartTime"
        Me.DataGridViewTextBoxColumn13.HeaderText = "暂停开始时间"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 80
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "TrackEndUserId"
        Me.DataGridViewTextBoxColumn14.HeaderText = "暂停结束用户"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 80
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "TrackEndTime"
        Me.DataGridViewTextBoxColumn15.HeaderText = "暂停结束时间"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 80
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "TrackEndTime"
        Me.DataGridViewTextBoxColumn16.HeaderText = "暂停结束时间"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 80
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "TrackEndTime"
        Me.DataGridViewTextBoxColumn17.HeaderText = "暂停结束时间"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 80
        '
        'FrmMOStatusSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 469)
        Me.Controls.Add(Me.txtNotInspectionQty)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.txtMOQuantity)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtInspectionQuantity)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.txtAlreadyInspectionQty)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.txtNotAlreadyQty)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.txtMOAlreadyQty)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtLineId)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.txtMOId)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMOStatusSetting"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "工单状态设置"
        CType(Me.dgvQuery,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolBt.ResumeLayout(false)
        Me.ToolBt.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox2.ResumeLayout(false)
        CType(Me.dgvInspectionQuery,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents txtMOId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dgvQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEnd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSuspend As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtLineId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolCommodityinspection As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolRestore As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtMOAlreadyQty As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNotAlreadyQty As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtAlreadyInspectionQty As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNotInspectionQty As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtMOQuantity As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtInspectionQuantity As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvInspectionQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolCard As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrackStartUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrackStartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrackEndUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrackEndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InspectionMOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOInspectionQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONotInspectionQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InspectionLineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InspectionQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InspectionUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InspectionTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
