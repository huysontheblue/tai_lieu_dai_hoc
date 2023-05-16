<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWareHouseOutDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWareHouseOutDetail))
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle58 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle59 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle60 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle56 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle57 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle61 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle62 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle67 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle68 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle63 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle64 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle65 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolDeleteCartonid = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.GbSelect = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.txtInvOut = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCartonid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gridView = New System.Windows.Forms.DataGridView()
        Me.Outwhid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CarType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsFullCarton = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsFinish = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridViewD = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cartonidColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'toolDeleteCartonid
        '
        Me.toolDeleteCartonid.Enabled = False
        Me.toolDeleteCartonid.Image = CType(resources.GetObject("toolDeleteCartonid.Image"), System.Drawing.Image)
        Me.toolDeleteCartonid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDeleteCartonid.Name = "toolDeleteCartonid"
        Me.toolDeleteCartonid.Size = New System.Drawing.Size(100, 21)
        Me.toolDeleteCartonid.Text = "删除整箱数据"
        Me.toolDeleteCartonid.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 24)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 24)
        '
        'GbSelect
        '
        Me.GbSelect.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbSelect.Controls.Add(Me.txtVersion)
        Me.GbSelect.Controls.Add(Me.Label4)
        Me.GbSelect.Controls.Add(Me.Label5)
        Me.GbSelect.Controls.Add(Me.txtProNo)
        Me.GbSelect.Controls.Add(Me.Label2)
        Me.GbSelect.Controls.Add(Me.txtLotNo)
        Me.GbSelect.Controls.Add(Me.txtInvOut)
        Me.GbSelect.Controls.Add(Me.Label3)
        Me.GbSelect.Controls.Add(Me.txtCartonid)
        Me.GbSelect.Controls.Add(Me.Label1)
        Me.GbSelect.Location = New System.Drawing.Point(0, 24)
        Me.GbSelect.Name = "GbSelect"
        Me.GbSelect.Size = New System.Drawing.Size(1184, 65)
        Me.GbSelect.TabIndex = 13
        Me.GbSelect.TabStop = False
        Me.GbSelect.Text = "查询条件"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(561, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 17)
        Me.Label5.TabIndex = 227
        Me.Label5.Text = "料号:"
        '
        'txtProNo
        '
        Me.txtProNo.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtProNo.Location = New System.Drawing.Point(600, 22)
        Me.txtProNo.Name = "txtProNo"
        Me.txtProNo.Size = New System.Drawing.Size(147, 21)
        Me.txtProNo.TabIndex = 226
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(771, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 17)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "批次:"
        '
        'txtLotNo
        '
        Me.txtLotNo.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtLotNo.Location = New System.Drawing.Point(812, 22)
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(97, 21)
        Me.txtLotNo.TabIndex = 223
        '
        'txtInvOut
        '
        Me.txtInvOut.Location = New System.Drawing.Point(90, 22)
        Me.txtInvOut.Name = "txtInvOut"
        Me.txtInvOut.Size = New System.Drawing.Size(120, 21)
        Me.txtInvOut.TabIndex = 221
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(20, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "出货单号："
        '
        'txtCartonid
        '
        Me.txtCartonid.Location = New System.Drawing.Point(282, 22)
        Me.txtCartonid.Name = "txtCartonid"
        Me.txtCartonid.Size = New System.Drawing.Size(261, 21)
        Me.txtCartonid.TabIndex = 217
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(216, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 216
        Me.Label1.Text = "外箱条码："
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 95)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridView)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridViewD)
        Me.SplitContainer1.Size = New System.Drawing.Size(1184, 415)
        Me.SplitContainer1.SplitterDistance = 652
        Me.SplitContainer1.TabIndex = 15
        '
        'gridView
        '
        Me.gridView.AllowUserToAddRows = False
        Me.gridView.AllowUserToDeleteRows = False
        Me.gridView.AllowUserToResizeRows = False
        DataGridViewCellStyle52.BackColor = System.Drawing.Color.AliceBlue
        Me.gridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle52
        Me.gridView.BackgroundColor = System.Drawing.Color.White
        Me.gridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle53.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle53.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle53.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle53.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle53
        Me.gridView.ColumnHeadersHeight = 24
        Me.gridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Outwhid, Me.ProNo, Me.LotNo, Me.Version, Me.CarType, Me.LineName, Me.Code, Me.Qty, Me.IsFullCarton, Me.IsFinish})
        DataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle58.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle58.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle58.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle58.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle58.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridView.DefaultCellStyle = DataGridViewCellStyle58
        Me.gridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridView.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.gridView.Location = New System.Drawing.Point(0, 0)
        Me.gridView.MultiSelect = False
        Me.gridView.Name = "gridView"
        Me.gridView.ReadOnly = True
        Me.gridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle59.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle59
        Me.gridView.RowHeadersWidth = 35
        DataGridViewCellStyle60.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle60.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle60.SelectionForeColor = System.Drawing.Color.White
        Me.gridView.RowsDefaultCellStyle = DataGridViewCellStyle60
        Me.gridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gridView.RowTemplate.Height = 24
        Me.gridView.ShowEditingIcon = False
        Me.gridView.Size = New System.Drawing.Size(652, 415)
        Me.gridView.TabIndex = 12
        Me.gridView.TabStop = False
        '
        'Outwhid
        '
        Me.Outwhid.DataPropertyName = "Outwhid"
        Me.Outwhid.HeaderText = "Outwhid"
        Me.Outwhid.Name = "Outwhid"
        Me.Outwhid.ReadOnly = True
        Me.Outwhid.Visible = False
        '
        'ProNo
        '
        Me.ProNo.DataPropertyName = "ProNo"
        Me.ProNo.HeaderText = "线束型号"
        Me.ProNo.Name = "ProNo"
        Me.ProNo.ReadOnly = True
        '
        'LotNo
        '
        Me.LotNo.DataPropertyName = "LotNo"
        DataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LotNo.DefaultCellStyle = DataGridViewCellStyle54
        Me.LotNo.HeaderText = "批次"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        Me.LotNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LotNo.Width = 80
        '
        'Version
        '
        Me.Version.DataPropertyName = "Version"
        DataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Version.DefaultCellStyle = DataGridViewCellStyle55
        Me.Version.HeaderText = "设变号"
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
        Me.Version.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Version.Width = 80
        '
        'CarType
        '
        Me.CarType.DataPropertyName = "CarType"
        Me.CarType.HeaderText = "车型"
        Me.CarType.Name = "CarType"
        Me.CarType.ReadOnly = True
        '
        'LineName
        '
        Me.LineName.DataPropertyName = "LineName"
        Me.LineName.HeaderText = "线束名称"
        Me.LineName.Name = "LineName"
        Me.LineName.ReadOnly = True
        '
        'Code
        '
        Me.Code.DataPropertyName = "Code"
        Me.Code.HeaderText = "简码"
        Me.Code.Name = "Code"
        Me.Code.ReadOnly = True
        Me.Code.Width = 60
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        DataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle56.Format = "N0"
        DataGridViewCellStyle56.NullValue = Nothing
        DataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Qty.DefaultCellStyle = DataGridViewCellStyle56
        Me.Qty.HeaderText = "出库数量"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Qty.Width = 70
        '
        'IsFullCarton
        '
        Me.IsFullCarton.DataPropertyName = "IsFullCarton"
        Me.IsFullCarton.HeaderText = "是否整箱"
        Me.IsFullCarton.Name = "IsFullCarton"
        Me.IsFullCarton.ReadOnly = True
        '
        'IsFinish
        '
        Me.IsFinish.DataPropertyName = "IsFinish"
        DataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsFinish.DefaultCellStyle = DataGridViewCellStyle57
        Me.IsFinish.HeaderText = "状态"
        Me.IsFinish.Name = "IsFinish"
        Me.IsFinish.ReadOnly = True
        Me.IsFinish.Visible = False
        Me.IsFinish.Width = 70
        '
        'gridViewD
        '
        Me.gridViewD.AllowUserToAddRows = False
        Me.gridViewD.AllowUserToDeleteRows = False
        Me.gridViewD.AllowUserToResizeRows = False
        DataGridViewCellStyle61.BackColor = System.Drawing.Color.AliceBlue
        Me.gridViewD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle61
        Me.gridViewD.BackgroundColor = System.Drawing.Color.White
        Me.gridViewD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridViewD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle62.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle62.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle62.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle62.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle62.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle62.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridViewD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle62
        Me.gridViewD.ColumnHeadersHeight = 24
        Me.gridViewD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.cartonidColumn, Me.Qty2, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        DataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle66.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle66.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle66.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle66.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle66.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle66.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridViewD.DefaultCellStyle = DataGridViewCellStyle66
        Me.gridViewD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridViewD.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.gridViewD.Location = New System.Drawing.Point(0, 0)
        Me.gridViewD.MultiSelect = False
        Me.gridViewD.Name = "gridViewD"
        Me.gridViewD.ReadOnly = True
        Me.gridViewD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle67.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle67.Font = New System.Drawing.Font("PMingLiU", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle67.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle67.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle67.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridViewD.RowHeadersDefaultCellStyle = DataGridViewCellStyle67
        Me.gridViewD.RowHeadersWidth = 35
        DataGridViewCellStyle68.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle68.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle68.SelectionForeColor = System.Drawing.Color.White
        Me.gridViewD.RowsDefaultCellStyle = DataGridViewCellStyle68
        Me.gridViewD.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.gridViewD.RowTemplate.Height = 24
        Me.gridViewD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.gridViewD.ShowEditingIcon = False
        Me.gridViewD.Size = New System.Drawing.Size(528, 415)
        Me.gridViewD.TabIndex = 13
        Me.gridViewD.TabStop = False
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "序号"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 50
        '
        'cartonidColumn
        '
        Me.cartonidColumn.DataPropertyName = "cartonid"
        DataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cartonidColumn.DefaultCellStyle = DataGridViewCellStyle63
        Me.cartonidColumn.HeaderText = "外箱编号"
        Me.cartonidColumn.Name = "cartonidColumn"
        Me.cartonidColumn.ReadOnly = True
        Me.cartonidColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cartonidColumn.Width = 130
        '
        'Qty2
        '
        Me.Qty2.DataPropertyName = "Qty"
        Me.Qty2.HeaderText = "出库数量"
        Me.Qty2.Name = "Qty2"
        Me.Qty2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Userid"
        DataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle64.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle64
        Me.DataGridViewTextBoxColumn7.HeaderText = "出库人员"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Intime"
        DataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle65.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle65
        Me.DataGridViewTextBoxColumn8.HeaderText = "出库时间"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'txtVersion
        '
        Me.txtVersion.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.txtVersion.Location = New System.Drawing.Point(985, 21)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(97, 21)
        Me.txtVersion.TabIndex = 228
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(929, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 229
        Me.Label4.Text = "设变号："
        '
        'FrmWareHouseOutDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 512)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.GbSelect)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmWareHouseOutDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "出货明细查询"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GbSelect.ResumeLayout(False)
        Me.GbSelect.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridViewD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolDeleteCartonid As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GbSelect As System.Windows.Forms.GroupBox
    Friend WithEvents txtInvOut As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCartonid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gridView As System.Windows.Forms.DataGridView
    Friend WithEvents gridViewD As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProNo As System.Windows.Forms.TextBox
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Outwhid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Version As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsFullCarton As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsFinish As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cartonidColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
