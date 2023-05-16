<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCartonV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCartonV2))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GrpStyleSet = New System.Windows.Forms.GroupBox()
        Me.txtContainerNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CobShift = New System.Windows.Forms.ComboBox()
        Me.CboCartonQty = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CboLineid = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LblCartonPrintNum = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblMoidLastNum = New System.Windows.Forms.Label()
        Me.LblMoidOkNum = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblDeptid = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblMoidNum = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.LblAVCPart = New System.Windows.Forms.Label()
        Me.CboMoid = New System.Windows.Forms.ComboBox()
        Me.LblPrintPaper = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BnEdit = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblCartonDate = New System.Windows.Forms.Label()
        Me.LblCusName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GrpPrintSet = New System.Windows.Forms.GroupBox()
        Me.LblEndSn = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblStartSn = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPrintNum = New System.Windows.Forms.TextBox()
        Me.LblYN = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolTestPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolBeginPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolPrintLast = New System.Windows.Forms.ToolStripButton()
        Me.ToolView = New System.Windows.Forms.ToolStripButton()
        Me.ToolQuit = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DgPartSet = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CodeRuleID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Flen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gflen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarCodeQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarcodePic = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSameNum = New System.Windows.Forms.TextBox()
        Me.GrpStyleSet.SuspendLayout()
        Me.GrpPrintSet.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DgPartSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarcodePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpStyleSet
        '
        Me.GrpStyleSet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpStyleSet.Controls.Add(Me.txtContainerNo)
        Me.GrpStyleSet.Controls.Add(Me.Label9)
        Me.GrpStyleSet.Controls.Add(Me.LblMsg)
        Me.GrpStyleSet.Controls.Add(Me.Label8)
        Me.GrpStyleSet.Controls.Add(Me.CobShift)
        Me.GrpStyleSet.Controls.Add(Me.CboCartonQty)
        Me.GrpStyleSet.Controls.Add(Me.Label16)
        Me.GrpStyleSet.Controls.Add(Me.CboLineid)
        Me.GrpStyleSet.Controls.Add(Me.Label15)
        Me.GrpStyleSet.Controls.Add(Me.LblCartonPrintNum)
        Me.GrpStyleSet.Controls.Add(Me.Label14)
        Me.GrpStyleSet.Controls.Add(Me.Label5)
        Me.GrpStyleSet.Controls.Add(Me.LblMoidLastNum)
        Me.GrpStyleSet.Controls.Add(Me.LblMoidOkNum)
        Me.GrpStyleSet.Controls.Add(Me.Label6)
        Me.GrpStyleSet.Controls.Add(Me.LblDeptid)
        Me.GrpStyleSet.Controls.Add(Me.Label3)
        Me.GrpStyleSet.Controls.Add(Me.LblMoidNum)
        Me.GrpStyleSet.Controls.Add(Me.Label53)
        Me.GrpStyleSet.Controls.Add(Me.LblAVCPart)
        Me.GrpStyleSet.Controls.Add(Me.CboMoid)
        Me.GrpStyleSet.Controls.Add(Me.LblPrintPaper)
        Me.GrpStyleSet.Controls.Add(Me.Label22)
        Me.GrpStyleSet.Controls.Add(Me.BnEdit)
        Me.GrpStyleSet.Controls.Add(Me.Label18)
        Me.GrpStyleSet.Controls.Add(Me.Label13)
        Me.GrpStyleSet.Controls.Add(Me.LblCartonDate)
        Me.GrpStyleSet.Controls.Add(Me.LblCusName)
        Me.GrpStyleSet.Controls.Add(Me.Label7)
        Me.GrpStyleSet.Controls.Add(Me.Label4)
        Me.GrpStyleSet.Location = New System.Drawing.Point(1, 29)
        Me.GrpStyleSet.Name = "GrpStyleSet"
        Me.GrpStyleSet.Size = New System.Drawing.Size(849, 118)
        Me.GrpStyleSet.TabIndex = 83
        Me.GrpStyleSet.TabStop = False
        Me.GrpStyleSet.Text = "样式设置"
        '
        'txtContainerNo
        '
        Me.txtContainerNo.BackColor = System.Drawing.Color.White
        Me.txtContainerNo.Location = New System.Drawing.Point(713, 69)
        Me.txtContainerNo.MaxLength = 4
        Me.txtContainerNo.Name = "txtContainerNo"
        Me.txtContainerNo.Size = New System.Drawing.Size(78, 21)
        Me.txtContainerNo.TabIndex = 85
        Me.txtContainerNo.Text = "1/1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(629, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 12)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "箱数/总箱数："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Font = New System.Drawing.Font("微軟正黑體", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(664, 48)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(64, 18)
        Me.LblMsg.TabIndex = 82
        Me.LblMsg.Text = "提示信息"
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(671, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 12)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "班別："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CobShift
        '
        Me.CobShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CobShift.FormattingEnabled = True
        Me.CobShift.Items.AddRange(New Object() {"白班", "夜班"})
        Me.CobShift.Location = New System.Drawing.Point(713, 20)
        Me.CobShift.Name = "CobShift"
        Me.CobShift.Size = New System.Drawing.Size(78, 20)
        Me.CobShift.TabIndex = 80
        '
        'CboCartonQty
        '
        Me.CboCartonQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCartonQty.FormattingEnabled = True
        Me.CboCartonQty.Location = New System.Drawing.Point(551, 20)
        Me.CboCartonQty.Name = "CboCartonQty"
        Me.CboCartonQty.Size = New System.Drawing.Size(78, 20)
        Me.CboCartonQty.TabIndex = 78
        Me.CboCartonQty.Tag = "A"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(483, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 12)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "箱装数量："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CboLineid
        '
        Me.CboLineid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLineid.FormattingEnabled = True
        Me.CboLineid.Location = New System.Drawing.Point(375, 20)
        Me.CboLineid.Name = "CboLineid"
        Me.CboLineid.Size = New System.Drawing.Size(78, 20)
        Me.CboLineid.TabIndex = 76
        Me.CboLineid.Tag = "A"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(328, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 12)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "线别："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblCartonPrintNum
        '
        Me.LblCartonPrintNum.AutoSize = True
        Me.LblCartonPrintNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblCartonPrintNum.Location = New System.Drawing.Point(551, 72)
        Me.LblCartonPrintNum.Name = "LblCartonPrintNum"
        Me.LblCartonPrintNum.Size = New System.Drawing.Size(41, 12)
        Me.LblCartonPrintNum.TabIndex = 75
        Me.LblCartonPrintNum.Text = "######"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(470, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 12)
        Me.Label14.TabIndex = 74
        Me.Label14.Text = "可打印箱数："
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "工单尾数："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMoidLastNum
        '
        Me.LblMoidLastNum.AutoSize = True
        Me.LblMoidLastNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblMoidLastNum.Location = New System.Drawing.Point(77, 96)
        Me.LblMoidLastNum.Name = "LblMoidLastNum"
        Me.LblMoidLastNum.Size = New System.Drawing.Size(41, 12)
        Me.LblMoidLastNum.TabIndex = 72
        Me.LblMoidLastNum.Text = "######"
        '
        'LblMoidOkNum
        '
        Me.LblMoidOkNum.AutoSize = True
        Me.LblMoidOkNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblMoidOkNum.Location = New System.Drawing.Point(375, 72)
        Me.LblMoidOkNum.Name = "LblMoidOkNum"
        Me.LblMoidOkNum.Size = New System.Drawing.Size(41, 12)
        Me.LblMoidOkNum.TabIndex = 71
        Me.LblMoidOkNum.Text = "######"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(292, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "已打印箱数："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblDeptid
        '
        Me.LblDeptid.AutoSize = True
        Me.LblDeptid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblDeptid.Location = New System.Drawing.Point(551, 48)
        Me.LblDeptid.Name = "LblDeptid"
        Me.LblDeptid.Size = New System.Drawing.Size(41, 12)
        Me.LblDeptid.TabIndex = 69
        Me.LblDeptid.Text = "######"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 72)
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
        Me.LblMoidNum.Location = New System.Drawing.Point(77, 72)
        Me.LblMoidNum.Name = "LblMoidNum"
        Me.LblMoidNum.Size = New System.Drawing.Size(41, 12)
        Me.LblMoidNum.TabIndex = 62
        Me.LblMoidNum.Text = "######"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(482, 48)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(65, 12)
        Me.Label53.TabIndex = 61
        Me.Label53.Text = "生产部门："
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAVCPart
        '
        Me.LblAVCPart.AutoSize = True
        Me.LblAVCPart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblAVCPart.Location = New System.Drawing.Point(77, 48)
        Me.LblAVCPart.Name = "LblAVCPart"
        Me.LblAVCPart.Size = New System.Drawing.Size(41, 12)
        Me.LblAVCPart.TabIndex = 43
        Me.LblAVCPart.Text = "######"
        '
        'CboMoid
        '
        Me.CboMoid.ForeColor = System.Drawing.Color.Black
        Me.CboMoid.FormattingEnabled = True
        Me.CboMoid.Location = New System.Drawing.Point(77, 20)
        Me.CboMoid.Name = "CboMoid"
        Me.CboMoid.Size = New System.Drawing.Size(245, 20)
        Me.CboMoid.TabIndex = 1
        Me.CboMoid.Tag = "A"
        '
        'LblPrintPaper
        '
        Me.LblPrintPaper.AutoSize = True
        Me.LblPrintPaper.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblPrintPaper.Location = New System.Drawing.Point(375, 96)
        Me.LblPrintPaper.Name = "LblPrintPaper"
        Me.LblPrintPaper.Size = New System.Drawing.Size(41, 12)
        Me.LblPrintPaper.TabIndex = 40
        Me.LblPrintPaper.Text = "######"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(304, 96)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 12)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "纸张大小："
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BnEdit
        '
        Me.BnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnEdit.Image = CType(resources.GetObject("BnEdit.Image"), System.Drawing.Image)
        Me.BnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnEdit.Location = New System.Drawing.Point(634, 90)
        Me.BnEdit.Name = "BnEdit"
        Me.BnEdit.Size = New System.Drawing.Size(35, 25)
        Me.BnEdit.TabIndex = 35
        Me.BnEdit.Text = "..."
        Me.BnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BnEdit.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 12)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "工单编号："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(482, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "裝箱日期："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblCartonDate
        '
        Me.LblCartonDate.AutoSize = True
        Me.LblCartonDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblCartonDate.Location = New System.Drawing.Point(551, 96)
        Me.LblCartonDate.Name = "LblCartonDate"
        Me.LblCartonDate.Size = New System.Drawing.Size(41, 12)
        Me.LblCartonDate.TabIndex = 17
        Me.LblCartonDate.Text = "######"
        '
        'LblCusName
        '
        Me.LblCusName.AutoSize = True
        Me.LblCusName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblCusName.Location = New System.Drawing.Point(375, 48)
        Me.LblCusName.Name = "LblCusName"
        Me.LblCusName.Size = New System.Drawing.Size(41, 12)
        Me.LblCusName.TabIndex = 14
        Me.LblCusName.Text = "######"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(304, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 12)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "客户名称："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "料件编号："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GrpPrintSet
        '
        Me.GrpPrintSet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPrintSet.Controls.Add(Me.Label11)
        Me.GrpPrintSet.Controls.Add(Me.txtSameNum)
        Me.GrpPrintSet.Controls.Add(Me.LblEndSn)
        Me.GrpPrintSet.Controls.Add(Me.Label10)
        Me.GrpPrintSet.Controls.Add(Me.LblStartSn)
        Me.GrpPrintSet.Controls.Add(Me.Label1)
        Me.GrpPrintSet.Controls.Add(Me.Label2)
        Me.GrpPrintSet.Controls.Add(Me.TxtPrintNum)
        Me.GrpPrintSet.Controls.Add(Me.LblYN)
        Me.GrpPrintSet.Location = New System.Drawing.Point(1, 414)
        Me.GrpPrintSet.Name = "GrpPrintSet"
        Me.GrpPrintSet.Size = New System.Drawing.Size(849, 50)
        Me.GrpPrintSet.TabIndex = 86
        Me.GrpPrintSet.TabStop = False
        Me.GrpPrintSet.Text = "打印设置"
        '
        'LblEndSn
        '
        Me.LblEndSn.AutoSize = True
        Me.LblEndSn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblEndSn.Location = New System.Drawing.Point(739, 24)
        Me.LblEndSn.Name = "LblEndSn"
        Me.LblEndSn.Size = New System.Drawing.Size(41, 12)
        Me.LblEndSn.TabIndex = 74
        Me.LblEndSn.Text = "######"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(658, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 12)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "终止流水码："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblStartSn
        '
        Me.LblStartSn.AutoSize = True
        Me.LblStartSn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.LblStartSn.Location = New System.Drawing.Point(536, 24)
        Me.LblStartSn.Name = "LblStartSn"
        Me.LblStartSn.Size = New System.Drawing.Size(41, 12)
        Me.LblStartSn.TabIndex = 72
        Me.LblStartSn.Text = "######"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(455, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "起始流水码："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "打印数量："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPrintNum
        '
        Me.TxtPrintNum.Location = New System.Drawing.Point(89, 16)
        Me.TxtPrintNum.MaxLength = 4
        Me.TxtPrintNum.Name = "TxtPrintNum"
        Me.TxtPrintNum.Size = New System.Drawing.Size(83, 21)
        Me.TxtPrintNum.TabIndex = 3
        '
        'LblYN
        '
        Me.LblYN.AutoSize = True
        Me.LblYN.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblYN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LblYN.Location = New System.Drawing.Point(181, 20)
        Me.LblYN.Name = "LblYN"
        Me.LblYN.Size = New System.Drawing.Size(76, 18)
        Me.LblYN.TabIndex = 7
        Me.LblYN.Text = "1000/1000"
        Me.LblYN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolTestPrint, Me.ToolBeginPrint, Me.ToolPrintLast, Me.ToolView, Me.ToolQuit})
        Me.ToolStrip1.Location = New System.Drawing.Point(4, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(848, 25)
        Me.ToolStrip1.TabIndex = 89
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolTestPrint
        '
        Me.ToolTestPrint.Image = CType(resources.GetObject("ToolTestPrint.Image"), System.Drawing.Image)
        Me.ToolTestPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolTestPrint.Name = "ToolTestPrint"
        Me.ToolTestPrint.Size = New System.Drawing.Size(91, 22)
        Me.ToolTestPrint.Text = "测试打印(&T)"
        '
        'ToolBeginPrint
        '
        Me.ToolBeginPrint.Image = CType(resources.GetObject("ToolBeginPrint.Image"), System.Drawing.Image)
        Me.ToolBeginPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBeginPrint.Name = "ToolBeginPrint"
        Me.ToolBeginPrint.Size = New System.Drawing.Size(91, 22)
        Me.ToolBeginPrint.Text = "正式打印(&P)"
        '
        'ToolPrintLast
        '
        Me.ToolPrintLast.Image = CType(resources.GetObject("ToolPrintLast.Image"), System.Drawing.Image)
        Me.ToolPrintLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPrintLast.Name = "ToolPrintLast"
        Me.ToolPrintLast.Size = New System.Drawing.Size(90, 22)
        Me.ToolPrintLast.Text = "尾箱打印(&L)"
        '
        'ToolView
        '
        Me.ToolView.Image = CType(resources.GetObject("ToolView.Image"), System.Drawing.Image)
        Me.ToolView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolView.Name = "ToolView"
        Me.ToolView.Size = New System.Drawing.Size(92, 22)
        Me.ToolView.Text = "条码预览(&V)"
        '
        'ToolQuit
        '
        Me.ToolQuit.Image = CType(resources.GetObject("ToolQuit.Image"), System.Drawing.Image)
        Me.ToolQuit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuit.Name = "ToolQuit"
        Me.ToolQuit.Size = New System.Drawing.Size(68, 22)
        Me.ToolQuit.Text = "退出(&X)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolUser})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 467)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(852, 22)
        Me.StatusStrip1.TabIndex = 90
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolUser
        '
        Me.ToolUser.Name = "ToolUser"
        Me.ToolUser.Size = New System.Drawing.Size(68, 17)
        Me.ToolUser.Text = "打印人員："
        '
        'DgPartSet
        '
        Me.DgPartSet.AllowUserToAddRows = False
        Me.DgPartSet.AllowUserToDeleteRows = False
        Me.DgPartSet.BackgroundColor = System.Drawing.Color.White
        Me.DgPartSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgPartSet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgPartSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgPartSet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeRuleID, Me.LabelType, Me.Flen, Me.Gflen, Me.BarCodeQty, Me.TextQty, Me.Userid, Me.Intime})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgPartSet.DefaultCellStyle = DataGridViewCellStyle5
        Me.DgPartSet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgPartSet.EnableHeadersVisualStyles = False
        Me.DgPartSet.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.DgPartSet.Location = New System.Drawing.Point(0, 0)
        Me.DgPartSet.Name = "DgPartSet"
        Me.DgPartSet.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgPartSet.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DgPartSet.RowHeadersWidth = 4
        Me.DgPartSet.RowTemplate.Height = 23
        Me.DgPartSet.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.DgPartSet.Size = New System.Drawing.Size(848, 255)
        Me.DgPartSet.TabIndex = 129
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
        Me.BarcodePic.TabIndex = 130
        Me.BarcodePic.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 153)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(848, 255)
        Me.SplitContainer1.SplitterDistance = 572
        Me.SplitContainer1.TabIndex = 75
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "編碼原則"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 40
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
        Me.DataGridViewTextBoxColumn3.Width = 40
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
        Me.DataGridViewTextBoxColumn6.Width = 50
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "設置人員"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 50
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
        Me.DataGridViewTextBoxColumn9.Width = 50
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "確認時間"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 110
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(274, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 76
        Me.Label11.Text = "相同份数："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSameNum
        '
        Me.txtSameNum.Location = New System.Drawing.Point(345, 18)
        Me.txtSameNum.MaxLength = 4
        Me.txtSameNum.Name = "txtSameNum"
        Me.txtSameNum.Size = New System.Drawing.Size(61, 21)
        Me.txtSameNum.TabIndex = 75
        Me.txtSameNum.Text = "1"
        '
        'FrmCartonV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 489)
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
        Me.Name = "FrmCartonV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "外箱条码打印作业"
        Me.GrpStyleSet.ResumeLayout(False)
        Me.GrpStyleSet.PerformLayout()
        Me.GrpPrintSet.ResumeLayout(False)
        Me.GrpPrintSet.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DgPartSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarcodePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpStyleSet As System.Windows.Forms.GroupBox
    Friend WithEvents LblDeptid As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblMoidNum As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents LblAVCPart As System.Windows.Forms.Label
    Friend WithEvents CboMoid As System.Windows.Forms.ComboBox
    Friend WithEvents LblPrintPaper As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BnEdit As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblCartonDate As System.Windows.Forms.Label
    Friend WithEvents LblCusName As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblMoidOkNum As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GrpPrintSet As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPrintNum As System.Windows.Forms.TextBox
    Friend WithEvents LblYN As System.Windows.Forms.Label
    Friend WithEvents LblEndSn As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblStartSn As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboCartonQty As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CboLineid As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LblCartonPrintNum As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblMoidLastNum As System.Windows.Forms.Label
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
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CobShift As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolTestPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBeginPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolPrintLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolQuit As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DgPartSet As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents CodeRuleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Flen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gflen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BarCodeQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents BarcodePic As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolView As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtContainerNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSameNum As System.Windows.Forms.TextBox
End Class
