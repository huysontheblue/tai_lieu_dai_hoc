<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLeader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLeader))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolNew = New System.Windows.Forms.ToolStripButton()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.toolUndo = New System.Windows.Forms.ToolStripButton()
        Me.toolSearch = New System.Windows.Forms.ToolStripButton()
        Me.toolRefresh = New System.Windows.Forms.ToolStripButton()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabEquipment = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvName = New System.Windows.Forms.DataGridView()
        Me.用户 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.姓名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.工厂 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.创建人 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.创建时间 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabEquipment.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolNew, Me.toolUndo, Me.toolSave, Me.toolSearch, Me.toolRefresh, Me.toolDelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1609, 27)
        Me.ToolStrip1.TabIndex = 233
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolNew
        '
        Me.toolNew.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolNew.Image = CType(resources.GetObject("toolNew.Image"), System.Drawing.Image)
        Me.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolNew.Name = "toolNew"
        Me.toolNew.Size = New System.Drawing.Size(127, 24)
        Me.toolNew.Tag = "新增"
        Me.toolNew.Text = "Thêm 新 增(&N)"
        Me.toolNew.ToolTipText = "新增"
        '
        'toolSave
        '
        Me.toolSave.Enabled = False
        Me.toolSave.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(110, 24)
        Me.toolSave.Text = "Lưu保 存(&S)"
        Me.toolSave.ToolTipText = "保存"
        '
        'toolUndo
        '
        Me.toolUndo.Enabled = False
        Me.toolUndo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolUndo.Image = CType(resources.GetObject("toolUndo.Image"), System.Drawing.Image)
        Me.toolUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolUndo.Name = "toolUndo"
        Me.toolUndo.Size = New System.Drawing.Size(122, 24)
        Me.toolUndo.Text = "Trở lại返回(&C)"
        Me.toolUndo.ToolTipText = "返回"
        '
        'toolSearch
        '
        Me.toolSearch.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolSearch.Image = CType(resources.GetObject("toolSearch.Image"), System.Drawing.Image)
        Me.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSearch.Name = "toolSearch"
        Me.toolSearch.Size = New System.Drawing.Size(141, 24)
        Me.toolSearch.Text = "Tìm kiếm查 找(&F)"
        Me.toolSearch.ToolTipText = "查找"
        '
        'toolRefresh
        '
        Me.toolRefresh.Enabled = False
        Me.toolRefresh.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolRefresh.Image = CType(resources.GetObject("toolRefresh.Image"), System.Drawing.Image)
        Me.toolRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.toolRefresh.Name = "toolRefresh"
        Me.toolRefresh.Size = New System.Drawing.Size(141, 24)
        Me.toolRefresh.Text = "Làm mới刷 新(&R)"
        Me.toolRefresh.ToolTipText = "刷新"
        '
        'toolDelete
        '
        Me.toolDelete.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(113, 24)
        Me.toolDelete.Tag = "删 除"
        Me.toolDelete.Text = "Xóa删 除(&D)"
        Me.toolDelete.ToolTipText = "刪除"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SplitContainer1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 27)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1609, 644)
        Me.GroupBox1.TabIndex = 234
        Me.GroupBox1.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 23)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtuser)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabEquipment)
        Me.SplitContainer1.Size = New System.Drawing.Size(1601, 616)
        Me.SplitContainer1.SplitterDistance = 48
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 0
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(109, 9)
        Me.txtuser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtuser.MaxLength = 20
        Me.txtuser.Name = "txtuser"
        Me.txtuser.ReadOnly = True
        Me.txtuser.Size = New System.Drawing.Size(193, 25)
        Me.txtuser.TabIndex = 105
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 34)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Mã công đơn" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "工号:"
        '
        'TabEquipment
        '
        Me.TabEquipment.Controls.Add(Me.TabPage4)
        Me.TabEquipment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabEquipment.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabEquipment.Location = New System.Drawing.Point(0, 0)
        Me.TabEquipment.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabEquipment.Name = "TabEquipment"
        Me.TabEquipment.SelectedIndex = 0
        Me.TabEquipment.Size = New System.Drawing.Size(1601, 562)
        Me.TabEquipment.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvName)
        Me.TabPage4.Location = New System.Drawing.Point(4, 26)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabPage4.Size = New System.Drawing.Size(1593, 532)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Thông tin nhân viên人员信息"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvName
        '
        Me.dgvName.AllowUserToAddRows = False
        Me.dgvName.BackgroundColor = System.Drawing.Color.White
        Me.dgvName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvName.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.用户, Me.姓名, Me.工厂, Me.创建人, Me.创建时间})
        Me.dgvName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvName.Location = New System.Drawing.Point(4, 5)
        Me.dgvName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvName.MultiSelect = False
        Me.dgvName.Name = "dgvName"
        Me.dgvName.RowHeadersVisible = False
        Me.dgvName.RowTemplate.Height = 23
        Me.dgvName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvName.Size = New System.Drawing.Size(1585, 522)
        Me.dgvName.TabIndex = 1
        '
        '用户
        '
        Me.用户.DataPropertyName = "UserID"
        Me.用户.Frozen = True
        Me.用户.HeaderText = "Mã Người dùng 用户"
        Me.用户.Name = "用户"
        Me.用户.Width = 200
        '
        '姓名
        '
        Me.姓名.DataPropertyName = "UserName"
        Me.姓名.Frozen = True
        Me.姓名.HeaderText = "Tên 姓名"
        Me.姓名.Name = "姓名"
        Me.姓名.Width = 200
        '
        '工厂
        '
        Me.工厂.DataPropertyName = "FactoryID"
        Me.工厂.HeaderText = "Nhà xưởng工厂"
        Me.工厂.Name = "工厂"
        Me.工厂.Width = 200
        '
        '创建人
        '
        Me.创建人.DataPropertyName = "Creater"
        Me.创建人.FillWeight = 200.0!
        Me.创建人.HeaderText = "Người tạo创建人"
        Me.创建人.Name = "创建人"
        Me.创建人.Width = 200
        '
        '创建时间
        '
        Me.创建时间.DataPropertyName = "Intime"
        Me.创建时间.HeaderText = "Thời gian tạo创建时间"
        Me.创建时间.Name = "创建时间"
        Me.创建时间.Width = 200
        '
        'FrmLeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1609, 671)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmLeader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quản lý người nhận 领用人管理"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabEquipment.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents toolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtuser As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabEquipment As System.Windows.Forms.TabControl
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents dgvName As System.Windows.Forms.DataGridView
    Friend WithEvents 用户 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 姓名 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 工厂 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 创建人 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 创建时间 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
