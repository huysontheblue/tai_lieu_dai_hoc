<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLocaion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLocaion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.toolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolBack = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkUsey = New System.Windows.Forms.CheckBox()
        Me.txtLocationID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLocationName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvView = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LocationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocationName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.toolStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.toolEdit, Me.toolAbandon, Me.ToolStripSeparator1, Me.toolSave, Me.toolBack, Me.toolStripSeparator4, Me.toolQuery, Me.ToolStripSeparator2, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(4, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(845, 21)
        Me.toolStrip1.TabIndex = 30
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 18)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        '
        'toolEdit
        '
        Me.toolEdit.Image = CType(resources.GetObject("toolEdit.Image"), System.Drawing.Image)
        Me.toolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEdit.Name = "toolEdit"
        Me.toolEdit.Size = New System.Drawing.Size(71, 18)
        Me.toolEdit.Tag = "NO"
        Me.toolEdit.Text = "修 改(&E)"
        '
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(73, 18)
        Me.toolAbandon.Tag = "NO"
        Me.toolAbandon.Text = "作 废(&D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 21)
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(73, 18)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保 存(&S)"
        '
        'toolBack
        '
        Me.toolBack.Image = CType(resources.GetObject("toolBack.Image"), System.Drawing.Image)
        Me.toolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBack.Name = "toolBack"
        Me.toolBack.Size = New System.Drawing.Size(72, 18)
        Me.toolBack.Tag = ""
        Me.toolBack.Text = "返 回(&B)"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 21)
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 18)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 21)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 18)
        Me.toolExit.Text = "退 出(&X)"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvView)
        Me.SplitContainer1.Size = New System.Drawing.Size(845, 374)
        Me.SplitContainer1.SplitterDistance = 55
        Me.SplitContainer1.TabIndex = 31
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbMsg)
        Me.GroupBox1.Controls.Add(Me.ChkUsey)
        Me.GroupBox1.Controls.Add(Me.txtLocationID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtLocationName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(845, 55)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'ChkUsey
        '
        Me.ChkUsey.AutoSize = True
        Me.ChkUsey.Location = New System.Drawing.Point(435, 21)
        Me.ChkUsey.Name = "ChkUsey"
        Me.ChkUsey.Size = New System.Drawing.Size(48, 16)
        Me.ChkUsey.TabIndex = 26
        Me.ChkUsey.Text = "启用"
        Me.ChkUsey.UseVisualStyleBackColor = True
        '
        'txtLocationID
        '
        Me.txtLocationID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLocationID.Location = New System.Drawing.Point(73, 20)
        Me.txtLocationID.MaxLength = 20
        Me.txtLocationID.Name = "txtLocationID"
        Me.txtLocationID.Size = New System.Drawing.Size(110, 21)
        Me.txtLocationID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "仓库代码："
        '
        'txtLocationName
        '
        Me.txtLocationName.AcceptsReturn = True
        Me.txtLocationName.Location = New System.Drawing.Point(266, 19)
        Me.txtLocationName.MaxLength = 20
        Me.txtLocationName.Name = "txtLocationName"
        Me.txtLocationName.Size = New System.Drawing.Size(140, 21)
        Me.txtLocationName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(204, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "仓库名称："
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.AllowUserToOrderColumns = True
        Me.dgvView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LocationID, Me.LocationName, Me.Usey, Me.UserId, Me.Intime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvView.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvView.EnableHeadersVisualStyles = False
        Me.dgvView.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvView.Location = New System.Drawing.Point(0, 0)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvView.RowHeadersWidth = 4
        Me.dgvView.RowTemplate.Height = 23
        Me.dgvView.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvView.Size = New System.Drawing.Size(845, 315)
        Me.dgvView.TabIndex = 11
        '
        'LocationID
        '
        Me.LocationID.DataPropertyName = "LocationID"
        Me.LocationID.HeaderText = "仓库代码"
        Me.LocationID.Name = "LocationID"
        Me.LocationID.ReadOnly = True
        Me.LocationID.Width = 120
        '
        'LocationName
        '
        Me.LocationName.DataPropertyName = "LocationName"
        Me.LocationName.HeaderText = "仓库名称"
        Me.LocationName.Name = "LocationName"
        Me.LocationName.ReadOnly = True
        Me.LocationName.Width = 120
        '
        'Usey
        '
        Me.Usey.DataPropertyName = "Usey"
        Me.Usey.HeaderText = "有效否"
        Me.Usey.Name = "Usey"
        Me.Usey.ReadOnly = True
        Me.Usey.Width = 80
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        Me.UserId.HeaderText = "操作用户"
        Me.UserId.Name = "UserId"
        Me.UserId.ReadOnly = True
        Me.UserId.Width = 120
        '
        'Intime
        '
        Me.Intime.DataPropertyName = "Intime"
        Me.Intime.HeaderText = "时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        Me.Intime.Width = 130
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.ForeColor = System.Drawing.Color.Red
        Me.lbMsg.Location = New System.Drawing.Point(514, 25)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(0, 12)
        Me.lbMsg.TabIndex = 27
        '
        'FrmLocaion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 397)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmLocaion"
        Me.Text = "仓库维护"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBack As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkUsey As System.Windows.Forms.CheckBox
    Friend WithEvents txtLocationID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLocationName As System.Windows.Forms.TextBox
    Friend WithEvents dgvView As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LocationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocationName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbMsg As System.Windows.Forms.Label
End Class
