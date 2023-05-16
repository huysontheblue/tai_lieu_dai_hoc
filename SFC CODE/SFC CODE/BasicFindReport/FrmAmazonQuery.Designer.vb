<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAmazonQuery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAmazonQuery))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolReflsh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GbCondition = New System.Windows.Forms.GroupBox()
        Me.cboAsin = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.CobPO = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CobPPID = New System.Windows.Forms.TextBox()
        Me.CobFactory = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DtEnd = New System.Windows.Forms.DateTimePicker()
        Me.DtStar = New System.Windows.Forms.DateTimePicker()
        Me.CboCus = New System.Windows.Forms.ComboBox()
        Me.CobDept = New System.Windows.Forms.ComboBox()
        Me.CobPart = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CobMo = New System.Windows.Forms.ComboBox()
        Me.CobCarton = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lab = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DgData = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Booking_Key = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Container_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PO_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SSCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Units = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExtensionBit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GbCondition.SuspendLayout()
        CType(Me.DgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolReflsh, Me.ToolStripSeparator2, Me.ToolExcel, Me.ToolStripSeparator3, Me.ToolExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(911, 24)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 144
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
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 553)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(911, 22)
        Me.StatusStrip1.TabIndex = 147
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
        'GbCondition
        '
        Me.GbCondition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GbCondition.Controls.Add(Me.cboAsin)
        Me.GbCondition.Controls.Add(Me.Label8)
        Me.GbCondition.Controls.Add(Me.lblMsg)
        Me.GbCondition.Controls.Add(Me.CobPO)
        Me.GbCondition.Controls.Add(Me.Label9)
        Me.GbCondition.Controls.Add(Me.CobPPID)
        Me.GbCondition.Controls.Add(Me.CobFactory)
        Me.GbCondition.Controls.Add(Me.Label7)
        Me.GbCondition.Controls.Add(Me.DtEnd)
        Me.GbCondition.Controls.Add(Me.DtStar)
        Me.GbCondition.Controls.Add(Me.CboCus)
        Me.GbCondition.Controls.Add(Me.CobDept)
        Me.GbCondition.Controls.Add(Me.CobPart)
        Me.GbCondition.Controls.Add(Me.Label10)
        Me.GbCondition.Controls.Add(Me.CobMo)
        Me.GbCondition.Controls.Add(Me.CobCarton)
        Me.GbCondition.Controls.Add(Me.Label4)
        Me.GbCondition.Controls.Add(Me.Lab)
        Me.GbCondition.Controls.Add(Me.Label6)
        Me.GbCondition.Controls.Add(Me.Label2)
        Me.GbCondition.Controls.Add(Me.Label1)
        Me.GbCondition.Controls.Add(Me.Label5)
        Me.GbCondition.Controls.Add(Me.Label3)
        Me.GbCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GbCondition.Location = New System.Drawing.Point(0, 51)
        Me.GbCondition.Name = "GbCondition"
        Me.GbCondition.Size = New System.Drawing.Size(911, 118)
        Me.GbCondition.TabIndex = 146
        Me.GbCondition.TabStop = False
        '
        'cboAsin
        '
        Me.cboAsin.FormattingEnabled = True
        Me.cboAsin.Location = New System.Drawing.Point(331, 93)
        Me.cboAsin.Name = "cboAsin"
        Me.cboAsin.Size = New System.Drawing.Size(155, 20)
        Me.cboAsin.TabIndex = 159
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(290, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "ASIN："
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Red
        Me.lblMsg.Location = New System.Drawing.Point(767, 97)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 16)
        Me.lblMsg.TabIndex = 158
        '
        'CobPO
        '
        Me.CobPO.FormattingEnabled = True
        Me.CobPO.Location = New System.Drawing.Point(73, 93)
        Me.CobPO.Name = "CobPO"
        Me.CobPO.Size = New System.Drawing.Size(155, 20)
        Me.CobPO.TabIndex = 156
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 12)
        Me.Label9.TabIndex = 157
        Me.Label9.Text = "PO NO："
        '
        'CobPPID
        '
        Me.CobPPID.Location = New System.Drawing.Point(588, 68)
        Me.CobPPID.Multiline = True
        Me.CobPPID.Name = "CobPPID"
        Me.CobPPID.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.CobPPID.Size = New System.Drawing.Size(155, 44)
        Me.CobPPID.TabIndex = 143
        '
        'CobFactory
        '
        Me.CobFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobFactory.FormattingEnabled = True
        Me.CobFactory.Location = New System.Drawing.Point(588, 14)
        Me.CobFactory.Name = "CobFactory"
        Me.CobFactory.Size = New System.Drawing.Size(155, 20)
        Me.CobFactory.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(523, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "营运中心："
        '
        'DtEnd
        '
        Me.DtEnd.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtEnd.Location = New System.Drawing.Point(331, 13)
        Me.DtEnd.Name = "DtEnd"
        Me.DtEnd.Size = New System.Drawing.Size(155, 21)
        Me.DtEnd.TabIndex = 2
        Me.DtEnd.Value = New Date(2014, 6, 20, 0, 0, 0, 0)
        '
        'DtStar
        '
        Me.DtStar.CustomFormat = "yyyy/MM/dd HH:mm:ss"
        Me.DtStar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtStar.Location = New System.Drawing.Point(73, 13)
        Me.DtStar.Name = "DtStar"
        Me.DtStar.Size = New System.Drawing.Size(155, 21)
        Me.DtStar.TabIndex = 1
        Me.DtStar.Value = New Date(2007, 5, 23, 0, 0, 0, 0)
        '
        'CboCus
        '
        Me.CboCus.FormattingEnabled = True
        Me.CboCus.Location = New System.Drawing.Point(331, 66)
        Me.CboCus.Name = "CboCus"
        Me.CboCus.Size = New System.Drawing.Size(155, 20)
        Me.CboCus.TabIndex = 10
        '
        'CobDept
        '
        Me.CobDept.FormattingEnabled = True
        Me.CobDept.Location = New System.Drawing.Point(588, 41)
        Me.CobDept.Name = "CobDept"
        Me.CobDept.Size = New System.Drawing.Size(155, 20)
        Me.CobDept.TabIndex = 7
        '
        'CobPart
        '
        Me.CobPart.FormattingEnabled = True
        Me.CobPart.Location = New System.Drawing.Point(331, 40)
        Me.CobPart.Name = "CobPart"
        Me.CobPart.Size = New System.Drawing.Size(155, 20)
        Me.CobPart.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(266, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 103
        Me.Label10.Text = "客户名称："
        '
        'CobMo
        '
        Me.CobMo.FormattingEnabled = True
        Me.CobMo.Location = New System.Drawing.Point(73, 40)
        Me.CobMo.Name = "CobMo"
        Me.CobMo.Size = New System.Drawing.Size(155, 20)
        Me.CobMo.TabIndex = 5
        '
        'CobCarton
        '
        Me.CobCarton.FormattingEnabled = True
        Me.CobCarton.Location = New System.Drawing.Point(73, 65)
        Me.CobCarton.Name = "CobCarton"
        Me.CobCarton.Size = New System.Drawing.Size(155, 20)
        Me.CobCarton.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(266, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "料件编号："
        '
        'Lab
        '
        Me.Lab.AutoSize = True
        Me.Lab.Location = New System.Drawing.Point(523, 44)
        Me.Lab.Name = "Lab"
        Me.Lab.Size = New System.Drawing.Size(65, 12)
        Me.Lab.TabIndex = 91
        Me.Lab.Text = "部门名称："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "起始时间："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(522, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "产品条码："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "外箱编号："
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
        Me.Label3.Location = New System.Drawing.Point(266, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 12)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "至 "
        '
        'DgData
        '
        Me.DgData.AllowUserToAddRows = False
        Me.DgData.AllowUserToDeleteRows = False
        Me.DgData.AllowUserToOrderColumns = True
        Me.DgData.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DgData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgData.BackgroundColor = System.Drawing.Color.White
        Me.DgData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgData.ColumnHeadersHeight = 24
        Me.DgData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Booking_Key, Me.Container_No, Me.PO_No, Me.ASIN, Me.SSCC, Me.Units, Me.ExtensionBit, Me.STATUS})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgData.DefaultCellStyle = DataGridViewCellStyle9
        Me.DgData.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.DgData.Location = New System.Drawing.Point(0, 176)
        Me.DgData.MultiSelect = False
        Me.DgData.Name = "DgData"
        Me.DgData.ReadOnly = True
        Me.DgData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgData.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DgData.RowHeadersVisible = False
        Me.DgData.RowHeadersWidth = 4
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        Me.DgData.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.DgData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DgData.RowTemplate.Height = 24
        Me.DgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgData.ShowEditingIcon = False
        Me.DgData.Size = New System.Drawing.Size(911, 375)
        Me.DgData.TabIndex = 145
        Me.DgData.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 20
        '
        'Booking_Key
        '
        Me.Booking_Key.DataPropertyName = "Booking_Key"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Booking_Key.DefaultCellStyle = DataGridViewCellStyle3
        Me.Booking_Key.HeaderText = "Booking_Key"
        Me.Booking_Key.Name = "Booking_Key"
        Me.Booking_Key.ReadOnly = True
        Me.Booking_Key.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Container_No
        '
        Me.Container_No.DataPropertyName = "Container_No"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Container_No.DefaultCellStyle = DataGridViewCellStyle4
        Me.Container_No.HeaderText = "Container_No"
        Me.Container_No.Name = "Container_No"
        Me.Container_No.ReadOnly = True
        Me.Container_No.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'PO_No
        '
        Me.PO_No.DataPropertyName = "PO_No"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PO_No.DefaultCellStyle = DataGridViewCellStyle5
        Me.PO_No.HeaderText = "PO_No"
        Me.PO_No.Name = "PO_No"
        Me.PO_No.ReadOnly = True
        Me.PO_No.Width = 120
        '
        'ASIN
        '
        Me.ASIN.DataPropertyName = "ASIN"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ASIN.DefaultCellStyle = DataGridViewCellStyle6
        Me.ASIN.HeaderText = "ASIN"
        Me.ASIN.Name = "ASIN"
        Me.ASIN.ReadOnly = True
        Me.ASIN.Width = 120
        '
        'SSCC
        '
        Me.SSCC.DataPropertyName = "SSCC"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SSCC.DefaultCellStyle = DataGridViewCellStyle7
        Me.SSCC.HeaderText = "SSCC"
        Me.SSCC.Name = "SSCC"
        Me.SSCC.ReadOnly = True
        Me.SSCC.Width = 120
        '
        'Units
        '
        Me.Units.DataPropertyName = "Units"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Units.DefaultCellStyle = DataGridViewCellStyle8
        Me.Units.HeaderText = "Units"
        Me.Units.Name = "Units"
        Me.Units.ReadOnly = True
        Me.Units.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Units.Width = 80
        '
        'ExtensionBit
        '
        Me.ExtensionBit.DataPropertyName = "ExtensionBit"
        Me.ExtensionBit.HeaderText = "校验位"
        Me.ExtensionBit.Name = "ExtensionBit"
        Me.ExtensionBit.ReadOnly = True
        '
        'STATUS
        '
        Me.STATUS.DataPropertyName = "STATUS"
        Me.STATUS.HeaderText = "扫描状态"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.ReadOnly = True
        '
        'FrmAmazonQuery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 575)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GbCondition)
        Me.Controls.Add(Me.DgData)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmAmazonQuery"
        Me.Text = "Amazon出货报表"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GbCondition.ResumeLayout(False)
        Me.GbCondition.PerformLayout()
        CType(Me.DgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolReflsh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GbCondition As System.Windows.Forms.GroupBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents CobPPID As System.Windows.Forms.TextBox
    Friend WithEvents CobFactory As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtStar As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboCus As System.Windows.Forms.ComboBox
    Friend WithEvents CobDept As System.Windows.Forms.ComboBox
    Friend WithEvents CobPart As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CobMo As System.Windows.Forms.ComboBox
    Friend WithEvents CobCarton As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lab As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DgData As System.Windows.Forms.DataGridView
    Friend WithEvents cboAsin As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CobPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Booking_Key As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PO_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SSCC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Units As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtensionBit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUS As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
