<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployeeCard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmployeeCard))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolComplete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStartCard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.lblEmployeeCode = New DevComponents.DotNetBar.LabelX()
        Me.dgvList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TiptopPlanItemCardId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRecord = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtEmployeeCode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtEmployeeName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblEmployeeName = New DevComponents.DotNetBar.LabelX()
        Me.txtCardNo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblCardNo = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.mtxtMOID = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.pbPhoto = New System.Windows.Forms.PictureBox()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.mtxtLineId = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStrip1.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip2.SuspendLayout()
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolComplete, Me.ToolStripSeparator1, Me.toolStartCard, Me.ToolStripSeparator3, Me.toolQuery, Me.ToolStripSeparator2, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(819, 25)
        Me.toolStrip1.TabIndex = 132
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolComplete
        '
        Me.toolComplete.Image = CType(resources.GetObject("toolComplete.Image"), System.Drawing.Image)
        Me.toolComplete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolComplete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolComplete.Name = "toolComplete"
        Me.toolComplete.Size = New System.Drawing.Size(73, 22)
        Me.toolComplete.Tag = ""
        Me.toolComplete.Text = "完 成(&S)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolStartCard
        '
        Me.toolStartCard.Image = CType(resources.GetObject("toolStartCard.Image"), System.Drawing.Image)
        Me.toolStartCard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStartCard.Name = "toolStartCard"
        Me.toolStartCard.Size = New System.Drawing.Size(91, 22)
        Me.toolStartCard.Tag = "NO"
        Me.toolStartCard.Text = "开始打卡(&E)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolQuery
        '
        Me.toolQuery.Enabled = False
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 22)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'lblEmployeeCode
        '
        '
        '
        '
        Me.lblEmployeeCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEmployeeCode.Location = New System.Drawing.Point(37, 142)
        Me.lblEmployeeCode.Name = "lblEmployeeCode"
        Me.lblEmployeeCode.Size = New System.Drawing.Size(75, 23)
        Me.lblEmployeeCode.TabIndex = 134
        Me.lblEmployeeCode.Text = "员工工号："
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 28
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TiptopPlanItemCardId, Me.Moid, Me.PartId, Me.LineId, Me.EmployeeCode, Me.EmployeeName, Me.CreateTime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvList.Location = New System.Drawing.Point(0, 210)
        Me.dgvList.Name = "dgvList"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvList.RowHeadersWidth = 15
        Me.dgvList.RowTemplate.Height = 23
        Me.dgvList.Size = New System.Drawing.Size(819, 215)
        Me.dgvList.TabIndex = 135
        '
        'TiptopPlanItemCardId
        '
        Me.TiptopPlanItemCardId.DataPropertyName = "TiptopPlanItemCardId"
        Me.TiptopPlanItemCardId.HeaderText = "TiptopPlanItemCardId"
        Me.TiptopPlanItemCardId.Name = "TiptopPlanItemCardId"
        Me.TiptopPlanItemCardId.ReadOnly = True
        Me.TiptopPlanItemCardId.Visible = False
        '
        'Moid
        '
        Me.Moid.DataPropertyName = "Moid"
        Me.Moid.HeaderText = "工单"
        Me.Moid.Name = "Moid"
        Me.Moid.ReadOnly = True
        Me.Moid.Width = 150
        '
        'PartId
        '
        Me.PartId.DataPropertyName = "PartId"
        Me.PartId.HeaderText = "料号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        Me.PartId.Width = 120
        '
        'LineId
        '
        Me.LineId.DataPropertyName = "LineId"
        Me.LineId.HeaderText = "产线"
        Me.LineId.Name = "LineId"
        Me.LineId.ReadOnly = True
        '
        'EmployeeCode
        '
        Me.EmployeeCode.DataPropertyName = "EmployeeCode"
        Me.EmployeeCode.HeaderText = "员工工号"
        Me.EmployeeCode.Name = "EmployeeCode"
        Me.EmployeeCode.ReadOnly = True
        '
        'EmployeeName
        '
        Me.EmployeeName.DataPropertyName = "EmployeeName"
        Me.EmployeeName.HeaderText = "员工姓名"
        Me.EmployeeName.Name = "EmployeeName"
        Me.EmployeeName.ReadOnly = True
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "CreateTime"
        Me.CreateTime.HeaderText = "刷卡时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        Me.CreateTime.Width = 200
        '
        'statusStrip2
        '
        Me.statusStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.lblRecord})
        Me.statusStrip2.Location = New System.Drawing.Point(0, 428)
        Me.statusStrip2.Name = "statusStrip2"
        Me.statusStrip2.Size = New System.Drawing.Size(819, 22)
        Me.statusStrip2.TabIndex = 136
        Me.statusStrip2.Text = "statusStrip2"
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.toolStripStatusLabel1.Text = "记录笔数:"
        '
        'lblRecord
        '
        Me.lblRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lblRecord.LinkColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(15, 17)
        Me.lblRecord.Text = "0"
        '
        'txtEmployeeCode
        '
        '
        '
        '
        Me.txtEmployeeCode.Border.Class = "TextBoxBorder"
        Me.txtEmployeeCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEmployeeCode.Location = New System.Drawing.Point(95, 142)
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.ReadOnly = True
        Me.txtEmployeeCode.Size = New System.Drawing.Size(155, 21)
        Me.txtEmployeeCode.TabIndex = 137
        '
        'txtEmployeeName
        '
        '
        '
        '
        Me.txtEmployeeName.Border.Class = "TextBoxBorder"
        Me.txtEmployeeName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEmployeeName.Location = New System.Drawing.Point(95, 181)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(155, 21)
        Me.txtEmployeeName.TabIndex = 139
        '
        'lblEmployeeName
        '
        '
        '
        '
        Me.lblEmployeeName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEmployeeName.Location = New System.Drawing.Point(37, 181)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Size = New System.Drawing.Size(75, 23)
        Me.lblEmployeeName.TabIndex = 138
        Me.lblEmployeeName.Text = "员工姓名："
        '
        'txtCardNo
        '
        Me.txtCardNo.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtCardNo.Border.Class = "RibbonFileMenuBottomContainer"
        Me.txtCardNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCardNo.ForeColor = System.Drawing.SystemColors.Control
        Me.txtCardNo.Location = New System.Drawing.Point(278, 71)
        Me.txtCardNo.Name = "txtCardNo"
        Me.txtCardNo.Size = New System.Drawing.Size(140, 14)
        Me.txtCardNo.TabIndex = 142
        '
        'lblCardNo
        '
        '
        '
        '
        Me.lblCardNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCardNo.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCardNo.Location = New System.Drawing.Point(525, 107)
        Me.lblCardNo.Name = "lblCardNo"
        Me.lblCardNo.Size = New System.Drawing.Size(75, 23)
        Me.lblCardNo.TabIndex = 141
        Me.lblCardNo.Text = "员工工卡："
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(37, 67)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 144
        Me.LabelX1.Text = "生产工单："
        '
        'mtxtMOID
        '
        '
        '
        '
        Me.mtxtMOID.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMOID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMOID.ButtonCustom.Visible = True
        Me.mtxtMOID.Location = New System.Drawing.Point(95, 66)
        Me.mtxtMOID.Name = "mtxtMOID"
        Me.mtxtMOID.ReadOnly = True
        Me.mtxtMOID.Size = New System.Drawing.Size(155, 21)
        Me.mtxtMOID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMOID.TabIndex = 145
        Me.mtxtMOID.Text = ""
        '
        'pbPhoto
        '
        Me.pbPhoto.Location = New System.Drawing.Point(269, 66)
        Me.pbPhoto.Name = "pbPhoto"
        Me.pbPhoto.Size = New System.Drawing.Size(149, 138)
        Me.pbPhoto.TabIndex = 140
        Me.pbPhoto.TabStop = False
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(424, 181)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(693, 23)
        Me.lblMessage.TabIndex = 146
        '
        'mtxtLineId
        '
        '
        '
        '
        Me.mtxtLineId.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtLineId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtLineId.ButtonCustom.Visible = True
        Me.mtxtLineId.Location = New System.Drawing.Point(95, 103)
        Me.mtxtLineId.Name = "mtxtLineId"
        Me.mtxtLineId.ReadOnly = True
        Me.mtxtLineId.Size = New System.Drawing.Size(155, 21)
        Me.mtxtLineId.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtLineId.TabIndex = 148
        Me.mtxtLineId.Text = ""
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(37, 104)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 147
        Me.LabelX2.Text = "生产产线："
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "TiptopPlanItemCardId"
        Me.DataGridViewTextBoxColumn1.HeaderText = "TiptopPlanItemCardId"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Moid"
        Me.DataGridViewTextBoxColumn2.HeaderText = "工单"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PartId"
        Me.DataGridViewTextBoxColumn3.HeaderText = "料号"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "LineId"
        Me.DataGridViewTextBoxColumn4.HeaderText = "产线"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "EmployeeCode"
        Me.DataGridViewTextBoxColumn5.HeaderText = "员工工号"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "EmployeeName"
        Me.DataGridViewTextBoxColumn6.HeaderText = "员工姓名"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "CreateTime"
        Me.DataGridViewTextBoxColumn7.HeaderText = "刷卡时间"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 200
        '
        'FrmEmployeeCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 450)
        Me.Controls.Add(Me.mtxtLineId)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.mtxtMOID)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.lblCardNo)
        Me.Controls.Add(Me.pbPhoto)
        Me.Controls.Add(Me.txtEmployeeName)
        Me.Controls.Add(Me.lblEmployeeName)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.statusStrip2)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.lblEmployeeCode)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtCardNo)
        Me.Name = "FrmEmployeeCard"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "员工打卡扫描"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip2.ResumeLayout(False)
        Me.statusStrip2.PerformLayout()
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStartCard As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolComplete As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblEmployeeCode As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvList As DevComponents.DotNetBar.Controls.DataGridViewX
    Private WithEvents statusStrip2 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents lblRecord As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtEmployeeCode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtEmployeeName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblEmployeeName As DevComponents.DotNetBar.LabelX
    Friend WithEvents pbPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents txtCardNo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblCardNo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtMOID As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents mtxtLineId As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TiptopPlanItemCardId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
