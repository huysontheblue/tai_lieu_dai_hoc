<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomerOrderImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCustomerOrderImport))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.lblMessage = New System.Windows.Forms.ToolStripLabel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtContractOrder = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.mtxtImportURL = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.dgvImport = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.OrderNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExportQuantity = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.FNSKU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExportingCountries = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShippingMethod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRDimensions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.titlemini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerDelivery = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.LinkLabelImportFile = New System.Windows.Forms.LinkLabel()
        Me.ToolBt.SuspendLayout()
        CType(Me.dgvImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolDelete, Me.ToolCommit, Me.ToolBack, Me.ToolStripSeparator1, Me.ToolExitFrom, Me.lblMessage})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1090, 25)
        Me.ToolBt.TabIndex = 135
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
        Me.ToolBack.Enabled = False
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
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
        'lblMessage
        '
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 22)
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(23, 40)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(82, 23)
        Me.LabelX1.TabIndex = 136
        Me.LabelX1.Text = "合约订单号："
        '
        'mtxtContractOrder
        '
        '
        '
        '
        Me.mtxtContractOrder.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtContractOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtContractOrder.Location = New System.Drawing.Point(100, 41)
        Me.mtxtContractOrder.Name = "mtxtContractOrder"
        Me.mtxtContractOrder.ReadOnly = True
        Me.mtxtContractOrder.Size = New System.Drawing.Size(155, 21)
        Me.mtxtContractOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtContractOrder.TabIndex = 137
        Me.mtxtContractOrder.Text = ""
        '
        'mtxtImportURL
        '
        '
        '
        '
        Me.mtxtImportURL.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtImportURL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtImportURL.ButtonCustom.Visible = True
        Me.mtxtImportURL.Location = New System.Drawing.Point(360, 41)
        Me.mtxtImportURL.Name = "mtxtImportURL"
        Me.mtxtImportURL.ReadOnly = True
        Me.mtxtImportURL.Size = New System.Drawing.Size(425, 21)
        Me.mtxtImportURL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtImportURL.TabIndex = 139
        Me.mtxtImportURL.Text = ""
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(291, 40)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 138
        Me.LabelX2.Text = "导入文件："
        '
        'dgvImport
        '
        Me.dgvImport.AllowUserToAddRows = False
        Me.dgvImport.AllowUserToDeleteRows = False
        Me.dgvImport.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvImport.ColumnHeadersHeight = 28
        Me.dgvImport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderNO, Me.PartId, Me.ExportQuantity, Me.FNSKU, Me.ExportingCountries, Me.ShippingMethod, Me.PRDimensions, Me.titlemini, Me.CustomerDelivery})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvImport.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvImport.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvImport.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvImport.Location = New System.Drawing.Point(0, 82)
        Me.dgvImport.Name = "dgvImport"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImport.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvImport.RowHeadersWidth = 15
        Me.dgvImport.RowTemplate.Height = 28
        Me.dgvImport.Size = New System.Drawing.Size(1090, 437)
        Me.dgvImport.TabIndex = 140
        '
        'OrderNO
        '
        Me.OrderNO.DataPropertyName = "OrderNO"
        Me.OrderNO.HeaderText = "订单号"
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
        Me.PartId.Width = 150
        '
        'ExportQuantity
        '
        '
        '
        '
        Me.ExportQuantity.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.ExportQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ExportQuantity.DataPropertyName = "ExportQuantity"
        Me.ExportQuantity.HeaderText = "交货数量"
        Me.ExportQuantity.MinValue = 1
        Me.ExportQuantity.Name = "ExportQuantity"
        Me.ExportQuantity.ReadOnly = True
        Me.ExportQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FNSKU
        '
        Me.FNSKU.DataPropertyName = "FNSKU"
        Me.FNSKU.HeaderText = "FNSKU"
        Me.FNSKU.Name = "FNSKU"
        Me.FNSKU.ReadOnly = True
        Me.FNSKU.Width = 120
        '
        'ExportingCountries
        '
        Me.ExportingCountries.DataPropertyName = "ExportingCountries"
        Me.ExportingCountries.HeaderText = "出口国家"
        Me.ExportingCountries.Name = "ExportingCountries"
        Me.ExportingCountries.ReadOnly = True
        Me.ExportingCountries.Width = 120
        '
        'ShippingMethod
        '
        Me.ShippingMethod.DataPropertyName = "ShippingMethod"
        Me.ShippingMethod.HeaderText = "交货方式"
        Me.ShippingMethod.Name = "ShippingMethod"
        Me.ShippingMethod.ReadOnly = True
        Me.ShippingMethod.Width = 120
        '
        'PRDimensions
        '
        Me.PRDimensions.DataPropertyName = "PRDimensions"
        Me.PRDimensions.HeaderText = "PR维度"
        Me.PRDimensions.Name = "PRDimensions"
        Me.PRDimensions.ReadOnly = True
        Me.PRDimensions.Width = 120
        '
        'titlemini
        '
        Me.titlemini.DataPropertyName = "titlemini"
        Me.titlemini.HeaderText = "title_mini"
        Me.titlemini.Name = "titlemini"
        Me.titlemini.ReadOnly = True
        '
        'CustomerDelivery
        '
        '
        '
        '
        Me.CustomerDelivery.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.CustomerDelivery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustomerDelivery.CustomFormat = "yyyy-MM-dd"
        Me.CustomerDelivery.DataPropertyName = "CustomerDelivery"
        Me.CustomerDelivery.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.CustomerDelivery.HeaderText = "客户交期"
        Me.CustomerDelivery.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.CustomerDelivery.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CustomerDelivery.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustomerDelivery.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.CustomerDelivery.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustomerDelivery.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        Me.CustomerDelivery.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.CustomerDelivery.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CustomerDelivery.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustomerDelivery.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.CustomerDelivery.Name = "CustomerDelivery"
        Me.CustomerDelivery.ReadOnly = True
        Me.CustomerDelivery.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CustomerDelivery.ShowUpDown = True
        Me.CustomerDelivery.Width = 150
        '
        'LinkLabelImportFile
        '
        Me.LinkLabelImportFile.AutoSize = True
        Me.LinkLabelImportFile.Location = New System.Drawing.Point(814, 46)
        Me.LinkLabelImportFile.Name = "LinkLabelImportFile"
        Me.LinkLabelImportFile.Size = New System.Drawing.Size(77, 12)
        Me.LinkLabelImportFile.TabIndex = 231
        Me.LinkLabelImportFile.TabStop = True
        Me.LinkLabelImportFile.Text = "导入模版格式"
        '
        'FrmCustomerOrderImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 519)
        Me.Controls.Add(Me.LinkLabelImportFile)
        Me.Controls.Add(Me.dgvImport)
        Me.Controls.Add(Me.mtxtImportURL)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.mtxtContractOrder)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmCustomerOrderImport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "海翼SKU导入"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.dgvImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtContractOrder As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents mtxtImportURL As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvImport As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents lblMessage As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LinkLabelImportFile As System.Windows.Forms.LinkLabel
    Friend WithEvents OrderNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExportQuantity As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents FNSKU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExportingCountries As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingMethod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRDimensions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents titlemini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerDelivery As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
End Class
