<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListPrint))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.mtxtMOid = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.chkConfirm = New System.Windows.Forms.CheckBox()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPackageVersion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBlueprintVersion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkGetCodeNoPrint = New System.Windows.Forms.CheckBox()
        Me.CboItemCode = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CboSeries = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ChkDemandTime = New System.Windows.Forms.CheckBox()
        Me.rtxtStepMessage = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.txtDemandInfo = New System.Windows.Forms.TextBox()
        Me.BnEdit = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblPrintDate = New System.Windows.Forms.Label()
        Me.ChkNotPrint = New System.Windows.Forms.CheckBox()
        Me.TxtBuildAttribute = New System.Windows.Forms.TextBox()
        Me.TxtDriFlag = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TxtFileVerNo = New System.Windows.Forms.TextBox()
        Me.TxtTaskDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.CboShift = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.DtMoNeedTime = New System.Windows.Forms.DateTimePicker()
        Me.LblCreatDate = New System.Windows.Forms.Label()
        Me.CboCust = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.CboMoType = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.CboLine = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.CboDept = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPrintCount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.TextBox()
        Me.Lbl1 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.txtMOId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTestPrint = New System.Windows.Forms.CheckBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.dgvLotList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Colmoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ppidprtqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PpidprtCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pkgprtqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlueprintVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackageVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CHECKTEXT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DemandInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNeedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDept = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CusName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Plandate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRework = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.chbPrintListSelect = New System.Windows.Forms.CheckBox()
        Me.dgvPrintList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ChkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PtaskId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lableType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileVerNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VersionTypeText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coluserid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colintime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinishPrintQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrtAddQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinishPrtAddQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfigurationQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnLable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrinterName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PackingQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FCLNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrunkNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelTemplates = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TemplateDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisorderType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.djmdc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.shift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.linejm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Demandtime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DriFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuildAttribute = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estateid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.applyPart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupPrintFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvRuleList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ParaCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParaName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParaValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolAgain = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolPrt = New System.Windows.Forms.ToolStripButton()
        Me.ToolTestPrt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolPrintLoak = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolCommitInfo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolMove = New System.Windows.Forms.ToolStripButton()
        Me.toolCheck = New System.Windows.Forms.ToolStripButton()
        Me.ToolInPortTxt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
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
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn46 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn47 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn48 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn49 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn50 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn51 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn52 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn53 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn54 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn57 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn58 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgvLotList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvPrintList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRuleList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount, Me.lblMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 595)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1354, 22)
        Me.StatusStrip1.TabIndex = 128
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
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lblMessage.LinkColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 17)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 30)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mtxtMOid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkConfirm)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPackageVersion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtBlueprintVersion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkGetCodeNoPrint)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboItemCode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboSeries)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkDemandTime)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtxtStepMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDemandInfo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BnEdit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblPrintDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkNotPrint)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtBuildAttribute)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtDriFlag)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label26)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtFileVerNo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtTaskDesc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label27)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboShift)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label23)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DtMoNeedTime)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblCreatDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboCust)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label38)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboMoType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label37)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboLine)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label36)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CboDept)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtQty)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPrintCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpStartDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtPartid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Lbl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpEndDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMOId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkTestPrint)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.Black
        Me.SplitContainer1.Panel1MinSize = 1
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Panel2MinSize = 1
        Me.SplitContainer1.Size = New System.Drawing.Size(1354, 562)
        Me.SplitContainer1.SplitterDistance = 130
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 129
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(1043, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 12)
        Me.Label17.TabIndex = 253
        Me.Label17.Text = "查找工单："
        '
        'mtxtMOid
        '
        '
        '
        '
        Me.mtxtMOid.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMOid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMOid.ButtonCustom.Visible = True
        Me.mtxtMOid.Location = New System.Drawing.Point(1110, 30)
        Me.mtxtMOid.Name = "mtxtMOid"
        Me.mtxtMOid.ReadOnly = True
        Me.mtxtMOid.Size = New System.Drawing.Size(152, 21)
        Me.mtxtMOid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMOid.TabIndex = 252
        Me.mtxtMOid.Text = ""
        '
        'chkConfirm
        '
        Me.chkConfirm.AutoSize = True
        Me.chkConfirm.Location = New System.Drawing.Point(108, 108)
        Me.chkConfirm.Name = "chkConfirm"
        Me.chkConfirm.Size = New System.Drawing.Size(72, 16)
        Me.chkConfirm.TabIndex = 250
        Me.chkConfirm.Text = "是否确认"
        Me.chkConfirm.UseVisualStyleBackColor = True
        '
        'txtPO
        '
        Me.txtPO.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPO.Location = New System.Drawing.Point(695, 56)
        Me.txtPO.MaxLength = 120
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(158, 21)
        Me.txtPO.TabIndex = 248
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(644, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 12)
        Me.Label15.TabIndex = 249
        Me.Label15.Text = "合同号："
        '
        'txtPackageVersion
        '
        Me.txtPackageVersion.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPackageVersion.Location = New System.Drawing.Point(695, 30)
        Me.txtPackageVersion.MaxLength = 120
        Me.txtPackageVersion.Name = "txtPackageVersion"
        Me.txtPackageVersion.Size = New System.Drawing.Size(159, 21)
        Me.txtPackageVersion.TabIndex = 246
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(632, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 12)
        Me.Label14.TabIndex = 247
        Me.Label14.Text = "包规版本："
        '
        'txtBlueprintVersion
        '
        Me.txtBlueprintVersion.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtBlueprintVersion.Location = New System.Drawing.Point(695, 4)
        Me.txtBlueprintVersion.MaxLength = 120
        Me.txtBlueprintVersion.Name = "txtBlueprintVersion"
        Me.txtBlueprintVersion.Size = New System.Drawing.Size(158, 21)
        Me.txtBlueprintVersion.TabIndex = 244
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(632, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 245
        Me.Label12.Text = "蓝图版本："
        '
        'chkGetCodeNoPrint
        '
        Me.chkGetCodeNoPrint.AutoSize = True
        Me.chkGetCodeNoPrint.Location = New System.Drawing.Point(12, 108)
        Me.chkGetCodeNoPrint.Name = "chkGetCodeNoPrint"
        Me.chkGetCodeNoPrint.Size = New System.Drawing.Size(90, 16)
        Me.chkGetCodeNoPrint.TabIndex = 235
        Me.chkGetCodeNoPrint.Text = "生成,不打印"
        Me.chkGetCodeNoPrint.UseVisualStyleBackColor = True
        '
        'CboItemCode
        '
        Me.CboItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboItemCode.FormattingEnabled = True
        Me.CboItemCode.Location = New System.Drawing.Point(486, 77)
        Me.CboItemCode.Name = "CboItemCode"
        Me.CboItemCode.Size = New System.Drawing.Size(134, 20)
        Me.CboItemCode.TabIndex = 234
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(424, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 233
        Me.Label16.Text = "项目代码："
        '
        'CboSeries
        '
        Me.CboSeries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboSeries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboSeries.FormattingEnabled = True
        Me.CboSeries.Location = New System.Drawing.Point(486, 54)
        Me.CboSeries.Name = "CboSeries"
        Me.CboSeries.Size = New System.Drawing.Size(134, 20)
        Me.CboSeries.TabIndex = 234
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(436, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 12)
        Me.Label11.TabIndex = 233
        Me.Label11.Text = "系列别："
        '
        'ChkDemandTime
        '
        Me.ChkDemandTime.AutoSize = True
        Me.ChkDemandTime.Location = New System.Drawing.Point(1023, 4)
        Me.ChkDemandTime.Name = "ChkDemandTime"
        Me.ChkDemandTime.Size = New System.Drawing.Size(15, 14)
        Me.ChkDemandTime.TabIndex = 231
        Me.ChkDemandTime.UseVisualStyleBackColor = True
        '
        'rtxtStepMessage
        '
        Me.rtxtStepMessage.BackColorRichTextBox = System.Drawing.Color.White
        '
        '
        '
        Me.rtxtStepMessage.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.rtxtStepMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rtxtStepMessage.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.rtxtStepMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.rtxtStepMessage.Location = New System.Drawing.Point(1040, 3)
        Me.rtxtStepMessage.Name = "rtxtStepMessage"
        Me.rtxtStepMessage.ReadOnly = True
        Me.rtxtStepMessage.Rtf = "{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fcharset" & _
    "134 \'cb\'ce\'cc\'e5;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{\colortbl ;\red255\green128\blue128;}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\" & _
    "pard\cf1\lang2052\b\f0\fs18\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.rtxtStepMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtxtStepMessage.Size = New System.Drawing.Size(294, 23)
        Me.rtxtStepMessage.TabIndex = 230
        Me.rtxtStepMessage.WordWrap = False
        '
        'txtDemandInfo
        '
        Me.txtDemandInfo.Location = New System.Drawing.Point(928, 81)
        Me.txtDemandInfo.MaxLength = 512
        Me.txtDemandInfo.Multiline = True
        Me.txtDemandInfo.Name = "txtDemandInfo"
        Me.txtDemandInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDemandInfo.Size = New System.Drawing.Size(405, 44)
        Me.txtDemandInfo.TabIndex = 227
        '
        'BnEdit
        '
        Me.BnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnEdit.Image = CType(resources.GetObject("BnEdit.Image"), System.Drawing.Image)
        Me.BnEdit.Location = New System.Drawing.Point(1008, 29)
        Me.BnEdit.Name = "BnEdit"
        Me.BnEdit.Size = New System.Drawing.Size(29, 18)
        Me.BnEdit.TabIndex = 225
        Me.BnEdit.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(867, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 224
        Me.Label13.Text = "打印日期："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblPrintDate
        '
        Me.LblPrintDate.AutoSize = True
        Me.LblPrintDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblPrintDate.Location = New System.Drawing.Point(935, 31)
        Me.LblPrintDate.Name = "LblPrintDate"
        Me.LblPrintDate.Size = New System.Drawing.Size(41, 12)
        Me.LblPrintDate.TabIndex = 223
        Me.LblPrintDate.Text = "######"
        '
        'ChkNotPrint
        '
        Me.ChkNotPrint.AutoSize = True
        Me.ChkNotPrint.Location = New System.Drawing.Point(928, 4)
        Me.ChkNotPrint.Name = "ChkNotPrint"
        Me.ChkNotPrint.Size = New System.Drawing.Size(15, 14)
        Me.ChkNotPrint.TabIndex = 222
        Me.ChkNotPrint.UseVisualStyleBackColor = True
        '
        'TxtBuildAttribute
        '
        Me.TxtBuildAttribute.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtBuildAttribute.ForeColor = System.Drawing.Color.Black
        Me.TxtBuildAttribute.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtBuildAttribute.Location = New System.Drawing.Point(1110, 55)
        Me.TxtBuildAttribute.MaxLength = 30
        Me.TxtBuildAttribute.Name = "TxtBuildAttribute"
        Me.TxtBuildAttribute.Size = New System.Drawing.Size(152, 21)
        Me.TxtBuildAttribute.TabIndex = 219
        '
        'TxtDriFlag
        '
        Me.TxtDriFlag.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.TxtDriFlag.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtDriFlag.Location = New System.Drawing.Point(928, 56)
        Me.TxtDriFlag.MaxLength = 30
        Me.TxtDriFlag.Name = "TxtDriFlag"
        Me.TxtDriFlag.Size = New System.Drawing.Size(115, 21)
        Me.TxtDriFlag.TabIndex = 217
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(872, 58)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(59, 12)
        Me.Label26.TabIndex = 218
        Me.Label26.Text = "自定义1："
        '
        'TxtFileVerNo
        '
        Me.TxtFileVerNo.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtFileVerNo.Location = New System.Drawing.Point(1335, 35)
        Me.TxtFileVerNo.MaxLength = 30
        Me.TxtFileVerNo.Name = "TxtFileVerNo"
        Me.TxtFileVerNo.Size = New System.Drawing.Size(19, 21)
        Me.TxtFileVerNo.TabIndex = 215
        Me.TxtFileVerNo.Visible = False
        '
        'TxtTaskDesc
        '
        Me.TxtTaskDesc.Location = New System.Drawing.Point(486, 103)
        Me.TxtTaskDesc.MaxLength = 100
        Me.TxtTaskDesc.Multiline = True
        Me.TxtTaskDesc.Name = "TxtTaskDesc"
        Me.TxtTaskDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtTaskDesc.Size = New System.Drawing.Size(134, 24)
        Me.TxtTaskDesc.TabIndex = 213
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(448, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 214
        Me.Label2.Text = "备注："
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(1049, 59)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(59, 12)
        Me.Label27.TabIndex = 220
        Me.Label27.Text = "自定义2："
        '
        'CboShift
        '
        Me.CboShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboShift.FormattingEnabled = True
        Me.CboShift.Items.AddRange(New Object() {"白班", "夜班"})
        Me.CboShift.Location = New System.Drawing.Point(280, 105)
        Me.CboShift.Name = "CboShift"
        Me.CboShift.Size = New System.Drawing.Size(136, 20)
        Me.CboShift.TabIndex = 211
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(242, 108)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(41, 12)
        Me.Label23.TabIndex = 212
        Me.Label23.Text = "班別："
        '
        'DtMoNeedTime
        '
        Me.DtMoNeedTime.Location = New System.Drawing.Point(74, 80)
        Me.DtMoNeedTime.Name = "DtMoNeedTime"
        Me.DtMoNeedTime.Size = New System.Drawing.Size(136, 21)
        Me.DtMoNeedTime.TabIndex = 210
        '
        'LblCreatDate
        '
        Me.LblCreatDate.AutoSize = True
        Me.LblCreatDate.Location = New System.Drawing.Point(11, 84)
        Me.LblCreatDate.Name = "LblCreatDate"
        Me.LblCreatDate.Size = New System.Drawing.Size(65, 12)
        Me.LblCreatDate.TabIndex = 209
        Me.LblCreatDate.Text = "需求日期："
        '
        'CboCust
        '
        Me.CboCust.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboCust.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboCust.FormattingEnabled = True
        Me.CboCust.Location = New System.Drawing.Point(486, 31)
        Me.CboCust.Name = "CboCust"
        Me.CboCust.Size = New System.Drawing.Size(134, 20)
        Me.CboCust.TabIndex = 206
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(448, 33)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(41, 12)
        Me.Label38.TabIndex = 205
        Me.Label38.Text = "客户："
        '
        'CboMoType
        '
        Me.CboMoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMoType.FormattingEnabled = True
        Me.CboMoType.Location = New System.Drawing.Point(486, 6)
        Me.CboMoType.Name = "CboMoType"
        Me.CboMoType.Size = New System.Drawing.Size(134, 20)
        Me.CboMoType.TabIndex = 204
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(424, 9)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(65, 12)
        Me.Label37.TabIndex = 203
        Me.Label37.Text = "工单类型："
        '
        'CboLine
        '
        Me.CboLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLine.FormattingEnabled = True
        Me.CboLine.Location = New System.Drawing.Point(280, 81)
        Me.CboLine.Name = "CboLine"
        Me.CboLine.Size = New System.Drawing.Size(136, 20)
        Me.CboLine.TabIndex = 202
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(242, 83)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(41, 12)
        Me.Label36.TabIndex = 201
        Me.Label36.Text = "线别："
        '
        'CboDept
        '
        Me.CboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDept.FormattingEnabled = True
        Me.CboDept.Location = New System.Drawing.Point(280, 56)
        Me.CboDept.Name = "CboDept"
        Me.CboDept.Size = New System.Drawing.Size(136, 20)
        Me.CboDept.TabIndex = 200
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(242, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 12)
        Me.Label7.TabIndex = 198
        Me.Label7.Text = "部门："
        '
        'txtQty
        '
        Me.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQty.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtQty.Location = New System.Drawing.Point(74, 56)
        Me.txtQty.MaxLength = 20
        Me.txtQty.Name = "txtQty"
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(136, 21)
        Me.txtQty.TabIndex = 120
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 12)
        Me.Label6.TabIndex = 121
        Me.Label6.Text = "数量："
        '
        'txtPrintCount
        '
        Me.txtPrintCount.BackColor = System.Drawing.Color.White
        Me.txtPrintCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrintCount.Font = New System.Drawing.Font("宋体", 32.0!)
        Me.txtPrintCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtPrintCount.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPrintCount.Location = New System.Drawing.Point(695, 81)
        Me.txtPrintCount.MaxLength = 20
        Me.txtPrintCount.Multiline = True
        Me.txtPrintCount.Name = "txtPrintCount"
        Me.txtPrintCount.Size = New System.Drawing.Size(158, 46)
        Me.txtPrintCount.TabIndex = 116
        Me.txtPrintCount.Text = "100"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(623, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 22)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "打印数量"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(280, 32)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpStartDate.TabIndex = 115
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(219, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "结束日期："
        '
        'TxtPartid
        '
        Me.TxtPartid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPartid.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtPartid.Location = New System.Drawing.Point(74, 32)
        Me.TxtPartid.MaxLength = 20
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(136, 21)
        Me.TxtPartid.TabIndex = 0
        '
        'Lbl1
        '
        Me.Lbl1.AutoSize = True
        Me.Lbl1.Location = New System.Drawing.Point(10, 33)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(65, 12)
        Me.Lbl1.TabIndex = 111
        Me.Lbl1.Text = "料件编号："
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(280, 7)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpEndDate.TabIndex = 112
        '
        'txtMOId
        '
        Me.txtMOId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOId.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMOId.Location = New System.Drawing.Point(74, 7)
        Me.txtMOId.MaxLength = 50
        Me.txtMOId.Name = "txtMOId"
        Me.txtMOId.Size = New System.Drawing.Size(136, 21)
        Me.txtMOId.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(219, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "开始日期："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(962, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 232
        Me.Label10.Text = "标签日期："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(867, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 226
        Me.Label8.Text = "是否打印："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(866, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 228
        Me.Label9.Text = "需求信息："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "工单："
        '
        'chkTestPrint
        '
        Me.chkTestPrint.AutoSize = True
        Me.chkTestPrint.Location = New System.Drawing.Point(188, 108)
        Me.chkTestPrint.Name = "chkTestPrint"
        Me.chkTestPrint.Size = New System.Drawing.Size(48, 16)
        Me.chkTestPrint.TabIndex = 251
        Me.chkTestPrint.Text = "测试"
        Me.chkTestPrint.UseVisualStyleBackColor = True
        Me.chkTestPrint.Visible = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgvLotList)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer3.Size = New System.Drawing.Size(1354, 431)
        Me.SplitContainer3.SplitterDistance = 159
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 45
        '
        'dgvLotList
        '
        Me.dgvLotList.AllowUserToAddRows = False
        Me.dgvLotList.AllowUserToDeleteRows = False
        Me.dgvLotList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLotList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLotList.ColumnHeadersHeight = 25
        Me.dgvLotList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Colmoid, Me.ColPartid, Me.ColQty, Me.Ppidprtqty, Me.PpidprtCount, Me.Pkgprtqty, Me.ColLineId, Me.BlueprintVersion, Me.PackageVersion, Me.ColPO, Me.CHECKTEXT, Me.DemandInfo, Me.ColNeedDate, Me.ColDept, Me.CusName, Me.Plandate, Me.Column16, Me.Column17, Me.ColRework})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLotList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLotList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLotList.EnableHeadersVisualStyles = False
        Me.dgvLotList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvLotList.Location = New System.Drawing.Point(0, 0)
        Me.dgvLotList.MultiSelect = False
        Me.dgvLotList.Name = "dgvLotList"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLotList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLotList.RowHeadersWidth = 4
        Me.dgvLotList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvLotList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvLotList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvLotList.RowTemplate.Height = 23
        Me.dgvLotList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvLotList.Size = New System.Drawing.Size(1354, 159)
        Me.dgvLotList.TabIndex = 115
        '
        'Colmoid
        '
        Me.Colmoid.Frozen = True
        Me.Colmoid.HeaderText = "工单编号"
        Me.Colmoid.Name = "Colmoid"
        Me.Colmoid.ReadOnly = True
        '
        'ColPartid
        '
        Me.ColPartid.Frozen = True
        Me.ColPartid.HeaderText = "料件编号"
        Me.ColPartid.Name = "ColPartid"
        Me.ColPartid.ReadOnly = True
        '
        'ColQty
        '
        Me.ColQty.HeaderText = "需求数量"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.ReadOnly = True
        Me.ColQty.Width = 60
        '
        'Ppidprtqty
        '
        Me.Ppidprtqty.HeaderText = "已打张数"
        Me.Ppidprtqty.Name = "Ppidprtqty"
        Me.Ppidprtqty.ReadOnly = True
        Me.Ppidprtqty.Width = 60
        '
        'PpidprtCount
        '
        Me.PpidprtCount.HeaderText = "已打数量"
        Me.PpidprtCount.Name = "PpidprtCount"
        Me.PpidprtCount.ReadOnly = True
        Me.PpidprtCount.Width = 60
        '
        'Pkgprtqty
        '
        Me.Pkgprtqty.HeaderText = "成品条码数量"
        Me.Pkgprtqty.Name = "Pkgprtqty"
        Me.Pkgprtqty.ReadOnly = True
        '
        'ColLineId
        '
        Me.ColLineId.HeaderText = "线别编号"
        Me.ColLineId.Name = "ColLineId"
        Me.ColLineId.ReadOnly = True
        Me.ColLineId.Width = 60
        '
        'BlueprintVersion
        '
        Me.BlueprintVersion.HeaderText = "蓝图版本"
        Me.BlueprintVersion.Name = "BlueprintVersion"
        Me.BlueprintVersion.ReadOnly = True
        Me.BlueprintVersion.Width = 60
        '
        'PackageVersion
        '
        Me.PackageVersion.HeaderText = "包规版本"
        Me.PackageVersion.Name = "PackageVersion"
        Me.PackageVersion.ReadOnly = True
        Me.PackageVersion.Width = 60
        '
        'ColPO
        '
        Me.ColPO.HeaderText = "合同号"
        Me.ColPO.Name = "ColPO"
        '
        'CHECKTEXT
        '
        Me.CHECKTEXT.HeaderText = "审核信息"
        Me.CHECKTEXT.Name = "CHECKTEXT"
        Me.CHECKTEXT.ReadOnly = True
        '
        'DemandInfo
        '
        Me.DemandInfo.HeaderText = "需求信息"
        Me.DemandInfo.Name = "DemandInfo"
        Me.DemandInfo.Width = 200
        '
        'ColNeedDate
        '
        Me.ColNeedDate.HeaderText = "计划时间"
        Me.ColNeedDate.Name = "ColNeedDate"
        Me.ColNeedDate.ReadOnly = True
        '
        'ColDept
        '
        Me.ColDept.HeaderText = "部门名称"
        Me.ColDept.Name = "ColDept"
        Me.ColDept.ReadOnly = True
        Me.ColDept.Width = 120
        '
        'CusName
        '
        Me.CusName.HeaderText = "客户"
        Me.CusName.Name = "CusName"
        Me.CusName.ReadOnly = True
        '
        'Plandate
        '
        Me.Plandate.HeaderText = "标签日期"
        Me.Plandate.Name = "Plandate"
        Me.Plandate.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.HeaderText = "责任人"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.HeaderText = "工单下载时间"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Visible = False
        '
        'ColRework
        '
        Me.ColRework.HeaderText = "备注"
        Me.ColRework.Name = "ColRework"
        Me.ColRework.ReadOnly = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.Snow
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.chbPrintListSelect)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgvPrintList)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvRuleList)
        Me.SplitContainer2.Size = New System.Drawing.Size(1354, 271)
        Me.SplitContainer2.SplitterDistance = 1043
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 0
        '
        'chbPrintListSelect
        '
        Me.chbPrintListSelect.AutoSize = True
        Me.chbPrintListSelect.Checked = True
        Me.chbPrintListSelect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPrintListSelect.Location = New System.Drawing.Point(22, 7)
        Me.chbPrintListSelect.Name = "chbPrintListSelect"
        Me.chbPrintListSelect.Size = New System.Drawing.Size(15, 14)
        Me.chbPrintListSelect.TabIndex = 2
        Me.chbPrintListSelect.UseVisualStyleBackColor = True
        '
        'dgvPrintList
        '
        Me.dgvPrintList.AllowUserToAddRows = False
        Me.dgvPrintList.AllowUserToDeleteRows = False
        Me.dgvPrintList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPrintList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvPrintList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrintList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPrintList.ColumnHeadersHeight = 25
        Me.dgvPrintList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChkSelect, Me.PtaskId, Me.Moid, Me.lableType, Me.PackItem, Me.PartId, Me.ParentPartId, Me.FileVerNo, Me.VersionTypeText, Me.Remark, Me.coluserid, Me.colintime, Me.Qty, Me.PrintQTY, Me.FinishPrintQty, Me.PrtAddQty, Me.FinishPrtAddQty, Me.ConfigurationQty, Me.PnLable, Me.PrinterName, Me.PackingQty, Me.FCLNumber, Me.TrunkNumber, Me.PrintNumber, Me.LabelTemplates, Me.TemplateDescription, Me.Status, Me.DisorderType, Me.djmdc, Me.shift, Me.linejm, Me.Demandtime, Me.DriFlag, Me.BuildAttribute, Me.Estateid, Me.PackingLevel, Me.applyPart, Me.GroupPrintFlag})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPrintList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPrintList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrintList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvPrintList.EnableHeadersVisualStyles = False
        Me.dgvPrintList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvPrintList.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrintList.MultiSelect = False
        Me.dgvPrintList.Name = "dgvPrintList"
        Me.dgvPrintList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrintList.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPrintList.RowHeadersWidth = 4
        Me.dgvPrintList.RowTemplate.Height = 23
        Me.dgvPrintList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPrintList.Size = New System.Drawing.Size(1043, 271)
        Me.dgvPrintList.TabIndex = 1
        '
        'ChkSelect
        '
        Me.ChkSelect.Frozen = True
        Me.ChkSelect.HeaderText = ""
        Me.ChkSelect.Name = "ChkSelect"
        Me.ChkSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkSelect.Width = 50
        '
        'PtaskId
        '
        Me.PtaskId.HeaderText = "单据编号"
        Me.PtaskId.Name = "PtaskId"
        Me.PtaskId.ReadOnly = True
        Me.PtaskId.Visible = False
        '
        'Moid
        '
        Me.Moid.Frozen = True
        Me.Moid.HeaderText = "工单编号"
        Me.Moid.Name = "Moid"
        Me.Moid.ReadOnly = True
        Me.Moid.Width = 120
        '
        'lableType
        '
        Me.lableType.Frozen = True
        Me.lableType.HeaderText = "标签类型"
        Me.lableType.Name = "lableType"
        Me.lableType.ReadOnly = True
        Me.lableType.Width = 80
        '
        'PackItem
        '
        Me.PackItem.Frozen = True
        Me.PackItem.HeaderText = "类型项次"
        Me.PackItem.Name = "PackItem"
        Me.PackItem.ReadOnly = True
        Me.PackItem.Width = 60
        '
        'PartId
        '
        Me.PartId.HeaderText = "料件编号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        Me.PartId.Width = 90
        '
        'ParentPartId
        '
        Me.ParentPartId.HeaderText = "父料件号"
        Me.ParentPartId.Name = "ParentPartId"
        Me.ParentPartId.ReadOnly = True
        Me.ParentPartId.Width = 90
        '
        'FileVerNo
        '
        Me.FileVerNo.HeaderText = "版本*"
        Me.FileVerNo.Name = "FileVerNo"
        Me.FileVerNo.Width = 40
        '
        'VersionTypeText
        '
        Me.VersionTypeText.HeaderText = "版本类型"
        Me.VersionTypeText.Name = "VersionTypeText"
        Me.VersionTypeText.ReadOnly = True
        Me.VersionTypeText.Width = 60
        '
        'Remark
        '
        Me.Remark.HeaderText = "料件版本"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 60
        '
        'coluserid
        '
        Me.coluserid.HeaderText = "申请人"
        Me.coluserid.Name = "coluserid"
        '
        'colintime
        '
        Me.colintime.HeaderText = "申请时间"
        Me.colintime.Name = "colintime"
        Me.colintime.Width = 130
        '
        'Qty
        '
        Me.Qty.HeaderText = "工单数量"
        Me.Qty.Name = "Qty"
        Me.Qty.Width = 60
        '
        'PrintQTY
        '
        Me.PrintQTY.FillWeight = 80.0!
        Me.PrintQTY.HeaderText = "需求数量"
        Me.PrintQTY.Name = "PrintQTY"
        Me.PrintQTY.ReadOnly = True
        Me.PrintQTY.Width = 60
        '
        'FinishPrintQty
        '
        Me.FinishPrintQty.HeaderText = "已打印"
        Me.FinishPrintQty.Name = "FinishPrintQty"
        Me.FinishPrintQty.ReadOnly = True
        Me.FinishPrintQty.Width = 60
        '
        'PrtAddQty
        '
        Me.PrtAddQty.DataPropertyName = "ApplyAddQty"
        Me.PrtAddQty.HeaderText = "补数申请"
        Me.PrtAddQty.Name = "PrtAddQty"
        Me.PrtAddQty.ReadOnly = True
        Me.PrtAddQty.Width = 60
        '
        'FinishPrtAddQty
        '
        Me.FinishPrtAddQty.DataPropertyName = "FinishedAddQty"
        Me.FinishPrtAddQty.HeaderText = "补数完成"
        Me.FinishPrtAddQty.Name = "FinishPrtAddQty"
        Me.FinishPrtAddQty.ReadOnly = True
        Me.FinishPrtAddQty.Width = 60
        '
        'ConfigurationQty
        '
        Me.ConfigurationQty.HeaderText = "配套数"
        Me.ConfigurationQty.Name = "ConfigurationQty"
        Me.ConfigurationQty.ReadOnly = True
        Me.ConfigurationQty.Width = 60
        '
        'PnLable
        '
        Me.PnLable.HeaderText = "标签料号"
        Me.PnLable.Name = "PnLable"
        '
        'PrinterName
        '
        Me.PrinterName.HeaderText = "打印机"
        Me.PrinterName.Name = "PrinterName"
        Me.PrinterName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrinterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PrinterName.Width = 200
        '
        'PackingQty
        '
        Me.PackingQty.HeaderText = "包装容量"
        Me.PackingQty.Name = "PackingQty"
        Me.PackingQty.ReadOnly = True
        Me.PackingQty.Width = 60
        '
        'FCLNumber
        '
        Me.FCLNumber.HeaderText = "整箱数"
        Me.FCLNumber.Name = "FCLNumber"
        Me.FCLNumber.ReadOnly = True
        Me.FCLNumber.Width = 60
        '
        'TrunkNumber
        '
        Me.TrunkNumber.HeaderText = "尾箱数"
        Me.TrunkNumber.Name = "TrunkNumber"
        Me.TrunkNumber.ReadOnly = True
        Me.TrunkNumber.Width = 60
        '
        'PrintNumber
        '
        Me.PrintNumber.DataPropertyName = "PrintNumber"
        Me.PrintNumber.HeaderText = "已印张数"
        Me.PrintNumber.Name = "PrintNumber"
        Me.PrintNumber.ReadOnly = True
        Me.PrintNumber.Width = 60
        '
        'LabelTemplates
        '
        Me.LabelTemplates.HeaderText = "标签模板"
        Me.LabelTemplates.Name = "LabelTemplates"
        Me.LabelTemplates.ReadOnly = True
        '
        'TemplateDescription
        '
        Me.TemplateDescription.HeaderText = "模板描述"
        Me.TemplateDescription.Name = "TemplateDescription"
        Me.TemplateDescription.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "状态"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 80
        '
        'DisorderType
        '
        Me.DisorderType.HeaderText = "无序类型"
        Me.DisorderType.Name = "DisorderType"
        Me.DisorderType.ReadOnly = True
        '
        'djmdc
        '
        Me.djmdc.HeaderText = "部门代码"
        Me.djmdc.Name = "djmdc"
        Me.djmdc.ReadOnly = True
        '
        'shift
        '
        Me.shift.HeaderText = "班组"
        Me.shift.Name = "shift"
        Me.shift.ReadOnly = True
        '
        'linejm
        '
        Me.linejm.HeaderText = "线别代码"
        Me.linejm.Name = "linejm"
        Me.linejm.ReadOnly = True
        '
        'Demandtime
        '
        Me.Demandtime.HeaderText = "需求日期"
        Me.Demandtime.Name = "Demandtime"
        Me.Demandtime.ReadOnly = True
        '
        'DriFlag
        '
        Me.DriFlag.HeaderText = "Dri标示"
        Me.DriFlag.Name = "DriFlag"
        Me.DriFlag.ReadOnly = True
        '
        'BuildAttribute
        '
        Me.BuildAttribute.HeaderText = "Build属性"
        Me.BuildAttribute.Name = "BuildAttribute"
        Me.BuildAttribute.ReadOnly = True
        '
        'Estateid
        '
        Me.Estateid.HeaderText = "打印状态"
        Me.Estateid.Name = "Estateid"
        Me.Estateid.ReadOnly = True
        '
        'PackingLevel
        '
        Me.PackingLevel.HeaderText = "箱层"
        Me.PackingLevel.Name = "PackingLevel"
        Me.PackingLevel.ReadOnly = True
        '
        'applyPart
        '
        Me.applyPart.HeaderText = "申请料号"
        Me.applyPart.Name = "applyPart"
        Me.applyPart.ReadOnly = True
        Me.applyPart.Visible = False
        '
        'GroupPrintFlag
        '
        Me.GroupPrintFlag.HeaderText = "组合打印"
        Me.GroupPrintFlag.Name = "GroupPrintFlag"
        Me.GroupPrintFlag.ReadOnly = True
        '
        'dgvRuleList
        '
        Me.dgvRuleList.AllowUserToAddRows = False
        Me.dgvRuleList.AllowUserToDeleteRows = False
        Me.dgvRuleList.AllowUserToOrderColumns = True
        Me.dgvRuleList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRuleList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvRuleList.ColumnHeadersHeight = 25
        Me.dgvRuleList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ParaCode, Me.ParaName, Me.ParaValue})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRuleList.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvRuleList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRuleList.EnableHeadersVisualStyles = False
        Me.dgvRuleList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvRuleList.Location = New System.Drawing.Point(0, 0)
        Me.dgvRuleList.Name = "dgvRuleList"
        Me.dgvRuleList.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRuleList.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvRuleList.RowHeadersWidth = 4
        Me.dgvRuleList.RowTemplate.Height = 23
        Me.dgvRuleList.Size = New System.Drawing.Size(310, 271)
        Me.dgvRuleList.TabIndex = 1
        '
        'ParaCode
        '
        Me.ParaCode.HeaderText = "参数代码"
        Me.ParaCode.Name = "ParaCode"
        Me.ParaCode.ReadOnly = True
        '
        'ParaName
        '
        Me.ParaName.HeaderText = "参数名称"
        Me.ParaName.Name = "ParaName"
        Me.ParaName.ReadOnly = True
        '
        'ParaValue
        '
        Me.ParaValue.HeaderText = "参数值"
        Me.ParaValue.Name = "ParaValue"
        Me.ParaValue.ReadOnly = True
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 180000
        '
        'ToolNew
        '
        Me.ToolNew.ForeColor = System.Drawing.Color.Black
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(74, 22)
        Me.ToolNew.Tag = "NO"
        Me.ToolNew.Text = "新 增(&N)"
        Me.ToolNew.ToolTipText = "新 增"
        '
        'ToolAgain
        '
        Me.ToolAgain.ForeColor = System.Drawing.Color.Black
        Me.ToolAgain.Image = CType(resources.GetObject("ToolAgain.Image"), System.Drawing.Image)
        Me.ToolAgain.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAgain.Name = "ToolAgain"
        Me.ToolAgain.Size = New System.Drawing.Size(92, 22)
        Me.ToolAgain.Tag = "NO"
        Me.ToolAgain.Text = "重新下载(&A)"
        Me.ToolAgain.ToolTipText = "重 新"
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
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
        '
        'ToolPrt
        '
        Me.ToolPrt.ForeColor = System.Drawing.Color.Black
        Me.ToolPrt.Image = CType(resources.GetObject("ToolPrt.Image"), System.Drawing.Image)
        Me.ToolPrt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrt.Name = "ToolPrt"
        Me.ToolPrt.Size = New System.Drawing.Size(52, 22)
        Me.ToolPrt.Tag = "NO"
        Me.ToolPrt.Text = "打印"
        Me.ToolPrt.ToolTipText = "打印"
        '
        'ToolTestPrt
        '
        Me.ToolTestPrt.Enabled = False
        Me.ToolTestPrt.ForeColor = System.Drawing.Color.Black
        Me.ToolTestPrt.Image = CType(resources.GetObject("ToolTestPrt.Image"), System.Drawing.Image)
        Me.ToolTestPrt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolTestPrt.Name = "ToolTestPrt"
        Me.ToolTestPrt.Size = New System.Drawing.Size(76, 22)
        Me.ToolTestPrt.Tag = "NO"
        Me.ToolTestPrt.Text = "测试打印"
        Me.ToolTestPrt.ToolTipText = "调试测试打印标签,不记录打印数量，条码标签无法在产线扫描使用"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolPrintLoak
        '
        Me.ToolPrintLoak.Image = CType(resources.GetObject("ToolPrintLoak.Image"), System.Drawing.Image)
        Me.ToolPrintLoak.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrintLoak.Name = "ToolPrintLoak"
        Me.ToolPrintLoak.Size = New System.Drawing.Size(76, 22)
        Me.ToolPrintLoak.Text = "打印解锁"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolCommitInfo
        '
        Me.ToolCommitInfo.Image = CType(resources.GetObject("ToolCommitInfo.Image"), System.Drawing.Image)
        Me.ToolCommitInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCommitInfo.Name = "ToolCommitInfo"
        Me.ToolCommitInfo.Size = New System.Drawing.Size(92, 22)
        Me.ToolCommitInfo.Tag = "NO"
        Me.ToolCommitInfo.Text = "需求提交(&C)"
        Me.ToolCommitInfo.ToolTipText = "需求提交"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolMove
        '
        Me.ToolMove.ForeColor = System.Drawing.Color.Black
        Me.ToolMove.Image = CType(resources.GetObject("ToolMove.Image"), System.Drawing.Image)
        Me.ToolMove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolMove.Name = "ToolMove"
        Me.ToolMove.Size = New System.Drawing.Size(52, 22)
        Me.ToolMove.Tag = "NO"
        Me.ToolMove.Text = "退单"
        Me.ToolMove.ToolTipText = "退单"
        '
        'toolCheck
        '
        Me.toolCheck.Image = CType(resources.GetObject("toolCheck.Image"), System.Drawing.Image)
        Me.toolCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCheck.Name = "toolCheck"
        Me.toolCheck.Size = New System.Drawing.Size(67, 22)
        Me.toolCheck.Text = "审核(&T)"
        '
        'ToolInPortTxt
        '
        Me.ToolInPortTxt.Image = CType(resources.GetObject("ToolInPortTxt.Image"), System.Drawing.Image)
        Me.ToolInPortTxt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolInPortTxt.Name = "ToolInPortTxt"
        Me.ToolInPortTxt.Size = New System.Drawing.Size(90, 22)
        Me.ToolInPortTxt.Tag = ""
        Me.ToolInPortTxt.Text = "修改模板(&F)"
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
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolAgain, Me.ToolEdit, Me.ToolDelete, Me.ToolCommit, Me.ToolBack, Me.ToolPrt, Me.ToolTestPrt, Me.ToolStripSeparator3, Me.ToolPrintLoak, Me.ToolStripSeparator5, Me.ToolCommitInfo, Me.ToolStripSeparator2, Me.ToolQuery, Me.ToolMove, Me.toolCheck, Me.ToolInPortTxt, Me.ToolStripSeparator1, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 2)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1354, 25)
        Me.ToolBt.TabIndex = 127
        Me.ToolBt.Text = "ToolStrip1"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "料件編號"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "标签类型"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "标签项次"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "编码原则"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "打印格式"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "空白標簽"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "列印份數"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 35
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "箱裝數量"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 35
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "外箱連接方式"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 70
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "起始流水號"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 50
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "終止流水號"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 50
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "狀態"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 60
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "設置參數人員"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 55
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "設置參數時間"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 110
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "設置格式人員"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 55
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "設置格式時間"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 110
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "作廢人員"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 55
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "作廢時間"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Visible = False
        Me.DataGridViewTextBoxColumn18.Width = 110
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "確認人員"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Visible = False
        Me.DataGridViewTextBoxColumn19.Width = 55
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "確認時間"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        Me.DataGridViewTextBoxColumn20.Width = 110
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.Frozen = True
        Me.DataGridViewTextBoxColumn21.HeaderText = "參數代碼"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 40
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn22.Frozen = True
        Me.DataGridViewTextBoxColumn22.HeaderText = "參數名稱"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Width = 40
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn23.Frozen = True
        Me.DataGridViewTextBoxColumn23.HeaderText = "參數值"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Width = 110
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn24.HeaderText = "參數值"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Width = 55
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "設置格式時間"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Width = 110
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn26.HeaderText = "作廢人員"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Width = 55
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn27.Frozen = True
        Me.DataGridViewTextBoxColumn27.HeaderText = "作廢時間"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn28.HeaderText = "確認人員"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn29.Frozen = True
        Me.DataGridViewTextBoxColumn29.HeaderText = "確認時間"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn30.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        Me.DataGridViewTextBoxColumn30.Width = 80
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn31.HeaderText = "參數代碼"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.FillWeight = 80.0!
        Me.DataGridViewTextBoxColumn32.HeaderText = "參數名稱"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.Width = 60
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.HeaderText = "參數值"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.Width = 60
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "ApplyAddQty"
        Me.DataGridViewTextBoxColumn34.HeaderText = "標簽列數"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.Width = 60
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "FinishedAddQty"
        Me.DataGridViewTextBoxColumn35.HeaderText = "描述"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.ReadOnly = True
        Me.DataGridViewTextBoxColumn35.Width = 50
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.HeaderText = "標簽列數"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.ReadOnly = True
        Me.DataGridViewTextBoxColumn36.Width = 78
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "PrintNumber"
        Me.DataGridViewTextBoxColumn37.HeaderText = "描述"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.ReadOnly = True
        Me.DataGridViewTextBoxColumn37.Width = 54
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.HeaderText = "描述"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.ReadOnly = True
        Me.DataGridViewTextBoxColumn38.Width = 80
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        Me.DataGridViewTextBoxColumn39.ReadOnly = True
        Me.DataGridViewTextBoxColumn39.Width = 60
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.HeaderText = "参数名称"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        Me.DataGridViewTextBoxColumn40.ReadOnly = True
        Me.DataGridViewTextBoxColumn40.Width = 80
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.DataPropertyName = "PrintNumber"
        Me.DataGridViewTextBoxColumn41.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        Me.DataGridViewTextBoxColumn41.ReadOnly = True
        Me.DataGridViewTextBoxColumn41.Width = 60
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        Me.DataGridViewTextBoxColumn42.ReadOnly = True
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        Me.DataGridViewTextBoxColumn43.ReadOnly = True
        Me.DataGridViewTextBoxColumn43.Visible = False
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        Me.DataGridViewTextBoxColumn44.ReadOnly = True
        Me.DataGridViewTextBoxColumn44.Visible = False
        Me.DataGridViewTextBoxColumn44.Width = 80
        '
        'DataGridViewTextBoxColumn45
        '
        Me.DataGridViewTextBoxColumn45.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn45.Name = "DataGridViewTextBoxColumn45"
        Me.DataGridViewTextBoxColumn45.ReadOnly = True
        '
        'DataGridViewTextBoxColumn46
        '
        Me.DataGridViewTextBoxColumn46.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
        Me.DataGridViewTextBoxColumn46.ReadOnly = True
        Me.DataGridViewTextBoxColumn46.Visible = False
        '
        'DataGridViewTextBoxColumn47
        '
        Me.DataGridViewTextBoxColumn47.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
        Me.DataGridViewTextBoxColumn47.ReadOnly = True
        '
        'DataGridViewTextBoxColumn48
        '
        Me.DataGridViewTextBoxColumn48.HeaderText = "参数名称"
        Me.DataGridViewTextBoxColumn48.Name = "DataGridViewTextBoxColumn48"
        Me.DataGridViewTextBoxColumn48.ReadOnly = True
        Me.DataGridViewTextBoxColumn48.Visible = False
        '
        'DataGridViewTextBoxColumn49
        '
        Me.DataGridViewTextBoxColumn49.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn49.Name = "DataGridViewTextBoxColumn49"
        Me.DataGridViewTextBoxColumn49.ReadOnly = True
        '
        'DataGridViewTextBoxColumn50
        '
        Me.DataGridViewTextBoxColumn50.HeaderText = "参数名称"
        Me.DataGridViewTextBoxColumn50.Name = "DataGridViewTextBoxColumn50"
        Me.DataGridViewTextBoxColumn50.ReadOnly = True
        Me.DataGridViewTextBoxColumn50.Visible = False
        '
        'DataGridViewTextBoxColumn51
        '
        Me.DataGridViewTextBoxColumn51.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn51.Name = "DataGridViewTextBoxColumn51"
        Me.DataGridViewTextBoxColumn51.ReadOnly = True
        '
        'DataGridViewTextBoxColumn52
        '
        Me.DataGridViewTextBoxColumn52.DataPropertyName = "PrtTestQty"
        Me.DataGridViewTextBoxColumn52.HeaderText = "参数名称"
        Me.DataGridViewTextBoxColumn52.Name = "DataGridViewTextBoxColumn52"
        Me.DataGridViewTextBoxColumn52.ReadOnly = True
        Me.DataGridViewTextBoxColumn52.Width = 80
        '
        'DataGridViewTextBoxColumn53
        '
        Me.DataGridViewTextBoxColumn53.DataPropertyName = "FinishTestPrintQty"
        Me.DataGridViewTextBoxColumn53.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn53.Name = "DataGridViewTextBoxColumn53"
        Me.DataGridViewTextBoxColumn53.ReadOnly = True
        Me.DataGridViewTextBoxColumn53.Width = 80
        '
        'DataGridViewTextBoxColumn54
        '
        Me.DataGridViewTextBoxColumn54.DataPropertyName = "ApplyAddQty"
        Me.DataGridViewTextBoxColumn54.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
        Me.DataGridViewTextBoxColumn54.ReadOnly = True
        Me.DataGridViewTextBoxColumn54.Visible = False
        Me.DataGridViewTextBoxColumn54.Width = 80
        '
        'DataGridViewTextBoxColumn55
        '
        Me.DataGridViewTextBoxColumn55.DataPropertyName = "FinishedAddQty"
        Me.DataGridViewTextBoxColumn55.HeaderText = "参数名称"
        Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
        Me.DataGridViewTextBoxColumn55.ReadOnly = True
        Me.DataGridViewTextBoxColumn55.Width = 80
        '
        'DataGridViewTextBoxColumn56
        '
        Me.DataGridViewTextBoxColumn56.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn56.Name = "DataGridViewTextBoxColumn56"
        Me.DataGridViewTextBoxColumn56.ReadOnly = True
        '
        'DataGridViewTextBoxColumn57
        '
        Me.DataGridViewTextBoxColumn57.HeaderText = "参数名称"
        Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
        Me.DataGridViewTextBoxColumn57.ReadOnly = True
        '
        'DataGridViewTextBoxColumn58
        '
        Me.DataGridViewTextBoxColumn58.HeaderText = "参数值"
        Me.DataGridViewTextBoxColumn58.Name = "DataGridViewTextBoxColumn58"
        Me.DataGridViewTextBoxColumn58.ReadOnly = True
        '
        'FrmListPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 617)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmListPrint"
        Me.Text = "条码打印作业"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgvLotList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvPrintList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRuleList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TxtPartid As System.Windows.Forms.TextBox
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvRuleList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtMOId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPrintCount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvLotList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewRolloverCellColumn1 As BarCodePrint.DataGridViewRolloverCellColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboCust As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents CboMoType As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents CboLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents CboDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblCreatDate As System.Windows.Forms.Label
    Friend WithEvents DtMoNeedTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboShift As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtBuildAttribute As System.Windows.Forms.TextBox
    Friend WithEvents TxtDriFlag As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtFileVerNo As System.Windows.Forms.TextBox
    Friend WithEvents TxtTaskDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ChkNotPrint As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BnEdit As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblPrintDate As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParaCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParaName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParaValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn43 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chbPrintListSelect As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDemandInfo As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewTextBoxColumn44 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridViewTextBoxColumn45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn46 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn47 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ChkDemandTime As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn48 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn49 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CboSeries As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkGetCodeNoPrint As System.Windows.Forms.CheckBox
    Friend WithEvents txtPackageVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBlueprintVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn50 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn51 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkConfirm As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn52 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn53 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn54 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkTestPrint As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn56 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn57 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn58 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colmoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPartid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ppidprtqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PpidprtCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pkgprtqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BlueprintVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackageVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHECKTEXT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemandInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNeedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CusName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plandate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRework As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvPrintList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ChkSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PtaskId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lableType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileVerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionTypeText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coluserid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colintime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinishPrintQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrtAddQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinishPrtAddQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfigurationQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PnLable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrinterName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents PackingQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCLNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrunkNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelTemplates As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TemplateDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisorderType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents djmdc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shift As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents linejm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Demandtime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DriFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildAttribute As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estateid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents applyPart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupPrintFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rtxtStepMessage As DevComponents.DotNetBar.Controls.RichTextBoxEx
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolAgain As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTestPrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolPrintLoak As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolCommitInfo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolMove As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolInPortTxt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents CboItemCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents mtxtMOid As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
End Class
