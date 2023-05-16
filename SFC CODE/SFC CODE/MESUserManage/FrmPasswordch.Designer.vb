<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPasswordch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPasswordch))
        Me.LabNewagain = New System.Windows.Forms.Label()
        Me.LabOldPwd = New System.Windows.Forms.Label()
        Me.LabNewPwd = New System.Windows.Forms.Label()
        Me.TxtagainPwd = New System.Windows.Forms.TextBox()
        Me.TxtOldPwd = New System.Windows.Forms.TextBox()
        Me.TxtNewPwd = New System.Windows.Forms.TextBox()
        Me.BtSave = New System.Windows.Forms.Button()
        Me.cbcheckout2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtCheckOutTwo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCheckOutOne = New System.Windows.Forms.TextBox()
        Me.CbCheckin = New System.Windows.Forms.CheckBox()
        Me.CbCheckout = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TxtCheckOutPwdOfRePrint2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCheckOutPwdOfRePrint1 = New System.Windows.Forms.TextBox()
        Me.CbCheckoutReprint = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabNewagain
        '
        Me.LabNewagain.AutoSize = True
        Me.LabNewagain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabNewagain.Location = New System.Drawing.Point(19, 51)
        Me.LabNewagain.Name = "LabNewagain"
        Me.LabNewagain.Size = New System.Drawing.Size(70, 15)
        Me.LabNewagain.TabIndex = 29
        Me.LabNewagain.Text = "确认新密码:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'LabOldPwd
        '
        Me.LabOldPwd.AutoSize = True
        Me.LabOldPwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabOldPwd.Location = New System.Drawing.Point(47, 12)
        Me.LabOldPwd.Name = "LabOldPwd"
        Me.LabOldPwd.Size = New System.Drawing.Size(82, 15)
        Me.LabOldPwd.TabIndex = 28
        Me.LabOldPwd.Text = "原始登入密码:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'LabNewPwd
        '
        Me.LabNewPwd.AutoSize = True
        Me.LabNewPwd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabNewPwd.Location = New System.Drawing.Point(19, 24)
        Me.LabNewPwd.Name = "LabNewPwd"
        Me.LabNewPwd.Size = New System.Drawing.Size(70, 15)
        Me.LabNewPwd.TabIndex = 27
        Me.LabNewPwd.Text = "输入新密码:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TxtagainPwd
        '
        Me.TxtagainPwd.Location = New System.Drawing.Point(93, 46)
        Me.TxtagainPwd.MaxLength = 16
        Me.TxtagainPwd.Name = "TxtagainPwd"
        Me.TxtagainPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtagainPwd.Size = New System.Drawing.Size(175, 21)
        Me.TxtagainPwd.TabIndex = 5
        '
        'TxtOldPwd
        '
        Me.TxtOldPwd.Location = New System.Drawing.Point(129, 10)
        Me.TxtOldPwd.Name = "TxtOldPwd"
        Me.TxtOldPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtOldPwd.Size = New System.Drawing.Size(142, 21)
        Me.TxtOldPwd.TabIndex = 0
        '
        'TxtNewPwd
        '
        Me.TxtNewPwd.Location = New System.Drawing.Point(93, 19)
        Me.TxtNewPwd.MaxLength = 16
        Me.TxtNewPwd.Name = "TxtNewPwd"
        Me.TxtNewPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtNewPwd.Size = New System.Drawing.Size(175, 21)
        Me.TxtNewPwd.TabIndex = 4
        '
        'BtSave
        '
        Me.BtSave.AutoSize = True
        Me.BtSave.BackColor = System.Drawing.SystemColors.Control
        Me.BtSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BtSave.Image = CType(resources.GetObject("BtSave.Image"), System.Drawing.Image)
        Me.BtSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtSave.Location = New System.Drawing.Point(42, 424)
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(75, 26)
        Me.BtSave.TabIndex = 9
        Me.BtSave.Text = "儲存(&S)"
        Me.BtSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtSave.UseVisualStyleBackColor = False
        '
        'cbcheckout2
        '
        Me.cbcheckout2.AutoSize = True
        Me.cbcheckout2.BackColor = System.Drawing.SystemColors.Control
        Me.cbcheckout2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbcheckout2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cbcheckout2.Image = CType(resources.GetObject("cbcheckout2.Image"), System.Drawing.Image)
        Me.cbcheckout2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cbcheckout2.Location = New System.Drawing.Point(162, 425)
        Me.cbcheckout2.Name = "cbcheckout2"
        Me.cbcheckout2.Size = New System.Drawing.Size(75, 25)
        Me.cbcheckout2.TabIndex = 10
        Me.cbcheckout2.Text = "取消(&C)"
        Me.cbcheckout2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbcheckout2.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtagainPwd)
        Me.GroupBox1.Controls.Add(Me.LabNewagain)
        Me.GroupBox1.Controls.Add(Me.LabNewPwd)
        Me.GroupBox1.Controls.Add(Me.TxtNewPwd)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 237)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 79)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "登入密碼修改"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtCheckOutTwo)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TxtCheckOutOne)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(294, 83)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "解鎖密碼修改"
        '
        'TxtCheckOutTwo
        '
        Me.TxtCheckOutTwo.Location = New System.Drawing.Point(93, 49)
        Me.TxtCheckOutTwo.MaxLength = 16
        Me.TxtCheckOutTwo.Name = "TxtCheckOutTwo"
        Me.TxtCheckOutTwo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtCheckOutTwo.Size = New System.Drawing.Size(175, 21)
        Me.TxtCheckOutTwo.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 15)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "确认新密码:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "输入新密码:"
        '
        'TxtCheckOutOne
        '
        Me.TxtCheckOutOne.Location = New System.Drawing.Point(93, 22)
        Me.TxtCheckOutOne.MaxLength = 16
        Me.TxtCheckOutOne.Name = "TxtCheckOutOne"
        Me.TxtCheckOutOne.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtCheckOutOne.Size = New System.Drawing.Size(175, 21)
        Me.TxtCheckOutOne.TabIndex = 7
        '
        'CbCheckin
        '
        Me.CbCheckin.AutoSize = True
        Me.CbCheckin.Enabled = False
        Me.CbCheckin.Location = New System.Drawing.Point(32, 37)
        Me.CbCheckin.Name = "CbCheckin"
        Me.CbCheckin.Size = New System.Drawing.Size(96, 16)
        Me.CbCheckin.TabIndex = 1
        Me.CbCheckin.Text = "登入密码修改"
        Me.CbCheckin.UseVisualStyleBackColor = True
        '
        'CbCheckout
        '
        Me.CbCheckout.AutoSize = True
        Me.CbCheckout.Location = New System.Drawing.Point(143, 37)
        Me.CbCheckout.Name = "CbCheckout"
        Me.CbCheckout.Size = New System.Drawing.Size(96, 16)
        Me.CbCheckout.TabIndex = 2
        Me.CbCheckout.Text = "解锁密码修改"
        Me.CbCheckout.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxtCheckOutPwdOfRePrint2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TxtCheckOutPwdOfRePrint1)
        Me.GroupBox3.Location = New System.Drawing.Point(28, 154)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(294, 78)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "外箱重新打印密碼修改"
        '
        'TxtCheckOutPwdOfRePrint2
        '
        Me.TxtCheckOutPwdOfRePrint2.Location = New System.Drawing.Point(93, 46)
        Me.TxtCheckOutPwdOfRePrint2.MaxLength = 16
        Me.TxtCheckOutPwdOfRePrint2.Name = "TxtCheckOutPwdOfRePrint2"
        Me.TxtCheckOutPwdOfRePrint2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtCheckOutPwdOfRePrint2.Size = New System.Drawing.Size(175, 21)
        Me.TxtCheckOutPwdOfRePrint2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "确认新密码:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "输入新密码:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TxtCheckOutPwdOfRePrint1
        '
        Me.TxtCheckOutPwdOfRePrint1.Location = New System.Drawing.Point(93, 19)
        Me.TxtCheckOutPwdOfRePrint1.MaxLength = 16
        Me.TxtCheckOutPwdOfRePrint1.Name = "TxtCheckOutPwdOfRePrint1"
        Me.TxtCheckOutPwdOfRePrint1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtCheckOutPwdOfRePrint1.Size = New System.Drawing.Size(175, 21)
        Me.TxtCheckOutPwdOfRePrint1.TabIndex = 4
        '
        'CbCheckoutReprint
        '
        Me.CbCheckoutReprint.AutoSize = True
        Me.CbCheckoutReprint.Checked = True
        Me.CbCheckoutReprint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CbCheckoutReprint.Location = New System.Drawing.Point(257, 37)
        Me.CbCheckoutReprint.Name = "CbCheckoutReprint"
        Me.CbCheckoutReprint.Size = New System.Drawing.Size(144, 16)
        Me.CbCheckoutReprint.TabIndex = 30
        Me.CbCheckoutReprint.Text = "外箱打印解锁密码修改"
        Me.CbCheckoutReprint.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBox1)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.TextBox2)
        Me.GroupBox4.Location = New System.Drawing.Point(28, 322)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(294, 79)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "PDA登入密碼修改"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(93, 46)
        Me.TextBox1.MaxLength = 16
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(175, 21)
        Me.TextBox1.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "确认新密码:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 15)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "输入新密码:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(93, 19)
        Me.TextBox2.MaxLength = 16
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2.Size = New System.Drawing.Size(175, 21)
        Me.TextBox2.TabIndex = 4
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(407, 37)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(114, 16)
        Me.CheckBox1.TabIndex = 32
        Me.CheckBox1.Text = "PDA登入密码修改"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FrmPasswordch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(613, 534)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.CbCheckoutReprint)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.CbCheckout)
        Me.Controls.Add(Me.CbCheckin)
        Me.Controls.Add(Me.LabOldPwd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbcheckout2)
        Me.Controls.Add(Me.BtSave)
        Me.Controls.Add(Me.TxtOldPwd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmPasswordch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "用戶密碼管理"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabNewagain As System.Windows.Forms.Label
    Friend WithEvents LabOldPwd As System.Windows.Forms.Label
    Friend WithEvents LabNewPwd As System.Windows.Forms.Label
    Friend WithEvents TxtagainPwd As System.Windows.Forms.TextBox
    Friend WithEvents TxtOldPwd As System.Windows.Forms.TextBox
    Friend WithEvents TxtNewPwd As System.Windows.Forms.TextBox
    Friend WithEvents BtSave As System.Windows.Forms.Button
    Friend WithEvents cbcheckout2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCheckOutTwo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCheckOutOne As System.Windows.Forms.TextBox
    Friend WithEvents CbCheckin As System.Windows.Forms.CheckBox
    Friend WithEvents CbCheckout As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCheckOutPwdOfRePrint2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCheckOutPwdOfRePrint1 As System.Windows.Forms.TextBox
    Friend WithEvents CbCheckoutReprint As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
