<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMsgEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMsgEdit))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TsbNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbUpdate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbReturn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.TsbView = New System.Windows.Forms.ToolStripButton()
        Me.TsbPublish = New System.Windows.Forms.ToolStripButton()
        Me.TsbPublishCancle = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsbRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAdv = New System.Windows.Forms.ToolStripButton()
        Me.TsbClose = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DtEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DtStar = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.CkbUsey = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgvShowTb = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contents = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.URL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtstart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtends = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgvShowTb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsbNew, Me.ToolStripSeparator5, Me.TsbUpdate, Me.ToolStripSeparator4, Me.TsbSave, Me.ToolStripSeparator3, Me.TsbReturn, Me.ToolStripSeparator7, Me.TsbDelete, Me.TsbView, Me.TsbPublish, Me.TsbPublishCancle, Me.ToolStripSeparator1, Me.TsbQuery, Me.ToolStripSeparator6, Me.TsbRefresh, Me.ToolStripSeparator2, Me.toolAdv, Me.TsbClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(754, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TsbNew
        '
        Me.TsbNew.Image = CType(resources.GetObject("TsbNew.Image"), System.Drawing.Image)
        Me.TsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbNew.Name = "TsbNew"
        Me.TsbNew.Size = New System.Drawing.Size(70, 22)
        Me.TsbNew.Text = "新增(&N)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'TsbUpdate
        '
        Me.TsbUpdate.Image = CType(resources.GetObject("TsbUpdate.Image"), System.Drawing.Image)
        Me.TsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbUpdate.Name = "TsbUpdate"
        Me.TsbUpdate.Size = New System.Drawing.Size(69, 22)
        Me.TsbUpdate.Text = "修改(&U)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'TsbSave
        '
        Me.TsbSave.Image = CType(resources.GetObject("TsbSave.Image"), System.Drawing.Image)
        Me.TsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbSave.Name = "TsbSave"
        Me.TsbSave.Size = New System.Drawing.Size(67, 22)
        Me.TsbSave.Text = "儲存(&S)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TsbReturn
        '
        Me.TsbReturn.Image = CType(resources.GetObject("TsbReturn.Image"), System.Drawing.Image)
        Me.TsbReturn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbReturn.Name = "TsbReturn"
        Me.TsbReturn.Size = New System.Drawing.Size(68, 22)
        Me.TsbReturn.Text = "返回(&B)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'TsbDelete
        '
        Me.TsbDelete.Image = CType(resources.GetObject("TsbDelete.Image"), System.Drawing.Image)
        Me.TsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbDelete.Name = "TsbDelete"
        Me.TsbDelete.Size = New System.Drawing.Size(69, 22)
        Me.TsbDelete.Text = "刪除(&D)"
        '
        'TsbView
        '
        Me.TsbView.Enabled = False
        Me.TsbView.Image = CType(resources.GetObject("TsbView.Image"), System.Drawing.Image)
        Me.TsbView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbView.Name = "TsbView"
        Me.TsbView.Size = New System.Drawing.Size(76, 22)
        Me.TsbView.Text = "公告预览"
        '
        'TsbPublish
        '
        Me.TsbPublish.Enabled = False
        Me.TsbPublish.Image = CType(resources.GetObject("TsbPublish.Image"), System.Drawing.Image)
        Me.TsbPublish.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbPublish.Name = "TsbPublish"
        Me.TsbPublish.Size = New System.Drawing.Size(76, 22)
        Me.TsbPublish.Text = "公告发布"
        '
        'TsbPublishCancle
        '
        Me.TsbPublishCancle.Enabled = False
        Me.TsbPublishCancle.Image = CType(resources.GetObject("TsbPublishCancle.Image"), System.Drawing.Image)
        Me.TsbPublishCancle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbPublishCancle.Name = "TsbPublishCancle"
        Me.TsbPublishCancle.Size = New System.Drawing.Size(76, 22)
        Me.TsbPublishCancle.Text = "取消发布"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TsbQuery
        '
        Me.TsbQuery.Image = CType(resources.GetObject("TsbQuery.Image"), System.Drawing.Image)
        Me.TsbQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbQuery.Name = "TsbQuery"
        Me.TsbQuery.Size = New System.Drawing.Size(70, 22)
        Me.TsbQuery.Text = "查詢(&Q)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'TsbRefresh
        '
        Me.TsbRefresh.Image = CType(resources.GetObject("TsbRefresh.Image"), System.Drawing.Image)
        Me.TsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbRefresh.Name = "TsbRefresh"
        Me.TsbRefresh.Size = New System.Drawing.Size(68, 21)
        Me.TsbRefresh.Text = "刷新(&R)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolAdv
        '
        Me.toolAdv.Image = CType(resources.GetObject("toolAdv.Image"), System.Drawing.Image)
        Me.toolAdv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdv.Name = "toolAdv"
        Me.toolAdv.Size = New System.Drawing.Size(76, 21)
        Me.toolAdv.Text = "公告详情"
        '
        'TsbClose
        '
        Me.TsbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbClose.Name = "TsbClose"
        Me.TsbClose.Size = New System.Drawing.Size(52, 21)
        Me.TsbClose.Text = "退出(&C)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DtEnd)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.DtStar)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtUrl)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtContent)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CmbType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtTitle)
        Me.GroupBox1.Controls.Add(Me.CkbUsey)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(754, 163)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(272, 130)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.Size = New System.Drawing.Size(155, 21)
        Me.DtEnd.TabIndex = 25
        Me.DtEnd.Value = New Date(2015, 7, 17, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(239, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "至"
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(74, 130)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.Size = New System.Drawing.Size(155, 21)
        Me.DtStar.TabIndex = 23
        Me.DtStar.Value = New Date(2015, 7, 17, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "有效期："
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(700, 17)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(21, 21)
        Me.txtID.TabIndex = 21
        Me.txtID.Visible = False
        '
        'txtUrl
        '
        Me.txtUrl.Location = New System.Drawing.Point(74, 103)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(609, 21)
        Me.txtUrl.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "链接："
        '
        'txtContent
        '
        Me.txtContent.Location = New System.Drawing.Point(74, 44)
        Me.txtContent.Multiline = True
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(609, 53)
        Me.txtContent.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "内容："
        '
        'CmbType
        '
        Me.CmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbType.FormattingEnabled = True
        Me.CmbType.Items.AddRange(New Object() {"0-文字公告", "1-网页链接"})
        Me.CmbType.Location = New System.Drawing.Point(484, 17)
        Me.CmbType.Name = "CmbType"
        Me.CmbType.Size = New System.Drawing.Size(88, 20)
        Me.CmbType.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(422, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "类型："
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(74, 17)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(334, 21)
        Me.txtTitle.TabIndex = 2
        '
        'CkbUsey
        '
        Me.CkbUsey.AutoSize = True
        Me.CkbUsey.Checked = True
        Me.CkbUsey.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkbUsey.Enabled = False
        Me.CkbUsey.Location = New System.Drawing.Point(589, 19)
        Me.CkbUsey.Name = "CkbUsey"
        Me.CkbUsey.Size = New System.Drawing.Size(72, 16)
        Me.CkbUsey.TabIndex = 4
        Me.CkbUsey.Text = "发布状态"
        Me.CkbUsey.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "标题："
        '
        'DgvShowTb
        '
        Me.DgvShowTb.AllowUserToAddRows = False
        Me.DgvShowTb.BackgroundColor = System.Drawing.Color.White
        Me.DgvShowTb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvShowTb.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgvShowTb.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DgvShowTb.ColumnHeadersHeight = 25
        Me.DgvShowTb.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.type, Me.title, Me.contents, Me.URL, Me.dtstart, Me.dtends, Me.Usey, Me.intime})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvShowTb.DefaultCellStyle = DataGridViewCellStyle1
        Me.DgvShowTb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvShowTb.GridColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.DgvShowTb.Location = New System.Drawing.Point(0, 188)
        Me.DgvShowTb.Name = "DgvShowTb"
        Me.DgvShowTb.ReadOnly = True
        Me.DgvShowTb.RowHeadersWidth = 4
        Me.DgvShowTb.RowTemplate.Height = 24
        Me.DgvShowTb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgvShowTb.Size = New System.Drawing.Size(754, 181)
        Me.DgvShowTb.TabIndex = 17
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'type
        '
        Me.type.HeaderText = "类型"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        '
        'title
        '
        Me.title.HeaderText = "标题"
        Me.title.Name = "title"
        Me.title.ReadOnly = True
        '
        'contents
        '
        Me.contents.HeaderText = "内容"
        Me.contents.Name = "contents"
        Me.contents.ReadOnly = True
        '
        'URL
        '
        Me.URL.HeaderText = "链接"
        Me.URL.Name = "URL"
        Me.URL.ReadOnly = True
        '
        'dtstart
        '
        Me.dtstart.HeaderText = "起始时间"
        Me.dtstart.Name = "dtstart"
        Me.dtstart.ReadOnly = True
        '
        'dtends
        '
        Me.dtends.HeaderText = "截止时间"
        Me.dtends.Name = "dtends"
        Me.dtends.ReadOnly = True
        '
        'Usey
        '
        Me.Usey.HeaderText = "发布状态"
        Me.Usey.Name = "Usey"
        Me.Usey.ReadOnly = True
        Me.Usey.Width = 80
        '
        'intime
        '
        Me.intime.HeaderText = "时间"
        Me.intime.Name = "intime"
        Me.intime.ReadOnly = True
        Me.intime.Width = 200
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "类型"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "标题"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "内容"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "链接"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "起始时间"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "截止时间"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "发布状态"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "时间"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 200
        '
        'FrmMsgEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 369)
        Me.Controls.Add(Me.DgvShowTb)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMsgEdit"
        Me.Text = "系统信息公告"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgvShowTb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsbUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsbReturn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsbQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents CkbUsey As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgvShowTb As System.Windows.Forms.DataGridView
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Private WithEvents TsbView As System.Windows.Forms.ToolStripButton
    Friend WithEvents TsbPublishCancle As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents contents As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents URL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtstart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtends As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TsbPublish As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toolAdv As System.Windows.Forms.ToolStripButton
End Class
