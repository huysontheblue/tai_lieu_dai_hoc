<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.lblbtitle = New System.Windows.Forms.Label()
        Me.LblUErrMessage = New System.Windows.Forms.Label()
        Me.LblPErrMessage = New System.Windows.Forms.Label()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtUsername = New System.Windows.Forms.ComboBox()
        Me.CobFartory = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Lblmsg = New System.Windows.Forms.Label()
        Me.CobProfitcenter = New System.Windows.Forms.ComboBox()
        Me.btnLogin = New DevComponents.DotNetBar.ButtonX()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.CobLang = New System.Windows.Forms.ComboBox()
        Me.lblFactory = New DevComponents.DotNetBar.LabelX()
        Me.lblProfit = New DevComponents.DotNetBar.LabelX()
        Me.lblUser = New DevComponents.DotNetBar.LabelX()
        Me.lblPwd = New DevComponents.DotNetBar.LabelX()
        Me.lbllang = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'lblbtitle
        '
        Me.lblbtitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblbtitle.BackColor = System.Drawing.Color.Transparent
        Me.lblbtitle.ForeColor = System.Drawing.Color.Gray
        Me.lblbtitle.Location = New System.Drawing.Point(2, 340)
        Me.lblbtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblbtitle.Name = "lblbtitle"
        Me.lblbtitle.Size = New System.Drawing.Size(776, 32)
        Me.lblbtitle.TabIndex = 16
        Me.lblbtitle.Text = "立讯精密工业股份有限公司          版权所有"
        Me.lblbtitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUErrMessage
        '
        Me.LblUErrMessage.AutoSize = True
        Me.LblUErrMessage.BackColor = System.Drawing.Color.White
        Me.LblUErrMessage.ForeColor = System.Drawing.Color.Maroon
        Me.LblUErrMessage.Location = New System.Drawing.Point(364, 338)
        Me.LblUErrMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUErrMessage.Name = "LblUErrMessage"
        Me.LblUErrMessage.Size = New System.Drawing.Size(0, 18)
        Me.LblUErrMessage.TabIndex = 27
        '
        'LblPErrMessage
        '
        Me.LblPErrMessage.AutoSize = True
        Me.LblPErrMessage.BackColor = System.Drawing.Color.White
        Me.LblPErrMessage.ForeColor = System.Drawing.Color.Maroon
        Me.LblPErrMessage.Location = New System.Drawing.Point(362, 370)
        Me.LblPErrMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblPErrMessage.Name = "LblPErrMessage"
        Me.LblPErrMessage.Size = New System.Drawing.Size(0, 18)
        Me.LblPErrMessage.TabIndex = 28
        '
        'TxtPassword
        '
        Me.TxtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.TxtPassword.Location = New System.Drawing.Point(462, 249)
        Me.TxtPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(274, 28)
        Me.TxtPassword.TabIndex = 2
        '
        'TxtUsername
        '
        Me.TxtUsername.Font = New System.Drawing.Font("SimSun", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.TxtUsername.FormattingEnabled = True
        Me.TxtUsername.Location = New System.Drawing.Point(462, 208)
        Me.TxtUsername.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtUsername.Name = "TxtUsername"
        Me.TxtUsername.Size = New System.Drawing.Size(274, 26)
        Me.TxtUsername.TabIndex = 1
        '
        'CobFartory
        '
        Me.CobFartory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobFartory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CobFartory.FormattingEnabled = True
        Me.CobFartory.Items.AddRange(New Object() {"LX21-协讯外销"})
        Me.CobFartory.Location = New System.Drawing.Point(462, 128)
        Me.CobFartory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CobFartory.Name = "CobFartory"
        Me.CobFartory.Size = New System.Drawing.Size(274, 26)
        Me.CobFartory.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(320, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(333, 74)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "生 产 现 场 控 制 系 统" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Shop Floor Control System"
        '
        'Lblmsg
        '
        Me.Lblmsg.AutoSize = True
        Me.Lblmsg.BackColor = System.Drawing.Color.Transparent
        Me.Lblmsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Lblmsg.Location = New System.Drawing.Point(26, 92)
        Me.Lblmsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lblmsg.Name = "Lblmsg"
        Me.Lblmsg.Size = New System.Drawing.Size(0, 18)
        Me.Lblmsg.TabIndex = 36
        '
        'CobProfitcenter
        '
        Me.CobProfitcenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobProfitcenter.FormattingEnabled = True
        Me.CobProfitcenter.Location = New System.Drawing.Point(462, 168)
        Me.CobProfitcenter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CobProfitcenter.Name = "CobProfitcenter"
        Me.CobProfitcenter.Size = New System.Drawing.Size(274, 26)
        Me.CobProfitcenter.TabIndex = 37
        '
        'btnLogin
        '
        Me.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.Location = New System.Drawing.Point(462, 294)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(112, 38)
        Me.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.btnLogin.TabIndex = 39
        Me.btnLogin.Text = "登录"
        '
        'btnClose
        '
        Me.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(614, 294)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(112, 38)
        Me.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.btnClose.TabIndex = 40
        Me.btnClose.Text = "取消"
        '
        'CobLang
        '
        Me.CobLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobLang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CobLang.FormattingEnabled = True
        Me.CobLang.Location = New System.Drawing.Point(462, 87)
        Me.CobLang.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CobLang.Name = "CobLang"
        Me.CobLang.Size = New System.Drawing.Size(274, 26)
        Me.CobLang.TabIndex = 42
        '
        'lblFactory
        '
        Me.lblFactory.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblFactory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFactory.Location = New System.Drawing.Point(280, 124)
        Me.lblFactory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblFactory.Name = "lblFactory"
        Me.lblFactory.Size = New System.Drawing.Size(172, 34)
        Me.lblFactory.TabIndex = 43
        Me.lblFactory.Text = "营运中心:"
        Me.lblFactory.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblProfit
        '
        Me.lblProfit.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblProfit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblProfit.Location = New System.Drawing.Point(280, 164)
        Me.lblProfit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblProfit.Name = "lblProfit"
        Me.lblProfit.Size = New System.Drawing.Size(172, 34)
        Me.lblProfit.TabIndex = 44
        Me.lblProfit.Text = "利润中心:"
        Me.lblProfit.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblUser
        '
        Me.lblUser.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblUser.Location = New System.Drawing.Point(280, 204)
        Me.lblUser.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(172, 34)
        Me.lblUser.TabIndex = 45
        Me.lblUser.Text = "用户名:"
        Me.lblUser.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblPwd
        '
        Me.lblPwd.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblPwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPwd.Location = New System.Drawing.Point(280, 249)
        Me.lblPwd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblPwd.Name = "lblPwd"
        Me.lblPwd.Size = New System.Drawing.Size(172, 34)
        Me.lblPwd.TabIndex = 46
        Me.lblPwd.Text = "密码:"
        Me.lblPwd.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lbllang
        '
        Me.lbllang.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbllang.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbllang.Location = New System.Drawing.Point(280, 87)
        Me.lbllang.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lbllang.Name = "lbllang"
        Me.lbllang.Size = New System.Drawing.Size(172, 34)
        Me.lbllang.TabIndex = 47
        Me.lbllang.Text = "语言:"
        Me.lbllang.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Login
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.BackgroundImage = Global.MesSystem.My.Resources.Resources.bg01
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(780, 375)
        Me.Controls.Add(Me.lbllang)
        Me.Controls.Add(Me.lblPwd)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblProfit)
        Me.Controls.Add(Me.lblFactory)
        Me.Controls.Add(Me.CobLang)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.CobProfitcenter)
        Me.Controls.Add(Me.Lblmsg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CobFartory)
        Me.Controls.Add(Me.TxtUsername)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.LblPErrMessage)
        Me.Controls.Add(Me.LblUErrMessage)
        Me.Controls.Add(Me.lblbtitle)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Login"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "立讯精密工业股份有限公司-系统登录"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblbtitle As System.Windows.Forms.Label
    Friend WithEvents LblUErrMessage As System.Windows.Forms.Label
    Friend WithEvents LblPErrMessage As System.Windows.Forms.Label
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsername As System.Windows.Forms.ComboBox
    'Private WithEvents CobFactory As DevComponents.DotNetBar.Controls.ComboBoxEx
    'Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    'Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents CobFartory As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Lblmsg As System.Windows.Forms.Label
    Friend WithEvents CobProfitcenter As System.Windows.Forms.ComboBox
    Friend WithEvents CobLang As System.Windows.Forms.ComboBox
    Private WithEvents btnLogin As DevComponents.DotNetBar.ButtonX
    Private WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Private WithEvents lblFactory As DevComponents.DotNetBar.LabelX
    Private WithEvents lblProfit As DevComponents.DotNetBar.LabelX
    Private WithEvents lblUser As DevComponents.DotNetBar.LabelX
    Private WithEvents lblPwd As DevComponents.DotNetBar.LabelX
    Private WithEvents lbllang As DevComponents.DotNetBar.LabelX

End Class
