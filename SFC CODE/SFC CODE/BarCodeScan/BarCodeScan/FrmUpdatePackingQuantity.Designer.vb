<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUpdatePackingQuantity
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
        Me.txtPackingId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnDefine = New DevComponents.DotNetBar.ButtonX()
        Me.txtQuantity = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtEditQuantity = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.txtMoid = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'txtPackingId
        '
        '
        '
        '
        Me.txtPackingId.Border.Class = "TextBoxBorder"
        Me.txtPackingId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPackingId.Location = New System.Drawing.Point(72, 89)
        Me.txtPackingId.Name = "txtPackingId"
        Me.txtPackingId.ReadOnly = True
        Me.txtPackingId.Size = New System.Drawing.Size(271, 21)
        Me.txtPackingId.TabIndex = 57
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(12, 89)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(82, 23)
        Me.LabelX2.TabIndex = 56
        Me.LabelX2.Text = "箱号"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(281, 212)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 23)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 55
        Me.btnCancel.Text = "取消"
        '
        'btnDefine
        '
        Me.btnDefine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDefine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDefine.Location = New System.Drawing.Point(194, 212)
        Me.btnDefine.Name = "btnDefine"
        Me.btnDefine.Size = New System.Drawing.Size(60, 23)
        Me.btnDefine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDefine.TabIndex = 54
        Me.btnDefine.Text = "确定"
        '
        'txtQuantity
        '
        '
        '
        '
        Me.txtQuantity.Border.Class = "TextBoxBorder"
        Me.txtQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtQuantity.Location = New System.Drawing.Point(72, 132)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.ReadOnly = True
        Me.txtQuantity.Size = New System.Drawing.Size(271, 21)
        Me.txtQuantity.TabIndex = 59
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 132)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(82, 23)
        Me.LabelX1.TabIndex = 58
        Me.LabelX1.Text = "扫描数量"
        '
        'txtEditQuantity
        '
        '
        '
        '
        Me.txtEditQuantity.Border.Class = "TextBoxBorder"
        Me.txtEditQuantity.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEditQuantity.Location = New System.Drawing.Point(72, 174)
        Me.txtEditQuantity.Name = "txtEditQuantity"
        Me.txtEditQuantity.Size = New System.Drawing.Size(271, 21)
        Me.txtEditQuantity.TabIndex = 61
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(12, 174)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(82, 23)
        Me.LabelX3.TabIndex = 60
        Me.LabelX3.Text = "调整数量"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(12, 212)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(302, 23)
        Me.lblMessage.TabIndex = 62
        '
        'txtMoid
        '
        '
        '
        '
        Me.txtMoid.Border.Class = "TextBoxBorder"
        Me.txtMoid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMoid.Location = New System.Drawing.Point(72, 48)
        Me.txtMoid.Name = "txtMoid"
        Me.txtMoid.ReadOnly = True
        Me.txtMoid.Size = New System.Drawing.Size(271, 21)
        Me.txtMoid.TabIndex = 64
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(12, 48)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(82, 23)
        Me.LabelX4.TabIndex = 63
        Me.LabelX4.Text = "工单"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Blue
        Me.LabelX5.Location = New System.Drawing.Point(12, 12)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(340, 23)
        Me.LabelX5.TabIndex = 65
        Me.LabelX5.Text = "▼注意：保存成功，需要重新设置扫描界面才能更新扫描界面"
        '
        'FrmUpdatePackingQuantity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 251)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.txtMoid)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.txtEditQuantity)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtPackingId)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDefine)
        Me.Controls.Add(Me.lblMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUpdatePackingQuantity"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "包装数量调整"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPackingId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDefine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtQuantity As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtEditQuantity As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtMoid As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
End Class
