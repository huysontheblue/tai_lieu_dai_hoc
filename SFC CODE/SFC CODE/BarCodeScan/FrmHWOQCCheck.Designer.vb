<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHWOQCCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHWOQCCheck))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblNo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblPartID = New System.Windows.Forms.Label()
        Me.TxtLineId = New System.Windows.Forms.Label()
        Me.TxtSitName = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.TxtMoId = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.lblSIQty = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblScanQty = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LabResult = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.txtPackingBoxBarcode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPackingBoxCartonCode = New System.Windows.Forms.TextBox()
        Me.dgvUnPackBox = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.toolStrip1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvUnPackBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolScanSet, Me.toolExit, Me.ToolStripSeparator3})
        Me.toolStrip1.Location = New System.Drawing.Point(3, 2)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.toolStrip1.TabIndex = 141
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.BackColor = System.Drawing.Color.White
        Me.groupBox1.Controls.Add(Me.lblNo)
        Me.groupBox1.Controls.Add(Me.Label7)
        Me.groupBox1.Controls.Add(Me.lblTotal)
        Me.groupBox1.Controls.Add(Me.lblLine)
        Me.groupBox1.Controls.Add(Me.lblPartID)
        Me.groupBox1.Controls.Add(Me.TxtLineId)
        Me.groupBox1.Controls.Add(Me.TxtSitName)
        Me.groupBox1.Controls.Add(Me.TxtPartid)
        Me.groupBox1.Controls.Add(Me.label22)
        Me.groupBox1.Controls.Add(Me.TxtMoId)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.groupBox1.Location = New System.Drawing.Point(4, 29)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(1263, 37)
        Me.groupBox1.TabIndex = 142
        Me.groupBox1.TabStop = False
        '
        'lblNo
        '
        Me.lblNo.AutoSize = True
        Me.lblNo.Location = New System.Drawing.Point(616, 15)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Size = New System.Drawing.Size(0, 12)
        Me.lblNo.TabIndex = 111
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(544, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 12)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "抽检批次号："
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(403, 15)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 12)
        Me.lblTotal.TabIndex = 109
        '
        'lblLine
        '
        Me.lblLine.AutoSize = True
        Me.lblLine.Location = New System.Drawing.Point(238, 16)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(0, 12)
        Me.lblLine.TabIndex = 108
        '
        'lblPartID
        '
        Me.lblPartID.AutoSize = True
        Me.lblPartID.Location = New System.Drawing.Point(65, 16)
        Me.lblPartID.Name = "lblPartID"
        Me.lblPartID.Size = New System.Drawing.Size(0, 12)
        Me.lblPartID.TabIndex = 107
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
        Me.TxtSitName.Location = New System.Drawing.Point(586, 16)
        Me.TxtSitName.Name = "TxtSitName"
        Me.TxtSitName.Size = New System.Drawing.Size(0, 12)
        Me.TxtSitName.TabIndex = 102
        '
        'TxtPartid
        '
        Me.TxtPartid.AutoSize = True
        Me.TxtPartid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.TxtPartid.Location = New System.Drawing.Point(236, 16)
        Me.TxtPartid.Name = "TxtPartid"
        Me.TxtPartid.Size = New System.Drawing.Size(0, 12)
        Me.TxtPartid.TabIndex = 100
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.ForeColor = System.Drawing.Color.Black
        Me.label22.Location = New System.Drawing.Point(178, 16)
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
        Me.label4.Location = New System.Drawing.Point(356, 16)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(53, 12)
        Me.label4.TabIndex = 6
        Me.label4.Text = "总数量："
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(6, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 12)
        Me.label2.TabIndex = 2
        Me.label2.Text = "料件编号："
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.btnConfirm)
        Me.GroupBox2.Controls.Add(Me.lblSIQty)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblScanQty)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.txtPackingBoxBarcode)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtPackingBoxCartonCode)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1283, 198)
        Me.GroupBox2.TabIndex = 143
        Me.GroupBox2.TabStop = False
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(114, 139)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 114
        Me.btnConfirm.Text = "抽检完成"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'lblSIQty
        '
        Me.lblSIQty.AutoSize = True
        Me.lblSIQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblSIQty.ForeColor = System.Drawing.Color.Red
        Me.lblSIQty.Location = New System.Drawing.Point(85, 94)
        Me.lblSIQty.Name = "lblSIQty"
        Me.lblSIQty.Size = New System.Drawing.Size(17, 16)
        Me.lblSIQty.TabIndex = 113
        Me.lblSIQty.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 12)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = "需抽检数量："
        '
        'lblScanQty
        '
        Me.lblScanQty.AutoSize = True
        Me.lblScanQty.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblScanQty.ForeColor = System.Drawing.Color.Green
        Me.lblScanQty.Location = New System.Drawing.Point(242, 96)
        Me.lblScanQty.Name = "lblScanQty"
        Me.lblScanQty.Size = New System.Drawing.Size(17, 16)
        Me.lblScanQty.TabIndex = 111
        Me.lblScanQty.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(164, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "已抽检数量："
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.LabResult)
        Me.GroupBox3.Controls.Add(Me.lblMessage)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(444, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(839, 82)
        Me.GroupBox3.TabIndex = 109
        Me.GroupBox3.TabStop = False
        '
        'LabResult
        '
        Me.LabResult.AutoSize = True
        Me.LabResult.Font = New System.Drawing.Font("Arial", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabResult.Location = New System.Drawing.Point(6, 40)
        Me.LabResult.Name = "LabResult"
        Me.LabResult.Size = New System.Drawing.Size(106, 40)
        Me.LabResult.TabIndex = 86
        Me.LabResult.Text = "PASS"
        Me.LabResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(7, 15)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(257, 19)
        Me.lblMessage.TabIndex = 82
        Me.lblMessage.Text = "CN0XX5807244997E000A000026"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPackingBoxBarcode
        '
        Me.txtPackingBoxBarcode.Location = New System.Drawing.Point(71, 60)
        Me.txtPackingBoxBarcode.Name = "txtPackingBoxBarcode"
        Me.txtPackingBoxBarcode.Size = New System.Drawing.Size(367, 21)
        Me.txtPackingBoxBarcode.TabIndex = 108
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "产品条码："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "外箱标签："
        '
        'txtPackingBoxCartonCode
        '
        Me.txtPackingBoxCartonCode.Location = New System.Drawing.Point(71, 20)
        Me.txtPackingBoxCartonCode.Name = "txtPackingBoxCartonCode"
        Me.txtPackingBoxCartonCode.Size = New System.Drawing.Size(367, 21)
        Me.txtPackingBoxCartonCode.TabIndex = 106
        '
        'dgvUnPackBox
        '
        Me.dgvUnPackBox.AllowUserToAddRows = False
        Me.dgvUnPackBox.AllowUserToDeleteRows = False
        Me.dgvUnPackBox.BackgroundColor = System.Drawing.Color.White
        Me.dgvUnPackBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvUnPackBox.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvUnPackBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUnPackBox.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.Column1, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.dgvUnPackBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUnPackBox.Location = New System.Drawing.Point(3, 17)
        Me.dgvUnPackBox.Name = "dgvUnPackBox"
        Me.dgvUnPackBox.ReadOnly = True
        Me.dgvUnPackBox.RowHeadersWidth = 4
        Me.dgvUnPackBox.RowTemplate.Height = 23
        Me.dgvUnPackBox.Size = New System.Drawing.Size(1277, 244)
        Me.dgvUnPackBox.TabIndex = 136
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "外箱条码"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 250
        '
        'Column1
        '
        Me.Column1.HeaderText = "产品条码"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 200
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "扫描人员"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "扫描时间"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 200
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox4.Controls.Add(Me.dgvUnPackBox)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 273)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1283, 264)
        Me.GroupBox4.TabIndex = 144
        Me.GroupBox4.TabStop = False
        '
        'FrmHWOQCCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 549)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmHWOQCCheck"
        Me.Text = "华为OQC检验"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvUnPackBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtLineId As System.Windows.Forms.Label
    Friend WithEvents TxtSitName As System.Windows.Forms.Label
    Friend WithEvents TxtPartid As System.Windows.Forms.Label
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents TxtMoId As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblPartID As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents LabResult As System.Windows.Forms.Label
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtPackingBoxBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPackingBoxCartonCode As System.Windows.Forms.TextBox
    Friend WithEvents lblNo As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblSIQty As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblScanQty As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents dgvUnPackBox As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
End Class
