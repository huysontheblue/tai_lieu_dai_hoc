<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMaterialManagement
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem6 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel5 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgvTransactionItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabItem5 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel3 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgvBarcode = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Reel_BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warehouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperTabItem3 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.txtPackingQuantity = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.chkPackingQuantityScan = New System.Windows.Forms.CheckBox()
        Me.chkPackingSame = New System.Windows.Forms.CheckBox()
        Me.cboMaterialType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.cboTransactionType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cboFIFOType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.chkFIFO = New System.Windows.Forms.CheckBox()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.ExpandableSplitterItem = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.dgvMaterial = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.MATERIAL_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MATERIAL_NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPECIFICATION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUANTITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoStorageQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DELETEFLAG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CREATE_USERID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CREATE_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DELETE_USERID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DELETE_TIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionTypeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TYPEFLAGNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIFO_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIFO_RULEName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FIFO_REFER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingSame = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TYPEFLAG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem()
        Me.btnBack = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.txtMaterialNO = New DevComponents.DotNetBar.TextBoxItem()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.lblMessage = New DevComponents.DotNetBar.LabelItem()
        Me.dgvBarcodeQuery = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ScanBarcodeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanTransactionId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanMaterialNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanSpecification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanCreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanCreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RowNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceDefinitionsName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemtotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuStrip1.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel4.SuspendLayout()
        Me.SuperTabControlPanel5.SuspendLayout()
        CType(Me.dgvTransactionItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel3.SuspendLayout()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.dgvMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBarcodeQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(920, 25)
        Me.menuStrip1.TabIndex = 139
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel4)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel5)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel3)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.Location = New System.Drawing.Point(0, 293)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 3
        Me.SuperTabControl1.Size = New System.Drawing.Size(920, 191)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SuperTabControl1.TabIndex = 146
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem3, Me.SuperTabItem5, Me.SuperTabItem6, Me.SuperTabItem2})
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.dgvBarcodeQuery)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(920, 163)
        Me.SuperTabControlPanel4.TabIndex = 0
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem6
        '
        'SuperTabItem6
        '
        Me.SuperTabItem6.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem6.GlobalItem = False
        Me.SuperTabItem6.Name = "SuperTabItem6"
        Me.SuperTabItem6.Text = "条码明细"
        '
        'SuperTabControlPanel5
        '
        Me.SuperTabControlPanel5.Controls.Add(Me.dgvTransactionItem)
        Me.SuperTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel5.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel5.Name = "SuperTabControlPanel5"
        Me.SuperTabControlPanel5.Size = New System.Drawing.Size(920, 163)
        Me.SuperTabControlPanel5.TabIndex = 0
        Me.SuperTabControlPanel5.TabItem = Me.SuperTabItem5
        '
        'dgvTransactionItem
        '
        Me.dgvTransactionItem.AllowUserToAddRows = False
        Me.dgvTransactionItem.AllowUserToDeleteRows = False
        Me.dgvTransactionItem.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransactionItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTransactionItem.ColumnHeadersHeight = 28
        Me.dgvTransactionItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTransactionItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TransactionId, Me.RowNum, Me.MaterialNO, Me.InvoiceDefinitionsName, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn7, Me.Uint, Me.DataGridViewTextBoxColumn8, Me.UnitPrice, Me.ItemtotalAmount, Me.OrderNumber, Me.ItemRemark})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTransactionItem.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTransactionItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTransactionItem.EnableHeadersVisualStyles = False
        Me.dgvTransactionItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvTransactionItem.Location = New System.Drawing.Point(0, 0)
        Me.dgvTransactionItem.Name = "dgvTransactionItem"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransactionItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTransactionItem.RowHeadersWidth = 15
        Me.dgvTransactionItem.RowTemplate.Height = 23
        Me.dgvTransactionItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransactionItem.Size = New System.Drawing.Size(920, 163)
        Me.dgvTransactionItem.TabIndex = 138
        '
        'SuperTabItem5
        '
        Me.SuperTabItem5.AttachedControl = Me.SuperTabControlPanel5
        Me.SuperTabItem5.GlobalItem = False
        Me.SuperTabItem5.Name = "SuperTabItem5"
        Me.SuperTabItem5.Text = "出入库明细"
        '
        'SuperTabControlPanel3
        '
        Me.SuperTabControlPanel3.Controls.Add(Me.dgvBarcode)
        Me.SuperTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel3.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel3.Name = "SuperTabControlPanel3"
        Me.SuperTabControlPanel3.Size = New System.Drawing.Size(920, 163)
        Me.SuperTabControlPanel3.TabIndex = 0
        Me.SuperTabControlPanel3.TabItem = Me.SuperTabItem3
        '
        'dgvBarcode
        '
        Me.dgvBarcode.AllowUserToAddRows = False
        Me.dgvBarcode.AllowUserToDeleteRows = False
        Me.dgvBarcode.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvBarcode.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarcode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvBarcode.ColumnHeadersHeight = 28
        Me.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvBarcode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reel_BarCode, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.Warehouse, Me.Location, Me.DateCode, Me.DataGridViewTextBoxColumn9})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBarcode.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvBarcode.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvBarcode.EnableHeadersVisualStyles = False
        Me.dgvBarcode.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvBarcode.Location = New System.Drawing.Point(0, 0)
        Me.dgvBarcode.MultiSelect = False
        Me.dgvBarcode.Name = "dgvBarcode"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarcode.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvBarcode.RowHeadersWidth = 15
        Me.dgvBarcode.RowTemplate.Height = 28
        Me.dgvBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBarcode.Size = New System.Drawing.Size(920, 235)
        Me.dgvBarcode.TabIndex = 145
        '
        'Reel_BarCode
        '
        Me.Reel_BarCode.DataPropertyName = "REEL_BARCODE"
        Me.Reel_BarCode.HeaderText = "条码"
        Me.Reel_BarCode.Name = "Reel_BarCode"
        Me.Reel_BarCode.ReadOnly = True
        Me.Reel_BarCode.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "MATERIAL_NO"
        Me.DataGridViewTextBoxColumn2.HeaderText = "物料编码"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DESCRIPTION"
        Me.DataGridViewTextBoxColumn3.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "SPECIFICATION"
        Me.DataGridViewTextBoxColumn4.HeaderText = "规格"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "UNIT_MEASURE_ID"
        Me.DataGridViewTextBoxColumn5.HeaderText = "单位"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 40
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "REMAINING_QUANTITY"
        Me.DataGridViewTextBoxColumn6.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 50
        '
        'Warehouse
        '
        Me.Warehouse.DataPropertyName = "WarehouseId"
        Me.Warehouse.HeaderText = "仓库"
        Me.Warehouse.Name = "Warehouse"
        Me.Warehouse.ReadOnly = True
        '
        'Location
        '
        Me.Location.DataPropertyName = "Location"
        Me.Location.HeaderText = "库位"
        Me.Location.Name = "Location"
        Me.Location.ReadOnly = True
        '
        'DateCode
        '
        Me.DateCode.DataPropertyName = "CREATE_TIME"
        Me.DateCode.HeaderText = "DataCode"
        Me.DateCode.Name = "DateCode"
        Me.DateCode.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "DELETEFLAG"
        Me.DataGridViewTextBoxColumn9.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'SuperTabItem3
        '
        Me.SuperTabItem3.AttachedControl = Me.SuperTabControlPanel3
        Me.SuperTabItem3.GlobalItem = False
        Me.SuperTabItem3.Name = "SuperTabItem3"
        Me.SuperTabItem3.Text = "库存状况"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.txtPackingQuantity)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX4)
        Me.SuperTabControlPanel1.Controls.Add(Me.chkPackingQuantityScan)
        Me.SuperTabControlPanel1.Controls.Add(Me.chkPackingSame)
        Me.SuperTabControlPanel1.Controls.Add(Me.cboMaterialType)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX3)
        Me.SuperTabControlPanel1.Controls.Add(Me.cboTransactionType)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX1)
        Me.SuperTabControlPanel1.Controls.Add(Me.cboFIFOType)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX2)
        Me.SuperTabControlPanel1.Controls.Add(Me.chkFIFO)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(920, 163)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'txtPackingQuantity
        '
        '
        '
        '
        Me.txtPackingQuantity.Border.Class = "TextBoxBorder"
        Me.txtPackingQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPackingQuantity.Location = New System.Drawing.Point(486, 60)
        Me.txtPackingQuantity.Name = "txtPackingQuantity"
        Me.txtPackingQuantity.Size = New System.Drawing.Size(121, 21)
        Me.txtPackingQuantity.TabIndex = 11
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(424, 60)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 10
        Me.LabelX4.Text = "包装数量："
        '
        'chkPackingQuantityScan
        '
        Me.chkPackingQuantityScan.AutoSize = True
        Me.chkPackingQuantityScan.BackColor = System.Drawing.Color.Transparent
        Me.chkPackingQuantityScan.Enabled = False
        Me.chkPackingQuantityScan.Location = New System.Drawing.Point(211, 65)
        Me.chkPackingQuantityScan.Name = "chkPackingQuantityScan"
        Me.chkPackingQuantityScan.Size = New System.Drawing.Size(72, 16)
        Me.chkPackingQuantityScan.TabIndex = 9
        Me.chkPackingQuantityScan.Text = "扫描数量"
        Me.chkPackingQuantityScan.UseVisualStyleBackColor = False
        '
        'chkPackingSame
        '
        Me.chkPackingSame.AutoSize = True
        Me.chkPackingSame.BackColor = System.Drawing.Color.Transparent
        Me.chkPackingSame.Enabled = False
        Me.chkPackingSame.Location = New System.Drawing.Point(21, 65)
        Me.chkPackingSame.Name = "chkPackingSame"
        Me.chkPackingSame.Size = New System.Drawing.Size(72, 16)
        Me.chkPackingSame.TabIndex = 8
        Me.chkPackingSame.Text = "包装相同"
        Me.chkPackingSame.UseVisualStyleBackColor = False
        '
        'cboMaterialType
        '
        Me.cboMaterialType.DisplayMember = "Text"
        Me.cboMaterialType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMaterialType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaterialType.Enabled = False
        Me.cboMaterialType.FormattingEnabled = True
        Me.cboMaterialType.ItemHeight = 15
        Me.cboMaterialType.Items.AddRange(New Object() {Me.ComboItem4, Me.ComboItem5})
        Me.cboMaterialType.Location = New System.Drawing.Point(486, 17)
        Me.cboMaterialType.Name = "cboMaterialType"
        Me.cboMaterialType.Size = New System.Drawing.Size(121, 21)
        Me.cboMaterialType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboMaterialType.TabIndex = 7
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "0-数量"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "1-条码"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(424, 17)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX3.Size = New System.Drawing.Size(108, 23)
        Me.LabelX3.TabIndex = 6
        Me.LabelX3.Text = "物料类型："
        '
        'cboTransactionType
        '
        Me.cboTransactionType.DisplayMember = "Text"
        Me.cboTransactionType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransactionType.Enabled = False
        Me.cboTransactionType.FormattingEnabled = True
        Me.cboTransactionType.ItemHeight = 15
        Me.cboTransactionType.Items.AddRange(New Object() {Me.ComboItem7, Me.ComboItem8})
        Me.cboTransactionType.Location = New System.Drawing.Point(751, 17)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.Size = New System.Drawing.Size(121, 21)
        Me.cboTransactionType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboTransactionType.TabIndex = 5
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "0-数量"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "1-条码"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(673, 17)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX1.Size = New System.Drawing.Size(108, 23)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "出入库类型："
        '
        'cboFIFOType
        '
        Me.cboFIFOType.DisplayMember = "Text"
        Me.cboFIFOType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboFIFOType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIFOType.Enabled = False
        Me.cboFIFOType.FormattingEnabled = True
        Me.cboFIFOType.ItemHeight = 15
        Me.cboFIFOType.Location = New System.Drawing.Point(211, 19)
        Me.cboFIFOType.Name = "cboFIFOType"
        Me.cboFIFOType.Size = New System.Drawing.Size(121, 21)
        Me.cboFIFOType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboFIFOType.TabIndex = 3
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(172, 19)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "规则："
        '
        'chkFIFO
        '
        Me.chkFIFO.AutoSize = True
        Me.chkFIFO.BackColor = System.Drawing.Color.Transparent
        Me.chkFIFO.Enabled = False
        Me.chkFIFO.Location = New System.Drawing.Point(21, 22)
        Me.chkFIFO.Name = "chkFIFO"
        Me.chkFIFO.Size = New System.Drawing.Size(72, 16)
        Me.chkFIFO.TabIndex = 1
        Me.chkFIFO.Text = "先进先出"
        Me.chkFIFO.UseVisualStyleBackColor = False
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "料件设置"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(920, 163)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "订单记录"
        Me.SuperTabItem2.Visible = False
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "调拨明细"
        '
        'ExpandableSplitterItem
        '
        Me.ExpandableSplitterItem.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitterItem.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitterItem.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitterItem.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandableSplitterItem.ExpandableControl = Me.dgvMaterial
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
        Me.ExpandableSplitterItem.Location = New System.Drawing.Point(0, 287)
        Me.ExpandableSplitterItem.Name = "ExpandableSplitterItem"
        Me.ExpandableSplitterItem.Size = New System.Drawing.Size(920, 6)
        Me.ExpandableSplitterItem.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitterItem.TabIndex = 145
        Me.ExpandableSplitterItem.TabStop = False
        '
        'dgvMaterial
        '
        Me.dgvMaterial.AllowUserToAddRows = False
        Me.dgvMaterial.AllowUserToDeleteRows = False
        Me.dgvMaterial.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvMaterial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaterial.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvMaterial.ColumnHeadersHeight = 28
        Me.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvMaterial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MATERIAL_ID, Me.MATERIAL_NO, Me.DESCRIPTION, Me.SPECIFICATION, Me.UOM_NAME, Me.QUANTITY, Me.NoStorageQuantity, Me.DELETEFLAG, Me.Remark, Me.CREATE_USERID, Me.CREATE_TIME, Me.DELETE_USERID, Me.DELETE_TIME, Me.TransactionTypeName, Me.TYPEFLAGNAME, Me.FIFO_TYPE, Me.FIFO_RULEName, Me.FIFO_REFER, Me.PackingSame, Me.TYPEFLAG})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMaterial.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvMaterial.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvMaterial.EnableHeadersVisualStyles = False
        Me.dgvMaterial.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvMaterial.Location = New System.Drawing.Point(0, 52)
        Me.dgvMaterial.MultiSelect = False
        Me.dgvMaterial.Name = "dgvMaterial"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaterial.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvMaterial.RowHeadersWidth = 15
        Me.dgvMaterial.RowTemplate.Height = 28
        Me.dgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaterial.Size = New System.Drawing.Size(920, 235)
        Me.dgvMaterial.TabIndex = 144
        '
        'MATERIAL_ID
        '
        Me.MATERIAL_ID.DataPropertyName = "MATERIAL_ID"
        Me.MATERIAL_ID.HeaderText = "MATERIAL_ID"
        Me.MATERIAL_ID.Name = "MATERIAL_ID"
        Me.MATERIAL_ID.ReadOnly = True
        Me.MATERIAL_ID.Visible = False
        '
        'MATERIAL_NO
        '
        Me.MATERIAL_NO.DataPropertyName = "MATERIALNO"
        Me.MATERIAL_NO.HeaderText = "物料编码"
        Me.MATERIAL_NO.Name = "MATERIAL_NO"
        Me.MATERIAL_NO.ReadOnly = True
        Me.MATERIAL_NO.Width = 150
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.DataPropertyName = "DESCRIPTION"
        Me.DESCRIPTION.HeaderText = "品名"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.ReadOnly = True
        Me.DESCRIPTION.Width = 150
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
        Me.UOM_NAME.Width = 40
        '
        'QUANTITY
        '
        Me.QUANTITY.DataPropertyName = "QUANTITY"
        Me.QUANTITY.HeaderText = "库存数量"
        Me.QUANTITY.Name = "QUANTITY"
        Me.QUANTITY.ReadOnly = True
        Me.QUANTITY.Width = 60
        '
        'NoStorageQuantity
        '
        Me.NoStorageQuantity.HeaderText = "未入库数量"
        Me.NoStorageQuantity.Name = "NoStorageQuantity"
        Me.NoStorageQuantity.ReadOnly = True
        Me.NoStorageQuantity.Width = 60
        '
        'DELETEFLAG
        '
        Me.DELETEFLAG.DataPropertyName = "DELETEFLAG"
        Me.DELETEFLAG.HeaderText = "状态"
        Me.DELETEFLAG.Name = "DELETEFLAG"
        Me.DELETEFLAG.ReadOnly = True
        Me.DELETEFLAG.Width = 40
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 80
        '
        'CREATE_USERID
        '
        Me.CREATE_USERID.DataPropertyName = "CREATE_USERID"
        Me.CREATE_USERID.HeaderText = "创建人"
        Me.CREATE_USERID.Name = "CREATE_USERID"
        Me.CREATE_USERID.ReadOnly = True
        Me.CREATE_USERID.Width = 60
        '
        'CREATE_TIME
        '
        Me.CREATE_TIME.DataPropertyName = "CREATE_TIME"
        Me.CREATE_TIME.HeaderText = "创建时间"
        Me.CREATE_TIME.Name = "CREATE_TIME"
        Me.CREATE_TIME.ReadOnly = True
        '
        'DELETE_USERID
        '
        Me.DELETE_USERID.DataPropertyName = "DELETE_USERID"
        Me.DELETE_USERID.HeaderText = "删除人"
        Me.DELETE_USERID.Name = "DELETE_USERID"
        Me.DELETE_USERID.ReadOnly = True
        Me.DELETE_USERID.Width = 60
        '
        'DELETE_TIME
        '
        Me.DELETE_TIME.DataPropertyName = "DELETE_TIME"
        Me.DELETE_TIME.HeaderText = "删除时间"
        Me.DELETE_TIME.Name = "DELETE_TIME"
        Me.DELETE_TIME.ReadOnly = True
        '
        'TransactionTypeName
        '
        Me.TransactionTypeName.DataPropertyName = "TransactionTypeName"
        Me.TransactionTypeName.HeaderText = "TransactionTypeName"
        Me.TransactionTypeName.Name = "TransactionTypeName"
        Me.TransactionTypeName.ReadOnly = True
        Me.TransactionTypeName.Visible = False
        '
        'TYPEFLAGNAME
        '
        Me.TYPEFLAGNAME.DataPropertyName = "TYPEFLAGNAME"
        Me.TYPEFLAGNAME.HeaderText = "TYPEFLAGNAME"
        Me.TYPEFLAGNAME.Name = "TYPEFLAGNAME"
        Me.TYPEFLAGNAME.ReadOnly = True
        Me.TYPEFLAGNAME.Visible = False
        '
        'FIFO_TYPE
        '
        Me.FIFO_TYPE.DataPropertyName = "FIFO_TYPE"
        Me.FIFO_TYPE.HeaderText = "FIFO_TYPE"
        Me.FIFO_TYPE.Name = "FIFO_TYPE"
        Me.FIFO_TYPE.ReadOnly = True
        Me.FIFO_TYPE.Visible = False
        '
        'FIFO_RULEName
        '
        Me.FIFO_RULEName.DataPropertyName = "FIFO_RULEName"
        Me.FIFO_RULEName.HeaderText = "FIFO_RULEName"
        Me.FIFO_RULEName.Name = "FIFO_RULEName"
        Me.FIFO_RULEName.ReadOnly = True
        Me.FIFO_RULEName.Visible = False
        '
        'FIFO_REFER
        '
        Me.FIFO_REFER.DataPropertyName = "FIFO_REFER"
        Me.FIFO_REFER.HeaderText = "FIFO_REFER"
        Me.FIFO_REFER.Name = "FIFO_REFER"
        Me.FIFO_REFER.ReadOnly = True
        Me.FIFO_REFER.Visible = False
        '
        'PackingSame
        '
        Me.PackingSame.DataPropertyName = "PackingSame"
        Me.PackingSame.HeaderText = "PackingSame"
        Me.PackingSame.Name = "PackingSame"
        Me.PackingSame.ReadOnly = True
        Me.PackingSame.Visible = False
        '
        'TYPEFLAG
        '
        Me.TYPEFLAG.DataPropertyName = "TYPEFLAG"
        Me.TYPEFLAG.HeaderText = "TYPEFLAG"
        Me.TYPEFLAG.Name = "TYPEFLAG"
        Me.TYPEFLAG.ReadOnly = True
        Me.TYPEFLAG.Visible = False
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAdd, Me.btnDelete, Me.btnEdit, Me.btnSave, Me.btnBack, Me.LabelItem5, Me.LabelItem2, Me.txtMaterialNO, Me.btnQuery, Me.lblMessage})
        Me.Bar1.Location = New System.Drawing.Point(0, 25)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Bar1.Size = New System.Drawing.Size(920, 27)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 143
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
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
        Me.btnDelete.Text = "作废"
        Me.btnDelete.Tooltip = "删除"
        '
        'btnEdit
        '
        Me.btnEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEdit.Image = Global.WmsManagement.My.Resources.Resources.edit
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "修改"
        Me.btnEdit.Tooltip = "修改"
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSave.Enabled = False
        Me.btnSave.Image = Global.WmsManagement.My.Resources.Resources.save
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "保存"
        Me.btnSave.Tooltip = "保存"
        '
        'btnBack
        '
        Me.btnBack.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnBack.Enabled = False
        Me.btnBack.Image = Global.WmsManagement.My.Resources.Resources.back
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Text = "返回"
        Me.btnBack.Tooltip = "返回"
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
        Me.LabelItem2.Text = "料件代码:"
        '
        'txtMaterialNO
        '
        Me.txtMaterialNO.FocusHighlightColor = System.Drawing.Color.Transparent
        Me.txtMaterialNO.Name = "txtMaterialNO"
        Me.txtMaterialNO.Tag = "查询单号"
        Me.txtMaterialNO.TextBoxWidth = 150
        Me.txtMaterialNO.WatermarkColor = System.Drawing.SystemColors.GrayText
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
        'dgvBarcodeQuery
        '
        Me.dgvBarcodeQuery.AllowUserToAddRows = False
        Me.dgvBarcodeQuery.AllowUserToDeleteRows = False
        Me.dgvBarcodeQuery.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarcodeQuery.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBarcodeQuery.ColumnHeadersHeight = 28
        Me.dgvBarcodeQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvBarcodeQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ScanBarcodeId, Me.ScanTransactionId, Me.BarCode, Me.ScanMaterialNO, Me.ScanDescription, Me.ScanSpecification, Me.ScanQuantity, Me.DataGridViewTextBoxColumn10, Me.ScanCreateUser, Me.ScanCreateTime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBarcodeQuery.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBarcodeQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBarcodeQuery.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvBarcodeQuery.Location = New System.Drawing.Point(0, 0)
        Me.dgvBarcodeQuery.Name = "dgvBarcodeQuery"
        Me.dgvBarcodeQuery.RowHeadersWidth = 15
        Me.dgvBarcodeQuery.RowTemplate.Height = 23
        Me.dgvBarcodeQuery.Size = New System.Drawing.Size(920, 163)
        Me.dgvBarcodeQuery.TabIndex = 2
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
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "PackingSame"
        Me.DataGridViewTextBoxColumn10.HeaderText = "条码是否相同"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
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
        'TransactionId
        '
        Me.TransactionId.DataPropertyName = "TransactionId"
        Me.TransactionId.HeaderText = "TransactionId"
        Me.TransactionId.Name = "TransactionId"
        Me.TransactionId.ReadOnly = True
        Me.TransactionId.Visible = False
        '
        'RowNum
        '
        Me.RowNum.DataPropertyName = "RowNum"
        Me.RowNum.HeaderText = "序号"
        Me.RowNum.Name = "RowNum"
        Me.RowNum.ReadOnly = True
        Me.RowNum.Visible = False
        Me.RowNum.Width = 35
        '
        'MaterialNO
        '
        Me.MaterialNO.DataPropertyName = "MaterialNO"
        Me.MaterialNO.HeaderText = "货品编码"
        Me.MaterialNO.Name = "MaterialNO"
        Me.MaterialNO.ReadOnly = True
        Me.MaterialNO.Width = 82
        '
        'InvoiceDefinitionsName
        '
        Me.InvoiceDefinitionsName.DataPropertyName = "InvoiceDefinitionsName"
        Me.InvoiceDefinitionsName.HeaderText = "类型"
        Me.InvoiceDefinitionsName.Name = "InvoiceDefinitionsName"
        Me.InvoiceDefinitionsName.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn1.HeaderText = "货品名称"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 83
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Specification"
        Me.DataGridViewTextBoxColumn7.HeaderText = "规格型号"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 82
        '
        'Uint
        '
        Me.Uint.DataPropertyName = "Uint"
        Me.Uint.HeaderText = "计量单位"
        Me.Uint.Name = "Uint"
        Me.Uint.ReadOnly = True
        Me.Uint.Width = 82
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn8.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 82
        '
        'UnitPrice
        '
        Me.UnitPrice.DataPropertyName = "UnitPrice"
        Me.UnitPrice.HeaderText = "单价"
        Me.UnitPrice.Name = "UnitPrice"
        Me.UnitPrice.ReadOnly = True
        Me.UnitPrice.Width = 82
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
        'FrmMaterialManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 484)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.ExpandableSplitterItem)
        Me.Controls.Add(Me.dgvMaterial)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "FrmMaterialManagement"
        Me.ShowIcon = False
        Me.Text = "料件基础管理"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel4.ResumeLayout(False)
        Me.SuperTabControlPanel5.ResumeLayout(False)
        CType(Me.dgvTransactionItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel3.ResumeLayout(False)
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        CType(Me.dgvMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBarcodeQuery, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel5 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem5 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ExpandableSplitterItem As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents dgvMaterial As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtMaterialNO As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SuperTabControlPanel3 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem3 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents cboFIFOType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkFIFO As System.Windows.Forms.CheckBox
    Friend WithEvents dgvBarcode As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cboTransactionType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents cboMaterialType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnBack As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents chkPackingSame As System.Windows.Forms.CheckBox
    Friend WithEvents txtPackingQuantity As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkPackingQuantityScan As System.Windows.Forms.CheckBox
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents dgvTransactionItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents MATERIAL_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MATERIAL_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPECIFICATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUANTITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoStorageQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DELETEFLAG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATE_USERID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATE_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DELETE_USERID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DELETE_TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionTypeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TYPEFLAGNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIFO_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIFO_RULEName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FIFO_REFER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingSame As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TYPEFLAG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reel_BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Warehouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem6 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents dgvBarcodeQuery As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ScanBarcodeId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanTransactionId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanMaterialNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanSpecification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanCreateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanCreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RowNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaterialNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDefinitionsName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Uint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemtotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemRemark As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
