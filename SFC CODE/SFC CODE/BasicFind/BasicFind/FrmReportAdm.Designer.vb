<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportAdm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportAdm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolUnDo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.btnReportView = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BnSelectSta = New System.Windows.Forms.Button()
        Me.LblDown = New System.Windows.Forms.Label()
        Me.LblUp = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSEQ = New System.Windows.Forms.TextBox()
        Me.txtCONDITIONSQL = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.comPARA_TYPE = New System.Windows.Forms.ComboBox()
        Me.txtTABLENAME = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDEFAULT_VALUE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPARA_LENGTH = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPARA_CHG_NAME = New System.Windows.Forms.TextBox()
        Me.ChkISNUL = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPARA_NAME = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTtext1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSQLSCRIPT1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txttkey1 = New System.Windows.Forms.TextBox()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Tkey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QRYSEQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARA_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARA_CHG_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARA_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARA_LENGTH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEFAULT_VALUE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TABLENAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ISNUL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONDITIONSQL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAMPUSERNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAMPDATETIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.AdvTree1 = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnquerytest = New System.Windows.Forms.Button()
        Me.txtChartTitle = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtChartType = New System.Windows.Forms.ComboBox()
        Me.txtChartScript = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chkChartUsey = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtDetScript = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkDetUsey = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkSqlUsey = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtSQLSCRIPT = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbTparent = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtTkey = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTtext = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTreeTag = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEnname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ToolBt.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolDelete, Me.ToolSave, Me.ToolUnDo, Me.ToolStripSeparator2, Me.ToolRefresh, Me.btnReportView, Me.ToolStripSeparator3, Me.ToolStripButton1})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1234, 25)
        Me.ToolBt.TabIndex = 143
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(74, 22)
        Me.ToolNew.Tag = "YES"
        Me.ToolNew.Text = "新 增(&N)"
        Me.ToolNew.ToolTipText = "新 增"
        '
        'ToolEdit
        '
        Me.ToolEdit.Image = CType(resources.GetObject("ToolEdit.Image"), System.Drawing.Image)
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(71, 22)
        Me.ToolEdit.Tag = "YES"
        Me.ToolEdit.Text = "修 改(&E)"
        Me.ToolEdit.ToolTipText = "修 改"
        '
        'ToolDelete
        '
        Me.ToolDelete.Enabled = False
        Me.ToolDelete.Image = CType(resources.GetObject("ToolDelete.Image"), System.Drawing.Image)
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(73, 22)
        Me.ToolDelete.Tag = "YES"
        Me.ToolDelete.Text = "删 除(&D)"
        Me.ToolDelete.ToolTipText = "删 除"
        '
        'ToolSave
        '
        Me.ToolSave.Enabled = False
        Me.ToolSave.Image = CType(resources.GetObject("ToolSave.Image"), System.Drawing.Image)
        Me.ToolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSave.Name = "ToolSave"
        Me.ToolSave.Size = New System.Drawing.Size(71, 22)
        Me.ToolSave.Text = "保 存(&S)"
        Me.ToolSave.ToolTipText = "保 存"
        '
        'ToolUnDo
        '
        Me.ToolUnDo.Enabled = False
        Me.ToolUnDo.Image = CType(resources.GetObject("ToolUnDo.Image"), System.Drawing.Image)
        Me.ToolUnDo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolUnDo.Name = "ToolUnDo"
        Me.ToolUnDo.Size = New System.Drawing.Size(72, 22)
        Me.ToolUnDo.Text = "返 回(&B)"
        Me.ToolUnDo.ToolTipText = "返 回"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolRefresh
        '
        Me.ToolRefresh.Image = CType(resources.GetObject("ToolRefresh.Image"), System.Drawing.Image)
        Me.ToolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolRefresh.Name = "ToolRefresh"
        Me.ToolRefresh.Size = New System.Drawing.Size(72, 22)
        Me.ToolRefresh.Text = "刷 新(&R)"
        Me.ToolRefresh.ToolTipText = "刷 新"
        Me.ToolRefresh.Visible = False
        '
        'btnReportView
        '
        Me.btnReportView.Image = Global.BasicFind.My.Resources.Resources.query
        Me.btnReportView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReportView.Name = "btnReportView"
        Me.btnReportView.Size = New System.Drawing.Size(100, 22)
        Me.btnReportView.Tag = "YES"
        Me.btnReportView.Text = "报表查询预览"
        Me.btnReportView.ToolTipText = "报表查询预览"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripButton1.Text = "退出(&X)"
        Me.ToolStripButton1.ToolTipText = "退出"
        '
        'TabControl1
        '
        Me.TabControl1.AutoCloseTabs = True
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1234, 577)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.TabControl1.TabIndex = 144
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.SplitContainer2)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 25)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(1234, 552)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(1, 1)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox4)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridViewX1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1232, 550)
        Me.SplitContainer2.SplitterDistance = 255
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.BnSelectSta)
        Me.GroupBox5.Controls.Add(Me.LblDown)
        Me.GroupBox5.Controls.Add(Me.LblUp)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.txtSEQ)
        Me.GroupBox5.Controls.Add(Me.txtCONDITIONSQL)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.comPARA_TYPE)
        Me.GroupBox5.Controls.Add(Me.txtTABLENAME)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.txtDEFAULT_VALUE)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.txtPARA_LENGTH)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.txtPARA_CHG_NAME)
        Me.GroupBox5.Controls.Add(Me.ChkISNUL)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txtPARA_NAME)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 149)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1213, 100)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "查询脚本参数变量设置"
        '
        'BnSelectSta
        '
        Me.BnSelectSta.BackgroundImage = CType(resources.GetObject("BnSelectSta.BackgroundImage"), System.Drawing.Image)
        Me.BnSelectSta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BnSelectSta.Location = New System.Drawing.Point(644, 55)
        Me.BnSelectSta.Name = "BnSelectSta"
        Me.BnSelectSta.Size = New System.Drawing.Size(23, 23)
        Me.BnSelectSta.TabIndex = 94
        Me.BnSelectSta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BnSelectSta.UseVisualStyleBackColor = True
        '
        'LblDown
        '
        Me.LblDown.Image = CType(resources.GetObject("LblDown.Image"), System.Drawing.Image)
        Me.LblDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblDown.Location = New System.Drawing.Point(954, 76)
        Me.LblDown.Name = "LblDown"
        Me.LblDown.Size = New System.Drawing.Size(69, 19)
        Me.LblDown.TabIndex = 224
        Me.LblDown.Text = "下移(&D)"
        Me.LblDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUp
        '
        Me.LblUp.Image = CType(resources.GetObject("LblUp.Image"), System.Drawing.Image)
        Me.LblUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblUp.Location = New System.Drawing.Point(885, 77)
        Me.LblUp.Name = "LblUp"
        Me.LblUp.Size = New System.Drawing.Size(69, 19)
        Me.LblUp.TabIndex = 223
        Me.LblUp.Text = "上移(&U)"
        Me.LblUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(669, 63)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(239, 12)
        Me.Label21.TabIndex = 107
        Me.Label21.Text = "2.参数类型为L，T时，请输入绑定数据源SQL"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(669, 44)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(317, 12)
        Me.Label20.TabIndex = 106
        Me.Label20.Text = "1.参数值允许为空时，请输入需要替换成空值的参数字符串"
        '
        'txtSEQ
        '
        Me.txtSEQ.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtSEQ.Location = New System.Drawing.Point(956, 14)
        Me.txtSEQ.Name = "txtSEQ"
        Me.txtSEQ.Size = New System.Drawing.Size(10, 21)
        Me.txtSEQ.TabIndex = 105
        Me.txtSEQ.Visible = False
        '
        'txtCONDITIONSQL
        '
        Me.txtCONDITIONSQL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtCONDITIONSQL.Location = New System.Drawing.Point(72, 69)
        Me.txtCONDITIONSQL.Name = "txtCONDITIONSQL"
        Me.txtCONDITIONSQL.Size = New System.Drawing.Size(140, 21)
        Me.txtCONDITIONSQL.TabIndex = 104
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 72)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 103
        Me.Label18.Text = "空值字符："
        '
        'comPARA_TYPE
        '
        Me.comPARA_TYPE.FormattingEnabled = True
        Me.comPARA_TYPE.Items.AddRange(New Object() {"C-字符格式", "S-字符格式(多行)", "D-日期格式", "N-数字格式", "L-下拉列表", "T-下拉选择(可输入)"})
        Me.comPARA_TYPE.Location = New System.Drawing.Point(501, 15)
        Me.comPARA_TYPE.Name = "comPARA_TYPE"
        Me.comPARA_TYPE.Size = New System.Drawing.Size(139, 20)
        Me.comPARA_TYPE.TabIndex = 102
        '
        'txtTABLENAME
        '
        Me.txtTABLENAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtTABLENAME.Location = New System.Drawing.Point(284, 42)
        Me.txtTABLENAME.Multiline = True
        Me.txtTABLENAME.Name = "txtTABLENAME"
        Me.txtTABLENAME.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTABLENAME.Size = New System.Drawing.Size(356, 50)
        Me.txtTABLENAME.TabIndex = 101
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(230, 61)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 100
        Me.Label17.Text = "数据源："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(433, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = "参数类型："
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 45)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 12)
        Me.Label16.TabIndex = 99
        Me.Label16.Text = "默认值："
        '
        'txtDEFAULT_VALUE
        '
        Me.txtDEFAULT_VALUE.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtDEFAULT_VALUE.Location = New System.Drawing.Point(72, 42)
        Me.txtDEFAULT_VALUE.Name = "txtDEFAULT_VALUE"
        Me.txtDEFAULT_VALUE.Size = New System.Drawing.Size(140, 21)
        Me.txtDEFAULT_VALUE.TabIndex = 98
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(643, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 12)
        Me.Label14.TabIndex = 97
        Me.Label14.Text = "参数长度："
        '
        'txtPARA_LENGTH
        '
        Me.txtPARA_LENGTH.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtPARA_LENGTH.Location = New System.Drawing.Point(710, 15)
        Me.txtPARA_LENGTH.Name = "txtPARA_LENGTH"
        Me.txtPARA_LENGTH.Size = New System.Drawing.Size(135, 21)
        Me.txtPARA_LENGTH.TabIndex = 96
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(218, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "参数名称："
        '
        'txtPARA_CHG_NAME
        '
        Me.txtPARA_CHG_NAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtPARA_CHG_NAME.Location = New System.Drawing.Point(284, 14)
        Me.txtPARA_CHG_NAME.Name = "txtPARA_CHG_NAME"
        Me.txtPARA_CHG_NAME.Size = New System.Drawing.Size(140, 21)
        Me.txtPARA_CHG_NAME.TabIndex = 90
        '
        'ChkISNUL
        '
        Me.ChkISNUL.AutoSize = True
        Me.ChkISNUL.ForeColor = System.Drawing.Color.Black
        Me.ChkISNUL.Location = New System.Drawing.Point(851, 16)
        Me.ChkISNUL.Name = "ChkISNUL"
        Me.ChkISNUL.Size = New System.Drawing.Size(96, 16)
        Me.ChkISNUL.TabIndex = 89
        Me.ChkISNUL.Text = "参数允许为空"
        Me.ChkISNUL.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "参数变量："
        '
        'txtPARA_NAME
        '
        Me.txtPARA_NAME.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtPARA_NAME.Location = New System.Drawing.Point(72, 14)
        Me.txtPARA_NAME.Name = "txtPARA_NAME"
        Me.txtPARA_NAME.Size = New System.Drawing.Size(140, 21)
        Me.txtPARA_NAME.TabIndex = 75
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txtTtext1)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtSQLSCRIPT1)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txttkey1)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1213, 135)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "报表查询脚本"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(644, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "菜单名称："
        '
        'txtTtext1
        '
        Me.txtTtext1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtTtext1.Location = New System.Drawing.Point(710, 43)
        Me.txtTtext1.MaxLength = 999999
        Me.txtTtext1.Name = "txtTtext1"
        Me.txtTtext1.ReadOnly = True
        Me.txtTtext1.Size = New System.Drawing.Size(140, 21)
        Me.txtTtext1.TabIndex = 75
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(656, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 12)
        Me.Label8.TabIndex = 74
        Me.Label8.Text = "菜单ID："
        '
        'txtSQLSCRIPT1
        '
        Me.txtSQLSCRIPT1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtSQLSCRIPT1.Location = New System.Drawing.Point(72, 14)
        Me.txtSQLSCRIPT1.MaxLength = 999999
        Me.txtSQLSCRIPT1.Multiline = True
        Me.txtSQLSCRIPT1.Name = "txtSQLSCRIPT1"
        Me.txtSQLSCRIPT1.ReadOnly = True
        Me.txtSQLSCRIPT1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQLSCRIPT1.Size = New System.Drawing.Size(568, 116)
        Me.txtSQLSCRIPT1.TabIndex = 93
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 92
        Me.Label12.Text = "查询脚本："
        '
        'txttkey1
        '
        Me.txttkey1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txttkey1.Location = New System.Drawing.Point(710, 14)
        Me.txttkey1.MaxLength = 999999
        Me.txttkey1.Name = "txttkey1"
        Me.txttkey1.ReadOnly = True
        Me.txttkey1.Size = New System.Drawing.Size(140, 21)
        Me.txttkey1.TabIndex = 72
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tkey, Me.QRYSEQ, Me.PARA_NAME, Me.PARA_CHG_NAME, Me.PARA_TYPE, Me.PARA_LENGTH, Me.DEFAULT_VALUE, Me.TABLENAME, Me.ISNUL, Me.CONDITIONSQL, Me.STAMPUSERNAME, Me.STAMPDATETIME})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewX1.EnableHeadersVisualStyles = False
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewX1.RowTemplate.Height = 23
        Me.DataGridViewX1.SelectAllSignVisible = False
        Me.DataGridViewX1.Size = New System.Drawing.Size(1232, 294)
        Me.DataGridViewX1.TabIndex = 1
        '
        'Tkey
        '
        Me.Tkey.DataPropertyName = "Tkey"
        Me.Tkey.HeaderText = "菜单ID"
        Me.Tkey.Name = "Tkey"
        Me.Tkey.ReadOnly = True
        '
        'QRYSEQ
        '
        Me.QRYSEQ.DataPropertyName = "QRYSEQ"
        Me.QRYSEQ.HeaderText = "参数序号"
        Me.QRYSEQ.Name = "QRYSEQ"
        Me.QRYSEQ.ReadOnly = True
        '
        'PARA_NAME
        '
        Me.PARA_NAME.DataPropertyName = "PARA_NAME"
        Me.PARA_NAME.HeaderText = "参数变量"
        Me.PARA_NAME.Name = "PARA_NAME"
        Me.PARA_NAME.ReadOnly = True
        '
        'PARA_CHG_NAME
        '
        Me.PARA_CHG_NAME.DataPropertyName = "PARA_CHG_NAME"
        Me.PARA_CHG_NAME.HeaderText = "参数名称"
        Me.PARA_CHG_NAME.Name = "PARA_CHG_NAME"
        Me.PARA_CHG_NAME.ReadOnly = True
        '
        'PARA_TYPE
        '
        Me.PARA_TYPE.DataPropertyName = "PARA_TYPE"
        Me.PARA_TYPE.HeaderText = "参数类型"
        Me.PARA_TYPE.Name = "PARA_TYPE"
        Me.PARA_TYPE.ReadOnly = True
        '
        'PARA_LENGTH
        '
        Me.PARA_LENGTH.DataPropertyName = "PARA_LENGTH"
        Me.PARA_LENGTH.HeaderText = "长度"
        Me.PARA_LENGTH.Name = "PARA_LENGTH"
        Me.PARA_LENGTH.ReadOnly = True
        '
        'DEFAULT_VALUE
        '
        Me.DEFAULT_VALUE.DataPropertyName = "DEFAULT_VALUE"
        Me.DEFAULT_VALUE.HeaderText = "默认值"
        Me.DEFAULT_VALUE.Name = "DEFAULT_VALUE"
        Me.DEFAULT_VALUE.ReadOnly = True
        '
        'TABLENAME
        '
        Me.TABLENAME.DataPropertyName = "TABLENAME"
        Me.TABLENAME.HeaderText = "参数数据源"
        Me.TABLENAME.Name = "TABLENAME"
        Me.TABLENAME.ReadOnly = True
        '
        'ISNUL
        '
        Me.ISNUL.DataPropertyName = "ISNUL"
        Me.ISNUL.HeaderText = "是否为空"
        Me.ISNUL.Name = "ISNUL"
        Me.ISNUL.ReadOnly = True
        '
        'CONDITIONSQL
        '
        Me.CONDITIONSQL.DataPropertyName = "CONDITIONSQL"
        Me.CONDITIONSQL.HeaderText = "空值替换字符"
        Me.CONDITIONSQL.Name = "CONDITIONSQL"
        Me.CONDITIONSQL.ReadOnly = True
        '
        'STAMPUSERNAME
        '
        Me.STAMPUSERNAME.DataPropertyName = "STAMPUSERNAME"
        Me.STAMPUSERNAME.HeaderText = "操作人"
        Me.STAMPUSERNAME.Name = "STAMPUSERNAME"
        Me.STAMPUSERNAME.ReadOnly = True
        '
        'STAMPDATETIME
        '
        Me.STAMPDATETIME.DataPropertyName = "STAMPDATETIME"
        Me.STAMPDATETIME.HeaderText = "操作时间"
        Me.STAMPDATETIME.Name = "STAMPDATETIME"
        Me.STAMPDATETIME.ReadOnly = True
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "报表查询管理"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.SplitContainer1)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(1234, 552)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.AdvTree1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1232, 550)
        Me.SplitContainer1.SplitterDistance = 200
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        '
        'AdvTree1
        '
        Me.AdvTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.AdvTree1.AllowDrop = True
        Me.AdvTree1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.AdvTree1.BackgroundStyle.Class = "TreeBorderKey"
        Me.AdvTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AdvTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvTree1.DragDropEnabled = False
        Me.AdvTree1.DragDropNodeCopyEnabled = False
        Me.AdvTree1.Location = New System.Drawing.Point(0, 0)
        Me.AdvTree1.Name = "AdvTree1"
        Me.AdvTree1.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.AdvTree1.NodesConnector = Me.NodeConnector1
        Me.AdvTree1.NodeStyle = Me.ElementStyle1
        Me.AdvTree1.PathSeparator = ";"
        Me.AdvTree1.Size = New System.Drawing.Size(200, 550)
        Me.AdvTree1.Styles.Add(Me.ElementStyle1)
        Me.AdvTree1.TabIndex = 0
        Me.AdvTree1.Text = "AdvTree1"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "Node1"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label36)
        Me.GroupBox3.Controls.Add(Me.btnquerytest)
        Me.GroupBox3.Controls.Add(Me.txtChartTitle)
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.txtChartType)
        Me.GroupBox3.Controls.Add(Me.txtChartScript)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.chkChartUsey)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 340)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1022, 184)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "统计报表项设置-开启后生效"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(623, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(173, 12)
        Me.Label5.TabIndex = 132
        Me.Label5.Text = "2.统计SQL，可以获取主SQL变量"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(831, 123)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(23, 12)
        Me.Label36.TabIndex = 131
        Me.Label36.Text = "=》"
        '
        'btnquerytest
        '
        Me.btnquerytest.Location = New System.Drawing.Point(749, 118)
        Me.btnquerytest.Name = "btnquerytest"
        Me.btnquerytest.Size = New System.Drawing.Size(75, 23)
        Me.btnquerytest.TabIndex = 130
        Me.btnquerytest.Text = "查询范例"
        Me.btnquerytest.UseVisualStyleBackColor = True
        '
        'txtChartTitle
        '
        Me.txtChartTitle.Enabled = False
        Me.txtChartTitle.Location = New System.Drawing.Point(106, 147)
        Me.txtChartTitle.Name = "txtChartTitle"
        Me.txtChartTitle.Size = New System.Drawing.Size(185, 21)
        Me.txtChartTitle.TabIndex = 129
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.BasicFind.My.Resources.Resources.demo
        Me.PictureBox1.Location = New System.Drawing.Point(860, 73)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(145, 103)
        Me.PictureBox1.TabIndex = 128
        Me.PictureBox1.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(38, 150)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(65, 12)
        Me.Label33.TabIndex = 127
        Me.Label33.Text = "图表标题："
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(635, 89)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(179, 12)
        Me.Label32.TabIndex = 126
        Me.Label32.Text = "第二列，Y轴值（必须数字类型）"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(635, 75)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(179, 12)
        Me.Label31.TabIndex = 125
        Me.Label31.Text = "第一列，X轴值（一般文本类型）"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(623, 57)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(167, 12)
        Me.Label30.TabIndex = 124
        Me.Label30.Text = "3.查询统计记录，至少包含2列"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(623, 23)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(299, 12)
        Me.Label29.TabIndex = 123
        Me.Label29.Text = "1.统计SQL，传递的值方式与明细报表查询传值方式一致"
        '
        'txtChartType
        '
        Me.txtChartType.Enabled = False
        Me.txtChartType.FormattingEnabled = True
        Me.txtChartType.Items.AddRange(New Object() {"0-柱状图", "1-线状图", "2-线柱复合图（传2组数据分别设置）"})
        Me.txtChartType.Location = New System.Drawing.Point(370, 147)
        Me.txtChartType.Name = "txtChartType"
        Me.txtChartType.Size = New System.Drawing.Size(121, 20)
        Me.txtChartType.TabIndex = 122
        '
        'txtChartScript
        '
        Me.txtChartScript.Enabled = False
        Me.txtChartScript.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtChartScript.Location = New System.Drawing.Point(106, 20)
        Me.txtChartScript.MaxLength = 999999
        Me.txtChartScript.Multiline = True
        Me.txtChartScript.Name = "txtChartScript"
        Me.txtChartScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChartScript.Size = New System.Drawing.Size(507, 121)
        Me.txtChartScript.TabIndex = 121
        Me.txtChartScript.Text = "范例：select Xcol,Tcol from tableName "
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(14, 73)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 12)
        Me.Label24.TabIndex = 120
        Me.Label24.Text = "统计查询脚本："
        '
        'chkChartUsey
        '
        Me.chkChartUsey.AutoSize = True
        Me.chkChartUsey.Location = New System.Drawing.Point(625, 125)
        Me.chkChartUsey.Name = "chkChartUsey"
        Me.chkChartUsey.Size = New System.Drawing.Size(120, 16)
        Me.chkChartUsey.TabIndex = 119
        Me.chkChartUsey.Text = "开启统计报表查询"
        Me.chkChartUsey.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtDetScript)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.chkDetUsey)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 219)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1023, 114)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "明细报表项设置-开启后生效"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(621, 59)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(335, 12)
        Me.Label28.TabIndex = 115
        Me.Label28.Text = "3.范例查询包装明细，传递的值{0}就是双击列表中的第一列值"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(621, 41)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(287, 12)
        Me.Label27.TabIndex = 114
        Me.Label27.Text = "2.主表选择行，对应列值通过{0},{1}...{n}进行传递"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(621, 22)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(293, 12)
        Me.Label26.TabIndex = 113
        Me.Label26.Text = "1.明细查询通过双击主查询列表记录触发明细查询脚本"
        '
        'txtDetScript
        '
        Me.txtDetScript.Enabled = False
        Me.txtDetScript.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtDetScript.Location = New System.Drawing.Point(107, 20)
        Me.txtDetScript.MaxLength = 999999
        Me.txtDetScript.Multiline = True
        Me.txtDetScript.Name = "txtDetScript"
        Me.txtDetScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDetScript.Size = New System.Drawing.Size(507, 80)
        Me.txtDetScript.TabIndex = 112
        Me.txtDetScript.Text = "范例：select * from m_Cartonsn_t  where Cartonid='{0}'"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(15, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(89, 12)
        Me.Label23.TabIndex = 111
        Me.Label23.Text = "明细查询脚本："
        '
        'chkDetUsey
        '
        Me.chkDetUsey.AutoSize = True
        Me.chkDetUsey.Location = New System.Drawing.Point(623, 84)
        Me.chkDetUsey.Name = "chkDetUsey"
        Me.chkDetUsey.Size = New System.Drawing.Size(120, 16)
        Me.chkDetUsey.TabIndex = 110
        Me.chkDetUsey.Text = "开启明细报表查询"
        Me.chkDetUsey.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.chkSqlUsey)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtSQLSCRIPT)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cmbTparent)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label40)
        Me.GroupBox1.Controls.Add(Me.txtTkey)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtTtext)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtTreeTag)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtEnname)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1023, 210)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "报表菜单设置-开启后生效"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(296, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "父级菜单："
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(618, 99)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(173, 12)
        Me.Label22.TabIndex = 114
        Me.Label22.Text = "1.开启后，将在通用查询内显示"
        '
        'chkSqlUsey
        '
        Me.chkSqlUsey.AutoSize = True
        Me.chkSqlUsey.Location = New System.Drawing.Point(626, 184)
        Me.chkSqlUsey.Name = "chkSqlUsey"
        Me.chkSqlUsey.Size = New System.Drawing.Size(108, 16)
        Me.chkSqlUsey.TabIndex = 113
        Me.chkSqlUsey.Text = "开启主报表查询"
        Me.chkSqlUsey.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(618, 117)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(173, 12)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "2.查询语句SQL或者存储过程SQL"
        '
        'txtSQLSCRIPT
        '
        Me.txtSQLSCRIPT.Enabled = False
        Me.txtSQLSCRIPT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtSQLSCRIPT.Location = New System.Drawing.Point(107, 96)
        Me.txtSQLSCRIPT.MaxLength = 999999
        Me.txtSQLSCRIPT.Multiline = True
        Me.txtSQLSCRIPT.Name = "txtSQLSCRIPT"
        Me.txtSQLSCRIPT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQLSCRIPT.Size = New System.Drawing.Size(507, 104)
        Me.txtSQLSCRIPT.TabIndex = 111
        Me.txtSQLSCRIPT.Text = "例如：select * from m_carton_t where intime between @intime1 and @intime2 and moid=@" & _
    "moid and teamid=@teamid and cartonid=@cartonid"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(36, 143)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 110
        Me.Label15.Text = "查询脚本："
        '
        'cmbTparent
        '
        Me.cmbTparent.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTparent.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTparent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTparent.ButtonDropDown.Visible = True
        Me.cmbTparent.Location = New System.Drawing.Point(367, 17)
        Me.cmbTparent.Name = "cmbTparent"
        Me.cmbTparent.Size = New System.Drawing.Size(247, 23)
        Me.cmbTparent.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.cmbTparent.TabIndex = 109
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(621, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(209, 12)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "菜单标签,如:BasicFind.FrmPackQuery"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(621, 23)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(161, 12)
        Me.Label40.TabIndex = 107
        Me.Label40.Text = "注意：新增菜单ID自动生成；"
        '
        'txtTkey
        '
        Me.txtTkey.Enabled = False
        Me.txtTkey.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtTkey.Location = New System.Drawing.Point(107, 19)
        Me.txtTkey.MaxLength = 4
        Me.txtTkey.Name = "txtTkey"
        Me.txtTkey.Size = New System.Drawing.Size(185, 21)
        Me.txtTkey.TabIndex = 99
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(48, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "菜单ID："
        '
        'txtTtext
        '
        Me.txtTtext.Location = New System.Drawing.Point(107, 44)
        Me.txtTtext.MaxLength = 100
        Me.txtTtext.Name = "txtTtext"
        Me.txtTtext.Size = New System.Drawing.Size(185, 21)
        Me.txtTtext.TabIndex = 100
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "菜单名称："
        '
        'txtTreeTag
        '
        Me.txtTreeTag.Location = New System.Drawing.Point(107, 69)
        Me.txtTreeTag.MaxLength = 200
        Me.txtTreeTag.Name = "txtTreeTag"
        Me.txtTreeTag.Size = New System.Drawing.Size(507, 21)
        Me.txtTreeTag.TabIndex = 102
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "菜单标签："
        '
        'txtEnname
        '
        Me.txtEnname.Location = New System.Drawing.Point(367, 44)
        Me.txtEnname.MaxLength = 35
        Me.txtEnname.Name = "txtEnname"
        Me.txtEnname.Size = New System.Drawing.Size(247, 21)
        Me.txtEnname.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(296, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "英文名称："
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "报表菜单管理"
        '
        'FrmReportAdm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1234, 602)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolBt)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReportAdm"
        Me.Text = "报表查询设置"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolUnDo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnReportView As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents AdvTree1 As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chkSqlUsey As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSQLSCRIPT As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbTparent As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtTkey As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTtext As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTreeTag As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEnname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtDetScript As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents chkDetUsey As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btnquerytest As System.Windows.Forms.Button
    Friend WithEvents txtChartTitle As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtChartType As System.Windows.Forms.ComboBox
    Friend WithEvents txtChartScript As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents chkChartUsey As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTtext1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSQLSCRIPT1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txttkey1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents BnSelectSta As System.Windows.Forms.Button
    Friend WithEvents LblDown As System.Windows.Forms.Label
    Friend WithEvents LblUp As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSEQ As System.Windows.Forms.TextBox
    Friend WithEvents txtCONDITIONSQL As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents comPARA_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents txtTABLENAME As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDEFAULT_VALUE As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPARA_LENGTH As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPARA_CHG_NAME As System.Windows.Forms.TextBox
    Friend WithEvents ChkISNUL As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPARA_NAME As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Tkey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QRYSEQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARA_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARA_CHG_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARA_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PARA_LENGTH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEFAULT_VALUE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TABLENAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ISNUL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONDITIONSQL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAMPUSERNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAMPDATETIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
