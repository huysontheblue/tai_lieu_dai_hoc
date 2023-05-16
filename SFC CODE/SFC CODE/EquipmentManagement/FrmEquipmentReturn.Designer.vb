<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEquipmentReturn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEquipmentReturn))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.toolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiBatchIn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cboRequestClass = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.ComboBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.txtHardWarePartNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoError = New System.Windows.Forms.RadioButton()
        Me.rdoRight = New System.Windows.Forms.RadioButton()
        Me.chkNeedKeyInResult = New System.Windows.Forms.CheckBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEquipment = New System.Windows.Forms.TextBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.dgvReturn = New System.Windows.Forms.DataGridView()
        Me.ChkItem = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RequestID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipmentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessParameters = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HardWarePartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Receiver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Storage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Checker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolRefresh, Me.ToolStripSeparator7, Me.tsmiBatchIn, Me.ToolStripSeparator1, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1710, 29)
        Me.ToolBt.TabIndex = 137
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'toolRefresh
        '
        Me.toolRefresh.Image = CType(resources.GetObject("toolRefresh.Image"), System.Drawing.Image)
        Me.toolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolRefresh.Name = "toolRefresh"
        Me.toolRefresh.Size = New System.Drawing.Size(152, 26)
        Me.toolRefresh.Text = "Làm mới 刷 新(&R)"
        Me.toolRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 29)
        '
        'tsmiBatchIn
        '
        Me.tsmiBatchIn.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsmiBatchIn.Name = "tsmiBatchIn"
        Me.tsmiBatchIn.Size = New System.Drawing.Size(215, 26)
        Me.tsmiBatchIn.Text = "Nhập kho hàng loạt批量入库"
        Me.tsmiBatchIn.ToolTipText = "刷新"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(129, 26)
        Me.btnExit.Text = "Thoát退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 29)
        Me.splitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.cboRequestClass)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtRemark)
        Me.splitContainer1.Panel1.Controls.Add(Me.BtnSearch)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtHardWarePartNumber)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.splitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.splitContainer1.Panel1.Controls.Add(Me.chkNeedKeyInResult)
        Me.splitContainer1.Panel1.Controls.Add(Me.lblInfo)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtLine)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtEquipment)
        Me.splitContainer1.Panel1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.chkAll)
        Me.splitContainer1.Panel2.Controls.Add(Me.dgvReturn)
        Me.splitContainer1.Size = New System.Drawing.Size(1710, 549)
        Me.splitContainer1.SplitterDistance = 106
        Me.splitContainer1.SplitterWidth = 5
        Me.splitContainer1.TabIndex = 138
        '
        'cboRequestClass
        '
        Me.cboRequestClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRequestClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRequestClass.Font = New System.Drawing.Font("SimSun", 9.0!)
        Me.cboRequestClass.FormattingEnabled = True
        Me.cboRequestClass.Location = New System.Drawing.Point(1171, 53)
        Me.cboRequestClass.Margin = New System.Windows.Forms.Padding(4)
        Me.cboRequestClass.Name = "cboRequestClass"
        Me.cboRequestClass.Size = New System.Drawing.Size(207, 23)
        Me.cboRequestClass.TabIndex = 233
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1029, 46)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 34)
        Me.Label5.TabIndex = 231
        Me.Label5.Text = "Đơn vị phụ trách" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "责任单位:"
        '
        'txtRemark
        '
        Me.txtRemark.FormattingEnabled = True
        Me.txtRemark.Items.AddRange(New Object() {"自然磨损", "员工操作不档,压坏", "断线", "其它"})
        Me.txtRemark.Location = New System.Drawing.Point(1154, 5)
        Me.txtRemark.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(246, 25)
        Me.txtRemark.TabIndex = 230
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearch.Location = New System.Drawing.Point(444, 65)
        Me.BtnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(147, 29)
        Me.BtnSearch.TabIndex = 229
        Me.BtnSearch.Text = "Tìm Kiếm查询"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'txtHardWarePartNumber
        '
        Me.txtHardWarePartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHardWarePartNumber.Location = New System.Drawing.Point(120, 65)
        Me.txtHardWarePartNumber.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHardWarePartNumber.Name = "txtHardWarePartNumber"
        Me.txtHardWarePartNumber.Size = New System.Drawing.Size(316, 25)
        Me.txtHardWarePartNumber.TabIndex = 228
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 64)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 34)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "Mã liệu ngũ kim" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "五金料号:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1029, 8)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 34)
        Me.Label2.TabIndex = 225
        Me.Label2.Text = "Chú ý nhập kho" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "入库备注:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoError)
        Me.GroupBox1.Controls.Add(Me.rdoRight)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(283, 8)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(330, 53)
        Me.GroupBox1.TabIndex = 224
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Đã hoàn thành chưa?是否完好"
        '
        'rdoError
        '
        Me.rdoError.AutoSize = True
        Me.rdoError.Location = New System.Drawing.Point(178, 26)
        Me.rdoError.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoError.Name = "rdoError"
        Me.rdoError.Size = New System.Drawing.Size(112, 21)
        Me.rdoError.TabIndex = 3
        Me.rdoError.TabStop = True
        Me.rdoError.Text = "Hư hỏng损坏"
        Me.rdoError.UseVisualStyleBackColor = True
        '
        'rdoRight
        '
        Me.rdoRight.AutoSize = True
        Me.rdoRight.Location = New System.Drawing.Point(8, 26)
        Me.rdoRight.Margin = New System.Windows.Forms.Padding(4)
        Me.rdoRight.Name = "rdoRight"
        Me.rdoRight.Size = New System.Drawing.Size(138, 21)
        Me.rdoRight.TabIndex = 2
        Me.rdoRight.TabStop = True
        Me.rdoRight.Text = "Bình Thường正常"
        Me.rdoRight.UseVisualStyleBackColor = True
        '
        'chkNeedKeyInResult
        '
        Me.chkNeedKeyInResult.AutoSize = True
        Me.chkNeedKeyInResult.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNeedKeyInResult.Location = New System.Drawing.Point(13, 8)
        Me.chkNeedKeyInResult.Margin = New System.Windows.Forms.Padding(4)
        Me.chkNeedKeyInResult.Name = "chkNeedKeyInResult"
        Me.chkNeedKeyInResult.Size = New System.Drawing.Size(252, 38)
        Me.chkNeedKeyInResult.TabIndex = 221
        Me.chkNeedKeyInResult.Text = "Nhập vào trả về đã hoàn thành chưa?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "录入归还是否完好"
        Me.chkNeedKeyInResult.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.ForeColor = System.Drawing.Color.Green
        Me.lblInfo.Location = New System.Drawing.Point(1006, 15)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(13, 17)
        Me.lblInfo.TabIndex = 220
        Me.lblInfo.Text = "-"
        '
        'txtLine
        '
        Me.txtLine.Location = New System.Drawing.Point(873, 65)
        Me.txtLine.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(64, 25)
        Me.txtLine.TabIndex = 14
        Me.txtLine.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(678, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 34)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Nhập kho theo mã chuyền" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "按线别入库:"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(631, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 34)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Mã công cụ" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "工治具编号:"
        '
        'txtEquipment
        '
        Me.txtEquipment.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEquipment.Location = New System.Drawing.Point(730, 8)
        Me.txtEquipment.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEquipment.Name = "txtEquipment"
        Me.txtEquipment.Size = New System.Drawing.Size(268, 34)
        Me.txtEquipment.TabIndex = 11
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(66, 4)
        Me.chkAll.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(18, 17)
        Me.chkAll.TabIndex = 139
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'dgvReturn
        '
        Me.dgvReturn.AllowUserToAddRows = False
        Me.dgvReturn.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvReturn.ColumnHeadersHeight = 28
        Me.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvReturn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChkItem, Me.RequestID, Me.EquipmentNo, Me.ProcessParameters, Me.HardWarePartNumber, Me.Receiver, Me.Line, Me.Storage, Me.Checker, Me.OutTime})
        Me.dgvReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReturn.Location = New System.Drawing.Point(0, 0)
        Me.dgvReturn.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvReturn.Name = "dgvReturn"
        Me.dgvReturn.RowTemplate.Height = 23
        Me.dgvReturn.Size = New System.Drawing.Size(1710, 438)
        Me.dgvReturn.TabIndex = 138
        '
        'ChkItem
        '
        Me.ChkItem.FalseValue = "False"
        Me.ChkItem.HeaderText = ""
        Me.ChkItem.Name = "ChkItem"
        Me.ChkItem.TrueValue = "True"
        Me.ChkItem.Width = 30
        '
        'RequestID
        '
        Me.RequestID.DataPropertyName = "RequestID"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RequestID.DefaultCellStyle = DataGridViewCellStyle1
        Me.RequestID.HeaderText = "Đơn xin đăng ký申请单号"
        Me.RequestID.MinimumWidth = 20
        Me.RequestID.Name = "RequestID"
        Me.RequestID.Width = 150
        '
        'EquipmentNo
        '
        Me.EquipmentNo.DataPropertyName = "EquipmentNo"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EquipmentNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.EquipmentNo.HeaderText = "Mã công cụ工治具编号"
        Me.EquipmentNo.MinimumWidth = 20
        Me.EquipmentNo.Name = "EquipmentNo"
        Me.EquipmentNo.Width = 150
        '
        'ProcessParameters
        '
        Me.ProcessParameters.DataPropertyName = "ProcessParameters"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProcessParameters.DefaultCellStyle = DataGridViewCellStyle3
        Me.ProcessParameters.HeaderText = "Thông số gia công加工参数"
        Me.ProcessParameters.MinimumWidth = 20
        Me.ProcessParameters.Name = "ProcessParameters"
        Me.ProcessParameters.Width = 210
        '
        'HardWarePartNumber
        '
        Me.HardWarePartNumber.DataPropertyName = "HardWarePartNumber"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HardWarePartNumber.DefaultCellStyle = DataGridViewCellStyle4
        Me.HardWarePartNumber.HeaderText = "Mã liệu ngũ kim五金料号"
        Me.HardWarePartNumber.MinimumWidth = 20
        Me.HardWarePartNumber.Name = "HardWarePartNumber"
        Me.HardWarePartNumber.Width = 150
        '
        'Receiver
        '
        Me.Receiver.DataPropertyName = "Receiver"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Receiver.DefaultCellStyle = DataGridViewCellStyle5
        Me.Receiver.HeaderText = "Người mượn借出人"
        Me.Receiver.MinimumWidth = 20
        Me.Receiver.Name = "Receiver"
        Me.Receiver.Width = 130
        '
        'Line
        '
        Me.Line.DataPropertyName = "Line"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line.DefaultCellStyle = DataGridViewCellStyle6
        Me.Line.HeaderText = "Chuyền mượn借出线别"
        Me.Line.MinimumWidth = 20
        Me.Line.Name = "Line"
        Me.Line.Width = 150
        '
        'Storage
        '
        Me.Storage.DataPropertyName = "Storage"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Storage.DefaultCellStyle = DataGridViewCellStyle7
        Me.Storage.HeaderText = "Kho lưu trữ仓库储位"
        Me.Storage.MinimumWidth = 20
        Me.Storage.Name = "Storage"
        Me.Storage.Width = 160
        '
        'Checker
        '
        Me.Checker.DataPropertyName = "Checker"
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Checker.DefaultCellStyle = DataGridViewCellStyle8
        Me.Checker.HeaderText = "Nhân viên kỹ thuật生技人员"
        Me.Checker.MinimumWidth = 20
        Me.Checker.Name = "Checker"
        Me.Checker.Width = 220
        '
        'OutTime
        '
        Me.OutTime.DataPropertyName = "OutTime"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutTime.DefaultCellStyle = DataGridViewCellStyle9
        Me.OutTime.DividerWidth = 20
        Me.OutTime.HeaderText = "Thời gian mượn借出时间"
        Me.OutTime.MinimumWidth = 20
        Me.OutTime.Name = "OutTime"
        Me.OutTime.Width = 200
        '
        'FrmEquipmentReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1710, 578)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmEquipmentReturn"
        Me.Text = "Nhập kho Thiết bị - Công cụ工治具-设备入库"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.Panel2.PerformLayout()
        Me.splitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents toolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtLine As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEquipment As System.Windows.Forms.TextBox
    Friend WithEvents dgvReturn As System.Windows.Forms.DataGridView
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents chkNeedKeyInResult As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoError As System.Windows.Forms.RadioButton
    Friend WithEvents rdoRight As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHardWarePartNumber As System.Windows.Forms.TextBox
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents tsmiBatchIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtRemark As System.Windows.Forms.ComboBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboRequestClass As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChkItem As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RequestID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipmentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessParameters As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HardWarePartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Receiver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Storage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Checker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
