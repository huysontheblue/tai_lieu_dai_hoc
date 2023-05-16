<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWarehousingQuery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWarehousingQuery))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NavigationPane1 = New DevComponents.DotNetBar.NavigationPane()
        Me.NavigationPanePanel1 = New DevComponents.DotNetBar.NavigationPanePanel()
        Me.tvWarehousing = New System.Windows.Forms.TreeView()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.dtpDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnPrinter = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.txtTransactionId = New DevComponents.DotNetBar.TextBoxItem()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.lblMessage = New DevComponents.DotNetBar.LabelItem()
        Me.dgvInvoiceTransaction = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.InvoiceTransactionId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceTransactionTypeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeliveryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AttentionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalConversionUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpandableSplitterItem = New DevComponents.DotNetBar.ExpandableSplitter()
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
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgvInvoiceTransactionItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.RowNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Specification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WarehouseLocationId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemtotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgvBarcode = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ScanBarcodeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanTransactionId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanMaterialNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanSpecification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingSame = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanCreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanCreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuStrip1.SuspendLayout()
        Me.NavigationPane1.SuspendLayout()
        Me.NavigationPanePanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.dgvInvoiceTransactionItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1045, 25)
        Me.menuStrip1.TabIndex = 132
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
        'NavigationPane1
        '
        Me.NavigationPane1.Controls.Add(Me.NavigationPanePanel1)
        Me.NavigationPane1.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavigationPane1.ItemPaddingBottom = 2
        Me.NavigationPane1.ItemPaddingTop = 2
        Me.NavigationPane1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.NavigationPane1.Location = New System.Drawing.Point(0, 25)
        Me.NavigationPane1.Name = "NavigationPane1"
        Me.NavigationPane1.Padding = New System.Windows.Forms.Padding(1)
        Me.NavigationPane1.Size = New System.Drawing.Size(206, 484)
        Me.NavigationPane1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NavigationPane1.TabIndex = 133
        '
        '
        '
        Me.NavigationPane1.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.NavigationPane1.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NavigationPane1.TitlePanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavigationPane1.TitlePanel.Location = New System.Drawing.Point(1, 1)
        Me.NavigationPane1.TitlePanel.Name = "panelTitle"
        Me.NavigationPane1.TitlePanel.Size = New System.Drawing.Size(204, 24)
        Me.NavigationPane1.TitlePanel.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPane1.TitlePanel.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.NavigationPane1.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.NavigationPane1.TitlePanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPane1.TitlePanel.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.NavigationPane1.TitlePanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPane1.TitlePanel.Style.GradientAngle = 90
        Me.NavigationPane1.TitlePanel.Style.MarginLeft = 4
        Me.NavigationPane1.TitlePanel.TabIndex = 0
        Me.NavigationPane1.TitlePanel.Text = "入库"
        '
        'NavigationPanePanel1
        '
        Me.NavigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.NavigationPanePanel1.Controls.Add(Me.tvWarehousing)
        Me.NavigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPanePanel1.Location = New System.Drawing.Point(1, 25)
        Me.NavigationPanePanel1.Name = "NavigationPanePanel1"
        Me.NavigationPanePanel1.ParentItem = Me.ButtonItem1
        Me.NavigationPanePanel1.Size = New System.Drawing.Size(204, 426)
        Me.NavigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.NavigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.NavigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.NavigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.NavigationPanePanel1.Style.GradientAngle = 90
        Me.NavigationPanePanel1.TabIndex = 2
        '
        'tvWarehousing
        '
        Me.tvWarehousing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvWarehousing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvWarehousing.Location = New System.Drawing.Point(0, 0)
        Me.tvWarehousing.Name = "tvWarehousing"
        Me.tvWarehousing.Scrollable = False
        Me.tvWarehousing.Size = New System.Drawing.Size(204, 426)
        Me.tvWarehousing.Sorted = True
        Me.tvWarehousing.TabIndex = 2
        '
        'ButtonItem1
        '
        Me.ButtonItem1.Checked = True
        Me.ButtonItem1.Image = CType(resources.GetObject("ButtonItem1.Image"), System.Drawing.Image)
        Me.ButtonItem1.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.OptionGroup = "navBar"
        Me.ButtonItem1.Text = "入库"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Controls.Add(Me.dtpDate)
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAdd, Me.btnDelete, Me.btnEdit, Me.btnPrinter, Me.LabelItem3, Me.LabelItem4, Me.ControlContainerItem1, Me.LabelItem5, Me.LabelItem2, Me.txtTransactionId, Me.btnQuery, Me.lblMessage})
        Me.Bar1.Location = New System.Drawing.Point(206, 25)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Bar1.Size = New System.Drawing.Size(839, 28)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 134
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'dtpDate
        '
        '
        '
        '
        Me.dtpDate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpDate.ButtonDropDown.Visible = True
        Me.dtpDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpDate.IsPopupCalendarOpen = False
        Me.dtpDate.Location = New System.Drawing.Point(268, 2)
        '
        '
        '
        Me.dtpDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpDate.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate.MonthCalendar.DisplayMonth = New Date(2015, 7, 1, 0, 0, 0, 0)
        Me.dtpDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpDate.MonthCalendar.TodayButtonVisible = True
        Me.dtpDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(124, 23)
        Me.dtpDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpDate.TabIndex = 138
        Me.dtpDate.Tag = "查询日期"
        '
        'btnAdd
        '
        Me.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAdd.Image = Global.WmsManagement.My.Resources.Resources.add
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "添加"
        Me.btnAdd.Tooltip = "添加"
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Image = Global.WmsManagement.My.Resources.Resources.delete
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "删除"
        Me.btnDelete.Tooltip = "删除"
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEdit.Enabled = False
        Me.btnEdit.Image = Global.WmsManagement.My.Resources.Resources.edit
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "修改"
        Me.btnEdit.Tooltip = "修改"
        '
        'btnPrinter
        '
        Me.btnPrinter.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrinter.Image = Global.WmsManagement.My.Resources.Resources.print
        Me.btnPrinter.Name = "btnPrinter"
        Me.btnPrinter.Text = "打印"
        Me.btnPrinter.Tooltip = "打印"
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
        Me.LabelItem4.Text = "日期:"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.Control = Me.dtpDate
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
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
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.Text = "单号:"
        '
        'txtTransactionId
        '
        Me.txtTransactionId.FocusHighlightColor = System.Drawing.Color.Transparent
        Me.txtTransactionId.Name = "txtTransactionId"
        Me.txtTransactionId.Tag = "查询单号"
        Me.txtTransactionId.TextBoxWidth = 94
        Me.txtTransactionId.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'btnQuery
        '
        Me.btnQuery.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnQuery.Image = Global.WmsManagement.My.Resources.Resources.query
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Tag = "查询"
        Me.btnQuery.Text = "查询"
        '
        'lblMessage
        '
        Me.lblMessage.Name = "lblMessage"
        '
        'dgvInvoiceTransaction
        '
        Me.dgvInvoiceTransaction.AllowUserToAddRows = False
        Me.dgvInvoiceTransaction.AllowUserToDeleteRows = False
        Me.dgvInvoiceTransaction.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceTransaction.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoiceTransaction.ColumnHeadersHeight = 28
        Me.dgvInvoiceTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInvoiceTransaction.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceTransactionId, Me.NO, Me.InvoiceTransactionTypeName, Me.TransactionId, Me.CreateTime1, Me.WarehouseName, Me.DeptName, Me.SupplierName, Me.TotalAmount, Me.DeliveryName, Me.AttentionName, Me.Column11, Me.TotalNumber, Me.TotalConversionUnits, Me.Remark, Me.CreateUser, Me.CreateTime, Me.UpdateUser, Me.UpdateTime, Me.StatusFlag})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInvoiceTransaction.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInvoiceTransaction.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvInvoiceTransaction.EnableHeadersVisualStyles = False
        Me.dgvInvoiceTransaction.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvInvoiceTransaction.Location = New System.Drawing.Point(206, 53)
        Me.dgvInvoiceTransaction.Name = "dgvInvoiceTransaction"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceTransaction.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInvoiceTransaction.RowHeadersWidth = 15
        Me.dgvInvoiceTransaction.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvInvoiceTransaction.RowTemplate.Height = 28
        Me.dgvInvoiceTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInvoiceTransaction.Size = New System.Drawing.Size(839, 223)
        Me.dgvInvoiceTransaction.TabIndex = 135
        '
        'InvoiceTransactionId
        '
        Me.InvoiceTransactionId.HeaderText = "InvoiceTransactionId"
        Me.InvoiceTransactionId.Name = "InvoiceTransactionId"
        Me.InvoiceTransactionId.ReadOnly = True
        Me.InvoiceTransactionId.Visible = False
        '
        'NO
        '
        Me.NO.HeaderText = "序号"
        Me.NO.Name = "NO"
        Me.NO.ReadOnly = True
        Me.NO.Width = 35
        '
        'InvoiceTransactionTypeName
        '
        Me.InvoiceTransactionTypeName.DataPropertyName = "InvoiceTransactionTypeName"
        Me.InvoiceTransactionTypeName.HeaderText = "类型"
        Me.InvoiceTransactionTypeName.Name = "InvoiceTransactionTypeName"
        Me.InvoiceTransactionTypeName.ReadOnly = True
        '
        'TransactionId
        '
        Me.TransactionId.DataPropertyName = "TransactionId"
        Me.TransactionId.HeaderText = "单号"
        Me.TransactionId.Name = "TransactionId"
        Me.TransactionId.ReadOnly = True
        '
        'CreateTime1
        '
        Me.CreateTime1.DataPropertyName = "CreateTime"
        Me.CreateTime1.HeaderText = "日期"
        Me.CreateTime1.Name = "CreateTime1"
        Me.CreateTime1.ReadOnly = True
        Me.CreateTime1.Width = 54
        '
        'WarehouseName
        '
        Me.WarehouseName.DataPropertyName = "WarehouseName"
        Me.WarehouseName.HeaderText = "仓库名称"
        Me.WarehouseName.Name = "WarehouseName"
        Me.WarehouseName.ReadOnly = True
        Me.WarehouseName.Width = 78
        '
        'DeptName
        '
        Me.DeptName.DataPropertyName = "DeptName"
        Me.DeptName.HeaderText = "部门"
        Me.DeptName.Name = "DeptName"
        Me.DeptName.ReadOnly = True
        Me.DeptName.Width = 54
        '
        'SupplierName
        '
        Me.SupplierName.DataPropertyName = "SupplierName"
        Me.SupplierName.HeaderText = "供应商/对方单位"
        Me.SupplierName.Name = "SupplierName"
        Me.SupplierName.ReadOnly = True
        Me.SupplierName.Width = 66
        '
        'TotalAmount
        '
        Me.TotalAmount.DataPropertyName = "TotalAmount"
        Me.TotalAmount.HeaderText = "入库总金额"
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.ReadOnly = True
        Me.TotalAmount.Width = 90
        '
        'DeliveryName
        '
        Me.DeliveryName.DataPropertyName = "DeliveryName"
        Me.DeliveryName.HeaderText = "交货人"
        Me.DeliveryName.Name = "DeliveryName"
        Me.DeliveryName.ReadOnly = True
        Me.DeliveryName.Width = 66
        '
        'AttentionName
        '
        Me.AttentionName.DataPropertyName = "AttentionName"
        Me.AttentionName.HeaderText = "经办人"
        Me.AttentionName.Name = "AttentionName"
        Me.AttentionName.ReadOnly = True
        Me.AttentionName.Width = 66
        '
        'Column11
        '
        Me.Column11.HeaderText = "入库商品"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 78
        '
        'TotalNumber
        '
        Me.TotalNumber.DataPropertyName = "TotalNumber"
        Me.TotalNumber.HeaderText = "数量合计"
        Me.TotalNumber.Name = "TotalNumber"
        Me.TotalNumber.ReadOnly = True
        Me.TotalNumber.Width = 78
        '
        'TotalConversionUnits
        '
        Me.TotalConversionUnits.DataPropertyName = "TotalConversionUnits"
        Me.TotalConversionUnits.HeaderText = "换算单位合计"
        Me.TotalConversionUnits.Name = "TotalConversionUnits"
        Me.TotalConversionUnits.ReadOnly = True
        Me.TotalConversionUnits.Width = 102
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 54
        '
        'CreateUser
        '
        Me.CreateUser.DataPropertyName = "CreateUser"
        Me.CreateUser.HeaderText = "录入人"
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.ReadOnly = True
        Me.CreateUser.Width = 66
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "CreateTime"
        Me.CreateTime.HeaderText = "录入时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        Me.CreateTime.Width = 78
        '
        'UpdateUser
        '
        Me.UpdateUser.DataPropertyName = "UpdateUser"
        Me.UpdateUser.HeaderText = "最后修改人"
        Me.UpdateUser.Name = "UpdateUser"
        Me.UpdateUser.ReadOnly = True
        Me.UpdateUser.Width = 90
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "最后修改时间"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        Me.UpdateTime.Width = 102
        '
        'StatusFlag
        '
        Me.StatusFlag.DataPropertyName = "StatusFlag"
        Me.StatusFlag.HeaderText = "状态"
        Me.StatusFlag.Name = "StatusFlag"
        Me.StatusFlag.ReadOnly = True
        Me.StatusFlag.Width = 60
        '
        'ExpandableSplitterItem
        '
        Me.ExpandableSplitterItem.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitterItem.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterItem.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitterItem.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandableSplitterItem.ExpandableControl = Me.dgvInvoiceTransaction
        Me.ExpandableSplitterItem.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitterItem.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterItem.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitterItem.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitterItem.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitterItem.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitterItem.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitterItem.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitterItem.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ExpandableSplitterItem.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ExpandableSplitterItem.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitterItem.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitterItem.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitterItem.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterItem.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitterItem.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitterItem.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitterItem.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterItem.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitterItem.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitterItem.Location = New System.Drawing.Point(206, 276)
        Me.ExpandableSplitterItem.Name = "ExpandableSplitterItem"
        Me.ExpandableSplitterItem.Size = New System.Drawing.Size(839, 6)
        Me.ExpandableSplitterItem.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitterItem.TabIndex = 136
        Me.ExpandableSplitterItem.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "InvoiceTransactionId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "序号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 35
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "InvoiceTransactionTypeName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "类型"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 54
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "TransactionId"
        Me.DataGridViewTextBoxColumn4.HeaderText = "单号"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 54
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "CreateTime"
        Me.DataGridViewTextBoxColumn5.HeaderText = "日期"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 54
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "WarehouseName"
        Me.DataGridViewTextBoxColumn6.HeaderText = "仓库名称"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 78
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "DeptName"
        Me.DataGridViewTextBoxColumn7.HeaderText = "部门"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 54
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "SupplierName"
        Me.DataGridViewTextBoxColumn8.HeaderText = "供应商/对方单位"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 66
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "TotalAmount"
        Me.DataGridViewTextBoxColumn9.HeaderText = "入库总金额"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 90
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "DeliveryName"
        Me.DataGridViewTextBoxColumn10.HeaderText = "交货人"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 66
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "AttentionName"
        Me.DataGridViewTextBoxColumn11.HeaderText = "经办人"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 66
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "入库商品"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 78
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "TotalNumber"
        Me.DataGridViewTextBoxColumn13.HeaderText = "数量合计"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 78
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "TotalConversionUnits"
        Me.DataGridViewTextBoxColumn14.HeaderText = "换算单位合计"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 102
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Remark"
        Me.DataGridViewTextBoxColumn15.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 54
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "CreateUser"
        Me.DataGridViewTextBoxColumn16.HeaderText = "录入人"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 66
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "CreateTime"
        Me.DataGridViewTextBoxColumn17.HeaderText = "录入时间"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 78
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "UpdateUser"
        Me.DataGridViewTextBoxColumn18.HeaderText = "最后修改人"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 90
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "UpdateTime"
        Me.DataGridViewTextBoxColumn19.HeaderText = "最后修改时间"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 102
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 30
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "RowNum"
        Me.DataGridViewTextBoxColumn21.HeaderText = "序号"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 35
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "MaterialNO"
        Me.DataGridViewTextBoxColumn22.HeaderText = "货品编码"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 82
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn23.HeaderText = "货品名称"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 83
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "Specification"
        Me.DataGridViewTextBoxColumn24.HeaderText = "规格型号"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Width = 82
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "Uint"
        Me.DataGridViewTextBoxColumn25.HeaderText = "计量单位"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Width = 82
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn26.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Width = 82
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "UnitPrice"
        Me.DataGridViewTextBoxColumn27.HeaderText = "单价"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Width = 82
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "totalAmount"
        Me.DataGridViewTextBoxColumn28.HeaderText = "金额"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        Me.DataGridViewTextBoxColumn28.Width = 83
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "OrderNumber"
        Me.DataGridViewTextBoxColumn29.HeaderText = "订单号"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.Width = 82
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "Remark"
        Me.DataGridViewTextBoxColumn30.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        Me.DataGridViewTextBoxColumn30.Width = 225
        '
        'SuperTabControl1
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.Location = New System.Drawing.Point(206, 282)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(839, 227)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SuperTabControl1.TabIndex = 137
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "单据明细"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.dgvInvoiceTransactionItem)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(839, 199)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'dgvInvoiceTransactionItem
        '
        Me.dgvInvoiceTransactionItem.AllowUserToAddRows = False
        Me.dgvInvoiceTransactionItem.AllowUserToDeleteRows = False
        Me.dgvInvoiceTransactionItem.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceTransactionItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvInvoiceTransactionItem.ColumnHeadersHeight = 28
        Me.dgvInvoiceTransactionItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInvoiceTransactionItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowNum, Me.MaterialNO, Me.Description, Me.Specification, Me.Uint, Me.WarehouseLocationId, Me.Quantity, Me.UnitPrice, Me.ItemtotalAmount, Me.OrderNumber, Me.ItemRemark})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInvoiceTransactionItem.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvInvoiceTransactionItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceTransactionItem.EnableHeadersVisualStyles = False
        Me.dgvInvoiceTransactionItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvInvoiceTransactionItem.Location = New System.Drawing.Point(0, 0)
        Me.dgvInvoiceTransactionItem.Name = "dgvInvoiceTransactionItem"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceTransactionItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvInvoiceTransactionItem.RowHeadersWidth = 15
        Me.dgvInvoiceTransactionItem.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvInvoiceTransactionItem.RowTemplate.Height = 23
        Me.dgvInvoiceTransactionItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInvoiceTransactionItem.Size = New System.Drawing.Size(839, 199)
        Me.dgvInvoiceTransactionItem.TabIndex = 138
        '
        'RowNum
        '
        Me.RowNum.DataPropertyName = "RowNum"
        Me.RowNum.HeaderText = "序号"
        Me.RowNum.Name = "RowNum"
        Me.RowNum.ReadOnly = True
        Me.RowNum.Width = 35
        '
        'MaterialNO
        '
        Me.MaterialNO.DataPropertyName = "MaterialNO"
        Me.MaterialNO.HeaderText = "货品编码"
        Me.MaterialNO.Name = "MaterialNO"
        Me.MaterialNO.ReadOnly = True
        Me.MaterialNO.Width = 130
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "货品名称"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 83
        '
        'Specification
        '
        Me.Specification.DataPropertyName = "Specification"
        Me.Specification.HeaderText = "规格型号"
        Me.Specification.Name = "Specification"
        Me.Specification.ReadOnly = True
        Me.Specification.Width = 82
        '
        'Uint
        '
        Me.Uint.DataPropertyName = "Uint"
        Me.Uint.HeaderText = "计量单位"
        Me.Uint.Name = "Uint"
        Me.Uint.ReadOnly = True
        Me.Uint.Width = 40
        '
        'WarehouseLocationId
        '
        Me.WarehouseLocationId.DataPropertyName = "WarehouseLocationId"
        Me.WarehouseLocationId.HeaderText = "储位"
        Me.WarehouseLocationId.Name = "WarehouseLocationId"
        Me.WarehouseLocationId.ReadOnly = True
        Me.WarehouseLocationId.Width = 80
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.HeaderText = "数量"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 82
        '
        'UnitPrice
        '
        Me.UnitPrice.DataPropertyName = "UnitPrice"
        Me.UnitPrice.HeaderText = "单价"
        Me.UnitPrice.Name = "UnitPrice"
        Me.UnitPrice.ReadOnly = True
        Me.UnitPrice.Width = 60
        '
        'ItemtotalAmount
        '
        Me.ItemtotalAmount.DataPropertyName = "totalAmount"
        Me.ItemtotalAmount.HeaderText = "金额"
        Me.ItemtotalAmount.Name = "ItemtotalAmount"
        Me.ItemtotalAmount.ReadOnly = True
        Me.ItemtotalAmount.Width = 83
        '
        'OrderNumber
        '
        Me.OrderNumber.DataPropertyName = "OrderNumber"
        Me.OrderNumber.HeaderText = "订单号"
        Me.OrderNumber.Name = "OrderNumber"
        Me.OrderNumber.ReadOnly = True
        Me.OrderNumber.Width = 82
        '
        'ItemRemark
        '
        Me.ItemRemark.DataPropertyName = "Remark"
        Me.ItemRemark.HeaderText = "备注"
        Me.ItemRemark.Name = "ItemRemark"
        Me.ItemRemark.ReadOnly = True
        Me.ItemRemark.Width = 225
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "条码明细"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgvBarcode)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(839, 199)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'dgvBarcode
        '
        Me.dgvBarcode.AllowUserToAddRows = False
        Me.dgvBarcode.AllowUserToDeleteRows = False
        Me.dgvBarcode.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarcode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvBarcode.ColumnHeadersHeight = 28
        Me.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvBarcode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ScanBarcodeId, Me.ScanTransactionId, Me.BarCode, Me.ScanMaterialNO, Me.ScanDescription, Me.ScanSpecification, Me.ScanQuantity, Me.PackingSame, Me.ScanCreateUser, Me.ScanCreateTime})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBarcode.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBarcode.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvBarcode.Location = New System.Drawing.Point(0, 0)
        Me.dgvBarcode.Name = "dgvBarcode"
        Me.dgvBarcode.RowHeadersWidth = 15
        Me.dgvBarcode.RowTemplate.Height = 23
        Me.dgvBarcode.Size = New System.Drawing.Size(839, 199)
        Me.dgvBarcode.TabIndex = 2
        '
        'ScanBarcodeId
        '
        Me.ScanBarcodeId.HeaderText = "ScanBarcodeId"
        Me.ScanBarcodeId.Name = "ScanBarcodeId"
        Me.ScanBarcodeId.Visible = False
        '
        'ScanTransactionId
        '
        Me.ScanTransactionId.HeaderText = "TransactionId"
        Me.ScanTransactionId.Name = "ScanTransactionId"
        Me.ScanTransactionId.Visible = False
        '
        'BarCode
        '
        Me.BarCode.DataPropertyName = "BarCode"
        Me.BarCode.HeaderText = "条码"
        Me.BarCode.Name = "BarCode"
        Me.BarCode.ReadOnly = True
        Me.BarCode.Width = 200
        '
        'ScanMaterialNO
        '
        Me.ScanMaterialNO.DataPropertyName = "MaterialNO"
        Me.ScanMaterialNO.HeaderText = "料号"
        Me.ScanMaterialNO.Name = "ScanMaterialNO"
        Me.ScanMaterialNO.ReadOnly = True
        Me.ScanMaterialNO.Width = 150
        '
        'ScanDescription
        '
        Me.ScanDescription.DataPropertyName = "Description"
        Me.ScanDescription.HeaderText = "描述"
        Me.ScanDescription.Name = "ScanDescription"
        Me.ScanDescription.ReadOnly = True
        Me.ScanDescription.Width = 140
        '
        'ScanSpecification
        '
        Me.ScanSpecification.DataPropertyName = "Specification"
        Me.ScanSpecification.HeaderText = "规格"
        Me.ScanSpecification.Name = "ScanSpecification"
        Me.ScanSpecification.ReadOnly = True
        Me.ScanSpecification.Width = 140
        '
        'ScanQuantity
        '
        Me.ScanQuantity.DataPropertyName = "Quantity"
        Me.ScanQuantity.HeaderText = "数量"
        Me.ScanQuantity.Name = "ScanQuantity"
        Me.ScanQuantity.ReadOnly = True
        '
        'PackingSame
        '
        Me.PackingSame.DataPropertyName = "PackingSame"
        Me.PackingSame.HeaderText = "条码是否相同"
        Me.PackingSame.Name = "PackingSame"
        Me.PackingSame.ReadOnly = True
        '
        'ScanCreateUser
        '
        Me.ScanCreateUser.DataPropertyName = "CreateUser"
        Me.ScanCreateUser.HeaderText = "扫描用户"
        Me.ScanCreateUser.Name = "ScanCreateUser"
        Me.ScanCreateUser.ReadOnly = True
        '
        'ScanCreateTime
        '
        Me.ScanCreateTime.DataPropertyName = "CreateTime"
        Me.ScanCreateTime.HeaderText = "扫描时间"
        Me.ScanCreateTime.Name = "ScanCreateTime"
        Me.ScanCreateTime.ReadOnly = True
        '
        'FrmWarehousingQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 509)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.ExpandableSplitterItem)
        Me.Controls.Add(Me.dgvInvoiceTransaction)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.NavigationPane1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "FrmWarehousingQuery"
        Me.ShowIcon = False
        Me.Text = "入库"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.NavigationPane1.ResumeLayout(False)
        Me.NavigationPanePanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.dgvInvoiceTransactionItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents NavigationPane1 As DevComponents.DotNetBar.NavigationPane
    Friend WithEvents NavigationPanePanel1 As DevComponents.DotNetBar.NavigationPanePanel
    Private WithEvents tvWarehousing As System.Windows.Forms.TreeView
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents dgvInvoiceTransaction As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ExpandableSplitterItem As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtTransactionId As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelItem
    Friend WithEvents dtpDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
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
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTransactionId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTransactionTypeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarehouseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeliveryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AttentionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalConversionUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPrinter As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgvInvoiceTransactionItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents RowNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaterialNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Specification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Uint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WarehouseLocationId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemtotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents dgvBarcode As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ScanBarcodeId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanTransactionId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanMaterialNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanSpecification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingSame As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanCreateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanCreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
