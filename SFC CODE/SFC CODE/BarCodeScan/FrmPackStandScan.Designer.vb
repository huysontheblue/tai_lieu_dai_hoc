<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPackStandScan
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

    '注意： 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPackStandScan))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.label22 = New System.Windows.Forms.Label()
        Me.label23 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtCartonNo = New ULControls.textBoxUL()
        Me.LblPalletNo = New ULControls.textBoxUL()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblCurrQty = New System.Windows.Forms.Label()
        Me.LblMoQty = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblMoProduceQty = New System.Windows.Forms.Label()
        Me.TxtSnStyle1 = New ULControls.textBoxUL()
        Me.TxtSnStyle2 = New ULControls.textBoxUL()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.LabResult = New System.Windows.Forms.Label()
        Me.LblCurrentCartonIndex = New System.Windows.Forms.Label()
        Me.label19 = New System.Windows.Forms.Label()
        Me.LblPalletCartonCount = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtBarCode = New ULControls.textBoxUL()
        Me.LblPackQty = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblType = New System.Windows.Forms.Label()
        Me.TxtLineId = New System.Windows.Forms.Label()
        Me.TxtSitName = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.Label()
        Me.TxtMoId = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolUsename = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolTestPrint = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolLastCarton = New System.Windows.Forms.ToolStripSplitButton()
        Me.LastCartonSet = New System.Windows.Forms.ToolStripButton()
        Me.toolLastPalletSet = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolPalletCarton = New System.Windows.Forms.ToolStripButton()
        Me.toolPalletSet = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolReplacePrint = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolca = New System.Windows.Forms.ToolStripButton()
        Me.toolMOStatusSetting = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgDataShow = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TextQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fstyle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        CType(Me.dgDataShow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.ForeColor = System.Drawing.Color.Black
        Me.label22.Location = New System.Drawing.Point(345, 18)
        Me.label22.Name = "label22"
        Me.label22.Size = New System.Drawing.Size(65, 12)
        Me.label22.TabIndex = 87
        Me.label22.Text = "线别编号："
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.label23.ForeColor = System.Drawing.Color.White
        Me.label23.Location = New System.Drawing.Point(6, 108)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(67, 15)
        Me.label23.TabIndex = 83
        Me.label23.Text = "外箱条码："
        Me.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.groupBox2.Controls.Add(Me.TxtCartonNo)
        Me.groupBox2.Controls.Add(Me.LblPalletNo)
        Me.groupBox2.Controls.Add(Me.Label8)
        Me.groupBox2.Controls.Add(Me.Label3)
        Me.groupBox2.Controls.Add(Me.LblCurrQty)
        Me.groupBox2.Controls.Add(Me.LblMoQty)
        Me.groupBox2.Controls.Add(Me.Label13)
        Me.groupBox2.Controls.Add(Me.LblMoProduceQty)
        Me.groupBox2.Controls.Add(Me.TxtSnStyle1)
        Me.groupBox2.Controls.Add(Me.TxtSnStyle2)
        Me.groupBox2.Controls.Add(Me.groupBox3)
        Me.groupBox2.Controls.Add(Me.LblCurrentCartonIndex)
        Me.groupBox2.Controls.Add(Me.label19)
        Me.groupBox2.Controls.Add(Me.LblPalletCartonCount)
        Me.groupBox2.Controls.Add(Me.Label17)
        Me.groupBox2.Controls.Add(Me.TxtBarCode)
        Me.groupBox2.Controls.Add(Me.LblPackQty)
        Me.groupBox2.Controls.Add(Me.Label12)
        Me.groupBox2.Controls.Add(Me.label23)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.Label7)
        Me.groupBox2.Controls.Add(Me.Label16)
        Me.groupBox2.Location = New System.Drawing.Point(2, 72)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(874, 184)
        Me.groupBox2.TabIndex = 4
        Me.groupBox2.TabStop = False
        '
        'TxtCartonNo
        '
        Me.TxtCartonNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TxtCartonNo.BorderColor = System.Drawing.Color.White
        Me.TxtCartonNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCartonNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCartonNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtCartonNo.ForeColor = System.Drawing.Color.White
        Me.TxtCartonNo.HotColor = System.Drawing.Color.White
        Me.TxtCartonNo.Location = New System.Drawing.Point(76, 106)
        Me.TxtCartonNo.Name = "TxtCartonNo"
        Me.TxtCartonNo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtCartonNo.Size = New System.Drawing.Size(243, 14)
        Me.TxtCartonNo.TabIndex = 101
        '
        'LblPalletNo
        '
        Me.LblPalletNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.LblPalletNo.BorderColor = System.Drawing.Color.White
        Me.LblPalletNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LblPalletNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LblPalletNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LblPalletNo.ForeColor = System.Drawing.Color.White
        Me.LblPalletNo.HotColor = System.Drawing.Color.White
        Me.LblPalletNo.Location = New System.Drawing.Point(73, 132)
        Me.LblPalletNo.Name = "LblPalletNo"
        Me.LblPalletNo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.LblPalletNo.Size = New System.Drawing.Size(243, 14)
        Me.LblPalletNo.TabIndex = 100
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(553, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 12)
        Me.Label8.TabIndex = 99
        Me.Label8.Text = "工单生产数："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(553, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "工单扫描数："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblCurrQty
        '
        Me.LblCurrQty.AutoSize = True
        Me.LblCurrQty.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrQty.ForeColor = System.Drawing.Color.White
        Me.LblCurrQty.Location = New System.Drawing.Point(501, 131)
        Me.LblCurrQty.Name = "LblCurrQty"
        Me.LblCurrQty.Size = New System.Drawing.Size(24, 25)
        Me.LblCurrQty.TabIndex = 91
        Me.LblCurrQty.Text = "0"
        '
        'LblMoQty
        '
        Me.LblMoQty.AutoSize = True
        Me.LblMoQty.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMoQty.ForeColor = System.Drawing.Color.White
        Me.LblMoQty.Location = New System.Drawing.Point(641, 131)
        Me.LblMoQty.Name = "LblMoQty"
        Me.LblMoQty.Size = New System.Drawing.Size(24, 25)
        Me.LblMoQty.TabIndex = 96
        Me.LblMoQty.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(450, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 90
        Me.Label13.Text = "当前数："
        '
        'LblMoProduceQty
        '
        Me.LblMoProduceQty.AutoSize = True
        Me.LblMoProduceQty.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMoProduceQty.ForeColor = System.Drawing.Color.White
        Me.LblMoProduceQty.Location = New System.Drawing.Point(641, 103)
        Me.LblMoProduceQty.Name = "LblMoProduceQty"
        Me.LblMoProduceQty.Size = New System.Drawing.Size(24, 25)
        Me.LblMoProduceQty.TabIndex = 98
        Me.LblMoProduceQty.Text = "0"
        '
        'TxtSnStyle1
        '
        Me.TxtSnStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TxtSnStyle1.BorderColor = System.Drawing.Color.White
        Me.TxtSnStyle1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSnStyle1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSnStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtSnStyle1.ForeColor = System.Drawing.Color.White
        Me.TxtSnStyle1.HotColor = System.Drawing.Color.White
        Me.TxtSnStyle1.Location = New System.Drawing.Point(99, 17)
        Me.TxtSnStyle1.Name = "TxtSnStyle1"
        Me.TxtSnStyle1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtSnStyle1.Size = New System.Drawing.Size(243, 14)
        Me.TxtSnStyle1.TabIndex = 95
        Me.TxtSnStyle1.TabStop = False
        '
        'TxtSnStyle2
        '
        Me.TxtSnStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TxtSnStyle2.BorderColor = System.Drawing.Color.White
        Me.TxtSnStyle2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSnStyle2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSnStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtSnStyle2.ForeColor = System.Drawing.Color.White
        Me.TxtSnStyle2.HotColor = System.Drawing.Color.White
        Me.TxtSnStyle2.Location = New System.Drawing.Point(99, 45)
        Me.TxtSnStyle2.Name = "TxtSnStyle2"
        Me.TxtSnStyle2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtSnStyle2.Size = New System.Drawing.Size(243, 14)
        Me.TxtSnStyle2.TabIndex = 94
        Me.TxtSnStyle2.TabStop = False
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.groupBox3.Controls.Add(Me.lblMessage)
        Me.groupBox3.Controls.Add(Me.LabResult)
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(358, 11)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(510, 87)
        Me.groupBox3.TabIndex = 79
        Me.groupBox3.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(2, 40)
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
        Me.LabResult.Location = New System.Drawing.Point(10, 15)
        Me.LabResult.Name = "LabResult"
        Me.LabResult.Size = New System.Drawing.Size(140, 19)
        Me.LabResult.TabIndex = 82
        Me.LabResult.Text = "扫描资料已设置..."
        Me.LabResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCurrentCartonIndex
        '
        Me.LblCurrentCartonIndex.AutoSize = True
        Me.LblCurrentCartonIndex.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrentCartonIndex.ForeColor = System.Drawing.Color.White
        Me.LblCurrentCartonIndex.Location = New System.Drawing.Point(395, 131)
        Me.LblCurrentCartonIndex.Name = "LblCurrentCartonIndex"
        Me.LblCurrentCartonIndex.Size = New System.Drawing.Size(24, 25)
        Me.LblCurrentCartonIndex.TabIndex = 84
        Me.LblCurrentCartonIndex.Text = "0"
        '
        'label19
        '
        Me.label19.AutoSize = True
        Me.label19.ForeColor = System.Drawing.Color.White
        Me.label19.Location = New System.Drawing.Point(343, 136)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(53, 12)
        Me.label19.TabIndex = 83
        Me.label19.Text = "当前箱："
        '
        'LblPalletCartonCount
        '
        Me.LblPalletCartonCount.AutoSize = True
        Me.LblPalletCartonCount.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPalletCartonCount.ForeColor = System.Drawing.Color.White
        Me.LblPalletCartonCount.Location = New System.Drawing.Point(395, 103)
        Me.LblPalletCartonCount.Name = "LblPalletCartonCount"
        Me.LblPalletCartonCount.Size = New System.Drawing.Size(24, 25)
        Me.LblPalletCartonCount.TabIndex = 80
        Me.LblPalletCartonCount.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(450, 108)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 12)
        Me.Label17.TabIndex = 88
        Me.Label17.Text = "应装数："
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.TxtBarCode.Location = New System.Drawing.Point(99, 73)
        Me.TxtBarCode.Name = "TxtBarCode"
        Me.TxtBarCode.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtBarCode.Size = New System.Drawing.Size(243, 14)
        Me.TxtBarCode.TabIndex = 0
        '
        'LblPackQty
        '
        Me.LblPackQty.AutoSize = True
        Me.LblPackQty.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPackQty.ForeColor = System.Drawing.Color.White
        Me.LblPackQty.Location = New System.Drawing.Point(501, 103)
        Me.LblPackQty.Name = "LblPackQty"
        Me.LblPackQty.Size = New System.Drawing.Size(24, 25)
        Me.LblPackQty.TabIndex = 87
        Me.LblPackQty.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(343, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 77
        Me.Label12.Text = "应装箱："
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.label6.ForeColor = System.Drawing.Color.White
        Me.label6.Location = New System.Drawing.Point(7, 137)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(67, 15)
        Me.label6.TabIndex = 78
        Me.label6.Text = "栈板条码："
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.label5.ForeColor = System.Drawing.Color.White
        Me.label5.Location = New System.Drawing.Point(7, 48)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(91, 15)
        Me.label5.TabIndex = 74
        Me.label5.Text = "条码标准样式："
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(7, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 15)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "条码标准样式："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(7, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 15)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "产品条码序号："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(173, 18)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 12)
        Me.label2.TabIndex = 2
        Me.label2.Text = "料件编号："
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(8, 18)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(65, 12)
        Me.label1.TabIndex = 0
        Me.label1.Text = "工单编号："
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.groupBox1.Controls.Add(Me.LblType)
        Me.groupBox1.Controls.Add(Me.TxtLineId)
        Me.groupBox1.Controls.Add(Me.TxtSitName)
        Me.groupBox1.Controls.Add(Me.TxtPartid)
        Me.groupBox1.Controls.Add(Me.label22)
        Me.groupBox1.Controls.Add(Me.TxtMoId)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.groupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.groupBox1.Location = New System.Drawing.Point(2, 23)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(874, 43)
        Me.groupBox1.TabIndex = 7
        Me.groupBox1.TabStop = False
        '
        'LblType
        '
        Me.LblType.AutoSize = True
        Me.LblType.Location = New System.Drawing.Point(683, 18)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(0, 12)
        Me.LblType.TabIndex = 107
        Me.LblType.Visible = False
        '
        'TxtLineId
        '
        Me.TxtLineId.AutoSize = True
        Me.TxtLineId.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtLineId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.TxtLineId.Location = New System.Drawing.Point(411, 18)
        Me.TxtLineId.Name = "TxtLineId"
        Me.TxtLineId.Size = New System.Drawing.Size(0, 12)
        Me.TxtLineId.TabIndex = 106
        '
        'TxtSitName
        '
        Me.TxtSitName.AutoSize = True
        Me.TxtSitName.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtSitName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.TxtSitName.Location = New System.Drawing.Point(588, 18)
        Me.TxtSitName.Name = "TxtSitName"
        Me.TxtSitName.Size = New System.Drawing.Size(0, 12)
        Me.TxtSitName.TabIndex = 102
        '
        'TxtPartid
        '
        Me.TxtPartid.AutoSize = True
        Me.TxtPartid.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtPartid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.TxtPartid.Location = New System.Drawing.Point(237, 18)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(0, 12)
        Me.TxtPartid.TabIndex = 100
        '
        'TxtMoId
        '
        Me.TxtMoId.AutoSize = True
        Me.TxtMoId.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TxtMoId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.TxtMoId.Location = New System.Drawing.Point(71, 18)
        Me.TxtMoId.Name = "TxtMoId"
        Me.TxtMoId.Size = New System.Drawing.Size(0, 12)
        Me.TxtMoId.TabIndex = 99
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.ForeColor = System.Drawing.Color.Black
        Me.label4.Location = New System.Drawing.Point(523, 18)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(65, 12)
        Me.label4.TabIndex = 6
        Me.label4.Text = "站点名称："
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel2, Me.toolStripStatusLabel1, Me.ToolStripSeparator8, Me.ToolUsename})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 608)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(878, 23)
        Me.statusStrip1.TabIndex = 5
        Me.statusStrip1.Text = "statusStrip1"
        '
        'toolStripStatusLabel2
        '
        Me.toolStripStatusLabel2.Name = "toolStripStatusLabel2"
        Me.toolStripStatusLabel2.Size = New System.Drawing.Size(0, 18)
        '
        'toolStripStatusLabel1
        '
        Me.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.toolStripStatusLabel1.Image = CType(resources.GetObject("toolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.toolStripStatusLabel1.Name = "toolStripStatusLabel1"
        Me.toolStripStatusLabel1.Size = New System.Drawing.Size(84, 18)
        Me.toolStripStatusLabel1.Text = "扫描人员："
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStripSeparator8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
        '
        'ToolUsename
        '
        Me.ToolUsename.Name = "ToolUsename"
        Me.ToolUsename.Size = New System.Drawing.Size(44, 18)
        Me.ToolUsename.Text = ""
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.ToolScanSet, Me.toolStripSeparator2, Me.toolTestPrint, Me.toolStripSeparator4, Me.ToolLastCarton, Me.toolStripSeparator7, Me.ToolPalletCarton, Me.toolPalletSet, Me.ToolStripButton1, Me.ToolReplacePrint, Me.toolStripSeparator5, Me.toolca, Me.toolMOStatusSetting, Me.toolStripSeparator3, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, -1)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(928, 25)
        Me.toolStrip1.TabIndex = 6
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolScanSet
        '
        Me.ToolScanSet.Enabled = False
        Me.ToolScanSet.Image = CType(resources.GetObject("ToolScanSet.Image"), System.Drawing.Image)
        Me.ToolScanSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolScanSet.Name = "ToolScanSet"
        Me.ToolScanSet.Size = New System.Drawing.Size(97, 22)
        Me.ToolScanSet.Text = "扫描设置(&F1)"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolTestPrint
        '
        Me.toolTestPrint.Image = CType(resources.GetObject("toolTestPrint.Image"), System.Drawing.Image)
        Me.toolTestPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolTestPrint.Name = "toolTestPrint"
        Me.toolTestPrint.Size = New System.Drawing.Size(97, 22)
        Me.toolTestPrint.Text = "测试打印(&F2)"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolLastCarton
        '
        Me.ToolLastCarton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LastCartonSet, Me.toolLastPalletSet})
        Me.ToolLastCarton.Image = CType(resources.GetObject("ToolLastCarton.Image"), System.Drawing.Image)
        Me.ToolLastCarton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolLastCarton.Name = "ToolLastCarton"
        Me.ToolLastCarton.Size = New System.Drawing.Size(88, 22)
        Me.ToolLastCarton.Text = "尾数设置"
        '
        'LastCartonSet
        '
        Me.LastCartonSet.Image = CType(resources.GetObject("LastCartonSet.Image"), System.Drawing.Image)
        Me.LastCartonSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LastCartonSet.Name = "LastCartonSet"
        Me.LastCartonSet.Size = New System.Drawing.Size(114, 21)
        Me.LastCartonSet.Text = "外箱尾数设置(&L)"
        '
        'toolLastPalletSet
        '
        Me.toolLastPalletSet.Image = CType(resources.GetObject("toolLastPalletSet.Image"), System.Drawing.Image)
        Me.toolLastPalletSet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolLastPalletSet.Name = "toolLastPalletSet"
        Me.toolLastPalletSet.Size = New System.Drawing.Size(115, 21)
        Me.toolLastPalletSet.Text = "栈板尾数设置(&P)"
        '
        'toolStripSeparator7
        '
        Me.toolStripSeparator7.Name = "toolStripSeparator7"
        Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolPalletCarton
        '
        Me.ToolPalletCarton.Image = CType(resources.GetObject("ToolPalletCarton.Image"), System.Drawing.Image)
        Me.ToolPalletCarton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolPalletCarton.Name = "ToolPalletCarton"
        Me.ToolPalletCarton.Size = New System.Drawing.Size(121, 22)
        Me.ToolPalletCarton.Text = "栈板装箱设置(&F3)"
        '
        'toolPalletSet
        '
        Me.toolPalletSet.Name = "toolPalletSet"
        Me.toolPalletSet.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(121, 22)
        Me.ToolStripButton1.Text = "外箱替换打印(&F5)"
        '
        'ToolReplacePrint
        '
        Me.ToolReplacePrint.Image = CType(resources.GetObject("ToolReplacePrint.Image"), System.Drawing.Image)
        Me.ToolReplacePrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolReplacePrint.Name = "ToolReplacePrint"
        Me.ToolReplacePrint.Size = New System.Drawing.Size(133, 22)
        Me.ToolReplacePrint.Text = "尾箱转整箱打印(&F7)"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'toolca
        '
        Me.toolca.Image = CType(resources.GetObject("toolca.Image"), System.Drawing.Image)
        Me.toolca.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolca.Name = "toolca"
        Me.toolca.Size = New System.Drawing.Size(97, 22)
        Me.toolca.Text = "关联拆换(&F6)"
        '
        'toolMOStatusSetting
        '
        Me.toolMOStatusSetting.Image = CType(resources.GetObject("toolMOStatusSetting.Image"), System.Drawing.Image)
        Me.toolMOStatusSetting.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMOStatusSetting.Name = "toolMOStatusSetting"
        Me.toolMOStatusSetting.Size = New System.Drawing.Size(100, 22)
        Me.toolMOStatusSetting.Text = "工单状态设置"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        Me.toolStripSeparator3.Visible = False
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 21)
        Me.toolExit.Text = "退出(&X)"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "條碼序號"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 160
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "包裝箱號"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 160
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "工單編號"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 120
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "掃描人員"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "掃描時間"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'dgDataShow
        '
        Me.dgDataShow.AllowUserToAddRows = False
        Me.dgDataShow.AllowUserToDeleteRows = False
        Me.dgDataShow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDataShow.BackgroundColor = System.Drawing.Color.White
        Me.dgDataShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDataShow.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDataShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDataShow.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TextQty, Me.Remark, Me.Fstyle, Me.Userid, Me.Intime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDataShow.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgDataShow.EnableHeadersVisualStyles = False
        Me.dgDataShow.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgDataShow.Location = New System.Drawing.Point(2, 262)
        Me.dgDataShow.Name = "dgDataShow"
        Me.dgDataShow.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDataShow.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgDataShow.RowHeadersWidth = 4
        Me.dgDataShow.RowTemplate.Height = 23
        Me.dgDataShow.ScrollBarAppearance = DevComponents.DotNetBar.eScrollBarAppearance.[Default]
        Me.dgDataShow.Size = New System.Drawing.Size(874, 343)
        Me.dgDataShow.TabIndex = 131
        '
        'TextQty
        '
        Me.TextQty.HeaderText = "条码序号"
        Me.TextQty.Name = "TextQty"
        Me.TextQty.ReadOnly = True
        Me.TextQty.Width = 80
        '
        'Remark
        '
        Me.Remark.HeaderText = "包装箱号"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 120
        '
        'Fstyle
        '
        Me.Fstyle.HeaderText = "工单编号"
        Me.Fstyle.Name = "Fstyle"
        Me.Fstyle.ReadOnly = True
        Me.Fstyle.Width = 120
        '
        'Userid
        '
        Me.Userid.HeaderText = "扫描人员"
        Me.Userid.Name = "Userid"
        Me.Userid.ReadOnly = True
        '
        'Intime
        '
        Me.Intime.HeaderText = "扫描时间"
        Me.Intime.Name = "Intime"
        Me.Intime.ReadOnly = True
        '
        'FrmPackStandScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(878, 631)
        Me.Controls.Add(Me.dgDataShow)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmPackStandScan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "包装站扫描打印"
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
        CType(Me.dgDataShow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents toolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents toolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents label22 As System.Windows.Forms.Label
    Friend WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Private WithEvents LblCurrentCartonIndex As System.Windows.Forms.Label
    Private WithEvents label19 As System.Windows.Forms.Label
    Private WithEvents LabResult As System.Windows.Forms.Label
    Private WithEvents LblPalletCartonCount As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents toolTestPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolScanSet As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents ToolReplacePrint As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolca As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBarCode As ULControls.textBoxUL
    Private WithEvents LblPackQty As System.Windows.Forms.Label
    Private WithEvents LblCurrQty As System.Windows.Forms.Label
    Private WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtPartid As System.Windows.Forms.Label
    Private WithEvents TxtMoId As System.Windows.Forms.Label
    Friend WithEvents TxtLineId As System.Windows.Forms.Label
    Friend WithEvents ToolUsename As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TxtSitName As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSnStyle2 As ULControls.textBoxUL
    Friend WithEvents TxtSnStyle1 As ULControls.textBoxUL
    Private WithEvents ToolLastCarton As System.Windows.Forms.ToolStripSplitButton
    Private WithEvents toolLastPalletSet As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolPalletCarton As System.Windows.Forms.ToolStripButton
    Private WithEvents toolPalletSet As System.Windows.Forms.ToolStripSeparator
    Private WithEvents LastCartonSet As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents LblMoQty As System.Windows.Forms.Label
    Friend WithEvents LblType As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents LblMoProduceQty As System.Windows.Forms.Label
    Private WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgDataShow As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TextQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fstyle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Intime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblPalletNo As ULControls.textBoxUL
    Friend WithEvents TxtCartonNo As ULControls.textBoxUL
    Friend WithEvents toolMOStatusSetting As System.Windows.Forms.ToolStripButton
End Class
