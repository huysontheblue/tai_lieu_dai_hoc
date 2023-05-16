<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIssueTrace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIssueTrace))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnExit = New System.Windows.Forms.ToolStripButton()
        Me.DgvIssue = New System.Windows.Forms.DataGridView()
        Me.Items = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Factory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Issue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactTel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtItems = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtContactUser = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CobStatus = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStrip.SuspendLayout()
        CType(Me.DgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip
        '
        Me.toolStrip.AutoSize = False
        Me.toolStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.BtnSearch, Me.ToolStripSeparator7, Me.ToolStripSeparator2, Me.BtnExit})
        Me.toolStrip.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip.Name = "toolStrip"
        Me.toolStrip.Size = New System.Drawing.Size(983, 23)
        Me.toolStrip.TabIndex = 174
        Me.toolStrip.TabStop = True
        Me.toolStrip.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'BtnSearch
        '
        Me.BtnSearch.Image = CType(resources.GetObject("BtnSearch.Image"), System.Drawing.Image)
        Me.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(70, 20)
        Me.BtnSearch.Text = "查 找(&F)"
        Me.BtnSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'BtnExit
        '
        Me.BtnExit.Image = CType(resources.GetObject("BtnExit.Image"), System.Drawing.Image)
        Me.BtnExit.ImageTransparentColor = System.Drawing.Color.White
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(72, 20)
        Me.BtnExit.Text = "退 出(&X)"
        Me.BtnExit.ToolTipText = "退出"
        '
        'DgvIssue
        '
        Me.DgvIssue.AllowUserToAddRows = False
        Me.DgvIssue.AllowUserToDeleteRows = False
        Me.DgvIssue.AllowUserToOrderColumns = True
        Me.DgvIssue.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DgvIssue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvIssue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvIssue.BackgroundColor = System.Drawing.Color.White
        Me.DgvIssue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvIssue.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvIssue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgvIssue.ColumnHeadersHeight = 24
        Me.DgvIssue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Items, Me.Factory, Me.Type, Me.Issue, Me.Status, Me.CreateDate, Me.ContactUser, Me.ContactTel, Me.ContactEmail})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvIssue.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgvIssue.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgvIssue.Location = New System.Drawing.Point(0, 139)
        Me.DgvIssue.MultiSelect = False
        Me.DgvIssue.Name = "DgvIssue"
        Me.DgvIssue.ReadOnly = True
        Me.DgvIssue.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvIssue.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgvIssue.RowHeadersVisible = False
        Me.DgvIssue.RowHeadersWidth = 4
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.DgvIssue.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DgvIssue.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgvIssue.RowTemplate.Height = 24
        Me.DgvIssue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgvIssue.ShowEditingIcon = False
        Me.DgvIssue.Size = New System.Drawing.Size(983, 327)
        Me.DgvIssue.TabIndex = 176
        Me.DgvIssue.TabStop = False
        '
        'Items
        '
        Me.Items.DataPropertyName = "Items"
        Me.Items.HeaderText = "咨询编号"
        Me.Items.Name = "Items"
        Me.Items.ReadOnly = True
        '
        'Factory
        '
        Me.Factory.DataPropertyName = "Factory"
        Me.Factory.HeaderText = "厂区"
        Me.Factory.Name = "Factory"
        Me.Factory.ReadOnly = True
        '
        'Type
        '
        Me.Type.DataPropertyName = "Type"
        Me.Type.HeaderText = "类别"
        Me.Type.Name = "Type"
        Me.Type.ReadOnly = True
        '
        'Issue
        '
        Me.Issue.DataPropertyName = "Issue"
        Me.Issue.HeaderText = "问题摘要"
        Me.Issue.Name = "Issue"
        Me.Issue.ReadOnly = True
        Me.Issue.Width = 300
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "状态"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'CreateDate
        '
        Me.CreateDate.DataPropertyName = "CreateDate"
        Me.CreateDate.HeaderText = "咨询时间"
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.ReadOnly = True
        '
        'ContactUser
        '
        Me.ContactUser.DataPropertyName = "ContactUser"
        Me.ContactUser.HeaderText = "联系人"
        Me.ContactUser.Name = "ContactUser"
        Me.ContactUser.ReadOnly = True
        '
        'ContactTel
        '
        Me.ContactTel.DataPropertyName = "ContactTel"
        Me.ContactTel.HeaderText = "联系电话"
        Me.ContactTel.Name = "ContactTel"
        Me.ContactTel.ReadOnly = True
        '
        'ContactEmail
        '
        Me.ContactEmail.DataPropertyName = "ContactEmail"
        Me.ContactEmail.HeaderText = "邮件地址"
        Me.ContactEmail.Name = "ContactEmail"
        Me.ContactEmail.ReadOnly = True
        '
        'TxtItems
        '
        Me.TxtItems.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.TxtItems.Location = New System.Drawing.Point(70, 39)
        Me.TxtItems.Name = "TxtItems"
        Me.TxtItems.Size = New System.Drawing.Size(106, 21)
        Me.TxtItems.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 178
        Me.Label4.Text = "邮件地址:"
        '
        'TxtEmail
        '
        Me.TxtEmail.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.TxtEmail.Location = New System.Drawing.Point(70, 93)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(257, 21)
        Me.TxtEmail.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(23, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 12)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "联系人:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(11, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 181
        Me.Label2.Text = "咨询编号:"
        '
        'TxtContactUser
        '
        Me.TxtContactUser.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.TxtContactUser.Location = New System.Drawing.Point(70, 66)
        Me.TxtContactUser.Name = "TxtContactUser"
        Me.TxtContactUser.Size = New System.Drawing.Size(106, 21)
        Me.TxtContactUser.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(377, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 183
        Me.Label3.Text = "状态:"
        '
        'CobStatus
        '
        Me.CobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobStatus.FormattingEnabled = True
        Me.CobStatus.Items.AddRange(New Object() {"All", "0.新开立", "1.进行中", "2.完成"})
        Me.CobStatus.Location = New System.Drawing.Point(419, 93)
        Me.CobStatus.Name = "CobStatus"
        Me.CobStatus.Size = New System.Drawing.Size(121, 20)
        Me.CobStatus.TabIndex = 4
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 467)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(983, 22)
        Me.StatusStrip1.TabIndex = 185
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(68, 17)
        Me.StatusLabel.Text = "记录笔数："
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "咨询编号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "类别"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "问题摘要"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "咨询时间"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "联系人"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "联系电话"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "邮件地址"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'FrmIssueTrace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 489)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CobStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtItems)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtContactUser)
        Me.Controls.Add(Me.DgvIssue)
        Me.Controls.Add(Me.toolStrip)
        Me.Name = "FrmIssueTrace"
        Me.Text = "问题进度查询"
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        CType(Me.DgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DgvIssue As System.Windows.Forms.DataGridView
    Friend WithEvents TxtItems As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtContactUser As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CobStatus As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Items As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Factory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Issue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactTel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactEmail As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
