<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEqupmentCategory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEqupmentCategory))
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.toolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSearch = New System.Windows.Forms.ToolStripButton()
        Me.toolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblId = New System.Windows.Forms.Label()
        Me.txtCategoryName = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtAlertCount = New System.Windows.Forms.TextBox()
        Me.txtServiceCount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgGrid = New System.Windows.Forms.DataGridView()
        Me.CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlertCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemainCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TYPEName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FactoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Profitcenter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TYPECode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        CType(Me.dgGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolNew, Me.ToolStripSeparator6, Me.toolEdit, Me.ToolStripSeparator8, Me.toolSave, Me.ToolStripSeparator7, Me.toolUndo, Me.ToolStripSeparator3, Me.toolSearch, Me.toolRefresh, Me.ToolStripSeparator10, Me.toolExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1033, 25)
        Me.ToolBt.TabIndex = 144
        Me.ToolBt.Text = "ToolStrip1"
        '
        'toolNew
        '
        Me.toolNew.Enabled = False
        Me.toolNew.Image = CType(resources.GetObject("toolNew.Image"), System.Drawing.Image)
        Me.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolNew.Name = "toolNew"
        Me.toolNew.Size = New System.Drawing.Size(70, 22)
        Me.toolNew.Text = "新增(&N)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 22)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        Me.toolEdit.ToolTipText = "修 改"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'toolSave
        '
        Me.toolSave.Enabled = False
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(67, 22)
        Me.toolSave.Text = "保存(&S)"
        Me.toolSave.ToolTipText = "保存"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'toolUndo
        '
        Me.toolUndo.Enabled = False
        Me.toolUndo.Image = CType(resources.GetObject("toolUndo.Image"), System.Drawing.Image)
        Me.toolUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolUndo.Name = "toolUndo"
        Me.toolUndo.Size = New System.Drawing.Size(68, 22)
        Me.toolUndo.Text = "返回(&C)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolSearch
        '
        Me.toolSearch.Image = CType(resources.GetObject("toolSearch.Image"), System.Drawing.Image)
        Me.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSearch.Name = "toolSearch"
        Me.toolSearch.Size = New System.Drawing.Size(66, 22)
        Me.toolSearch.Text = "查询(&F)"
        '
        'toolRefresh
        '
        Me.toolRefresh.Image = CType(resources.GetObject("toolRefresh.Image"), System.Drawing.Image)
        Me.toolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolRefresh.Name = "toolRefresh"
        Me.toolRefresh.Size = New System.Drawing.Size(72, 22)
        Me.toolRefresh.Text = "刷 新(&R)"
        Me.toolRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退出(&X)"
        Me.toolExit.ToolTipText = "退出"
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.splitContainer1.Name = "splitContainer1"
        Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.lblId)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtCategoryName)
        Me.splitContainer1.Panel1.Controls.Add(Me.label5)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtAlertCount)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtServiceCount)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.splitContainer1.Panel1.Controls.Add(Me.label7)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtDescription)
        Me.splitContainer1.Panel1.Controls.Add(Me.label4)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtType)
        Me.splitContainer1.Panel1.Controls.Add(Me.label3)
        Me.splitContainer1.Panel1.Controls.Add(Me.cboCategory)
        Me.splitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.dgGrid)
        Me.splitContainer1.Size = New System.Drawing.Size(1033, 438)
        Me.splitContainer1.SplitterDistance = 62
        Me.splitContainer1.TabIndex = 145
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(882, 9)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(35, 12)
        Me.lblId.TabIndex = 170
        Me.lblId.Text = "lblId"
        Me.lblId.Visible = False
        '
        'txtCategoryName
        '
        Me.txtCategoryName.BackColor = System.Drawing.SystemColors.Control
        Me.txtCategoryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategoryName.Enabled = False
        Me.txtCategoryName.Location = New System.Drawing.Point(462, 6)
        Me.txtCategoryName.MaxLength = 25
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.Size = New System.Drawing.Size(157, 21)
        Me.txtCategoryName.TabIndex = 2
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(401, 10)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(59, 12)
        Me.label5.TabIndex = 169
        Me.label5.Text = "类别名称:"
        '
        'txtAlertCount
        '
        Me.txtAlertCount.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtAlertCount.Location = New System.Drawing.Point(716, 34)
        Me.txtAlertCount.Name = "txtAlertCount"
        Me.txtAlertCount.Size = New System.Drawing.Size(87, 21)
        Me.txtAlertCount.TabIndex = 5
        Me.txtAlertCount.Tag = "预警次数"
        '
        'txtServiceCount
        '
        Me.txtServiceCount.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtServiceCount.Location = New System.Drawing.Point(716, 7)
        Me.txtServiceCount.Name = "txtServiceCount"
        Me.txtServiceCount.Size = New System.Drawing.Size(87, 21)
        Me.txtServiceCount.TabIndex = 3
        Me.txtServiceCount.Tag = "使用次数"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(634, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 12)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = "默认使用次数:"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(634, 37)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(83, 12)
        Me.label7.TabIndex = 165
        Me.label7.Text = "默认预警次数:"
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescription.Location = New System.Drawing.Point(87, 33)
        Me.txtDescription.MaxLength = 100
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(532, 21)
        Me.txtDescription.TabIndex = 4
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(53, 36)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(35, 12)
        Me.label4.TabIndex = 160
        Me.label4.Text = "描述:"
        '
        'txtType
        '
        Me.txtType.BackColor = System.Drawing.SystemColors.Control
        Me.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtType.Location = New System.Drawing.Point(320, 7)
        Me.txtType.MaxLength = 100
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.Size = New System.Drawing.Size(63, 21)
        Me.txtType.TabIndex = 1
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(261, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(59, 12)
        Me.label3.TabIndex = 158
        Me.label3.Text = "类别编号:"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(87, 7)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(152, 20)
        Me.cboCategory.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 12)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "工治具中分类:"
        '
        'dgGrid
        '
        Me.dgGrid.AllowUserToAddRows = False
        Me.dgGrid.AllowUserToDeleteRows = False
        Me.dgGrid.AllowUserToResizeRows = False
        Me.dgGrid.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgGrid.ColumnHeadersHeight = 28
        Me.dgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODE, Me.CategoryNAME, Me.Description, Me.ServiceCount, Me.AlertCount, Me.RemainCount, Me.TYPEName, Me.Status, Me.UserName, Me.InTime, Me.FactoryName, Me.Profitcenter, Me.ID, Me.TYPECode})
        Me.dgGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgGrid.Location = New System.Drawing.Point(0, 0)
        Me.dgGrid.Name = "dgGrid"
        Me.dgGrid.ReadOnly = True
        Me.dgGrid.RowHeadersWidth = 20
        Me.dgGrid.RowTemplate.Height = 23
        Me.dgGrid.Size = New System.Drawing.Size(1033, 372)
        Me.dgGrid.TabIndex = 149
        '
        'CODE
        '
        Me.CODE.DataPropertyName = "CODE"
        Me.CODE.HeaderText = "类别编号"
        Me.CODE.Name = "CODE"
        Me.CODE.ReadOnly = True
        Me.CODE.Width = 70
        '
        'CategoryNAME
        '
        Me.CategoryNAME.DataPropertyName = "NAME"
        Me.CategoryNAME.HeaderText = "类别名称"
        Me.CategoryNAME.Name = "CategoryNAME"
        Me.CategoryNAME.ReadOnly = True
        Me.CategoryNAME.Width = 120
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "描述"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 150
        '
        'ServiceCount
        '
        Me.ServiceCount.DataPropertyName = "ServiceCount"
        Me.ServiceCount.HeaderText = "默认使用次数"
        Me.ServiceCount.Name = "ServiceCount"
        Me.ServiceCount.ReadOnly = True
        '
        'AlertCount
        '
        Me.AlertCount.DataPropertyName = "AlertCount"
        Me.AlertCount.HeaderText = "默认预警次数"
        Me.AlertCount.Name = "AlertCount"
        Me.AlertCount.ReadOnly = True
        '
        'RemainCount
        '
        Me.RemainCount.DataPropertyName = "RemainCount"
        Me.RemainCount.HeaderText = "默认可用次数"
        Me.RemainCount.Name = "RemainCount"
        Me.RemainCount.ReadOnly = True
        '
        'TYPEName
        '
        Me.TYPEName.DataPropertyName = "TYPEName"
        Me.TYPEName.HeaderText = "工治具类型"
        Me.TYPEName.Name = "TYPEName"
        Me.TYPEName.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "可用否"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 80
        '
        'UserName
        '
        Me.UserName.DataPropertyName = "UserName"
        Me.UserName.HeaderText = "设置人"
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        Me.UserName.Width = 80
        '
        'InTime
        '
        Me.InTime.DataPropertyName = "InTime"
        Me.InTime.HeaderText = "设置时间"
        Me.InTime.Name = "InTime"
        Me.InTime.ReadOnly = True
        Me.InTime.Width = 120
        '
        'FactoryName
        '
        Me.FactoryName.DataPropertyName = "FactoryName"
        Me.FactoryName.HeaderText = "FactoryName"
        Me.FactoryName.Name = "FactoryName"
        Me.FactoryName.ReadOnly = True
        Me.FactoryName.Visible = False
        '
        'Profitcenter
        '
        Me.Profitcenter.DataPropertyName = "Profitcenter"
        Me.Profitcenter.HeaderText = "Profitcenter"
        Me.Profitcenter.Name = "Profitcenter"
        Me.Profitcenter.ReadOnly = True
        Me.Profitcenter.Visible = False
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'TYPECode
        '
        Me.TYPECode.DataPropertyName = "TYPECode"
        Me.TYPECode.HeaderText = "TYPECode"
        Me.TYPECode.Name = "TYPECode"
        Me.TYPECode.ReadOnly = True
        Me.TYPECode.Visible = False
        '
        'FrmEqupmentCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 463)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmEqupmentCategory"
        Me.Text = "工治具－类别参数设置"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        CType(Me.dgGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents toolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtCategoryName As System.Windows.Forms.TextBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents txtAlertCount As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceCount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgGrid As System.Windows.Forms.DataGridView
    Friend WithEvents toolSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CategoryNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlertCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemainCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TYPEName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FactoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Profitcenter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TYPECode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
