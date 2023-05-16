<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMaterialMaster
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
        Me.chkActiveFlag = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.txtMaterialNO = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.cboMaterialType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.cboTransactionType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cboFIFOType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.chkFIFO = New System.Windows.Forms.CheckBox()
        Me.txtDescription = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txtSpecification = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.txtUnit = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.txtQuantity = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.txtUnitPrice = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.txtRemark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'chkActiveFlag
        '
        '
        '
        '
        Me.chkActiveFlag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkActiveFlag.Location = New System.Drawing.Point(548, 232)
        Me.chkActiveFlag.Name = "chkActiveFlag"
        Me.chkActiveFlag.Size = New System.Drawing.Size(100, 23)
        Me.chkActiveFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkActiveFlag.TabIndex = 38
        Me.chkActiveFlag.Text = "有/无效"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(588, 326)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 37
        Me.btnCancel.Text = "取 消"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(459, 326)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSave.TabIndex = 36
        Me.btnSave.Text = "保 存"
        '
        'txtMaterialNO
        '
        '
        '
        '
        Me.txtMaterialNO.Border.Class = "TextBoxBorder"
        Me.txtMaterialNO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMaterialNO.Location = New System.Drawing.Point(84, 24)
        Me.txtMaterialNO.Name = "txtMaterialNO"
        Me.txtMaterialNO.Size = New System.Drawing.Size(140, 21)
        Me.txtMaterialNO.TabIndex = 35
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(21, 24)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 34
        Me.LabelX2.Text = "料号"
        '
        'cboMaterialType
        '
        Me.cboMaterialType.DisplayMember = "Text"
        Me.cboMaterialType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMaterialType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaterialType.FormattingEnabled = True
        Me.cboMaterialType.ItemHeight = 15
        Me.cboMaterialType.Items.AddRange(New Object() {Me.ComboItem4, Me.ComboItem5})
        Me.cboMaterialType.Location = New System.Drawing.Point(548, 175)
        Me.cboMaterialType.Name = "cboMaterialType"
        Me.cboMaterialType.Size = New System.Drawing.Size(140, 21)
        Me.cboMaterialType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboMaterialType.TabIndex = 45
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
        Me.LabelX3.Location = New System.Drawing.Point(486, 176)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX3.Size = New System.Drawing.Size(108, 23)
        Me.LabelX3.TabIndex = 44
        Me.LabelX3.Text = "物料类型"
        '
        'cboTransactionType
        '
        Me.cboTransactionType.DisplayMember = "Text"
        Me.cboTransactionType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransactionType.FormattingEnabled = True
        Me.cboTransactionType.ItemHeight = 15
        Me.cboTransactionType.Items.AddRange(New Object() {Me.ComboItem7, Me.ComboItem8})
        Me.cboTransactionType.Location = New System.Drawing.Point(84, 234)
        Me.cboTransactionType.Name = "cboTransactionType"
        Me.cboTransactionType.Size = New System.Drawing.Size(140, 21)
        Me.cboTransactionType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboTransactionType.TabIndex = 43
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
        Me.LabelX1.Location = New System.Drawing.Point(21, 234)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX1.Size = New System.Drawing.Size(108, 23)
        Me.LabelX1.TabIndex = 42
        Me.LabelX1.Text = "出入类型"
        '
        'cboFIFOType
        '
        Me.cboFIFOType.DisplayMember = "Text"
        Me.cboFIFOType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboFIFOType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFIFOType.Enabled = False
        Me.cboFIFOType.FormattingEnabled = True
        Me.cboFIFOType.ItemHeight = 15
        Me.cboFIFOType.Location = New System.Drawing.Point(320, 177)
        Me.cboFIFOType.Name = "cboFIFOType"
        Me.cboFIFOType.Size = New System.Drawing.Size(140, 21)
        Me.cboFIFOType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboFIFOType.TabIndex = 41
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(253, 177)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.SingleLineColor = System.Drawing.Color.Transparent
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 40
        Me.LabelX4.Text = "规则"
        '
        'chkFIFO
        '
        Me.chkFIFO.BackColor = System.Drawing.Color.Transparent
        Me.chkFIFO.Location = New System.Drawing.Point(84, 180)
        Me.chkFIFO.Name = "chkFIFO"
        Me.chkFIFO.Size = New System.Drawing.Size(72, 16)
        Me.chkFIFO.TabIndex = 39
        Me.chkFIFO.Text = "先进先出"
        Me.chkFIFO.UseVisualStyleBackColor = False
        '
        'txtDescription
        '
        '
        '
        '
        Me.txtDescription.Border.Class = "TextBoxBorder"
        Me.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescription.Location = New System.Drawing.Point(84, 73)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(604, 21)
        Me.txtDescription.TabIndex = 47
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(21, 73)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 46
        Me.LabelX5.Text = "描述"
        '
        'txtSpecification
        '
        '
        '
        '
        Me.txtSpecification.Border.Class = "TextBoxBorder"
        Me.txtSpecification.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSpecification.Location = New System.Drawing.Point(83, 122)
        Me.txtSpecification.Name = "txtSpecification"
        Me.txtSpecification.Size = New System.Drawing.Size(604, 21)
        Me.txtSpecification.TabIndex = 49
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(21, 122)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 48
        Me.LabelX6.Text = "规格"
        '
        'txtUnit
        '
        '
        '
        '
        Me.txtUnit.Border.Class = "TextBoxBorder"
        Me.txtUnit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUnit.Location = New System.Drawing.Point(320, 24)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(140, 21)
        Me.txtUnit.TabIndex = 51
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(253, 24)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 50
        Me.LabelX7.Text = "单位"
        '
        'txtQuantity
        '
        '
        '
        '
        Me.txtQuantity.Border.Class = "TextBoxBorder"
        Me.txtQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtQuantity.Location = New System.Drawing.Point(548, 24)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(140, 21)
        Me.txtQuantity.TabIndex = 53
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(486, 24)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 23)
        Me.LabelX8.TabIndex = 52
        Me.LabelX8.Text = "库存"
        '
        'txtUnitPrice
        '
        '
        '
        '
        Me.txtUnitPrice.Border.Class = "TextBoxBorder"
        Me.txtUnitPrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUnitPrice.Location = New System.Drawing.Point(320, 234)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(140, 21)
        Me.txtUnitPrice.TabIndex = 55
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Location = New System.Drawing.Point(253, 234)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 23)
        Me.LabelX9.TabIndex = 54
        Me.LabelX9.Text = "单价"
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(21, 327)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.SingleLineColor = System.Drawing.Color.Transparent
        Me.lblMessage.Size = New System.Drawing.Size(418, 23)
        Me.lblMessage.TabIndex = 56
        '
        'txtRemark
        '
        '
        '
        '
        Me.txtRemark.Border.Class = "TextBoxBorder"
        Me.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemark.Location = New System.Drawing.Point(84, 277)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(604, 21)
        Me.txtRemark.TabIndex = 60
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(22, 277)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(75, 23)
        Me.LabelX10.TabIndex = 59
        Me.LabelX10.Text = "备注"
        '
        'FrmMaterialMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 361)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtUnitPrice)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.txtSpecification)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.cboMaterialType)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.cboTransactionType)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.cboFIFOType)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.chkFIFO)
        Me.Controls.Add(Me.chkActiveFlag)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtMaterialNO)
        Me.Controls.Add(Me.LabelX2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMaterialMaster"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "料件信息"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkActiveFlag As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtMaterialNO As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboMaterialType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboTransactionType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboFIFOType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkFIFO As System.Windows.Forms.CheckBox
    Friend WithEvents txtDescription As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtSpecification As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUnit As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtQuantity As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUnitPrice As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtRemark As DevComponents.DotNetBar.Controls.TextBoxX
End Class
