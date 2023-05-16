<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFinishedProductMaster
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboDept = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvFinishedProductItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.mtxtAttentionName = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.btnStick = New DevComponents.DotNetBar.ButtonX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.txtERPTranscationID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.txtRemark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtOrderNumber = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtTransactionId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnSelectmaterial = New DevComponents.DotNetBar.ButtonX()
        Me.btnBarcodeInput = New DevComponents.DotNetBar.ButtonX()
        Me.btnDeleteRow = New DevComponents.DotNetBar.ButtonX()
        Me.btnInsertRow = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtDelivery = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.cboWarehouse = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.dtpInvoiceDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransactionType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingSame = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MATERIALNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPECIFICATION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STOCKQUANTITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QUANTITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNITPRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REMARK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvFinishedProductItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.FillWeight = 26.86562!
        Me.DataGridViewTextBoxColumn11.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 118
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.FillWeight = 26.86562!
        Me.DataGridViewTextBoxColumn9.HeaderText = "单价"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 60
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "QUANTITY"
        Me.DataGridViewTextBoxColumn8.FillWeight = 27.32929!
        Me.DataGridViewTextBoxColumn8.HeaderText = "数量"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 60
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.FillWeight = 26.86562!
        Me.DataGridViewTextBoxColumn7.HeaderText = "库存数量"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "UOM_NAME"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn6.FillWeight = 27.32929!
        Me.DataGridViewTextBoxColumn6.HeaderText = "单位"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 35
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "SPECIFICATION"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn5.FillWeight = 27.32929!
        Me.DataGridViewTextBoxColumn5.HeaderText = "规格"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DESCRIPTION"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGray
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn4.FillWeight = 27.32929!
        Me.DataGridViewTextBoxColumn4.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "MATERIALNO"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.FillWeight = 691.8499!
        Me.DataGridViewTextBoxColumn3.HeaderText = "料号"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "TransactionType"
        Me.DataGridViewTextBoxColumn2.HeaderText = "TransactionType"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ItemId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'cboDept
        '
        Me.cboDept.DisplayMember = "Text"
        Me.cboDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.ItemHeight = 15
        Me.cboDept.Location = New System.Drawing.Point(389, 94)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(170, 21)
        Me.cboDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboDept.TabIndex = 205
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.FillWeight = 26.86562!
        Me.DataGridViewTextBoxColumn10.HeaderText = "金额"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'dgvFinishedProductItem
        '
        Me.dgvFinishedProductItem.AllowUserToAddRows = False
        Me.dgvFinishedProductItem.AllowUserToDeleteRows = False
        Me.dgvFinishedProductItem.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvFinishedProductItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFinishedProductItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvFinishedProductItem.ColumnHeadersHeight = 32
        Me.dgvFinishedProductItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFinishedProductItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemId, Me.TransactionType, Me.PackingSame, Me.MATERIALNO, Me.DESCRIPTION, Me.SPECIFICATION, Me.UOM_NAME, Me.STOCKQUANTITY, Me.QUANTITY, Me.UNITPRICE, Me.TotalAmount, Me.OrderNumber, Me.REMARK})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFinishedProductItem.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvFinishedProductItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvFinishedProductItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvFinishedProductItem.Location = New System.Drawing.Point(15, 193)
        Me.dgvFinishedProductItem.MultiSelect = False
        Me.dgvFinishedProductItem.Name = "dgvFinishedProductItem"
        Me.dgvFinishedProductItem.RowHeadersWidth = 15
        Me.dgvFinishedProductItem.RowTemplate.Height = 28
        Me.dgvFinishedProductItem.Size = New System.Drawing.Size(840, 246)
        Me.dgvFinishedProductItem.TabIndex = 204
        '
        'mtxtAttentionName
        '
        '
        '
        '
        Me.mtxtAttentionName.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtAttentionName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtAttentionName.ButtonCustom.Visible = True
        Me.mtxtAttentionName.Location = New System.Drawing.Point(86, 95)
        Me.mtxtAttentionName.Name = "mtxtAttentionName"
        Me.mtxtAttentionName.ReadOnly = True
        Me.mtxtAttentionName.Size = New System.Drawing.Size(170, 21)
        Me.mtxtAttentionName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtAttentionName.TabIndex = 203
        Me.mtxtAttentionName.Text = ""
        '
        'btnStick
        '
        Me.btnStick.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnStick.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnStick.Location = New System.Drawing.Point(867, 394)
        Me.btnStick.Name = "btnStick"
        Me.btnStick.Size = New System.Drawing.Size(75, 23)
        Me.btnStick.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnStick.TabIndex = 202
        Me.btnStick.Text = "批量粘贴"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(16, 460)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(419, 23)
        Me.lblMessage.TabIndex = 201
        '
        'txtERPTranscationID
        '
        '
        '
        '
        Me.txtERPTranscationID.Border.Class = "TextBoxBorder"
        Me.txtERPTranscationID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtERPTranscationID.Location = New System.Drawing.Point(86, 54)
        Me.txtERPTranscationID.Name = "txtERPTranscationID"
        Me.txtERPTranscationID.Size = New System.Drawing.Size(170, 21)
        Me.txtERPTranscationID.TabIndex = 200
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Location = New System.Drawing.Point(16, 54)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(82, 23)
        Me.LabelX11.TabIndex = 199
        Me.LabelX11.Text = "Tiptop单号"
        '
        'txtRemark
        '
        '
        '
        '
        Me.txtRemark.Border.Class = "TextBoxBorder"
        Me.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemark.Location = New System.Drawing.Point(85, 135)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(770, 21)
        Me.txtRemark.TabIndex = 198
        '
        'txtOrderNumber
        '
        '
        '
        '
        Me.txtOrderNumber.Border.Class = "TextBoxBorder"
        Me.txtOrderNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOrderNumber.Location = New System.Drawing.Point(685, 54)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.Size = New System.Drawing.Size(170, 21)
        Me.txtOrderNumber.TabIndex = 197
        '
        'txtTransactionId
        '
        '
        '
        '
        Me.txtTransactionId.Border.Class = "TextBoxBorder"
        Me.txtTransactionId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTransactionId.Location = New System.Drawing.Point(389, 14)
        Me.txtTransactionId.Name = "txtTransactionId"
        Me.txtTransactionId.Size = New System.Drawing.Size(170, 21)
        Me.txtTransactionId.TabIndex = 196
        '
        'btnSelectmaterial
        '
        Me.btnSelectmaterial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSelectmaterial.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSelectmaterial.Location = New System.Drawing.Point(867, 209)
        Me.btnSelectmaterial.Name = "btnSelectmaterial"
        Me.btnSelectmaterial.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectmaterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSelectmaterial.TabIndex = 194
        Me.btnSelectmaterial.Text = "选择料号"
        '
        'btnBarcodeInput
        '
        Me.btnBarcodeInput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBarcodeInput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBarcodeInput.Location = New System.Drawing.Point(867, 350)
        Me.btnBarcodeInput.Name = "btnBarcodeInput"
        Me.btnBarcodeInput.Size = New System.Drawing.Size(75, 23)
        Me.btnBarcodeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBarcodeInput.TabIndex = 193
        Me.btnBarcodeInput.Text = "条码录入"
        '
        'btnDeleteRow
        '
        Me.btnDeleteRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDeleteRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDeleteRow.Location = New System.Drawing.Point(867, 303)
        Me.btnDeleteRow.Name = "btnDeleteRow"
        Me.btnDeleteRow.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDeleteRow.TabIndex = 192
        Me.btnDeleteRow.Text = "删除行"
        '
        'btnInsertRow
        '
        Me.btnInsertRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnInsertRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnInsertRow.Location = New System.Drawing.Point(867, 256)
        Me.btnInsertRow.Name = "btnInsertRow"
        Me.btnInsertRow.Size = New System.Drawing.Size(75, 23)
        Me.btnInsertRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnInsertRow.TabIndex = 191
        Me.btnInsertRow.Text = "增加行"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(723, 460)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 190
        Me.btnCancel.Text = "取  消"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(582, 460)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSave.TabIndex = 189
        Me.btnSave.Text = "保  存"
        '
        'CheckBoxX1
        '
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.Location = New System.Drawing.Point(565, 165)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(226, 23)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 188
        Me.CheckBoxX1.Text = "启用计量单位换算(如1箱=10个）"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(16, 164)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(354, 23)
        Me.LabelX10.TabIndex = 187
        Me.LabelX10.Text = "▼下方输入料号编码或右侧""选择料号""或""条码录入"""
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(15, 134)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 23)
        Me.LabelX9.TabIndex = 186
        Me.LabelX9.Text = "备     注"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(615, 54)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 23)
        Me.LabelX8.TabIndex = 185
        Me.LabelX8.Text = "订  单 号"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(16, 95)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 184
        Me.LabelX7.Text = "经  办 人"
        '
        'mtxtDelivery
        '
        '
        '
        '
        Me.mtxtDelivery.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtDelivery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtDelivery.ButtonCustom.Visible = True
        Me.mtxtDelivery.Location = New System.Drawing.Point(685, 95)
        Me.mtxtDelivery.Name = "mtxtDelivery"
        Me.mtxtDelivery.ReadOnly = True
        Me.mtxtDelivery.Size = New System.Drawing.Size(170, 21)
        Me.mtxtDelivery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtDelivery.TabIndex = 182
        Me.mtxtDelivery.Text = ""
        '
        'cboWarehouse
        '
        Me.cboWarehouse.DisplayMember = "Text"
        Me.cboWarehouse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWarehouse.FormattingEnabled = True
        Me.cboWarehouse.ItemHeight = 15
        Me.cboWarehouse.Location = New System.Drawing.Point(389, 54)
        Me.cboWarehouse.Name = "cboWarehouse"
        Me.cboWarehouse.Size = New System.Drawing.Size(170, 21)
        Me.cboWarehouse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboWarehouse.TabIndex = 177
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
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(86, 14)
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
        Me.dtpInvoiceDate.TabIndex = 175
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(16, 14)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 174
        Me.LabelX1.Text = "日     期"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(319, 94)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 181
        Me.LabelX5.Text = "部     门"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(615, 95)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 183
        Me.LabelX6.Text = "收  货 人"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(319, 14)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(82, 23)
        Me.LabelX4.TabIndex = 180
        Me.LabelX4.Text = "单     号"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(319, 54)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 176
        Me.LabelX2.Text = "仓     库"
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
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray
        Me.MATERIALNO.DefaultCellStyle = DataGridViewCellStyle6
        Me.MATERIALNO.FillWeight = 691.8499!
        Me.MATERIALNO.HeaderText = "料号"
        Me.MATERIALNO.Name = "MATERIALNO"
        Me.MATERIALNO.ReadOnly = True
        Me.MATERIALNO.Width = 150
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.DataPropertyName = "DESCRIPTION"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        Me.DESCRIPTION.DefaultCellStyle = DataGridViewCellStyle7
        Me.DESCRIPTION.FillWeight = 27.32929!
        Me.DESCRIPTION.HeaderText = "品名"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.ReadOnly = True
        Me.DESCRIPTION.Width = 120
        '
        'SPECIFICATION
        '
        Me.SPECIFICATION.DataPropertyName = "SPECIFICATION"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray
        Me.SPECIFICATION.DefaultCellStyle = DataGridViewCellStyle8
        Me.SPECIFICATION.FillWeight = 27.32929!
        Me.SPECIFICATION.HeaderText = "规格"
        Me.SPECIFICATION.Name = "SPECIFICATION"
        Me.SPECIFICATION.ReadOnly = True
        Me.SPECIFICATION.Width = 120
        '
        'UOM_NAME
        '
        Me.UOM_NAME.DataPropertyName = "UOM_NAME"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGray
        Me.UOM_NAME.DefaultCellStyle = DataGridViewCellStyle9
        Me.UOM_NAME.FillWeight = 27.32929!
        Me.UOM_NAME.HeaderText = "单位"
        Me.UOM_NAME.Name = "UOM_NAME"
        Me.UOM_NAME.ReadOnly = True
        Me.UOM_NAME.Width = 35
        '
        'STOCKQUANTITY
        '
        Me.STOCKQUANTITY.DataPropertyName = "STOCKQUANTITY"
        Me.STOCKQUANTITY.FillWeight = 26.86562!
        Me.STOCKQUANTITY.HeaderText = "库存数量"
        Me.STOCKQUANTITY.Name = "STOCKQUANTITY"
        Me.STOCKQUANTITY.ReadOnly = True
        Me.STOCKQUANTITY.Width = 80
        '
        'QUANTITY
        '
        Me.QUANTITY.DataPropertyName = "QUANTITY"
        Me.QUANTITY.FillWeight = 27.32929!
        Me.QUANTITY.HeaderText = "数量"
        Me.QUANTITY.Name = "QUANTITY"
        Me.QUANTITY.Width = 60
        '
        'UNITPRICE
        '
        Me.UNITPRICE.DataPropertyName = "UNITPRICE"
        Me.UNITPRICE.FillWeight = 26.86562!
        Me.UNITPRICE.HeaderText = "单价"
        Me.UNITPRICE.Name = "UNITPRICE"
        Me.UNITPRICE.ReadOnly = True
        Me.UNITPRICE.Width = 60
        '
        'TotalAmount
        '
        Me.TotalAmount.DataPropertyName = "TotalAmount"
        Me.TotalAmount.FillWeight = 26.86562!
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
        Me.OrderNumber.Width = 80
        '
        'REMARK
        '
        Me.REMARK.DataPropertyName = "REMARK"
        Me.REMARK.FillWeight = 26.86562!
        Me.REMARK.HeaderText = "备注"
        Me.REMARK.Name = "REMARK"
        Me.REMARK.Width = 118
        '
        'FrmFinishedProductMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 496)
        Me.Controls.Add(Me.cboDept)
        Me.Controls.Add(Me.dgvFinishedProductItem)
        Me.Controls.Add(Me.mtxtAttentionName)
        Me.Controls.Add(Me.btnStick)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtERPTranscationID)
        Me.Controls.Add(Me.LabelX11)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.txtOrderNumber)
        Me.Controls.Add(Me.txtTransactionId)
        Me.Controls.Add(Me.btnSelectmaterial)
        Me.Controls.Add(Me.btnBarcodeInput)
        Me.Controls.Add(Me.btnDeleteRow)
        Me.Controls.Add(Me.btnInsertRow)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.CheckBoxX1)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.mtxtDelivery)
        Me.Controls.Add(Me.cboWarehouse)
        Me.Controls.Add(Me.dtpInvoiceDate)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFinishedProductMaster"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "成品出库"
        CType(Me.dgvFinishedProductItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpInvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboDept As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvFinishedProductItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents mtxtAttentionName As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents btnStick As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtERPTranscationID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtRemark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtOrderNumber As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtTransactionId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnSelectmaterial As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBarcodeInput As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDeleteRow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnInsertRow As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtDelivery As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents cboWarehouse As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents dtpInvoiceDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ItemId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingSame As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MATERIALNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPECIFICATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCKQUANTITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QUANTITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNITPRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REMARK As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
