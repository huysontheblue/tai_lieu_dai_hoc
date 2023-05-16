<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPackingCheckSetting
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
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtNumberDdivisions = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtAffiliatedBarCode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.btnConfir = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.CobLine = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.mtxtMOid = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(34, 103)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "附属条码:"
        '
        'txtNumberDdivisions
        '
        '
        '
        '
        Me.txtNumberDdivisions.Border.Class = "TextBoxBorder"
        Me.txtNumberDdivisions.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumberDdivisions.Location = New System.Drawing.Point(101, 145)
        Me.txtNumberDdivisions.Name = "txtNumberDdivisions"
        Me.txtNumberDdivisions.ReadOnly = True
        Me.txtNumberDdivisions.Size = New System.Drawing.Size(201, 21)
        Me.txtNumberDdivisions.TabIndex = 1
        '
        'txtAffiliatedBarCode
        '
        '
        '
        '
        Me.txtAffiliatedBarCode.Border.Class = "TextBoxBorder"
        Me.txtAffiliatedBarCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAffiliatedBarCode.Location = New System.Drawing.Point(101, 103)
        Me.txtAffiliatedBarCode.Name = "txtAffiliatedBarCode"
        Me.txtAffiliatedBarCode.ReadOnly = True
        Me.txtAffiliatedBarCode.Size = New System.Drawing.Size(201, 21)
        Me.txtAffiliatedBarCode.TabIndex = 3
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(45, 145)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "重复数:"
        '
        'btnConfir
        '
        Me.btnConfir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnConfir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnConfir.Location = New System.Drawing.Point(120, 191)
        Me.btnConfir.Name = "btnConfir"
        Me.btnConfir.Size = New System.Drawing.Size(63, 25)
        Me.btnConfir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnConfir.TabIndex = 4
        Me.btnConfir.Text = "确 定"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(237, 191)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(63, 25)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取 消"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(56, 63)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(44, 23)
        Me.LabelX3.TabIndex = 6
        Me.LabelX3.Text = "产线:"
        '
        'CobLine
        '
        Me.CobLine.DisplayMember = "Text"
        Me.CobLine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CobLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLine.FormattingEnabled = True
        Me.CobLine.ItemHeight = 15
        Me.CobLine.Location = New System.Drawing.Point(101, 63)
        Me.CobLine.Name = "CobLine"
        Me.CobLine.Size = New System.Drawing.Size(201, 21)
        Me.CobLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CobLine.TabIndex = 7
        '
        'mtxtMOid
        '
        '
        '
        '
        Me.mtxtMOid.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMOid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMOid.ButtonCustom.Image = Global.BarCodeScan.My.Resources.Resources.query
        Me.mtxtMOid.ButtonCustom.Visible = True
        Me.mtxtMOid.Location = New System.Drawing.Point(101, 22)
        Me.mtxtMOid.Name = "mtxtMOid"
        Me.mtxtMOid.ReadOnly = True
        Me.mtxtMOid.Size = New System.Drawing.Size(201, 21)
        Me.mtxtMOid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMOid.TabIndex = 109
        Me.mtxtMOid.Text = ""
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(56, 22)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(44, 23)
        Me.LabelX4.TabIndex = 110
        Me.LabelX4.Text = "工单:"
        '
        'FrmPackingCheckSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 241)
        Me.Controls.Add(Me.mtxtMOid)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.CobLine)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.txtNumberDdivisions)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConfir)
        Me.Controls.Add(Me.txtAffiliatedBarCode)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPackingCheckSetting"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "包装检查设置"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNumberDdivisions As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAffiliatedBarCode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnConfir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CobLine As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents mtxtMOid As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
