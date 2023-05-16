<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipmentInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipmentInfo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.TxtVendCode = New System.Windows.Forms.TextBox()
        Me.ComType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMachine_Format = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtZcNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtJsNo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComCheckInterval = New System.Windows.Forms.ComboBox()
        Me.txtStorage = New System.Windows.Forms.TextBox()
        Me.txtResponUser = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCreateUser = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpCheckDate = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEquCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQueryMO = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolLend = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolErpCheck = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolCheck = New System.Windows.Forms.ToolStripButton()
        Me.GridList = New System.Windows.Forms.DataGridView()
        Me.Machine_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JsNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZcNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Machine_Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Machine_Format = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Storage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckInterval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NextCheckTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ResponUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TouchUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CREATEDATETIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FactoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Profitcenter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Labelcount = New System.Windows.Forms.ToolStripLabel()
        Me.TlelCount = New System.Windows.Forms.ToolStripLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.label23 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        CType(Me.GridList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExitFrom
        '
        Me.ExitFrom.Image = CType(resources.GetObject("ExitFrom.Image"), System.Drawing.Image)
        Me.ExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ExitFrom.Name = "ExitFrom"
        Me.ExitFrom.Size = New System.Drawing.Size(68, 22)
        Me.ExitFrom.Text = "退出(&X)"
        Me.ExitFrom.ToolTipText = "退出"
        '
        'TxtVendCode
        '
        Me.TxtVendCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtVendCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVendCode.Location = New System.Drawing.Point(817, 31)
        Me.TxtVendCode.MaxLength = 10
        Me.TxtVendCode.Name = "TxtVendCode"
        Me.TxtVendCode.Size = New System.Drawing.Size(142, 21)
        Me.TxtVendCode.TabIndex = 54
        '
        'ComType
        '
        Me.ComType.FormattingEnabled = True
        Me.ComType.Location = New System.Drawing.Point(568, 6)
        Me.ComType.Name = "ComType"
        Me.ComType.Size = New System.Drawing.Size(142, 20)
        Me.ComType.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(754, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "创 建 人："
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 77
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 53
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "工单编号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 77
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "客户代码"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "工单状态"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Width = 77
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "工单数量"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 77
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "工单类型"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 77
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(511, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "设备类型："
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.cmbStatus)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtMachine_Format)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtZcNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtJsNo)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.ComCheckInterval)
        Me.Panel1.Controls.Add(Me.txtStorage)
        Me.Panel1.Controls.Add(Me.txtResponUser)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtCreateUser)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.dtpCheckDate)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtRemark)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.TxtVendCode)
        Me.Panel1.Controls.Add(Me.ComType)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtEquCode)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(0, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1226, 121)
        Me.Panel1.TabIndex = 131
        '
        'cmbStatus
        '
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Location = New System.Drawing.Point(816, 6)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(142, 20)
        Me.cmbStatus.TabIndex = 88
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(754, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "设备状态："
        '
        'txtMachine_Format
        '
        Me.txtMachine_Format.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtMachine_Format.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMachine_Format.Location = New System.Drawing.Point(305, 61)
        Me.txtMachine_Format.MaxLength = 25
        Me.txtMachine_Format.Name = "txtMachine_Format"
        Me.txtMachine_Format.Size = New System.Drawing.Size(121, 21)
        Me.txtMachine_Format.TabIndex = 87
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(245, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "规格型号："
        '
        'txtZcNo
        '
        Me.txtZcNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtZcNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZcNo.Location = New System.Drawing.Point(66, 58)
        Me.txtZcNo.MaxLength = 25
        Me.txtZcNo.Name = "txtZcNo"
        Me.txtZcNo.Size = New System.Drawing.Size(121, 21)
        Me.txtZcNo.TabIndex = 84
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "资产编号："
        '
        'txtJsNo
        '
        Me.txtJsNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtJsNo.Location = New System.Drawing.Point(65, 34)
        Me.txtJsNo.MaxLength = 30
        Me.txtJsNo.Name = "txtJsNo"
        Me.txtJsNo.Size = New System.Drawing.Size(121, 21)
        Me.txtJsNo.TabIndex = 82
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 81
        Me.Label10.Text = "机 申 号："
        '
        'ComCheckInterval
        '
        Me.ComCheckInterval.FormattingEnabled = True
        Me.ComCheckInterval.Location = New System.Drawing.Point(305, 34)
        Me.ComCheckInterval.MaxLength = 30
        Me.ComCheckInterval.Name = "ComCheckInterval"
        Me.ComCheckInterval.Size = New System.Drawing.Size(121, 20)
        Me.ComCheckInterval.TabIndex = 80
        '
        'txtStorage
        '
        Me.txtStorage.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtStorage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStorage.Location = New System.Drawing.Point(568, 60)
        Me.txtStorage.MaxLength = 25
        Me.txtStorage.Name = "txtStorage"
        Me.txtStorage.Size = New System.Drawing.Size(142, 21)
        Me.txtStorage.TabIndex = 79
        '
        'txtResponUser
        '
        Me.txtResponUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtResponUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtResponUser.Location = New System.Drawing.Point(568, 34)
        Me.txtResponUser.MaxLength = 25
        Me.txtResponUser.Name = "txtResponUser"
        Me.txtResponUser.Size = New System.Drawing.Size(142, 21)
        Me.txtResponUser.TabIndex = 77
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(508, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "负 责 人："
        '
        'txtCreateUser
        '
        Me.txtCreateUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCreateUser.Location = New System.Drawing.Point(817, 57)
        Me.txtCreateUser.MaxLength = 30
        Me.txtCreateUser.Name = "txtCreateUser"
        Me.txtCreateUser.Size = New System.Drawing.Size(141, 21)
        Me.txtCreateUser.TabIndex = 74
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(221, 37)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 12)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "校验间隔(年)："
        '
        'dtpCheckDate
        '
        Me.dtpCheckDate.Checked = False
        Me.dtpCheckDate.CustomFormat = "yyyy/MM/dd"
        Me.dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCheckDate.Location = New System.Drawing.Point(305, 6)
        Me.dtpCheckDate.Name = "dtpCheckDate"
        Me.dtpCheckDate.ShowCheckBox = True
        Me.dtpCheckDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpCheckDate.TabIndex = 68
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(245, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "校验日期："
        '
        'txtRemark
        '
        Me.txtRemark.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Location = New System.Drawing.Point(66, 92)
        Me.txtRemark.MaxLength = 25
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(892, 21)
        Me.txtRemark.TabIndex = 66
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "备    注："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(506, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "储    位："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(742, 37)
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
        Me.Label8.Location = New System.Drawing.Point(6, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "设备编号："
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolStripSeparator6, Me.ToolEdit, Me.ToolStripSeparator8, Me.ToolDelete, Me.ToolStripSeparator10, Me.ToolSave, Me.ToolCancel, Me.ToolStripSeparator2, Me.ToolQueryMO, Me.ToolStripSeparator1, Me.toolRefresh, Me.ToolStripSeparator5, Me.ToolLend, Me.ToolStripSeparator3, Me.ToolErpCheck, Me.ToolStripSeparator7, Me.ToolCheck, Me.ExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 2)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1226, 25)
        Me.ToolBt.TabIndex = 128
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(70, 22)
        Me.ToolNew.Text = "新增(&N)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolEdit
        '
        Me.ToolEdit.Image = CType(resources.GetObject("ToolEdit.Image"), System.Drawing.Image)
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(71, 22)
        Me.ToolEdit.Tag = "NO"
        Me.ToolEdit.Text = "修 改(&E)"
        Me.ToolEdit.ToolTipText = "修 改"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolDelete
        '
        Me.ToolDelete.Image = CType(resources.GetObject("ToolDelete.Image"), System.Drawing.Image)
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(52, 22)
        Me.ToolDelete.Text = "报废"
        Me.ToolDelete.ToolTipText = "报废"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolSave
        '
        Me.ToolSave.Image = CType(resources.GetObject("ToolSave.Image"), System.Drawing.Image)
        Me.ToolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSave.Name = "ToolSave"
        Me.ToolSave.Size = New System.Drawing.Size(67, 22)
        Me.ToolSave.Text = "保存(&S)"
        Me.ToolSave.ToolTipText = "保存"
        '
        'ToolCancel
        '
        Me.ToolCancel.Image = CType(resources.GetObject("ToolCancel.Image"), System.Drawing.Image)
        Me.ToolCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCancel.Name = "ToolCancel"
        Me.ToolCancel.Size = New System.Drawing.Size(68, 22)
        Me.ToolCancel.Text = "返回(&C)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolQueryMO
        '
        Me.ToolQueryMO.Image = CType(resources.GetObject("ToolQueryMO.Image"), System.Drawing.Image)
        Me.ToolQueryMO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQueryMO.Name = "ToolQueryMO"
        Me.ToolQueryMO.Size = New System.Drawing.Size(66, 22)
        Me.ToolQueryMO.Text = "查询(&F)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefresh
        '
        Me.toolRefresh.Image = CType(resources.GetObject("toolRefresh.Image"), System.Drawing.Image)
        Me.toolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolRefresh.Name = "toolRefresh"
        Me.toolRefresh.Size = New System.Drawing.Size(72, 22)
        Me.toolRefresh.Text = "刷 新(&R)"
        Me.toolRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolLend
        '
        Me.ToolLend.Image = CType(resources.GetObject("ToolLend.Image"), System.Drawing.Image)
        Me.ToolLend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLend.Name = "ToolLend"
        Me.ToolLend.Size = New System.Drawing.Size(108, 22)
        Me.ToolLend.Tag = "NO"
        Me.ToolLend.Text = "借出/归还(&L/R)"
        Me.ToolLend.ToolTipText = "借出/归还"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolErpCheck
        '
        Me.ToolErpCheck.Image = CType(resources.GetObject("ToolErpCheck.Image"), System.Drawing.Image)
        Me.ToolErpCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolErpCheck.Name = "ToolErpCheck"
        Me.ToolErpCheck.Size = New System.Drawing.Size(126, 22)
        Me.ToolErpCheck.Text = "TITOP校验下载(&T)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolCheck
        '
        Me.ToolCheck.Image = CType(resources.GetObject("ToolCheck.Image"), System.Drawing.Image)
        Me.ToolCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCheck.Name = "ToolCheck"
        Me.ToolCheck.Size = New System.Drawing.Size(65, 22)
        Me.ToolCheck.Text = "校验(&J)"
        Me.ToolCheck.Visible = False
        '
        'GridList
        '
        Me.GridList.AllowUserToAddRows = False
        Me.GridList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.GridList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GridList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridList.BackgroundColor = System.Drawing.Color.White
        Me.GridList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.GridList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GridList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Machine_Code, Me.JsNo, Me.ZcNo, Me.Machine_Type, Me.Machine_Format, Me.Storage, Me.Status, Me.CheckTime, Me.CheckInterval, Me.NextCheckTime, Me.ResponUser, Me.TouchUser, Me.LineName, Me.VendCode, Me.Remark, Me.CREATEDATETIME, Me.FactoryName, Me.Profitcenter})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridList.DefaultCellStyle = DataGridViewCellStyle3
        Me.GridList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.GridList.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GridList.Location = New System.Drawing.Point(0, 169)
        Me.GridList.MultiSelect = False
        Me.GridList.Name = "GridList"
        Me.GridList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridList.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GridList.RowHeadersWidth = 4
        Me.GridList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GridList.RowTemplate.Height = 24
        Me.GridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridList.ShowEditingIcon = False
        Me.GridList.Size = New System.Drawing.Size(1226, 344)
        Me.GridList.TabIndex = 129
        Me.GridList.TabStop = False
        '
        'Machine_Code
        '
        Me.Machine_Code.HeaderText = "设备编号"
        Me.Machine_Code.Name = "Machine_Code"
        Me.Machine_Code.ReadOnly = True
        Me.Machine_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'JsNo
        '
        Me.JsNo.HeaderText = "机申号"
        Me.JsNo.Name = "JsNo"
        Me.JsNo.ReadOnly = True
        Me.JsNo.Width = 80
        '
        'ZcNo
        '
        Me.ZcNo.HeaderText = "资产编号"
        Me.ZcNo.Name = "ZcNo"
        Me.ZcNo.ReadOnly = True
        Me.ZcNo.Width = 80
        '
        'Machine_Type
        '
        Me.Machine_Type.HeaderText = "设备类型"
        Me.Machine_Type.Name = "Machine_Type"
        Me.Machine_Type.ReadOnly = True
        Me.Machine_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Machine_Format
        '
        Me.Machine_Format.HeaderText = "设备规格"
        Me.Machine_Format.Name = "Machine_Format"
        Me.Machine_Format.ReadOnly = True
        Me.Machine_Format.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Machine_Format.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Machine_Format.Width = 85
        '
        'Storage
        '
        Me.Storage.HeaderText = "储位"
        Me.Storage.Name = "Storage"
        Me.Storage.ReadOnly = True
        Me.Storage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Storage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Storage.Width = 80
        '
        'Status
        '
        Me.Status.HeaderText = "设备状态"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Status.Width = 77
        '
        'CheckTime
        '
        Me.CheckTime.HeaderText = "本次校验日期"
        Me.CheckTime.Name = "CheckTime"
        Me.CheckTime.ReadOnly = True
        Me.CheckTime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CheckTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CheckInterval
        '
        Me.CheckInterval.HeaderText = "检验间隔"
        Me.CheckInterval.Name = "CheckInterval"
        Me.CheckInterval.ReadOnly = True
        Me.CheckInterval.Width = 80
        '
        'NextCheckTime
        '
        Me.NextCheckTime.HeaderText = "下次校验日期"
        Me.NextCheckTime.Name = "NextCheckTime"
        Me.NextCheckTime.ReadOnly = True
        Me.NextCheckTime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ResponUser
        '
        Me.ResponUser.HeaderText = "负责人"
        Me.ResponUser.Name = "ResponUser"
        Me.ResponUser.ReadOnly = True
        Me.ResponUser.Width = 70
        '
        'TouchUser
        '
        Me.TouchUser.HeaderText = "借出人"
        Me.TouchUser.Name = "TouchUser"
        Me.TouchUser.ReadOnly = True
        Me.TouchUser.Width = 70
        '
        'LineName
        '
        Me.LineName.HeaderText = "设备位置"
        Me.LineName.Name = "LineName"
        Me.LineName.ReadOnly = True
        '
        'VendCode
        '
        Me.VendCode.HeaderText = "供应商代码"
        Me.VendCode.Name = "VendCode"
        Me.VendCode.ReadOnly = True
        Me.VendCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Remark
        '
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 70
        '
        'CREATEDATETIME
        '
        Me.CREATEDATETIME.HeaderText = "创建时间"
        Me.CREATEDATETIME.Name = "CREATEDATETIME"
        '
        'FactoryName
        '
        Me.FactoryName.HeaderText = "厂区"
        Me.FactoryName.Name = "FactoryName"
        Me.FactoryName.Width = 60
        '
        'Profitcenter
        '
        Me.Profitcenter.HeaderText = "利润中心"
        Me.Profitcenter.Name = "Profitcenter"
        Me.Profitcenter.Width = 70
        '
        'Labelcount
        '
        Me.Labelcount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Labelcount.Name = "Labelcount"
        Me.Labelcount.Size = New System.Drawing.Size(0, 17)
        '
        'TlelCount
        '
        Me.TlelCount.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TlelCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TlelCount.Name = "TlelCount"
        Me.TlelCount.Size = New System.Drawing.Size(15, 17)
        Me.TlelCount.Text = "0"
        '
        'ToolLblCount
        '
        Me.ToolLblCount.ForeColor = System.Drawing.Color.Black
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(59, 17)
        Me.ToolLblCount.Text = "记录笔数:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.ToolLblCount, Me.Labelcount, Me.TlelCount})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 516)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1226, 20)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 130
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 20)
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "工单状态"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 77
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label23.Location = New System.Drawing.Point(25, 154)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(593, 12)
        Me.label23.TabIndex = 88
        Me.label23.Text = "设备各种状态表示颜色【0:未校】白色 【1:正常】白色 【2:停用】深青色 【3.退修】粉红色 【4.报废】红色"
        '
        'EquipmentInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1226, 536)
        Me.Controls.Add(Me.label23)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.GridList)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "EquipmentInfo"
        Me.Text = "设备基础信息"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.GridList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtVendCode As System.Windows.Forms.TextBox
    Friend WithEvents ComType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEquCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQueryMO As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridList As System.Windows.Forms.DataGridView
    Friend WithEvents Labelcount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TlelCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpCheckDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolLend As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCreateUser As System.Windows.Forms.TextBox
    Friend WithEvents txtResponUser As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ComCheckInterval As System.Windows.Forms.ComboBox
    Friend WithEvents txtStorage As System.Windows.Forms.TextBox
    Friend WithEvents txtZcNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtJsNo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolErpCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtMachine_Format As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents toolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Machine_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JsNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZcNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Machine_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Machine_Format As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Storage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckInterval As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NextCheckTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ResponUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TouchUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATEDATETIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FactoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Profitcenter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents label23 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
