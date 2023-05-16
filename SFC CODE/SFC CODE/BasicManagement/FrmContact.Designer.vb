<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContact))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolModify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolDelete = New System.Windows.Forms.ToolStripButton()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.toolBatch = New System.Windows.Forms.ToolStripButton()
        Me.dgViewQuery = New System.Windows.Forms.DataGridView()
        Me.colType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colShort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMonday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTuesday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWednesday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colThursday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFriday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaturday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSunday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboDutyUser = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDT = New System.Windows.Forms.DateTimePicker()
        Me.cmbDuteType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.dtpDTQuery = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblId = New System.Windows.Forms.Label()
        Me.chkMonthSearch = New System.Windows.Forms.CheckBox()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.dgViewEdit = New System.Windows.Forms.DataGridView()
        Me.colDTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colweekday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDutyType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolBt.SuspendLayout()
        CType(Me.dgViewQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.toolNew, Me.ToolStripSeparator4, Me.toolModify, Me.ToolStripSeparator5, Me.toolDelete, Me.toolSave, Me.ToolStripSeparator2, Me.toolUndo, Me.ToolStripSeparator6, Me.toolSearch, Me.ToolStripSeparator3, Me.toolExit, Me.toolBatch})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1059, 23)
        Me.ToolBt.TabIndex = 145
        Me.ToolBt.TabStop = True
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'toolNew
        '
        Me.toolNew.Image = CType(resources.GetObject("toolNew.Image"), System.Drawing.Image)
        Me.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolNew.Name = "toolNew"
        Me.toolNew.Size = New System.Drawing.Size(74, 20)
        Me.toolNew.Tag = "新增"
        Me.toolNew.Text = "新 增(&N)"
        Me.toolNew.ToolTipText = "新增"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'toolModify
        '
        Me.toolModify.Image = CType(resources.GetObject("toolModify.Image"), System.Drawing.Image)
        Me.toolModify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModify.Name = "toolModify"
        Me.toolModify.Size = New System.Drawing.Size(71, 20)
        Me.toolModify.Tag = "修改"
        Me.toolModify.Text = "修 改(&E)"
        Me.toolModify.ToolTipText = "修 改"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'toolDelete
        '
        Me.toolDelete.Image = CType(resources.GetObject("toolDelete.Image"), System.Drawing.Image)
        Me.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDelete.Name = "toolDelete"
        Me.toolDelete.Size = New System.Drawing.Size(73, 20)
        Me.toolDelete.Tag = "删 除"
        Me.toolDelete.Text = "删 除(&D)"
        Me.toolDelete.ToolTipText = "刪除"
        '
        'toolSave
        '
        Me.toolSave.Enabled = False
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(71, 20)
        Me.toolSave.Text = "保 存(&S)"
        Me.toolSave.ToolTipText = "保存"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolUndo
        '
        Me.toolUndo.Enabled = False
        Me.toolUndo.Image = CType(resources.GetObject("toolUndo.Image"), System.Drawing.Image)
        Me.toolUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolUndo.Name = "toolUndo"
        Me.toolUndo.Size = New System.Drawing.Size(68, 20)
        Me.toolUndo.Text = "返回(&C)"
        Me.toolUndo.ToolTipText = "返回"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'toolSearch
        '
        Me.toolSearch.Image = CType(resources.GetObject("toolSearch.Image"), System.Drawing.Image)
        Me.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSearch.Name = "toolSearch"
        Me.toolSearch.Size = New System.Drawing.Size(70, 20)
        Me.toolSearch.Text = "查 找(&F)"
        Me.toolSearch.ToolTipText = "查找"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 20)
        Me.toolExit.Text = "退 出(&X)"
        Me.toolExit.ToolTipText = "退出"
        '
        'toolBatch
        '
        Me.toolBatch.Image = CType(resources.GetObject("toolBatch.Image"), System.Drawing.Image)
        Me.toolBatch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBatch.Name = "toolBatch"
        Me.toolBatch.Size = New System.Drawing.Size(92, 20)
        Me.toolBatch.Tag = "批量导入"
        Me.toolBatch.Text = "批量导入(&B)"
        '
        'dgViewQuery
        '
        Me.dgViewQuery.AllowUserToAddRows = False
        Me.dgViewQuery.AllowUserToDeleteRows = False
        Me.dgViewQuery.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgViewQuery.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewQuery.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgViewQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colType, Me.colUserName, Me.colTel, Me.colExt, Me.colShort, Me.colMonday, Me.colTuesday, Me.colWednesday, Me.colThursday, Me.colFriday, Me.colSaturday, Me.colSunday, Me.Column5})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgViewQuery.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgViewQuery.Location = New System.Drawing.Point(3, 39)
        Me.dgViewQuery.Name = "dgViewQuery"
        Me.dgViewQuery.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgViewQuery.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgViewQuery.RowTemplate.Height = 23
        Me.dgViewQuery.Size = New System.Drawing.Size(1045, 346)
        Me.dgViewQuery.TabIndex = 146
        '
        'colType
        '
        Me.colType.DataPropertyName = "Type"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colType.DefaultCellStyle = DataGridViewCellStyle2
        Me.colType.HeaderText = "类型"
        Me.colType.Name = "colType"
        Me.colType.ReadOnly = True
        Me.colType.Width = 80
        '
        'colUserName
        '
        Me.colUserName.DataPropertyName = "UserName"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colUserName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colUserName.HeaderText = "值班人员"
        Me.colUserName.Name = "colUserName"
        Me.colUserName.ReadOnly = True
        Me.colUserName.Width = 90
        '
        'colTel
        '
        Me.colTel.DataPropertyName = "Mobile"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTel.DefaultCellStyle = DataGridViewCellStyle4
        Me.colTel.HeaderText = "值班人员电话"
        Me.colTel.Name = "colTel"
        Me.colTel.ReadOnly = True
        Me.colTel.Width = 110
        '
        'colExt
        '
        Me.colExt.DataPropertyName = "Extension"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colExt.DefaultCellStyle = DataGridViewCellStyle5
        Me.colExt.HeaderText = "分机"
        Me.colExt.Name = "colExt"
        Me.colExt.ReadOnly = True
        Me.colExt.Width = 70
        '
        'colShort
        '
        Me.colShort.DataPropertyName = "Cornet"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colShort.DefaultCellStyle = DataGridViewCellStyle6
        Me.colShort.HeaderText = "短号"
        Me.colShort.Name = "colShort"
        Me.colShort.ReadOnly = True
        Me.colShort.Width = 60
        '
        'colMonday
        '
        Me.colMonday.DataPropertyName = "Monday"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colMonday.DefaultCellStyle = DataGridViewCellStyle7
        Me.colMonday.HeaderText = "星期一(11/13)"
        Me.colMonday.Name = "colMonday"
        Me.colMonday.ReadOnly = True
        Me.colMonday.Width = 80
        '
        'colTuesday
        '
        Me.colTuesday.DataPropertyName = "Tuesday"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colTuesday.DefaultCellStyle = DataGridViewCellStyle8
        Me.colTuesday.HeaderText = "星期二(11/14)"
        Me.colTuesday.Name = "colTuesday"
        Me.colTuesday.ReadOnly = True
        Me.colTuesday.Width = 80
        '
        'colWednesday
        '
        Me.colWednesday.DataPropertyName = "Wednesday"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colWednesday.DefaultCellStyle = DataGridViewCellStyle9
        Me.colWednesday.HeaderText = "星期三"
        Me.colWednesday.Name = "colWednesday"
        Me.colWednesday.ReadOnly = True
        Me.colWednesday.Width = 80
        '
        'colThursday
        '
        Me.colThursday.DataPropertyName = "Thursday"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colThursday.DefaultCellStyle = DataGridViewCellStyle10
        Me.colThursday.HeaderText = "星期四"
        Me.colThursday.Name = "colThursday"
        Me.colThursday.ReadOnly = True
        Me.colThursday.Width = 80
        '
        'colFriday
        '
        Me.colFriday.DataPropertyName = "Friday"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colFriday.DefaultCellStyle = DataGridViewCellStyle11
        Me.colFriday.HeaderText = "星期五"
        Me.colFriday.Name = "colFriday"
        Me.colFriday.ReadOnly = True
        Me.colFriday.Width = 80
        '
        'colSaturday
        '
        Me.colSaturday.DataPropertyName = "Saturday"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colSaturday.DefaultCellStyle = DataGridViewCellStyle12
        Me.colSaturday.HeaderText = "星期六"
        Me.colSaturday.Name = "colSaturday"
        Me.colSaturday.ReadOnly = True
        Me.colSaturday.Width = 80
        '
        'colSunday
        '
        Me.colSunday.DataPropertyName = "Sunday"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colSunday.DefaultCellStyle = DataGridViewCellStyle13
        Me.colSunday.HeaderText = "星期日"
        Me.colSunday.Name = "colSunday"
        Me.colSunday.ReadOnly = True
        Me.colSunday.Width = 80
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "id"
        Me.Column5.HeaderText = "id"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "值班日期："
        '
        'cboDutyUser
        '
        Me.cboDutyUser.BackColor = System.Drawing.Color.White
        Me.cboDutyUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDutyUser.FormattingEnabled = True
        Me.cboDutyUser.Location = New System.Drawing.Point(255, 17)
        Me.cboDutyUser.Name = "cboDutyUser"
        Me.cboDutyUser.Size = New System.Drawing.Size(109, 20)
        Me.cboDutyUser.TabIndex = 149
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(196, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "值班人员："
        '
        'dtpDT
        '
        Me.dtpDT.Location = New System.Drawing.Point(79, 17)
        Me.dtpDT.Name = "dtpDT"
        Me.dtpDT.Size = New System.Drawing.Size(111, 21)
        Me.dtpDT.TabIndex = 151
        '
        'cmbDuteType
        '
        Me.cmbDuteType.BackColor = System.Drawing.Color.White
        Me.cmbDuteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDuteType.FormattingEnabled = True
        Me.cmbDuteType.Location = New System.Drawing.Point(441, 19)
        Me.cmbDuteType.Name = "cmbDuteType"
        Me.cmbDuteType.Size = New System.Drawing.Size(109, 20)
        Me.cmbDuteType.TabIndex = 149
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(370, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "值班类型："
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 23)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1059, 411)
        Me.TabControl1.TabIndex = 152
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtIP)
        Me.TabPage1.Controls.Add(Me.dtpDTQuery)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dgViewQuery)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1051, 385)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "显示本周值班人员"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtIP
        '
        Me.txtIP.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtIP.ForeColor = System.Drawing.Color.Green
        Me.txtIP.Location = New System.Drawing.Point(516, 7)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(291, 26)
        Me.txtIP.TabIndex = 155
        '
        'dtpDTQuery
        '
        Me.dtpDTQuery.Location = New System.Drawing.Point(77, 6)
        Me.dtpDTQuery.Name = "dtpDTQuery"
        Me.dtpDTQuery.Size = New System.Drawing.Size(111, 21)
        Me.dtpDTQuery.TabIndex = 153
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(414, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 12)
        Me.Label6.TabIndex = 152
        Me.Label6.Text = "电脑名（IP）："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "值班日期："
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblId)
        Me.TabPage2.Controls.Add(Me.chkMonthSearch)
        Me.TabPage2.Controls.Add(Me.txtRemark)
        Me.TabPage2.Controls.Add(Me.dgViewEdit)
        Me.TabPage2.Controls.Add(Me.cboDutyUser)
        Me.TabPage2.Controls.Add(Me.dtpDT)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.cmbDuteType)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1051, 360)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "维护值班信息"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(647, 26)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(35, 12)
        Me.lblId.TabIndex = 155
        Me.lblId.Text = "lblId"
        Me.lblId.Visible = False
        '
        'chkMonthSearch
        '
        Me.chkMonthSearch.AutoSize = True
        Me.chkMonthSearch.Location = New System.Drawing.Point(569, 23)
        Me.chkMonthSearch.Name = "chkMonthSearch"
        Me.chkMonthSearch.Size = New System.Drawing.Size(72, 16)
        Me.chkMonthSearch.TabIndex = 154
        Me.chkMonthSearch.Text = "按月查找"
        Me.chkMonthSearch.UseVisualStyleBackColor = True
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(79, 41)
        Me.txtRemark.MaxLength = 50
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(282, 36)
        Me.txtRemark.TabIndex = 153
        '
        'dgViewEdit
        '
        Me.dgViewEdit.AllowUserToAddRows = False
        Me.dgViewEdit.AllowUserToDeleteRows = False
        Me.dgViewEdit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgViewEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgViewEdit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDTA, Me.colweekday, Me.Column2, Me.colDutyType, Me.colRemark, Me.colUserID, Me.colID})
        Me.dgViewEdit.Location = New System.Drawing.Point(3, 83)
        Me.dgViewEdit.Name = "dgViewEdit"
        Me.dgViewEdit.ReadOnly = True
        Me.dgViewEdit.RowTemplate.Height = 23
        Me.dgViewEdit.Size = New System.Drawing.Size(1048, 274)
        Me.dgViewEdit.TabIndex = 152
        '
        'colDTA
        '
        Me.colDTA.DataPropertyName = "dt"
        Me.colDTA.HeaderText = "值班日期"
        Me.colDTA.Name = "colDTA"
        Me.colDTA.ReadOnly = True
        '
        'colweekday
        '
        Me.colweekday.DataPropertyName = "weekday"
        Me.colweekday.HeaderText = "星期"
        Me.colweekday.Name = "colweekday"
        Me.colweekday.ReadOnly = True
        Me.colweekday.Width = 60
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "UserName"
        Me.Column2.HeaderText = "值班人员"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'colDutyType
        '
        Me.colDutyType.DataPropertyName = "DutyType"
        Me.colDutyType.HeaderText = "值班类型"
        Me.colDutyType.Name = "colDutyType"
        Me.colDutyType.ReadOnly = True
        '
        'colRemark
        '
        Me.colRemark.DataPropertyName = "Remark"
        Me.colRemark.HeaderText = "备注"
        Me.colRemark.Name = "colRemark"
        Me.colRemark.ReadOnly = True
        Me.colRemark.Width = 200
        '
        'colUserID
        '
        Me.colUserID.DataPropertyName = "UserID"
        Me.colUserID.HeaderText = "UserID"
        Me.colUserID.Name = "colUserID"
        Me.colUserID.ReadOnly = True
        Me.colUserID.Visible = False
        '
        'colID
        '
        Me.colID.DataPropertyName = "ID"
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(47, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = "备注："
        '
        'FrmContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 434)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmContact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MES联系人查询"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.dgViewQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolModify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgViewQuery As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboDutyUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDT As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbDuteType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dtpDTQuery As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgViewEdit As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents chkMonthSearch As System.Windows.Forms.CheckBox
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents colDTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colweekday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDutyType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colShort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTuesday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWednesday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colThursday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFriday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaturday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSunday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents toolBatch As System.Windows.Forms.ToolStripButton
End Class
