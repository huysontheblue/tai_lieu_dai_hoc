<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductionPlanQuery
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ExpandablePanelWhere = New DevComponents.DotNetBar.ExpandablePanel()
        Me.btnVisibleColumn = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.itxtRefreshInterval = New DevComponents.Editors.IntegerInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.txtMOId = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonX()
        Me.cboLine = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.dtpInvoiceDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cboDept = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.dgvProductionPlanItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ProductionPlanId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptName = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.TimerRefreshQuery = New System.Windows.Forms.Timer(Me.components)
        Me.ExpandablePanelWhere.SuspendLayout()
        CType(Me.itxtRefreshInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProductionPlanItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExpandablePanelWhere
        '
        Me.ExpandablePanelWhere.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanelWhere.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanelWhere.Controls.Add(Me.btnVisibleColumn)
        Me.ExpandablePanelWhere.Controls.Add(Me.LabelX3)
        Me.ExpandablePanelWhere.Controls.Add(Me.itxtRefreshInterval)
        Me.ExpandablePanelWhere.Controls.Add(Me.LabelX4)
        Me.ExpandablePanelWhere.Controls.Add(Me.lblMessage)
        Me.ExpandablePanelWhere.Controls.Add(Me.txtMOId)
        Me.ExpandablePanelWhere.Controls.Add(Me.LabelX6)
        Me.ExpandablePanelWhere.Controls.Add(Me.btnQuery)
        Me.ExpandablePanelWhere.Controls.Add(Me.cboLine)
        Me.ExpandablePanelWhere.Controls.Add(Me.LabelX2)
        Me.ExpandablePanelWhere.Controls.Add(Me.dtpInvoiceDate)
        Me.ExpandablePanelWhere.Controls.Add(Me.LabelX1)
        Me.ExpandablePanelWhere.Controls.Add(Me.cboDept)
        Me.ExpandablePanelWhere.Controls.Add(Me.LabelX5)
        Me.ExpandablePanelWhere.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandablePanelWhere.Location = New System.Drawing.Point(0, 0)
        Me.ExpandablePanelWhere.Name = "ExpandablePanelWhere"
        Me.ExpandablePanelWhere.Size = New System.Drawing.Size(1198, 95)
        Me.ExpandablePanelWhere.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanelWhere.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanelWhere.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanelWhere.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanelWhere.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanelWhere.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanelWhere.Style.GradientAngle = 90
        Me.ExpandablePanelWhere.TabIndex = 0
        Me.ExpandablePanelWhere.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanelWhere.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanelWhere.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanelWhere.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanelWhere.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanelWhere.TitleStyle.GradientAngle = 90
        Me.ExpandablePanelWhere.TitleText = " 条件"
        '
        'btnVisibleColumn
        '
        Me.btnVisibleColumn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVisibleColumn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVisibleColumn.Location = New System.Drawing.Point(1133, 35)
        Me.btnVisibleColumn.Name = "btnVisibleColumn"
        Me.btnVisibleColumn.Size = New System.Drawing.Size(62, 23)
        Me.btnVisibleColumn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVisibleColumn.TabIndex = 242
        Me.btnVisibleColumn.Text = "列显示"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(223, 68)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(40, 23)
        Me.LabelX3.TabIndex = 240
        Me.LabelX3.Text = "分"
        '
        'itxtRefreshInterval
        '
        '
        '
        '
        Me.itxtRefreshInterval.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.itxtRefreshInterval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.itxtRefreshInterval.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.itxtRefreshInterval.Location = New System.Drawing.Point(80, 68)
        Me.itxtRefreshInterval.MaxValue = 10000
        Me.itxtRefreshInterval.MinValue = 0
        Me.itxtRefreshInterval.Name = "itxtRefreshInterval"
        Me.itxtRefreshInterval.ShowUpDown = True
        Me.itxtRefreshInterval.Size = New System.Drawing.Size(137, 21)
        Me.itxtRefreshInterval.TabIndex = 239
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(9, 68)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(82, 23)
        Me.LabelX4.TabIndex = 238
        Me.LabelX4.Text = "刷新 时间"
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(259, 67)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(788, 23)
        Me.lblMessage.TabIndex = 237
        '
        'txtMOId
        '
        '
        '
        '
        Me.txtMOId.BackgroundStyle.Class = "TextBoxBorder"
        Me.txtMOId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMOId.Location = New System.Drawing.Point(849, 37)
        Me.txtMOId.Name = "txtMOId"
        Me.txtMOId.ReadOnly = True
        Me.txtMOId.Size = New System.Drawing.Size(138, 21)
        Me.txtMOId.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtMOId.TabIndex = 236
        Me.txtMOId.Text = ""
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(779, 37)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 235
        Me.LabelX6.Text = "工    单"
        '
        'btnQuery
        '
        Me.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuery.Location = New System.Drawing.Point(1042, 35)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(62, 23)
        Me.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQuery.TabIndex = 234
        Me.btnQuery.Text = "查  询"
        '
        'cboLine
        '
        Me.cboLine.DisplayMember = "Text"
        Me.cboLine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLine.FormattingEnabled = True
        Me.cboLine.ItemHeight = 15
        Me.cboLine.Location = New System.Drawing.Point(594, 37)
        Me.cboLine.Name = "cboLine"
        Me.cboLine.Size = New System.Drawing.Size(140, 21)
        Me.cboLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboLine.TabIndex = 213
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(523, 37)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 212
        Me.LabelX2.Text = "产     线"
        '
        'dtpInvoiceDate
        '
        '
        '
        '
        Me.dtpInvoiceDate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpInvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpInvoiceDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpInvoiceDate.ButtonDropDown.Visible = True
        Me.dtpInvoiceDate.CustomFormat = "yyyy-MM"
        Me.dtpInvoiceDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpInvoiceDate.IsPopupCalendarOpen = False
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(80, 37)
        '
        '
        '
        Me.dtpInvoiceDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpInvoiceDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpInvoiceDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpInvoiceDate.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpInvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpInvoiceDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpInvoiceDate.MonthCalendar.DisplayMonth = New Date(2015, 7, 1, 0, 0, 0, 0)
        Me.dtpInvoiceDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpInvoiceDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpInvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpInvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpInvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpInvoiceDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpInvoiceDate.MonthCalendar.TodayButtonVisible = True
        Me.dtpInvoiceDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(137, 21)
        Me.dtpInvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpInvoiceDate.TabIndex = 211
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(10, 37)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 210
        Me.LabelX1.Text = "月     份"
        '
        'cboDept
        '
        Me.cboDept.DisplayMember = "Text"
        Me.cboDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.ItemHeight = 15
        Me.cboDept.Location = New System.Drawing.Point(330, 37)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(140, 21)
        Me.cboDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboDept.TabIndex = 209
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(259, 37)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 208
        Me.LabelX5.Text = "部     门"
        '
        'dgvProductionPlanItem
        '
        Me.dgvProductionPlanItem.AllowUserToAddRows = False
        Me.dgvProductionPlanItem.AllowUserToDeleteRows = False
        Me.dgvProductionPlanItem.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionPlanItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProductionPlanItem.ColumnHeadersHeight = 32
        Me.dgvProductionPlanItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProductionPlanItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductionPlanId, Me.RowNum, Me.MaterialNO, Me.MOId, Me.DeptName, Me.LineName, Me.ProductionQuantity, Me.CustomerName, Me.UnfinishedQuantity, Me.ExpectedDate, Me.SingleDay, Me.StandardWorkingHours, Me.ManpowerNumber, Me.Effectiveness, Me.EstimatedDays, Me.ExpectedCapacity, Me.ProductionDays, Me.WKone, Me.WKtwo, Me.NOYieldQuantity, Me.LineUserName, Me.Remark, Me.DailyWorkOne, Me.DailyWorkTwo, Me.DailyWorkThree, Me.DailyWorkFour, Me.DailyWorkFive, Me.DailyWorkSix, Me.DailyWorkSeven, Me.DailyWorkEight, Me.DailyWorkNine, Me.DailyWorkTen, Me.DailyWorkEleven, Me.DailyWorkTwelve, Me.DailyWorkThirteen, Me.DailyWorkFourteen, Me.DailyWorkFifteen, Me.DailyWorkSixteen, Me.DailyWorkSeveteen, Me.DailyWorkEighteen, Me.DailyWorkNineteen, Me.DailyWorkTwenty, Me.DailyWorkTwentyone, Me.DailyWorkTwentytwo, Me.DailyWorkTwentythree, Me.DailyWorkTwentyfour, Me.DailyWorkTwentyfive, Me.DailyWorkTwentysix, Me.DailyWorkTwentyseven, Me.DailyWorkTwentyeight, Me.DailyWorkTwentynine, Me.DailyWorkThirty, Me.DailyWorkThirtyone})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductionPlanItem.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProductionPlanItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductionPlanItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvProductionPlanItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvProductionPlanItem.Location = New System.Drawing.Point(0, 95)
        Me.dgvProductionPlanItem.Name = "dgvProductionPlanItem"
        Me.dgvProductionPlanItem.RowHeadersWidth = 15
        Me.dgvProductionPlanItem.RowTemplate.Height = 28
        Me.dgvProductionPlanItem.Size = New System.Drawing.Size(1198, 361)
        Me.dgvProductionPlanItem.TabIndex = 222
        '
        'ProductionPlanId
        '
        Me.ProductionPlanId.DataPropertyName = "TransactionId"
        Me.ProductionPlanId.HeaderText = "TransactionId"
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
        Me.MOId.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MOId.Width = 120
        '
        'DeptName
        '
        Me.DeptName.DataPropertyName = "DeptName"
        Me.DeptName.FillWeight = 80.0!
        Me.DeptName.HeaderText = "部门"
        Me.DeptName.Name = "DeptName"
        Me.DeptName.ReadOnly = True
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
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 120
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
        'TimerRefreshQuery
        '
        '
        'FrmProductionPlanQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 456)
        Me.Controls.Add(Me.dgvProductionPlanItem)
        Me.Controls.Add(Me.ExpandablePanelWhere)
        Me.Name = "FrmProductionPlanQuery"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "排程查询"
        Me.ExpandablePanelWhere.ResumeLayout(False)
        CType(Me.itxtRefreshInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProductionPlanItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExpandablePanelWhere As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dgvProductionPlanItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cboDept As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpInvoiceDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboLine As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtMOId As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents TimerRefreshQuery As System.Windows.Forms.Timer
    Friend WithEvents itxtRefreshInterval As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnVisibleColumn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ProductionPlanId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RowNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaterialNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptName As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
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
End Class
