<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductionPlanMaster
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
        Me.txtTransactionId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dtpInvoiceDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.cboDept = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txtRemark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtCreateUser = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtCheckUser = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtCheckTime = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
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
        Me.btnImportRow = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.btnDeleteRow = New DevComponents.DotNetBar.ButtonX()
        Me.btnInsertRow = New DevComponents.DotNetBar.ButtonX()
        Me.mtxtOrderNumber = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LinkLabelImportFile = New System.Windows.Forms.LinkLabel()
        Me.LinklblVisibleColumn = New System.Windows.Forms.LinkLabel()
        Me.btnExport = New DevComponents.DotNetBar.ButtonX()
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProductionPlanItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTransactionId
        '
        '
        '
        '
        Me.txtTransactionId.Border.Class = "TextBoxBorder"
        Me.txtTransactionId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTransactionId.Location = New System.Drawing.Point(420, 20)
        Me.txtTransactionId.Name = "txtTransactionId"
        Me.txtTransactionId.Size = New System.Drawing.Size(170, 21)
        Me.txtTransactionId.TabIndex = 200
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
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(94, 20)
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
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(170, 21)
        Me.dtpInvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpInvoiceDate.TabIndex = 198
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(24, 20)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 197
        Me.LabelX1.Text = "月     份"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(354, 20)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(82, 23)
        Me.LabelX4.TabIndex = 199
        Me.LabelX4.Text = "单     号"
        '
        'cboDept
        '
        Me.cboDept.DisplayMember = "Text"
        Me.cboDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.ItemHeight = 15
        Me.cboDept.Location = New System.Drawing.Point(762, 20)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(170, 21)
        Me.cboDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboDept.TabIndex = 207
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(691, 20)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 206
        Me.LabelX5.Text = "部     门"
        '
        'txtRemark
        '
        '
        '
        '
        Me.txtRemark.Border.Class = "TextBoxBorder"
        Me.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemark.Location = New System.Drawing.Point(94, 103)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(496, 21)
        Me.txtRemark.TabIndex = 209
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(24, 102)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 23)
        Me.LabelX9.TabIndex = 208
        Me.LabelX9.Text = "备     注"
        '
        'mtxtCreateUser
        '
        '
        '
        '
        Me.mtxtCreateUser.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtCreateUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtCreateUser.Location = New System.Drawing.Point(762, 104)
        Me.mtxtCreateUser.Name = "mtxtCreateUser"
        Me.mtxtCreateUser.ReadOnly = True
        Me.mtxtCreateUser.Size = New System.Drawing.Size(170, 21)
        Me.mtxtCreateUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtCreateUser.TabIndex = 211
        Me.mtxtCreateUser.Text = ""
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(692, 102)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 210
        Me.LabelX7.Text = "新  增 人"
        '
        'mtxtCheckUser
        '
        '
        '
        '
        Me.mtxtCheckUser.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtCheckUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtCheckUser.Location = New System.Drawing.Point(420, 63)
        Me.mtxtCheckUser.Name = "mtxtCheckUser"
        Me.mtxtCheckUser.ReadOnly = True
        Me.mtxtCheckUser.Size = New System.Drawing.Size(170, 21)
        Me.mtxtCheckUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtCheckUser.TabIndex = 215
        Me.mtxtCheckUser.Text = ""
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(354, 63)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 214
        Me.LabelX3.Text = "审  核 人"
        '
        'mtxtCheckTime
        '
        '
        '
        '
        Me.mtxtCheckTime.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtCheckTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtCheckTime.Location = New System.Drawing.Point(762, 61)
        Me.mtxtCheckTime.Name = "mtxtCheckTime"
        Me.mtxtCheckTime.ReadOnly = True
        Me.mtxtCheckTime.Size = New System.Drawing.Size(170, 21)
        Me.mtxtCheckTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtCheckTime.TabIndex = 217
        Me.mtxtCheckTime.Text = ""
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(692, 61)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 216
        Me.LabelX6.Text = "审核时间"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(24, 143)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(354, 23)
        Me.LabelX10.TabIndex = 220
        Me.LabelX10.Text = "▼导入排程计划,请参考[导入模板格式]文件,确保格式正确"
        '
        'dgvProductionPlanItem
        '
        Me.dgvProductionPlanItem.AllowUserToAddRows = False
        Me.dgvProductionPlanItem.AllowUserToDeleteRows = False
        Me.dgvProductionPlanItem.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionPlanItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductionPlanItem.ColumnHeadersHeight = 32
        Me.dgvProductionPlanItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProductionPlanItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductionPlanId, Me.RowNum, Me.MaterialNO, Me.MOId, Me.DeptName, Me.LineName, Me.ProductionQuantity, Me.CustomerName, Me.UnfinishedQuantity, Me.ExpectedDate, Me.SingleDay, Me.StandardWorkingHours, Me.ManpowerNumber, Me.Effectiveness, Me.EstimatedDays, Me.ExpectedCapacity, Me.ProductionDays, Me.WKone, Me.WKtwo, Me.NOYieldQuantity, Me.LineUserName, Me.Remark, Me.DailyWorkOne, Me.DailyWorkTwo, Me.DailyWorkThree, Me.DailyWorkFour, Me.DailyWorkFive, Me.DailyWorkSix, Me.DailyWorkSeven, Me.DailyWorkEight, Me.DailyWorkNine, Me.DailyWorkTen, Me.DailyWorkEleven, Me.DailyWorkTwelve, Me.DailyWorkThirteen, Me.DailyWorkFourteen, Me.DailyWorkFifteen, Me.DailyWorkSixteen, Me.DailyWorkSeveteen, Me.DailyWorkEighteen, Me.DailyWorkNineteen, Me.DailyWorkTwenty, Me.DailyWorkTwentyone, Me.DailyWorkTwentytwo, Me.DailyWorkTwentythree, Me.DailyWorkTwentyfour, Me.DailyWorkTwentyfive, Me.DailyWorkTwentysix, Me.DailyWorkTwentyseven, Me.DailyWorkTwentyeight, Me.DailyWorkTwentynine, Me.DailyWorkThirty, Me.DailyWorkThirtyone})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductionPlanItem.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProductionPlanItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvProductionPlanItem.EnableHeadersVisualStyles = False
        Me.dgvProductionPlanItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvProductionPlanItem.Location = New System.Drawing.Point(24, 173)
        Me.dgvProductionPlanItem.Name = "dgvProductionPlanItem"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionPlanItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProductionPlanItem.RowHeadersWidth = 15
        Me.dgvProductionPlanItem.RowTemplate.Height = 28
        Me.dgvProductionPlanItem.Size = New System.Drawing.Size(908, 279)
        Me.dgvProductionPlanItem.TabIndex = 221
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
        Me.MaterialNO.Width = 120
        '
        'MOId
        '
        Me.MOId.DataPropertyName = "MOId"
        Me.MOId.HeaderText = "工单"
        Me.MOId.Name = "MOId"
        Me.MOId.Width = 120
        '
        'DeptName
        '
        Me.DeptName.DataPropertyName = "DeptName"
        Me.DeptName.FillWeight = 80.0!
        Me.DeptName.HeaderText = "部门"
        Me.DeptName.Name = "DeptName"
        '
        'LineName
        '
        Me.LineName.DataPropertyName = "LineName"
        Me.LineName.HeaderText = "线别"
        Me.LineName.Name = "LineName"
        Me.LineName.Width = 60
        '
        'ProductionQuantity
        '
        Me.ProductionQuantity.DataPropertyName = "ProductionQuantity"
        Me.ProductionQuantity.HeaderText = "生产数量"
        Me.ProductionQuantity.Name = "ProductionQuantity"
        Me.ProductionQuantity.Width = 80
        '
        'CustomerName
        '
        Me.CustomerName.DataPropertyName = "CustomerName"
        Me.CustomerName.HeaderText = "客户名称"
        Me.CustomerName.Name = "CustomerName"
        Me.CustomerName.Width = 120
        '
        'UnfinishedQuantity
        '
        Me.UnfinishedQuantity.DataPropertyName = "UnfinishedQuantity"
        Me.UnfinishedQuantity.HeaderText = "未完成数量"
        Me.UnfinishedQuantity.Name = "UnfinishedQuantity"
        Me.UnfinishedQuantity.Width = 80
        '
        'ExpectedDate
        '
        Me.ExpectedDate.DataPropertyName = "ExpectedDate"
        Me.ExpectedDate.HeaderText = "预计开工日"
        Me.ExpectedDate.Name = "ExpectedDate"
        Me.ExpectedDate.Width = 80
        '
        'SingleDay
        '
        Me.SingleDay.DataPropertyName = "SingleDay"
        Me.SingleDay.HeaderText = "下单天数"
        Me.SingleDay.Name = "SingleDay"
        Me.SingleDay.Width = 60
        '
        'StandardWorkingHours
        '
        Me.StandardWorkingHours.DataPropertyName = "StandardWorkingHours"
        Me.StandardWorkingHours.HeaderText = "标准工时(秒)"
        Me.StandardWorkingHours.Name = "StandardWorkingHours"
        Me.StandardWorkingHours.Width = 60
        '
        'ManpowerNumber
        '
        Me.ManpowerNumber.DataPropertyName = "ManpowerNumber"
        Me.ManpowerNumber.HeaderText = "人力"
        Me.ManpowerNumber.Name = "ManpowerNumber"
        Me.ManpowerNumber.Width = 60
        '
        'Effectiveness
        '
        Me.Effectiveness.DataPropertyName = "Effectiveness"
        Me.Effectiveness.HeaderText = "效率"
        Me.Effectiveness.Name = "Effectiveness"
        Me.Effectiveness.Width = 60
        '
        'EstimatedDays
        '
        Me.EstimatedDays.DataPropertyName = "EstimatedDays"
        Me.EstimatedDays.HeaderText = "预计天数"
        Me.EstimatedDays.Name = "EstimatedDays"
        Me.EstimatedDays.Width = 60
        '
        'ExpectedCapacity
        '
        Me.ExpectedCapacity.DataPropertyName = "ExpectedCapacity"
        Me.ExpectedCapacity.HeaderText = "预计产能"
        Me.ExpectedCapacity.Name = "ExpectedCapacity"
        Me.ExpectedCapacity.Width = 80
        '
        'ProductionDays
        '
        Me.ProductionDays.DataPropertyName = "ProductionDays"
        Me.ProductionDays.HeaderText = "在制天数"
        Me.ProductionDays.Name = "ProductionDays"
        Me.ProductionDays.Width = 60
        '
        'WKone
        '
        Me.WKone.DataPropertyName = "WKone"
        Me.WKone.HeaderText = "WK1欠"
        Me.WKone.Name = "WKone"
        '
        'WKtwo
        '
        Me.WKtwo.DataPropertyName = "WKtwo"
        Me.WKtwo.HeaderText = "WK2欠"
        Me.WKtwo.Name = "WKtwo"
        Me.WKtwo.Width = 80
        '
        'NOYieldQuantity
        '
        Me.NOYieldQuantity.DataPropertyName = "NOYieldQuantity"
        Me.NOYieldQuantity.HeaderText = "未排量"
        Me.NOYieldQuantity.Name = "NOYieldQuantity"
        Me.NOYieldQuantity.Width = 80
        '
        'LineUserName
        '
        Me.LineUserName.DataPropertyName = "LineUserName"
        Me.LineUserName.HeaderText = "线长"
        Me.LineUserName.Name = "LineUserName"
        Me.LineUserName.Width = 80
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 120
        '
        'DailyWorkOne
        '
        Me.DailyWorkOne.DataPropertyName = "DailyWorkOne"
        Me.DailyWorkOne.HeaderText = "Column1"
        Me.DailyWorkOne.Name = "DailyWorkOne"
        Me.DailyWorkOne.Width = 50
        '
        'DailyWorkTwo
        '
        Me.DailyWorkTwo.DataPropertyName = "DailyWorkTwo"
        Me.DailyWorkTwo.FillWeight = 40.0!
        Me.DailyWorkTwo.HeaderText = "Column1"
        Me.DailyWorkTwo.Name = "DailyWorkTwo"
        Me.DailyWorkTwo.Width = 50
        '
        'DailyWorkThree
        '
        Me.DailyWorkThree.DataPropertyName = "DailyWorkThree"
        Me.DailyWorkThree.FillWeight = 40.0!
        Me.DailyWorkThree.HeaderText = "Column1"
        Me.DailyWorkThree.Name = "DailyWorkThree"
        Me.DailyWorkThree.Width = 50
        '
        'DailyWorkFour
        '
        Me.DailyWorkFour.DataPropertyName = "DailyWorkFour"
        Me.DailyWorkFour.FillWeight = 40.0!
        Me.DailyWorkFour.HeaderText = "Column1"
        Me.DailyWorkFour.Name = "DailyWorkFour"
        Me.DailyWorkFour.Width = 50
        '
        'DailyWorkFive
        '
        Me.DailyWorkFive.DataPropertyName = "DailyWorkFive"
        Me.DailyWorkFive.FillWeight = 40.0!
        Me.DailyWorkFive.HeaderText = "Column1"
        Me.DailyWorkFive.Name = "DailyWorkFive"
        Me.DailyWorkFive.Width = 50
        '
        'DailyWorkSix
        '
        Me.DailyWorkSix.DataPropertyName = "DailyWorkSix"
        Me.DailyWorkSix.FillWeight = 40.0!
        Me.DailyWorkSix.HeaderText = "Column1"
        Me.DailyWorkSix.Name = "DailyWorkSix"
        Me.DailyWorkSix.Width = 50
        '
        'DailyWorkSeven
        '
        Me.DailyWorkSeven.DataPropertyName = "DailyWorkSeven"
        Me.DailyWorkSeven.FillWeight = 40.0!
        Me.DailyWorkSeven.HeaderText = "Column1"
        Me.DailyWorkSeven.Name = "DailyWorkSeven"
        Me.DailyWorkSeven.Width = 50
        '
        'DailyWorkEight
        '
        Me.DailyWorkEight.DataPropertyName = "DailyWorkEight"
        Me.DailyWorkEight.FillWeight = 40.0!
        Me.DailyWorkEight.HeaderText = "Column1"
        Me.DailyWorkEight.Name = "DailyWorkEight"
        Me.DailyWorkEight.Width = 50
        '
        'DailyWorkNine
        '
        Me.DailyWorkNine.DataPropertyName = "DailyWorkNine"
        Me.DailyWorkNine.FillWeight = 40.0!
        Me.DailyWorkNine.HeaderText = "Column1"
        Me.DailyWorkNine.Name = "DailyWorkNine"
        Me.DailyWorkNine.Width = 50
        '
        'DailyWorkTen
        '
        Me.DailyWorkTen.DataPropertyName = "DailyWorkTen"
        Me.DailyWorkTen.FillWeight = 40.0!
        Me.DailyWorkTen.HeaderText = "Column1"
        Me.DailyWorkTen.Name = "DailyWorkTen"
        Me.DailyWorkTen.Width = 50
        '
        'DailyWorkEleven
        '
        Me.DailyWorkEleven.DataPropertyName = "DailyWorkEleven"
        Me.DailyWorkEleven.FillWeight = 40.0!
        Me.DailyWorkEleven.HeaderText = "Column1"
        Me.DailyWorkEleven.Name = "DailyWorkEleven"
        Me.DailyWorkEleven.Width = 50
        '
        'DailyWorkTwelve
        '
        Me.DailyWorkTwelve.DataPropertyName = "DailyWorkTwelve"
        Me.DailyWorkTwelve.FillWeight = 40.0!
        Me.DailyWorkTwelve.HeaderText = "Column1"
        Me.DailyWorkTwelve.Name = "DailyWorkTwelve"
        Me.DailyWorkTwelve.Width = 50
        '
        'DailyWorkThirteen
        '
        Me.DailyWorkThirteen.DataPropertyName = "DailyWorkThirteen"
        Me.DailyWorkThirteen.FillWeight = 40.0!
        Me.DailyWorkThirteen.HeaderText = "Column1"
        Me.DailyWorkThirteen.Name = "DailyWorkThirteen"
        Me.DailyWorkThirteen.Width = 50
        '
        'DailyWorkFourteen
        '
        Me.DailyWorkFourteen.DataPropertyName = "DailyWorkFourteen"
        Me.DailyWorkFourteen.FillWeight = 40.0!
        Me.DailyWorkFourteen.HeaderText = "Column1"
        Me.DailyWorkFourteen.Name = "DailyWorkFourteen"
        Me.DailyWorkFourteen.Width = 50
        '
        'DailyWorkFifteen
        '
        Me.DailyWorkFifteen.DataPropertyName = "DailyWorkFifteen"
        Me.DailyWorkFifteen.FillWeight = 40.0!
        Me.DailyWorkFifteen.HeaderText = "Column1"
        Me.DailyWorkFifteen.Name = "DailyWorkFifteen"
        Me.DailyWorkFifteen.Width = 50
        '
        'DailyWorkSixteen
        '
        Me.DailyWorkSixteen.DataPropertyName = "DailyWorkSixteen"
        Me.DailyWorkSixteen.FillWeight = 40.0!
        Me.DailyWorkSixteen.HeaderText = "Column1"
        Me.DailyWorkSixteen.Name = "DailyWorkSixteen"
        Me.DailyWorkSixteen.Width = 50
        '
        'DailyWorkSeveteen
        '
        Me.DailyWorkSeveteen.DataPropertyName = "DailyWorkSeveteen"
        Me.DailyWorkSeveteen.FillWeight = 40.0!
        Me.DailyWorkSeveteen.HeaderText = "Column1"
        Me.DailyWorkSeveteen.Name = "DailyWorkSeveteen"
        Me.DailyWorkSeveteen.Width = 50
        '
        'DailyWorkEighteen
        '
        Me.DailyWorkEighteen.DataPropertyName = "DailyWorkEighteen"
        Me.DailyWorkEighteen.FillWeight = 40.0!
        Me.DailyWorkEighteen.HeaderText = "Column1"
        Me.DailyWorkEighteen.Name = "DailyWorkEighteen"
        Me.DailyWorkEighteen.Width = 50
        '
        'DailyWorkNineteen
        '
        Me.DailyWorkNineteen.DataPropertyName = "DailyWorkNineteen"
        Me.DailyWorkNineteen.FillWeight = 40.0!
        Me.DailyWorkNineteen.HeaderText = "Column1"
        Me.DailyWorkNineteen.Name = "DailyWorkNineteen"
        Me.DailyWorkNineteen.Width = 50
        '
        'DailyWorkTwenty
        '
        Me.DailyWorkTwenty.DataPropertyName = "DailyWorkTwenty"
        Me.DailyWorkTwenty.FillWeight = 40.0!
        Me.DailyWorkTwenty.HeaderText = "Column1"
        Me.DailyWorkTwenty.Name = "DailyWorkTwenty"
        Me.DailyWorkTwenty.Width = 50
        '
        'DailyWorkTwentyone
        '
        Me.DailyWorkTwentyone.DataPropertyName = "DailyWorkTwentyone"
        Me.DailyWorkTwentyone.FillWeight = 40.0!
        Me.DailyWorkTwentyone.HeaderText = "Column1"
        Me.DailyWorkTwentyone.Name = "DailyWorkTwentyone"
        Me.DailyWorkTwentyone.Width = 50
        '
        'DailyWorkTwentytwo
        '
        Me.DailyWorkTwentytwo.DataPropertyName = "DailyWorkTwentytwo"
        Me.DailyWorkTwentytwo.FillWeight = 40.0!
        Me.DailyWorkTwentytwo.HeaderText = "Column1"
        Me.DailyWorkTwentytwo.Name = "DailyWorkTwentytwo"
        Me.DailyWorkTwentytwo.Width = 50
        '
        'DailyWorkTwentythree
        '
        Me.DailyWorkTwentythree.DataPropertyName = "DailyWorkTwentythree"
        Me.DailyWorkTwentythree.FillWeight = 40.0!
        Me.DailyWorkTwentythree.HeaderText = "Column1"
        Me.DailyWorkTwentythree.Name = "DailyWorkTwentythree"
        Me.DailyWorkTwentythree.Width = 50
        '
        'DailyWorkTwentyfour
        '
        Me.DailyWorkTwentyfour.DataPropertyName = "DailyWorkTwentyfour"
        Me.DailyWorkTwentyfour.FillWeight = 40.0!
        Me.DailyWorkTwentyfour.HeaderText = "Column1"
        Me.DailyWorkTwentyfour.Name = "DailyWorkTwentyfour"
        Me.DailyWorkTwentyfour.Width = 50
        '
        'DailyWorkTwentyfive
        '
        Me.DailyWorkTwentyfive.DataPropertyName = "DailyWorkTwentyfive"
        Me.DailyWorkTwentyfive.FillWeight = 40.0!
        Me.DailyWorkTwentyfive.HeaderText = "Column1"
        Me.DailyWorkTwentyfive.Name = "DailyWorkTwentyfive"
        Me.DailyWorkTwentyfive.Width = 50
        '
        'DailyWorkTwentysix
        '
        Me.DailyWorkTwentysix.DataPropertyName = "DailyWorkTwentysix"
        Me.DailyWorkTwentysix.FillWeight = 40.0!
        Me.DailyWorkTwentysix.HeaderText = "Column1"
        Me.DailyWorkTwentysix.Name = "DailyWorkTwentysix"
        Me.DailyWorkTwentysix.Width = 50
        '
        'DailyWorkTwentyseven
        '
        Me.DailyWorkTwentyseven.DataPropertyName = "DailyWorkTwentyseven"
        Me.DailyWorkTwentyseven.FillWeight = 40.0!
        Me.DailyWorkTwentyseven.HeaderText = "Column1"
        Me.DailyWorkTwentyseven.Name = "DailyWorkTwentyseven"
        Me.DailyWorkTwentyseven.Width = 50
        '
        'DailyWorkTwentyeight
        '
        Me.DailyWorkTwentyeight.DataPropertyName = "DailyWorkTwentyeight"
        Me.DailyWorkTwentyeight.FillWeight = 40.0!
        Me.DailyWorkTwentyeight.HeaderText = "Column1"
        Me.DailyWorkTwentyeight.Name = "DailyWorkTwentyeight"
        Me.DailyWorkTwentyeight.Width = 50
        '
        'DailyWorkTwentynine
        '
        Me.DailyWorkTwentynine.DataPropertyName = "DailyWorkTwentynine"
        Me.DailyWorkTwentynine.FillWeight = 40.0!
        Me.DailyWorkTwentynine.HeaderText = "Column1"
        Me.DailyWorkTwentynine.Name = "DailyWorkTwentynine"
        Me.DailyWorkTwentynine.Width = 50
        '
        'DailyWorkThirty
        '
        Me.DailyWorkThirty.DataPropertyName = "DailyWorkThirty"
        Me.DailyWorkThirty.FillWeight = 40.0!
        Me.DailyWorkThirty.HeaderText = "Column1"
        Me.DailyWorkThirty.Name = "DailyWorkThirty"
        Me.DailyWorkThirty.Width = 50
        '
        'DailyWorkThirtyone
        '
        Me.DailyWorkThirtyone.DataPropertyName = "DailyWorkThirtyone"
        Me.DailyWorkThirtyone.FillWeight = 40.0!
        Me.DailyWorkThirtyone.HeaderText = "Column1"
        Me.DailyWorkThirtyone.Name = "DailyWorkThirtyone"
        Me.DailyWorkThirtyone.Width = 50
        '
        'btnImportRow
        '
        Me.btnImportRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnImportRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnImportRow.Location = New System.Drawing.Point(941, 293)
        Me.btnImportRow.Name = "btnImportRow"
        Me.btnImportRow.Size = New System.Drawing.Size(75, 23)
        Me.btnImportRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnImportRow.TabIndex = 222
        Me.btnImportRow.Text = "导  入"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(775, 468)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 224
        Me.btnCancel.Text = "取  消"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(634, 468)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSave.TabIndex = 223
        Me.btnSave.Text = "保  存"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(24, 468)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(604, 23)
        Me.lblMessage.TabIndex = 225
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDeleteRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDeleteRow.Location = New System.Drawing.Point(941, 244)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDeleteRow.TabIndex = 227
        Me.btnDeleteRow.Text = "删除作废"
        '
        'btnInsertRow
        '
        Me.btnInsertRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnInsertRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnInsertRow.Location = New System.Drawing.Point(941, 195)
        Me.btnInsertRow.Name = "btnInsertRow"
        Me.btnInsertRow.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnInsertRow.TabIndex = 226
        Me.btnInsertRow.Text = "增    加"
        '
        'mtxtOrderNumber
        '
        '
        '
        '
        Me.mtxtOrderNumber.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtOrderNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtOrderNumber.Location = New System.Drawing.Point(94, 63)
        Me.mtxtOrderNumber.Name = "mtxtOrderNumber"
        Me.mtxtOrderNumber.ReadOnly = True
        Me.mtxtOrderNumber.Size = New System.Drawing.Size(170, 21)
        Me.mtxtOrderNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtOrderNumber.TabIndex = 229
        Me.mtxtOrderNumber.Text = ""
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(24, 61)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 228
        Me.LabelX2.Text = "订  单 号"
        '
        'LinkLabelImportFile
        '
        Me.LinkLabelImportFile.AutoSize = True
        Me.LinkLabelImportFile.Location = New System.Drawing.Point(773, 149)
        Me.LinkLabelImportFile.Name = "LinkLabelImportFile"
        Me.LinkLabelImportFile.Size = New System.Drawing.Size(77, 12)
        Me.LinkLabelImportFile.TabIndex = 230
        Me.LinkLabelImportFile.TabStop = True
        Me.LinkLabelImportFile.Text = "导入模版格式"
        '
        'LinklblVisibleColumn
        '
        Me.LinklblVisibleColumn.AutoSize = True
        Me.LinklblVisibleColumn.Location = New System.Drawing.Point(879, 149)
        Me.LinklblVisibleColumn.Name = "LinklblVisibleColumn"
        Me.LinklblVisibleColumn.Size = New System.Drawing.Size(53, 12)
        Me.LinklblVisibleColumn.TabIndex = 232
        Me.LinklblVisibleColumn.TabStop = True
        Me.LinklblVisibleColumn.Text = "字段显示"
        '
        'btnExport
        '
        Me.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExport.Location = New System.Drawing.Point(941, 345)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExport.TabIndex = 233
        Me.btnExport.Text = "导  出"
        '
        'FrmProductionPlanMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 506)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.LinklblVisibleColumn)
        Me.Controls.Add(Me.LinkLabelImportFile)
        Me.Controls.Add(Me.mtxtOrderNumber)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.btnDeleteRow)
        Me.Controls.Add(Me.btnInsertRow)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnImportRow)
        Me.Controls.Add(Me.dgvProductionPlanItem)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.mtxtCheckTime)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.mtxtCheckUser)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.mtxtCreateUser)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.cboDept)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.txtTransactionId)
        Me.Controls.Add(Me.dtpInvoiceDate)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductionPlanMaster"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生产排产单"
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProductionPlanItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtTransactionId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dtpInvoiceDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboDept As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtRemark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtCreateUser As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtCheckUser As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtCheckTime As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvProductionPlanItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnImportRow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnDeleteRow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnInsertRow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents mtxtOrderNumber As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LinkLabelImportFile As System.Windows.Forms.LinkLabel
    Friend WithEvents LinklblVisibleColumn As System.Windows.Forms.LinkLabel
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonX
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
