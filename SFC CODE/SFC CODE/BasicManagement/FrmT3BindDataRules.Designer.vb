<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmT3BindDataRules
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmT3BindDataRules))
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.dgvT3BindDataRules = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Items = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CusPartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestLoop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecLowerLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpecUpperLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitDesEn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitDesCn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendMoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SendLineID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifyTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateSQL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateSQLD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.txtPartID = New System.Windows.Forms.TextBox()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRealMoid = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolChangeData = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.txtItems = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboDelayTestTimeUnit = New System.Windows.Forms.ComboBox()
        Me.txtDelayTestTimeNum = New System.Windows.Forms.TextBox()
        Me.txtSendLineID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSendMoid = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkNeedSend = New System.Windows.Forms.CheckBox()
        Me.chkDelaySend = New System.Windows.Forms.CheckBox()
        Me.txtRealLineID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgvT3BindDataRules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgvT3BindDataRules)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.statusStrip2)
        Me.SplitContainer3.Size = New System.Drawing.Size(1290, 418)
        Me.SplitContainer3.SplitterDistance = 387
        Me.SplitContainer3.TabIndex = 72
        '
        'dgvT3BindDataRules
        '
        Me.dgvT3BindDataRules.AllowUserToAddRows = False
        Me.dgvT3BindDataRules.AllowUserToDeleteRows = False
        Me.dgvT3BindDataRules.AllowUserToOrderColumns = True
        Me.dgvT3BindDataRules.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvT3BindDataRules.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvT3BindDataRules.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Items, Me.PartNumber, Me.CusPartNumber, Me.TestItem, Me.TestLoop, Me.SpecLowerLimit, Me.SpecUpperLimit, Me.Unit, Me.UnitDesEn, Me.UnitDesCn, Me.SendMoid, Me.SendLineID, Me.TestCondition, Me.ModifyBy, Me.ModifyTime, Me.UpdateSQL, Me.UpdateSQLD})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvT3BindDataRules.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvT3BindDataRules.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvT3BindDataRules.EnableHeadersVisualStyles = False
        Me.dgvT3BindDataRules.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvT3BindDataRules.Location = New System.Drawing.Point(0, 0)
        Me.dgvT3BindDataRules.Name = "dgvT3BindDataRules"
        Me.dgvT3BindDataRules.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvT3BindDataRules.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvT3BindDataRules.RowHeadersWidth = 4
        Me.dgvT3BindDataRules.RowTemplate.Height = 23
        Me.dgvT3BindDataRules.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.dgvT3BindDataRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvT3BindDataRules.Size = New System.Drawing.Size(1290, 387)
        Me.dgvT3BindDataRules.TabIndex = 72
        '
        'Items
        '
        Me.Items.DataPropertyName = "Items"
        Me.Items.HeaderText = "Items"
        Me.Items.Name = "Items"
        Me.Items.ReadOnly = True
        Me.Items.Visible = False
        '
        'PartNumber
        '
        Me.PartNumber.DataPropertyName = "Priority"
        Me.PartNumber.HeaderText = "优先级"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        '
        'CusPartNumber
        '
        Me.CusPartNumber.DataPropertyName = "PartID"
        Me.CusPartNumber.HeaderText = "立讯料号"
        Me.CusPartNumber.Name = "CusPartNumber"
        Me.CusPartNumber.ReadOnly = True
        '
        'TestItem
        '
        Me.TestItem.DataPropertyName = "RealMoid"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TestItem.DefaultCellStyle = DataGridViewCellStyle2
        Me.TestItem.HeaderText = "生产工单"
        Me.TestItem.Name = "TestItem"
        Me.TestItem.ReadOnly = True
        '
        'TestLoop
        '
        Me.TestLoop.DataPropertyName = "ReallineID"
        Me.TestLoop.HeaderText = "生产线别"
        Me.TestLoop.Name = "TestLoop"
        Me.TestLoop.ReadOnly = True
        Me.TestLoop.Width = 60
        '
        'SpecLowerLimit
        '
        Me.SpecLowerLimit.DataPropertyName = "NeedSend"
        Me.SpecLowerLimit.HeaderText = "需发送给客户"
        Me.SpecLowerLimit.Name = "SpecLowerLimit"
        Me.SpecLowerLimit.ReadOnly = True
        Me.SpecLowerLimit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SpecLowerLimit.Width = 85
        '
        'SpecUpperLimit
        '
        Me.SpecUpperLimit.DataPropertyName = "DelaySend"
        Me.SpecUpperLimit.HeaderText = "延迟发送"
        Me.SpecUpperLimit.Name = "SpecUpperLimit"
        Me.SpecUpperLimit.ReadOnly = True
        Me.SpecUpperLimit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SpecUpperLimit.Width = 60
        '
        'Unit
        '
        Me.Unit.DataPropertyName = "DelaySendNum"
        Me.Unit.HeaderText = "延迟时间"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.Visible = False
        '
        'UnitDesEn
        '
        Me.UnitDesEn.DataPropertyName = "DelaySendUnit"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.UnitDesEn.DefaultCellStyle = DataGridViewCellStyle3
        Me.UnitDesEn.HeaderText = "延迟单位"
        Me.UnitDesEn.Name = "UnitDesEn"
        Me.UnitDesEn.ReadOnly = True
        Me.UnitDesEn.Visible = False
        '
        'UnitDesCn
        '
        Me.UnitDesCn.DataPropertyName = "DelaySendDes"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.UnitDesCn.DefaultCellStyle = DataGridViewCellStyle4
        Me.UnitDesCn.HeaderText = "延迟发送时间"
        Me.UnitDesCn.Name = "UnitDesCn"
        Me.UnitDesCn.ReadOnly = True
        '
        'SendMoid
        '
        Me.SendMoid.HeaderText = "发送工单"
        Me.SendMoid.Name = "SendMoid"
        Me.SendMoid.ReadOnly = True
        '
        'SendLineID
        '
        Me.SendLineID.HeaderText = "发送线别"
        Me.SendLineID.Name = "SendLineID"
        Me.SendLineID.ReadOnly = True
        '
        'TestCondition
        '
        Me.TestCondition.DataPropertyName = "Remark"
        Me.TestCondition.HeaderText = "备注说明"
        Me.TestCondition.Name = "TestCondition"
        Me.TestCondition.ReadOnly = True
        Me.TestCondition.Width = 400
        '
        'ModifyBy
        '
        Me.ModifyBy.DataPropertyName = "ModifyBy"
        Me.ModifyBy.HeaderText = "设置人员"
        Me.ModifyBy.Name = "ModifyBy"
        Me.ModifyBy.ReadOnly = True
        '
        'ModifyTime
        '
        Me.ModifyTime.DataPropertyName = "ModifyTime"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ModifyTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.ModifyTime.HeaderText = "设置时间"
        Me.ModifyTime.Name = "ModifyTime"
        Me.ModifyTime.ReadOnly = True
        Me.ModifyTime.Width = 120
        '
        'UpdateSQL
        '
        Me.UpdateSQL.HeaderText = "变更主表语句"
        Me.UpdateSQL.Name = "UpdateSQL"
        Me.UpdateSQL.ReadOnly = True
        '
        'UpdateSQLD
        '
        Me.UpdateSQLD.HeaderText = "变更明细表语句"
        Me.UpdateSQLD.Name = "UpdateSQLD"
        Me.UpdateSQLD.ReadOnly = True
        '
        'statusStrip2
        '
        Me.statusStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.toolStripStatusLabel3})
        Me.statusStrip2.Location = New System.Drawing.Point(0, 5)
        Me.statusStrip2.Name = "statusStrip2"
        Me.statusStrip2.Size = New System.Drawing.Size(1290, 22)
        Me.statusStrip2.TabIndex = 74
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
        'toolStripStatusLabel3
        '
        Me.toolStripStatusLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.toolStripStatusLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.toolStripStatusLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.toolStripStatusLabel3.Name = "toolStripStatusLabel3"
        Me.toolStripStatusLabel3.Size = New System.Drawing.Size(15, 17)
        Me.toolStripStatusLabel3.Text = "0"
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(891, 9)
        Me.txtRemark.MaxLength = 50
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(365, 50)
        Me.txtRemark.TabIndex = 57
        '
        'txtPartID
        '
        Me.txtPartID.Location = New System.Drawing.Point(274, 10)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(132, 21)
        Me.txtPartID.TabIndex = 53
        '
        'cboPriority
        '
        Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriority.FormattingEnabled = True
        Me.cboPriority.Items.AddRange(New Object() {"", "1.By工单+线别", "2.By工单", "3.By料号+线别", "4.By料号", "5.By线别"})
        Me.cboPriority.Location = New System.Drawing.Point(74, 11)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(133, 20)
        Me.cboPriority.TabIndex = 55
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(832, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "备注说明："
        '
        'txtRealMoid
        '
        Me.txtRealMoid.Location = New System.Drawing.Point(477, 10)
        Me.txtRealMoid.Name = "txtRealMoid"
        Me.txtRealMoid.Size = New System.Drawing.Size(132, 21)
        Me.txtRealMoid.TabIndex = 70
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1290, 522)
        Me.SplitContainer1.SplitterDistance = 100
        Me.SplitContainer1.TabIndex = 1
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.toolStrip1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtItems)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel2.Controls.Add(Me.cboDelayTestTimeUnit)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtDelayTestTimeNum)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtSendLineID)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtSendMoid)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.chkNeedSend)
        Me.SplitContainer2.Panel2.Controls.Add(Me.chkDelaySend)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtRealLineID)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtRemark)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtPartID)
        Me.SplitContainer2.Panel2.Controls.Add(Me.cboPriority)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtRealMoid)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Size = New System.Drawing.Size(1290, 100)
        Me.SplitContainer2.SplitterDistance = 25
        Me.SplitContainer2.TabIndex = 0
        '
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.ToolStripSeparator2, Me.toolSave, Me.toolBack, Me.ToolStripSeparator1, Me.toolDelete, Me.toolStripSeparator4, Me.toolQuery, Me.ToolStripSeparator3, Me.ToolChangeData, Me.ToolStripSeparator5, Me.toolExit, Me.toolStripSeparator})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1290, 21)
        Me.toolStrip1.TabIndex = 54
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 18)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 18)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 21)
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 18)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(72, 18)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 21)
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(69, 18)
        Me.toolDelete.Text = "刪除(&D)"
        Me.toolDelete.ToolTipText = "刪除"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 21)
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 18)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 21)
        '
        'ToolChangeData
        '
        Me.ToolChangeData.Enabled = False
        Me.ToolChangeData.Image = CType(resources.GetObject("ToolChangeData.Image"), System.Drawing.Image)
        Me.ToolChangeData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolChangeData.Name = "ToolChangeData"
        Me.ToolChangeData.Size = New System.Drawing.Size(148, 18)
        Me.ToolChangeData.Text = "已绑定数据变更！！！"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 21)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 18)
        Me.toolExit.Text = "退 出(&X)"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 21)
        '
        'txtItems
        '
        Me.txtItems.Location = New System.Drawing.Point(849, 37)
        Me.txtItems.Name = "txtItems"
        Me.txtItems.Size = New System.Drawing.Size(22, 21)
        Me.txtItems.TabIndex = 84
        Me.txtItems.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(216, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(192, 11)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "延后测试时间，发送的时间也对应延后"
        '
        'cboDelayTestTimeUnit
        '
        Me.cboDelayTestTimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDelayTestTimeUnit.Enabled = False
        Me.cboDelayTestTimeUnit.FormattingEnabled = True
        Me.cboDelayTestTimeUnit.Items.AddRange(New Object() {"", "Minute", "Hour", "Day", "Week", "Month"})
        Me.cboDelayTestTimeUnit.Location = New System.Drawing.Point(345, 40)
        Me.cboDelayTestTimeUnit.Name = "cboDelayTestTimeUnit"
        Me.cboDelayTestTimeUnit.Size = New System.Drawing.Size(61, 20)
        Me.cboDelayTestTimeUnit.TabIndex = 74
        '
        'txtDelayTestTimeNum
        '
        Me.txtDelayTestTimeNum.Location = New System.Drawing.Point(283, 40)
        Me.txtDelayTestTimeNum.Name = "txtDelayTestTimeNum"
        Me.txtDelayTestTimeNum.ReadOnly = True
        Me.txtDelayTestTimeNum.Size = New System.Drawing.Size(63, 21)
        Me.txtDelayTestTimeNum.TabIndex = 82
        '
        'txtSendLineID
        '
        Me.txtSendLineID.Location = New System.Drawing.Point(682, 38)
        Me.txtSendLineID.Name = "txtSendLineID"
        Me.txtSendLineID.Size = New System.Drawing.Size(132, 21)
        Me.txtSendLineID.TabIndex = 81
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(623, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "发送线别："
        '
        'txtSendMoid
        '
        Me.txtSendMoid.Location = New System.Drawing.Point(477, 38)
        Me.txtSendMoid.Name = "txtSendMoid"
        Me.txtSendMoid.Size = New System.Drawing.Size(132, 21)
        Me.txtSendMoid.TabIndex = 79
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(418, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "发送工单："
        '
        'chkNeedSend
        '
        Me.chkNeedSend.AutoSize = True
        Me.chkNeedSend.Checked = True
        Me.chkNeedSend.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNeedSend.Location = New System.Drawing.Point(29, 43)
        Me.chkNeedSend.Name = "chkNeedSend"
        Me.chkNeedSend.Size = New System.Drawing.Size(156, 16)
        Me.chkNeedSend.TabIndex = 77
        Me.chkNeedSend.Text = "发送相关生产数据给客户"
        Me.chkNeedSend.UseVisualStyleBackColor = True
        '
        'chkDelaySend
        '
        Me.chkDelaySend.AutoSize = True
        Me.chkDelaySend.Location = New System.Drawing.Point(216, 42)
        Me.chkDelaySend.Name = "chkDelaySend"
        Me.chkDelaySend.Size = New System.Drawing.Size(72, 16)
        Me.chkDelaySend.TabIndex = 76
        Me.chkDelaySend.Text = "延迟发送"
        Me.chkDelaySend.UseVisualStyleBackColor = True
        '
        'txtRealLineID
        '
        Me.txtRealLineID.Location = New System.Drawing.Point(682, 10)
        Me.txtRealLineID.Name = "txtRealLineID"
        Me.txtRealLineID.Size = New System.Drawing.Size(132, 21)
        Me.txtRealLineID.TabIndex = 72
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(623, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "生产线别："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(418, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "生产工单："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(215, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "生产料号："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "优先级："
        '
        'FrmT3BindDataRules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1290, 522)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmT3BindDataRules"
        Me.Text = "T3测试数据配置(数据绑定&传送给客户)"
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgvT3BindDataRules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip2.ResumeLayout(False)
        Me.statusStrip2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvT3BindDataRules As DevComponents.DotNetBar.Controls.DataGridViewX
    Private WithEvents statusStrip2 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRealMoid As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkNeedSend As System.Windows.Forms.CheckBox
    Friend WithEvents chkDelaySend As System.Windows.Forms.CheckBox
    Friend WithEvents cboDelayTestTimeUnit As System.Windows.Forms.ComboBox
    Friend WithEvents txtRealLineID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSendLineID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSendMoid As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Items As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CusPartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestLoop As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecLowerLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpecUpperLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitDesEn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitDesCn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendMoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SendLineID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestCondition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifyBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifyTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateSQL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateSQLD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDelayTestTimeNum As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtItems As System.Windows.Forms.TextBox
    Friend WithEvents ToolChangeData As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
End Class
