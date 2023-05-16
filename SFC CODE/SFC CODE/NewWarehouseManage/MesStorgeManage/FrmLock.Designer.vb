<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLock))
        Me.BnCancel = New System.Windows.Forms.Button()
        Me.TxtPassWord = New System.Windows.Forms.TextBox()
        Me.BnOpenlock = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BnCancel
        '
        Me.BnCancel.Image = CType(resources.GetObject("BnCancel.Image"), System.Drawing.Image)
        Me.BnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnCancel.Location = New System.Drawing.Point(190, 55)
        Me.BnCancel.Name = "BnCancel"
        Me.BnCancel.Size = New System.Drawing.Size(66, 23)
        Me.BnCancel.TabIndex = 56
        Me.BnCancel.Text = "取 消"
        Me.BnCancel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnCancel.UseVisualStyleBackColor = True
        '
        'TxtPassWord
        '
        Me.TxtPassWord.Location = New System.Drawing.Point(103, 15)
        Me.TxtPassWord.Name = "TxtPassWord"
        Me.TxtPassWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassWord.Size = New System.Drawing.Size(153, 21)
        Me.TxtPassWord.TabIndex = 54
        '
        'BnOpenlock
        '
        Me.BnOpenlock.Image = CType(resources.GetObject("BnOpenlock.Image"), System.Drawing.Image)
        Me.BnOpenlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnOpenlock.Location = New System.Drawing.Point(31, 55)
        Me.BnOpenlock.Name = "BnOpenlock"
        Me.BnOpenlock.Size = New System.Drawing.Size(66, 23)
        Me.BnOpenlock.TabIndex = 55
        Me.BnOpenlock.Text = "确 定"
        Me.BnOpenlock.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnOpenlock.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "解锁密码:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 95)
        Me.Controls.Add(Me.BnCancel)
        Me.Controls.Add(Me.TxtPassWord)
        Me.Controls.Add(Me.BnOpenlock)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "驳回解锁"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BnCancel As System.Windows.Forms.Button
    Friend WithEvents TxtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents BnOpenlock As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
