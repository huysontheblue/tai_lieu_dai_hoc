<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmL01PackQuery
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmL01PackQuery))
        Me.GbCondition = New System.Windows.Forms.GroupBox()
        Me.txtCustOrder = New System.Windows.Forms.TextBox()
        Me.txtCartonid = New System.Windows.Forms.TextBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.CobLine = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CobPPID = New System.Windows.Forms.TextBox()
        Me.CobFactory = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DtEnd = New System.Windows.Forms.DateTimePicker()
        Me.DtStar = New System.Windows.Forms.DateTimePicker()
        Me.CobPart = New System.Windows.Forms.ComboBox()
        Me.CobMo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DgMoData = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PPID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deptid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItemDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolReflsh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolTxt = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.GbCondition.SuspendLayout()
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbCondition
        '
        Me.GbCondition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbCondition.Controls.Add(Me.txtCustOrder)
        Me.GbCondition.Controls.Add(Me.txtCartonid)
        Me.GbCondition.Controls.Add(Me.lblMsg)
        Me.GbCondition.Controls.Add(Me.CobLine)
        Me.GbCondition.Controls.Add(Me.Label9)
        Me.GbCondition.Controls.Add(Me.CobPPID)
        Me.GbCondition.Controls.Add(Me.CobFactory)
        Me.GbCondition.Controls.Add(Me.Label7)
        Me.GbCondition.Controls.Add(Me.DtEnd)
        Me.GbCondition.Controls.Add(Me.DtStar)
        Me.GbCondition.Controls.Add(Me.CobPart)
        Me.GbCondition.Controls.Add(Me.CobMo)
        Me.GbCondition.Controls.Add(Me.Label4)
        Me.GbCondition.Controls.Add(Me.Label6)
        Me.GbCondition.Controls.Add(Me.Label2)
        Me.GbCondition.Controls.Add(Me.Label1)
        Me.GbCondition.Controls.Add(Me.Label8)
        Me.GbCondition.Controls.Add(Me.Label5)
        Me.GbCondition.Controls.Add(Me.Label3)
        Me.GbCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GbCondition.Location = New System.Drawing.Point(0, 28)
        Me.GbCondition.Name = "GbCondition"
        Me.GbCondition.Size = New System.Drawing.Size(1057, 118)
        Me.GbCondition.TabIndex = 71
        Me.GbCondition.TabStop = False
        '
        'txtCustOrder
        '
        Me.txtCustOrder.Location = New System.Drawing.Point(67, 68)
        Me.txtCustOrder.Name = "txtCustOrder"
        Me.txtCustOrder.Size = New System.Drawing.Size(155, 21)
        Me.txtCustOrder.TabIndex = 160
        '
        'txtCartonid
        '
        Me.txtCartonid.Location = New System.Drawing.Point(348, 69)
        Me.txtCartonid.Multiline = True
        Me.txtCartonid.Name = "txtCartonid"
        Me.txtCartonid.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCartonid.Size = New System.Drawing.Size(173, 44)
        Me.txtCartonid.TabIndex = 159
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(778, 97)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 16)
        Me.lblMsg.TabIndex = 158
        '
        'CobLine
        '
        Me.CobLine.FormattingEnabled = True
        Me.CobLine.Location = New System.Drawing.Point(599, 40)
        Me.CobLine.Name = "CobLine"
        Me.CobLine.Size = New System.Drawing.Size(155, 20)
        Me.CobLine.TabIndex = 156
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(553, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 12)
        Me.Label9.TabIndex = 157
        Me.Label9.Text = "线别："
        '
        'CobPPID
        '
        Me.CobPPID.Location = New System.Drawing.Point(599, 72)
        Me.CobPPID.Multiline = True
        Me.CobPPID.Name = "CobPPID"
        Me.CobPPID.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.CobPPID.Size = New System.Drawing.Size(173, 44)
        Me.CobPPID.TabIndex = 143
        Me.CobPPID.Visible = False
        '
        'CobFactory
        '
        Me.CobFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobFactory.FormattingEnabled = True
        Me.CobFactory.Location = New System.Drawing.Point(599, 14)
        Me.CobFactory.Name = "CobFactory"
        Me.CobFactory.Size = New System.Drawing.Size(173, 20)
        Me.CobFactory.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(529, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "营运中心："
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(271, 13)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.Size = New System.Drawing.Size(169, 21)
        Me.DtEnd.TabIndex = 2
        Me.DtEnd.Value = New Date(2014, 6, 20, 0, 0, 0, 0)
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(95, 13)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.Size = New System.Drawing.Size(155, 21)
        Me.DtStar.TabIndex = 1
        Me.DtStar.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'CobPart
        '
        Me.CobPart.FormattingEnabled = True
        Me.CobPart.Location = New System.Drawing.Point(348, 41)
        Me.CobPart.Name = "CobPart"
        Me.CobPart.Size = New System.Drawing.Size(150, 20)
        Me.CobPart.TabIndex = 6
        '
        'CobMo
        '
        Me.CobMo.FormattingEnabled = True
        Me.CobMo.Location = New System.Drawing.Point(66, 40)
        Me.CobMo.Name = "CobMo"
        Me.CobMo.Size = New System.Drawing.Size(155, 20)
        Me.CobMo.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(290, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "料件编号："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 12)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "出货扫描时间："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(529, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "产品条码："
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(290, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "外箱编号："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "出货单号："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "工单编号："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(251, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 12)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "至 "
        '
        'DgMoData
        '
        Me.DgMoData.AllowUserToAddRows = False
        Me.DgMoData.AllowUserToDeleteRows = False
        Me.DgMoData.AllowUserToOrderColumns = True
        Me.DgMoData.AllowUserToResizeRows = False
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.AliceBlue
        Me.DgMoData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.DgMoData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgMoData.BackgroundColor = System.Drawing.Color.White
        Me.DgMoData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgMoData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMoData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DgMoData.ColumnHeadersHeight = 24
        Me.DgMoData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.PPID, Me.Column3, Me.Column12, Me.Column8, Me.Column4, Me.Column5, Me.Column6, Me.deptid, Me.Column9, Me.Intime, Me.custno})
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgMoData.DefaultCellStyle = DataGridViewCellStyle24
        Me.DgMoData.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgMoData.Location = New System.Drawing.Point(0, 152)
        Me.DgMoData.MultiSelect = False
        Me.DgMoData.Name = "DgMoData"
        Me.DgMoData.ReadOnly = True
        Me.DgMoData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgMoData.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.DgMoData.RowHeadersVisible = False
        Me.DgMoData.RowHeadersWidth = 4
        DataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.White
        Me.DgMoData.RowsDefaultCellStyle = DataGridViewCellStyle26
        Me.DgMoData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgMoData.RowTemplate.Height = 24
        Me.DgMoData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgMoData.ShowEditingIcon = False
        Me.DgMoData.Size = New System.Drawing.Size(1057, 398)
        Me.DgMoData.TabIndex = 11
        Me.DgMoData.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 20
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "cartonid"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle16
        Me.Column2.HeaderText = "外箱编号"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.Width = 160
        '
        'PPID
        '
        Me.PPID.DataPropertyName = "PPID"
        Me.PPID.HeaderText = "条码"
        Me.PPID.Name = "PPID"
        Me.PPID.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "cartonqty"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.Format = "N0"
        DataGridViewCellStyle17.NullValue = Nothing
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle17
        Me.Column3.HeaderText = "数量"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.Width = 50
        '
        'Column12
        '
        Me.Column12.DataPropertyName = "teamid"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column12.DefaultCellStyle = DataGridViewCellStyle18
        Me.Column12.HeaderText = "线别"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 60
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "state"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle19
        Me.Column8.HeaderText = "状态"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 70
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "moid"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle20
        Me.Column4.HeaderText = "工单编号"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "partid"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle21
        Me.Column5.HeaderText = "料件编号"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.Width = 120
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "cusname"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle22
        Me.Column6.HeaderText = "客户名称"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 70
        '
        'deptid
        '
        Me.deptid.DataPropertyName = "djc"
        Me.deptid.HeaderText = "部门"
        Me.deptid.Name = "deptid"
        Me.deptid.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "userid"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle23
        Me.Column9.HeaderText = "包装人员"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.DataPropertyName = "intime"
        Me.Intime.HeaderText = "包装时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'custno
        '
        Me.custno.DataPropertyName = "custno"
        Me.custno.HeaderText = "订单号"
        Me.custno.Name = "custno"
        Me.custno.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemAll, Me.MenuItemNone, Me.MenuItemDetail})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(192, 70)
        '
        'MenuItemAll
        '
        Me.MenuItemAll.Name = "MenuItemAll"
        Me.MenuItemAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MenuItemAll.Size = New System.Drawing.Size(191, 22)
        Me.MenuItemAll.Text = "全選"
        '
        'MenuItemNone
        '
        Me.MenuItemNone.Name = "MenuItemNone"
        Me.MenuItemNone.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.MenuItemNone.Size = New System.Drawing.Size(191, 22)
        Me.MenuItemNone.Text = "全不選"
        '
        'MenuItemDetail
        '
        Me.MenuItemDetail.Name = "MenuItemDetail"
        Me.MenuItemDetail.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.MenuItemDetail.Size = New System.Drawing.Size(191, 22)
        Me.MenuItemDetail.Text = "顯示詳細 "
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 553)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1057, 22)
        Me.StatusStrip1.TabIndex = 73
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel1.Text = "记录笔数："
        '
        'ToolCount
        '
        Me.ToolCount.BackColor = System.Drawing.SystemColors.Control
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolCount.Text = "0"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolReflsh, Me.ToolStripSeparator2, Me.ToolExcel, Me.ToolTxt, Me.ToolStripSeparator3, Me.ToolExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 1)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1057, 24)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 24)
        '
        'ToolReflsh
        '
        Me.ToolReflsh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToolReflsh.Image = CType(resources.GetObject("ToolReflsh.Image"), System.Drawing.Image)
        Me.ToolReflsh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReflsh.Name = "ToolReflsh"
        Me.ToolReflsh.Size = New System.Drawing.Size(63, 21)
        Me.ToolReflsh.Text = "刷    新"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 24)
        '
        'ToolExcel
        '
        Me.ToolExcel.Image = CType(resources.GetObject("ToolExcel.Image"), System.Drawing.Image)
        Me.ToolExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExcel.Name = "ToolExcel"
        Me.ToolExcel.Size = New System.Drawing.Size(64, 21)
        Me.ToolExcel.Text = "汇   出"
        '
        'ToolTxt
        '
        Me.ToolTxt.Enabled = False
        Me.ToolTxt.Image = Global.BasicFindReport.My.Resources.Resources.export_file
        Me.ToolTxt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolTxt.Name = "ToolTxt"
        Me.ToolTxt.Size = New System.Drawing.Size(74, 21)
        Me.ToolTxt.Text = "汇出TXT"
        Me.ToolTxt.ToolTipText = "汇出TXT"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 24)
        '
        'ToolExit
        '
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(68, 21)
        Me.ToolExit.Text = "退    出"
        '
        'FrmL01PackQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 575)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GbCondition)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DgMoData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmL01PackQuery"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "L01包装导出"
        Me.GbCondition.ResumeLayout(False)
        Me.GbCondition.PerformLayout()
        CType(Me.DgMoData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents CobPart As System.Windows.Forms.ComboBox
    Friend WithEvents CobMo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolReflsh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents DgMoData As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuItemAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItemDetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CobFactory As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CobPPID As System.Windows.Forms.TextBox
    Friend WithEvents CobLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents txtCartonid As System.Windows.Forms.TextBox
    Friend WithEvents ToolTxt As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCustOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deptid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents custno As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
