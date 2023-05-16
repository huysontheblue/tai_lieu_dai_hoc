<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEquipmentBorrow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEquipmentBorrow))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Toolmaintain = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiBatchOut = New System.Windows.Forms.ToolStripButton()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRequestTime = New System.Windows.Forms.TextBox()
        Me.label23 = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEquipment = New System.Windows.Forms.TextBox()
        Me.txtQueryUserId = New System.Windows.Forms.TextBox()
        Me.txtQueryEquPN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtQueryPn = New System.Windows.Forms.TextBox()
        Me.cboQueryClass = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtQueryMo = New System.Windows.Forms.TextBox()
        Me.cboQueryLine = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgvMOID = New System.Windows.Forms.DataGridView()
        Me.dgvEquipment = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AppUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipmentPNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RequestTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkItem = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EquipmentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessParameters = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Storage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FactoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Profitcenter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.splitContainer2.Panel1.SuspendLayout()
        Me.splitContainer2.Panel2.SuspendLayout()
        Me.splitContainer2.SuspendLayout()
        CType(Me.dgvMOID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!)
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator7, Me.toolQuery, Me.toolStripSeparator1, Me.Toolmaintain, Me.ToolStripSeparator2, Me.tsmiBatchOut, Me.btnExit, Me.ToolStripSeparator3})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1597, 38)
        Me.ToolBt.TabIndex = 135
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 38)
        '
        'toolQuery
        '
        Me.toolQuery.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(208, 35)
        Me.toolQuery.Text = "Tìm kiếm查  询(&F)"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'Toolmaintain
        '
        Me.Toolmaintain.Image = CType(resources.GetObject("Toolmaintain.Image"), System.Drawing.Image)
        Me.Toolmaintain.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Toolmaintain.Name = "Toolmaintain"
        Me.Toolmaintain.Size = New System.Drawing.Size(336, 35)
        Me.Toolmaintain.Text = "Hoàn thành bảo dưỡng保养完成"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'tsmiBatchOut
        '
        Me.tsmiBatchOut.ImageTransparentColor = System.Drawing.Color.White
        Me.tsmiBatchOut.Name = "tsmiBatchOut"
        Me.tsmiBatchOut.Size = New System.Drawing.Size(277, 35)
        Me.tsmiBatchOut.Text = "Xuất kho hàng loạt批量出库"
        Me.tsmiBatchOut.ToolTipText = "退出"
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(163, 35)
        Me.btnExit.Text = "Thoát退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 38)
        Me.splitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.groupBox1)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtQueryUserId)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtQueryEquPN)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.splitContainer1.Panel1.Controls.Add(Me.label17)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtQueryPn)
        Me.splitContainer1.Panel1.Controls.Add(Me.cboQueryClass)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtQueryMo)
        Me.splitContainer1.Panel1.Controls.Add(Me.cboQueryLine)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label6)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.splitContainer2)
        Me.splitContainer1.Size = New System.Drawing.Size(1597, 702)
        Me.splitContainer1.SplitterDistance = 82
        Me.splitContainer1.SplitterWidth = 5
        Me.splitContainer1.TabIndex = 136
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.txtRequestTime)
        Me.groupBox1.Controls.Add(Me.label23)
        Me.groupBox1.Controls.Add(Me.label22)
        Me.groupBox1.Controls.Add(Me.lblMessage)
        Me.groupBox1.Controls.Add(Me.Label1)
        Me.groupBox1.Controls.Add(Me.Label2)
        Me.groupBox1.Controls.Add(Me.txtEquipment)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.groupBox1.Location = New System.Drawing.Point(0, -38)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox1.Size = New System.Drawing.Size(1597, 120)
        Me.groupBox1.TabIndex = 181
        Me.groupBox1.TabStop = False
        '
        'txtRequestTime
        '
        Me.txtRequestTime.BackColor = System.Drawing.SystemColors.Control
        Me.txtRequestTime.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequestTime.Location = New System.Drawing.Point(804, 86)
        Me.txtRequestTime.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRequestTime.Name = "txtRequestTime"
        Me.txtRequestTime.Size = New System.Drawing.Size(45, 22)
        Me.txtRequestTime.TabIndex = 145
        Me.txtRequestTime.Text = "120"
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label23.Location = New System.Drawing.Point(857, 78)
        Me.label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(490, 32)
        Me.label23.TabIndex = 144
        Me.label23.Text = "min chưa mượn hiển thị bên trái là màu hồng phấn, đã mượn thì bên phải là màu xám" & _
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "min  左未借出显示为粉红色，右已借出的为灰色"
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label22.Location = New System.Drawing.Point(660, 82)
        Me.label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(136, 32)
        Me.label22.TabIndex = 143
        Me.label22.Text = "Thời gian xin vượt quá" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 申请超过"
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("SimSun", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblMessage.ForeColor = System.Drawing.Color.Green
        Me.lblMessage.Location = New System.Drawing.Point(823, 52)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 22)
        Me.lblMessage.TabIndex = 142
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 32)
        Me.Label1.TabIndex = 141
        Me.Label1.Text = "Mã công cụ/Mã người nhận" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "工治具编号/接收人工号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(111, 86)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(363, 32)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Nhắc nhở: Quẹt mã công cụ trước rồi mới quẹt mã người nhận" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "提示：请先刷工治具编号，再刷接收人工号。"
        '
        'txtEquipment
        '
        Me.txtEquipment.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtEquipment.Location = New System.Drawing.Point(275, 44)
        Me.txtEquipment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtEquipment.Name = "txtEquipment"
        Me.txtEquipment.Size = New System.Drawing.Size(479, 30)
        Me.txtEquipment.TabIndex = 139
        '
        'txtQueryUserId
        '
        Me.txtQueryUserId.BackColor = System.Drawing.SystemColors.Window
        Me.txtQueryUserId.Location = New System.Drawing.Point(128, 12)
        Me.txtQueryUserId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtQueryUserId.Name = "txtQueryUserId"
        Me.txtQueryUserId.Size = New System.Drawing.Size(105, 25)
        Me.txtQueryUserId.TabIndex = 170
        '
        'txtQueryEquPN
        '
        Me.txtQueryEquPN.Location = New System.Drawing.Point(1375, 11)
        Me.txtQueryEquPN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtQueryEquPN.Name = "txtQueryEquPN"
        Me.txtQueryEquPN.Size = New System.Drawing.Size(164, 25)
        Me.txtQueryEquPN.TabIndex = 180
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(32, 16)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 15)
        Me.Label5.TabIndex = 169
        Me.Label5.Text = "申请人工号:"
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label17.Location = New System.Drawing.Point(1276, 15)
        Me.label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(90, 15)
        Me.label17.TabIndex = 179
        Me.label17.Text = "工治具料号:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(252, 16)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 15)
        Me.Label12.TabIndex = 171
        Me.Label12.Text = "课别:"
        '
        'txtQueryPn
        '
        Me.txtQueryPn.Location = New System.Drawing.Point(1088, 11)
        Me.txtQueryPn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtQueryPn.Name = "txtQueryPn"
        Me.txtQueryPn.Size = New System.Drawing.Size(176, 25)
        Me.txtQueryPn.TabIndex = 178
        '
        'cboQueryClass
        '
        Me.cboQueryClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQueryClass.FormattingEnabled = True
        Me.cboQueryClass.Location = New System.Drawing.Point(301, 12)
        Me.cboQueryClass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboQueryClass.Name = "cboQueryClass"
        Me.cboQueryClass.Size = New System.Drawing.Size(208, 23)
        Me.cboQueryClass.TabIndex = 172
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(1007, 15)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 15)
        Me.Label11.TabIndex = 177
        Me.Label11.Text = "产品料号:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(527, 16)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 15)
        Me.Label13.TabIndex = 173
        Me.Label13.Text = "线别:"
        '
        'txtQueryMo
        '
        Me.txtQueryMo.Location = New System.Drawing.Point(804, 11)
        Me.txtQueryMo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtQueryMo.Name = "txtQueryMo"
        Me.txtQueryMo.Size = New System.Drawing.Size(183, 25)
        Me.txtQueryMo.TabIndex = 176
        '
        'cboQueryLine
        '
        Me.cboQueryLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQueryLine.FormattingEnabled = True
        Me.cboQueryLine.Location = New System.Drawing.Point(577, 14)
        Me.cboQueryLine.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboQueryLine.Name = "cboQueryLine"
        Me.cboQueryLine.Size = New System.Drawing.Size(132, 23)
        Me.cboQueryLine.TabIndex = 174
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(724, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 15)
        Me.Label6.TabIndex = 175
        Me.Label6.Text = "工单编号:"
        '
        'splitContainer2
        '
        Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.splitContainer2.Name = "splitContainer2"
        '
        'splitContainer2.Panel1
        '
        Me.splitContainer2.Panel1.Controls.Add(Me.dgvMOID)
        '
        'splitContainer2.Panel2
        '
        Me.splitContainer2.Panel2.Controls.Add(Me.dgvEquipment)
        Me.splitContainer2.Size = New System.Drawing.Size(1597, 615)
        Me.splitContainer2.SplitterDistance = 833
        Me.splitContainer2.SplitterWidth = 5
        Me.splitContainer2.TabIndex = 0
        '
        'dgvMOID
        '
        Me.dgvMOID.AllowUserToAddRows = False
        Me.dgvMOID.AllowUserToDeleteRows = False
        Me.dgvMOID.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvMOID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMOID.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.AppUserName, Me.MOID, Me.PNumber, Me.EquipmentPNumber, Me.Qty, Me.Line, Me.InTime, Me.Remark, Me.RequestTime})
        Me.dgvMOID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMOID.Location = New System.Drawing.Point(0, 0)
        Me.dgvMOID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvMOID.MultiSelect = False
        Me.dgvMOID.Name = "dgvMOID"
        Me.dgvMOID.ReadOnly = True
        Me.dgvMOID.RowTemplate.Height = 23
        Me.dgvMOID.Size = New System.Drawing.Size(833, 615)
        Me.dgvMOID.TabIndex = 157
        '
        'dgvEquipment
        '
        Me.dgvEquipment.AllowUserToAddRows = False
        Me.dgvEquipment.AllowUserToDeleteRows = False
        Me.dgvEquipment.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquipment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkItem, Me.EquipmentNo, Me.ProcessParameters, Me.Storage, Me.colLine, Me.FactoryName, Me.Profitcenter, Me.InOut})
        Me.dgvEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEquipment.Location = New System.Drawing.Point(0, 0)
        Me.dgvEquipment.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvEquipment.Name = "dgvEquipment"
        Me.dgvEquipment.ReadOnly = True
        Me.dgvEquipment.RowHeadersVisible = False
        Me.dgvEquipment.RowTemplate.Height = 23
        Me.dgvEquipment.Size = New System.Drawing.Size(759, 615)
        Me.dgvEquipment.TabIndex = 157
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 50
        '
        'AppUserName
        '
        Me.AppUserName.FillWeight = 70.0!
        Me.AppUserName.HeaderText = "Người đăng ký 申请人"
        Me.AppUserName.Name = "AppUserName"
        Me.AppUserName.ReadOnly = True
        Me.AppUserName.Width = 70
        '
        'MOID
        '
        Me.MOID.FillWeight = 90.0!
        Me.MOID.HeaderText = "Mã công đơn工单号"
        Me.MOID.Name = "MOID"
        Me.MOID.ReadOnly = True
        '
        'PNumber
        '
        Me.PNumber.FillWeight = 80.0!
        Me.PNumber.HeaderText = "Mã liệu sản phẩm产品料号"
        Me.PNumber.Name = "PNumber"
        Me.PNumber.ReadOnly = True
        Me.PNumber.Width = 80
        '
        'EquipmentPNumber
        '
        Me.EquipmentPNumber.FillWeight = 90.0!
        Me.EquipmentPNumber.HeaderText = "Mã liệu công cụ工治具料号"
        Me.EquipmentPNumber.Name = "EquipmentPNumber"
        Me.EquipmentPNumber.ReadOnly = True
        '
        'Qty
        '
        Me.Qty.FillWeight = 80.0!
        Me.Qty.HeaderText = "Số lượng cần thiết还需数量"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 80
        '
        'Line
        '
        Me.Line.FillWeight = 50.0!
        Me.Line.HeaderText = "Mã chuyền线别"
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        Me.Line.Width = 55
        '
        'InTime
        '
        Me.InTime.FillWeight = 80.0!
        Me.InTime.HeaderText = "Thời gian时间"
        Me.InTime.Name = "InTime"
        Me.InTime.ReadOnly = True
        Me.InTime.Width = 120
        '
        'Remark
        '
        Me.Remark.HeaderText = "Chú ý 备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'RequestTime
        '
        Me.RequestTime.HeaderText = "RequestTime"
        Me.RequestTime.Name = "RequestTime"
        Me.RequestTime.ReadOnly = True
        Me.RequestTime.Visible = False
        '
        'chkItem
        '
        Me.chkItem.FalseValue = "False"
        Me.chkItem.HeaderText = ""
        Me.chkItem.Name = "chkItem"
        Me.chkItem.ReadOnly = True
        Me.chkItem.TrueValue = "True"
        Me.chkItem.Width = 30
        '
        'EquipmentNo
        '
        Me.EquipmentNo.DataPropertyName = "EquipmentNo"
        Me.EquipmentNo.HeaderText = "Mã công cụ 工治具编号"
        Me.EquipmentNo.Name = "EquipmentNo"
        Me.EquipmentNo.ReadOnly = True
        Me.EquipmentNo.Width = 90
        '
        'ProcessParameters
        '
        Me.ProcessParameters.DataPropertyName = "ProcessParameters"
        Me.ProcessParameters.HeaderText = "Tham số gia công加工参数"
        Me.ProcessParameters.Name = "ProcessParameters"
        Me.ProcessParameters.ReadOnly = True
        Me.ProcessParameters.Width = 220
        '
        'Storage
        '
        Me.Storage.DataPropertyName = "Storage"
        Me.Storage.HeaderText = "Vị trí lưu trữ储位"
        Me.Storage.Name = "Storage"
        Me.Storage.ReadOnly = True
        Me.Storage.Width = 60
        '
        'colLine
        '
        Me.colLine.DataPropertyName = "lineid"
        Me.colLine.HeaderText = "Mã chuyền线别"
        Me.colLine.Name = "colLine"
        Me.colLine.ReadOnly = True
        Me.colLine.Width = 60
        '
        'FactoryName
        '
        Me.FactoryName.DataPropertyName = "FactoryName"
        Me.FactoryName.HeaderText = "Nhà xưởng厂区"
        Me.FactoryName.Name = "FactoryName"
        Me.FactoryName.ReadOnly = True
        Me.FactoryName.Width = 60
        '
        'Profitcenter
        '
        Me.Profitcenter.DataPropertyName = "Profitcenter"
        Me.Profitcenter.HeaderText = "Trung tâm lợi nhuận利润中心"
        Me.Profitcenter.Name = "Profitcenter"
        Me.Profitcenter.ReadOnly = True
        Me.Profitcenter.Width = 80
        '
        'InOut
        '
        Me.InOut.DataPropertyName = "InOut"
        Me.InOut.HeaderText = "InOut"
        Me.InOut.Name = "InOut"
        Me.InOut.ReadOnly = True
        Me.InOut.Visible = False
        '
        'FrmEquipmentBorrow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1597, 740)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmEquipmentBorrow"
        Me.Text = "Xuất kho thiết bị - Công cụ工治具-设备出库"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.splitContainer2.Panel1.ResumeLayout(False)
        Me.splitContainer2.Panel2.ResumeLayout(False)
        Me.splitContainer2.ResumeLayout(False)
        CType(Me.dgvMOID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRequestTime As System.Windows.Forms.TextBox
    Friend WithEvents label23 As System.Windows.Forms.Label
    Friend WithEvents label22 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEquipment As System.Windows.Forms.TextBox
    Friend WithEvents txtQueryUserId As System.Windows.Forms.TextBox
    Friend WithEvents txtQueryEquPN As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtQueryPn As System.Windows.Forms.TextBox
    Friend WithEvents cboQueryClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtQueryMo As System.Windows.Forms.TextBox
    Friend WithEvents cboQueryLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents splitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvMOID As System.Windows.Forms.DataGridView
    Friend WithEvents dgvEquipment As System.Windows.Forms.DataGridView
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Toolmaintain As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmiBatchOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AppUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipmentPNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RequestTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkItem As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EquipmentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessParameters As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Storage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FactoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Profitcenter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InOut As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
