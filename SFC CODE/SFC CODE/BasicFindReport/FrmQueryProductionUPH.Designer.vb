<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQueryProductionUPH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQueryProductionUPH))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolReflsh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.mtxtMOid = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.CobPart = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TokenEditor1 = New DevComponents.DotNetBar.Controls.TokenEditor()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtEnd = New System.Windows.Forms.DateTimePicker()
        Me.DtStar = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.orderby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stationid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column00 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolReflsh, Me.ToolStripSeparator2, Me.ToolExcel, Me.ToolStripSeparator1, Me.ToolExit, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 2)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(889, 23)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 146
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolReflsh
        '
        Me.ToolReflsh.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolReflsh.Image = CType(resources.GetObject("ToolReflsh.Image"), System.Drawing.Image)
        Me.ToolReflsh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReflsh.Name = "ToolReflsh"
        Me.ToolReflsh.Size = New System.Drawing.Size(61, 20)
        Me.ToolReflsh.Text = "刷  新"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'ToolExcel
        '
        Me.ToolExcel.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolExcel.Image = CType(resources.GetObject("ToolExcel.Image"), System.Drawing.Image)
        Me.ToolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExcel.Name = "ToolExcel"
        Me.ToolExcel.Size = New System.Drawing.Size(61, 20)
        Me.ToolExcel.Text = "汇  出"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'ToolExit
        '
        Me.ToolExit.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(61, 20)
        Me.ToolExit.Text = "退  出"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.mtxtMOid)
        Me.GroupBox1.Controls.Add(Me.CobPart)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TokenEditor1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DtEnd)
        Me.GroupBox1.Controls.Add(Me.DtStar)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(884, 87)
        Me.GroupBox1.TabIndex = 149
        Me.GroupBox1.TabStop = False
        '
        'mtxtMOid
        '
        Me.mtxtMOid.BackgroundImage = Global.BasicFindReport.My.Resources.Resources.query
        '
        '
        '
        Me.mtxtMOid.BackgroundStyle.Class = "TextBoxBorder"
        Me.mtxtMOid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.mtxtMOid.ButtonCustom.Image = Global.BasicFindReport.My.Resources.Resources.query
        Me.mtxtMOid.ButtonCustom.Visible = True
        Me.mtxtMOid.Location = New System.Drawing.Point(317, 47)
        Me.mtxtMOid.Name = "mtxtMOid"
        Me.mtxtMOid.Size = New System.Drawing.Size(153, 21)
        Me.mtxtMOid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.mtxtMOid.TabIndex = 163
        Me.mtxtMOid.Text = ""
        '
        'CobPart
        '
        '
        '
        '
        Me.CobPart.Border.Class = "TextBoxBorder"
        Me.CobPart.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CobPart.Location = New System.Drawing.Point(86, 46)
        Me.CobPart.Name = "CobPart"
        Me.CobPart.PreventEnterBeep = True
        Me.CobPart.Size = New System.Drawing.Size(153, 21)
        Me.CobPart.TabIndex = 161
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(483, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 12)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "输入物料或选择工单，可以带出相关工站数据"
        '
        'TokenEditor1
        '
        '
        '
        '
        Me.TokenEditor1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.TokenEditor1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TokenEditor1.CheckBoxesVisible = True
        Me.TokenEditor1.DropDownButtonVisible = True
        Me.TokenEditor1.DropDownHeight = 150
        Me.TokenEditor1.DropDownWidth = 200
        Me.TokenEditor1.Location = New System.Drawing.Point(546, 46)
        Me.TokenEditor1.Name = "TokenEditor1"
        Me.TokenEditor1.Separators.Add(";")
        Me.TokenEditor1.Separators.Add(",")
        Me.TokenEditor1.Size = New System.Drawing.Size(200, 22)
        Me.TokenEditor1.TabIndex = 158
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(499, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 157
        Me.Label2.Text = "工站："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "料件编号："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(271, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 153
        Me.Label5.Text = "工单："
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(317, 15)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.Size = New System.Drawing.Size(153, 21)
        Me.DtEnd.TabIndex = 147
        Me.DtEnd.Value = New Date(2007, 5, 22, 0, 0, 0, 0)
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(86, 15)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.Size = New System.Drawing.Size(153, 21)
        Me.DtStar.TabIndex = 146
        Me.DtStar.Value = New Date(2007, 5, 22, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(269, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 12)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "至 "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(21, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "起始时间："
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 503)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(892, 22)
        Me.StatusStrip1.TabIndex = 150
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(92, 17)
        Me.ToolStripStatusLabel1.Text = "请输入查询条件"
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToDeleteRows = False
        Me.DataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX1.ColumnHeadersHeight = 30
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.orderby, Me.PartID, Me.stationid, Me.StationName, Me.Column00, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column20, Me.Column21, Me.Column22, Me.Column23})
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
        Me.DataGridViewX1.RowTemplate.Height = 30
        Me.DataGridViewX1.Size = New System.Drawing.Size(884, 353)
        Me.DataGridViewX1.TabIndex = 151
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Location = New System.Drawing.Point(4, 121)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(884, 379)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SuperTabControl1.TabIndex = 158
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl1.Tag = "1代表0:00~1:00,24代表23:00~24:00"
        Me.SuperTabControl1.Text = "1代表0:00~1:00,24代表23:00~24:00"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.DataGridViewX1)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(884, 353)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "产出24小时汇总-UPH(00代表0:00~1:00,23代表23:00~24:00)"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(884, 379)
        Me.SuperTabControlPanel2.TabIndex = 0
        '
        'orderby
        '
        Me.orderby.DataPropertyName = "序号"
        Me.orderby.HeaderText = "序号"
        Me.orderby.Name = "orderby"
        Me.orderby.ReadOnly = True
        '
        'PartID
        '
        Me.PartID.DataPropertyName = "物料"
        Me.PartID.HeaderText = "物料"
        Me.PartID.Name = "PartID"
        Me.PartID.ReadOnly = True
        '
        'stationid
        '
        Me.stationid.DataPropertyName = "工站编号"
        Me.stationid.HeaderText = "工站编号"
        Me.stationid.Name = "stationid"
        Me.stationid.ReadOnly = True
        '
        'StationName
        '
        Me.StationName.DataPropertyName = "工站名称"
        Me.StationName.FillWeight = 220.0!
        Me.StationName.HeaderText = "工站名称"
        Me.StationName.Name = "StationName"
        Me.StationName.ReadOnly = True
        '
        'Column00
        '
        Me.Column00.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column00.DataPropertyName = "00"
        Me.Column00.FillWeight = 76.4725!
        Me.Column00.HeaderText = "00"
        Me.Column00.Name = "Column00"
        Me.Column00.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.DataPropertyName = "01"
        Me.Column1.FillWeight = 76.4725!
        Me.Column1.HeaderText = "01"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.DataPropertyName = "02"
        Me.Column2.FillWeight = 76.4725!
        Me.Column2.HeaderText = "02"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.DataPropertyName = "03"
        Me.Column3.FillWeight = 76.4725!
        Me.Column3.HeaderText = "03"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.DataPropertyName = "04"
        Me.Column4.FillWeight = 76.4725!
        Me.Column4.HeaderText = "04"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.DataPropertyName = "05"
        Me.Column5.FillWeight = 76.4725!
        Me.Column5.HeaderText = "05"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.DataPropertyName = "06"
        Me.Column6.FillWeight = 76.4725!
        Me.Column6.HeaderText = "06"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column7.DataPropertyName = "07"
        Me.Column7.FillWeight = 76.4725!
        Me.Column7.HeaderText = "07"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column8.DataPropertyName = "08"
        Me.Column8.FillWeight = 76.4725!
        Me.Column8.HeaderText = "08"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column9.DataPropertyName = "09"
        Me.Column9.FillWeight = 76.4725!
        Me.Column9.HeaderText = "09"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column10.DataPropertyName = "10"
        Me.Column10.FillWeight = 76.4725!
        Me.Column10.HeaderText = "10"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column11.DataPropertyName = "11"
        Me.Column11.FillWeight = 76.4725!
        Me.Column11.HeaderText = "11"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column12.DataPropertyName = "12"
        Me.Column12.FillWeight = 76.4725!
        Me.Column12.HeaderText = "12"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column13.DataPropertyName = "13"
        Me.Column13.FillWeight = 76.4725!
        Me.Column13.HeaderText = "13"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column14.DataPropertyName = "14"
        Me.Column14.FillWeight = 76.4725!
        Me.Column14.HeaderText = "14"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column15.DataPropertyName = "15"
        Me.Column15.FillWeight = 76.4725!
        Me.Column15.HeaderText = "15"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column16.DataPropertyName = "16"
        Me.Column16.FillWeight = 76.4725!
        Me.Column16.HeaderText = "16"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column17.DataPropertyName = "17"
        Me.Column17.FillWeight = 76.4725!
        Me.Column17.HeaderText = "17"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column18.DataPropertyName = "18"
        Me.Column18.FillWeight = 76.4725!
        Me.Column18.HeaderText = "18"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        '
        'Column19
        '
        Me.Column19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column19.DataPropertyName = "19"
        Me.Column19.FillWeight = 76.4725!
        Me.Column19.HeaderText = "19"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        '
        'Column20
        '
        Me.Column20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column20.DataPropertyName = "20"
        Me.Column20.FillWeight = 76.4725!
        Me.Column20.HeaderText = "20"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        '
        'Column21
        '
        Me.Column21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column21.DataPropertyName = "21"
        Me.Column21.FillWeight = 76.4725!
        Me.Column21.HeaderText = "21"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        '
        'Column22
        '
        Me.Column22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column22.DataPropertyName = "22"
        Me.Column22.FillWeight = 76.4725!
        Me.Column22.HeaderText = "22"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        '
        'Column23
        '
        Me.Column23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column23.DataPropertyName = "23"
        Me.Column23.FillWeight = 76.4725!
        Me.Column23.HeaderText = "23"
        Me.Column23.Name = "Column23"
        Me.Column23.ReadOnly = True
        '
        'FrmQueryProductionUPH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(892, 525)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmQueryProductionUPH"
        Me.Text = "生产UPH查询"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolReflsh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents TokenEditor1 As DevComponents.DotNetBar.Controls.TokenEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CobPart As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents mtxtMOid As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents orderby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stationid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column00 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents Column21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column23 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
