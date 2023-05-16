<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputText
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InputText))
        Me.textBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'textBoxX1
        '
        Me.textBoxX1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.textBoxX1.Border.Class = "TextBoxBorder"
        Me.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.textBoxX1.Location = New System.Drawing.Point(1, 1)
        Me.textBoxX1.Multiline = True
        Me.textBoxX1.Name = "textBoxX1"
        Me.textBoxX1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.textBoxX1.Size = New System.Drawing.Size(584, 220)
        Me.textBoxX1.TabIndex = 2
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(305, 239)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(75, 23)
        Me.button2.TabIndex = 5
        Me.button2.Text = "取消"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(200, 240)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 4
        Me.button1.Text = "确定"
        Me.button1.UseVisualStyleBackColor = True
        '
        'InputText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 277)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.textBoxX1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InputText"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "多行文本输入"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents textBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
End Class
