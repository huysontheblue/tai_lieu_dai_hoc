<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReprintQuery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReprintQuery))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dtpTime = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtMOId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.dgvLot = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Moid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PPartid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackingReprintCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductReprintCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AffiliatedReprintCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvBarcode = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lableType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelTemplates = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TemplateDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisorderType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReprintQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TemplatePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remork = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.ToolBt.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dtpTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolBack, Me.ToolCancel, Me.ToolStripSeparator2, Me.ToolPrint, Me.ToolFind, Me.ToolStripSeparator3, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1048, 25)
        Me.ToolBt.TabIndex = 128
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolPrint
        '
        Me.ToolPrint.Enabled = False
        Me.ToolPrint.ForeColor = System.Drawing.Color.Black
        Me.ToolPrint.Image = CType(resources.GetObject("ToolPrint.Image"), System.Drawing.Image)
        Me.ToolPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrint.Name = "ToolPrint"
        Me.ToolPrint.Size = New System.Drawing.Size(52, 22)
        Me.ToolPrint.Tag = "NO"
        Me.ToolPrint.Text = "打印"
        Me.ToolPrint.ToolTipText = "確 認"
        '
        'ToolFind
        '
        Me.ToolFind.ForeColor = System.Drawing.Color.Black
        Me.ToolFind.Image = CType(resources.GetObject("ToolFind.Image"), System.Drawing.Image)
        Me.ToolFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolFind.Name = "ToolFind"
        Me.ToolFind.Size = New System.Drawing.Size(74, 22)
        Me.ToolFind.Text = "查 询(&Q)"
        Me.ToolFind.ToolTipText = "查 詢"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpTime)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMOId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvLot)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvBarcode)
        Me.SplitContainer1.Size = New System.Drawing.Size(1048, 457)
        Me.SplitContainer1.SplitterDistance = 251
        Me.SplitContainer1.TabIndex = 132
        '
        'dtpTime
        '
        '
        '
        '
        Me.dtpTime.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpTime.ButtonDropDown.Visible = True
        Me.dtpTime.CustomFormat = "yyyy-MM-dd"
        Me.dtpTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtpTime.IsPopupCalendarOpen = False
        Me.dtpTime.Location = New System.Drawing.Point(327, 15)
        '
        '
        '
        '
        '
        '
        Me.dtpTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpTime.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpTime.MonthCalendar.DisplayMonth = New Date(2016, 11, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dtpTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpTime.MonthCalendar.TodayButtonVisible = True
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.Size = New System.Drawing.Size(149, 21)
        Me.dtpTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpTime.TabIndex = 138
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(274, 14)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 137
        Me.LabelX1.Text = "日期："
        '
        'txtMOId
        '
        '
        '
        '
        Me.txtMOId.Border.Class = "TextBoxBorder"
        Me.txtMOId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMOId.Location = New System.Drawing.Point(68, 15)
        Me.txtMOId.Name = "txtMOId"
        Me.txtMOId.Size = New System.Drawing.Size(157, 21)
        Me.txtMOId.TabIndex = 135
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(28, 15)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 136
        Me.LabelX2.Text = "工单："
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(501, 15)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(446, 23)
        Me.lblMessage.TabIndex = 134
        '
        'dgvLot
        '
        Me.dgvLot.AllowUserToAddRows = False
        Me.dgvLot.AllowUserToDeleteRows = False
        Me.dgvLot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLot.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLot.ColumnHeadersHeight = 25
        Me.dgvLot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Moid, Me.PPartid, Me.PackingReprintCount, Me.ProductReprintCount, Me.AffiliatedReprintCount, Me.LineID})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLot.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLot.EnableHeadersVisualStyles = False
        Me.dgvLot.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvLot.Location = New System.Drawing.Point(3, 53)
        Me.dgvLot.MultiSelect = False
        Me.dgvLot.Name = "dgvLot"
        Me.dgvLot.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLot.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLot.RowHeadersWidth = 20
        Me.dgvLot.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvLot.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvLot.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvLot.RowTemplate.Height = 23
        Me.dgvLot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLot.Size = New System.Drawing.Size(1045, 196)
        Me.dgvLot.TabIndex = 133
        '
        'Moid
        '
        Me.Moid.HeaderText = "工单编号"
        Me.Moid.Name = "Moid"
        Me.Moid.ReadOnly = True
        '
        'PPartid
        '
        Me.PPartid.HeaderText = "料件编号"
        Me.PPartid.Name = "PPartid"
        Me.PPartid.ReadOnly = True
        '
        'PackingReprintCount
        '
        Me.PackingReprintCount.HeaderText = "包装申请数量"
        Me.PackingReprintCount.Name = "PackingReprintCount"
        Me.PackingReprintCount.ReadOnly = True
        Me.PackingReprintCount.Width = 120
        '
        'ProductReprintCount
        '
        Me.ProductReprintCount.HeaderText = "产品申请数量"
        Me.ProductReprintCount.Name = "ProductReprintCount"
        Me.ProductReprintCount.ReadOnly = True
        Me.ProductReprintCount.Width = 120
        '
        'AffiliatedReprintCount
        '
        Me.AffiliatedReprintCount.HeaderText = "附属标签"
        Me.AffiliatedReprintCount.Name = "AffiliatedReprintCount"
        Me.AffiliatedReprintCount.ReadOnly = True
        '
        'LineID
        '
        Me.LineID.HeaderText = "申请产线"
        Me.LineID.Name = "LineID"
        Me.LineID.ReadOnly = True
        '
        'dgvBarcode
        '
        Me.dgvBarcode.AllowUserToAddRows = False
        Me.dgvBarcode.AllowUserToDeleteRows = False
        Me.dgvBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarcode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBarcode.ColumnHeadersHeight = 25
        Me.dgvBarcode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartId, Me.sBarCode, Me.lableType, Me.LabelTemplates, Me.TemplateDescription, Me.DisorderType, Me.ReprintQty, Me.UserName, Me.CreateDate, Me.PrintDate, Me.PrintUserName, Me.TemplatePath, Me.Remork, Me.StatusFlag})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBarcode.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBarcode.EnableHeadersVisualStyles = False
        Me.dgvBarcode.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvBarcode.Location = New System.Drawing.Point(0, 0)
        Me.dgvBarcode.MultiSelect = False
        Me.dgvBarcode.Name = "dgvBarcode"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBarcode.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvBarcode.RowHeadersWidth = 20
        Me.dgvBarcode.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvBarcode.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvBarcode.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgvBarcode.RowTemplate.Height = 23
        Me.dgvBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBarcode.Size = New System.Drawing.Size(1048, 202)
        Me.dgvBarcode.TabIndex = 133
        '
        'PartId
        '
        Me.PartId.HeaderText = "料件号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        '
        'sBarCode
        '
        Me.sBarCode.HeaderText = "条码"
        Me.sBarCode.Name = "sBarCode"
        Me.sBarCode.ReadOnly = True
        Me.sBarCode.Width = 150
        '
        'lableType
        '
        Me.lableType.HeaderText = "标签类型"
        Me.lableType.Name = "lableType"
        Me.lableType.ReadOnly = True
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
        'DisorderType
        '
        Me.DisorderType.HeaderText = "无序类型"
        Me.DisorderType.Name = "DisorderType"
        Me.DisorderType.ReadOnly = True
        '
        'ReprintQty
        '
        Me.ReprintQty.HeaderText = "数量"
        Me.ReprintQty.Name = "ReprintQty"
        Me.ReprintQty.ReadOnly = True
        '
        'UserName
        '
        Me.UserName.HeaderText = "申请人员"
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        '
        'CreateDate
        '
        Me.CreateDate.HeaderText = "申请时间"
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.ReadOnly = True
        '
        'PrintDate
        '
        Me.PrintDate.HeaderText = "打印时间"
        Me.PrintDate.Name = "PrintDate"
        Me.PrintDate.ReadOnly = True
        '
        'PrintUserName
        '
        Me.PrintUserName.HeaderText = "打印用户"
        Me.PrintUserName.Name = "PrintUserName"
        Me.PrintUserName.ReadOnly = True
        '
        'TemplatePath
        '
        Me.TemplatePath.HeaderText = "模板路径"
        Me.TemplatePath.Name = "TemplatePath"
        Me.TemplatePath.ReadOnly = True
        '
        'Remork
        '
        Me.Remork.HeaderText = "备注"
        Me.Remork.Name = "Remork"
        Me.Remork.ReadOnly = True
        '
        'StatusFlag
        '
        Me.StatusFlag.HeaderText = "打印状态"
        Me.StatusFlag.Name = "StatusFlag"
        Me.StatusFlag.ReadOnly = True
        Me.StatusFlag.Width = 50
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "工单编号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "包装申请数量"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "产品申请数量"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "料件号"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "条码"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 150
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "标签类型"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "标签模板"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 150
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "模板描述"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "无序类型"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "打印状态"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "申请人员"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "申请时间"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "模板路径"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "模板路径"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "备注"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'FrmReprintQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 482)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmReprintQuery"
        Me.ShowIcon = False
        Me.Text = "不良条码申请报表"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dtpTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLot, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvLot As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvBarcode As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtMOId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Moid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PPartid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingReprintCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductReprintCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AffiliatedReprintCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dtpTime As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lableType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelTemplates As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TemplateDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisorderType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReprintQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TemplatePath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remork As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusFlag As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
