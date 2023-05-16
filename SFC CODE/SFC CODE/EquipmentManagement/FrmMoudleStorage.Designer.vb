<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMoudleStorage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMoudleStorage))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolNew = New System.Windows.Forms.ToolStripButton()
        Me.toolModify = New System.Windows.Forms.ToolStripButton()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.chkUseY = New System.Windows.Forms.CheckBox()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtWarehouse = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStorageID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvStorage = New System.Windows.Forms.DataGridView()
        Me.StorageID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Warehouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FactoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvStorage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolNew, Me.toolModify, Me.toolAbandon, Me.ToolStripSeparator1, Me.toolSave, Me.toolBack, Me.toolStripSeparator4, Me.toolQuery, Me.toolStripSeparator3, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(619, 25)
        Me.toolStrip1.TabIndex = 132
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolNew
        '
        Me.toolNew.Image = CType(resources.GetObject("toolNew.Image"), System.Drawing.Image)
        Me.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolNew.Name = "toolNew"
        Me.toolNew.Size = New System.Drawing.Size(74, 22)
        Me.toolNew.Tag = "新 增"
        Me.toolNew.Text = "新 增(&N)"
        '
        'toolModify
        '
        Me.toolModify.Image = CType(resources.GetObject("toolModify.Image"), System.Drawing.Image)
        Me.toolModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModify.Name = "toolModify"
        Me.toolModify.Size = New System.Drawing.Size(71, 22)
        Me.toolModify.Tag = "NO"
        Me.toolModify.Text = "修 改(&E)"
        '
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(73, 22)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "作 废(&D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 22)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(72, 22)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvStorage)
        Me.SplitContainer1.Size = New System.Drawing.Size(619, 297)
        Me.SplitContainer1.SplitterDistance = 72
        Me.SplitContainer1.TabIndex = 133
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbMsg)
        Me.GroupBox1.Controls.Add(Me.chkUseY)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtWarehouse)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtStorageID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.ForeColor = System.Drawing.Color.Red
        Me.lbMsg.Location = New System.Drawing.Point(486, 15)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(0, 12)
        Me.lbMsg.TabIndex = 7
        '
        'chkUseY
        '
        Me.chkUseY.AutoSize = True
        Me.chkUseY.Location = New System.Drawing.Point(488, 46)
        Me.chkUseY.Name = "chkUseY"
        Me.chkUseY.Size = New System.Drawing.Size(72, 16)
        Me.chkUseY.TabIndex = 6
        Me.chkUseY.Text = "是否有效"
        Me.chkUseY.UseVisualStyleBackColor = True
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(54, 44)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(400, 21)
        Me.txtRemark.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "备注："
        '
        'txtWarehouse
        '
        Me.txtWarehouse.Location = New System.Drawing.Point(294, 12)
        Me.txtWarehouse.Name = "txtWarehouse"
        Me.txtWarehouse.Size = New System.Drawing.Size(160, 21)
        Me.txtWarehouse.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(257, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "仓库："
        '
        'txtStorageID
        '
        Me.txtStorageID.Location = New System.Drawing.Point(54, 12)
        Me.txtStorageID.Name = "txtStorageID"
        Me.txtStorageID.Size = New System.Drawing.Size(160, 21)
        Me.txtStorageID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "储位："
        '
        'dgvStorage
        '
        Me.dgvStorage.AllowUserToAddRows = False
        Me.dgvStorage.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStorage.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StorageID, Me.Warehouse, Me.Remark, Me.FactoryID, Me.Usey})
        Me.dgvStorage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStorage.Location = New System.Drawing.Point(0, 0)
        Me.dgvStorage.Name = "dgvStorage"
        Me.dgvStorage.ReadOnly = True
        Me.dgvStorage.RowTemplate.Height = 23
        Me.dgvStorage.Size = New System.Drawing.Size(619, 221)
        Me.dgvStorage.TabIndex = 0
        '
        'StorageID
        '
        Me.StorageID.DataPropertyName = "StorageID"
        Me.StorageID.HeaderText = "储位"
        Me.StorageID.Name = "StorageID"
        Me.StorageID.ReadOnly = True
        '
        'Warehouse
        '
        Me.Warehouse.DataPropertyName = "Warehouse"
        Me.Warehouse.HeaderText = "仓库"
        Me.Warehouse.Name = "Warehouse"
        Me.Warehouse.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 160
        '
        'FactoryID
        '
        Me.FactoryID.DataPropertyName = "FactoryID"
        Me.FactoryID.HeaderText = "厂区"
        Me.FactoryID.Name = "FactoryID"
        Me.FactoryID.ReadOnly = True
        '
        'Usey
        '
        Me.Usey.DataPropertyName = "Usey"
        Me.Usey.HeaderText = "有效否"
        Me.Usey.Name = "Usey"
        Me.Usey.ReadOnly = True
        Me.Usey.Width = 70
        '
        'FrmMoudleStorage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 322)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmMoudleStorage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "模具储位信息"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvStorage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModify As System.Windows.Forms.ToolStripButton
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtWarehouse As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStorageID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvStorage As System.Windows.Forms.DataGridView
    Friend WithEvents chkUseY As System.Windows.Forms.CheckBox
    Friend WithEvents lbMsg As System.Windows.Forms.Label
    Friend WithEvents StorageID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Warehouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FactoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usey As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
