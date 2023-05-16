<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAberrantErrPrompt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAberrantErrPrompt))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabSn = New ULControls.textBoxUL()
        Me.RTxtErrdes = New System.Windows.Forms.TextBox()
        Me.lbTitile = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CobError = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtUserPass = New System.Windows.Forms.TextBox()
        Me.BnOpenlock = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BnCancel = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabSn)
        Me.Panel1.Controls.Add(Me.RTxtErrdes)
        Me.Panel1.Controls.Add(Me.lbTitile)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(585, 127)
        Me.Panel1.TabIndex = 96
        '
        'LabSn
        '
        Me.LabSn.BackColor = System.Drawing.Color.White
        Me.LabSn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabSn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabSn.Font = New System.Drawing.Font("幼圆", 14.25!)
        Me.LabSn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LabSn.HotColor = System.Drawing.Color.White
        Me.LabSn.Location = New System.Drawing.Point(147, 30)
        Me.LabSn.Name = "LabSn"
        Me.LabSn.ReadOnly = True
        Me.LabSn.Size = New System.Drawing.Size(336, 21)
        Me.LabSn.TabIndex = 99
        '
        'RTxtErrdes
        '
        Me.RTxtErrdes.BackColor = System.Drawing.Color.White
        Me.RTxtErrdes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RTxtErrdes.Font = New System.Drawing.Font("宋体", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RTxtErrdes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RTxtErrdes.Location = New System.Drawing.Point(144, 61)
        Me.RTxtErrdes.Multiline = True
        Me.RTxtErrdes.Name = "RTxtErrdes"
        Me.RTxtErrdes.ReadOnly = True
        Me.RTxtErrdes.Size = New System.Drawing.Size(437, 54)
        Me.RTxtErrdes.TabIndex = 98
        Me.RTxtErrdes.Text = "提示信息"
        '
        'lbTitile
        '
        Me.lbTitile.AutoSize = True
        Me.lbTitile.Font = New System.Drawing.Font("幼圆", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbTitile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lbTitile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbTitile.Location = New System.Drawing.Point(214, 5)
        Me.lbTitile.Name = "lbTitile"
        Me.lbTitile.Size = New System.Drawing.Size(89, 19)
        Me.lbTitile.TabIndex = 97
        Me.lbTitile.Text = "错误提示"
        Me.lbTitile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(132, 111)
        Me.PictureBox1.TabIndex = 96
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 127)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(585, 158)
        Me.Panel2.TabIndex = 97
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CobError)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtUserPass)
        Me.GroupBox1.Controls.Add(Me.BnOpenlock)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.BnCancel)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(585, 158)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(158, 82)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(131, 21)
        Me.txtUserName.TabIndex = 84
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "解锁用户："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobError
        '
        Me.CobError.FormattingEnabled = True
        Me.CobError.Location = New System.Drawing.Point(158, 44)
        Me.CobError.Name = "CobError"
        Me.CobError.Size = New System.Drawing.Size(334, 20)
        Me.CobError.TabIndex = 83
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(87, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "解決方法："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtUserPass
        '
        Me.TxtUserPass.Location = New System.Drawing.Point(368, 81)
        Me.TxtUserPass.Name = "TxtUserPass"
        Me.TxtUserPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtUserPass.Size = New System.Drawing.Size(123, 21)
        Me.TxtUserPass.TabIndex = 85
        '
        'BnOpenlock
        '
        Me.BnOpenlock.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnOpenlock.Image = CType(resources.GetObject("BnOpenlock.Image"), System.Drawing.Image)
        Me.BnOpenlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnOpenlock.Location = New System.Drawing.Point(174, 122)
        Me.BnOpenlock.Name = "BnOpenlock"
        Me.BnOpenlock.Size = New System.Drawing.Size(89, 23)
        Me.BnOpenlock.TabIndex = 79
        Me.BnOpenlock.Text = "继续替换"
        Me.BnOpenlock.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnOpenlock.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(297, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "解锁密码："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BnCancel
        '
        Me.BnCancel.DialogResult = System.Windows.Forms.DialogResult.No
        Me.BnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnCancel.Image = CType(resources.GetObject("BnCancel.Image"), System.Drawing.Image)
        Me.BnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnCancel.Location = New System.Drawing.Point(313, 122)
        Me.BnCancel.Name = "BnCancel"
        Me.BnCancel.Size = New System.Drawing.Size(61, 23)
        Me.BnCancel.TabIndex = 80
        Me.BnCancel.Text = "解锁"
        Me.BnCancel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnCancel.UseVisualStyleBackColor = True
        '
        'FrmAberrantErrPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 285)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmAberrantErrPrompt"
        Me.Text = "异常错误确认框"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabSn As ULControls.textBoxUL
    Friend WithEvents RTxtErrdes As System.Windows.Forms.TextBox
    Friend WithEvents lbTitile As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CobError As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtUserPass As System.Windows.Forms.TextBox
    Friend WithEvents BnOpenlock As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BnCancel As System.Windows.Forms.Button
End Class
