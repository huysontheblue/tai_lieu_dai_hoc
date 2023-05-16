<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCheckShippingBarCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCheckShippingBarCode))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtShippingNO = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.ChkPlay = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.btnHandle = New DevComponents.DotNetBar.ButtonX()
        Me.lblQuantity = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.btnClear = New DevComponents.DotNetBar.ButtonX()
        Me.txtScanBarcode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtCheckBarcode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.lblResult = New DevComponents.DotNetBar.LabelX()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgvScanList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHIPPING_NO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvScanList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolCancel, Me.ToolCommit, Me.ToolBack, Me.ToolStripSeparator3, Me.ToolStripSeparator2, Me.ToolQuery, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 2)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(524, 25)
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
        'ToolCancel
        '
        Me.ToolCancel.Enabled = False
        Me.ToolCancel.ForeColor = System.Drawing.Color.Black
        Me.ToolCancel.Image = CType(resources.GetObject("ToolCancel.Image"), System.Drawing.Image)
        Me.ToolCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCancel.Name = "ToolCancel"
        Me.ToolCancel.Size = New System.Drawing.Size(73, 22)
        Me.ToolCancel.Tag = "NO"
        Me.ToolCancel.Text = "作 废(&D)"
        Me.ToolCancel.ToolTipText = "作 廢"
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
        Me.ToolQuery.Enabled = False
        Me.ToolQuery.ForeColor = System.Drawing.Color.Black
        Me.ToolQuery.Image = CType(resources.GetObject("ToolQuery.Image"), System.Drawing.Image)
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(74, 22)
        Me.ToolQuery.Text = "查 询(&Q)"
        Me.ToolQuery.ToolTipText = "查 詢"
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
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 30)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtShippingNO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ChkPlay)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnHandle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblQuantity)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnClear)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtScanBarcode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCheckBarcode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblResult)
        Me.SplitContainer1.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvScanList)
        Me.SplitContainer1.Size = New System.Drawing.Size(1223, 465)
        Me.SplitContainer1.SplitterDistance = 169
        Me.SplitContainer1.TabIndex = 133
        '
        'txtShippingNO
        '
        '
        '
        '
        Me.txtShippingNO.Border.Class = "TextBoxBorder"
        Me.txtShippingNO.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtShippingNO.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.txtShippingNO.Location = New System.Drawing.Point(164, 11)
        Me.txtShippingNO.Name = "txtShippingNO"
        Me.txtShippingNO.Size = New System.Drawing.Size(235, 38)
        Me.txtShippingNO.TabIndex = 10
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.LabelX4.Location = New System.Drawing.Point(32, 18)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(136, 31)
        Me.LabelX4.TabIndex = 9
        Me.LabelX4.Text = "出货单号:"
        '
        'ChkPlay
        '
        '
        '
        '
        Me.ChkPlay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkPlay.Checked = True
        Me.ChkPlay.CheckSignSize = New System.Drawing.Size(18, 18)
        Me.ChkPlay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPlay.CheckValue = "Y"
        Me.ChkPlay.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.ChkPlay.Location = New System.Drawing.Point(604, 11)
        Me.ChkPlay.Name = "ChkPlay"
        Me.ChkPlay.Size = New System.Drawing.Size(150, 23)
        Me.ChkPlay.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.ChkPlay.TabIndex = 8
        Me.ChkPlay.Text = "声音播放"
        '
        'btnHandle
        '
        Me.btnHandle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnHandle.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.btnHandle.Location = New System.Drawing.Point(430, 123)
        Me.btnHandle.Name = "btnHandle"
        Me.btnHandle.Size = New System.Drawing.Size(94, 38)
        Me.btnHandle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnHandle.TabIndex = 7
        Me.btnHandle.Text = "处 理"
        '
        'lblQuantity
        '
        '
        '
        '
        Me.lblQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblQuantity.Font = New System.Drawing.Font("宋体", 80.0!)
        Me.lblQuantity.ForeColor = System.Drawing.Color.Green
        Me.lblQuantity.Location = New System.Drawing.Point(940, 48)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(420, 101)
        Me.lblQuantity.TabIndex = 6
        Me.lblQuantity.Text = "10000"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("宋体", 60.0!)
        Me.LabelX3.Location = New System.Drawing.Point(580, 48)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(412, 101)
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "扫描数量:"
        '
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.Font = New System.Drawing.Font("宋体", 15.0!)
        Me.btnClear.Location = New System.Drawing.Point(429, 65)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(94, 38)
        Me.btnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "清 除"
        '
        'txtScanBarcode
        '
        '
        '
        '
        Me.txtScanBarcode.Border.Class = "TextBoxBorder"
        Me.txtScanBarcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtScanBarcode.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.txtScanBarcode.Location = New System.Drawing.Point(164, 123)
        Me.txtScanBarcode.Name = "txtScanBarcode"
        Me.txtScanBarcode.Size = New System.Drawing.Size(235, 38)
        Me.txtScanBarcode.TabIndex = 3
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.LabelX2.Location = New System.Drawing.Point(32, 119)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(158, 47)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "检查扫描:"
        '
        'txtCheckBarcode
        '
        '
        '
        '
        Me.txtCheckBarcode.Border.Class = "TextBoxBorder"
        Me.txtCheckBarcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCheckBarcode.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.txtCheckBarcode.Location = New System.Drawing.Point(164, 65)
        Me.txtCheckBarcode.Name = "txtCheckBarcode"
        Me.txtCheckBarcode.Size = New System.Drawing.Size(235, 38)
        Me.txtCheckBarcode.TabIndex = 1
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("宋体", 20.0!)
        Me.LabelX1.Location = New System.Drawing.Point(32, 72)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(136, 31)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "标准条码:"
        '
        'lblResult
        '
        Me.lblResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResult.BackColor = System.Drawing.Color.PaleGreen
        '
        '
        '
        Me.lblResult.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblResult.Font = New System.Drawing.Font("宋体", 185.0!)
        Me.lblResult.ForeColor = System.Drawing.Color.Green
        Me.lblResult.Location = New System.Drawing.Point(871, 9)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(345, 254)
        Me.lblResult.TabIndex = 130
        Me.lblResult.Text = "OK"
        Me.lblResult.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblResult.TextLineAlignment = System.Drawing.StringAlignment.Near
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount, Me.lblMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 270)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1223, 22)
        Me.StatusStrip1.TabIndex = 129
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
        'dgvScanList
        '
        Me.dgvScanList.AllowUserToAddRows = False
        Me.dgvScanList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvScanList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvScanList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvScanList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvScanList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvScanList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 13.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvScanList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvScanList.ColumnHeadersHeight = 35
        Me.dgvScanList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NO, Me.SHIPPING_NO, Me.PartId, Me.CheckBarCode, Me.ScanBarCode, Me.CheckResult})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvScanList.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvScanList.EnableHeadersVisualStyles = False
        Me.dgvScanList.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgvScanList.Location = New System.Drawing.Point(0, 0)
        Me.dgvScanList.Name = "dgvScanList"
        Me.dgvScanList.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvScanList.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvScanList.RowHeadersWidth = 20
        Me.dgvScanList.RowTemplate.Height = 23
        Me.dgvScanList.Size = New System.Drawing.Size(864, 274)
        Me.dgvScanList.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn1.HeaderText = "序号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn2.HeaderText = "出货单号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 180
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn3.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 180
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn4.HeaderText = "标准条码"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn5.HeaderText = "检查条码"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 200
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "检查结果"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'NO
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NO.DefaultCellStyle = DataGridViewCellStyle3
        Me.NO.HeaderText = "序号"
        Me.NO.Name = "NO"
        Me.NO.ReadOnly = True
        Me.NO.Width = 80
        '
        'SHIPPING_NO
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.SHIPPING_NO.DefaultCellStyle = DataGridViewCellStyle4
        Me.SHIPPING_NO.HeaderText = "出货单号"
        Me.SHIPPING_NO.Name = "SHIPPING_NO"
        Me.SHIPPING_NO.ReadOnly = True
        Me.SHIPPING_NO.Width = 180
        '
        'PartId
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.PartId.DefaultCellStyle = DataGridViewCellStyle5
        Me.PartId.HeaderText = "料件编号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        Me.PartId.Width = 180
        '
        'CheckBarCode
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.CheckBarCode.DefaultCellStyle = DataGridViewCellStyle6
        Me.CheckBarCode.HeaderText = "标准条码"
        Me.CheckBarCode.Name = "CheckBarCode"
        Me.CheckBarCode.ReadOnly = True
        Me.CheckBarCode.Width = 200
        '
        'ScanBarCode
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ScanBarCode.DefaultCellStyle = DataGridViewCellStyle7
        Me.ScanBarCode.HeaderText = "检查条码"
        Me.ScanBarCode.Name = "ScanBarCode"
        Me.ScanBarCode.ReadOnly = True
        Me.ScanBarCode.Width = 200
        '
        'CheckResult
        '
        Me.CheckResult.HeaderText = "检查结果"
        Me.CheckResult.Name = "CheckResult"
        Me.CheckResult.ReadOnly = True
        Me.CheckResult.Visible = False
        '
        'FrmCheckShippingBarCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1223, 498)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmCheckShippingBarCode"
        Me.Text = "Belkin出货检查"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvScanList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtScanBarcode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCheckBarcode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblQuantity As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvScanList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnHandle As DevComponents.DotNetBar.ButtonX
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblResult As DevComponents.DotNetBar.LabelX
    Friend WithEvents ChkPlay As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHIPPING_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtShippingNO As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
