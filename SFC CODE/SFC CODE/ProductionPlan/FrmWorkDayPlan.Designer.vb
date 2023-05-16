<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWorkDayPlan
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWorkDayPlan))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CboUsey = New System.Windows.Forms.ComboBox()
        Me.chkusey = New System.Windows.Forms.CheckBox()
        Me.txtPlanDay = New System.Windows.Forms.DateTimePicker()
        Me.CboLine = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CboDept = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtMoid = New System.Windows.Forms.TextBox()
        Me.LabWorkNo = New System.Windows.Forms.Label()
        Me.txtDt2 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDt1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DGOrder = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolKanban = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.Pager1 = New SysBasicClass.Pager()
        Me.bindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.RowId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanDay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustPartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SWorkHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Deptid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lineid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanQty1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanQty2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanQty3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanQty4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanQty5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quorum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStrip1.SuspendLayout()
        Me.Pager1.SuspendLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.CboUsey)
        Me.GroupBox1.Controls.Add(Me.chkusey)
        Me.GroupBox1.Controls.Add(Me.txtPlanDay)
        Me.GroupBox1.Controls.Add(Me.CboLine)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.CboDept)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtMoid)
        Me.GroupBox1.Controls.Add(Me.LabWorkNo)
        Me.GroupBox1.Controls.Add(Me.txtDt2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDt1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtUserId)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1209, 80)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "查询条件"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(473, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "启用状态:"
        '
        'CboUsey
        '
        Me.CboUsey.FormattingEnabled = True
        Me.CboUsey.Items.AddRange(New Object() {"ALL", "Y-启用", "N-作废"})
        Me.CboUsey.Location = New System.Drawing.Point(536, 49)
        Me.CboUsey.Name = "CboUsey"
        Me.CboUsey.Size = New System.Drawing.Size(126, 20)
        Me.CboUsey.TabIndex = 119
        '
        'chkusey
        '
        Me.chkusey.AutoSize = True
        Me.chkusey.Checked = True
        Me.chkusey.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkusey.Location = New System.Drawing.Point(792, 49)
        Me.chkusey.Name = "chkusey"
        Me.chkusey.Size = New System.Drawing.Size(72, 16)
        Me.chkusey.TabIndex = 118
        Me.chkusey.Text = "启用状态"
        Me.chkusey.UseVisualStyleBackColor = True
        '
        'txtPlanDay
        '
        Me.txtPlanDay.Location = New System.Drawing.Point(536, 21)
        Me.txtPlanDay.Name = "txtPlanDay"
        Me.txtPlanDay.Size = New System.Drawing.Size(126, 21)
        Me.txtPlanDay.TabIndex = 117
        '
        'CboLine
        '
        Me.CboLine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboLine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboLine.FormattingEnabled = True
        Me.CboLine.Location = New System.Drawing.Point(307, 23)
        Me.CboLine.Name = "CboLine"
        Me.CboLine.Size = New System.Drawing.Size(160, 20)
        Me.CboLine.TabIndex = 115
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(244, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "生产线别:"
        '
        'CboDept
        '
        Me.CboDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboDept.FormattingEnabled = True
        Me.CboDept.Location = New System.Drawing.Point(77, 22)
        Me.CboDept.Name = "CboDept"
        Me.CboDept.Size = New System.Drawing.Size(160, 20)
        Me.CboDept.TabIndex = 113
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "生产部门:"
        '
        'TxtMoid
        '
        Me.TxtMoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMoid.Location = New System.Drawing.Point(738, 20)
        Me.TxtMoid.Name = "TxtMoid"
        Me.TxtMoid.Size = New System.Drawing.Size(126, 21)
        Me.TxtMoid.TabIndex = 107
        '
        'LabWorkNo
        '
        Me.LabWorkNo.AutoSize = True
        Me.LabWorkNo.Location = New System.Drawing.Point(676, 25)
        Me.LabWorkNo.Name = "LabWorkNo"
        Me.LabWorkNo.Size = New System.Drawing.Size(59, 12)
        Me.LabWorkNo.TabIndex = 108
        Me.LabWorkNo.Text = "工单编号:"
        '
        'txtDt2
        '
        Me.txtDt2.Location = New System.Drawing.Point(307, 48)
        Me.txtDt2.Name = "txtDt2"
        Me.txtDt2.Size = New System.Drawing.Size(160, 21)
        Me.txtDt2.TabIndex = 106
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(261, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "~~"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDt1
        '
        Me.txtDt1.Location = New System.Drawing.Point(77, 48)
        Me.txtDt1.Name = "txtDt1"
        Me.txtDt1.Size = New System.Drawing.Size(160, 21)
        Me.txtDt1.TabIndex = 104
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "创建日期:"
        '
        'txtUserId
        '
        Me.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserId.Location = New System.Drawing.Point(927, 20)
        Me.txtUserId.Name = "txtUserId"
        Me.txtUserId.Size = New System.Drawing.Size(126, 21)
        Me.txtUserId.TabIndex = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(877, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "创建人:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(473, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "计划日期:"
        '
        'DGOrder
        '
        Me.DGOrder.AllowUserToAddRows = False
        Me.DGOrder.AllowUserToDeleteRows = False
        Me.DGOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGOrder.ColumnHeadersHeight = 25
        Me.DGOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowId, Me.PlanDay, Me.Moid, Me.PartID, Me.CustPartID, Me.SWorkHours, Me.Deptid, Me.Lineid, Me.PlanQty1, Me.PlanQty2, Me.PlanQty3, Me.PlanQty4, Me.PlanQty5, Me.Quorum, Me.UserID, Me.Intime, Me.usey, Me.id})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGOrder.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGOrder.EnableHeadersVisualStyles = False
        Me.DGOrder.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.DGOrder.Location = New System.Drawing.Point(6, 115)
        Me.DGOrder.Name = "DGOrder"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGOrder.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGOrder.RowHeadersWidth = 20
        Me.DGOrder.RowTemplate.Height = 23
        Me.DGOrder.Size = New System.Drawing.Size(1209, 292)
        Me.DGOrder.TabIndex = 128
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.toolAbandon, Me.toolStripSeparator4, Me.toolQuery, Me.ToolKanban, Me.ToolStripSeparator2, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(1, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1222, 28)
        Me.toolStrip1.TabIndex = 19
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 25)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 25)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(73, 25)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "作 废(&D)"
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 25)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolKanban
        '
        Me.ToolKanban.Image = CType(resources.GetObject("ToolKanban.Image"), System.Drawing.Image)
        Me.ToolKanban.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolKanban.Name = "ToolKanban"
        Me.ToolKanban.Size = New System.Drawing.Size(68, 25)
        Me.ToolKanban.Tag = ""
        Me.ToolKanban.Text = "看板(&K)"
        Me.ToolKanban.ToolTipText = "提交"
        Me.ToolKanban.Visible = False
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 25)
        Me.toolExit.Text = "退 出(&X)"
        '
        'Pager1
        '
        Me.Pager1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pager1.Controls.Add(Me.bindingNavigator)
        Me.Pager1.ExportAllDataToXls = True
        Me.Pager1.ExportPageDataToXls = True
        Me.Pager1.Location = New System.Drawing.Point(1, 408)
        Me.Pager1.Name = "Pager1"
        Me.Pager1.NMax = 0
        Me.Pager1.PageCount = 0
        Me.Pager1.PageCurrent = 0
        Me.Pager1.PageSize = 20
        Me.Pager1.QuerySeconds = 0.0R
        Me.Pager1.Size = New System.Drawing.Size(1353, 30)
        Me.Pager1.TabIndex = 129
        '
        'bindingNavigator
        '
        Me.bindingNavigator.AddNewItem = Nothing
        Me.bindingNavigator.BackColor = System.Drawing.Color.Transparent
        Me.bindingNavigator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.bindingNavigator.CountItem = Nothing
        Me.bindingNavigator.DeleteItem = Nothing
        Me.bindingNavigator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bindingNavigator.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.bindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.bindingNavigator.MoveFirstItem = Nothing
        Me.bindingNavigator.MoveLastItem = Nothing
        Me.bindingNavigator.MoveNextItem = Nothing
        Me.bindingNavigator.MovePreviousItem = Nothing
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.Padding = New System.Windows.Forms.Padding(0)
        Me.bindingNavigator.PositionItem = Nothing
        Me.bindingNavigator.Size = New System.Drawing.Size(1353, 30)
        Me.bindingNavigator.TabIndex = 0
        Me.bindingNavigator.Text = "bindingNavigator1"
        '
        'RowId
        '
        Me.RowId.DataPropertyName = "RowId"
        Me.RowId.Frozen = True
        Me.RowId.HeaderText = "序号"
        Me.RowId.Name = "RowId"
        Me.RowId.ReadOnly = True
        Me.RowId.Width = 60
        '
        'PlanDay
        '
        Me.PlanDay.DataPropertyName = "PlanDay"
        Me.PlanDay.HeaderText = "计划日期"
        Me.PlanDay.Name = "PlanDay"
        Me.PlanDay.ReadOnly = True
        '
        'Moid
        '
        Me.Moid.DataPropertyName = "Moid"
        Me.Moid.HeaderText = "工单编号"
        Me.Moid.Name = "Moid"
        Me.Moid.ReadOnly = True
        '
        'PartID
        '
        Me.PartID.DataPropertyName = "PartID"
        Me.PartID.HeaderText = "立讯料号"
        Me.PartID.Name = "PartID"
        '
        'CustPartID
        '
        Me.CustPartID.DataPropertyName = "CustPartID"
        Me.CustPartID.HeaderText = "客户料号"
        Me.CustPartID.Name = "CustPartID"
        '
        'SWorkHours
        '
        Me.SWorkHours.DataPropertyName = "SWorkHours"
        Me.SWorkHours.HeaderText = "标准工时"
        Me.SWorkHours.Name = "SWorkHours"
        '
        'Deptid
        '
        Me.Deptid.DataPropertyName = "Deptid"
        Me.Deptid.HeaderText = "部门编号"
        Me.Deptid.Name = "Deptid"
        Me.Deptid.ReadOnly = True
        '
        'Lineid
        '
        Me.Lineid.DataPropertyName = "Lineid"
        Me.Lineid.HeaderText = "线别编号"
        Me.Lineid.Name = "Lineid"
        Me.Lineid.ReadOnly = True
        '
        'PlanQty1
        '
        Me.PlanQty1.DataPropertyName = "PlanQty1"
        Me.PlanQty1.HeaderText = "第一节"
        Me.PlanQty1.Name = "PlanQty1"
        Me.PlanQty1.ReadOnly = True
        '
        'PlanQty2
        '
        Me.PlanQty2.DataPropertyName = "PlanQty2"
        Me.PlanQty2.HeaderText = "第二节"
        Me.PlanQty2.Name = "PlanQty2"
        '
        'PlanQty3
        '
        Me.PlanQty3.DataPropertyName = "PlanQty3"
        Me.PlanQty3.HeaderText = "第三节"
        Me.PlanQty3.Name = "PlanQty3"
        '
        'PlanQty4
        '
        Me.PlanQty4.DataPropertyName = "PlanQty4"
        Me.PlanQty4.HeaderText = "第四节"
        Me.PlanQty4.Name = "PlanQty4"
        '
        'PlanQty5
        '
        Me.PlanQty5.DataPropertyName = "PlanQty5"
        Me.PlanQty5.HeaderText = "第五节"
        Me.PlanQty5.Name = "PlanQty5"
        '
        'Quorum
        '
        Me.Quorum.DataPropertyName = "Quorum"
        Me.Quorum.HeaderText = "出勤人数"
        Me.Quorum.Name = "Quorum"
        Me.Quorum.ReadOnly = True
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "创建人"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.DataPropertyName = "Intime"
        Me.Intime.HeaderText = "创建时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'usey
        '
        Me.usey.DataPropertyName = "Usey"
        Me.usey.HeaderText = "启用状态"
        Me.usey.Name = "usey"
        Me.usey.ReadOnly = True
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'FrmWorkDayPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 440)
        Me.Controls.Add(Me.Pager1)
        Me.Controls.Add(Me.DGOrder)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmWorkDayPlan"
        Me.ShowIcon = False
        Me.Text = "生产日计划"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.Pager1.ResumeLayout(False)
        Me.Pager1.PerformLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGOrder As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Pager1 As SysBasicClass.Pager
    Friend WithEvents bindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents txtUserId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDt1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDt2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMoid As System.Windows.Forms.TextBox
    Friend WithEvents LabWorkNo As System.Windows.Forms.Label
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents CboLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPlanDay As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkusey As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CboUsey As System.Windows.Forms.ComboBox
    Friend WithEvents ToolKanban As System.Windows.Forms.ToolStripButton
    Friend WithEvents RowId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanDay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustPartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SWorkHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deptid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lineid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanQty1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanQty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanQty3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanQty4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanQty5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quorum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
