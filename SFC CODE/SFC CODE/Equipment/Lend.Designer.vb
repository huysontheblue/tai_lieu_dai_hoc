<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lend
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lend))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtZcNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtJsNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbResponUser = New System.Windows.Forms.Label()
        Me.txtResponUser = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtStorage = New System.Windows.Forms.TextBox()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtVendCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEquCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTouchUser = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComStatus = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtLineName = New System.Windows.Forms.TextBox()
        Me.lbLendFullName = New System.Windows.Forms.Label()
        Me.dtpOperateTime = New System.Windows.Forms.DateTimePicker()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnCancal = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.hidEquID = New System.Windows.Forms.TextBox()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbFullName = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFinishTime = New System.Windows.Forms.DateTimePicker()
        Me.txtFinishUser = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolLend = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolReturn = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.txtZcNo)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtJsNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lbResponUser)
        Me.Panel1.Controls.Add(Me.txtResponUser)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtStorage)
        Me.Panel1.Controls.Add(Me.txtType)
        Me.Panel1.Controls.Add(Me.txtStatus)
        Me.Panel1.Controls.Add(Me.txtTitle)
        Me.Panel1.Controls.Add(Me.txtVendCode)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtEquCode)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(24, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(759, 114)
        Me.Panel1.TabIndex = 136
        '
        'txtZcNo
        '
        Me.txtZcNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtZcNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZcNo.Location = New System.Drawing.Point(582, 8)
        Me.txtZcNo.MaxLength = 30
        Me.txtZcNo.Name = "txtZcNo"
        Me.txtZcNo.Size = New System.Drawing.Size(114, 21)
        Me.txtZcNo.TabIndex = 84
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(519, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "资产编号："
        '
        'txtJsNo
        '
        Me.txtJsNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtJsNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtJsNo.Location = New System.Drawing.Point(313, 8)
        Me.txtJsNo.MaxLength = 30
        Me.txtJsNo.Name = "txtJsNo"
        Me.txtJsNo.Size = New System.Drawing.Size(121, 21)
        Me.txtJsNo.TabIndex = 82
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(256, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "机 申 号："
        '
        'lbResponUser
        '
        Me.lbResponUser.AutoSize = True
        Me.lbResponUser.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbResponUser.Location = New System.Drawing.Point(696, 43)
        Me.lbResponUser.Name = "lbResponUser"
        Me.lbResponUser.Size = New System.Drawing.Size(0, 12)
        Me.lbResponUser.TabIndex = 80
        '
        'txtResponUser
        '
        Me.txtResponUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtResponUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtResponUser.Location = New System.Drawing.Point(582, 67)
        Me.txtResponUser.MaxLength = 30
        Me.txtResponUser.Name = "txtResponUser"
        Me.txtResponUser.Size = New System.Drawing.Size(114, 21)
        Me.txtResponUser.TabIndex = 79
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(519, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "负 责 人："
        '
        'txtStorage
        '
        Me.txtStorage.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStorage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStorage.Location = New System.Drawing.Point(66, 66)
        Me.txtStorage.MaxLength = 25
        Me.txtStorage.Name = "txtStorage"
        Me.txtStorage.Size = New System.Drawing.Size(121, 21)
        Me.txtStorage.TabIndex = 77
        '
        'txtType
        '
        Me.txtType.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtType.Location = New System.Drawing.Point(582, 40)
        Me.txtType.MaxLength = 30
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(114, 21)
        Me.txtType.TabIndex = 76
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStatus.Location = New System.Drawing.Point(313, 38)
        Me.txtStatus.MaxLength = 30
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(121, 21)
        Me.txtStatus.TabIndex = 75
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTitle.Location = New System.Drawing.Point(65, 38)
        Me.txtTitle.MaxLength = 30
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(121, 21)
        Me.txtTitle.TabIndex = 73
        '
        'txtVendCode
        '
        Me.txtVendCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtVendCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendCode.Location = New System.Drawing.Point(313, 66)
        Me.txtVendCode.MaxLength = 10
        Me.txtVendCode.Name = "txtVendCode"
        Me.txtVendCode.Size = New System.Drawing.Size(121, 21)
        Me.txtVendCode.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(519, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "设备类型："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(256, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "状    态："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "储    位："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "设备名称："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(244, 70)
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 77)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "备    注："
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(256, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 12)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "借出线别："
        '
        'txtTouchUser
        '
        Me.txtTouchUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTouchUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTouchUser.Location = New System.Drawing.Point(66, 13)
        Me.txtTouchUser.MaxLength = 30
        Me.txtTouchUser.Name = "txtTouchUser"
        Me.txtTouchUser.Size = New System.Drawing.Size(112, 21)
        Me.txtTouchUser.TabIndex = 0
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "状    态："
        '
        'ComStatus
        '
        Me.ComStatus.FormattingEnabled = True
        Me.ComStatus.Location = New System.Drawing.Point(65, 42)
        Me.ComStatus.Name = "ComStatus"
        Me.ComStatus.Size = New System.Drawing.Size(113, 20)
        Me.ComStatus.TabIndex = 52
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtLineName)
        Me.Panel2.Controls.Add(Me.lbLendFullName)
        Me.Panel2.Controls.Add(Me.dtpOperateTime)
        Me.Panel2.Controls.Add(Me.txtRemark)
        Me.Panel2.Controls.Add(Me.ComStatus)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.txtTouchUser)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Location = New System.Drawing.Point(24, 171)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(759, 105)
        Me.Panel2.TabIndex = 139
        '
        'txtLineName
        '
        Me.txtLineName.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtLineName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineName.Location = New System.Drawing.Point(313, 13)
        Me.txtLineName.MaxLength = 30
        Me.txtLineName.Name = "txtLineName"
        Me.txtLineName.Size = New System.Drawing.Size(142, 21)
        Me.txtLineName.TabIndex = 1
        '
        'lbLendFullName
        '
        Me.lbLendFullName.AutoSize = True
        Me.lbLendFullName.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbLendFullName.Location = New System.Drawing.Point(187, 18)
        Me.lbLendFullName.Name = "lbLendFullName"
        Me.lbLendFullName.Size = New System.Drawing.Size(0, 12)
        Me.lbLendFullName.TabIndex = 89
        '
        'dtpOperateTime
        '
        Me.dtpOperateTime.Checked = False
        Me.dtpOperateTime.CustomFormat = "yyyy/MM/dd"
        Me.dtpOperateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOperateTime.Location = New System.Drawing.Point(313, 39)
        Me.dtpOperateTime.Name = "dtpOperateTime"
        Me.dtpOperateTime.ShowCheckBox = True
        Me.dtpOperateTime.Size = New System.Drawing.Size(142, 21)
        Me.dtpOperateTime.TabIndex = 2
        '
        'txtRemark
        '
        Me.txtRemark.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(66, 74)
        Me.txtRemark.MaxLength = 40
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(645, 21)
        Me.txtRemark.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(256, 45)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 12)
        Me.Label22.TabIndex = 55
        Me.Label22.Text = "操作时间："
        '
        'btnCancal
        '
        Me.btnCancal.Location = New System.Drawing.Point(496, 354)
        Me.btnCancal.Name = "btnCancal"
        Me.btnCancal.Size = New System.Drawing.Size(75, 23)
        Me.btnCancal.TabIndex = 1
        Me.btnCancal.Text = "取 消"
        Me.btnCancal.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(218, 354)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "提 交"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'hidEquID
        '
        Me.hidEquID.Location = New System.Drawing.Point(32, 146)
        Me.hidEquID.Name = "hidEquID"
        Me.hidEquID.Size = New System.Drawing.Size(100, 21)
        Me.hidEquID.TabIndex = 140
        Me.hidEquID.Visible = False
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("Microsoft JhengHei", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(267, 140)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(148, 18)
        Me.LblMsg.TabIndex = 141
        Me.LblMsg.Text = "该设备您已借出！！！"
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.lbFullName)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txtFinishTime)
        Me.Panel3.Controls.Add(Me.txtFinishUser)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Panel3.Location = New System.Drawing.Point(24, 290)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(759, 55)
        Me.Panel3.TabIndex = 142
        Me.Panel3.Visible = False
        '
        'lbFullName
        '
        Me.lbFullName.AutoSize = True
        Me.lbFullName.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbFullName.Location = New System.Drawing.Point(222, 22)
        Me.lbFullName.Name = "lbFullName"
        Me.lbFullName.Size = New System.Drawing.Size(0, 12)
        Me.lbFullName.TabIndex = 88
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(0, 12)
        Me.Label14.TabIndex = 87
        '
        'txtFinishTime
        '
        Me.txtFinishTime.CustomFormat = "yyyy/MM/dd"
        Me.txtFinishTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFinishTime.Location = New System.Drawing.Point(313, 16)
        Me.txtFinishTime.Name = "txtFinishTime"
        Me.txtFinishTime.ShowCheckBox = True
        Me.txtFinishTime.Size = New System.Drawing.Size(142, 21)
        Me.txtFinishTime.TabIndex = 1
        Me.txtFinishTime.Value = New Date(2015, 6, 8, 0, 0, 0, 0)
        '
        'txtFinishUser
        '
        Me.txtFinishUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFinishUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFinishUser.Location = New System.Drawing.Point(66, 16)
        Me.txtFinishUser.MaxLength = 30
        Me.txtFinishUser.Name = "txtFinishUser"
        Me.txtFinishUser.Size = New System.Drawing.Size(121, 21)
        Me.txtFinishUser.TabIndex = 0
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 22)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 12)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "归 还 人："
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(256, 22)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 12)
        Me.Label25.TabIndex = 55
        Me.Label25.Text = "归还时间："
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolLend, Me.ToolStripSeparator6, Me.ToolReturn})
        Me.ToolBt.Location = New System.Drawing.Point(1, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(796, 28)
        Me.ToolBt.TabIndex = 144
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolLend
        '
        Me.ToolLend.Image = CType(resources.GetObject("ToolLend.Image"), System.Drawing.Image)
        Me.ToolLend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLend.Name = "ToolLend"
        Me.ToolLend.Size = New System.Drawing.Size(66, 25)
        Me.ToolLend.Text = "借出(&L)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 28)
        '
        'ToolReturn
        '
        Me.ToolReturn.Image = CType(resources.GetObject("ToolReturn.Image"), System.Drawing.Image)
        Me.ToolReturn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReturn.Name = "ToolReturn"
        Me.ToolReturn.Size = New System.Drawing.Size(68, 25)
        Me.ToolReturn.Text = "归还(&R)"
        '
        'Lend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 389)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.hidEquID)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnCancal)
        Me.Controls.Add(Me.btnSave)
        Me.MaximizeBox = False
        Me.Name = "Lend"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "借出/归还"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtVendCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEquCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTouchUser As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtpOperateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnCancal As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtStorage As System.Windows.Forms.TextBox
    Friend WithEvents hidEquID As System.Windows.Forms.TextBox
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFinishTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFinishUser As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolLend As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolReturn As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbFullName As System.Windows.Forms.Label
    Friend WithEvents lbLendFullName As System.Windows.Forms.Label
    Friend WithEvents txtResponUser As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbResponUser As System.Windows.Forms.Label
    Friend WithEvents txtZcNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtJsNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLineName As System.Windows.Forms.TextBox
End Class
