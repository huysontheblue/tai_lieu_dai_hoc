<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCartonReplace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCartonReplace))
        Me.TxtPackNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPassWord = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ButtonXP1 = New PinkieControls.ButtonXP
        Me.ButtonXP2 = New PinkieControls.ButtonXP
        Me.TxtPartid = New System.Windows.Forms.TextBox
        Me.type = New System.Windows.Forms.TextBox
        Me.replacetype = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TxtPackNo
        '
        Me.TxtPackNo.AcceptsReturn = True
        Me.TxtPackNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPackNo.Location = New System.Drawing.Point(77, 25)
        Me.TxtPackNo.MaxLength = 40
        Me.TxtPackNo.Name = "TxtPackNo"
        Me.TxtPackNo.Size = New System.Drawing.Size(235, 21)
        Me.TxtPackNo.TabIndex = 60
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "旧箱箱号："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPassWord
        '
        Me.TxtPassWord.Location = New System.Drawing.Point(78, 63)
        Me.TxtPassWord.Name = "TxtPassWord"
        Me.TxtPassWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassWord.Size = New System.Drawing.Size(235, 21)
        Me.TxtPassWord.TabIndex = 61
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "解锁密码："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonXP1
        '
        Me.ButtonXP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ButtonXP1.DefaultScheme = True
        Me.ButtonXP1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.ButtonXP1.Hint = ""
        Me.ButtonXP1.Location = New System.Drawing.Point(36, 107)
        Me.ButtonXP1.Name = "ButtonXP1"
        Me.ButtonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.ButtonXP1.Size = New System.Drawing.Size(90, 31)
        Me.ButtonXP1.TabIndex = 66
        Me.ButtonXP1.Text = "替换打印(&R)"
        '
        'ButtonXP2
        '
        Me.ButtonXP2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ButtonXP2.DefaultScheme = True
        Me.ButtonXP2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.ButtonXP2.Hint = ""
        Me.ButtonXP2.Location = New System.Drawing.Point(221, 107)
        Me.ButtonXP2.Name = "ButtonXP2"
        Me.ButtonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.ButtonXP2.Size = New System.Drawing.Size(90, 31)
        Me.ButtonXP2.TabIndex = 67
        Me.ButtonXP2.Text = "取消(&C)"
        '
        'TxtPartid
        '
        Me.TxtPartid.Location = New System.Drawing.Point(132, 117)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(24, 21)
        Me.TxtPartid.TabIndex = 68
        Me.TxtPartid.Visible = False
        '
        'type
        '
        Me.type.Location = New System.Drawing.Point(162, 117)
        Me.type.Name = "type"
        Me.type.Size = New System.Drawing.Size(24, 21)
        Me.type.TabIndex = 69
        Me.type.Text = "E5"
        Me.type.Visible = False
        '
        'replacetype
        '
        Me.replacetype.Location = New System.Drawing.Point(191, 117)
        Me.replacetype.Name = "replacetype"
        Me.replacetype.Size = New System.Drawing.Size(24, 21)
        Me.replacetype.TabIndex = 70
        Me.replacetype.Visible = False
        '
        'FrmCartonReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 154)
        Me.Controls.Add(Me.replacetype)
        Me.Controls.Add(Me.type)
        Me.Controls.Add(Me.TxtPartid)
        Me.Controls.Add(Me.ButtonXP2)
        Me.Controls.Add(Me.ButtonXP1)
        Me.Controls.Add(Me.TxtPackNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPassWord)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCartonReplace"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "外箱替换打印作业"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtPackNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonXP1 As PinkieControls.ButtonXP
    Friend WithEvents ButtonXP2 As PinkieControls.ButtonXP
    Friend WithEvents TxtPartid As System.Windows.Forms.TextBox
    Friend WithEvents type As System.Windows.Forms.TextBox
    Friend WithEvents replacetype As System.Windows.Forms.TextBox
End Class
