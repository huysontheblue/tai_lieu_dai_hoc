<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataHistoryManagement
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
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEnable = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDisabled = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.txtMigrateTable = New DevComponents.DotNetBar.TextBoxItem()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.lblMessage = New DevComponents.DotNetBar.LabelItem()
        Me.dgvDataHistory = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataHistoryId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MigrateServerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MigrateDataBaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetTableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TreatmentFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessingNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExecutionInterval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IntervalFrequency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IntervalType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RetentionDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JobID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpandableSplitterCenter = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.SuperTabControlList = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgvSuccessRecord = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataHistoryRecordId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataHistoryTableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LinkServerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TargetDataBaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourceDatabase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartExecuteTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndExecuteTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecordRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperTabItemSuccess = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgvFailureRecord = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.FDataHistoryRecordId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FDataHistoryTableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RMigrateServerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RMigrateDataBaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FSourceDatabase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FLinkServerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FTargetDataBaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RTargetTableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FStartExecuteTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FEndExecuteTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FRecordRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperTabItemFailure = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.menuStrip1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDataHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControlList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlList.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.dgvSuccessRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.dgvFailureRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(964, 25)
        Me.menuStrip1.TabIndex = 134
        Me.menuStrip1.Text = "menuStrip1"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem1.Text = "系统(&S)"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(58, 21)
        Me.toolStripMenuItem2.Text = "文件(&F)"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(60, 21)
        Me.toolStripMenuItem3.Text = "查看(&V)"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem4.Text = "工具(&T)"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(64, 21)
        Me.toolStripMenuItem5.Text = "窗口(&W)"
        '
        'toolStripMenuItem6
        '
        Me.toolStripMenuItem6.ForeColor = System.Drawing.Color.Black
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        Me.toolStripMenuItem6.Size = New System.Drawing.Size(61, 21)
        Me.toolStripMenuItem6.Text = "帮助(&H)"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAdd, Me.btnDelete, Me.btnEdit, Me.btnEnable, Me.btnDisabled, Me.LabelItem5, Me.LabelItem2, Me.txtMigrateTable, Me.btnQuery, Me.lblMessage})
        Me.Bar1.Location = New System.Drawing.Point(0, 25)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Bar1.Size = New System.Drawing.Size(964, 27)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 136
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnAdd
        '
        Me.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAdd.Image = Global.DataHistoryManagement.My.Resources.Resources.add
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "添加"
        Me.btnAdd.Tooltip = "添加"
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Image = Global.DataHistoryManagement.My.Resources.Resources.delete
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "删除"
        Me.btnDelete.Tooltip = "删除"
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEdit.Image = Global.DataHistoryManagement.My.Resources.Resources.edit
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "修改"
        Me.btnEdit.Tooltip = "修改"
        '
        'btnEnable
        '
        Me.btnEnable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEnable.Image = Global.DataHistoryManagement.My.Resources.Resources.control_play_blue
        Me.btnEnable.Name = "btnEnable"
        Me.btnEnable.Text = "启用"
        Me.btnEnable.Tooltip = "启用"
        '
        'btnDisabled
        '
        Me.btnDisabled.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDisabled.Image = Global.DataHistoryManagement.My.Resources.Resources.control_pause_blue
        Me.btnDisabled.Name = "btnDisabled"
        Me.btnDisabled.Text = "停用"
        Me.btnDisabled.Tooltip = "停用"
        '
        'LabelItem5
        '
        Me.LabelItem5.BackColor = System.Drawing.Color.Transparent
        Me.LabelItem5.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem5.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem5.Name = "LabelItem5"
        Me.LabelItem5.PaddingBottom = 1
        Me.LabelItem5.PaddingLeft = 10
        Me.LabelItem5.PaddingTop = 1
        Me.LabelItem5.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelItem5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = Global.DataHistoryManagement.My.Resources.Resources.control_play_blue
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "启用"
        Me.ButtonItem1.Tooltip = "启用"
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.Text = "链接名称:"
        '
        'txtMigrateTable
        '
        Me.txtMigrateTable.FocusHighlightColor = System.Drawing.Color.Transparent
        Me.txtMigrateTable.Name = "txtMigrateTable"
        Me.txtMigrateTable.Tag = "查询单号"
        Me.txtMigrateTable.TextBoxWidth = 130
        Me.txtMigrateTable.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'btnQuery
        '
        Me.btnQuery.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnQuery.Image = Global.DataHistoryManagement.My.Resources.Resources.query
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Tag = "查询"
        Me.btnQuery.Text = "查询"
        '
        'lblMessage
        '
        Me.lblMessage.Name = "lblMessage"
        '
        'dgvDataHistory
        '
        Me.dgvDataHistory.AllowUserToAddRows = False
        Me.dgvDataHistory.AllowUserToDeleteRows = False
        Me.dgvDataHistory.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDataHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDataHistory.ColumnHeadersHeight = 28
        Me.dgvDataHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDataHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataHistoryId, Me.DataGridViewTextBoxColumn1, Me.MigrateServerName, Me.MigrateDataBaseName, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.TargetTableName, Me.DataGridViewTextBoxColumn2, Me.TreatmentFlag, Me.ProcessingNumber, Me.ExecutionInterval, Me.IntervalFrequency, Me.IntervalType, Me.StartTime, Me.EndTime, Me.RetentionDays, Me.Remark, Me.StatusFlag, Me.CreateUserId, Me.CreateTime, Me.UpdateUserId, Me.UpdateTime, Me.JobID})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDataHistory.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDataHistory.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvDataHistory.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvDataHistory.Location = New System.Drawing.Point(0, 52)
        Me.dgvDataHistory.Name = "dgvDataHistory"
        Me.dgvDataHistory.RowHeadersWidth = 15
        Me.dgvDataHistory.RowTemplate.Height = 23
        Me.dgvDataHistory.Size = New System.Drawing.Size(964, 258)
        Me.dgvDataHistory.TabIndex = 137
        '
        'DataHistoryId
        '
        Me.DataHistoryId.DataPropertyName = "DataHistoryId"
        Me.DataHistoryId.HeaderText = "DataHistoryId"
        Me.DataHistoryId.Name = "DataHistoryId"
        Me.DataHistoryId.ReadOnly = True
        Me.DataHistoryId.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DataHistoryTableName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "表名称"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'MigrateServerName
        '
        Me.MigrateServerName.DataPropertyName = "MigrateServerName"
        Me.MigrateServerName.HeaderText = "源链接服务器"
        Me.MigrateServerName.Name = "MigrateServerName"
        Me.MigrateServerName.ReadOnly = True
        Me.MigrateServerName.Width = 200
        '
        'MigrateDataBaseName
        '
        Me.MigrateDataBaseName.DataPropertyName = "MigrateDataBaseName"
        Me.MigrateDataBaseName.HeaderText = "源数据库"
        Me.MigrateDataBaseName.Name = "MigrateDataBaseName"
        Me.MigrateDataBaseName.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "LinkServerName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "目标链接服务器"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "TargetDataBaseName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "目标数据库"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'TargetTableName
        '
        Me.TargetTableName.DataPropertyName = "TargetTableName"
        Me.TargetTableName.HeaderText = "目标表"
        Me.TargetTableName.Name = "TargetTableName"
        Me.TargetTableName.ReadOnly = True
        Me.TargetTableName.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "SourceDatabase"
        Me.DataGridViewTextBoxColumn2.HeaderText = "当前数据库"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'TreatmentFlag
        '
        Me.TreatmentFlag.DataPropertyName = "TreatmentFlag"
        Me.TreatmentFlag.HeaderText = "处理方式"
        Me.TreatmentFlag.Name = "TreatmentFlag"
        Me.TreatmentFlag.ReadOnly = True
        '
        'ProcessingNumber
        '
        Me.ProcessingNumber.DataPropertyName = "ProcessingNumber"
        Me.ProcessingNumber.HeaderText = "处理笔数"
        Me.ProcessingNumber.Name = "ProcessingNumber"
        Me.ProcessingNumber.ReadOnly = True
        '
        'ExecutionInterval
        '
        Me.ExecutionInterval.DataPropertyName = "ExecutionInterval"
        Me.ExecutionInterval.HeaderText = "执行间隔"
        Me.ExecutionInterval.Name = "ExecutionInterval"
        Me.ExecutionInterval.ReadOnly = True
        '
        'IntervalFrequency
        '
        Me.IntervalFrequency.DataPropertyName = "IntervalFrequency"
        Me.IntervalFrequency.HeaderText = "间隔频率"
        Me.IntervalFrequency.Name = "IntervalFrequency"
        Me.IntervalFrequency.ReadOnly = True
        '
        'IntervalType
        '
        Me.IntervalType.DataPropertyName = "IntervalType"
        Me.IntervalType.HeaderText = "间隔类型"
        Me.IntervalType.Name = "IntervalType"
        Me.IntervalType.ReadOnly = True
        '
        'StartTime
        '
        Me.StartTime.DataPropertyName = "StartTime"
        Me.StartTime.HeaderText = "开始时间"
        Me.StartTime.Name = "StartTime"
        Me.StartTime.ReadOnly = True
        '
        'EndTime
        '
        Me.EndTime.DataPropertyName = "EndTime"
        Me.EndTime.HeaderText = "结束时间"
        Me.EndTime.Name = "EndTime"
        Me.EndTime.ReadOnly = True
        '
        'RetentionDays
        '
        Me.RetentionDays.DataPropertyName = "RetentionDays"
        Me.RetentionDays.HeaderText = "保留天数"
        Me.RetentionDays.Name = "RetentionDays"
        Me.RetentionDays.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "说明"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'StatusFlag
        '
        Me.StatusFlag.DataPropertyName = "StatusFlag"
        Me.StatusFlag.HeaderText = "状态"
        Me.StatusFlag.Name = "StatusFlag"
        Me.StatusFlag.ReadOnly = True
        '
        'CreateUserId
        '
        Me.CreateUserId.DataPropertyName = "CreateUserId"
        Me.CreateUserId.HeaderText = "创建用户"
        Me.CreateUserId.Name = "CreateUserId"
        Me.CreateUserId.ReadOnly = True
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "CreateTime"
        Me.CreateTime.HeaderText = "创建时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        '
        'UpdateUserId
        '
        Me.UpdateUserId.DataPropertyName = "UpdateUserId"
        Me.UpdateUserId.HeaderText = "更新用户"
        Me.UpdateUserId.Name = "UpdateUserId"
        Me.UpdateUserId.ReadOnly = True
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "更新时间"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        '
        'JobID
        '
        Me.JobID.DataPropertyName = "JobID"
        Me.JobID.HeaderText = "JobID"
        Me.JobID.Name = "JobID"
        Me.JobID.ReadOnly = True
        Me.JobID.Visible = False
        '
        'ExpandableSplitterCenter
        '
        Me.ExpandableSplitterCenter.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitterCenter.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterCenter.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitterCenter.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandableSplitterCenter.ExpandableControl = Me.dgvDataHistory
        Me.ExpandableSplitterCenter.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitterCenter.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterCenter.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitterCenter.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitterCenter.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitterCenter.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitterCenter.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitterCenter.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitterCenter.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ExpandableSplitterCenter.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ExpandableSplitterCenter.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitterCenter.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitterCenter.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitterCenter.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterCenter.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitterCenter.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitterCenter.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitterCenter.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterCenter.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitterCenter.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitterCenter.Location = New System.Drawing.Point(0, 310)
        Me.ExpandableSplitterCenter.Name = "ExpandableSplitterCenter"
        Me.ExpandableSplitterCenter.Size = New System.Drawing.Size(964, 6)
        Me.ExpandableSplitterCenter.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitterCenter.TabIndex = 138
        Me.ExpandableSplitterCenter.TabStop = False
        '
        'SuperTabControlList
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControlList.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControlList.ControlBox.MenuBox.Name = ""
        Me.SuperTabControlList.ControlBox.Name = ""
        Me.SuperTabControlList.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControlList.ControlBox.MenuBox, Me.SuperTabControlList.ControlBox.CloseBox})
        Me.SuperTabControlList.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControlList.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlList.Location = New System.Drawing.Point(0, 316)
        Me.SuperTabControlList.Name = "SuperTabControlList"
        Me.SuperTabControlList.ReorderTabsEnabled = True
        Me.SuperTabControlList.SelectedTabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControlList.SelectedTabIndex = 0
        Me.SuperTabControlList.Size = New System.Drawing.Size(964, 181)
        Me.SuperTabControlList.TabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SuperTabControlList.TabIndex = 139
        Me.SuperTabControlList.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItemSuccess, Me.SuperTabItemFailure})
        Me.SuperTabControlList.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.dgvSuccessRecord)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(964, 153)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItemSuccess
        '
        'dgvSuccessRecord
        '
        Me.dgvSuccessRecord.AllowUserToAddRows = False
        Me.dgvSuccessRecord.AllowUserToDeleteRows = False
        Me.dgvSuccessRecord.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSuccessRecord.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSuccessRecord.ColumnHeadersHeight = 28
        Me.dgvSuccessRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSuccessRecord.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataHistoryRecordId, Me.DataHistoryTableName, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.LinkServerName, Me.TargetDataBaseName, Me.DataGridViewTextBoxColumn7, Me.SourceDatabase, Me.StartExecuteTime, Me.EndExecuteTime, Me.RecordRemark})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSuccessRecord.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSuccessRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSuccessRecord.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvSuccessRecord.Location = New System.Drawing.Point(0, 0)
        Me.dgvSuccessRecord.Name = "dgvSuccessRecord"
        Me.dgvSuccessRecord.RowHeadersWidth = 15
        Me.dgvSuccessRecord.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvSuccessRecord.RowTemplate.Height = 25
        Me.dgvSuccessRecord.Size = New System.Drawing.Size(964, 153)
        Me.dgvSuccessRecord.TabIndex = 0
        '
        'DataHistoryRecordId
        '
        Me.DataHistoryRecordId.HeaderText = "DataHistoryRecordId"
        Me.DataHistoryRecordId.Name = "DataHistoryRecordId"
        Me.DataHistoryRecordId.ReadOnly = True
        Me.DataHistoryRecordId.Visible = False
        '
        'DataHistoryTableName
        '
        Me.DataHistoryTableName.DataPropertyName = "DataHistoryTableName"
        Me.DataHistoryTableName.HeaderText = "表名称"
        Me.DataHistoryTableName.Name = "DataHistoryTableName"
        Me.DataHistoryTableName.ReadOnly = True
        Me.DataHistoryTableName.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "MigrateServerName"
        Me.DataGridViewTextBoxColumn5.HeaderText = "源链接服务器"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 200
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "MigrateDataBaseName"
        Me.DataGridViewTextBoxColumn6.HeaderText = "源数据库"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'LinkServerName
        '
        Me.LinkServerName.DataPropertyName = "LinkServerName"
        Me.LinkServerName.HeaderText = "目标链接服务器"
        Me.LinkServerName.Name = "LinkServerName"
        Me.LinkServerName.ReadOnly = True
        Me.LinkServerName.Width = 200
        '
        'TargetDataBaseName
        '
        Me.TargetDataBaseName.DataPropertyName = "TargetDataBaseName"
        Me.TargetDataBaseName.HeaderText = "目标数据库"
        Me.TargetDataBaseName.Name = "TargetDataBaseName"
        Me.TargetDataBaseName.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "TargetTableName"
        Me.DataGridViewTextBoxColumn7.HeaderText = "目标表"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 200
        '
        'SourceDatabase
        '
        Me.SourceDatabase.DataPropertyName = "SourceDatabase"
        Me.SourceDatabase.HeaderText = "当前数据库"
        Me.SourceDatabase.Name = "SourceDatabase"
        Me.SourceDatabase.ReadOnly = True
        '
        'StartExecuteTime
        '
        Me.StartExecuteTime.DataPropertyName = "StartExecuteTime"
        Me.StartExecuteTime.HeaderText = "开始时间"
        Me.StartExecuteTime.Name = "StartExecuteTime"
        Me.StartExecuteTime.ReadOnly = True
        Me.StartExecuteTime.Width = 150
        '
        'EndExecuteTime
        '
        Me.EndExecuteTime.DataPropertyName = "EndExecuteTime"
        Me.EndExecuteTime.HeaderText = "结束时间"
        Me.EndExecuteTime.Name = "EndExecuteTime"
        Me.EndExecuteTime.ReadOnly = True
        Me.EndExecuteTime.Width = 150
        '
        'RecordRemark
        '
        Me.RecordRemark.DataPropertyName = "RecordRemark"
        Me.RecordRemark.HeaderText = "执行说明"
        Me.RecordRemark.Name = "RecordRemark"
        Me.RecordRemark.ReadOnly = True
        Me.RecordRemark.Width = 400
        '
        'SuperTabItemSuccess
        '
        Me.SuperTabItemSuccess.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItemSuccess.GlobalItem = False
        Me.SuperTabItemSuccess.Name = "SuperTabItemSuccess"
        Me.SuperTabItemSuccess.Text = "成功日志"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.dgvFailureRecord)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(964, 181)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItemFailure
        '
        'dgvFailureRecord
        '
        Me.dgvFailureRecord.AllowUserToAddRows = False
        Me.dgvFailureRecord.AllowUserToDeleteRows = False
        Me.dgvFailureRecord.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFailureRecord.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvFailureRecord.ColumnHeadersHeight = 28
        Me.dgvFailureRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFailureRecord.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FDataHistoryRecordId, Me.FDataHistoryTableName, Me.RMigrateServerName, Me.RMigrateDataBaseName, Me.FSourceDatabase, Me.FLinkServerName, Me.FTargetDataBaseName, Me.RTargetTableName, Me.FStartExecuteTime, Me.FEndExecuteTime, Me.FRecordRemark})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFailureRecord.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvFailureRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFailureRecord.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvFailureRecord.Location = New System.Drawing.Point(0, 0)
        Me.dgvFailureRecord.Name = "dgvFailureRecord"
        Me.dgvFailureRecord.RowHeadersWidth = 15
        Me.dgvFailureRecord.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvFailureRecord.RowTemplate.Height = 25
        Me.dgvFailureRecord.Size = New System.Drawing.Size(964, 181)
        Me.dgvFailureRecord.TabIndex = 0
        '
        'FDataHistoryRecordId
        '
        Me.FDataHistoryRecordId.HeaderText = "DataHistoryRecordId"
        Me.FDataHistoryRecordId.Name = "FDataHistoryRecordId"
        Me.FDataHistoryRecordId.ReadOnly = True
        Me.FDataHistoryRecordId.Visible = False
        '
        'FDataHistoryTableName
        '
        Me.FDataHistoryTableName.DataPropertyName = "DataHistoryTableName"
        Me.FDataHistoryTableName.HeaderText = "表名称"
        Me.FDataHistoryTableName.Name = "FDataHistoryTableName"
        Me.FDataHistoryTableName.ReadOnly = True
        Me.FDataHistoryTableName.Width = 200
        '
        'RMigrateServerName
        '
        Me.RMigrateServerName.DataPropertyName = "MigrateServerName"
        Me.RMigrateServerName.HeaderText = "源链接服务器"
        Me.RMigrateServerName.Name = "RMigrateServerName"
        Me.RMigrateServerName.ReadOnly = True
        Me.RMigrateServerName.Width = 200
        '
        'RMigrateDataBaseName
        '
        Me.RMigrateDataBaseName.DataPropertyName = "MigrateDataBaseName"
        Me.RMigrateDataBaseName.HeaderText = "源数据库"
        Me.RMigrateDataBaseName.Name = "RMigrateDataBaseName"
        Me.RMigrateDataBaseName.ReadOnly = True
        '
        'FSourceDatabase
        '
        Me.FSourceDatabase.DataPropertyName = "SourceDatabase"
        Me.FSourceDatabase.HeaderText = "当前数据库"
        Me.FSourceDatabase.Name = "FSourceDatabase"
        Me.FSourceDatabase.ReadOnly = True
        '
        'FLinkServerName
        '
        Me.FLinkServerName.DataPropertyName = "LinkServerName"
        Me.FLinkServerName.HeaderText = "目标链接服务器"
        Me.FLinkServerName.Name = "FLinkServerName"
        Me.FLinkServerName.ReadOnly = True
        Me.FLinkServerName.Width = 200
        '
        'FTargetDataBaseName
        '
        Me.FTargetDataBaseName.DataPropertyName = "TargetDataBaseName"
        Me.FTargetDataBaseName.HeaderText = "目标数据库"
        Me.FTargetDataBaseName.Name = "FTargetDataBaseName"
        Me.FTargetDataBaseName.ReadOnly = True
        '
        'RTargetTableName
        '
        Me.RTargetTableName.DataPropertyName = "TargetTableName"
        Me.RTargetTableName.HeaderText = "目标表"
        Me.RTargetTableName.Name = "RTargetTableName"
        Me.RTargetTableName.ReadOnly = True
        Me.RTargetTableName.Width = 200
        '
        'FStartExecuteTime
        '
        Me.FStartExecuteTime.DataPropertyName = "StartExecuteTime"
        Me.FStartExecuteTime.HeaderText = "开始时间"
        Me.FStartExecuteTime.Name = "FStartExecuteTime"
        Me.FStartExecuteTime.ReadOnly = True
        Me.FStartExecuteTime.Width = 150
        '
        'FEndExecuteTime
        '
        Me.FEndExecuteTime.DataPropertyName = "EndExecuteTime"
        Me.FEndExecuteTime.HeaderText = "结束时间"
        Me.FEndExecuteTime.Name = "FEndExecuteTime"
        Me.FEndExecuteTime.ReadOnly = True
        Me.FEndExecuteTime.Width = 150
        '
        'FRecordRemark
        '
        Me.FRecordRemark.DataPropertyName = "RecordRemark"
        Me.FRecordRemark.HeaderText = "执行说明"
        Me.FRecordRemark.Name = "FRecordRemark"
        Me.FRecordRemark.ReadOnly = True
        Me.FRecordRemark.Width = 400
        '
        'SuperTabItemFailure
        '
        Me.SuperTabItemFailure.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItemFailure.GlobalItem = False
        Me.SuperTabItemFailure.Name = "SuperTabItemFailure"
        Me.SuperTabItemFailure.Text = "异常日志"
        '
        'SuperTabItem
        '
        Me.SuperTabItem.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem.GlobalItem = False
        Me.SuperTabItem.Name = "SuperTabItem"
        Me.SuperTabItem.Text = "异常日志"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(964, 240)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem
        '
        'FrmDataHistoryManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 497)
        Me.Controls.Add(Me.SuperTabControlList)
        Me.Controls.Add(Me.ExpandableSplitterCenter)
        Me.Controls.Add(Me.dgvDataHistory)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "FrmDataHistoryManagement"
        Me.ShowIcon = False
        Me.Text = "数据迁移管理"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDataHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControlList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlList.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.dgvSuccessRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.dgvFailureRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEnable As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDisabled As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtMigrateTable As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dgvDataHistory As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ExpandableSplitterCenter As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents SuperTabControlList As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItemSuccess As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItemFailure As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents dgvSuccessRecord As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvFailureRecord As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents FDataHistoryRecordId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FDataHistoryTableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMigrateServerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMigrateDataBaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FSourceDatabase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FLinkServerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTargetDataBaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RTargetTableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FStartExecuteTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FEndExecuteTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FRecordRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataHistoryRecordId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataHistoryTableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkServerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TargetDataBaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceDatabase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartExecuteTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndExecuteTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecordRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataHistoryId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MigrateServerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MigrateDataBaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TargetTableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TreatmentFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessingNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExecutionInterval As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IntervalFrequency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IntervalType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetentionDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JobID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
