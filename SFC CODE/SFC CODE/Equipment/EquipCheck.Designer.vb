<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquipCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquipCheck))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtCheckUser = New System.Windows.Forms.TextBox()
        Me.ToolCancel = New System.Windows.Forms.ToolStripButton()
        Me.GridList = New System.Windows.Forms.DataGridView()
        Me.Machine_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CREATEUSERNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CREATEDATETIME = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.ColCheckTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNextCheckTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCheckInterval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FactoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Profitcenter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripLabel()
        Me.Labelcount = New System.Windows.Forms.ToolStripLabel()
        Me.TlelCount = New System.Windows.Forms.ToolStripLabel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ComCheckStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQueryMO = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCREATEUSERNAME = New System.Windows.Forms.TextBox()
        Me.txtEquCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.GridList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolBt.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCheckUser
        '
        Me.txtCheckUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCheckUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckUser.Location = New System.Drawing.Point(313, 8)
        Me.txtCheckUser.MaxLength = 30
        Me.txtCheckUser.Name = "txtCheckUser"
        Me.txtCheckUser.Size = New System.Drawing.Size(142, 21)
        Me.txtCheckUser.TabIndex = 73
        '
        'ToolCancel
        '
        Me.ToolCancel.Image = CType(resources.GetObject("ToolCancel.Image"), System.Drawing.Image)
        Me.ToolCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCancel.Name = "ToolCancel"
        Me.ToolCancel.Size = New System.Drawing.Size(68, 22)
        Me.ToolCancel.Text = "返回(&C)"
        '
        'GridList
        '
        Me.GridList.AllowUserToAddRows = False
        Me.GridList.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.GridList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GridList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridList.BackgroundColor = System.Drawing.Color.White
        Me.GridList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GridList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.GridList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GridList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Machine_Code, Me.CheckUser, Me.CheckStatus, Me.CREATEUSERNAME, Me.CREATEDATETIME, Me.ColCheckTime, Me.ColNextCheckTime, Me.ColCheckInterval, Me.Remark, Me.FactoryName, Me.Profitcenter})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridList.DefaultCellStyle = DataGridViewCellStyle3
        Me.GridList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.GridList.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.GridList.Location = New System.Drawing.Point(0, 113)
        Me.GridList.MultiSelect = False
        Me.GridList.Name = "GridList"
        Me.GridList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.GridList.RowHeadersWidth = 4
        Me.GridList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GridList.RowTemplate.Height = 24
        Me.GridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridList.ShowEditingIcon = False
        Me.GridList.Size = New System.Drawing.Size(1019, 423)
        Me.GridList.TabIndex = 135
        Me.GridList.TabStop = False
        '
        'Machine_Code
        '
        Me.Machine_Code.HeaderText = "设备编号"
        Me.Machine_Code.Name = "Machine_Code"
        Me.Machine_Code.ReadOnly = True
        Me.Machine_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CheckUser
        '
        Me.CheckUser.HeaderText = "校验人"
        Me.CheckUser.Name = "CheckUser"
        Me.CheckUser.ReadOnly = True
        Me.CheckUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CheckUser.Width = 80
        '
        'CheckStatus
        '
        Me.CheckStatus.HeaderText = "状态"
        Me.CheckStatus.Name = "CheckStatus"
        Me.CheckStatus.ReadOnly = True
        Me.CheckStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CheckStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CheckStatus.Width = 80
        '
        'CREATEUSERNAME
        '
        Me.CREATEUSERNAME.HeaderText = "创建人"
        Me.CREATEUSERNAME.Name = "CREATEUSERNAME"
        Me.CREATEUSERNAME.ReadOnly = True
        Me.CREATEUSERNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CREATEUSERNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CREATEUSERNAME.Width = 80
        '
        'CREATEDATETIME
        '
        '
        '
        '
        Me.CREATEDATETIME.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.CREATEDATETIME.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CREATEDATETIME.HeaderText = "创建时间"
        Me.CREATEDATETIME.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.CREATEDATETIME.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CREATEDATETIME.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CREATEDATETIME.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.CREATEDATETIME.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CREATEDATETIME.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.CREATEDATETIME.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.CREATEDATETIME.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.CREATEDATETIME.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CREATEDATETIME.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.CREATEDATETIME.Name = "CREATEDATETIME"
        Me.CREATEDATETIME.ReadOnly = True
        Me.CREATEDATETIME.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CREATEDATETIME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColCheckTime
        '
        Me.ColCheckTime.HeaderText = "本次校验时间"
        Me.ColCheckTime.Name = "ColCheckTime"
        '
        'ColNextCheckTime
        '
        Me.ColNextCheckTime.HeaderText = "下次校验时间"
        Me.ColNextCheckTime.Name = "ColNextCheckTime"
        '
        'ColCheckInterval
        '
        Me.ColCheckInterval.HeaderText = "时间间隔"
        Me.ColCheckInterval.Name = "ColCheckInterval"
        '
        'Remark
        '
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 250
        '
        'FactoryName
        '
        Me.FactoryName.HeaderText = "厂区"
        Me.FactoryName.Name = "FactoryName"
        '
        'Profitcenter
        '
        Me.Profitcenter.HeaderText = "利润中心"
        Me.Profitcenter.Name = "Profitcenter"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 46)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 67
        Me.Label16.Text = "创建日期："
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 20)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.ToolLblCount, Me.Labelcount, Me.TlelCount})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 536)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1019, 20)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 136
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolLblCount
        '
        Me.ToolLblCount.ForeColor = System.Drawing.Color.Black
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(59, 17)
        Me.ToolLblCount.Text = "记录笔数:"
        '
        'Labelcount
        '
        Me.Labelcount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Labelcount.Name = "Labelcount"
        Me.Labelcount.Size = New System.Drawing.Size(0, 17)
        '
        'TlelCount
        '
        Me.TlelCount.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TlelCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TlelCount.Name = "TlelCount"
        Me.TlelCount.Size = New System.Drawing.Size(15, 17)
        Me.TlelCount.Text = "0"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Checked = False
        Me.DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(65, 40)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowCheckBox = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 21)
        Me.DateTimePicker1.TabIndex = 68
        Me.DateTimePicker1.Value = New Date(2015, 5, 27, 10, 12, 43, 0)
        '
        'ComCheckStatus
        '
        Me.ComCheckStatus.FormattingEnabled = True
        Me.ComCheckStatus.Location = New System.Drawing.Point(568, 8)
        Me.ComCheckStatus.MaxLength = 20
        Me.ComCheckStatus.Name = "ComCheckStatus"
        Me.ComCheckStatus.Size = New System.Drawing.Size(142, 20)
        Me.ComCheckStatus.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(509, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "校验状态："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(256, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "校 验 人："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(256, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "创 建 人："
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolQueryMO
        '
        Me.ToolQueryMO.Image = CType(resources.GetObject("ToolQueryMO.Image"), System.Drawing.Image)
        Me.ToolQueryMO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQueryMO.Name = "ToolQueryMO"
        Me.ToolQueryMO.Size = New System.Drawing.Size(66, 22)
        Me.ToolQueryMO.Text = "查询(&F)"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "工单类型"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 77
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "工单数量"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 77
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 77
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "品名"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 53
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "工单编号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 77
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "客户代码"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "工单状态"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Width = 77
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.txtCREATEUSERNAME)
        Me.Panel1.Controls.Add(Me.txtCheckUser)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.ComCheckStatus)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtEquCode)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1019, 78)
        Me.Panel1.TabIndex = 137
        '
        'txtCREATEUSERNAME
        '
        Me.txtCREATEUSERNAME.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCREATEUSERNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCREATEUSERNAME.Location = New System.Drawing.Point(313, 40)
        Me.txtCREATEUSERNAME.MaxLength = 30
        Me.txtCREATEUSERNAME.Name = "txtCREATEUSERNAME"
        Me.txtCREATEUSERNAME.Size = New System.Drawing.Size(142, 21)
        Me.txtCREATEUSERNAME.TabIndex = 74
        '
        'txtEquCode
        '
        Me.txtEquCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEquCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEquCode.Location = New System.Drawing.Point(65, 8)
        Me.txtEquCode.MaxLength = 10
        Me.txtEquCode.Name = "txtEquCode"
        Me.txtEquCode.Size = New System.Drawing.Size(121, 21)
        Me.txtEquCode.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "设备编号："
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolQueryMO, Me.ToolStripSeparator5, Me.ToolCancel, Me.ToolStripSeparator1, Me.ExitFrom, Me.ToolStripButton1})
        Me.ToolBt.Location = New System.Drawing.Point(0, 2)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1019, 25)
        Me.ToolBt.TabIndex = 134
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ExitFrom
        '
        Me.ExitFrom.Image = CType(resources.GetObject("ExitFrom.Image"), System.Drawing.Image)
        Me.ExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ExitFrom.Name = "ExitFrom"
        Me.ExitFrom.Size = New System.Drawing.Size(68, 22)
        Me.ExitFrom.Text = "退出(&X)"
        Me.ExitFrom.ToolTipText = "退出"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "工单状态"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.Width = 77
        '
        'EquipCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 556)
        Me.Controls.Add(Me.GridList)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "EquipCheck"
        Me.Text = "设备校验维护"
        CType(Me.GridList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCheckUser As System.Windows.Forms.TextBox
    Friend WithEvents ToolCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridList As System.Windows.Forms.DataGridView
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Labelcount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TlelCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComCheckStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQueryMO As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtEquCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCREATEUSERNAME As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Machine_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATEUSERNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CREATEDATETIME As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents ColCheckTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNextCheckTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCheckInterval As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FactoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Profitcenter As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
