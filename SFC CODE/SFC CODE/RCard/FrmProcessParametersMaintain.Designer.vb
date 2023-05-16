<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcessParametersMaintain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProcessParametersMaintain))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.tsBtnUploadFile = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripAllowanceParam = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvCD = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtToleranceRange = New System.Windows.Forms.TextBox()
        Me.lblTolerance = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cdCobStatus = New System.Windows.Forms.ComboBox()
        Me.txtCDCutSize = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCDOtherFinishStandard = New System.Windows.Forms.TextBox()
        Me.txtCDEmFinishStandard = New System.Windows.Forms.TextBox()
        Me.txtCDHWFinishStandard = New System.Windows.Forms.TextBox()
        Me.txtCDFinishSizeMax = New System.Windows.Forms.TextBox()
        Me.txtCDFinishSizeMin = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Pager1 = New SysBasicClass.Pager()
        Me.bindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkPath = New System.Windows.Forms.LinkLabel()
        Me.LinkFileName = New System.Windows.Forms.LinkLabel()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtXP = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtSP = New System.Windows.Forms.TextBox()
        Me.txtXX = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtSX = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtOutDaoWidth = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtOutDaoHeight = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtEquPN = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtLineDesc4 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPnOfLineFour = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtLineDesc3 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtPnOfLineThree = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtLineDesc2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPnOfLineTwo = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPnOfCut = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFrontSize = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCutSize = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSizeOfCut = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDrawForce = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtWireWidth = New System.Windows.Forms.TextBox()
        Me.txtWireHeight = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLineDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPnOfLine = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTvName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPnOfTV = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvProcessParameter = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgvHWGC = New System.Windows.Forms.DataGridView()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.toolStripAllowanceParamHW = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtRangeMax = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtGCRange = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cobStatus = New System.Windows.Forms.ComboBox()
        Me.txtRangeMin = New System.Windows.Forms.TextBox()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lkFile = New System.Windows.Forms.LinkLabel()
        Me.ToolBt.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvCD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Pager1.SuspendLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvProcessParameter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgvHWGC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnNew, Me.ToolStripSeparator4, Me.btnModify, Me.ToolStripSeparator5, Me.btnSave, Me.ToolStripSeparator2, Me.btnUndo, Me.ToolStripSeparator6, Me.btnSearch, Me.ToolStripSeparator3, Me.btnRefresh, Me.ToolStripSeparator7, Me.btnImport, Me.btnExport, Me.toolQuery, Me.ToolStripSeparator8, Me.tsBtnUploadFile, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1361, 23)
        Me.ToolBt.TabIndex = 46
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(73, 20)
        Me.btnNew.Tag = ""
        Me.btnNew.Text = "新 增(&N)"
        Me.btnNew.ToolTipText = "新增"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'btnModify
        '
        Me.btnModify.Image = CType(resources.GetObject("btnModify.Image"), System.Drawing.Image)
        Me.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(73, 20)
        Me.btnModify.Tag = ""
        Me.btnModify.Text = "修 改(&E)"
        Me.btnModify.ToolTipText = "修 改"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(73, 20)
        Me.btnSave.Text = "保 存(&S)"
        Me.btnSave.ToolTipText = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'btnUndo
        '
        Me.btnUndo.Enabled = False
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(67, 20)
        Me.btnUndo.Text = "返回(&C)"
        Me.btnUndo.ToolTipText = "返回"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(73, 20)
        Me.btnSearch.Text = "查 找(&F)"
        Me.btnSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(73, 20)
        Me.btnRefresh.Text = "刷 新(&R)"
        Me.btnRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'btnImport
        '
        Me.btnImport.Image = CType(resources.GetObject("btnImport.Image"), System.Drawing.Image)
        Me.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(49, 20)
        Me.btnImport.Text = "导入"
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(49, 20)
        Me.btnExport.Text = "导出"
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(91, 20)
        Me.toolQuery.Text = "筛选查询(&F)"
        Me.toolQuery.ToolTipText = "查找"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(73, 20)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'tsBtnUploadFile
        '
        Me.tsBtnUploadFile.Image = CType(resources.GetObject("tsBtnUploadFile.Image"), System.Drawing.Image)
        Me.tsBtnUploadFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsBtnUploadFile.Name = "tsBtnUploadFile"
        Me.tsBtnUploadFile.Size = New System.Drawing.Size(73, 20)
        Me.tsBtnUploadFile.Text = "上传附件"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(368, 138)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(681, 203)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.StatusStrip1)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1332, 481)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "公差参数"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripAllowanceParam})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 456)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1326, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'toolStripAllowanceParam
        '
        Me.toolStripAllowanceParam.Name = "toolStripAllowanceParam"
        Me.toolStripAllowanceParam.Size = New System.Drawing.Size(71, 17)
        Me.toolStripAllowanceParam.Text = "记录笔数：0"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1332, 447)
        Me.Panel2.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvCD)
        Me.GroupBox4.Location = New System.Drawing.Point(-1, 111)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1328, 329)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "公差参数列表"
        '
        'dgvCD
        '
        Me.dgvCD.AllowUserToAddRows = False
        Me.dgvCD.AllowUserToDeleteRows = False
        Me.dgvCD.BackgroundColor = System.Drawing.Color.White
        Me.dgvCD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCD.Location = New System.Drawing.Point(7, 20)
        Me.dgvCD.Name = "dgvCD"
        Me.dgvCD.ReadOnly = True
        Me.dgvCD.RowHeadersVisible = False
        Me.dgvCD.RowTemplate.Height = 23
        Me.dgvCD.Size = New System.Drawing.Size(1315, 303)
        Me.dgvCD.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblID)
        Me.GroupBox3.Controls.Add(Me.txtToleranceRange)
        Me.GroupBox3.Controls.Add(Me.lblTolerance)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.cdCobStatus)
        Me.GroupBox3.Controls.Add(Me.txtCDCutSize)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtCDOtherFinishStandard)
        Me.GroupBox3.Controls.Add(Me.txtCDEmFinishStandard)
        Me.GroupBox3.Controls.Add(Me.txtCDHWFinishStandard)
        Me.GroupBox3.Controls.Add(Me.txtCDFinishSizeMax)
        Me.GroupBox3.Controls.Add(Me.txtCDFinishSizeMin)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1322, 100)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "公差参数设定"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(1110, 28)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(56, 14)
        Me.lblID.TabIndex = 16
        Me.lblID.Text = "Label21"
        Me.lblID.Visible = False
        '
        'txtToleranceRange
        '
        Me.txtToleranceRange.Location = New System.Drawing.Point(928, 51)
        Me.txtToleranceRange.Name = "txtToleranceRange"
        Me.txtToleranceRange.Size = New System.Drawing.Size(78, 23)
        Me.txtToleranceRange.TabIndex = 7
        '
        'lblTolerance
        '
        Me.lblTolerance.AutoSize = True
        Me.lblTolerance.Location = New System.Drawing.Point(860, 56)
        Me.lblTolerance.Name = "lblTolerance"
        Me.lblTolerance.Size = New System.Drawing.Size(70, 14)
        Me.lblTolerance.TabIndex = 14
        Me.lblTolerance.Text = "公差范围:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(880, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 14)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "状态:"
        '
        'cdCobStatus
        '
        Me.cdCobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cdCobStatus.FormattingEnabled = True
        Me.cdCobStatus.Items.AddRange(New Object() {"Y.有效", "N.无效"})
        Me.cdCobStatus.Location = New System.Drawing.Point(928, 16)
        Me.cdCobStatus.Name = "cdCobStatus"
        Me.cdCobStatus.Size = New System.Drawing.Size(78, 22)
        Me.cdCobStatus.TabIndex = 3
        '
        'txtCDCutSize
        '
        Me.txtCDCutSize.Location = New System.Drawing.Point(703, 51)
        Me.txtCDCutSize.Name = "txtCDCutSize"
        Me.txtCDCutSize.Size = New System.Drawing.Size(131, 23)
        Me.txtCDCutSize.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(591, 56)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 14)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "裁线下公差(mm):"
        '
        'txtCDOtherFinishStandard
        '
        Me.txtCDOtherFinishStandard.Location = New System.Drawing.Point(703, 17)
        Me.txtCDOtherFinishStandard.Name = "txtCDOtherFinishStandard"
        Me.txtCDOtherFinishStandard.Size = New System.Drawing.Size(131, 23)
        Me.txtCDOtherFinishStandard.TabIndex = 2
        '
        'txtCDEmFinishStandard
        '
        Me.txtCDEmFinishStandard.Location = New System.Drawing.Point(465, 51)
        Me.txtCDEmFinishStandard.Name = "txtCDEmFinishStandard"
        Me.txtCDEmFinishStandard.Size = New System.Drawing.Size(108, 23)
        Me.txtCDEmFinishStandard.TabIndex = 5
        '
        'txtCDHWFinishStandard
        '
        Me.txtCDHWFinishStandard.Location = New System.Drawing.Point(465, 18)
        Me.txtCDHWFinishStandard.Name = "txtCDHWFinishStandard"
        Me.txtCDHWFinishStandard.Size = New System.Drawing.Size(108, 23)
        Me.txtCDHWFinishStandard.TabIndex = 1
        '
        'txtCDFinishSizeMax
        '
        Me.txtCDFinishSizeMax.Location = New System.Drawing.Point(166, 51)
        Me.txtCDFinishSizeMax.Name = "txtCDFinishSizeMax"
        Me.txtCDFinishSizeMax.Size = New System.Drawing.Size(111, 23)
        Me.txtCDFinishSizeMax.TabIndex = 4
        '
        'txtCDFinishSizeMin
        '
        Me.txtCDFinishSizeMin.Location = New System.Drawing.Point(166, 17)
        Me.txtCDFinishSizeMin.Name = "txtCDFinishSizeMin"
        Me.txtCDFinishSizeMin.Size = New System.Drawing.Size(111, 23)
        Me.txtCDFinishSizeMin.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(577, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 14)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "其他成品公差标准:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(293, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(168, 14)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "HuaWei成品公差标准(mm):"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(293, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(175, 14)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Emerson成品公差标准(mm):"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(21, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(147, 14)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "成品尺寸范围Max(mm):"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(21, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(147, 14)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "成品尺寸范围Min(mm):"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Pager1)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1332, 481)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "加工工艺参数"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Pager1
        '
        Me.Pager1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pager1.Controls.Add(Me.bindingNavigator)
        Me.Pager1.ExportAllDataToXls = False
        Me.Pager1.ExportPageDataToXls = False
        Me.Pager1.Location = New System.Drawing.Point(137, 447)
        Me.Pager1.Name = "Pager1"
        Me.Pager1.NMax = 0
        Me.Pager1.PageCount = 0
        Me.Pager1.PageCurrent = 0
        Me.Pager1.PageSize = 100
        Me.Pager1.QuerySeconds = 0.0R
        Me.Pager1.Size = New System.Drawing.Size(880, 30)
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
        Me.bindingNavigator.Size = New System.Drawing.Size(880, 30)
        Me.bindingNavigator.TabIndex = 0
        Me.bindingNavigator.Text = "bindingNavigator1"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1332, 441)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkPath)
        Me.GroupBox1.Controls.Add(Me.LinkFileName)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.txtXP)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.txtSP)
        Me.GroupBox1.Controls.Add(Me.txtXX)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.txtSX)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.txtOutDaoWidth)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.txtOutDaoHeight)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.txtEquPN)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txtLineDesc4)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.txtPnOfLineFour)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.txtLineDesc3)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtPnOfLineThree)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.txtLineDesc2)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtPnOfLineTwo)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtPnOfCut)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtFrontSize)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtCutSize)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtSizeOfCut)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtDrawForce)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtWireWidth)
        Me.GroupBox1.Controls.Add(Me.txtWireHeight)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtLineDesc)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPnOfLine)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTvName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPnOfTV)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1324, 161)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "工艺参数设定"
        '
        'LinkPath
        '
        Me.LinkPath.AutoSize = True
        Me.LinkPath.Location = New System.Drawing.Point(409, 143)
        Me.LinkPath.Name = "LinkPath"
        Me.LinkPath.Size = New System.Drawing.Size(23, 12)
        Me.LinkPath.TabIndex = 52
        Me.LinkPath.TabStop = True
        Me.LinkPath.Text = "   "
        Me.LinkPath.Visible = False
        '
        'LinkFileName
        '
        Me.LinkFileName.AutoSize = True
        Me.LinkFileName.Location = New System.Drawing.Point(80, 143)
        Me.LinkFileName.Name = "LinkFileName"
        Me.LinkFileName.Size = New System.Drawing.Size(17, 12)
        Me.LinkFileName.TabIndex = 51
        Me.LinkFileName.TabStop = True
        Me.LinkFileName.Text = "  "
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(13, 143)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(53, 12)
        Me.Label37.TabIndex = 50
        Me.Label37.Text = "附件名称"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label33.Location = New System.Drawing.Point(1100, 115)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(98, 14)
        Me.Label33.TabIndex = 49
        Me.Label33.Text = "下皮刀片规格:"
        '
        'txtXP
        '
        Me.txtXP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtXP.Location = New System.Drawing.Point(1198, 112)
        Me.txtXP.Name = "txtXP"
        Me.txtXP.Size = New System.Drawing.Size(112, 21)
        Me.txtXP.TabIndex = 48
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label32.Location = New System.Drawing.Point(894, 119)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(98, 14)
        Me.Label32.TabIndex = 47
        Me.Label32.Text = "上皮刀片规格:"
        '
        'txtSP
        '
        Me.txtSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSP.Location = New System.Drawing.Point(998, 115)
        Me.txtSP.Name = "txtSP"
        Me.txtSP.Size = New System.Drawing.Size(96, 21)
        Me.txtSP.TabIndex = 46
        '
        'txtXX
        '
        Me.txtXX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtXX.Location = New System.Drawing.Point(763, 115)
        Me.txtXX.Name = "txtXX"
        Me.txtXX.Size = New System.Drawing.Size(122, 21)
        Me.txtXX.TabIndex = 45
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label31.Location = New System.Drawing.Point(659, 119)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(98, 14)
        Me.Label31.TabIndex = 44
        Me.Label31.Text = "下芯刀片规格:"
        '
        'txtSX
        '
        Me.txtSX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSX.Location = New System.Drawing.Point(574, 115)
        Me.txtSX.Name = "txtSX"
        Me.txtSX.Size = New System.Drawing.Size(84, 21)
        Me.txtSX.TabIndex = 43
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label30.Location = New System.Drawing.Point(470, 119)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(98, 14)
        Me.Label30.TabIndex = 42
        Me.Label30.Text = "上芯刀片规格:"
        '
        'txtOutDaoWidth
        '
        Me.txtOutDaoWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutDaoWidth.Location = New System.Drawing.Point(332, 115)
        Me.txtOutDaoWidth.Name = "txtOutDaoWidth"
        Me.txtOutDaoWidth.Size = New System.Drawing.Size(119, 21)
        Me.txtOutDaoWidth.TabIndex = 41
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label29.Location = New System.Drawing.Point(214, 118)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 14)
        Me.Label29.TabIndex = 40
        Me.Label29.Text = "外刀压着宽度W2:"
        '
        'txtOutDaoHeight
        '
        Me.txtOutDaoHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutDaoHeight.Location = New System.Drawing.Point(109, 113)
        Me.txtOutDaoHeight.Name = "txtOutDaoHeight"
        Me.txtOutDaoHeight.Size = New System.Drawing.Size(99, 21)
        Me.txtOutDaoHeight.TabIndex = 39
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label28.Location = New System.Drawing.Point(2, 118)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(112, 14)
        Me.Label28.TabIndex = 38
        Me.Label28.Text = "外刀压着高度H2:"
        '
        'txtEquPN
        '
        Me.txtEquPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEquPN.Location = New System.Drawing.Point(1200, 85)
        Me.txtEquPN.Name = "txtEquPN"
        Me.txtEquPN.Size = New System.Drawing.Size(110, 21)
        Me.txtEquPN.TabIndex = 36
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label27.Location = New System.Drawing.Point(1114, 88)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(84, 14)
        Me.Label27.TabIndex = 37
        Me.Label27.Text = "工治具料号:"
        '
        'txtLineDesc4
        '
        Me.txtLineDesc4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineDesc4.Location = New System.Drawing.Point(970, 47)
        Me.txtLineDesc4.Name = "txtLineDesc4"
        Me.txtLineDesc4.Size = New System.Drawing.Size(138, 21)
        Me.txtLineDesc4.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(1152, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 14)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "状态:"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"1.有效", "0.无效"})
        Me.cboStatus.Location = New System.Drawing.Point(1198, 48)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(110, 20)
        Me.cboStatus.TabIndex = 11
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label25.Location = New System.Drawing.Point(894, 51)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(77, 14)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "线材规格4:"
        '
        'txtPnOfLineFour
        '
        Me.txtPnOfLineFour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfLineFour.Location = New System.Drawing.Point(970, 16)
        Me.txtPnOfLineFour.Name = "txtPnOfLineFour"
        Me.txtPnOfLineFour.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfLineFour.TabIndex = 4
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label26.Location = New System.Drawing.Point(894, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(77, 14)
        Me.Label26.TabIndex = 33
        Me.Label26.Text = "线材料号4:"
        '
        'txtLineDesc3
        '
        Me.txtLineDesc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineDesc3.Location = New System.Drawing.Point(747, 47)
        Me.txtLineDesc3.Name = "txtLineDesc3"
        Me.txtLineDesc3.Size = New System.Drawing.Size(138, 21)
        Me.txtLineDesc3.TabIndex = 9
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label23.Location = New System.Drawing.Point(670, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 14)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "线材规格3:"
        '
        'txtPnOfLineThree
        '
        Me.txtPnOfLineThree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfLineThree.Location = New System.Drawing.Point(747, 15)
        Me.txtPnOfLineThree.Name = "txtPnOfLineThree"
        Me.txtPnOfLineThree.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfLineThree.TabIndex = 3
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label24.Location = New System.Drawing.Point(670, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 14)
        Me.Label24.TabIndex = 29
        Me.Label24.Text = "线材料号3:"
        '
        'txtLineDesc2
        '
        Me.txtLineDesc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineDesc2.Location = New System.Drawing.Point(520, 48)
        Me.txtLineDesc2.Name = "txtLineDesc2"
        Me.txtLineDesc2.Size = New System.Drawing.Size(138, 21)
        Me.txtLineDesc2.TabIndex = 8
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label21.Location = New System.Drawing.Point(443, 51)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 14)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "线材规格2:"
        '
        'txtPnOfLineTwo
        '
        Me.txtPnOfLineTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfLineTwo.Location = New System.Drawing.Point(520, 15)
        Me.txtPnOfLineTwo.Name = "txtPnOfLineTwo"
        Me.txtPnOfLineTwo.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfLineTwo.TabIndex = 2
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label22.Location = New System.Drawing.Point(443, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 14)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "线材料号2:"
        '
        'txtPnOfCut
        '
        Me.txtPnOfCut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfCut.Location = New System.Drawing.Point(1198, 13)
        Me.txtPnOfCut.Name = "txtPnOfCut"
        Me.txtPnOfCut.Size = New System.Drawing.Size(110, 21)
        Me.txtPnOfCut.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.Location = New System.Drawing.Point(1124, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 14)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "刀模料号:"
        '
        'txtFrontSize
        '
        Me.txtFrontSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFrontSize.Location = New System.Drawing.Point(290, 85)
        Me.txtFrontSize.Name = "txtFrontSize"
        Me.txtFrontSize.Size = New System.Drawing.Size(69, 21)
        Me.txtFrontSize.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label12.Location = New System.Drawing.Point(214, 88)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "前端尺寸:"
        '
        'txtCutSize
        '
        Me.txtCutSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCutSize.Location = New System.Drawing.Point(1038, 88)
        Me.txtCutSize.Name = "txtCutSize"
        Me.txtCutSize.Size = New System.Drawing.Size(70, 21)
        Me.txtCutSize.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(969, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 14)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "裁线尺寸:"
        '
        'txtSizeOfCut
        '
        Me.txtSizeOfCut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSizeOfCut.Location = New System.Drawing.Point(80, 86)
        Me.txtSizeOfCut.Name = "txtSizeOfCut"
        Me.txtSizeOfCut.Size = New System.Drawing.Size(95, 21)
        Me.txtSizeOfCut.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 14)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "脱皮尺寸:"
        '
        'txtDrawForce
        '
        Me.txtDrawForce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDrawForce.Location = New System.Drawing.Point(859, 90)
        Me.txtDrawForce.Name = "txtDrawForce"
        Me.txtDrawForce.Size = New System.Drawing.Size(104, 21)
        Me.txtDrawForce.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(808, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "拉拔力:"
        '
        'txtWireWidth
        '
        Me.txtWireWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWireWidth.Location = New System.Drawing.Point(696, 88)
        Me.txtWireWidth.Name = "txtWireWidth"
        Me.txtWireWidth.Size = New System.Drawing.Size(106, 21)
        Me.txtWireWidth.TabIndex = 15
        '
        'txtWireHeight
        '
        Me.txtWireHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWireHeight.Location = New System.Drawing.Point(477, 88)
        Me.txtWireHeight.Name = "txtWireHeight"
        Me.txtWireHeight.Size = New System.Drawing.Size(76, 21)
        Me.txtWireHeight.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(578, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 14)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "内刀压着宽度W1:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(365, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "内刀压着高度H1:"
        '
        'txtLineDesc
        '
        Me.txtLineDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineDesc.Location = New System.Drawing.Point(300, 50)
        Me.txtLineDesc.Name = "txtLineDesc"
        Me.txtLineDesc.Size = New System.Drawing.Size(137, 21)
        Me.txtLineDesc.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(224, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "线材规格1:"
        '
        'txtPnOfLine
        '
        Me.txtPnOfLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfLine.Location = New System.Drawing.Point(299, 17)
        Me.txtPnOfLine.Name = "txtPnOfLine"
        Me.txtPnOfLine.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfLine.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(224, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "线材料号1:"
        '
        'txtTvName
        '
        Me.txtTvName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTvName.Location = New System.Drawing.Point(80, 49)
        Me.txtTvName.Name = "txtTvName"
        Me.txtTvName.Size = New System.Drawing.Size(138, 21)
        Me.txtTvName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "端子规格:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "端子料号:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 12)
        Me.Label1.TabIndex = 1
        '
        'txtPnOfTV
        '
        Me.txtPnOfTV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPnOfTV.Location = New System.Drawing.Point(80, 17)
        Me.txtPnOfTV.Name = "txtPnOfTV"
        Me.txtPnOfTV.Size = New System.Drawing.Size(138, 21)
        Me.txtPnOfTV.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvProcessParameter)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1324, 267)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "工艺参数列表"
        '
        'dgvProcessParameter
        '
        Me.dgvProcessParameter.AllowUserToAddRows = False
        Me.dgvProcessParameter.BackgroundColor = System.Drawing.Color.White
        Me.dgvProcessParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProcessParameter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProcessParameter.Location = New System.Drawing.Point(3, 17)
        Me.dgvProcessParameter.Name = "dgvProcessParameter"
        Me.dgvProcessParameter.ReadOnly = True
        Me.dgvProcessParameter.RowHeadersVisible = False
        Me.dgvProcessParameter.RowTemplate.Height = 23
        Me.dgvProcessParameter.Size = New System.Drawing.Size(1318, 247)
        Me.dgvProcessParameter.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(1, 30)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1340, 507)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Controls.Add(Me.StatusStrip2)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1332, 481)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "端子高宽度公差"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgvHWGC)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 121)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1321, 332)
        Me.GroupBox6.TabIndex = 4
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "端子高宽度公差列表"
        '
        'dgvHWGC
        '
        Me.dgvHWGC.AllowUserToAddRows = False
        Me.dgvHWGC.AllowUserToDeleteRows = False
        Me.dgvHWGC.BackgroundColor = System.Drawing.Color.White
        Me.dgvHWGC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHWGC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHWGC.Location = New System.Drawing.Point(3, 17)
        Me.dgvHWGC.Name = "dgvHWGC"
        Me.dgvHWGC.ReadOnly = True
        Me.dgvHWGC.RowHeadersVisible = False
        Me.dgvHWGC.RowTemplate.Height = 23
        Me.dgvHWGC.Size = New System.Drawing.Size(1315, 312)
        Me.dgvHWGC.TabIndex = 2
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripAllowanceParamHW})
        Me.StatusStrip2.Location = New System.Drawing.Point(3, 456)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(1326, 22)
        Me.StatusStrip2.TabIndex = 3
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'toolStripAllowanceParamHW
        '
        Me.toolStripAllowanceParamHW.Name = "toolStripAllowanceParamHW"
        Me.toolStripAllowanceParamHW.Size = New System.Drawing.Size(71, 17)
        Me.toolStripAllowanceParamHW.Tag = ""
        Me.toolStripAllowanceParamHW.Text = "记录笔数：0"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtRangeMax)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.txtGCRange)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Controls.Add(Me.cobStatus)
        Me.GroupBox5.Controls.Add(Me.txtRangeMin)
        Me.GroupBox5.Controls.Add(Me.txtItemName)
        Me.GroupBox5.Controls.Add(Me.Label41)
        Me.GroupBox5.Controls.Add(Me.Label42)
        Me.GroupBox5.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(5, 15)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1322, 100)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "公差参数设定"
        '
        'txtRangeMax
        '
        Me.txtRangeMax.Location = New System.Drawing.Point(758, 15)
        Me.txtRangeMax.Name = "txtRangeMax"
        Me.txtRangeMax.Size = New System.Drawing.Size(108, 23)
        Me.txtRangeMax.TabIndex = 18
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(661, 19)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(91, 14)
        Me.Label38.TabIndex = 17
        Me.Label38.Text = "范围Max(mm):"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(1110, 22)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 14)
        Me.Label34.TabIndex = 16
        Me.Label34.Text = "Label21"
        Me.Label34.Visible = False
        '
        'txtGCRange
        '
        Me.txtGCRange.Location = New System.Drawing.Point(97, 54)
        Me.txtGCRange.Name = "txtGCRange"
        Me.txtGCRange.Size = New System.Drawing.Size(180, 23)
        Me.txtGCRange.TabIndex = 7
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(21, 54)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(70, 14)
        Me.Label35.TabIndex = 14
        Me.Label35.Text = "公差范围:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(937, 19)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(42, 14)
        Me.Label36.TabIndex = 13
        Me.Label36.Text = "状态:"
        '
        'cobStatus
        '
        Me.cobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobStatus.FormattingEnabled = True
        Me.cobStatus.Items.AddRange(New Object() {"1.有效", "0.无效"})
        Me.cobStatus.Location = New System.Drawing.Point(985, 16)
        Me.cobStatus.Name = "cobStatus"
        Me.cobStatus.Size = New System.Drawing.Size(78, 22)
        Me.cobStatus.TabIndex = 3
        '
        'txtRangeMin
        '
        Me.txtRangeMin.Location = New System.Drawing.Point(440, 14)
        Me.txtRangeMin.Name = "txtRangeMin"
        Me.txtRangeMin.Size = New System.Drawing.Size(135, 23)
        Me.txtRangeMin.TabIndex = 4
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(97, 17)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(180, 23)
        Me.txtItemName.TabIndex = 0
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(343, 19)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(91, 14)
        Me.Label41.TabIndex = 1
        Me.Label41.Text = "范围Min(mm):"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(21, 21)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(70, 14)
        Me.Label42.TabIndex = 0
        Me.Label42.Text = "压接部位:"
        '
        'lkFile
        '
        Me.lkFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lkFile.AutoSize = True
        Me.lkFile.Location = New System.Drawing.Point(1026, 7)
        Me.lkFile.Name = "lkFile"
        Me.lkFile.Size = New System.Drawing.Size(77, 12)
        Me.lkFile.TabIndex = 240
        Me.lkFile.TabStop = True
        Me.lkFile.Text = "查看导入格式"
        '
        'FrmProcessParametersMaintain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1361, 536)
        Me.Controls.Add(Me.lkFile)
        Me.Controls.Add(Me.ToolBt)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmProcessParametersMaintain"
        Me.Text = "工艺参数维护"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvCD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.Pager1.ResumeLayout(False)
        Me.Pager1.PerformLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvProcessParameter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgvHWGC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCD As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents txtToleranceRange As System.Windows.Forms.TextBox
    Friend WithEvents lblTolerance As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cdCobStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtCDCutSize As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCDOtherFinishStandard As System.Windows.Forms.TextBox
    Friend WithEvents txtCDEmFinishStandard As System.Windows.Forms.TextBox
    Friend WithEvents txtCDHWFinishStandard As System.Windows.Forms.TextBox
    Friend WithEvents txtCDFinishSizeMax As System.Windows.Forms.TextBox
    Friend WithEvents txtCDFinishSizeMin As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOutDaoWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtOutDaoHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtEquPN As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtLineDesc4 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfLineFour As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtLineDesc3 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfLineThree As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtLineDesc2 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfLineTwo As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfCut As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtFrontSize As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCutSize As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSizeOfCut As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDrawForce As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtWireWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtWireHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLineDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfLine As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTvName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPnOfTV As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvProcessParameter As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtXP As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtSP As System.Windows.Forms.TextBox
    Friend WithEvents txtXX As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtSX As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRangeMax As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtGCRange As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cobStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtRangeMin As System.Windows.Forms.TextBox
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents dgvHWGC As System.Windows.Forms.DataGridView
    Friend WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents Pager1 As SysBasicClass.Pager
    Friend WithEvents bindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents toolStripAllowanceParam As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents toolStripAllowanceParamHW As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lkFile As System.Windows.Forms.LinkLabel
    Friend WithEvents tsBtnUploadFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents LinkFileName As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkPath As System.Windows.Forms.LinkLabel
End Class
