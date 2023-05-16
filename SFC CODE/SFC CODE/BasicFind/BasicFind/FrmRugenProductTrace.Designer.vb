<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRugenProductTrace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRugenProductTrace))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolReflsh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolLotQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBarCode = New System.Windows.Forms.TextBox()
        Me.DgData = New System.Windows.Forms.DataGridView()
        Me.DgDataDetail = New System.Windows.Forms.DataGridView()
        Me.colPartid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLotid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPartdes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCustPart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPpartid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStationid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colintime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PCBASN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MACAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LaserSN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Test1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Test2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Test3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stationid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stationname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lineid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DgData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgDataDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolReflsh, Me.ToolStripSeparator2, Me.ToolExcel, Me.ToolLotQuery, Me.ToolStripSeparator3, Me.ToolExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(-6, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1084, 24)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 143
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 24)
        '
        'ToolReflsh
        '
        Me.ToolReflsh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolReflsh.Image = CType(resources.GetObject("ToolReflsh.Image"), System.Drawing.Image)
        Me.ToolReflsh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReflsh.Name = "ToolReflsh"
        Me.ToolReflsh.Size = New System.Drawing.Size(63, 21)
        Me.ToolReflsh.Text = "刷    新"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 24)
        '
        'ToolExcel
        '
        Me.ToolExcel.Image = CType(resources.GetObject("ToolExcel.Image"), System.Drawing.Image)
        Me.ToolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExcel.Name = "ToolExcel"
        Me.ToolExcel.Size = New System.Drawing.Size(64, 21)
        Me.ToolExcel.Text = "汇   出"
        Me.ToolExcel.Visible = False
        '
        'ToolLotQuery
        '
        Me.ToolLotQuery.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolLotQuery.Image = CType(resources.GetObject("ToolLotQuery.Image"), System.Drawing.Image)
        Me.ToolLotQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLotQuery.Name = "ToolLotQuery"
        Me.ToolLotQuery.Size = New System.Drawing.Size(75, 21)
        Me.ToolLotQuery.Text = "物料追踪"
        Me.ToolLotQuery.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 24)
        '
        'ToolExit
        '
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(68, 21)
        Me.ToolExit.Text = "退    出"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txtBarCode)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 27)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(956, 68)
        Me.GroupBox5.TabIndex = 144
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "查询条件"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(317, 31)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(335, 12)
        Me.Label20.TabIndex = 106
        Me.Label20.Text = "查询条件请输入：rugen产品PCB编号或者MacAdress或者镭雕码"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "产品编号："
        '
        'txtBarCode
        '
        Me.txtBarCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtBarCode.Location = New System.Drawing.Point(86, 25)
        Me.txtBarCode.Name = "txtBarCode"
        Me.txtBarCode.Size = New System.Drawing.Size(217, 21)
        Me.txtBarCode.TabIndex = 75
        '
        'DgData
        '
        Me.DgData.AllowUserToAddRows = False
        Me.DgData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DgData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgData.BackgroundColor = System.Drawing.Color.White
        Me.DgData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PCBASN, Me.MACAddress, Me.LaserSN, Me.Intime, Me.result, Me.Test1, Me.Test2, Me.Test3, Me.Stationid, Me.Stationname, Me.Moid, Me.partid, Me.lineid})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgData.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgData.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgData.Location = New System.Drawing.Point(3, 33)
        Me.DgData.MultiSelect = False
        Me.DgData.Name = "DgData"
        Me.DgData.ReadOnly = True
        Me.DgData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgData.RowHeadersWidth = 4
        Me.DgData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgData.RowTemplate.Height = 24
        Me.DgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgData.ShowEditingIcon = False
        Me.DgData.Size = New System.Drawing.Size(697, 330)
        Me.DgData.TabIndex = 172
        Me.DgData.TabStop = False
        '
        'DgDataDetail
        '
        Me.DgDataDetail.AllowUserToAddRows = False
        Me.DgDataDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue
        Me.DgDataDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DgDataDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgDataDetail.BackgroundColor = System.Drawing.Color.White
        Me.DgDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgDataDetail.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgDataDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgDataDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DgDataDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPartid, Me.colLotid, Me.colPartdes, Me.colCustPart, Me.colMoid, Me.colPpartid, Me.colStationid, Me.colUserID, Me.colintime})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgDataDetail.DefaultCellStyle = DataGridViewCellStyle6
        Me.DgDataDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgDataDetail.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgDataDetail.Location = New System.Drawing.Point(3, 33)
        Me.DgDataDetail.MultiSelect = False
        Me.DgDataDetail.Name = "DgDataDetail"
        Me.DgDataDetail.ReadOnly = True
        Me.DgDataDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgDataDetail.RowHeadersWidth = 4
        Me.DgDataDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgDataDetail.RowTemplate.Height = 24
        Me.DgDataDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgDataDetail.ShowEditingIcon = False
        Me.DgDataDetail.Size = New System.Drawing.Size(245, 330)
        Me.DgDataDetail.TabIndex = 187
        Me.DgDataDetail.TabStop = False
        '
        'colPartid
        '
        Me.colPartid.DataPropertyName = "Partid"
        Me.colPartid.HeaderText = "料号"
        Me.colPartid.Name = "colPartid"
        Me.colPartid.ReadOnly = True
        '
        'colLotid
        '
        Me.colLotid.DataPropertyName = "Lotid"
        Me.colLotid.HeaderText = "批次号"
        Me.colLotid.Name = "colLotid"
        Me.colLotid.ReadOnly = True
        '
        'colPartdes
        '
        Me.colPartdes.DataPropertyName = "Partdes"
        Me.colPartdes.HeaderText = "物料描述"
        Me.colPartdes.Name = "colPartdes"
        Me.colPartdes.ReadOnly = True
        '
        'colCustPart
        '
        Me.colCustPart.DataPropertyName = "CustPart"
        Me.colCustPart.HeaderText = "客户料号"
        Me.colCustPart.Name = "colCustPart"
        Me.colCustPart.ReadOnly = True
        Me.colCustPart.Width = 70
        '
        'colMoid
        '
        Me.colMoid.DataPropertyName = "Moid"
        Me.colMoid.HeaderText = "工单编号"
        Me.colMoid.Name = "colMoid"
        Me.colMoid.ReadOnly = True
        '
        'colPpartid
        '
        Me.colPpartid.DataPropertyName = "Ppartid"
        Me.colPpartid.HeaderText = "工单料号"
        Me.colPpartid.Name = "colPpartid"
        Me.colPpartid.ReadOnly = True
        '
        'colStationid
        '
        Me.colStationid.DataPropertyName = "Stationid"
        Me.colStationid.HeaderText = "上料工站"
        Me.colStationid.Name = "colStationid"
        Me.colStationid.ReadOnly = True
        Me.colStationid.Width = 70
        '
        'colUserID
        '
        Me.colUserID.DataPropertyName = "UserID"
        Me.colUserID.HeaderText = "上料人"
        Me.colUserID.Name = "colUserID"
        Me.colUserID.ReadOnly = True
        '
        'colintime
        '
        Me.colintime.DataPropertyName = "intime"
        Me.colintime.HeaderText = "上料时间"
        Me.colintime.Name = "colintime"
        Me.colintime.ReadOnly = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 101)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgData)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgDataDetail)
        Me.SplitContainer1.Size = New System.Drawing.Size(956, 365)
        Me.SplitContainer1.SplitterDistance = 703
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 188
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "产品作业轨迹："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 188
        Me.Label2.Text = "工单上料明细："
        '
        'PCBASN
        '
        Me.PCBASN.DataPropertyName = "PCBASN"
        Me.PCBASN.HeaderText = "PCBA SN"
        Me.PCBASN.Name = "PCBASN"
        Me.PCBASN.ReadOnly = True
        '
        'MACAddress
        '
        Me.MACAddress.DataPropertyName = "MACAddress"
        Me.MACAddress.HeaderText = "MACAddress"
        Me.MACAddress.Name = "MACAddress"
        Me.MACAddress.ReadOnly = True
        Me.MACAddress.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MACAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LaserSN
        '
        Me.LaserSN.DataPropertyName = "LaserSN"
        Me.LaserSN.HeaderText = "镭雕SN"
        Me.LaserSN.Name = "LaserSN"
        Me.LaserSN.ReadOnly = True
        Me.LaserSN.Width = 90
        '
        'Intime
        '
        Me.Intime.DataPropertyName = "Intime"
        Me.Intime.HeaderText = "作业时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'result
        '
        Me.result.DataPropertyName = "result"
        Me.result.HeaderText = "测试结果"
        Me.result.Name = "result"
        Me.result.ReadOnly = True
        Me.result.Width = 80
        '
        'Test1
        '
        Me.Test1.DataPropertyName = "Test1"
        Me.Test1.HeaderText = "测试1"
        Me.Test1.Name = "Test1"
        Me.Test1.ReadOnly = True
        Me.Test1.Width = 80
        '
        'Test2
        '
        Me.Test2.DataPropertyName = "Test2"
        Me.Test2.HeaderText = "测试2"
        Me.Test2.Name = "Test2"
        Me.Test2.ReadOnly = True
        Me.Test2.Width = 80
        '
        'Test3
        '
        Me.Test3.DataPropertyName = "Test3"
        Me.Test3.HeaderText = "测试3"
        Me.Test3.Name = "Test3"
        Me.Test3.ReadOnly = True
        Me.Test3.Width = 80
        '
        'Stationid
        '
        Me.Stationid.DataPropertyName = "Stationid"
        Me.Stationid.HeaderText = "工站编号"
        Me.Stationid.Name = "Stationid"
        Me.Stationid.ReadOnly = True
        Me.Stationid.Width = 80
        '
        'Stationname
        '
        Me.Stationname.DataPropertyName = "Stationname"
        Me.Stationname.HeaderText = "工站名称"
        Me.Stationname.Name = "Stationname"
        Me.Stationname.ReadOnly = True
        Me.Stationname.Width = 80
        '
        'Moid
        '
        Me.Moid.DataPropertyName = "Moid"
        Me.Moid.HeaderText = "工单编号"
        Me.Moid.Name = "Moid"
        Me.Moid.ReadOnly = True
        Me.Moid.Width = 110
        '
        'partid
        '
        Me.partid.DataPropertyName = "partid"
        Me.partid.HeaderText = "料件编号"
        Me.partid.Name = "partid"
        Me.partid.ReadOnly = True
        '
        'lineid
        '
        Me.lineid.DataPropertyName = "teamid"
        Me.lineid.HeaderText = "产线别"
        Me.lineid.Name = "lineid"
        Me.lineid.ReadOnly = True
        '
        'FrmRugenProductTrace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 472)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmRugenProductTrace"
        Me.Text = "Rugen产品追溯"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DgData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgDataDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolReflsh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBarCode As System.Windows.Forms.TextBox
    Friend WithEvents DgData As System.Windows.Forms.DataGridView
    Friend WithEvents ToolLotQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents DgDataDetail As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents colPartid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLotid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartdes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCustPart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPpartid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStationid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colintime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCBASN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MACAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LaserSN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents result As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Test1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Test2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Test3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stationid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stationname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lineid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
