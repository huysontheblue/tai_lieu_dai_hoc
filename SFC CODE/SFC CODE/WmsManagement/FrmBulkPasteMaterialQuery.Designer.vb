<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBulkPasteMaterialQuery
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
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.txtMaterialNO = New DevComponents.DotNetBar.TextBoxItem()
        Me.LabelItem10 = New DevComponents.DotNetBar.LabelItem()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem11 = New DevComponents.DotNetBar.LabelItem()
        Me.btnGeneration = New DevComponents.DotNetBar.ButtonItem()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.btnConfirm = New DevComponents.DotNetBar.ButtonItem()
        Me.lblMessage = New DevComponents.DotNetBar.LabelItem()
        Me.txtPasteMaterial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.dgvSelectMaterial = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SELECTUNITPRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECTMATERIALNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECTDESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECTSPECIFICATION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECTUOM_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SELECTQUANTITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSelectMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem4, Me.LabelItem2, Me.txtMaterialNO, Me.LabelItem10, Me.btnQuery, Me.LabelItem11, Me.btnGeneration, Me.LabelItem1, Me.btnConfirm, Me.lblMessage})
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.SingleLineColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Bar1.Size = New System.Drawing.Size(431, 27)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 140
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem4
        '
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.Text = " "
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.Text = "料号:"
        '
        'txtMaterialNO
        '
        Me.txtMaterialNO.FocusHighlightColor = System.Drawing.Color.Transparent
        Me.txtMaterialNO.Name = "txtMaterialNO"
        Me.txtMaterialNO.Tag = "查询单号"
        Me.txtMaterialNO.TextBoxWidth = 100
        Me.txtMaterialNO.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'LabelItem10
        '
        Me.LabelItem10.Name = "LabelItem10"
        Me.LabelItem10.Text = "  "
        '
        'btnQuery
        '
        Me.btnQuery.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnQuery.Image = Global.WmsManagement.My.Resources.Resources.query
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Tag = "查询"
        Me.btnQuery.Text = "查询"
        '
        'LabelItem11
        '
        Me.LabelItem11.Name = "LabelItem11"
        Me.LabelItem11.Text = " "
        '
        'btnGeneration
        '
        Me.btnGeneration.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnGeneration.Image = Global.WmsManagement.My.Resources.Resources.edit
        Me.btnGeneration.Name = "btnGeneration"
        Me.btnGeneration.Tag = "生成"
        Me.btnGeneration.Text = "生成"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = " "
        '
        'btnConfirm
        '
        Me.btnConfirm.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnConfirm.Image = Global.WmsManagement.My.Resources.Resources.check
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Tag = "确定"
        Me.btnConfirm.Text = "确定"
        '
        'lblMessage
        '
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.PaddingLeft = 12
        '
        'txtPasteMaterial
        '
        '
        '
        '
        Me.txtPasteMaterial.Border.Class = "TextBoxBorder"
        Me.txtPasteMaterial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPasteMaterial.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtPasteMaterial.Location = New System.Drawing.Point(0, 27)
        Me.txtPasteMaterial.Multiline = True
        Me.txtPasteMaterial.Name = "txtPasteMaterial"
        Me.txtPasteMaterial.Size = New System.Drawing.Size(431, 198)
        Me.txtPasteMaterial.TabIndex = 141
        '
        'ExpandableSplitter1
        '
        Me.ExpandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandableSplitter1.ExpandableControl = Me.txtPasteMaterial
        Me.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(0, 225)
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(431, 6)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter1.TabIndex = 142
        Me.ExpandableSplitter1.TabStop = False
        '
        'dgvSelectMaterial
        '
        Me.dgvSelectMaterial.AllowUserToAddRows = False
        Me.dgvSelectMaterial.AllowUserToDeleteRows = False
        Me.dgvSelectMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSelectMaterial.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelectMaterial.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSelectMaterial.ColumnHeadersHeight = 28
        Me.dgvSelectMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSelectMaterial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SELECTUNITPRICE, Me.SELECTMATERIALNO, Me.SELECTDESCRIPTION, Me.SELECTSPECIFICATION, Me.SELECTUOM_NAME, Me.SELECTQUANTITY})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSelectMaterial.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSelectMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSelectMaterial.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvSelectMaterial.Location = New System.Drawing.Point(0, 231)
        Me.dgvSelectMaterial.Name = "dgvSelectMaterial"
        Me.dgvSelectMaterial.RowHeadersWidth = 15
        Me.dgvSelectMaterial.RowTemplate.Height = 23
        Me.dgvSelectMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSelectMaterial.Size = New System.Drawing.Size(431, 241)
        Me.dgvSelectMaterial.TabIndex = 143
        '
        'SELECTUNITPRICE
        '
        Me.SELECTUNITPRICE.DataPropertyName = "UNITPRICE"
        Me.SELECTUNITPRICE.HeaderText = "UNITPRICE"
        Me.SELECTUNITPRICE.Name = "SELECTUNITPRICE"
        Me.SELECTUNITPRICE.ReadOnly = True
        Me.SELECTUNITPRICE.Visible = False
        '
        'SELECTMATERIALNO
        '
        Me.SELECTMATERIALNO.DataPropertyName = "MATERIALNO"
        Me.SELECTMATERIALNO.FillWeight = 169.3663!
        Me.SELECTMATERIALNO.HeaderText = "料号"
        Me.SELECTMATERIALNO.Name = "SELECTMATERIALNO"
        Me.SELECTMATERIALNO.ReadOnly = True
        '
        'SELECTDESCRIPTION
        '
        Me.SELECTDESCRIPTION.DataPropertyName = "DESCRIPTION"
        Me.SELECTDESCRIPTION.FillWeight = 108.4388!
        Me.SELECTDESCRIPTION.HeaderText = "品名"
        Me.SELECTDESCRIPTION.Name = "SELECTDESCRIPTION"
        Me.SELECTDESCRIPTION.ReadOnly = True
        '
        'SELECTSPECIFICATION
        '
        Me.SELECTSPECIFICATION.DataPropertyName = "SPECIFICATION"
        Me.SELECTSPECIFICATION.FillWeight = 76.45449!
        Me.SELECTSPECIFICATION.HeaderText = "规格"
        Me.SELECTSPECIFICATION.Name = "SELECTSPECIFICATION"
        Me.SELECTSPECIFICATION.ReadOnly = True
        '
        'SELECTUOM_NAME
        '
        Me.SELECTUOM_NAME.DataPropertyName = "UOM_NAME"
        Me.SELECTUOM_NAME.FillWeight = 77.91541!
        Me.SELECTUOM_NAME.HeaderText = "单位"
        Me.SELECTUOM_NAME.Name = "SELECTUOM_NAME"
        Me.SELECTUOM_NAME.ReadOnly = True
        '
        'SELECTQUANTITY
        '
        Me.SELECTQUANTITY.DataPropertyName = "STOCKQUANTITY"
        Me.SELECTQUANTITY.FillWeight = 76.45449!
        Me.SELECTQUANTITY.HeaderText = "库存数量"
        Me.SELECTQUANTITY.Name = "SELECTQUANTITY"
        Me.SELECTQUANTITY.ReadOnly = True
        '
        'FrmBulkPasteMaterialQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 472)
        Me.Controls.Add(Me.dgvSelectMaterial)
        Me.Controls.Add(Me.ExpandableSplitter1)
        Me.Controls.Add(Me.txtPasteMaterial)
        Me.Controls.Add(Me.Bar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBulkPasteMaterialQuery"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量粘贴"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSelectMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtMaterialNO As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents LabelItem10 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem11 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelItem
    Friend WithEvents txtPasteMaterial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents dgvSelectMaterial As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnConfirm As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnGeneration As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents SELECTUNITPRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECTMATERIALNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECTDESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECTSPECIFICATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECTUOM_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SELECTQUANTITY As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
