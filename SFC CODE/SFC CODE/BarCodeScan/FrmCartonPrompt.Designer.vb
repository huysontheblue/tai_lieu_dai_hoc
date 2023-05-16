<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCartonPrompt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCartonPrompt))
        Me.CobError = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BnOpenlock = New System.Windows.Forms.Button
        Me.TxtUserPass = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabSn = New System.Windows.Forms.Label
        Me.LabError = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BnCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CobError
        '
        Me.CobError.FormattingEnabled = True
        Me.CobError.Items.AddRange(New Object() {"处理方案..."})
        Me.CobError.Location = New System.Drawing.Point(115, 11)
        Me.CobError.Name = "CobError"
        Me.CobError.Size = New System.Drawing.Size(238, 20)
        Me.CobError.TabIndex = 83
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "解决方法："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BnOpenlock
        '
        Me.BnOpenlock.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BnOpenlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnOpenlock.Location = New System.Drawing.Point(115, 68)
        Me.BnOpenlock.Name = "BnOpenlock"
        Me.BnOpenlock.Size = New System.Drawing.Size(66, 23)
        Me.BnOpenlock.TabIndex = 79
        Me.BnOpenlock.Text = "確 定(&O)"
        Me.BnOpenlock.UseVisualStyleBackColor = True
        '
        'TxtUserPass
        '
        Me.TxtUserPass.Location = New System.Drawing.Point(115, 38)
        Me.TxtUserPass.Name = "TxtUserPass"
        Me.TxtUserPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtUserPass.Size = New System.Drawing.Size(238, 21)
        Me.TxtUserPass.TabIndex = 78
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "解锁密码："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CobError)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtUserPass)
        Me.GroupBox1.Controls.Add(Me.BnOpenlock)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.BnCancel)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 111)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(394, 98)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(166, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "扫描错误提示"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabSn
        '
        Me.LabSn.AutoSize = True
        Me.LabSn.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabSn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabSn.Location = New System.Drawing.Point(137, 31)
        Me.LabSn.Name = "LabSn"
        Me.LabSn.Size = New System.Drawing.Size(192, 16)
        Me.LabSn.TabIndex = 81
        Me.LabSn.Text = "CN0YN993698617368003"
        Me.LabSn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabError
        '
        Me.LabError.AutoSize = True
        Me.LabError.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LabError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LabError.Location = New System.Drawing.Point(133, 66)
        Me.LabError.Name = "LabError"
        Me.LabError.Size = New System.Drawing.Size(57, 12)
        Me.LabError.TabIndex = 80
        Me.LabError.Text = "重复扫描"
        Me.LabError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(132, 111)
        Me.PictureBox1.TabIndex = 82
        Me.PictureBox1.TabStop = False
        '
        'BnCancel
        '
        Me.BnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BnCancel.Image = CType(resources.GetObject("BnCancel.Image"), System.Drawing.Image)
        Me.BnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnCancel.Location = New System.Drawing.Point(287, 68)
        Me.BnCancel.Name = "BnCancel"
        Me.BnCancel.Size = New System.Drawing.Size(66, 23)
        Me.BnCancel.TabIndex = 80
        Me.BnCancel.Text = "清 除(&C)"
        Me.BnCancel.UseVisualStyleBackColor = True
        '
        'FrmCartonPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 211)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabSn)
        Me.Controls.Add(Me.LabError)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCartonPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "扫描错误提示框"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CobError As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BnOpenlock As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtUserPass As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabSn As System.Windows.Forms.Label
    Friend WithEvents LabError As System.Windows.Forms.Label
End Class
