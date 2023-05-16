<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCartonRepeatPrint
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
        Me.BnCancel = New System.Windows.Forms.Button()
        Me.BnOpenlock = New System.Windows.Forms.Button()
        Me.TxtBarcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPassWord = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BnCancel
        '
        Me.BnCancel.Location = New System.Drawing.Point(206, 96)
        Me.BnCancel.Name = "BnCancel"
        Me.BnCancel.Size = New System.Drawing.Size(75, 31)
        Me.BnCancel.TabIndex = 3
        Me.BnCancel.Text = "取  消"
        Me.BnCancel.UseVisualStyleBackColor = True
        '
        'BnOpenlock
        '
        Me.BnOpenlock.Location = New System.Drawing.Point(58, 96)
        Me.BnOpenlock.Name = "BnOpenlock"
        Me.BnOpenlock.Size = New System.Drawing.Size(75, 31)
        Me.BnOpenlock.TabIndex = 2
        Me.BnOpenlock.Text = "確  定"
        Me.BnOpenlock.UseVisualStyleBackColor = True
        '
        'TxtBarcode
        '
        Me.TxtBarcode.Location = New System.Drawing.Point(114, 15)
        Me.TxtBarcode.MaxLength = 100
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.Size = New System.Drawing.Size(191, 21)
        Me.TxtBarcode.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 12)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "箱内扫描过条码:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPassWord
        '
        Me.TxtPassWord.Location = New System.Drawing.Point(115, 53)
        Me.TxtPassWord.MaxLength = 30
        Me.TxtPassWord.Name = "TxtPassWord"
        Me.TxtPassWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassWord.Size = New System.Drawing.Size(191, 21)
        Me.TxtPassWord.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "解鎖密碼:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmCartonRepeatPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 154)
        Me.Controls.Add(Me.BnCancel)
        Me.Controls.Add(Me.BnOpenlock)
        Me.Controls.Add(Me.TxtBarcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPassWord)
        Me.Controls.Add(Me.Label6)
        Me.MaximizeBox = False
        Me.Name = "FrmCartonRepeatPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "外箱标签重新打印"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BnCancel As System.Windows.Forms.Button
    Friend WithEvents BnOpenlock As System.Windows.Forms.Button
    Friend WithEvents TxtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
