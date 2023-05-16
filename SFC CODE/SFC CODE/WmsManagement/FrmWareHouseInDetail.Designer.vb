<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseInDetail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWareHouseInDetail))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.GbSelect = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCartonId = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProNo = New System.Windows.Forms.TextBox()
        Me.txtMoid = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gridView = New System.Windows.Forms.DataGridView()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.gridViewD = New System.Windows.Forms.DataGridView()
        Me.chkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cartonidColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolDeleteCartonid = New System.Windows.Forms.ToolStripButton()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.finishqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.st = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.GbSelect.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridViewD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolQuery, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.toolDeleteCartonid, Me.ToolStripSeparator4, Me.btnExit, Me.ToolStripSeparator5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 24)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 13
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 24)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 24)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 24)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 24)
        '
        'GbSelect
        '
        Me.GbSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbSelect.Controls.Add(Me.Label1)
        Me.GbSelect.Controls.Add(Me.txtCartonId)
        Me.GbSelect.Controls.Add(Me.Label5)
        Me.GbSelect.Controls.Add(Me.txtProNo)
        Me.GbSelect.Controls.Add(Me.txtMoid)
        Me.GbSelect.Controls.Add(Me.Label3)
        Me.GbSelect.Location = New System.Drawing.Point(0, 25)
        Me.GbSelect.Name = "GbSelect"
        Me.GbSelect.Size = New System.Drawing.Size(1184, 65)
        Me.GbSelect.TabIndex = 14
        Me.GbSelect.TabStop = False
        Me.GbSelect.Text = "查询条件"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(439, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 17)
        Me.Label1.TabIndex = 229
        Me.Label1.Text = "箱号:"
        '
        'txtCartonId
        '
        Me.txtCartonId.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtCartonId.Location = New System.Drawing.Point(478, 21)
        Me.txtCartonId.Name = "txtCartonId"
        Me.txtCartonId.Size = New System.Drawing.Size(296, 21)
        Me.txtCartonId.TabIndex = 228
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(235, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 17)
        Me.Label5.TabIndex = 227
        Me.Label5.Text = "料号:"
        '
        'txtProNo
        '
        Me.txtProNo.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtProNo.Location = New System.Drawing.Point(274, 22)
        Me.txtProNo.Name = "txtProNo"
        Me.txtProNo.Size = New System.Drawing.Size(147, 21)
        Me.txtProNo.TabIndex = 226
        '
        'txtMoid
        '
        Me.txtMoid.Location = New System.Drawing.Point(90, 22)
        Me.txtMoid.Name = "txtMoid"
        Me.txtMoid.Size = New System.Drawing.Size(120, 21)
        Me.txtMoid.TabIndex = 221
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(20, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "工单号："
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 96)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkAll)
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridViewD)
        Me.SplitContainer1.Size = New System.Drawing.Size(1184, 415)
        Me.SplitContainer1.SplitterDistance = 521
        Me.SplitContainer1.TabIndex = 16
        '
        'gridView
        '
        Me.gridView.AllowUserToAddRows = False
        Me.gridView.AllowUserToDeleteRows = False
        Me.gridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.gridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridView.BackgroundColor = System.Drawing.Color.White
        Me.gridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridView.ColumnHeadersHeight = 24
        Me.gridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.moid, Me.partid, Me.finishqty, Me.Moqty, Me.st})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridView.DefaultCellStyle = DataGridViewCellStyle7
        Me.gridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridView.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.gridView.Location = New System.Drawing.Point(0, 0)
        Me.gridView.MultiSelect = False
        Me.gridView.Name = "gridView"
        Me.gridView.ReadOnly = True
        Me.gridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.gridView.RowHeadersWidth = 35
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        Me.gridView.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.gridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gridView.RowTemplate.Height = 24
        Me.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridView.ShowEditingIcon = False
        Me.gridView.Size = New System.Drawing.Size(521, 415)
        Me.gridView.TabIndex = 13
        Me.gridView.TabStop = False
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(40, 5)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(15, 14)
        Me.chkAll.TabIndex = 14
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'gridViewD
        '
        Me.gridViewD.AllowUserToAddRows = False
        Me.gridViewD.AllowUserToDeleteRows = False
        Me.gridViewD.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue
        Me.gridViewD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.gridViewD.BackgroundColor = System.Drawing.Color.White
        Me.gridViewD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridViewD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle11.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridViewD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.gridViewD.ColumnHeadersHeight = 24
        Me.gridViewD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkSelect, Me.cartonidColumn, Me.Qty2, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridViewD.DefaultCellStyle = DataGridViewCellStyle15
        Me.gridViewD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridViewD.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.gridViewD.Location = New System.Drawing.Point(0, 0)
        Me.gridViewD.MultiSelect = False
        Me.gridViewD.Name = "gridViewD"
        Me.gridViewD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridViewD.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.gridViewD.RowHeadersWidth = 35
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.White
        Me.gridViewD.RowsDefaultCellStyle = DataGridViewCellStyle17
        Me.gridViewD.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gridViewD.RowTemplate.Height = 24
        Me.gridViewD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridViewD.ShowEditingIcon = False
        Me.gridViewD.Size = New System.Drawing.Size(659, 415)
        Me.gridViewD.TabIndex = 13
        Me.gridViewD.TabStop = False
        '
        'chkSelect
        '
        Me.chkSelect.HeaderText = ""
        Me.chkSelect.Name = "chkSelect"
        Me.chkSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.chkSelect.Width = 60
        '
        'cartonidColumn
        '
        Me.cartonidColumn.DataPropertyName = "cartonid"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cartonidColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.cartonidColumn.HeaderText = "外箱编号"
        Me.cartonidColumn.Name = "cartonidColumn"
        Me.cartonidColumn.ReadOnly = True
        Me.cartonidColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cartonidColumn.Width = 130
        '
        'Qty2
        '
        Me.Qty2.DataPropertyName = "Qty"
        Me.Qty2.HeaderText = "入库数量"
        Me.Qty2.Name = "Qty2"
        Me.Qty2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "InUserId"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn7.HeaderText = "入库人员"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "inintime"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn8.HeaderText = "入库时间"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'toolQuery
        '
        Me.toolQuery.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(85, 21)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'toolDeleteCartonid
        '
        Me.toolDeleteCartonid.Image = CType(resources.GetObject("toolDeleteCartonid.Image"), System.Drawing.Image)
        Me.toolDeleteCartonid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDeleteCartonid.Name = "toolDeleteCartonid"
        Me.toolDeleteCartonid.Size = New System.Drawing.Size(100, 21)
        Me.toolDeleteCartonid.Text = "删除入库数据"
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 21)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'moid
        '
        Me.moid.DataPropertyName = "moid"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.moid.DefaultCellStyle = DataGridViewCellStyle3
        Me.moid.HeaderText = "工单编号"
        Me.moid.Name = "moid"
        Me.moid.ReadOnly = True
        Me.moid.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.moid.Width = 120
        '
        'partid
        '
        Me.partid.DataPropertyName = "partid"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.partid.DefaultCellStyle = DataGridViewCellStyle4
        Me.partid.HeaderText = "产品料号"
        Me.partid.Name = "partid"
        Me.partid.ReadOnly = True
        Me.partid.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.partid.Width = 120
        '
        'finishqty
        '
        Me.finishqty.DataPropertyName = "finishqty"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.finishqty.DefaultCellStyle = DataGridViewCellStyle5
        Me.finishqty.HeaderText = "已装数量"
        Me.finishqty.Name = "finishqty"
        Me.finishqty.ReadOnly = True
        Me.finishqty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.finishqty.Width = 70
        '
        'Moqty
        '
        Me.Moqty.DataPropertyName = "Moqty"
        Me.Moqty.HeaderText = "应装数量"
        Me.Moqty.Name = "Moqty"
        Me.Moqty.ReadOnly = True
        Me.Moqty.Width = 70
        '
        'st
        '
        Me.st.DataPropertyName = "st"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.st.DefaultCellStyle = DataGridViewCellStyle6
        Me.st.HeaderText = "状态"
        Me.st.Name = "st"
        Me.st.ReadOnly = True
        Me.st.Width = 70
        '
        'FrmWareHouseInDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 512)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.GbSelect)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmWareHouseInDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "入库明细记录"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GbSelect.ResumeLayout(False)
        Me.GbSelect.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridViewD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolDeleteCartonid As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GbSelect As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMoid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gridViewD As System.Windows.Forms.DataGridView
    Friend WithEvents gridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCartonId As System.Windows.Forms.TextBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cartonidColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents finishqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
