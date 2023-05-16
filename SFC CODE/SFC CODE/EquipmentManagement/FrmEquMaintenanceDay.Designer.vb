<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEquMaintenanceDay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEquMaintenanceDay))
        Me.tcMaintenanceDay = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.dgvMaintenanceEveryDay = New System.Windows.Forms.DataGridView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvMainanceRecord = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvMaintenanceEverDayUser = New System.Windows.Forms.DataGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtpMonths = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbMonths = New System.Windows.Forms.Label()
        Me.txtAssetNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAssetName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.dgvMaintenToDay = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.dtPickerCurrentDay = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAssetNameToDay = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSpecSave = New System.Windows.Forms.ToolStripButton()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcMaintenanceDay.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.dgvMaintenanceEveryDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvMainanceRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMaintenanceEverDayUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dgvMaintenToDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMaintenanceDay
        '
        Me.tcMaintenanceDay.Controls.Add(Me.TabPage1)
        Me.tcMaintenanceDay.Controls.Add(Me.TabPage2)
        Me.tcMaintenanceDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMaintenanceDay.Location = New System.Drawing.Point(0, 0)
        Me.tcMaintenanceDay.Name = "tcMaintenanceDay"
        Me.tcMaintenanceDay.SelectedIndex = 0
        Me.tcMaintenanceDay.Size = New System.Drawing.Size(1008, 611)
        Me.tcMaintenanceDay.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1000, 585)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "每日保养记录"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(994, 493)
        Me.Panel2.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Splitter1)
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(994, 369)
        Me.Panel4.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.dgvMaintenanceEveryDay)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(994, 173)
        Me.Panel8.TabIndex = 2
        '
        'dgvMaintenanceEveryDay
        '
        Me.dgvMaintenanceEveryDay.AllowUserToAddRows = False
        Me.dgvMaintenanceEveryDay.AllowUserToDeleteRows = False
        Me.dgvMaintenanceEveryDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaintenanceEveryDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaintenanceEveryDay.Location = New System.Drawing.Point(0, 0)
        Me.dgvMaintenanceEveryDay.Name = "dgvMaintenanceEveryDay"
        Me.dgvMaintenanceEveryDay.ReadOnly = True
        Me.dgvMaintenanceEveryDay.RowHeadersVisible = False
        Me.dgvMaintenanceEveryDay.RowTemplate.Height = 23
        Me.dgvMaintenanceEveryDay.Size = New System.Drawing.Size(994, 173)
        Me.dgvMaintenanceEveryDay.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 173)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(994, 3)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.GroupBox2)
        Me.Panel9.Controls.Add(Me.GroupBox1)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(0, 176)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(994, 193)
        Me.Panel9.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvMainanceRecord)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(257, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(737, 193)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "设备保养记录"
        '
        'dgvMainanceRecord
        '
        Me.dgvMainanceRecord.AllowUserToAddRows = False
        Me.dgvMainanceRecord.AllowUserToDeleteRows = False
        Me.dgvMainanceRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMainanceRecord.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgvMainanceRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMainanceRecord.Location = New System.Drawing.Point(3, 17)
        Me.dgvMainanceRecord.Name = "dgvMainanceRecord"
        Me.dgvMainanceRecord.ReadOnly = True
        Me.dgvMainanceRecord.RowHeadersVisible = False
        Me.dgvMainanceRecord.RowTemplate.Height = 23
        Me.dgvMainanceRecord.Size = New System.Drawing.Size(731, 173)
        Me.dgvMainanceRecord.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvMaintenanceEverDayUser)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 193)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "保养人签名"
        '
        'dgvMaintenanceEverDayUser
        '
        Me.dgvMaintenanceEverDayUser.AllowUserToAddRows = False
        Me.dgvMaintenanceEverDayUser.AllowUserToDeleteRows = False
        Me.dgvMaintenanceEverDayUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaintenanceEverDayUser.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column8})
        Me.dgvMaintenanceEverDayUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaintenanceEverDayUser.Location = New System.Drawing.Point(3, 17)
        Me.dgvMaintenanceEverDayUser.Name = "dgvMaintenanceEverDayUser"
        Me.dgvMaintenanceEverDayUser.ReadOnly = True
        Me.dgvMaintenanceEverDayUser.RowHeadersVisible = False
        Me.dgvMaintenanceEverDayUser.RowTemplate.Height = 23
        Me.dgvMaintenanceEverDayUser.Size = New System.Drawing.Size(251, 173)
        Me.dgvMaintenanceEverDayUser.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 369)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(994, 124)
        Me.Panel5.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(7, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(281, 12)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "注：""O"" 表示""OK"",""X""表示NG，""I"" 表示机台未使用"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(377, 12)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "4.工作使用之后，整理好各相关对象，关掉电源，保持机器整体清洁。"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(65, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(365, 12)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "3.生技人员自检OK后，需由现场IPQC当场确认，OK后方能投入使用。"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(66, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(365, 12)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "2.若有异常时，且自己无法排除时，应及时通知现场生技人员处理。"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(533, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "实施步骤：1.工作前，擦试机台表面，使之清洁美观，逐步落实规定内容，并认真准确填写相关项目"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(461, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "目的：通过切实执行各项保养项目并记录，保证人员安全，设备性能稳定，便于查证。"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(575, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "保养规范"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.dtpMonths)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.lbMonths)
        Me.Panel1.Controls.Add(Me.txtAssetNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtModel)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtAssetName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 86)
        Me.Panel1.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(807, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 12)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "月份:"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(918, 56)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(57, 23)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "查找"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dtpMonths
        '
        Me.dtpMonths.CustomFormat = "yyyy-MM"
        Me.dtpMonths.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMonths.Location = New System.Drawing.Point(843, 57)
        Me.dtpMonths.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
        Me.dtpMonths.Name = "dtpMonths"
        Me.dtpMonths.Size = New System.Drawing.Size(69, 21)
        Me.dtpMonths.TabIndex = 11
        Me.dtpMonths.Value = New Date(2017, 1, 1, 0, 0, 0, 0)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label15.Location = New System.Drawing.Point(508, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 14)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "月份:"
        '
        'lbMonths
        '
        Me.lbMonths.AutoSize = True
        Me.lbMonths.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbMonths.ForeColor = System.Drawing.Color.Blue
        Me.lbMonths.Location = New System.Drawing.Point(557, 34)
        Me.lbMonths.Name = "lbMonths"
        Me.lbMonths.Size = New System.Drawing.Size(71, 16)
        Me.lbMonths.TabIndex = 9
        Me.lbMonths.Text = "2016-12"
        '
        'txtAssetNo
        '
        Me.txtAssetNo.Location = New System.Drawing.Point(645, 59)
        Me.txtAssetNo.Name = "txtAssetNo"
        Me.txtAssetNo.ReadOnly = True
        Me.txtAssetNo.Size = New System.Drawing.Size(123, 21)
        Me.txtAssetNo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(558, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "设备资产编码:"
        '
        'txtModel
        '
        Me.txtModel.Location = New System.Drawing.Point(306, 59)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.ReadOnly = True
        Me.txtModel.Size = New System.Drawing.Size(233, 21)
        Me.txtModel.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(264, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "型号:"
        '
        'txtAssetName
        '
        Me.txtAssetName.Location = New System.Drawing.Point(66, 59)
        Me.txtAssetName.Name = "txtAssetName"
        Me.txtAssetName.ReadOnly = True
        Me.txtAssetName.Size = New System.Drawing.Size(174, 21)
        Me.txtAssetName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "设备名称:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(463, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "每日保养记录表"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1000, 585)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "当日设备保养"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.ToolBt)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(994, 579)
        Me.Panel3.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.dgvMaintenToDay)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 23)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(994, 556)
        Me.Panel6.TabIndex = 52
        '
        'dgvMaintenToDay
        '
        Me.dgvMaintenToDay.AllowUserToAddRows = False
        Me.dgvMaintenToDay.AllowUserToDeleteRows = False
        Me.dgvMaintenToDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaintenToDay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column9})
        Me.dgvMaintenToDay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaintenToDay.Location = New System.Drawing.Point(0, 76)
        Me.dgvMaintenToDay.Name = "dgvMaintenToDay"
        Me.dgvMaintenToDay.RowHeadersVisible = False
        Me.dgvMaintenToDay.RowTemplate.Height = 23
        Me.dgvMaintenToDay.Size = New System.Drawing.Size(994, 480)
        Me.dgvMaintenToDay.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "idx"
        Me.Column1.HeaderText = "序号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "AssetName"
        Me.Column2.HeaderText = "设备名称"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "MaintenanceProject"
        Me.Column3.HeaderText = "保养项目"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 300
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "IsOk"
        Me.Column4.HeaderText = "是否OK"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "IsNg"
        Me.Column5.HeaderText = "是否NG"
        Me.Column5.Name = "Column5"
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.Width = 70
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "IsNotUsed"
        Me.Column6.HeaderText = "是否未使用"
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column9.DataPropertyName = "Remark"
        Me.Column9.HeaderText = "备注"
        Me.Column9.Name = "Column9"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel7.Controls.Add(Me.dtPickerCurrentDay)
        Me.Panel7.Controls.Add(Me.Label16)
        Me.Panel7.Controls.Add(Me.lbMsg)
        Me.Panel7.Controls.Add(Me.Label13)
        Me.Panel7.Controls.Add(Me.txtAssetNameToDay)
        Me.Panel7.Controls.Add(Me.Label12)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(994, 76)
        Me.Panel7.TabIndex = 1
        '
        'dtPickerCurrentDay
        '
        Me.dtPickerCurrentDay.CustomFormat = "yy-MM-dd"
        Me.dtPickerCurrentDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickerCurrentDay.Location = New System.Drawing.Point(70, 11)
        Me.dtPickerCurrentDay.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
        Me.dtPickerCurrentDay.Name = "dtPickerCurrentDay"
        Me.dtPickerCurrentDay.Size = New System.Drawing.Size(106, 21)
        Me.dtPickerCurrentDay.TabIndex = 12
        Me.dtPickerCurrentDay.Value = New Date(2017, 1, 1, 0, 0, 0, 0)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(5, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 12)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "保养日期:"
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbMsg.ForeColor = System.Drawing.Color.Red
        Me.lbMsg.Location = New System.Drawing.Point(389, 17)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(0, 12)
        Me.lbMsg.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(383, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 12)
        Me.Label13.TabIndex = 5
        '
        'txtAssetNameToDay
        '
        Me.txtAssetNameToDay.Location = New System.Drawing.Point(70, 44)
        Me.txtAssetNameToDay.Name = "txtAssetNameToDay"
        Me.txtAssetNameToDay.ReadOnly = True
        Me.txtAssetNameToDay.Size = New System.Drawing.Size(257, 21)
        Me.txtAssetNameToDay.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "设备名称:"
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator3, Me.btnSpecSave, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(994, 23)
        Me.ToolBt.TabIndex = 51
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(71, 20)
        Me.btnSave.Text = "保 存(&S)"
        Me.btnSave.ToolTipText = "保存"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnSpecSave
        '
        Me.btnSpecSave.Image = CType(resources.GetObject("btnSpecSave.Image"), System.Drawing.Image)
        Me.btnSpecSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSpecSave.Name = "btnSpecSave"
        Me.btnSpecSave.Size = New System.Drawing.Size(103, 20)
        Me.btnSpecSave.Text = "非当日保存(&S)"
        Me.btnSpecSave.ToolTipText = "保存"
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 20)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "Maintenancetime"
        Me.Column7.HeaderText = "保养日期"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "UserName"
        Me.Column8.HeaderText = "保养人签名"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 150
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "MaintenanceProject"
        Me.DataGridViewTextBoxColumn1.HeaderText = "保养项目"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Status"
        Me.DataGridViewTextBoxColumn2.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Maintenancetime"
        Me.DataGridViewTextBoxColumn3.HeaderText = "保养日期"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "UserName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "保养人"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Remark"
        Me.DataGridViewTextBoxColumn5.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'FrmEquMaintenanceDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 611)
        Me.Controls.Add(Me.tcMaintenanceDay)
        Me.Name = "FrmEquMaintenanceDay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "设备日保养(MJ)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tcMaintenanceDay.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.dgvMaintenanceEveryDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvMainanceRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvMaintenanceEverDayUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.dgvMaintenToDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcMaintenanceDay As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAssetNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtModel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAssetName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvMaintenanceEveryDay As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents dgvMaintenToDay As System.Windows.Forms.DataGridView
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents dgvMaintenanceEverDayUser As System.Windows.Forms.DataGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lbMsg As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAssetNameToDay As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMainanceRecord As System.Windows.Forms.DataGridView
    Friend WithEvents lbMonths As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpMonths As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtPickerCurrentDay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnSpecSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
