<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBarCodeReceivedRecord
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBarCodeReceivedRecord))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolIssued = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.statusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRecord = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvBarCodeReceived = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BarCodeReceivedID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ptaskid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Packid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.MOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContentText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceivedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOReceivedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YieldQuantity = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.NoYieldQuantity = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.ReturnQuantity = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.ExchangeFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvBarCodeReceivedRecord = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BarCodeReceivedRecordID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tContentText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tYieldQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tNoYieldQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tExchangeFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExchangeUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExchangeDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtReceivedUserId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.dtpEndDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dtpStartDate = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.txtPartID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtMOID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.toolStrip1.SuspendLayout()
        Me.statusStrip2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvBarCodeReceived, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBarCodeReceivedRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtpEndDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.toolAbandon, Me.ToolStripSeparator1, Me.toolSave, Me.toolBack, Me.ToolStripSeparator3, Me.toolIssued, Me.toolStripSeparator4, Me.toolQuery, Me.ToolStripSeparator2, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(983, 25)
        Me.toolStrip1.TabIndex = 130
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 22)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 22)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(73, 22)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "作 废(&D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 22)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(72, 22)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolIssued
        '
        Me.toolIssued.Image = Global.BasicManagement.My.Resources.Resources.recount
        Me.toolIssued.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolIssued.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolIssued.Name = "toolIssued"
        Me.toolIssued.Size = New System.Drawing.Size(74, 22)
        Me.toolIssued.Text = "发  放(&F)"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolQuery
        '
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
        'statusStrip2
        '
        Me.statusStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.lblRecord})
        Me.statusStrip2.Location = New System.Drawing.Point(0, 498)
        Me.statusStrip2.Name = "statusStrip2"
        Me.statusStrip2.Size = New System.Drawing.Size(983, 22)
        Me.statusStrip2.TabIndex = 134
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 148)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvBarCodeReceived)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvBarCodeReceivedRecord)
        Me.SplitContainer1.Size = New System.Drawing.Size(983, 350)
        Me.SplitContainer1.SplitterDistance = 207
        Me.SplitContainer1.TabIndex = 137
        '
        'dgvBarCodeReceived
        '
        Me.dgvBarCodeReceived.AllowUserToAddRows = False
        Me.dgvBarCodeReceived.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarCodeReceived.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBarCodeReceived.ColumnHeadersHeight = 28
        Me.dgvBarCodeReceived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvBarCodeReceived.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BarCodeReceivedID, Me.Ptaskid, Me.PPartId, Me.Packid, Me.PackItem, Me.ChkSelect, Me.MOID, Me.PartId, Me.LabelType, Me.ContentText, Me.Quantity, Me.ReceivedQuantity, Me.NOReceivedQuantity, Me.NoQuantity, Me.YieldQuantity, Me.NoYieldQuantity, Me.ReturnQuantity, Me.ExchangeFlag, Me.Remark})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBarCodeReceived.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBarCodeReceived.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBarCodeReceived.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvBarCodeReceived.EnableHeadersVisualStyles = False
        Me.dgvBarCodeReceived.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvBarCodeReceived.Location = New System.Drawing.Point(0, 0)
        Me.dgvBarCodeReceived.Name = "dgvBarCodeReceived"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarCodeReceived.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBarCodeReceived.RowHeadersWidth = 15
        Me.dgvBarCodeReceived.RowTemplate.Height = 23
        Me.dgvBarCodeReceived.Size = New System.Drawing.Size(983, 207)
        Me.dgvBarCodeReceived.TabIndex = 136
        '
        'BarCodeReceivedID
        '
        Me.BarCodeReceivedID.DataPropertyName = "BarCodeReceivedID"
        Me.BarCodeReceivedID.HeaderText = "BarCodeReceivedID"
        Me.BarCodeReceivedID.Name = "BarCodeReceivedID"
        Me.BarCodeReceivedID.ReadOnly = True
        Me.BarCodeReceivedID.Visible = False
        '
        'Ptaskid
        '
        Me.Ptaskid.DataPropertyName = "Ptaskid"
        Me.Ptaskid.HeaderText = "Ptaskid"
        Me.Ptaskid.Name = "Ptaskid"
        Me.Ptaskid.Visible = False
        '
        'PPartId
        '
        Me.PPartId.DataPropertyName = "PPartId"
        Me.PPartId.HeaderText = "PPartId"
        Me.PPartId.Name = "PPartId"
        Me.PPartId.ReadOnly = True
        Me.PPartId.Visible = False
        '
        'Packid
        '
        Me.Packid.DataPropertyName = "Packid"
        Me.Packid.HeaderText = "PackId"
        Me.Packid.Name = "Packid"
        Me.Packid.Visible = False
        '
        'PackItem
        '
        Me.PackItem.DataPropertyName = "PackItem"
        Me.PackItem.HeaderText = "PackItem"
        Me.PackItem.Name = "PackItem"
        Me.PackItem.Visible = False
        '
        'ChkSelect
        '
        Me.ChkSelect.HeaderText = "选择"
        Me.ChkSelect.Name = "ChkSelect"
        Me.ChkSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ChkSelect.Width = 30
        '
        'MOID
        '
        Me.MOID.DataPropertyName = "MOID"
        Me.MOID.HeaderText = "工单"
        Me.MOID.Name = "MOID"
        Me.MOID.ReadOnly = True
        Me.MOID.Width = 120
        '
        'PartId
        '
        Me.PartId.DataPropertyName = "PartId"
        Me.PartId.HeaderText = "料号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        Me.PartId.Width = 150
        '
        'LabelType
        '
        Me.LabelType.DataPropertyName = "LabelType"
        Me.LabelType.HeaderText = "标签类型"
        Me.LabelType.Name = "LabelType"
        Me.LabelType.ReadOnly = True
        Me.LabelType.Width = 200
        '
        'ContentText
        '
        Me.ContentText.DataPropertyName = "ContentText"
        Me.ContentText.HeaderText = "标签内容"
        Me.ContentText.Name = "ContentText"
        Me.ContentText.ReadOnly = True
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.HeaderText = "总数"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.Width = 60
        '
        'ReceivedQuantity
        '
        Me.ReceivedQuantity.DataPropertyName = "ReceivedQuantity"
        Me.ReceivedQuantity.HeaderText = "已领数量"
        Me.ReceivedQuantity.Name = "ReceivedQuantity"
        Me.ReceivedQuantity.ReadOnly = True
        Me.ReceivedQuantity.Width = 60
        '
        'NOReceivedQuantity
        '
        Me.NOReceivedQuantity.DataPropertyName = "NOReceivedQuantity"
        Me.NOReceivedQuantity.HeaderText = "未领数量"
        Me.NOReceivedQuantity.Name = "NOReceivedQuantity"
        Me.NOReceivedQuantity.ReadOnly = True
        Me.NOReceivedQuantity.Width = 60
        '
        'NoQuantity
        '
        Me.NoQuantity.DataPropertyName = "NoQuantity"
        Me.NoQuantity.HeaderText = "不良统计"
        Me.NoQuantity.Name = "NoQuantity"
        Me.NoQuantity.ReadOnly = True
        Me.NoQuantity.Width = 50
        '
        'YieldQuantity
        '
        '
        '
        '
        Me.YieldQuantity.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.YieldQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.YieldQuantity.DataPropertyName = "YieldQuantity"
        Me.YieldQuantity.HeaderText = "良品数"
        Me.YieldQuantity.MinValue = 0
        Me.YieldQuantity.Name = "YieldQuantity"
        Me.YieldQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.YieldQuantity.ShowUpDown = True
        Me.YieldQuantity.Width = 50
        '
        'NoYieldQuantity
        '
        '
        '
        '
        Me.NoYieldQuantity.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.NoYieldQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.NoYieldQuantity.DataPropertyName = "NoYieldQuantity"
        Me.NoYieldQuantity.HeaderText = "不良数"
        Me.NoYieldQuantity.MinValue = 0
        Me.NoYieldQuantity.Name = "NoYieldQuantity"
        Me.NoYieldQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NoYieldQuantity.ShowUpDown = True
        Me.NoYieldQuantity.Width = 50
        '
        'ReturnQuantity
        '
        '
        '
        '
        Me.ReturnQuantity.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.ReturnQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReturnQuantity.DataPropertyName = "ReturnQuantity"
        Me.ReturnQuantity.HeaderText = "退还数"
        Me.ReturnQuantity.MinValue = 0
        Me.ReturnQuantity.Name = "ReturnQuantity"
        Me.ReturnQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReturnQuantity.ShowUpDown = True
        Me.ReturnQuantity.Width = 50
        '
        'ExchangeFlag
        '
        Me.ExchangeFlag.DataPropertyName = "ExchangeFlag"
        Me.ExchangeFlag.HeaderText = "兑换状态"
        Me.ExchangeFlag.Name = "ExchangeFlag"
        Me.ExchangeFlag.ReadOnly = True
        Me.ExchangeFlag.Width = 80
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 160
        '
        'dgvBarCodeReceivedRecord
        '
        Me.dgvBarCodeReceivedRecord.AllowUserToAddRows = False
        Me.dgvBarCodeReceivedRecord.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarCodeReceivedRecord.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBarCodeReceivedRecord.ColumnHeadersHeight = 28
        Me.dgvBarCodeReceivedRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvBarCodeReceivedRecord.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BarCodeReceivedRecordID, Me.tPartId, Me.tContentText, Me.tYieldQuantity, Me.tNoYieldQuantity, Me.tExchangeFlag, Me.ExchangeUserId, Me.ExchangeDate, Me.tRemark})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBarCodeReceivedRecord.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvBarCodeReceivedRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBarCodeReceivedRecord.EnableHeadersVisualStyles = False
        Me.dgvBarCodeReceivedRecord.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvBarCodeReceivedRecord.Location = New System.Drawing.Point(0, 0)
        Me.dgvBarCodeReceivedRecord.Name = "dgvBarCodeReceivedRecord"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarCodeReceivedRecord.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvBarCodeReceivedRecord.RowHeadersWidth = 15
        Me.dgvBarCodeReceivedRecord.RowTemplate.Height = 23
        Me.dgvBarCodeReceivedRecord.Size = New System.Drawing.Size(983, 139)
        Me.dgvBarCodeReceivedRecord.TabIndex = 0
        '
        'BarCodeReceivedRecordID
        '
        Me.BarCodeReceivedRecordID.DataPropertyName = "BarCodeReceivedRecordID"
        Me.BarCodeReceivedRecordID.HeaderText = "BarCodeReceivedRecordID"
        Me.BarCodeReceivedRecordID.Name = "BarCodeReceivedRecordID"
        Me.BarCodeReceivedRecordID.ReadOnly = True
        Me.BarCodeReceivedRecordID.Visible = False
        '
        'tPartId
        '
        Me.tPartId.DataPropertyName = "PartId"
        Me.tPartId.HeaderText = "料号"
        Me.tPartId.Name = "tPartId"
        Me.tPartId.ReadOnly = True
        Me.tPartId.Width = 150
        '
        'tContentText
        '
        Me.tContentText.DataPropertyName = "ContentText"
        Me.tContentText.HeaderText = "标签内容"
        Me.tContentText.Name = "tContentText"
        Me.tContentText.ReadOnly = True
        Me.tContentText.Width = 150
        '
        'tYieldQuantity
        '
        Me.tYieldQuantity.DataPropertyName = "YieldQuantity"
        Me.tYieldQuantity.HeaderText = "良品数"
        Me.tYieldQuantity.Name = "tYieldQuantity"
        Me.tYieldQuantity.ReadOnly = True
        Me.tYieldQuantity.Width = 80
        '
        'tNoYieldQuantity
        '
        Me.tNoYieldQuantity.DataPropertyName = "NoYieldQuantity"
        Me.tNoYieldQuantity.HeaderText = "不良数"
        Me.tNoYieldQuantity.Name = "tNoYieldQuantity"
        Me.tNoYieldQuantity.ReadOnly = True
        Me.tNoYieldQuantity.Width = 80
        '
        'tExchangeFlag
        '
        Me.tExchangeFlag.DataPropertyName = "ExchangeFlag"
        Me.tExchangeFlag.HeaderText = "兑换状况"
        Me.tExchangeFlag.Name = "tExchangeFlag"
        Me.tExchangeFlag.ReadOnly = True
        '
        'ExchangeUserId
        '
        Me.ExchangeUserId.DataPropertyName = "ExchangeUserId"
        Me.ExchangeUserId.HeaderText = "兑换人"
        Me.ExchangeUserId.Name = "ExchangeUserId"
        Me.ExchangeUserId.ReadOnly = True
        '
        'ExchangeDate
        '
        Me.ExchangeDate.DataPropertyName = "ExchangeDate"
        Me.ExchangeDate.HeaderText = "兑换时间"
        Me.ExchangeDate.Name = "ExchangeDate"
        Me.ExchangeDate.ReadOnly = True
        '
        'tRemark
        '
        Me.tRemark.DataPropertyName = "Remark"
        Me.tRemark.HeaderText = "备注"
        Me.tRemark.Name = "tRemark"
        Me.tRemark.ReadOnly = True
        Me.tRemark.Width = 200
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtReceivedUserId)
        Me.GroupBox1.Controls.Add(Me.LabelX5)
        Me.GroupBox1.Controls.Add(Me.dtpEndDate)
        Me.GroupBox1.Controls.Add(Me.dtpStartDate)
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.LabelX3)
        Me.GroupBox1.Controls.Add(Me.txtPartID)
        Me.GroupBox1.Controls.Add(Me.LabelX2)
        Me.GroupBox1.Controls.Add(Me.txtMOID)
        Me.GroupBox1.Controls.Add(Me.LabelX1)
        Me.GroupBox1.Controls.Add(Me.lblMessage)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(983, 95)
        Me.GroupBox1.TabIndex = 138
        Me.GroupBox1.TabStop = False
        '
        'txtReceivedUserId
        '
        '
        '
        '
        Me.txtReceivedUserId.Border.Class = "TextBoxBorder"
        Me.txtReceivedUserId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReceivedUserId.Location = New System.Drawing.Point(575, 23)
        Me.txtReceivedUserId.Name = "txtReceivedUserId"
        Me.txtReceivedUserId.Size = New System.Drawing.Size(147, 21)
        Me.txtReceivedUserId.TabIndex = 131
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(521, 22)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 23)
        Me.LabelX5.TabIndex = 130
        Me.LabelX5.Text = "领用人："
        '
        'dtpEndDate
        '
        '
        '
        '
        Me.dtpEndDate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpEndDate.ButtonDropDown.Visible = True
        Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpEndDate.IsPopupCalendarOpen = False
        Me.dtpEndDate.Location = New System.Drawing.Point(340, 58)
        '
        '
        '
        Me.dtpEndDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpEndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpEndDate.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndDate.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.dtpEndDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpEndDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEndDate.MonthCalendar.TodayButtonVisible = True
        Me.dtpEndDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(147, 21)
        Me.dtpEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpEndDate.TabIndex = 129
        '
        'dtpStartDate
        '
        '
        '
        '
        Me.dtpStartDate.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpStartDate.ButtonDropDown.Visible = True
        Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpStartDate.IsPopupCalendarOpen = False
        Me.dtpStartDate.Location = New System.Drawing.Point(93, 59)
        '
        '
        '
        Me.dtpStartDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpStartDate.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartDate.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        Me.dtpStartDate.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpStartDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpStartDate.MonthCalendar.TodayButtonVisible = True
        Me.dtpStartDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(147, 21)
        Me.dtpStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpStartDate.TabIndex = 128
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(272, 59)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 23)
        Me.LabelX4.TabIndex = 127
        Me.LabelX4.Text = "结束日期："
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(27, 59)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 126
        Me.LabelX3.Text = "开始日期："
        '
        'txtPartID
        '
        '
        '
        '
        Me.txtPartID.Border.Class = "TextBoxBorder"
        Me.txtPartID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPartID.Location = New System.Drawing.Point(340, 23)
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(147, 21)
        Me.txtPartID.TabIndex = 125
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(272, 22)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 124
        Me.LabelX2.Text = "料号："
        '
        'txtMOID
        '
        '
        '
        '
        Me.txtMOID.Border.Class = "TextBoxBorder"
        Me.txtMOID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMOID.Location = New System.Drawing.Point(93, 23)
        Me.txtMOID.Name = "txtMOID"
        Me.txtMOID.Size = New System.Drawing.Size(147, 21)
        Me.txtMOID.TabIndex = 123
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(27, 21)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 122
        Me.LabelX1.Text = "工单："
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(521, 57)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(531, 23)
        Me.lblMessage.TabIndex = 121
        '
        'FrmBarCodeReceivedRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 520)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.statusStrip2)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmBarCodeReceivedRecord"
        Me.ShowIcon = False
        Me.Text = "标签发放记录"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.statusStrip2.ResumeLayout(False)
        Me.statusStrip2.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvBarCodeReceived, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBarCodeReceivedRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dtpEndDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpStartDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Private WithEvents statusStrip2 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents lblRecord As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvBarCodeReceived As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvBarCodeReceivedRecord As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtpStartDate As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPartID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtMOID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolIssued As System.Windows.Forms.ToolStripButton
    Friend WithEvents BarCodeReceivedRecordID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tContentText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tYieldQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tNoYieldQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tExchangeFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExchangeUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExchangeDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtReceivedUserId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents BarCodeReceivedID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ptaskid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Packid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContentText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOReceivedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YieldQuantity As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents NoYieldQuantity As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents ReturnQuantity As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents ExchangeFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
