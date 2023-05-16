<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAssemblySetting
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAssemblySetting))
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtPartId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtMOId = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.chbListSelect = New System.Windows.Forms.CheckBox()
        Me.dgvBomList = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ChkSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParentPartId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChKisUpload = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ChkAssemble = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ChkIsLot = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ChkTransData = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ChkMaterialCheck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ChkAlter = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ChkExtensible = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolCommit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.dgvBomList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBt.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(7, 49)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 23)
        Me.LabelX1.TabIndex = 133
        Me.LabelX1.Text = "产品料号:"
        '
        'txtPartId
        '
        '
        '
        '
        Me.txtPartId.Border.Class = "TextBoxBorder"
        Me.txtPartId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPartId.Location = New System.Drawing.Point(69, 49)
        Me.txtPartId.Name = "txtPartId"
        Me.txtPartId.Size = New System.Drawing.Size(152, 21)
        Me.txtPartId.TabIndex = 134
        '
        'txtMOId
        '
        '
        '
        '
        Me.txtMOId.Border.Class = "TextBoxBorder"
        Me.txtMOId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMOId.Location = New System.Drawing.Point(69, 82)
        Me.txtMOId.Name = "txtMOId"
        Me.txtMOId.Size = New System.Drawing.Size(152, 21)
        Me.txtMOId.TabIndex = 136
        Me.txtMOId.Visible = False
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(5, 78)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(52, 23)
        Me.LabelX2.TabIndex = 135
        Me.LabelX2.Text = "工单:"
        Me.LabelX2.Visible = False
        '
        'chbListSelect
        '
        Me.chbListSelect.AutoSize = True
        Me.chbListSelect.Location = New System.Drawing.Point(52, 7)
        Me.chbListSelect.Name = "chbListSelect"
        Me.chbListSelect.Size = New System.Drawing.Size(15, 14)
        Me.chbListSelect.TabIndex = 138
        Me.chbListSelect.UseVisualStyleBackColor = True
        '
        'dgvBomList
        '
        Me.dgvBomList.AllowUserToAddRows = False
        Me.dgvBomList.AllowUserToDeleteRows = False
        Me.dgvBomList.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvBomList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBomList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBomList.ColumnHeadersHeight = 25
        Me.dgvBomList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ChkSelect, Me.PartId, Me.ParentPartId, Me.Description, Me.DESCRIPTION2, Me.Usey, Me.ChKisUpload, Me.ChkAssemble, Me.ChkIsLot, Me.ChkTransData, Me.ChkMaterialCheck, Me.ChkAlter, Me.ChkExtensible})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBomList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBomList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBomList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvBomList.EnableHeadersVisualStyles = False
        Me.dgvBomList.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dgvBomList.Location = New System.Drawing.Point(0, 0)
        Me.dgvBomList.MultiSelect = False
        Me.dgvBomList.Name = "dgvBomList"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBomList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBomList.RowHeadersWidth = 20
        Me.dgvBomList.RowTemplate.Height = 23
        Me.dgvBomList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvBomList.Size = New System.Drawing.Size(1185, 366)
        Me.dgvBomList.TabIndex = 137
        '
        'ChkSelect
        '
        Me.ChkSelect.HeaderText = "选择"
        Me.ChkSelect.Name = "ChkSelect"
        Me.ChkSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkSelect.Width = 50
        '
        'PartId
        '
        Me.PartId.HeaderText = "料件编号"
        Me.PartId.Name = "PartId"
        Me.PartId.ReadOnly = True
        Me.PartId.Width = 90
        '
        'ParentPartId
        '
        Me.ParentPartId.HeaderText = "父料件号"
        Me.ParentPartId.Name = "ParentPartId"
        Me.ParentPartId.ReadOnly = True
        Me.ParentPartId.Width = 90
        '
        'Description
        '
        Me.Description.HeaderText = "物料描述"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 200
        '
        'DESCRIPTION2
        '
        Me.DESCRIPTION2.HeaderText = "规格"
        Me.DESCRIPTION2.Name = "DESCRIPTION2"
        Me.DESCRIPTION2.Width = 150
        '
        'Usey
        '
        Me.Usey.HeaderText = "状态"
        Me.Usey.Name = "Usey"
        Me.Usey.ReadOnly = True
        Me.Usey.Width = 50
        '
        'ChKisUpload
        '
        Me.ChKisUpload.HeaderText = "是否上传Panda"
        Me.ChKisUpload.Name = "ChKisUpload"
        Me.ChKisUpload.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChKisUpload.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ChKisUpload.Width = 90
        '
        'ChkAssemble
        '
        Me.ChkAssemble.FillWeight = 80.0!
        Me.ChkAssemble.HeaderText = "扫描组装部件"
        Me.ChkAssemble.Name = "ChkAssemble"
        Me.ChkAssemble.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkAssemble.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ChkAssemble.Width = 90
        '
        'ChkIsLot
        '
        Me.ChkIsLot.HeaderText = "扫描部件批次"
        Me.ChkIsLot.Name = "ChkIsLot"
        Me.ChkIsLot.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkIsLot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ChkIsLot.Width = 90
        '
        'ChkTransData
        '
        Me.ChkTransData.HeaderText = "是否抛转资料"
        Me.ChkTransData.Name = "ChkTransData"
        Me.ChkTransData.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkTransData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ChkTransData.Width = 90
        '
        'ChkMaterialCheck
        '
        Me.ChkMaterialCheck.HeaderText = "原材料盘点预警"
        Me.ChkMaterialCheck.Name = "ChkMaterialCheck"
        Me.ChkMaterialCheck.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkMaterialCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ChkAlter
        '
        Me.ChkAlter.HeaderText = "是否物料转移预警"
        Me.ChkAlter.Name = "ChkAlter"
        Me.ChkAlter.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkAlter.Width = 120
        '
        'ChkExtensible
        '
        Me.ChkExtensible.HeaderText = "可扩展否"
        Me.ChkExtensible.Name = "ChkExtensible"
        Me.ChkExtensible.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ChkExtensible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ChkExtensible.Width = 60
        '
        'ToolNew
        '
        Me.ToolNew.Enabled = False
        Me.ToolNew.ForeColor = System.Drawing.Color.Black
        Me.ToolNew.Image = CType(resources.GetObject("ToolNew.Image"), System.Drawing.Image)
        Me.ToolNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNew.Name = "ToolNew"
        Me.ToolNew.Size = New System.Drawing.Size(74, 22)
        Me.ToolNew.Tag = "NO"
        Me.ToolNew.Text = "新 增(&N)"
        Me.ToolNew.ToolTipText = "新 增"
        '
        'ToolEdit
        '
        Me.ToolEdit.Enabled = False
        Me.ToolEdit.ForeColor = System.Drawing.Color.Black
        Me.ToolEdit.Image = CType(resources.GetObject("ToolEdit.Image"), System.Drawing.Image)
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(71, 22)
        Me.ToolEdit.Tag = "NO"
        Me.ToolEdit.Text = "修 改(&E)"
        Me.ToolEdit.ToolTipText = "修 改"
        '
        'ToolCommit
        '
        Me.ToolCommit.Image = CType(resources.GetObject("ToolCommit.Image"), System.Drawing.Image)
        Me.ToolCommit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolCommit.Name = "ToolCommit"
        Me.ToolCommit.Size = New System.Drawing.Size(68, 22)
        Me.ToolCommit.Tag = ""
        Me.ToolCommit.Text = "提交(&C)"
        Me.ToolCommit.ToolTipText = "提交"
        '
        'ToolBack
        '
        Me.ToolBack.Enabled = False
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolExit
        '
        Me.ToolExit.ForeColor = System.Drawing.Color.Black
        Me.ToolExit.Image = CType(resources.GetObject("ToolExit.Image"), System.Drawing.Image)
        Me.ToolExit.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolExit.Name = "ToolExit"
        Me.ToolExit.Size = New System.Drawing.Size(72, 22)
        Me.ToolExit.Text = "退 出(&X)"
        Me.ToolExit.ToolTipText = "退 出"
        '
        'ToolBt
        '
        Me.ToolBt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolNew, Me.ToolEdit, Me.ToolCommit, Me.ToolBack, Me.ToolStripSeparator2, Me.ToolQuery, Me.ToolExit})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(445, 25)
        Me.ToolBt.TabIndex = 139
        Me.ToolBt.Text = "ToolStrip1"
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(288, 49)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(658, 23)
        Me.lblMessage.TabIndex = 140
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "料件编号"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 90
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "父料件号"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "物料描述"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "状态"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtPartId)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolBt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblMessage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelX2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMOId)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.chbListSelect)
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvBomList)
        Me.SplitContainer1.Size = New System.Drawing.Size(1185, 479)
        Me.SplitContainer1.SplitterDistance = 109
        Me.SplitContainer1.TabIndex = 142
        '
        'FrmAssemblySetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1185, 479)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmAssemblySetting"
        Me.Text = "物料装配设置"
        CType(Me.dgvBomList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPartId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtMOId As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chbListSelect As System.Windows.Forms.CheckBox
    Friend WithEvents dgvBomList As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ToolNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolCommit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents ChkSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ParentPartId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChKisUpload As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ChkAssemble As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ChkIsLot As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ChkTransData As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ChkMaterialCheck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ChkAlter As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ChkExtensible As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
