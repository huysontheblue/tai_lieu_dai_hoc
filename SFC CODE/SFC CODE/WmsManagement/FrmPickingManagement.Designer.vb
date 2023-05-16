<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPickingManagement
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel4 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DataGridViewX2 = New DevComponents.DotNetBar.Controls.DataGridViewX()
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
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel6 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperTabItem4 = New DevComponents.DotNetBar.SuperTabItem()
        Me.ExpandableSplitterItem = New DevComponents.DotNetBar.ExpandableSplitter()
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
        Me.ActiveFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.dtpDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonItem()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEdit = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.LabelItem5 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.txtTransactionId = New DevComponents.DotNetBar.TextBoxItem()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.lblMessage = New DevComponents.DotNetBar.LabelItem()
        Me.menuStrip1.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel4.SuspendLayout()
        CType(Me.DataGridViewX2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel6.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1045, 25)
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
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel6)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.Location = New System.Drawing.Point(0, 260)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(1045, 249)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SuperTabControl1.TabIndex = 151
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem2, Me.SuperTabItem4})
        '
        'SuperTabControlPanel4
        '
        Me.SuperTabControlPanel4.Controls.Add(Me.DataGridViewX2)
        Me.SuperTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel4.Location = New System.Drawing.Point(0, 28)
        Me.SuperTabControlPanel4.Name = "SuperTabControlPanel4"
        Me.SuperTabControlPanel4.Size = New System.Drawing.Size(1045, 221)
        Me.SuperTabControlPanel4.TabIndex = 1
        Me.SuperTabControlPanel4.TabItem = Me.SuperTabItem2
        '
        'DataGridViewX2
        '
        Me.DataGridViewX2.AllowUserToAddRows = False
        Me.DataGridViewX2.AllowUserToDeleteRows = False
        Me.DataGridViewX2.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX2.ColumnHeadersHeight = 28
        Me.DataGridViewX2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewX2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewX2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewX2.EnableHeadersVisualStyles = False
        Me.DataGridViewX2.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.DataGridViewX2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewX2.Name = "DataGridViewX2"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX2.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewX2.RowHeadersWidth = 15
        Me.DataGridViewX2.RowTemplate.Height = 23
        Me.DataGridViewX2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewX2.Size = New System.Drawing.Size(1045, 221)
        Me.DataGridViewX2.TabIndex = 141
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "RowNum"
        Me.DataGridViewTextBoxColumn15.HeaderText = "序号"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 35
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "MaterialNO"
        Me.DataGridViewTextBoxColumn16.HeaderText = "货品编码"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Width = 82
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Description"
        Me.DataGridViewTextBoxColumn17.HeaderText = "货品名称"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 83
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Specification"
        Me.DataGridViewTextBoxColumn18.HeaderText = "规格型号"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 82
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Uint"
        Me.DataGridViewTextBoxColumn19.HeaderText = "计量单位"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Width = 82
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn20.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Width = 82
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "UnitPrice"
        Me.DataGridViewTextBoxColumn21.HeaderText = "单价"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 82
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "totalAmount"
        Me.DataGridViewTextBoxColumn22.HeaderText = "金额"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 83
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "OrderNumber"
        Me.DataGridViewTextBoxColumn23.HeaderText = "订单号"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 82
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "Remark"
        Me.DataGridViewTextBoxColumn24.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Width = 225
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel4
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "捡料明细"
        '
        'SuperTabControlPanel6
        '
        Me.SuperTabControlPanel6.Controls.Add(Me.DataGridViewX1)
        Me.SuperTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel6.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel6.Name = "SuperTabControlPanel6"
        Me.SuperTabControlPanel6.Size = New System.Drawing.Size(1045, 249)
        Me.SuperTabControlPanel6.TabIndex = 0
        Me.SuperTabControlPanel6.TabItem = Me.SuperTabItem4
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToDeleteRows = False
        Me.DataGridViewX1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridViewX1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewX1.ColumnHeadersHeight = 28
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewX1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridViewX1.EnableHeadersVisualStyles = False
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewX1.MultiSelect = False
        Me.DataGridViewX1.Name = "DataGridViewX1"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewX1.RowHeadersWidth = 15
        Me.DataGridViewX1.RowTemplate.Height = 28
        Me.DataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewX1.Size = New System.Drawing.Size(1045, 235)
        Me.DataGridViewX1.TabIndex = 145
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "条码"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "MATERIAL_NO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "物料编码"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "DESCRIPTION"
        Me.DataGridViewTextBoxColumn8.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "SPECIFICATION"
        Me.DataGridViewTextBoxColumn10.HeaderText = "规格"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "UOM_NAME"
        Me.DataGridViewTextBoxColumn11.HeaderText = "单位"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "QUANTITY"
        Me.DataGridViewTextBoxColumn12.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "DataCode"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "DELETEFLAG"
        Me.DataGridViewTextBoxColumn14.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'SuperTabItem4
        '
        Me.SuperTabItem4.AttachedControl = Me.SuperTabControlPanel6
        Me.SuperTabItem4.GlobalItem = False
        Me.SuperTabItem4.Name = "SuperTabItem4"
        Me.SuperTabItem4.Text = "批次明细"
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
        Me.ExpandableSplitterItem.Location = New System.Drawing.Point(0, 254)
        Me.ExpandableSplitterItem.Name = "ExpandableSplitterItem"
        Me.ExpandableSplitterItem.Size = New System.Drawing.Size(1045, 6)
        Me.ExpandableSplitterItem.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitterItem.TabIndex = 150
        Me.ExpandableSplitterItem.TabStop = False
        '
        'dgvInvoiceTransaction
        '
        Me.dgvInvoiceTransaction.AllowUserToAddRows = False
        Me.dgvInvoiceTransaction.AllowUserToDeleteRows = False
        Me.dgvInvoiceTransaction.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceTransaction.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvInvoiceTransaction.ColumnHeadersHeight = 28
        Me.dgvInvoiceTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInvoiceTransaction.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceTransactionId, Me.NO, Me.InvoiceTransactionTypeName, Me.TransactionId, Me.CreateTime1, Me.WarehouseName, Me.DeptName, Me.SupplierName, Me.TotalAmount, Me.DeliveryName, Me.AttentionName, Me.Column11, Me.TotalNumber, Me.TotalConversionUnits, Me.Remark, Me.CreateUser, Me.CreateTime, Me.UpdateUser, Me.UpdateTime, Me.ActiveFlag})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInvoiceTransaction.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvInvoiceTransaction.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvInvoiceTransaction.EnableHeadersVisualStyles = False
        Me.dgvInvoiceTransaction.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvInvoiceTransaction.Location = New System.Drawing.Point(0, 53)
        Me.dgvInvoiceTransaction.Name = "dgvInvoiceTransaction"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceTransaction.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvInvoiceTransaction.RowHeadersWidth = 15
        Me.dgvInvoiceTransaction.RowTemplate.Height = 28
        Me.dgvInvoiceTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInvoiceTransaction.Size = New System.Drawing.Size(1045, 201)
        Me.dgvInvoiceTransaction.TabIndex = 149
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
        Me.InvoiceTransactionTypeName.Width = 54
        '
        'TransactionId
        '
        Me.TransactionId.DataPropertyName = "TransactionId"
        Me.TransactionId.HeaderText = "单号"
        Me.TransactionId.Name = "TransactionId"
        Me.TransactionId.ReadOnly = True
        Me.TransactionId.Width = 54
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
        'ActiveFlag
        '
        Me.ActiveFlag.HeaderText = "状态"
        Me.ActiveFlag.Name = "ActiveFlag"
        Me.ActiveFlag.ReadOnly = True
        Me.ActiveFlag.Width = 30
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Controls.Add(Me.dtpDate)
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAdd, Me.btnDelete, Me.btnEdit, Me.LabelItem3, Me.LabelItem4, Me.ControlContainerItem1, Me.LabelItem5, Me.LabelItem2, Me.txtTransactionId, Me.btnQuery, Me.lblMessage})
        Me.Bar1.Location = New System.Drawing.Point(0, 25)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Bar1.Size = New System.Drawing.Size(1045, 28)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 148
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
        Me.dtpDate.Location = New System.Drawing.Point(214, 2)
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
        Me.btnEdit.Image = Global.WmsManagement.My.Resources.Resources.edit
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "修改"
        Me.btnEdit.Tooltip = "修改"
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
        'FrmPickingManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 509)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.ExpandableSplitterItem)
        Me.Controls.Add(Me.dgvInvoiceTransaction)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Name = "FrmPickingManagement"
        Me.ShowIcon = False
        Me.Text = "捡料管理"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel4.ResumeLayout(False)
        CType(Me.DataGridViewX2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel6.ResumeLayout(False)
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        CType(Me.dtpDate, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents SuperTabControlPanel4 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents DataGridViewX2 As DevComponents.DotNetBar.Controls.DataGridViewX
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
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel6 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuperTabItem4 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ExpandableSplitterItem As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents dgvInvoiceTransaction As DevComponents.DotNetBar.Controls.DataGridViewX
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
    Friend WithEvents ActiveFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents dtpDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEdit As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents LabelItem5 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtTransactionId As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelItem
End Class
