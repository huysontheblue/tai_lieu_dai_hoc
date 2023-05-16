<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTiptopPrtTask
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意： 以下為 Windows Form 設計工具所需的程序

    '可以使用 Windows Form 設計工具進行修改。

    '請不要使用程式碼編輯器進行修改。

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTiptopPrtTask))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolAddNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEditTask = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelTask = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolPrt = New System.Windows.Forms.ToolStripButton()
        Me.ToolBTask = New System.Windows.Forms.ToolStripButton()
        Me.ToolFinish = New System.Windows.Forms.ToolStripButton()
        Me.ToolStopTask = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TxtPalletVer = New System.Windows.Forms.TextBox()
        Me.TxtNoVer = New System.Windows.Forms.TextBox()
        Me.TxtPackVer = New System.Windows.Forms.TextBox()
        Me.TxtPPidVER = New System.Windows.Forms.TextBox()
        Me.CboFactory = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtPCartonqty = New System.Windows.Forms.TextBox()
        Me.CboCust = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.CboMoType = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.CboLineid1 = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.CboDept = New System.Windows.Forms.ComboBox()
        Me.txtTitle3 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtTitle2 = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtTitle1 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.CboTemplate = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.CboRuleid = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtCoding = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtPackingCapacity = New System.Windows.Forms.TextBox()
        Me.TxtBuildAttribute = New System.Windows.Forms.TextBox()
        Me.TxtDriFlag = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TxtNqty = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtFileVerNo = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ComShift = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblNserier = New System.Windows.Forms.Label()
        Me.LblMoidqty = New System.Windows.Forms.Label()
        Me.LblTaskid = New System.Windows.Forms.Label()
        Me.LblCartonPrinted = New System.Windows.Forms.Label()
        Me.TxtPPIDqty = New System.Windows.Forms.TextBox()
        Me.TxtNserierQty = New System.Windows.Forms.TextBox()
        Me.TxtTaskDesc = New System.Windows.Forms.TextBox()
        Me.DtMoNeedTime = New System.Windows.Forms.DateTimePicker()
        Me.TxtCartonqty = New System.Windows.Forms.TextBox()
        Me.TxtMoid1 = New System.Windows.Forms.TextBox()
        Me.TxtPartid1 = New System.Windows.Forms.TextBox()
        Me.LblPPIDPrinted = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ChkPPID = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ChkCarton = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblCreatDate = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Lbl1 = New System.Windows.Forms.Label()
        Me.Lbl8 = New System.Windows.Forms.Label()
        Me.ChkNserier = New System.Windows.Forms.CheckBox()
        Me.ChkNppid = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ChkNotPrint = New System.Windows.Forms.CheckBox()
        Me.DtpEndtime = New System.Windows.Forms.DateTimePicker()
        Me.DtpStarttime = New System.Windows.Forms.DateTimePicker()
        Me.CboLineid = New System.Windows.Forms.ComboBox()
        Me.CboTaskid = New System.Windows.Forms.ComboBox()
        Me.LblRemark = New System.Windows.Forms.Label()
        Me.CboLabelType = New System.Windows.Forms.ComboBox()
        Me.CboDeptname = New System.Windows.Forms.ComboBox()
        Me.CboPartid = New System.Windows.Forms.ComboBox()
        Me.CboMoid = New System.Windows.Forms.ComboBox()
        Me.CboTaskStatus = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DgTask = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column1 = New BarCodePrint.DataGridViewRolloverCellColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colmoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Coldocfile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNeedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDeptDC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colshift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.linejm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFileVerno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDriFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuildAttribute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewRolloverCellColumn1 = New BarCodePrint.DataGridViewRolloverCellColumn()
        Me.DataGridViewRolloverCellColumn2 = New BarCodePrint.DataGridViewRolloverCellColumn()
        Me.DataGridViewRolloverCellColumn3 = New BarCodePrint.DataGridViewRolloverCellColumn()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DgTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 180000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 502)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1362, 22)
        Me.StatusStrip1.TabIndex = 111
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
        Me.ToolLblCount.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolLblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolLblCount.Text = "0"
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolAddNew, Me.ToolEditTask, Me.ToolDelTask, Me.ToolCommit, Me.ToolQuery, Me.ToolStripSeparator2, Me.ToolBack, Me.ToolRefresh, Me.ToolExcel, Me.ToolStripSeparator6, Me.ToolPrt, Me.ToolBTask, Me.ToolFinish, Me.ToolStopTask, Me.ToolStripSeparator5, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 2)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1471, 25)
        Me.ToolBt.TabIndex = 106
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolAddNew
        '
        Me.ToolAddNew.Image = CType(resources.GetObject("ToolAddNew.Image"), System.Drawing.Image)
        Me.ToolAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolAddNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAddNew.Name = "ToolAddNew"
        Me.ToolAddNew.Size = New System.Drawing.Size(70, 22)
        Me.ToolAddNew.Tag = "NO"
        Me.ToolAddNew.Text = "新建(&N)"
        Me.ToolAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolAddNew.ToolTipText = "新建"
        '
        'ToolEditTask
        '
        Me.ToolEditTask.Image = CType(resources.GetObject("ToolEditTask.Image"), System.Drawing.Image)
        Me.ToolEditTask.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEditTask.Name = "ToolEditTask"
        Me.ToolEditTask.Size = New System.Drawing.Size(67, 22)
        Me.ToolEditTask.Tag = "NO"
        Me.ToolEditTask.Text = "修改(&E)"
        Me.ToolEditTask.ToolTipText = "修改"
        '
        'ToolDelTask
        '
        Me.ToolDelTask.Image = CType(resources.GetObject("ToolDelTask.Image"), System.Drawing.Image)
        Me.ToolDelTask.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelTask.Name = "ToolDelTask"
        Me.ToolDelTask.Size = New System.Drawing.Size(69, 22)
        Me.ToolDelTask.Tag = "NO"
        Me.ToolDelTask.Text = "作废(&D)"
        Me.ToolDelTask.ToolTipText = "作废"
        '
        'ToolCommit
        '
        Me.ToolCommit.Image = CType(resources.GetObject("ToolCommit.Image"), System.Drawing.Image)
        Me.ToolCommit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCommit.Name = "ToolCommit"
        Me.ToolCommit.Size = New System.Drawing.Size(68, 22)
        Me.ToolCommit.Tag = ""
        Me.ToolCommit.Text = "提交(&C)"
        Me.ToolCommit.ToolTipText = "提交"
        '
        'ToolQuery
        '
        Me.ToolQuery.Image = Global.BarCodePrint.My.Resources.Resources.Query
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(98, 22)
        Me.ToolQuery.Text = "ERP工单查询"
        Me.ToolQuery.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolBack
        '
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
        '
        'ToolRefresh
        '
        Me.ToolRefresh.Image = CType(resources.GetObject("ToolRefresh.Image"), System.Drawing.Image)
        Me.ToolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolRefresh.Name = "ToolRefresh"
        Me.ToolRefresh.Size = New System.Drawing.Size(68, 22)
        Me.ToolRefresh.Text = "刷新(&R)"
        '
        'ToolExcel
        '
        Me.ToolExcel.Image = CType(resources.GetObject("ToolExcel.Image"), System.Drawing.Image)
        Me.ToolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExcel.Name = "ToolExcel"
        Me.ToolExcel.Size = New System.Drawing.Size(70, 22)
        Me.ToolExcel.Text = "汇出(&O)"
        Me.ToolExcel.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolPrt
        '
        Me.ToolPrt.Image = CType(resources.GetObject("ToolPrt.Image"), System.Drawing.Image)
        Me.ToolPrt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrt.Name = "ToolPrt"
        Me.ToolPrt.Size = New System.Drawing.Size(67, 22)
        Me.ToolPrt.Tag = "NO"
        Me.ToolPrt.Text = "打印(&P)"
        '
        'ToolBTask
        '
        Me.ToolBTask.Image = CType(resources.GetObject("ToolBTask.Image"), System.Drawing.Image)
        Me.ToolBTask.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBTask.Name = "ToolBTask"
        Me.ToolBTask.Size = New System.Drawing.Size(68, 22)
        Me.ToolBTask.Tag = "NO"
        Me.ToolBTask.Text = "驳回(&K)"
        Me.ToolBTask.ToolTipText = "驳回"
        '
        'ToolFinish
        '
        Me.ToolFinish.Image = CType(resources.GetObject("ToolFinish.Image"), System.Drawing.Image)
        Me.ToolFinish.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolFinish.Name = "ToolFinish"
        Me.ToolFinish.Size = New System.Drawing.Size(92, 22)
        Me.ToolFinish.Tag = "NO"
        Me.ToolFinish.Text = "打印完成(&A)"
        '
        'ToolStopTask
        '
        Me.ToolStopTask.Image = CType(resources.GetObject("ToolStopTask.Image"), System.Drawing.Image)
        Me.ToolStopTask.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStopTask.Name = "ToolStopTask"
        Me.ToolStopTask.Size = New System.Drawing.Size(68, 22)
        Me.ToolStopTask.Tag = "NO"
        Me.ToolStopTask.Text = "结案(&V)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExitFrom
        '
        Me.ToolExitFrom.Image = CType(resources.GetObject("ToolExitFrom.Image"), System.Drawing.Image)
        Me.ToolExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExitFrom.Name = "ToolExitFrom"
        Me.ToolExitFrom.Size = New System.Drawing.Size(68, 22)
        Me.ToolExitFrom.Text = "退出(&X)"
        Me.ToolExitFrom.ToolTipText = "退出"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 30)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtPalletVer)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtNoVer)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtPackVer)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtPPidVER)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboFactory)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtPCartonqty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboCust)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label38)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboMoType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label37)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboLineid1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label36)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboDept)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTitle3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label35)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTitle2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label34)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTitle1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label33)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboTemplate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label32)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboRuleid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label31)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtVersion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label29)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCoding)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label30)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPackingCapacity)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtBuildAttribute)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtDriFlag)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label26)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtNqty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label25)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtFileVerNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label24)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComShift)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblNserier)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblMoidqty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblTaskid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblCartonPrinted)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtPPIDqty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtNserierQty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtTaskDesc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DtMoNeedTime)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtCartonqty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtMoid1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtPartid1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblPPIDPrinted)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label23)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label18)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkPPID)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkCarton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblCreatDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lbl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lbl8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkNserier)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkNppid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label27)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label28)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1362, 469)
        Me.SplitContainer1.SplitterDistance = 183
        Me.SplitContainer1.TabIndex = 113
        '
        'TxtPalletVer
        '
        Me.TxtPalletVer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPalletVer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPalletVer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtPalletVer.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtPalletVer.Location = New System.Drawing.Point(427, 127)
        Me.TxtPalletVer.MaxLength = 5
        Me.TxtPalletVer.Name = "TxtPalletVer"
        Me.TxtPalletVer.Size = New System.Drawing.Size(47, 21)
        Me.TxtPalletVer.TabIndex = 204
        '
        'TxtNoVer
        '
        Me.TxtNoVer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtNoVer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNoVer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtNoVer.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtNoVer.Location = New System.Drawing.Point(427, 101)
        Me.TxtNoVer.MaxLength = 5
        Me.TxtNoVer.Name = "TxtNoVer"
        Me.TxtNoVer.Size = New System.Drawing.Size(47, 21)
        Me.TxtNoVer.TabIndex = 203
        '
        'TxtPackVer
        '
        Me.TxtPackVer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPackVer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPackVer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtPackVer.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtPackVer.Location = New System.Drawing.Point(427, 61)
        Me.TxtPackVer.MaxLength = 5
        Me.TxtPackVer.Name = "TxtPackVer"
        Me.TxtPackVer.Size = New System.Drawing.Size(47, 21)
        Me.TxtPackVer.TabIndex = 202
        '
        'TxtPPidVER
        '
        Me.TxtPPidVER.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPPidVER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPPidVER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtPPidVER.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtPPidVER.Location = New System.Drawing.Point(427, 34)
        Me.TxtPPidVER.MaxLength = 5
        Me.TxtPPidVER.Name = "TxtPPidVER"
        Me.TxtPPidVER.Size = New System.Drawing.Size(47, 21)
        Me.TxtPPidVER.TabIndex = 201
        '
        'CboFactory
        '
        Me.CboFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFactory.FormattingEnabled = True
        Me.CboFactory.Location = New System.Drawing.Point(70, 125)
        Me.CboFactory.Name = "CboFactory"
        Me.CboFactory.Size = New System.Drawing.Size(139, 20)
        Me.CboFactory.TabIndex = 200
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 199
        Me.Label11.Text = "工厂编号："
        '
        'TxtPCartonqty
        '
        Me.TxtPCartonqty.Location = New System.Drawing.Point(369, 78)
        Me.TxtPCartonqty.Name = "TxtPCartonqty"
        Me.TxtPCartonqty.Size = New System.Drawing.Size(53, 21)
        Me.TxtPCartonqty.TabIndex = 198
        '
        'CboCust
        '
        Me.CboCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCust.FormattingEnabled = True
        Me.CboCust.Location = New System.Drawing.Point(543, 32)
        Me.CboCust.Name = "CboCust"
        Me.CboCust.Size = New System.Drawing.Size(140, 20)
        Me.CboCust.TabIndex = 197
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(480, 34)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(65, 12)
        Me.Label38.TabIndex = 196
        Me.Label38.Text = "客户编号："
        '
        'CboMoType
        '
        Me.CboMoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMoType.FormattingEnabled = True
        Me.CboMoType.Location = New System.Drawing.Point(543, 55)
        Me.CboMoType.Name = "CboMoType"
        Me.CboMoType.Size = New System.Drawing.Size(140, 20)
        Me.CboMoType.TabIndex = 195
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(480, 58)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(65, 12)
        Me.Label37.TabIndex = 194
        Me.Label37.Text = "工单类型："
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(890, 147)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(49, 14)
        Me.lblMessage.TabIndex = 190
        Me.lblMessage.Text = "......"
        '
        'CboLineid1
        '
        Me.CboLineid1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLineid1.FormattingEnabled = True
        Me.CboLineid1.Location = New System.Drawing.Point(68, 60)
        Me.CboLineid1.Name = "CboLineid1"
        Me.CboLineid1.Size = New System.Drawing.Size(141, 20)
        Me.CboLineid1.TabIndex = 193
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(8, 63)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(65, 12)
        Me.Label36.TabIndex = 192
        Me.Label36.Text = "线别编号："
        '
        'CboDept
        '
        Me.CboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDept.FormattingEnabled = True
        Me.CboDept.Location = New System.Drawing.Point(70, 150)
        Me.CboDept.Name = "CboDept"
        Me.CboDept.Size = New System.Drawing.Size(139, 20)
        Me.CboDept.TabIndex = 191
        '
        'txtTitle3
        '
        Me.txtTitle3.Enabled = False
        Me.txtTitle3.ForeColor = System.Drawing.Color.Black
        Me.txtTitle3.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtTitle3.Location = New System.Drawing.Point(765, 62)
        Me.txtTitle3.MaxLength = 30
        Me.txtTitle3.Name = "txtTitle3"
        Me.txtTitle3.Size = New System.Drawing.Size(104, 21)
        Me.txtTitle3.TabIndex = 188
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(722, 65)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(47, 12)
        Me.Label35.TabIndex = 189
        Me.Label35.Text = "标题3："
        '
        'txtTitle2
        '
        Me.txtTitle2.Enabled = False
        Me.txtTitle2.ForeColor = System.Drawing.Color.Black
        Me.txtTitle2.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtTitle2.Location = New System.Drawing.Point(765, 36)
        Me.txtTitle2.MaxLength = 30
        Me.txtTitle2.Name = "txtTitle2"
        Me.txtTitle2.Size = New System.Drawing.Size(104, 21)
        Me.txtTitle2.TabIndex = 186
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(722, 40)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 12)
        Me.Label34.TabIndex = 187
        Me.Label34.Text = "标题2："
        '
        'txtTitle1
        '
        Me.txtTitle1.Enabled = False
        Me.txtTitle1.ForeColor = System.Drawing.Color.Black
        Me.txtTitle1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtTitle1.Location = New System.Drawing.Point(765, 9)
        Me.txtTitle1.MaxLength = 30
        Me.txtTitle1.Name = "txtTitle1"
        Me.txtTitle1.Size = New System.Drawing.Size(104, 21)
        Me.txtTitle1.TabIndex = 184
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(722, 12)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(47, 12)
        Me.Label33.TabIndex = 185
        Me.Label33.Text = "标题1："
        '
        'CboTemplate
        '
        Me.CboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTemplate.Enabled = False
        Me.CboTemplate.FormattingEnabled = True
        Me.CboTemplate.Location = New System.Drawing.Point(543, 102)
        Me.CboTemplate.Name = "CboTemplate"
        Me.CboTemplate.Size = New System.Drawing.Size(140, 20)
        Me.CboTemplate.TabIndex = 183
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(504, 107)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(41, 12)
        Me.Label32.TabIndex = 182
        Me.Label32.Text = "模板："
        '
        'CboRuleid
        '
        Me.CboRuleid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRuleid.Enabled = False
        Me.CboRuleid.FormattingEnabled = True
        Me.CboRuleid.Location = New System.Drawing.Point(543, 79)
        Me.CboRuleid.Name = "CboRuleid"
        Me.CboRuleid.Size = New System.Drawing.Size(140, 20)
        Me.CboRuleid.TabIndex = 181
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(480, 84)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(65, 12)
        Me.Label31.TabIndex = 123
        Me.Label31.Text = "编码原则："
        '
        'txtVersion
        '
        Me.txtVersion.Enabled = False
        Me.txtVersion.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtVersion.Location = New System.Drawing.Point(543, 125)
        Me.txtVersion.MaxLength = 30
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(140, 21)
        Me.txtVersion.TabIndex = 120
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(504, 131)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(41, 12)
        Me.Label29.TabIndex = 121
        Me.Label29.Text = "版本："
        '
        'txtCoding
        '
        Me.txtCoding.Enabled = False
        Me.txtCoding.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtCoding.Location = New System.Drawing.Point(543, 149)
        Me.txtCoding.MaxLength = 30
        Me.txtCoding.Name = "txtCoding"
        Me.txtCoding.Size = New System.Drawing.Size(140, 21)
        Me.txtCoding.TabIndex = 180
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(504, 152)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(41, 12)
        Me.Label30.TabIndex = 119
        Me.Label30.Text = "编码："
        '
        'txtPackingCapacity
        '
        Me.txtPackingCapacity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPackingCapacity.Enabled = False
        Me.txtPackingCapacity.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPackingCapacity.Location = New System.Drawing.Point(367, 8)
        Me.txtPackingCapacity.MaxLength = 5
        Me.txtPackingCapacity.Name = "txtPackingCapacity"
        Me.txtPackingCapacity.Size = New System.Drawing.Size(53, 21)
        Me.txtPackingCapacity.TabIndex = 116
        '
        'TxtBuildAttribute
        '
        Me.TxtBuildAttribute.ForeColor = System.Drawing.Color.Black
        Me.TxtBuildAttribute.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtBuildAttribute.Location = New System.Drawing.Point(765, 140)
        Me.TxtBuildAttribute.MaxLength = 30
        Me.TxtBuildAttribute.Name = "TxtBuildAttribute"
        Me.TxtBuildAttribute.Size = New System.Drawing.Size(104, 21)
        Me.TxtBuildAttribute.TabIndex = 113
        '
        'TxtDriFlag
        '
        Me.TxtDriFlag.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtDriFlag.Location = New System.Drawing.Point(765, 113)
        Me.TxtDriFlag.MaxLength = 30
        Me.TxtDriFlag.Name = "TxtDriFlag"
        Me.TxtDriFlag.Size = New System.Drawing.Size(104, 21)
        Me.TxtDriFlag.TabIndex = 111
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(710, 118)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(59, 12)
        Me.Label26.TabIndex = 112
        Me.Label26.Text = "自定义2："
        '
        'TxtNqty
        '
        Me.TxtNqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNqty.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtNqty.Location = New System.Drawing.Point(367, 101)
        Me.TxtNqty.MaxLength = 5
        Me.TxtNqty.Name = "TxtNqty"
        Me.TxtNqty.Size = New System.Drawing.Size(54, 21)
        Me.TxtNqty.TabIndex = 109
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(306, 105)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 12)
        Me.Label25.TabIndex = 110
        Me.Label25.Text = "需求数量："
        '
        'TxtFileVerNo
        '
        Me.TxtFileVerNo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtFileVerNo.Location = New System.Drawing.Point(765, 87)
        Me.TxtFileVerNo.MaxLength = 30
        Me.TxtFileVerNo.Name = "TxtFileVerNo"
        Me.TxtFileVerNo.Size = New System.Drawing.Size(104, 21)
        Me.TxtFileVerNo.TabIndex = 106
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(710, 92)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(59, 12)
        Me.Label24.TabIndex = 107
        Me.Label24.Text = "自定义1："
        '
        'ComShift
        '
        Me.ComShift.FormattingEnabled = True
        Me.ComShift.Items.AddRange(New Object() {"白班", "夜班"})
        Me.ComShift.Location = New System.Drawing.Point(255, 150)
        Me.ComShift.Name = "ComShift"
        Me.ComShift.Size = New System.Drawing.Size(165, 20)
        Me.ComShift.TabIndex = 104
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(306, 83)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 103
        Me.Label16.Text = "尾箱容量："
        '
        'LblNserier
        '
        Me.LblNserier.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.LblNserier.AutoSize = True
        Me.LblNserier.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblNserier.Location = New System.Drawing.Point(689, 12)
        Me.LblNserier.Name = "LblNserier"
        Me.LblNserier.Size = New System.Drawing.Size(11, 12)
        Me.LblNserier.TabIndex = 99
        Me.LblNserier.Text = "0"
        '
        'LblMoidqty
        '
        Me.LblMoidqty.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.LblMoidqty.AutoSize = True
        Me.LblMoidqty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblMoidqty.Location = New System.Drawing.Point(272, 14)
        Me.LblMoidqty.Name = "LblMoidqty"
        Me.LblMoidqty.Size = New System.Drawing.Size(29, 12)
        Me.LblMoidqty.TabIndex = 83
        Me.LblMoidqty.Text = "9999"
        '
        'LblTaskid
        '
        Me.LblTaskid.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.LblTaskid.AutoSize = True
        Me.LblTaskid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblTaskid.Location = New System.Drawing.Point(68, 109)
        Me.LblTaskid.Name = "LblTaskid"
        Me.LblTaskid.Size = New System.Drawing.Size(41, 12)
        Me.LblTaskid.TabIndex = 94
        Me.LblTaskid.Text = "A00001"
        '
        'LblCartonPrinted
        '
        Me.LblCartonPrinted.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.LblCartonPrinted.AutoSize = True
        Me.LblCartonPrinted.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblCartonPrinted.Location = New System.Drawing.Point(593, 12)
        Me.LblCartonPrinted.Name = "LblCartonPrinted"
        Me.LblCartonPrinted.Size = New System.Drawing.Size(29, 12)
        Me.LblCartonPrinted.TabIndex = 82
        Me.LblCartonPrinted.Text = "9999"
        '
        'TxtPPIDqty
        '
        Me.TxtPPIDqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPPIDqty.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtPPIDqty.Location = New System.Drawing.Point(367, 34)
        Me.TxtPPIDqty.MaxLength = 5
        Me.TxtPPIDqty.Name = "TxtPPIDqty"
        Me.TxtPPIDqty.Size = New System.Drawing.Size(54, 21)
        Me.TxtPPIDqty.TabIndex = 5
        '
        'TxtNserierQty
        '
        Me.TxtNserierQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNserierQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtNserierQty.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtNserierQty.Location = New System.Drawing.Point(367, 125)
        Me.TxtNserierQty.MaxLength = 5
        Me.TxtNserierQty.Name = "TxtNserierQty"
        Me.TxtNserierQty.Size = New System.Drawing.Size(54, 21)
        Me.TxtNserierQty.TabIndex = 12
        '
        'TxtTaskDesc
        '
        Me.TxtTaskDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtTaskDesc.ForeColor = System.Drawing.Color.Black
        Me.TxtTaskDesc.Location = New System.Drawing.Point(918, 5)
        Me.TxtTaskDesc.MaxLength = 100
        Me.TxtTaskDesc.Multiline = True
        Me.TxtTaskDesc.Name = "TxtTaskDesc"
        Me.TxtTaskDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtTaskDesc.Size = New System.Drawing.Size(166, 47)
        Me.TxtTaskDesc.TabIndex = 13
        '
        'DtMoNeedTime
        '
        Me.DtMoNeedTime.Checked = False
        Me.DtMoNeedTime.CustomFormat = "yyyy/MM/dd HH：mm"
        Me.DtMoNeedTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtMoNeedTime.Location = New System.Drawing.Point(68, 82)
        Me.DtMoNeedTime.Name = "DtMoNeedTime"
        Me.DtMoNeedTime.Size = New System.Drawing.Size(141, 21)
        Me.DtMoNeedTime.TabIndex = 3
        '
        'TxtCartonqty
        '
        Me.TxtCartonqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCartonqty.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtCartonqty.Location = New System.Drawing.Point(367, 59)
        Me.TxtCartonqty.MaxLength = 5
        Me.TxtCartonqty.Name = "TxtCartonqty"
        Me.TxtCartonqty.Size = New System.Drawing.Size(54, 21)
        Me.TxtCartonqty.TabIndex = 8
        '
        'TxtMoid1
        '
        Me.TxtMoid1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMoid1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtMoid1.Location = New System.Drawing.Point(66, 9)
        Me.TxtMoid1.MaxLength = 30
        Me.TxtMoid1.Name = "TxtMoid1"
        Me.TxtMoid1.Size = New System.Drawing.Size(143, 21)
        Me.TxtMoid1.TabIndex = 0
        '
        'TxtPartid1
        '
        Me.TxtPartid1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPartid1.Enabled = False
        Me.TxtPartid1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtPartid1.Location = New System.Drawing.Point(66, 34)
        Me.TxtPartid1.MaxLength = 20
        Me.TxtPartid1.Name = "TxtPartid1"
        Me.TxtPartid1.Size = New System.Drawing.Size(143, 21)
        Me.TxtPartid1.TabIndex = 1
        '
        'LblPPIDPrinted
        '
        Me.LblPPIDPrinted.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.LblPPIDPrinted.AutoSize = True
        Me.LblPPIDPrinted.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblPPIDPrinted.Location = New System.Drawing.Point(494, 13)
        Me.LblPPIDPrinted.Name = "LblPPIDPrinted"
        Me.LblPPIDPrinted.Size = New System.Drawing.Size(29, 12)
        Me.LblPPIDPrinted.TabIndex = 62
        Me.LblPPIDPrinted.Text = "9999"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(219, 155)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 12)
        Me.Label23.TabIndex = 105
        Me.Label23.Text = "班別："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(628, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 98
        Me.Label18.Text = "已打印量："
        '
        'ChkPPID
        '
        Me.ChkPPID.AutoSize = True
        Me.ChkPPID.Location = New System.Drawing.Point(217, 37)
        Me.ChkPPID.Name = "ChkPPID"
        Me.ChkPPID.Size = New System.Drawing.Size(84, 16)
        Me.ChkPPID.TabIndex = 4
        Me.ChkPPID.Text = "产品条码："
        Me.ChkPPID.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 109)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 12)
        Me.Label14.TabIndex = 93
        Me.Label14.Text = "申请单号："
        '
        'ChkCarton
        '
        Me.ChkCarton.AutoSize = True
        Me.ChkCarton.Location = New System.Drawing.Point(216, 61)
        Me.ChkCarton.Name = "ChkCarton"
        Me.ChkCarton.Size = New System.Drawing.Size(84, 16)
        Me.ChkCarton.TabIndex = 6
        Me.ChkCarton.Text = "外箱条码："
        Me.ChkCarton.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(306, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 12)
        Me.Label15.TabIndex = 88
        Me.Label15.Text = "需求数量："
        '
        'LblCreatDate
        '
        Me.LblCreatDate.AutoSize = True
        Me.LblCreatDate.Location = New System.Drawing.Point(9, 87)
        Me.LblCreatDate.Name = "LblCreatDate"
        Me.LblCreatDate.Size = New System.Drawing.Size(65, 12)
        Me.LblCreatDate.TabIndex = 53
        Me.LblCreatDate.Text = "需求时间："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(306, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 97
        Me.Label10.Text = "需求数量："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(881, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "备注："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(214, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "工单总量："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(531, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "已打印量："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(433, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "已打印量："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "部门编号："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(306, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 91
        Me.Label13.Text = "箱装容量："
        '
        'Lbl1
        '
        Me.Lbl1.AutoSize = True
        Me.Lbl1.Location = New System.Drawing.Point(9, 14)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(65, 12)
        Me.Lbl1.TabIndex = 46
        Me.Lbl1.Text = "工单编号："
        '
        'Lbl8
        '
        Me.Lbl8.AutoSize = True
        Me.Lbl8.Location = New System.Drawing.Point(9, 39)
        Me.Lbl8.Name = "Lbl8"
        Me.Lbl8.Size = New System.Drawing.Size(65, 12)
        Me.Lbl8.TabIndex = 52
        Me.Lbl8.Text = "料件编号："
        '
        'ChkNserier
        '
        Me.ChkNserier.AutoSize = True
        Me.ChkNserier.Location = New System.Drawing.Point(216, 129)
        Me.ChkNserier.Name = "ChkNserier"
        Me.ChkNserier.Size = New System.Drawing.Size(72, 16)
        Me.ChkNserier.TabIndex = 11
        Me.ChkNserier.Text = "栈板标签"
        Me.ChkNserier.UseVisualStyleBackColor = True
        '
        'ChkNppid
        '
        Me.ChkNppid.AutoSize = True
        Me.ChkNppid.Location = New System.Drawing.Point(216, 104)
        Me.ChkNppid.Name = "ChkNppid"
        Me.ChkNppid.Size = New System.Drawing.Size(72, 16)
        Me.ChkNppid.TabIndex = 108
        Me.ChkNppid.Text = "无流水码"
        Me.ChkNppid.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(710, 144)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(59, 12)
        Me.Label27.TabIndex = 114
        Me.Label27.Text = "自定义3："
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(306, 62)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(65, 12)
        Me.Label28.TabIndex = 115
        Me.Label28.Text = "整箱数量："
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChkNotPrint)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DtpEndtime)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DtpStarttime)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CboLineid)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CboTaskid)
        Me.SplitContainer2.Panel1.Controls.Add(Me.LblRemark)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CboLabelType)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CboDeptname)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CboPartid)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CboMoid)
        Me.SplitContainer2.Panel1.Controls.Add(Me.CboTaskStatus)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label21)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label20)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label19)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label22)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DgTask)
        Me.SplitContainer2.Size = New System.Drawing.Size(1362, 282)
        Me.SplitContainer2.SplitterDistance = 79
        Me.SplitContainer2.TabIndex = 2
        '
        'ChkNotPrint
        '
        Me.ChkNotPrint.AutoSize = True
        Me.ChkNotPrint.Location = New System.Drawing.Point(792, 12)
        Me.ChkNotPrint.Name = "ChkNotPrint"
        Me.ChkNotPrint.Size = New System.Drawing.Size(120, 16)
        Me.ChkNotPrint.TabIndex = 108
        Me.ChkNotPrint.Text = "生成记录，不打印"
        Me.ChkNotPrint.UseVisualStyleBackColor = True
        '
        'DtpEndtime
        '
        Me.DtpEndtime.Checked = False
        Me.DtpEndtime.CustomFormat = "yyyy/MM/dd HH：mm"
        Me.DtpEndtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEndtime.Location = New System.Drawing.Point(619, 29)
        Me.DtpEndtime.Name = "DtpEndtime"
        Me.DtpEndtime.Size = New System.Drawing.Size(141, 21)
        Me.DtpEndtime.TabIndex = 8
        '
        'DtpStarttime
        '
        Me.DtpStarttime.Checked = False
        Me.DtpStarttime.CustomFormat = "yyyy/MM/dd HH：mm"
        Me.DtpStarttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpStarttime.Location = New System.Drawing.Point(424, 30)
        Me.DtpStarttime.Name = "DtpStarttime"
        Me.DtpStarttime.Size = New System.Drawing.Size(144, 21)
        Me.DtpStarttime.TabIndex = 7
        '
        'CboLineid
        '
        Me.CboLineid.FormattingEnabled = True
        Me.CboLineid.Items.AddRange(New Object() {"ALL"})
        Me.CboLineid.Location = New System.Drawing.Point(240, 54)
        Me.CboLineid.Name = "CboLineid"
        Me.CboLineid.Size = New System.Drawing.Size(124, 20)
        Me.CboLineid.TabIndex = 5
        '
        'CboTaskid
        '
        Me.CboTaskid.FormattingEnabled = True
        Me.CboTaskid.Items.AddRange(New Object() {"ALL"})
        Me.CboTaskid.Location = New System.Drawing.Point(66, 8)
        Me.CboTaskid.Name = "CboTaskid"
        Me.CboTaskid.Size = New System.Drawing.Size(115, 20)
        Me.CboTaskid.TabIndex = 0
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LblRemark.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblRemark.Location = New System.Drawing.Point(424, 58)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(28, 15)
        Me.LblRemark.TabIndex = 70
        Me.LblRemark.Text = "000"
        '
        'CboLabelType
        '
        Me.CboLabelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLabelType.FormattingEnabled = True
        Me.CboLabelType.Items.AddRange(New Object() {"ALL", "S-产品条码标签", "C-外箱条码标签", "N-无流水码标签"})
        Me.CboLabelType.Location = New System.Drawing.Point(66, 54)
        Me.CboLabelType.Name = "CboLabelType"
        Me.CboLabelType.Size = New System.Drawing.Size(115, 20)
        Me.CboLabelType.TabIndex = 2
        '
        'CboDeptname
        '
        Me.CboDeptname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDeptname.FormattingEnabled = True
        Me.CboDeptname.Location = New System.Drawing.Point(424, 8)
        Me.CboDeptname.Name = "CboDeptname"
        Me.CboDeptname.Size = New System.Drawing.Size(336, 20)
        Me.CboDeptname.TabIndex = 6
        '
        'CboPartid
        '
        Me.CboPartid.FormattingEnabled = True
        Me.CboPartid.Items.AddRange(New Object() {"ALL"})
        Me.CboPartid.Location = New System.Drawing.Point(240, 31)
        Me.CboPartid.Name = "CboPartid"
        Me.CboPartid.Size = New System.Drawing.Size(124, 20)
        Me.CboPartid.TabIndex = 4
        '
        'CboMoid
        '
        Me.CboMoid.FormattingEnabled = True
        Me.CboMoid.Items.AddRange(New Object() {"ALL"})
        Me.CboMoid.Location = New System.Drawing.Point(240, 8)
        Me.CboMoid.Name = "CboMoid"
        Me.CboMoid.Size = New System.Drawing.Size(124, 20)
        Me.CboMoid.TabIndex = 3
        '
        'CboTaskStatus
        '
        Me.CboTaskStatus.FormattingEnabled = True
        Me.CboTaskStatus.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.CboTaskStatus.Items.AddRange(New Object() {"0-ALL", "1-待打印", "2-打印中", "3-被駁回", "4-被作廢", "5-待領取", "6-已完成"})
        Me.CboTaskStatus.Location = New System.Drawing.Point(66, 31)
        Me.CboTaskStatus.Name = "CboTaskStatus"
        Me.CboTaskStatus.Size = New System.Drawing.Size(115, 20)
        Me.CboTaskStatus.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(366, 35)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 12)
        Me.Label21.TabIndex = 75
        Me.Label21.Text = "申请时间："
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(183, 58)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 12)
        Me.Label20.TabIndex = 73
        Me.Label20.Text = "线别编号："
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 12)
        Me.Label19.TabIndex = 71
        Me.Label19.Text = "单据编号："
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(366, 58)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 12)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "单据描述："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "标签类型："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(366, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "部门名称："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "单据状态："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(183, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "工单编号："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(183, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "料件编号："
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(573, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 12)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "至："
        '
        'DgTask
        '
        Me.DgTask.AllowUserToAddRows = False
        Me.DgTask.AllowUserToDeleteRows = False
        Me.DgTask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgTask.BackgroundColor = System.Drawing.Color.White
        Me.DgTask.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgTask.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgTask.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Colmoid, Me.ColPartid, Me.Column7, Me.Coldocfile, Me.Column8, Me.ColNeedDate, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.ColFac, Me.ColDeptDC, Me.Colshift, Me.linejm, Me.ColFileVerno, Me.ColDriFlag, Me.BuildAttribute})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgTask.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgTask.EnableHeadersVisualStyles = False
        Me.DgTask.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.DgTask.Location = New System.Drawing.Point(0, 0)
        Me.DgTask.Name = "DgTask"
        Me.DgTask.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgTask.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgTask.RowHeadersWidth = 4
        Me.DgTask.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DgTask.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.DgTask.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DgTask.RowTemplate.Height = 23
        Me.DgTask.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.DgTask.Size = New System.Drawing.Size(1359, 199)
        Me.DgTask.TabIndex = 114
        '
        'Column1
        '
        Me.Column1.HeaderText = "单据编号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column2
        '
        Me.Column2.HeaderText = "单据状态"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "标签类型"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "线别编号"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Colmoid
        '
        Me.Colmoid.HeaderText = "工单编号"
        Me.Colmoid.Name = "Colmoid"
        Me.Colmoid.ReadOnly = True
        '
        'ColPartid
        '
        Me.ColPartid.HeaderText = "料件编号"
        Me.ColPartid.Name = "ColPartid"
        Me.ColPartid.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "空白标签"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Coldocfile
        '
        Me.Coldocfile.HeaderText = "图面文件"
        Me.Coldocfile.Name = "Coldocfile"
        Me.Coldocfile.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "需求数量"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'ColNeedDate
        '
        Me.ColNeedDate.HeaderText = "需求时间"
        Me.ColNeedDate.Name = "ColNeedDate"
        Me.ColNeedDate.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "打印机型号"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "温度"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "碳带"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "部门名称"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "打印人员"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "完成时间"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.HeaderText = "申请人员"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.HeaderText = "申请时间"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.HeaderText = "领取人员"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        '
        'Column19
        '
        Me.Column19.HeaderText = "领取时间"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        '
        'Column20
        '
        Me.Column20.HeaderText = "备注"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        '
        'ColFac
        '
        Me.ColFac.HeaderText = "工厂"
        Me.ColFac.Name = "ColFac"
        Me.ColFac.ReadOnly = True
        '
        'ColDeptDC
        '
        Me.ColDeptDC.HeaderText = "部门简码"
        Me.ColDeptDC.Name = "ColDeptDC"
        Me.ColDeptDC.ReadOnly = True
        '
        'Colshift
        '
        Me.Colshift.HeaderText = "班别"
        Me.Colshift.Name = "Colshift"
        Me.Colshift.ReadOnly = True
        '
        'linejm
        '
        Me.linejm.HeaderText = "线别简码"
        Me.linejm.Name = "linejm"
        Me.linejm.ReadOnly = True
        '
        'ColFileVerno
        '
        Me.ColFileVerno.HeaderText = "申请版本"
        Me.ColFileVerno.Name = "ColFileVerno"
        Me.ColFileVerno.ReadOnly = True
        '
        'ColDriFlag
        '
        Me.ColDriFlag.HeaderText = "DriFlag标识"
        Me.ColDriFlag.Name = "ColDriFlag"
        Me.ColDriFlag.ReadOnly = True
        '
        'BuildAttribute
        '
        Me.BuildAttribute.HeaderText = "BuildAttribute"
        Me.BuildAttribute.Name = "BuildAttribute"
        Me.BuildAttribute.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "單據編號"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "單據狀態"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "標簽類型"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "線別編號"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.Frozen = True
        Me.DataGridViewTextBoxColumn5.HeaderText = "工單編號"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.Frozen = True
        Me.DataGridViewTextBoxColumn6.HeaderText = "料件編號"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.Frozen = True
        Me.DataGridViewTextBoxColumn7.HeaderText = "空白標簽料號"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.Frozen = True
        Me.DataGridViewTextBoxColumn8.HeaderText = "需求數量"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 40
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.Frozen = True
        Me.DataGridViewTextBoxColumn9.HeaderText = "需求時間"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 120
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "部門名稱"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 120
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "打印人員"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 45
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "完成時間"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 45
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "申請人員"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 45
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "申請時間"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 45
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "領取人員"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 45
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "領取時間"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "申请时间"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "领取人员"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "领取时间"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "工厂"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "部门简码"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.HeaderText = "班别"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "线别简码"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'DataGridViewRolloverCellColumn1
        '
        Me.DataGridViewRolloverCellColumn1.Frozen = True
        Me.DataGridViewRolloverCellColumn1.HeaderText = "單據編號"
        Me.DataGridViewRolloverCellColumn1.Name = "DataGridViewRolloverCellColumn1"
        Me.DataGridViewRolloverCellColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewRolloverCellColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewRolloverCellColumn2
        '
        Me.DataGridViewRolloverCellColumn2.Frozen = True
        Me.DataGridViewRolloverCellColumn2.HeaderText = "單據編號"
        Me.DataGridViewRolloverCellColumn2.Name = "DataGridViewRolloverCellColumn2"
        Me.DataGridViewRolloverCellColumn2.ReadOnly = True
        Me.DataGridViewRolloverCellColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewRolloverCellColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewRolloverCellColumn3
        '
        Me.DataGridViewRolloverCellColumn3.Frozen = True
        Me.DataGridViewRolloverCellColumn3.HeaderText = "單據編號"
        Me.DataGridViewRolloverCellColumn3.Name = "DataGridViewRolloverCellColumn3"
        Me.DataGridViewRolloverCellColumn3.ReadOnly = True
        Me.DataGridViewRolloverCellColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewRolloverCellColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'FrmTiptopPrtTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 524)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolBt)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmTiptopPrtTask"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "打印下载申请作业"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DgTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolAddNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolEditTask As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBTask As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelTask As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStopTask As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewRolloverCellColumn1 As BarCodePrint.DataGridViewRolloverCellColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolFinish As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents LblTaskid As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtPartid1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtMoid1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCartonqty As System.Windows.Forms.TextBox
    Friend WithEvents TxtPPIDqty As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ChkCarton As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPPID As System.Windows.Forms.CheckBox
    Friend WithEvents LblMoidqty As System.Windows.Forms.Label
    Friend WithEvents LblCartonPrinted As System.Windows.Forms.Label
    Friend WithEvents TxtTaskDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblPPIDPrinted As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DtMoNeedTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblCreatDate As System.Windows.Forms.Label
    Friend WithEvents Lbl8 As System.Windows.Forms.Label
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents CboLabelType As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CboDeptname As System.Windows.Forms.ComboBox
    Friend WithEvents CboPartid As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboMoid As System.Windows.Forms.ComboBox
    Friend WithEvents CboTaskStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNserierQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ChkNserier As System.Windows.Forms.CheckBox
    Friend WithEvents LblNserier As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewRolloverCellColumn2 As BarCodePrint.DataGridViewRolloverCellColumn
    Friend WithEvents DataGridViewRolloverCellColumn3 As BarCodePrint.DataGridViewRolloverCellColumn
    Friend WithEvents LblRemark As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CboTaskid As System.Windows.Forms.ComboBox
    Friend WithEvents CboLineid As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DtpEndtime As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpStarttime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ComShift As System.Windows.Forms.ComboBox
    Friend WithEvents DgTask As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtFileVerNo As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ChkNotPrint As System.Windows.Forms.CheckBox
    Friend WithEvents ChkNppid As System.Windows.Forms.CheckBox
    Friend WithEvents TxtNqty As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtDriFlag As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtBuildAttribute As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Column1 As BarCodePrint.DataGridViewRolloverCellColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colmoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPartid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Coldocfile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNeedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDeptDC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colshift As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents linejm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFileVerno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDriFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildAttribute As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtPackingCapacity As System.Windows.Forms.TextBox
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCoding As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents CboTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents CboRuleid As System.Windows.Forms.ComboBox
    Friend WithEvents txtTitle1 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtTitle3 As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtTitle2 As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents CboDept As System.Windows.Forms.ComboBox
    Friend WithEvents CboLineid1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents CboMoType As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents CboCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents TxtPCartonqty As System.Windows.Forms.TextBox
    Friend WithEvents CboFactory As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPPidVER As System.Windows.Forms.TextBox
    Friend WithEvents TxtPalletVer As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoVer As System.Windows.Forms.TextBox
    Friend WithEvents TxtPackVer As System.Windows.Forms.TextBox
End Class
