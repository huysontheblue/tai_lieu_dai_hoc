<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCSamplingPlan
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCSamplingPlan))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gvData = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.LabFilter = New System.Windows.Forms.Label()
        Me.editFilter = New System.Windows.Forms.TextBox()
        Me.combFilter = New System.Windows.Forms.ComboBox()
        Me.bindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.combShow = New System.Windows.Forms.ToolStripComboBox()
        Me.btnAppend = New System.Windows.Forms.ToolStripButton()
        Me.btnModify = New System.Windows.Forms.ToolStripButton()
        Me.btnEnabled = New System.Windows.Forms.ToolStripButton()
        Me.btnDisabled = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
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
        Me.gvDetail = New System.Windows.Forms.DataGridView()
        Me.bindingNavigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.btnDetailAppend = New System.Windows.Forms.ToolStripButton()
        Me.btnDetailModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.btnDetailDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
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
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.bindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator1.SuspendLayout()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gvData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.bindingNavigator1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gvDetail)
        Me.SplitContainer1.Panel2.Controls.Add(Me.bindingNavigator2)
        Me.SplitContainer1.Size = New System.Drawing.Size(637, 425)
        Me.SplitContainer1.SplitterDistance = 212
        Me.SplitContainer1.TabIndex = 8
        '
        'gvData
        '
        Me.gvData.AllowUserToAddRows = False
        Me.gvData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.gvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvData.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvData.DefaultCellStyle = DataGridViewCellStyle3
        Me.gvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvData.Location = New System.Drawing.Point(0, 72)
        Me.gvData.MultiSelect = False
        Me.gvData.Name = "gvData"
        Me.gvData.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.gvData.RowHeadersWidth = 25
        Me.gvData.RowTemplate.Height = 24
        Me.gvData.Size = New System.Drawing.Size(637, 140)
        Me.gvData.TabIndex = 9
        Me.gvData.VirtualMode = True
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "SamplingId"
        Me.Column1.HeaderText = "SamplingId"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.White
        Me.panel1.Controls.Add(Me.LabFilter)
        Me.panel1.Controls.Add(Me.editFilter)
        Me.panel1.Controls.Add(Me.combFilter)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 36)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(637, 36)
        Me.panel1.TabIndex = 8
        '
        'LabFilter
        '
        Me.LabFilter.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.LabFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabFilter.Location = New System.Drawing.Point(3, 10)
        Me.LabFilter.Name = "LabFilter"
        Me.LabFilter.Size = New System.Drawing.Size(87, 18)
        Me.LabFilter.TabIndex = 3
        Me.LabFilter.Text = "查询条件："
        '
        'editFilter
        '
        Me.editFilter.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.editFilter.Location = New System.Drawing.Point(232, 6)
        Me.editFilter.Name = "editFilter"
        Me.editFilter.Size = New System.Drawing.Size(148, 23)
        Me.editFilter.TabIndex = 1
        '
        'combFilter
        '
        Me.combFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combFilter.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.combFilter.FormattingEnabled = True
        Me.combFilter.Items.AddRange(New Object() {"抽验计划", "抽验计划描述", "主缺判退标准", "次缺判退标准", "重缺判退标准"})
        Me.combFilter.Location = New System.Drawing.Point(105, 7)
        Me.combFilter.Name = "combFilter"
        Me.combFilter.Size = New System.Drawing.Size(121, 21)
        Me.combFilter.TabIndex = 0
        '
        'bindingNavigator1
        '
        Me.bindingNavigator1.AddNewItem = Nothing
        Me.bindingNavigator1.CountItem = Nothing
        Me.bindingNavigator1.DeleteItem = Nothing
        Me.bindingNavigator1.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.bindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.combShow, Me.btnAppend, Me.btnModify, Me.btnEnabled, Me.btnDisabled, Me.btnDelete, Me.bindingNavigatorSeparator2, Me.btnExport, Me.bindingNavigatorMoveFirstItem, Me.bindingNavigatorMovePreviousItem, Me.bindingNavigatorSeparator, Me.bindingNavigatorPositionItem, Me.bindingNavigatorCountItem, Me.bindingNavigatorSeparator1, Me.bindingNavigatorMoveNextItem, Me.bindingNavigatorMoveLastItem})
        Me.bindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.bindingNavigator1.MoveFirstItem = Me.bindingNavigatorMoveFirstItem
        Me.bindingNavigator1.MoveLastItem = Me.bindingNavigatorMoveLastItem
        Me.bindingNavigator1.MoveNextItem = Me.bindingNavigatorMoveNextItem
        Me.bindingNavigator1.MovePreviousItem = Me.bindingNavigatorMovePreviousItem
        Me.bindingNavigator1.Name = "bindingNavigator1"
        Me.bindingNavigator1.PositionItem = Nothing
        Me.bindingNavigator1.Size = New System.Drawing.Size(637, 36)
        Me.bindingNavigator1.TabIndex = 7
        Me.bindingNavigator1.Text = "bindingNavigator1"
        '
        'combShow
        '
        Me.combShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combShow.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.combShow.Items.AddRange(New Object() {"是否有效", "停用", "全部"})
        Me.combShow.Name = "combShow"
        Me.combShow.Size = New System.Drawing.Size(80, 36)
        '
        'btnAppend
        '
        Me.btnAppend.Image = CType(resources.GetObject("btnAppend.Image"), System.Drawing.Image)
        Me.btnAppend.Name = "btnAppend"
        Me.btnAppend.RightToLeftAutoMirrorImage = True
        Me.btnAppend.Size = New System.Drawing.Size(37, 33)
        Me.btnAppend.Text = "新增"
        Me.btnAppend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnModify
        '
        Me.btnModify.Image = CType(resources.GetObject("btnModify.Image"), System.Drawing.Image)
        Me.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(37, 33)
        Me.btnModify.Text = "修改"
        Me.btnModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEnabled
        '
        Me.btnEnabled.Image = CType(resources.GetObject("btnEnabled.Image"), System.Drawing.Image)
        Me.btnEnabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnabled.Name = "btnEnabled"
        Me.btnEnabled.Size = New System.Drawing.Size(63, 33)
        Me.btnEnabled.Text = "是否有效"
        Me.btnEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEnabled.Visible = False
        '
        'btnDisabled
        '
        Me.btnDisabled.Image = CType(resources.GetObject("btnDisabled.Image"), System.Drawing.Image)
        Me.btnDisabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDisabled.Name = "btnDisabled"
        Me.btnDisabled.Size = New System.Drawing.Size(37, 33)
        Me.btnDisabled.Text = "停用"
        Me.btnDisabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeftAutoMirrorImage = True
        Me.btnDelete.Size = New System.Drawing.Size(37, 33)
        Me.btnDelete.Text = "删除"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDelete.Visible = False
        '
        'bindingNavigatorSeparator2
        '
        Me.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2"
        Me.bindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 36)
        Me.bindingNavigatorSeparator2.Visible = False
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(43, 33)
        Me.btnExport.Text = "Export"
        Me.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExport.Visible = False
        '
        'bindingNavigatorMoveFirstItem
        '
        Me.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem"
        Me.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 33)
        Me.bindingNavigatorMoveFirstItem.Text = "移到最前面"
        Me.bindingNavigatorMoveFirstItem.Visible = False
        '
        'bindingNavigatorMovePreviousItem
        '
        Me.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem"
        Me.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 33)
        Me.bindingNavigatorMovePreviousItem.Text = "移到上一個"
        Me.bindingNavigatorMovePreviousItem.Visible = False
        '
        'bindingNavigatorSeparator
        '
        Me.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator"
        Me.bindingNavigatorSeparator.Size = New System.Drawing.Size(6, 36)
        Me.bindingNavigatorSeparator.Visible = False
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
        Me.bindingNavigatorCountItem.Size = New System.Drawing.Size(28, 33)
        Me.bindingNavigatorCountItem.Text = "/{0}"
        Me.bindingNavigatorCountItem.ToolTipText = "項目總數"
        Me.bindingNavigatorCountItem.Visible = False
        '
        'bindingNavigatorSeparator1
        '
        Me.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1"
        Me.bindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 36)
        Me.bindingNavigatorSeparator1.Visible = False
        '
        'bindingNavigatorMoveNextItem
        '
        Me.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveNextItem.Image = CType(resources.GetObject("bindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem"
        Me.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 33)
        Me.bindingNavigatorMoveNextItem.Text = "移到下一個"
        Me.bindingNavigatorMoveNextItem.Visible = False
        '
        'bindingNavigatorMoveLastItem
        '
        Me.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingNavigatorMoveLastItem.Image = CType(resources.GetObject("bindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem"
        Me.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.bindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 33)
        Me.bindingNavigatorMoveLastItem.Text = "移到最後面"
        Me.bindingNavigatorMoveLastItem.Visible = False
        '
        'gvDetail
        '
        Me.gvDetail.AllowUserToAddRows = False
        Me.gvDetail.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        Me.gvDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gvDetail.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gvDetail.DefaultCellStyle = DataGridViewCellStyle7
        Me.gvDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvDetail.Location = New System.Drawing.Point(0, 36)
        Me.gvDetail.MultiSelect = False
        Me.gvDetail.Name = "gvDetail"
        Me.gvDetail.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.gvDetail.RowHeadersWidth = 25
        Me.gvDetail.RowTemplate.Height = 24
        Me.gvDetail.Size = New System.Drawing.Size(637, 173)
        Me.gvDetail.TabIndex = 8
        Me.gvDetail.VirtualMode = True
        '
        'bindingNavigator2
        '
        Me.bindingNavigator2.AddNewItem = Nothing
        Me.bindingNavigator2.CountItem = Nothing
        Me.bindingNavigator2.DeleteItem = Nothing
        Me.bindingNavigator2.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.bindingNavigator2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDetailAppend, Me.btnDetailModify, Me.ToolStripButton1, Me.btnDetailDelete, Me.ToolStripButton2, Me.toolStripSeparator1, Me.btnDetailExport, Me.toolStripButton7, Me.toolStripButton8, Me.toolStripSeparator2, Me.toolStripTextBox1, Me.toolStripLabel1, Me.toolStripSeparator3, Me.toolStripButton9, Me.toolStripButton10})
        Me.bindingNavigator2.Location = New System.Drawing.Point(0, 0)
        Me.bindingNavigator2.MoveFirstItem = Me.toolStripButton7
        Me.bindingNavigator2.MoveLastItem = Me.toolStripButton10
        Me.bindingNavigator2.MoveNextItem = Me.toolStripButton9
        Me.bindingNavigator2.MovePreviousItem = Me.toolStripButton8
        Me.bindingNavigator2.Name = "bindingNavigator2"
        Me.bindingNavigator2.PositionItem = Nothing
        Me.bindingNavigator2.Size = New System.Drawing.Size(637, 36)
        Me.bindingNavigator2.TabIndex = 4
        Me.bindingNavigator2.Text = "bindingNavigator2"
        '
        'btnDetailAppend
        '
        Me.btnDetailAppend.Image = CType(resources.GetObject("btnDetailAppend.Image"), System.Drawing.Image)
        Me.btnDetailAppend.Name = "btnDetailAppend"
        Me.btnDetailAppend.RightToLeftAutoMirrorImage = True
        Me.btnDetailAppend.Size = New System.Drawing.Size(37, 33)
        Me.btnDetailAppend.Text = "新增"
        Me.btnDetailAppend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDetailModify
        '
        Me.btnDetailModify.Image = CType(resources.GetObject("btnDetailModify.Image"), System.Drawing.Image)
        Me.btnDetailModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetailModify.Name = "btnDetailModify"
        Me.btnDetailModify.Size = New System.Drawing.Size(37, 33)
        Me.btnDetailModify.Text = "修改"
        Me.btnDetailModify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Enabled = False
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(37, 33)
        Me.ToolStripButton1.Text = "停用"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDetailDelete
        '
        Me.btnDetailDelete.Enabled = False
        Me.btnDetailDelete.Image = CType(resources.GetObject("btnDetailDelete.Image"), System.Drawing.Image)
        Me.btnDetailDelete.Name = "btnDetailDelete"
        Me.btnDetailDelete.RightToLeftAutoMirrorImage = True
        Me.btnDetailDelete.Size = New System.Drawing.Size(37, 33)
        Me.btnDetailDelete.Text = "删除"
        Me.btnDetailDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(63, 33)
        Me.ToolStripButton2.Text = "是否有效"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 36)
        Me.toolStripSeparator1.Visible = False
        '
        'btnDetailExport
        '
        Me.btnDetailExport.Image = CType(resources.GetObject("btnDetailExport.Image"), System.Drawing.Image)
        Me.btnDetailExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetailExport.Name = "btnDetailExport"
        Me.btnDetailExport.Size = New System.Drawing.Size(43, 33)
        Me.btnDetailExport.Text = "Export"
        Me.btnDetailExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDetailExport.Visible = False
        '
        'toolStripButton7
        '
        Me.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton7.Image = CType(resources.GetObject("toolStripButton7.Image"), System.Drawing.Image)
        Me.toolStripButton7.Name = "toolStripButton7"
        Me.toolStripButton7.RightToLeftAutoMirrorImage = True
        Me.toolStripButton7.Size = New System.Drawing.Size(23, 33)
        Me.toolStripButton7.Text = "移到最前面"
        Me.toolStripButton7.Visible = False
        '
        'toolStripButton8
        '
        Me.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton8.Image = CType(resources.GetObject("toolStripButton8.Image"), System.Drawing.Image)
        Me.toolStripButton8.Name = "toolStripButton8"
        Me.toolStripButton8.RightToLeftAutoMirrorImage = True
        Me.toolStripButton8.Size = New System.Drawing.Size(23, 33)
        Me.toolStripButton8.Text = "移到上一個"
        Me.toolStripButton8.Visible = False
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 36)
        Me.toolStripSeparator2.Visible = False
        '
        'toolStripTextBox1
        '
        Me.toolStripTextBox1.AccessibleName = "位置"
        Me.toolStripTextBox1.AutoSize = False
        Me.toolStripTextBox1.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.toolStripTextBox1.Name = "toolStripTextBox1"
        Me.toolStripTextBox1.Size = New System.Drawing.Size(40, 23)
        Me.toolStripTextBox1.Text = "0"
        Me.toolStripTextBox1.ToolTipText = "目前的位置"
        Me.toolStripTextBox1.Visible = False
        '
        'toolStripLabel1
        '
        Me.toolStripLabel1.Name = "toolStripLabel1"
        Me.toolStripLabel1.Size = New System.Drawing.Size(28, 33)
        Me.toolStripLabel1.Text = "/{0}"
        Me.toolStripLabel1.ToolTipText = "項目總數"
        Me.toolStripLabel1.Visible = False
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 36)
        Me.toolStripSeparator3.Visible = False
        '
        'toolStripButton9
        '
        Me.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton9.Image = CType(resources.GetObject("toolStripButton9.Image"), System.Drawing.Image)
        Me.toolStripButton9.Name = "toolStripButton9"
        Me.toolStripButton9.RightToLeftAutoMirrorImage = True
        Me.toolStripButton9.Size = New System.Drawing.Size(23, 33)
        Me.toolStripButton9.Text = "移到下一個"
        Me.toolStripButton9.Visible = False
        '
        'toolStripButton10
        '
        Me.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolStripButton10.Image = CType(resources.GetObject("toolStripButton10.Image"), System.Drawing.Image)
        Me.toolStripButton10.Name = "toolStripButton10"
        Me.toolStripButton10.RightToLeftAutoMirrorImage = True
        Me.toolStripButton10.Size = New System.Drawing.Size(23, 33)
        Me.toolStripButton10.Text = "移到最後面"
        Me.toolStripButton10.Visible = False
        '
        'FrmCSamplingPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 425)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmCSamplingPlan"
        Me.Text = "抽验计划"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.bindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator1.ResumeLayout(False)
        Me.bindingNavigator1.PerformLayout()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator2.ResumeLayout(False)
        Me.bindingNavigator2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents gvData As System.Windows.Forms.DataGridView
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents LabFilter As System.Windows.Forms.Label
    Private WithEvents editFilter As System.Windows.Forms.TextBox
    Private WithEvents combFilter As System.Windows.Forms.ComboBox
    Private WithEvents bindingNavigator1 As System.Windows.Forms.BindingNavigator
    Private WithEvents combShow As System.Windows.Forms.ToolStripComboBox
    Private WithEvents btnAppend As System.Windows.Forms.ToolStripButton
    Private WithEvents btnModify As System.Windows.Forms.ToolStripButton
    Private WithEvents btnEnabled As System.Windows.Forms.ToolStripButton
    Private WithEvents btnDisabled As System.Windows.Forms.ToolStripButton
    Private WithEvents btnDelete As System.Windows.Forms.ToolStripButton
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
    Private WithEvents gvDetail As System.Windows.Forms.DataGridView
    Private WithEvents bindingNavigator2 As System.Windows.Forms.BindingNavigator
    Private WithEvents btnDetailAppend As System.Windows.Forms.ToolStripButton
    Private WithEvents btnDetailModify As System.Windows.Forms.ToolStripButton
    Private WithEvents btnDetailDelete As System.Windows.Forms.ToolStripButton
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
    Private WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
