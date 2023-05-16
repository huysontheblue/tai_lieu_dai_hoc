<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Checks
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
        Me.txtCreaterUser = New System.Windows.Forms.TextBox()
        Me.txtCheckUser = New System.Windows.Forms.TextBox()
        Me.txtCheckTime = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNextCheckTime = New System.Windows.Forms.TextBox()
        Me.ComCheckStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.hidChecksEquID = New System.Windows.Forms.TextBox()
        Me.txtEquCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCreaterUser
        '
        Me.txtCreaterUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCreaterUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreaterUser.Location = New System.Drawing.Point(724, 36)
        Me.txtCreaterUser.MaxLength = 30
        Me.txtCreaterUser.Name = "txtCreaterUser"
        Me.txtCreaterUser.Size = New System.Drawing.Size(127, 21)
        Me.txtCreaterUser.TabIndex = 74
        '
        'txtCheckUser
        '
        Me.txtCheckUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckUser.Location = New System.Drawing.Point(300, 36)
        Me.txtCheckUser.MaxLength = 30
        Me.txtCheckUser.Name = "txtCheckUser"
        Me.txtCheckUser.Size = New System.Drawing.Size(121, 21)
        Me.txtCheckUser.TabIndex = 73
        '
        'txtCheckTime
        '
        Me.txtCheckTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckTime.Location = New System.Drawing.Point(300, 84)
        Me.txtCheckTime.MaxLength = 25
        Me.txtCheckTime.Name = "txtCheckTime"
        Me.txtCheckTime.Size = New System.Drawing.Size(121, 21)
        Me.txtCheckTime.TabIndex = 70
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(213, 90)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 12)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "本次校验日期："
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Checked = False
        Me.DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(86, 84)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowCheckBox = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 21)
        Me.DateTimePicker1.TabIndex = 68
        Me.DateTimePicker1.Value = New Date(2015, 5, 27, 10, 12, 43, 0)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(27, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "创建日期："
        '
        'txtRemark
        '
        Me.txtRemark.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(86, 140)
        Me.txtRemark.MaxLength = 25
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(804, 21)
        Me.txtRemark.TabIndex = 66
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(27, 143)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "备    注："
        '
        'txtNextCheckTime
        '
        Me.txtNextCheckTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNextCheckTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNextCheckTime.Location = New System.Drawing.Point(522, 81)
        Me.txtNextCheckTime.MaxLength = 25
        Me.txtNextCheckTime.Name = "txtNextCheckTime"
        Me.txtNextCheckTime.Size = New System.Drawing.Size(118, 21)
        Me.txtNextCheckTime.TabIndex = 54
        '
        'ComCheckStatus
        '
        Me.ComCheckStatus.FormattingEnabled = True
        Me.ComCheckStatus.Location = New System.Drawing.Point(522, 37)
        Me.ComCheckStatus.MaxLength = 20
        Me.ComCheckStatus.Name = "ComCheckStatus"
        Me.ComCheckStatus.Size = New System.Drawing.Size(118, 20)
        Me.ComCheckStatus.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(457, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "校验状态："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(662, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "创 建 人："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(237, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "校 验 人："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(436, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 12)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "下次校验日期："
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(282, 189)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 138
        Me.btnSave.Text = "提 交"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(512, 189)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 139
        Me.Button1.Text = "取 消"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'hidChecksEquID
        '
        Me.hidChecksEquID.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.hidChecksEquID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.hidChecksEquID.Location = New System.Drawing.Point(724, 84)
        Me.hidChecksEquID.MaxLength = 25
        Me.hidChecksEquID.Name = "hidChecksEquID"
        Me.hidChecksEquID.Size = New System.Drawing.Size(118, 21)
        Me.hidChecksEquID.TabIndex = 140
        Me.hidChecksEquID.Visible = False
        '
        'txtEquCode
        '
        Me.txtEquCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEquCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEquCode.Location = New System.Drawing.Point(86, 36)
        Me.txtEquCode.MaxLength = 30
        Me.txtEquCode.Name = "txtEquCode"
        Me.txtEquCode.Size = New System.Drawing.Size(121, 21)
        Me.txtEquCode.TabIndex = 148
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "设备编号："
        '
        'Checks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 225)
        Me.Controls.Add(Me.txtEquCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.hidChecksEquID)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.txtCheckTime)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCreaterUser)
        Me.Controls.Add(Me.txtNextCheckTime)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.txtCheckUser)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComCheckStatus)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Checks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "设备校验"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCreaterUser As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckTime As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNextCheckTime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCheckUser As System.Windows.Forms.TextBox
    Friend WithEvents ComCheckStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents hidChecksEquID As System.Windows.Forms.TextBox
    Friend WithEvents txtEquCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
