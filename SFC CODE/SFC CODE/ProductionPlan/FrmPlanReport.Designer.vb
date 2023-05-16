<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlanReport))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboDept = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txtLineId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.txtPartId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtMOId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.dgvPlanWorkingHours = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.MOid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Specification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeptId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeliveryTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanEndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanStatusFlagText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cboQueryType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.ToolBt.SuspendLayout()
        CType(Me.dgvPlanWorkingHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboDept
        '
        Me.cboDept.DisplayMember = "Text"
        Me.cboDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.ItemHeight = 15
        Me.cboDept.Location = New System.Drawing.Point(483, 51)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(121, 21)
        Me.cboDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboDept.TabIndex = 236
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(435, 51)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 237
        Me.LabelX5.Text = "部门："
        '
        'txtLineId
        '
        '
        '
        '
        Me.txtLineId.Border.Class = "TextBoxBorder"
        Me.txtLineId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLineId.Location = New System.Drawing.Point(483, 92)
        Me.txtLineId.Name = "txtLineId"
        Me.txtLineId.Size = New System.Drawing.Size(120, 21)
        Me.txtLineId.TabIndex = 233
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(435, 92)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 232
        Me.LabelX3.Text = "产线："
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(280, 94)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpEndDate.TabIndex = 231
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(217, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 230
        Me.Label4.Text = "结束日期："
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(280, 51)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpStartDate.TabIndex = 229
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(217, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "开始日期："
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(643, 90)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(486, 23)
        Me.lblMessage.TabIndex = 227
        '
        'txtPartId
        '
        '
        '
        '
        Me.txtPartId.Border.Class = "TextBoxBorder"
        Me.txtPartId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPartId.Location = New System.Drawing.Point(62, 92)
        Me.txtPartId.Name = "txtPartId"
        Me.txtPartId.Size = New System.Drawing.Size(120, 21)
        Me.txtPartId.TabIndex = 226
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(26, 92)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 225
        Me.LabelX2.Text = "料号："
        '
        'txtMOId
        '
        '
        '
        '
        Me.txtMOId.Border.Class = "TextBoxBorder"
        Me.txtMOId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMOId.Location = New System.Drawing.Point(62, 53)
        Me.txtMOId.Name = "txtMOId"
        Me.txtMOId.Size = New System.Drawing.Size(120, 21)
        Me.txtMOId.TabIndex = 224
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(25, 53)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 223
        Me.LabelX1.Text = "工单："
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolDelete, Me.ToolCommit, Me.ToolBack, Me.ToolStripSeparator3, Me.ToolQuery, Me.ToolStripSeparator1, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(892, 25)
        Me.ToolBt.TabIndex = 239
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
        Me.ToolNew.Enabled = False
        Me.ToolNew.ForeColor = System.Drawing.Color.Black
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(74, 22)
        Me.ToolNew.Tag = "NO"
        Me.ToolNew.Text = "新 增(&N)"
        Me.ToolNew.ToolTipText = "新 增"
        '
        'ToolEdit
        '
        Me.ToolEdit.Enabled = False
        Me.ToolEdit.ForeColor = System.Drawing.Color.Black
        Me.ToolEdit.Image = CType(resources.GetObject("ToolEdit.Image"), System.Drawing.Image)
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(71, 22)
        Me.ToolEdit.Tag = "NO"
        Me.ToolEdit.Text = "修 改(&E)"
        Me.ToolEdit.ToolTipText = "修 改"
        '
        'ToolDelete
        '
        Me.ToolDelete.Enabled = False
        Me.ToolDelete.ForeColor = System.Drawing.Color.Black
        Me.ToolDelete.Image = CType(resources.GetObject("ToolDelete.Image"), System.Drawing.Image)
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(73, 22)
        Me.ToolDelete.Tag = "NO"
        Me.ToolDelete.Text = "删 除(&D)"
        Me.ToolDelete.ToolTipText = "删除"
        '
        'ToolCommit
        '
        Me.ToolCommit.Enabled = False
        Me.ToolCommit.Image = CType(resources.GetObject("ToolCommit.Image"), System.Drawing.Image)
        Me.ToolCommit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCommit.Name = "ToolCommit"
        Me.ToolCommit.Size = New System.Drawing.Size(68, 22)
        Me.ToolCommit.Tag = ""
        Me.ToolCommit.Text = "提交(&C)"
        Me.ToolCommit.ToolTipText = "提交"
        '
        'ToolBack
        '
        Me.ToolBack.Enabled = False
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolQuery
        '
        Me.ToolQuery.ForeColor = System.Drawing.Color.Black
        Me.ToolQuery.Image = CType(resources.GetObject("ToolQuery.Image"), System.Drawing.Image)
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(74, 22)
        Me.ToolQuery.Text = "查 询(&Q)"
        Me.ToolQuery.ToolTipText = "查 詢"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExitFrom
        '
        Me.ToolExitFrom.ForeColor = System.Drawing.Color.Black
        Me.ToolExitFrom.Image = CType(resources.GetObject("ToolExitFrom.Image"), System.Drawing.Image)
        Me.ToolExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExitFrom.Name = "ToolExitFrom"
        Me.ToolExitFrom.Size = New System.Drawing.Size(72, 22)
        Me.ToolExitFrom.Text = "退 出(&X)"
        Me.ToolExitFrom.ToolTipText = "退 出"
        '
        'dgvPlanWorkingHours
        '
        Me.dgvPlanWorkingHours.AllowUserToAddRows = False
        Me.dgvPlanWorkingHours.AllowUserToDeleteRows = False
        Me.dgvPlanWorkingHours.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPlanWorkingHours.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPlanWorkingHours.ColumnHeadersHeight = 27
        Me.dgvPlanWorkingHours.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MOid, Me.PartId, Me.Description, Me.Specification, Me.Quantity, Me.CustId, Me.DeptId, Me.LineId, Me.DeliveryTime, Me.PlanStartTime, Me.PlanEndTime, Me.PlanStatusFlagText})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPlanWorkingHours.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPlanWorkingHours.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPlanWorkingHours.EnableHeadersVisualStyles = False
        Me.dgvPlanWorkingHours.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvPlanWorkingHours.Location = New System.Drawing.Point(0, 146)
        Me.dgvPlanWorkingHours.Name = "dgvPlanWorkingHours"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPlanWorkingHours.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPlanWorkingHours.RowHeadersWidth = 15
        Me.dgvPlanWorkingHours.RowTemplate.Height = 23
        Me.dgvPlanWorkingHours.Size = New System.Drawing.Size(892, 320)
        Me.dgvPlanWorkingHours.TabIndex = 240
        '
        'MOid
        '
        Me.MOid.DataPropertyName = "MOid"
        Me.MOid.HeaderText = "工单"
        Me.MOid.Name = "MOid"
        Me.MOid.ReadOnly = True
        '
        'PartId
        '
        Me.PartId.DataPropertyName = "PartId"
        Me.PartId.HeaderText = "料号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "品名"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'Specification
        '
        Me.Specification.DataPropertyName = "Specification"
        Me.Specification.HeaderText = "规格"
        Me.Specification.Name = "Specification"
        Me.Specification.ReadOnly = True
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.HeaderText = "数量"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 60
        '
        'CustId
        '
        Me.CustId.DataPropertyName = "CustId"
        Me.CustId.HeaderText = "客户简称"
        Me.CustId.Name = "CustId"
        Me.CustId.ReadOnly = True
        Me.CustId.Width = 60
        '
        'DeptId
        '
        Me.DeptId.DataPropertyName = "DeptId"
        Me.DeptId.HeaderText = "部门"
        Me.DeptId.Name = "DeptId"
        Me.DeptId.ReadOnly = True
        Me.DeptId.Width = 60
        '
        'LineId
        '
        Me.LineId.DataPropertyName = "LineId"
        Me.LineId.HeaderText = "线别"
        Me.LineId.Name = "LineId"
        Me.LineId.ReadOnly = True
        Me.LineId.Width = 60
        '
        'DeliveryTime
        '
        Me.DeliveryTime.DataPropertyName = "DeliveryTime"
        Me.DeliveryTime.HeaderText = "交货日期"
        Me.DeliveryTime.Name = "DeliveryTime"
        Me.DeliveryTime.ReadOnly = True
        '
        'PlanStartTime
        '
        Me.PlanStartTime.DataPropertyName = "PlanStartTime"
        Me.PlanStartTime.HeaderText = "计划开始日期"
        Me.PlanStartTime.Name = "PlanStartTime"
        Me.PlanStartTime.ReadOnly = True
        '
        'PlanEndTime
        '
        Me.PlanEndTime.DataPropertyName = "PlanEndTime"
        Me.PlanEndTime.HeaderText = "计划结束日期"
        Me.PlanEndTime.Name = "PlanEndTime"
        Me.PlanEndTime.ReadOnly = True
        '
        'PlanStatusFlagText
        '
        Me.PlanStatusFlagText.DataPropertyName = "StatusFlagText"
        Me.PlanStatusFlagText.HeaderText = "状态"
        Me.PlanStatusFlagText.Name = "PlanStatusFlagText"
        Me.PlanStatusFlagText.ReadOnly = True
        Me.PlanStatusFlagText.Width = 80
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 469)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(892, 22)
        Me.StatusStrip1.TabIndex = 241
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数："
        '
        'ToolLblCount
        '
        Me.ToolLblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolLblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.LinkColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolLblCount.Text = "0"
        '
        'cboQueryType
        '
        Me.cboQueryType.DisplayMember = "Text"
        Me.cboQueryType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboQueryType.FormattingEnabled = True
        Me.cboQueryType.ItemHeight = 15
        Me.cboQueryType.Location = New System.Drawing.Point(691, 51)
        Me.cboQueryType.Name = "cboQueryType"
        Me.cboQueryType.Size = New System.Drawing.Size(121, 21)
        Me.cboQueryType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboQueryType.TabIndex = 242
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(643, 51)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 243
        Me.LabelX4.Text = "类型："
        '
        'FrmPlanReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 491)
        Me.Controls.Add(Me.cboQueryType)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvPlanWorkingHours)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.cboDept)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.txtLineId)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtPartId)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.txtMOId)
        Me.Controls.Add(Me.LabelX1)
        Me.Name = "FrmPlanReport"
        Me.ShowIcon = False
        Me.Text = "排配报表"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.dgvPlanWorkingHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboDept As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtLineId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPartId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtMOId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvPlanWorkingHours As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboQueryType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents MOid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Specification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeptId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeliveryTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanStartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanEndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanStatusFlagText As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
