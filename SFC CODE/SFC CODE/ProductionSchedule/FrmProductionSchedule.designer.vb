<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductionSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductionSchedule))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolType = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtLine = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.dgvQuery = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ProductionSchID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductionTimeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductionTimeValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanEndTime = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.料件系列 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductiveValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManpowerValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductionType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtProductionTimeName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtProductionTimeValue = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.dtpStart = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dtpEnd = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtProductive = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.txtManPower = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.txtDept = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.DateTimeInput1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.ToolBt.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeInput1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolDelete, Me.ToolCommit, Me.ToolBack, Me.ToolStripSeparator3, Me.ToolQuery, Me.toolType, Me.ToolStripSeparator1, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 25)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1030, 25)
        Me.ToolBt.TabIndex = 139
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
        Me.ToolNew.Enabled = False
        Me.ToolNew.ForeColor = System.Drawing.Color.Black
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(74, 22)
        Me.ToolNew.Tag = "NO"
        Me.ToolNew.Text = "新 增(&N)"
        Me.ToolNew.ToolTipText = "新 增"
        '
        'ToolEdit
        '
        Me.ToolEdit.Enabled = False
        Me.ToolEdit.ForeColor = System.Drawing.Color.Black
        Me.ToolEdit.Image = CType(resources.GetObject("ToolEdit.Image"), System.Drawing.Image)
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(71, 22)
        Me.ToolEdit.Tag = "NO"
        Me.ToolEdit.Text = "修 改(&E)"
        Me.ToolEdit.ToolTipText = "修 改"
        '
        'ToolDelete
        '
        Me.ToolDelete.Enabled = False
        Me.ToolDelete.ForeColor = System.Drawing.Color.Black
        Me.ToolDelete.Image = CType(resources.GetObject("ToolDelete.Image"), System.Drawing.Image)
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(73, 22)
        Me.ToolDelete.Tag = "NO"
        Me.ToolDelete.Text = "删 除(&D)"
        Me.ToolDelete.ToolTipText = "删除"
        '
        'ToolCommit
        '
        Me.ToolCommit.Image = CType(resources.GetObject("ToolCommit.Image"), System.Drawing.Image)
        Me.ToolCommit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCommit.Name = "ToolCommit"
        Me.ToolCommit.Size = New System.Drawing.Size(68, 22)
        Me.ToolCommit.Tag = ""
        Me.ToolCommit.Text = "提交(&C)"
        Me.ToolCommit.ToolTipText = "提交"
        '
        'ToolBack
        '
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'toolType
        '
        Me.toolType.Image = CType(resources.GetObject("toolType.Image"), System.Drawing.Image)
        Me.toolType.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolType.Name = "toolType"
        Me.toolType.Size = New System.Drawing.Size(124, 22)
        Me.toolType.Tag = "YES"
        Me.toolType.Text = "线别料号类型维护"
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
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.Gray
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1030, 25)
        Me.menuStrip1.TabIndex = 138
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
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(272, 70)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(51, 23)
        Me.LabelX2.TabIndex = 153
        Me.LabelX2.Text = "开始："
        '
        'mtxtLine
        '
        '
        '
        '
        Me.mtxtLine.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtLine.ButtonCustom.Visible = True
        Me.mtxtLine.Location = New System.Drawing.Point(86, 67)
        Me.mtxtLine.Name = "mtxtLine"
        Me.mtxtLine.Size = New System.Drawing.Size(132, 21)
        Me.mtxtLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtLine.TabIndex = 152
        Me.mtxtLine.Text = ""
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(748, 148)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(270, 21)
        Me.lblMessage.TabIndex = 151
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToAddRows = False
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuery.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQuery.ColumnHeadersHeight = 28
        Me.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductionSchID, Me.DeptID, Me.LineId, Me.ProductionTimeName, Me.StartTime, Me.EndTime, Me.ProductionTimeValue, Me.PlanEndTime, Me.料件系列, Me.ProductiveValue, Me.ManpowerValue, Me.ProductionType, Me.CreateUserId, Me.CreateTime})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQuery.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvQuery.EnableHeadersVisualStyles = False
        Me.dgvQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvQuery.Location = New System.Drawing.Point(0, 191)
        Me.dgvQuery.Name = "dgvQuery"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQuery.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvQuery.RowHeadersWidth = 15
        Me.dgvQuery.RowTemplate.Height = 23
        Me.dgvQuery.Size = New System.Drawing.Size(1030, 265)
        Me.dgvQuery.TabIndex = 150
        '
        'ProductionSchID
        '
        Me.ProductionSchID.DataPropertyName = "ProductionSchID"
        Me.ProductionSchID.HeaderText = "ProductionSchID"
        Me.ProductionSchID.Name = "ProductionSchID"
        Me.ProductionSchID.ReadOnly = True
        Me.ProductionSchID.Visible = False
        '
        'DeptID
        '
        Me.DeptID.DataPropertyName = "DEPTID"
        Me.DeptID.HeaderText = "部门"
        Me.DeptID.Name = "DeptID"
        Me.DeptID.ReadOnly = True
        '
        'LineId
        '
        Me.LineId.DataPropertyName = "LineId"
        Me.LineId.HeaderText = "产线"
        Me.LineId.Name = "LineId"
        Me.LineId.ReadOnly = True
        '
        'ProductionTimeName
        '
        Me.ProductionTimeName.DataPropertyName = "ProductionTimeName"
        Me.ProductionTimeName.HeaderText = "时段名称"
        Me.ProductionTimeName.Name = "ProductionTimeName"
        Me.ProductionTimeName.ReadOnly = True
        '
        'StartTime
        '
        Me.StartTime.DataPropertyName = "StartTime"
        DataGridViewCellStyle2.Format = "t"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.StartTime.DefaultCellStyle = DataGridViewCellStyle2
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
        'ProductionTimeValue
        '
        Me.ProductionTimeValue.DataPropertyName = "ProductionTimeValue"
        Me.ProductionTimeValue.HeaderText = "时间值"
        Me.ProductionTimeValue.Name = "ProductionTimeValue"
        Me.ProductionTimeValue.ReadOnly = True
        '
        'PlanEndTime
        '
        '
        '
        '
        Me.PlanEndTime.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.PlanEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanEndTime.ButtonClear.Visible = True
        Me.PlanEndTime.ButtonDropDown.Visible = True
        Me.PlanEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.PlanEndTime.DataPropertyName = "LastLineDate"
        Me.PlanEndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.PlanEndTime.HeaderText = "派工时间"
        Me.PlanEndTime.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.PlanEndTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanEndTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.PlanEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanEndTime.MonthCalendar.DisplayMonth = New Date(2017, 6, 1, 0, 0, 0, 0)
        Me.PlanEndTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.PlanEndTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.PlanEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.PlanEndTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.PlanEndTime.Name = "PlanEndTime"
        Me.PlanEndTime.ReadOnly = True
        Me.PlanEndTime.Width = 200
        '
        '料件系列
        '
        Me.料件系列.DataPropertyName = "PartSeriesTypeName"
        Me.料件系列.HeaderText = "类别"
        Me.料件系列.Name = "料件系列"
        Me.料件系列.ReadOnly = True
        '
        'ProductiveValue
        '
        Me.ProductiveValue.DataPropertyName = "ProductiveValue"
        Me.ProductiveValue.HeaderText = "生产效率"
        Me.ProductiveValue.Name = "ProductiveValue"
        Me.ProductiveValue.ReadOnly = True
        '
        'ManpowerValue
        '
        Me.ManpowerValue.DataPropertyName = "ManpowerValue"
        Me.ManpowerValue.HeaderText = "人力"
        Me.ManpowerValue.Name = "ManpowerValue"
        Me.ManpowerValue.ReadOnly = True
        '
        'ProductionType
        '
        Me.ProductionType.DataPropertyName = "ProductionType"
        Me.ProductionType.HeaderText = "类型"
        Me.ProductionType.Name = "ProductionType"
        Me.ProductionType.ReadOnly = True
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
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(19, 66)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 149
        Me.LabelX1.Text = "产线："
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(500, 68)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(55, 23)
        Me.LabelX3.TabIndex = 155
        Me.LabelX3.Text = "结束："
        '
        'txtProductionTimeName
        '
        '
        '
        '
        Me.txtProductionTimeName.Border.Class = "TextBoxBorder"
        Me.txtProductionTimeName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtProductionTimeName.Location = New System.Drawing.Point(316, 146)
        Me.txtProductionTimeName.Name = "txtProductionTimeName"
        Me.txtProductionTimeName.Size = New System.Drawing.Size(125, 21)
        Me.txtProductionTimeName.TabIndex = 158
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(250, 146)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(73, 23)
        Me.LabelX4.TabIndex = 157
        Me.LabelX4.Text = "时段名称："
        '
        'txtProductionTimeValue
        '
        '
        '
        '
        Me.txtProductionTimeValue.Border.Class = "TextBoxBorder"
        Me.txtProductionTimeValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtProductionTimeValue.Location = New System.Drawing.Point(316, 105)
        Me.txtProductionTimeValue.Name = "txtProductionTimeValue"
        Me.txtProductionTimeValue.Size = New System.Drawing.Size(125, 21)
        Me.txtProductionTimeValue.TabIndex = 160
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(260, 103)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 159
        Me.LabelX5.Text = "时间值："
        '
        'dtpStart
        '
        '
        '
        '
        Me.dtpStart.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpStart.ButtonDropDown.Visible = True
        Me.dtpStart.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.dtpStart.IsPopupCalendarOpen = False
        Me.dtpStart.Location = New System.Drawing.Point(316, 70)
        '
        '
        '
        Me.dtpStart.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStart.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpStart.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStart.MonthCalendar.DisplayMonth = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.dtpStart.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpStart.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStart.MonthCalendar.TodayButtonVisible = True
        Me.dtpStart.MonthCalendar.Visible = False
        Me.dtpStart.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(125, 21)
        Me.dtpStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpStart.TabIndex = 161
        '
        'dtpEnd
        '
        '
        '
        '
        Me.dtpEnd.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpEnd.ButtonDropDown.Visible = True
        Me.dtpEnd.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.dtpEnd.IsPopupCalendarOpen = False
        Me.dtpEnd.Location = New System.Drawing.Point(544, 68)
        '
        '
        '
        Me.dtpEnd.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEnd.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpEnd.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEnd.MonthCalendar.DisplayMonth = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.dtpEnd.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpEnd.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEnd.MonthCalendar.TodayButtonVisible = True
        Me.dtpEnd.MonthCalendar.Visible = False
        Me.dtpEnd.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(132, 21)
        Me.dtpEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpEnd.TabIndex = 162
        '
        'txtProductive
        '
        '
        '
        '
        Me.txtProductive.Border.Class = "TextBoxBorder"
        Me.txtProductive.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtProductive.Location = New System.Drawing.Point(87, 146)
        Me.txtProductive.Name = "txtProductive"
        Me.txtProductive.Size = New System.Drawing.Size(132, 21)
        Me.txtProductive.TabIndex = 164
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(19, 146)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(73, 23)
        Me.LabelX6.TabIndex = 163
        Me.LabelX6.Text = "生产效率："
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(496, 101)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(42, 23)
        Me.LabelX7.TabIndex = 163
        Me.LabelX7.Text = "人力："
        '
        'txtManPower
        '
        '
        '
        '
        Me.txtManPower.Border.Class = "TextBoxBorder"
        Me.txtManPower.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtManPower.Location = New System.Drawing.Point(544, 105)
        Me.txtManPower.Name = "txtManPower"
        Me.txtManPower.Size = New System.Drawing.Size(132, 21)
        Me.txtManPower.TabIndex = 164
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(18, 103)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 23)
        Me.LabelX8.TabIndex = 149
        Me.LabelX8.Text = "部门编号："
        '
        'txtDept
        '
        '
        '
        '
        Me.txtDept.Border.Class = "TextBoxBorder"
        Me.txtDept.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDept.Location = New System.Drawing.Point(87, 105)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.ReadOnly = True
        Me.txtDept.Size = New System.Drawing.Size(132, 21)
        Me.txtDept.TabIndex = 164
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(473, 146)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(72, 23)
        Me.LabelX9.TabIndex = 153
        Me.LabelX9.Text = "派工时间："
        '
        'DateTimeInput1
        '
        '
        '
        '
        Me.DateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.ButtonClear.Visible = True
        Me.DateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInput1.ButtonDropDown.Visible = True
        Me.DateTimeInput1.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DateTimeInput1.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.DateTimeInput1.IsPopupCalendarOpen = False
        Me.DateTimeInput1.Location = New System.Drawing.Point(544, 146)
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DateTimeInput1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.MonthCalendar.DisplayMonth = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.DateTimeInput1.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInput1.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInput1.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInput1.Name = "DateTimeInput1"
        Me.DateTimeInput1.Size = New System.Drawing.Size(198, 21)
        Me.DateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInput1.TabIndex = 161
        '
        'FrmProductionSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 457)
        Me.Controls.Add(Me.txtManPower)
        Me.Controls.Add(Me.txtDept)
        Me.Controls.Add(Me.txtProductive)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.DateTimeInput1)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.txtProductionTimeValue)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.txtProductionTimeName)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.mtxtLine)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvQuery)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "FrmProductionSchedule"
        Me.ShowIcon = False
        Me.Text = "生产维护"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeInput1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtLine As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtProductionTimeName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtProductionTimeValue As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpStart As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtpEnd As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtProductive As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtManPower As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents toolType As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDept As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DateTimeInput1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents ProductionSchID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionTimeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionTimeValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanEndTime As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents 料件系列 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductiveValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ManpowerValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
