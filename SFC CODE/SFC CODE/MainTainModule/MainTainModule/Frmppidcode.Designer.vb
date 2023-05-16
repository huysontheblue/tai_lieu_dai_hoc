<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmppidcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmppidcode))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolExit = New System.Windows.Forms.ToolStripButton()
        Me.dgvPackingData = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtMoid = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCartonid = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.chkPrintNoScan = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtppid = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Checkscan = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtDeReason = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.toolStrip1.SuspendLayout()
        CType(Me.dgvPackingData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStrip1
        '
        Me.toolStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolStrip1.AutoSize = False
        Me.toolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.toolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolQuery, Me.ToolDelete, Me.ToolStripSeparator2, Me.toolExit})
        Me.toolStrip1.Location = New System.Drawing.Point(9, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1033, 25)
        Me.toolStrip1.TabIndex = 131
        Me.toolStrip1.Text = "toolStrip1"
        '
        'toolQuery
        '
        Me.toolQuery.Image = CType(resources.GetObject("toolQuery.Image"), System.Drawing.Image)
        Me.toolQuery.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.toolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolQuery.Name = "toolQuery"
        Me.toolQuery.Size = New System.Drawing.Size(76, 22)
        Me.toolQuery.Text = "查  询(&F)"
        '
        'ToolDelete
        '
        Me.ToolDelete.ForeColor = System.Drawing.Color.Black
        Me.ToolDelete.Image = CType(resources.GetObject("ToolDelete.Image"), System.Drawing.Image)
        Me.ToolDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDelete.Name = "ToolDelete"
        Me.ToolDelete.Size = New System.Drawing.Size(73, 22)
        Me.ToolDelete.Tag = "NO"
        Me.ToolDelete.Text = "删 除(&D)"
        Me.ToolDelete.ToolTipText = "删除"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolExit
        '
        Me.toolExit.Image = CType(resources.GetObject("toolExit.Image"), System.Drawing.Image)
        Me.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExit.Name = "toolExit"
        Me.toolExit.Size = New System.Drawing.Size(72, 22)
        Me.toolExit.Text = "退 出(&X)"
        '
        'dgvPackingData
        '
        Me.dgvPackingData.AllowUserToAddRows = False
        Me.dgvPackingData.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvPackingData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPackingData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPackingData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvPackingData.BackgroundColor = System.Drawing.Color.White
        Me.dgvPackingData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPackingData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPackingData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPackingData.ColumnHeadersHeight = 24
        Me.dgvPackingData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column5, Me.Column1, Me.Column3, Me.Column4})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPackingData.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvPackingData.GridColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.dgvPackingData.Location = New System.Drawing.Point(0, 122)
        Me.dgvPackingData.MultiSelect = False
        Me.dgvPackingData.Name = "dgvPackingData"
        Me.dgvPackingData.ReadOnly = True
        Me.dgvPackingData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPackingData.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPackingData.RowHeadersWidth = 4
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White
        Me.dgvPackingData.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvPackingData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgvPackingData.RowTemplate.Height = 24
        Me.dgvPackingData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPackingData.ShowEditingIcon = False
        Me.dgvPackingData.Size = New System.Drawing.Size(1044, 311)
        Me.dgvPackingData.TabIndex = 132
        Me.dgvPackingData.TabStop = False
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "sbarcode"
        Me.Column2.HeaderText = "产品条码"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "cartonid"
        Me.Column5.HeaderText = "箱号"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 56
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "moid"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column1.HeaderText = "工单编号"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.Width = 80
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "stationid"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column3.HeaderText = "最后扫描站id"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 102
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "stationname"
        Me.Column4.HeaderText = "最后扫描站"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 92
        '
        'txtMoid
        '
        '
        '
        '
        Me.txtMoid.Border.Class = "TextBoxBorder"
        Me.txtMoid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMoid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMoid.Location = New System.Drawing.Point(66, 48)
        Me.txtMoid.Name = "txtMoid"
        Me.txtMoid.Size = New System.Drawing.Size(155, 21)
        Me.txtMoid.TabIndex = 145
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 146
        Me.Label1.Text = "工单号："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "箱号："
        '
        'txtCartonid
        '
        '
        '
        '
        Me.txtCartonid.Border.Class = "TextBoxBorder"
        Me.txtCartonid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCartonid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCartonid.Location = New System.Drawing.Point(66, 84)
        Me.txtCartonid.Name = "txtCartonid"
        Me.txtCartonid.Size = New System.Drawing.Size(226, 21)
        Me.txtCartonid.TabIndex = 150
        '
        'chkPrintNoScan
        '
        Me.chkPrintNoScan.AutoSize = True
        Me.chkPrintNoScan.Location = New System.Drawing.Point(617, 67)
        Me.chkPrintNoScan.Name = "chkPrintNoScan"
        Me.chkPrintNoScan.Size = New System.Drawing.Size(84, 16)
        Me.chkPrintNoScan.TabIndex = 151
        Me.chkPrintNoScan.Text = "打印未扫描"
        Me.chkPrintNoScan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(309, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 153
        Me.Label2.Text = "产品条码："
        '
        'txtppid
        '
        '
        '
        '
        Me.txtppid.Border.Class = "TextBoxBorder"
        Me.txtppid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtppid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtppid.Location = New System.Drawing.Point(367, 48)
        Me.txtppid.Name = "txtppid"
        Me.txtppid.Size = New System.Drawing.Size(226, 21)
        Me.txtppid.TabIndex = 154
        '
        'Checkscan
        '
        Me.Checkscan.AutoSize = True
        Me.Checkscan.Location = New System.Drawing.Point(725, 67)
        Me.Checkscan.Name = "Checkscan"
        Me.Checkscan.Size = New System.Drawing.Size(84, 16)
        Me.Checkscan.TabIndex = 155
        Me.Checkscan.Text = "未到包装站"
        Me.Checkscan.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 441)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1044, 22)
        Me.StatusStrip1.TabIndex = 156
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel3.Text = "记录笔数："
        '
        'ToolCount
        '
        Me.ToolCount.BackColor = System.Drawing.SystemColors.Control
        Me.ToolCount.Name = "ToolCount"
        Me.ToolCount.Size = New System.Drawing.Size(15, 17)
        Me.ToolCount.Text = "0"
        '
        'txtDeReason
        '
        Me.txtDeReason.Location = New System.Drawing.Point(366, 78)
        Me.txtDeReason.Multiline = True
        Me.txtDeReason.Name = "txtDeReason"
        Me.txtDeReason.Size = New System.Drawing.Size(227, 36)
        Me.txtDeReason.TabIndex = 158
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(309, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 157
        Me.Label8.Text = "删除原因："
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(627, 93)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 12)
        Me.lblMessage.TabIndex = 159
        '
        'Frmppidcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 463)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.txtDeReason)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvPackingData)
        Me.Controls.Add(Me.Checkscan)
        Me.Controls.Add(Me.txtppid)
        Me.Controls.Add(Me.chkPrintNoScan)
        Me.Controls.Add(Me.txtCartonid)
        Me.Controls.Add(Me.txtMoid)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Frmppidcode"
        Me.Text = "条码遗失查询"
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        CType(Me.dgvPackingData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents toolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvPackingData As System.Windows.Forms.DataGridView

    Friend WithEvents txtMoid As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCartonid As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents chkPrintNoScan As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtppid As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Checkscan As System.Windows.Forms.CheckBox
    Friend WithEvents ToolDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtDeReason As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
End Class
