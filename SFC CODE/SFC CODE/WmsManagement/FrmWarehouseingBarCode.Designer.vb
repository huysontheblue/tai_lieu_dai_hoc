<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWarehouseingBarCode
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
        Me.txtBarCode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblDescription = New DevComponents.DotNetBar.LabelX()
        Me.chkQuantity = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.dgvBarcode = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ChkSelect = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MATERIAL_NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPECIFICATION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendorCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Versions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDefine = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.btnDelete = New DevComponents.DotNetBar.ButtonX()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBarCode
        '
        '
        '
        '
        Me.txtBarCode.Border.Class = "TextBoxBorder"
        Me.txtBarCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBarCode.Location = New System.Drawing.Point(75, 10)
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(351, 21)
        Me.txtBarCode.TabIndex = 0
        '
        'lblDescription
        '
        '
        '
        '
        Me.lblDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDescription.Location = New System.Drawing.Point(13, 10)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(75, 23)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "扫描物料"
        '
        'chkQuantity
        '
        '
        '
        '
        Me.chkQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkQuantity.Location = New System.Drawing.Point(470, 10)
        Me.chkQuantity.Name = "chkQuantity"
        Me.chkQuantity.Size = New System.Drawing.Size(100, 23)
        Me.chkQuantity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkQuantity.TabIndex = 2
        Me.chkQuantity.Text = "扫描数量"
        Me.chkQuantity.Visible = False
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
        Me.dgvBarcode.Location = New System.Drawing.Point(3, 40)
        Me.dgvBarcode.Name = "dgvBarcode"
        Me.dgvBarcode.RowHeadersWidth = 15
        Me.dgvBarcode.RowTemplate.Height = 28
        Me.dgvBarcode.Size = New System.Drawing.Size(627, 359)
        Me.dgvBarcode.TabIndex = 3
        '
        'ChkSelect
        '
        Me.ChkSelect.Checked = True
        Me.ChkSelect.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.ChkSelect.CheckValue = Nothing
        Me.ChkSelect.DataPropertyName = "ChkSelect"
        Me.ChkSelect.HeaderText = "选择"
        Me.ChkSelect.Name = "ChkSelect"
        Me.ChkSelect.Visible = False
        Me.ChkSelect.Width = 35
        '
        'BarCode
        '
        Me.BarCode.DataPropertyName = "BARCODE"
        Me.BarCode.HeaderText = "条码"
        Me.BarCode.Name = "BarCode"
        Me.BarCode.ReadOnly = True
        Me.BarCode.Width = 150
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
        'MATERIAL_NO
        '
        Me.MATERIAL_NO.DataPropertyName = "MATERIALNO"
        Me.MATERIAL_NO.HeaderText = "料号"
        Me.MATERIAL_NO.Name = "MATERIAL_NO"
        Me.MATERIAL_NO.ReadOnly = True
        Me.MATERIAL_NO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.DataPropertyName = "DESCRIPTION"
        Me.DESCRIPTION.HeaderText = "品名"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.ReadOnly = True
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
        '
        'VendorCode
        '
        Me.VendorCode.DataPropertyName = "VendorCode"
        Me.VendorCode.HeaderText = "VendorCode"
        Me.VendorCode.Name = "VendorCode"
        Me.VendorCode.ReadOnly = True
        Me.VendorCode.Visible = False
        '
        'DateCode
        '
        Me.DateCode.DataPropertyName = "DateCode"
        Me.DateCode.HeaderText = "DateCode"
        Me.DateCode.Name = "DateCode"
        Me.DateCode.ReadOnly = True
        Me.DateCode.Visible = False
        '
        'Versions
        '
        Me.Versions.DataPropertyName = "Versions"
        Me.Versions.HeaderText = "Versions"
        Me.Versions.Name = "Versions"
        Me.Versions.ReadOnly = True
        Me.Versions.Visible = False
        '
        'btnDefine
        '
        Me.btnDefine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDefine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDefine.Location = New System.Drawing.Point(404, 409)
        Me.btnDefine.Name = "btnDefine"
        Me.btnDefine.Size = New System.Drawing.Size(75, 23)
        Me.btnDefine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDefine.TabIndex = 4
        Me.btnDefine.Text = "确 定"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(530, 409)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "关 闭"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(3, 409)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(155, 23)
        Me.lblMessage.TabIndex = 6
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDelete.Location = New System.Drawing.Point(278, 409)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "删 除"
        '
        'FrmWarehouseingBarCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 443)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDefine)
        Me.Controls.Add(Me.dgvBarcode)
        Me.Controls.Add(Me.chkQuantity)
        Me.Controls.Add(Me.txtBarCode)
        Me.Controls.Add(Me.lblDescription)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmWarehouseingBarCode"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "条码扫描"
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtBarCode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblDescription As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkQuantity As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents dgvBarcode As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnDefine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ChkSelect As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MATERIAL_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPECIFICATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendorCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Versions As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
