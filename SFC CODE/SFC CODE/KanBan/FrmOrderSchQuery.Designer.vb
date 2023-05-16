<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrderSchQuery
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrderSchQuery))
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.txtOrderSeq = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgOrder = New System.Windows.Forms.DataGridView()
        Me.colCusid1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCusName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeriesID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeriesName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colORDERNO1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderseq1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPartID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colmoqty1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProQty1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutQty1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colScheFinishDate1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.lblMoid = New System.Windows.Forms.Label()
        Me.dgMoid = New System.Windows.Forms.DataGridView()
        Me.colORDERNO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMoid2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLINENAME2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTELPHONE2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colleaderid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblChildMoid = New System.Windows.Forms.Label()
        Me.dgDetail = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLINENAME3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTELPHONE3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colleaderid2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDetail = New System.Windows.Forms.ToolStripButton()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgMoid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Location = New System.Drawing.Point(76, 11)
        Me.txtOrderNo.MaxLength = 50
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(138, 21)
        Me.txtOrderNo.TabIndex = 188
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "订单编号："
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 46)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMsg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtOrderSeq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtOrderNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1167, 412)
        Me.SplitContainer1.SplitterDistance = 34
        Me.SplitContainer1.TabIndex = 192
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Location = New System.Drawing.Point(477, 18)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 12)
        Me.lblMsg.TabIndex = 218
        '
        'txtOrderSeq
        '
        Me.txtOrderSeq.Location = New System.Drawing.Point(284, 12)
        Me.txtOrderSeq.MaxLength = 50
        Me.txtOrderSeq.Name = "txtOrderSeq"
        Me.txtOrderSeq.Size = New System.Drawing.Size(138, 21)
        Me.txtOrderSeq.TabIndex = 200
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(223, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "订单项次："
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgOrder)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(1167, 374)
        Me.SplitContainer2.SplitterDistance = 160
        Me.SplitContainer2.TabIndex = 0
        '
        'dgOrder
        '
        Me.dgOrder.AllowUserToAddRows = False
        Me.dgOrder.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue
        Me.dgOrder.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgOrder.BackgroundColor = System.Drawing.Color.White
        Me.dgOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgOrder.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgOrder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle11.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCusid1, Me.colCusName, Me.colSeriesID1, Me.colSeriesName, Me.colORDERNO1, Me.colOrderseq1, Me.colPartID1, Me.colmoqty1, Me.colProQty1, Me.colOutQty1, Me.colScheFinishDate1})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOrder.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgOrder.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgOrder.Location = New System.Drawing.Point(0, 0)
        Me.dgOrder.MultiSelect = False
        Me.dgOrder.Name = "dgOrder"
        Me.dgOrder.ReadOnly = True
        Me.dgOrder.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgOrder.RowHeadersWidth = 4
        Me.dgOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgOrder.RowTemplate.Height = 24
        Me.dgOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgOrder.ShowEditingIcon = False
        Me.dgOrder.Size = New System.Drawing.Size(1167, 160)
        Me.dgOrder.TabIndex = 173
        Me.dgOrder.TabStop = False
        '
        'colCusid1
        '
        Me.colCusid1.DataPropertyName = "Cusid"
        Me.colCusid1.HeaderText = "客户ID"
        Me.colCusid1.Name = "colCusid1"
        Me.colCusid1.ReadOnly = True
        Me.colCusid1.Visible = False
        '
        'colCusName
        '
        Me.colCusName.DataPropertyName = "CusName"
        Me.colCusName.HeaderText = "客户"
        Me.colCusName.Name = "colCusName"
        Me.colCusName.ReadOnly = True
        '
        'colSeriesID1
        '
        Me.colSeriesID1.DataPropertyName = "SeriesID"
        Me.colSeriesID1.HeaderText = "系列别ID"
        Me.colSeriesID1.Name = "colSeriesID1"
        Me.colSeriesID1.ReadOnly = True
        Me.colSeriesID1.Visible = False
        '
        'colSeriesName
        '
        Me.colSeriesName.DataPropertyName = "SeriesName"
        Me.colSeriesName.HeaderText = "系列别"
        Me.colSeriesName.Name = "colSeriesName"
        Me.colSeriesName.ReadOnly = True
        '
        'colORDERNO1
        '
        Me.colORDERNO1.DataPropertyName = "ORDERNO"
        Me.colORDERNO1.HeaderText = "订单编号"
        Me.colORDERNO1.Name = "colORDERNO1"
        Me.colORDERNO1.ReadOnly = True
        '
        'colOrderseq1
        '
        Me.colOrderseq1.DataPropertyName = "Orderseq"
        Me.colOrderseq1.HeaderText = "订单项次"
        Me.colOrderseq1.Name = "colOrderseq1"
        Me.colOrderseq1.ReadOnly = True
        '
        'colPartID1
        '
        Me.colPartID1.DataPropertyName = "PartID"
        Me.colPartID1.HeaderText = "料件编号"
        Me.colPartID1.Name = "colPartID1"
        Me.colPartID1.ReadOnly = True
        '
        'colmoqty1
        '
        Me.colmoqty1.DataPropertyName = "moqty"
        Me.colmoqty1.HeaderText = "订单数量"
        Me.colmoqty1.Name = "colmoqty1"
        Me.colmoqty1.ReadOnly = True
        '
        'colProQty1
        '
        Me.colProQty1.DataPropertyName = "ProQty"
        Me.colProQty1.HeaderText = "投入数量"
        Me.colProQty1.Name = "colProQty1"
        Me.colProQty1.ReadOnly = True
        Me.colProQty1.Visible = False
        '
        'colOutQty1
        '
        Me.colOutQty1.DataPropertyName = "OutQty"
        Me.colOutQty1.HeaderText = "包装产出数量"
        Me.colOutQty1.Name = "colOutQty1"
        Me.colOutQty1.ReadOnly = True
        '
        'colScheFinishDate1
        '
        Me.colScheFinishDate1.DataPropertyName = "ScheFinishDate"
        Me.colScheFinishDate1.HeaderText = "预计交货日期"
        Me.colScheFinishDate1.Name = "colScheFinishDate1"
        Me.colScheFinishDate1.ReadOnly = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.lblMoid)
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgMoid)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.lblChildMoid)
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgDetail)
        Me.SplitContainer3.Size = New System.Drawing.Size(1167, 210)
        Me.SplitContainer3.SplitterDistance = 610
        Me.SplitContainer3.TabIndex = 0
        '
        'lblMoid
        '
        Me.lblMoid.AutoSize = True
        Me.lblMoid.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMoid.Location = New System.Drawing.Point(3, 2)
        Me.lblMoid.Name = "lblMoid"
        Me.lblMoid.Size = New System.Drawing.Size(473, 12)
        Me.lblMoid.TabIndex = 190
        Me.lblMoid.Text = "下表显示上表中相同【客户】【系列别】【订单编号】【订单项次】【料件编号】"
        '
        'dgMoid
        '
        Me.dgMoid.AllowUserToAddRows = False
        Me.dgMoid.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.AliceBlue
        Me.dgMoid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgMoid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMoid.BackgroundColor = System.Drawing.Color.White
        Me.dgMoid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgMoid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgMoid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle14.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMoid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgMoid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colORDERNO2, Me.colMoid2, Me.Column20, Me.Column9, Me.Column10, Me.colLINENAME2, Me.colTELPHONE2, Me.Column17, Me.Column14, Me.Column16, Me.Column18, Me.Column15, Me.colleaderid})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMoid.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgMoid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgMoid.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgMoid.Location = New System.Drawing.Point(0, 17)
        Me.dgMoid.MultiSelect = False
        Me.dgMoid.Name = "dgMoid"
        Me.dgMoid.ReadOnly = True
        Me.dgMoid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgMoid.RowHeadersWidth = 4
        Me.dgMoid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgMoid.RowTemplate.Height = 24
        Me.dgMoid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgMoid.ShowEditingIcon = False
        Me.dgMoid.Size = New System.Drawing.Size(610, 193)
        Me.dgMoid.TabIndex = 174
        Me.dgMoid.TabStop = False
        '
        'colORDERNO2
        '
        Me.colORDERNO2.DataPropertyName = "ORDERNO"
        Me.colORDERNO2.HeaderText = "订单编号"
        Me.colORDERNO2.Name = "colORDERNO2"
        Me.colORDERNO2.ReadOnly = True
        '
        'colMoid2
        '
        Me.colMoid2.DataPropertyName = "Moid"
        Me.colMoid2.HeaderText = "工单编号"
        Me.colMoid2.Name = "colMoid2"
        Me.colMoid2.ReadOnly = True
        '
        'Column20
        '
        Me.Column20.DataPropertyName = "PartID"
        Me.Column20.HeaderText = "料件编号"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        Me.Column20.Width = 80
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "Deptid"
        Me.Column9.HeaderText = "生产部门"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 70
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "Lineid"
        Me.Column10.HeaderText = "线别"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 50
        '
        'colLINENAME2
        '
        Me.colLINENAME2.DataPropertyName = "LINENAME"
        Me.colLINENAME2.HeaderText = "线长"
        Me.colLINENAME2.Name = "colLINENAME2"
        Me.colLINENAME2.ReadOnly = True
        Me.colLINENAME2.Width = 50
        '
        'colTELPHONE2
        '
        Me.colTELPHONE2.DataPropertyName = "TELPHONE"
        Me.colTELPHONE2.HeaderText = "线长电话"
        Me.colTELPHONE2.Name = "colTELPHONE2"
        Me.colTELPHONE2.ReadOnly = True
        Me.colTELPHONE2.Width = 80
        '
        'Column17
        '
        Me.Column17.DataPropertyName = "Status"
        Me.Column17.HeaderText = "状态"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 70
        '
        'Column14
        '
        Me.Column14.DataPropertyName = "Moqty"
        Me.Column14.HeaderText = "工单数量"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 70
        '
        'Column16
        '
        Me.Column16.DataPropertyName = "OutQty"
        Me.Column16.HeaderText = "成品包装产出数量"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 107
        '
        'Column18
        '
        Me.Column18.DataPropertyName = "ScheFinishDate"
        Me.Column18.HeaderText = "预计完工日期"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.DataPropertyName = "ProQty"
        Me.Column15.HeaderText = "投入数量"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Visible = False
        Me.Column15.Width = 70
        '
        'colleaderid
        '
        Me.colleaderid.DataPropertyName = "leaderid"
        Me.colleaderid.HeaderText = "leaderid"
        Me.colleaderid.Name = "colleaderid"
        Me.colleaderid.ReadOnly = True
        Me.colleaderid.Visible = False
        '
        'lblChildMoid
        '
        Me.lblChildMoid.AutoSize = True
        Me.lblChildMoid.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblChildMoid.Location = New System.Drawing.Point(3, 2)
        Me.lblChildMoid.Name = "lblChildMoid"
        Me.lblChildMoid.Size = New System.Drawing.Size(213, 12)
        Me.lblChildMoid.TabIndex = 191
        Me.lblChildMoid.Text = "此表显示左边工单编号的子工单数据"
        '
        'dgDetail
        '
        Me.dgDetail.AllowUserToAddRows = False
        Me.dgDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.AliceBlue
        Me.dgDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dgDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDetail.BackgroundColor = System.Drawing.Color.White
        Me.dgDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgDetail.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle17.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.colLINENAME3, Me.colTELPHONE3, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn7, Me.colleaderid2})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDetail.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgDetail.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgDetail.Location = New System.Drawing.Point(0, 17)
        Me.dgDetail.MultiSelect = False
        Me.dgDetail.Name = "dgDetail"
        Me.dgDetail.ReadOnly = True
        Me.dgDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgDetail.RowHeadersWidth = 4
        Me.dgDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgDetail.ShowEditingIcon = False
        Me.dgDetail.Size = New System.Drawing.Size(553, 193)
        Me.dgDetail.TabIndex = 175
        Me.dgDetail.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Moid"
        Me.DataGridViewTextBoxColumn1.HeaderText = "子工单"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PartID"
        Me.DataGridViewTextBoxColumn2.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 85
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "dqc"
        Me.DataGridViewTextBoxColumn3.HeaderText = "生产部门"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 70
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Lineid"
        Me.DataGridViewTextBoxColumn4.HeaderText = "线别"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 50
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Status"
        Me.DataGridViewTextBoxColumn5.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'colLINENAME3
        '
        Me.colLINENAME3.DataPropertyName = "LINENAME"
        Me.colLINENAME3.HeaderText = "线长"
        Me.colLINENAME3.Name = "colLINENAME3"
        Me.colLINENAME3.ReadOnly = True
        Me.colLINENAME3.Width = 50
        '
        'colTELPHONE3
        '
        Me.colTELPHONE3.DataPropertyName = "TELPHONE"
        Me.colTELPHONE3.HeaderText = "线长电话"
        Me.colTELPHONE3.Name = "colTELPHONE3"
        Me.colTELPHONE3.ReadOnly = True
        Me.colTELPHONE3.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Moqty"
        Me.DataGridViewTextBoxColumn6.HeaderText = "工单数量"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "OutQty"
        Me.DataGridViewTextBoxColumn8.HeaderText = "部件包装产出数量"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 107
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "ScheFinishDate"
        Me.DataGridViewTextBoxColumn9.HeaderText = "预计完工日期"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ProQty"
        Me.DataGridViewTextBoxColumn7.HeaderText = "投入数量"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 70
        '
        'colleaderid2
        '
        Me.colleaderid2.DataPropertyName = "leaderid"
        Me.colleaderid2.HeaderText = "leaderid"
        Me.colleaderid2.Name = "colleaderid2"
        Me.colleaderid2.ReadOnly = True
        Me.colleaderid2.Visible = False
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(73, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(81, 22)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolQuery, Me.ToolStripSeparator1, Me.ToolExcel, Me.ToolStripSeparator3, Me.tsbDetail, Me.ToolStripSeparator2, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1167, 25)
        Me.toolStrip1.TabIndex = 189
        Me.toolStrip1.Text = "toolStrip1"
        '
        'ToolExcel
        '
        Me.ToolExcel.Image = CType(resources.GetObject("ToolExcel.Image"), System.Drawing.Image)
        Me.ToolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExcel.Name = "ToolExcel"
        Me.ToolExcel.Size = New System.Drawing.Size(73, 22)
        Me.ToolExcel.Text = "汇出统计"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbDetail
        '
        Me.tsbDetail.Image = CType(resources.GetObject("tsbDetail.Image"), System.Drawing.Image)
        Me.tsbDetail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDetail.Name = "tsbDetail"
        Me.tsbDetail.Size = New System.Drawing.Size(73, 22)
        Me.tsbDetail.Text = "汇出明细"
        '
        'ToolCount
        '
        Me.ToolCount.BackColor = System.Drawing.SystemColors.Control
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(11, 17)
        Me.ToolCount.Text = "0"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel1.Text = "記錄筆數:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 467)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1167, 22)
        Me.StatusStrip1.TabIndex = 191
        Me.StatusStrip1.Text = "StatusStrip1"
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
        'menuStrip1
        '
        Me.menuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(119, Byte), Integer))
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, Me.toolStripMenuItem2, Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5, Me.toolStripMenuItem6})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1167, 24)
        Me.menuStrip1.TabIndex = 190
        Me.menuStrip1.Text = "menuStrip1"
        '
        'FrmOrderSchQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 489)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "FrmOrderSchQuery"
        Me.Text = "订单生产进度查询"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgMoid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents txtOrderSeq As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgOrder As System.Windows.Forms.DataGridView
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbDetail As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgMoid As System.Windows.Forms.DataGridView
    Friend WithEvents dgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents colCusid1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCusName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeriesID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeriesName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colORDERNO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderseq1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPartID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colmoqty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProQty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOutQty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colScheFinishDate1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMoid As System.Windows.Forms.Label
    Friend WithEvents lblChildMoid As System.Windows.Forms.Label
    Private WithEvents toolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents colORDERNO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMoid2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLINENAME2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTELPHONE2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colleaderid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLINENAME3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTELPHONE3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colleaderid2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
