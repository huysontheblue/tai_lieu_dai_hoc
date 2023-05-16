<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReworkMaster
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
        Me.txtTransactionId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.dtpInvoiceDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.cboDept = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.mtxtAttentionName = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.txtRemark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtDelivery = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.dgvReworkItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingSame = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MATERIALNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPECIFICATION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUANTITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNITPRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REMARK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnStick = New DevComponents.DotNetBar.ButtonX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.btnSelectmaterial = New DevComponents.DotNetBar.ButtonX()
        Me.btnBarcodeInput = New DevComponents.DotNetBar.ButtonX()
        Me.btnDeleteRow = New DevComponents.DotNetBar.ButtonX()
        Me.btnInsertRow = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.cboTransactionType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtOrderNumber = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
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
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReworkItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTransactionId
        '
        '
        '
        '
        Me.txtTransactionId.Border.Class = "TextBoxBorder"
        Me.txtTransactionId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTransactionId.Location = New System.Drawing.Point(389, 60)
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
        Me.dtpInvoiceDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpInvoiceDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpInvoiceDate.IsPopupCalendarOpen = False
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(86, 58)
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
        Me.LabelX1.Location = New System.Drawing.Point(14, 58)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 197
        Me.LabelX1.Text = "日     期"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(319, 58)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(82, 23)
        Me.LabelX4.TabIndex = 199
        Me.LabelX4.Text = "单     号"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(14, 19)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(608, 23)
        Me.LabelX10.TabIndex = 201
        Me.LabelX10.Text = "▼已入库未出货请选择重工类型，已出货请选择退货类型"
        '
        'cboDept
        '
        Me.cboDept.DisplayMember = "Text"
        Me.cboDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.ItemHeight = 15
        Me.cboDept.Location = New System.Drawing.Point(389, 101)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(170, 21)
        Me.cboDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboDept.TabIndex = 213
        '
        'mtxtAttentionName
        '
        '
        '
        '
        Me.mtxtAttentionName.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtAttentionName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtAttentionName.ButtonCustom.Visible = True
        Me.mtxtAttentionName.Location = New System.Drawing.Point(85, 101)
        Me.mtxtAttentionName.Name = "mtxtAttentionName"
        Me.mtxtAttentionName.ReadOnly = True
        Me.mtxtAttentionName.Size = New System.Drawing.Size(170, 21)
        Me.mtxtAttentionName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtAttentionName.TabIndex = 212
        Me.mtxtAttentionName.Text = ""
        '
        'txtRemark
        '
        '
        '
        '
        Me.txtRemark.Border.Class = "TextBoxBorder"
        Me.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemark.Location = New System.Drawing.Point(85, 142)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(770, 21)
        Me.txtRemark.TabIndex = 211
        '
        'CheckBoxX1
        '
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.Location = New System.Drawing.Point(565, 172)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(226, 23)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 209
        Me.CheckBoxX1.Text = "启用计量单位换算(如1箱=10个）"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(16, 171)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(354, 23)
        Me.LabelX2.TabIndex = 208
        Me.LabelX2.Text = "▼下方输入料号编码或右侧""选择料号""或""条码录入"""
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(14, 140)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 23)
        Me.LabelX9.TabIndex = 207
        Me.LabelX9.Text = "备     注"
        '
        'mtxtDelivery
        '
        '
        '
        '
        Me.mtxtDelivery.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtDelivery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtDelivery.ButtonCustom.Visible = True
        Me.mtxtDelivery.Location = New System.Drawing.Point(685, 99)
        Me.mtxtDelivery.Name = "mtxtDelivery"
        Me.mtxtDelivery.ReadOnly = True
        Me.mtxtDelivery.Size = New System.Drawing.Size(170, 21)
        Me.mtxtDelivery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtDelivery.TabIndex = 206
        Me.mtxtDelivery.Text = ""
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(616, 58)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 23)
        Me.LabelX8.TabIndex = 217
        Me.LabelX8.Text = "订  单 号"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(14, 99)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 216
        Me.LabelX7.Text = "经  办 人"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(319, 101)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 214
        Me.LabelX5.Text = "部     门"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(616, 99)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 215
        Me.LabelX6.Text = "接  收 人"
        '
        'dgvReworkItem
        '
        Me.dgvReworkItem.AllowUserToAddRows = False
        Me.dgvReworkItem.AllowUserToDeleteRows = False
        Me.dgvReworkItem.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReworkItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReworkItem.ColumnHeadersHeight = 32
        Me.dgvReworkItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvReworkItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemId, Me.TransactionType, Me.PackingSame, Me.MATERIALNO, Me.DESCRIPTION, Me.SPECIFICATION, Me.UOM_NAME, Me.QUANTITY, Me.UNITPRICE, Me.TotalAmount, Me.OrderNumber, Me.REMARK})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReworkItem.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvReworkItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvReworkItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvReworkItem.Location = New System.Drawing.Point(14, 201)
        Me.dgvReworkItem.Name = "dgvReworkItem"
        Me.dgvReworkItem.RowHeadersWidth = 15
        Me.dgvReworkItem.RowTemplate.Height = 28
        Me.dgvReworkItem.Size = New System.Drawing.Size(843, 232)
        Me.dgvReworkItem.TabIndex = 218
        '
        'ItemId
        '
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
        'PackingSame
        '
        Me.PackingSame.DataPropertyName = "PackingSame"
        Me.PackingSame.HeaderText = "PackingSame"
        Me.PackingSame.Name = "PackingSame"
        Me.PackingSame.ReadOnly = True
        Me.PackingSame.Visible = False
        '
        'MATERIALNO
        '
        Me.MATERIALNO.DataPropertyName = "MATERIALNO"
        Me.MATERIALNO.HeaderText = "料号"
        Me.MATERIALNO.Name = "MATERIALNO"
        Me.MATERIALNO.ReadOnly = True
        Me.MATERIALNO.Width = 150
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.DataPropertyName = "DESCRIPTION"
        Me.DESCRIPTION.HeaderText = "描述"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.ReadOnly = True
        Me.DESCRIPTION.Width = 140
        '
        'SPECIFICATION
        '
        Me.SPECIFICATION.DataPropertyName = "SPECIFICATION"
        Me.SPECIFICATION.HeaderText = "规格"
        Me.SPECIFICATION.Name = "SPECIFICATION"
        Me.SPECIFICATION.ReadOnly = True
        '
        'UOM_NAME
        '
        Me.UOM_NAME.DataPropertyName = "UOM_NAME"
        Me.UOM_NAME.HeaderText = "单位"
        Me.UOM_NAME.Name = "UOM_NAME"
        Me.UOM_NAME.ReadOnly = True
        Me.UOM_NAME.Width = 60
        '
        'QUANTITY
        '
        Me.QUANTITY.DataPropertyName = "QUANTITY"
        Me.QUANTITY.HeaderText = "数量"
        Me.QUANTITY.Name = "QUANTITY"
        Me.QUANTITY.ReadOnly = True
        Me.QUANTITY.Width = 80
        '
        'UNITPRICE
        '
        Me.UNITPRICE.DataPropertyName = "UNITPRICE"
        Me.UNITPRICE.HeaderText = "单价"
        Me.UNITPRICE.Name = "UNITPRICE"
        Me.UNITPRICE.ReadOnly = True
        Me.UNITPRICE.Width = 60
        '
        'TotalAmount
        '
        Me.TotalAmount.DataPropertyName = "TotalAmount"
        Me.TotalAmount.HeaderText = "金额"
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.ReadOnly = True
        Me.TotalAmount.Width = 80
        '
        'OrderNumber
        '
        Me.OrderNumber.DataPropertyName = "OrderNumber"
        Me.OrderNumber.HeaderText = "订单号"
        Me.OrderNumber.Name = "OrderNumber"
        Me.OrderNumber.Width = 120
        '
        'REMARK
        '
        Me.REMARK.DataPropertyName = "REMARK"
        Me.REMARK.HeaderText = "说明"
        Me.REMARK.Name = "REMARK"
        '
        'btnStick
        '
        Me.btnStick.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnStick.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnStick.Location = New System.Drawing.Point(867, 385)
        Me.btnStick.Name = "btnStick"
        Me.btnStick.Size = New System.Drawing.Size(75, 23)
        Me.btnStick.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnStick.TabIndex = 226
        Me.btnStick.Text = "批量粘贴"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(16, 454)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(543, 23)
        Me.lblMessage.TabIndex = 225
        '
        'btnSelectmaterial
        '
        Me.btnSelectmaterial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSelectmaterial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSelectmaterial.Location = New System.Drawing.Point(867, 200)
        Me.btnSelectmaterial.Name = "btnSelectmaterial"
        Me.btnSelectmaterial.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectmaterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSelectmaterial.TabIndex = 224
        Me.btnSelectmaterial.Text = "选择料号"
        '
        'btnBarcodeInput
        '
        Me.btnBarcodeInput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBarcodeInput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBarcodeInput.Location = New System.Drawing.Point(867, 341)
        Me.btnBarcodeInput.Name = "btnBarcodeInput"
        Me.btnBarcodeInput.Size = New System.Drawing.Size(75, 23)
        Me.btnBarcodeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBarcodeInput.TabIndex = 223
        Me.btnBarcodeInput.Text = "条码录入"
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDeleteRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDeleteRow.Location = New System.Drawing.Point(867, 294)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDeleteRow.TabIndex = 222
        Me.btnDeleteRow.Text = "删除行"
        '
        'btnInsertRow
        '
        Me.btnInsertRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnInsertRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnInsertRow.Location = New System.Drawing.Point(867, 247)
        Me.btnInsertRow.Name = "btnInsertRow"
        Me.btnInsertRow.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnInsertRow.TabIndex = 221
        Me.btnInsertRow.Text = "增加行"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(723, 454)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 220
        Me.btnCancel.Text = "取  消"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(582, 454)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSave.TabIndex = 219
        Me.btnSave.Text = "保  存"
        '
        'cboTransactionType
        '
        Me.cboTransactionType.DisplayMember = "Text"
        Me.cboTransactionType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransactionType.FormattingEnabled = True
        Me.cboTransactionType.ItemHeight = 15
        Me.cboTransactionType.Location = New System.Drawing.Point(685, 19)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.Size = New System.Drawing.Size(170, 21)
        Me.cboTransactionType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboTransactionType.TabIndex = 227
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(616, 19)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 228
        Me.LabelX3.Text = "类     型"
        '
        'mtxtOrderNumber
        '
        '
        '
        '
        Me.mtxtOrderNumber.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtOrderNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtOrderNumber.ButtonCustom.Visible = True
        Me.mtxtOrderNumber.Location = New System.Drawing.Point(685, 59)
        Me.mtxtOrderNumber.Name = "mtxtOrderNumber"
        Me.mtxtOrderNumber.ReadOnly = True
        Me.mtxtOrderNumber.Size = New System.Drawing.Size(170, 21)
        Me.mtxtOrderNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtOrderNumber.TabIndex = 229
        Me.mtxtOrderNumber.Text = ""
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ItemId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "TransactionType"
        Me.DataGridViewTextBoxColumn2.HeaderText = "TransactionType"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PackingSame"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PackingSame"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "MATERIALNO"
        Me.DataGridViewTextBoxColumn4.HeaderText = "料号"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "DESCRIPTION"
        Me.DataGridViewTextBoxColumn5.HeaderText = "描述"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 140
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "SPECIFICATION"
        Me.DataGridViewTextBoxColumn6.HeaderText = "规格"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "UOM_NAME"
        Me.DataGridViewTextBoxColumn7.HeaderText = "单位"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 60
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "QUANTITY"
        Me.DataGridViewTextBoxColumn8.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "UNITPRICE"
        Me.DataGridViewTextBoxColumn9.HeaderText = "单价"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 60
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "TotalAmount"
        Me.DataGridViewTextBoxColumn10.HeaderText = "金额"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "OrderNumber"
        Me.DataGridViewTextBoxColumn11.HeaderText = "订单号"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 120
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "REMARK"
        Me.DataGridViewTextBoxColumn12.HeaderText = "说明"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'FrmReworkMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 496)
        Me.Controls.Add(Me.mtxtOrderNumber)
        Me.Controls.Add(Me.cboTransactionType)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.btnStick)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnSelectmaterial)
        Me.Controls.Add(Me.btnBarcodeInput)
        Me.Controls.Add(Me.btnDeleteRow)
        Me.Controls.Add(Me.btnInsertRow)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvReworkItem)
        Me.Controls.Add(Me.cboDept)
        Me.Controls.Add(Me.mtxtAttentionName)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.CheckBoxX1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.mtxtDelivery)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.txtTransactionId)
        Me.Controls.Add(Me.dtpInvoiceDate)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.LabelX6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReworkMaster"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "退货重工维护"
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReworkItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTransactionId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dtpInvoiceDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboDept As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents mtxtAttentionName As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents txtRemark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtDelivery As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvReworkItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnStick As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnSelectmaterial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBarcodeInput As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDeleteRow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnInsertRow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cboTransactionType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtOrderNumber As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
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
    Friend WithEvents ItemId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingSame As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MATERIALNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPECIFICATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUANTITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNITPRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REMARK As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
