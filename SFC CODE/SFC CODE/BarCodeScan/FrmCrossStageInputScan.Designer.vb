<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrossStageInputScan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCrossStageInputScan))
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolScanSet = New System.Windows.Forms.ToolStripButton()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtLineId = New System.Windows.Forms.Label()
        Me.TxtSitName = New System.Windows.Forms.Label()
        Me.TxtPartid = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.TxtMoId = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblMainBarCode = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chbMessage = New System.Windows.Forms.CheckBox()
        Me.LblScanQty = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtBarCode = New ULControls.textBoxUL()
        Me.LblBarName = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblMessage = New System.Windows.Forms.TextBox()
        Me.LabResult = New System.Windows.Forms.Label()
        Me.DGridBarCode = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolStrip1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolScanSet, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(774, 25)
        Me.toolStrip1.TabIndex = 8
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
        'groupBox1
        '
        Me.groupBox1.BackColor = System.Drawing.Color.White
        Me.groupBox1.Controls.Add(Me.TxtLineId)
        Me.groupBox1.Controls.Add(Me.TxtSitName)
        Me.groupBox1.Controls.Add(Me.TxtPartid)
        Me.groupBox1.Controls.Add(Me.label22)
        Me.groupBox1.Controls.Add(Me.TxtMoId)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.groupBox1.Location = New System.Drawing.Point(0, 25)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(774, 42)
        Me.groupBox1.TabIndex = 92
        Me.groupBox1.TabStop = False
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
        Me.label4.Location = New System.Drawing.Point(523, 16)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(65, 12)
        Me.label4.TabIndex = 6
        Me.label4.Text = "站点名称："
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.ForeColor = System.Drawing.Color.Black
        Me.label2.Location = New System.Drawing.Point(173, 16)
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
        'groupBox2
        '
        Me.groupBox2.BackColor = System.Drawing.Color.White
        Me.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.groupBox2.Controls.Add(Me.LblMainBarCode)
        Me.groupBox2.Controls.Add(Me.Label13)
        Me.groupBox2.Controls.Add(Me.chbMessage)
        Me.groupBox2.Controls.Add(Me.LblScanQty)
        Me.groupBox2.Controls.Add(Me.Label8)
        Me.groupBox2.Controls.Add(Me.TxtBarCode)
        Me.groupBox2.Controls.Add(Me.LblBarName)
        Me.groupBox2.Controls.Add(Me.groupBox3)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.groupBox2.Location = New System.Drawing.Point(0, 67)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(774, 129)
        Me.groupBox2.TabIndex = 93
        Me.groupBox2.TabStop = False
        '
        'LblMainBarCode
        '
        Me.LblMainBarCode.AutoSize = True
        Me.LblMainBarCode.Location = New System.Drawing.Point(12, 58)
        Me.LblMainBarCode.Name = "LblMainBarCode"
        Me.LblMainBarCode.Size = New System.Drawing.Size(0, 12)
        Me.LblMainBarCode.TabIndex = 116
        Me.LblMainBarCode.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("宋体", 11.0!)
        Me.Label13.Location = New System.Drawing.Point(302, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 15)
        Me.Label13.TabIndex = 115
        Me.Label13.Text = "提示声音"
        '
        'chbMessage
        '
        Me.chbMessage.AutoSize = True
        Me.chbMessage.Location = New System.Drawing.Point(281, 71)
        Me.chbMessage.Name = "chbMessage"
        Me.chbMessage.Size = New System.Drawing.Size(15, 14)
        Me.chbMessage.TabIndex = 114
        Me.chbMessage.UseVisualStyleBackColor = True
        '
        'LblScanQty
        '
        Me.LblScanQty.AutoSize = True
        Me.LblScanQty.BackColor = System.Drawing.Color.White
        Me.LblScanQty.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblScanQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblScanQty.Location = New System.Drawing.Point(83, 73)
        Me.LblScanQty.Name = "LblScanQty"
        Me.LblScanQty.Size = New System.Drawing.Size(21, 22)
        Me.LblScanQty.TabIndex = 101
        Me.LblScanQty.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(12, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "已扫数量："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtBarCode
        '
        Me.TxtBarCode.BackColor = System.Drawing.Color.White
        Me.TxtBarCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBarCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtBarCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtBarCode.HotColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtBarCode.Location = New System.Drawing.Point(126, 32)
        Me.TxtBarCode.Name = "TxtBarCode"
        Me.TxtBarCode.Size = New System.Drawing.Size(243, 14)
        Me.TxtBarCode.TabIndex = 90
        '
        'LblBarName
        '
        Me.LblBarName.AutoSize = True
        Me.LblBarName.BackColor = System.Drawing.Color.White
        Me.LblBarName.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBarName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblBarName.Location = New System.Drawing.Point(6, 28)
        Me.LblBarName.Name = "LblBarName"
        Me.LblBarName.Size = New System.Drawing.Size(114, 18)
        Me.LblBarName.TabIndex = 71
        Me.LblBarName.Text = "产品条码序号:"
        Me.LblBarName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.BackColor = System.Drawing.Color.White
        Me.groupBox3.Controls.Add(Me.lblMessage)
        Me.groupBox3.Controls.Add(Me.LabResult)
        Me.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(395, 12)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(367, 105)
        Me.groupBox3.TabIndex = 93
        Me.groupBox3.TabStop = False
        '
        'lblMessage
        '
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMessage.Location = New System.Drawing.Point(3, 34)
        Me.lblMessage.Multiline = True
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(361, 68)
        Me.lblMessage.TabIndex = 87
        Me.lblMessage.TabStop = False
        Me.lblMessage.Text = "PASS"
        '
        'LabResult
        '
        Me.LabResult.AutoSize = True
        Me.LabResult.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabResult.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabResult.Location = New System.Drawing.Point(7, 15)
        Me.LabResult.Name = "LabResult"
        Me.LabResult.Size = New System.Drawing.Size(257, 19)
        Me.LabResult.TabIndex = 82
        Me.LabResult.Text = "CN0XX5807244997E000A000026"
        Me.LabResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.DGridBarCode.Location = New System.Drawing.Point(0, 196)
        Me.DGridBarCode.Name = "DGridBarCode"
        Me.DGridBarCode.ReadOnly = True
        Me.DGridBarCode.RowHeadersWidth = 4
        Me.DGridBarCode.RowTemplate.Height = 23
        Me.DGridBarCode.Size = New System.Drawing.Size(774, 249)
        Me.DGridBarCode.TabIndex = 133
        '
        'Column1
        '
        Me.Column1.HeaderText = "成品料号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 120
        '
        'Column2
        '
        Me.Column2.HeaderText = "站点项次序号"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "条码序号"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 240
        '
        'Column4
        '
        Me.Column4.HeaderText = "站点名称"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 120
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
        'FrmCrossStageInputScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 445)
        Me.Controls.Add(Me.DGridBarCode)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.toolStrip1)
        Me.Name = "FrmCrossStageInputScan"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        CType(Me.DGridBarCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolScanSet As System.Windows.Forms.ToolStripButton
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
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBarCode As ULControls.textBoxUL
    Friend WithEvents LblBarName As System.Windows.Forms.Label
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMessage As System.Windows.Forms.TextBox
    Private WithEvents LabResult As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblScanQty As System.Windows.Forms.Label
    Friend WithEvents DGridBarCode As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chbMessage As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblMainBarCode As System.Windows.Forms.Label
End Class
