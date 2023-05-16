<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScanErrPrompt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmScanErrPrompt))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtUserPass = New System.Windows.Forms.TextBox()
        Me.BnOpenlock = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BnCancel = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(132, 111)
        Me.PictureBox1.TabIndex = 75
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(139, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 41)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "ASN掃描錯誤"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtUserPass)
        Me.GroupBox1.Controls.Add(Me.BnOpenlock)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.BnCancel)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 80)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        '
        'TxtUserPass
        '
        Me.TxtUserPass.Location = New System.Drawing.Point(115, 17)
        Me.TxtUserPass.Name = "TxtUserPass"
        Me.TxtUserPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtUserPass.Size = New System.Drawing.Size(238, 21)
        Me.TxtUserPass.TabIndex = 78
        '
        'BnOpenlock
        '
        Me.BnOpenlock.Image = CType(resources.GetObject("BnOpenlock.Image"), System.Drawing.Image)
        Me.BnOpenlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnOpenlock.Location = New System.Drawing.Point(115, 47)
        Me.BnOpenlock.Name = "BnOpenlock"
        Me.BnOpenlock.Size = New System.Drawing.Size(80, 23)
        Me.BnOpenlock.TabIndex = 79
        Me.BnOpenlock.Text = "確 定( &T)"
        Me.BnOpenlock.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnOpenlock.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "解锁密码:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BnCancel
        '
        Me.BnCancel.Image = CType(resources.GetObject("BnCancel.Image"), System.Drawing.Image)
        Me.BnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnCancel.Location = New System.Drawing.Point(275, 47)
        Me.BnCancel.Name = "BnCancel"
        Me.BnCancel.Size = New System.Drawing.Size(78, 23)
        Me.BnCancel.TabIndex = 80
        Me.BnCancel.Text = "取消（&F)"
        Me.BnCancel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnCancel.UseVisualStyleBackColor = True
        '
        'FrmScanErrPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 198)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmScanErrPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "扫描错误提示框"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtUserPass As System.Windows.Forms.TextBox
    Friend WithEvents BnOpenlock As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BnCancel As System.Windows.Forms.Button
End Class
