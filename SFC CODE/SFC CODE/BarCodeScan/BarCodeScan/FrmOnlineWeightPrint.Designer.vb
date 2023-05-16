<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOnlineWeightPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOnlineWeightPrint))
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TxtCotainerNo = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtWeight2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPassWord = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.txtWeight3 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOldBarCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNewBarCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPassword2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BnCancel = New System.Windows.Forms.Button()
        Me.BnOpenlock = New System.Windows.Forms.Button()
        Me.RadIsLinePrintFullCode = New System.Windows.Forms.RadioButton()
        Me.RadIsLineNOPrintFullCode = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbComDes = New System.Windows.Forms.Label()
        Me.btnSetCOM = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtUpLimit = New System.Windows.Forms.TextBox()
        Me.txtLowlimit = New System.Windows.Forms.TextBox()
        Me.lbComlb = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtComInfo = New System.Windows.Forms.TextBox()
        Me.RbManual = New System.Windows.Forms.RadioButton()
        Me.RbAuto = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtWeight
        '
        Me.txtWeight.Location = New System.Drawing.Point(99, 31)
        Me.txtWeight.MaxLength = 10
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(149, 21)
        Me.txtWeight.TabIndex = 0
        Me.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "整箱重量:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 12)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "称重箱号:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(254, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 12)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "KG"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(565, 157)
        Me.TabControl1.TabIndex = 78
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TxtCotainerNo)
        Me.TabPage1.Controls.Add(Me.txtWeight)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage1.Size = New System.Drawing.Size(557, 131)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "在线称重打印"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TxtCotainerNo
        '
        Me.TxtCotainerNo.Enabled = False
        Me.TxtCotainerNo.Location = New System.Drawing.Point(99, 69)
        Me.TxtCotainerNo.MaxLength = 100
        Me.TxtCotainerNo.Name = "TxtCotainerNo"
        Me.TxtCotainerNo.Size = New System.Drawing.Size(203, 21)
        Me.TxtCotainerNo.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtWeight2)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtBarcode)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.TxtPassWord)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage2.Size = New System.Drawing.Size(557, 131)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "重新称重打印"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtWeight2
        '
        Me.txtWeight2.Location = New System.Drawing.Point(105, 16)
        Me.txtWeight2.MaxLength = 10
        Me.txtWeight2.Name = "txtWeight2"
        Me.txtWeight2.Size = New System.Drawing.Size(149, 21)
        Me.txtWeight2.TabIndex = 0
        Me.txtWeight2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 12)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "整箱重量:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(260, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 12)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "KG"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(105, 50)
        Me.txtBarcode.MaxLength = 100
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(191, 21)
        Me.txtBarcode.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "箱号或条码:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtPassWord
        '
        Me.TxtPassWord.Location = New System.Drawing.Point(105, 88)
        Me.TxtPassWord.MaxLength = 30
        Me.TxtPassWord.Name = "TxtPassWord"
        Me.TxtPassWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassWord.Size = New System.Drawing.Size(191, 21)
        Me.TxtPassWord.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "解鎖密碼:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.txtWeight3)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.txtOldBarCode)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.txtNewBarCode)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.txtPassword2)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage3.Size = New System.Drawing.Size(557, 131)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "称重条码替换打印"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'txtWeight3
        '
        Me.txtWeight3.Location = New System.Drawing.Point(102, 15)
        Me.txtWeight3.MaxLength = 10
        Me.txtWeight3.Name = "txtWeight3"
        Me.txtWeight3.Size = New System.Drawing.Size(149, 21)
        Me.txtWeight3.TabIndex = 0
        Me.txtWeight3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(37, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 12)
        Me.Label11.TabIndex = 82
        Me.Label11.Text = "整箱重量:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(257, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 12)
        Me.Label12.TabIndex = 83
        Me.Label12.Text = "KG"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOldBarCode
        '
        Me.txtOldBarCode.AcceptsReturn = True
        Me.txtOldBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOldBarCode.Location = New System.Drawing.Point(102, 41)
        Me.txtOldBarCode.MaxLength = 40
        Me.txtOldBarCode.Name = "txtOldBarCode"
        Me.txtOldBarCode.Size = New System.Drawing.Size(209, 21)
        Me.txtOldBarCode.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 12)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "原产品条码:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNewBarCode
        '
        Me.txtNewBarCode.AcceptsReturn = True
        Me.txtNewBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewBarCode.Location = New System.Drawing.Point(102, 68)
        Me.txtNewBarCode.MaxLength = 1000
        Me.txtNewBarCode.Name = "txtNewBarCode"
        Me.txtNewBarCode.Size = New System.Drawing.Size(209, 21)
        Me.txtNewBarCode.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 12)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "新产品条码:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPassword2
        '
        Me.txtPassword2.Location = New System.Drawing.Point(102, 95)
        Me.txtPassword2.Name = "txtPassword2"
        Me.txtPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword2.Size = New System.Drawing.Size(209, 21)
        Me.txtPassword2.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(37, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "解锁密码:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BnCancel
        '
        Me.BnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnCancel.Image = CType(resources.GetObject("BnCancel.Image"), System.Drawing.Image)
        Me.BnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnCancel.Location = New System.Drawing.Point(309, 331)
        Me.BnCancel.Name = "BnCancel"
        Me.BnCancel.Size = New System.Drawing.Size(66, 23)
        Me.BnCancel.TabIndex = 1
        Me.BnCancel.Text = "取 消"
        Me.BnCancel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnCancel.UseVisualStyleBackColor = True
        '
        'BnOpenlock
        '
        Me.BnOpenlock.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BnOpenlock.Image = CType(resources.GetObject("BnOpenlock.Image"), System.Drawing.Image)
        Me.BnOpenlock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BnOpenlock.Location = New System.Drawing.Point(203, 331)
        Me.BnOpenlock.Name = "BnOpenlock"
        Me.BnOpenlock.Size = New System.Drawing.Size(66, 23)
        Me.BnOpenlock.TabIndex = 0
        Me.BnOpenlock.Text = "确 定"
        Me.BnOpenlock.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.BnOpenlock.UseVisualStyleBackColor = True
        '
        'RadIsLinePrintFullCode
        '
        Me.RadIsLinePrintFullCode.AutoSize = True
        Me.RadIsLinePrintFullCode.Checked = True
        Me.RadIsLinePrintFullCode.Location = New System.Drawing.Point(102, 18)
        Me.RadIsLinePrintFullCode.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RadIsLinePrintFullCode.Name = "RadIsLinePrintFullCode"
        Me.RadIsLinePrintFullCode.Size = New System.Drawing.Size(83, 16)
        Me.RadIsLinePrintFullCode.TabIndex = 79
        Me.RadIsLinePrintFullCode.TabStop = True
        Me.RadIsLinePrintFullCode.Text = "称重并打印"
        Me.RadIsLinePrintFullCode.UseVisualStyleBackColor = True
        '
        'RadIsLineNOPrintFullCode
        '
        Me.RadIsLineNOPrintFullCode.AutoSize = True
        Me.RadIsLineNOPrintFullCode.Location = New System.Drawing.Point(218, 18)
        Me.RadIsLineNOPrintFullCode.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RadIsLineNOPrintFullCode.Name = "RadIsLineNOPrintFullCode"
        Me.RadIsLineNOPrintFullCode.Size = New System.Drawing.Size(83, 16)
        Me.RadIsLineNOPrintFullCode.TabIndex = 80
        Me.RadIsLineNOPrintFullCode.Text = "称重不打印"
        Me.RadIsLineNOPrintFullCode.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.RadIsLinePrintFullCode)
        Me.GroupBox1.Controls.Add(Me.RadIsLineNOPrintFullCode)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(3, 161)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(559, 46)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "是否打印"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(410, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(143, 12)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "---工艺流程设置是否打印"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbComDes)
        Me.GroupBox2.Controls.Add(Me.btnSetCOM)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtUpLimit)
        Me.GroupBox2.Controls.Add(Me.txtLowlimit)
        Me.GroupBox2.Controls.Add(Me.lbComlb)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtComInfo)
        Me.GroupBox2.Controls.Add(Me.RbManual)
        Me.GroupBox2.Controls.Add(Me.RbAuto)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 211)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(559, 102)
        Me.GroupBox2.TabIndex = 82
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "称重设置"
        '
        'lbComDes
        '
        Me.lbComDes.AutoSize = True
        Me.lbComDes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbComDes.Location = New System.Drawing.Point(305, 77)
        Me.lbComDes.Name = "lbComDes"
        Me.lbComDes.Size = New System.Drawing.Size(131, 12)
        Me.lbComDes.TabIndex = 93
        Me.lbComDes.Text = "已开启-通讯端口已打开"
        Me.lbComDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSetCOM
        '
        Me.btnSetCOM.Location = New System.Drawing.Point(471, 70)
        Me.btnSetCOM.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnSetCOM.Name = "btnSetCOM"
        Me.btnSetCOM.Size = New System.Drawing.Size(83, 23)
        Me.btnSetCOM.TabIndex = 92
        Me.btnSetCOM.Text = "设置COM参数"
        Me.btnSetCOM.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(305, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(197, 12)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "工艺流程设置重量上下限后自动校验"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(195, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 12)
        Me.Label16.TabIndex = 89
        Me.Label16.Text = "~"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUpLimit
        '
        Me.txtUpLimit.Enabled = False
        Me.txtUpLimit.Location = New System.Drawing.Point(213, 49)
        Me.txtUpLimit.MaxLength = 100
        Me.txtUpLimit.Name = "txtUpLimit"
        Me.txtUpLimit.ReadOnly = True
        Me.txtUpLimit.Size = New System.Drawing.Size(88, 21)
        Me.txtUpLimit.TabIndex = 88
        '
        'txtLowlimit
        '
        Me.txtLowlimit.Enabled = False
        Me.txtLowlimit.Location = New System.Drawing.Point(101, 49)
        Me.txtLowlimit.MaxLength = 100
        Me.txtLowlimit.Name = "txtLowlimit"
        Me.txtLowlimit.ReadOnly = True
        Me.txtLowlimit.Size = New System.Drawing.Size(88, 21)
        Me.txtLowlimit.TabIndex = 87
        '
        'lbComlb
        '
        Me.lbComlb.AutoSize = True
        Me.lbComlb.Location = New System.Drawing.Point(37, 75)
        Me.lbComlb.Name = "lbComlb"
        Me.lbComlb.Size = New System.Drawing.Size(59, 12)
        Me.lbComlb.TabIndex = 86
        Me.lbComlb.Text = "端口设置:"
        Me.lbComlb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(37, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 12)
        Me.Label14.TabIndex = 85
        Me.Label14.Text = "称重范围:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(61, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 12)
        Me.Label13.TabIndex = 84
        Me.Label13.Text = "模式:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtComInfo
        '
        Me.txtComInfo.Enabled = False
        Me.txtComInfo.Location = New System.Drawing.Point(101, 73)
        Me.txtComInfo.MaxLength = 100
        Me.txtComInfo.Name = "txtComInfo"
        Me.txtComInfo.ReadOnly = True
        Me.txtComInfo.Size = New System.Drawing.Size(200, 21)
        Me.txtComInfo.TabIndex = 83
        '
        'RbManual
        '
        Me.RbManual.AutoSize = True
        Me.RbManual.Checked = True
        Me.RbManual.Location = New System.Drawing.Point(101, 22)
        Me.RbManual.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RbManual.Name = "RbManual"
        Me.RbManual.Size = New System.Drawing.Size(71, 16)
        Me.RbManual.TabIndex = 81
        Me.RbManual.TabStop = True
        Me.RbManual.Text = "手动称重"
        Me.RbManual.UseVisualStyleBackColor = True
        '
        'RbAuto
        '
        Me.RbAuto.AutoSize = True
        Me.RbAuto.Location = New System.Drawing.Point(218, 22)
        Me.RbAuto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RbAuto.Name = "RbAuto"
        Me.RbAuto.Size = New System.Drawing.Size(107, 16)
        Me.RbAuto.TabIndex = 82
        Me.RbAuto.Text = "电子秤自动称重"
        Me.RbAuto.UseVisualStyleBackColor = True
        '
        'FrmOnlineWeightPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(565, 372)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BnCancel)
        Me.Controls.Add(Me.BnOpenlock)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOnlineWeightPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "称重绑定-校验-打印"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtOldBarCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNewBarCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPassword2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BnCancel As System.Windows.Forms.Button
    Friend WithEvents BnOpenlock As System.Windows.Forms.Button
    Friend WithEvents txtWeight2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWeight3 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCotainerNo As System.Windows.Forms.TextBox
    Friend WithEvents RadIsLinePrintFullCode As System.Windows.Forms.RadioButton
    Friend WithEvents RadIsLineNOPrintFullCode As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtComInfo As System.Windows.Forms.TextBox
    Friend WithEvents RbManual As System.Windows.Forms.RadioButton
    Friend WithEvents RbAuto As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtUpLimit As System.Windows.Forms.TextBox
    Friend WithEvents txtLowlimit As System.Windows.Forms.TextBox
    Friend WithEvents lbComlb As System.Windows.Forms.Label
    Friend WithEvents btnSetCOM As System.Windows.Forms.Button
    Friend WithEvents lbComDes As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
