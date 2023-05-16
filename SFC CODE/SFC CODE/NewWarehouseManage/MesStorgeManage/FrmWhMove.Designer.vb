<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWhMove
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWhMove))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMoveWhid = New System.Windows.Forms.TextBox()
        Me.txtPartid = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StartDtp = New System.Windows.Forms.DateTimePicker()
        Me.EndDtp = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CobMoveType = New System.Windows.Forms.ComboBox()
        Me.CobIntoWhid = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CobOutWhid = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CobFactory = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DGShipList = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.MVDtp = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtControlTime = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtController = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CobIntoFloor = New System.Windows.Forms.ComboBox()
        Me.CobIntoAreaid = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMoveReason = New System.Windows.Forms.TextBox()
        Me.ChkDtp = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkSelectAll = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtNew = New System.Windows.Forms.ToolStripButton()
        Me.BtSave = New System.Windows.Forms.ToolStripButton()
        Me.BtReuse = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtRefresh = New System.Windows.Forms.ToolStripButton()
        Me.BtCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.DGShipList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "调拨单号:"
        '
        'txtMoveWhid
        '
        Me.txtMoveWhid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMoveWhid.Location = New System.Drawing.Point(64, 13)
        Me.txtMoveWhid.MaxLength = 10
        Me.txtMoveWhid.Name = "txtMoveWhid"
        Me.txtMoveWhid.Size = New System.Drawing.Size(120, 21)
        Me.txtMoveWhid.TabIndex = 1
        '
        'txtPartid
        '
        Me.txtPartid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPartid.Enabled = False
        Me.txtPartid.Location = New System.Drawing.Point(64, 49)
        Me.txtPartid.MaxLength = 20
        Me.txtPartid.Name = "txtPartid"
        Me.txtPartid.Size = New System.Drawing.Size(120, 21)
        Me.txtPartid.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(473, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "生产日期:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(656, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 12)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "到:"
        '
        'StartDtp
        '
        Me.StartDtp.CustomFormat = "yyyy/MM/dd HH:mm"
        Me.StartDtp.Enabled = False
        Me.StartDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.StartDtp.Location = New System.Drawing.Point(530, 13)
        Me.StartDtp.Name = "StartDtp"
        Me.StartDtp.Size = New System.Drawing.Size(120, 21)
        Me.StartDtp.TabIndex = 5
        Me.StartDtp.Value = New Date(2007, 1, 1, 0, 0, 0, 0)
        '
        'EndDtp
        '
        Me.EndDtp.Checked = False
        Me.EndDtp.CustomFormat = "yyyy/MM/dd HH:mm"
        Me.EndDtp.Enabled = False
        Me.EndDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EndDtp.Location = New System.Drawing.Point(685, 13)
        Me.EndDtp.Name = "EndDtp"
        Me.EndDtp.Size = New System.Drawing.Size(120, 21)
        Me.EndDtp.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(300, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "调拨类型:"
        '
        'CobMoveType
        '
        Me.CobMoveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobMoveType.Enabled = False
        Me.CobMoveType.FormattingEnabled = True
        Me.CobMoveType.Location = New System.Drawing.Point(360, 50)
        Me.CobMoveType.Name = "CobMoveType"
        Me.CobMoveType.Size = New System.Drawing.Size(143, 20)
        Me.CobMoveType.TabIndex = 9
        '
        'CobIntoWhid
        '
        Me.CobIntoWhid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobIntoWhid.Enabled = False
        Me.CobIntoWhid.FormattingEnabled = True
        Me.CobIntoWhid.Location = New System.Drawing.Point(572, 85)
        Me.CobIntoWhid.Name = "CobIntoWhid"
        Me.CobIntoWhid.Size = New System.Drawing.Size(65, 20)
        Me.CobIntoWhid.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(525, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 12)
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "调入仓:"
        '
        'CobOutWhid
        '
        Me.CobOutWhid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobOutWhid.Enabled = False
        Me.CobOutWhid.FormattingEnabled = True
        Me.CobOutWhid.Location = New System.Drawing.Point(572, 50)
        Me.CobOutWhid.Name = "CobOutWhid"
        Me.CobOutWhid.Size = New System.Drawing.Size(65, 20)
        Me.CobOutWhid.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(525, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 12)
        Me.Label7.TabIndex = 128
        Me.Label7.Text = "调出仓:"
        '
        'CobFactory
        '
        Me.CobFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobFactory.Enabled = False
        Me.CobFactory.FormattingEnabled = True
        Me.CobFactory.Location = New System.Drawing.Point(222, 14)
        Me.CobFactory.Name = "CobFactory"
        Me.CobFactory.Size = New System.Drawing.Size(70, 20)
        Me.CobFactory.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(188, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "公司:"
        '
        'DGShipList
        '
        Me.DGShipList.AllowUserToAddRows = False
        Me.DGShipList.AllowUserToDeleteRows = False
        Me.DGShipList.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DGShipList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGShipList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGShipList.BackgroundColor = System.Drawing.Color.White
        Me.DGShipList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGShipList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGShipList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGShipList.ColumnHeadersHeight = 24
        Me.DGShipList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGShipList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.Column4, Me.Column5, Me.Column1, Me.Column3, Me.Column2})
        Me.DGShipList.Enabled = False
        Me.DGShipList.Location = New System.Drawing.Point(3, 167)
        Me.DGShipList.MultiSelect = False
        Me.DGShipList.Name = "DGShipList"
        Me.DGShipList.RowHeadersVisible = False
        Me.DGShipList.RowHeadersWidth = 4
        Me.DGShipList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGShipList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Moccasin
        Me.DGShipList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DGShipList.RowTemplate.Height = 23
        Me.DGShipList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGShipList.ShowEditingIcon = False
        Me.DGShipList.Size = New System.Drawing.Size(849, 416)
        Me.DGShipList.StandardTab = True
        Me.DGShipList.TabIndex = 15
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.FalseValue = "0"
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxColumn1.TrueValue = "1"
        Me.DataGridViewCheckBoxColumn1.Width = 30
        '
        'Column4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "工單編號"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "生產日期"
        Me.Column5.Name = "Column5"
        '
        'Column1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column1.HeaderText = "樓層"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Column3
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column3.HeaderText = "儲位"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column2
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column2.HeaderText = "數量"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.MVDtp)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtControlTime)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtController)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.CobIntoFloor)
        Me.GroupBox1.Controls.Add(Me.CobIntoAreaid)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtQty)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtMoveReason)
        Me.GroupBox1.Controls.Add(Me.ChkDtp)
        Me.GroupBox1.Controls.Add(Me.CobOutWhid)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CobFactory)
        Me.GroupBox1.Controls.Add(Me.txtMoveWhid)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPartid)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CobIntoWhid)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.StartDtp)
        Me.GroupBox1.Controls.Add(Me.CobMoveType)
        Me.GroupBox1.Controls.Add(Me.EndDtp)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(845, 116)
        Me.GroupBox1.TabIndex = 133
        Me.GroupBox1.TabStop = False
        '
        'MVDtp
        '
        Me.MVDtp.CustomFormat = "yyyy/MM/dd HH:mm"
        Me.MVDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.MVDtp.Location = New System.Drawing.Point(360, 14)
        Me.MVDtp.Name = "MVDtp"
        Me.MVDtp.Size = New System.Drawing.Size(85, 21)
        Me.MVDtp.TabIndex = 149
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(504, 89)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(17, 12)
        Me.Label16.TabIndex = 148
        Me.Label16.Text = "天"
        '
        'txtControlTime
        '
        Me.txtControlTime.Enabled = False
        Me.txtControlTime.Location = New System.Drawing.Point(460, 84)
        Me.txtControlTime.MaxLength = 3
        Me.txtControlTime.Name = "txtControlTime"
        Me.txtControlTime.Size = New System.Drawing.Size(43, 21)
        Me.txtControlTime.TabIndex = 147
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(404, 89)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 12)
        Me.Label15.TabIndex = 146
        Me.Label15.Text = "管制期限:"
        '
        'txtController
        '
        Me.txtController.Enabled = False
        Me.txtController.Location = New System.Drawing.Point(345, 84)
        Me.txtController.MaxLength = 10
        Me.txtController.Name = "txtController"
        Me.txtController.Size = New System.Drawing.Size(56, 21)
        Me.txtController.TabIndex = 145
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(300, 89)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 12)
        Me.Label14.TabIndex = 144
        Me.Label14.Text = "管制人:"
        '
        'CobIntoFloor
        '
        Me.CobIntoFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobIntoFloor.Enabled = False
        Me.CobIntoFloor.FormattingEnabled = True
        Me.CobIntoFloor.Location = New System.Drawing.Point(707, 50)
        Me.CobIntoFloor.Name = "CobIntoFloor"
        Me.CobIntoFloor.Size = New System.Drawing.Size(65, 20)
        Me.CobIntoFloor.TabIndex = 12
        '
        'CobIntoAreaid
        '
        Me.CobIntoAreaid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobIntoAreaid.Enabled = False
        Me.CobIntoAreaid.FormattingEnabled = True
        Me.CobIntoAreaid.Location = New System.Drawing.Point(707, 85)
        Me.CobIntoAreaid.Name = "CobIntoAreaid"
        Me.CobIntoAreaid.Size = New System.Drawing.Size(65, 20)
        Me.CobIntoAreaid.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(647, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 12)
        Me.Label9.TabIndex = 143
        Me.Label9.Text = "调入楼层:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(647, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 12)
        Me.Label13.TabIndex = 141
        Me.Label13.Text = "调入储位:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(300, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 12)
        Me.Label12.TabIndex = 139
        Me.Label12.Text = "調撥日期:"
        '
        'txtQty
        '
        Me.txtQty.Enabled = False
        Me.txtQty.Location = New System.Drawing.Point(222, 49)
        Me.txtQty.MaxLength = 8
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(70, 21)
        Me.txtQty.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(188, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 12)
        Me.Label11.TabIndex = 137
        Me.Label11.Text = "数量:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 12)
        Me.Label10.TabIndex = 135
        Me.Label10.Text = "调拨原因:"
        '
        'txtMoveReason
        '
        Me.txtMoveReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMoveReason.Enabled = False
        Me.txtMoveReason.Location = New System.Drawing.Point(64, 84)
        Me.txtMoveReason.Name = "txtMoveReason"
        Me.txtMoveReason.Size = New System.Drawing.Size(228, 21)
        Me.txtMoveReason.TabIndex = 14
        '
        'ChkDtp
        '
        Me.ChkDtp.AutoSize = True
        Me.ChkDtp.Enabled = False
        Me.ChkDtp.Location = New System.Drawing.Point(453, 17)
        Me.ChkDtp.Name = "ChkDtp"
        Me.ChkDtp.Size = New System.Drawing.Size(15, 14)
        Me.ChkDtp.TabIndex = 4
        Me.ChkDtp.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "料件编号:"
        '
        'ChkSelectAll
        '
        Me.ChkSelectAll.AutoSize = True
        Me.ChkSelectAll.Location = New System.Drawing.Point(22, 172)
        Me.ChkSelectAll.Name = "ChkSelectAll"
        Me.ChkSelectAll.Size = New System.Drawing.Size(15, 14)
        Me.ChkSelectAll.TabIndex = 134
        Me.ChkSelectAll.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtNew, Me.BtSave, Me.BtReuse, Me.ToolStripSeparator4, Me.BtRefresh, Me.BtCancel, Me.ToolStripSeparator2, Me.BtExit, Me.ToolStripLabel1, Me.ToolStripLabel2, Me.ToolStripLabel4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(852, 25)
        Me.ToolStrip1.TabIndex = 116
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtNew
        '
        Me.BtNew.Image = CType(resources.GetObject("BtNew.Image"), System.Drawing.Image)
        Me.BtNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtNew.Name = "BtNew"
        Me.BtNew.Size = New System.Drawing.Size(94, 22)
        Me.BtNew.Text = "新增单据(&N)"
        '
        'BtSave
        '
        Me.BtSave.Image = CType(resources.GetObject("BtSave.Image"), System.Drawing.Image)
        Me.BtSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtSave.Name = "BtSave"
        Me.BtSave.Size = New System.Drawing.Size(91, 22)
        Me.BtSave.Text = "确认调拨(&S)"
        '
        'BtReuse
        '
        Me.BtReuse.Image = CType(resources.GetObject("BtReuse.Image"), System.Drawing.Image)
        Me.BtReuse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtReuse.Name = "BtReuse"
        Me.BtReuse.Size = New System.Drawing.Size(93, 22)
        Me.BtReuse.Text = "取消管制(&U)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BtRefresh
        '
        Me.BtRefresh.Image = CType(resources.GetObject("BtRefresh.Image"), System.Drawing.Image)
        Me.BtRefresh.ImageTransparentColor = System.Drawing.Color.Black
        Me.BtRefresh.Name = "BtRefresh"
        Me.BtRefresh.Size = New System.Drawing.Size(72, 22)
        Me.BtRefresh.Text = "刷 新(&R)"
        Me.BtRefresh.ToolTipText = "刷新"
        '
        'BtCancel
        '
        Me.BtCancel.Image = CType(resources.GetObject("BtCancel.Image"), System.Drawing.Image)
        Me.BtCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(72, 22)
        Me.BtCancel.Text = "返 回(&C)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BtExit
        '
        Me.BtExit.ForeColor = System.Drawing.Color.Black
        Me.BtExit.Image = CType(resources.GetObject("BtExit.Image"), System.Drawing.Image)
        Me.BtExit.ImageTransparentColor = System.Drawing.Color.White
        Me.BtExit.Name = "BtExit"
        Me.BtExit.Size = New System.Drawing.Size(72, 22)
        Me.BtExit.Text = "退 出(&X)"
        Me.BtExit.ToolTipText = "退 出"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(16, 22)
        Me.ToolStripLabel4.Text = "  "
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 586)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(852, 22)
        Me.StatusStrip1.TabIndex = 135
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数:"
        '
        'ToolLblCount
        '
        Me.ToolLblCount.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolLblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolLblCount.Text = "0"
        '
        'FrmWhMove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 608)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ChkSelectAll)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGShipList)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmWhMove"
        Me.Text = "仓库调拨作业"
        CType(Me.DGShipList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtMoveWhid As System.Windows.Forms.TextBox
    Friend WithEvents txtPartid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StartDtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents EndDtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CobMoveType As System.Windows.Forms.ComboBox
    Friend WithEvents CobIntoWhid As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CobOutWhid As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CobFactory As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DGShipList As System.Windows.Forms.DataGridView
    Friend WithEvents BtRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkDtp As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMoveReason As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CobIntoFloor As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CobIntoAreaid As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents txtController As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtControlTime As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents MVDtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtReuse As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtExit As System.Windows.Forms.ToolStripButton
End Class
