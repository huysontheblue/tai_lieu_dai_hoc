<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWorkStantScan_L01
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWorkStantScan_L01))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtOnLineWeight = New ULControls.textBoxUL()
        Me.lbOnLineWeight = New System.Windows.Forms.Label()
        Me.chbMessage = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_tmpbarcode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblRcode = New System.Windows.Forms.Label()
        Me.LblMoqty = New System.Windows.Forms.Label()
        Me.TxtRcode = New ULControls.textBoxUL()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LabCartonQty = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblCheckTime = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.LabResult = New System.Windows.Forms.Label()
        Me.TxtSnStyle1 = New ULControls.textBoxUL()
        Me.TxtSnStyle2 = New ULControls.textBoxUL()
        Me.TxtCartonNo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtBarCode = New ULControls.textBoxUL()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblBarName = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboPrinterList = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.lblMSCustType = New System.Windows.Forms.Label()
        Me.TxtTTPackQty = New System.Windows.Forms.Label()
        Me.lblMSType = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.chkIsRepaired = New System.Windows.Forms.CheckBox()
        Me.LblScanTime = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtLineId = New System.Windows.Forms.Label()
        Me.TxtSitName = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.TxtMoId = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolUsename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolCa = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolOption = New System.Windows.Forms.ToolStripButton()
        Me.toolPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolNg = New System.Windows.Forms.ToolStripButton()
        Me.ToolReplace = New System.Windows.Forms.ToolStripButton()
        Me.ToolScanPrt = New System.Windows.Forms.ToolStripButton()
        Me.ToolLot = New System.Windows.Forms.ToolStripButton()
        Me.toolMOStatusSetting = New System.Windows.Forms.ToolStripButton()
        Me.ToolEquipment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.DGridBarCode = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvEquipPart = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.EquipmentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessParameters = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlertCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemainCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvEquipPart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.groupBox2.Controls.Add(Me.txtOnLineWeight)
        Me.groupBox2.Controls.Add(Me.lbOnLineWeight)
        Me.groupBox2.Controls.Add(Me.chbMessage)
        Me.groupBox2.Controls.Add(Me.Label13)
        Me.groupBox2.Controls.Add(Me.txt_tmpbarcode)
        Me.groupBox2.Controls.Add(Me.Label11)
        Me.groupBox2.Controls.Add(Me.LblRcode)
        Me.groupBox2.Controls.Add(Me.LblMoqty)
        Me.groupBox2.Controls.Add(Me.TxtRcode)
        Me.groupBox2.Controls.Add(Me.Label9)
        Me.groupBox2.Controls.Add(Me.LabCartonQty)
        Me.groupBox2.Controls.Add(Me.Label10)
        Me.groupBox2.Controls.Add(Me.LblCheckTime)
        Me.groupBox2.Controls.Add(Me.Label6)
        Me.groupBox2.Controls.Add(Me.groupBox3)
        Me.groupBox2.Controls.Add(Me.TxtSnStyle1)
        Me.groupBox2.Controls.Add(Me.TxtSnStyle2)
        Me.groupBox2.Controls.Add(Me.TxtCartonNo)
        Me.groupBox2.Controls.Add(Me.Label3)
        Me.groupBox2.Controls.Add(Me.TxtBarCode)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.Label7)
        Me.groupBox2.Controls.Add(Me.LblBarName)
        Me.groupBox2.ForeColor = System.Drawing.Color.White
        Me.groupBox2.Location = New System.Drawing.Point(2, 70)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(1245, 186)
        Me.groupBox2.TabIndex = 6
        Me.groupBox2.TabStop = False
        '
        'txtOnLineWeight
        '
        Me.txtOnLineWeight.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.txtOnLineWeight.BorderColor = System.Drawing.Color.White
        Me.txtOnLineWeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOnLineWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOnLineWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtOnLineWeight.ForeColor = System.Drawing.Color.White
        Me.txtOnLineWeight.HotColor = System.Drawing.Color.White
        Me.txtOnLineWeight.Location = New System.Drawing.Point(127, 134)
        Me.txtOnLineWeight.Name = "txtOnLineWeight"
        Me.txtOnLineWeight.Size = New System.Drawing.Size(243, 14)
        Me.txtOnLineWeight.TabIndex = 117
        '
        'lbOnLineWeight
        '
        Me.lbOnLineWeight.AutoSize = True
        Me.lbOnLineWeight.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOnLineWeight.ForeColor = System.Drawing.Color.White
        Me.lbOnLineWeight.Location = New System.Drawing.Point(6, 132)
        Me.lbOnLineWeight.Name = "lbOnLineWeight"
        Me.lbOnLineWeight.Size = New System.Drawing.Size(78, 16)
        Me.lbOnLineWeight.TabIndex = 116
        Me.lbOnLineWeight.Text = "产品重量："
        '
        'chbMessage
        '
        Me.chbMessage.AutoSize = True
        Me.chbMessage.Location = New System.Drawing.Point(817, 114)
        Me.chbMessage.Name = "chbMessage"
        Me.chbMessage.Size = New System.Drawing.Size(15, 14)
        Me.chbMessage.TabIndex = 115
        Me.chbMessage.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 11.0!)
        Me.Label13.Location = New System.Drawing.Point(735, 113)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 15)
        Me.Label13.TabIndex = 114
        Me.Label13.Text = "提示声音:"
        '
        'txt_tmpbarcode
        '
        Me.txt_tmpbarcode.Location = New System.Drawing.Point(113, 120)
        Me.txt_tmpbarcode.Name = "txt_tmpbarcode"
        Me.txt_tmpbarcode.Size = New System.Drawing.Size(0, 21)
        Me.txt_tmpbarcode.TabIndex = 106
        Me.txt_tmpbarcode.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(729, 113)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 40)
        Me.Label11.TabIndex = 105
        Me.Label11.Text = "..."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblRcode
        '
        Me.LblRcode.AutoSize = True
        Me.LblRcode.Font = New System.Drawing.Font("Arial", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRcode.ForeColor = System.Drawing.Color.White
        Me.LblRcode.Location = New System.Drawing.Point(6, 163)
        Me.LblRcode.Name = "LblRcode"
        Me.LblRcode.Size = New System.Drawing.Size(106, 16)
        Me.LblRcode.TabIndex = 100
        Me.LblRcode.Text = "不良现象代码："
        '
        'LblMoqty
        '
        Me.LblMoqty.AutoSize = True
        Me.LblMoqty.BackColor = System.Drawing.Color.Transparent
        Me.LblMoqty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblMoqty.ForeColor = System.Drawing.Color.White
        Me.LblMoqty.Location = New System.Drawing.Point(671, 148)
        Me.LblMoqty.Name = "LblMoqty"
        Me.LblMoqty.Size = New System.Drawing.Size(21, 22)
        Me.LblMoqty.TabIndex = 104
        Me.LblMoqty.Text = "0"
        '
        'TxtRcode
        '
        Me.TxtRcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TxtRcode.BorderColor = System.Drawing.Color.White
        Me.TxtRcode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtRcode.ForeColor = System.Drawing.Color.White
        Me.TxtRcode.HotColor = System.Drawing.Color.White
        Me.TxtRcode.Location = New System.Drawing.Point(127, 162)
        Me.TxtRcode.Name = "TxtRcode"
        Me.TxtRcode.Size = New System.Drawing.Size(243, 14)
        Me.TxtRcode.TabIndex = 91
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(570, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 18)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "工单生产数:"
        '
        'LabCartonQty
        '
        Me.LabCartonQty.AutoSize = True
        Me.LabCartonQty.BackColor = System.Drawing.Color.Transparent
        Me.LabCartonQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LabCartonQty.ForeColor = System.Drawing.Color.White
        Me.LabCartonQty.Location = New System.Drawing.Point(492, 148)
        Me.LabCartonQty.Name = "LabCartonQty"
        Me.LabCartonQty.Size = New System.Drawing.Size(21, 22)
        Me.LabCartonQty.TabIndex = 102
        Me.LabCartonQty.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(391, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 18)
        Me.Label10.TabIndex = 101
        Me.Label10.Text = "扫描产品数:"
        '
        'LblCheckTime
        '
        Me.LblCheckTime.AutoSize = True
        Me.LblCheckTime.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblCheckTime.ForeColor = System.Drawing.Color.White
        Me.LblCheckTime.Location = New System.Drawing.Point(621, 113)
        Me.LblCheckTime.Name = "LblCheckTime"
        Me.LblCheckTime.Size = New System.Drawing.Size(27, 19)
        Me.LblCheckTime.TabIndex = 99
        Me.LblCheckTime.Text = "72"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(391, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(217, 16)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "产品时间管控间隔时间(小時):"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.groupBox3.Controls.Add(Me.lblMessage)
        Me.groupBox3.Controls.Add(Me.LabResult)
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(386, 11)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(853, 84)
        Me.groupBox3.TabIndex = 93
        Me.groupBox3.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(6, 37)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(106, 40)
        Me.lblMessage.TabIndex = 86
        Me.lblMessage.Text = "PASS"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabResult
        '
        Me.LabResult.AutoSize = True
        Me.LabResult.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabResult.ForeColor = System.Drawing.Color.White
        Me.LabResult.Location = New System.Drawing.Point(7, 16)
        Me.LabResult.Name = "LabResult"
        Me.LabResult.Size = New System.Drawing.Size(69, 19)
        Me.LabResult.TabIndex = 82
        Me.LabResult.Text = "Ready..."
        Me.LabResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtSnStyle1
        '
        Me.TxtSnStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TxtSnStyle1.BorderColor = System.Drawing.Color.White
        Me.TxtSnStyle1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSnStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtSnStyle1.ForeColor = System.Drawing.Color.White
        Me.TxtSnStyle1.HotColor = System.Drawing.Color.White
        Me.TxtSnStyle1.Location = New System.Drawing.Point(127, 15)
        Me.TxtSnStyle1.Name = "TxtSnStyle1"
        Me.TxtSnStyle1.Size = New System.Drawing.Size(243, 14)
        Me.TxtSnStyle1.TabIndex = 97
        '
        'TxtSnStyle2
        '
        Me.TxtSnStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TxtSnStyle2.BorderColor = System.Drawing.Color.White
        Me.TxtSnStyle2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSnStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtSnStyle2.ForeColor = System.Drawing.Color.White
        Me.TxtSnStyle2.HotColor = System.Drawing.Color.White
        Me.TxtSnStyle2.Location = New System.Drawing.Point(127, 43)
        Me.TxtSnStyle2.Name = "TxtSnStyle2"
        Me.TxtSnStyle2.Size = New System.Drawing.Size(243, 14)
        Me.TxtSnStyle2.TabIndex = 96
        '
        'TxtCartonNo
        '
        Me.TxtCartonNo.AutoSize = True
        Me.TxtCartonNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCartonNo.ForeColor = System.Drawing.Color.White
        Me.TxtCartonNo.Location = New System.Drawing.Point(123, 102)
        Me.TxtCartonNo.Name = "TxtCartonNo"
        Me.TxtCartonNo.Size = New System.Drawing.Size(0, 15)
        Me.TxtCartonNo.TabIndex = 95
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 18)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "主条码序号:"
        '
        'TxtBarCode
        '
        Me.TxtBarCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TxtBarCode.BorderColor = System.Drawing.Color.White
        Me.TxtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtBarCode.ForeColor = System.Drawing.Color.White
        Me.TxtBarCode.HotColor = System.Drawing.Color.White
        Me.TxtBarCode.Location = New System.Drawing.Point(127, 70)
        Me.TxtBarCode.Name = "TxtBarCode"
        Me.TxtBarCode.Size = New System.Drawing.Size(243, 14)
        Me.TxtBarCode.TabIndex = 90
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.ForeColor = System.Drawing.Color.White
        Me.label5.Location = New System.Drawing.Point(5, 47)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(89, 12)
        Me.label5.TabIndex = 74
        Me.label5.Text = "条码标准样式："
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 12)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "条码标准样式："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBarName
        '
        Me.LblBarName.AutoSize = True
        Me.LblBarName.Font = New System.Drawing.Font("宋体", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBarName.ForeColor = System.Drawing.Color.White
        Me.LblBarName.Location = New System.Drawing.Point(3, 69)
        Me.LblBarName.Name = "LblBarName"
        Me.LblBarName.Size = New System.Drawing.Size(80, 15)
        Me.LblBarName.TabIndex = 71
        Me.LblBarName.Text = "电源条码:"
        Me.LblBarName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.groupBox1.Controls.Add(Me.cboPrinterList)
        Me.groupBox1.Controls.Add(Me.LabelX1)
        Me.groupBox1.Controls.Add(Me.lblMSCustType)
        Me.groupBox1.Controls.Add(Me.TxtTTPackQty)
        Me.groupBox1.Controls.Add(Me.lblMSType)
        Me.groupBox1.Controls.Add(Me.Label12)
        Me.groupBox1.Controls.Add(Me.chkIsRepaired)
        Me.groupBox1.Controls.Add(Me.LblScanTime)
        Me.groupBox1.Controls.Add(Me.Label8)
        Me.groupBox1.Controls.Add(Me.TxtLineId)
        Me.groupBox1.Controls.Add(Me.TxtSitName)
        Me.groupBox1.Controls.Add(Me.TxtPartid)
        Me.groupBox1.Controls.Add(Me.label22)
        Me.groupBox1.Controls.Add(Me.TxtMoId)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.groupBox1.Location = New System.Drawing.Point(0, 26)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(1245, 38)
        Me.groupBox1.TabIndex = 91
        Me.groupBox1.TabStop = False
        '
        'cboPrinterList
        '
        Me.cboPrinterList.DisplayMember = "Text"
        Me.cboPrinterList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPrinterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrinterList.FormattingEnabled = True
        Me.cboPrinterList.ItemHeight = 15
        Me.cboPrinterList.Location = New System.Drawing.Point(885, 13)
        Me.cboPrinterList.Name = "cboPrinterList"
        Me.cboPrinterList.Size = New System.Drawing.Size(133, 21)
        Me.cboPrinterList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboPrinterList.TabIndex = 114
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(831, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(48, 19)
        Me.LabelX1.TabIndex = 113
        Me.LabelX1.Text = "打印机"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Far
        '
        'lblMSCustType
        '
        Me.lblMSCustType.AutoSize = True
        Me.lblMSCustType.Location = New System.Drawing.Point(1121, 17)
        Me.lblMSCustType.Name = "lblMSCustType"
        Me.lblMSCustType.Size = New System.Drawing.Size(0, 12)
        Me.lblMSCustType.TabIndex = 112
        '
        'TxtTTPackQty
        '
        Me.TxtTTPackQty.AutoSize = True
        Me.TxtTTPackQty.Location = New System.Drawing.Point(1018, 16)
        Me.TxtTTPackQty.Name = "TxtTTPackQty"
        Me.TxtTTPackQty.Size = New System.Drawing.Size(0, 12)
        Me.TxtTTPackQty.TabIndex = 111
        '
        'lblMSType
        '
        Me.lblMSType.AutoSize = True
        Me.lblMSType.ForeColor = System.Drawing.Color.Black
        Me.lblMSType.Location = New System.Drawing.Point(1243, 17)
        Me.lblMSType.Name = "lblMSType"
        Me.lblMSType.Size = New System.Drawing.Size(65, 12)
        Me.lblMSType.TabIndex = 110
        Me.lblMSType.Text = "来料类型："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(1125, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 12)
        Me.Label12.TabIndex = 110
        Me.Label12.Text = "TT成品装箱数："
        '
        'chkIsRepaired
        '
        Me.chkIsRepaired.AutoSize = True
        Me.chkIsRepaired.Location = New System.Drawing.Point(1039, 15)
        Me.chkIsRepaired.Name = "chkIsRepaired"
        Me.chkIsRepaired.Size = New System.Drawing.Size(72, 16)
        Me.chkIsRepaired.TabIndex = 109
        Me.chkIsRepaired.Text = "是维修品"
        Me.chkIsRepaired.UseVisualStyleBackColor = True
        '
        'LblScanTime
        '
        Me.LblScanTime.AutoSize = True
        Me.LblScanTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblScanTime.Location = New System.Drawing.Point(727, 16)
        Me.LblScanTime.Name = "LblScanTime"
        Me.LblScanTime.Size = New System.Drawing.Size(0, 12)
        Me.LblScanTime.TabIndex = 108
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(639, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 12)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "计数起始时间："
        '
        'TxtLineId
        '
        Me.TxtLineId.AutoSize = True
        Me.TxtLineId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtLineId.Location = New System.Drawing.Point(408, 16)
        Me.TxtLineId.Name = "TxtLineId"
        Me.TxtLineId.Size = New System.Drawing.Size(0, 12)
        Me.TxtLineId.TabIndex = 106
        '
        'TxtSitName
        '
        Me.TxtSitName.AutoSize = True
        Me.TxtSitName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtSitName.Location = New System.Drawing.Point(521, 16)
        Me.TxtSitName.Name = "TxtSitName"
        Me.TxtSitName.Size = New System.Drawing.Size(0, 12)
        Me.TxtSitName.TabIndex = 102
        '
        'TxtPartid
        '
        Me.TxtPartid.AutoSize = True
        Me.TxtPartid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtPartid.Location = New System.Drawing.Point(242, 16)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(0, 12)
        Me.TxtPartid.TabIndex = 100
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.ForeColor = System.Drawing.Color.Black
        Me.label22.Location = New System.Drawing.Point(345, 16)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(65, 12)
        Me.label22.TabIndex = 87
        Me.label22.Text = "线别编号："
        '
        'TxtMoId
        '
        Me.TxtMoId.AutoSize = True
        Me.TxtMoId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtMoId.Location = New System.Drawing.Point(69, 16)
        Me.TxtMoId.Name = "TxtMoId"
        Me.TxtMoId.Size = New System.Drawing.Size(0, 12)
        Me.TxtMoId.TabIndex = 99
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.ForeColor = System.Drawing.Color.Black
        Me.label4.Location = New System.Drawing.Point(462, 16)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(65, 12)
        Me.label4.TabIndex = 6
        Me.label4.Text = "站点名称："
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(180, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 12)
        Me.label2.TabIndex = 2
        Me.label2.Text = "料件编号："
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(7, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(65, 12)
        Me.label1.TabIndex = 0
        Me.label1.Text = "工单编号："
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.ToolUsename})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 605)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1250, 22)
        Me.statusStrip1.TabIndex = 92
        Me.statusStrip1.Text = "statusStrip1"
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.toolStripStatusLabel1.Image = CType(resources.GetObject("toolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(81, 17)
        Me.toolStripStatusLabel1.Text = "扫描人员："
        '
        'ToolUsename
        '
        Me.ToolUsename.Name = "ToolUsename"
        Me.ToolUsename.Size = New System.Drawing.Size(0, 17)
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolScanSet, Me.toolStripSeparator2, Me.toolCa, Me.ToolStripSeparator4, Me.ToolOption, Me.toolPrint, Me.ToolStripSeparator3, Me.ToolNg, Me.ToolReplace, Me.ToolScanPrt, Me.ToolLot, Me.toolMOStatusSetting, Me.ToolEquipment, Me.ToolStripSeparator5, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(2, 2)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1250, 25)
        Me.toolStrip1.TabIndex = 7
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolScanSet
        '
        Me.toolScanSet.Image = CType(resources.GetObject("toolScanSet.Image"), System.Drawing.Image)
        Me.toolScanSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolScanSet.Name = "toolScanSet"
        Me.toolScanSet.Size = New System.Drawing.Size(97, 22)
        Me.toolScanSet.Text = "扫描设置(&F1)"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolCa
        '
        Me.toolCa.Image = CType(resources.GetObject("toolCa.Image"), System.Drawing.Image)
        Me.toolCa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCa.Name = "toolCa"
        Me.toolCa.Size = New System.Drawing.Size(97, 22)
        Me.toolCa.Text = "关联拆换(&F2)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolOption
        '
        Me.ToolOption.Image = CType(resources.GetObject("ToolOption.Image"), System.Drawing.Image)
        Me.ToolOption.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolOption.Name = "ToolOption"
        Me.ToolOption.Size = New System.Drawing.Size(91, 22)
        Me.ToolOption.Text = "参数设置(&O)"
        '
        'toolPrint
        '
        Me.toolPrint.Image = CType(resources.GetObject("toolPrint.Image"), System.Drawing.Image)
        Me.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolPrint.Name = "toolPrint"
        Me.toolPrint.Size = New System.Drawing.Size(121, 22)
        Me.toolPrint.Text = "重新打印彩盒标签"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolNg
        '
        Me.ToolNg.Image = CType(resources.GetObject("ToolNg.Image"), System.Drawing.Image)
        Me.ToolNg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNg.Name = "ToolNg"
        Me.ToolNg.Size = New System.Drawing.Size(115, 22)
        Me.ToolNg.Text = "录入不良代码(R)"
        '
        'ToolReplace
        '
        Me.ToolReplace.Image = CType(resources.GetObject("ToolReplace.Image"), System.Drawing.Image)
        Me.ToolReplace.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReplace.Name = "ToolReplace"
        Me.ToolReplace.Size = New System.Drawing.Size(139, 22)
        Me.ToolReplace.Text = "产品条码替换打印(R)"
        '
        'ToolScanPrt
        '
        Me.ToolScanPrt.Image = CType(resources.GetObject("ToolScanPrt.Image"), System.Drawing.Image)
        Me.ToolScanPrt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolScanPrt.Name = "ToolScanPrt"
        Me.ToolScanPrt.Size = New System.Drawing.Size(73, 22)
        Me.ToolScanPrt.Text = "扫描打印"
        '
        'ToolLot
        '
        Me.ToolLot.Image = CType(resources.GetObject("ToolLot.Image"), System.Drawing.Image)
        Me.ToolLot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLot.Name = "ToolLot"
        Me.ToolLot.Size = New System.Drawing.Size(115, 22)
        Me.ToolLot.Text = "上料批次扫描(L)"
        '
        'toolMOStatusSetting
        '
        Me.toolMOStatusSetting.Image = CType(resources.GetObject("toolMOStatusSetting.Image"), System.Drawing.Image)
        Me.toolMOStatusSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMOStatusSetting.Name = "toolMOStatusSetting"
        Me.toolMOStatusSetting.Size = New System.Drawing.Size(97, 22)
        Me.toolMOStatusSetting.Text = "工单状态设置"
        '
        'ToolEquipment
        '
        Me.ToolEquipment.Image = CType(resources.GetObject("ToolEquipment.Image"), System.Drawing.Image)
        Me.ToolEquipment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEquipment.Name = "ToolEquipment"
        Me.ToolEquipment.Size = New System.Drawing.Size(85, 22)
        Me.ToolEquipment.Text = "工冶具设定"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(67, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'DGridBarCode
        '
        Me.DGridBarCode.AllowUserToAddRows = False
        Me.DGridBarCode.AllowUserToDeleteRows = False
        Me.DGridBarCode.BackgroundColor = System.Drawing.Color.White
        Me.DGridBarCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGridBarCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGridBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridBarCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.DGridBarCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGridBarCode.Location = New System.Drawing.Point(3, 17)
        Me.DGridBarCode.Name = "DGridBarCode"
        Me.DGridBarCode.ReadOnly = True
        Me.DGridBarCode.RowHeadersWidth = 4
        Me.DGridBarCode.RowTemplate.Height = 23
        Me.DGridBarCode.Size = New System.Drawing.Size(1237, 330)
        Me.DGridBarCode.TabIndex = 105
        '
        'Column1
        '
        Me.Column1.HeaderText = "成品料号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "站点项次序号"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "部件条码序号"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 120
        '
        'Column4
        '
        Me.Column4.HeaderText = "部件名称"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "扫描人员"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "扫描时间"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.dgvEquipPart)
        Me.GroupBox4.Controls.Add(Me.DGridBarCode)
        Me.GroupBox4.Location = New System.Drawing.Point(2, 252)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1243, 350)
        Me.GroupBox4.TabIndex = 129
        Me.GroupBox4.TabStop = False
        '
        'dgvEquipPart
        '
        Me.dgvEquipPart.AllowUserToAddRows = False
        Me.dgvEquipPart.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvEquipPart.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEquipPart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEquipPart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEquipPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquipPart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EquipmentNo, Me.ProcessParameters, Me.AlertCount, Me.ServiceCount, Me.RemainCount})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEquipPart.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEquipPart.Dock = System.Windows.Forms.DockStyle.Right
        Me.dgvEquipPart.EnableHeadersVisualStyles = False
        Me.dgvEquipPart.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvEquipPart.Location = New System.Drawing.Point(859, 17)
        Me.dgvEquipPart.Name = "dgvEquipPart"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEquipPart.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEquipPart.RowHeadersVisible = False
        Me.dgvEquipPart.RowHeadersWidth = 20
        Me.dgvEquipPart.RowTemplate.Height = 23
        Me.dgvEquipPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvEquipPart.Size = New System.Drawing.Size(381, 330)
        Me.dgvEquipPart.TabIndex = 134
        '
        'EquipmentNo
        '
        Me.EquipmentNo.HeaderText = "治具编号"
        Me.EquipmentNo.Name = "EquipmentNo"
        Me.EquipmentNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EquipmentNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EquipmentNo.Width = 80
        '
        'ProcessParameters
        '
        Me.ProcessParameters.HeaderText = "冶具名称"
        Me.ProcessParameters.Name = "ProcessParameters"
        Me.ProcessParameters.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProcessParameters.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'AlertCount
        '
        Me.AlertCount.HeaderText = "预警次数"
        Me.AlertCount.Name = "AlertCount"
        Me.AlertCount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AlertCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AlertCount.Width = 60
        '
        'ServiceCount
        '
        Me.ServiceCount.HeaderText = "使用次数"
        Me.ServiceCount.Name = "ServiceCount"
        Me.ServiceCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ServiceCount.Width = 60
        '
        'RemainCount
        '
        Me.RemainCount.HeaderText = "剩余次数"
        Me.RemainCount.Name = "RemainCount"
        Me.RemainCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RemainCount.Width = 60
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "成品料號"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "站點項次序號"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 160.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "子料號條碼序號"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 160
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "子條碼名稱"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 120
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "掃描人員"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "掃描時間"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "站点项次序号"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "部件条码序号"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 120
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "部件名称"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "扫描人员"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "扫描时间"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'FrmWorkStantScan_L01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1250, 627)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.groupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmWorkStantScan_L01"
        Me.Text = "工站扫描作业"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvEquipPart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblBarName As System.Windows.Forms.Label
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolCa As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtLineId As System.Windows.Forms.Label
    Friend WithEvents TxtSitName As System.Windows.Forms.Label
    Friend WithEvents TxtPartid As System.Windows.Forms.Label
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents TxtMoId As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Private WithEvents LabResult As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCartonNo As System.Windows.Forms.Label
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolUsename As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TxtSnStyle2 As ULControls.textBoxUL
    Friend WithEvents TxtSnStyle1 As ULControls.textBoxUL
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolOption As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblCheckTime As System.Windows.Forms.Label
    Friend WithEvents ToolNg As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolScanPrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LblRcode As System.Windows.Forms.Label
    Friend WithEvents TxtRcode As ULControls.textBoxUL
    Friend WithEvents LabCartonQty As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblMoqty As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToolReplace As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolLot As System.Windows.Forms.ToolStripButton
    Private WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblScanTime As System.Windows.Forms.Label
    Friend WithEvents DGridBarCode As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_tmpbarcode As System.Windows.Forms.TextBox
    Friend WithEvents chbMessage As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkIsRepaired As System.Windows.Forms.CheckBox
    Friend WithEvents ToolEquipment As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEquipPart As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents EquipmentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessParameters As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlertCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemainCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toolMOStatusSetting As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxtTTPackQty As System.Windows.Forms.Label
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents lblMSType As System.Windows.Forms.Label
    Friend WithEvents lblMSCustType As System.Windows.Forms.Label
    Friend WithEvents TxtBarCode As ULControls.textBoxUL
    Private WithEvents cboPrinterList As DevComponents.DotNetBar.Controls.ComboBoxEx
    Private WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents toolPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtOnLineWeight As ULControls.textBoxUL
    Friend WithEvents lbOnLineWeight As System.Windows.Forms.Label
End Class
