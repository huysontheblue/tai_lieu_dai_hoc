<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductitem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductitem))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.miniToolStrip = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.combDetailShow = New System.Windows.Forms.ToolStripComboBox()
        Me.btnDetailAppend = New System.Windows.Forms.ToolStripButton()
        Me.btnDetailModify = New System.Windows.Forms.ToolStripButton()
        Me.btnDetailEnabled = New System.Windows.Forms.ToolStripButton()
        Me.btnDetailDisabled = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDetailExport = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.toolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.gvDetail = New System.Windows.Forms.DataGridView()
        Me.RelationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Partid1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SmallID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SmallName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SmallName1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Effective1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSonID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gvData = New System.Windows.Forms.DataGridView()
        Me.Partidv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestitemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestitemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.不良类型 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Effective = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colmID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Partid = New System.Windows.Forms.TextBox()
        Me.bindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.combShow = New System.Windows.Forms.ToolStripComboBox()
        Me.btnAppend = New System.Windows.Forms.ToolStripButton()
        Me.btnModify = New System.Windows.Forms.ToolStripButton()
        Me.btnEnabled = New System.Windows.Forms.ToolStripButton()
        Me.btnDisabled = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.bindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.bindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.bindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.bindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
        CType(Me.miniToolStrip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.bindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator1.SuspendLayout()
        CType(Me.bindingNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator2.SuspendLayout()
        Me.SuspendLayout()
        '
        'contextMenuStrip1
        '
        Me.contextMenuStrip1.Name = "contextMenuStrip1"
        Me.contextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'MenuHistory
        '
        Me.MenuHistory.Name = "MenuHistory"
        Me.MenuHistory.Size = New System.Drawing.Size(143, 22)
        Me.MenuHistory.Text = "History Log"
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AddNewItem = Nothing
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.CountItem = Nothing
        Me.miniToolStrip.DeleteItem = Nothing
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.Location = New System.Drawing.Point(456, 8)
        Me.miniToolStrip.MoveFirstItem = Nothing
        Me.miniToolStrip.MoveLastItem = Nothing
        Me.miniToolStrip.MoveNextItem = Nothing
        Me.miniToolStrip.MovePreviousItem = Nothing
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.PositionItem = Nothing
        Me.miniToolStrip.Size = New System.Drawing.Size(758, 36)
        Me.miniToolStrip.TabIndex = 3
        '
        'combDetailShow
        '
        Me.combDetailShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combDetailShow.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.combDetailShow.Items.AddRange(New Object() {"是否有效", "停用", "有效"})
        Me.combDetailShow.Name = "combDetailShow"
        Me.combDetailShow.Size = New System.Drawing.Size(118, 43)
        '
        'btnDetailAppend
        '
        Me.btnDetailAppend.Image = CType(resources.GetObject("btnDetailAppend.Image"), System.Drawing.Image)
        Me.btnDetailAppend.Name = "btnDetailAppend"
        Me.btnDetailAppend.RightToLeftAutoMirrorImage = True
        Me.btnDetailAppend.Size = New System.Drawing.Size(53, 40)
        Me.btnDetailAppend.Text = "新增"
        Me.btnDetailAppend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDetailModify
        '
        Me.btnDetailModify.Image = CType(resources.GetObject("btnDetailModify.Image"), System.Drawing.Image)
        Me.btnDetailModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetailModify.Name = "btnDetailModify"
        Me.btnDetailModify.Size = New System.Drawing.Size(53, 40)
        Me.btnDetailModify.Text = "修改"
        Me.btnDetailModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDetailEnabled
        '
        Me.btnDetailEnabled.Enabled = False
        Me.btnDetailEnabled.Image = CType(resources.GetObject("btnDetailEnabled.Image"), System.Drawing.Image)
        Me.btnDetailEnabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetailEnabled.Name = "btnDetailEnabled"
        Me.btnDetailEnabled.Size = New System.Drawing.Size(53, 40)
        Me.btnDetailEnabled.Text = "有效"
        Me.btnDetailEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDetailDisabled
        '
        Me.btnDetailDisabled.Image = CType(resources.GetObject("btnDetailDisabled.Image"), System.Drawing.Image)
        Me.btnDetailDisabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetailDisabled.Name = "btnDetailDisabled"
        Me.btnDetailDisabled.Size = New System.Drawing.Size(53, 40)
        Me.btnDetailDisabled.Text = "停用"
        Me.btnDetailDisabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 43)
        '
        'btnDetailExport
        '
        Me.btnDetailExport.Image = CType(resources.GetObject("btnDetailExport.Image"), System.Drawing.Image)
        Me.btnDetailExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetailExport.Name = "btnDetailExport"
        Me.btnDetailExport.Size = New System.Drawing.Size(53, 40)
        Me.btnDetailExport.Text = "导出"
        Me.btnDetailExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'toolStripButton7
        '
        Me.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton7.Image = CType(resources.GetObject("toolStripButton7.Image"), System.Drawing.Image)
        Me.toolStripButton7.Name = "toolStripButton7"
        Me.toolStripButton7.RightToLeftAutoMirrorImage = True
        Me.toolStripButton7.Size = New System.Drawing.Size(23, 40)
        Me.toolStripButton7.Text = "移到最前面"
        Me.toolStripButton7.Visible = False
        '
        'toolStripButton8
        '
        Me.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton8.Image = CType(resources.GetObject("toolStripButton8.Image"), System.Drawing.Image)
        Me.toolStripButton8.Name = "toolStripButton8"
        Me.toolStripButton8.RightToLeftAutoMirrorImage = True
        Me.toolStripButton8.Size = New System.Drawing.Size(23, 40)
        Me.toolStripButton8.Text = "移到上一個"
        Me.toolStripButton8.Visible = False
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 43)
        '
        'toolStripTextBox1
        '
        Me.toolStripTextBox1.AccessibleName = "位置"
        Me.toolStripTextBox1.AutoSize = False
        Me.toolStripTextBox1.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.toolStripTextBox1.Name = "toolStripTextBox1"
        Me.toolStripTextBox1.Size = New System.Drawing.Size(58, 31)
        Me.toolStripTextBox1.Text = "0"
        Me.toolStripTextBox1.ToolTipText = "目前的位置"
        Me.toolStripTextBox1.Visible = False
        '
        'toolStripLabel1
        '
        Me.toolStripLabel1.Name = "toolStripLabel1"
        Me.toolStripLabel1.Size = New System.Drawing.Size(41, 40)
        Me.toolStripLabel1.Text = "/{0}"
        Me.toolStripLabel1.ToolTipText = "項目總數"
        Me.toolStripLabel1.Visible = False
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 43)
        Me.toolStripSeparator3.Visible = False
        '
        'toolStripButton9
        '
        Me.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton9.Image = CType(resources.GetObject("toolStripButton9.Image"), System.Drawing.Image)
        Me.toolStripButton9.Name = "toolStripButton9"
        Me.toolStripButton9.RightToLeftAutoMirrorImage = True
        Me.toolStripButton9.Size = New System.Drawing.Size(23, 40)
        Me.toolStripButton9.Text = "移到下一個"
        Me.toolStripButton9.Visible = False
        '
        'toolStripButton10
        '
        Me.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton10.Image = CType(resources.GetObject("toolStripButton10.Image"), System.Drawing.Image)
        Me.toolStripButton10.Name = "toolStripButton10"
        Me.toolStripButton10.RightToLeftAutoMirrorImage = True
        Me.toolStripButton10.Size = New System.Drawing.Size(23, 40)
        Me.toolStripButton10.Text = "移到最後面"
        Me.toolStripButton10.Visible = False
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel2.Location = New System.Drawing.Point(0, 43)
        Me.panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(1137, 15)
        Me.panel2.TabIndex = 6
        '
        'gvDetail
        '
        Me.gvDetail.AllowUserToAddRows = False
        Me.gvDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gvDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvDetail.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RelationID, Me.Partid1, Me.SmallID, Me.SmallName, Me.SmallName1, Me.Effective1, Me.Usid, Me.TIME, Me.colSonID})
        Me.gvDetail.ContextMenuStrip = Me.contextMenuStrip1
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvDetail.DefaultCellStyle = DataGridViewCellStyle3
        Me.gvDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvDetail.Location = New System.Drawing.Point(0, 58)
        Me.gvDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.gvDetail.MultiSelect = False
        Me.gvDetail.Name = "gvDetail"
        Me.gvDetail.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.gvDetail.RowHeadersWidth = 25
        Me.gvDetail.RowTemplate.Height = 24
        Me.gvDetail.Size = New System.Drawing.Size(1137, 846)
        Me.gvDetail.TabIndex = 4
        Me.gvDetail.VirtualMode = True
        '
        'RelationID
        '
        Me.RelationID.DataPropertyName = "RelationID"
        Me.RelationID.HeaderText = "测试大项代码"
        Me.RelationID.Name = "RelationID"
        Me.RelationID.ReadOnly = True
        '
        'Partid1
        '
        Me.Partid1.DataPropertyName = "Partid"
        Me.Partid1.HeaderText = "料号"
        Me.Partid1.Name = "Partid1"
        Me.Partid1.ReadOnly = True
        '
        'SmallID
        '
        Me.SmallID.DataPropertyName = "SmallID"
        Me.SmallID.HeaderText = "测试小项代码"
        Me.SmallID.Name = "SmallID"
        Me.SmallID.ReadOnly = True
        '
        'SmallName
        '
        Me.SmallName.DataPropertyName = "SmallName"
        Me.SmallName.HeaderText = "测试小项名称"
        Me.SmallName.Name = "SmallName"
        Me.SmallName.ReadOnly = True
        '
        'SmallName1
        '
        Me.SmallName1.DataPropertyName = "Serialnumber"
        Me.SmallName1.HeaderText = "排序"
        Me.SmallName1.Name = "SmallName1"
        Me.SmallName1.ReadOnly = True
        '
        'Effective1
        '
        Me.Effective1.DataPropertyName = "Effective"
        Me.Effective1.HeaderText = "是否有效"
        Me.Effective1.Name = "Effective1"
        Me.Effective1.ReadOnly = True
        '
        'Usid
        '
        Me.Usid.DataPropertyName = "Usid"
        Me.Usid.HeaderText = "维护人"
        Me.Usid.Name = "Usid"
        Me.Usid.ReadOnly = True
        '
        'TIME
        '
        Me.TIME.DataPropertyName = "TIME"
        Me.TIME.HeaderText = "维护时间"
        Me.TIME.Name = "TIME"
        Me.TIME.ReadOnly = True
        '
        'colSonID
        '
        Me.colSonID.DataPropertyName = "ID"
        Me.colSonID.HeaderText = "ID"
        Me.colSonID.Name = "colSonID"
        Me.colSonID.ReadOnly = True
        Me.colSonID.Visible = False
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.gvData)
        Me.splitContainer1.Panel1.Controls.Add(Me.panel1)
        Me.splitContainer1.Panel1.Controls.Add(Me.bindingNavigator1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.gvDetail)
        Me.splitContainer1.Panel2.Controls.Add(Me.panel2)
        Me.splitContainer1.Panel2.Controls.Add(Me.bindingNavigator2)
        Me.splitContainer1.Size = New System.Drawing.Size(1755, 904)
        Me.splitContainer1.SplitterDistance = 612
        Me.splitContainer1.SplitterWidth = 6
        Me.splitContainer1.TabIndex = 8
        '
        'gvData
        '
        Me.gvData.AllowUserToAddRows = False
        Me.gvData.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gvData.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Partidv, Me.TestitemID, Me.TestitemName, Me.不良类型, Me.Effective, Me.Column4, Me.colmID})
        Me.gvData.ContextMenuStrip = Me.contextMenuStrip1
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvData.DefaultCellStyle = DataGridViewCellStyle7
        Me.gvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvData.Location = New System.Drawing.Point(0, 107)
        Me.gvData.Margin = New System.Windows.Forms.Padding(4)
        Me.gvData.MultiSelect = False
        Me.gvData.Name = "gvData"
        Me.gvData.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.gvData.RowHeadersWidth = 25
        Me.gvData.RowTemplate.Height = 24
        Me.gvData.Size = New System.Drawing.Size(612, 797)
        Me.gvData.TabIndex = 1
        Me.gvData.VirtualMode = True
        '
        'Partidv
        '
        Me.Partidv.DataPropertyName = "Partid"
        Me.Partidv.HeaderText = "料号"
        Me.Partidv.Name = "Partidv"
        Me.Partidv.ReadOnly = True
        '
        'TestitemID
        '
        Me.TestitemID.DataPropertyName = "TestitemID"
        Me.TestitemID.HeaderText = "测试大项代码"
        Me.TestitemID.Name = "TestitemID"
        Me.TestitemID.ReadOnly = True
        '
        'TestitemName
        '
        Me.TestitemName.DataPropertyName = "TestitemName"
        Me.TestitemName.HeaderText = "测试大项名称"
        Me.TestitemName.Name = "TestitemName"
        Me.TestitemName.ReadOnly = True
        '
        '不良类型
        '
        Me.不良类型.DataPropertyName = "TypeName"
        Me.不良类型.HeaderText = "不良类型"
        Me.不良类型.Name = "不良类型"
        Me.不良类型.ReadOnly = True
        '
        'Effective
        '
        Me.Effective.DataPropertyName = "Effective"
        Me.Effective.HeaderText = "是否有效"
        Me.Effective.Name = "Effective"
        Me.Effective.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Usid"
        Me.Column4.HeaderText = "维护人"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'colmID
        '
        Me.colmID.DataPropertyName = "ID"
        Me.colmID.HeaderText = "ID"
        Me.colmID.Name = "colmID"
        Me.colmID.ReadOnly = True
        Me.colmID.Visible = False
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label2)
        Me.panel1.Controls.Add(Me.Button1)
        Me.panel1.Controls.Add(Me.Partid)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 43)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(612, 64)
        Me.panel1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 24)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "料号"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(534, 16)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(54, 34)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "....."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Partid
        '
        Me.Partid.Enabled = False
        Me.Partid.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.Partid.Location = New System.Drawing.Point(136, 16)
        Me.Partid.Margin = New System.Windows.Forms.Padding(4)
        Me.Partid.Name = "Partid"
        Me.Partid.Size = New System.Drawing.Size(362, 31)
        Me.Partid.TabIndex = 5
        '
        'bindingNavigator1
        '
        Me.bindingNavigator1.AddNewItem = Nothing
        Me.bindingNavigator1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bindingNavigator1.CountItem = Nothing
        Me.bindingNavigator1.DeleteItem = Nothing
        Me.bindingNavigator1.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.bindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.combShow, Me.btnAppend, Me.btnModify, Me.btnEnabled, Me.btnDisabled, Me.bindingNavigatorSeparator2, Me.btnExport, Me.bindingNavigatorMoveFirstItem, Me.bindingNavigatorMovePreviousItem, Me.bindingNavigatorSeparator, Me.bindingNavigatorPositionItem, Me.bindingNavigatorCountItem, Me.bindingNavigatorSeparator1, Me.bindingNavigatorMoveNextItem, Me.bindingNavigatorMoveLastItem})
        Me.bindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.bindingNavigator1.MoveFirstItem = Me.bindingNavigatorMoveFirstItem
        Me.bindingNavigator1.MoveLastItem = Me.bindingNavigatorMoveLastItem
        Me.bindingNavigator1.MoveNextItem = Me.bindingNavigatorMoveNextItem
        Me.bindingNavigator1.MovePreviousItem = Me.bindingNavigatorMovePreviousItem
        Me.bindingNavigator1.Name = "bindingNavigator1"
        Me.bindingNavigator1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.bindingNavigator1.PositionItem = Nothing
        Me.bindingNavigator1.Size = New System.Drawing.Size(612, 43)
        Me.bindingNavigator1.TabIndex = 2
        Me.bindingNavigator1.Text = "bindingNavigator1"
        '
        'combShow
        '
        Me.combShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combShow.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.combShow.Items.AddRange(New Object() {"是否有效", "停用", "有效"})
        Me.combShow.Name = "combShow"
        Me.combShow.Size = New System.Drawing.Size(118, 43)
        '
        'btnAppend
        '
        Me.btnAppend.Image = CType(resources.GetObject("btnAppend.Image"), System.Drawing.Image)
        Me.btnAppend.Name = "btnAppend"
        Me.btnAppend.RightToLeftAutoMirrorImage = True
        Me.btnAppend.Size = New System.Drawing.Size(53, 40)
        Me.btnAppend.Text = "新增"
        Me.btnAppend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnModify
        '
        Me.btnModify.Image = CType(resources.GetObject("btnModify.Image"), System.Drawing.Image)
        Me.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(53, 40)
        Me.btnModify.Text = "修改"
        Me.btnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEnabled
        '
        Me.btnEnabled.Enabled = False
        Me.btnEnabled.Image = CType(resources.GetObject("btnEnabled.Image"), System.Drawing.Image)
        Me.btnEnabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnabled.Name = "btnEnabled"
        Me.btnEnabled.Size = New System.Drawing.Size(53, 40)
        Me.btnEnabled.Text = "有效"
        Me.btnEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDisabled
        '
        Me.btnDisabled.Image = CType(resources.GetObject("btnDisabled.Image"), System.Drawing.Image)
        Me.btnDisabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDisabled.Name = "btnDisabled"
        Me.btnDisabled.Size = New System.Drawing.Size(53, 40)
        Me.btnDisabled.Text = "停用"
        Me.btnDisabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'bindingNavigatorSeparator2
        '
        Me.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2"
        Me.bindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 43)
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(53, 40)
        Me.btnExport.Text = "导出"
        Me.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'bindingNavigatorMoveFirstItem
        '
        Me.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem"
        Me.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 40)
        Me.bindingNavigatorMoveFirstItem.Text = "移到最前面"
        Me.bindingNavigatorMoveFirstItem.Visible = False
        '
        'bindingNavigatorMovePreviousItem
        '
        Me.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem"
        Me.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 40)
        Me.bindingNavigatorMovePreviousItem.Text = "移到上一個"
        Me.bindingNavigatorMovePreviousItem.Visible = False
        '
        'bindingNavigatorSeparator
        '
        Me.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator"
        Me.bindingNavigatorSeparator.Size = New System.Drawing.Size(6, 43)
        '
        'bindingNavigatorPositionItem
        '
        Me.bindingNavigatorPositionItem.AccessibleName = "位置"
        Me.bindingNavigatorPositionItem.AutoSize = False
        Me.bindingNavigatorPositionItem.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem"
        Me.bindingNavigatorPositionItem.Size = New System.Drawing.Size(40, 23)
        Me.bindingNavigatorPositionItem.Text = "0"
        Me.bindingNavigatorPositionItem.ToolTipText = "目前的位置"
        Me.bindingNavigatorPositionItem.Visible = False
        '
        'bindingNavigatorCountItem
        '
        Me.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem"
        Me.bindingNavigatorCountItem.Size = New System.Drawing.Size(41, 40)
        Me.bindingNavigatorCountItem.Text = "/{0}"
        Me.bindingNavigatorCountItem.ToolTipText = "項目總數"
        Me.bindingNavigatorCountItem.Visible = False
        '
        'bindingNavigatorSeparator1
        '
        Me.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1"
        Me.bindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 43)
        Me.bindingNavigatorSeparator1.Visible = False
        '
        'bindingNavigatorMoveNextItem
        '
        Me.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveNextItem.Image = CType(resources.GetObject("bindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem"
        Me.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 40)
        Me.bindingNavigatorMoveNextItem.Text = "移到下一個"
        Me.bindingNavigatorMoveNextItem.Visible = False
        '
        'bindingNavigatorMoveLastItem
        '
        Me.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveLastItem.Image = CType(resources.GetObject("bindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem"
        Me.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 40)
        Me.bindingNavigatorMoveLastItem.Text = "移到最後面"
        Me.bindingNavigatorMoveLastItem.Visible = False
        '
        'bindingNavigator2
        '
        Me.bindingNavigator2.AddNewItem = Nothing
        Me.bindingNavigator2.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.bindingNavigator2.CountItem = Nothing
        Me.bindingNavigator2.DeleteItem = Nothing
        Me.bindingNavigator2.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.bindingNavigator2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.combDetailShow, Me.btnDetailAppend, Me.btnDetailModify, Me.btnDetailEnabled, Me.btnDetailDisabled, Me.toolStripSeparator1, Me.btnDetailExport, Me.toolStripButton7, Me.toolStripButton8, Me.toolStripSeparator2, Me.toolStripTextBox1, Me.toolStripLabel1, Me.toolStripSeparator3, Me.toolStripButton9, Me.toolStripButton10})
        Me.bindingNavigator2.Location = New System.Drawing.Point(0, 0)
        Me.bindingNavigator2.MoveFirstItem = Me.toolStripButton7
        Me.bindingNavigator2.MoveLastItem = Me.toolStripButton10
        Me.bindingNavigator2.MoveNextItem = Me.toolStripButton9
        Me.bindingNavigator2.MovePreviousItem = Me.toolStripButton8
        Me.bindingNavigator2.Name = "bindingNavigator2"
        Me.bindingNavigator2.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.bindingNavigator2.PositionItem = Nothing
        Me.bindingNavigator2.Size = New System.Drawing.Size(1137, 43)
        Me.bindingNavigator2.TabIndex = 3
        Me.bindingNavigator2.Text = "bindingNavigator2"
        '
        'FormProductitem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1755, 904)
        Me.Controls.Add(Me.splitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormProductitem"
        Me.Text = "产品测试项目"
        CType(Me.miniToolStrip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.Panel2.PerformLayout()
        Me.splitContainer1.ResumeLayout(False)
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.bindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator1.ResumeLayout(False)
        Me.bindingNavigator1.PerformLayout()
        CType(Me.bindingNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator2.ResumeLayout(False)
        Me.bindingNavigator2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents MenuHistory As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents miniToolStrip As System.Windows.Forms.BindingNavigator
    Private WithEvents combDetailShow As System.Windows.Forms.ToolStripComboBox
    Private WithEvents btnDetailAppend As System.Windows.Forms.ToolStripButton
    Private WithEvents btnDetailModify As System.Windows.Forms.ToolStripButton
    Private WithEvents btnDetailEnabled As System.Windows.Forms.ToolStripButton
    Private WithEvents btnDetailDisabled As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnDetailExport As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripButton7 As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripButton8 As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Private WithEvents toolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripButton9 As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripButton10 As System.Windows.Forms.ToolStripButton
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents gvDetail As System.Windows.Forms.DataGridView
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents gvData As System.Windows.Forms.DataGridView
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents bindingNavigator1 As System.Windows.Forms.BindingNavigator
    Private WithEvents combShow As System.Windows.Forms.ToolStripComboBox
    Private WithEvents btnAppend As System.Windows.Forms.ToolStripButton
    Private WithEvents btnModify As System.Windows.Forms.ToolStripButton
    Private WithEvents btnEnabled As System.Windows.Forms.ToolStripButton
    Private WithEvents btnDisabled As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Private WithEvents bindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Private WithEvents bindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Private WithEvents bindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents bindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Private WithEvents bindingNavigator2 As System.Windows.Forms.BindingNavigator
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents Partid As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Partidv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestitemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestitemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 不良类型 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Effective As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colmID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RelationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Partid1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SmallID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SmallName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SmallName1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Effective1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSonID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
