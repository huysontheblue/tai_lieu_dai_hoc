<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEquipmentStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEquipmentStock))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSearch = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboSmallCategory = New System.Windows.Forms.ComboBox()
        Me.cboMiddleCategory = New System.Windows.Forms.ComboBox()
        Me.cboBigCategory = New System.Windows.Forms.ComboBox()
        Me.cboUserY = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtPartNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.dgvEquipment = New System.Windows.Forms.DataGridView()
        Me.BigCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MiddleCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SmallCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SafeQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BigCategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MiddleCategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SmallCategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvEquipmentD = New System.Windows.Forms.DataGridView()
        Me.EquipmentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SmallCategory2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartNumberD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessParameters = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Storage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemainCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.splitContainer2.Panel1.SuspendLayout()
        Me.splitContainer2.Panel2.SuspendLayout()
        Me.splitContainer2.SuspendLayout()
        CType(Me.dgvEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEquipmentD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator7, Me.toolSearch, Me.toolStripSeparator1, Me.toolExcel, Me.ToolStripSeparator3, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1202, 23)
        Me.ToolBt.TabIndex = 141
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'toolSearch
        '
        Me.toolSearch.Image = CType(resources.GetObject("toolSearch.Image"), System.Drawing.Image)
        Me.toolSearch.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolSearch.Name = "toolSearch"
        Me.toolSearch.Size = New System.Drawing.Size(72, 20)
        Me.toolSearch.Text = "刷 新(&R)"
        Me.toolSearch.ToolTipText = "刷新"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'toolExcel
        '
        Me.toolExcel.Image = CType(resources.GetObject("toolExcel.Image"), System.Drawing.Image)
        Me.toolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExcel.Name = "toolExcel"
        Me.toolExcel.Size = New System.Drawing.Size(64, 20)
        Me.toolExcel.Text = "汇   出"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 20)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 23)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label13)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.splitContainer1.Panel1.Controls.Add(Me.cboSmallCategory)
        Me.splitContainer1.Panel1.Controls.Add(Me.cboMiddleCategory)
        Me.splitContainer1.Panel1.Controls.Add(Me.cboBigCategory)
        Me.splitContainer1.Panel1.Controls.Add(Me.cboUserY)
        Me.splitContainer1.Panel1.Controls.Add(Me.label3)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtPartNumber)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.splitContainer2)
        Me.splitContainer1.Size = New System.Drawing.Size(1202, 457)
        Me.splitContainer1.SplitterDistance = 47
        Me.splitContainer1.TabIndex = 142
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(386, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "小分类:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(203, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 12)
        Me.Label13.TabIndex = 171
        Me.Label13.Text = "中分类:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 12)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "大分类:"
        '
        'cboSmallCategory
        '
        Me.cboSmallCategory.BackColor = System.Drawing.Color.White
        Me.cboSmallCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSmallCategory.FormattingEnabled = True
        Me.cboSmallCategory.Location = New System.Drawing.Point(439, 12)
        Me.cboSmallCategory.Name = "cboSmallCategory"
        Me.cboSmallCategory.Size = New System.Drawing.Size(115, 20)
        Me.cboSmallCategory.TabIndex = 167
        '
        'cboMiddleCategory
        '
        Me.cboMiddleCategory.BackColor = System.Drawing.Color.White
        Me.cboMiddleCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMiddleCategory.FormattingEnabled = True
        Me.cboMiddleCategory.Location = New System.Drawing.Point(256, 12)
        Me.cboMiddleCategory.Name = "cboMiddleCategory"
        Me.cboMiddleCategory.Size = New System.Drawing.Size(115, 20)
        Me.cboMiddleCategory.TabIndex = 168
        '
        'cboBigCategory
        '
        Me.cboBigCategory.BackColor = System.Drawing.Color.White
        Me.cboBigCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBigCategory.FormattingEnabled = True
        Me.cboBigCategory.Location = New System.Drawing.Point(65, 11)
        Me.cboBigCategory.Name = "cboBigCategory"
        Me.cboBigCategory.Size = New System.Drawing.Size(118, 20)
        Me.cboBigCategory.TabIndex = 169
        '
        'cboUserY
        '
        Me.cboUserY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserY.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.cboUserY.FormattingEnabled = True
        Me.cboUserY.Items.AddRange(New Object() {"", "1.有效", "0.无效"})
        Me.cboUserY.Location = New System.Drawing.Point(840, 11)
        Me.cboUserY.Name = "cboUserY"
        Me.cboUserY.Size = New System.Drawing.Size(121, 20)
        Me.cboUserY.TabIndex = 164
        Me.cboUserY.Visible = False
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(787, 14)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(47, 12)
        Me.label3.TabIndex = 166
        Me.label3.Text = "可用否:"
        Me.label3.Visible = False
        '
        'txtPartNumber
        '
        Me.txtPartNumber.BackColor = System.Drawing.SystemColors.Window
        Me.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartNumber.Location = New System.Drawing.Point(657, 11)
        Me.txtPartNumber.MaxLength = 25
        Me.txtPartNumber.Name = "txtPartNumber"
        Me.txtPartNumber.Size = New System.Drawing.Size(121, 21)
        Me.txtPartNumber.TabIndex = 163
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(580, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 165
        Me.Label1.Text = "工治具料号:"
        '
        'splitContainer2
        '
        Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer2.Name = "splitContainer2"
        '
        'splitContainer2.Panel1
        '
        Me.splitContainer2.Panel1.Controls.Add(Me.dgvEquipment)
        '
        'splitContainer2.Panel2
        '
        Me.splitContainer2.Panel2.Controls.Add(Me.dgvEquipmentD)
        Me.splitContainer2.Size = New System.Drawing.Size(1202, 406)
        Me.splitContainer2.SplitterDistance = 539
        Me.splitContainer2.TabIndex = 0
        '
        'dgvEquipment
        '
        Me.dgvEquipment.AllowUserToAddRows = False
        Me.dgvEquipment.AllowUserToDeleteRows = False
        Me.dgvEquipment.AllowUserToResizeColumns = False
        Me.dgvEquipment.AllowUserToResizeRows = False
        Me.dgvEquipment.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvEquipment.ColumnHeadersHeight = 28
        Me.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvEquipment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BigCategory, Me.MiddleCategory, Me.SmallCategory, Me.PartNumber, Me.CNT, Me.dataGridViewTextBoxColumn3, Me.SafeQty, Me.CategoryID, Me.Status, Me.BigCategoryCode, Me.MiddleCategoryCode, Me.SmallCategoryCode})
        Me.dgvEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEquipment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEquipment.Location = New System.Drawing.Point(0, 0)
        Me.dgvEquipment.Name = "dgvEquipment"
        Me.dgvEquipment.ReadOnly = True
        Me.dgvEquipment.RowHeadersWidth = 50
        Me.dgvEquipment.RowTemplate.Height = 23
        Me.dgvEquipment.Size = New System.Drawing.Size(539, 406)
        Me.dgvEquipment.TabIndex = 0
        '
        'BigCategory
        '
        Me.BigCategory.DataPropertyName = "BigCategory"
        Me.BigCategory.HeaderText = "工治具大类"
        Me.BigCategory.Name = "BigCategory"
        Me.BigCategory.ReadOnly = True
        Me.BigCategory.Width = 75
        '
        'MiddleCategory
        '
        Me.MiddleCategory.DataPropertyName = "MiddleCategory"
        Me.MiddleCategory.HeaderText = "中分类"
        Me.MiddleCategory.Name = "MiddleCategory"
        Me.MiddleCategory.ReadOnly = True
        Me.MiddleCategory.Width = 60
        '
        'SmallCategory
        '
        Me.SmallCategory.DataPropertyName = "SmallCategory"
        Me.SmallCategory.HeaderText = "小分类"
        Me.SmallCategory.Name = "SmallCategory"
        Me.SmallCategory.ReadOnly = True
        Me.SmallCategory.Width = 70
        '
        'PartNumber
        '
        Me.PartNumber.DataPropertyName = "PartNumber"
        Me.PartNumber.HeaderText = "工治具料号"
        Me.PartNumber.Name = "PartNumber"
        Me.PartNumber.ReadOnly = True
        '
        'CNT
        '
        Me.CNT.DataPropertyName = "CNT"
        Me.CNT.HeaderText = "库存数量"
        Me.CNT.Name = "CNT"
        Me.CNT.ReadOnly = True
        Me.CNT.Width = 70
        '
        'dataGridViewTextBoxColumn3
        '
        Me.dataGridViewTextBoxColumn3.DataPropertyName = "DESCRIPTION"
        Me.dataGridViewTextBoxColumn3.HeaderText = "工治具规格"
        Me.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3"
        Me.dataGridViewTextBoxColumn3.ReadOnly = True
        Me.dataGridViewTextBoxColumn3.Width = 150
        '
        'SafeQty
        '
        Me.SafeQty.DataPropertyName = "SafeQty"
        Me.SafeQty.HeaderText = "安全库存"
        Me.SafeQty.Name = "SafeQty"
        Me.SafeQty.ReadOnly = True
        '
        'CategoryID
        '
        Me.CategoryID.DataPropertyName = "CategoryID"
        Me.CategoryID.HeaderText = "CategoryID"
        Me.CategoryID.Name = "CategoryID"
        Me.CategoryID.ReadOnly = True
        Me.CategoryID.Visible = False
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Visible = False
        '
        'BigCategoryCode
        '
        Me.BigCategoryCode.DataPropertyName = "BigCategoryCode"
        Me.BigCategoryCode.HeaderText = "BigCategoryCode"
        Me.BigCategoryCode.Name = "BigCategoryCode"
        Me.BigCategoryCode.ReadOnly = True
        Me.BigCategoryCode.Visible = False
        '
        'MiddleCategoryCode
        '
        Me.MiddleCategoryCode.DataPropertyName = "MiddleCategoryCode"
        Me.MiddleCategoryCode.HeaderText = "MiddleCategoryCode"
        Me.MiddleCategoryCode.Name = "MiddleCategoryCode"
        Me.MiddleCategoryCode.ReadOnly = True
        Me.MiddleCategoryCode.Visible = False
        '
        'SmallCategoryCode
        '
        Me.SmallCategoryCode.DataPropertyName = "SmallCategoryCode"
        Me.SmallCategoryCode.HeaderText = "SmallCategoryCode"
        Me.SmallCategoryCode.Name = "SmallCategoryCode"
        Me.SmallCategoryCode.ReadOnly = True
        Me.SmallCategoryCode.Visible = False
        '
        'dgvEquipmentD
        '
        Me.dgvEquipmentD.AllowUserToAddRows = False
        Me.dgvEquipmentD.AllowUserToDeleteRows = False
        Me.dgvEquipmentD.AllowUserToResizeColumns = False
        Me.dgvEquipmentD.AllowUserToResizeRows = False
        Me.dgvEquipmentD.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvEquipmentD.ColumnHeadersHeight = 28
        Me.dgvEquipmentD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvEquipmentD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EquipmentNo, Me.SmallCategory2, Me.PartNumberD, Me.ProcessParameters, Me.StatusD, Me.Storage, Me.RemainCount})
        Me.dgvEquipmentD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEquipmentD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEquipmentD.Location = New System.Drawing.Point(0, 0)
        Me.dgvEquipmentD.Name = "dgvEquipmentD"
        Me.dgvEquipmentD.ReadOnly = True
        Me.dgvEquipmentD.RowTemplate.Height = 23
        Me.dgvEquipmentD.Size = New System.Drawing.Size(659, 406)
        Me.dgvEquipmentD.TabIndex = 151
        '
        'EquipmentNo
        '
        Me.EquipmentNo.DataPropertyName = "EquipmentNo"
        Me.EquipmentNo.HeaderText = "工治具编号"
        Me.EquipmentNo.Name = "EquipmentNo"
        Me.EquipmentNo.ReadOnly = True
        Me.EquipmentNo.Width = 90
        '
        'SmallCategory2
        '
        Me.SmallCategory2.DataPropertyName = "SmallCategory"
        Me.SmallCategory2.HeaderText = "工治具小分类"
        Me.SmallCategory2.Name = "SmallCategory2"
        Me.SmallCategory2.ReadOnly = True
        Me.SmallCategory2.Width = 90
        '
        'PartNumberD
        '
        Me.PartNumberD.DataPropertyName = "PartNumber"
        Me.PartNumberD.HeaderText = "工治具料号"
        Me.PartNumberD.Name = "PartNumberD"
        Me.PartNumberD.ReadOnly = True
        Me.PartNumberD.Width = 90
        '
        'ProcessParameters
        '
        Me.ProcessParameters.DataPropertyName = "ProcessParameters"
        Me.ProcessParameters.HeaderText = "加工参数"
        Me.ProcessParameters.Name = "ProcessParameters"
        Me.ProcessParameters.ReadOnly = True
        Me.ProcessParameters.Width = 180
        '
        'StatusD
        '
        Me.StatusD.DataPropertyName = "Status"
        Me.StatusD.HeaderText = "状态"
        Me.StatusD.Name = "StatusD"
        Me.StatusD.ReadOnly = True
        Me.StatusD.Width = 70
        '
        'Storage
        '
        Me.Storage.DataPropertyName = "Storage"
        Me.Storage.HeaderText = "仓库储位"
        Me.Storage.Name = "Storage"
        Me.Storage.ReadOnly = True
        Me.Storage.Width = 80
        '
        'RemainCount
        '
        Me.RemainCount.DataPropertyName = "RemainCount"
        Me.RemainCount.HeaderText = "剩余使用次数"
        Me.RemainCount.Name = "RemainCount"
        Me.RemainCount.ReadOnly = True
        '
        'FrmEquipmentStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1202, 480)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmEquipmentStock"
        Me.Text = "库存查询"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.splitContainer2.Panel1.ResumeLayout(False)
        Me.splitContainer2.Panel2.ResumeLayout(False)
        Me.splitContainer2.ResumeLayout(False)
        CType(Me.dgvEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEquipmentD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents splitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvEquipment As System.Windows.Forms.DataGridView
    Friend WithEvents dgvEquipmentD As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSmallCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboMiddleCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboBigCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboUserY As System.Windows.Forms.ComboBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents txtPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EquipmentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SmallCategory2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessParameters As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Storage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemainCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BigCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MiddleCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SmallCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SafeQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BigCategoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MiddleCategoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SmallCategoryCode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
