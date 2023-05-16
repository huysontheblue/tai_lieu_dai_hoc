<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReplaceLock
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReplaceLock))
        Me.BnCancel = New System.Windows.Forms.Button
        Me.TxtPassWord = New System.Windows.Forms.TextBox
        Me.BnOpenlock = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtPackNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'BnCancel
        '
        Me.BnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnCancel.Image = CType(resources.GetObject("BnCancel.Image"), System.Drawing.Image)
        Me.BnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnCancel.Location = New System.Drawing.Point(207, 107)
        Me.BnCancel.Name = "BnCancel"
        Me.BnCancel.Size = New System.Drawing.Size(66, 23)
        Me.BnCancel.TabIndex = 56
        Me.BnCancel.Text = "取 消"
        Me.BnCancel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnCancel.UseVisualStyleBackColor = True
        '
        'TxtPassWord
        '
        Me.TxtPassWord.Location = New System.Drawing.Point(79, 65)
        Me.TxtPassWord.Name = "TxtPassWord"
        Me.TxtPassWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassWord.Size = New System.Drawing.Size(235, 21)
        Me.TxtPassWord.TabIndex = 54
        '
        'BnOpenlock
        '
        Me.BnOpenlock.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnOpenlock.Image = CType(resources.GetObject("BnOpenlock.Image"), System.Drawing.Image)
        Me.BnOpenlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnOpenlock.Location = New System.Drawing.Point(48, 107)
        Me.BnOpenlock.Name = "BnOpenlock"
        Me.BnOpenlock.Size = New System.Drawing.Size(66, 23)
        Me.BnOpenlock.TabIndex = 55
        Me.BnOpenlock.Text = "確 定"
        Me.BnOpenlock.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnOpenlock.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "解鎖密碼："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPackNo
        '
        Me.TxtPackNo.AcceptsReturn = True
        Me.TxtPackNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPackNo.Location = New System.Drawing.Point(78, 27)
        Me.TxtPackNo.MaxLength = 40
        Me.TxtPackNo.Name = "TxtPackNo"
        Me.TxtPackNo.Size = New System.Drawing.Size(235, 21)
        Me.TxtPackNo.TabIndex = 53
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "舊箱箱號："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmReplaceLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 154)
        Me.Controls.Add(Me.TxtPackNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BnCancel)
        Me.Controls.Add(Me.TxtPassWord)
        Me.Controls.Add(Me.BnOpenlock)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReplaceLock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "在線打印(箱號替換打印)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents BnOpenlock As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPackNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
