<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEquMaintenanceType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEquMaintenanceType))
        Me.ckIsMpQuarter = New System.Windows.Forms.CheckBox()
        Me.ckIsMpDay = New System.Windows.Forms.CheckBox()
        Me.cbAssetName = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvMaintenanceType = New System.Windows.Forms.DataGridView()
        Me.ckIsMpMonth = New System.Windows.Forms.CheckBox()
        Me.txtMaintenanceProject = New System.Windows.Forms.RichTextBox()
        Me.btnExit = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbRowAount = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvMaintenanceType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ckIsMpQuarter
        '
        Me.ckIsMpQuarter.AutoSize = True
        Me.ckIsMpQuarter.Location = New System.Drawing.Point(445, 16)
        Me.ckIsMpQuarter.Name = "ckIsMpQuarter"
        Me.ckIsMpQuarter.Size = New System.Drawing.Size(60, 16)
        Me.ckIsMpQuarter.TabIndex = 13
        Me.ckIsMpQuarter.Text = "季保养"
        Me.ckIsMpQuarter.UseVisualStyleBackColor = True
        '
        'ckIsMpDay
        '
        Me.ckIsMpDay.AutoSize = True
        Me.ckIsMpDay.Location = New System.Drawing.Point(274, 16)
        Me.ckIsMpDay.Name = "ckIsMpDay"
        Me.ckIsMpDay.Size = New System.Drawing.Size(60, 16)
        Me.ckIsMpDay.TabIndex = 11
        Me.ckIsMpDay.Text = "日保养"
        Me.ckIsMpDay.UseVisualStyleBackColor = True
        '
        'cbAssetName
        '
        Me.cbAssetName.FormattingEnabled = True
        Me.cbAssetName.Location = New System.Drawing.Point(71, 14)
        Me.cbAssetName.Name = "cbAssetName"
        Me.cbAssetName.Size = New System.Drawing.Size(172, 20)
        Me.cbAssetName.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "设备类型"
        '
        'dgvMaintenanceType
        '
        Me.dgvMaintenanceType.AllowUserToAddRows = False
        Me.dgvMaintenanceType.AllowUserToDeleteRows = False
        Me.dgvMaintenanceType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaintenanceType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column6, Me.Column8, Me.Column7, Me.Column4, Me.Column5, Me.Column9})
        Me.dgvMaintenanceType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaintenanceType.Location = New System.Drawing.Point(0, 122)
        Me.dgvMaintenanceType.Name = "dgvMaintenanceType"
        Me.dgvMaintenanceType.RowTemplate.Height = 23
        Me.dgvMaintenanceType.Size = New System.Drawing.Size(821, 472)
        Me.dgvMaintenanceType.TabIndex = 52
        '
        'ckIsMpMonth
        '
        Me.ckIsMpMonth.AutoSize = True
        Me.ckIsMpMonth.Location = New System.Drawing.Point(361, 16)
        Me.ckIsMpMonth.Name = "ckIsMpMonth"
        Me.ckIsMpMonth.Size = New System.Drawing.Size(60, 16)
        Me.ckIsMpMonth.TabIndex = 12
        Me.ckIsMpMonth.Text = "月保养"
        Me.ckIsMpMonth.UseVisualStyleBackColor = True
        '
        'txtMaintenanceProject
        '
        Me.txtMaintenanceProject.Location = New System.Drawing.Point(71, 40)
        Me.txtMaintenanceProject.MaxLength = 500
        Me.txtMaintenanceProject.Name = "txtMaintenanceProject"
        Me.txtMaintenanceProject.Size = New System.Drawing.Size(687, 53)
        Me.txtMaintenanceProject.TabIndex = 15
        Me.txtMaintenanceProject.Text = ""
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(73, 20)
        Me.btnExit.Text = "退 出(&X)"
        Me.btnExit.ToolTipText = "退出"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbMsg)
        Me.Panel1.Controls.Add(Me.txtMaintenanceProject)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ckIsMpQuarter)
        Me.Panel1.Controls.Add(Me.ckIsMpMonth)
        Me.Panel1.Controls.Add(Me.ckIsMpDay)
        Me.Panel1.Controls.Add(Me.cbAssetName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(821, 99)
        Me.Panel1.TabIndex = 51
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.ForeColor = System.Drawing.Color.Red
        Me.lbMsg.Location = New System.Drawing.Point(526, 18)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(0, 12)
        Me.lbMsg.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "保养项目"
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnNew, Me.ToolStripSeparator2, Me.btnModify, Me.ToolStripSeparator4, Me.btnDelete, Me.ToolStripSeparator5, Me.btnSave, Me.ToolStripSeparator3, Me.btnUndo, Me.ToolStripSeparator6, Me.btnSearch, Me.ToolStripSeparator7, Me.btnRefresh, Me.ToolStripSeparator8, Me.btnExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(821, 23)
        Me.ToolBt.TabIndex = 50
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnNew
        '
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(73, 20)
        Me.btnNew.Tag = "新增"
        Me.btnNew.Text = "新 增(&N)"
        Me.btnNew.ToolTipText = "新增"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'btnModify
        '
        Me.btnModify.Image = CType(resources.GetObject("btnModify.Image"), System.Drawing.Image)
        Me.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(73, 20)
        Me.btnModify.Tag = "修改"
        Me.btnModify.Text = "修 改(&E)"
        Me.btnModify.ToolTipText = "修 改"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(49, 20)
        Me.btnDelete.Text = "删除"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(73, 20)
        Me.btnSave.Text = "保 存(&S)"
        Me.btnSave.ToolTipText = "保存"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnUndo
        '
        Me.btnUndo.Enabled = False
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(67, 20)
        Me.btnUndo.Text = "返回(&C)"
        Me.btnUndo.ToolTipText = "返回"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(73, 20)
        Me.btnSearch.Text = "查 找(&F)"
        Me.btnSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(73, 20)
        Me.btnRefresh.Text = "刷 新(&R)"
        Me.btnRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lbRowAount)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 594)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(821, 25)
        Me.Panel2.TabIndex = 53
        '
        'lbRowAount
        '
        Me.lbRowAount.AutoSize = True
        Me.lbRowAount.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbRowAount.Location = New System.Drawing.Point(49, 8)
        Me.lbRowAount.Name = "lbRowAount"
        Me.lbRowAount.Size = New System.Drawing.Size(0, 12)
        Me.lbRowAount.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "总笔数:"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "AssetName"
        Me.Column2.HeaderText = "设备类型"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "MaintenanceProject"
        Me.Column3.HeaderText = "保养项目"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 200
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "IsMpDay"
        Me.Column6.HeaderText = "日保养"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 65
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "IsMpMonth"
        Me.Column8.HeaderText = "月保养"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 65
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "IsMpQuarter"
        Me.Column7.HeaderText = "季保养"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 65
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "UserName"
        Me.Column4.HeaderText = "创建人"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "CreateTime"
        Me.Column5.HeaderText = "创建时间"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 339
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "ID"
        Me.Column9.HeaderText = "ID"
        Me.Column9.Name = "Column9"
        Me.Column9.Visible = False
        '
        'FrmEquMaintenanceType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 619)
        Me.Controls.Add(Me.dgvMaintenanceType)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmEquMaintenanceType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "设备保养项目维护(MJ)"
        CType(Me.dgvMaintenanceType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ckIsMpQuarter As System.Windows.Forms.CheckBox
    Friend WithEvents ckIsMpDay As System.Windows.Forms.CheckBox
    Friend WithEvents cbAssetName As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvMaintenanceType As System.Windows.Forms.DataGridView
    Friend WithEvents ckIsMpMonth As System.Windows.Forms.CheckBox
    Friend WithEvents txtMaintenanceProject As System.Windows.Forms.RichTextBox
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbMsg As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbRowAount As System.Windows.Forms.Label
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
