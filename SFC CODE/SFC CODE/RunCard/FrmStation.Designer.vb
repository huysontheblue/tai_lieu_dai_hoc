<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStation))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim PageDataGridPager1 As Pager.PageDataGridPager = New Pager.PageDataGridPager
        Me.toolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnNew = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnModify = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.btnUndo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSearch = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.dgvStation = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.PagerPaging = New Pager.PagerPaging
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.lblId = New System.Windows.Forms.Label
        Me.txtStationName = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.cboStationType = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboReportType = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboSkillCode = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboSection = New System.Windows.Forms.ComboBox
        Me.txtStationNo = New System.Windows.Forms.TextBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmiCopyRecord = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStrip.SuspendLayout()
        CType(Me.dgvStation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip
        '
        Me.toolStrip.AutoSize = False
        Me.toolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnNew, Me.ToolStripSeparator4, Me.btnModify, Me.ToolStripSeparator5, Me.btnSave, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator8, Me.btnUndo, Me.ToolStripSeparator6, Me.btnSearch, Me.ToolStripSeparator3, Me.btnRefresh, Me.ToolStripSeparator7, Me.btnExit})
        Me.toolStrip.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.Size = New System.Drawing.Size(1311, 23)
        Me.toolStrip.TabIndex = 45
        Me.toolStrip.TabStop = True
        Me.toolStrip.Text = "ToolStrip1"
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
        Me.btnNew.Size = New System.Drawing.Size(74, 20)
        Me.btnNew.Tag = "新增"
        Me.btnNew.Text = "新 增(&N)"
        Me.btnNew.ToolTipText = "新增"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'btnModify
        '
        Me.btnModify.Image = CType(resources.GetObject("btnModify.Image"), System.Drawing.Image)
        Me.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(71, 20)
        Me.btnModify.Tag = "修改"
        Me.btnModify.Text = "修 改(&E)"
        Me.btnModify.ToolTipText = "修 改"
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
        Me.btnSave.Size = New System.Drawing.Size(71, 20)
        Me.btnSave.Text = "保 存(&S)"
        Me.btnSave.ToolTipText = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(69, 20)
        Me.btnDelete.Text = "删除(&D)"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
        '
        'btnUndo
        '
        Me.btnUndo.Enabled = False
        Me.btnUndo.Image = CType(resources.GetObject("btnUndo.Image"), System.Drawing.Image)
        Me.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(68, 20)
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
        Me.btnSearch.Size = New System.Drawing.Size(70, 20)
        Me.btnSearch.Text = "查 找(&F)"
        Me.btnSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 20)
        Me.btnRefresh.Text = "刷 新(&R)"
        Me.btnRefresh.ToolTipText = "刷新"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
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
        'dgvStation
        '
        Me.dgvStation.AllowUserToAddRows = False
        Me.dgvStation.AllowUserToDeleteRows = False
        Me.dgvStation.BackgroundColor = System.Drawing.Color.White
        Me.dgvStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStation.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStation.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvStation.Location = New System.Drawing.Point(0, 101)
        Me.dgvStation.MultiSelect = False
        Me.dgvStation.Name = "dgvStation"
        Me.dgvStation.ReadOnly = True
        Me.dgvStation.RowHeadersVisible = False
        Me.dgvStation.RowHeadersWidth = 25
        Me.dgvStation.RowTemplate.Height = 23
        Me.dgvStation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvStation.Size = New System.Drawing.Size(1307, 280)
        Me.dgvStation.TabIndex = 50
        '
        'PagerPaging
        '
        Me.PagerPaging.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.PagerPaging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PagerPaging.Location = New System.Drawing.Point(257, 387)
        Me.PagerPaging.Name = "PagerPaging"
        PageDataGridPager1.DataGrid = Nothing
        PageDataGridPager1.PageSize = 10
        PageDataGridPager1.PageSizes = New Integer() {10, 20, 50, 100, 500, 1000}
        PageDataGridPager1.Sort = ""
        Me.PagerPaging.PagerGrid = PageDataGridPager1
        Me.PagerPaging.Size = New System.Drawing.Size(767, 29)
        Me.PagerPaging.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(992, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "状 态:"
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.White
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"0:无效", "1:有效"})
        Me.cboStatus.Location = New System.Drawing.Point(1032, 15)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(84, 20)
        Me.cboStatus.TabIndex = 9
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(1272, 18)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(35, 12)
        Me.lblId.TabIndex = 69
        Me.lblId.Text = "lblId"
        Me.lblId.Visible = False
        '
        'txtStationName
        '
        Me.txtStationName.AcceptsReturn = True
        Me.txtStationName.Location = New System.Drawing.Point(218, 17)
        Me.txtStationName.MaxLength = 20
        Me.txtStationName.Name = "txtStationName"
        Me.txtStationName.Size = New System.Drawing.Size(151, 21)
        Me.txtStationName.TabIndex = 71
        Me.txtStationName.Tag = "工站名称"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1125, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "描述:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "工站名称:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "工站编号:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(375, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "工站类别:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(1160, 14)
        Me.txtDescription.MaxLength = 50
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(107, 21)
        Me.txtDescription.TabIndex = 72
        Me.txtDescription.Tag = "描述"
        '
        'cboStationType
        '
        Me.cboStationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStationType.FormattingEnabled = True
        Me.cboStationType.Items.AddRange(New Object() {""})
        Me.cboStationType.Location = New System.Drawing.Point(434, 16)
        Me.cboStationType.Name = "cboStationType"
        Me.cboStationType.Size = New System.Drawing.Size(126, 20)
        Me.cboStationType.TabIndex = 77
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboReportType)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cboSkillCode)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cboSection)
        Me.GroupBox1.Controls.Add(Me.cboStationType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.txtStationNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtStationName)
        Me.GroupBox1.Controls.Add(Me.lblId)
        Me.GroupBox1.Controls.Add(Me.cboStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 23)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Size = New System.Drawing.Size(1311, 75)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        '
        'cboReportType
        '
        Me.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Location = New System.Drawing.Point(84, 51)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(150, 20)
        Me.cboReportType.TabIndex = 83
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 12)
        Me.Label8.TabIndex = 82
        Me.Label8.Text = "品质报表类型:"
        '
        'cboSkillCode
        '
        Me.cboSkillCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSkillCode.FormattingEnabled = True
        Me.cboSkillCode.Location = New System.Drawing.Point(840, 16)
        Me.cboSkillCode.Name = "cboSkillCode"
        Me.cboSkillCode.Size = New System.Drawing.Size(146, 20)
        Me.cboSkillCode.TabIndex = 81
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(757, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 12)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "岗位技能代码:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(571, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "所属工段:"
        '
        'cboSection
        '
        Me.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSection.FormattingEnabled = True
        Me.cboSection.Items.AddRange(New Object() {""})
        Me.cboSection.Location = New System.Drawing.Point(630, 16)
        Me.cboSection.Name = "cboSection"
        Me.cboSection.Size = New System.Drawing.Size(116, 20)
        Me.cboSection.TabIndex = 78
        '
        'txtStationNo
        '
        Me.txtStationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStationNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStationNo.ForeColor = System.Drawing.Color.Blue
        Me.txtStationNo.Location = New System.Drawing.Point(63, 16)
        Me.txtStationNo.MaxLength = 6
        Me.txtStationNo.Name = "txtStationNo"
        Me.txtStationNo.Size = New System.Drawing.Size(89, 21)
        Me.txtStationNo.TabIndex = 70
        Me.txtStationNo.Tag = "工站编号"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCopy, Me.tsmiCopyRecord})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(141, 48)
        '
        'tsmiCopy
        '
        Me.tsmiCopy.Image = CType(resources.GetObject("tsmiCopy.Image"), System.Drawing.Image)
        Me.tsmiCopy.Name = "tsmiCopy"
        Me.tsmiCopy.Size = New System.Drawing.Size(140, 22)
        Me.tsmiCopy.Tag = "复制"
        Me.tsmiCopy.Text = "复制(&C)"
        '
        'tsmiCopyRecord
        '
        Me.tsmiCopyRecord.Image = CType(resources.GetObject("tsmiCopyRecord.Image"), System.Drawing.Image)
        Me.tsmiCopyRecord.Name = "tsmiCopyRecord"
        Me.tsmiCopyRecord.Size = New System.Drawing.Size(140, 22)
        Me.tsmiCopyRecord.Tag = "复制记录"
        Me.tsmiCopyRecord.Text = "复制记录(&R)"
        '
        'FrmStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1311, 428)
        Me.Controls.Add(Me.dgvStation)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PagerPaging)
        Me.Controls.Add(Me.toolStrip)
        Me.Name = "FrmStationModule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "工站基本资料"
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        CType(Me.dgvStation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvStation As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtStationName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents cboStationType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStationNo As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmiCopyRecord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSection As System.Windows.Forms.ComboBox
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PagerPaging As Pager.PagerPaging
    Friend WithEvents cboSkillCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboReportType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
