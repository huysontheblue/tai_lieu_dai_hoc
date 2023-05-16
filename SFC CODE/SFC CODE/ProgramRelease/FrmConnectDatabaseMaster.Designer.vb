<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConnectDatabaseMaster
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
        Me.txtConnectDatabaseName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtConnectDatabaseAddress = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtConnnectDataBase = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtLoginPassword = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtLoginUserId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.txtCreateUserId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.txtCreateTime = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.txtRemark = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'txtConnectDatabaseName
        '
        '
        '
        '
        Me.txtConnectDatabaseName.Border.Class = "TextBoxBorder"
        Me.txtConnectDatabaseName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtConnectDatabaseName.Location = New System.Drawing.Point(105, 56)
        Me.txtConnectDatabaseName.Name = "txtConnectDatabaseName"
        Me.txtConnectDatabaseName.Size = New System.Drawing.Size(170, 21)
        Me.txtConnectDatabaseName.TabIndex = 0
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(24, 56)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "连接名称"
        '
        'txtConnectDatabaseAddress
        '
        '
        '
        '
        Me.txtConnectDatabaseAddress.Border.Class = "TextBoxBorder"
        Me.txtConnectDatabaseAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtConnectDatabaseAddress.Location = New System.Drawing.Point(105, 110)
        Me.txtConnectDatabaseAddress.Name = "txtConnectDatabaseAddress"
        Me.txtConnectDatabaseAddress.Size = New System.Drawing.Size(170, 21)
        Me.txtConnectDatabaseAddress.TabIndex = 2
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(24, 108)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "连接地址"
        '
        'txtConnnectDataBase
        '
        '
        '
        '
        Me.txtConnnectDataBase.Border.Class = "TextBoxBorder"
        Me.txtConnnectDataBase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtConnnectDataBase.Location = New System.Drawing.Point(424, 110)
        Me.txtConnnectDataBase.Name = "txtConnnectDataBase"
        Me.txtConnnectDataBase.Size = New System.Drawing.Size(170, 21)
        Me.txtConnnectDataBase.TabIndex = 3
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(343, 110)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "连接数据库"
        '
        'txtLoginPassword
        '
        '
        '
        '
        Me.txtLoginPassword.Border.Class = "TextBoxBorder"
        Me.txtLoginPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLoginPassword.Location = New System.Drawing.Point(424, 160)
        Me.txtLoginPassword.Name = "txtLoginPassword"
        Me.txtLoginPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtLoginPassword.Size = New System.Drawing.Size(170, 21)
        Me.txtLoginPassword.TabIndex = 5
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(343, 160)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 7
        Me.LabelX4.Text = "登录密码"
        '
        'txtLoginUserId
        '
        '
        '
        '
        Me.txtLoginUserId.Border.Class = "TextBoxBorder"
        Me.txtLoginUserId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLoginUserId.Location = New System.Drawing.Point(105, 160)
        Me.txtLoginUserId.Name = "txtLoginUserId"
        Me.txtLoginUserId.Size = New System.Drawing.Size(170, 21)
        Me.txtLoginUserId.TabIndex = 4
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(24, 160)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 9
        Me.LabelX5.Text = "登录用户"
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Location = New System.Drawing.Point(24, 16)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(532, 23)
        Me.LabelX23.TabIndex = 189
        Me.LabelX23.Text = "▼登录密码为加密后的字符串"
        '
        'txtCreateUserId
        '
        '
        '
        '
        Me.txtCreateUserId.Border.Class = "TextBoxBorder"
        Me.txtCreateUserId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCreateUserId.Location = New System.Drawing.Point(105, 264)
        Me.txtCreateUserId.Name = "txtCreateUserId"
        Me.txtCreateUserId.ReadOnly = True
        Me.txtCreateUserId.Size = New System.Drawing.Size(170, 21)
        Me.txtCreateUserId.TabIndex = 192
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(24, 264)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 23)
        Me.LabelX6.TabIndex = 193
        Me.LabelX6.Text = "编辑用户"
        '
        'txtCreateTime
        '
        '
        '
        '
        Me.txtCreateTime.Border.Class = "TextBoxBorder"
        Me.txtCreateTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCreateTime.Location = New System.Drawing.Point(424, 265)
        Me.txtCreateTime.Name = "txtCreateTime"
        Me.txtCreateTime.ReadOnly = True
        Me.txtCreateTime.Size = New System.Drawing.Size(170, 21)
        Me.txtCreateTime.TabIndex = 190
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(343, 265)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 23)
        Me.LabelX7.TabIndex = 191
        Me.LabelX7.Text = "编辑时间"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(517, 321)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(65, 25)
        Me.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "取  消"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(370, 321)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(65, 25)
        Me.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "保  存"
        '
        'txtRemark
        '
        '
        '
        '
        Me.txtRemark.Border.Class = "TextBoxBorder"
        Me.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemark.Location = New System.Drawing.Point(105, 214)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(489, 21)
        Me.txtRemark.TabIndex = 6
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(24, 212)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 23)
        Me.LabelX8.TabIndex = 197
        Me.LabelX8.Text = "说明"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(12, 323)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(371, 23)
        Me.lblMessage.TabIndex = 198
        '
        'FrmConnectDatabaseMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 368)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.LabelX8)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtCreateUserId)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.txtCreateTime)
        Me.Controls.Add(Me.LabelX7)
        Me.Controls.Add(Me.LabelX23)
        Me.Controls.Add(Me.txtLoginUserId)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.txtLoginPassword)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.txtConnnectDataBase)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.txtConnectDatabaseAddress)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.txtConnectDatabaseName)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.lblMessage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConnectDatabaseMaster"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "数据库定义"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtConnectDatabaseName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtConnectDatabaseAddress As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtConnnectDataBase As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtLoginPassword As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtLoginUserId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCreateUserId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCreateTime As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtRemark As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
End Class
