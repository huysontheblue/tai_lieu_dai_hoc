<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMaterialReg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMaterialReg))
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRegRecord = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabEquipment = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgvReg = New System.Windows.Forms.DataGridView()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.dgvRegLog = New System.Windows.Forms.DataGridView()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvBaseQty = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSafeQty = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtReqUserID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPartID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.ContextMenuStripAsset = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmi_MaintenanceDay = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_MaintenanceMonth = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmi_MaintenanceType = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolUndo = New System.Windows.Forms.ToolStripButton()
        Me.toolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolExport = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRecord = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolBaseQty = New System.Windows.Forms.ToolStripButton()
        Me.ToolLook = New System.Windows.Forms.ToolStripButton()
        Me.toolBuyList = New System.Windows.Forms.ToolStripButton()
        Me.Colchk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColINB04 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colima02 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colima021 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colinb16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColResidualQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSafetyStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.TabEquipment.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvReg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgvRegLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.dgvBaseQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStripAsset.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 23)
        '
        'toolRegRecord
        '
        Me.toolRegRecord.Image = CType(resources.GetObject("toolRegRecord.Image"), System.Drawing.Image)
        Me.toolRegRecord.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolRegRecord.Name = "toolRegRecord"
        Me.toolRegRecord.Size = New System.Drawing.Size(76, 20)
        Me.toolRegRecord.Text = "领用登记"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'TabEquipment
        '
        Me.TabEquipment.Controls.Add(Me.TabPage4)
        Me.TabEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabEquipment.Location = New System.Drawing.Point(0, 0)
        Me.TabEquipment.Name = "TabEquipment"
        Me.TabEquipment.SelectedIndex = 0
        Me.TabEquipment.Size = New System.Drawing.Size(1152, 297)
        Me.TabEquipment.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.SplitContainer2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1144, 271)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "料信息"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvReg)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(1138, 265)
        Me.SplitContainer2.SplitterDistance = 787
        Me.SplitContainer2.TabIndex = 0
        '
        'dgvReg
        '
        Me.dgvReg.AllowUserToAddRows = False
        Me.dgvReg.BackgroundColor = System.Drawing.Color.White
        Me.dgvReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Colchk, Me.ColINB04, Me.Colima02, Me.Colima021, Me.Colinb16, Me.ColResidualQuantity, Me.ColSafetyStock, Me.ColGAP})
        Me.dgvReg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReg.Location = New System.Drawing.Point(0, 0)
        Me.dgvReg.Name = "dgvReg"
        Me.dgvReg.RowHeadersVisible = False
        Me.dgvReg.RowTemplate.Height = 23
        Me.dgvReg.Size = New System.Drawing.Size(787, 265)
        Me.dgvReg.TabIndex = 1
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
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgvRegLog)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer3.Size = New System.Drawing.Size(347, 265)
        Me.SplitContainer3.SplitterDistance = 118
        Me.SplitContainer3.TabIndex = 0
        '
        'dgvRegLog
        '
        Me.dgvRegLog.AllowUserToAddRows = False
        Me.dgvRegLog.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvRegLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRegLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRegLog.Location = New System.Drawing.Point(0, 0)
        Me.dgvRegLog.Name = "dgvRegLog"
        Me.dgvRegLog.RowHeadersVisible = False
        Me.dgvRegLog.RowTemplate.Height = 23
        Me.dgvRegLog.Size = New System.Drawing.Size(347, 118)
        Me.dgvRegLog.TabIndex = 0
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.dgvBaseQty)
        Me.SplitContainer4.Size = New System.Drawing.Size(347, 143)
        Me.SplitContainer4.SplitterDistance = 26
        Me.SplitContainer4.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "期初数记录:"
        '
        'dgvBaseQty
        '
        Me.dgvBaseQty.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvBaseQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBaseQty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBaseQty.Location = New System.Drawing.Point(0, 0)
        Me.dgvBaseQty.Name = "dgvBaseQty"
        Me.dgvBaseQty.RowTemplate.Height = 23
        Me.dgvBaseQty.Size = New System.Drawing.Size(347, 113)
        Me.dgvBaseQty.TabIndex = 0
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1152, 371)
        Me.SplitContainer1.SplitterDistance = 70
        Me.SplitContainer1.TabIndex = 55
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSafeQty)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtReqUserID)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtQty)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPName)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPartID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblId)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1152, 70)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        '
        'txtSafeQty
        '
        Me.txtSafeQty.Location = New System.Drawing.Point(89, 50)
        Me.txtSafeQty.MaxLength = 20
        Me.txtSafeQty.Name = "txtSafeQty"
        Me.txtSafeQty.Size = New System.Drawing.Size(151, 21)
        Me.txtSafeQty.TabIndex = 113
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "安全库存:"
        '
        'txtReqUserID
        '
        Me.txtReqUserID.Location = New System.Drawing.Point(620, 50)
        Me.txtReqUserID.MaxLength = 20
        Me.txtReqUserID.Name = "txtReqUserID"
        Me.txtReqUserID.Size = New System.Drawing.Size(149, 21)
        Me.txtReqUserID.TabIndex = 111
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(548, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 12)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "申请人工号:"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(335, 50)
        Me.txtQty.MaxLength = 20
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(142, 21)
        Me.txtQty.TabIndex = 109
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(292, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 12)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "数量:"
        '
        'txtPName
        '
        Me.txtPName.Location = New System.Drawing.Point(335, 18)
        Me.txtPName.Name = "txtPName"
        Me.txtPName.Size = New System.Drawing.Size(142, 21)
        Me.txtPName.TabIndex = 107
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(288, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "品名:"
        '
        'txtPartID
        '
        Me.txtPartID.Location = New System.Drawing.Point(89, 16)
        Me.txtPartID.MaxLength = 20
        Me.txtPartID.Name = "txtPartID"
        Me.txtPartID.Size = New System.Drawing.Size(151, 21)
        Me.txtPartID.TabIndex = 105
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "料件编号:"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(974, 53)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(35, 12)
        Me.lblId.TabIndex = 94
        Me.lblId.Text = "lblId"
        Me.lblId.Visible = False
        '
        'ContextMenuStripAsset
        '
        Me.ContextMenuStripAsset.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmi_MaintenanceDay, Me.tsmi_MaintenanceMonth, Me.tsmi_MaintenanceType})
        Me.ContextMenuStripAsset.Name = "ContextMenuStripAsset"
        Me.ContextMenuStripAsset.Size = New System.Drawing.Size(188, 70)
        '
        'tsmi_MaintenanceDay
        '
        Me.tsmi_MaintenanceDay.Image = CType(resources.GetObject("tsmi_MaintenanceDay.Image"), System.Drawing.Image)
        Me.tsmi_MaintenanceDay.Name = "tsmi_MaintenanceDay"
        Me.tsmi_MaintenanceDay.Size = New System.Drawing.Size(187, 22)
        Me.tsmi_MaintenanceDay.Text = "设备日保养(&D)"
        '
        'tsmi_MaintenanceMonth
        '
        Me.tsmi_MaintenanceMonth.Image = CType(resources.GetObject("tsmi_MaintenanceMonth.Image"), System.Drawing.Image)
        Me.tsmi_MaintenanceMonth.Name = "tsmi_MaintenanceMonth"
        Me.tsmi_MaintenanceMonth.Size = New System.Drawing.Size(187, 22)
        Me.tsmi_MaintenanceMonth.Text = "设备月/季保养(&M)"
        '
        'tsmi_MaintenanceType
        '
        Me.tsmi_MaintenanceType.Image = CType(resources.GetObject("tsmi_MaintenanceType.Image"), System.Drawing.Image)
        Me.tsmi_MaintenanceType.Name = "tsmi_MaintenanceType"
        Me.tsmi_MaintenanceType.Size = New System.Drawing.Size(187, 22)
        Me.tsmi_MaintenanceType.Text = "设备保养项目维护(&T)"
        '
        'toolModify
        '
        Me.toolModify.Image = CType(resources.GetObject("toolModify.Image"), System.Drawing.Image)
        Me.toolModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModify.Name = "toolModify"
        Me.toolModify.Size = New System.Drawing.Size(71, 20)
        Me.toolModify.Tag = "修改"
        Me.toolModify.Text = "修 改(&E)"
        Me.toolModify.ToolTipText = "修 改"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'toolSearch
        '
        Me.toolSearch.Image = CType(resources.GetObject("toolSearch.Image"), System.Drawing.Image)
        Me.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSearch.Name = "toolSearch"
        Me.toolSearch.Size = New System.Drawing.Size(70, 20)
        Me.toolSearch.Text = "查 找(&F)"
        Me.toolSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'toolUndo
        '
        Me.toolUndo.Enabled = False
        Me.toolUndo.Image = CType(resources.GetObject("toolUndo.Image"), System.Drawing.Image)
        Me.toolUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolUndo.Name = "toolUndo"
        Me.toolUndo.Size = New System.Drawing.Size(68, 20)
        Me.toolUndo.Text = "返回(&C)"
        Me.toolUndo.ToolTipText = "返回"
        '
        'toolRefresh
        '
        Me.toolRefresh.Image = CType(resources.GetObject("toolRefresh.Image"), System.Drawing.Image)
        Me.toolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolRefresh.Name = "toolRefresh"
        Me.toolRefresh.Size = New System.Drawing.Size(72, 20)
        Me.toolRefresh.Text = "刷 新(&R)"
        Me.toolRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
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
        Me.toolSave.Size = New System.Drawing.Size(71, 20)
        Me.toolSave.Text = "保 存(&S)"
        Me.toolSave.ToolTipText = "保存"
        '
        'toolExport
        '
        Me.toolExport.Image = CType(resources.GetObject("toolExport.Image"), System.Drawing.Image)
        Me.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExport.Name = "toolExport"
        Me.toolExport.Size = New System.Drawing.Size(64, 20)
        Me.toolExport.Text = "汇   出"
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 21)
        Me.toolExit.Text = "退 出(&X)"
        Me.toolExit.ToolTipText = "退出"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'toolNew
        '
        Me.toolNew.Image = CType(resources.GetObject("toolNew.Image"), System.Drawing.Image)
        Me.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolNew.Name = "toolNew"
        Me.toolNew.Size = New System.Drawing.Size(74, 20)
        Me.toolNew.Tag = "新增"
        Me.toolNew.Text = "新 增(&N)"
        Me.toolNew.ToolTipText = "新增"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatusLabel, Me.ToolStripStatusLabel1, Me.lblRecord})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 394)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1152, 22)
        Me.StatusStrip1.TabIndex = 57
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStatusLabel
        '
        Me.ToolStatusLabel.Name = "ToolStatusLabel"
        Me.ToolStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数:"
        '
        'lblRecord
        '
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(15, 17)
        Me.lblRecord.Text = "0"
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.toolNew, Me.ToolStripSeparator4, Me.toolModify, Me.toolDelete, Me.toolAbandon, Me.ToolStripSeparator5, Me.toolSave, Me.ToolStripSeparator2, Me.toolUndo, Me.ToolStripSeparator6, Me.toolSearch, Me.ToolStripSeparator3, Me.toolRefresh, Me.ToolStripButton1, Me.ToolBaseQty, Me.ToolStripSeparator10, Me.toolRegRecord, Me.ToolStripSeparator11, Me.ToolLook, Me.toolExport, Me.ToolStripSeparator7, Me.toolBuyList, Me.toolExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1152, 23)
        Me.ToolBt.TabIndex = 56
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(73, 20)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "屏 蔽(&D)"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(92, 20)
        Me.ToolStripButton1.Text = "查看全部(&R)"
        Me.ToolStripButton1.ToolTipText = "刷新"
        '
        'ToolBaseQty
        '
        Me.ToolBaseQty.Image = CType(resources.GetObject("ToolBaseQty.Image"), System.Drawing.Image)
        Me.ToolBaseQty.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBaseQty.Name = "ToolBaseQty"
        Me.ToolBaseQty.Size = New System.Drawing.Size(112, 20)
        Me.ToolBaseQty.Tag = "NO"
        Me.ToolBaseQty.Text = "料号初始数维护"
        Me.ToolBaseQty.ToolTipText = "借出/归还"
        '
        'ToolLook
        '
        Me.ToolLook.Image = CType(resources.GetObject("ToolLook.Image"), System.Drawing.Image)
        Me.ToolLook.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLook.Name = "ToolLook"
        Me.ToolLook.Size = New System.Drawing.Size(100, 20)
        Me.ToolLook.Tag = "NO"
        Me.ToolLook.Text = "查看领用记录"
        Me.ToolLook.ToolTipText = "借出/归还"
        '
        'toolBuyList
        '
        Me.toolBuyList.Image = CType(resources.GetObject("toolBuyList.Image"), System.Drawing.Image)
        Me.toolBuyList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBuyList.Name = "toolBuyList"
        Me.toolBuyList.Size = New System.Drawing.Size(103, 21)
        Me.toolBuyList.Tag = "修改"
        Me.toolBuyList.Text = "请购人维护(&E)"
        Me.toolBuyList.ToolTipText = "修 改"
        '
        'Colchk
        '
        Me.Colchk.DataPropertyName = "Colchk"
        Me.Colchk.FalseValue = "False"
        Me.Colchk.HeaderText = "全选"
        Me.Colchk.Name = "Colchk"
        Me.Colchk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Colchk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Colchk.TrueValue = "True"
        '
        'ColINB04
        '
        Me.ColINB04.DataPropertyName = "INB04"
        Me.ColINB04.HeaderText = "料件编号"
        Me.ColINB04.Name = "ColINB04"
        '
        'Colima02
        '
        Me.Colima02.DataPropertyName = "ima02"
        Me.Colima02.HeaderText = "品名"
        Me.Colima02.Name = "Colima02"
        '
        'Colima021
        '
        Me.Colima021.DataPropertyName = "ima021"
        Me.Colima021.HeaderText = "规格"
        Me.Colima021.Name = "Colima021"
        '
        'Colinb16
        '
        Me.Colinb16.DataPropertyName = "Colinb16"
        Me.Colinb16.HeaderText = "Tiptop总入库数量"
        Me.Colinb16.Name = "Colinb16"
        '
        'ColResidualQuantity
        '
        Me.ColResidualQuantity.DataPropertyName = "ResidualQuantity"
        Me.ColResidualQuantity.HeaderText = "剩余数量"
        Me.ColResidualQuantity.Name = "ColResidualQuantity"
        '
        'ColSafetyStock
        '
        Me.ColSafetyStock.DataPropertyName = "SafetyStock"
        Me.ColSafetyStock.HeaderText = "安全库存"
        Me.ColSafetyStock.Name = "ColSafetyStock"
        '
        'ColGAP
        '
        Me.ColGAP.DataPropertyName = "GAP"
        Me.ColGAP.HeaderText = "GAP"
        Me.ColGAP.Name = "ColGAP"
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(73, 20)
        Me.toolDelete.Tag = "删 除"
        Me.toolDelete.Text = "删 除(&D)"
        Me.toolDelete.ToolTipText = "刪除"
        '
        'FrmMaterialReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 416)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmMaterialReg"
        Me.Text = "机加工物料登记"
        Me.TabEquipment.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvReg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgvRegLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.dgvBaseQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStripAsset.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRegRecord As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabEquipment As System.Windows.Forms.TabControl
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgvReg As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPartID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripAsset As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmi_MaintenanceDay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_MaintenanceMonth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmi_MaintenanceType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolLook As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvRegLog As System.Windows.Forms.DataGridView
    Friend WithEvents txtReqUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents toolBuyList As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBaseQty As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvBaseQty As System.Windows.Forms.DataGridView
    Friend WithEvents txtSafeQty As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRecord As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Colchk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColINB04 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colima02 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colima021 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colinb16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColResidualQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSafetyStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGAP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toolDelete As System.Windows.Forms.ToolStripButton
End Class
