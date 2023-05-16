<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewLabel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewLabel))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LabScanState = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtlineJM = New System.Windows.Forms.TextBox()
        Me.TxtDeptJM = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CobShift = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtFactory = New System.Windows.Forms.TextBox()
        Me.DtpMakeDay = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lblrealqty = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtPpid = New System.Windows.Forms.TextBox()
        Me.TxtCartonid = New System.Windows.Forms.TextBox()
        Me.TxtPartid = New System.Windows.Forms.TextBox()
        Me.TxtNeedQty = New System.Windows.Forms.TextBox()
        Me.TxtMoid = New System.Windows.Forms.TextBox()
        Me.BtPpidScan = New System.Windows.Forms.Button()
        Me.BtCartonScan = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CobNCartonid = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TsBnPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsBtTest = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsBtDrop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsBnBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.DgDcload = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtGetDc = New System.Windows.Forms.Button()
        Me.Btback = New System.Windows.Forms.Button()
        Me.DGridBarCode = New System.Windows.Forms.DataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DgDcload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "掃描結果："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabScanState
        '
        Me.LabScanState.AutoSize = True
        Me.LabScanState.ForeColor = System.Drawing.Color.Red
        Me.LabScanState.Location = New System.Drawing.Point(80, 134)
        Me.LabScanState.Name = "LabScanState"
        Me.LabScanState.Size = New System.Drawing.Size(0, 12)
        Me.LabScanState.TabIndex = 74
        Me.LabScanState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "來源箱號："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "產品序號："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TxtlineJM)
        Me.GroupBox1.Controls.Add(Me.TxtDeptJM)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.CobShift)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtFactory)
        Me.GroupBox1.Controls.Add(Me.DtpMakeDay)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Lblrealqty)
        Me.GroupBox1.Controls.Add(Me.LabScanState)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtPpid)
        Me.GroupBox1.Controls.Add(Me.TxtCartonid)
        Me.GroupBox1.Controls.Add(Me.TxtPartid)
        Me.GroupBox1.Controls.Add(Me.TxtNeedQty)
        Me.GroupBox1.Controls.Add(Me.TxtMoid)
        Me.GroupBox1.Controls.Add(Me.BtPpidScan)
        Me.GroupBox1.Controls.Add(Me.BtCartonScan)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(899, 155)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "待處理箱號條碼掃描"
        '
        'TxtlineJM
        '
        Me.TxtlineJM.Enabled = False
        Me.TxtlineJM.Location = New System.Drawing.Point(615, 44)
        Me.TxtlineJM.Name = "TxtlineJM"
        Me.TxtlineJM.Size = New System.Drawing.Size(58, 21)
        Me.TxtlineJM.TabIndex = 129
        Me.TxtlineJM.Visible = False
        '
        'TxtDeptJM
        '
        Me.TxtDeptJM.Enabled = False
        Me.TxtDeptJM.Location = New System.Drawing.Point(615, 18)
        Me.TxtDeptJM.Name = "TxtDeptJM"
        Me.TxtDeptJM.Size = New System.Drawing.Size(58, 21)
        Me.TxtDeptJM.TabIndex = 127
        Me.TxtDeptJM.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(551, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 130
        Me.Label11.Text = "線別簡碼："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(551, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 128
        Me.Label9.Text = "部門簡碼："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(422, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "班別："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobShift
        '
        Me.CobShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobShift.Enabled = False
        Me.CobShift.FormattingEnabled = True
        Me.CobShift.Items.AddRange(New Object() {"白班", "夜班"})
        Me.CobShift.Location = New System.Drawing.Point(465, 44)
        Me.CobShift.Name = "CobShift"
        Me.CobShift.Size = New System.Drawing.Size(79, 20)
        Me.CobShift.TabIndex = 125
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(410, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "工廠別："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtFactory
        '
        Me.TxtFactory.Enabled = False
        Me.TxtFactory.Location = New System.Drawing.Point(466, 18)
        Me.TxtFactory.Name = "TxtFactory"
        Me.TxtFactory.Size = New System.Drawing.Size(79, 21)
        Me.TxtFactory.TabIndex = 123
        '
        'DtpMakeDay
        '
        Me.DtpMakeDay.CustomFormat = "yyyy-MM-dd "
        Me.DtpMakeDay.Enabled = False
        Me.DtpMakeDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpMakeDay.Location = New System.Drawing.Point(282, 47)
        Me.DtpMakeDay.Name = "DtpMakeDay"
        Me.DtpMakeDay.Size = New System.Drawing.Size(119, 21)
        Me.DtpMakeDay.TabIndex = 122
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(209, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "生產日期："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lblrealqty
        '
        Me.Lblrealqty.AutoSize = True
        Me.Lblrealqty.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Lblrealqty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Lblrealqty.Location = New System.Drawing.Point(481, 134)
        Me.Lblrealqty.Name = "Lblrealqty"
        Me.Lblrealqty.Size = New System.Drawing.Size(12, 12)
        Me.Lblrealqty.TabIndex = 105
        Me.Lblrealqty.Text = "0"
        Me.Lblrealqty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(410, 134)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 12)
        Me.Label19.TabIndex = 104
        Me.Label19.Text = "实装数量："
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPpid
        '
        Me.TxtPpid.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.TxtPpid.Location = New System.Drawing.Point(81, 102)
        Me.TxtPpid.Name = "TxtPpid"
        Me.TxtPpid.Size = New System.Drawing.Size(320, 21)
        Me.TxtPpid.TabIndex = 4
        '
        'TxtCartonid
        '
        Me.TxtCartonid.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.TxtCartonid.Location = New System.Drawing.Point(81, 74)
        Me.TxtCartonid.Name = "TxtCartonid"
        Me.TxtCartonid.Size = New System.Drawing.Size(320, 21)
        Me.TxtCartonid.TabIndex = 2
        '
        'TxtPartid
        '
        Me.TxtPartid.Enabled = False
        Me.TxtPartid.Location = New System.Drawing.Point(281, 18)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(120, 21)
        Me.TxtPartid.TabIndex = 120
        '
        'TxtNeedQty
        '
        Me.TxtNeedQty.AcceptsReturn = True
        Me.TxtNeedQty.Location = New System.Drawing.Point(81, 46)
        Me.TxtNeedQty.Name = "TxtNeedQty"
        Me.TxtNeedQty.Size = New System.Drawing.Size(120, 21)
        Me.TxtNeedQty.TabIndex = 1
        '
        'TxtMoid
        '
        Me.TxtMoid.Enabled = False
        Me.TxtMoid.Location = New System.Drawing.Point(82, 18)
        Me.TxtMoid.Name = "TxtMoid"
        Me.TxtMoid.Size = New System.Drawing.Size(120, 21)
        Me.TxtMoid.TabIndex = 115
        '
        'BtPpidScan
        '
        Me.BtPpidScan.Image = CType(resources.GetObject("BtPpidScan.Image"), System.Drawing.Image)
        Me.BtPpidScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPpidScan.Location = New System.Drawing.Point(433, 101)
        Me.BtPpidScan.Name = "BtPpidScan"
        Me.BtPpidScan.Size = New System.Drawing.Size(81, 23)
        Me.BtPpidScan.TabIndex = 5
        Me.BtPpidScan.Text = "產品掃描"
        Me.BtPpidScan.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtPpidScan.UseVisualStyleBackColor = True
        '
        'BtCartonScan
        '
        Me.BtCartonScan.Image = CType(resources.GetObject("BtCartonScan.Image"), System.Drawing.Image)
        Me.BtCartonScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCartonScan.Location = New System.Drawing.Point(433, 73)
        Me.BtCartonScan.Name = "BtCartonScan"
        Me.BtCartonScan.Size = New System.Drawing.Size(81, 23)
        Me.BtCartonScan.TabIndex = 3
        Me.BtCartonScan.Text = "箱號掃描"
        Me.BtCartonScan.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtCartonScan.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "應裝數量："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 102
        Me.Label10.Text = "工單編號："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(210, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "AVC  P/N："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobNCartonid
        '
        Me.CobNCartonid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobNCartonid.FormattingEnabled = True
        Me.CobNCartonid.Location = New System.Drawing.Point(82, 32)
        Me.CobNCartonid.Name = "CobNCartonid"
        Me.CobNCartonid.Size = New System.Drawing.Size(319, 20)
        Me.CobNCartonid.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "新箱序號："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsBnPrint, Me.ToolStripSeparator1, Me.TsBtTest, Me.ToolStripSeparator2, Me.TsBtDrop, Me.ToolStripSeparator3, Me.TsBnBack, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(899, 25)
        Me.ToolStrip1.TabIndex = 118
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TsBnPrint
        '
        Me.TsBnPrint.Image = CType(resources.GetObject("TsBnPrint.Image"), System.Drawing.Image)
        Me.TsBnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBnPrint.Name = "TsBnPrint"
        Me.TsBnPrint.Size = New System.Drawing.Size(91, 22)
        Me.TsBnPrint.Text = "新箱打印(&P)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TsBtTest
        '
        Me.TsBtTest.Image = CType(resources.GetObject("TsBtTest.Image"), System.Drawing.Image)
        Me.TsBtTest.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtTest.Name = "TsBtTest"
        Me.TsBtTest.Size = New System.Drawing.Size(91, 22)
        Me.TsBtTest.Text = "測試打印(&T)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TsBtDrop
        '
        Me.TsBtDrop.Image = CType(resources.GetObject("TsBtDrop.Image"), System.Drawing.Image)
        Me.TsBtDrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtDrop.Name = "TsBtDrop"
        Me.TsBtDrop.Size = New System.Drawing.Size(93, 22)
        Me.TsBtDrop.Text = "異常捨棄(&D)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TsBnBack
        '
        Me.TsBnBack.Image = CType(resources.GetObject("TsBnBack.Image"), System.Drawing.Image)
        Me.TsBnBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBnBack.Name = "TsBnBack"
        Me.TsBnBack.Size = New System.Drawing.Size(75, 22)
        Me.TsBnBack.Text = "返  回(&E)"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'DgDcload
        '
        Me.DgDcload.AllowUserToAddRows = False
        Me.DgDcload.AllowUserToDeleteRows = False
        Me.DgDcload.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DgDcload.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgDcload.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DgDcload.BackgroundColor = System.Drawing.Color.White
        Me.DgDcload.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgDcload.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgDcload.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgDcload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgDcload.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.DgDcload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgDcload.Location = New System.Drawing.Point(0, 0)
        Me.DgDcload.Name = "DgDcload"
        Me.DgDcload.RowHeadersWidth = 4
        Me.DgDcload.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgDcload.RowTemplate.Height = 24
        Me.DgDcload.Size = New System.Drawing.Size(897, 135)
        Me.DgDcload.StandardTab = True
        Me.DgDcload.TabIndex = 5
        '
        'Column1
        '
        Me.Column1.HeaderText = "選擇"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 35
        '
        'Column2
        '
        Me.Column2.HeaderText = "舊箱編號"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 78
        '
        'Column3
        '
        Me.Column3.HeaderText = "日期碼"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 66
        '
        'Column4
        '
        Me.Column4.HeaderText = "箱內數量"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 78
        '
        'Column5
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "遷移數量"
        Me.Column5.MaxInputLength = 5
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 78
        '
        'BtGetDc
        '
        Me.BtGetDc.Image = CType(resources.GetObject("BtGetDc.Image"), System.Drawing.Image)
        Me.BtGetDc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtGetDc.Location = New System.Drawing.Point(188, 13)
        Me.BtGetDc.Name = "BtGetDc"
        Me.BtGetDc.Size = New System.Drawing.Size(66, 23)
        Me.BtGetDc.TabIndex = 4
        Me.BtGetDc.Text = "確定"
        Me.BtGetDc.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtGetDc.UseVisualStyleBackColor = True
        '
        'Btback
        '
        Me.Btback.Image = CType(resources.GetObject("Btback.Image"), System.Drawing.Image)
        Me.Btback.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btback.Location = New System.Drawing.Point(344, 13)
        Me.Btback.Name = "Btback"
        Me.Btback.Size = New System.Drawing.Size(66, 23)
        Me.Btback.TabIndex = 5
        Me.Btback.Text = "取消"
        Me.Btback.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Btback.UseVisualStyleBackColor = True
        '
        'DGridBarCode
        '
        Me.DGridBarCode.AllowUserToAddRows = False
        Me.DGridBarCode.AllowUserToDeleteRows = False
        Me.DGridBarCode.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.DGridBarCode.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGridBarCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGridBarCode.BackgroundColor = System.Drawing.Color.White
        Me.DGridBarCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGridBarCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGridBarCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGridBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridBarCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGridBarCode.Location = New System.Drawing.Point(3, 17)
        Me.DGridBarCode.Name = "DGridBarCode"
        Me.DGridBarCode.ReadOnly = True
        Me.DGridBarCode.RowHeadersWidth = 4
        Me.DGridBarCode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGridBarCode.RowTemplate.Height = 24
        Me.DGridBarCode.ShowEditingIcon = False
        Me.DGridBarCode.Size = New System.Drawing.Size(891, 115)
        Me.DGridBarCode.StandardTab = True
        Me.DGridBarCode.TabIndex = 2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DgDcload)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.BtGetDc)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Btback)
        Me.SplitContainer2.Size = New System.Drawing.Size(899, 192)
        Me.SplitContainer2.SplitterDistance = 137
        Me.SplitContainer2.TabIndex = 4
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 219)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(899, 333)
        Me.SplitContainer1.SplitterDistance = 137
        Me.SplitContainer1.TabIndex = 119
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.DGridBarCode)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(897, 135)
        Me.GroupBox3.TabIndex = 80
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "條碼掃描記錄"
        '
        'FrmNewLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 554)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.CobNCartonid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmNewLabel"
        Me.Text = "拆合箱作業"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DgDcload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LabScanState As System.Windows.Forms.Label
    Friend WithEvents BtCartonScan As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Lblrealqty As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtPpidScan As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtMoid As System.Windows.Forms.TextBox
    Friend WithEvents TxtPartid As System.Windows.Forms.TextBox
    Friend WithEvents TxtNeedQty As System.Windows.Forms.TextBox
    Friend WithEvents CobNCartonid As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPpid As System.Windows.Forms.TextBox
    Friend WithEvents TxtCartonid As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TsBnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsBtTest As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsBtDrop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsBnBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Btback As System.Windows.Forms.Button
    Friend WithEvents BtGetDc As System.Windows.Forms.Button
    Friend WithEvents DgDcload As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtpMakeDay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CobShift As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtFactory As System.Windows.Forms.TextBox
    Friend WithEvents TxtlineJM As System.Windows.Forms.TextBox
    Friend WithEvents TxtDeptJM As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DGridBarCode As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class
