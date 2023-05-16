<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFixedCodeScan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFixedCodeScan))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbLineId = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbPartNo = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbMoid = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Number = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBoxUL1 = New TextBoxUL.TextBoxUL()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBarcode = New TextBoxUL.TextBoxUL()
        Me.boxqty = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Boxpretend = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtStyle = New TextBoxUL.TextBoxUL()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbMoQty = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.labScanAcount = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbMsg = New System.Windows.Forms.Label()
        Me.lbBarcode = New System.Windows.Forms.Label()
        Me.txtScanFour = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtScanTree = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtScanTwo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtScanOne = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DGridBarCode = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.toolStrip1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtScanFour)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtScanTree)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtScanTwo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtScanOne)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1313, 286)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lbLineId)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.lbPartNo)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.lbMoid)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1313, 32)
        Me.Panel3.TabIndex = 9
        '
        'lbLineId
        '
        Me.lbLineId.AutoSize = True
        Me.lbLineId.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbLineId.Location = New System.Drawing.Point(559, 11)
        Me.lbLineId.Name = "lbLineId"
        Me.lbLineId.Size = New System.Drawing.Size(0, 12)
        Me.lbLineId.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(518, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 12)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "线别:"
        '
        'lbPartNo
        '
        Me.lbPartNo.AutoSize = True
        Me.lbPartNo.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbPartNo.Location = New System.Drawing.Point(331, 11)
        Me.lbPartNo.Name = "lbPartNo"
        Me.lbPartNo.Size = New System.Drawing.Size(0, 12)
        Me.lbPartNo.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(266, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 12)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "料件编号:"
        '
        'lbMoid
        '
        Me.lbMoid.AutoSize = True
        Me.lbMoid.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbMoid.Location = New System.Drawing.Point(75, 10)
        Me.lbMoid.Name = "lbMoid"
        Me.lbMoid.Size = New System.Drawing.Size(0, 12)
        Me.lbMoid.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "工单编号:"
        '
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolScanSet, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1313, 25)
        Me.toolStrip1.TabIndex = 10
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
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(68, 22)
        Me.toolExit.Text = "退出(&X)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Number)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TextBoxUL1)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtBarcode)
        Me.GroupBox1.Controls.Add(Me.boxqty)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Boxpretend)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtStyle)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbMoQty)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.labScanAcount)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lbBarcode)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(929, 216)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Number
        '
        Me.Number.AutoSize = True
        Me.Number.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Number.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Number.Location = New System.Drawing.Point(807, 112)
        Me.Number.Name = "Number"
        Me.Number.Size = New System.Drawing.Size(22, 22)
        Me.Number.TabIndex = 213
        Me.Number.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(744, 117)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 12)
        Me.Label13.TabIndex = 212
        Me.Label13.Text = "已装箱数："
        '
        'TextBoxUL1
        '
        Me.TextBoxUL1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxUL1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBoxUL1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxUL1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxUL1.Enabled = False
        Me.TextBoxUL1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TextBoxUL1.Location = New System.Drawing.Point(89, 29)
        Me.TextBoxUL1.Name = "TextBoxUL1"
        Me.TextBoxUL1.ReadOnly = True
        Me.TextBoxUL1.Size = New System.Drawing.Size(264, 19)
        Me.TextBoxUL1.TabIndex = 211
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 12)
        Me.Label15.TabIndex = 210
        Me.Label15.Text = "样式:"
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.SystemColors.Control
        Me.txtBarcode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBarcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarcode.Enabled = False
        Me.txtBarcode.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(89, 70)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.ReadOnly = True
        Me.txtBarcode.Size = New System.Drawing.Size(264, 19)
        Me.txtBarcode.TabIndex = 209
        '
        'boxqty
        '
        Me.boxqty.AutoSize = True
        Me.boxqty.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.boxqty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.boxqty.Location = New System.Drawing.Point(626, 111)
        Me.boxqty.Name = "boxqty"
        Me.boxqty.Size = New System.Drawing.Size(22, 22)
        Me.boxqty.TabIndex = 208
        Me.boxqty.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(563, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 207
        Me.Label14.Text = "应装数："
        '
        'Boxpretend
        '
        Me.Boxpretend.AutoSize = True
        Me.Boxpretend.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Boxpretend.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Boxpretend.Location = New System.Drawing.Point(446, 110)
        Me.Boxpretend.Name = "Boxpretend"
        Me.Boxpretend.Size = New System.Drawing.Size(22, 22)
        Me.Boxpretend.TabIndex = 206
        Me.Boxpretend.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(387, 115)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 12)
        Me.Label12.TabIndex = 205
        Me.Label12.Text = "已装数："
        '
        'txtStyle
        '
        Me.txtStyle.BackColor = System.Drawing.SystemColors.Control
        Me.txtStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtStyle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStyle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtStyle.Enabled = False
        Me.txtStyle.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtStyle.Location = New System.Drawing.Point(89, 111)
        Me.txtStyle.Name = "txtStyle"
        Me.txtStyle.ReadOnly = True
        Me.txtStyle.Size = New System.Drawing.Size(264, 19)
        Me.txtStyle.TabIndex = 203
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 204
        Me.Label6.Text = "箱号:"
        '
        'lbMoQty
        '
        Me.lbMoQty.AutoSize = True
        Me.lbMoQty.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbMoQty.Location = New System.Drawing.Point(626, 66)
        Me.lbMoQty.Name = "lbMoQty"
        Me.lbMoQty.Size = New System.Drawing.Size(20, 20)
        Me.lbMoQty.TabIndex = 7
        Me.lbMoQty.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(561, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 12)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "应扫描数:"
        '
        'labScanAcount
        '
        Me.labScanAcount.AutoSize = True
        Me.labScanAcount.Font = New System.Drawing.Font("宋体", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.labScanAcount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labScanAcount.Location = New System.Drawing.Point(446, 65)
        Me.labScanAcount.Name = "labScanAcount"
        Me.labScanAcount.Size = New System.Drawing.Size(22, 22)
        Me.labScanAcount.TabIndex = 6
        Me.labScanAcount.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(387, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 12)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "扫描数："
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbMsg)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 143)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(656, 60)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'lbMsg
        '
        Me.lbMsg.AutoSize = True
        Me.lbMsg.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbMsg.Location = New System.Drawing.Point(7, 22)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(93, 20)
        Me.lbMsg.TabIndex = 0
        Me.lbMsg.Text = "请先配置"
        '
        'lbBarcode
        '
        Me.lbBarcode.AutoSize = True
        Me.lbBarcode.Location = New System.Drawing.Point(12, 74)
        Me.lbBarcode.Name = "lbBarcode"
        Me.lbBarcode.Size = New System.Drawing.Size(59, 12)
        Me.lbBarcode.TabIndex = 2
        Me.lbBarcode.Text = "产品条码:"
        '
        'txtScanFour
        '
        Me.txtScanFour.Enabled = False
        Me.txtScanFour.Location = New System.Drawing.Point(1030, 179)
        Me.txtScanFour.Name = "txtScanFour"
        Me.txtScanFour.Size = New System.Drawing.Size(145, 21)
        Me.txtScanFour.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(953, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "固定条码四:"
        '
        'txtScanTree
        '
        Me.txtScanTree.Enabled = False
        Me.txtScanTree.Location = New System.Drawing.Point(1030, 144)
        Me.txtScanTree.Name = "txtScanTree"
        Me.txtScanTree.Size = New System.Drawing.Size(145, 21)
        Me.txtScanTree.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(953, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "固定条码三:"
        '
        'txtScanTwo
        '
        Me.txtScanTwo.Enabled = False
        Me.txtScanTwo.Location = New System.Drawing.Point(1030, 107)
        Me.txtScanTwo.Name = "txtScanTwo"
        Me.txtScanTwo.Size = New System.Drawing.Size(145, 21)
        Me.txtScanTwo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(953, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "固定条码二:"
        '
        'txtScanOne
        '
        Me.txtScanOne.Enabled = False
        Me.txtScanOne.Location = New System.Drawing.Point(1030, 72)
        Me.txtScanOne.Name = "txtScanOne"
        Me.txtScanOne.Size = New System.Drawing.Size(145, 21)
        Me.txtScanOne.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(953, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "固定条码一:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DGridBarCode)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 286)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1313, 201)
        Me.Panel2.TabIndex = 1
        '
        'DGridBarCode
        '
        Me.DGridBarCode.AllowUserToAddRows = False
        Me.DGridBarCode.AllowUserToDeleteRows = False
        Me.DGridBarCode.BackgroundColor = System.Drawing.Color.White
        Me.DGridBarCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGridBarCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGridBarCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGridBarCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column5, Me.Column6})
        Me.DGridBarCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGridBarCode.Location = New System.Drawing.Point(0, 0)
        Me.DGridBarCode.Name = "DGridBarCode"
        Me.DGridBarCode.ReadOnly = True
        Me.DGridBarCode.RowHeadersWidth = 4
        Me.DGridBarCode.RowTemplate.Height = 23
        Me.DGridBarCode.Size = New System.Drawing.Size(1313, 201)
        Me.DGridBarCode.TabIndex = 133
        '
        'Column3
        '
        Me.Column3.HeaderText = "条码序号"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 240
        '
        'Column5
        '
        Me.Column5.HeaderText = "扫描人员"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 120
        '
        'Column6
        '
        Me.Column6.HeaderText = "扫描时间"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 120
        '
        'FrmFixedCodeScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1313, 487)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmFixedCodeScan"
        Me.Text = "固定码校验"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtScanFour As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtScanTree As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtScanTwo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtScanOne As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbBarcode As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbMsg As System.Windows.Forms.Label
    Friend WithEvents labScanAcount As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DGridBarCode As System.Windows.Forms.DataGridView
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbLineId As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbPartNo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbMoid As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbMoQty As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxUL1 As TextBoxUL.TextBoxUL
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As TextBoxUL.TextBoxUL
    Friend WithEvents boxqty As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Boxpretend As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtStyle As TextBoxUL.TextBoxUL
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Number As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
