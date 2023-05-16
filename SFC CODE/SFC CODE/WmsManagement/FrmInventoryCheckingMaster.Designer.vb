<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInventoryCheckingMaster
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.dtpInvoiceDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.cboWarehouse = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtTransactionId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.txtRemark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.dgvInventroyCheckingItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Specification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProfitQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LossQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BookPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnStick = New DevComponents.DotNetBar.ButtonX()
        Me.btnSelectmaterial = New DevComponents.DotNetBar.ButtonX()
        Me.btnBarcodeInput = New DevComponents.DotNetBar.ButtonX()
        Me.btnDeleteRow = New DevComponents.DotNetBar.ButtonX()
        Me.btnInsertRow = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.cboInvoiceTransactionType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtAttentionName = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
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
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventroyCheckingItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Blue
        Me.LabelX1.Location = New System.Drawing.Point(18, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(579, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "注意：盘点单中只记录盘点结果有差异的情况，盘点前的货品列表建议导出成品列表或月报表进行打印"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(18, 49)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "日    期"
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
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(86, 49)
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
        Me.dtpInvoiceDate.MonthCalendar.DisplayMonth = New Date(2015, 8, 1, 0, 0, 0, 0)
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
        Me.dtpInvoiceDate.TabIndex = 2
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(623, 49)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 3
        Me.LabelX3.Text = "仓    库"
        '
        'cboWarehouse
        '
        Me.cboWarehouse.DisplayMember = "Text"
        Me.cboWarehouse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWarehouse.FormattingEnabled = True
        Me.cboWarehouse.ItemHeight = 15
        Me.cboWarehouse.Location = New System.Drawing.Point(692, 49)
        Me.cboWarehouse.Name = "cboWarehouse"
        Me.cboWarehouse.Size = New System.Drawing.Size(170, 21)
        Me.cboWarehouse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboWarehouse.TabIndex = 4
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(316, 49)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "单    号"
        '
        'txtTransactionId
        '
        '
        '
        '
        Me.txtTransactionId.Border.Class = "TextBoxBorder"
        Me.txtTransactionId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTransactionId.Location = New System.Drawing.Point(385, 49)
        Me.txtTransactionId.Name = "txtTransactionId"
        Me.txtTransactionId.Size = New System.Drawing.Size(170, 21)
        Me.txtTransactionId.TabIndex = 6
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(18, 86)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 7
        Me.LabelX5.Text = "经 办 人"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(317, 90)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 9
        Me.LabelX6.Text = "备    注"
        '
        'txtRemark
        '
        '
        '
        '
        Me.txtRemark.Border.Class = "TextBoxBorder"
        Me.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemark.Location = New System.Drawing.Point(385, 90)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(477, 21)
        Me.txtRemark.TabIndex = 10
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(13, 123)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(308, 23)
        Me.LabelX7.TabIndex = 11
        Me.LabelX7.Text = "输入料号编码查找货品或点击右侧""选择货品"""
        '
        'dgvInventroyCheckingItem
        '
        Me.dgvInventroyCheckingItem.AllowUserToAddRows = False
        Me.dgvInventroyCheckingItem.AllowUserToDeleteRows = False
        Me.dgvInventroyCheckingItem.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvInventroyCheckingItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventroyCheckingItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventroyCheckingItem.ColumnHeadersHeight = 32
        Me.dgvInventroyCheckingItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInventroyCheckingItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemId, Me.TransactionType, Me.MaterialNO, Me.Description, Me.Specification, Me.UOM_NAME, Me.BookQuantity, Me.CheckQuantity, Me.ProfitQuantity, Me.LossQuantity, Me.BookPrice, Me.UnitPrice, Me.TotalAmount, Me.Remark})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInventroyCheckingItem.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvInventroyCheckingItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvInventroyCheckingItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvInventroyCheckingItem.Location = New System.Drawing.Point(13, 152)
        Me.dgvInventroyCheckingItem.Name = "dgvInventroyCheckingItem"
        Me.dgvInventroyCheckingItem.RowHeadersWidth = 15
        Me.dgvInventroyCheckingItem.RowTemplate.Height = 28
        Me.dgvInventroyCheckingItem.Size = New System.Drawing.Size(849, 295)
        Me.dgvInventroyCheckingItem.TabIndex = 12
        '
        'ItemId
        '
        Me.ItemId.DataPropertyName = "ItemId"
        Me.ItemId.HeaderText = "ItemId"
        Me.ItemId.Name = "ItemId"
        Me.ItemId.ReadOnly = True
        Me.ItemId.Visible = False
        '
        'TransactionType
        '
        Me.TransactionType.DataPropertyName = "TransactionType"
        Me.TransactionType.HeaderText = "TransactionType"
        Me.TransactionType.Name = "TransactionType"
        Me.TransactionType.ReadOnly = True
        Me.TransactionType.Visible = False
        '
        'MaterialNO
        '
        Me.MaterialNO.DataPropertyName = "MaterialNO"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
        Me.MaterialNO.DefaultCellStyle = DataGridViewCellStyle2
        Me.MaterialNO.HeaderText = "料号"
        Me.MaterialNO.Name = "MaterialNO"
        Me.MaterialNO.ReadOnly = True
        Me.MaterialNO.Width = 110
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray
        Me.Description.DefaultCellStyle = DataGridViewCellStyle3
        Me.Description.HeaderText = "品名"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'Specification
        '
        Me.Specification.DataPropertyName = "Specification"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray
        Me.Specification.DefaultCellStyle = DataGridViewCellStyle4
        Me.Specification.HeaderText = "规格"
        Me.Specification.Name = "Specification"
        Me.Specification.ReadOnly = True
        '
        'UOM_NAME
        '
        Me.UOM_NAME.DataPropertyName = "UOM_NAME"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray
        Me.UOM_NAME.DefaultCellStyle = DataGridViewCellStyle5
        Me.UOM_NAME.HeaderText = "单位"
        Me.UOM_NAME.Name = "UOM_NAME"
        Me.UOM_NAME.ReadOnly = True
        Me.UOM_NAME.Width = 35
        '
        'BookQuantity
        '
        Me.BookQuantity.DataPropertyName = "STOCKQUANTITY"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray
        Me.BookQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.BookQuantity.HeaderText = "账面数量"
        Me.BookQuantity.Name = "BookQuantity"
        Me.BookQuantity.ReadOnly = True
        Me.BookQuantity.Width = 60
        '
        'CheckQuantity
        '
        Me.CheckQuantity.DataPropertyName = "CheckQuantity"
        Me.CheckQuantity.HeaderText = "盘点数量"
        Me.CheckQuantity.Name = "CheckQuantity"
        Me.CheckQuantity.Width = 60
        '
        'ProfitQuantity
        '
        Me.ProfitQuantity.DataPropertyName = "ProfitQuantity"
        Me.ProfitQuantity.HeaderText = "盈"
        Me.ProfitQuantity.Name = "ProfitQuantity"
        Me.ProfitQuantity.Width = 60
        '
        'LossQuantity
        '
        Me.LossQuantity.DataPropertyName = "LossQuantity"
        Me.LossQuantity.HeaderText = "亏"
        Me.LossQuantity.Name = "LossQuantity"
        Me.LossQuantity.Width = 60
        '
        'BookPrice
        '
        Me.BookPrice.DataPropertyName = "BookPrice"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        Me.BookPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.BookPrice.HeaderText = "账面单价"
        Me.BookPrice.Name = "BookPrice"
        Me.BookPrice.ReadOnly = True
        Me.BookPrice.Width = 40
        '
        'UnitPrice
        '
        Me.UnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray
        Me.UnitPrice.DefaultCellStyle = DataGridViewCellStyle8
        Me.UnitPrice.HeaderText = "盘点单价"
        Me.UnitPrice.Name = "UnitPrice"
        Me.UnitPrice.ReadOnly = True
        Me.UnitPrice.Width = 40
        '
        'TotalAmount
        '
        Me.TotalAmount.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGray
        Me.TotalAmount.DefaultCellStyle = DataGridViewCellStyle9
        Me.TotalAmount.HeaderText = "总金额"
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.ReadOnly = True
        Me.TotalAmount.Width = 80
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 86
        '
        'btnStick
        '
        Me.btnStick.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnStick.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnStick.Location = New System.Drawing.Point(872, 378)
        Me.btnStick.Name = "btnStick"
        Me.btnStick.Size = New System.Drawing.Size(75, 23)
        Me.btnStick.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnStick.TabIndex = 39
        Me.btnStick.Text = "批量粘贴"
        '
        'btnSelectmaterial
        '
        Me.btnSelectmaterial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSelectmaterial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSelectmaterial.Location = New System.Drawing.Point(872, 193)
        Me.btnSelectmaterial.Name = "btnSelectmaterial"
        Me.btnSelectmaterial.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectmaterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSelectmaterial.TabIndex = 38
        Me.btnSelectmaterial.Text = "选择料号"
        '
        'btnBarcodeInput
        '
        Me.btnBarcodeInput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBarcodeInput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBarcodeInput.Location = New System.Drawing.Point(872, 334)
        Me.btnBarcodeInput.Name = "btnBarcodeInput"
        Me.btnBarcodeInput.Size = New System.Drawing.Size(75, 23)
        Me.btnBarcodeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBarcodeInput.TabIndex = 37
        Me.btnBarcodeInput.Text = "条码录入"
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDeleteRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDeleteRow.Location = New System.Drawing.Point(872, 287)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDeleteRow.TabIndex = 36
        Me.btnDeleteRow.Text = "删除行"
        '
        'btnInsertRow
        '
        Me.btnInsertRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnInsertRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnInsertRow.Location = New System.Drawing.Point(872, 240)
        Me.btnInsertRow.Name = "btnInsertRow"
        Me.btnInsertRow.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnInsertRow.TabIndex = 35
        Me.btnInsertRow.Text = "增加行"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(773, 462)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 41
        Me.btnCancel.Text = "取  消"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(596, 462)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSave.TabIndex = 40
        Me.btnSave.Text = "保  存"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(15, 462)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(419, 23)
        Me.lblMessage.TabIndex = 45
        '
        'cboInvoiceTransactionType
        '
        Me.cboInvoiceTransactionType.DisplayMember = "Text"
        Me.cboInvoiceTransactionType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboInvoiceTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInvoiceTransactionType.FormattingEnabled = True
        Me.cboInvoiceTransactionType.ItemHeight = 15
        Me.cboInvoiceTransactionType.Location = New System.Drawing.Point(692, 12)
        Me.cboInvoiceTransactionType.Name = "cboInvoiceTransactionType"
        Me.cboInvoiceTransactionType.Size = New System.Drawing.Size(170, 21)
        Me.cboInvoiceTransactionType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboInvoiceTransactionType.TabIndex = 47
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(623, 12)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 23)
        Me.LabelX9.TabIndex = 46
        Me.LabelX9.Text = "单据类型"
        '
        'mtxtAttentionName
        '
        '
        '
        '
        Me.mtxtAttentionName.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtAttentionName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtAttentionName.ButtonCustom.Visible = True
        Me.mtxtAttentionName.Location = New System.Drawing.Point(86, 88)
        Me.mtxtAttentionName.Name = "mtxtAttentionName"
        Me.mtxtAttentionName.ReadOnly = True
        Me.mtxtAttentionName.Size = New System.Drawing.Size(170, 21)
        Me.mtxtAttentionName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtAttentionName.TabIndex = 49
        Me.mtxtAttentionName.Text = ""
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(317, 123)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 23)
        Me.LabelX8.TabIndex = 50
        Me.LabelX8.Text = "盘点金额"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(385, 125)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(245, 16)
        Me.RadioButton1.TabIndex = 51
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "盘点金额按盘点数量*当前成品价自动计算"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(692, 125)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(119, 16)
        Me.RadioButton2.TabIndex = 52
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "库存金额手工输入"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "InventoryCheckingItemId"
        Me.DataGridViewTextBoxColumn1.HeaderText = "InventoryCheckingItemId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "MaterialNO"
        Me.DataGridViewTextBoxColumn2.HeaderText = "料号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 110
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn3.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Specification"
        Me.DataGridViewTextBoxColumn4.HeaderText = "规格"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "UOM_NAME"
        Me.DataGridViewTextBoxColumn5.HeaderText = "单位"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 50
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "QUANTITY"
        Me.DataGridViewTextBoxColumn6.HeaderText = "账面数量"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 50
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "CheckQuantity"
        Me.DataGridViewTextBoxColumn7.HeaderText = "盘点数量"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 50
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "ProfitQuantity"
        Me.DataGridViewTextBoxColumn8.HeaderText = "盈"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 70
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "LossQuantity"
        Me.DataGridViewTextBoxColumn9.HeaderText = "亏"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 70
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "BookPrice"
        Me.DataGridViewTextBoxColumn10.HeaderText = "账面单价"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 50
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "UnitPrice"
        Me.DataGridViewTextBoxColumn11.HeaderText = "盘点单价"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 50
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "TotalAmount"
        Me.DataGridViewTextBoxColumn12.HeaderText = "总金额"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 60
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Remark"
        Me.DataGridViewTextBoxColumn13.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 80
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Remark"
        Me.DataGridViewTextBoxColumn14.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 150
        '
        'FrmInventoryCheckingMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 496)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.mtxtAttentionName)
        Me.Controls.Add(Me.cboInvoiceTransactionType)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnStick)
        Me.Controls.Add(Me.btnSelectmaterial)
        Me.Controls.Add(Me.btnBarcodeInput)
        Me.Controls.Add(Me.btnDeleteRow)
        Me.Controls.Add(Me.btnInsertRow)
        Me.Controls.Add(Me.dgvInventroyCheckingItem)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.txtTransactionId)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.cboWarehouse)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.dtpInvoiceDate)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInventoryCheckingMaster"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "盘点单"
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventroyCheckingItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpInvoiceDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboWarehouse As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtTransactionId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtRemark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvInventroyCheckingItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnStick As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSelectmaterial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBarcodeInput As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDeleteRow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnInsertRow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboInvoiceTransactionType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
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
    Friend WithEvents mtxtAttentionName As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaterialNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Specification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProfitQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LossQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
