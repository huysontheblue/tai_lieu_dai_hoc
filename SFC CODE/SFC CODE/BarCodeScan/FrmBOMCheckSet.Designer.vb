<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBOMCheckSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBOMCheckSet))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPPartID_Hide = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPPartID = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckAll2 = New System.Windows.Forms.CheckBox()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvNeedCheckSelected = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.dgvAllBOMPart = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.BOM_Select = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PartID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typedest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmountQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BOM_Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PartID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.typedest2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmountQty2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvNeedCheckSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAllBOMPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "剩余数量"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Flag"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 60
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "料件ID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Flag"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "料件ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 60
        '
        'btnOK
        '
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(278, 378)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 36)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "确 定(&1)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "预警数量"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 80
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.txtPPartID_Hide)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnQuery)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtPPartID)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(934, 84)
        Me.Panel1.TabIndex = 5
        '
        'txtPPartID_Hide
        '
        Me.txtPPartID_Hide.Location = New System.Drawing.Point(871, 39)
        Me.txtPPartID_Hide.Name = "txtPPartID_Hide"
        Me.txtPPartID_Hide.Size = New System.Drawing.Size(17, 21)
        Me.txtPPartID_Hide.TabIndex = 22
        Me.txtPPartID_Hide.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(491, 52)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox2.TabIndex = 19
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(520, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 12)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "已选择的物料："
        '
        'btnQuery
        '
        Me.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuery.Location = New System.Drawing.Point(389, 19)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.TabIndex = 17
        Me.btnQuery.Text = "查询"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "筛选: 主料号："
        '
        'txtPPartID
        '
        Me.txtPPartID.Location = New System.Drawing.Point(122, 19)
        Me.txtPPartID.Name = "txtPPartID"
        Me.txtPPartID.Size = New System.Drawing.Size(240, 21)
        Me.txtPPartID.TabIndex = 14
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 52)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(35, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "请选择需要检查的物料："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckAll2)
        Me.GroupBox2.Controls.Add(Me.ChkAll)
        Me.GroupBox2.Controls.Add(Me.btnRemove)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.dgvNeedCheckSelected)
        Me.GroupBox2.Controls.Add(Me.dgvAllBOMPart)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(940, 375)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'CheckAll2
        '
        Me.CheckAll2.AutoSize = True
        Me.CheckAll2.Location = New System.Drawing.Point(510, 103)
        Me.CheckAll2.Name = "CheckAll2"
        Me.CheckAll2.Size = New System.Drawing.Size(15, 14)
        Me.CheckAll2.TabIndex = 10
        Me.CheckAll2.UseVisualStyleBackColor = True
        '
        'ChkAll
        '
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(15, 103)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(15, 14)
        Me.ChkAll.TabIndex = 9
        Me.ChkAll.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.BackgroundImage = CType(resources.GetObject("btnRemove.BackgroundImage"), System.Drawing.Image)
        Me.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Location = New System.Drawing.Point(456, 263)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(32, 49)
        Me.btnRemove.TabIndex = 2
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(456, 145)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 48)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvNeedCheckSelected
        '
        Me.dgvNeedCheckSelected.AllowUserToAddRows = False
        Me.dgvNeedCheckSelected.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvNeedCheckSelected.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNeedCheckSelected.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvNeedCheckSelected.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNeedCheckSelected.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvNeedCheckSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNeedCheckSelected.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BOM_Selected, Me.PartID2, Me.typedest2, Me.AmountQty2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNeedCheckSelected.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvNeedCheckSelected.Dock = System.Windows.Forms.DockStyle.Right
        Me.dgvNeedCheckSelected.EnableHeadersVisualStyles = False
        Me.dgvNeedCheckSelected.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvNeedCheckSelected.Location = New System.Drawing.Point(492, 101)
        Me.dgvNeedCheckSelected.Name = "dgvNeedCheckSelected"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNeedCheckSelected.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvNeedCheckSelected.RowHeadersVisible = False
        Me.dgvNeedCheckSelected.RowHeadersWidth = 20
        Me.dgvNeedCheckSelected.RowTemplate.Height = 23
        Me.dgvNeedCheckSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvNeedCheckSelected.Size = New System.Drawing.Size(445, 271)
        Me.dgvNeedCheckSelected.TabIndex = 8
        '
        'dgvAllBOMPart
        '
        Me.dgvAllBOMPart.AllowUserToAddRows = False
        Me.dgvAllBOMPart.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvAllBOMPart.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvAllBOMPart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvAllBOMPart.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAllBOMPart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvAllBOMPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAllBOMPart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BOM_Select, Me.PartID, Me.typedest, Me.AmountQty})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAllBOMPart.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvAllBOMPart.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvAllBOMPart.EnableHeadersVisualStyles = False
        Me.dgvAllBOMPart.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvAllBOMPart.Location = New System.Drawing.Point(3, 101)
        Me.dgvAllBOMPart.Name = "dgvAllBOMPart"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAllBOMPart.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvAllBOMPart.RowHeadersVisible = False
        Me.dgvAllBOMPart.RowHeadersWidth = 20
        Me.dgvAllBOMPart.RowTemplate.Height = 23
        Me.dgvAllBOMPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAllBOMPart.Size = New System.Drawing.Size(449, 271)
        Me.dgvAllBOMPart.TabIndex = 7
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(557, 379)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 35)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "取消(&0)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'BOM_Select
        '
        Me.BOM_Select.FalseValue = "N"
        Me.BOM_Select.HeaderText = ""
        Me.BOM_Select.Name = "BOM_Select"
        Me.BOM_Select.TrueValue = "Y"
        Me.BOM_Select.Width = 35
        '
        'PartID
        '
        Me.PartID.HeaderText = "物料料号"
        Me.PartID.Name = "PartID"
        Me.PartID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PartID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PartID.Width = 110
        '
        'typedest
        '
        Me.typedest.HeaderText = "料件描述"
        Me.typedest.Name = "typedest"
        Me.typedest.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.typedest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AmountQty
        '
        Me.AmountQty.HeaderText = "倍数"
        Me.AmountQty.Name = "AmountQty"
        Me.AmountQty.Width = 80
        '
        'BOM_Selected
        '
        Me.BOM_Selected.FalseValue = "N"
        Me.BOM_Selected.HeaderText = ""
        Me.BOM_Selected.Name = "BOM_Selected"
        Me.BOM_Selected.TrueValue = "Y"
        Me.BOM_Selected.Width = 40
        '
        'PartID2
        '
        Me.PartID2.HeaderText = "物料料号"
        Me.PartID2.Name = "PartID2"
        Me.PartID2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PartID2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PartID2.Width = 110
        '
        'typedest2
        '
        Me.typedest2.HeaderText = "料件描述"
        Me.typedest2.Name = "typedest2"
        Me.typedest2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.typedest2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AmountQty2
        '
        Me.AmountQty2.HeaderText = "倍数"
        Me.AmountQty2.Name = "AmountQty2"
        Me.AmountQty2.Width = 80
        '
        'FrmBOMCheckSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 424)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FrmBOMCheckSet"
        Me.Text = "BOM检查设置"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvNeedCheckSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAllBOMPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPPartID As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckAll2 As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvNeedCheckSelected As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvAllBOMPart As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtPPartID_Hide As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents BOM_Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PartID2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents typedest2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountQty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BOM_Select As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PartID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents typedest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountQty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
