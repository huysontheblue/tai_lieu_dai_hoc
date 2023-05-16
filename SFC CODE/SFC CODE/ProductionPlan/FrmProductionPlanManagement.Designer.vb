<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductionPlanManagement
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("生产排产单")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("排程管理", New System.Windows.Forms.TreeNode() {TreeNode1})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductionPlanManagement))
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
        Me.dtpEndDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dtpStartDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnUpdate = New DevComponents.DotNetBar.ButtonItem()
        Me.btnCheck = New DevComponents.DotNetBar.ButtonItem()
        Me.btnReturn = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrinter = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.LabelItem7 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem6 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.txtMOId = New DevComponents.DotNetBar.TextBoxItem()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.lblMessage = New DevComponents.DotNetBar.LabelItem()
        Me.NavigationPane1 = New DevComponents.DotNetBar.NavigationPane()
        Me.NavigationPanePanel1 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.tvProductionPlan = New System.Windows.Forms.TreeView()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.dgvProductionPlan = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ProductionPlanId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpandableSplitterItem = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.dgvProductionPlanItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductionQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnfinishedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpectedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SingleDay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StandardWorkingHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManpowerNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Effectiveness = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstimatedDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpectedCapacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductionDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WKone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WKtwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOYieldQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkOne = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkThree = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkFour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkFive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkSix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkSeven = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkEight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkNine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkEleven = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwelve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkThirteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkFourteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkFifteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkSixteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkSeveteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkEighteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkNineteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwenty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwentyone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwentytwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwentythree = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwentyfour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwentyfive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwentysix = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwentyseven = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwentyeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkTwentynine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkThirty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyWorkThirtyone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuStrip1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        CType(Me.dtpEndDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigationPane1.SuspendLayout()
        Me.NavigationPanePanel1.SuspendLayout()
        CType(Me.dgvProductionPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProductionPlanItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1153, 25)
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
        Me.Bar1.Controls.Add(Me.dtpStartDate)
        Me.Bar1.Controls.Add(Me.dtpEndDate)
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAdd, Me.btnDelete, Me.btnEdit, Me.btnUpdate, Me.btnCheck, Me.btnReturn, Me.btnPrinter, Me.LabelItem3, Me.LabelItem4, Me.ControlContainerItem1, Me.LabelItem7, Me.ControlContainerItem2, Me.LabelItem5, Me.LabelItem2, Me.txtMOId, Me.btnQuery, Me.lblMessage})
        Me.Bar1.Location = New System.Drawing.Point(206, 25)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Bar1.Size = New System.Drawing.Size(947, 28)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 141
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'dtpEndDate
        '
        '
        '
        '
        Me.dtpEndDate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpEndDate.ButtonDropDown.Visible = True
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpEndDate.IsPopupCalendarOpen = False
        Me.dtpEndDate.Location = New System.Drawing.Point(608, 2)
        '
        '
        '
        Me.dtpEndDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpEndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpEndDate.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndDate.MonthCalendar.DisplayMonth = New Date(2015, 7, 1, 0, 0, 0, 0)
        Me.dtpEndDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpEndDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndDate.MonthCalendar.TodayButtonVisible = True
        Me.dtpEndDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(124, 23)
        Me.dtpEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpEndDate.TabIndex = 223
        Me.dtpEndDate.Tag = "查询日期"
        '
        'dtpStartDate
        '
        '
        '
        '
        Me.dtpStartDate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpStartDate.ButtonDropDown.Visible = True
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpStartDate.IsPopupCalendarOpen = False
        Me.dtpStartDate.Location = New System.Drawing.Point(455, 2)
        '
        '
        '
        Me.dtpStartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpStartDate.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartDate.MonthCalendar.DisplayMonth = New Date(2015, 7, 1, 0, 0, 0, 0)
        Me.dtpStartDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpStartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartDate.MonthCalendar.TodayButtonVisible = True
        Me.dtpStartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(124, 23)
        Me.dtpStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpStartDate.TabIndex = 138
        Me.dtpStartDate.Tag = "查询日期"
        '
        'btnAdd
        '
        Me.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAdd.Image = Global.ProductionPlan.My.Resources.Resources.add
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Tag = "添加"
        Me.btnAdd.Text = "添加"
        Me.btnAdd.Tooltip = "添加"
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Image = Global.ProductionPlan.My.Resources.Resources.delete
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Tag = "删除"
        Me.btnDelete.Text = "删除"
        Me.btnDelete.Tooltip = "删除"
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEdit.Image = Global.ProductionPlan.My.Resources.Resources.edit
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Tag = "修改"
        Me.btnEdit.Text = "修改"
        Me.btnEdit.Tooltip = "修改"
        '
        'btnUpdate
        '
        Me.btnUpdate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUpdate.Image = Global.ProductionPlan.My.Resources.Resources.check
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Tag = "更新"
        Me.btnUpdate.Text = "更新"
        Me.btnUpdate.Tooltip = "更新"
        '
        'btnCheck
        '
        Me.btnCheck.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCheck.Image = Global.ProductionPlan.My.Resources.Resources.restore
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Tag = "审核"
        Me.btnCheck.Text = "审核"
        Me.btnCheck.Tooltip = "审核"
        Me.btnCheck.Visible = False
        '
        'btnReturn
        '
        Me.btnReturn.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnReturn.Image = Global.ProductionPlan.My.Resources.Resources._end
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Tag = "弃审"
        Me.btnReturn.Text = "弃审"
        Me.btnReturn.Tooltip = "弃审"
        Me.btnReturn.Visible = False
        '
        'btnPrinter
        '
        Me.btnPrinter.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrinter.Image = Global.ProductionPlan.My.Resources.Resources.print
        Me.btnPrinter.Name = "btnPrinter"
        Me.btnPrinter.Tag = "打印"
        Me.btnPrinter.Text = "打印"
        Me.btnPrinter.Tooltip = "打印"
        Me.btnPrinter.Visible = False
        '
        'LabelItem3
        '
        Me.LabelItem3.BackColor = System.Drawing.Color.Transparent
        Me.LabelItem3.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem3.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.PaddingBottom = 1
        Me.LabelItem3.PaddingLeft = 5
        Me.LabelItem3.PaddingTop = 1
        Me.LabelItem3.SingleLineColor = System.Drawing.Color.Transparent
        '
        'LabelItem4
        '
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.Text = "起始日期:"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.Control = Me.dtpStartDate
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'LabelItem7
        '
        Me.LabelItem7.Name = "LabelItem7"
        Me.LabelItem7.Text = " To"
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.Control = Me.dtpEndDate
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
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
        Me.LabelItem5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.LabelItem6})
        '
        'LabelItem1
        '
        Me.LabelItem1.BackColor = System.Drawing.Color.Transparent
        Me.LabelItem1.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem1.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.PaddingBottom = 1
        Me.LabelItem1.PaddingLeft = 10
        Me.LabelItem1.PaddingTop = 1
        Me.LabelItem1.SingleLineColor = System.Drawing.Color.Transparent
        '
        'LabelItem6
        '
        Me.LabelItem6.BackColor = System.Drawing.Color.Transparent
        Me.LabelItem6.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem6.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.LabelItem6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.LabelItem6.Name = "LabelItem6"
        Me.LabelItem6.PaddingBottom = 1
        Me.LabelItem6.PaddingLeft = 10
        Me.LabelItem6.PaddingTop = 1
        Me.LabelItem6.SingleLineColor = System.Drawing.Color.Transparent
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.Text = "工单:"
        '
        'txtMOId
        '
        Me.txtMOId.FocusHighlightColor = System.Drawing.Color.Transparent
        Me.txtMOId.Name = "txtMOId"
        Me.txtMOId.Tag = "查询单号"
        Me.txtMOId.TextBoxWidth = 94
        Me.txtMOId.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'btnQuery
        '
        Me.btnQuery.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnQuery.Image = Global.ProductionPlan.My.Resources.Resources.query
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Tag = "查询"
        Me.btnQuery.Text = "查询"
        Me.btnQuery.Tooltip = "查询"
        '
        'lblMessage
        '
        Me.lblMessage.Name = "lblMessage"
        '
        'NavigationPane1
        '
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel1)
        Me.NavigationPane1.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavigationPane1.ItemPaddingBottom = 2
        Me.NavigationPane1.ItemPaddingTop = 2
        Me.NavigationPane1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.NavigationPane1.Location = New System.Drawing.Point(0, 25)
        Me.NavigationPane1.Name = "NavigationPane1"
        Me.NavigationPane1.Size = New System.Drawing.Size(206, 484)
        Me.NavigationPane1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NavigationPane1.TabIndex = 140
        '
        '
        '
        Me.NavigationPane1.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.NavigationPane1.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavigationPane1.TitlePanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavigationPane1.TitlePanel.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPane1.TitlePanel.Name = "panelTitle"
        Me.NavigationPane1.TitlePanel.Size = New System.Drawing.Size(206, 24)
        Me.NavigationPane1.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPane1.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.NavigationPane1.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPane1.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.NavigationPane1.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPane1.TitlePanel.Style.GradientAngle = 90
        Me.NavigationPane1.TitlePanel.Style.MarginLeft = 4
        Me.NavigationPane1.TitlePanel.TabIndex = 0
        Me.NavigationPane1.TitlePanel.Text = "排程管理"
        '
        'NavigationPanePanel1
        '
        Me.NavigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.NavigationPanePanel1.Controls.Add(Me.tvProductionPlan)
        Me.NavigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel1.Location = New System.Drawing.Point(0, 24)
        Me.NavigationPanePanel1.Name = "NavigationPanePanel1"
        Me.NavigationPanePanel1.ParentItem = Me.ButtonItem1
        Me.NavigationPanePanel1.Size = New System.Drawing.Size(206, 428)
        Me.NavigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel1.Style.GradientAngle = 90
        Me.NavigationPanePanel1.TabIndex = 2
        '
        'tvProductionPlan
        '
        Me.tvProductionPlan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvProductionPlan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvProductionPlan.Location = New System.Drawing.Point(0, 0)
        Me.tvProductionPlan.Name = "tvProductionPlan"
        TreeNode1.Checked = True
        TreeNode1.Name = "节点1"
        TreeNode1.Text = "生产排产单"
        TreeNode2.Name = "节点0"
        TreeNode2.Text = "排程管理"
        Me.tvProductionPlan.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.tvProductionPlan.Scrollable = False
        Me.tvProductionPlan.Size = New System.Drawing.Size(206, 428)
        Me.tvProductionPlan.Sorted = True
        Me.tvProductionPlan.TabIndex = 2
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Checked = True
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.OptionGroup = "navBar"
        Me.ButtonItem1.Text = "排程管理"
        '
        'dgvProductionPlan
        '
        Me.dgvProductionPlan.AllowUserToAddRows = False
        Me.dgvProductionPlan.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionPlan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductionPlan.ColumnHeadersHeight = 32
        Me.dgvProductionPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProductionPlan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductionPlanId, Me.RowNum, Me.TransactionId, Me.PlanMonth, Me.OrderNumber, Me.DeptName, Me.Remark, Me.CheckUser, Me.CheckTime, Me.StatusFlag, Me.UpdateUser, Me.UpdateTime, Me.CreateUser, Me.CreateTime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductionPlan.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProductionPlan.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvProductionPlan.EnableHeadersVisualStyles = False
        Me.dgvProductionPlan.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvProductionPlan.Location = New System.Drawing.Point(206, 53)
        Me.dgvProductionPlan.Name = "dgvProductionPlan"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionPlan.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProductionPlan.RowHeadersWidth = 15
        Me.dgvProductionPlan.RowTemplate.Height = 28
        Me.dgvProductionPlan.Size = New System.Drawing.Size(947, 204)
        Me.dgvProductionPlan.TabIndex = 142
        '
        'ProductionPlanId
        '
        Me.ProductionPlanId.DataPropertyName = "ProductionPlanId"
        Me.ProductionPlanId.HeaderText = "ProductionPlanId"
        Me.ProductionPlanId.Name = "ProductionPlanId"
        Me.ProductionPlanId.ReadOnly = True
        Me.ProductionPlanId.Visible = False
        '
        'RowNum
        '
        Me.RowNum.DataPropertyName = "RowNum"
        Me.RowNum.HeaderText = "序号"
        Me.RowNum.Name = "RowNum"
        Me.RowNum.ReadOnly = True
        Me.RowNum.Width = 30
        '
        'TransactionId
        '
        Me.TransactionId.DataPropertyName = "TransactionId"
        Me.TransactionId.FillWeight = 120.0!
        Me.TransactionId.HeaderText = "单据号"
        Me.TransactionId.Name = "TransactionId"
        Me.TransactionId.ReadOnly = True
        Me.TransactionId.Width = 140
        '
        'PlanMonth
        '
        Me.PlanMonth.DataPropertyName = "PlanMonth"
        Me.PlanMonth.HeaderText = "月份"
        Me.PlanMonth.Name = "PlanMonth"
        Me.PlanMonth.ReadOnly = True
        '
        'OrderNumber
        '
        Me.OrderNumber.DataPropertyName = "OrderNumber"
        Me.OrderNumber.FillWeight = 120.0!
        Me.OrderNumber.HeaderText = "订单号"
        Me.OrderNumber.Name = "OrderNumber"
        Me.OrderNumber.ReadOnly = True
        Me.OrderNumber.Width = 140
        '
        'DeptName
        '
        Me.DeptName.DataPropertyName = "DeptName"
        Me.DeptName.HeaderText = "部门"
        Me.DeptName.Name = "DeptName"
        Me.DeptName.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.FillWeight = 150.0!
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 150
        '
        'CheckUser
        '
        Me.CheckUser.DataPropertyName = "CheckUser"
        Me.CheckUser.HeaderText = "审核人"
        Me.CheckUser.Name = "CheckUser"
        Me.CheckUser.ReadOnly = True
        '
        'CheckTime
        '
        Me.CheckTime.DataPropertyName = "CheckTime"
        Me.CheckTime.HeaderText = "审核时间"
        Me.CheckTime.Name = "CheckTime"
        Me.CheckTime.ReadOnly = True
        '
        'StatusFlag
        '
        Me.StatusFlag.DataPropertyName = "StatusFlag"
        Me.StatusFlag.FillWeight = 80.0!
        Me.StatusFlag.HeaderText = "状态"
        Me.StatusFlag.Name = "StatusFlag"
        Me.StatusFlag.ReadOnly = True
        Me.StatusFlag.Width = 60
        '
        'UpdateUser
        '
        Me.UpdateUser.DataPropertyName = "UpdateUser"
        Me.UpdateUser.HeaderText = "更新人"
        Me.UpdateUser.Name = "UpdateUser"
        Me.UpdateUser.ReadOnly = True
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "更新时间"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        '
        'CreateUser
        '
        Me.CreateUser.DataPropertyName = "CreateUser"
        Me.CreateUser.HeaderText = "新增人"
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.ReadOnly = True
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "CreateTime"
        Me.CreateTime.HeaderText = "新增时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        '
        'ExpandableSplitterItem
        '
        Me.ExpandableSplitterItem.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitterItem.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterItem.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitterItem.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandableSplitterItem.ExpandableControl = Me.dgvProductionPlan
        Me.ExpandableSplitterItem.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitterItem.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterItem.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.ExpandableSplitterItem.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitterItem.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.ExpandableSplitterItem.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitterItem.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ExpandableSplitterItem.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitterItem.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.ExpandableSplitterItem.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.ExpandableSplitterItem.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitterItem.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitterItem.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitterItem.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterItem.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.ExpandableSplitterItem.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitterItem.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitterItem.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterItem.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ExpandableSplitterItem.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitterItem.Location = New System.Drawing.Point(206, 257)
        Me.ExpandableSplitterItem.Name = "ExpandableSplitterItem"
        Me.ExpandableSplitterItem.Size = New System.Drawing.Size(947, 6)
        Me.ExpandableSplitterItem.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitterItem.TabIndex = 143
        Me.ExpandableSplitterItem.TabStop = False
        '
        'dgvProductionPlanItem
        '
        Me.dgvProductionPlanItem.AllowUserToAddRows = False
        Me.dgvProductionPlanItem.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionPlanItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProductionPlanItem.ColumnHeadersHeight = 32
        Me.dgvProductionPlanItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProductionPlanItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.MaterialNO, Me.MOId, Me.DataGridViewTextBoxColumn3, Me.LineName, Me.ProductionQuantity, Me.CustomerName, Me.UnfinishedQuantity, Me.ExpectedDate, Me.SingleDay, Me.StandardWorkingHours, Me.ManpowerNumber, Me.Effectiveness, Me.EstimatedDays, Me.ExpectedCapacity, Me.ProductionDays, Me.WKone, Me.WKtwo, Me.NOYieldQuantity, Me.LineUserName, Me.DataGridViewTextBoxColumn4, Me.DailyWorkOne, Me.DailyWorkTwo, Me.DailyWorkThree, Me.DailyWorkFour, Me.DailyWorkFive, Me.DailyWorkSix, Me.DailyWorkSeven, Me.DailyWorkEight, Me.DailyWorkNine, Me.DailyWorkTen, Me.DailyWorkEleven, Me.DailyWorkTwelve, Me.DailyWorkThirteen, Me.DailyWorkFourteen, Me.DailyWorkFifteen, Me.DailyWorkSixteen, Me.DailyWorkSeveteen, Me.DailyWorkEighteen, Me.DailyWorkNineteen, Me.DailyWorkTwenty, Me.DailyWorkTwentyone, Me.DailyWorkTwentytwo, Me.DailyWorkTwentythree, Me.DailyWorkTwentyfour, Me.DailyWorkTwentyfive, Me.DailyWorkTwentysix, Me.DailyWorkTwentyseven, Me.DailyWorkTwentyeight, Me.DailyWorkTwentynine, Me.DailyWorkThirty, Me.DailyWorkThirtyone})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductionPlanItem.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProductionPlanItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductionPlanItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvProductionPlanItem.EnableHeadersVisualStyles = False
        Me.dgvProductionPlanItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvProductionPlanItem.Location = New System.Drawing.Point(206, 263)
        Me.dgvProductionPlanItem.Name = "dgvProductionPlanItem"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionPlanItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvProductionPlanItem.RowHeadersWidth = 15
        Me.dgvProductionPlanItem.RowTemplate.Height = 28
        Me.dgvProductionPlanItem.Size = New System.Drawing.Size(947, 246)
        Me.dgvProductionPlanItem.TabIndex = 222
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "TransactionId"
        Me.DataGridViewTextBoxColumn1.HeaderText = "TransactionId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "RowNum"
        Me.DataGridViewTextBoxColumn2.HeaderText = "序号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 30
        '
        'MaterialNO
        '
        Me.MaterialNO.DataPropertyName = "MaterialNO"
        Me.MaterialNO.HeaderText = "料号"
        Me.MaterialNO.Name = "MaterialNO"
        Me.MaterialNO.ReadOnly = True
        Me.MaterialNO.Width = 120
        '
        'MOId
        '
        Me.MOId.DataPropertyName = "MOId"
        Me.MOId.HeaderText = "工单"
        Me.MOId.Name = "MOId"
        Me.MOId.ReadOnly = True
        Me.MOId.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DeptName"
        Me.DataGridViewTextBoxColumn3.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "部门"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'LineName
        '
        Me.LineName.DataPropertyName = "LineName"
        Me.LineName.HeaderText = "线别"
        Me.LineName.Name = "LineName"
        Me.LineName.ReadOnly = True
        Me.LineName.Width = 60
        '
        'ProductionQuantity
        '
        Me.ProductionQuantity.DataPropertyName = "ProductionQuantity"
        Me.ProductionQuantity.HeaderText = "生产数量"
        Me.ProductionQuantity.Name = "ProductionQuantity"
        Me.ProductionQuantity.ReadOnly = True
        Me.ProductionQuantity.Width = 80
        '
        'CustomerName
        '
        Me.CustomerName.DataPropertyName = "CustomerName"
        Me.CustomerName.HeaderText = "客户名称"
        Me.CustomerName.Name = "CustomerName"
        Me.CustomerName.ReadOnly = True
        Me.CustomerName.Width = 120
        '
        'UnfinishedQuantity
        '
        Me.UnfinishedQuantity.DataPropertyName = "UnfinishedQuantity"
        Me.UnfinishedQuantity.HeaderText = "未完成数量"
        Me.UnfinishedQuantity.Name = "UnfinishedQuantity"
        Me.UnfinishedQuantity.ReadOnly = True
        Me.UnfinishedQuantity.Width = 80
        '
        'ExpectedDate
        '
        Me.ExpectedDate.DataPropertyName = "ExpectedDate"
        Me.ExpectedDate.HeaderText = "预计开工日"
        Me.ExpectedDate.Name = "ExpectedDate"
        Me.ExpectedDate.ReadOnly = True
        Me.ExpectedDate.Width = 80
        '
        'SingleDay
        '
        Me.SingleDay.DataPropertyName = "SingleDay"
        Me.SingleDay.HeaderText = "下单天数"
        Me.SingleDay.Name = "SingleDay"
        Me.SingleDay.ReadOnly = True
        Me.SingleDay.Width = 60
        '
        'StandardWorkingHours
        '
        Me.StandardWorkingHours.DataPropertyName = "StandardWorkingHours"
        Me.StandardWorkingHours.HeaderText = "标准工时(秒)"
        Me.StandardWorkingHours.Name = "StandardWorkingHours"
        Me.StandardWorkingHours.ReadOnly = True
        Me.StandardWorkingHours.Width = 60
        '
        'ManpowerNumber
        '
        Me.ManpowerNumber.DataPropertyName = "ManpowerNumber"
        Me.ManpowerNumber.HeaderText = "人力"
        Me.ManpowerNumber.Name = "ManpowerNumber"
        Me.ManpowerNumber.ReadOnly = True
        Me.ManpowerNumber.Width = 60
        '
        'Effectiveness
        '
        Me.Effectiveness.DataPropertyName = "Effectiveness"
        Me.Effectiveness.HeaderText = "效率"
        Me.Effectiveness.Name = "Effectiveness"
        Me.Effectiveness.ReadOnly = True
        Me.Effectiveness.Width = 60
        '
        'EstimatedDays
        '
        Me.EstimatedDays.DataPropertyName = "EstimatedDays"
        Me.EstimatedDays.HeaderText = "预计天数"
        Me.EstimatedDays.Name = "EstimatedDays"
        Me.EstimatedDays.ReadOnly = True
        Me.EstimatedDays.Width = 60
        '
        'ExpectedCapacity
        '
        Me.ExpectedCapacity.DataPropertyName = "ExpectedCapacity"
        Me.ExpectedCapacity.HeaderText = "预计产能"
        Me.ExpectedCapacity.Name = "ExpectedCapacity"
        Me.ExpectedCapacity.ReadOnly = True
        Me.ExpectedCapacity.Width = 80
        '
        'ProductionDays
        '
        Me.ProductionDays.DataPropertyName = "ProductionDays"
        Me.ProductionDays.HeaderText = "在制天数"
        Me.ProductionDays.Name = "ProductionDays"
        Me.ProductionDays.ReadOnly = True
        Me.ProductionDays.Width = 60
        '
        'WKone
        '
        Me.WKone.DataPropertyName = "WKone"
        Me.WKone.HeaderText = "WK1欠"
        Me.WKone.Name = "WKone"
        Me.WKone.ReadOnly = True
        '
        'WKtwo
        '
        Me.WKtwo.DataPropertyName = "WKtwo"
        Me.WKtwo.HeaderText = "WK2欠"
        Me.WKtwo.Name = "WKtwo"
        Me.WKtwo.ReadOnly = True
        Me.WKtwo.Width = 80
        '
        'NOYieldQuantity
        '
        Me.NOYieldQuantity.DataPropertyName = "NOYieldQuantity"
        Me.NOYieldQuantity.HeaderText = "未排量"
        Me.NOYieldQuantity.Name = "NOYieldQuantity"
        Me.NOYieldQuantity.ReadOnly = True
        Me.NOYieldQuantity.Width = 80
        '
        'LineUserName
        '
        Me.LineUserName.DataPropertyName = "LineUserName"
        Me.LineUserName.HeaderText = "线长"
        Me.LineUserName.Name = "LineUserName"
        Me.LineUserName.ReadOnly = True
        Me.LineUserName.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Remark"
        Me.DataGridViewTextBoxColumn4.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'DailyWorkOne
        '
        Me.DailyWorkOne.DataPropertyName = "DailyWorkOne"
        Me.DailyWorkOne.HeaderText = "Column1"
        Me.DailyWorkOne.Name = "DailyWorkOne"
        Me.DailyWorkOne.ReadOnly = True
        Me.DailyWorkOne.Width = 50
        '
        'DailyWorkTwo
        '
        Me.DailyWorkTwo.DataPropertyName = "DailyWorkTwo"
        Me.DailyWorkTwo.FillWeight = 40.0!
        Me.DailyWorkTwo.HeaderText = "Column1"
        Me.DailyWorkTwo.Name = "DailyWorkTwo"
        Me.DailyWorkTwo.ReadOnly = True
        Me.DailyWorkTwo.Width = 50
        '
        'DailyWorkThree
        '
        Me.DailyWorkThree.DataPropertyName = "DailyWorkThree"
        Me.DailyWorkThree.FillWeight = 40.0!
        Me.DailyWorkThree.HeaderText = "Column1"
        Me.DailyWorkThree.Name = "DailyWorkThree"
        Me.DailyWorkThree.ReadOnly = True
        Me.DailyWorkThree.Width = 50
        '
        'DailyWorkFour
        '
        Me.DailyWorkFour.DataPropertyName = "DailyWorkFour"
        Me.DailyWorkFour.FillWeight = 40.0!
        Me.DailyWorkFour.HeaderText = "Column1"
        Me.DailyWorkFour.Name = "DailyWorkFour"
        Me.DailyWorkFour.ReadOnly = True
        Me.DailyWorkFour.Width = 50
        '
        'DailyWorkFive
        '
        Me.DailyWorkFive.DataPropertyName = "DailyWorkFive"
        Me.DailyWorkFive.FillWeight = 40.0!
        Me.DailyWorkFive.HeaderText = "Column1"
        Me.DailyWorkFive.Name = "DailyWorkFive"
        Me.DailyWorkFive.ReadOnly = True
        Me.DailyWorkFive.Width = 50
        '
        'DailyWorkSix
        '
        Me.DailyWorkSix.DataPropertyName = "DailyWorkSix"
        Me.DailyWorkSix.FillWeight = 40.0!
        Me.DailyWorkSix.HeaderText = "Column1"
        Me.DailyWorkSix.Name = "DailyWorkSix"
        Me.DailyWorkSix.ReadOnly = True
        Me.DailyWorkSix.Width = 50
        '
        'DailyWorkSeven
        '
        Me.DailyWorkSeven.DataPropertyName = "DailyWorkSeven"
        Me.DailyWorkSeven.FillWeight = 40.0!
        Me.DailyWorkSeven.HeaderText = "Column1"
        Me.DailyWorkSeven.Name = "DailyWorkSeven"
        Me.DailyWorkSeven.ReadOnly = True
        Me.DailyWorkSeven.Width = 50
        '
        'DailyWorkEight
        '
        Me.DailyWorkEight.DataPropertyName = "DailyWorkEight"
        Me.DailyWorkEight.FillWeight = 40.0!
        Me.DailyWorkEight.HeaderText = "Column1"
        Me.DailyWorkEight.Name = "DailyWorkEight"
        Me.DailyWorkEight.ReadOnly = True
        Me.DailyWorkEight.Width = 50
        '
        'DailyWorkNine
        '
        Me.DailyWorkNine.DataPropertyName = "DailyWorkNine"
        Me.DailyWorkNine.FillWeight = 40.0!
        Me.DailyWorkNine.HeaderText = "Column1"
        Me.DailyWorkNine.Name = "DailyWorkNine"
        Me.DailyWorkNine.ReadOnly = True
        Me.DailyWorkNine.Width = 50
        '
        'DailyWorkTen
        '
        Me.DailyWorkTen.DataPropertyName = "DailyWorkTen"
        Me.DailyWorkTen.FillWeight = 40.0!
        Me.DailyWorkTen.HeaderText = "Column1"
        Me.DailyWorkTen.Name = "DailyWorkTen"
        Me.DailyWorkTen.ReadOnly = True
        Me.DailyWorkTen.Width = 50
        '
        'DailyWorkEleven
        '
        Me.DailyWorkEleven.DataPropertyName = "DailyWorkEleven"
        Me.DailyWorkEleven.FillWeight = 40.0!
        Me.DailyWorkEleven.HeaderText = "Column1"
        Me.DailyWorkEleven.Name = "DailyWorkEleven"
        Me.DailyWorkEleven.ReadOnly = True
        Me.DailyWorkEleven.Width = 50
        '
        'DailyWorkTwelve
        '
        Me.DailyWorkTwelve.DataPropertyName = "DailyWorkTwelve"
        Me.DailyWorkTwelve.FillWeight = 40.0!
        Me.DailyWorkTwelve.HeaderText = "Column1"
        Me.DailyWorkTwelve.Name = "DailyWorkTwelve"
        Me.DailyWorkTwelve.ReadOnly = True
        Me.DailyWorkTwelve.Width = 50
        '
        'DailyWorkThirteen
        '
        Me.DailyWorkThirteen.DataPropertyName = "DailyWorkThirteen"
        Me.DailyWorkThirteen.FillWeight = 40.0!
        Me.DailyWorkThirteen.HeaderText = "Column1"
        Me.DailyWorkThirteen.Name = "DailyWorkThirteen"
        Me.DailyWorkThirteen.ReadOnly = True
        Me.DailyWorkThirteen.Width = 50
        '
        'DailyWorkFourteen
        '
        Me.DailyWorkFourteen.DataPropertyName = "DailyWorkFourteen"
        Me.DailyWorkFourteen.FillWeight = 40.0!
        Me.DailyWorkFourteen.HeaderText = "Column1"
        Me.DailyWorkFourteen.Name = "DailyWorkFourteen"
        Me.DailyWorkFourteen.ReadOnly = True
        Me.DailyWorkFourteen.Width = 50
        '
        'DailyWorkFifteen
        '
        Me.DailyWorkFifteen.DataPropertyName = "DailyWorkFifteen"
        Me.DailyWorkFifteen.FillWeight = 40.0!
        Me.DailyWorkFifteen.HeaderText = "Column1"
        Me.DailyWorkFifteen.Name = "DailyWorkFifteen"
        Me.DailyWorkFifteen.ReadOnly = True
        Me.DailyWorkFifteen.Width = 50
        '
        'DailyWorkSixteen
        '
        Me.DailyWorkSixteen.DataPropertyName = "DailyWorkSixteen"
        Me.DailyWorkSixteen.FillWeight = 40.0!
        Me.DailyWorkSixteen.HeaderText = "Column1"
        Me.DailyWorkSixteen.Name = "DailyWorkSixteen"
        Me.DailyWorkSixteen.ReadOnly = True
        Me.DailyWorkSixteen.Width = 50
        '
        'DailyWorkSeveteen
        '
        Me.DailyWorkSeveteen.DataPropertyName = "DailyWorkSeveteen"
        Me.DailyWorkSeveteen.FillWeight = 40.0!
        Me.DailyWorkSeveteen.HeaderText = "Column1"
        Me.DailyWorkSeveteen.Name = "DailyWorkSeveteen"
        Me.DailyWorkSeveteen.ReadOnly = True
        Me.DailyWorkSeveteen.Width = 50
        '
        'DailyWorkEighteen
        '
        Me.DailyWorkEighteen.DataPropertyName = "DailyWorkEighteen"
        Me.DailyWorkEighteen.FillWeight = 40.0!
        Me.DailyWorkEighteen.HeaderText = "Column1"
        Me.DailyWorkEighteen.Name = "DailyWorkEighteen"
        Me.DailyWorkEighteen.ReadOnly = True
        Me.DailyWorkEighteen.Width = 50
        '
        'DailyWorkNineteen
        '
        Me.DailyWorkNineteen.DataPropertyName = "DailyWorkNineteen"
        Me.DailyWorkNineteen.FillWeight = 40.0!
        Me.DailyWorkNineteen.HeaderText = "Column1"
        Me.DailyWorkNineteen.Name = "DailyWorkNineteen"
        Me.DailyWorkNineteen.ReadOnly = True
        Me.DailyWorkNineteen.Width = 50
        '
        'DailyWorkTwenty
        '
        Me.DailyWorkTwenty.DataPropertyName = "DailyWorkTwenty"
        Me.DailyWorkTwenty.FillWeight = 40.0!
        Me.DailyWorkTwenty.HeaderText = "Column1"
        Me.DailyWorkTwenty.Name = "DailyWorkTwenty"
        Me.DailyWorkTwenty.ReadOnly = True
        Me.DailyWorkTwenty.Width = 50
        '
        'DailyWorkTwentyone
        '
        Me.DailyWorkTwentyone.DataPropertyName = "DailyWorkTwentyone"
        Me.DailyWorkTwentyone.FillWeight = 40.0!
        Me.DailyWorkTwentyone.HeaderText = "Column1"
        Me.DailyWorkTwentyone.Name = "DailyWorkTwentyone"
        Me.DailyWorkTwentyone.ReadOnly = True
        Me.DailyWorkTwentyone.Width = 50
        '
        'DailyWorkTwentytwo
        '
        Me.DailyWorkTwentytwo.DataPropertyName = "DailyWorkTwentytwo"
        Me.DailyWorkTwentytwo.FillWeight = 40.0!
        Me.DailyWorkTwentytwo.HeaderText = "Column1"
        Me.DailyWorkTwentytwo.Name = "DailyWorkTwentytwo"
        Me.DailyWorkTwentytwo.ReadOnly = True
        Me.DailyWorkTwentytwo.Width = 50
        '
        'DailyWorkTwentythree
        '
        Me.DailyWorkTwentythree.DataPropertyName = "DailyWorkTwentythree"
        Me.DailyWorkTwentythree.FillWeight = 40.0!
        Me.DailyWorkTwentythree.HeaderText = "Column1"
        Me.DailyWorkTwentythree.Name = "DailyWorkTwentythree"
        Me.DailyWorkTwentythree.ReadOnly = True
        Me.DailyWorkTwentythree.Width = 50
        '
        'DailyWorkTwentyfour
        '
        Me.DailyWorkTwentyfour.DataPropertyName = "DailyWorkTwentyfour"
        Me.DailyWorkTwentyfour.FillWeight = 40.0!
        Me.DailyWorkTwentyfour.HeaderText = "Column1"
        Me.DailyWorkTwentyfour.Name = "DailyWorkTwentyfour"
        Me.DailyWorkTwentyfour.ReadOnly = True
        Me.DailyWorkTwentyfour.Width = 50
        '
        'DailyWorkTwentyfive
        '
        Me.DailyWorkTwentyfive.DataPropertyName = "DailyWorkTwentyfive"
        Me.DailyWorkTwentyfive.FillWeight = 40.0!
        Me.DailyWorkTwentyfive.HeaderText = "Column1"
        Me.DailyWorkTwentyfive.Name = "DailyWorkTwentyfive"
        Me.DailyWorkTwentyfive.ReadOnly = True
        Me.DailyWorkTwentyfive.Width = 50
        '
        'DailyWorkTwentysix
        '
        Me.DailyWorkTwentysix.DataPropertyName = "DailyWorkTwentysix"
        Me.DailyWorkTwentysix.FillWeight = 40.0!
        Me.DailyWorkTwentysix.HeaderText = "Column1"
        Me.DailyWorkTwentysix.Name = "DailyWorkTwentysix"
        Me.DailyWorkTwentysix.ReadOnly = True
        Me.DailyWorkTwentysix.Width = 50
        '
        'DailyWorkTwentyseven
        '
        Me.DailyWorkTwentyseven.DataPropertyName = "DailyWorkTwentyseven"
        Me.DailyWorkTwentyseven.FillWeight = 40.0!
        Me.DailyWorkTwentyseven.HeaderText = "Column1"
        Me.DailyWorkTwentyseven.Name = "DailyWorkTwentyseven"
        Me.DailyWorkTwentyseven.ReadOnly = True
        Me.DailyWorkTwentyseven.Width = 50
        '
        'DailyWorkTwentyeight
        '
        Me.DailyWorkTwentyeight.DataPropertyName = "DailyWorkTwentyeight"
        Me.DailyWorkTwentyeight.FillWeight = 40.0!
        Me.DailyWorkTwentyeight.HeaderText = "Column1"
        Me.DailyWorkTwentyeight.Name = "DailyWorkTwentyeight"
        Me.DailyWorkTwentyeight.ReadOnly = True
        Me.DailyWorkTwentyeight.Width = 50
        '
        'DailyWorkTwentynine
        '
        Me.DailyWorkTwentynine.DataPropertyName = "DailyWorkTwentynine"
        Me.DailyWorkTwentynine.FillWeight = 40.0!
        Me.DailyWorkTwentynine.HeaderText = "Column1"
        Me.DailyWorkTwentynine.Name = "DailyWorkTwentynine"
        Me.DailyWorkTwentynine.ReadOnly = True
        Me.DailyWorkTwentynine.Width = 50
        '
        'DailyWorkThirty
        '
        Me.DailyWorkThirty.DataPropertyName = "DailyWorkThirty"
        Me.DailyWorkThirty.FillWeight = 40.0!
        Me.DailyWorkThirty.HeaderText = "Column1"
        Me.DailyWorkThirty.Name = "DailyWorkThirty"
        Me.DailyWorkThirty.ReadOnly = True
        Me.DailyWorkThirty.Width = 50
        '
        'DailyWorkThirtyone
        '
        Me.DailyWorkThirtyone.DataPropertyName = "DailyWorkThirtyone"
        Me.DailyWorkThirtyone.FillWeight = 40.0!
        Me.DailyWorkThirtyone.HeaderText = "Column1"
        Me.DailyWorkThirtyone.Name = "DailyWorkThirtyone"
        Me.DailyWorkThirtyone.ReadOnly = True
        Me.DailyWorkThirtyone.Width = 50
        '
        'FrmProductionPlanManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 509)
        Me.Controls.Add(Me.dgvProductionPlanItem)
        Me.Controls.Add(Me.ExpandableSplitterItem)
        Me.Controls.Add(Me.dgvProductionPlan)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.NavigationPane1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "FrmProductionPlanManagement"
        Me.ShowIcon = False
        Me.Text = "生产排程管理"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        CType(Me.dtpEndDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStartDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigationPane1.ResumeLayout(False)
        Me.NavigationPanePanel1.ResumeLayout(False)
        CType(Me.dgvProductionPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProductionPlanItem, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dtpStartDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrinter As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtMOId As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelItem
    Friend WithEvents NavigationPane1 As DevComponents.DotNetBar.NavigationPane
    Friend WithEvents NavigationPanePanel1 As DevComponents.DotNetBar.NavigationPanePanel
    Private WithEvents tvProductionPlan As System.Windows.Forms.TreeView
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dgvProductionPlan As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ExpandableSplitterItem As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents ProductionPlanId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RowNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvProductionPlanItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnUpdate As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCheck As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnReturn As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaterialNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnfinishedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpectedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SingleDay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StandardWorkingHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ManpowerNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Effectiveness As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstimatedDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExpectedCapacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WKone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WKtwo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOYieldQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkOne As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkThree As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkFour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkFive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkSix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkSeven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkEight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkNine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkEleven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwelve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkThirteen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkFourteen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkFifteen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkSixteen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkSeveteen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkEighteen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkNineteen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwenty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwentyone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwentytwo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwentythree As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwentyfour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwentyfive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwentysix As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwentyseven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwentyeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkTwentynine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkThirty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyWorkThirtyone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpEndDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelItem7 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem6 As DevComponents.DotNetBar.LabelItem
End Class
