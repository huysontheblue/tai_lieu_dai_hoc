<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLastPalletSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLastPalletSet))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPassWord = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ButOk = New System.Windows.Forms.Button
        Me.ButExit = New System.Windows.Forms.Button
        Me.ChkPallet = New System.Windows.Forms.CheckedListBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 12)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "尾數箱包裝數量:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPassWord
        '
        Me.TxtPassWord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(162, Byte), Integer))
        Me.TxtPassWord.Location = New System.Drawing.Point(113, 98)
        Me.TxtPassWord.MaxLength = 30
        Me.TxtPassWord.Name = "TxtPassWord"
        Me.TxtPassWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassWord.Size = New System.Drawing.Size(201, 22)
        Me.TxtPassWord.TabIndex = 67
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 12)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "解鎖密碼:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButOk
        '
        Me.ButOk.AutoEllipsis = True
        Me.ButOk.Location = New System.Drawing.Point(32, 125)
        Me.ButOk.Name = "ButOk"
        Me.ButOk.Size = New System.Drawing.Size(75, 23)
        Me.ButOk.TabIndex = 70
        Me.ButOk.Text = "確定"
        Me.ButOk.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButOk.UseVisualStyleBackColor = True
        '
        'ButExit
        '
        Me.ButExit.AutoEllipsis = True
        Me.ButExit.Location = New System.Drawing.Point(215, 123)
        Me.ButExit.Name = "ButExit"
        Me.ButExit.Size = New System.Drawing.Size(75, 23)
        Me.ButExit.TabIndex = 71
        Me.ButExit.Text = "取消"
        Me.ButExit.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ButExit.UseVisualStyleBackColor = True
        '
        'ChkPallet
        '
        Me.ChkPallet.CheckOnClick = True
        Me.ChkPallet.FormattingEnabled = True
        Me.ChkPallet.Location = New System.Drawing.Point(114, 6)
        Me.ChkPallet.Name = "ChkPallet"
        Me.ChkPallet.Size = New System.Drawing.Size(200, 89)
        Me.ChkPallet.TabIndex = 72
        '
        'FrmLastPalletSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 154)
        Me.Controls.Add(Me.ChkPallet)
        Me.Controls.Add(Me.ButExit)
        Me.Controls.Add(Me.ButOk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPassWord)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLastPalletSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "尾數棧板設置"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButOk As System.Windows.Forms.Button
    Friend WithEvents ButExit As System.Windows.Forms.Button
    Friend WithEvents ChkPallet As System.Windows.Forms.CheckedListBox
End Class
