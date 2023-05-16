<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBomQuery
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtPartNo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnQuery = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.lbsapMessage = New DevComponents.DotNetBar.LabelX()
        Me.txtAVpartID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.btnQueryPlm = New DevComponents.DotNetBar.ButtonX()
        Me.ComboBoxEx1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.dgvSAPList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DOKAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOKNR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DKTXT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOKVR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FILE_URL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FILE_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FILEDESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FILE_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAPURLQuery = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.dgvECNList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.classification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.names = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sop_ver = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sop_gen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.create_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.modified_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.states = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modified_on = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.state = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClassification = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.part_create_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.trBomList = New DevComponents.AdvTree.AdvTree()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgvSAPList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.dgvECNList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trBomList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(17, 11)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(50, 23)
        Me.LabelX1.TabIndex = 143
        Me.LabelX1.Text = "料号："
        '
        'txtPartNo
        '
        '
        '
        '
        Me.txtPartNo.Border.Class = "TextBoxBorder"
        Me.txtPartNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPartNo.Location = New System.Drawing.Point(73, 11)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(156, 21)
        Me.txtPartNo.TabIndex = 144
        '
        'btnQuery
        '
        Me.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuery.Location = New System.Drawing.Point(253, 8)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(69, 25)
        Me.btnQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.btnQuery.TabIndex = 145
        Me.btnQuery.Text = "查 询"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.ExpandableSplitter1)
        Me.Panel1.Controls.Add(Me.trBomList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1021, 450)
        Me.Panel1.TabIndex = 146
        '
        'TabControl1
        '
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(229, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(792, 450)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.TabControl1.TabIndex = 3
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.SplitContainer2)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 25)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(792, 425)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 5
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(1, 1)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lbsapMessage)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtAVpartID)
        Me.SplitContainer2.Panel1.Controls.Add(Me.LabelX3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnQueryPlm)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ComboBoxEx1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.LabelX2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvSAPList)
        Me.SplitContainer2.Size = New System.Drawing.Size(790, 423)
        Me.SplitContainer2.SplitterDistance = 40
        Me.SplitContainer2.SplitterWidth = 2
        Me.SplitContainer2.TabIndex = 7
        '
        'lbsapMessage
        '
        '
        '
        '
        Me.lbsapMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbsapMessage.Location = New System.Drawing.Point(515, 8)
        Me.lbsapMessage.Name = "lbsapMessage"
        Me.lbsapMessage.Size = New System.Drawing.Size(198, 25)
        Me.lbsapMessage.TabIndex = 148
        '
        'txtAVpartID
        '
        '
        '
        '
        Me.txtAVpartID.Border.Class = "TextBoxBorder"
        Me.txtAVpartID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAVpartID.Location = New System.Drawing.Point(55, 9)
        Me.txtAVpartID.Name = "txtAVpartID"
        Me.txtAVpartID.PreventEnterBeep = True
        Me.txtAVpartID.Size = New System.Drawing.Size(130, 21)
        Me.txtAVpartID.TabIndex = 4
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(5, 9)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(43, 23)
        Me.LabelX3.TabIndex = 3
        Me.LabelX3.Text = "料号："
        '
        'btnQueryPlm
        '
        Me.btnQueryPlm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQueryPlm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQueryPlm.Location = New System.Drawing.Point(418, 8)
        Me.btnQueryPlm.Name = "btnQueryPlm"
        Me.btnQueryPlm.Size = New System.Drawing.Size(75, 23)
        Me.btnQueryPlm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQueryPlm.TabIndex = 2
        Me.btnQueryPlm.Text = "查询"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "Text"
        Me.ComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.ItemHeight = 15
        Me.ComboBoxEx1.Location = New System.Drawing.Point(272, 9)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(130, 21)
        Me.ComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxEx1.TabIndex = 0
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(191, 9)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "图纸类型："
        '
        'dgvSAPList
        '
        Me.dgvSAPList.AllowUserToAddRows = False
        Me.dgvSAPList.AllowUserToDeleteRows = False
        Me.dgvSAPList.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSAPList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvSAPList.ColumnHeadersHeight = 28
        Me.dgvSAPList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSAPList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DOKAR, Me.DOKNR, Me.DKTXT, Me.DOKVR, Me.FILE_URL, Me.FILE_NAME, Me.FILEDESC, Me.FILE_ID, Me.SAPURLQuery})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSAPList.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvSAPList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSAPList.EnableHeadersVisualStyles = False
        Me.dgvSAPList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvSAPList.Location = New System.Drawing.Point(0, 0)
        Me.dgvSAPList.Name = "dgvSAPList"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSAPList.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvSAPList.RowHeadersWidth = 25
        Me.dgvSAPList.RowTemplate.Height = 25
        Me.dgvSAPList.Size = New System.Drawing.Size(790, 381)
        Me.dgvSAPList.TabIndex = 6
        '
        'DOKAR
        '
        Me.DOKAR.DataPropertyName = "DOKAR"
        Me.DOKAR.HeaderText = "类别"
        Me.DOKAR.Name = "DOKAR"
        Me.DOKAR.ReadOnly = True
        Me.DOKAR.Width = 150
        '
        'DOKNR
        '
        Me.DOKNR.DataPropertyName = "DOKNR"
        Me.DOKNR.HeaderText = "文件号"
        Me.DOKNR.Name = "DOKNR"
        Me.DOKNR.ReadOnly = True
        Me.DOKNR.Width = 150
        '
        'DKTXT
        '
        Me.DKTXT.DataPropertyName = "DKTXT"
        Me.DKTXT.FillWeight = 250.0!
        Me.DKTXT.HeaderText = "文件名称"
        Me.DKTXT.Name = "DKTXT"
        Me.DKTXT.ReadOnly = True
        Me.DKTXT.Width = 150
        '
        'DOKVR
        '
        Me.DOKVR.DataPropertyName = "DOKVR"
        Me.DOKVR.HeaderText = "版本"
        Me.DOKVR.Name = "DOKVR"
        Me.DOKVR.ReadOnly = True
        Me.DOKVR.Width = 60
        '
        'FILE_URL
        '
        Me.FILE_URL.DataPropertyName = "FILE_URL"
        Me.FILE_URL.HeaderText = "FILE_URL"
        Me.FILE_URL.Name = "FILE_URL"
        Me.FILE_URL.Visible = False
        '
        'FILE_NAME
        '
        Me.FILE_NAME.DataPropertyName = "FILE_NAME"
        Me.FILE_NAME.HeaderText = "文件名"
        Me.FILE_NAME.Name = "FILE_NAME"
        '
        'FILEDESC
        '
        Me.FILEDESC.DataPropertyName = "FILEDESC"
        Me.FILEDESC.HeaderText = "描述"
        Me.FILEDESC.Name = "FILEDESC"
        '
        'FILE_ID
        '
        Me.FILE_ID.DataPropertyName = "FILE_ID"
        Me.FILE_ID.HeaderText = "文件ID"
        Me.FILE_ID.Name = "FILE_ID"
        '
        'SAPURLQuery
        '
        Me.SAPURLQuery.HeaderText = "查看"
        Me.SAPURLQuery.Name = "SAPURLQuery"
        Me.SAPURLQuery.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.SAPURLQuery.Text = "文件预览"
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "SAP资料"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.dgvECNList)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(792, 425)
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
        'dgvECNList
        '
        Me.dgvECNList.AllowUserToAddRows = False
        Me.dgvECNList.AllowUserToDeleteRows = False
        Me.dgvECNList.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvECNList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvECNList.ColumnHeadersHeight = 28
        Me.dgvECNList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvECNList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.classification, Me.item_number, Me.names, Me.sop_ver, Me.sop_gen, Me.create_name, Me.modified_name, Me.states, Me.Modified_on, Me.state, Me.btnClassification, Me.part_create_name})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvECNList.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvECNList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvECNList.EnableHeadersVisualStyles = False
        Me.dgvECNList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvECNList.Location = New System.Drawing.Point(1, 1)
        Me.dgvECNList.Name = "dgvECNList"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvECNList.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvECNList.RowHeadersWidth = 25
        Me.dgvECNList.RowTemplate.Height = 25
        Me.dgvECNList.Size = New System.Drawing.Size(790, 423)
        Me.dgvECNList.TabIndex = 2
        '
        'classification
        '
        Me.classification.DataPropertyName = "classification"
        Me.classification.HeaderText = "类别"
        Me.classification.Name = "classification"
        Me.classification.ReadOnly = True
        Me.classification.Width = 150
        '
        'item_number
        '
        Me.item_number.DataPropertyName = "item_number"
        Me.item_number.HeaderText = "文件号"
        Me.item_number.Name = "item_number"
        Me.item_number.ReadOnly = True
        Me.item_number.Width = 150
        '
        'names
        '
        Me.names.DataPropertyName = "name"
        Me.names.FillWeight = 250.0!
        Me.names.HeaderText = "文件名称"
        Me.names.Name = "names"
        Me.names.ReadOnly = True
        Me.names.Width = 150
        '
        'sop_ver
        '
        Me.sop_ver.DataPropertyName = "sop_ver"
        Me.sop_ver.HeaderText = "版本"
        Me.sop_ver.Name = "sop_ver"
        Me.sop_ver.ReadOnly = True
        Me.sop_ver.Width = 60
        '
        'sop_gen
        '
        Me.sop_gen.DataPropertyName = "sop_gen"
        Me.sop_gen.HeaderText = "版次"
        Me.sop_gen.Name = "sop_gen"
        Me.sop_gen.ReadOnly = True
        Me.sop_gen.Width = 60
        '
        'create_name
        '
        Me.create_name.DataPropertyName = "create_name"
        Me.create_name.HeaderText = "创建人"
        Me.create_name.Name = "create_name"
        '
        'modified_name
        '
        Me.modified_name.DataPropertyName = "modified_name"
        Me.modified_name.HeaderText = "修改人"
        Me.modified_name.Name = "modified_name"
        '
        'states
        '
        Me.states.HeaderText = "ECN码"
        Me.states.Name = "states"
        Me.states.ReadOnly = True
        '
        'Modified_on
        '
        Me.Modified_on.DataPropertyName = "release_date"
        Me.Modified_on.HeaderText = "发行日期"
        Me.Modified_on.Name = "Modified_on"
        Me.Modified_on.ReadOnly = True
        Me.Modified_on.Width = 200
        '
        'state
        '
        Me.state.DataPropertyName = "state"
        Me.state.HeaderText = "状态"
        Me.state.Name = "state"
        Me.state.ReadOnly = True
        '
        'btnClassification
        '
        Me.btnClassification.HeaderText = ""
        Me.btnClassification.Name = "btnClassification"
        Me.btnClassification.Text = "文件预览"
        '
        'part_create_name
        '
        Me.part_create_name.DataPropertyName = "part_create_name"
        Me.part_create_name.HeaderText = "料号创建人"
        Me.part_create_name.Name = "part_create_name"
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "MES资料"
        '
        'ExpandableSplitter1
        '
        Me.ExpandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter1.ExpandableControl = Me.trBomList
        Me.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(223, 0)
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(6, 450)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter1.TabIndex = 1
        Me.ExpandableSplitter1.TabStop = False
        '
        'trBomList
        '
        Me.trBomList.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.trBomList.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.trBomList.BackgroundStyle.Class = "TreeBorderKey"
        Me.trBomList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.trBomList.Dock = System.Windows.Forms.DockStyle.Left
        Me.trBomList.Location = New System.Drawing.Point(0, 0)
        Me.trBomList.Name = "trBomList"
        Me.trBomList.NodesConnector = Me.NodeConnector1
        Me.trBomList.NodeStyle = Me.ElementStyle1
        Me.trBomList.PathSeparator = ";"
        Me.trBomList.Size = New System.Drawing.Size(223, 450)
        Me.trBomList.Styles.Add(Me.ElementStyle1)
        Me.trBomList.TabIndex = 0
        Me.trBomList.Text = "AdvTree1"
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
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Location = New System.Drawing.Point(337, 8)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(570, 25)
        Me.lblMessage.TabIndex = 147
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnQuery)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPartNo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1021, 494)
        Me.SplitContainer1.SplitterDistance = 40
        Me.SplitContainer1.TabIndex = 148
        '
        'FrmBomQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 494)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmBomQuery"
        Me.ShowIcon = False
        Me.Text = "图纸查询"
        Me.Panel1.ResumeLayout(False)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgvSAPList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel1.ResumeLayout(False)
        CType(Me.dgvECNList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trBomList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPartNo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnQuery As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvECNList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents trBomList As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents classification As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item_number As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents names As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sop_ver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sop_gen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents create_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents modified_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents states As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modified_on As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents state As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnClassification As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents part_create_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboBoxEx1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents dgvSAPList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnQueryPlm As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtAVpartID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DOKAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOKNR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DKTXT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOKVR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FILE_URL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FILE_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FILEDESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FILE_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SAPURLQuery As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents lbsapMessage As DevComponents.DotNetBar.LabelX
End Class
