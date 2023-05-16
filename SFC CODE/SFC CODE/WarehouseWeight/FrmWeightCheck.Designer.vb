<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWeightCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWeightCheck))
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolUsename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TxtHWCartonID = New ULControls.textBoxUL()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnENT = New System.Windows.Forms.Button()
        Me.btPause = New System.Windows.Forms.Button()
        Me.txtOutputWeight = New System.Windows.Forms.TextBox()
        Me.LblCheckedQty = New System.Windows.Forms.Label()
        Me.LblShouldCheckQty = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DGridBarCode = New System.Windows.Forms.DataGridView()
        Me.toolCOMSetting = New System.Windows.Forms.ToolStripButton()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.LabResult = New System.Windows.Forms.Label()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.cobBardRate = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCOMNo = New System.Windows.Forms.ComboBox()
        Me.TxtLineId = New System.Windows.Forms.Label()
        Me.TxtSitName = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.Label()
        Me.Txt = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblBarName = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtStdMaxWeight = New ULControls.textBoxUL()
        Me.TxtSheetNo = New ULControls.textBoxUL()
        Me.TxtStdMinWeight = New ULControls.textBoxUL()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolCheck = New System.Windows.Forms.ToolStripButton()
        Me.dgvNeedCheckList = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrossWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SheetNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RealWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox3.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.dgvNeedCheckList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.toolStripStatusLabel1.Image = CType(resources.GetObject("toolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(75, 17)
        Me.toolStripStatusLabel1.Text = "扫描人员:"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "掃描人員"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.ToolUsename})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 527)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1267, 22)
        Me.statusStrip1.TabIndex = 144
        Me.statusStrip1.Text = "statusStrip1"
        '
        'ToolUsename
        '
        Me.ToolUsename.Name = "ToolUsename"
        Me.ToolUsename.Size = New System.Drawing.Size(41, 17)
        Me.ToolUsename.Text = "歐翔烽"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(59, 20)
        Me.toolStripMenuItem1.Text = "系统(&S)"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(59, 20)
        Me.toolStripMenuItem2.Text = "文件(&F)"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(59, 20)
        Me.toolStripMenuItem3.Text = "查看(&V)"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(59, 20)
        Me.toolStripMenuItem4.Text = "工具(&T)"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(59, 20)
        Me.toolStripMenuItem5.Text = "窗口(&W)"
        '
        'toolStripMenuItem6
        '
        Me.toolStripMenuItem6.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        Me.toolStripMenuItem6.Size = New System.Drawing.Size(59, 20)
        Me.toolStripMenuItem6.Text = "帮助(&H)"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.TxtHWCartonID)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.btnENT)
        Me.GroupBox4.Controls.Add(Me.btPause)
        Me.GroupBox4.Controls.Add(Me.LblCheckedQty)
        Me.GroupBox4.Controls.Add(Me.LblShouldCheckQty)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(2, 216)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1262, 52)
        Me.GroupBox4.TabIndex = 146
        Me.GroupBox4.TabStop = False
        '
        'TxtHWCartonID
        '
        Me.TxtHWCartonID.BackColor = System.Drawing.SystemColors.Control
        Me.TxtHWCartonID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtHWCartonID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtHWCartonID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtHWCartonID.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHWCartonID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtHWCartonID.HotColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtHWCartonID.Location = New System.Drawing.Point(93, 25)
        Me.TxtHWCartonID.MaxLength = 150
        Me.TxtHWCartonID.Name = "TxtHWCartonID"
        Me.TxtHWCartonID.Size = New System.Drawing.Size(270, 14)
        Me.TxtHWCartonID.TabIndex = 122
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(28, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 121
        Me.Label6.Text = "裝箱单号:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnENT
        '
        Me.btnENT.Location = New System.Drawing.Point(869, 16)
        Me.btnENT.Name = "btnENT"
        Me.btnENT.Size = New System.Drawing.Size(75, 23)
        Me.btnENT.TabIndex = 120
        Me.btnENT.Text = "监听"
        Me.btnENT.UseVisualStyleBackColor = True
        '
        'btPause
        '
        Me.btPause.Location = New System.Drawing.Point(963, 16)
        Me.btPause.Name = "btPause"
        Me.btPause.Size = New System.Drawing.Size(75, 23)
        Me.btPause.TabIndex = 119
        Me.btPause.Text = "暂停"
        Me.btPause.UseVisualStyleBackColor = True
        '
        'txtOutputWeight
        '
        Me.txtOutputWeight.BackColor = System.Drawing.SystemColors.Window
        Me.txtOutputWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutputWeight.Location = New System.Drawing.Point(407, 20)
        Me.txtOutputWeight.Multiline = True
        Me.txtOutputWeight.Name = "txtOutputWeight"
        Me.txtOutputWeight.ReadOnly = True
        Me.txtOutputWeight.Size = New System.Drawing.Size(131, 103)
        Me.txtOutputWeight.TabIndex = 118
        '
        'LblCheckedQty
        '
        Me.LblCheckedQty.AutoSize = True
        Me.LblCheckedQty.BackColor = System.Drawing.SystemColors.Control
        Me.LblCheckedQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblCheckedQty.ForeColor = System.Drawing.SystemColors.Desktop
        Me.LblCheckedQty.Location = New System.Drawing.Point(592, 17)
        Me.LblCheckedQty.Name = "LblCheckedQty"
        Me.LblCheckedQty.Size = New System.Drawing.Size(21, 22)
        Me.LblCheckedQty.TabIndex = 101
        Me.LblCheckedQty.Text = "0"
        '
        'LblShouldCheckQty
        '
        Me.LblShouldCheckQty.AutoSize = True
        Me.LblShouldCheckQty.BackColor = System.Drawing.SystemColors.Control
        Me.LblShouldCheckQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblShouldCheckQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblShouldCheckQty.Location = New System.Drawing.Point(483, 19)
        Me.LblShouldCheckQty.Name = "LblShouldCheckQty"
        Me.LblShouldCheckQty.Size = New System.Drawing.Size(21, 22)
        Me.LblShouldCheckQty.TabIndex = 100
        Me.LblShouldCheckQty.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(524, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 12)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "已检查数量："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(405, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 12)
        Me.Label8.TabIndex = 93
        Me.Label8.Text = "应检查数量："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.Gray
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1267, 24)
        Me.menuStrip1.TabIndex = 145
        Me.menuStrip1.Text = "menuStrip1"
        '
        'DGridBarCode
        '
        Me.DGridBarCode.AllowUserToAddRows = False
        Me.DGridBarCode.AllowUserToDeleteRows = False
        Me.DGridBarCode.BackgroundColor = System.Drawing.Color.White
        Me.DGridBarCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGridBarCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGridBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridBarCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SheetNo, Me.RealWeight, Me.UserID, Me.Intime})
        Me.DGridBarCode.Location = New System.Drawing.Point(0, 274)
        Me.DGridBarCode.Name = "DGridBarCode"
        Me.DGridBarCode.ReadOnly = True
        Me.DGridBarCode.RowHeadersWidth = 4
        Me.DGridBarCode.RowTemplate.Height = 23
        Me.DGridBarCode.Size = New System.Drawing.Size(844, 250)
        Me.DGridBarCode.TabIndex = 147
        '
        'toolCOMSetting
        '
        Me.toolCOMSetting.Image = CType(resources.GetObject("toolCOMSetting.Image"), System.Drawing.Image)
        Me.toolCOMSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCOMSetting.Name = "toolCOMSetting"
        Me.toolCOMSetting.Size = New System.Drawing.Size(85, 22)
        Me.toolCOMSetting.Text = "COM设置(S)"
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.BackColor = System.Drawing.Color.White
        Me.groupBox3.Controls.Add(Me.lblMessage)
        Me.groupBox3.Controls.Add(Me.LabResult)
        Me.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(544, 12)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(723, 111)
        Me.groupBox3.TabIndex = 93
        Me.groupBox3.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(6, 54)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(106, 40)
        Me.lblMessage.TabIndex = 86
        Me.lblMessage.Text = "PASS"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabResult
        '
        Me.LabResult.AutoSize = True
        Me.LabResult.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabResult.Location = New System.Drawing.Point(7, 15)
        Me.LabResult.Name = "LabResult"
        Me.LabResult.Size = New System.Drawing.Size(257, 19)
        Me.LabResult.TabIndex = 82
        Me.LabResult.Text = "CN0XX5807244997E000A000026"
        Me.LabResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(67, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "掃描時間"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "子條碼名稱"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 160.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "子料號條碼序號"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 160
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "站點項次序號"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "成品料號"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'groupBox1
        '
        Me.groupBox1.BackColor = System.Drawing.Color.White
        Me.groupBox1.Controls.Add(Me.cobBardRate)
        Me.groupBox1.Controls.Add(Me.Label4)
        Me.groupBox1.Controls.Add(Me.cboCOMNo)
        Me.groupBox1.Controls.Add(Me.TxtLineId)
        Me.groupBox1.Controls.Add(Me.TxtSitName)
        Me.groupBox1.Controls.Add(Me.TxtPartid)
        Me.groupBox1.Controls.Add(Me.Txt)
        Me.groupBox1.Controls.Add(Me.Label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.groupBox1.Location = New System.Drawing.Point(2, 52)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(1262, 37)
        Me.groupBox1.TabIndex = 143
        Me.groupBox1.TabStop = False
        '
        'cobBardRate
        '
        Me.cobBardRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cobBardRate.FormattingEnabled = True
        Me.cobBardRate.Location = New System.Drawing.Point(764, 8)
        Me.cobBardRate.Name = "cobBardRate"
        Me.cobBardRate.Size = New System.Drawing.Size(133, 20)
        Me.cobBardRate.TabIndex = 111
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(705, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "波特率："
        '
        'cboCOMNo
        '
        Me.cboCOMNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboCOMNo.FormattingEnabled = True
        Me.cboCOMNo.Location = New System.Drawing.Point(513, 8)
        Me.cboCOMNo.Name = "cboCOMNo"
        Me.cboCOMNo.Size = New System.Drawing.Size(146, 20)
        Me.cboCOMNo.TabIndex = 109
        '
        'TxtLineId
        '
        Me.TxtLineId.AutoSize = True
        Me.TxtLineId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtLineId.Location = New System.Drawing.Point(408, 16)
        Me.TxtLineId.Name = "TxtLineId"
        Me.TxtLineId.Size = New System.Drawing.Size(0, 12)
        Me.TxtLineId.TabIndex = 106
        '
        'TxtSitName
        '
        Me.TxtSitName.AutoSize = True
        Me.TxtSitName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtSitName.Location = New System.Drawing.Point(586, 16)
        Me.TxtSitName.Name = "TxtSitName"
        Me.TxtSitName.Size = New System.Drawing.Size(0, 12)
        Me.TxtSitName.TabIndex = 102
        '
        'TxtPartid
        '
        Me.TxtPartid.AutoSize = True
        Me.TxtPartid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtPartid.Location = New System.Drawing.Point(83, 16)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(0, 12)
        Me.TxtPartid.TabIndex = 100
        '
        'Txt
        '
        Me.Txt.AutoSize = True
        Me.Txt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Txt.Location = New System.Drawing.Point(69, 16)
        Me.Txt.Name = "Txt"
        Me.Txt.Size = New System.Drawing.Size(0, 12)
        Me.Txt.TabIndex = 99
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(454, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "端口号："
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(10, 12)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 12)
        Me.label2.TabIndex = 2
        Me.label2.Text = "料件编号："
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.White
        Me.label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.label5.Location = New System.Drawing.Point(3, 54)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(103, 15)
        Me.label5.TabIndex = 74
        Me.label5.Text = "标准重量最大值："
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(3, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 15)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "标准重量最小值："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBarName
        '
        Me.LblBarName.AutoSize = True
        Me.LblBarName.BackColor = System.Drawing.Color.White
        Me.LblBarName.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBarName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblBarName.Location = New System.Drawing.Point(9, 93)
        Me.LblBarName.Name = "LblBarName"
        Me.LblBarName.Size = New System.Drawing.Size(80, 18)
        Me.LblBarName.TabIndex = 71
        Me.LblBarName.Text = "备货单号:"
        Me.LblBarName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.BackColor = System.Drawing.Color.White
        Me.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.groupBox2.Controls.Add(Me.txtStdMaxWeight)
        Me.groupBox2.Controls.Add(Me.TxtSheetNo)
        Me.groupBox2.Controls.Add(Me.TxtStdMinWeight)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.txtOutputWeight)
        Me.groupBox2.Controls.Add(Me.Label7)
        Me.groupBox2.Controls.Add(Me.LblBarName)
        Me.groupBox2.Controls.Add(Me.groupBox3)
        Me.groupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox2.Location = New System.Drawing.Point(2, 87)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(1262, 129)
        Me.groupBox2.TabIndex = 141
        Me.groupBox2.TabStop = False
        '
        'txtStdMaxWeight
        '
        Me.txtStdMaxWeight.BackColor = System.Drawing.Color.White
        Me.txtStdMaxWeight.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.txtStdMaxWeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStdMaxWeight.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtStdMaxWeight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtStdMaxWeight.HotColor = System.Drawing.Color.White
        Me.txtStdMaxWeight.Location = New System.Drawing.Point(100, 55)
        Me.txtStdMaxWeight.Name = "txtStdMaxWeight"
        Me.txtStdMaxWeight.ReadOnly = True
        Me.txtStdMaxWeight.Size = New System.Drawing.Size(263, 15)
        Me.txtStdMaxWeight.TabIndex = 100
        '
        'TxtSheetNo
        '
        Me.TxtSheetNo.BackColor = System.Drawing.Color.White
        Me.TxtSheetNo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtSheetNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSheetNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSheetNo.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtSheetNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtSheetNo.HotColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtSheetNo.Location = New System.Drawing.Point(102, 91)
        Me.TxtSheetNo.Name = "TxtSheetNo"
        Me.TxtSheetNo.Size = New System.Drawing.Size(263, 15)
        Me.TxtSheetNo.TabIndex = 99
        '
        'TxtStdMinWeight
        '
        Me.TxtStdMinWeight.BackColor = System.Drawing.Color.White
        Me.TxtStdMinWeight.BorderColor = System.Drawing.Color.FromArgb(CType(CType(56, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.TxtStdMinWeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStdMinWeight.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtStdMinWeight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtStdMinWeight.HotColor = System.Drawing.Color.White
        Me.TxtStdMinWeight.Location = New System.Drawing.Point(104, 20)
        Me.TxtStdMinWeight.Name = "TxtStdMinWeight"
        Me.TxtStdMinWeight.ReadOnly = True
        Me.TxtStdMinWeight.Size = New System.Drawing.Size(263, 15)
        Me.TxtStdMinWeight.TabIndex = 98
        '
        'toolScanSet
        '
        Me.toolScanSet.Image = CType(resources.GetObject("toolScanSet.Image"), System.Drawing.Image)
        Me.toolScanSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolScanSet.Name = "toolScanSet"
        Me.toolScanSet.Size = New System.Drawing.Size(97, 22)
        Me.toolScanSet.Text = "扫描设置(&F1)"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolScanSet, Me.toolCheck, Me.toolCOMSetting, Me.ToolStripSeparator3, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1267, 25)
        Me.toolStrip1.TabIndex = 142
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolCheck
        '
        Me.toolCheck.Image = CType(resources.GetObject("toolCheck.Image"), System.Drawing.Image)
        Me.toolCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCheck.Name = "toolCheck"
        Me.toolCheck.Size = New System.Drawing.Size(115, 22)
        Me.toolCheck.Text = "重量比对检查(C)"
        '
        'dgvNeedCheckList
        '
        Me.dgvNeedCheckList.AllowUserToAddRows = False
        Me.dgvNeedCheckList.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvNeedCheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNeedCheckList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column7, Me.GrossWeight})
        Me.dgvNeedCheckList.Location = New System.Drawing.Point(850, 292)
        Me.dgvNeedCheckList.Name = "dgvNeedCheckList"
        Me.dgvNeedCheckList.RowTemplate.Height = 23
        Me.dgvNeedCheckList.Size = New System.Drawing.Size(414, 174)
        Me.dgvNeedCheckList.TabIndex = 148
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(869, 271)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "待检查的列表:"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "SheetNo"
        Me.Column3.HeaderText = "备货单号"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "RequestQty"
        Me.Column7.HeaderText = "需求数量"
        Me.Column7.Name = "Column7"
        '
        'GrossWeight
        '
        Me.GrossWeight.DataPropertyName = "GrossWeight"
        Me.GrossWeight.HeaderText = "标准毛重"
        Me.GrossWeight.Name = "GrossWeight"
        '
        'SheetNo
        '
        Me.SheetNo.DataPropertyName = "SheetNo"
        Me.SheetNo.HeaderText = "备货单号"
        Me.SheetNo.Name = "SheetNo"
        Me.SheetNo.ReadOnly = True
        '
        'RealWeight
        '
        Me.RealWeight.DataPropertyName = "RealWeight"
        Me.RealWeight.HeaderText = "实际重量"
        Me.RealWeight.Name = "RealWeight"
        Me.RealWeight.ReadOnly = True
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "称重人员"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.DataPropertyName = "Intime"
        Me.Intime.HeaderText = "称重时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'FrmWeightCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 549)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvNeedCheckList)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.DGridBarCode)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmWeightCheck"
        Me.Text = "华为称重检查"
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.dgvNeedCheckList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolUsename As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LblCheckedQty As System.Windows.Forms.Label
    Friend WithEvents LblShouldCheckQty As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DGridBarCode As System.Windows.Forms.DataGridView
    Friend WithEvents toolCOMSetting As System.Windows.Forms.ToolStripButton
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Private WithEvents LabResult As System.Windows.Forms.Label
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCOMNo As System.Windows.Forms.ComboBox
    Friend WithEvents TxtLineId As System.Windows.Forms.Label
    Friend WithEvents TxtSitName As System.Windows.Forms.Label
    Friend WithEvents TxtPartid As System.Windows.Forms.Label
    Private WithEvents Txt As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblBarName As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtStdMinWeight As ULControls.textBoxUL
    Friend WithEvents TxtSheetNo As ULControls.textBoxUL
    Friend WithEvents txtStdMaxWeight As ULControls.textBoxUL
    Friend WithEvents cobBardRate As System.Windows.Forms.ComboBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOutputWeight As System.Windows.Forms.TextBox
    Private WithEvents btnENT As System.Windows.Forms.Button
    Private WithEvents btPause As System.Windows.Forms.Button
    Friend WithEvents TxtHWCartonID As ULControls.textBoxUL
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvNeedCheckList As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GrossWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SheetNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RealWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
