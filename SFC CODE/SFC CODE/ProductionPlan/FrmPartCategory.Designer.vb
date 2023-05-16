<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPartCategory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPartCategory))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImport = New System.Windows.Forms.ToolStripButton()
        Me.toolExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.DgPartContrast = New System.Windows.Forms.DataGridView()
        Me.tavcpart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pavcpart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PartSeriesTypeCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.intime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtPAvcPart = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lkFile = New System.Windows.Forms.LinkLabel()
        Me.ToolBt.SuspendLayout()
        CType(Me.DgPartContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ToolQuery, Me.ToolStripSeparator2, Me.ToolCommit, Me.ToolStripSeparator4, Me.toolImport, Me.toolExport, Me.ToolStripSeparator1, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1132, 25)
        Me.ToolBt.TabIndex = 233
        Me.ToolBt.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolQuery
        '
        Me.ToolQuery.ForeColor = System.Drawing.Color.Black
        Me.ToolQuery.Image = CType(resources.GetObject("ToolQuery.Image"), System.Drawing.Image)
        Me.ToolQuery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolQuery.Name = "ToolQuery"
        Me.ToolQuery.Size = New System.Drawing.Size(74, 22)
        Me.ToolQuery.Text = "查 询(&Q)"
        Me.ToolQuery.ToolTipText = "查 詢"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolCommit
        '
        Me.ToolCommit.Image = CType(resources.GetObject("ToolCommit.Image"), System.Drawing.Image)
        Me.ToolCommit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCommit.Name = "ToolCommit"
        Me.ToolCommit.Size = New System.Drawing.Size(67, 22)
        Me.ToolCommit.Tag = ""
        Me.ToolCommit.Text = "保存(&S)"
        Me.ToolCommit.ToolTipText = "提交"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolImport
        '
        Me.toolImport.Image = CType(resources.GetObject("toolImport.Image"), System.Drawing.Image)
        Me.toolImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImport.Name = "toolImport"
        Me.toolImport.Size = New System.Drawing.Size(64, 22)
        Me.toolImport.Text = "汇   入"
        '
        'toolExport
        '
        Me.toolExport.Image = CType(resources.GetObject("toolExport.Image"), System.Drawing.Image)
        Me.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolExport.Name = "toolExport"
        Me.toolExport.Size = New System.Drawing.Size(64, 22)
        Me.toolExport.Text = "汇   出"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolExitFrom
        '
        Me.ToolExitFrom.ForeColor = System.Drawing.Color.Black
        Me.ToolExitFrom.Image = CType(resources.GetObject("ToolExitFrom.Image"), System.Drawing.Image)
        Me.ToolExitFrom.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExitFrom.Name = "ToolExitFrom"
        Me.ToolExitFrom.Size = New System.Drawing.Size(72, 22)
        Me.ToolExitFrom.Text = "退 出(&X)"
        Me.ToolExitFrom.ToolTipText = "退 出"
        '
        'DgPartContrast
        '
        Me.DgPartContrast.AllowUserToAddRows = False
        Me.DgPartContrast.AllowUserToDeleteRows = False
        Me.DgPartContrast.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.DgPartContrast.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgPartContrast.BackgroundColor = System.Drawing.Color.White
        Me.DgPartContrast.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgPartContrast.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DgPartContrast.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgPartContrast.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DgPartContrast.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tavcpart, Me.pavcpart, Me.PartSeriesTypeCode, Me.Column1, Me.Column2, Me.Usey, Me.userid, Me.intime})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(153, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgPartContrast.DefaultCellStyle = DataGridViewCellStyle3
        Me.DgPartContrast.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgPartContrast.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DgPartContrast.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.DgPartContrast.Location = New System.Drawing.Point(0, 0)
        Me.DgPartContrast.MultiSelect = False
        Me.DgPartContrast.Name = "DgPartContrast"
        Me.DgPartContrast.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgPartContrast.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DgPartContrast.RowHeadersWidth = 4
        Me.DgPartContrast.RowTemplate.Height = 24
        Me.DgPartContrast.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DgPartContrast.ShowEditingIcon = False
        Me.DgPartContrast.Size = New System.Drawing.Size(1132, 396)
        Me.DgPartContrast.TabIndex = 236
        Me.DgPartContrast.TabStop = False
        '
        'tavcpart
        '
        Me.tavcpart.DataPropertyName = "tavcpart"
        Me.tavcpart.HeaderText = "料件编号"
        Me.tavcpart.Name = "tavcpart"
        Me.tavcpart.ReadOnly = True
        '
        'pavcpart
        '
        Me.pavcpart.DataPropertyName = "pavcpart"
        Me.pavcpart.HeaderText = "父料件编号"
        Me.pavcpart.Name = "pavcpart"
        Me.pavcpart.ReadOnly = True
        '
        'PartSeriesTypeCode
        '
        Me.PartSeriesTypeCode.DataPropertyName = "PartSeriesTypeCode"
        Me.PartSeriesTypeCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.PartSeriesTypeCode.HeaderText = "料件类别名称"
        Me.PartSeriesTypeCode.Name = "PartSeriesTypeCode"
        Me.PartSeriesTypeCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PartSeriesTypeCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "quantity"
        Me.Column1.HeaderText = "配置比率"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "DESCRIPTION"
        Me.Column2.HeaderText = "规格"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Usey
        '
        Me.Usey.DataPropertyName = "Usey"
        Me.Usey.HeaderText = "可用否"
        Me.Usey.Name = "Usey"
        Me.Usey.ReadOnly = True
        '
        'userid
        '
        Me.userid.DataPropertyName = "userid"
        Me.userid.HeaderText = "更新用户"
        Me.userid.Name = "userid"
        Me.userid.ReadOnly = True
        '
        'intime
        '
        Me.intime.DataPropertyName = "intime"
        Me.intime.HeaderText = "更新时间"
        Me.intime.Name = "intime"
        Me.intime.ReadOnly = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPAvcPart)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1MinSize = 40
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgPartContrast)
        Me.SplitContainer1.Size = New System.Drawing.Size(1132, 440)
        Me.SplitContainer1.SplitterDistance = 40
        Me.SplitContainer1.TabIndex = 237
        '
        'txtPAvcPart
        '
        Me.txtPAvcPart.Location = New System.Drawing.Point(129, 12)
        Me.txtPAvcPart.Name = "txtPAvcPart"
        Me.txtPAvcPart.Size = New System.Drawing.Size(100, 21)
        Me.txtPAvcPart.TabIndex = 237
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 12)
        Me.Label2.TabIndex = 236
        Me.Label2.Text = "父料件编号:"
        '
        'lkFile
        '
        Me.lkFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lkFile.AutoSize = True
        Me.lkFile.Location = New System.Drawing.Point(865, 31)
        Me.lkFile.Name = "lkFile"
        Me.lkFile.Size = New System.Drawing.Size(77, 12)
        Me.lkFile.TabIndex = 238
        Me.lkFile.TabStop = True
        Me.lkFile.Text = "查看导入格式"
        '
        'FrmPartCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 465)
        Me.Controls.Add(Me.lkFile)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmPartCategory"
        Me.Text = "料号类别维护"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.DgPartContrast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents DgPartContrast As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtPAvcPart As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lkFile As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tavcpart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pavcpart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartSeriesTypeCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents intime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
