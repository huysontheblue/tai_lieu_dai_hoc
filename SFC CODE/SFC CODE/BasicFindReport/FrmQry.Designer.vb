<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQry
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmQry))
        Me.ToolBt = New System.Windows.Forms.ToolStrip
        Me.ToolNew = New System.Windows.Forms.ToolStripButton
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton
        Me.ToolCancel = New System.Windows.Forms.ToolStripButton
        Me.ToolSave = New System.Windows.Forms.ToolStripButton
        Me.ToolUnDo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolQuery = New System.Windows.Forms.ToolStripButton
        Me.ToolRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.txtCondition = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tbase = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DGDetail = New System.Windows.Forms.DataGridView
        Me.DataName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FieldName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FieldDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsReturn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.FieldType = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Relation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtProName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtWinTitle = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.chkIsMulti = New System.Windows.Forms.CheckBox
        Me.tstate = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.CGrup = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CUser = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.DActi = New System.Windows.Forms.TextBox
        Me.EUser = New System.Windows.Forms.TextBox
        Me.DDate = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolBt.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tbase.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DGDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tstate.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolCancel, Me.ToolSave, Me.ToolUnDo, Me.ToolStripSeparator2, Me.toolQuery, Me.ToolRefresh, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton6, Me.ToolStripLabel1, Me.ToolStripButton7, Me.ToolStripButton4, Me.ToolStripButton5})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(999, 25)
        Me.ToolBt.TabIndex = 121
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolNew
        '
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
        Me.ToolCancel.Image = CType(resources.GetObject("ToolCancel.Image"), System.Drawing.Image)
        Me.ToolCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCancel.Name = "ToolCancel"
        Me.ToolCancel.Size = New System.Drawing.Size(73, 22)
        Me.ToolCancel.Tag = "NO"
        Me.ToolCancel.Text = "作 废(&D)"
        Me.ToolCancel.ToolTipText = "作 废"
        '
        'ToolSave
        '
        Me.ToolSave.Image = CType(resources.GetObject("ToolSave.Image"), System.Drawing.Image)
        Me.ToolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolSave.Name = "ToolSave"
        Me.ToolSave.Size = New System.Drawing.Size(71, 22)
        Me.ToolSave.Text = "保 存(&S)"
        Me.ToolSave.ToolTipText = "保 存"
        '
        'ToolUnDo
        '
        Me.ToolUnDo.Image = CType(resources.GetObject("ToolUnDo.Image"), System.Drawing.Image)
        Me.ToolUnDo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolUnDo.Name = "ToolUnDo"
        Me.ToolUnDo.Size = New System.Drawing.Size(72, 22)
        Me.ToolUnDo.Text = "返 回(&B)"
        Me.ToolUnDo.ToolTipText = "返 回"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 22)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolRefresh
        '
        Me.ToolRefresh.Image = CType(resources.GetObject("ToolRefresh.Image"), System.Drawing.Image)
        Me.ToolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.ToolRefresh.Name = "ToolRefresh"
        Me.ToolRefresh.Size = New System.Drawing.Size(72, 22)
        Me.ToolRefresh.Text = "刷 新(&R)"
        Me.ToolRefresh.ToolTipText = "刷 新"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripButton1.Text = "退出(&X)"
        Me.ToolStripButton1.ToolTipText = "退出"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripButton2.Text = "记录尾"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripButton3.Text = "下一条"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(27, 22)
        Me.ToolStripLabel1.Text = "1/1"
        Me.ToolStripLabel1.ToolTipText = "第几页/共几页"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripButton4.Text = "上一条"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripButton5.Text = "记录首"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtTableName
        '
        Me.txtTableName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTableName.Location = New System.Drawing.Point(123, 6)
        Me.txtTableName.MaxLength = 200
        Me.txtTableName.Multiline = True
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(856, 25)
        Me.txtTableName.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtTableName, "表名之间请用逗号(,)分隔")
        '
        'txtCondition
        '
        Me.txtCondition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCondition.Location = New System.Drawing.Point(123, 40)
        Me.txtCondition.MaxLength = 2000
        Me.txtCondition.Multiline = True
        Me.txtCondition.Name = "txtCondition"
        Me.txtCondition.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCondition.Size = New System.Drawing.Size(856, 43)
        Me.txtCondition.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.txtCondition, "输入查询条件")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 493)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(999, 22)
        Me.StatusStrip1.TabIndex = 124
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbase)
        Me.TabControl1.Controls.Add(Me.tstate)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(999, 468)
        Me.TabControl1.TabIndex = 125
        '
        'tbase
        '
        Me.tbase.Controls.Add(Me.TableLayoutPanel1)
        Me.tbase.Controls.Add(Me.FlowLayoutPanel1)
        Me.tbase.Location = New System.Drawing.Point(4, 22)
        Me.tbase.Name = "tbase"
        Me.tbase.Padding = New System.Windows.Forms.Padding(3)
        Me.tbase.Size = New System.Drawing.Size(991, 442)
        Me.tbase.TabIndex = 0
        Me.tbase.Text = "基本资料"
        Me.tbase.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTableName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCondition, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DGDetail, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 41)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(985, 398)
        Me.TableLayoutPanel1.TabIndex = 125
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(10, 3)
        Me.Label3.Margin = New System.Windows.Forms.Padding(7, 0, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 31)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "需关联的表名"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(10, 37)
        Me.Label4.Margin = New System.Windows.Forms.Padding(7, 0, 3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 49)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "查询必要条件"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DGDetail
        '
        Me.DGDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataName, Me.TabName, Me.FieldName, Me.FieldDesc, Me.IsReturn, Me.FieldType, Me.Relation})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DGDetail, 2)
        Me.DGDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DGDetail.Location = New System.Drawing.Point(6, 92)
        Me.DGDetail.Name = "DGDetail"
        Me.DGDetail.RowTemplate.Height = 23
        Me.DGDetail.Size = New System.Drawing.Size(973, 300)
        Me.DGDetail.TabIndex = 8
        '
        'DataName
        '
        Me.DataName.HeaderText = "资料数据库代码"
        Me.DataName.Name = "DataName"
        '
        'TabName
        '
        Me.TabName.HeaderText = "资料表代码"
        Me.TabName.Name = "TabName"
        '
        'FieldName
        '
        Me.FieldName.HeaderText = "字段代码"
        Me.FieldName.Name = "FieldName"
        '
        'FieldDesc
        '
        Me.FieldDesc.HeaderText = "字段说明"
        Me.FieldDesc.Name = "FieldDesc"
        '
        'IsReturn
        '
        Me.IsReturn.HeaderText = "本栏回传"
        Me.IsReturn.Name = "IsReturn"
        Me.IsReturn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsReturn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'FieldType
        '
        Me.FieldType.HeaderText = "字段类型"
        Me.FieldType.Items.AddRange(New Object() {"String", "Number", "Boolean", "Date"})
        Me.FieldType.Name = "FieldType"
        Me.FieldType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FieldType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Relation
        '
        Me.Relation.HeaderText = "关联查询"
        Me.Relation.Name = "Relation"
        Me.Relation.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Relation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(985, 38)
        Me.FlowLayoutPanel1.TabIndex = 124
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtProName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(351, 32)
        Me.Panel1.TabIndex = 0
        '
        'txtProName
        '
        Me.txtProName.BackColor = System.Drawing.Color.Yellow
        Me.txtProName.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtProName.Location = New System.Drawing.Point(121, 7)
        Me.txtProName.MaxLength = 20
        Me.txtProName.Name = "txtProName"
        Me.txtProName.Size = New System.Drawing.Size(207, 21)
        Me.txtProName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "动态查询程序名称"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtWinTitle)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(360, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(355, 32)
        Me.Panel2.TabIndex = 1
        '
        'txtWinTitle
        '
        Me.txtWinTitle.BackColor = System.Drawing.Color.Yellow
        Me.txtWinTitle.Location = New System.Drawing.Point(121, 7)
        Me.txtWinTitle.MaxLength = 40
        Me.txtWinTitle.Name = "txtWinTitle"
        Me.txtWinTitle.Size = New System.Drawing.Size(207, 21)
        Me.txtWinTitle.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "查询视窗标题"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chkIsMulti)
        Me.Panel3.Location = New System.Drawing.Point(721, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(239, 32)
        Me.Panel3.TabIndex = 2
        '
        'chkIsMulti
        '
        Me.chkIsMulti.AutoSize = True
        Me.chkIsMulti.Location = New System.Drawing.Point(3, 9)
        Me.chkIsMulti.Name = "chkIsMulti"
        Me.chkIsMulti.Size = New System.Drawing.Size(228, 16)
        Me.chkIsMulti.TabIndex = 9
        Me.chkIsMulti.Text = "本单据查询忽略明细资料营运中心设置"
        Me.chkIsMulti.UseVisualStyleBackColor = True
        '
        'tstate
        '
        Me.tstate.Controls.Add(Me.TableLayoutPanel2)
        Me.tstate.Location = New System.Drawing.Point(4, 22)
        Me.tstate.Name = "tstate"
        Me.tstate.Padding = New System.Windows.Forms.Padding(3)
        Me.tstate.Size = New System.Drawing.Size(991, 442)
        Me.tstate.TabIndex = 1
        Me.tstate.Text = "状态"
        Me.tstate.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CGrup, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CUser, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.DActi, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.EUser, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.DDate, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 4)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(8, 6)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(321, 186)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'CGrup
        '
        Me.CGrup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CGrup.Location = New System.Drawing.Point(103, 43)
        Me.CGrup.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.CGrup.Multiline = True
        Me.CGrup.Name = "CGrup"
        Me.CGrup.ReadOnly = True
        Me.CGrup.Size = New System.Drawing.Size(215, 25)
        Me.CGrup.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 37)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "资料所有群"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 37)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "资料所有者"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CUser
        '
        Me.CUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CUser.Location = New System.Drawing.Point(103, 6)
        Me.CUser.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.CUser.Multiline = True
        Me.CUser.Name = "CUser"
        Me.CUser.ReadOnly = True
        Me.CUser.Size = New System.Drawing.Size(215, 25)
        Me.CUser.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 37)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "资料有效码"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(3, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 37)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "资料更改者"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DActi
        '
        Me.DActi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DActi.Location = New System.Drawing.Point(103, 80)
        Me.DActi.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.DActi.Multiline = True
        Me.DActi.Name = "DActi"
        Me.DActi.ReadOnly = True
        Me.DActi.Size = New System.Drawing.Size(215, 25)
        Me.DActi.TabIndex = 6
        '
        'EUser
        '
        Me.EUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EUser.Location = New System.Drawing.Point(103, 117)
        Me.EUser.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.EUser.Multiline = True
        Me.EUser.Name = "EUser"
        Me.EUser.ReadOnly = True
        Me.EUser.Size = New System.Drawing.Size(215, 25)
        Me.EUser.TabIndex = 7
        '
        'DDate
        '
        Me.DDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DDate.Location = New System.Drawing.Point(103, 154)
        Me.DDate.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.DDate.Multiline = True
        Me.DDate.Name = "DDate"
        Me.DDate.ReadOnly = True
        Me.DDate.Size = New System.Drawing.Size(215, 26)
        Me.DDate.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(3, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 38)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "最近更改日"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "资料数据库代码"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "资料表代码"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "字段代码"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "字段说明"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "本栏回传"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "字段类型"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'FrmQry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 515)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmQry"
        Me.Text = "Form1"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tbase.ResumeLayout(False)
        Me.tbase.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DGDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tstate.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolUnDo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbase As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents txtCondition As System.Windows.Forms.TextBox
    Friend WithEvents DGDetail As System.Windows.Forms.DataGridView
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtProName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtWinTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkIsMulti As System.Windows.Forms.CheckBox
    Friend WithEvents tstate As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CUser As System.Windows.Forms.TextBox
    Friend WithEvents CGrup As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DActi As System.Windows.Forms.TextBox
    Friend WithEvents EUser As System.Windows.Forms.TextBox
    Friend WithEvents DDate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FieldName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FieldDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsReturn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FieldType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Relation As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
