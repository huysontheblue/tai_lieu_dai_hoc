<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCheckDigitPrt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCheckDigitPrt))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GrpStyleSet = New System.Windows.Forms.GroupBox()
        Me.TxtCcMsg = New System.Windows.Forms.TextBox()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.LblMoidPrinted = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblDeptid = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblMoidNum = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.LblCusPart = New System.Windows.Forms.Label()
        Me.LblAVCPart = New System.Windows.Forms.Label()
        Me.CboMoid = New System.Windows.Forms.ComboBox()
        Me.LblPrintPaper = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BnEdit = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblPrintDate = New System.Windows.Forms.Label()
        Me.LblCusName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpPrintSet = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPrintNum = New System.Windows.Forms.TextBox()
        Me.LblYN = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolTestPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolBeginPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolPrintLast = New System.Windows.Forms.ToolStripButton()
        Me.ToolView = New System.Windows.Forms.ToolStripButton()
        Me.ToolQuit = New System.Windows.Forms.ToolStripButton()
        Me.DgPartSet = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CodeRuleID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Flen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gflen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarCodeQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BarcodePic = New System.Windows.Forms.PictureBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrpStyleSet.SuspendLayout()
        Me.GrpPrintSet.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DgPartSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.BarcodePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpStyleSet
        '
        Me.GrpStyleSet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpStyleSet.Controls.Add(Me.TxtCcMsg)
        Me.GrpStyleSet.Controls.Add(Me.LblMsg)
        Me.GrpStyleSet.Controls.Add(Me.LblMoidPrinted)
        Me.GrpStyleSet.Controls.Add(Me.Label6)
        Me.GrpStyleSet.Controls.Add(Me.LblDeptid)
        Me.GrpStyleSet.Controls.Add(Me.Label3)
        Me.GrpStyleSet.Controls.Add(Me.LblMoidNum)
        Me.GrpStyleSet.Controls.Add(Me.Label53)
        Me.GrpStyleSet.Controls.Add(Me.LblCusPart)
        Me.GrpStyleSet.Controls.Add(Me.LblAVCPart)
        Me.GrpStyleSet.Controls.Add(Me.CboMoid)
        Me.GrpStyleSet.Controls.Add(Me.LblPrintPaper)
        Me.GrpStyleSet.Controls.Add(Me.Label22)
        Me.GrpStyleSet.Controls.Add(Me.BnEdit)
        Me.GrpStyleSet.Controls.Add(Me.Label18)
        Me.GrpStyleSet.Controls.Add(Me.Label13)
        Me.GrpStyleSet.Controls.Add(Me.LblPrintDate)
        Me.GrpStyleSet.Controls.Add(Me.LblCusName)
        Me.GrpStyleSet.Controls.Add(Me.Label7)
        Me.GrpStyleSet.Controls.Add(Me.Label5)
        Me.GrpStyleSet.Controls.Add(Me.Label4)
        Me.GrpStyleSet.Controls.Add(Me.Label1)
        Me.GrpStyleSet.Location = New System.Drawing.Point(0, 28)
        Me.GrpStyleSet.Name = "GrpStyleSet"
        Me.GrpStyleSet.Size = New System.Drawing.Size(820, 87)
        Me.GrpStyleSet.TabIndex = 83
        Me.GrpStyleSet.TabStop = False
        Me.GrpStyleSet.Text = "样式设置"
        '
        'TxtCcMsg
        '
        Me.TxtCcMsg.ForeColor = System.Drawing.Color.Black
        Me.TxtCcMsg.Location = New System.Drawing.Point(688, 16)
        Me.TxtCcMsg.MaxLength = 10
        Me.TxtCcMsg.Name = "TxtCcMsg"
        Me.TxtCcMsg.Size = New System.Drawing.Size(100, 21)
        Me.TxtCcMsg.TabIndex = 79
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("微軟正黑體", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(627, 57)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(64, 18)
        Me.LblMsg.TabIndex = 77
        Me.LblMsg.Text = "提示信息"
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMoidPrinted
        '
        Me.LblMoidPrinted.AutoSize = True
        Me.LblMoidPrinted.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblMoidPrinted.Location = New System.Drawing.Point(102, 63)
        Me.LblMoidPrinted.Name = "LblMoidPrinted"
        Me.LblMoidPrinted.Size = New System.Drawing.Size(41, 12)
        Me.LblMoidPrinted.TabIndex = 71
        Me.LblMoidPrinted.Text = "######"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "已打印数量："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDeptid
        '
        Me.LblDeptid.AutoSize = True
        Me.LblDeptid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblDeptid.Location = New System.Drawing.Point(498, 20)
        Me.LblDeptid.Name = "LblDeptid"
        Me.LblDeptid.Size = New System.Drawing.Size(41, 12)
        Me.LblDeptid.TabIndex = 69
        Me.LblDeptid.Text = "######"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "工单批量："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMoidNum
        '
        Me.LblMoidNum.AutoSize = True
        Me.LblMoidNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblMoidNum.Location = New System.Drawing.Point(307, 20)
        Me.LblMoidNum.Name = "LblMoidNum"
        Me.LblMoidNum.Size = New System.Drawing.Size(41, 12)
        Me.LblMoidNum.TabIndex = 62
        Me.LblMoidNum.Text = "######"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(431, 20)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(65, 12)
        Me.Label53.TabIndex = 61
        Me.Label53.Text = "生产部门："
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblCusPart
        '
        Me.LblCusPart.AutoSize = True
        Me.LblCusPart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblCusPart.Location = New System.Drawing.Point(307, 41)
        Me.LblCusPart.Name = "LblCusPart"
        Me.LblCusPart.Size = New System.Drawing.Size(41, 12)
        Me.LblCusPart.TabIndex = 44
        Me.LblCusPart.Text = "######"
        '
        'LblAVCPart
        '
        Me.LblAVCPart.AutoSize = True
        Me.LblAVCPart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblAVCPart.Location = New System.Drawing.Point(102, 41)
        Me.LblAVCPart.Name = "LblAVCPart"
        Me.LblAVCPart.Size = New System.Drawing.Size(41, 12)
        Me.LblAVCPart.TabIndex = 43
        Me.LblAVCPart.Text = "######"
        '
        'CboMoid
        '
        Me.CboMoid.FormattingEnabled = True
        Me.CboMoid.Location = New System.Drawing.Point(102, 16)
        Me.CboMoid.Name = "CboMoid"
        Me.CboMoid.Size = New System.Drawing.Size(108, 20)
        Me.CboMoid.TabIndex = 1
        Me.CboMoid.Tag = "A"
        '
        'LblPrintPaper
        '
        Me.LblPrintPaper.AutoSize = True
        Me.LblPrintPaper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblPrintPaper.Location = New System.Drawing.Point(307, 63)
        Me.LblPrintPaper.Name = "LblPrintPaper"
        Me.LblPrintPaper.Size = New System.Drawing.Size(41, 12)
        Me.LblPrintPaper.TabIndex = 40
        Me.LblPrintPaper.Text = "######"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(241, 63)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 12)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "纸张大小："
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BnEdit
        '
        Me.BnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BnEdit.Image = CType(resources.GetObject("BnEdit.Image"), System.Drawing.Image)
        Me.BnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnEdit.Location = New System.Drawing.Point(570, 51)
        Me.BnEdit.Name = "BnEdit"
        Me.BnEdit.Size = New System.Drawing.Size(35, 27)
        Me.BnEdit.TabIndex = 35
        Me.BnEdit.Text = "..."
        Me.BnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BnEdit.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(35, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "工单编号："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(431, 63)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "打印日期："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblPrintDate
        '
        Me.LblPrintDate.AutoSize = True
        Me.LblPrintDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblPrintDate.Location = New System.Drawing.Point(498, 63)
        Me.LblPrintDate.Name = "LblPrintDate"
        Me.LblPrintDate.Size = New System.Drawing.Size(41, 12)
        Me.LblPrintDate.TabIndex = 17
        Me.LblPrintDate.Text = "######"
        '
        'LblCusName
        '
        Me.LblCusName.AutoSize = True
        Me.LblCusName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblCusName.Location = New System.Drawing.Point(498, 41)
        Me.LblCusName.Name = "LblCusName"
        Me.LblCusName.Size = New System.Drawing.Size(41, 12)
        Me.LblCusName.TabIndex = 14
        Me.LblCusName.Text = "######"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(431, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "客户名称："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(242, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "客戶  P/N："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "料件编号："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(621, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Config ID："
        '
        'GrpPrintSet
        '
        Me.GrpPrintSet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPrintSet.Controls.Add(Me.Label2)
        Me.GrpPrintSet.Controls.Add(Me.TxtPrintNum)
        Me.GrpPrintSet.Controls.Add(Me.LblYN)
        Me.GrpPrintSet.Location = New System.Drawing.Point(0, 400)
        Me.GrpPrintSet.Name = "GrpPrintSet"
        Me.GrpPrintSet.Size = New System.Drawing.Size(820, 55)
        Me.GrpPrintSet.TabIndex = 86
        Me.GrpPrintSet.TabStop = False
        Me.GrpPrintSet.Text = "打印设置"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "打印数量："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPrintNum
        '
        Me.TxtPrintNum.Location = New System.Drawing.Point(89, 24)
        Me.TxtPrintNum.MaxLength = 5
        Me.TxtPrintNum.Name = "TxtPrintNum"
        Me.TxtPrintNum.Size = New System.Drawing.Size(83, 21)
        Me.TxtPrintNum.TabIndex = 3
        '
        'LblYN
        '
        Me.LblYN.AutoSize = True
        Me.LblYN.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblYN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LblYN.Location = New System.Drawing.Point(181, 26)
        Me.LblYN.Name = "LblYN"
        Me.LblYN.Size = New System.Drawing.Size(76, 18)
        Me.LblYN.TabIndex = 7
        Me.LblYN.Text = "1000/1000"
        Me.LblYN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolTestPrint, Me.ToolBeginPrint, Me.ToolPrintLast, Me.ToolView, Me.ToolQuit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(820, 24)
        Me.ToolStrip1.TabIndex = 89
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolTestPrint
        '
        Me.ToolTestPrint.Image = CType(resources.GetObject("ToolTestPrint.Image"), System.Drawing.Image)
        Me.ToolTestPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolTestPrint.Name = "ToolTestPrint"
        Me.ToolTestPrint.Size = New System.Drawing.Size(91, 21)
        Me.ToolTestPrint.Text = "测试打印(&T)"
        '
        'ToolBeginPrint
        '
        Me.ToolBeginPrint.Image = CType(resources.GetObject("ToolBeginPrint.Image"), System.Drawing.Image)
        Me.ToolBeginPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBeginPrint.Name = "ToolBeginPrint"
        Me.ToolBeginPrint.Size = New System.Drawing.Size(91, 21)
        Me.ToolBeginPrint.Text = "正式打印(&P)"
        '
        'ToolPrintLast
        '
        Me.ToolPrintLast.Image = CType(resources.GetObject("ToolPrintLast.Image"), System.Drawing.Image)
        Me.ToolPrintLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrintLast.Name = "ToolPrintLast"
        Me.ToolPrintLast.Size = New System.Drawing.Size(90, 21)
        Me.ToolPrintLast.Text = "尾箱打印(&L)"
        '
        'ToolView
        '
        Me.ToolView.Image = CType(resources.GetObject("ToolView.Image"), System.Drawing.Image)
        Me.ToolView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolView.Name = "ToolView"
        Me.ToolView.Size = New System.Drawing.Size(92, 21)
        Me.ToolView.Text = "条码预览(&V)"
        '
        'ToolQuit
        '
        Me.ToolQuit.Image = CType(resources.GetObject("ToolQuit.Image"), System.Drawing.Image)
        Me.ToolQuit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuit.Name = "ToolQuit"
        Me.ToolQuit.Size = New System.Drawing.Size(68, 21)
        Me.ToolQuit.Text = "退出(&X)"
        '
        'DgPartSet
        '
        Me.DgPartSet.AllowUserToAddRows = False
        Me.DgPartSet.AllowUserToDeleteRows = False
        Me.DgPartSet.BackgroundColor = System.Drawing.Color.White
        Me.DgPartSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgPartSet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgPartSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgPartSet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeRuleID, Me.LabelType, Me.Flen, Me.Gflen, Me.BarCodeQty, Me.TextQty, Me.Userid, Me.Intime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgPartSet.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgPartSet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgPartSet.EnableHeadersVisualStyles = False
        Me.DgPartSet.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DgPartSet.Location = New System.Drawing.Point(0, 0)
        Me.DgPartSet.Name = "DgPartSet"
        Me.DgPartSet.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgPartSet.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgPartSet.RowHeadersWidth = 4
        Me.DgPartSet.RowTemplate.Height = 23
        Me.DgPartSet.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.DgPartSet.Size = New System.Drawing.Size(820, 273)
        Me.DgPartSet.TabIndex = 130
        '
        'CodeRuleID
        '
        Me.CodeRuleID.HeaderText = "编码原则"
        Me.CodeRuleID.Name = "CodeRuleID"
        Me.CodeRuleID.ReadOnly = True
        '
        'LabelType
        '
        Me.LabelType.HeaderText = "料件编号"
        Me.LabelType.Name = "LabelType"
        Me.LabelType.ReadOnly = True
        '
        'Flen
        '
        Me.Flen.HeaderText = "参数代码"
        Me.Flen.Name = "Flen"
        Me.Flen.ReadOnly = True
        Me.Flen.Width = 80
        '
        'Gflen
        '
        Me.Gflen.HeaderText = "参数名称"
        Me.Gflen.Name = "Gflen"
        Me.Gflen.ReadOnly = True
        Me.Gflen.Width = 90
        '
        'BarCodeQty
        '
        Me.BarCodeQty.HeaderText = "参数值"
        Me.BarCodeQty.Name = "BarCodeQty"
        Me.BarCodeQty.ReadOnly = True
        Me.BarCodeQty.Width = 80
        '
        'TextQty
        '
        Me.TextQty.HeaderText = "有效否"
        Me.TextQty.Name = "TextQty"
        Me.TextQty.ReadOnly = True
        Me.TextQty.Width = 80
        '
        'Userid
        '
        Me.Userid.HeaderText = "设置人员"
        Me.Userid.Name = "Userid"
        Me.Userid.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.HeaderText = "设置时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolUser})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 458)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(820, 22)
        Me.StatusStrip1.TabIndex = 131
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolUser
        '
        Me.ToolUser.Name = "ToolUser"
        Me.ToolUser.Size = New System.Drawing.Size(68, 17)
        Me.ToolUser.Text = "打印人员："
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 121)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgPartSet)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.BarcodePic)
        Me.SplitContainer1.Panel2Collapsed = True
        Me.SplitContainer1.Size = New System.Drawing.Size(820, 273)
        Me.SplitContainer1.SplitterDistance = 586
        Me.SplitContainer1.TabIndex = 132
        '
        'BarcodePic
        '
        Me.BarcodePic.BackColor = System.Drawing.Color.GhostWhite
        Me.BarcodePic.BackgroundImage = CType(resources.GetObject("BarcodePic.BackgroundImage"), System.Drawing.Image)
        Me.BarcodePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BarcodePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BarcodePic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BarcodePic.Location = New System.Drawing.Point(0, 0)
        Me.BarcodePic.Name = "BarcodePic"
        Me.BarcodePic.Size = New System.Drawing.Size(96, 100)
        Me.BarcodePic.TabIndex = 132
        Me.BarcodePic.TabStop = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "編碼原則"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "料件編號"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "參數代碼"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "參數名稱"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 90
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "參數值"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "是否有效"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "設置人員"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "設置時間"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 110
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "確認人員"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "確認時間"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 110
        '
        'FrmCheckDigitPrt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 480)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GrpPrintSet)
        Me.Controls.Add(Me.GrpStyleSet)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmCheckDigitPrt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "校验码条码打印作业"
        Me.GrpStyleSet.ResumeLayout(False)
        Me.GrpStyleSet.PerformLayout()
        Me.GrpPrintSet.ResumeLayout(False)
        Me.GrpPrintSet.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DgPartSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.BarcodePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpStyleSet As System.Windows.Forms.GroupBox
    Friend WithEvents LblDeptid As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblMoidNum As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents LblCusPart As System.Windows.Forms.Label
    Friend WithEvents LblAVCPart As System.Windows.Forms.Label
    Friend WithEvents CboMoid As System.Windows.Forms.ComboBox
    Friend WithEvents LblPrintPaper As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BnEdit As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblPrintDate As System.Windows.Forms.Label
    Friend WithEvents LblCusName As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblMoidPrinted As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GrpPrintSet As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPrintNum As System.Windows.Forms.TextBox
    Friend WithEvents LblYN As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolTestPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBeginPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPrintLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolQuit As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DgPartSet As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents CodeRuleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Flen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gflen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BarCodeQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents BarcodePic As System.Windows.Forms.PictureBox
    Friend WithEvents ToolView As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtCcMsg As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
