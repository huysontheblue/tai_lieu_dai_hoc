<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSNCheckSet
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMO = New System.Windows.Forms.TextBox()
        Me.txtPart = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CobLine = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BnConFrm = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.txtMO)
        Me.GroupBox2.Controls.Add(Me.txtPart)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CobLine)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(444, 103)
        Me.GroupBox2.TabIndex = 95
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "扫描信息设置"
        '
        'txtMO
        '
        Me.txtMO.Location = New System.Drawing.Point(90, 13)
        Me.txtMO.Name = "txtMO"
        Me.txtMO.Size = New System.Drawing.Size(118, 21)
        Me.txtMO.TabIndex = 92
        '
        'txtPart
        '
        Me.txtPart.Location = New System.Drawing.Point(315, 13)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(118, 21)
        Me.txtPart.TabIndex = 92
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(239, 22)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 12)
        Me.Label31.TabIndex = 91
        Me.Label31.Text = "料件编号："
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "线别编号："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobLine
        '
        Me.CobLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLine.FormattingEnabled = True
        Me.CobLine.Location = New System.Drawing.Point(89, 45)
        Me.CobLine.Name = "CobLine"
        Me.CobLine.Size = New System.Drawing.Size(119, 20)
        Me.CobLine.TabIndex = 73
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(14, 17)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 12)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "工单编号："
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(200, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 23)
        Me.Button1.TabIndex = 97
        Me.Button1.Text = "退  出(&E)"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BnConFrm
        '
        Me.BnConFrm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnConFrm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnConFrm.Location = New System.Drawing.Point(111, 121)
        Me.BnConFrm.Name = "BnConFrm"
        Me.BnConFrm.Size = New System.Drawing.Size(63, 23)
        Me.BnConFrm.TabIndex = 96
        Me.BnConFrm.Text = "确  认(&O)"
        Me.BnConFrm.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnConFrm.UseVisualStyleBackColor = True
        '
        'FrmSNCheckSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 170)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BnConFrm)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FrmSNCheckSet"
        Me.Text = "重码检测设置"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CobLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtMO As System.Windows.Forms.TextBox
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BnConFrm As System.Windows.Forms.Button
End Class
