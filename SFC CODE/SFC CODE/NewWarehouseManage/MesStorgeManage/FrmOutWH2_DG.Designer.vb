<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOutWH2_DG
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOutWH2_DG))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtPalletID = New TextCtrlV.ClassTextUnCtrlV()
        Me.LabCartCoun = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtCartonid = New TextCtrlV.ClassTextUnCtrlV()
        Me.LabSumQty = New System.Windows.Forms.Label()
        Me.LabScanType = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LabelState = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtTranType = New System.Windows.Forms.TextBox()
        Me.LabShipType = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtConfirm = New System.Windows.Forms.ToolStripButton()
        Me.BtReuse = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtOtherOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.chkReuse = New System.Windows.Forms.CheckBox()
        Me.RbCartonScan = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtDrop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.BtBack = New System.Windows.Forms.ToolStripButton()
        Me.LabCQty = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCust = New System.Windows.Forms.TextBox()
        Me.RbPalletScan = New System.Windows.Forms.RadioButton()
        Me.PlScan = New System.Windows.Forms.Panel()
        Me.CobInvoice = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtAddress = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtBusNo = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolLblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DGScanList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGShipList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClmInvoiceJob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.PlScan.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DGScanList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGShipList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtPalletID
        '
        Me.TxtPalletID.Location = New System.Drawing.Point(70, 56)
        Me.TxtPalletID.Name = "TxtPalletID"
        Me.TxtPalletID.Size = New System.Drawing.Size(356, 21)
        Me.TxtPalletID.TabIndex = 111
        '
        'LabCartCoun
        '
        Me.LabCartCoun.AutoSize = True
        Me.LabCartCoun.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabCartCoun.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LabCartCoun.Location = New System.Drawing.Point(465, 10)
        Me.LabCartCoun.Name = "LabCartCoun"
        Me.LabCartCoun.Size = New System.Drawing.Size(18, 19)
        Me.LabCartCoun.TabIndex = 102
        Me.LabCartCoun.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "棧板序號:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtCartonid
        '
        Me.TxtCartonid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCartonid.Location = New System.Drawing.Point(70, 30)
        Me.TxtCartonid.Name = "TxtCartonid"
        Me.TxtCartonid.Size = New System.Drawing.Size(356, 21)
        Me.TxtCartonid.TabIndex = 112
        '
        'LabSumQty
        '
        Me.LabSumQty.AutoSize = True
        Me.LabSumQty.ForeColor = System.Drawing.Color.Red
        Me.LabSumQty.Location = New System.Drawing.Point(343, 70)
        Me.LabSumQty.Name = "LabSumQty"
        Me.LabSumQty.Size = New System.Drawing.Size(0, 12)
        Me.LabSumQty.TabIndex = 98
        Me.LabSumQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabScanType
        '
        Me.LabScanType.AutoSize = True
        Me.LabScanType.Location = New System.Drawing.Point(8, 35)
        Me.LabScanType.Name = "LabScanType"
        Me.LabScanType.Size = New System.Drawing.Size(59, 12)
        Me.LabScanType.TabIndex = 94
        Me.LabScanType.Text = "外箱序號:"
        Me.LabScanType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(398, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(71, 12)
        Me.Label17.TabIndex = 95
        Me.Label17.Text = "已扫描箱数:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(567, 53)
        Me.txtRemark.MaxLength = 50
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(160, 46)
        Me.txtRemark.TabIndex = 128
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(527, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 12)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "备注:"
        '
        'LabelState
        '
        Me.LabelState.AutoSize = True
        Me.LabelState.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LabelState.Location = New System.Drawing.Point(429, 32)
        Me.LabelState.Name = "LabelState"
        Me.LabelState.Size = New System.Drawing.Size(0, 12)
        Me.LabelState.TabIndex = 126
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(386, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 125
        Me.Label5.Text = "状态:"
        '
        'TxtTranType
        '
        Me.TxtTranType.BackColor = System.Drawing.Color.White
        Me.TxtTranType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTranType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.TxtTranType.Location = New System.Drawing.Point(318, 53)
        Me.TxtTranType.Name = "TxtTranType"
        Me.TxtTranType.ReadOnly = True
        Me.TxtTranType.Size = New System.Drawing.Size(203, 21)
        Me.TxtTranType.TabIndex = 124
        Me.TxtTranType.TabStop = False
        '
        'LabShipType
        '
        Me.LabShipType.AutoSize = True
        Me.LabShipType.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabShipType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LabShipType.Location = New System.Drawing.Point(319, 32)
        Me.LabShipType.Name = "LabShipType"
        Me.LabShipType.Size = New System.Drawing.Size(0, 12)
        Me.LabShipType.TabIndex = 123
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(254, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 12)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "出货类型:"
        '
        'BtConfirm
        '
        Me.BtConfirm.Image = CType(resources.GetObject("BtConfirm.Image"), System.Drawing.Image)
        Me.BtConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtConfirm.Name = "BtConfirm"
        Me.BtConfirm.Size = New System.Drawing.Size(67, 22)
        Me.BtConfirm.Text = "确认(&S)"
        '
        'BtReuse
        '
        Me.BtReuse.Image = CType(resources.GetObject("BtReuse.Image"), System.Drawing.Image)
        Me.BtReuse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtReuse.Name = "BtReuse"
        Me.BtReuse.Size = New System.Drawing.Size(68, 22)
        Me.BtReuse.Text = "驳回(&R)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BtOtherOut
        '
        Me.BtOtherOut.Image = CType(resources.GetObject("BtOtherOut.Image"), System.Drawing.Image)
        Me.BtOtherOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtOtherOut.Name = "BtOtherOut"
        Me.BtOtherOut.Size = New System.Drawing.Size(91, 22)
        Me.BtOtherOut.Text = "其它出库(&T)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(0, 22)
        '
        'chkReuse
        '
        Me.chkReuse.AutoSize = True
        Me.chkReuse.Location = New System.Drawing.Point(246, 12)
        Me.chkReuse.Name = "chkReuse"
        Me.chkReuse.Size = New System.Drawing.Size(96, 16)
        Me.chkReuse.TabIndex = 5
        Me.chkReuse.Text = "移除扫描数据"
        Me.chkReuse.UseVisualStyleBackColor = True
        '
        'RbCartonScan
        '
        Me.RbCartonScan.AutoSize = True
        Me.RbCartonScan.Checked = True
        Me.RbCartonScan.Enabled = False
        Me.RbCartonScan.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RbCartonScan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.RbCartonScan.Location = New System.Drawing.Point(10, 12)
        Me.RbCartonScan.Name = "RbCartonScan"
        Me.RbCartonScan.Size = New System.Drawing.Size(75, 16)
        Me.RbCartonScan.TabIndex = 4
        Me.RbCartonScan.TabStop = True
        Me.RbCartonScan.Text = "外箱编号"
        Me.RbCartonScan.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtDrop, Me.ToolStripLabel1, Me.ToolStripLabel2, Me.ToolStripSeparator2, Me.BtReuse, Me.BtConfirm, Me.ToolStripSeparator5, Me.BtOtherOut, Me.ToolStripSeparator3, Me.BtBack})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(834, 25)
        Me.ToolStrip1.TabIndex = 115
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtDrop
        '
        Me.BtDrop.Image = CType(resources.GetObject("BtDrop.Image"), System.Drawing.Image)
        Me.BtDrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtDrop.Name = "BtDrop"
        Me.BtDrop.Size = New System.Drawing.Size(69, 22)
        Me.BtDrop.Text = "舍弃(&D)"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'BtBack
        '
        Me.BtBack.ForeColor = System.Drawing.Color.Black
        Me.BtBack.Image = CType(resources.GetObject("BtBack.Image"), System.Drawing.Image)
        Me.BtBack.ImageTransparentColor = System.Drawing.Color.White
        Me.BtBack.Name = "BtBack"
        Me.BtBack.Size = New System.Drawing.Size(72, 22)
        Me.BtBack.Text = "退 出(&X)"
        Me.BtBack.ToolTipText = "退 出"
        '
        'LabCQty
        '
        Me.LabCQty.AutoSize = True
        Me.LabCQty.ForeColor = System.Drawing.Color.Red
        Me.LabCQty.Location = New System.Drawing.Point(466, 7)
        Me.LabCQty.Name = "LabCQty"
        Me.LabCQty.Size = New System.Drawing.Size(0, 12)
        Me.LabCQty.TabIndex = 96
        Me.LabCQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "出货客户:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 12)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "出货地址:"
        '
        'TxtCust
        '
        Me.TxtCust.BackColor = System.Drawing.Color.White
        Me.TxtCust.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCust.ForeColor = System.Drawing.Color.Black
        Me.TxtCust.Location = New System.Drawing.Point(81, 53)
        Me.TxtCust.Name = "TxtCust"
        Me.TxtCust.ReadOnly = True
        Me.TxtCust.Size = New System.Drawing.Size(154, 21)
        Me.TxtCust.TabIndex = 116
        Me.TxtCust.TabStop = False
        '
        'RbPalletScan
        '
        Me.RbPalletScan.AutoSize = True
        Me.RbPalletScan.Enabled = False
        Me.RbPalletScan.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RbPalletScan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.RbPalletScan.Location = New System.Drawing.Point(121, 12)
        Me.RbPalletScan.Name = "RbPalletScan"
        Me.RbPalletScan.Size = New System.Drawing.Size(75, 16)
        Me.RbPalletScan.TabIndex = 5
        Me.RbPalletScan.Text = "栈板编号"
        Me.RbPalletScan.UseVisualStyleBackColor = True
        '
        'PlScan
        '
        Me.PlScan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlScan.Controls.Add(Me.TxtCartonid)
        Me.PlScan.Controls.Add(Me.TxtPalletID)
        Me.PlScan.Controls.Add(Me.LabCartCoun)
        Me.PlScan.Controls.Add(Me.Label6)
        Me.PlScan.Controls.Add(Me.LabSumQty)
        Me.PlScan.Controls.Add(Me.LabScanType)
        Me.PlScan.Controls.Add(Me.Label17)
        Me.PlScan.Controls.Add(Me.LabCQty)
        Me.PlScan.Controls.Add(Me.chkReuse)
        Me.PlScan.Controls.Add(Me.RbCartonScan)
        Me.PlScan.Controls.Add(Me.RbPalletScan)
        Me.PlScan.Location = New System.Drawing.Point(0, 247)
        Me.PlScan.Name = "PlScan"
        Me.PlScan.Size = New System.Drawing.Size(836, 99)
        Me.PlScan.TabIndex = 112
        '
        'CobInvoice
        '
        Me.CobInvoice.FormattingEnabled = True
        Me.CobInvoice.Location = New System.Drawing.Point(81, 29)
        Me.CobInvoice.Name = "CobInvoice"
        Me.CobInvoice.Size = New System.Drawing.Size(154, 20)
        Me.CobInvoice.TabIndex = 118
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(254, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "运输方式:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Invoice No:"
        '
        'TxtAddress
        '
        Me.TxtAddress.BackColor = System.Drawing.Color.White
        Me.TxtAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddress.ForeColor = System.Drawing.Color.Black
        Me.TxtAddress.Location = New System.Drawing.Point(81, 78)
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.ReadOnly = True
        Me.TxtAddress.Size = New System.Drawing.Size(440, 21)
        Me.TxtAddress.TabIndex = 117
        Me.TxtAddress.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(516, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 12)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "货柜号:"
        '
        'TxtBusNo
        '
        Me.TxtBusNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBusNo.ForeColor = System.Drawing.Color.Black
        Me.TxtBusNo.Location = New System.Drawing.Point(567, 28)
        Me.TxtBusNo.Name = "TxtBusNo"
        Me.TxtBusNo.Size = New System.Drawing.Size(160, 21)
        Me.TxtBusNo.TabIndex = 129
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolLblCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 600)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(834, 22)
        Me.StatusStrip1.TabIndex = 130
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
        'DGScanList
        '
        Me.DGScanList.AllowUserToAddRows = False
        Me.DGScanList.AllowUserToDeleteRows = False
        Me.DGScanList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGScanList.BackgroundColor = System.Drawing.Color.White
        Me.DGScanList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGScanList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGScanList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column8, Me.Column9})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGScanList.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGScanList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGScanList.Location = New System.Drawing.Point(2, 352)
        Me.DGScanList.Name = "DGScanList"
        Me.DGScanList.ReadOnly = True
        Me.DGScanList.RowHeadersWidth = 4
        Me.DGScanList.RowTemplate.Height = 23
        Me.DGScanList.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.DGScanList.Size = New System.Drawing.Size(830, 245)
        Me.DGScanList.TabIndex = 131
        '
        'Column1
        '
        Me.Column1.HeaderText = "序号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "料件编号"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "栈板编号"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "外箱编号"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "装箱数量"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "扫描人员"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "扫描时间"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'DGShipList
        '
        Me.DGShipList.AllowUserToAddRows = False
        Me.DGShipList.AllowUserToDeleteRows = False
        Me.DGShipList.BackgroundColor = System.Drawing.Color.White
        Me.DGShipList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGShipList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGShipList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column7, Me.Column10, Me.Column11, Me.Column12, Me.ClmInvoiceJob, Me.ScanY})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGShipList.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGShipList.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DGShipList.Location = New System.Drawing.Point(3, 109)
        Me.DGShipList.Name = "DGShipList"
        Me.DGShipList.RowHeadersWidth = 4
        Me.DGShipList.RowTemplate.Height = 23
        Me.DGShipList.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.DGShipList.Size = New System.Drawing.Size(831, 132)
        Me.DGShipList.TabIndex = 132
        '
        'Column2
        '
        Me.Column2.HeaderText = "选择"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 70
        '
        'Column7
        '
        Me.Column7.HeaderText = "料件编号"
        Me.Column7.Name = "Column7"
        '
        'Column10
        '
        Me.Column10.HeaderText = "出货数量"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.HeaderText = "已扫描数量"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "状态"
        Me.Column12.Name = "Column12"
        '
        'ClmInvoiceJob
        '
        Me.ClmInvoiceJob.HeaderText = "出货扫描单号"
        Me.ClmInvoiceJob.Name = "ClmInvoiceJob"
        '
        'ScanY
        '
        Me.ScanY.HeaderText = "是否需要扫描"
        Me.ScanY.Name = "ScanY"
        '
        'FrmOutWH2_DG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 622)
        Me.Controls.Add(Me.DGShipList)
        Me.Controls.Add(Me.DGScanList)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TxtBusNo)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LabelState)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtTranType)
        Me.Controls.Add(Me.LabShipType)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCust)
        Me.Controls.Add(Me.PlScan)
        Me.Controls.Add(Me.CobInvoice)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtAddress)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmOutWH2_DG"
        Me.Text = "FrmOutWH2_DG"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PlScan.ResumeLayout(False)
        Me.PlScan.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DGScanList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGShipList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtPalletID As TextCtrlV.ClassTextUnCtrlV
    Friend WithEvents LabCartCoun As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtCartonid As TextCtrlV.ClassTextUnCtrlV
    Friend WithEvents LabSumQty As System.Windows.Forms.Label
    Friend WithEvents LabScanType As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LabelState As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtTranType As System.Windows.Forms.TextBox
    Friend WithEvents LabShipType As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtConfirm As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtReuse As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtOtherOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents chkReuse As System.Windows.Forms.CheckBox
    Friend WithEvents RbCartonScan As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtDrop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LabCQty As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCust As System.Windows.Forms.TextBox
    Friend WithEvents RbPalletScan As System.Windows.Forms.RadioButton
    Friend WithEvents PlScan As System.Windows.Forms.Panel
    Friend WithEvents CobInvoice As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtBusNo As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolLblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents DGScanList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGShipList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClmInvoiceJob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanY As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
