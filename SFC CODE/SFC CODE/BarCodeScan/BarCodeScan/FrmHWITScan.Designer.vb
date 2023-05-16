<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHWITScan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHWITScan))
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtSitName = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.Label()
        Me.txtBarCode = New ULControls.textBoxUL()
        Me.label5 = New System.Windows.Forms.Label()
        Me.TxtLineId = New System.Windows.Forms.Label()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.label22 = New System.Windows.Forms.Label()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtMoId = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolUsename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.LabResult = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.LblBarName = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblCartonStyle = New System.Windows.Forms.Label()
        Me.txt_tmpbarcode = New System.Windows.Forms.Label()
        Me.chkShowCartonFull = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chbMessage = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblCurrQty = New System.Windows.Forms.Label()
        Me.LabCartonQty = New System.Windows.Forms.Label()
        Me.LblPackQty = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCartonID = New ULControls.textBoxUL()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtBarCodeStyle = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.ToolOption = New System.Windows.Forms.ToolStripButton()
        Me.toolMOStatusSetting = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DGridBarCode = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFNSKU = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Column1
        '
        Me.Column1.HeaderText = "成品料号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
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
        Me.TxtPartid.Location = New System.Drawing.Point(236, 16)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(0, 12)
        Me.TxtPartid.TabIndex = 100
        '
        'txtBarCode
        '
        Me.txtBarCode.BackColor = System.Drawing.Color.White
        Me.txtBarCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtBarCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBarCode.HotColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtBarCode.Location = New System.Drawing.Point(127, 65)
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(240, 14)
        Me.txtBarCode.TabIndex = 90
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.White
        Me.label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.label5.Location = New System.Drawing.Point(32, 23)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(91, 15)
        Me.label5.TabIndex = 74
        Me.label5.Text = "条码标准样式："
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'Column2
        '
        Me.Column2.HeaderText = "站点项次序号"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.ForeColor = System.Drawing.Color.Black
        Me.label22.Location = New System.Drawing.Point(345, 16)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(65, 12)
        Me.label22.TabIndex = 87
        Me.label22.Text = "线别编号："
        '
        'Column3
        '
        Me.Column3.HeaderText = "部件条码序号"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 240
        '
        'TxtMoId
        '
        Me.TxtMoId.AutoSize = True
        Me.TxtMoId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtMoId.Location = New System.Drawing.Point(69, 16)
        Me.TxtMoId.Name = "TxtMoId"
        Me.TxtMoId.Size = New System.Drawing.Size(0, 12)
        Me.TxtMoId.TabIndex = 99
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
        'ToolUsename
        '
        Me.ToolUsename.Name = "ToolUsename"
        Me.ToolUsename.Size = New System.Drawing.Size(44, 17)
        Me.ToolUsename.Text = ""
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.BackColor = System.Drawing.Color.White
        Me.groupBox3.Controls.Add(Me.LabResult)
        Me.groupBox3.Controls.Add(Me.lblMessage)
        Me.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(387, 9)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(880, 78)
        Me.groupBox3.TabIndex = 93
        Me.groupBox3.TabStop = False
        '
        'LabResult
        '
        Me.LabResult.AutoSize = True
        Me.LabResult.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabResult.Location = New System.Drawing.Point(9, 11)
        Me.LabResult.Name = "LabResult"
        Me.LabResult.Size = New System.Drawing.Size(0, 19)
        Me.LabResult.TabIndex = 87
        Me.LabResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(6, 34)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(106, 40)
        Me.lblMessage.TabIndex = 86
        Me.lblMessage.Text = "PASS"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblBarName
        '
        Me.LblBarName.AutoSize = True
        Me.LblBarName.BackColor = System.Drawing.Color.White
        Me.LblBarName.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBarName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblBarName.Location = New System.Drawing.Point(3, 65)
        Me.LblBarName.Name = "LblBarName"
        Me.LblBarName.Size = New System.Drawing.Size(114, 18)
        Me.LblBarName.TabIndex = 71
        Me.LblBarName.Text = "产品条码序号:"
        Me.LblBarName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.ForeColor = System.Drawing.Color.Black
        Me.label4.Location = New System.Drawing.Point(523, 16)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(65, 12)
        Me.label4.TabIndex = 6
        Me.label4.Text = "站点名称："
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(173, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 12)
        Me.label2.TabIndex = 2
        Me.label2.Text = "料件编号："
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(7, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(65, 12)
        Me.label1.TabIndex = 0
        Me.label1.Text = "工单编号："
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.lblCartonStyle)
        Me.GroupBox4.Controls.Add(Me.txt_tmpbarcode)
        Me.GroupBox4.Controls.Add(Me.chkShowCartonFull)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.chbMessage)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.LblCurrQty)
        Me.GroupBox4.Controls.Add(Me.LabCartonQty)
        Me.GroupBox4.Controls.Add(Me.LblPackQty)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtCartonID)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(2, 154)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1262, 61)
        Me.GroupBox4.TabIndex = 143
        Me.GroupBox4.TabStop = False
        '
        'lblCartonStyle
        '
        Me.lblCartonStyle.AutoSize = True
        Me.lblCartonStyle.ForeColor = System.Drawing.Color.LightGray
        Me.lblCartonStyle.Location = New System.Drawing.Point(1134, 39)
        Me.lblCartonStyle.Name = "lblCartonStyle"
        Me.lblCartonStyle.Size = New System.Drawing.Size(0, 12)
        Me.lblCartonStyle.TabIndex = 125
        '
        'txt_tmpbarcode
        '
        Me.txt_tmpbarcode.AutoSize = True
        Me.txt_tmpbarcode.Location = New System.Drawing.Point(1128, 21)
        Me.txt_tmpbarcode.Name = "txt_tmpbarcode"
        Me.txt_tmpbarcode.Size = New System.Drawing.Size(89, 12)
        Me.txt_tmpbarcode.TabIndex = 117
        Me.txt_tmpbarcode.Text = "txt_tmpbarcode"
        Me.txt_tmpbarcode.Visible = False
        '
        'chkShowCartonFull
        '
        Me.chkShowCartonFull.AutoSize = True
        Me.chkShowCartonFull.Location = New System.Drawing.Point(971, 27)
        Me.chkShowCartonFull.Name = "chkShowCartonFull"
        Me.chkShowCartonFull.Size = New System.Drawing.Size(15, 14)
        Me.chkShowCartonFull.TabIndex = 115
        Me.chkShowCartonFull.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 11.0!)
        Me.Label11.Location = New System.Drawing.Point(989, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 15)
        Me.Label11.TabIndex = 114
        Me.Label11.Text = "提示满箱"
        '
        'chbMessage
        '
        Me.chbMessage.AutoSize = True
        Me.chbMessage.Location = New System.Drawing.Point(864, 27)
        Me.chbMessage.Name = "chbMessage"
        Me.chbMessage.Size = New System.Drawing.Size(15, 14)
        Me.chbMessage.TabIndex = 113
        Me.chbMessage.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 11.0!)
        Me.Label13.Location = New System.Drawing.Point(882, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 15)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "提示声音"
        '
        'LblCurrQty
        '
        Me.LblCurrQty.AutoSize = True
        Me.LblCurrQty.BackColor = System.Drawing.SystemColors.Control
        Me.LblCurrQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblCurrQty.ForeColor = System.Drawing.SystemColors.Desktop
        Me.LblCurrQty.Location = New System.Drawing.Point(597, 23)
        Me.LblCurrQty.Name = "LblCurrQty"
        Me.LblCurrQty.Size = New System.Drawing.Size(21, 22)
        Me.LblCurrQty.TabIndex = 101
        Me.LblCurrQty.Text = "0"
        '
        'LabCartonQty
        '
        Me.LabCartonQty.AutoSize = True
        Me.LabCartonQty.BackColor = System.Drawing.SystemColors.Control
        Me.LabCartonQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabCartonQty.ForeColor = System.Drawing.Color.Crimson
        Me.LabCartonQty.Location = New System.Drawing.Point(763, 24)
        Me.LabCartonQty.Name = "LabCartonQty"
        Me.LabCartonQty.Size = New System.Drawing.Size(21, 22)
        Me.LabCartonQty.TabIndex = 99
        Me.LabCartonQty.Text = "0"
        '
        'LblPackQty
        '
        Me.LblPackQty.AutoSize = True
        Me.LblPackQty.BackColor = System.Drawing.SystemColors.Control
        Me.LblPackQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblPackQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblPackQty.Location = New System.Drawing.Point(454, 23)
        Me.LblPackQty.Name = "LblPackQty"
        Me.LblPackQty.Size = New System.Drawing.Size(21, 22)
        Me.LblPackQty.TabIndex = 100
        Me.LblPackQty.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Font = New System.Drawing.Font("宋体", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label10.Location = New System.Drawing.Point(679, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 15)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "扫描箱数:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(530, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "已裝数量："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(386, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 93
        Me.Label8.Text = "应装数量："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCartonID
        '
        Me.txtCartonID.BackColor = System.Drawing.SystemColors.Control
        Me.txtCartonID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCartonID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCartonID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCartonID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtCartonID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCartonID.HotColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCartonID.Location = New System.Drawing.Point(127, 25)
        Me.txtCartonID.MaxLength = 150
        Me.txtCartonID.Name = "txtCartonID"
        Me.txtCartonID.Size = New System.Drawing.Size(240, 14)
        Me.txtCartonID.TabIndex = 92
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(26, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 12)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "小箱/袋条码ID："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.BackColor = System.Drawing.Color.White
        Me.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.groupBox2.Controls.Add(Me.txtBarCodeStyle)
        Me.groupBox2.Controls.Add(Me.txtBarCode)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.LblBarName)
        Me.groupBox2.Controls.Add(Me.groupBox3)
        Me.groupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox2.Location = New System.Drawing.Point(2, 60)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(1262, 93)
        Me.groupBox2.TabIndex = 139
        Me.groupBox2.TabStop = False
        '
        'txtBarCodeStyle
        '
        '
        '
        '
        Me.txtBarCodeStyle.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtBarCodeStyle.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtBarCodeStyle.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtBarCodeStyle.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtBarCodeStyle.BackgroundStyle.Class = "TextBoxBorder"
        Me.txtBarCodeStyle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBarCodeStyle.ButtonCustom.Image = Global.BarCodeScan.My.Resources.Resources.query
        Me.txtBarCodeStyle.ButtonCustom.Visible = True
        Me.txtBarCodeStyle.Location = New System.Drawing.Point(127, 20)
        Me.txtBarCodeStyle.Name = "txtBarCodeStyle"
        Me.txtBarCodeStyle.ReadOnly = True
        Me.txtBarCodeStyle.Size = New System.Drawing.Size(240, 21)
        Me.txtBarCodeStyle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtBarCodeStyle.TabIndex = 118
        Me.txtBarCodeStyle.Text = ""
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolScanSet, Me.ToolOption, Me.toolMOStatusSetting, Me.toolExit, Me.ToolStripSeparator3})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 3)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1267, 25)
        Me.toolStrip1.TabIndex = 140
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolScanSet
        '
        Me.toolScanSet.Image = CType(resources.GetObject("toolScanSet.Image"), System.Drawing.Image)
        Me.toolScanSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolScanSet.Name = "toolScanSet"
        Me.toolScanSet.Size = New System.Drawing.Size(97, 22)
        Me.toolScanSet.Text = "扫描设置(&F1)"
        '
        'ToolOption
        '
        Me.ToolOption.Image = CType(resources.GetObject("ToolOption.Image"), System.Drawing.Image)
        Me.ToolOption.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolOption.Name = "ToolOption"
        Me.ToolOption.Size = New System.Drawing.Size(106, 22)
        Me.ToolOption.Text = "尾数箱设置(&O)"
        '
        'toolMOStatusSetting
        '
        Me.toolMOStatusSetting.Image = CType(resources.GetObject("toolMOStatusSetting.Image"), System.Drawing.Image)
        Me.toolMOStatusSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMOStatusSetting.Name = "toolMOStatusSetting"
        Me.toolMOStatusSetting.Size = New System.Drawing.Size(100, 22)
        Me.toolMOStatusSetting.Text = "工单状态设置"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'DGridBarCode
        '
        Me.DGridBarCode.AllowUserToAddRows = False
        Me.DGridBarCode.AllowUserToDeleteRows = False
        Me.DGridBarCode.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGridBarCode.BackgroundColor = System.Drawing.Color.White
        Me.DGridBarCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGridBarCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGridBarCode.ColumnHeadersHeight = 26
        Me.DGridBarCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.DGridBarCode.Location = New System.Drawing.Point(0, 221)
        Me.DGridBarCode.Name = "DGridBarCode"
        Me.DGridBarCode.ReadOnly = True
        Me.DGridBarCode.RowHeadersWidth = 4
        Me.DGridBarCode.RowTemplate.Height = 23
        Me.DGridBarCode.Size = New System.Drawing.Size(1264, 303)
        Me.DGridBarCode.TabIndex = 145
        '
        'Column4
        '
        Me.Column4.HeaderText = "部件名称"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "扫描人员"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "扫描时间"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.ToolUsename})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 527)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1267, 22)
        Me.statusStrip1.TabIndex = 142
        Me.statusStrip1.Text = "statusStrip1"
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.toolStripStatusLabel1.Image = CType(resources.GetObject("toolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(75, 17)
        Me.toolStripStatusLabel1.Text = "扫描人员:"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "成品料號"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "站點項次序號"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 160.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "子料號條碼序號"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 160
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "子條碼名稱"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.BackColor = System.Drawing.Color.White
        Me.groupBox1.Controls.Add(Me.chkFNSKU)
        Me.groupBox1.Controls.Add(Me.TxtLineId)
        Me.groupBox1.Controls.Add(Me.TxtSitName)
        Me.groupBox1.Controls.Add(Me.TxtPartid)
        Me.groupBox1.Controls.Add(Me.label22)
        Me.groupBox1.Controls.Add(Me.TxtMoId)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.groupBox1.Location = New System.Drawing.Point(2, 23)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(1262, 37)
        Me.groupBox1.TabIndex = 141
        Me.groupBox1.TabStop = False
        '
        'chkFNSKU
        '
        Me.chkFNSKU.AutoSize = True
        Me.chkFNSKU.Location = New System.Drawing.Point(784, 14)
        Me.chkFNSKU.Name = "chkFNSKU"
        Me.chkFNSKU.Size = New System.Drawing.Size(90, 16)
        Me.chkFNSKU.TabIndex = 118
        Me.chkFNSKU.Tag = "是否有FNSKU"
        Me.chkFNSKU.Text = "是否有FNSKU"
        Me.chkFNSKU.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "掃描時間"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FrmHWITScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 549)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.DGridBarCode)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "FrmHWITScan"
        Me.ShowIcon = False
        Me.Text = "海翼包装扫描"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtSitName As System.Windows.Forms.Label
    Friend WithEvents TxtPartid As System.Windows.Forms.Label
    Friend WithEvents txtBarCode As ULControls.textBoxUL
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents TxtLineId As System.Windows.Forms.Label
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents label22 As System.Windows.Forms.Label
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents TxtMoId As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolUsename As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolOption As System.Windows.Forms.ToolStripButton
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents LblBarName As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_tmpbarcode As System.Windows.Forms.Label
    Friend WithEvents chkShowCartonFull As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chbMessage As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblCurrQty As System.Windows.Forms.Label
    Friend WithEvents LabCartonQty As System.Windows.Forms.Label
    Friend WithEvents LblPackQty As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCartonID As ULControls.textBoxUL
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DGridBarCode As System.Windows.Forms.DataGridView
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtBarCodeStyle As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Private WithEvents LabResult As System.Windows.Forms.Label
    Friend WithEvents chkFNSKU As System.Windows.Forms.CheckBox
    Friend WithEvents toolMOStatusSetting As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblCartonStyle As System.Windows.Forms.Label
End Class
