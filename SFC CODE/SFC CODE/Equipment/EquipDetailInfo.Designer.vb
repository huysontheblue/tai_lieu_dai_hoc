<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipDetailInfo
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
        Me.hidEquID = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbLend = New System.Windows.Forms.Label()
        Me.txtCreateTime = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtStorage = New System.Windows.Forms.TextBox()
        Me.txtJsNo = New System.Windows.Forms.TextBox()
        Me.txtZcNo = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lbUser = New System.Windows.Forms.Label()
        Me.lbCreateUser = New System.Windows.Forms.Label()
        Me.txtCheckTime = New System.Windows.Forms.TextBox()
        Me.txtNextCheckTime = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.txtCreateUser = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtCheckInterval = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTouchUserS = New System.Windows.Forms.TextBox()
        Me.txtVendCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtResponUser = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEquCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtFinishTime = New System.Windows.Forms.TextBox()
        Me.lbReturnUser = New System.Windows.Forms.Label()
        Me.lbCreaterUser = New System.Windows.Forms.Label()
        Me.lbTouchUser = New System.Windows.Forms.Label()
        Me.txtLendStatus = New System.Windows.Forms.TextBox()
        Me.txtLocationNow = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtFinishUser = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtCreaterUser = New System.Windows.Forms.TextBox()
        Me.txtLendRemark = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTouchUser = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbCUser = New System.Windows.Forms.Label()
        Me.lbCheck = New System.Windows.Forms.Label()
        Me.txtCheckRemark = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCheckCreateTime = New System.Windows.Forms.TextBox()
        Me.txtCheckCreateUser = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtCheckStatus = New System.Windows.Forms.TextBox()
        Me.txtCheckUser = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'hidEquID
        '
        Me.hidEquID.Location = New System.Drawing.Point(288, 239)
        Me.hidEquID.Name = "hidEquID"
        Me.hidEquID.Size = New System.Drawing.Size(100, 21)
        Me.hidEquID.TabIndex = 0
        Me.hidEquID.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lbLend)
        Me.Panel1.Controls.Add(Me.txtCreateTime)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.txtStorage)
        Me.Panel1.Controls.Add(Me.txtJsNo)
        Me.Panel1.Controls.Add(Me.txtZcNo)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.lbUser)
        Me.Panel1.Controls.Add(Me.lbCreateUser)
        Me.Panel1.Controls.Add(Me.txtCheckTime)
        Me.Panel1.Controls.Add(Me.txtNextCheckTime)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtStatus)
        Me.Panel1.Controls.Add(Me.txtLocation)
        Me.Panel1.Controls.Add(Me.txtType)
        Me.Panel1.Controls.Add(Me.txtCreateUser)
        Me.Panel1.Controls.Add(Me.txtTitle)
        Me.Panel1.Controls.Add(Me.txtCheckInterval)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtRemark)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtTouchUserS)
        Me.Panel1.Controls.Add(Me.txtVendCode)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtResponUser)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtEquCode)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(24, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(959, 158)
        Me.Panel1.TabIndex = 132
        '
        'lbLend
        '
        Me.lbLend.AutoSize = True
        Me.lbLend.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLend.Location = New System.Drawing.Point(686, 94)
        Me.lbLend.Name = "lbLend"
        Me.lbLend.Size = New System.Drawing.Size(40, 12)
        Me.lbLend.TabIndex = 91
        Me.lbLend.Text = "/////"
        '
        'txtCreateTime
        '
        Me.txtCreateTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCreateTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreateTime.Location = New System.Drawing.Point(823, 88)
        Me.txtCreateTime.MaxLength = 11
        Me.txtCreateTime.Name = "txtCreateTime"
        Me.txtCreateTime.Size = New System.Drawing.Size(132, 21)
        Me.txtCreateTime.TabIndex = 90
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(764, 91)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(65, 12)
        Me.Label32.TabIndex = 89
        Me.Label32.Text = "创建时间："
        '
        'txtStorage
        '
        Me.txtStorage.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStorage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStorage.Location = New System.Drawing.Point(568, 34)
        Me.txtStorage.MaxLength = 11
        Me.txtStorage.Name = "txtStorage"
        Me.txtStorage.Size = New System.Drawing.Size(112, 21)
        Me.txtStorage.TabIndex = 88
        '
        'txtJsNo
        '
        Me.txtJsNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtJsNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJsNo.Location = New System.Drawing.Point(313, 8)
        Me.txtJsNo.MaxLength = 10
        Me.txtJsNo.Name = "txtJsNo"
        Me.txtJsNo.Size = New System.Drawing.Size(121, 21)
        Me.txtJsNo.TabIndex = 87
        '
        'txtZcNo
        '
        Me.txtZcNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtZcNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZcNo.Location = New System.Drawing.Point(568, 7)
        Me.txtZcNo.MaxLength = 30
        Me.txtZcNo.Name = "txtZcNo"
        Me.txtZcNo.Size = New System.Drawing.Size(112, 21)
        Me.txtZcNo.TabIndex = 86
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(256, 11)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(65, 12)
        Me.Label29.TabIndex = 85
        Me.Label29.Text = "机 申 号："
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(508, 38)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(65, 12)
        Me.Label30.TabIndex = 84
        Me.Label30.Text = "储    位："
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(508, 11)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 12)
        Me.Label31.TabIndex = 83
        Me.Label31.Text = "资产编号："
        '
        'lbUser
        '
        Me.lbUser.AutoSize = True
        Me.lbUser.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbUser.Location = New System.Drawing.Point(441, 94)
        Me.lbUser.Name = "lbUser"
        Me.lbUser.Size = New System.Drawing.Size(40, 12)
        Me.lbUser.TabIndex = 82
        Me.lbUser.Text = "/////"
        '
        'lbCreateUser
        '
        Me.lbCreateUser.AutoSize = True
        Me.lbCreateUser.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbCreateUser.Location = New System.Drawing.Point(189, 97)
        Me.lbCreateUser.Name = "lbCreateUser"
        Me.lbCreateUser.Size = New System.Drawing.Size(0, 12)
        Me.lbCreateUser.TabIndex = 81
        '
        'txtCheckTime
        '
        Me.txtCheckTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckTime.Location = New System.Drawing.Point(65, 61)
        Me.txtCheckTime.MaxLength = 25
        Me.txtCheckTime.Name = "txtCheckTime"
        Me.txtCheckTime.Size = New System.Drawing.Size(121, 21)
        Me.txtCheckTime.TabIndex = 80
        '
        'txtNextCheckTime
        '
        Me.txtNextCheckTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNextCheckTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNextCheckTime.Location = New System.Drawing.Point(568, 61)
        Me.txtNextCheckTime.MaxLength = 25
        Me.txtNextCheckTime.Name = "txtNextCheckTime"
        Me.txtNextCheckTime.Size = New System.Drawing.Size(112, 21)
        Me.txtNextCheckTime.TabIndex = 79
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(484, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 12)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "下次校验日期："
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Location = New System.Drawing.Point(314, 34)
        Me.txtStatus.MaxLength = 25
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(121, 21)
        Me.txtStatus.TabIndex = 77
        '
        'txtLocation
        '
        Me.txtLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocation.Location = New System.Drawing.Point(824, 34)
        Me.txtLocation.MaxLength = 11
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(133, 21)
        Me.txtLocation.TabIndex = 76
        '
        'txtType
        '
        Me.txtType.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtType.Location = New System.Drawing.Point(66, 34)
        Me.txtType.MaxLength = 10
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(120, 21)
        Me.txtType.TabIndex = 75
        '
        'txtCreateUser
        '
        Me.txtCreateUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCreateUser.Location = New System.Drawing.Point(65, 91)
        Me.txtCreateUser.MaxLength = 30
        Me.txtCreateUser.Name = "txtCreateUser"
        Me.txtCreateUser.Size = New System.Drawing.Size(121, 21)
        Me.txtCreateUser.TabIndex = 74
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTitle.Location = New System.Drawing.Point(823, 7)
        Me.txtTitle.MaxLength = 30
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(133, 21)
        Me.txtTitle.TabIndex = 73
        '
        'txtCheckInterval
        '
        Me.txtCheckInterval.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckInterval.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckInterval.Location = New System.Drawing.Point(313, 61)
        Me.txtCheckInterval.MaxLength = 25
        Me.txtCheckInterval.Name = "txtCheckInterval"
        Me.txtCheckInterval.Size = New System.Drawing.Size(121, 21)
        Me.txtCheckInterval.TabIndex = 70
        Me.txtCheckInterval.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(232, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 12)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "校验间隔(天)："
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "校验日期："
        '
        'txtRemark
        '
        Me.txtRemark.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(65, 118)
        Me.txtRemark.MaxLength = 25
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(891, 21)
        Me.txtRemark.TabIndex = 66
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "备    注："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Location = New System.Drawing.Point(256, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "负 责 人："
        '
        'txtTouchUserS
        '
        Me.txtTouchUserS.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTouchUserS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTouchUserS.Location = New System.Drawing.Point(568, 88)
        Me.txtTouchUserS.MaxLength = 11
        Me.txtTouchUserS.Name = "txtTouchUserS"
        Me.txtTouchUserS.Size = New System.Drawing.Size(112, 21)
        Me.txtTouchUserS.TabIndex = 57
        '
        'txtVendCode
        '
        Me.txtVendCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtVendCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendCode.Location = New System.Drawing.Point(823, 61)
        Me.txtVendCode.MaxLength = 10
        Me.txtVendCode.Name = "txtVendCode"
        Me.txtVendCode.Size = New System.Drawing.Size(133, 21)
        Me.txtVendCode.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "设备类型："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "创 建 人："
        '
        'txtResponUser
        '
        Me.txtResponUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtResponUser.Location = New System.Drawing.Point(314, 88)
        Me.txtResponUser.MaxLength = 30
        Me.txtResponUser.Name = "txtResponUser"
        Me.txtResponUser.Size = New System.Drawing.Size(120, 21)
        Me.txtResponUser.TabIndex = 41
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(508, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "借 出 人："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(764, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "设备位置："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(256, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "状    态："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(764, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "设备名称："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(753, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "供应商代码："
        '
        'txtEquCode
        '
        Me.txtEquCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEquCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEquCode.Location = New System.Drawing.Point(65, 8)
        Me.txtEquCode.MaxLength = 25
        Me.txtEquCode.Name = "txtEquCode"
        Me.txtEquCode.Size = New System.Drawing.Size(121, 21)
        Me.txtEquCode.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "设备编号："
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtFinishTime)
        Me.Panel2.Controls.Add(Me.lbReturnUser)
        Me.Panel2.Controls.Add(Me.lbCreaterUser)
        Me.Panel2.Controls.Add(Me.lbTouchUser)
        Me.Panel2.Controls.Add(Me.txtLendStatus)
        Me.Panel2.Controls.Add(Me.txtLocationNow)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.txtFinishUser)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.txtCreaterUser)
        Me.Panel2.Controls.Add(Me.txtLendRemark)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txtTouchUser)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Location = New System.Drawing.Point(24, 195)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(959, 105)
        Me.Panel2.TabIndex = 140
        '
        'txtFinishTime
        '
        Me.txtFinishTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFinishTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFinishTime.Location = New System.Drawing.Point(568, 35)
        Me.txtFinishTime.MaxLength = 30
        Me.txtFinishTime.Name = "txtFinishTime"
        Me.txtFinishTime.Size = New System.Drawing.Size(121, 21)
        Me.txtFinishTime.TabIndex = 94
        '
        'lbReturnUser
        '
        Me.lbReturnUser.AutoSize = True
        Me.lbReturnUser.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbReturnUser.Location = New System.Drawing.Point(194, 44)
        Me.lbReturnUser.Name = "lbReturnUser"
        Me.lbReturnUser.Size = New System.Drawing.Size(0, 12)
        Me.lbReturnUser.TabIndex = 93
        '
        'lbCreaterUser
        '
        Me.lbCreaterUser.AutoSize = True
        Me.lbCreaterUser.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbCreaterUser.Location = New System.Drawing.Point(441, 44)
        Me.lbCreaterUser.Name = "lbCreaterUser"
        Me.lbCreaterUser.Size = New System.Drawing.Size(0, 12)
        Me.lbCreaterUser.TabIndex = 92
        '
        'lbTouchUser
        '
        Me.lbTouchUser.AutoSize = True
        Me.lbTouchUser.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbTouchUser.Location = New System.Drawing.Point(192, 16)
        Me.lbTouchUser.Name = "lbTouchUser"
        Me.lbTouchUser.Size = New System.Drawing.Size(0, 12)
        Me.lbTouchUser.TabIndex = 91
        '
        'txtLendStatus
        '
        Me.txtLendStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtLendStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLendStatus.Location = New System.Drawing.Point(568, 8)
        Me.txtLendStatus.MaxLength = 30
        Me.txtLendStatus.Name = "txtLendStatus"
        Me.txtLendStatus.Size = New System.Drawing.Size(121, 21)
        Me.txtLendStatus.TabIndex = 90
        '
        'txtLocationNow
        '
        Me.txtLocationNow.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtLocationNow.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocationNow.Location = New System.Drawing.Point(314, 12)
        Me.txtLocationNow.MaxLength = 30
        Me.txtLocationNow.Name = "txtLocationNow"
        Me.txtLocationNow.Size = New System.Drawing.Size(120, 21)
        Me.txtLocationNow.TabIndex = 89
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(508, 41)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 12)
        Me.Label25.TabIndex = 55
        Me.Label25.Text = "归还时间："
        '
        'txtFinishUser
        '
        Me.txtFinishUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFinishUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFinishUser.Location = New System.Drawing.Point(66, 41)
        Me.txtFinishUser.MaxLength = 30
        Me.txtFinishUser.Name = "txtFinishUser"
        Me.txtFinishUser.Size = New System.Drawing.Size(120, 21)
        Me.txtFinishUser.TabIndex = 36
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 44)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 12)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "归 还 人："
        '
        'txtCreaterUser
        '
        Me.txtCreaterUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCreaterUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreaterUser.Location = New System.Drawing.Point(313, 38)
        Me.txtCreaterUser.MaxLength = 30
        Me.txtCreaterUser.Name = "txtCreaterUser"
        Me.txtCreaterUser.Size = New System.Drawing.Size(121, 21)
        Me.txtCreaterUser.TabIndex = 60
        '
        'txtLendRemark
        '
        Me.txtLendRemark.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtLendRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLendRemark.Location = New System.Drawing.Point(66, 67)
        Me.txtLendRemark.MaxLength = 40
        Me.txtLendRemark.Name = "txtLendRemark"
        Me.txtLendRemark.Size = New System.Drawing.Size(890, 21)
        Me.txtLendRemark.TabIndex = 57
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(508, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "状    态："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "借出备注："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(256, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "操 作 人："
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(256, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 12)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "借 出 到："
        '
        'txtTouchUser
        '
        Me.txtTouchUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTouchUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTouchUser.Location = New System.Drawing.Point(66, 13)
        Me.txtTouchUser.MaxLength = 30
        Me.txtTouchUser.Name = "txtTouchUser"
        Me.txtTouchUser.Size = New System.Drawing.Size(120, 21)
        Me.txtTouchUser.TabIndex = 36
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 12)
        Me.Label20.TabIndex = 39
        Me.Label20.Text = "借 出 人："
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.lbCUser)
        Me.Panel3.Controls.Add(Me.lbCheck)
        Me.Panel3.Controls.Add(Me.txtCheckRemark)
        Me.Panel3.Controls.Add(Me.Label28)
        Me.Panel3.Controls.Add(Me.txtCheckCreateTime)
        Me.Panel3.Controls.Add(Me.txtCheckCreateUser)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.txtCheckStatus)
        Me.Panel3.Controls.Add(Me.txtCheckUser)
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.Label23)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Location = New System.Drawing.Point(24, 316)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(959, 85)
        Me.Panel3.TabIndex = 143
        '
        'lbCUser
        '
        Me.lbCUser.AutoSize = True
        Me.lbCUser.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbCUser.Location = New System.Drawing.Point(472, 10)
        Me.lbCUser.Name = "lbCUser"
        Me.lbCUser.Size = New System.Drawing.Size(0, 12)
        Me.lbCUser.TabIndex = 100
        '
        'lbCheck
        '
        Me.lbCheck.AutoSize = True
        Me.lbCheck.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbCheck.Location = New System.Drawing.Point(206, 11)
        Me.lbCheck.Name = "lbCheck"
        Me.lbCheck.Size = New System.Drawing.Size(0, 12)
        Me.lbCheck.TabIndex = 99
        '
        'txtCheckRemark
        '
        Me.txtCheckRemark.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckRemark.Location = New System.Drawing.Point(70, 38)
        Me.txtCheckRemark.MaxLength = 30
        Me.txtCheckRemark.Name = "txtCheckRemark"
        Me.txtCheckRemark.Size = New System.Drawing.Size(887, 21)
        Me.txtCheckRemark.TabIndex = 98
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 42)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(65, 12)
        Me.Label28.TabIndex = 97
        Me.Label28.Text = "校验备注："
        '
        'txtCheckCreateTime
        '
        Me.txtCheckCreateTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckCreateTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckCreateTime.Location = New System.Drawing.Point(835, 6)
        Me.txtCheckCreateTime.MaxLength = 30
        Me.txtCheckCreateTime.Name = "txtCheckCreateTime"
        Me.txtCheckCreateTime.Size = New System.Drawing.Size(121, 21)
        Me.txtCheckCreateTime.TabIndex = 96
        '
        'txtCheckCreateUser
        '
        Me.txtCheckCreateUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckCreateUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckCreateUser.Location = New System.Drawing.Point(348, 6)
        Me.txtCheckCreateUser.MaxLength = 30
        Me.txtCheckCreateUser.Name = "txtCheckCreateUser"
        Me.txtCheckCreateUser.Size = New System.Drawing.Size(121, 21)
        Me.txtCheckCreateUser.TabIndex = 95
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(289, 11)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 12)
        Me.Label26.TabIndex = 93
        Me.Label26.Text = "创 建 人："
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(778, 11)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 12)
        Me.Label27.TabIndex = 94
        Me.Label27.Text = "创建日期："
        '
        'txtCheckStatus
        '
        Me.txtCheckStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckStatus.Location = New System.Drawing.Point(602, 6)
        Me.txtCheckStatus.MaxLength = 30
        Me.txtCheckStatus.Name = "txtCheckStatus"
        Me.txtCheckStatus.Size = New System.Drawing.Size(121, 21)
        Me.txtCheckStatus.TabIndex = 92
        '
        'txtCheckUser
        '
        Me.txtCheckUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckUser.Location = New System.Drawing.Point(69, 7)
        Me.txtCheckUser.MaxLength = 30
        Me.txtCheckUser.Name = "txtCheckUser"
        Me.txtCheckUser.Size = New System.Drawing.Size(121, 21)
        Me.txtCheckUser.TabIndex = 91
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 11)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 12)
        Me.Label22.TabIndex = 88
        Me.Label22.Text = "校 验 人："
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(543, 11)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 12)
        Me.Label23.TabIndex = 90
        Me.Label23.Text = "校验状态："
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 71)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(0, 12)
        Me.Label21.TabIndex = 87
        '
        'EquipDetailInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 439)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.hidEquID)
        Me.Name = "EquipDetailInfo"
        Me.Text = "设备信息展示"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents hidEquID As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTouchUserS As System.Windows.Forms.TextBox
    Friend WithEvents txtVendCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtResponUser As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEquCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtCreaterUser As System.Windows.Forms.TextBox
    Friend WithEvents txtLendRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTouchUser As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtFinishUser As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents txtLocationNow As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckUser As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtCheckCreateTime As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckCreateUser As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtCheckStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCheckTime As System.Windows.Forms.TextBox
    Friend WithEvents txtNextCheckTime As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtLendStatus As System.Windows.Forms.TextBox
    Friend WithEvents lbUser As System.Windows.Forms.Label
    Friend WithEvents lbCreateUser As System.Windows.Forms.Label
    Friend WithEvents lbTouchUser As System.Windows.Forms.Label
    Friend WithEvents lbCUser As System.Windows.Forms.Label
    Friend WithEvents lbCheck As System.Windows.Forms.Label
    Friend WithEvents lbReturnUser As System.Windows.Forms.Label
    Friend WithEvents lbCreaterUser As System.Windows.Forms.Label
    Friend WithEvents txtStorage As System.Windows.Forms.TextBox
    Friend WithEvents txtJsNo As System.Windows.Forms.TextBox
    Friend WithEvents txtZcNo As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtCreateUser As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCreateTime As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lbLend As System.Windows.Forms.Label
    Friend WithEvents txtFinishTime As System.Windows.Forms.TextBox
End Class
