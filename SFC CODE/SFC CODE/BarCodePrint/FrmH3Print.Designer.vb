<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmH3Print
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmH3Print))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolPrintLoak = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolTestPrinte = New System.Windows.Forms.ToolStripButton()
        Me.ToolPrt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.ChkDemandTime = New System.Windows.Forms.CheckBox()
        Me.BnEdit = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblPrintDate = New System.Windows.Forms.Label()
        Me.ChkNotPrint = New System.Windows.Forms.CheckBox()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.dgvLotList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Colmoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPartid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ppidprtqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PpidprtCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pkgprtqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lableType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileVerNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinishPrintQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfigurationQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrinterName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PackingQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FCLNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TrunkNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.dgvRuleList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ParaCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParaName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParaValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
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
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolDelete, Me.ToolCommit, Me.ToolBack, Me.ToolPrintLoak, Me.ToolStripSeparator4, Me.ToolTestPrinte, Me.ToolPrt, Me.ToolStripSeparator3, Me.ToolStripSeparator2, Me.ToolQuery, Me.ToolStripSeparator1, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1362, 25)
        Me.ToolBt.TabIndex = 132
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
        'ToolPrintLoak
        '
        Me.ToolPrintLoak.Image = CType(resources.GetObject("ToolPrintLoak.Image"), System.Drawing.Image)
        Me.ToolPrintLoak.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrintLoak.Name = "ToolPrintLoak"
        Me.ToolPrintLoak.Size = New System.Drawing.Size(76, 22)
        Me.ToolPrintLoak.Text = "打印解锁"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolTestPrinte
        '
        Me.ToolTestPrinte.ForeColor = System.Drawing.Color.Black
        Me.ToolTestPrinte.Image = Global.BarCodePrint.My.Resources.Resources.printer_key
        Me.ToolTestPrinte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolTestPrinte.Name = "ToolTestPrinte"
        Me.ToolTestPrinte.Size = New System.Drawing.Size(76, 22)
        Me.ToolTestPrinte.Tag = "NO"
        Me.ToolTestPrinte.Text = "测试打印"
        Me.ToolTestPrinte.ToolTipText = "测试打印"
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
        Me.ToolPrt.ToolTipText = "確 認"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkDemandTime)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BnEdit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblPrintDate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkNotPrint)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.Black
        Me.SplitContainer1.Panel1MinSize = 1
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Panel2MinSize = 1
        Me.SplitContainer1.Size = New System.Drawing.Size(1362, 592)
        Me.SplitContainer1.SplitterDistance = 79
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 133
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(828, 21)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(442, 36)
        Me.lblMessage.TabIndex = 233
        '
        'ChkDemandTime
        '
        Me.ChkDemandTime.AutoSize = True
        Me.ChkDemandTime.Location = New System.Drawing.Point(785, 20)
        Me.ChkDemandTime.Name = "ChkDemandTime"
        Me.ChkDemandTime.Size = New System.Drawing.Size(15, 14)
        Me.ChkDemandTime.TabIndex = 231
        Me.ChkDemandTime.UseVisualStyleBackColor = True
        '
        'BnEdit
        '
        Me.BnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnEdit.Image = CType(resources.GetObject("BnEdit.Image"), System.Drawing.Image)
        Me.BnEdit.Location = New System.Drawing.Point(769, 40)
        Me.BnEdit.Name = "BnEdit"
        Me.BnEdit.Size = New System.Drawing.Size(29, 18)
        Me.BnEdit.TabIndex = 225
        Me.BnEdit.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(629, 43)
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
        Me.LblPrintDate.Location = New System.Drawing.Point(696, 43)
        Me.LblPrintDate.Name = "LblPrintDate"
        Me.LblPrintDate.Size = New System.Drawing.Size(41, 12)
        Me.LblPrintDate.TabIndex = 223
        Me.LblPrintDate.Text = "######"
        '
        'ChkNotPrint
        '
        Me.ChkNotPrint.AutoSize = True
        Me.ChkNotPrint.Location = New System.Drawing.Point(690, 20)
        Me.ChkNotPrint.Name = "ChkNotPrint"
        Me.ChkNotPrint.Size = New System.Drawing.Size(15, 14)
        Me.ChkNotPrint.TabIndex = 222
        Me.ChkNotPrint.UseVisualStyleBackColor = True
        '
        'txtPrintCount
        '
        Me.txtPrintCount.BackColor = System.Drawing.Color.White
        Me.txtPrintCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrintCount.Font = New System.Drawing.Font("宋体", 32.0!)
        Me.txtPrintCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtPrintCount.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtPrintCount.Location = New System.Drawing.Point(511, 15)
        Me.txtPrintCount.MaxLength = 20
        Me.txtPrintCount.Multiline = True
        Me.txtPrintCount.Name = "txtPrintCount"
        Me.txtPrintCount.Size = New System.Drawing.Size(103, 46)
        Me.txtPrintCount.TabIndex = 116
        Me.txtPrintCount.Text = "100"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(431, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 22)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "打印数量"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(280, 40)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpStartDate.TabIndex = 115
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(219, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "结束日期："
        '
        'TxtPartid
        '
        Me.TxtPartid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPartid.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TxtPartid.Location = New System.Drawing.Point(74, 40)
        Me.TxtPartid.MaxLength = 20
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(136, 21)
        Me.TxtPartid.TabIndex = 0
        '
        'Lbl1
        '
        Me.Lbl1.AutoSize = True
        Me.Lbl1.Location = New System.Drawing.Point(10, 41)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(65, 12)
        Me.Lbl1.TabIndex = 111
        Me.Lbl1.Text = "料件编号："
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(280, 15)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(136, 21)
        Me.dtpEndDate.TabIndex = 112
        '
        'txtMOId
        '
        Me.txtMOId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMOId.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtMOId.Location = New System.Drawing.Point(74, 15)
        Me.txtMOId.MaxLength = 20
        Me.txtMOId.Name = "txtMOId"
        Me.txtMOId.Size = New System.Drawing.Size(136, 21)
        Me.txtMOId.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(219, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "开始日期："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(724, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 232
        Me.Label10.Text = "标签日期："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(629, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 226
        Me.Label8.Text = "是否打印："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "工单："
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
        Me.SplitContainer3.Size = New System.Drawing.Size(1362, 512)
        Me.SplitContainer3.SplitterDistance = 218
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
        Me.dgvLotList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Colmoid, Me.ColPartid, Me.ColQty, Me.Ppidprtqty, Me.PpidprtCount, Me.Pkgprtqty, Me.ColLineId, Me.CHECKTEXT, Me.DemandInfo, Me.ColNeedDate, Me.ColDept, Me.CusName, Me.Plandate, Me.Column16, Me.Column17, Me.ColRework})
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
        Me.dgvLotList.Size = New System.Drawing.Size(1362, 218)
        Me.dgvLotList.TabIndex = 115
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
        'ColQty
        '
        Me.ColQty.HeaderText = "需求数量"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.ReadOnly = True
        Me.ColQty.Width = 80
        '
        'Ppidprtqty
        '
        Me.Ppidprtqty.HeaderText = "已打张数"
        Me.Ppidprtqty.Name = "Ppidprtqty"
        Me.Ppidprtqty.ReadOnly = True
        Me.Ppidprtqty.Width = 80
        '
        'PpidprtCount
        '
        Me.PpidprtCount.HeaderText = "已打数量"
        Me.PpidprtCount.Name = "PpidprtCount"
        Me.PpidprtCount.ReadOnly = True
        Me.PpidprtCount.Width = 80
        '
        'Pkgprtqty
        '
        Me.Pkgprtqty.HeaderText = "成品条码数量"
        Me.Pkgprtqty.Name = "Pkgprtqty"
        Me.Pkgprtqty.ReadOnly = True
        Me.Pkgprtqty.Width = 110
        '
        'ColLineId
        '
        Me.ColLineId.HeaderText = "线别编号"
        Me.ColLineId.Name = "ColLineId"
        Me.ColLineId.ReadOnly = True
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
        Me.SplitContainer2.Size = New System.Drawing.Size(1362, 293)
        Me.SplitContainer2.SplitterDistance = 1050
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 0
        '
        'chbPrintListSelect
        '
        Me.chbPrintListSelect.AutoSize = True
        Me.chbPrintListSelect.Checked = True
        Me.chbPrintListSelect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPrintListSelect.Location = New System.Drawing.Point(58, 7)
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
        Me.dgvPrintList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChkSelect, Me.PtaskId, Me.Moid, Me.PartId, Me.ParentPartId, Me.lableType, Me.PackItem, Me.FileVerNo, Me.Remark, Me.Qty, Me.PrintQTY, Me.FinishPrintQty, Me.ConfigurationQty, Me.PrinterName, Me.PackingQty, Me.FCLNumber, Me.TrunkNumber, Me.LabelTemplates, Me.TemplateDescription, Me.Status, Me.DisorderType, Me.djmdc, Me.shift, Me.linejm, Me.Demandtime, Me.DriFlag, Me.BuildAttribute, Me.Estateid, Me.PackingLevel, Me.applyPart})
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
        Me.dgvPrintList.Size = New System.Drawing.Size(1050, 293)
        Me.dgvPrintList.TabIndex = 1
        '
        'ChkSelect
        '
        Me.ChkSelect.HeaderText = "选择"
        Me.ChkSelect.Name = "ChkSelect"
        Me.ChkSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkSelect.Width = 70
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
        Me.Moid.HeaderText = "工单编号"
        Me.Moid.Name = "Moid"
        Me.Moid.ReadOnly = True
        Me.Moid.Width = 120
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
        'lableType
        '
        Me.lableType.HeaderText = "标签类型"
        Me.lableType.Name = "lableType"
        Me.lableType.ReadOnly = True
        Me.lableType.Width = 80
        '
        'PackItem
        '
        Me.PackItem.HeaderText = "类型项次"
        Me.PackItem.Name = "PackItem"
        Me.PackItem.ReadOnly = True
        Me.PackItem.Width = 80
        '
        'FileVerNo
        '
        Me.FileVerNo.HeaderText = "申请版本(*)"
        Me.FileVerNo.Name = "FileVerNo"
        '
        'Remark
        '
        Me.Remark.HeaderText = "料件版本"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'Qty
        '
        Me.Qty.HeaderText = "工单数量"
        Me.Qty.Name = "Qty"
        Me.Qty.Width = 80
        '
        'PrintQTY
        '
        Me.PrintQTY.FillWeight = 80.0!
        Me.PrintQTY.HeaderText = "需求数量"
        Me.PrintQTY.Name = "PrintQTY"
        Me.PrintQTY.ReadOnly = True
        Me.PrintQTY.Width = 80
        '
        'FinishPrintQty
        '
        Me.FinishPrintQty.HeaderText = "已打印"
        Me.FinishPrintQty.Name = "FinishPrintQty"
        Me.FinishPrintQty.ReadOnly = True
        Me.FinishPrintQty.Width = 80
        '
        'ConfigurationQty
        '
        Me.ConfigurationQty.HeaderText = "配套数"
        Me.ConfigurationQty.Name = "ConfigurationQty"
        Me.ConfigurationQty.ReadOnly = True
        Me.ConfigurationQty.Width = 70
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
        Me.PackingQty.Width = 80
        '
        'FCLNumber
        '
        Me.FCLNumber.HeaderText = "整箱数"
        Me.FCLNumber.Name = "FCLNumber"
        Me.FCLNumber.ReadOnly = True
        Me.FCLNumber.Width = 80
        '
        'TrunkNumber
        '
        Me.TrunkNumber.HeaderText = "尾箱数"
        Me.TrunkNumber.Name = "TrunkNumber"
        Me.TrunkNumber.ReadOnly = True
        Me.TrunkNumber.Width = 80
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
        Me.dgvRuleList.Size = New System.Drawing.Size(311, 293)
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
        'FrmH3Print
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 617)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmH3Print"
        Me.ShowIcon = False
        Me.Text = "华三外箱标签打印"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTestPrinte As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ChkDemandTime As System.Windows.Forms.CheckBox
    Friend WithEvents BnEdit As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblPrintDate As System.Windows.Forms.Label
    Friend WithEvents ChkNotPrint As System.Windows.Forms.CheckBox
    Friend WithEvents txtPrintCount As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPartid As System.Windows.Forms.TextBox
    Friend WithEvents Lbl1 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtMOId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvLotList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Colmoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPartid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ppidprtqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PpidprtCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pkgprtqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHECKTEXT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemandInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNeedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CusName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Plandate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRework As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents chbPrintListSelect As System.Windows.Forms.CheckBox
    Friend WithEvents dgvPrintList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ChkSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PtaskId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lableType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileVerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinishPrintQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfigurationQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrinterName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents PackingQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCLNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrunkNumber As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents dgvRuleList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ParaCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParaName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParaValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents ToolPrintLoak As System.Windows.Forms.ToolStripButton
End Class
