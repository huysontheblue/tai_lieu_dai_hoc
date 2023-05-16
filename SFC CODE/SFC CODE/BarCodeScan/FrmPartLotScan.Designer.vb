<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPartLotScan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPartLotScan))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CobPartid = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtLotno = New System.Windows.Forms.TextBox()
        Me.TxtMoid = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.TxtStationid = New System.Windows.Forms.TextBox()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.Dglot = New System.Windows.Forms.DataGridView()
        Me.moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colmpartid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Coldes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.linkqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Splitqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolUpdate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolNg = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.toolBOMCheckSet = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.TxtStyle = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DgPartid = New System.Windows.Forms.DataGridView()
        Me.Col1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalQTY = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblMOQty = New System.Windows.Forms.Label()
        Me.chkSap = New System.Windows.Forms.CheckBox()
        CType(Me.Dglot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.DgPartid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "部件编号："
        '
        'CobPartid
        '
        Me.CobPartid.Enabled = False
        Me.CobPartid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CobPartid.FormattingEnabled = True
        Me.CobPartid.Location = New System.Drawing.Point(91, 156)
        Me.CobPartid.Name = "CobPartid"
        Me.CobPartid.Size = New System.Drawing.Size(279, 20)
        Me.CobPartid.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 214)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "来料Lot No："
        '
        'TxtLotno
        '
        Me.TxtLotno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLotno.Enabled = False
        Me.TxtLotno.ForeColor = System.Drawing.Color.Black
        Me.TxtLotno.Location = New System.Drawing.Point(90, 211)
        Me.TxtLotno.Name = "TxtLotno"
        Me.TxtLotno.Size = New System.Drawing.Size(280, 21)
        Me.TxtLotno.TabIndex = 3
        '
        'TxtMoid
        '
        Me.TxtMoid.Enabled = False
        Me.TxtMoid.Location = New System.Drawing.Point(90, 82)
        Me.TxtMoid.Name = "TxtMoid"
        Me.TxtMoid.Size = New System.Drawing.Size(280, 21)
        Me.TxtMoid.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "工单编号："
        '
        'TxtPartid
        '
        Me.TxtPartid.Enabled = False
        Me.TxtPartid.Location = New System.Drawing.Point(90, 106)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(280, 21)
        Me.TxtPartid.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "成品料号："
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(89, 62)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(57, 12)
        Me.LblMsg.TabIndex = 10
        Me.LblMsg.Text = "提示信息"
        '
        'TxtStationid
        '
        Me.TxtStationid.Enabled = False
        Me.TxtStationid.Location = New System.Drawing.Point(90, 131)
        Me.TxtStationid.Name = "TxtStationid"
        Me.TxtStationid.Size = New System.Drawing.Size(280, 21)
        Me.TxtStationid.TabIndex = 11
        '
        'lblLine
        '
        Me.lblLine.AutoSize = True
        Me.lblLine.Location = New System.Drawing.Point(19, 134)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(65, 12)
        Me.lblLine.TabIndex = 12
        Me.lblLine.Text = "站点编号："
        '
        'Dglot
        '
        Me.Dglot.AllowUserToAddRows = False
        Me.Dglot.AllowUserToDeleteRows = False
        Me.Dglot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dglot.BackgroundColor = System.Drawing.Color.White
        Me.Dglot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dglot.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Dglot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dglot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.moid, Me.partid, Me.Colmpartid, Me.Coldes, Me.ColLot, Me.Column6, Me.linkqty, Me.Splitqty, Me.ScanCount, Me.Intime})
        Me.Dglot.Location = New System.Drawing.Point(2, 283)
        Me.Dglot.Name = "Dglot"
        Me.Dglot.ReadOnly = True
        Me.Dglot.RowHeadersWidth = 4
        Me.Dglot.RowTemplate.Height = 23
        Me.Dglot.Size = New System.Drawing.Size(1074, 151)
        Me.Dglot.TabIndex = 13
        '
        'moid
        '
        Me.moid.HeaderText = "工单编号"
        Me.moid.Name = "moid"
        Me.moid.ReadOnly = True
        Me.moid.Width = 80
        '
        'partid
        '
        Me.partid.HeaderText = "成品料号"
        Me.partid.Name = "partid"
        Me.partid.ReadOnly = True
        Me.partid.Width = 80
        '
        'Colmpartid
        '
        Me.Colmpartid.HeaderText = "部件编号"
        Me.Colmpartid.Name = "Colmpartid"
        Me.Colmpartid.ReadOnly = True
        Me.Colmpartid.Width = 80
        '
        'Coldes
        '
        Me.Coldes.HeaderText = "描述"
        Me.Coldes.Name = "Coldes"
        Me.Coldes.ReadOnly = True
        Me.Coldes.Width = 85
        '
        'ColLot
        '
        Me.ColLot.HeaderText = "批次号"
        Me.ColLot.Name = "ColLot"
        Me.ColLot.ReadOnly = True
        Me.ColLot.Width = 70
        '
        'Column6
        '
        Me.Column6.HeaderText = "有效"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 60
        '
        'linkqty
        '
        Me.linkqty.HeaderText = "批次总数"
        Me.linkqty.Name = "linkqty"
        Me.linkqty.ReadOnly = True
        '
        'Splitqty
        '
        Me.Splitqty.HeaderText = "已用数"
        Me.Splitqty.Name = "Splitqty"
        Me.Splitqty.ReadOnly = True
        '
        'ScanCount
        '
        Me.ScanCount.HeaderText = "上料次数"
        Me.ScanCount.Name = "ScanCount"
        Me.ScanCount.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.HeaderText = "扫描时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.Gray
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1076, 25)
        Me.menuStrip1.TabIndex = 129
        Me.menuStrip1.Text = "menuStrip1"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        Me.toolStripMenuItem1.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem1.Text = "系统(&S)"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        Me.toolStripMenuItem2.Size = New System.Drawing.Size(58, 21)
        Me.toolStripMenuItem2.Text = "文件(&F)"
        '
        'toolStripMenuItem3
        '
        Me.toolStripMenuItem3.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        Me.toolStripMenuItem3.Size = New System.Drawing.Size(60, 21)
        Me.toolStripMenuItem3.Text = "查看(&V)"
        '
        'toolStripMenuItem4
        '
        Me.toolStripMenuItem4.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        Me.toolStripMenuItem4.Size = New System.Drawing.Size(59, 21)
        Me.toolStripMenuItem4.Text = "工具(&T)"
        '
        'toolStripMenuItem5
        '
        Me.toolStripMenuItem5.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        Me.toolStripMenuItem5.Size = New System.Drawing.Size(64, 21)
        Me.toolStripMenuItem5.Text = "窗口(&W)"
        '
        'toolStripMenuItem6
        '
        Me.toolStripMenuItem6.ForeColor = System.Drawing.Color.White
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        Me.toolStripMenuItem6.Size = New System.Drawing.Size(61, 21)
        Me.toolStripMenuItem6.Text = "帮助(&H)"
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolScanSet, Me.toolStripSeparator2, Me.toolUpdate, Me.ToolStripSeparator4, Me.ToolDelete, Me.ToolStripSeparator3, Me.ToolNg, Me.ToolStripSeparator5, Me.toolSave, Me.ToolStripButton2, Me.toolBOMCheckSet, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(2, 28)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1074, 25)
        Me.toolStrip1.TabIndex = 130
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolScanSet
        '
        Me.toolScanSet.Image = CType(resources.GetObject("toolScanSet.Image"), System.Drawing.Image)
        Me.toolScanSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolScanSet.Name = "toolScanSet"
        Me.toolScanSet.Size = New System.Drawing.Size(70, 22)
        Me.toolScanSet.Text = "新增(&N)"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolUpdate
        '
        Me.toolUpdate.Image = CType(resources.GetObject("toolUpdate.Image"), System.Drawing.Image)
        Me.toolUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolUpdate.Name = "toolUpdate"
        Me.toolUpdate.Size = New System.Drawing.Size(67, 22)
        Me.toolUpdate.Text = "修改(&E)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolDelete
        '
        Me.ToolDelete.Image = CType(resources.GetObject("ToolDelete.Image"), System.Drawing.Image)
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(69, 22)
        Me.ToolDelete.Text = "作废(&D)"
        Me.ToolDelete.ToolTipText = "(D)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolNg
        '
        Me.ToolNg.Enabled = False
        Me.ToolNg.Image = CType(resources.GetObject("ToolNg.Image"), System.Drawing.Image)
        Me.ToolNg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNg.Name = "ToolNg"
        Me.ToolNg.Size = New System.Drawing.Size(68, 22)
        Me.ToolNg.Text = "取消(&C)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'toolSave
        '
        Me.toolSave.Enabled = False
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(67, 22)
        Me.toolSave.Text = "保存(&S)"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButton2.Text = "抛转(&T)"
        '
        'toolBOMCheckSet
        '
        Me.toolBOMCheckSet.Enabled = False
        Me.toolBOMCheckSet.Image = CType(resources.GetObject("toolBOMCheckSet.Image"), System.Drawing.Image)
        Me.toolBOMCheckSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBOMCheckSet.Name = "toolBOMCheckSet"
        Me.toolBOMCheckSet.Size = New System.Drawing.Size(121, 22)
        Me.toolBOMCheckSet.Text = "BOM扫描设置(&T)"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'TxtStyle
        '
        Me.TxtStyle.BackColor = System.Drawing.Color.Gray
        Me.TxtStyle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtStyle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStyle.ForeColor = System.Drawing.Color.White
        Me.TxtStyle.Location = New System.Drawing.Point(90, 240)
        Me.TxtStyle.MaxLength = 7
        Me.TxtStyle.Name = "TxtStyle"
        Me.TxtStyle.ReadOnly = True
        Me.TxtStyle.Size = New System.Drawing.Size(280, 21)
        Me.TxtStyle.TabIndex = 132
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 131
        Me.Label6.Text = "批次样式："
        '
        'DgPartid
        '
        Me.DgPartid.AllowUserToAddRows = False
        Me.DgPartid.AllowUserToDeleteRows = False
        Me.DgPartid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgPartid.BackgroundColor = System.Drawing.Color.White
        Me.DgPartid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgPartid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DgPartid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgPartid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col1, Me.Col2, Me.Col3, Me.Col4, Me.Col5, Me.Col6})
        Me.DgPartid.Location = New System.Drawing.Point(401, 82)
        Me.DgPartid.Name = "DgPartid"
        Me.DgPartid.ReadOnly = True
        Me.DgPartid.RowHeadersWidth = 4
        Me.DgPartid.RowTemplate.Height = 23
        Me.DgPartid.Size = New System.Drawing.Size(675, 195)
        Me.DgPartid.TabIndex = 133
        '
        'Col1
        '
        Me.Col1.HeaderText = "料件编号"
        Me.Col1.Name = "Col1"
        Me.Col1.ReadOnly = True
        Me.Col1.Width = 80
        '
        'Col2
        '
        Me.Col2.HeaderText = "上级料号"
        Me.Col2.Name = "Col2"
        Me.Col2.ReadOnly = True
        Me.Col2.Width = 80
        '
        'Col3
        '
        Me.Col3.HeaderText = "料件描述"
        Me.Col3.Name = "Col3"
        Me.Col3.ReadOnly = True
        Me.Col3.Width = 80
        '
        'Col4
        '
        Me.Col4.HeaderText = "客户料号"
        Me.Col4.Name = "Col4"
        Me.Col4.ReadOnly = True
        Me.Col4.Width = 85
        '
        'Col5
        '
        Me.Col5.HeaderText = "料件代码"
        Me.Col5.Name = "Col5"
        Me.Col5.ReadOnly = True
        '
        'Col6
        '
        Me.Col6.HeaderText = "供应商代码"
        Me.Col6.Name = "Col6"
        Me.Col6.ReadOnly = True
        Me.Col6.Width = 120
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 437)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1076, 22)
        Me.statusStrip1.TabIndex = 134
        Me.statusStrip1.Text = "statusStrip1"
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.toolStripStatusLabel1.Image = CType(resources.GetObject("toolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(69, 17)
        Me.toolStripStatusLabel1.Text = "Ready..."
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "工单编号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "成品料号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "部件编号"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "描述"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 85
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "批次号"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "有效"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 60
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "上级料号"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "料件描述"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 80
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "客户料号"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 85
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "料件代码"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 85
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "供应商代码"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 120
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "供应商代码"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 120
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "批次总数："
        '
        'txtTotalQTY
        '
        Me.txtTotalQTY.Location = New System.Drawing.Point(91, 182)
        Me.txtTotalQTY.Name = "txtTotalQTY"
        Me.txtTotalQTY.Size = New System.Drawing.Size(158, 21)
        Me.txtTotalQTY.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(554, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 135
        Me.Label7.Text = "工单数量:"
        '
        'lblMOQty
        '
        Me.lblMOQty.AutoSize = True
        Me.lblMOQty.Location = New System.Drawing.Point(625, 62)
        Me.lblMOQty.Name = "lblMOQty"
        Me.lblMOQty.Size = New System.Drawing.Size(11, 12)
        Me.lblMOQty.TabIndex = 136
        Me.lblMOQty.Text = "0"
        '
        'chkSap
        '
        Me.chkSap.AutoSize = True
        Me.chkSap.Location = New System.Drawing.Point(268, 187)
        Me.chkSap.Name = "chkSap"
        Me.chkSap.Size = New System.Drawing.Size(102, 16)
        Me.chkSap.TabIndex = 137
        Me.chkSap.Text = "是否是SAP标签"
        Me.chkSap.UseVisualStyleBackColor = True
        '
        'FrmPartLotScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 459)
        Me.Controls.Add(Me.chkSap)
        Me.Controls.Add(Me.lblMOQty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.DgPartid)
        Me.Controls.Add(Me.TxtStyle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.Dglot)
        Me.Controls.Add(Me.txtTotalQTY)
        Me.Controls.Add(Me.TxtStationid)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblLine)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.TxtPartid)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtMoid)
        Me.Controls.Add(Me.TxtLotno)
        Me.Controls.Add(Me.CobPartid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPartLotScan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "来料批次扫描作业"
        CType(Me.Dglot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.DgPartid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CobPartid As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtLotno As System.Windows.Forms.TextBox
    Friend WithEvents TxtMoid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPartid As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents TxtStationid As System.Windows.Forms.TextBox
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents Dglot As System.Windows.Forms.DataGridView
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolNg As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtStyle As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgPartid As System.Windows.Forms.DataGridView
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Col1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Col6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents toolBOMCheckSet As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalQTY As System.Windows.Forms.TextBox
    Friend WithEvents moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colmpartid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Coldes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents linkqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Splitqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblMOQty As System.Windows.Forms.Label
    Private WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkSap As System.Windows.Forms.CheckBox
End Class
