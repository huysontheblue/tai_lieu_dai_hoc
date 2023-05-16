<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLineBorrow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLineBorrow))
        Me.ToolStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.txtStorage = New System.Windows.Forms.TextBox()
        Me.lblStorage = New System.Windows.Forms.Label()
        Me.cboInOut = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboMiddleCategory = New System.Windows.Forms.ComboBox()
        Me.cboBigCategory = New System.Windows.Forms.ComboBox()
        Me.cboSmallCategory = New System.Windows.Forms.ComboBox()
        Me.txtEquipmentPN = New System.Windows.Forms.TextBox()
        Me.txtEquipmentNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabEquipment = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvEqu = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolLend = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.btnLookLendRecord = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabEquipment.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvEqu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStatusLabel
        '
        Me.ToolStatusLabel.Name = "ToolStatusLabel"
        Me.ToolStatusLabel.Size = New System.Drawing.Size(95, 17)
        Me.ToolStatusLabel.Text = "ToolStatusLabel"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(597, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "借出线别:"
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.White
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"", "0.无效", "1.有效"})
        Me.cboStatus.Location = New System.Drawing.Point(662, 12)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(84, 20)
        Me.cboStatus.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(610, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 12)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "有效否:"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(1156, 44)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(35, 12)
        Me.lblId.TabIndex = 94
        Me.lblId.Text = "lblId"
        Me.lblId.Visible = False
        '
        'txtLine
        '
        Me.txtLine.Location = New System.Drawing.Point(662, 65)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(85, 21)
        Me.txtLine.TabIndex = 10
        '
        'txtStorage
        '
        Me.txtStorage.Location = New System.Drawing.Point(64, 67)
        Me.txtStorage.Name = "txtStorage"
        Me.txtStorage.Size = New System.Drawing.Size(142, 21)
        Me.txtStorage.TabIndex = 3
        '
        'lblStorage
        '
        Me.lblStorage.AutoSize = True
        Me.lblStorage.Location = New System.Drawing.Point(30, 68)
        Me.lblStorage.Name = "lblStorage"
        Me.lblStorage.Size = New System.Drawing.Size(35, 12)
        Me.lblStorage.TabIndex = 90
        Me.lblStorage.Text = "储位:"
        '
        'cboInOut
        '
        Me.cboInOut.BackColor = System.Drawing.Color.White
        Me.cboInOut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInOut.FormattingEnabled = True
        Me.cboInOut.Items.AddRange(New Object() {"", "0.借出", "1.在库"})
        Me.cboInOut.Location = New System.Drawing.Point(662, 38)
        Me.cboInOut.Name = "cboInOut"
        Me.cboInOut.Size = New System.Drawing.Size(85, 20)
        Me.cboInOut.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(597, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 12)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "在库状态:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(220, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 12)
        Me.Label13.TabIndex = 65
        Me.Label13.Text = "中分类:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(220, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 12)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "大分类:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(220, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 12)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "小分类:"
        '
        'cboMiddleCategory
        '
        Me.cboMiddleCategory.BackColor = System.Drawing.Color.White
        Me.cboMiddleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMiddleCategory.FormattingEnabled = True
        Me.cboMiddleCategory.Location = New System.Drawing.Point(273, 40)
        Me.cboMiddleCategory.Name = "cboMiddleCategory"
        Me.cboMiddleCategory.Size = New System.Drawing.Size(156, 20)
        Me.cboMiddleCategory.TabIndex = 2
        '
        'cboBigCategory
        '
        Me.cboBigCategory.BackColor = System.Drawing.Color.White
        Me.cboBigCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBigCategory.FormattingEnabled = True
        Me.cboBigCategory.Location = New System.Drawing.Point(273, 12)
        Me.cboBigCategory.Name = "cboBigCategory"
        Me.cboBigCategory.Size = New System.Drawing.Size(156, 20)
        Me.cboBigCategory.TabIndex = 2
        '
        'cboSmallCategory
        '
        Me.cboSmallCategory.Location = New System.Drawing.Point(273, 68)
        Me.cboSmallCategory.Name = "cboSmallCategory"
        Me.cboSmallCategory.Size = New System.Drawing.Size(156, 20)
        Me.cboSmallCategory.TabIndex = 101
        '
        'txtEquipmentPN
        '
        Me.txtEquipmentPN.Location = New System.Drawing.Point(64, 40)
        Me.txtEquipmentPN.MaxLength = 50
        Me.txtEquipmentPN.Name = "txtEquipmentPN"
        Me.txtEquipmentPN.Size = New System.Drawing.Size(142, 21)
        Me.txtEquipmentPN.TabIndex = 1
        '
        'txtEquipmentNo
        '
        Me.txtEquipmentNo.Location = New System.Drawing.Point(64, 13)
        Me.txtEquipmentNo.MaxLength = 20
        Me.txtEquipmentNo.Name = "txtEquipmentNo"
        Me.txtEquipmentNo.Size = New System.Drawing.Size(142, 21)
        Me.txtEquipmentNo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "设备料号:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblId)
        Me.GroupBox1.Controls.Add(Me.txtLine)
        Me.GroupBox1.Controls.Add(Me.txtStorage)
        Me.GroupBox1.Controls.Add(Me.lblStorage)
        Me.GroupBox1.Controls.Add(Me.cboInOut)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cboMiddleCategory)
        Me.GroupBox1.Controls.Add(Me.cboBigCategory)
        Me.GroupBox1.Controls.Add(Me.cboSmallCategory)
        Me.GroupBox1.Controls.Add(Me.txtEquipmentPN)
        Me.GroupBox1.Controls.Add(Me.txtEquipmentNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1293, 94)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "设备编号:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 23)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabEquipment)
        Me.SplitContainer1.Size = New System.Drawing.Size(1293, 460)
        Me.SplitContainer1.SplitterDistance = 94
        Me.SplitContainer1.TabIndex = 49
        '
        'TabEquipment
        '
        Me.TabEquipment.Controls.Add(Me.TabPage4)
        Me.TabEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabEquipment.Location = New System.Drawing.Point(0, 0)
        Me.TabEquipment.Name = "TabEquipment"
        Me.TabEquipment.SelectedIndex = 0
        Me.TabEquipment.Size = New System.Drawing.Size(1293, 362)
        Me.TabEquipment.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvEqu)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1285, 336)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "治具"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvEqu
        '
        Me.dgvEqu.AllowUserToAddRows = False
        Me.dgvEqu.BackgroundColor = System.Drawing.Color.White
        Me.dgvEqu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEqu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEqu.Location = New System.Drawing.Point(3, 3)
        Me.dgvEqu.Name = "dgvEqu"
        Me.dgvEqu.RowHeadersVisible = False
        Me.dgvEqu.RowTemplate.Height = 23
        Me.dgvEqu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvEqu.Size = New System.Drawing.Size(1279, 330)
        Me.dgvEqu.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 483)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1293, 22)
        Me.StatusStrip1.TabIndex = 51
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.toolNew, Me.ToolStripSeparator4, Me.toolModify, Me.ToolStripSeparator5, Me.toolSave, Me.ToolStripSeparator2, Me.toolUndo, Me.ToolStripSeparator6, Me.toolSearch, Me.ToolStripSeparator3, Me.toolRefresh, Me.ToolLend, Me.ToolStripSeparator8, Me.toolExport, Me.btnLookLendRecord, Me.ToolStripSeparator7, Me.toolExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1293, 23)
        Me.ToolBt.TabIndex = 50
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'toolNew
        '
        Me.toolNew.Enabled = False
        Me.toolNew.Image = CType(resources.GetObject("toolNew.Image"), System.Drawing.Image)
        Me.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolNew.Name = "toolNew"
        Me.toolNew.Size = New System.Drawing.Size(73, 20)
        Me.toolNew.Tag = "新增"
        Me.toolNew.Text = "新 增(&N)"
        Me.toolNew.ToolTipText = "新增"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'toolModify
        '
        Me.toolModify.Image = CType(resources.GetObject("toolModify.Image"), System.Drawing.Image)
        Me.toolModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModify.Name = "toolModify"
        Me.toolModify.Size = New System.Drawing.Size(73, 20)
        Me.toolModify.Tag = "修改"
        Me.toolModify.Text = "修 改(&E)"
        Me.toolModify.ToolTipText = "修 改"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'toolSave
        '
        Me.toolSave.Enabled = False
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 20)
        Me.toolSave.Text = "保 存(&S)"
        Me.toolSave.ToolTipText = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolUndo
        '
        Me.toolUndo.Enabled = False
        Me.toolUndo.Image = CType(resources.GetObject("toolUndo.Image"), System.Drawing.Image)
        Me.toolUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolUndo.Name = "toolUndo"
        Me.toolUndo.Size = New System.Drawing.Size(67, 20)
        Me.toolUndo.Text = "返回(&C)"
        Me.toolUndo.ToolTipText = "返回"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'toolSearch
        '
        Me.toolSearch.Image = CType(resources.GetObject("toolSearch.Image"), System.Drawing.Image)
        Me.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSearch.Name = "toolSearch"
        Me.toolSearch.Size = New System.Drawing.Size(73, 20)
        Me.toolSearch.Text = "查 找(&F)"
        Me.toolSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'toolRefresh
        '
        Me.toolRefresh.Image = CType(resources.GetObject("toolRefresh.Image"), System.Drawing.Image)
        Me.toolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolRefresh.Name = "toolRefresh"
        Me.toolRefresh.Size = New System.Drawing.Size(73, 20)
        Me.toolRefresh.Text = "刷 新(&R)"
        Me.toolRefresh.ToolTipText = "刷新"
        '
        'ToolLend
        '
        Me.ToolLend.Image = CType(resources.GetObject("ToolLend.Image"), System.Drawing.Image)
        Me.ToolLend.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLend.Name = "ToolLend"
        Me.ToolLend.Size = New System.Drawing.Size(73, 20)
        Me.ToolLend.Tag = "NO"
        Me.ToolLend.Text = "产线转借"
        Me.ToolLend.ToolTipText = "借出/归还"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
        '
        'toolExport
        '
        Me.toolExport.Image = CType(resources.GetObject("toolExport.Image"), System.Drawing.Image)
        Me.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExport.Name = "toolExport"
        Me.toolExport.Size = New System.Drawing.Size(67, 20)
        Me.toolExport.Text = "汇   出"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(73, 20)
        Me.toolExit.Text = "退 出(&X)"
        Me.toolExit.ToolTipText = "退出"
        '
        'btnLookLendRecord
        '
        Me.btnLookLendRecord.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnLookLendRecord.Name = "btnLookLendRecord"
        Me.btnLookLendRecord.Size = New System.Drawing.Size(99, 20)
        Me.btnLookLendRecord.Text = "查看转借记录(&L)"
        Me.btnLookLendRecord.ToolTipText = "导入"
        '
        'FrmLineBorrow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1293, 505)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmLineBorrow"
        Me.Text = "工治具转借"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabEquipment.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvEqu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtLine As System.Windows.Forms.TextBox
    Friend WithEvents txtStorage As System.Windows.Forms.TextBox
    Friend WithEvents lblStorage As System.Windows.Forms.Label
    Friend WithEvents cboInOut As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboMiddleCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboBigCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboSmallCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtEquipmentPN As System.Windows.Forms.TextBox
    Friend WithEvents txtEquipmentNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabEquipment As System.Windows.Forms.TabControl
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgvEqu As System.Windows.Forms.DataGridView
    Friend WithEvents ToolLend As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLookLendRecord As System.Windows.Forms.ToolStripButton
    'Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    'Friend WithEvents tsmiCopy As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents tsmiCopyRecord As System.Windows.Forms.ToolStripMenuItem
End Class
