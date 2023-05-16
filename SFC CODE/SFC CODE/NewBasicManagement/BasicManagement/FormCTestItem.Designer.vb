<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCTestItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCTestItem))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gvData = New System.Windows.Forms.DataGridView()
        Me.ITEM_TYPE_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_TYPE_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_TYPE_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Effective = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.combFilterField = New System.Windows.Forms.ComboBox()
        Me.editFilter = New System.Windows.Forms.TextBox()
        Me.combFilter = New System.Windows.Forms.ComboBox()
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
        Me.gvDetail = New System.Windows.Forms.DataGridView()
        Me.ITEM_Small_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_Small_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_Small_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_Small_default = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_Small_Usid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_Small_Effective = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_Small_Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.combDetailFilterField = New System.Windows.Forms.ComboBox()
        Me.editDetailFilter = New System.Windows.Forms.TextBox()
        Me.combDetailFilter = New System.Windows.Forms.ComboBox()
        Me.bindingNavigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contextMenuStrip1.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.bindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator1.SuspendLayout()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel2.SuspendLayout()
        CType(Me.bindingNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator2.SuspendLayout()
        Me.SuspendLayout()
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
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
        Me.splitContainer1.Size = New System.Drawing.Size(890, 426)
        Me.splitContainer1.SplitterDistance = 169
        Me.splitContainer1.TabIndex = 7
        '
        'gvData
        '
        Me.gvData.AllowUserToAddRows = False
        Me.gvData.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gvData.BackgroundColor = System.Drawing.Color.White
        Me.gvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITEM_TYPE_CODE, Me.ITEM_TYPE_NAME, Me.ITEM_TYPE_DESC, Me.USID, Me.Effective, Me.Time})
        Me.gvData.ContextMenuStrip = Me.contextMenuStrip1
        Me.gvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvData.Location = New System.Drawing.Point(0, 72)
        Me.gvData.MultiSelect = False
        Me.gvData.Name = "gvData"
        Me.gvData.ReadOnly = True
        Me.gvData.RowHeadersWidth = 25
        Me.gvData.RowTemplate.Height = 24
        Me.gvData.Size = New System.Drawing.Size(890, 97)
        Me.gvData.TabIndex = 1
        Me.gvData.VirtualMode = True
        '
        'ITEM_TYPE_CODE
        '
        Me.ITEM_TYPE_CODE.DataPropertyName = "ITEM_TYPE_CODE"
        Me.ITEM_TYPE_CODE.HeaderText = "测试大项代码"
        Me.ITEM_TYPE_CODE.Name = "ITEM_TYPE_CODE"
        Me.ITEM_TYPE_CODE.ReadOnly = True
        '
        'ITEM_TYPE_NAME
        '
        Me.ITEM_TYPE_NAME.DataPropertyName = "ITEM_TYPE_NAME"
        Me.ITEM_TYPE_NAME.HeaderText = "测试大项名称"
        Me.ITEM_TYPE_NAME.Name = "ITEM_TYPE_NAME"
        Me.ITEM_TYPE_NAME.ReadOnly = True
        '
        'ITEM_TYPE_DESC
        '
        Me.ITEM_TYPE_DESC.DataPropertyName = "ITEM_TYPE_DESC"
        Me.ITEM_TYPE_DESC.HeaderText = "测试大项描述"
        Me.ITEM_TYPE_DESC.Name = "ITEM_TYPE_DESC"
        Me.ITEM_TYPE_DESC.ReadOnly = True
        '
        'USID
        '
        Me.USID.DataPropertyName = "USID"
        Me.USID.HeaderText = "维护人"
        Me.USID.Name = "USID"
        Me.USID.ReadOnly = True
        '
        'Effective
        '
        Me.Effective.DataPropertyName = "Effective"
        Me.Effective.HeaderText = "是否有效"
        Me.Effective.Name = "Effective"
        Me.Effective.ReadOnly = True
        '
        'Time
        '
        Me.Time.DataPropertyName = "Time"
        Me.Time.HeaderText = "维护时间"
        Me.Time.Name = "Time"
        Me.Time.ReadOnly = True
        '
        'contextMenuStrip1
        '
        Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuHistory})
        Me.contextMenuStrip1.Name = "contextMenuStrip1"
        Me.contextMenuStrip1.Size = New System.Drawing.Size(144, 26)
        '
        'MenuHistory
        '
        Me.MenuHistory.Name = "MenuHistory"
        Me.MenuHistory.Size = New System.Drawing.Size(143, 22)
        Me.MenuHistory.Text = "History Log"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.panel1.Controls.Add(Me.Label1)
        Me.panel1.Controls.Add(Me.combFilterField)
        Me.panel1.Controls.Add(Me.editFilter)
        Me.panel1.Controls.Add(Me.combFilter)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 36)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(890, 36)
        Me.panel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "过滤条件"
        '
        'combFilterField
        '
        Me.combFilterField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combFilterField.FormattingEnabled = True
        Me.combFilterField.Location = New System.Drawing.Point(400, 9)
        Me.combFilterField.Name = "combFilterField"
        Me.combFilterField.Size = New System.Drawing.Size(121, 20)
        Me.combFilterField.TabIndex = 2
        Me.combFilterField.Visible = False
        '
        'editFilter
        '
        Me.editFilter.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.editFilter.Location = New System.Drawing.Point(223, 6)
        Me.editFilter.Name = "editFilter"
        Me.editFilter.Size = New System.Drawing.Size(148, 23)
        Me.editFilter.TabIndex = 1
        '
        'combFilter
        '
        Me.combFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combFilter.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.combFilter.FormattingEnabled = True
        Me.combFilter.Items.AddRange(New Object() {"测试大项代码", "测试大项名称", "测试大项描述"})
        Me.combFilter.Location = New System.Drawing.Point(92, 6)
        Me.combFilter.Name = "combFilter"
        Me.combFilter.Size = New System.Drawing.Size(125, 21)
        Me.combFilter.TabIndex = 0
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
        Me.bindingNavigator1.PositionItem = Nothing
        Me.bindingNavigator1.Size = New System.Drawing.Size(890, 36)
        Me.bindingNavigator1.TabIndex = 2
        Me.bindingNavigator1.Text = "bindingNavigator1"
        '
        'combShow
        '
        Me.combShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combShow.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.combShow.Items.AddRange(New Object() {"是否有效", "停用", "有效"})
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
        Me.btnEnabled.Enabled = False
        Me.btnEnabled.Image = CType(resources.GetObject("btnEnabled.Image"), System.Drawing.Image)
        Me.btnEnabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnabled.Name = "btnEnabled"
        Me.btnEnabled.Size = New System.Drawing.Size(37, 33)
        Me.btnEnabled.Text = "有效"
        Me.btnEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'bindingNavigatorSeparator2
        '
        Me.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2"
        Me.bindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 36)
        '
        'btnExport
        '
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(37, 33)
        Me.btnExport.Text = "导出"
        Me.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gvDetail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gvDetail.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITEM_Small_Code, Me.ITEM_Small_Name, Me.ITEM_Small_DESC, Me.ITEM_Small_default, Me.ITEM_Small_Usid, Me.ITEM_Small_Effective, Me.ITEM_Small_Time})
        Me.gvDetail.ContextMenuStrip = Me.contextMenuStrip1
        Me.gvDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvDetail.Location = New System.Drawing.Point(0, 72)
        Me.gvDetail.MultiSelect = False
        Me.gvDetail.Name = "gvDetail"
        Me.gvDetail.ReadOnly = True
        Me.gvDetail.RowHeadersWidth = 25
        Me.gvDetail.RowTemplate.Height = 24
        Me.gvDetail.Size = New System.Drawing.Size(890, 181)
        Me.gvDetail.TabIndex = 4
        Me.gvDetail.VirtualMode = True
        '
        'ITEM_Small_Code
        '
        Me.ITEM_Small_Code.DataPropertyName = "ITEM_Small_Code"
        Me.ITEM_Small_Code.HeaderText = "测试小项代码"
        Me.ITEM_Small_Code.Name = "ITEM_Small_Code"
        Me.ITEM_Small_Code.ReadOnly = True
        '
        'ITEM_Small_Name
        '
        Me.ITEM_Small_Name.DataPropertyName = "ITEM_Small_Name"
        Me.ITEM_Small_Name.HeaderText = "测试小项名称"
        Me.ITEM_Small_Name.Name = "ITEM_Small_Name"
        Me.ITEM_Small_Name.ReadOnly = True
        '
        'ITEM_Small_DESC
        '
        Me.ITEM_Small_DESC.DataPropertyName = "ITEM_Small_DESC"
        Me.ITEM_Small_DESC.HeaderText = "测试小项描述"
        Me.ITEM_Small_DESC.Name = "ITEM_Small_DESC"
        Me.ITEM_Small_DESC.ReadOnly = True
        '
        'ITEM_Small_default
        '
        Me.ITEM_Small_default.DataPropertyName = "ITEM_Small_default"
        Me.ITEM_Small_default.HeaderText = "测试默认值"
        Me.ITEM_Small_default.Name = "ITEM_Small_default"
        Me.ITEM_Small_default.ReadOnly = True
        '
        'ITEM_Small_Usid
        '
        Me.ITEM_Small_Usid.DataPropertyName = "ITEM_Small_Usid"
        Me.ITEM_Small_Usid.HeaderText = "维护人"
        Me.ITEM_Small_Usid.Name = "ITEM_Small_Usid"
        Me.ITEM_Small_Usid.ReadOnly = True
        '
        'ITEM_Small_Effective
        '
        Me.ITEM_Small_Effective.DataPropertyName = "ITEM_Small_Effective"
        Me.ITEM_Small_Effective.HeaderText = "是否有效"
        Me.ITEM_Small_Effective.Name = "ITEM_Small_Effective"
        Me.ITEM_Small_Effective.ReadOnly = True
        '
        'ITEM_Small_Time
        '
        Me.ITEM_Small_Time.DataPropertyName = "ITEM_Small_Time"
        Me.ITEM_Small_Time.HeaderText = "维护时间"
        Me.ITEM_Small_Time.Name = "ITEM_Small_Time"
        Me.ITEM_Small_Time.ReadOnly = True
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.panel2.Controls.Add(Me.Label2)
        Me.panel2.Controls.Add(Me.combDetailFilterField)
        Me.panel2.Controls.Add(Me.editDetailFilter)
        Me.panel2.Controls.Add(Me.combDetailFilter)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel2.Location = New System.Drawing.Point(0, 36)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(890, 36)
        Me.panel2.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "过滤条件"
        '
        'combDetailFilterField
        '
        Me.combDetailFilterField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combDetailFilterField.FormattingEnabled = True
        Me.combDetailFilterField.Location = New System.Drawing.Point(373, 8)
        Me.combDetailFilterField.Name = "combDetailFilterField"
        Me.combDetailFilterField.Size = New System.Drawing.Size(121, 20)
        Me.combDetailFilterField.TabIndex = 2
        Me.combDetailFilterField.Visible = False
        '
        'editDetailFilter
        '
        Me.editDetailFilter.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.editDetailFilter.Location = New System.Drawing.Point(223, 6)
        Me.editDetailFilter.Name = "editDetailFilter"
        Me.editDetailFilter.Size = New System.Drawing.Size(148, 23)
        Me.editDetailFilter.TabIndex = 1
        '
        'combDetailFilter
        '
        Me.combDetailFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combDetailFilter.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.combDetailFilter.FormattingEnabled = True
        Me.combDetailFilter.Items.AddRange(New Object() {"测试小项代码", "测试小项名称", "测试小项描述"})
        Me.combDetailFilter.Location = New System.Drawing.Point(92, 7)
        Me.combDetailFilter.Name = "combDetailFilter"
        Me.combDetailFilter.Size = New System.Drawing.Size(125, 21)
        Me.combDetailFilter.TabIndex = 0
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
        Me.bindingNavigator2.PositionItem = Nothing
        Me.bindingNavigator2.Size = New System.Drawing.Size(890, 36)
        Me.bindingNavigator2.TabIndex = 3
        Me.bindingNavigator2.Text = "bindingNavigator2"
        '
        'combDetailShow
        '
        Me.combDetailShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combDetailShow.Font = New System.Drawing.Font("新細明體-ExtB", 9.75!)
        Me.combDetailShow.Items.AddRange(New Object() {"是否有效", "停用", "有效"})
        Me.combDetailShow.Name = "combDetailShow"
        Me.combDetailShow.Size = New System.Drawing.Size(80, 36)
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
        'btnDetailEnabled
        '
        Me.btnDetailEnabled.Enabled = False
        Me.btnDetailEnabled.Image = CType(resources.GetObject("btnDetailEnabled.Image"), System.Drawing.Image)
        Me.btnDetailEnabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetailEnabled.Name = "btnDetailEnabled"
        Me.btnDetailEnabled.Size = New System.Drawing.Size(37, 33)
        Me.btnDetailEnabled.Text = "有效"
        Me.btnDetailEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDetailDisabled
        '
        Me.btnDetailDisabled.Image = CType(resources.GetObject("btnDetailDisabled.Image"), System.Drawing.Image)
        Me.btnDetailDisabled.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetailDisabled.Name = "btnDetailDisabled"
        Me.btnDetailDisabled.Size = New System.Drawing.Size(37, 33)
        Me.btnDetailDisabled.Text = "停用"
        Me.btnDetailDisabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 36)
        '
        'btnDetailExport
        '
        Me.btnDetailExport.Image = CType(resources.GetObject("btnDetailExport.Image"), System.Drawing.Image)
        Me.btnDetailExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetailExport.Name = "btnDetailExport"
        Me.btnDetailExport.Size = New System.Drawing.Size(37, 33)
        Me.btnDetailExport.Text = "导出"
        Me.btnDetailExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'FormCTestItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 426)
        Me.Controls.Add(Me.splitContainer1)
        Me.Name = "FormCTestItem"
        Me.Text = "QC测试项目"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.Panel2.PerformLayout()
        Me.splitContainer1.ResumeLayout(False)
        CType(Me.gvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contextMenuStrip1.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.bindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator1.ResumeLayout(False)
        Me.bindingNavigator1.PerformLayout()
        CType(Me.gvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.bindingNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator2.ResumeLayout(False)
        Me.bindingNavigator2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents gvData As System.Windows.Forms.DataGridView
    Private WithEvents contextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents MenuHistory As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents combFilterField As System.Windows.Forms.ComboBox
    Private WithEvents editFilter As System.Windows.Forms.TextBox
    Private WithEvents combFilter As System.Windows.Forms.ComboBox
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
    Private WithEvents gvDetail As System.Windows.Forms.DataGridView
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents combDetailFilterField As System.Windows.Forms.ComboBox
    Private WithEvents editDetailFilter As System.Windows.Forms.TextBox
    Private WithEvents combDetailFilter As System.Windows.Forms.ComboBox
    Private WithEvents bindingNavigator2 As System.Windows.Forms.BindingNavigator
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
    Private WithEvents saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ITEM_TYPE_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_TYPE_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_TYPE_DESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Effective As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_DESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_default As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_Usid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_Effective As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_Small_Time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
