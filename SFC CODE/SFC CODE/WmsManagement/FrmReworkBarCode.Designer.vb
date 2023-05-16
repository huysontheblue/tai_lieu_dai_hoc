<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReworkBarCode
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
        Me.chkScanProduct = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.chkRule = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtRule = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtQuantity = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Versions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendorCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPECIFICATION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MATERIAL_NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChkSelect = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.chkPackingSame = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnDefine = New DevComponents.DotNetBar.ButtonX()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonX()
        Me.chkQuantity = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtBarCode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblDescription = New DevComponents.DotNetBar.LabelX()
        Me.dgvBarcode = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkScanProduct
        '
        '
        '
        '
        Me.chkScanProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkScanProduct.Location = New System.Drawing.Point(531, 42)
        Me.chkScanProduct.Name = "chkScanProduct"
        Me.chkScanProduct.Size = New System.Drawing.Size(100, 23)
        Me.chkScanProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkScanProduct.TabIndex = 42
        Me.chkScanProduct.Text = "扫描产品"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(15, 11)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(608, 23)
        Me.LabelX10.TabIndex = 40
        Me.LabelX10.Text = "▼规则比对使用*代表变量，扫描勾选扫描数量,只针对包装条码相同,数量不同成品"
        '
        'chkRule
        '
        '
        '
        '
        Me.chkRule.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkRule.Location = New System.Drawing.Point(446, 106)
        Me.chkRule.Name = "chkRule"
        Me.chkRule.Size = New System.Drawing.Size(100, 23)
        Me.chkRule.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkRule.TabIndex = 39
        Me.chkRule.Text = "检查规则"
        '
        'txtRule
        '
        '
        '
        '
        Me.txtRule.Border.Class = "TextBoxBorder"
        Me.txtRule.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRule.Enabled = False
        Me.txtRule.Location = New System.Drawing.Point(77, 107)
        Me.txtRule.Name = "txtRule"
        Me.txtRule.Size = New System.Drawing.Size(351, 21)
        Me.txtRule.TabIndex = 37
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(15, 107)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 38
        Me.LabelX2.Text = "扫描规则"
        '
        'txtQuantity
        '
        '
        '
        '
        Me.txtQuantity.Border.Class = "TextBoxBorder"
        Me.txtQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtQuantity.Enabled = False
        Me.txtQuantity.Location = New System.Drawing.Point(77, 75)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(351, 21)
        Me.txtQuantity.TabIndex = 35
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(15, 75)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 36
        Me.LabelX1.Text = "扫描数量"
        '
        'Versions
        '
        Me.Versions.DataPropertyName = "Versions"
        Me.Versions.HeaderText = "Versions"
        Me.Versions.Name = "Versions"
        Me.Versions.ReadOnly = True
        Me.Versions.Visible = False
        '
        'DateCode
        '
        Me.DateCode.DataPropertyName = "DateCode"
        Me.DateCode.HeaderText = "DateCode"
        Me.DateCode.Name = "DateCode"
        Me.DateCode.ReadOnly = True
        Me.DateCode.Visible = False
        '
        'VendorCode
        '
        Me.VendorCode.DataPropertyName = "VendorCode"
        Me.VendorCode.HeaderText = "VendorCode"
        Me.VendorCode.Name = "VendorCode"
        Me.VendorCode.ReadOnly = True
        Me.VendorCode.Visible = False
        '
        'UOM_NAME
        '
        Me.UOM_NAME.DataPropertyName = "UOM_NAME"
        Me.UOM_NAME.HeaderText = "单位"
        Me.UOM_NAME.Name = "UOM_NAME"
        Me.UOM_NAME.ReadOnly = True
        '
        'SPECIFICATION
        '
        Me.SPECIFICATION.DataPropertyName = "SPECIFICATION"
        Me.SPECIFICATION.HeaderText = "规格"
        Me.SPECIFICATION.Name = "SPECIFICATION"
        Me.SPECIFICATION.ReadOnly = True
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.DataPropertyName = "DESCRIPTION"
        Me.DESCRIPTION.HeaderText = "品名"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.ReadOnly = True
        '
        'MATERIAL_NO
        '
        Me.MATERIAL_NO.DataPropertyName = "MATERIALNO"
        Me.MATERIAL_NO.HeaderText = "料号"
        Me.MATERIAL_NO.Name = "MATERIAL_NO"
        Me.MATERIAL_NO.ReadOnly = True
        Me.MATERIAL_NO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "QUANTITY"
        Me.Quantity.HeaderText = "数量"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'BarCode
        '
        Me.BarCode.DataPropertyName = "BARCODE"
        Me.BarCode.HeaderText = "条码"
        Me.BarCode.Name = "BarCode"
        Me.BarCode.ReadOnly = True
        Me.BarCode.Width = 150
        '
        'ChkSelect
        '
        Me.ChkSelect.Checked = True
        Me.ChkSelect.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.ChkSelect.CheckValue = Nothing
        Me.ChkSelect.HeaderText = "选择"
        Me.ChkSelect.Name = "ChkSelect"
        Me.ChkSelect.Visible = False
        Me.ChkSelect.Width = 35
        '
        'chkPackingSame
        '
        '
        '
        '
        Me.chkPackingSame.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkPackingSame.Location = New System.Drawing.Point(446, 42)
        Me.chkPackingSame.Name = "chkPackingSame"
        Me.chkPackingSame.Size = New System.Drawing.Size(100, 23)
        Me.chkPackingSame.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkPackingSame.TabIndex = 41
        Me.chkPackingSame.Text = "相同条码"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(4, 492)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(269, 23)
        Me.lblMessage.TabIndex = 33
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(531, 492)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 32
        Me.btnCancel.Text = "关 闭"
        '
        'btnDefine
        '
        Me.btnDefine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDefine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDefine.Location = New System.Drawing.Point(405, 492)
        Me.btnDefine.Name = "btnDefine"
        Me.btnDefine.Size = New System.Drawing.Size(75, 23)
        Me.btnDefine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDefine.TabIndex = 31
        Me.btnDefine.Text = "确 定"
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDelete.Location = New System.Drawing.Point(279, 492)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDelete.TabIndex = 34
        Me.btnDelete.Text = "删 除"
        '
        'chkQuantity
        '
        '
        '
        '
        Me.chkQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkQuantity.Location = New System.Drawing.Point(446, 74)
        Me.chkQuantity.Name = "chkQuantity"
        Me.chkQuantity.Size = New System.Drawing.Size(100, 23)
        Me.chkQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkQuantity.TabIndex = 29
        Me.chkQuantity.Text = "扫描数量"
        '
        'txtBarCode
        '
        '
        '
        '
        Me.txtBarCode.Border.Class = "TextBoxBorder"
        Me.txtBarCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBarCode.Location = New System.Drawing.Point(77, 44)
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(351, 21)
        Me.txtBarCode.TabIndex = 27
        '
        'lblDescription
        '
        '
        '
        '
        Me.lblDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDescription.Location = New System.Drawing.Point(15, 44)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(75, 23)
        Me.lblDescription.TabIndex = 28
        Me.lblDescription.Text = "扫描条码"
        '
        'dgvBarcode
        '
        Me.dgvBarcode.AllowUserToAddRows = False
        Me.dgvBarcode.AllowUserToDeleteRows = False
        Me.dgvBarcode.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvBarcode.ColumnHeadersHeight = 28
        Me.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvBarcode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChkSelect, Me.BarCode, Me.Quantity, Me.MATERIAL_NO, Me.DESCRIPTION, Me.SPECIFICATION, Me.UOM_NAME, Me.VendorCode, Me.DateCode, Me.Versions})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBarcode.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBarcode.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvBarcode.Location = New System.Drawing.Point(4, 136)
        Me.dgvBarcode.Name = "dgvBarcode"
        Me.dgvBarcode.RowHeadersWidth = 15
        Me.dgvBarcode.RowTemplate.Height = 28
        Me.dgvBarcode.Size = New System.Drawing.Size(627, 344)
        Me.dgvBarcode.TabIndex = 30
        '
        'FrmReworkBarCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 527)
        Me.Controls.Add(Me.chkScanProduct)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.chkRule)
        Me.Controls.Add(Me.txtRule)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.chkPackingSame)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDefine)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.chkQuantity)
        Me.Controls.Add(Me.txtBarCode)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.dgvBarcode)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReworkBarCode"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "退货重工条码扫描"
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkScanProduct As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkRule As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtRule As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtQuantity As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Versions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPECIFICATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MATERIAL_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkSelect As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents chkPackingSame As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDefine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkQuantity As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtBarCode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblDescription As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvBarcode As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
