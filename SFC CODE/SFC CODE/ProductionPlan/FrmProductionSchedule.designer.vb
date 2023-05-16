<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductionSchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductionSchedule))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.toolAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolEdit = New System.Windows.Forms.ToolStripButton()
        Me.toolAbandon = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolQuery = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImport = New System.Windows.Forms.ToolStripButton()
        Me.toolExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolClass = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.txtLine = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.gridView = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.DeptID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClassName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductiveValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManpowerValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDept = New System.Windows.Forms.TextBox()
        Me.txtMans = New System.Windows.Forms.TextBox()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.ToolBt.SuspendLayout()
        CType(Me.gridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAdd, Me.ToolEdit, Me.toolAbandon, Me.ToolStripSeparator1, Me.toolSave, Me.ToolBack, Me.ToolStripSeparator3, Me.ToolQuery, Me.ToolStripSeparator2, Me.toolImport, Me.toolExport, Me.ToolStripSeparator5, Me.toolClass, Me.ToolStripSeparator4, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1217, 25)
        Me.ToolBt.TabIndex = 139
        Me.ToolBt.Text = "ToolStrip1"
        '
        'toolAdd
        '
        Me.toolAdd.ForeColor = System.Drawing.Color.Black
        Me.toolAdd.Image = CType(resources.GetObject("toolAdd.Image"), System.Drawing.Image)
        Me.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAdd.Name = "toolAdd"
        Me.toolAdd.Size = New System.Drawing.Size(74, 22)
        Me.toolAdd.Tag = "NO"
        Me.toolAdd.Text = "新 增(&N)"
        Me.toolAdd.ToolTipText = "新 增"
        '
        'ToolEdit
        '
        Me.ToolEdit.ForeColor = System.Drawing.Color.Black
        Me.ToolEdit.Image = CType(resources.GetObject("ToolEdit.Image"), System.Drawing.Image)
        Me.ToolEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolEdit.Name = "ToolEdit"
        Me.ToolEdit.Size = New System.Drawing.Size(71, 22)
        Me.ToolEdit.Tag = "NO"
        Me.ToolEdit.Text = "修 改(&E)"
        Me.ToolEdit.ToolTipText = "修 改"
        '
        'toolAbandon
        '
        Me.toolAbandon.Image = CType(resources.GetObject("toolAbandon.Image"), System.Drawing.Image)
        Me.toolAbandon.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAbandon.Name = "toolAbandon"
        Me.toolAbandon.Size = New System.Drawing.Size(69, 22)
        Me.toolAbandon.Tag = "Yes"
        Me.toolAbandon.Text = "删除(&D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolSave
        '
        Me.toolSave.Image = CType(resources.GetObject("toolSave.Image"), System.Drawing.Image)
        Me.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSave.Name = "toolSave"
        Me.toolSave.Size = New System.Drawing.Size(67, 22)
        Me.toolSave.Tag = ""
        Me.toolSave.Text = "保存(&S)"
        Me.toolSave.ToolTipText = "提交"
        '
        'ToolBack
        '
        Me.ToolBack.Image = CType(resources.GetObject("ToolBack.Image"), System.Drawing.Image)
        Me.ToolBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolBack.Name = "ToolBack"
        Me.ToolBack.Size = New System.Drawing.Size(68, 22)
        Me.ToolBack.Text = "返回(&B)"
        Me.ToolBack.ToolTipText = "返回"
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'toolClass
        '
        Me.toolClass.Image = CType(resources.GetObject("toolClass.Image"), System.Drawing.Image)
        Me.toolClass.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolClass.Name = "toolClass"
        Me.toolClass.Size = New System.Drawing.Size(76, 22)
        Me.toolClass.Tag = "NO"
        Me.toolClass.Text = "班别维护"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'txtLine
        '
        '
        '
        '
        Me.txtLine.BackgroundStyle.Class = "TextBoxBorder"
        Me.txtLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLine.ButtonCustom.Visible = True
        Me.txtLine.Location = New System.Drawing.Point(86, 35)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(118, 21)
        Me.txtLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtLine.TabIndex = 152
        Me.txtLine.Text = ""
        '
        'gridView
        '
        Me.gridView.AllowUserToAddRows = False
        Me.gridView.AllowUserToDeleteRows = False
        Me.gridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridView.ColumnHeadersHeight = 28
        Me.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DeptID, Me.LineId, Me.ClassName, Me.ProductiveValue, Me.ManpowerValue, Me.CreateUserId, Me.CreateTime})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(139, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridView.EnableHeadersVisualStyles = False
        Me.gridView.GridColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.gridView.Location = New System.Drawing.Point(0, 105)
        Me.gridView.Name = "gridView"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gridView.RowHeadersWidth = 15
        Me.gridView.RowTemplate.Height = 23
        Me.gridView.Size = New System.Drawing.Size(1217, 351)
        Me.gridView.TabIndex = 150
        '
        'DeptID
        '
        Me.DeptID.DataPropertyName = "DEPTID"
        Me.DeptID.HeaderText = "部门"
        Me.DeptID.Name = "DeptID"
        Me.DeptID.ReadOnly = True
        Me.DeptID.Width = 80
        '
        'LineId
        '
        Me.LineId.DataPropertyName = "LineId"
        Me.LineId.HeaderText = "产线"
        Me.LineId.Name = "LineId"
        Me.LineId.ReadOnly = True
        Me.LineId.Width = 80
        '
        'ClassName
        '
        Me.ClassName.DataPropertyName = "ClassName"
        Me.ClassName.HeaderText = "时段名称"
        Me.ClassName.Name = "ClassName"
        Me.ClassName.ReadOnly = True
        Me.ClassName.Width = 80
        '
        'ProductiveValue
        '
        Me.ProductiveValue.DataPropertyName = "ProductiveValue"
        Me.ProductiveValue.HeaderText = "生产效率"
        Me.ProductiveValue.Name = "ProductiveValue"
        Me.ProductiveValue.ReadOnly = True
        Me.ProductiveValue.Width = 80
        '
        'ManpowerValue
        '
        Me.ManpowerValue.DataPropertyName = "ManpowerValue"
        Me.ManpowerValue.HeaderText = "人力"
        Me.ManpowerValue.Name = "ManpowerValue"
        Me.ManpowerValue.ReadOnly = True
        Me.ManpowerValue.Width = 60
        '
        'CreateUserId
        '
        Me.CreateUserId.DataPropertyName = "CreateUserId"
        Me.CreateUserId.HeaderText = "创建用户"
        Me.CreateUserId.Name = "CreateUserId"
        Me.CreateUserId.ReadOnly = True
        '
        'CreateTime
        '
        Me.CreateTime.DataPropertyName = "CreateTime"
        Me.CreateTime.HeaderText = "创建时间"
        Me.CreateTime.Name = "CreateTime"
        Me.CreateTime.ReadOnly = True
        '
        'txtDept
        '
        Me.txtDept.Enabled = False
        Me.txtDept.Location = New System.Drawing.Point(316, 35)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.ReadOnly = True
        Me.txtDept.Size = New System.Drawing.Size(100, 21)
        Me.txtDept.TabIndex = 167
        '
        'txtMans
        '
        Me.txtMans.Location = New System.Drawing.Point(316, 62)
        Me.txtMans.Name = "txtMans"
        Me.txtMans.Size = New System.Drawing.Size(100, 21)
        Me.txtMans.TabIndex = 167
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(503, 63)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(100, 21)
        Me.txtRate.TabIndex = 167
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(251, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 168
        Me.Label2.Text = "部门编号："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 12)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "时段名称："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 168
        Me.Label4.Text = "产线："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(275, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 168
        Me.Label5.Text = "人力："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(432, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 12)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "生产效率："
        '
        'cmbClass
        '
        Me.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(86, 62)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(118, 20)
        Me.cmbClass.TabIndex = 169
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMsg.Location = New System.Drawing.Point(823, 68)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(53, 12)
        Me.LblMsg.TabIndex = 170
        Me.LblMsg.Text = "操作成功"
        '
        'FrmProductionSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 457)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.cmbClass)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMans)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.txtDept)
        Me.Controls.Add(Me.txtLine)
        Me.Controls.Add(Me.gridView)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmProductionSchedule"
        Me.ShowIcon = False
        Me.Text = "生产维护"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.gridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolQuery As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtLine As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents gridView As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents txtMans As System.Windows.Forms.TextBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbClass As System.Windows.Forms.ComboBox
    Friend WithEvents toolSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolAbandon As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolClass As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClassName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductiveValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ManpowerValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
