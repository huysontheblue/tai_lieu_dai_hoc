<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanUpload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlanUpload))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolExitFrom = New System.Windows.Forms.ToolStripButton()
        Me.ToolBt = New System.Windows.Forms.ToolStrip()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnChild = New System.Windows.Forms.Button()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMO = New System.Windows.Forms.Button()
        Me.txtMOFile = New System.Windows.Forms.TextBox()
        Me.lblMessage = New DevComponents.DotNetBar.LabelX()
        Me.dgvProductionPlanItem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.RowNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductionPlanId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AssignLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChildMOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComponentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChildQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolBt.SuspendLayout()
        CType(Me.dgvProductionPlanItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolBt
        '
        Me.ToolBt.AutoSize = False
        Me.ToolBt.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ToolBt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ToolStripSeparator1, Me.ToolExitFrom})
        Me.ToolBt.Location = New System.Drawing.Point(0, 0)
        Me.ToolBt.Name = "ToolBt"
        Me.ToolBt.Size = New System.Drawing.Size(1144, 25)
        Me.ToolBt.TabIndex = 141
        Me.ToolBt.Text = "ToolStrip1"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnChild
        '
        Me.btnChild.Location = New System.Drawing.Point(308, 78)
        Me.btnChild.Name = "btnChild"
        Me.btnChild.Size = New System.Drawing.Size(75, 23)
        Me.btnChild.TabIndex = 142
        Me.btnChild.Text = "上传"
        Me.btnChild.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(139, 80)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(163, 21)
        Me.txtFileName.TabIndex = 143
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "工单上传："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "子键上传："
        '
        'btnMO
        '
        Me.btnMO.Location = New System.Drawing.Point(308, 35)
        Me.btnMO.Name = "btnMO"
        Me.btnMO.Size = New System.Drawing.Size(75, 23)
        Me.btnMO.TabIndex = 142
        Me.btnMO.Text = "上传"
        Me.btnMO.UseVisualStyleBackColor = True
        '
        'txtMOFile
        '
        Me.txtMOFile.Location = New System.Drawing.Point(139, 37)
        Me.txtMOFile.Name = "txtMOFile"
        Me.txtMOFile.Size = New System.Drawing.Size(163, 21)
        Me.txtMOFile.TabIndex = 143
        '
        'lblMessage
        '
        '
        '
        '
        Me.lblMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMessage.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(738, 69)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(394, 23)
        Me.lblMessage.TabIndex = 229
        '
        'dgvProductionPlanItem
        '
        Me.dgvProductionPlanItem.AllowUserToAddRows = False
        Me.dgvProductionPlanItem.AllowUserToDeleteRows = False
        Me.dgvProductionPlanItem.BackgroundColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductionPlanItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProductionPlanItem.ColumnHeadersHeight = 32
        Me.dgvProductionPlanItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProductionPlanItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RowNum, Me.ProductionPlanId, Me.AssignLine, Me.MOId, Me.ChildMOID, Me.ComponentID, Me.ChildQTY, Me.Remark})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductionPlanItem.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProductionPlanItem.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvProductionPlanItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvProductionPlanItem.Location = New System.Drawing.Point(0, 126)
        Me.dgvProductionPlanItem.Name = "dgvProductionPlanItem"
        Me.dgvProductionPlanItem.RowHeadersWidth = 15
        Me.dgvProductionPlanItem.RowTemplate.Height = 28
        Me.dgvProductionPlanItem.Size = New System.Drawing.Size(1144, 336)
        Me.dgvProductionPlanItem.TabIndex = 230
        Me.dgvProductionPlanItem.Visible = False
        '
        'RowNum
        '
        Me.RowNum.DataPropertyName = "RowNum"
        Me.RowNum.HeaderText = "序号"
        Me.RowNum.Name = "RowNum"
        Me.RowNum.ReadOnly = True
        '
        'ProductionPlanId
        '
        Me.ProductionPlanId.DataPropertyName = "AssignDate"
        Me.ProductionPlanId.HeaderText = "派工日期"
        Me.ProductionPlanId.Name = "ProductionPlanId"
        Me.ProductionPlanId.ReadOnly = True
        '
        'AssignLine
        '
        Me.AssignLine.DataPropertyName = "AssignLine"
        Me.AssignLine.HeaderText = "派工线体"
        Me.AssignLine.Name = "AssignLine"
        Me.AssignLine.ReadOnly = True
        '
        'MOId
        '
        Me.MOId.DataPropertyName = "MOId"
        Me.MOId.HeaderText = "工单"
        Me.MOId.Name = "MOId"
        Me.MOId.ReadOnly = True
        Me.MOId.Width = 120
        '
        'ChildMOID
        '
        Me.ChildMOID.DataPropertyName = "ChildMOID"
        Me.ChildMOID.HeaderText = "子工单"
        Me.ChildMOID.Name = "ChildMOID"
        Me.ChildMOID.ReadOnly = True
        '
        'ComponentID
        '
        Me.ComponentID.DataPropertyName = "ComponentID"
        Me.ComponentID.HeaderText = "元件编码"
        Me.ComponentID.Name = "ComponentID"
        Me.ComponentID.ReadOnly = True
        '
        'ChildQTY
        '
        Me.ChildQTY.DataPropertyName = "ChildQTY"
        Me.ChildQTY.HeaderText = "生产数量"
        Me.ChildQTY.Name = "ChildQTY"
        Me.ChildQTY.ReadOnly = True
        Me.ChildQTY.Width = 80
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "备注"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        '
        'FrmPlanUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 462)
        Me.Controls.Add(Me.dgvProductionPlanItem)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMOFile)
        Me.Controls.Add(Me.btnMO)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.btnChild)
        Me.Controls.Add(Me.ToolBt)
        Me.Name = "FrmPlanUpload"
        Me.Text = "上传派工计划"
        Me.ToolBt.ResumeLayout(False)
        Me.ToolBt.PerformLayout()
        CType(Me.dgvProductionPlanItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolExitFrom As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolBt As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnChild As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMO As System.Windows.Forms.Button
    Friend WithEvents txtMOFile As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgvProductionPlanItem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents RowNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductionPlanId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AssignLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChildMOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChildQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
