<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReworkOut_DG
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReworkOut_DG))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsBnOutBill = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsBtEnter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TsBtDrop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsBnBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.TxtPartid = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtPScan = New System.Windows.Forms.Button()
        Me.TxtPalletid = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabSumQty = New System.Windows.Forms.Label()
        Me.BtCScan = New System.Windows.Forms.Button()
        Me.TxtCartonId = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LabCQty = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtOuttime = New System.Windows.Forms.TextBox()
        Me.TxtObject = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtRwDept = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CobRwMoid = New System.Windows.Forms.ComboBox()
        Me.CobRwBill = New System.Windows.Forms.ComboBox()
        Me.TxtDescript = New System.Windows.Forms.TextBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtRwQty = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGridBarCode = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TsBnOutBill
        '
        Me.TsBnOutBill.Image = CType(resources.GetObject("TsBnOutBill.Image"), System.Drawing.Image)
        Me.TsBnOutBill.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBnOutBill.Name = "TsBnOutBill"
        Me.TsBnOutBill.Size = New System.Drawing.Size(92, 22)
        Me.TsBnOutBill.Text = "新增單據(&A)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TsBtEnter
        '
        Me.TsBtEnter.Image = CType(resources.GetObject("TsBtEnter.Image"), System.Drawing.Image)
        Me.TsBtEnter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsBtEnter.Name = "TsBtEnter"
        Me.TsBtEnter.Size = New System.Drawing.Size(91, 22)
        Me.TsBtEnter.Text = "確認出庫(&S)"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsBnOutBill, Me.ToolStripSeparator1, Me.TsBtEnter, Me.ToolStripSeparator2, Me.TsBtDrop, Me.ToolStripSeparator3, Me.TsBnBack, Me.ToolStripLabel1, Me.ToolStripLabel2, Me.ToolStripLabel3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(792, 25)
        Me.ToolStrip1.TabIndex = 83
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripLabel2.Text = "                      "
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripLabel3.Text = "出庫單號:"
        '
        'TxtPartid
        '
        Me.TxtPartid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPartid.Enabled = False
        Me.TxtPartid.Location = New System.Drawing.Point(80, 45)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(123, 21)
        Me.TxtPartid.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "產品料號："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtPScan)
        Me.Panel4.Controls.Add(Me.TxtPalletid)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.LabSumQty)
        Me.Panel4.Controls.Add(Me.BtCScan)
        Me.Panel4.Controls.Add(Me.TxtCartonId)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.LabCQty)
        Me.Panel4.Location = New System.Drawing.Point(1, 126)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(791, 91)
        Me.Panel4.TabIndex = 49
        '
        'BtPScan
        '
        Me.BtPScan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtPScan.Image = CType(resources.GetObject("BtPScan.Image"), System.Drawing.Image)
        Me.BtPScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtPScan.Location = New System.Drawing.Point(508, 37)
        Me.BtPScan.Name = "BtPScan"
        Me.BtPScan.Size = New System.Drawing.Size(83, 23)
        Me.BtPScan.TabIndex = 5
        Me.BtPScan.Text = "棧板掃描"
        Me.BtPScan.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtPScan.UseVisualStyleBackColor = True
        Me.BtPScan.Visible = False
        '
        'TxtPalletid
        '
        Me.TxtPalletid.BackColor = System.Drawing.Color.White
        Me.TxtPalletid.Location = New System.Drawing.Point(79, 35)
        Me.TxtPalletid.Name = "TxtPalletid"
        Me.TxtPalletid.Size = New System.Drawing.Size(330, 21)
        Me.TxtPalletid.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "棧板序號："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(215, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "產品總數："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabSumQty
        '
        Me.LabSumQty.AutoSize = True
        Me.LabSumQty.ForeColor = System.Drawing.Color.Red
        Me.LabSumQty.Location = New System.Drawing.Point(286, 68)
        Me.LabSumQty.Name = "LabSumQty"
        Me.LabSumQty.Size = New System.Drawing.Size(0, 12)
        Me.LabSumQty.TabIndex = 76
        Me.LabSumQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtCScan
        '
        Me.BtCScan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtCScan.Image = CType(resources.GetObject("BtCScan.Image"), System.Drawing.Image)
        Me.BtCScan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtCScan.Location = New System.Drawing.Point(508, 6)
        Me.BtCScan.Name = "BtCScan"
        Me.BtCScan.Size = New System.Drawing.Size(83, 23)
        Me.BtCScan.TabIndex = 3
        Me.BtCScan.Text = "箱號掃描"
        Me.BtCScan.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BtCScan.UseVisualStyleBackColor = True
        Me.BtCScan.Visible = False
        '
        'TxtCartonId
        '
        Me.TxtCartonId.BackColor = System.Drawing.Color.White
        Me.TxtCartonId.Location = New System.Drawing.Point(79, 7)
        Me.TxtCartonId.Name = "TxtCartonId"
        Me.TxtCartonId.Size = New System.Drawing.Size(330, 21)
        Me.TxtCartonId.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "包裝箱號："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 68)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 12)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "已掃箱數："
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabCQty
        '
        Me.LabCQty.AutoSize = True
        Me.LabCQty.ForeColor = System.Drawing.Color.Red
        Me.LabCQty.Location = New System.Drawing.Point(80, 68)
        Me.LabCQty.Name = "LabCQty"
        Me.LabCQty.Size = New System.Drawing.Size(0, 12)
        Me.LabCQty.TabIndex = 56
        Me.LabCQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(216, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "工單數量："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtOuttime
        '
        Me.TxtOuttime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOuttime.Enabled = False
        Me.TxtOuttime.Location = New System.Drawing.Point(287, 45)
        Me.TxtOuttime.Name = "TxtOuttime"
        Me.TxtOuttime.Size = New System.Drawing.Size(123, 21)
        Me.TxtOuttime.TabIndex = 6
        '
        'TxtObject
        '
        Me.TxtObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtObject.Enabled = False
        Me.TxtObject.Location = New System.Drawing.Point(287, 71)
        Me.TxtObject.Name = "TxtObject"
        Me.TxtObject.Size = New System.Drawing.Size(123, 21)
        Me.TxtObject.TabIndex = 85
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(216, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "需求對象："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtRwDept
        '
        Me.TxtRwDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRwDept.Enabled = False
        Me.TxtRwDept.Location = New System.Drawing.Point(80, 71)
        Me.TxtRwDept.Name = "TxtRwDept"
        Me.TxtRwDept.Size = New System.Drawing.Size(123, 21)
        Me.TxtRwDept.TabIndex = 83
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(424, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 88
        Me.Label11.Text = "出庫備註："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobRwMoid
        '
        Me.CobRwMoid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobRwMoid.Location = New System.Drawing.Point(80, 18)
        Me.CobRwMoid.Name = "CobRwMoid"
        Me.CobRwMoid.Size = New System.Drawing.Size(123, 20)
        Me.CobRwMoid.TabIndex = 1
        '
        'CobRwBill
        '
        Me.CobRwBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobRwBill.FormattingEnabled = True
        Me.CobRwBill.Location = New System.Drawing.Point(538, 3)
        Me.CobRwBill.Name = "CobRwBill"
        Me.CobRwBill.Size = New System.Drawing.Size(123, 20)
        Me.CobRwBill.TabIndex = 0
        '
        'TxtDescript
        '
        Me.TxtDescript.Enabled = False
        Me.TxtDescript.Location = New System.Drawing.Point(491, 19)
        Me.TxtDescript.Multiline = True
        Me.TxtDescript.Name = "TxtDescript"
        Me.TxtDescript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDescript.Size = New System.Drawing.Size(123, 74)
        Me.TxtDescript.TabIndex = 87
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer3.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.AutoScroll = True
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer3.Panel1.Controls.Add(Me.CobRwBill)
        Me.SplitContainer3.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel4)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.AutoScroll = True
        Me.SplitContainer3.Panel2.Controls.Add(Me.DGridBarCode)
        Me.SplitContainer3.Size = New System.Drawing.Size(792, 580)
        Me.SplitContainer3.SplitterDistance = 219
        Me.SplitContainer3.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.CobRwMoid)
        Me.GroupBox2.Controls.Add(Me.TxtDescript)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TxtObject)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TxtRwDept)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TxtRwQty)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TxtOuttime)
        Me.GroupBox2.Controls.Add(Me.TxtPartid)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(791, 99)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "重工出库基础资料"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "重工部門："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtRwQty
        '
        Me.TxtRwQty.Location = New System.Drawing.Point(287, 19)
        Me.TxtRwQty.Name = "TxtRwQty"
        Me.TxtRwQty.Size = New System.Drawing.Size(123, 21)
        Me.TxtRwQty.TabIndex = 80
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "重工工單："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(216, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "出庫時間："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DGridBarCode
        '
        Me.DGridBarCode.AllowUserToAddRows = False
        Me.DGridBarCode.AllowUserToDeleteRows = False
        Me.DGridBarCode.AllowUserToOrderColumns = True
        Me.DGridBarCode.BackgroundColor = System.Drawing.Color.White
        Me.DGridBarCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGridBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGridBarCode.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGridBarCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGridBarCode.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGridBarCode.Location = New System.Drawing.Point(0, 0)
        Me.DGridBarCode.Name = "DGridBarCode"
        Me.DGridBarCode.ReadOnly = True
        Me.DGridBarCode.RowHeadersWidth = 4
        Me.DGridBarCode.RowTemplate.Height = 23
        Me.DGridBarCode.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.DGridBarCode.Size = New System.Drawing.Size(792, 357)
        Me.DGridBarCode.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 586)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(785, 22)
        Me.StatusStrip1.TabIndex = 121
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
        Me.ToolLblCount.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolLblCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.LinkColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.ToolLblCount.Name = "ToolLblCount"
        Me.ToolLblCount.Size = New System.Drawing.Size(12, 17)
        Me.ToolLblCount.Text = "0"
        '
        'FrmReworkOut_DG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 608)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmReworkOut_DG"
        Me.Text = "FrmReworkOut_DG"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsBnOutBill As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsBtEnter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TsBtDrop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TsBnBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TxtPartid As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtPScan As System.Windows.Forms.Button
    Friend WithEvents TxtPalletid As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabSumQty As System.Windows.Forms.Label
    Friend WithEvents BtCScan As System.Windows.Forms.Button
    Friend WithEvents TxtCartonId As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LabCQty As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtOuttime As System.Windows.Forms.TextBox
    Friend WithEvents TxtObject As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtRwDept As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CobRwMoid As System.Windows.Forms.ComboBox
    Friend WithEvents CobRwBill As System.Windows.Forms.ComboBox
    Friend WithEvents TxtDescript As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtRwQty As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGridBarCode As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
End Class
