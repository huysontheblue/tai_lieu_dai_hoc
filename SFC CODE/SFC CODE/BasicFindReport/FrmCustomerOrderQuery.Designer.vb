<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomerOrderQuery
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCustomerOrderQuery))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFNSKU = New System.Windows.Forms.TextBox()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.txtShippingNO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCustomerOrder = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.OrderNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FNSKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExportingCountries = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingMethod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRDimensions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerDelivery = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExportQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrinteQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StorageQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShipmentsQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolQty = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuItemAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolReflsh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GbCondition = New System.Windows.Forms.GroupBox()
        Me.txtPartId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        CType(Me.dgvCustomerOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GbCondition.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 12)
        Me.Label5.TabIndex = 226
        Me.Label5.Text = "生产SKU码："
        '
        'txtFNSKU
        '
        Me.txtFNSKU.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFNSKU.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtFNSKU.Location = New System.Drawing.Point(83, 56)
        Me.txtFNSKU.MaxLength = 20
        Me.txtFNSKU.Name = "txtFNSKU"
        Me.txtFNSKU.Size = New System.Drawing.Size(136, 21)
        Me.txtFNSKU.TabIndex = 225
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(313, 20)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpStartDate.TabIndex = 223
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(481, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 222
        Me.Label4.Text = "结束日期："
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(543, 20)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpEndDate.TabIndex = 221
        '
        'txtShippingNO
        '
        Me.txtShippingNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShippingNO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtShippingNO.Location = New System.Drawing.Point(83, 20)
        Me.txtShippingNO.MaxLength = 20
        Me.txtShippingNO.Name = "txtShippingNO"
        Me.txtShippingNO.Size = New System.Drawing.Size(136, 21)
        Me.txtShippingNO.TabIndex = 219
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(242, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "开始日期："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 224
        Me.Label1.Text = "合约定单号："
        '
        'dgvCustomerOrder
        '
        Me.dgvCustomerOrder.AllowUserToAddRows = False
        Me.dgvCustomerOrder.AllowUserToDeleteRows = False
        Me.dgvCustomerOrder.AllowUserToOrderColumns = True
        Me.dgvCustomerOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCustomerOrder.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvCustomerOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCustomerOrder.ColumnHeadersHeight = 28
        Me.dgvCustomerOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvCustomerOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderNO, Me.PartId, Me.FNSKU, Me.ExportingCountries, Me.ShippingMethod, Me.PRDimensions, Me.CustomerDelivery, Me.ExportQuantity, Me.PrinteQuantity, Me.PackingQuantity, Me.StorageQuantity, Me.ShipmentsQuantity})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCustomerOrder.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCustomerOrder.EnableHeadersVisualStyles = False
        Me.dgvCustomerOrder.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvCustomerOrder.Location = New System.Drawing.Point(2, 125)
        Me.dgvCustomerOrder.Name = "dgvCustomerOrder"
        Me.dgvCustomerOrder.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCustomerOrder.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCustomerOrder.RowHeadersWidth = 15
        Me.dgvCustomerOrder.RowTemplate.Height = 23
        Me.dgvCustomerOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCustomerOrder.Size = New System.Drawing.Size(1047, 400)
        Me.dgvCustomerOrder.TabIndex = 147
        '
        'OrderNO
        '
        Me.OrderNO.DataPropertyName = "OrderNO"
        Me.OrderNO.HeaderText = "合约订单号"
        Me.OrderNO.Name = "OrderNO"
        Me.OrderNO.ReadOnly = True
        Me.OrderNO.Width = 120
        '
        'PartId
        '
        Me.PartId.DataPropertyName = "PartId"
        Me.PartId.HeaderText = "料号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        Me.PartId.Width = 120
        '
        'FNSKU
        '
        Me.FNSKU.DataPropertyName = "FNSKU"
        Me.FNSKU.HeaderText = "FNSKU"
        Me.FNSKU.Name = "FNSKU"
        Me.FNSKU.ReadOnly = True
        '
        'ExportingCountries
        '
        Me.ExportingCountries.DataPropertyName = "ExportingCountries"
        Me.ExportingCountries.HeaderText = "出口国家"
        Me.ExportingCountries.Name = "ExportingCountries"
        Me.ExportingCountries.ReadOnly = True
        '
        'ShippingMethod
        '
        Me.ShippingMethod.DataPropertyName = "ShippingMethod"
        Me.ShippingMethod.HeaderText = "交货方式"
        Me.ShippingMethod.Name = "ShippingMethod"
        Me.ShippingMethod.ReadOnly = True
        '
        'PRDimensions
        '
        Me.PRDimensions.DataPropertyName = "PRDimensions"
        Me.PRDimensions.HeaderText = "PR维度"
        Me.PRDimensions.Name = "PRDimensions"
        Me.PRDimensions.ReadOnly = True
        '
        'CustomerDelivery
        '
        Me.CustomerDelivery.DataPropertyName = "CustomerDelivery"
        Me.CustomerDelivery.HeaderText = "客户交期"
        Me.CustomerDelivery.Name = "CustomerDelivery"
        Me.CustomerDelivery.ReadOnly = True
        '
        'ExportQuantity
        '
        Me.ExportQuantity.DataPropertyName = "ExportQuantity"
        Me.ExportQuantity.HeaderText = "交货数量"
        Me.ExportQuantity.Name = "ExportQuantity"
        Me.ExportQuantity.ReadOnly = True
        Me.ExportQuantity.Width = 60
        '
        'PrinteQuantity
        '
        Me.PrinteQuantity.DataPropertyName = "PrinteQuantity"
        Me.PrinteQuantity.HeaderText = "打印数量"
        Me.PrinteQuantity.Name = "PrinteQuantity"
        Me.PrinteQuantity.ReadOnly = True
        Me.PrinteQuantity.Width = 60
        '
        'PackingQuantity
        '
        Me.PackingQuantity.DataPropertyName = "PackingQuantity"
        Me.PackingQuantity.HeaderText = "包装数量"
        Me.PackingQuantity.Name = "PackingQuantity"
        Me.PackingQuantity.ReadOnly = True
        Me.PackingQuantity.Width = 60
        '
        'StorageQuantity
        '
        Me.StorageQuantity.DataPropertyName = "StorageQuantity"
        Me.StorageQuantity.HeaderText = "入库数量"
        Me.StorageQuantity.Name = "StorageQuantity"
        Me.StorageQuantity.ReadOnly = True
        Me.StorageQuantity.Width = 60
        '
        'ShipmentsQuantity
        '
        Me.ShipmentsQuantity.DataPropertyName = "ShipmentsQuantity"
        Me.ShipmentsQuantity.HeaderText = "出货数量"
        Me.ShipmentsQuantity.Name = "ShipmentsQuantity"
        Me.ShipmentsQuantity.ReadOnly = True
        Me.ShipmentsQuantity.Width = 60
        '
        'ToolCount
        '
        Me.ToolCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(66, 17)
        Me.ToolCount.Text = "记录笔数:0"
        '
        'ToolQty
        '
        Me.ToolQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolQty.ForeColor = System.Drawing.Color.Black
        Me.ToolQty.Name = "ToolQty"
        Me.ToolQty.Size = New System.Drawing.Size(66, 17)
        Me.ToolQty.Text = "出库总数:0"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolCount, Me.ToolQty})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 530)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1049, 22)
        Me.StatusStrip1.TabIndex = 144
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuItemAll
        '
        Me.MenuItemAll.Name = "MenuItemAll"
        Me.MenuItemAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MenuItemAll.Size = New System.Drawing.Size(191, 22)
        Me.MenuItemAll.Text = "全選"
        '
        'MenuItemNone
        '
        Me.MenuItemNone.Name = "MenuItemNone"
        Me.MenuItemNone.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MenuItemNone.Size = New System.Drawing.Size(191, 22)
        Me.MenuItemNone.Text = "全不選"
        '
        'MenuItemDetail
        '
        Me.MenuItemDetail.Name = "MenuItemDetail"
        Me.MenuItemDetail.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.MenuItemDetail.Size = New System.Drawing.Size(191, 22)
        Me.MenuItemDetail.Text = "顯示詳細 "
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemAll, Me.MenuItemNone, Me.MenuItemDetail})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(192, 70)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'ToolReflsh
        '
        Me.ToolReflsh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolReflsh.Image = CType(resources.GetObject("ToolReflsh.Image"), System.Drawing.Image)
        Me.ToolReflsh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReflsh.Name = "ToolReflsh"
        Me.ToolReflsh.Size = New System.Drawing.Size(63, 20)
        Me.ToolReflsh.Text = "刷    新"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'ToolExcel
        '
        Me.ToolExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolExcel.Image = CType(resources.GetObject("ToolExcel.Image"), System.Drawing.Image)
        Me.ToolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExcel.Name = "ToolExcel"
        Me.ToolExcel.Size = New System.Drawing.Size(60, 20)
        Me.ToolExcel.Text = "汇   出"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'ToolExit
        '
        Me.ToolExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(63, 20)
        Me.ToolExit.Text = "退    出"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ToolReflsh, Me.ToolStripSeparator2, Me.ToolExcel, Me.ToolStripSeparator1, Me.ToolExit})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1049, 26)
        Me.ToolStrip1.TabIndex = 145
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'GbCondition
        '
        Me.GbCondition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbCondition.Controls.Add(Me.txtPartId)
        Me.GbCondition.Controls.Add(Me.Label2)
        Me.GbCondition.Controls.Add(Me.txtFNSKU)
        Me.GbCondition.Controls.Add(Me.dtpEndDate)
        Me.GbCondition.Controls.Add(Me.lblMessage)
        Me.GbCondition.Controls.Add(Me.Label5)
        Me.GbCondition.Controls.Add(Me.dtpStartDate)
        Me.GbCondition.Controls.Add(Me.Label4)
        Me.GbCondition.Controls.Add(Me.txtShippingNO)
        Me.GbCondition.Controls.Add(Me.Label3)
        Me.GbCondition.Controls.Add(Me.Label1)
        Me.GbCondition.ForeColor = System.Drawing.Color.Black
        Me.GbCondition.Location = New System.Drawing.Point(2, 29)
        Me.GbCondition.Name = "GbCondition"
        Me.GbCondition.Size = New System.Drawing.Size(1047, 90)
        Me.GbCondition.TabIndex = 143
        Me.GbCondition.TabStop = False
        '
        'txtPartId
        '
        Me.txtPartId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartId.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPartId.Location = New System.Drawing.Point(313, 56)
        Me.txtPartId.MaxLength = 20
        Me.txtPartId.Name = "txtPartId"
        Me.txtPartId.Size = New System.Drawing.Size(136, 21)
        Me.txtPartId.TabIndex = 229
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(266, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 230
        Me.Label2.Text = "料号："
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(483, 55)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(454, 23)
        Me.lblMessage.TabIndex = 228
        '
        'FrmCustomerOrderQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 552)
        Me.Controls.Add(Me.dgvCustomerOrder)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GbCondition)
        Me.Name = "FrmCustomerOrderQuery"
        Me.ShowIcon = False
        Me.Text = "海翼出货状况报表"
        CType(Me.dgvCustomerOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GbCondition.ResumeLayout(False)
        Me.GbCondition.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFNSKU As System.Windows.Forms.TextBox
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtShippingNO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvCustomerOrder As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolQty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuItemAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemDetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolReflsh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents OrderNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FNSKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExportingCountries As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRDimensions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerDelivery As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExportQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrinteQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StorageQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentsQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPartId As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
