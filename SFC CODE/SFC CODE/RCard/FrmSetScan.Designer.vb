<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSetScan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSetScan))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblCurrQty = New System.Windows.Forms.Label()
        Me.LblChildSetQty = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGridBarCode = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblWeek = New System.Windows.Forms.Label()
        Me.chkUnfinish = New System.Windows.Forms.CheckBox()
        Me.txtPackBarcode = New ULControls.textBoxUL()
        Me.lblChildPN = New System.Windows.Forms.Label()
        Me.LblChildFinishQty = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LblMainBarCode = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtLineID = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtFinishQty = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtMOQty = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtChildPNQty = New System.Windows.Forms.Label()
        Me.txtPVersion = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.TxtMoId = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.LblBarName = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.LabResult = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtBarCode = New ULControls.textBoxUL()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolGroupMaintain = New System.Windows.Forms.ToolStripButton()
        Me.ToolUsename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(548, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 12)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "该子件已裝数量："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(374, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 12)
        Me.Label8.TabIndex = 93
        Me.Label8.Text = "该子件应装数量："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblCurrQty
        '
        Me.LblCurrQty.AutoSize = True
        Me.LblCurrQty.BackColor = System.Drawing.SystemColors.Control
        Me.LblCurrQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblCurrQty.ForeColor = System.Drawing.SystemColors.Desktop
        Me.LblCurrQty.Location = New System.Drawing.Point(639, 49)
        Me.LblCurrQty.Name = "LblCurrQty"
        Me.LblCurrQty.Size = New System.Drawing.Size(21, 22)
        Me.LblCurrQty.TabIndex = 101
        Me.LblCurrQty.Text = "0"
        '
        'LblChildSetQty
        '
        Me.LblChildSetQty.AutoSize = True
        Me.LblChildSetQty.BackColor = System.Drawing.SystemColors.Control
        Me.LblChildSetQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblChildSetQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblChildSetQty.Location = New System.Drawing.Point(479, 50)
        Me.LblChildSetQty.Name = "LblChildSetQty"
        Me.LblChildSetQty.Size = New System.Drawing.Size(21, 22)
        Me.LblChildSetQty.TabIndex = 100
        Me.LblChildSetQty.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(21, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "子件料号："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.DGridBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridBarCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column2, Me.Column5, Me.Column6})
        Me.DGridBarCode.Location = New System.Drawing.Point(0, 287)
        Me.DGridBarCode.Name = "DGridBarCode"
        Me.DGridBarCode.ReadOnly = True
        Me.DGridBarCode.RowHeadersWidth = 4
        Me.DGridBarCode.RowTemplate.Height = 23
        Me.DGridBarCode.Size = New System.Drawing.Size(988, 237)
        Me.DGridBarCode.TabIndex = 138
        '
        'Column1
        '
        Me.Column1.HeaderText = "子件料号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "子件配置数"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "已扫描数量"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
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
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.lblWeek)
        Me.GroupBox4.Controls.Add(Me.chkUnfinish)
        Me.GroupBox4.Controls.Add(Me.txtPackBarcode)
        Me.GroupBox4.Controls.Add(Me.lblChildPN)
        Me.GroupBox4.Controls.Add(Me.LblCurrQty)
        Me.GroupBox4.Controls.Add(Me.LblChildFinishQty)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.LblChildSetQty)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(2, 191)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(986, 90)
        Me.GroupBox4.TabIndex = 136
        Me.GroupBox4.TabStop = False
        '
        'lblWeek
        '
        Me.lblWeek.AutoSize = True
        Me.lblWeek.Location = New System.Drawing.Point(900, 30)
        Me.lblWeek.Name = "lblWeek"
        Me.lblWeek.Size = New System.Drawing.Size(0, 12)
        Me.lblWeek.TabIndex = 116
        '
        'chkUnfinish
        '
        Me.chkUnfinish.AutoSize = True
        Me.chkUnfinish.Location = New System.Drawing.Point(693, 15)
        Me.chkUnfinish.Name = "chkUnfinish"
        Me.chkUnfinish.Size = New System.Drawing.Size(108, 16)
        Me.chkUnfinish.TabIndex = 115
        Me.chkUnfinish.Text = "检查未完成包装"
        Me.chkUnfinish.UseVisualStyleBackColor = True
        '
        'txtPackBarcode
        '
        Me.txtPackBarcode.BackColor = System.Drawing.SystemColors.Control
        Me.txtPackBarcode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPackBarcode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPackBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPackBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPackBarcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPackBarcode.HotColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtPackBarcode.Location = New System.Drawing.Point(126, 17)
        Me.txtPackBarcode.Name = "txtPackBarcode"
        Me.txtPackBarcode.Size = New System.Drawing.Size(240, 14)
        Me.txtPackBarcode.TabIndex = 97
        '
        'lblChildPN
        '
        Me.lblChildPN.AutoSize = True
        Me.lblChildPN.BackColor = System.Drawing.SystemColors.Control
        Me.lblChildPN.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblChildPN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblChildPN.Location = New System.Drawing.Point(90, 51)
        Me.lblChildPN.Name = "lblChildPN"
        Me.lblChildPN.Size = New System.Drawing.Size(36, 22)
        Me.lblChildPN.TabIndex = 114
        Me.lblChildPN.Text = "NA"
        '
        'LblChildFinishQty
        '
        Me.LblChildFinishQty.AutoSize = True
        Me.LblChildFinishQty.BackColor = System.Drawing.SystemColors.Control
        Me.LblChildFinishQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblChildFinishQty.ForeColor = System.Drawing.Color.Crimson
        Me.LblChildFinishQty.Location = New System.Drawing.Point(824, 50)
        Me.LblChildFinishQty.Name = "LblChildFinishQty"
        Me.LblChildFinishQty.Size = New System.Drawing.Size(21, 22)
        Me.LblChildFinishQty.TabIndex = 99
        Me.LblChildFinishQty.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(21, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 18)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "包装袋条码:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Font = New System.Drawing.Font("宋体", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.Label10.Location = New System.Drawing.Point(690, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 15)
        Me.Label10.TabIndex = 98
        Me.Label10.Text = "扫描完成子件数:"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "掃描人員"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LblMainBarCode
        '
        Me.LblMainBarCode.AutoSize = True
        Me.LblMainBarCode.BackColor = System.Drawing.Color.White
        Me.LblMainBarCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMainBarCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblMainBarCode.Location = New System.Drawing.Point(123, 105)
        Me.LblMainBarCode.Name = "LblMainBarCode"
        Me.LblMainBarCode.Size = New System.Drawing.Size(0, 15)
        Me.LblMainBarCode.TabIndex = 95
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.BackColor = System.Drawing.Color.White
        Me.groupBox1.Controls.Add(Me.TxtLineID)
        Me.groupBox1.Controls.Add(Me.Label12)
        Me.groupBox1.Controls.Add(Me.TxtFinishQty)
        Me.groupBox1.Controls.Add(Me.Label13)
        Me.groupBox1.Controls.Add(Me.TxtMOQty)
        Me.groupBox1.Controls.Add(Me.Label11)
        Me.groupBox1.Controls.Add(Me.Label7)
        Me.groupBox1.Controls.Add(Me.Label5)
        Me.groupBox1.Controls.Add(Me.Label4)
        Me.groupBox1.Controls.Add(Me.TxtChildPNQty)
        Me.groupBox1.Controls.Add(Me.txtPVersion)
        Me.groupBox1.Controls.Add(Me.TxtPartid)
        Me.groupBox1.Controls.Add(Me.label22)
        Me.groupBox1.Controls.Add(Me.TxtMoId)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.groupBox1.Location = New System.Drawing.Point(2, 21)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(986, 37)
        Me.groupBox1.TabIndex = 134
        Me.groupBox1.TabStop = False
        '
        'TxtLineID
        '
        Me.TxtLineID.AutoSize = True
        Me.TxtLineID.Location = New System.Drawing.Point(885, 18)
        Me.TxtLineID.Name = "TxtLineID"
        Me.TxtLineID.Size = New System.Drawing.Size(0, 12)
        Me.TxtLineID.TabIndex = 115
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(843, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 12)
        Me.Label12.TabIndex = 114
        Me.Label12.Text = "线别:"
        '
        'TxtFinishQty
        '
        Me.TxtFinishQty.AutoSize = True
        Me.TxtFinishQty.Location = New System.Drawing.Point(819, 16)
        Me.TxtFinishQty.Name = "TxtFinishQty"
        Me.TxtFinishQty.Size = New System.Drawing.Size(0, 12)
        Me.TxtFinishQty.TabIndex = 113
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(742, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 12)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "已完成数量:"
        '
        'TxtMOQty
        '
        Me.TxtMOQty.AutoSize = True
        Me.TxtMOQty.Location = New System.Drawing.Point(679, 16)
        Me.TxtMOQty.Name = "TxtMOQty"
        Me.TxtMOQty.Size = New System.Drawing.Size(0, 12)
        Me.TxtMOQty.TabIndex = 111
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(493, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 12)
        Me.Label11.TabIndex = 110
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(613, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "工单数量:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(476, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 12)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "版本号:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(627, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 12)
        Me.Label4.TabIndex = 107
        '
        'TxtChildPNQty
        '
        Me.TxtChildPNQty.AutoSize = True
        Me.TxtChildPNQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtChildPNQty.Location = New System.Drawing.Point(408, 16)
        Me.TxtChildPNQty.Name = "TxtChildPNQty"
        Me.TxtChildPNQty.Size = New System.Drawing.Size(0, 12)
        Me.TxtChildPNQty.TabIndex = 106
        '
        'txtPVersion
        '
        Me.txtPVersion.AutoSize = True
        Me.txtPVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.txtPVersion.Location = New System.Drawing.Point(540, 16)
        Me.txtPVersion.Name = "txtPVersion"
        Me.txtPVersion.Size = New System.Drawing.Size(0, 12)
        Me.txtPVersion.TabIndex = 102
        '
        'TxtPartid
        '
        Me.TxtPartid.AutoSize = True
        Me.TxtPartid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtPartid.Location = New System.Drawing.Point(238, 16)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(0, 12)
        Me.TxtPartid.TabIndex = 100
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.ForeColor = System.Drawing.Color.Black
        Me.label22.Location = New System.Drawing.Point(345, 16)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(65, 12)
        Me.label22.TabIndex = 87
        Me.label22.Text = "子件数量："
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
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(175, 16)
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
        'LblBarName
        '
        Me.LblBarName.AutoSize = True
        Me.LblBarName.BackColor = System.Drawing.Color.White
        Me.LblBarName.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBarName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblBarName.Location = New System.Drawing.Point(2, 70)
        Me.LblBarName.Name = "LblBarName"
        Me.LblBarName.Size = New System.Drawing.Size(124, 18)
        Me.LblBarName.TabIndex = 71
        Me.LblBarName.Text = "子件(包装)条码:"
        Me.LblBarName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(6, 40)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(106, 40)
        Me.lblMessage.TabIndex = 86
        Me.lblMessage.Text = "PASS"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.groupBox3.Location = New System.Drawing.Point(388, 12)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(603, 111)
        Me.groupBox3.TabIndex = 93
        Me.groupBox3.TabStop = False
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
        'groupBox2
        '
        Me.groupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.BackColor = System.Drawing.Color.White
        Me.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.groupBox2.Controls.Add(Me.TxtBarCode)
        Me.groupBox2.Controls.Add(Me.LblMainBarCode)
        Me.groupBox2.Controls.Add(Me.LblBarName)
        Me.groupBox2.Controls.Add(Me.groupBox3)
        Me.groupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox2.Location = New System.Drawing.Point(2, 58)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(986, 129)
        Me.groupBox2.TabIndex = 132
        Me.groupBox2.TabStop = False
        '
        'TxtBarCode
        '
        Me.TxtBarCode.BackColor = System.Drawing.Color.White
        Me.TxtBarCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtBarCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtBarCode.HotColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBarCode.Location = New System.Drawing.Point(126, 70)
        Me.TxtBarCode.Name = "TxtBarCode"
        Me.TxtBarCode.Size = New System.Drawing.Size(240, 14)
        Me.TxtBarCode.TabIndex = 96
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
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.ToolStripButton1, Me.ToolGroupMaintain, Me.toolExit, Me.ToolStripSeparator3})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 1)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(991, 25)
        Me.toolStrip1.TabIndex = 133
        Me.toolStrip1.Text = "toolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripButton1.Text = "查看明细"
        '
        'ToolGroupMaintain
        '
        Me.ToolGroupMaintain.Image = CType(resources.GetObject("ToolGroupMaintain.Image"), System.Drawing.Image)
        Me.ToolGroupMaintain.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolGroupMaintain.Name = "ToolGroupMaintain"
        Me.ToolGroupMaintain.Size = New System.Drawing.Size(121, 22)
        Me.ToolGroupMaintain.Text = "小袋组员维护(&F5)"
        '
        'ToolUsename
        '
        Me.ToolUsename.Name = "ToolUsename"
        Me.ToolUsename.Size = New System.Drawing.Size(44, 17)
        Me.ToolUsename.Text = "歐翔烽"
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.toolStripStatusLabel1.Image = CType(resources.GetObject("toolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(75, 17)
        Me.toolStripStatusLabel1.Text = "扫描人员:"
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
        Me.statusStrip1.Size = New System.Drawing.Size(991, 22)
        Me.statusStrip1.TabIndex = 135
        Me.statusStrip1.Text = "statusStrip1"
        '
        'FrmSetScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 549)
        Me.Controls.Add(Me.DGridBarCode)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Name = "FrmSetScan"
        Me.Text = "配套扫描"
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblCurrQty As System.Windows.Forms.Label
    Friend WithEvents LblChildSetQty As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGridBarCode As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LblChildFinishQty As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblMainBarCode As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtChildPNQty As System.Windows.Forms.Label
    Friend WithEvents txtPVersion As System.Windows.Forms.Label
    Friend WithEvents TxtPartid As System.Windows.Forms.Label
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents TxtMoId As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents LblBarName As System.Windows.Forms.Label
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents LabResult As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolUsename As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TxtBarCode As ULControls.textBoxUL
    Friend WithEvents txtPackBarcode As ULControls.textBoxUL
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblChildPN As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkUnfinish As System.Windows.Forms.CheckBox
    Friend WithEvents TxtFinishQty As System.Windows.Forms.Label
    Private WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtMOQty As System.Windows.Forms.Label
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtLineID As System.Windows.Forms.Label
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents ToolGroupMaintain As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblWeek As System.Windows.Forms.Label
End Class
